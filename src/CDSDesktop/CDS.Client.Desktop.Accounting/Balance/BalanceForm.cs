using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB; 

namespace CDS.Client.Desktop.Accounting
{
    public partial class BalanceForm : CDS.Client.Desktop.Essential.BasePivot
    {
        private BalanceType balanceType = BalanceType.TrialBalance;

        public BalanceForm()
        {
            InitializeComponent();
        }

        public BalanceForm(BalanceType balanceType)
            : this()
        {
            this.balanceType = balanceType;

            switch (balanceType)
            {
                case BalanceType.TrialBalance:
                    this.Text = "Trial Balance";
                    this.TabIcon = global::CDS.Shared.Resources.Properties.Resources.folder2_black_16;
                    break;
                case BalanceType.IncomeStatement:
                    this.Text = "Income Statement";
                    this.TabIcon = global::CDS.Shared.Resources.Properties.Resources.folder2_green_16;
                    break;
                case BalanceType.BalanceSheet:
                    this.Text = "Balance Sheet";
                    this.TabIcon = global::CDS.Shared.Resources.Properties.Resources.folder2_yellow_16;
                    break;
            }
        }

        /// <summary>
        /// Load the balances for accounts that do not have parents (top level). These balances should incorporate all the child balances as well.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnStart()
        {
            base.OnStart();             
        }

        protected override void BindData()
        {
            base.BindData();

            List<Int32> financialYears = new List<Int32>();

            DateTime fromDate = new DateTime(DateTime.Now.Year, 02, 28);
            if (DateTime.Now.Month <= 2)
            {
                if (DateTime.IsLeapYear(DateTime.Now.Year - 2))
                    fromDate = new DateTime(DateTime.Now.Year - 2, 02, 29);
                else
                    fromDate = new DateTime(DateTime.Now.Year - 2, 02, 28);
            }
            else
            {
                if (DateTime.IsLeapYear(DateTime.Now.Year - 1))
                    fromDate = new DateTime(DateTime.Now.Year - 1, 02, 29);
                else
                    fromDate = new DateTime(DateTime.Now.Year - 1, 02, 28);
            }

            //At the time when this software was spawned you could not put DateTime.Today.AddMonths(1)
            //in the where clause of the Linq to Entity query
            DateTime oneMonthInTheFuture = DateTime.Today.AddMonths(1);
            switch (balanceType)
            {
                case BalanceType.TrialBalance:
                    //BindingSource.DataSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountMasterControlId == null && /*n.PeriodStartDate > DateTime.Now.AddMonths(-17) &&  /*financialYears.Contains(n.FinancialYear.Value) &&*/ n.PeriodEndDate >= fromDate && n.PeriodEndDate < oneMonthInTheFuture).ToList();
                    EntityServerModeSource.QueryableSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountMasterControlId == null && /*n.PeriodStartDate > DateTime.Now.AddMonths(-17) &&  /*financialYears.Contains(n.FinancialYear.Value) &&*/ n.PeriodEndDate >= fromDate && n.PeriodEndDate < oneMonthInTheFuture);
                    break;
                case BalanceType.IncomeStatement:
                    //BindingSource.DataSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountMasterControlId == null && n.TypeFlag1 == "I" && /*n.PeriodStartDate > DateTime.Now.AddMonths(-36) &&*/ n.PeriodEndDate >= fromDate && n.PeriodEndDate < oneMonthInTheFuture).ToList();
                    EntityServerModeSource.QueryableSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountMasterControlId == null && n.TypeFlag1 == "I" && /*n.PeriodStartDate > DateTime.Now.AddMonths(-36) &&*/ n.PeriodEndDate >= fromDate && n.PeriodEndDate < oneMonthInTheFuture);
                    break;
                case BalanceType.BalanceSheet:
                    //BindingSource.DataSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountMasterControlId == null && n.TypeFlag1 == "B" && /*n.PeriodStartDate > DateTime.Now.AddMonths(-36) &&*/ n.PeriodEndDate >= fromDate && n.PeriodEndDate < oneMonthInTheFuture).ToList();
                    EntityServerModeSource.QueryableSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountMasterControlId == null && n.TypeFlag1 == "B" && /*n.PeriodStartDate > DateTime.Now.AddMonths(-36) &&*/ n.PeriodEndDate >= fromDate && n.PeriodEndDate < oneMonthInTheFuture);
                    break;
            }

            PivotControl.BestFit(); 
        }

        /// <summary>
        /// This method will apply access security
        /// </summary>
        /// <remarks>Created: Werner Scheffer 07/03/2014</remarks>
        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowExport = true;
        }

        /// <summary>
        /// Opens the Entry screen showing the Entries that caused the selected cells movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 07/03/2014</remarks>
        private void PivotControl_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            if (PivotControl.GetFieldValue(fieldAccountCode1, e.RowIndex) != null)
            {
                Entry.EntryList childForm = new Entry.EntryList();
                childForm.AutoFilter(string.Format("StartsWith([EntityId.Title], '{0}') And StartsWith([HeaderId.PeriodId.Code], '{1}')",
                    //AccountName
                PivotControl.GetFieldValue(fieldAccountCode1, e.RowIndex).ToString().Substring(0, 5),
                    //Period Code
                PivotControl.GetFieldValue(e.ColumnField, e.ColumnIndex)));
                ShowForm(childForm);
            }
        }
         
        /// <summary>
        /// Enum for the different Balance types 
        /// </summary>
        public enum BalanceType
        {
            TrialBalance,
            IncomeStatement,
            BalanceSheet
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {

           
        }
    }
}
