namespace CDS.Client.Desktop.Stock.Document
{
    partial class BaseStockDocument
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
            this.itmDetails = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmMessage = new DevExpress.XtraLayout.LayoutControlItem();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCreatedBy = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.grdItems = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceLine = new System.Windows.Forms.BindingSource();
            this.grvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLineEntity = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.InstantFeedbackSourceItem = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.repViewEntity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceChanged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmItems = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmItems)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Header);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.memoEdit1);
            this.LayoutControl.Controls.Add(this.grdItems);
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.LayoutControl.Size = new System.Drawing.Size(1015, 593);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmDetails,
            this.lcgHistory,
            this.itmItems});
            this.LayoutGroup.Size = new System.Drawing.Size(1015, 593);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3);
            this.RibbonControl.Size = new System.Drawing.Size(1015, 144);
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
            // itmDetails
            // 
            this.itmDetails.CustomizationFormText = "Details";
            this.itmDetails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmMessage});
            this.itmDetails.Location = new System.Drawing.Point(0, 0);
            this.itmDetails.Name = "itmDetails";
            this.itmDetails.Size = new System.Drawing.Size(995, 79);
            this.itmDetails.Text = "Details";
            // 
            // itmMessage
            // 
            this.itmMessage.Control = this.memoEdit1;
            this.itmMessage.CustomizationFormText = "Message";
            this.itmMessage.Location = new System.Drawing.Point(0, 0);
            this.itmMessage.Name = "itmMessage";
            this.itmMessage.Size = new System.Drawing.Size(971, 36);
            this.itmMessage.Text = "Message";
            this.itmMessage.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmMessage.TextSize = new System.Drawing.Size(56, 13);
            // 
            // memoEdit1
            // 
            this.memoEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Comment", true));
            this.memoEdit1.Location = new System.Drawing.Point(24, 59);
            this.memoEdit1.MenuManager = this.RibbonControl;
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Size = new System.Drawing.Size(967, 16);
            this.memoEdit1.StyleController = this.LayoutControl;
            this.memoEdit1.TabIndex = 7;
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedBy,
            this.itmCreatedOn});
            this.lcgHistory.Location = new System.Drawing.Point(0, 506);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(995, 67);
            this.lcgHistory.Text = "History";
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(484, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(84, 549);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.DataSource = this.ServerModeSourceCreatedBy;
            this.txtCreatedBy.Properties.DisplayMember = "Fullname";
            this.txtCreatedBy.Properties.NullText = "";
            this.txtCreatedBy.Size = new System.Drawing.Size(420, 20);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 4;
            // 
            // ServerModeSourceCreatedBy
            // 
            this.ServerModeSourceCreatedBy.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Person);
            this.ServerModeSourceCreatedBy.KeyExpression = "Id";
            // 
            // itmCreatedOn
            // 
            this.itmCreatedOn.Control = this.txtCreatedOn;
            this.itmCreatedOn.CustomizationFormText = "Created On";
            this.itmCreatedOn.Location = new System.Drawing.Point(484, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(487, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(568, 549);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Size = new System.Drawing.Size(423, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 5;
            // 
            // grdItems
            // 
            this.grdItems.DataSource = this.BindingSourceLine;
            this.grdItems.Location = new System.Drawing.Point(12, 91);
            this.grdItems.MainView = this.grvItems;
            this.grdItems.MenuManager = this.RibbonControl;
            this.grdItems.Name = "grdItems";
            this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLineEntity});
            this.grdItems.Size = new System.Drawing.Size(991, 423);
            this.grdItems.TabIndex = 6;
            this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvItems});
            // 
            // BindingSourceLine
            // 
            this.BindingSourceLine.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Line);
            // 
            // grvItems
            // 
            this.grvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineOrder,
            this.colItemId,
            this.colDescription,
            this.colQuantity,
            this.colAmount,
            this.colTotal,
            this.colTotalTax,
            this.colTotalAmount,
            this.colPriceChanged});
            this.grvItems.GridControl = this.grdItems;
            this.grvItems.Name = "grvItems";
            this.grvItems.OptionsBehavior.Editable = false;
            this.grvItems.OptionsDetail.EnableMasterViewMode = false;
            this.grvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvItems.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvItems.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvItems.OptionsView.ShowDetailButtons = false;
            this.grvItems.OptionsView.ShowFooter = true;
            this.grvItems.OptionsView.ShowGroupPanel = false;
            this.grvItems.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPriceChanged, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLineOrder, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvItems.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grvItems_CustomSummaryCalculate);
            this.grvItems.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvItems_ShowingEditor);
            this.grvItems.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvItems_InitNewRow);
            this.grvItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvItems_CellValueChanged);
            this.grvItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvItems_KeyDown);
            // 
            // colLineOrder
            // 
            this.colLineOrder.Caption = " ";
            this.colLineOrder.FieldName = "LineOrder";
            this.colLineOrder.Name = "colLineOrder";
            this.colLineOrder.OptionsColumn.AllowEdit = false;
            this.colLineOrder.OptionsColumn.AllowFocus = false;
            this.colLineOrder.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colLineOrder.OptionsColumn.AllowMove = false;
            this.colLineOrder.OptionsColumn.AllowSize = false;
            this.colLineOrder.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLineOrder.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLineOrder.Visible = true;
            this.colLineOrder.VisibleIndex = 0;
            this.colLineOrder.Width = 33;
            // 
            // colItemId
            // 
            this.colItemId.Caption = "Item";
            this.colItemId.ColumnEdit = this.repLineEntity;
            this.colItemId.FieldName = "ItemId";
            this.colItemId.MinWidth = 120;
            this.colItemId.Name = "colItemId";
            this.colItemId.OptionsColumn.AllowMove = false;
            this.colItemId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colItemId.Visible = true;
            this.colItemId.VisibleIndex = 1;
            this.colItemId.Width = 231;
            // 
            // repLineEntity
            // 
            this.repLineEntity.AutoHeight = false;
            this.repLineEntity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLineEntity.DataSource = this.InstantFeedbackSourceItem;
            this.repLineEntity.DisplayMember = "Title";
            this.repLineEntity.EditValueChangedDelay = 2000;
            this.repLineEntity.Name = "repLineEntity";
            this.repLineEntity.NullText = "Select Item ...";
            this.repLineEntity.ValueMember = "Id";
            this.repLineEntity.View = this.repViewEntity;
            this.repLineEntity.EditValueChanged += new System.EventHandler(this.repLineEntity_EditValueChanged);
            // 
            // InstantFeedbackSourceItem
            // 
            this.InstantFeedbackSourceItem.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_LineItem);
            this.InstantFeedbackSourceItem.KeyExpression = "Id";
            this.InstantFeedbackSourceItem.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceItem_GetQueryable);
            // 
            // repViewEntity
            // 
            this.repViewEntity.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repViewEntity.Name = "repViewEntity";
            this.repViewEntity.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repViewEntity.OptionsView.ShowGroupPanel = false;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 521;
            // 
            // colQuantity
            // 
            this.colQuantity.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 90;
            this.colQuantity.MinWidth = 60;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowMove = false;
            this.colQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:##,#.00}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            this.colQuantity.Width = 86;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Unit Price";
            this.colAmount.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 80;
            this.colAmount.MinWidth = 60;
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsColumn.AllowMove = false;
            this.colAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 4;
            this.colAmount.Width = 79;
            // 
            // colTotal
            // 
            this.colTotal.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.MaxWidth = 120;
            this.colTotal.MinWidth = 90;
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.AllowFocus = false;
            this.colTotal.OptionsColumn.AllowMove = false;
            this.colTotal.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.OptionsColumn.ShowInCustomizationForm = false;
            this.colTotal.OptionsColumn.ShowInExpressionEditor = false;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:##,#.00}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 5;
            this.colTotal.Width = 116;
            // 
            // colTotalTax
            // 
            this.colTotalTax.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colTotalTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalTax.FieldName = "TotalTax";
            this.colTotalTax.MaxWidth = 120;
            this.colTotalTax.MinWidth = 90;
            this.colTotalTax.Name = "colTotalTax";
            this.colTotalTax.OptionsColumn.AllowEdit = false;
            this.colTotalTax.OptionsColumn.AllowFocus = false;
            this.colTotalTax.OptionsColumn.AllowMove = false;
            this.colTotalTax.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalTax.OptionsColumn.ReadOnly = true;
            this.colTotalTax.OptionsColumn.ShowInCustomizationForm = false;
            this.colTotalTax.OptionsColumn.ShowInExpressionEditor = false;
            this.colTotalTax.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalTax", "{0:##,#.00}")});
            this.colTotalTax.Visible = true;
            this.colTotalTax.VisibleIndex = 6;
            this.colTotalTax.Width = 90;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAmount.FieldName = "TotalAmount";
            this.colTotalAmount.MaxWidth = 120;
            this.colTotalAmount.MinWidth = 90;
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.OptionsColumn.AllowEdit = false;
            this.colTotalAmount.OptionsColumn.AllowFocus = false;
            this.colTotalAmount.OptionsColumn.AllowMove = false;
            this.colTotalAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colTotalAmount.OptionsColumn.ReadOnly = true;
            this.colTotalAmount.OptionsColumn.ShowInCustomizationForm = false;
            this.colTotalAmount.OptionsColumn.ShowInExpressionEditor = false;
            this.colTotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "{0:##,#.00}")});
            this.colTotalAmount.Visible = true;
            this.colTotalAmount.VisibleIndex = 7;
            this.colTotalAmount.Width = 120;
            // 
            // colPriceChanged
            // 
            this.colPriceChanged.FieldName = "PriceChanged";
            this.colPriceChanged.Name = "colPriceChanged";
            this.colPriceChanged.Width = 113;
            // 
            // itmItems
            // 
            this.itmItems.Control = this.grdItems;
            this.itmItems.CustomizationFormText = "itmItems";
            this.itmItems.Location = new System.Drawing.Point(0, 79);
            this.itmItems.Name = "itmItems";
            this.itmItems.Size = new System.Drawing.Size(995, 427);
            this.itmItems.Text = "itmItems";
            this.itmItems.TextSize = new System.Drawing.Size(0, 0);
            this.itmItems.TextVisible = false;
            // 
            // BaseStockDocument
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1015, 737);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "BaseStockDocument";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseStockDocument_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseStockDocument_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup itmDetails;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.XtraEditors.LookUpEdit txtCreatedBy;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCreatedBy;
        private DevExpress.XtraGrid.Views.Grid.GridView grvItems;
        private DevExpress.XtraLayout.LayoutControlItem itmItems;
        protected System.Windows.Forms.BindingSource BindingSourceLine;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceChanged;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colItemId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colLineOrder;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repLineEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView repViewEntity;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraLayout.LayoutControlItem itmMessage;
        private DevExpress.XtraGrid.GridControl grdItems;
    }
}
