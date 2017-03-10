using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CDS.Client.DataAccessLayer.DB;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using CDS.Client.Desktop.Essential.UTL;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Threading.Tasks;


namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    public partial class BaseBulkPaymentForm : CDS.Client.Desktop.Essential.BaseForm
    {
        List<BulkPaymentEntry> bulkPaymentEntries = new List<BulkPaymentEntry>();
        DataTable paymentItems = new DataTable("Items");
        List<BL.GLX.PaymentAccount> paymentAccounts = null;
         
        public BaseBulkPaymentForm()
        {
            InitializeComponent();
        }

        public List<BulkPaymentEntry> BulkPaymentEntries
        { get { return bulkPaymentEntries; } }

        public List<BL.GLX.PaymentAccount> PaymentAccounts
        { get { return paymentAccounts; } }

        /// <summary>
        /// Load any necesary lookup values.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/09/2013</remarks>
        protected override void OnStart()
        {
            base.OnStart();

            ServerModeSourcePeriod.QueryableSource =  DataContext.EntitySystemContext.SYS_Period.Where(n => n.StatusId == 50);
            ServerModeSourcePeriodAll.QueryableSource = DataContext.EntitySystemContext.SYS_Period;

            paymentAccounts = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(BL.ApplicationDataContext.Instance.CompanySite.PaymentAccounts, typeof(List<BL.GLX.PaymentAccount>));

            List<Int64> paymentAccountIds = paymentAccounts.Select(l => l.AccountId).ToList();

            //Select only accounts that are in the Payment Accounts
            ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account
                                                                                .Where(n => n.Archived.Equals(false) && paymentAccountIds.Contains(n.Id));
            //Select only Debtor or Credit Accounts
            ServerModeSourceContraAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && n.ControlId != null);

            List<Int64> settlementAccountIds = paymentAccounts.Where(nn => nn.AccountDescription.StartsWith("Set")).Select(l => l.AccountId).ToList();

            ServerModeSourceSettlementAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && settlementAccountIds.Contains(n.Id));

            ServerModeSourceAging.QueryableSource = DataContext.EntityAccountingContext.GLX_Aging;

            BindingSource.DataSource = bulkPaymentEntries;


        }

        public virtual bool ValidateBeforeSave()
        {
            try
            {
                bool isValid = true;
                isValid = ValidationProvider.Validate() && HasEntries() && HasValidEntries() && HasValidPeriods() && HasValidContraAccounts() && HasValidReference() && HasValidDescription();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public virtual bool HasValidAccount()
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

        public virtual bool HasValidContraAccounts()
        {
            try
            {
                return bulkPaymentEntries.Where(n => n.AccountId == null || n.AccountId == 0).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public virtual bool HasValidPeriods()
        {
            try
            {
                return bulkPaymentEntries.Where(n => n.PeriodId == null || n.PeriodId == 0).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public virtual bool HasEntries()
        {
            try
            {
                return bulkPaymentEntries.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public virtual bool HasValidEntries()
        {
            try
            {
                bool isValid = true;

                foreach (BulkPaymentEntry entry in bulkPaymentEntries)
                {
                    if ((entry.BulkPaymentItems.Where(n=>n.Checked.Equals(true)).Sum(l => l.Balance) - entry.Amount) != 0)
                    {

                        Essential.BaseAlert.ShowAlert("Invalid entry",
                            String.Format("Total amount of entry with reference \"{0}\" has not been assigned.", entry.Reference)
                            , Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        isValid = false;
                        break;
                    }
                }

                return isValid;

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public virtual bool HasValidReference()
        {
            try
            {
                return bulkPaymentEntries.Where(n => n.Reference == null).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public virtual bool HasValidDescription()
        {
            try
            {
                return bulkPaymentEntries.Where(n => n.Description == null).Count() > 0 ? false : true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Import the CSV file data from the Dialogue into the grid
        /// </summary>
        /// <param name="dialogue"></param>
        private void ImportFile(BulkPaymentImportDialogue dialogue)
        {
            try
            {

                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    ddlAccount.EditValue = dialogue.AccountId;
                    if (dialogue.SkippedAccounts.Count() != 0)
                    {
                        Essential.BaseAlert.ShowAlert("Invalid accounts",
                        String.Format("The following accounts could not be found \"{0}\".", String.Join(",", dialogue.SkippedAccounts))
                        , Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }

                    //Cant find any of the accounts
                    if (dialogue.Data.Where(n => n.AccountId != null).Select(l => l.AccountId.Value).Distinct().ToList().Count() == 0)
                        return;

                    paymentItems = GetPaymentItems(dialogue.Data.Where(n => n.AccountId != null).Select(l => l.AccountId.Value).Distinct().ToList());

                    Parallel.ForEach(paymentItems.AsEnumerable(), row =>
                    //foreach (DataRow row in paymentItems.AsEnumerable())
                    {
                        int agingId = -1;

                        DateTime entryDate = Convert.ToDateTime(bulkPaymentEntries.Where(n => n.AccountId.Equals(row["AccountId"])).Select(n => n.Date).FirstOrDefault());
                        entryDate = entryDate.AddDays(-(entryDate.Day - 1));
                        DateTime date = Convert.ToDateTime(row["Date"]);
                        date = date.AddDays(-(date.Day - 1));

                        int monthDiff = (int)entryDate.Subtract(date).Days / (365 / 12);

                        if (monthDiff >= 5)
                        {
                            agingId = 5;
                        }
                        else
                        {
                            agingId = monthDiff + 1;
                        }

                        bulkPaymentEntries.Where(n => n.AccountId.Equals(row["AccountId"])).FirstOrDefault().BulkPaymentItems.Add(
                             new BulkPaymentItem()
                             {
                                 Type = Convert.ToString(row["Type"]),
                                 Title = Convert.ToString(row["Title"]),
                                 Reference = Convert.ToString(row["Reference"]),
                                 Description = Convert.ToString(row["Description"]),
                                 Date = Convert.ToDateTime(row["Date"]),
                                 Balance = Convert.ToDecimal(row["Balance"]),
                                 PeriodId = Convert.ToInt64(row["PeriodId"]),
                                 AgingId = Convert.ToByte(agingId),//Convert.ToInt16(row["AgingId"]),
                                 TrackNumber = Convert.ToString(row["TrackNumber"]),
                                 LineId = Convert.ToInt64(row["LineId"] != DBNull.Value ? row["LineId"] : -1),
                                 HeaderId = Convert.ToInt64(row["HeaderId"] != DBNull.Value ? row["HeaderId"] : -1)
                             }

                             );
                    });

                    foreach (var mainLine in bulkPaymentEntries)
                    {
                        //Skip OI Accounts
                        if (mainLine.BulkPaymentItems.Count == 0)
                            continue;
                        if (mainLine.BulkPaymentItems.Select(n => n.Type).FirstOrDefault().Equals("OI"))
                            continue;

                        //Auto assigns the entry to the Correct Aging
                        foreach (var subLine in mainLine.BulkPaymentItems)
                        {
                            if (subLine.AgingId.Equals(mainLine.AgingId))
                                subLine.Checked = true;
                        }
                    }

                    grdEntries.RefreshDataSource();
                    grdEntries.Focus();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Shows import dialogue and gets data from CSV file.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 27/09/2013</remarks>
        private void btnImportStatement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                BulkPaymentImportDialogue dialogue = new BulkPaymentImportDialogue(bulkPaymentEntries, paymentAccounts.Select(l => l.AccountId).ToList());
                if (dialogue.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ImportFile(dialogue);
                }

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Retrieves the Items from the database
        /// Method should always the overriden in the child form for different Items data
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public virtual DataTable GetPaymentItems(List<Int64> accounts)
        {
            return null;
        }

        /// <summary>
        /// Shows bulk rule dialogue and allowes you to setup and change rules.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 27/09/2013</remarks>
        private void btnBulkEntryRules_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            throw new NotImplementedException("Need to do this");
        }

        /// <summary>
        /// Handels all cell value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvEntries_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //BulkPaymentEntry row = (BulkPaymentEntry)grvEntries.GetRow(e.RowHandle);

                //You hould not do this because the amount already has settlement discount buttracted as it comes from the bankaccount
                //row.Amount -= row.settlement;
                HasErrors = false;
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Handles deleteing items from grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdEntries_ProcessGridKey(object sender, KeyEventArgs e)
        {

            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            //if (e.KeyData == Keys.Delete && ! (grvEntries.FocusedColumn == colExclusive || grvEntries.FocusedColumn == colInclusive))
            if (e.KeyData == Keys.Delete && view.State == GridState.Normal)
            {
                //throw new NotImplementedException("Check that when deleting row on view that object is deleted");
                if (Essential.BaseAlert.ShowAlert("Confirm delete.", "You are about to delete the selected row do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    view.DeleteSelectedRows();
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Disables showing the editor for the Aging dropdown if the account isn't a agingg account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvEntries_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                //If the selected accounts does not have agings
                BulkPaymentEntry FocusedRow = grvEntries.GetFocusedRow() as BulkPaymentEntry;

                if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).FocusedValue == null || FocusedRow.AccountId == null)
                    return;

                if ((sender as DevExpress.XtraGrid.Views.Grid.GridView).FocusedColumn == colAgingId)
                {


                    if (!((IEnumerable<DB.VW_Account>)ServerModeSourceContraAccount.QueryableSource).Where(n => n.Id == (long?)FocusedRow.AccountId).Select(n => n.AgingAccount).FirstOrDefault())
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

        private void grvEntries_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            DB.VW_Validation validationReference = BL.ApplicationDataContext.Instance.ValidationRestrictions
                .Where(n => n.TableName.Equals("GLX_Header") && n.ColumnName.Equals("Reference")).FirstOrDefault();

            if (validationReference != null)
            {
                string reference = (string)((BulkPaymentEntry)(e.Row)).Reference;
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
                string description = (string)((BulkPaymentEntry)(e.Row)).Description;
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

        /// <summary>
        /// Disables the popup that you get when the call values is invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvEntries_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        /// <summary>
        /// Cancels changing the focused column if the call has an error 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvEntries_KeyDown(object sender, KeyEventArgs e)
        {
            string columnError = grvEntries.GetColumnError(grvEntries.FocusedColumn);
            if (columnError != null && columnError.Length != 0)
                e.Handled = false;
        }

        /// <summary>
        /// Calculate the focused views summary information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvItems_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView currentChildGrid = (sender as DevExpress.XtraGrid.Views.Grid.GridView);

            if (currentChildGrid.DataSource == null)
                e.TotalValue = 0;
            else
                e.TotalValue = (currentChildGrid.DataSource as System.Collections.Generic.List<BulkPaymentItem>).Where(n => n.Checked).Sum(s => s.Balance)
                    - (
                        ((BulkPaymentEntry)(grvEntries.GetFocusedRow())).Amount
                        +
                        ((BulkPaymentEntry)(grvEntries.GetFocusedRow())).Settlement
                      );
        }

        /// <summary>
        /// Refreshes the Summary Footer for the current focused grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repItemsChecked_CheckedChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                GridView grid_itm = grdEntries.FocusedView as GridView;

                grid_itm.PostEditor();
                grid_itm.UpdateCurrentRow();
            }));
        }

    }
}

