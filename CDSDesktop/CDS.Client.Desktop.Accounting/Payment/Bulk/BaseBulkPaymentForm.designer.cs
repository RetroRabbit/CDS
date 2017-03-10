namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    partial class BaseBulkPaymentForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseBulkPaymentForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.grvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemsChecked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgingIdItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriptionItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodIdItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrackNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEntries = new DevExpress.XtraGrid.GridControl();
            this.grvEntries = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPeriodId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPeriod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourcePeriod = new DevExpress.Data.Linq.LinqServerModeSource();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAccountId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlContraAccount = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.ServerModeSourceContraAccount = new DevExpress.Data.Linq.LinqServerModeSource();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgingId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlAging = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourceAging = new DevExpress.Data.Linq.LinqServerModeSource();
            this.colSettlement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPeriodAll = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourcePeriodAll = new DevExpress.Data.Linq.LinqServerModeSource();
            this.pnlAccount = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ServerModeSourceAccount = new DevExpress.Data.Linq.LinqServerModeSource();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeMain2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSub2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmSettlementAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlSettlementAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ServerModeSourceSettlementAccount = new DevExpress.Data.Linq.LinqServerModeSource();
            this.gridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeMain1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSub1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmEntries = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnImportStatement = new DevExpress.XtraBars.BarButtonItem();
            this.btnBulkEntryRules = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemsChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContraAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContraAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPeriodAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriodAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSettlementAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSettlementAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceSettlementAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.Desktop.Accounting.Payment.Bulk.BulkPaymentEntry);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.grdEntries);
            this.LayoutControl.Controls.Add(this.ddlSettlementAccount);
            this.LayoutControl.Controls.Add(this.ddlAccount);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.Size = new System.Drawing.Size(754, 384);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pnlAccount,
            this.itmEntries});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(754, 384);
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnImportStatement,
            this.btnBulkEntryRules});
            this.RibbonControl.MaxItemId = 25;
            this.RibbonControl.Size = new System.Drawing.Size(754, 140);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnImportStatement, true);
            this.rpgActions.ItemLinks.Add(this.btnBulkEntryRules);
            // 
            // grvItems
            // 
            this.grvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChecked,
            this.colType,
            this.colAgingIdItem,
            this.colReferenceItem,
            this.colDescriptionItem,
            this.colDateItem,
            this.colPeriodIdItem,
            this.colTrackNumber,
            this.colBalance});
            this.grvItems.GridControl = this.grdEntries;
            this.grvItems.Name = "grvItems";
            this.grvItems.OptionsView.ShowFooter = true;
            this.grvItems.OptionsView.ShowGroupPanel = false;
            this.grvItems.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDateItem, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvItems.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grvItems_CustomSummaryCalculate);
            // 
            // colChecked
            // 
            this.colChecked.Caption = " ";
            this.colChecked.ColumnEdit = this.repItemsChecked;
            this.colChecked.FieldName = "Checked";
            this.colChecked.MaxWidth = 40;
            this.colChecked.MinWidth = 40;
            this.colChecked.Name = "colChecked";
            this.colChecked.Visible = true;
            this.colChecked.VisibleIndex = 0;
            this.colChecked.Width = 40;
            // 
            // repItemsChecked
            // 
            this.repItemsChecked.AutoHeight = false;
            this.repItemsChecked.Name = "repItemsChecked";
            this.repItemsChecked.CheckedChanged += new System.EventHandler(this.repItemsChecked_CheckedChanged);
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.MaxWidth = 40;
            this.colType.MinWidth = 40;
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowEdit = false;
            this.colType.OptionsColumn.ReadOnly = true;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            this.colType.Width = 40;
            // 
            // colAgingIdItem
            // 
            this.colAgingIdItem.Caption = "Aging";
            this.colAgingIdItem.FieldName = "AgingId";
            this.colAgingIdItem.MaxWidth = 60;
            this.colAgingIdItem.MinWidth = 60;
            this.colAgingIdItem.Name = "colAgingIdItem";
            this.colAgingIdItem.OptionsColumn.AllowEdit = false;
            this.colAgingIdItem.OptionsColumn.ReadOnly = true;
            this.colAgingIdItem.Visible = true;
            this.colAgingIdItem.VisibleIndex = 3;
            this.colAgingIdItem.Width = 60;
            // 
            // colReferenceItem
            // 
            this.colReferenceItem.FieldName = "Reference";
            this.colReferenceItem.Name = "colReferenceItem";
            this.colReferenceItem.OptionsColumn.AllowEdit = false;
            this.colReferenceItem.OptionsColumn.ReadOnly = true;
            this.colReferenceItem.Visible = true;
            this.colReferenceItem.VisibleIndex = 4;
            this.colReferenceItem.Width = 64;
            // 
            // colDescriptionItem
            // 
            this.colDescriptionItem.FieldName = "Description";
            this.colDescriptionItem.Name = "colDescriptionItem";
            this.colDescriptionItem.OptionsColumn.AllowEdit = false;
            this.colDescriptionItem.OptionsColumn.ReadOnly = true;
            this.colDescriptionItem.Visible = true;
            this.colDescriptionItem.VisibleIndex = 5;
            this.colDescriptionItem.Width = 36;
            // 
            // colDateItem
            // 
            this.colDateItem.FieldName = "Date";
            this.colDateItem.MaxWidth = 120;
            this.colDateItem.MinWidth = 120;
            this.colDateItem.Name = "colDateItem";
            this.colDateItem.OptionsColumn.AllowEdit = false;
            this.colDateItem.OptionsColumn.ReadOnly = true;
            this.colDateItem.Visible = true;
            this.colDateItem.VisibleIndex = 2;
            this.colDateItem.Width = 120;
            // 
            // colPeriodIdItem
            // 
            this.colPeriodIdItem.Caption = "Period";
            this.colPeriodIdItem.FieldName = "PeriodId";
            this.colPeriodIdItem.Name = "colPeriodIdItem";
            this.colPeriodIdItem.OptionsColumn.AllowEdit = false;
            this.colPeriodIdItem.OptionsColumn.ReadOnly = true;
            // 
            // colTrackNumber
            // 
            this.colTrackNumber.FieldName = "TrackNumber";
            this.colTrackNumber.MaxWidth = 100;
            this.colTrackNumber.MinWidth = 100;
            this.colTrackNumber.Name = "colTrackNumber";
            this.colTrackNumber.OptionsColumn.AllowEdit = false;
            this.colTrackNumber.OptionsColumn.ReadOnly = true;
            this.colTrackNumber.Visible = true;
            this.colTrackNumber.VisibleIndex = 6;
            this.colTrackNumber.Width = 100;
            // 
            // colBalance
            // 
            this.colBalance.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBalance.FieldName = "Balance";
            this.colBalance.MaxWidth = 120;
            this.colBalance.MinWidth = 120;
            this.colBalance.Name = "colBalance";
            this.colBalance.OptionsColumn.AllowEdit = false;
            this.colBalance.OptionsColumn.ReadOnly = true;
            this.colBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Balance", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 7;
            this.colBalance.Width = 120;
            // 
            // grdEntries
            // 
            this.grdEntries.DataSource = this.BindingSource;
            gridLevelNode1.LevelTemplate = this.grvItems;
            gridLevelNode1.RelationName = "BulkPaymentItems";
            this.grdEntries.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdEntries.Location = new System.Drawing.Point(12, 103);
            this.grdEntries.MainView = this.grvEntries;
            this.grdEntries.MenuManager = this.RibbonControl;
            this.grdEntries.Name = "grdEntries";
            this.grdEntries.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repPeriod,
            this.repPeriodAll,
            this.dtDate,
            this.ddlAging,
            this.ddlContraAccount,
            this.repItemsChecked});
            this.grdEntries.Size = new System.Drawing.Size(730, 269);
            this.grdEntries.TabIndex = 6;
            this.grdEntries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEntries,
            this.grvItems});
            this.grdEntries.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdEntries_ProcessGridKey);
            // 
            // grvEntries
            // 
            this.grvEntries.ChildGridLevelName = "BulkPaymentItems";
            this.grvEntries.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPeriodId,
            this.colDate,
            this.colAccountId,
            this.colReference,
            this.colDescription,
            this.colAgingId,
            this.colSettlement,
            this.colAmount});
            this.grvEntries.GridControl = this.grdEntries;
            this.grvEntries.Name = "grvEntries";
            this.grvEntries.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvEntries.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvEntries.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.grvEntries.OptionsCustomization.AllowFilter = false;
            this.grvEntries.OptionsCustomization.AllowGroup = false;
            this.grvEntries.OptionsDetail.ShowDetailTabs = false;
            this.grvEntries.OptionsView.ShowFooter = true;
            this.grvEntries.OptionsView.ShowGroupPanel = false;
            this.grvEntries.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvEntries_ShowingEditor);
            this.grvEntries.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvEntries_CellValueChanged);
            this.grvEntries.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvEntries_InvalidRowException);
            this.grvEntries.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvEntries_ValidateRow);
            this.grvEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvEntries_KeyDown);
            this.grvEntries.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvEntries_ValidatingEditor);
            // 
            // colPeriodId
            // 
            this.colPeriodId.Caption = "Period";
            this.colPeriodId.ColumnEdit = this.repPeriod;
            this.colPeriodId.FieldName = "PeriodId";
            this.colPeriodId.MaxWidth = 120;
            this.colPeriodId.MinWidth = 120;
            this.colPeriodId.Name = "colPeriodId";
            this.colPeriodId.Visible = true;
            this.colPeriodId.VisibleIndex = 0;
            this.colPeriodId.Width = 133;
            // 
            // repPeriod
            // 
            this.repPeriod.AutoHeight = false;
            this.repPeriod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPeriod.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.repPeriod.DataSource = this.ServerModeSourcePeriod;
            this.repPeriod.DisplayMember = "Code";
            this.repPeriod.Name = "repPeriod";
            this.repPeriod.NullText = "Select period ...";
            this.repPeriod.ValueMember = "Id";
            // 
            // ServerModeSourcePeriod
            // 
            this.ServerModeSourcePeriod.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Period);
            this.ServerModeSourcePeriod.KeyExpression = "[Id]";
            // 
            // colDate
            // 
            this.colDate.ColumnEdit = this.dtDate;
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 120;
            this.colDate.MinWidth = 120;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 120;
            // 
            // dtDate
            // 
            this.dtDate.AutoHeight = false;
            this.dtDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate.Name = "dtDate";
            // 
            // colAccountId
            // 
            this.colAccountId.Caption = "Contra Account";
            this.colAccountId.ColumnEdit = this.ddlContraAccount;
            this.colAccountId.FieldName = "AccountId";
            this.colAccountId.Name = "colAccountId";
            this.colAccountId.Visible = true;
            this.colAccountId.VisibleIndex = 3;
            this.colAccountId.Width = 83;
            // 
            // ddlContraAccount
            // 
            this.ddlContraAccount.AutoHeight = false;
            this.ddlContraAccount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlContraAccount.DataSource = this.ServerModeSourceContraAccount;
            this.ddlContraAccount.DisplayMember = "Title";
            this.ddlContraAccount.Name = "ddlContraAccount";
            this.ddlContraAccount.NullText = "Select account ...";
            this.ddlContraAccount.ValueMember = "Id";
            this.ddlContraAccount.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // ServerModeSourceContraAccount
            // 
            this.ServerModeSourceContraAccount.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.ServerModeSourceContraAccount.KeyExpression = "[Id]";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeMain,
            this.colCodeSub,
            this.colName});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemGridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeMain, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeSub, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCodeMain
            // 
            this.colCodeMain.FieldName = "CodeMain";
            this.colCodeMain.Name = "colCodeMain";
            this.colCodeMain.Visible = true;
            this.colCodeMain.VisibleIndex = 0;
            // 
            // colCodeSub
            // 
            this.colCodeSub.FieldName = "CodeSub";
            this.colCodeSub.Name = "colCodeSub";
            this.colCodeSub.Visible = true;
            this.colCodeSub.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colReference
            // 
            this.colReference.FieldName = "Reference";
            this.colReference.Name = "colReference";
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 4;
            this.colReference.Width = 95;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            this.colDescription.Width = 87;
            // 
            // colAgingId
            // 
            this.colAgingId.Caption = "Aging";
            this.colAgingId.ColumnEdit = this.ddlAging;
            this.colAgingId.FieldName = "AgingId";
            this.colAgingId.MaxWidth = 60;
            this.colAgingId.MinWidth = 60;
            this.colAgingId.Name = "colAgingId";
            this.colAgingId.Visible = true;
            this.colAgingId.VisibleIndex = 2;
            this.colAgingId.Width = 60;
            // 
            // ddlAging
            // 
            this.ddlAging.AutoHeight = false;
            this.ddlAging.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAging.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlAging.DataSource = this.ServerModeSourceAging;
            this.ddlAging.DisplayMember = "Code";
            this.ddlAging.Name = "ddlAging";
            this.ddlAging.NullText = "Select aging ...";
            this.ddlAging.ValueMember = "Id";
            // 
            // ServerModeSourceAging
            // 
            this.ServerModeSourceAging.ElementType = typeof(CDS.Client.DataAccessLayer.DB.GLX_Aging);
            this.ServerModeSourceAging.KeyExpression = "[Id]";
            // 
            // colSettlement
            // 
            this.colSettlement.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colSettlement.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSettlement.FieldName = "Settlement";
            this.colSettlement.MaxWidth = 120;
            this.colSettlement.MinWidth = 120;
            this.colSettlement.Name = "colSettlement";
            this.colSettlement.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Settlement", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colSettlement.Visible = true;
            this.colSettlement.VisibleIndex = 6;
            this.colSettlement.Width = 120;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 120;
            this.colAmount.MinWidth = 120;
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 7;
            this.colAmount.Width = 120;
            // 
            // repPeriodAll
            // 
            this.repPeriodAll.AutoHeight = false;
            this.repPeriodAll.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPeriodAll.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.repPeriodAll.DataSource = this.ServerModeSourcePeriodAll;
            this.repPeriodAll.DisplayMember = "Code";
            this.repPeriodAll.Name = "repPeriodAll";
            this.repPeriodAll.NullText = "Select period ...";
            this.repPeriodAll.ValueMember = "Id";
            // 
            // ServerModeSourcePeriodAll
            // 
            this.ServerModeSourcePeriodAll.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Period);
            this.ServerModeSourcePeriodAll.KeyExpression = "[Id]";
            // 
            // pnlAccount
            // 
            this.pnlAccount.CustomizationFormText = "Account";
            this.pnlAccount.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAccount,
            this.itmSettlementAccount});
            this.pnlAccount.Location = new System.Drawing.Point(0, 0);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(734, 91);
            this.pnlAccount.Text = "Account";
            // 
            // itmAccount
            // 
            this.itmAccount.Control = this.ddlAccount;
            this.itmAccount.CustomizationFormText = "Account";
            this.itmAccount.Location = new System.Drawing.Point(0, 0);
            this.itmAccount.Name = "itmAccount";
            this.itmAccount.Size = new System.Drawing.Size(710, 24);
            this.itmAccount.Text = "Account";
            this.itmAccount.TextSize = new System.Drawing.Size(94, 13);
            // 
            // ddlAccount
            // 
            this.ddlAccount.EditValue = "";
            this.ddlAccount.Location = new System.Drawing.Point(122, 43);
            this.ddlAccount.MenuManager = this.RibbonControl;
            this.ddlAccount.Name = "ddlAccount";
            this.ddlAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAccount.Properties.DataSource = this.ServerModeSourceAccount;
            this.ddlAccount.Properties.DisplayMember = "Title";
            this.ddlAccount.Properties.NullText = "Select account ...";
            this.ddlAccount.Properties.ValueMember = "Id";
            this.ddlAccount.Properties.View = this.gridLookUpEdit1View;
            this.ddlAccount.Size = new System.Drawing.Size(608, 20);
            this.ddlAccount.StyleController = this.LayoutControl;
            this.ddlAccount.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.ValidationProvider.SetValidationRule(this.ddlAccount, conditionValidationRule2);
            // 
            // ServerModeSourceAccount
            // 
            this.ServerModeSourceAccount.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.ServerModeSourceAccount.KeyExpression = "[Id]";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeMain2,
            this.colCodeSub2,
            this.colName2,
            this.colDescription2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeMain2, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeSub2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCodeMain2
            // 
            this.colCodeMain2.FieldName = "CodeMain";
            this.colCodeMain2.Name = "colCodeMain2";
            this.colCodeMain2.Visible = true;
            this.colCodeMain2.VisibleIndex = 0;
            // 
            // colCodeSub2
            // 
            this.colCodeSub2.FieldName = "CodeSub";
            this.colCodeSub2.Name = "colCodeSub2";
            this.colCodeSub2.Visible = true;
            this.colCodeSub2.VisibleIndex = 1;
            // 
            // colName2
            // 
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 2;
            // 
            // colDescription2
            // 
            this.colDescription2.FieldName = "Description";
            this.colDescription2.Name = "colDescription2";
            this.colDescription2.Visible = true;
            this.colDescription2.VisibleIndex = 3;
            // 
            // itmSettlementAccount
            // 
            this.itmSettlementAccount.Control = this.ddlSettlementAccount;
            this.itmSettlementAccount.CustomizationFormText = "Settlement Account";
            this.itmSettlementAccount.Location = new System.Drawing.Point(0, 24);
            this.itmSettlementAccount.Name = "itmSettlementAccount";
            this.itmSettlementAccount.Size = new System.Drawing.Size(710, 24);
            this.itmSettlementAccount.Text = "Settlement Account";
            this.itmSettlementAccount.TextSize = new System.Drawing.Size(94, 13);
            // 
            // ddlSettlementAccount
            // 
            this.ddlSettlementAccount.EditValue = "";
            this.ddlSettlementAccount.Location = new System.Drawing.Point(122, 67);
            this.ddlSettlementAccount.MenuManager = this.RibbonControl;
            this.ddlSettlementAccount.Name = "ddlSettlementAccount";
            this.ddlSettlementAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlSettlementAccount.Properties.DataSource = this.ServerModeSourceSettlementAccount;
            this.ddlSettlementAccount.Properties.DisplayMember = "Title";
            this.ddlSettlementAccount.Properties.NullText = "Select Account ...";
            this.ddlSettlementAccount.Properties.ValueMember = "Id";
            this.ddlSettlementAccount.Properties.View = this.gridLookUpEdit2View;
            this.ddlSettlementAccount.Size = new System.Drawing.Size(608, 20);
            this.ddlSettlementAccount.StyleController = this.LayoutControl;
            this.ddlSettlementAccount.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.ValidationProvider.SetValidationRule(this.ddlSettlementAccount, conditionValidationRule1);
            // 
            // ServerModeSourceSettlementAccount
            // 
            this.ServerModeSourceSettlementAccount.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.ServerModeSourceSettlementAccount.KeyExpression = "[Id]";
            // 
            // gridLookUpEdit2View
            // 
            this.gridLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeMain1,
            this.colCodeSub1,
            this.colName1,
            this.colDescription1});
            this.gridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit2View.Name = "gridLookUpEdit2View";
            this.gridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // colCodeMain1
            // 
            this.colCodeMain1.FieldName = "CodeMain";
            this.colCodeMain1.Name = "colCodeMain1";
            this.colCodeMain1.Visible = true;
            this.colCodeMain1.VisibleIndex = 0;
            // 
            // colCodeSub1
            // 
            this.colCodeSub1.FieldName = "CodeSub";
            this.colCodeSub1.Name = "colCodeSub1";
            this.colCodeSub1.Visible = true;
            this.colCodeSub1.VisibleIndex = 1;
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 2;
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.Visible = true;
            this.colDescription1.VisibleIndex = 3;
            // 
            // itmEntries
            // 
            this.itmEntries.Control = this.grdEntries;
            this.itmEntries.CustomizationFormText = "Grid Entries";
            this.itmEntries.Location = new System.Drawing.Point(0, 91);
            this.itmEntries.Name = "itmEntries";
            this.itmEntries.Size = new System.Drawing.Size(734, 273);
            this.itmEntries.Text = "Grid Entries";
            this.itmEntries.TextSize = new System.Drawing.Size(0, 0);
            this.itmEntries.TextToControlDistance = 0;
            this.itmEntries.TextVisible = false;
            // 
            // btnImportStatement
            // 
            this.btnImportStatement.Caption = "Import Statement";
            this.btnImportStatement.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImportStatement.Glyph")));
            this.btnImportStatement.Id = 23;
            this.btnImportStatement.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImportStatement.LargeGlyph")));
            this.btnImportStatement.Name = "btnImportStatement";
            toolTipTitleItem1.Text = "Import Statement";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click this button to show the import statement dialogue";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnImportStatement.SuperTip = superToolTip1;
            this.btnImportStatement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportStatement_ItemClick);
            // 
            // btnBulkEntryRules
            // 
            this.btnBulkEntryRules.Caption = "Bulk Entry Rules";
            this.btnBulkEntryRules.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBulkEntryRules.Glyph")));
            this.btnBulkEntryRules.Id = 24;
            this.btnBulkEntryRules.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBulkEntryRules.LargeGlyph")));
            this.btnBulkEntryRules.Name = "btnBulkEntryRules";
            toolTipTitleItem2.Text = "Bulk Entry Rules";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Click this button to show the Bulk Entry Rules dialogue.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnBulkEntryRules.SuperTip = superToolTip2;
            this.btnBulkEntryRules.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBulkEntryRules_ItemClick);
            // 
            // BaseBulkPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(766, 536);
            this.Name = "BaseBulkPaymentForm";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemsChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContraAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContraAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPeriodAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriodAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSettlementAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSettlementAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceSettlementAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup pnlAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit2View;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem itmAccount;
        private DevExpress.XtraLayout.LayoutControlItem itmSettlementAccount;
        protected DevExpress.XtraGrid.GridControl grdEntries;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvEntries;
        protected DevExpress.XtraLayout.LayoutControlItem itmEntries;
        protected DevExpress.XtraGrid.Views.Grid.GridView grvItems;
        private DevExpress.XtraBars.BarButtonItem btnImportStatement;
        private DevExpress.XtraBars.BarButtonItem btnBulkEntryRules;
        protected DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePeriod;
        protected DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAccount;
        protected DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAging;
        protected DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceContraAccount;
        protected DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceSettlementAccount;
        protected DevExpress.XtraGrid.Columns.GridColumn colChecked;
        protected DevExpress.XtraGrid.Columns.GridColumn colType;
        protected DevExpress.XtraGrid.Columns.GridColumn colAgingIdItem;
        protected DevExpress.XtraGrid.Columns.GridColumn colReferenceItem;
        protected DevExpress.XtraGrid.Columns.GridColumn colDescriptionItem;
        protected DevExpress.XtraGrid.Columns.GridColumn colDateItem;
        protected DevExpress.XtraGrid.Columns.GridColumn colPeriodIdItem;
        protected DevExpress.XtraGrid.Columns.GridColumn colTrackNumber;
        protected DevExpress.XtraGrid.Columns.GridColumn colBalance;
        protected DevExpress.XtraGrid.Columns.GridColumn colPeriodId;
        protected DevExpress.XtraGrid.Columns.GridColumn colDate;
        protected DevExpress.XtraGrid.Columns.GridColumn colAccountId;
        protected DevExpress.XtraGrid.Columns.GridColumn colReference;
        protected DevExpress.XtraGrid.Columns.GridColumn colDescription;
        protected DevExpress.XtraGrid.Columns.GridColumn colAgingId;
        protected DevExpress.XtraGrid.Columns.GridColumn colSettlement;
        protected DevExpress.XtraGrid.Columns.GridColumn colAmount;
        protected DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePeriodAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repPeriod;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ddlContraAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSub;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlAging;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repPeriodAll;
        protected DevExpress.XtraEditors.GridLookUpEdit ddlSettlementAccount;
        protected DevExpress.XtraEditors.GridLookUpEdit ddlAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain1;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSub1;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription1;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain2;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSub2;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemsChecked;
    }
}
