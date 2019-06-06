namespace CDS.Client.Desktop.Accounting.Entry
{
    partial class BulkEntryForm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkEntryForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.grdEntries = new DevExpress.XtraGrid.GridControl();
            this.grvEntries = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlContraAccount = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.ServerModeSourceAccount = new DevExpress.Data.Linq.LinqServerModeSource();
            this.repViewContraAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgingId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlAgingId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourceAging = new DevExpress.Data.Linq.LinqServerModeSource();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlTax = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourceTax = new DevExpress.Data.Linq.LinqServerModeSource();
            this.colExclusive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInclusive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlPeriod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourcePeriod = new DevExpress.Data.Linq.LinqServerModeSource();
            this.InstantFeedbackSourceAccount = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.itmEntries = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlAccount = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlAccount = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkAutoPost = new DevExpress.XtraEditors.CheckEdit();
            this.itmStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.BindingSourceHeader = new System.Windows.Forms.BindingSource();
            this.ServerModeSourceStatus = new DevExpress.Data.Linq.LinqServerModeSource();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkNewTrackNumber = new DevExpress.XtraEditors.CheckEdit();
            this.itmTrackNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTrackNumber = new DevExpress.XtraEditors.TextEdit();
            this.itmAging = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlAging = new DevExpress.XtraEditors.LookUpEdit();
            this.itmTotal = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.pnlEntries = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnBulkEntryRules = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportStatement = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContraAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewContraAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgingId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoPost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNewTrackNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTrackNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrackNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAging.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtTotal);
            this.LayoutControl.Controls.Add(this.txtTrackNumber);
            this.LayoutControl.Controls.Add(this.chkNewTrackNumber);
            this.LayoutControl.Controls.Add(this.chkAutoPost);
            this.LayoutControl.Controls.Add(this.ddlAging);
            this.LayoutControl.Controls.Add(this.grdEntries);
            this.LayoutControl.Controls.Add(this.txtStatus);
            this.LayoutControl.Controls.Add(this.ddlAccount);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControl.Size = new System.Drawing.Size(784, 415);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pnlAccount,
            this.pnlEntries});
            this.LayoutGroup.Size = new System.Drawing.Size(784, 415);
            // 
            // rpgNavigation
            // 
            this.rpgNavigation.Visible = false;
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnBulkEntryRules,
            this.btnImportStatement});
            this.RibbonControl.Size = new System.Drawing.Size(784, 147);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnImportStatement, true);
            this.rpgActions.ItemLinks.Add(this.btnBulkEntryRules);
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
            // grdEntries
            // 
            this.grdEntries.DataSource = this.BindingSource;
            this.grdEntries.Location = new System.Drawing.Point(24, 158);
            this.grdEntries.MainView = this.grvEntries;
            this.grdEntries.MenuManager = this.RibbonControl;
            this.grdEntries.Name = "grdEntries";
            this.grdEntries.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ddlPeriod,
            this.ddlTax,
            this.dtDate,
            this.ddlAgingId,
            this.ddlContraAccount});
            this.grdEntries.Size = new System.Drawing.Size(736, 233);
            this.grdEntries.TabIndex = 4;
            this.grdEntries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEntries});
            this.grdEntries.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdEntries_ProcessGridKey);
            // 
            // grvEntries
            // 
            this.grvEntries.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colAccount,
            this.colAgingId,
            this.colReference,
            this.colDescription,
            this.colTax,
            this.colExclusive,
            this.colInclusive});
            this.grvEntries.GridControl = this.grdEntries;
            this.grvEntries.Name = "grvEntries";
            this.grvEntries.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvEntries.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvEntries.OptionsBehavior.AutoPopulateColumns = false;
            this.grvEntries.OptionsCustomization.AllowColumnMoving = false;
            this.grvEntries.OptionsCustomization.AllowFilter = false;
            this.grvEntries.OptionsCustomization.AllowGroup = false;
            this.grvEntries.OptionsCustomization.AllowQuickHideColumns = false;
            this.grvEntries.OptionsCustomization.AllowSort = false;
            this.grvEntries.OptionsFind.AllowFindPanel = false;
            this.grvEntries.OptionsMenu.EnableColumnMenu = false;
            this.grvEntries.OptionsMenu.EnableFooterMenu = false;
            this.grvEntries.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvEntries.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvEntries.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvEntries.OptionsView.ShowDetailButtons = false;
            this.grvEntries.OptionsView.ShowFooter = true;
            this.grvEntries.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.grvEntries.OptionsView.ShowGroupPanel = false;
            this.grvEntries.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvEntries_ShowingEditor);
            this.grvEntries.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvEntries_InitNewRow);
            this.grvEntries.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvEntries_CellValueChanged);
            this.grvEntries.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvEntries_InvalidRowException);
            this.grvEntries.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvEntries_ValidateRow);
            this.grvEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvEntries_KeyDown);
            this.grvEntries.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvEntries_ValidatingEditor);
            // 
            // colDate
            // 
            this.colDate.Caption = "Date";
            this.colDate.ColumnEdit = this.dtDate;
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 80;
            this.colDate.MinWidth = 80;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 80;
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
            // colAccount
            // 
            this.colAccount.Caption = "Contra Account";
            this.colAccount.ColumnEdit = this.ddlContraAccount;
            this.colAccount.FieldName = "AccountId";
            this.colAccount.MaxWidth = 220;
            this.colAccount.MinWidth = 160;
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 0;
            this.colAccount.Width = 160;
            // 
            // ddlContraAccount
            // 
            this.ddlContraAccount.AutoHeight = false;
            this.ddlContraAccount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlContraAccount.DataSource = this.ServerModeSourceAccount;
            this.ddlContraAccount.DisplayMember = "Title";
            this.ddlContraAccount.Name = "ddlContraAccount";
            this.ddlContraAccount.NullText = "Select Account ...";
            this.ddlContraAccount.ValueMember = "Id";
            this.ddlContraAccount.View = this.repViewContraAccount;
            // 
            // ServerModeSourceAccount
            // 
            this.ServerModeSourceAccount.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.ServerModeSourceAccount.KeyExpression = "Id";
            // 
            // repViewContraAccount
            // 
            this.repViewContraAccount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.repViewContraAccount.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repViewContraAccount.Name = "repViewContraAccount";
            this.repViewContraAccount.OptionsCustomization.AllowColumnMoving = false;
            this.repViewContraAccount.OptionsCustomization.AllowColumnResizing = false;
            this.repViewContraAccount.OptionsMenu.EnableColumnMenu = false;
            this.repViewContraAccount.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repViewContraAccount.OptionsView.ShowGroupPanel = false;
            this.repViewContraAccount.OptionsView.ShowIndicator = false;
            this.repViewContraAccount.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Title";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "Description";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "Amount";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // colAgingId
            // 
            this.colAgingId.Caption = "Aging";
            this.colAgingId.ColumnEdit = this.ddlAgingId;
            this.colAgingId.FieldName = "AgingId";
            this.colAgingId.MaxWidth = 100;
            this.colAgingId.MinWidth = 100;
            this.colAgingId.Name = "colAgingId";
            this.colAgingId.Visible = true;
            this.colAgingId.VisibleIndex = 2;
            this.colAgingId.Width = 100;
            // 
            // ddlAgingId
            // 
            this.ddlAgingId.AutoHeight = false;
            this.ddlAgingId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAgingId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlAgingId.DataSource = this.ServerModeSourceAging;
            this.ddlAgingId.DisplayMember = "Name";
            this.ddlAgingId.ImmediatePopup = true;
            this.ddlAgingId.Name = "ddlAgingId";
            this.ddlAgingId.NullText = "Select Aging...";
            this.ddlAgingId.ValueMember = "Id";
            // 
            // ServerModeSourceAging
            // 
            this.ServerModeSourceAging.ElementType = typeof(CDS.Client.DataAccessLayer.DB.GLX_Aging);
            this.ServerModeSourceAging.KeyExpression = "[Id]";
            // 
            // colReference
            // 
            this.colReference.Caption = "Reference";
            this.colReference.FieldName = "Reference";
            this.colReference.MinWidth = 50;
            this.colReference.Name = "colReference";
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 3;
            this.colReference.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 20;
            // 
            // colTax
            // 
            this.colTax.Caption = "Tax";
            this.colTax.ColumnEdit = this.ddlTax;
            this.colTax.FieldName = "TaxId";
            this.colTax.MaxWidth = 35;
            this.colTax.MinWidth = 35;
            this.colTax.Name = "colTax";
            this.colTax.Visible = true;
            this.colTax.VisibleIndex = 5;
            this.colTax.Width = 35;
            // 
            // ddlTax
            // 
            this.ddlTax.AutoHeight = false;
            this.ddlTax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlTax.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Percentage", "Percentage", 65, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlTax.DataSource = this.ServerModeSourceTax;
            this.ddlTax.DisplayMember = "Code";
            this.ddlTax.Name = "ddlTax";
            this.ddlTax.NullText = "-1";
            this.ddlTax.NullValuePrompt = "-1";
            this.ddlTax.ValueMember = "Id";
            // 
            // ServerModeSourceTax
            // 
            this.ServerModeSourceTax.ElementType = typeof(CDS.Client.DataAccessLayer.DB.GLX_Tax);
            this.ServerModeSourceTax.KeyExpression = "[Id]";
            // 
            // colExclusive
            // 
            this.colExclusive.Caption = "Exclusive";
            this.colExclusive.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colExclusive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colExclusive.FieldName = "Exclusive";
            this.colExclusive.MaxWidth = 100;
            this.colExclusive.MinWidth = 100;
            this.colExclusive.Name = "colExclusive";
            this.colExclusive.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Exclusive", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colExclusive.Visible = true;
            this.colExclusive.VisibleIndex = 6;
            this.colExclusive.Width = 100;
            // 
            // colInclusive
            // 
            this.colInclusive.Caption = "Inclusive";
            this.colInclusive.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colInclusive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colInclusive.FieldName = "Inclusive";
            this.colInclusive.MaxWidth = 100;
            this.colInclusive.MinWidth = 100;
            this.colInclusive.Name = "colInclusive";
            this.colInclusive.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Inclusive", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colInclusive.Visible = true;
            this.colInclusive.VisibleIndex = 7;
            this.colInclusive.Width = 100;
            // 
            // ddlPeriod
            // 
            this.ddlPeriod.AutoHeight = false;
            this.ddlPeriod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlPeriod.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 90, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlPeriod.DataSource = this.ServerModeSourcePeriod;
            this.ddlPeriod.DisplayMember = "Code";
            this.ddlPeriod.Name = "ddlPeriod";
            this.ddlPeriod.NullText = "Select Period...";
            this.ddlPeriod.ValueMember = "Id";
            // 
            // ServerModeSourcePeriod
            // 
            this.ServerModeSourcePeriod.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Period);
            this.ServerModeSourcePeriod.KeyExpression = "[Id]";
            // 
            // InstantFeedbackSourceAccount
            // 
            this.InstantFeedbackSourceAccount.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.InstantFeedbackSourceAccount.KeyExpression = "Id";
            this.InstantFeedbackSourceAccount.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceAccount_GetQueryable);
            // 
            // itmEntries
            // 
            this.itmEntries.Control = this.grdEntries;
            this.itmEntries.CustomizationFormText = "Entries";
            this.itmEntries.Location = new System.Drawing.Point(0, 0);
            this.itmEntries.Name = "itmEntries";
            this.itmEntries.Size = new System.Drawing.Size(740, 237);
            this.itmEntries.Text = "Entries";
            this.itmEntries.TextSize = new System.Drawing.Size(0, 0);
            this.itmEntries.TextVisible = false;
            // 
            // itmAccount
            // 
            this.itmAccount.Control = this.ddlAccount;
            this.itmAccount.CustomizationFormText = "Account";
            this.itmAccount.Location = new System.Drawing.Point(0, 0);
            this.itmAccount.Name = "itmAccount";
            this.itmAccount.Size = new System.Drawing.Size(740, 24);
            this.itmAccount.Text = "Account";
            this.itmAccount.TextSize = new System.Drawing.Size(66, 13);
            // 
            // ddlAccount
            // 
            this.ddlAccount.EnterMoveNextControl = true;
            this.ddlAccount.Location = new System.Drawing.Point(94, 43);
            this.ddlAccount.MenuManager = this.RibbonControl;
            this.ddlAccount.Name = "ddlAccount";
            this.ddlAccount.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.ddlAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAccount.Properties.DataSource = this.InstantFeedbackSourceAccount;
            this.ddlAccount.Properties.DisplayMember = "Title";
            this.ddlAccount.Properties.NullText = "Select Account...";
            this.ddlAccount.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ddlAccount.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.ddlAccount.Properties.ValueMember = "Id";
            this.ddlAccount.Properties.View = this.searchLookUpEdit1View;
            this.ddlAccount.Size = new System.Drawing.Size(666, 20);
            this.ddlAccount.StyleController = this.LayoutControl;
            this.ddlAccount.TabIndex = 5;
            this.ddlAccount.EditValueChanged += new System.EventHandler(this.ddlAccount_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsCustomization.AllowColumnMoving = false;
            this.searchLookUpEdit1View.OptionsCustomization.AllowColumnResizing = false;
            this.searchLookUpEdit1View.OptionsMenu.EnableColumnMenu = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Title";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Description";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "Amount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // pnlAccount
            // 
            this.pnlAccount.CustomizationFormText = "Account";
            this.pnlAccount.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAccount,
            this.layoutControlItem1,
            this.itmStatus,
            this.layoutControlItem2,
            this.itmTrackNumber,
            this.itmAging,
            this.itmTotal,
            this.emptySpaceItem2});
            this.pnlAccount.Location = new System.Drawing.Point(0, 0);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(764, 115);
            this.pnlAccount.Text = "Account";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkAutoPost;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(470, 24);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(90, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(90, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(90, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // chkAutoPost
            // 
            this.chkAutoPost.Enabled = false;
            this.chkAutoPost.EnterMoveNextControl = true;
            this.chkAutoPost.Location = new System.Drawing.Point(494, 67);
            this.chkAutoPost.MenuManager = this.RibbonControl;
            this.chkAutoPost.Name = "chkAutoPost";
            this.chkAutoPost.Properties.Caption = "Auto Post";
            this.chkAutoPost.Properties.ReadOnly = true;
            this.chkAutoPost.Size = new System.Drawing.Size(86, 19);
            this.chkAutoPost.StyleController = this.LayoutControl;
            this.chkAutoPost.TabIndex = 7;
            this.chkAutoPost.TabStop = false;
            this.chkAutoPost.CheckedChanged += new System.EventHandler(this.chkAutoPost_CheckedChanged);
            // 
            // itmStatus
            // 
            this.itmStatus.Control = this.txtStatus;
            this.itmStatus.CustomizationFormText = "Status";
            this.itmStatus.Location = new System.Drawing.Point(560, 24);
            this.itmStatus.MaxSize = new System.Drawing.Size(180, 24);
            this.itmStatus.MinSize = new System.Drawing.Size(180, 24);
            this.itmStatus.Name = "itmStatus";
            this.itmStatus.Size = new System.Drawing.Size(180, 24);
            this.itmStatus.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmStatus.Text = "Status";
            this.itmStatus.TextSize = new System.Drawing.Size(66, 13);
            // 
            // txtStatus
            // 
            this.txtStatus.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHeader, "StatusId", true));
            this.txtStatus.Location = new System.Drawing.Point(654, 67);
            this.txtStatus.MenuManager = this.RibbonControl;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtStatus.Properties.Appearance.Options.UseBackColor = true;
            this.txtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtStatus.Properties.DataSource = this.ServerModeSourceStatus;
            this.txtStatus.Properties.DisplayMember = "Code";
            this.txtStatus.Properties.NullText = "";
            this.txtStatus.Properties.ValueMember = "Id";
            this.txtStatus.Size = new System.Drawing.Size(106, 18);
            this.txtStatus.StyleController = this.LayoutControl;
            this.txtStatus.TabIndex = 10;
            this.txtStatus.TabStop = false;
            // 
            // BindingSourceHeader
            // 
            this.BindingSourceHeader.DataSource = typeof(CDS.Client.DataAccessLayer.DB.GLX_Header);
            // 
            // ServerModeSourceStatus
            // 
            this.ServerModeSourceStatus.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Status);
            this.ServerModeSourceStatus.KeyExpression = "[Id]";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkNewTrackNumber;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(470, 48);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(90, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(90, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(90, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // chkNewTrackNumber
            // 
            this.chkNewTrackNumber.EditValue = true;
            this.chkNewTrackNumber.EnterMoveNextControl = true;
            this.chkNewTrackNumber.Location = new System.Drawing.Point(494, 91);
            this.chkNewTrackNumber.MenuManager = this.RibbonControl;
            this.chkNewTrackNumber.Name = "chkNewTrackNumber";
            this.chkNewTrackNumber.Properties.Caption = "Auto Assign";
            this.chkNewTrackNumber.Size = new System.Drawing.Size(86, 19);
            this.chkNewTrackNumber.StyleController = this.LayoutControl;
            this.chkNewTrackNumber.TabIndex = 8;
            this.chkNewTrackNumber.TabStop = false;
            this.chkNewTrackNumber.CheckedChanged += new System.EventHandler(this.chkNewTrackNumber_CheckedChanged);
            // 
            // itmTrackNumber
            // 
            this.itmTrackNumber.Control = this.txtTrackNumber;
            this.itmTrackNumber.CustomizationFormText = "Track Number";
            this.itmTrackNumber.Location = new System.Drawing.Point(560, 48);
            this.itmTrackNumber.MaxSize = new System.Drawing.Size(180, 24);
            this.itmTrackNumber.MinSize = new System.Drawing.Size(180, 24);
            this.itmTrackNumber.Name = "itmTrackNumber";
            this.itmTrackNumber.Size = new System.Drawing.Size(180, 24);
            this.itmTrackNumber.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmTrackNumber.Text = "Track Number";
            this.itmTrackNumber.TextSize = new System.Drawing.Size(66, 13);
            // 
            // txtTrackNumber
            // 
            this.txtTrackNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHeader, "TrackId", true));
            this.txtTrackNumber.EditValue = "-1";
            this.txtTrackNumber.Enabled = false;
            this.txtTrackNumber.EnterMoveNextControl = true;
            this.txtTrackNumber.Location = new System.Drawing.Point(654, 91);
            this.txtTrackNumber.MenuManager = this.RibbonControl;
            this.txtTrackNumber.Name = "txtTrackNumber";
            this.txtTrackNumber.Size = new System.Drawing.Size(106, 20);
            this.txtTrackNumber.StyleController = this.LayoutControl;
            this.txtTrackNumber.TabIndex = 9;
            this.txtTrackNumber.TabStop = false;
            // 
            // itmAging
            // 
            this.itmAging.Control = this.ddlAging;
            this.itmAging.CustomizationFormText = "Aging";
            this.itmAging.Location = new System.Drawing.Point(0, 24);
            this.itmAging.MaxSize = new System.Drawing.Size(229, 24);
            this.itmAging.MinSize = new System.Drawing.Size(229, 24);
            this.itmAging.Name = "itmAging";
            this.itmAging.Size = new System.Drawing.Size(229, 24);
            this.itmAging.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmAging.Text = "Aging";
            this.itmAging.TextSize = new System.Drawing.Size(66, 13);
            // 
            // ddlAging
            // 
            this.ddlAging.EnterMoveNextControl = true;
            this.ddlAging.Location = new System.Drawing.Point(94, 67);
            this.ddlAging.MenuManager = this.RibbonControl;
            this.ddlAging.Name = "ddlAging";
            this.ddlAging.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.ddlAging.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAging.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlAging.Properties.DataSource = this.ServerModeSourceAging;
            this.ddlAging.Properties.DisplayMember = "Name";
            this.ddlAging.Properties.NullText = "Select Aging...";
            this.ddlAging.Properties.ValueMember = "Id";
            this.ddlAging.Size = new System.Drawing.Size(155, 20);
            this.ddlAging.StyleController = this.LayoutControl;
            this.ddlAging.TabIndex = 6;
            this.ddlAging.TabStop = false;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Aging not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.ValidationProvider.SetValidationRule(this.ddlAging, conditionValidationRule1);
            // 
            // itmTotal
            // 
            this.itmTotal.Control = this.txtTotal;
            this.itmTotal.CustomizationFormText = "Total";
            this.itmTotal.Location = new System.Drawing.Point(0, 48);
            this.itmTotal.Name = "itmTotal";
            this.itmTotal.Size = new System.Drawing.Size(229, 24);
            this.itmTotal.Text = "Total";
            this.itmTotal.TextSize = new System.Drawing.Size(66, 13);
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotal.Location = new System.Drawing.Point(94, 91);
            this.txtTotal.MenuManager = this.RibbonControl;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotal.Properties.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtTotal.Properties.EditFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.txtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(155, 20);
            this.txtTotal.StyleController = this.LayoutControl;
            this.txtTotal.TabIndex = 11;
            this.txtTotal.TabStop = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(229, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(241, 48);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // pnlEntries
            // 
            this.pnlEntries.CustomizationFormText = "Entries";
            this.pnlEntries.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmEntries});
            this.pnlEntries.Location = new System.Drawing.Point(0, 115);
            this.pnlEntries.Name = "pnlEntries";
            this.pnlEntries.Size = new System.Drawing.Size(764, 280);
            this.pnlEntries.Text = "Entries";
            // 
            // btnBulkEntryRules
            // 
            this.btnBulkEntryRules.Caption = "Bulk Entry Rules";
            this.btnBulkEntryRules.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBulkEntryRules.Glyph")));
            this.btnBulkEntryRules.Id = 22;
            this.btnBulkEntryRules.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBulkEntryRules.LargeGlyph")));
            this.btnBulkEntryRules.Name = "btnBulkEntryRules";
            toolTipTitleItem1.Text = "Bulk Entry Rules";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click this button to show the Bulk Entry Rules dialogue.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnBulkEntryRules.SuperTip = superToolTip1;
            this.btnBulkEntryRules.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBulkEntryRules_ItemClick);
            // 
            // btnImportStatement
            // 
            this.btnImportStatement.Caption = "Import Statement";
            this.btnImportStatement.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImportStatement.Glyph")));
            this.btnImportStatement.Id = 23;
            this.btnImportStatement.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImportStatement.LargeGlyph")));
            this.btnImportStatement.Name = "btnImportStatement";
            toolTipTitleItem2.Text = "Import Statement";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Click this button to show the import statement dialogue";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnImportStatement.SuperTip = superToolTip2;
            this.btnImportStatement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportStatement_ItemClick);
            // 
            // BulkEntryForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AllowNavigate = false;
            this.AllowNavigateBackOnly = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "BulkEntryForm";
            this.SuperTipParameter = "bulk entry";
            this.TabIcon = global::CDS.Client.Desktop.Accounting.Properties.Resources.checkbook_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Accounting.Properties.Resources.checkbook_16;
            this.Text = "Bulk Entry";
            this.WaitFormNewRecordDescription = "Creating new bulk entry...";
            this.WaitFormOpenRecordDescription = "Opening bulk entry...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContraAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewContraAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgingId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoPost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNewTrackNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTrackNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrackNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAging.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEntries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdEntries;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEntries;
        private DevExpress.XtraLayout.LayoutControlItem itmEntries;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colReference;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colTax;
        private DevExpress.XtraGrid.Columns.GridColumn colExclusive;
        private DevExpress.XtraGrid.Columns.GridColumn colInclusive;
        private DevExpress.XtraLayout.LayoutControlGroup pnlAccount;
        private DevExpress.XtraLayout.LayoutControlItem itmAccount;
        private DevExpress.XtraLayout.LayoutControlGroup pnlEntries;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePeriod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlPeriod;
        private DevExpress.XtraBars.BarButtonItem btnBulkEntryRules;
        private DevExpress.XtraBars.BarButtonItem btnImportStatement;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceTax;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlTax;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAgingId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlAgingId;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAging;
        private DevExpress.XtraEditors.LookUpEdit ddlAging;
        private DevExpress.XtraLayout.LayoutControlItem itmAging;
        private DevExpress.XtraEditors.CheckEdit chkNewTrackNumber;
        private DevExpress.XtraEditors.CheckEdit chkAutoPost;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtTrackNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmTrackNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmStatus;
        private DevExpress.XtraEditors.LookUpEdit txtStatus;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceStatus;
        private System.Windows.Forms.BindingSource BindingSourceHeader;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceAccount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit ddlContraAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView repViewContraAccount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAccount;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraLayout.LayoutControlItem itmTotal;
    }
}
