using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;


namespace CDS.Client.Desktop.Accounting.Entry
{
    public partial class BulkEntryForm : CDS.Client.Desktop.Essential.BaseForm
    {
        private List<DB.GLX_Tax> taxes = null;
        private List<BulkEntry> bulkentries = null;
        private long? defaultSiteId;
        public BulkEntryForm()
        {
            InitializeComponent();
        }         

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            //This is a fake bindingsource to bind status and tracking number to
            BindingSourceHeader.DataSource = BL.GLX.GLX_Header.New;

            ((DataAccessLayer.DB.GLX_Header)BindingSourceHeader.DataSource).TrackId = -1;

            taxes = DataContext.EntityAccountingContext.GLX_Tax.ToList();
            bulkentries = new List<BulkEntry>();

            ServerModeSourceTax.QueryableSource = taxes.AsQueryable();
            dtDate.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;

            if (BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.FIENRE02))
            {
                chkAutoPost.Enabled = true;
                chkAutoPost.Properties.ReadOnly = false;
                chkAutoPost.Checked = true;
            }
            BindingSource.DataSource = bulkentries;
        }

        protected override void OnStart()
        {
            try
            {
                defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                //This is a fake bindingsource to bind status and tracking number to
                BindingSourceHeader.DataSource = BL.GLX.GLX_Header.New;

                ((DataAccessLayer.DB.GLX_Header)BindingSourceHeader.DataSource).TrackId = -1;
                base.OnStart();

                taxes = DataContext.EntityAccountingContext.GLX_Tax.ToList();
                bulkentries = new List<BulkEntry>();

                ServerModeSourcePeriod.QueryableSource = DataContext.EntitySystemContext.SYS_Period.Where(n => n.StatusId == 50);
                ServerModeSourceStatus.QueryableSource = DataContext.EntitySystemContext.SYS_Status;

                if ((BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRE03)))    // Harcoded Access: FIEN05 = 544, // Write to Control accounts )
            {
                   
                //Check for Master accountant
                if(!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR))
                    ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.SiteId == defaultSiteId);
                else
                    ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);

            }
            else
            {
                //Check for Master accountant
                if (!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR))
                    ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && n.CodeSub != "00000" && n.SiteId == defaultSiteId);
                else
                    ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && n.CodeSub != "00000");
            }

                ServerModeSourceAging.QueryableSource = DataContext.EntityAccountingContext.GLX_Aging;
                ServerModeSourceTax.QueryableSource = taxes.AsQueryable();
                dtDate.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
                dtDate.MinValue = DataContext.ReadonlyContext.VW_Period.OrderBy(o => o.StartDate).Where(n => n.Status == "Open").Select(n=>n.StartDate).FirstOrDefault();
                dtDate.MaxValue = DataContext.ReadonlyContext.VW_Period.OrderByDescending(o => o.EndDate).Where(n => n.Status == "Open").Select(n=>n.EndDate).FirstOrDefault();
                
                //tblImportData = new DataTable();
                //tblImportData.Columns.Add("colPeriod", typeof(Int64));
                //tblImportData.Columns.Add("colDate", typeof(DateTime));
                //tblImportData.Columns.Add("colAccount", typeof(Int64));
                //tblImportData.Columns.Add("colReference", typeof(String));
                //tblImportData.Columns.Add("colDescription", typeof(String));
                //tblImportData.Columns.Add("colTax", typeof(Int16));
                //tblImportData.Columns.Add("colExclusive", typeof(Decimal));
                //tblImportData.Columns.Add("colInclusive", typeof(Decimal));

                if (BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.FIENRE02))
                {
                    chkAutoPost.Enabled = true;
                    chkAutoPost.Properties.ReadOnly = false;
                    chkAutoPost.Checked = true;
                }
                BindingSource.DataSource = bulkentries;
         
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    if (!IsValid)
                    {
                        CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Error", "Please ensure that all Periods, Contra Accounts and References have been filled in.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        return false;
                    }

                    if (CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Process Bulk Entries", "You are about to create multiple entries.\nAre you certain you wish to continue?", CDS.Client.Desktop.Essential.BaseAlert.Buttons.OkCancel, CDS.Client.Desktop.Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            using (TransactionScope transaction = DataContext.GetTransactionScope())
                            {
                                // Create Records for all entries...
                                foreach (BulkEntry entry in bulkentries)
                                {
                                    DB.GLX_Header glx_header = BL.GLX.GLX_Header.New;
                                    glx_header.Date = entry.Date.Value;
                                    glx_header.Description = entry.Description;
                                    glx_header.Reference = entry.Reference;
                                    glx_header.PeriodId = DataContext.ReadonlyContext.VW_Period.Where(n => glx_header.Date >= n.StartDate && glx_header.Date < n.EndDate).Select(n=>n.Id).FirstOrDefault(); //entry.PeriodId.Value;
                                    glx_header.ReferencePeriodId = glx_header.PeriodId;
                                    glx_header.PostedDate = BL.ApplicationDataContext.Instance.ServerDateTime.Date;
                                    glx_header.TrackId = ((DataAccessLayer.DB.GLX_Header)BindingSourceHeader.DataSource).TrackId;
                                    glx_header.StatusId = chkAutoPost.Checked ? (byte)BL.SYS.SYS_Status.Posted : (byte)BL.SYS.SYS_Status.Unposted;
                                    glx_header.JournalTypeId = (byte)BL.GLX.GLX_JournalType.BulkJournal;

                                    // TOTAL
                                    DB.GLX_Line glx_line_total = BL.GLX.GLX_Line.New;
                                    glx_line_total.EntityId = (Int64)ddlAccount.EditValue;// DataAccessLayer.ApplicationContext.Instance.CompanySite.glx_Debtors;
                                    //CURRENT
                                    glx_line_total.AgingId = Convert.ToByte(ddlAging.EditValue);
                                    glx_line_total.Amount = -entry.Inclusive.Value;
                                    glx_line_total.CenterId = DataContext.ReadonlyContext.VW_Account.Where(n => n.Id == glx_line_total.EntityId).Select(n => n.CenterId).FirstOrDefault();

                                    // EXCL
                                    DB.GLX_Line glx_line_excl = BL.GLX.GLX_Line.New;
                                    glx_line_excl.EntityId = entry.AccountId.Value;// DataAccessLayer.ApplicationContext.Instance.CompanySite.glx_Debtors;
                                    //CURRENT
                                    glx_line_excl.AgingId = entry.AgingId.Value;
                                    glx_line_excl.Amount = entry.Exclusive.Value;
                                    glx_line_excl.CenterId = DataContext.ReadonlyContext.VW_Account.Where(n => n.Id == glx_line_excl.EntityId).Select(n => n.CenterId).FirstOrDefault();

                                    glx_header.GLX_Line.Add(glx_line_total);
                                    glx_header.GLX_Line.Add(glx_line_excl);

                                    if (entry.Inclusive != entry.Exclusive)
                                    {
                                        // TAX
                                        DB.GLX_Line glx_line_tax = BL.GLX.GLX_Line.New;
                                        glx_line_tax.EntityId = DataContext.EntityAccountingContext.GLX_Tax.Where(n => n.Id == entry.TaxId.Value).Select(n => n.EntityId.Value).FirstOrDefault(); //DataAccessLayer.ApplicationContext.Instance.CompanySite.glx_VatAccount;
                                        //CURRENT
                                        glx_line_tax.AgingId = entry.AgingId.Value;
                                        glx_line_tax.Amount = (entry.Inclusive.Value - entry.Exclusive.Value);
                                        glx_line_tax.CenterId = DataContext.ReadonlyContext.VW_Account.Where(n => n.Id == glx_line_tax.EntityId).Select(n => n.CenterId).FirstOrDefault();

                                        glx_header.GLX_Line.Add(glx_line_tax);
                                    }

                                    //TODO: Need to check that this works
                                    //DataContext.EntityAccountingContext.BeginTransaction();
                                    glx_header.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Journal;

                                    if (!glx_header.IsYearendHeader)
                                        BL.GLX.GLX_Header.InsertProfitDistributionEntries(glx_header, DataContext);
                                    DB.SYS_Tracking tracking = BL.SYS.SYS_Tracking.New;
                                    BL.EntityController.SaveSYS_Tracking(tracking, DataContext);
                                    DataContext.SaveChangesEntitySystemContext();
                                    glx_header.TrackId = tracking.Id;
                                    BL.EntityController.SaveGLX_Header(glx_header, DataContext);
                                    DataContext.SaveChangesEntityAccountingContext();
                                    if (chkAutoPost.Checked)
                                        BL.GLX.GLX_Header.UpdateLedgerAccountBalance(glx_header, DataContext);

                                }
                                DataContext.CompleteTransaction(transaction);
                            }
                            DataContext.EntitySystemContext.AcceptAllChanges();
                            DataContext.EntityAccountingContext.AcceptAllChanges();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            DataContext.EntitySystemContext.RejectChanges();
                            DataContext.EntityAccountingContext.RejectChanges();
                            HasErrors = true;
                            if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                            return false;
                        }
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                 bool isValid = true;
                 isValid = HasEntries() && HasValidContraAccounts() && HasValidReference() && HasValidDescription();
                 return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasValidAccount()
        {
            try
            {
                if ((Int64)ddlAccount.EditValue == -1)
                {
                    ddlAccount.ErrorText = "Please select an Account.";
                    return false;
                }
                else
                {
                    ddlAccount.ErrorText = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasValidContraAccounts()
        {
            try
            {
                return bulkentries.Where(n => n.AccountId == null || n.AccountId == 0).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasValidPeriods()
        {
            try
            {
                return bulkentries.Where(n => n.PeriodId == null || n.PeriodId == 0).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasEntries()
        {
            try
            {
                return bulkentries.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasValidReference()
        {
            try
            {
                return bulkentries.Where(n => n.Reference == null).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasValidDescription()
        {
            try
            {
                return bulkentries.Where(n => n.Description == null).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRE06);
        }
                
        private void btnBulkEntryRules_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new BulkEntryRuleDialogue().ShowDialog(this);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnImportStatement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                BulkEntryImportDialogue dialogue = new BulkEntryImportDialogue(bulkentries);
                if (dialogue.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ddlAccount.EditValue = dialogue.AccountId;
                    bulkentries = dialogue.Data;
                    grdEntries.RefreshDataSource();
                    grdEntries.Focus();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvEntries_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                BulkEntry row = (BulkEntry)grvEntries.GetRow(e.RowHandle);
                if (row.TaxId == null)
                {
                    row.Inclusive = Math.Round((row.Exclusive ?? 0) * (1.0m), 2, MidpointRounding.AwayFromZero);
                }
                else if (e.Column == colTax)
                {
                    // Tax type changed recalc exclusive based on inclusive
                    row.Exclusive = Math.Round((row.Inclusive ?? 0) * 1.0m / (1.0m + taxes.FirstOrDefault(n => n.Id == row.TaxId).Percentage), 2, MidpointRounding.AwayFromZero);
                }
                else if (e.Column == colExclusive)
                {
                    // Exclusive changed - recalc inclusive
                    row.Inclusive = Math.Round((row.Exclusive ?? 0) * (1.0m + taxes.FirstOrDefault(n => n.Id == row.TaxId).Percentage), 2, MidpointRounding.AwayFromZero);
                }
                else if (e.Column == colInclusive)
                {
                    // Inclusive changed - recalc exclusive
                    row.Exclusive = Math.Round((row.Inclusive ?? 0) * 1.0m / (1.0m + taxes.FirstOrDefault(n => n.Id == row.TaxId).Percentage), 2, MidpointRounding.AwayFromZero);
                } 
                txtTotal.EditValue = bulkentries.Sum(n => -n.Inclusive.Value);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grdEntries_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            //if (e.KeyData == Keys.Delete && ! (grvEntries.FocusedColumn == colExclusive || grvEntries.FocusedColumn == colInclusive))
            if (e.KeyData == Keys.Delete && view.State == GridState.Normal)
            {
                if (Essential.BaseAlert.ShowAlert("Confirm delete.", "You are about to delete the selected row do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    view.DeleteSelectedRows();
                    e.Handled = true;
                }
            }
        }

        private void grvEntries_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var current = DataContext.EntityAccountingContext.GLX_Aging.Where(n => n.Code.Equals("000")).FirstOrDefault();
                grvEntries.SetFocusedRowCellValue(grvEntries.Columns["AgingId"], current.Id);
                grvEntries.SetFocusedRowCellValue(grvEntries.Columns["Date"], DateTime.Now);
           
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        private void grvEntries_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                // The ledger account has been selected
                BulkEntry FocusedRow = grvEntries.GetFocusedRow() as BulkEntry;

                if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).FocusedValue == null || FocusedRow.AccountId == null)
                    return;

                if ((sender as DevExpress.XtraGrid.Views.Grid.GridView).FocusedColumn == colAgingId)
                {
                    

                    if (!( ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(ddlAccount.Properties.View.GetFocusedRow())).OriginalRow as DB.VW_Account).AgingAccount)
                    {
                        e.Cancel = true;
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void chkNewTrackNumber_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNewTrackNumber.Checked)
                {
                    ((DataAccessLayer.DB.GLX_Header)BindingSourceHeader.DataSource).TrackId = -1;
                    txtTrackNumber.Enabled = false;
                }
                else
                {
                    txtTrackNumber.Enabled = true;
                    if (((DataAccessLayer.DB.GLX_Header)BindingSourceHeader.DataSource).TrackId == -1)
                        ((DataAccessLayer.DB.GLX_Header)BindingSourceHeader.DataSource).TrackId = -1;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void chkAutoPost_CheckedChanged(object sender, EventArgs e)
        {
            ((DataAccessLayer.DB.GLX_Header)BindingSourceHeader.DataSource).StatusId = chkAutoPost.Checked == true ? Convert.ToByte(52) : Convert.ToByte(53);
        }

        private void ddlAccount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAccount.EditValue == null)
                    return;

                var current = DataContext.EntityAccountingContext.GLX_Aging.Where(n => n.Code.Equals("000")).FirstOrDefault();
                ddlAging.EditValue = current.Id;

                if (!( ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(ddlAccount.Properties.View.GetFocusedRow())).OriginalRow as DB.VW_Account).AgingAccount)
                {
                    ddlAging.Properties.Buttons[0].Visible = false;
                    ddlAging.Properties.ReadOnly = true;
                    ddlAging.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                }
                else
                {
                    ddlAging.Properties.Buttons[0].Visible = true;
                    ddlAging.Properties.ReadOnly = false;
                    ddlAging.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
                } 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvEntries_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            DB.VW_Validation validationReference = BL.ApplicationDataContext.Instance.ValidationRestrictions
                .Where(n => n.TableName.Equals("GLX_Header") && n.ColumnName.Equals("Reference")).FirstOrDefault();

            if (validationReference != null)
            {
                string reference = (string)((BulkEntry)(e.Row)).Reference;
                if ((reference == null && !validationReference.Nullable.Value) || (reference != null && reference.Length == 0 && !validationReference.Nullable.Value))
                {
                    e.ErrorText = "Value cannot be blank";
                    valid = false;
                    grvEntries.SetColumnError(colReference, e.ErrorText);
                    grvEntries.FocusedColumn = colReference;
                    
                }
                else
                    e.ErrorText = string.Empty;

            }

            DB.VW_Validation validationDescription = BL.ApplicationDataContext.Instance.ValidationRestrictions
                .Where(n => n.TableName.Equals("GLX_Header") && n.ColumnName.Equals("Description")).FirstOrDefault();

            if (validationDescription != null)
            {
                string description = (string)((BulkEntry)(e.Row)).Description;
                if ((description == null && !validationDescription.Nullable.Value) || (description != null && description.Length == 0 && !validationDescription.Nullable.Value))
                {
                    e.ErrorText = "Value cannot be blank";
                    if (valid) valid = false;
                    grvEntries.SetColumnError(colDescription, e.ErrorText);
                    grvEntries.FocusedColumn = colDescription;
                    return;
                }
                else
                    e.Valid = true;

            }

            e.Valid = valid;
            grvEntries.ShowEditor();
        }

        private void grvEntries_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
              DB.VW_Validation validationReference = BL.ApplicationDataContext.Instance.ValidationRestrictions
                .Where(n => n.TableName.Equals("GLX_Header") && n.ColumnName.Equals("Reference")).FirstOrDefault();

            if (validationReference != null && grvEntries.FocusedColumn.Equals(colReference))
            {
                string reference = (string)e.Value;

                if (reference != null && reference.Length > validationReference.LengthMax && !validationReference.Nullable.Value)
                {
                    e.ErrorText = String.Format("Value cannot be longer than {0} characters", validationReference.LengthMax);
                    e.Valid = false;
                    return;
                }
                else
                    e.ErrorText = string.Empty;
            }

            DB.VW_Validation validationDescription = BL.ApplicationDataContext.Instance.ValidationRestrictions
                .Where(n => n.TableName.Equals("GLX_Header") && n.ColumnName.Equals("Description")).FirstOrDefault();

            if (validationDescription != null && grvEntries.FocusedColumn.Equals(validationDescription))
            {
                string reference = (string)e.Value;

                if (reference != null && reference.Length > validationDescription.LengthMax && !validationDescription.Nullable.Value)
                {
                    e.ErrorText = String.Format("Value cannot be longer than {0} characters", validationDescription.LengthMax);
                    e.Valid = false;
                    return;
                }
                else
                    e.Valid = true;
            }
        }

        private void grvEntries_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvEntries_KeyDown(object sender, KeyEventArgs e)
        {
            string columnError = grvEntries.GetColumnError(grvEntries.FocusedColumn);
            if (columnError != null && columnError.Length != 0)
                e.Handled = false;
        }

        private void InstantFeedbackSourceAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            if ((BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRE03)))    // Harcoded Access: FIEN05 = 544, // Write to Control accounts )
            {
                //Check for Master accountant
                if (!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR))
                    e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.SiteId == defaultSiteId);
                else
                    e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);

            }
            else
            {
                //Check for Master accountant
                if (!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR))
                    e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && n.CodeSub != "00000" && n.SiteId == defaultSiteId);
                else
                    e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && n.CodeSub != "00000");
            }
        }
 
    }
}
