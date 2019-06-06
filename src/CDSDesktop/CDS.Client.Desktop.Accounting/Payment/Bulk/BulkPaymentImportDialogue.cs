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


namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    public partial class BulkPaymentImportDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private DataTable tblFields = null;
        private List<BulkPaymentEntry> bulkentries = null;
        private char[] trimcharacters = new char[] { ' ', '\'', '"' };
        private List<Int64> accountFiter;
        private List<string> skippedAccounts = new List<string>();

        public Int64 AccountId
        {
            get
            {
                return Convert.ToInt64(ddlAccount.EditValue);
            }
        }

        public List<BulkPaymentEntry> Data
        {
            get
            {
                return bulkentries;
            }
        }

        public List<string> SkippedAccounts
        {
            get { return skippedAccounts; }
        }

        public BulkPaymentImportDialogue()
        {
            InitializeComponent();
        }

        public BulkPaymentImportDialogue(List<BulkPaymentEntry> bulkentries, List<Int64> accountFiter)
        {
            InitializeComponent();
            this.bulkentries = bulkentries;
            this.bulkentries.Clear();
            this.accountFiter = accountFiter;
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
                tblFields.Rows.Add(new object[] { "Account", "" });
                tblFields.Rows.Add(new object[] { "Reference", "" });
                tblFields.Rows.Add(new object[] { "Description", "" });
                tblFields.Rows.Add(new object[] { "Aging", "" });
                tblFields.Rows.Add(new object[] { "Amount", "" });

                grdFields.DataSource = tblFields;

                if (accountFiter == null)
                    ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.CodeSub == "00000");
                else
                    ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => accountFiter.Contains(n.Id));
                
                ServerModeSourcePeriod.QueryableSource = DataContext.EntitySystemContext.SYS_Period.Where(n => n.StatusId != 51).OrderByDescending(n => n.StartDate);
                ServerModeSourceAging.QueryableSource = DataContext.EntityAccountingContext.GLX_Aging;
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
                bulkentries.Clear();

                using (CsvReader csv = new CsvReader(new StreamReader((String)txtFile.EditValue), true, ddlSeperator.Text[0], CsvReader.DefaultQuote, CsvReader.DefaultEscape, CsvReader.DefaultComment, true))
                {
                    while (csv.ReadNextRecord())
                    {
                        try
                        {
                            DB.VW_Account Account = DataContext.ReadonlyContext.VW_Account
                                .Where(n => n.Archived.Equals(false) 
                                    && n.CodeSub.Equals(tblFields.Rows[1][1].ToString() != "<NOT MAPPED>" ? ParseString(csv[tblFields.Rows[1][1].ToString()]) : "")).FirstOrDefault();

                            DB.GLX_Aging aging = DataContext.EntityAccountingContext.GLX_Aging
                                .Where(n => n.Code.Contains(tblFields.Rows[4][1].ToString() != "<NOT MAPPED>" ? ParseString(csv[tblFields.Rows[4][1].ToString()]) : "")).OrderBy(o => o.Id)
                                .FirstOrDefault();

                            //TODO : Need to make this so that you can choose account on Payment/Receipt screens
                            if (Account == null)
                            {
                                skippedAccounts.Add(tblFields.Rows[1][1].ToString() != "<NOT MAPPED>" ? ParseString(csv[tblFields.Rows[1][1].ToString()]) : "");
                                continue;
                            }

                            bulkentries.Add(new BulkPaymentEntry()
                            {
                                //PeriodId = DB.SYS_PeriodGetCurrentPeriod().Id,
                                PeriodId = Convert.ToInt64(ddlPeriod.EditValue),
                                Date = tblFields.Rows[0][1].ToString() != "<NOT MAPPED>" ? ParseDate(csv[tblFields.Rows[0][1].ToString()]) : DateTime.Now,
                                AccountId = Account != null ? (Int64?)Account.Id : null,
                                Reference = tblFields.Rows[2][1].ToString() != "<NOT MAPPED>" ? ParseString(csv[tblFields.Rows[2][1].ToString()]) : "",
                                Description = tblFields.Rows[3][1].ToString() != "<NOT MAPPED>" ? ParseString(csv[tblFields.Rows[3][1].ToString()]) : "",
                                AgingId = aging != null ? aging.Id : (Int16)1,
                                Settlement =  0,
                                Amount =  tblFields.Rows[5][1].ToString() != "<NOT MAPPED>" ? ParseDecimal(csv[tblFields.Rows[5][1].ToString()]) * (chkReverseAmounts.Checked ? -1 : 1) : 0
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
                    var qry = ((IQueryable<BulkPaymentEntry>)bulkentries.AsQueryable().AppendWhere(converter, filRule.FilterCriteria)).ToList();

                    if (rule.EntryAction == "N")
                    {
                        // Do not import
                        foreach (BulkPaymentEntry row in qry)
                        {
                            bulkentries.Remove(row);
                        }
                    }
                    else if (rule.EntryAction == "Y")
                    {
                        // Import
                        foreach (BulkPaymentEntry row in qry)
                        {
                            row.AccountId = rule.EntityContraId;
                        }
                    }
                }

                // Get taxes
                List<DB.GLX_Tax> taxes = DataContext.EntityAccountingContext.GLX_Tax.ToList();

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
                            tblFields.Rows[1][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("ACC")) ?? "<NOT MAPPED>";
                            tblFields.Rows[2][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("REF")) ?? "<NOT MAPPED>";
                            tblFields.Rows[3][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("DESCRIPTION")) ?? "<NOT MAPPED>";
                            tblFields.Rows[4][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("AGI")) ?? "<NOT MAPPED>";
                            tblFields.Rows[5][1] = headers.FirstOrDefault(n => n.ToUpper().Contains("AMOUNT")) ?? "<NOT MAPPED>";
                        }
                        ddlAccount.Focus();
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
