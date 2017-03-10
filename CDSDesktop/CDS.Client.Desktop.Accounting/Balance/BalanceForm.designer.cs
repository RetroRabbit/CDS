namespace CDS.Client.Desktop.Accounting
{
    partial class BalanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceForm));
            this.fieldBalanceAmount1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBudgetAmount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPeriodCode1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAccountCode1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAccountName1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAccountDescription1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldStatusCode1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTypeCode1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldFinancialYear1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBalanceGroup = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ServerModeSourceBalance = new DevExpress.Data.Linq.LinqServerModeSource();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.EntityServerModeSource = new DevExpress.Data.Linq.EntityServerModeSource();
            ((System.ComponentModel.ISupportInitialize)(this.PivotControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityServerModeSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PivotControl
            // 
            this.PivotControl.DataSource = this.EntityServerModeSource;
            this.PivotControl.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldBalanceAmount1,
            this.fieldBudgetAmount,
            this.fieldPeriodCode1,
            this.fieldAccountCode1,
            this.fieldAccountName1,
            this.fieldAccountDescription1,
            this.fieldStatusCode1,
            this.fieldTypeCode1,
            this.fieldFinancialYear1,
            this.fieldBalanceGroup});
            this.PivotControl.Location = new System.Drawing.Point(0, 147);
            this.PivotControl.OptionsMenu.EnableFormatRulesMenu = true;
            this.PivotControl.OptionsView.ShowColumnGrandTotals = false;
            this.PivotControl.Size = new System.Drawing.Size(784, 415);
            this.PivotControl.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.PivotControl_CellDoubleClick);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_Balance);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Size = new System.Drawing.Size(784, 147);
            // 
            // DefaultToolTipController
            // 
            // 
            // 
            // 
            this.DefaultToolTipController.DefaultController.AutoPopDelay = 10000;
            this.DefaultToolTipController.DefaultController.Rounded = true;
            this.DefaultToolTipController.DefaultController.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7;
            this.DefaultToolTipController.DefaultController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // fieldBalanceAmount1
            // 
            this.fieldBalanceAmount1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldBalanceAmount1.AreaIndex = 0;
            this.fieldBalanceAmount1.Caption = "Amount";
            this.fieldBalanceAmount1.CellFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.fieldBalanceAmount1.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldBalanceAmount1.FieldName = "BalanceAmount";
            this.fieldBalanceAmount1.GrandTotalCellFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.fieldBalanceAmount1.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldBalanceAmount1.Name = "fieldBalanceAmount1";
            this.fieldBalanceAmount1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            // 
            // fieldBudgetAmount
            // 
            this.fieldBudgetAmount.AreaIndex = 1;
            this.fieldBudgetAmount.Caption = "Budget";
            this.fieldBudgetAmount.CellFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.fieldBudgetAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldBudgetAmount.FieldName = "BudgetAmount";
            this.fieldBudgetAmount.GrandTotalCellFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.fieldBudgetAmount.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fieldBudgetAmount.Name = "fieldBudgetAmount";
            this.fieldBudgetAmount.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            // 
            // fieldPeriodCode1
            // 
            this.fieldPeriodCode1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldPeriodCode1.AreaIndex = 1;
            this.fieldPeriodCode1.Caption = "Period";
            this.fieldPeriodCode1.FieldName = "PeriodCode";
            this.fieldPeriodCode1.Name = "fieldPeriodCode1";
            this.fieldPeriodCode1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            this.fieldPeriodCode1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            // 
            // fieldAccountCode1
            // 
            this.fieldAccountCode1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldAccountCode1.AreaIndex = 2;
            this.fieldAccountCode1.Caption = "Account Code";
            this.fieldAccountCode1.FieldName = "AccountCode";
            this.fieldAccountCode1.Name = "fieldAccountCode1";
            this.fieldAccountCode1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            // 
            // fieldAccountName1
            // 
            this.fieldAccountName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldAccountName1.AreaIndex = 3;
            this.fieldAccountName1.Caption = "Account Name";
            this.fieldAccountName1.FieldName = "AccountName";
            this.fieldAccountName1.Name = "fieldAccountName1";
            this.fieldAccountName1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            this.fieldAccountName1.Width = 200;
            // 
            // fieldAccountDescription1
            // 
            this.fieldAccountDescription1.AreaIndex = 2;
            this.fieldAccountDescription1.Caption = "Account Description";
            this.fieldAccountDescription1.FieldName = "AccountDescription";
            this.fieldAccountDescription1.Name = "fieldAccountDescription1";
            // 
            // fieldStatusCode1
            // 
            this.fieldStatusCode1.AreaIndex = 0;
            this.fieldStatusCode1.Caption = "Status";
            this.fieldStatusCode1.FieldName = "StatusCode";
            this.fieldStatusCode1.Name = "fieldStatusCode1";
            // 
            // fieldTypeCode1
            // 
            this.fieldTypeCode1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldTypeCode1.AreaIndex = 1;
            this.fieldTypeCode1.Caption = "Type";
            this.fieldTypeCode1.FieldName = "TypeCode";
            this.fieldTypeCode1.Name = "fieldTypeCode1";
            this.fieldTypeCode1.Width = 150;
            // 
            // fieldFinancialYear1
            // 
            this.fieldFinancialYear1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldFinancialYear1.AreaIndex = 0;
            this.fieldFinancialYear1.Caption = "Financial Year";
            this.fieldFinancialYear1.FieldName = "FinancialYear";
            this.fieldFinancialYear1.Name = "fieldFinancialYear1";
            this.fieldFinancialYear1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.True;
            this.fieldFinancialYear1.Options.ShowTotals = false;
            this.fieldFinancialYear1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            // 
            // fieldBalanceGroup
            // 
            this.fieldBalanceGroup.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldBalanceGroup.AreaIndex = 0;
            this.fieldBalanceGroup.FieldName = "BalanceGroup";
            this.fieldBalanceGroup.Name = "fieldBalanceGroup";
            this.fieldBalanceGroup.Width = 50;
            // 
            // ServerModeSourceBalance
            // 
            this.ServerModeSourceBalance.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Balance);
            this.ServerModeSourceBalance.KeyExpression = "Id";
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Balance);
            this.EntityInstantFeedbackSource.KeyExpression = "Id";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            // 
            // EntityServerModeSource
            // 
            this.EntityServerModeSource.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Balance);
            this.EntityServerModeSource.KeyExpression = "Id";
            // 
            // BalanceForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "BalanceForm";
            this.SuperTipParameter = "pivot,pivot\'s";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.Text = "Balance Sheet";
            ((System.ComponentModel.ISupportInitialize)(this.PivotControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntityServerModeSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridField fieldBalanceAmount1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBudgetAmount;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPeriodCode1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAccountCode1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAccountName1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAccountDescription1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldStatusCode1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTypeCode1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldFinancialYear1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBalanceGroup;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceBalance;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private DevExpress.Data.Linq.EntityServerModeSource EntityServerModeSource;

    }
}
