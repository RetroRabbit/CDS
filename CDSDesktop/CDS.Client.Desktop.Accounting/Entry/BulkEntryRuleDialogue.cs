using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Filtering.Helpers;

namespace CDS.Client.Desktop.Accounting.Entry
{
    public partial class BulkEntryRuleDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    { 
        List<BulkEntryAction> actions = new List<BulkEntryAction>();

        public BulkEntryRuleDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart(); 

            actions.Add(new BulkEntryAction() { Action = "Do Not Import", Value = "Y" });
            actions.Add(new BulkEntryAction() { Action = "Import Entry", Value = "N" });
            BindingSourceActions.DataSource = actions;

            filRule.FilterColumns.Add(new UnboundFilterColumn("Date", "Date", typeof(DateTime), new RepositoryItemDateEdit(), FilterColumnClauseClass.DateTime));
            filRule.FilterColumns.Add(new UnboundFilterColumn("Reference", "Reference", typeof(String), new RepositoryItemTextEdit(), FilterColumnClauseClass.String));
            filRule.FilterColumns.Add(new UnboundFilterColumn("Description", "Description", typeof(String), new RepositoryItemTextEdit(), FilterColumnClauseClass.String));
            filRule.FilterColumns.Add(new UnboundFilterColumn("Amount", "Inclusive", typeof(Decimal), new RepositoryItemSpinEdit(), FilterColumnClauseClass.Generic));
        }

