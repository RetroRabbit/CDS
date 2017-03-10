namespace CDS.Client.Desktop.Accounting.Payment
{
    partial class BasePaymentsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePaymentsForm));
            this.ServerModeSourcePeriod = new DevExpress.Data.Linq.LinqServerModeSource();
            this.txtDate = new DevExpress.XtraEditors.DateEdit();
            this.itmDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkAccount = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.BindingSourceAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.itmAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdOpenItem = new DevExpress.XtraGrid.GridControl();
            this.grvOpenItem = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gbActions = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCheck = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colViewTrackNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repViewTrackNumber = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colSetTrackNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repSetTrackNumber = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gbInformation = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTitle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPeriod = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAging = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTrackNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colReference = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDescription = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBalance = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbAccounts = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repCalcEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repddlAging = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourceAging = new DevExpress.Data.Linq.LinqServerModeSource();
            this.pnlReceiveInto = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnAddAdditionalPayment = new DevExpress.XtraBars.BarButtonItem();
            this.tabReceivePayments = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmOpenItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlFilterInto = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAccountFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAccountFilter = new DevExpress.XtraEditors.TextEdit();
            this.itmDateFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDateFilter = new DevExpress.XtraEditors.DateEdit();
            this.itmClearFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClearFilter = new DevExpress.XtraEditors.SimpleButton();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BindingSourceAging = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpenItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOpenItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewTrackNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSetTrackNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCalcEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repddlAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlReceiveInto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabReceivePayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOpenItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilterInto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDateFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClearFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAging)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_PaymentItems);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnClearFilter);
            this.LayoutControl.Controls.Add(this.txtDateFilter);
            this.LayoutControl.Controls.Add(this.txtAccountFilter);
            this.LayoutControl.Controls.Add(this.chkAccount);
            this.LayoutControl.Controls.Add(this.txtDate);
            this.LayoutControl.Controls.Add(this.grdOpenItem);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2756, 197, 395, 535);
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
            this.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = false;
            this.LayoutControl.Size = new System.Drawing.Size(784, 418);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pnlReceiveInto,
            this.tabReceivePayments,
            this.pnlFilterInto});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(784, 418);
            this.LayoutGroup.Text = "Root";
            // 
            // rpgNavigation
            // 
            this.rpgNavigation.Visible = false;
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddAdditionalPayment});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RibbonControl.Size = new System.Drawing.Size(784, 144);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnAddAdditionalPayment);
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
            // ServerModeSourcePeriod
            // 
            this.ServerModeSourcePeriod.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Period);
            this.ServerModeSourcePeriod.KeyExpression = "Id";
            // 
            // txtDate
            // 
            this.txtDate.EditValue = null;
            this.txtDate.EnterMoveNextControl = true;
            this.txtDate.Location = new System.Drawing.Point(319, 43);
            this.txtDate.MenuManager = this.RibbonControl;
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDate.Size = new System.Drawing.Size(91, 20);
            this.txtDate.StyleController = this.LayoutControl;
            this.txtDate.TabIndex = 4;
            // 
            // itmDate
            // 
            this.itmDate.Control = this.txtDate;
            this.itmDate.CustomizationFormText = "Date";
            this.itmDate.Location = new System.Drawing.Point(0, 0);
            this.itmDate.MaxSize = new System.Drawing.Size(163, 24);
            this.itmDate.MinSize = new System.Drawing.Size(163, 24);
            this.itmDate.Name = "itmDate";
            this.itmDate.Size = new System.Drawing.Size(163, 24);
            this.itmDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmDate.Text = "Date";
            this.itmDate.TextSize = new System.Drawing.Size(64, 13);
            // 
            // chkAccount
            // 
            this.chkAccount.CheckOnClick = true;
            this.chkAccount.DataSource = this.BindingSourceAccounts;
            this.chkAccount.DisplayMember = "AccountShortName";
            this.chkAccount.Location = new System.Drawing.Point(319, 67);
            this.chkAccount.MultiColumn = true;
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chkAccount.Size = new System.Drawing.Size(441, 48);
            this.chkAccount.StyleController = this.LayoutControl;
            this.chkAccount.TabIndex = 1;
            this.chkAccount.ValueMember = "AccountId";
            this.chkAccount.ItemChecking += new DevExpress.XtraEditors.Controls.ItemCheckingEventHandler(this.chkAccount_ItemChecking);
            this.chkAccount.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkAccount_ItemCheck);
            // 
            // BindingSourceAccounts
            // 
            this.BindingSourceAccounts.DataSource = typeof(CDS.Client.DataAccessLayer.DB.GLX_Account);
            // 
            // itmAccount
            // 
            this.itmAccount.AppearanceItemCaption.Options.UseTextOptions = true;
            this.itmAccount.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.itmAccount.Control = this.chkAccount;
            this.itmAccount.CustomizationFormText = "Account";
            this.itmAccount.Location = new System.Drawing.Point(0, 24);
            this.itmAccount.MaxSize = new System.Drawing.Size(0, 52);
            this.itmAccount.MinSize = new System.Drawing.Size(122, 52);
            this.itmAccount.Name = "itmAccount";
            this.itmAccount.Size = new System.Drawing.Size(513, 52);
            this.itmAccount.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmAccount.Text = "Account";
            this.itmAccount.TextSize = new System.Drawing.Size(64, 13);
            // 
            // grdOpenItem
            // 
            this.grdOpenItem.DataSource = this.BindingSource;
            this.grdOpenItem.Location = new System.Drawing.Point(24, 162);
            this.grdOpenItem.MainView = this.grvOpenItem;
            this.grdOpenItem.MenuManager = this.RibbonControl;
            this.grdOpenItem.Name = "grdOpenItem";
            this.grdOpenItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repDateEdit,
            this.repCheck,
            this.repViewTrackNumber,
            this.repSetTrackNumber,
            this.repLookUpEdit,
            this.repCalcEdit,
            this.repddlAging});
            this.grdOpenItem.Size = new System.Drawing.Size(736, 232);
            this.grdOpenItem.TabIndex = 6;
            this.grdOpenItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOpenItem});
            // 
            // grvOpenItem
            // 
            this.grvOpenItem.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.grvOpenItem.Appearance.OddRow.Options.UseBackColor = true;
            this.grvOpenItem.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbActions,
            this.gbInformation,
            this.gbAccounts});
            this.grvOpenItem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colCheck,
            this.colViewTrackNumber,
            this.colSetTrackNumber,
            this.colTitle,
            this.colDescription,
            this.colPeriod,
            this.colAging,
            this.colDate,
            this.colReference,
            this.colTrackNumber,
            this.colBalance,
            this.colType});
            this.grvOpenItem.GridControl = this.grdOpenItem;
            this.grvOpenItem.Name = "grvOpenItem";
            this.grvOpenItem.OptionsMenu.EnableFooterMenu = false;
            this.grvOpenItem.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvOpenItem.OptionsView.ColumnAutoWidth = true;
            this.grvOpenItem.OptionsView.EnableAppearanceOddRow = true;
            this.grvOpenItem.OptionsView.ShowBands = false;
            this.grvOpenItem.OptionsView.ShowFooter = true;
            this.grvOpenItem.OptionsView.ShowGroupPanel = false;
            this.grvOpenItem.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvOpenItem.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.grvOpenItem_CustomDrawColumnHeader);
            this.grvOpenItem.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvOpenItem_RowCellStyle);
            this.grvOpenItem.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvOpenItem_ShowingEditor);
            this.grvOpenItem.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvOpenItem_FocusedRowChanged);
            this.grvOpenItem.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.grvOpenItem_FocusedColumnChanged);
            this.grvOpenItem.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvOpenItem_CellValueChanged);
            this.grvOpenItem.ColumnFilterChanged += new System.EventHandler(this.grvOpenItem_ColumnFilterChanged);
            this.grvOpenItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvOpenItem_MouseDown);
            // 
            // gbActions
            // 
            this.gbActions.Caption = "Actions";
            this.gbActions.Columns.Add(this.colCheck);
            this.gbActions.Columns.Add(this.colViewTrackNumber);
            this.gbActions.Columns.Add(this.colSetTrackNumber);
            this.gbActions.MinWidth = 20;
            this.gbActions.Name = "gbActions";
            this.gbActions.OptionsBand.AllowSize = false;
            this.gbActions.OptionsBand.FixedWidth = true;
            this.gbActions.VisibleIndex = 0;
            this.gbActions.Width = 60;
            // 
            // colCheck
            // 
            this.colCheck.AutoFillDown = true;
            this.colCheck.Caption = " ";
            this.colCheck.ColumnEdit = this.repCheck;
            this.colCheck.FieldName = "colCheck";
            this.colCheck.Name = "colCheck";
            this.colCheck.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCheck.OptionsColumn.AllowIncrementalSearch = false;
            this.colCheck.OptionsColumn.AllowShowHide = false;
            this.colCheck.OptionsColumn.AllowSize = false;
            this.colCheck.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCheck.OptionsColumn.FixedWidth = true;
            this.colCheck.OptionsFilter.AllowAutoFilter = false;
            this.colCheck.OptionsFilter.AllowFilter = false;
            this.colCheck.Visible = true;
            this.colCheck.Width = 20;
            // 
            // repCheck
            // 
            this.repCheck.AutoHeight = false;
            this.repCheck.Name = "repCheck";
            this.repCheck.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheck.CheckedChanged += new System.EventHandler(this.repCheck_CheckedChanged);
            // 
            // colViewTrackNumber
            // 
            this.colViewTrackNumber.AutoFillDown = true;
            this.colViewTrackNumber.Caption = " ";
            this.colViewTrackNumber.ColumnEdit = this.repViewTrackNumber;
            this.colViewTrackNumber.FieldName = "colViewTrackNumber";
            this.colViewTrackNumber.Name = "colViewTrackNumber";
            this.colViewTrackNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colViewTrackNumber.OptionsColumn.AllowIncrementalSearch = false;
            this.colViewTrackNumber.OptionsColumn.AllowShowHide = false;
            this.colViewTrackNumber.OptionsColumn.AllowSize = false;
            this.colViewTrackNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colViewTrackNumber.OptionsColumn.FixedWidth = true;
            this.colViewTrackNumber.OptionsFilter.AllowAutoFilter = false;
            this.colViewTrackNumber.OptionsFilter.AllowFilter = false;
            this.colViewTrackNumber.UnboundExpression = "True";
            this.colViewTrackNumber.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colViewTrackNumber.Visible = true;
            this.colViewTrackNumber.Width = 20;
            // 
            // repViewTrackNumber
            // 
            this.repViewTrackNumber.AutoHeight = false;
            this.repViewTrackNumber.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repViewTrackNumber.Name = "repViewTrackNumber";
            this.repViewTrackNumber.PictureChecked = ((System.Drawing.Image)(resources.GetObject("repViewTrackNumber.PictureChecked")));
            this.repViewTrackNumber.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("repViewTrackNumber.PictureUnchecked")));
            this.repViewTrackNumber.Click += new System.EventHandler(this.repViewTrackNumber_Click);
            // 
            // colSetTrackNumber
            // 
            this.colSetTrackNumber.AutoFillDown = true;
            this.colSetTrackNumber.Caption = " ";
            this.colSetTrackNumber.ColumnEdit = this.repSetTrackNumber;
            this.colSetTrackNumber.FieldName = "colSetTrackNumber";
            this.colSetTrackNumber.Name = "colSetTrackNumber";
            this.colSetTrackNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSetTrackNumber.OptionsColumn.AllowIncrementalSearch = false;
            this.colSetTrackNumber.OptionsColumn.AllowShowHide = false;
            this.colSetTrackNumber.OptionsColumn.AllowSize = false;
            this.colSetTrackNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSetTrackNumber.OptionsColumn.FixedWidth = true;
            this.colSetTrackNumber.OptionsFilter.AllowAutoFilter = false;
            this.colSetTrackNumber.OptionsFilter.AllowFilter = false;
            this.colSetTrackNumber.UnboundExpression = "True";
            this.colSetTrackNumber.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colSetTrackNumber.Visible = true;
            this.colSetTrackNumber.Width = 20;
            // 
            // repSetTrackNumber
            // 
            this.repSetTrackNumber.AutoHeight = false;
            this.repSetTrackNumber.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repSetTrackNumber.Name = "repSetTrackNumber";
            this.repSetTrackNumber.PictureChecked = ((System.Drawing.Image)(resources.GetObject("repSetTrackNumber.PictureChecked")));
            this.repSetTrackNumber.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("repSetTrackNumber.PictureUnchecked")));
            this.repSetTrackNumber.Click += new System.EventHandler(this.repSetTrackNumber_Click);
            // 
            // gbInformation
            // 
            this.gbInformation.Caption = "Information";
            this.gbInformation.Columns.Add(this.colTitle);
            this.gbInformation.Columns.Add(this.colPeriod);
            this.gbInformation.Columns.Add(this.colAging);
            this.gbInformation.Columns.Add(this.colDate);
            this.gbInformation.Columns.Add(this.colTrackNumber);
            this.gbInformation.Columns.Add(this.colReference);
            this.gbInformation.Columns.Add(this.colDescription);
            this.gbInformation.Columns.Add(this.colBalance);
            this.gbInformation.MinWidth = 20;
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.VisibleIndex = 1;
            this.gbInformation.Width = 399;
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 130;
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowEdit = false;
            this.colTitle.OptionsColumn.AllowFocus = false;
            this.colTitle.OptionsColumn.AllowShowHide = false;
            this.colTitle.OptionsColumn.ReadOnly = true;
            this.colTitle.Visible = true;
            this.colTitle.Width = 199;
            // 
            // colPeriod
            // 
            this.colPeriod.FieldName = "Period";
            this.colPeriod.MinWidth = 80;
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.OptionsColumn.AllowEdit = false;
            this.colPeriod.OptionsColumn.AllowFocus = false;
            this.colPeriod.OptionsColumn.AllowShowHide = false;
            this.colPeriod.OptionsColumn.FixedWidth = true;
            this.colPeriod.OptionsColumn.ReadOnly = true;
            this.colPeriod.Visible = true;
            this.colPeriod.Width = 80;
            // 
            // colAging
            // 
            this.colAging.FieldName = "Aging";
            this.colAging.MinWidth = 50;
            this.colAging.Name = "colAging";
            this.colAging.OptionsColumn.AllowEdit = false;
            this.colAging.OptionsColumn.AllowFocus = false;
            this.colAging.OptionsColumn.AllowShowHide = false;
            this.colAging.OptionsColumn.FixedWidth = true;
            this.colAging.OptionsColumn.ReadOnly = true;
            this.colAging.Visible = true;
            this.colAging.Width = 50;
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 70;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.OptionsColumn.AllowFocus = false;
            this.colDate.OptionsColumn.AllowShowHide = false;
            this.colDate.OptionsColumn.FixedWidth = true;
            this.colDate.OptionsColumn.ReadOnly = true;
            this.colDate.Visible = true;
            this.colDate.Width = 65;
            // 
            // colTrackNumber
            // 
            this.colTrackNumber.Caption = "Track #";
            this.colTrackNumber.FieldName = "TrackNumber";
            this.colTrackNumber.MinWidth = 50;
            this.colTrackNumber.Name = "colTrackNumber";
            this.colTrackNumber.OptionsColumn.AllowEdit = false;
            this.colTrackNumber.OptionsColumn.AllowFocus = false;
            this.colTrackNumber.OptionsColumn.AllowShowHide = false;
            this.colTrackNumber.OptionsColumn.FixedWidth = true;
            this.colTrackNumber.OptionsColumn.ReadOnly = true;
            this.colTrackNumber.RowIndex = 1;
            this.colTrackNumber.Visible = true;
            this.colTrackNumber.Width = 50;
            // 
            // colReference
            // 
            this.colReference.Caption = "Reference";
            this.colReference.FieldName = "Reference";
            this.colReference.MinWidth = 80;
            this.colReference.Name = "colReference";
            this.colReference.OptionsColumn.AllowEdit = false;
            this.colReference.OptionsColumn.AllowFocus = false;
            this.colReference.OptionsColumn.AllowShowHide = false;
            this.colReference.OptionsColumn.FixedWidth = true;
            this.colReference.OptionsColumn.ReadOnly = true;
            this.colReference.RowIndex = 1;
            this.colReference.Visible = true;
            this.colReference.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 100;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowFocus = false;
            this.colDescription.OptionsColumn.AllowShowHide = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.RowIndex = 1;
            this.colDescription.Visible = true;
            this.colDescription.Width = 149;
            // 
            // colBalance
            // 
            this.colBalance.Caption = "Balance";
            this.colBalance.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBalance.FieldName = "Balance";
            this.colBalance.MinWidth = 90;
            this.colBalance.Name = "colBalance";
            this.colBalance.OptionsColumn.AllowEdit = false;
            this.colBalance.OptionsColumn.AllowFocus = false;
            this.colBalance.OptionsColumn.AllowShowHide = false;
            this.colBalance.OptionsColumn.ReadOnly = true;
            this.colBalance.RowIndex = 1;
            this.colBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colBalance.Visible = true;
            this.colBalance.Width = 120;
            // 
            // gbAccounts
            // 
            this.gbAccounts.Caption = "Accounts";
            this.gbAccounts.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gbAccounts.MinWidth = 240;
            this.gbAccounts.Name = "gbAccounts";
            this.gbAccounts.OptionsBand.AllowSize = false;
            this.gbAccounts.OptionsBand.FixedWidth = true;
            this.gbAccounts.VisibleIndex = 2;
            this.gbAccounts.Width = 240;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            // 
            // repDateEdit
            // 
            this.repDateEdit.AutoHeight = false;
            this.repDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repDateEdit.Name = "repDateEdit";
            // 
            // repLookUpEdit
            // 
            this.repLookUpEdit.AutoHeight = false;
            this.repLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpEdit.Name = "repLookUpEdit";
            // 
            // repCalcEdit
            // 
            this.repCalcEdit.AutoHeight = false;
            this.repCalcEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCalcEdit.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.repCalcEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repCalcEdit.EditFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.repCalcEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repCalcEdit.Mask.EditMask = "f";
            this.repCalcEdit.Name = "repCalcEdit";
            this.repCalcEdit.Precision = 2;
            this.repCalcEdit.ShowCloseButton = true;
            // 
            // repddlAging
            // 
            this.repddlAging.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repddlAging.AutoHeight = false;
            this.repddlAging.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repddlAging.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repddlAging.DataSource = this.ServerModeSourceAging;
            this.repddlAging.DisplayMember = "Code";
            this.repddlAging.Name = "repddlAging";
            this.repddlAging.NullText = "";
            this.repddlAging.ValueMember = "Id";
            this.repddlAging.Enter += new System.EventHandler(this.repddlAging_Enter);
            // 
            // ServerModeSourceAging
            // 
            this.ServerModeSourceAging.ElementType = typeof(CDS.Client.DataAccessLayer.DB.GLX_Aging);
            this.ServerModeSourceAging.KeyExpression = "[Id]";
            // 
            // pnlReceiveInto
            // 
            this.pnlReceiveInto.CustomizationFormText = "Receive Into";
            this.pnlReceiveInto.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmDate,
            this.emptySpaceItem1,
            this.itmAccount});
            this.pnlReceiveInto.Location = new System.Drawing.Point(227, 0);
            this.pnlReceiveInto.Name = "pnlReceiveInto";
            this.pnlReceiveInto.Size = new System.Drawing.Size(537, 119);
            this.pnlReceiveInto.Text = "Receive Into";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(163, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(350, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnAddAdditionalPayment
            // 
            this.btnAddAdditionalPayment.Caption = "Add Additional Payment";
            this.btnAddAdditionalPayment.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddAdditionalPayment.Glyph")));
            this.btnAddAdditionalPayment.Id = 22;
            this.btnAddAdditionalPayment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddAdditionalPayment.LargeGlyph")));
            this.btnAddAdditionalPayment.Name = "btnAddAdditionalPayment";
            this.btnAddAdditionalPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddAdditionalPayment_ItemClick);
            // 
            // tabReceivePayments
            // 
            this.tabReceivePayments.CustomizationFormText = "Receive Payments";
            this.tabReceivePayments.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmOpenItem});
            this.tabReceivePayments.Location = new System.Drawing.Point(0, 119);
            this.tabReceivePayments.Name = "tabReceivePayments";
            this.tabReceivePayments.Size = new System.Drawing.Size(764, 279);
            this.tabReceivePayments.Text = "Receive Payments";
            // 
            // itmOpenItem
            // 
            this.itmOpenItem.Control = this.grdOpenItem;
            this.itmOpenItem.CustomizationFormText = "Open Item";
            this.itmOpenItem.Location = new System.Drawing.Point(0, 0);
            this.itmOpenItem.Name = "itmOpenItem";
            this.itmOpenItem.Size = new System.Drawing.Size(740, 236);
            this.itmOpenItem.Text = "Open Item";
            this.itmOpenItem.TextSize = new System.Drawing.Size(0, 0);
            this.itmOpenItem.TextVisible = false;
            // 
            // pnlFilterInto
            // 
            this.pnlFilterInto.CustomizationFormText = "Filter Into";
            this.pnlFilterInto.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAccountFilter,
            this.itmDateFilter,
            this.itmClearFilter,
            this.emptySpaceItem2});
            this.pnlFilterInto.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterInto.Name = "pnlFilterInto";
            this.pnlFilterInto.Size = new System.Drawing.Size(227, 119);
            this.pnlFilterInto.Text = "Filter Into";
            // 
            // itmAccountFilter
            // 
            this.itmAccountFilter.Control = this.txtAccountFilter;
            this.itmAccountFilter.CustomizationFormText = "Account filter";
            this.itmAccountFilter.Location = new System.Drawing.Point(0, 0);
            this.itmAccountFilter.Name = "itmAccountFilter";
            this.itmAccountFilter.Size = new System.Drawing.Size(203, 24);
            this.itmAccountFilter.Text = "Account filter";
            this.itmAccountFilter.TextSize = new System.Drawing.Size(64, 13);
            // 
            // txtAccountFilter
            // 
            this.txtAccountFilter.Location = new System.Drawing.Point(92, 43);
            this.txtAccountFilter.MaximumSize = new System.Drawing.Size(172, 20);
            this.txtAccountFilter.MenuManager = this.RibbonControl;
            this.txtAccountFilter.Name = "txtAccountFilter";
            this.txtAccountFilter.Size = new System.Drawing.Size(131, 20);
            this.txtAccountFilter.StyleController = this.LayoutControl;
            this.txtAccountFilter.TabIndex = 0;
            this.txtAccountFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountFilter_KeyDown);
            // 
            // itmDateFilter
            // 
            this.itmDateFilter.Control = this.txtDateFilter;
            this.itmDateFilter.CustomizationFormText = "Date filter";
            this.itmDateFilter.Location = new System.Drawing.Point(0, 24);
            this.itmDateFilter.MaxSize = new System.Drawing.Size(163, 26);
            this.itmDateFilter.MinSize = new System.Drawing.Size(163, 26);
            this.itmDateFilter.Name = "itmDateFilter";
            this.itmDateFilter.Size = new System.Drawing.Size(163, 26);
            this.itmDateFilter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmDateFilter.Text = "Date filter";
            this.itmDateFilter.TextSize = new System.Drawing.Size(64, 13);
            // 
            // txtDateFilter
            // 
            this.txtDateFilter.EditValue = null;
            this.txtDateFilter.Location = new System.Drawing.Point(92, 67);
            this.txtDateFilter.MenuManager = this.RibbonControl;
            this.txtDateFilter.Name = "txtDateFilter";
            this.txtDateFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateFilter.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDateFilter.Size = new System.Drawing.Size(91, 20);
            this.txtDateFilter.StyleController = this.LayoutControl;
            this.txtDateFilter.TabIndex = 2;
            this.txtDateFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDateFilter_KeyDown);
            // 
            // itmClearFilter
            // 
            this.itmClearFilter.Control = this.btnClearFilter;
            this.itmClearFilter.CustomizationFormText = "Clear Filter";
            this.itmClearFilter.Location = new System.Drawing.Point(163, 24);
            this.itmClearFilter.Name = "itmClearFilter";
            this.itmClearFilter.Size = new System.Drawing.Size(40, 26);
            this.itmClearFilter.Text = "Clear Filter";
            this.itmClearFilter.TextSize = new System.Drawing.Size(0, 0);
            this.itmClearFilter.TextVisible = false;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(187, 67);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(36, 22);
            this.btnClearFilter.StyleController = this.LayoutControl;
            this.btnClearFilter.TabIndex = 5;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(203, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // BindingSourceAging
            // 
            this.BindingSourceAging.DataSource = typeof(CDS.Client.DataAccessLayer.DB.GLX_Aging);
            // 
            // BasePaymentsForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AllowNavigate = false;
            this.AllowNavigateBackOnly = false;
            this.AllowSaveAndNew = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "BasePaymentsForm";
            this.TabIcon = global::CDS.Client.Desktop.Accounting.Properties.Resources.money2_add_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Accounting.Properties.Resources.money2_add_16;
            this.Text = "Payments";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpenItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOpenItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewTrackNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSetTrackNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCalcEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repddlAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlReceiveInto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabReceivePayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOpenItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilterInto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDateFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClearFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAging)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup pnlReceiveInto;
        private DevExpress.XtraLayout.LayoutControlItem itmAccount;
        private DevExpress.XtraLayout.LayoutControlItem itmDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCheck;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colViewTrackNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSetTrackNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTitle;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPeriod;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colReference;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTrackNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBalance;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDescription;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAging;
        private DevExpress.XtraLayout.LayoutControlItem itmOpenItem;
        private DevExpress.XtraEditors.SimpleButton btnClearFilter;
        private DevExpress.XtraEditors.DateEdit txtDateFilter;
        private DevExpress.XtraEditors.TextEdit txtAccountFilter;
        private DevExpress.XtraLayout.LayoutControlGroup pnlFilterInto;
        private DevExpress.XtraLayout.LayoutControlItem itmAccountFilter;
        private DevExpress.XtraLayout.LayoutControlItem itmDateFilter;
        private DevExpress.XtraLayout.LayoutControlItem itmClearFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repViewTrackNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSetTrackNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repCalcEdit;
        protected DevExpress.XtraBars.BarButtonItem btnAddAdditionalPayment;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colType;
        private DevExpress.XtraGrid.GridControl grdOpenItem;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView grvOpenItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repDateEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repddlAging;
        private DevExpress.XtraEditors.CheckedListBoxControl chkAccount;
        private DevExpress.XtraEditors.DateEdit txtDate;
        private DevExpress.XtraLayout.LayoutControlGroup tabReceivePayments;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource BindingSourceAging;
        private System.Windows.Forms.BindingSource BindingSourceAccounts;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePeriod;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAging;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbActions;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbInformation;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbAccounts;
    }
}
