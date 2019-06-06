using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Filtering.Helpers;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;


namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    public partial class BulkPaymentRuleDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        List<DB.GLX_BulkEntryRule> rules = null;

        public BulkPaymentRuleDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.CodeSub == "00000");
                ServerModeSourceTax.QueryableSource = DataContext.EntityAccountingContext.GLX_Tax;

                filRule.FilterColumns.Add(new UnboundFilterColumn("Date", "Date", typeof(DateTime), new RepositoryItemDateEdit(), FilterColumnClauseClass.DateTime));
                filRule.FilterColumns.Add(new UnboundFilterColumn("Reference", "Reference", typeof(String), new RepositoryItemTextEdit(), FilterColumnClauseClass.String));
                filRule.FilterColumns.Add(new UnboundFilterColumn("Description", "Description", typeof(String), new RepositoryItemTextEdit(), FilterColumnClauseClass.String));
                filRule.FilterColumns.Add(new UnboundFilterColumn("Amount", "Inclusive", typeof(Decimal), new RepositoryItemSpinEdit(), FilterColumnClauseClass.Generic));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void BindRules(Int64 EntityId)
        {
            try
            {
                rules = new List<DB.GLX_BulkEntryRule>();
                foreach (DB.GLX_BulkEntryRule rule in DataContext.EntityAccountingContext.GLX_BulkEntryRule.Where(n => n.EntityId == EntityId))
                {
                    rules.Add(rule);
                }

                ServerModeSourceBulkEntryRule.QueryableSource = null;
                ServerModeSourceBulkEntryRule.QueryableSource = rules.AsQueryable();
                if (rules.Count > 0)
                {
                    grvRules.SelectRow(grvRules.GetRowHandle(0));
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
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
                    view.Columns[colPriority.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
               
                view.FocusedRowHandle = index - 1;
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

                nextRule.Priority = selectedRule.Priority;
                selectedRule.Priority = (Int16)(nextRule.Priority - 1);

                //SWITCH ROW POSITION

                DevExpress.XtraGrid.Views.Grid.GridView view = grvRules;

                view.GridControl.Focus();

                int index = view.FocusedRowHandle;

                if (index >= view.DataRowCount - 1) return;

                //  view.BeginSort();
                try
                {
                    view.ClearSorting();
                    view.Columns[colPriority.FieldName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }
                finally
                {
                    //      view.EndSort();
                }

                view.FocusedRowHandle = index + 1;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (BindingSourceRule.DataSource != null)
                {
                    (BindingSourceRule.DataSource as DB.GLX_BulkEntryRule).EntryAction = ddlAction.SelectedIndex == 0 ? "N" : "Y";
                    if (ddlAction.SelectedIndex == 0)
                    {
                        ddlContraAccount.Enabled = false;
                        ddlTax.Enabled = false;
                    }
                    else
                    {
                        ddlContraAccount.Enabled = true;
                        ddlTax.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvRules_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DB.GLX_BulkEntryRule rule = (DB.GLX_BulkEntryRule)grvRules.GetRow(e.FocusedRowHandle);

                if (rule != null)
                {
                    BindingSourceRule.DataSource = rule;

                    filRule.DataBindings.Clear();
                    filRule.DataBindings.Add("FilterString", BindingSourceRule.DataSource, "EntryRule");

                    ddlAction.SelectedIndex = rule.EntryAction == "Y" ? 1 : 0;

                    pnlRuleDetail.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlAccount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAccount.EditValue == String.Empty || ddlAccount.EditValue == null || ddlAccount.EditValue == DBNull.Value)
                    return;

                // Disable all controls until a rule is selected
                pnlRuleDetail.Enabled = false;

                BindRules(Convert.ToInt64(ddlAccount.EditValue));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DB.GLX_BulkEntryRule rule = BL.GLX.GLX_BulkEntryRule.New;
                rule.Name = String.Format("New Rule #{0}", rules.Count + 1);
                rule.EntryRule = "";
                rule.EntityId = (Int64)ddlAccount.EditValue;
                rule.EntryAction = ddlAction.SelectedIndex == 0 ? "N" : "Y";
                rule.Priority = (Int16)rules.Count;
                //DataContext.EntityContext.SaveChanges();

                BindRules(Convert.ToInt64(ddlAccount.EditValue));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateRules_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLayout();

                if (!ValidateBeforeSave())
                    return;
                //DataContext.EntityAccountingContext.BeginTransaction();
                rules.ForEach(n => BL.EntityController.SaveGLX_BulkEntryRule(n, DataContext));
                DataContext.SaveChangesEntityAccountingContext();
                //DataContext.EntityAccountingContext.CommitTransaction();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                //DataContext.EntityAccountingContext.RollBackTransaction();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
 
    }
}
