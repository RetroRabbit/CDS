namespace CDS.Client.Desktop.Accounting
{
    partial class AccountList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountList));
            this.ddlTypes = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ddlAccount = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ddlAging = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ddlHeaders = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grvAccounts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colControl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemDefaultAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalanceGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemDefaultAccount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).BeginInit();
            this.LayoutControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlHeaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl.Size = new System.Drawing.Size(1018, 619);
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAccounts,
            this.grvLines});
            // 
            // GridView
            // 
            this.GridView.ActiveFilterString = "[EntityId.Archived] = False";
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colCodeMain,
            this.colCodeSub,
            this.colName,
            this.colDescription,
            this.colBalanceGroup,
            this.colCodeType,
            this.colAmount,
            this.colArchived,
            this.colSystemDefaultAccount1});
            this.GridView.GroupCount = 2;
            this.GridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowFooter = true;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeMain, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // LayoutControlGrid
            // 
            this.LayoutControlGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControlGrid.Size = new System.Drawing.Size(1022, 623);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(1022, 623);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(1022, 623);
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.GLX_Account);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RibbonControl.Size = new System.Drawing.Size(1022, 144);
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
            // ddlTypes
            // 
            this.ddlTypes.AutoHeight = false;
            this.ddlTypes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlTypes.DisplayMember = "Code";
            this.ddlTypes.Name = "ddlTypes";
            this.ddlTypes.ValueMember = "Id";
            // 
            // ddlAccount
            // 
            this.ddlAccount.AutoHeight = false;
            this.ddlAccount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAccount.DisplayMember = "Code";
            this.ddlAccount.Name = "ddlAccount";
            this.ddlAccount.ValueMember = "Id";
            // 
            // ddlAging
            // 
            this.ddlAging.AutoHeight = false;
            this.ddlAging.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAging.DisplayMember = "Code";
            this.ddlAging.Name = "ddlAging";
            this.ddlAging.NullText = "Aging has no value";
            this.ddlAging.ValueMember = "Id";
            // 
            // ddlHeaders
            // 
            this.ddlHeaders.AutoHeight = false;
            this.ddlHeaders.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlHeaders.DisplayMember = "Description";
            this.ddlHeaders.Name = "ddlHeaders";
            this.ddlHeaders.ValueMember = "Id";
            // 
            // grvAccounts
            // 
            this.grvAccounts.GridControl = this.GridControl;
            this.grvAccounts.Name = "grvAccounts";
            // 
            // grvLines
            // 
            this.grvLines.GridControl = this.GridControl;
            this.grvLines.Name = "grvLines";
            // 
            // colControl
            // 
            this.colControl.FieldName = "Control";
            this.colControl.Name = "colControl";
            this.colControl.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colControl.Visible = true;
            this.colControl.VisibleIndex = 0;
            // 
            // colCodeMain
            // 
            this.colCodeMain.Caption = "Code Main";
            this.colCodeMain.FieldName = "EntityId.CodeMain";
            this.colCodeMain.MaxWidth = 70;
            this.colCodeMain.MinWidth = 70;
            this.colCodeMain.Name = "colCodeMain";
            this.colCodeMain.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodeMain.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCodeMain.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCodeMain.Visible = true;
            this.colCodeMain.VisibleIndex = 0;
            this.colCodeMain.Width = 70;
            // 
            // colCodeSub
            // 
            this.colCodeSub.Caption = "Code Sub";
            this.colCodeSub.FieldName = "EntityId.CodeSub";
            this.colCodeSub.MaxWidth = 70;
            this.colCodeSub.MinWidth = 70;
            this.colCodeSub.Name = "colCodeSub";
            this.colCodeSub.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodeSub.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCodeSub.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCodeSub.Visible = true;
            this.colCodeSub.VisibleIndex = 0;
            this.colCodeSub.Width = 112;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "EntityId.Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 281;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "EntityId.Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colDescription.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 945;
            // 
            // colCodeType
            // 
            this.colCodeType.Caption = "Type";
            this.colCodeType.FieldName = "AccountTypeId.Name";
            this.colCodeType.Name = "colCodeType";
            this.colCodeType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodeType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCodeType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCodeType.Visible = true;
            this.colCodeType.VisibleIndex = 6;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Balance";
            this.colAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount.FieldName = "EntityId.AccountBalance";
            this.colAmount.MaxWidth = 150;
            this.colAmount.MinWidth = 150;
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colAmount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EntityId.AccountBalance", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 4;
            this.colAmount.Width = 150;
            // 
            // colSystemDefaultAccount
            // 
            this.colSystemDefaultAccount.FieldName = "SystemDefaultAccount";
            this.colSystemDefaultAccount.Name = "colSystemDefaultAccount";
            this.colSystemDefaultAccount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colSystemDefaultAccount.Width = 165;
            // 
            // colBalanceGroup
            // 
            this.colBalanceGroup.Caption = "Balance Group";
            this.colBalanceGroup.FieldName = "BalanceGroup";
            this.colBalanceGroup.Name = "colBalanceGroup";
            this.colBalanceGroup.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBalanceGroup.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colBalanceGroup.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Title";
            this.colTitle.FieldName = "EntityId.Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTitle.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colTitle.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 1;
            // 
            // colArchived
            // 
            this.colArchived.Caption = "Archived";
            this.colArchived.FieldName = "EntityId.Archived";
            this.colArchived.Name = "colArchived";
            this.colArchived.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colSystemDefaultAccount1
            // 
            this.colSystemDefaultAccount1.Caption = "System Default Account";
            this.colSystemDefaultAccount1.FieldName = "EntityId.SiteAccount";
            this.colSystemDefaultAccount1.Name = "colSystemDefaultAccount1";
            this.colSystemDefaultAccount1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // AccountList
            // 
            this.ActiveFilter = "[EntityId.Archived] = False";
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1022, 767);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "AccountList";
            this.SuperTipParameter = "account";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.Text = "Accounts";
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).EndInit();
            this.LayoutControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlHeaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlTypes;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlAccount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlAging;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlHeaders;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAccounts;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLines;
        private DevExpress.XtraGrid.Columns.GridColumn colControl;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSub;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeType;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemDefaultAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colArchived;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemDefaultAccount1;
    }
}
