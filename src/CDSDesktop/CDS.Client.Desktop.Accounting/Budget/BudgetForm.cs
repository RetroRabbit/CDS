using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;


namespace CDS.Client.Desktop.Accounting.Budget
{
    public partial class BudgetForm : CDS.Client.Desktop.Essential.BaseForm
    {
        List<DB.SYS_Period> periods = null;
        List<DB.VW_Account> accounts = null;
        private List<DB.GLX_Budget> budgets = null;

        public BudgetForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                // Get financial Years
                List<short> years = DataContext.EntitySystemContext.SYS_Period.Select(n => n.FinancialYear.Value).Distinct().OrderByDescending(n => n).Take(5).ToList();
                ddlFinancialYear.Properties.DataSource = years;
                if (years.Count > 0)
                    ddlFinancialYear.ItemIndex = 0;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Essential.GridFilterDefaults.ApplyStandards(new List<DevExpress.XtraGrid.Views.Grid.GridView> { grvBudget });
        }

        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                if (ddlFinancialYear.ItemIndex > 0)
                    ddlFinancialYear.ItemIndex--;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();

                if (ddlFinancialYear.ItemIndex < ((List<short>)ddlFinancialYear.Properties.DataSource).Count - 1)
                    ddlFinancialYear.ItemIndex++;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIBUREED);
        }

        protected override void BindData()
        {         
            try
            {
                base.BindData();
                string accountType = Convert.ToString(radAccountType.EditValue);
                periods = DataContext.EntitySystemContext.SYS_Period.Where(n => n.FinancialYear == (short)ddlFinancialYear.EditValue).OrderBy(n => n.Code).ToList();
                //Filtering for Master Accountant
                //Sean Hill 14/9/2016
                if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
                {
                    accounts = DataContext.ReadonlyContext.VW_Account.Where(n => n.Flag1Type.Equals(accountType)).Where(n => radControlAccounts.SelectedIndex != 0 || n.CodeSub == "00000").ToList();
                }
                else
                {
                    accounts = DataContext.ReadonlyContext.VW_Account.Where(n => n.Flag1Type.Equals(accountType) && n.SiteId == BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId).Where(n => radControlAccounts.SelectedIndex != 0 || n.CodeSub == "00000").ToList();
                    radControlAccounts.Properties.Items[0].Enabled = false;
                    radControlAccounts.SelectedIndex = 1;

                }
                    List<Int64> EntityIds = accounts.Select(o => o.Id).ToList();
                List<Int64> periodIds = periods.Select(o => o.Id).ToList();

                budgets = DataContext.EntityAccountingContext.GLX_Budget.Where(n => EntityIds.Contains(n.EntityId.Value) && periodIds.Contains(n.PeriodId.Value)).ToList();


                while (this.grvBudget.Columns.Count > 5)
                    this.grvBudget.Columns.RemoveAt(5);

                DevExpress.XtraGrid.Columns.GridColumn[] columns = periods.OrderBy(n => n.Code).Select(n =>
                        new DevExpress.XtraGrid.Columns.GridColumn()
                        {
                            FieldName = n.Id.ToString(),
                            Caption = n.Code,
                            Tag = n.Id,
                            MinWidth = 80,
                            MaxWidth = 80,
                            UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                        }).ToArray();


                for (int i = 0; i < columns.Length; i++)
                {

                    columns[i].VisibleIndex = i + 5;
                    columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    columns[i].DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
                }

                // Add period columns
                this.grvBudget.Columns.AddRange(
                    columns
                    );

                // Set properties
                //for (int i = 4; i < grvBudget.Columns.Count; i++)
                //{
                //    this.grvBudget.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                //    this.grvBudget.Columns[i].DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
                //}

                BindingSource.DataSource = accounts.OrderBy(n => n.CodeMain).OrderBy(n => n.CodeSub);
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
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            budgets.Where(n => n.Id == 0).ToList().ForEach(n => BL.EntityController.SaveGLX_Budget(n, DataContext));
                            DataContext.SaveChangesEntityAccountingContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                //DataContext.EntityAccountingContext.RollBackTransaction();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
        }
         
        private void grvBudget_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Total" && e.IsGetData)
                {
                    DB.VW_Account row = e.Row as DB.VW_Account;
                    e.Value = budgets.Where(n => n.EntityId == row.Id).Sum(n => n.Amount);
                }
                else if (e.Column.FieldName != "Title" && e.IsGetData)
                {
                    DB.VW_Account row = e.Row as DB.VW_Account;
                    DB.GLX_Budget budg = budgets.FirstOrDefault(n => n.PeriodId == (Int64)e.Column.Tag && n.EntityId == row.Id);
                    if (budg != null)
                        e.Value = budg.Amount;
                    //e.Value = (budg == null) ? 0 : budg.Amount;
                }
                else if (e.Column.FieldName != "Title" && e.IsSetData)
                {
                    DB.VW_Account row = e.Row as DB.VW_Account;
                    DB.GLX_Budget budg = budgets.FirstOrDefault(n => n.PeriodId == (Int64)e.Column.Tag && n.EntityId == row.Id);
                    if (budg == null)
                    {
                        budg = BL.GLX.GLX_Budget.New;
                        budg.PeriodId = (Int64)e.Column.Tag;
                        budg.EntityId = row.Id;
                        budg.Amount = (decimal)e.Value;
                        budgets.Add(budg);
                    }
                    else
                    {
                        budg.Amount = (decimal?)e.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
         
        private void ddlFinancialYear_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void radControlAccounts_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void radAccountType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
