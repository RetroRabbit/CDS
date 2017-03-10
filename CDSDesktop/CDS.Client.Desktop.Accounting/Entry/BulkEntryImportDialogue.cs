using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.Data;
using DevExpress.Data.Helpers;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Linq;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using CDS.Client.Desktop.Accounting.Entry;


namespace CDS.Client.Desktop.Accounting.Entry
{
    public partial class BulkEntryImportDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private DataTable tblFields = null;
        private List<BulkEntry> bulkentries = null;
        private char[] trimcharacters = new char[] { ' ', '\'', '"' };
        
        public Int64 AccountId
        {
            get
            {
                return Convert.ToInt64(ddlAccount.EditValue);
            }
        }

        public List<BulkEntry> Data
        {
            get
            {
                return bulkentries;
            }
        }

        public BulkEntryImportDialogue()
        {
            InitializeComponent();
        }

        public BulkEntryImportDialogue(List<BulkEntry> bulkentries)
        {
            InitializeComponent();
            this.bulkentries = bulkentries;
            this.bulkentries.Clear();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                tblFields = new DataTable();
                tblFields.Columns.Add("colField", typeof(string));
                tblFields.Columns.Add("colMappedField", typeof(string));

                tblFields.Rows.Add(new object[] { "Date", "" });
                tblFields.Rows.Add(new object[] { "Reference", "" });
                tblFields.Rows.Add(new object[] { "Description", "" });
                tblFields.Rows.Add(new object[] { "Amount", "" });

                grdFields.DataSource = tblFields;

                ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.CodeSub == "00000");
                ServerModeSourcePeriod.QueryableSource = DataContext.ReadonlyContext.VW_Period.Where(n => n.Status != "Closed").OrderByDescending(n => n.StartDate);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private DateTime ParseDate(String input)
        {
            DateTime result = DateTime.ParseExact(input.Trim(trimcharacters), ddlDateFormat.Text, System.Globalization.CultureInfo.InvariantCulture);
            return result;
        }

        private String ParseString(String input)
        {
            String result = input.Trim(trimcharacters);
            return result;
        }

        private Decimal ParseDecimal(String input)
        {
            Decimal result = Decimal.Parse(input.Trim(trimcharacters).Replace(" ", ""), System.Globalization.CultureInfo.InvariantCulture);
            return result;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!ValidationProvider.Validate())
                return;

            try
            {
                

                using (CsvReader csv = new CsvReader(new StreamReader((String)txtFile.EditValue), true, ddlSeperator.Text[0], CsvReader.DefaultQuote, CsvReader.DefaultEscape, CsvReader.DefaultComment, true))
                {
                    while (csv.ReadNextRecord())
                    {
                        try
                        {
                            bulkentries.Add(new BulkEntry()
                            {
                                //PeriodId = DB.VW_PeriodGetCurrentPeriod().Id,
                                PeriodId = Convert.ToInt64(ddlPeriod.EditValue),
                                Date = tblFields.Rows[0][1].ToString() != "<NOT MAPPED>" ? ParseDate(csv[tblFields.Rows[0][1].ToString()]) : DateTime.Now,
                                AccountId = null,
                                AgingId = 1,
                                Reference = tblFields.Rows[1][1].ToString() != "<NOT MAPPED>" ? ParseString(csv[tblFields.Rows[1][1].ToString()]) : "",
                                Description = tblFields.Rows[2][1].ToString() != "<NOT MAPPED>" ? ParseString(csv[tblFields.Rows[2][1].ToString()]) : "",
                                TaxId = 1,
                                Exclusive = 0,
                                Inclusive = tblFields.Rows[3][1].ToString() != "<NOT MAPPED>" ? ParseDecimal(csv[tblFields.Rows[3][1].ToString()]) * (chkReverseAmounts.Checked ? -1 : 1) : 0
                            });
                        }
                        catch (Exception)
                        {
                            String [] rowdata = new string[csv.FieldCount];
                            csv.CopyCurrentRecordTo(rowdata);
                            CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Parsing Error", String.Format("There was a problem reading a value from the row and the import will not continue. The row data provided: \n{0}.", String.Join(ddlSeperator.Text, rowdata)), Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Warning);
                            return;
                        }
                    }
                }

                CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
                DevExpress.XtraFilterEditor.FilterEditorControl filRule = new DevExpress.XtraFilterEditor.FilterEditorControl();
                foreach (DB.GLX_BulkEntryRule rule in DataContext.EntityAccountingContext.GLX_BulkEntryRule.Where(n => n.EntityId == (Int64)ddlAccount.EditValue))
                {
                    filRule.FilterString = rule.EntryRule;
                    filRule.ApplyFilter();

                    //http://www.devexpress.com/Support/Center/p/Q357031.aspx
                    var qry = ((IQueryable<BulkEntry>)bulkentries.AsQueryable().AppendWhere(converter, filRule.FilterCriteria)).ToList();

                    if (rule.EntryAction == "N")
                    {
                        // Do not import
                        foreach (BulkEntry row in qry)
                        {
                            bulkentries.Remove(row);
                        }
                    }
                    else if (rule.EntryAction == "N")
                    {
                        // Import
                        foreach (BulkEntry row in qry)
                        {
                            row.AccountId = rule.EntityContraId;
                            row.TaxId = rule.TaxId;
                        }
                    }
                }

                // Get taxes
                List<DB.GLX_Tax> taxes = DataContext.EntityAccountingContext.GLX_Tax.ToList();

                // Populate inclusive/exclusive amounts
                if (!chkExclusive.Checked)
                {
                    // Amounts include tax 
                    //exclusive = inclusive * 100/114
                    //exclusive = inclusive * 100/100+percentage
                    //                      * 1 / 1+percentage
                    foreach (BulkEntry row in bulkentries)
                    {
                        row.Exclusive = Math.Round(row.Inclusive.Value * 1.0m / (1.0m + taxes.FirstOrDefault(n => n.Id == row.TaxId).Percentage), 2, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    // Amounts exclude tax
                    //inclusive = exclusive * 114
                    //inclusive = exclusive * 100+percentage
                    //                      * 1+percentage
                    foreach (BulkEntry row in bulkentries)
                    {
                        row.Exclusive = row.Inclusive;
                        row.Inclusive = Math.Round(row.Exclusive.Value * (1.0m + taxes.FirstOrDefault(n => n.Id == row.TaxId).Percentage), 2, MidpointRounding.AwayFromZero);
                    }
                }

                // Populate periods
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void txtFile_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                // Open the file dialogue
                using (OpenFileDialog diag = new OpenFileDialog())
                {
                    diag.Filter = "CSV Files|*.csv|All Files|*.*";
                    diag.CheckPathExists = true;
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        txtFile.EditValue = diag.FileName;

                        using (CsvReader csv = new CsvReader(new StreamReader((String)txtFile.EditValue), true))
                        {
                            repositoryItemComboBoxMappedField.Items.Clear();
                            repositoryItemComboBoxMappedField.Items.Add("<NOT MAPPED>");

                            string[] headers = csv.GetFieldHeaders();
                            repositoryItemComboBoxMappedField.Items.AddRange(headers);

                            tblFields.Rows[0][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("DATE")) ?? "<NOT MAPPED>";
                            tblFields.Rows[1][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("REF")) ?? "<NOT MAPPED>";
                            tblFields.Rows[2][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("DESCRIPTION")) ?? "<NOT MAPPED>";
                            tblFields.Rows[3][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("AMOUNT")) ?? "<NOT MAPPED>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

   
    }
}
