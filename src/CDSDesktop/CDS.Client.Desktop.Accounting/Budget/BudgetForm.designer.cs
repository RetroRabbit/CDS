namespace CDS.Client.Desktop.Accounting.Budget
{
    partial class BudgetForm
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
            this.ddlFinancialYear = new DevExpress.XtraEditors.LookUpEdit();
            this.itmFinancialYear = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAccountType = new DevExpress.XtraLayout.LayoutControlItem();
            this.radAccountType = new DevExpress.XtraEditors.RadioGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmControlAccounts = new DevExpress.XtraLayout.LayoutControlItem();
            this.radControlAccounts = new DevExpress.XtraEditors.RadioGroup();
            this.pnlBudget = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmBudget = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdBudget = new DevExpress.XtraGrid.GridControl();
            this.grvBudget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colControl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFinancialYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFinancialYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radAccountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmControlAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radControlAccounts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.radControlAccounts);
            this.LayoutControl.Controls.Add(this.ddlFinancialYear);
            this.LayoutControl.Controls.Add(this.grdBudget);
            this.LayoutControl.Controls.Add(this.radAccountType);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.Size = new System.Drawing.Size(772, 410);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.pnlBudget});
            this.LayoutGroup.Size = new System.Drawing.Size(772, 410);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Size = new System.Drawing.Size(772, 140);
            // 
            // ddlFinancialYear
            // 
            this.ddlFinancialYear.Location = new System.Drawing.Point(24, 59);
            this.ddlFinancialYear.MenuManager = this.RibbonControl;
            this.ddlFinancialYear.Name = "ddlFinancialYear";
            this.ddlFinancialYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.ddlFinancialYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlFinancialYear.Properties.ShowFooter = false;
            this.ddlFinancialYear.Properties.ShowHeader = false;
            this.ddlFinancialYear.Size = new System.Drawing.Size(132, 20);
            this.ddlFinancialYear.StyleController = this.LayoutControl;
            this.ddlFinancialYear.TabIndex = 4;
            this.ddlFinancialYear.EditValueChanged += new System.EventHandler(this.ddlFinancialYear_EditValueChanged);
            // 
            // itmFinancialYear
            // 
            this.itmFinancialYear.Control = this.ddlFinancialYear;
            this.itmFinancialYear.CustomizationFormText = "Financial Year";
            this.itmFinancialYear.Location = new System.Drawing.Point(0, 0);
            this.itmFinancialYear.Name = "itmFinancialYear";
            this.itmFinancialYear.Size = new System.Drawing.Size(136, 60);
            this.itmFinancialYear.Text = "Financial Year";
            this.itmFinancialYear.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmFinancialYear.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Select Budget";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmFinancialYear,
            this.itmAccountType,
            this.emptySpaceItem1,
            this.itmControlAccounts});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(752, 103);
            this.layoutControlGroup1.Text = "Select Budget";
            // 
            // itmAccountType
            // 
            this.itmAccountType.Control = this.radAccountType;
            this.itmAccountType.CustomizationFormText = "Account Type";
            this.itmAccountType.Location = new System.Drawing.Point(136, 0);
            this.itmAccountType.Name = "itmAccountType";
            this.itmAccountType.Size = new System.Drawing.Size(154, 60);
            this.itmAccountType.Text = "Account Type";
            this.itmAccountType.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmAccountType.TextSize = new System.Drawing.Size(82, 13);
            // 
            // radAccountType
            // 
            this.radAccountType.EditValue = 'B';
            this.radAccountType.Location = new System.Drawing.Point(160, 59);
            this.radAccountType.MenuManager = this.RibbonControl;
            this.radAccountType.Name = "radAccountType";
            this.radAccountType.Properties.Columns = 1;
            this.radAccountType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem('B', "Balance Sheet"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem('I', "Income Statement")});
            this.radAccountType.Size = new System.Drawing.Size(150, 40);
            this.radAccountType.StyleController = this.LayoutControl;
            this.radAccountType.TabIndex = 7;
            this.radAccountType.EditValueChanged += new System.EventHandler(this.radAccountType_EditValueChanged);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(448, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(280, 60);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmControlAccounts
            // 
            this.itmControlAccounts.Control = this.radControlAccounts;
            this.itmControlAccounts.CustomizationFormText = "Control Accounts";
            this.itmControlAccounts.Location = new System.Drawing.Point(290, 0);
            this.itmControlAccounts.Name = "itmControlAccounts";
            this.itmControlAccounts.Size = new System.Drawing.Size(158, 60);
            this.itmControlAccounts.Text = "Control Accounts";
            this.itmControlAccounts.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmControlAccounts.TextSize = new System.Drawing.Size(82, 13);
            // 
            // radControlAccounts
            // 
            this.radControlAccounts.EditValue = true;
            this.radControlAccounts.Location = new System.Drawing.Point(314, 59);
            this.radControlAccounts.MenuManager = this.RibbonControl;
            this.radControlAccounts.Name = "radControlAccounts";
            this.radControlAccounts.Properties.Columns = 1;
            this.radControlAccounts.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Only Control Accounts"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Include Sub Accounts")});
            this.radControlAccounts.Size = new System.Drawing.Size(154, 40);
            this.radControlAccounts.StyleController = this.LayoutControl;
            this.radControlAccounts.TabIndex = 8;
            this.radControlAccounts.EditValueChanged += new System.EventHandler(this.radControlAccounts_EditValueChanged);
            // 
            // pnlBudget
            // 
            this.pnlBudget.CustomizationFormText = "Budget";
            this.pnlBudget.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmBudget});
            this.pnlBudget.Location = new System.Drawing.Point(0, 103);
            this.pnlBudget.Name = "pnlBudget";
            this.pnlBudget.Size = new System.Drawing.Size(752, 287);
            this.pnlBudget.Text = "Budget";
            // 
            // itmBudget
            // 
            this.itmBudget.Control = this.grdBudget;
            this.itmBudget.CustomizationFormText = "Budget";
            this.itmBudget.Location = new System.Drawing.Point(0, 0);
            this.itmBudget.Name = "itmBudget";
            this.itmBudget.Size = new System.Drawing.Size(728, 244);
            this.itmBudget.Text = "Budget";
            this.itmBudget.TextSize = new System.Drawing.Size(0, 0);
            this.itmBudget.TextToControlDistance = 0;
            this.itmBudget.TextVisible = false;
            // 
            // grdBudget
            // 
            this.grdBudget.DataSource = this.BindingSource;
            this.grdBudget.Location = new System.Drawing.Point(24, 146);
            this.grdBudget.MainView = this.grvBudget;
            this.grdBudget.MenuManager = this.RibbonControl;
            this.grdBudget.Name = "grdBudget";
            this.grdBudget.Size = new System.Drawing.Size(724, 240);
            this.grdBudget.TabIndex = 6;
            this.grdBudget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBudget});
            // 
            // grvBudget
            // 
            this.grvBudget.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colControl,
            this.colCodeMain,
            this.colCodeSub,
            this.colName,
            this.colTotal});
            this.grvBudget.GridControl = this.grdBudget;
            this.grvBudget.GroupCount = 1;
            this.grvBudget.Name = "grvBudget";
            this.grvBudget.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvBudget.OptionsDetail.EnableMasterViewMode = false;
            this.grvBudget.OptionsView.ShowAutoFilterRow = true;
            this.grvBudget.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colControl, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvBudget.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvBudget_CustomUnboundColumnData);
            // 
            // colControl
            // 
            this.colControl.FieldName = "Control";
            this.colControl.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colControl.Name = "colControl";
            this.colControl.OptionsColumn.AllowEdit = false;
            this.colControl.OptionsColumn.AllowFocus = false;
            this.colControl.OptionsColumn.ReadOnly = true;
            // 
            // colCodeMain
            // 
            this.colCodeMain.FieldName = "CodeMain";
            this.colCodeMain.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colCodeMain.MaxWidth = 70;
            this.colCodeMain.MinWidth = 70;
            this.colCodeMain.Name = "colCodeMain";
            this.colCodeMain.OptionsColumn.AllowEdit = false;
            this.colCodeMain.OptionsColumn.AllowFocus = false;
            this.colCodeMain.OptionsColumn.ReadOnly = true;
            this.colCodeMain.Visible = true;
            this.colCodeMain.VisibleIndex = 0;
            this.colCodeMain.Width = 70;
            // 
            // colCodeSub
            // 
            this.colCodeSub.FieldName = "CodeSub";
            this.colCodeSub.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colCodeSub.MaxWidth = 70;
            this.colCodeSub.MinWidth = 70;
            this.colCodeSub.Name = "colCodeSub";
            this.colCodeSub.OptionsColumn.AllowEdit = false;
            this.colCodeSub.OptionsColumn.AllowFocus = false;
            this.colCodeSub.OptionsColumn.ReadOnly = true;
            this.colCodeSub.Visible = true;
            this.colCodeSub.VisibleIndex = 1;
            this.colCodeSub.Width = 70;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colName.MinWidth = 140;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Year Total";
            this.colTotal.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTotal.FieldName = "Total";
            this.colTotal.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colTotal.MaxWidth = 80;
            this.colTotal.MinWidth = 80;
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.AllowFocus = false;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 3;
            this.colTotal.Width = 80;
            // 
            // BudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "BudgetForm";
            this.SuperTipParameter = "budget";
            this.TabIcon = global::CDS.Client.Desktop.Accounting.Properties.Resources.money_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Accounting.Properties.Resources.money_16;
            this.Text = "Budgets";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFinancialYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFinancialYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radAccountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmControlAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radControlAccounts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBudget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit ddlFinancialYear;
        private DevExpress.XtraLayout.LayoutControlItem itmFinancialYear;
        private DevExpress.XtraGrid.GridControl grdBudget;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBudget;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup pnlBudget;
        private DevExpress.XtraLayout.LayoutControlItem itmBudget;
        private DevExpress.XtraGrid.Columns.GridColumn colControl;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSub;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraLayout.LayoutControlItem itmAccountType;
        private DevExpress.XtraEditors.RadioGroup radControlAccounts;
        private DevExpress.XtraEditors.RadioGroup radAccountType;
        private DevExpress.XtraLayout.LayoutControlItem itmControlAccounts;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