        private bool HasAccount()
        {
            try
            {
                if (ddlAccount.EditValue == null || ddlAccount.EditValue == DBNull.Value)
                {
                    ddlAccount.ErrorText = "Please select an account.";
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

        private bool HasTaxType()
        {
            try
            {
                if (ddlTax.EditValue == null || ddlTax.EditValue == DBNull.Value)
                {
                    ddlTax.ErrorText = "Please select an tax type.";
                    return false;
                }
                else
                {
                    ddlTax.ErrorText = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasContraAccount()
        {
            try
            {
                if (ddlContraAccount.EditValue == null || ddlContraAccount.EditValue == DBNull.Value)
                {
                    ddlContraAccount.ErrorText = "Please select an account.";
                    return false;
                }
                else
                {
                    ddlContraAccount.ErrorText = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                bool isValid = true;
                isValid = HasAccount() && HasContraAccount() && HasTaxType();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }
       
        private void InstantFeedbackSourceAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);
        }

        private void InstantFeedbackSourceContraAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);
        }

        private void InstantFeedbackSourceTax_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Tax;
        }

        private void ddlAccount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAccount.EditValue == null || ddlAccount.EditValue == DBNull.Value)
                    return;

                // Disable all controls until a rule is selected
                pnlRuleDetail.Enabled = false;
                BindingSourceRules.DataSource = DataContext.EntityAccountingContext.GLX_BulkEntryRule.Where(n => n.EntityId == (Int64)ddlAccount.EditValue).ToList();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Adds a new Bulk Entry Rule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            try
            {
                grvRules.BeginUpdate();
                grvRules.BeginDataUpdate();
                DB.GLX_BulkEntryRule rule = BL.GLX.GLX_BulkEntryRule.New;
                rule.Name = String.Format("New Rule #{0}", (BindingSourceRules.DataSource as List<DB.GLX_BulkEntryRule>).Count + 1);
                rule.EntryRule = "";
                rule.EntityId = (Int64)ddlAccount.EditValue;
                rule.EntryAction = "N";
                rule.Priority = (Int16)(BindingSourceRules.DataSource as List<DB.GLX_BulkEntryRule>).Count;
                BindingSourceRules.Add(rule);                 
                grvRules.RefreshData();
                grvRules.EndDataUpdate();
                grvRules.EndUpdate();
            }
            catch (Exception ex)
            {
                DataContext.EntitySystemContext.RejectChanges();
                DataContext.EntityAccountingContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Removes the selected Bulk Entry Rule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope transaction = DataContext.GetTransactionScope())
                {

                    DataContext.EntityAccountingContext.GLX_BulkEntryRule.Remove(grvRules.GetFocusedRow() as DB.GLX_BulkEntryRule);

                    DataContext.SaveChangesEntityAccountingContext();

                    DataContext.SaveChangesEntitySystemContext();
                    DataContext.CompleteTransaction(transaction);
                }
                DataContext.EntitySystemContext.AcceptAllChanges();
                DataContext.EntityAccountingContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                DataContext.EntitySystemContext.RejectChanges();
                DataContext.EntityAccountingContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvRules_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        { 

            if (grvRules.GetFocusedRow() == null)
                return;

            BindingSourceRule.DataSource = grvRules.GetFocusedRow();
            filRule.DataBindings.Clear();
            filRule.DataBindings.Add("FilterString", BindingSourceRule.DataSource, "EntryRule");
            pnlRuleDetail.Enabled = true; 
        }

        /// <summary>
        /// Moves selected Rules priority up by one and reorders rules.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 07/03/2012</remarks>
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                //SWITCH PRIORITY
                DB.GLX_BulkEntryRule selectedRule = (DB.GLX_BulkEntryRule)grvRules.GetRow(grvRules.GetSelectedRows()[0]);
                DB.GLX_BulkEntryRule previousRule = (DB.GLX_BulkEntryRule)grvRules.GetRow(grvRules.GetSelectedRows()[0] - 1);

                if (previousRule == null)
                    return;

                previousRule.Priority = selectedRule.Priority;
                selectedRule.Priority = (Int16)(previousRule.Priority - 1);

                //SWITCH ROW POSITION

                DevExpress.XtraGrid.Views.Grid.GridView view = grvRules;

                view.GridControl.Focus();

                int index = view.FocusedRowHandle;

                if (index <= 0) return;
                 
                
                    view.ClearSorting();
                    view.Columns[colRulePriority.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                

                //view.FocusedRowHandle = index - 1;
              //  view.FocusedRowHandle--;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Moves selected Rules priority down by one and reorders rules.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 07/03/2012</remarks>
        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                //SWITCH PRIORITY
                DB.GLX_BulkEntryRule selectedRule = (DB.GLX_BulkEntryRule)grvRules.GetRow(grvRules.GetSelectedRows()[0]);
                DB.GLX_BulkEntryRule nextRule = (DB.GLX_BulkEntryRule)grvRules.GetRow(grvRules.GetSelectedRows()[0] + 1);

                if (nextRule == null)
                    return;

                short? tempPriority = selectedRule.Priority;
                selectedRule.Priority = nextRule.Priority;
                nextRule.Priority = tempPriority;

                //SWITCH ROW POSITION

                DevExpress.XtraGrid.Views.Grid.GridView view = grvRules;

                view.GridControl.Focus();

                int index = view.FocusedRowHandle;

                if (index >= view.DataRowCount - 1) return;
                 
                    view.ClearSorting();
                    view.Columns[colRulePriority.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
              
                //view.FocusedRowHandle = index + 1;
            //    view.FocusedRowHandle++;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Saves the changes made to all rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveRule_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLayout();

                if (!ValidateBeforeSave())
                    return;

                using (TransactionScope transaction = DataContext.GetTransactionScope())
                {
                    foreach (DB.GLX_BulkEntryRule rule in (BindingSourceRules.DataSource as List<DB.GLX_BulkEntryRule>))
                    {
                        if (DataContext.EntityAccountingContext.GetEntityState(rule) == System.Data.Entity.EntityState.Detached)
                        {
                            BL.EntityController.SaveGLX_BulkEntryRule(rule, DataContext);
                        }
                    }

                    DataContext.SaveChangesEntityAccountingContext();

                    DataContext.SaveChangesEntitySystemContext();
                    DataContext.CompleteTransaction(transaction);
                }
                DataContext.EntitySystemContext.AcceptAllChanges();
                DataContext.EntityAccountingContext.AcceptAllChanges();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                DataContext.EntitySystemContext.RejectChanges();
                DataContext.EntityAccountingContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void filRule_FilterChanged(object sender, DevExpress.XtraEditors.FilterChangedEventArgs e)
        {

        }

    }

    public partial class BulkEntryAction
    {
        public string Action { get; set; }
        public string Value { get; set; }
    }
}
