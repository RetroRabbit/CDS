namespace CDS.Client.Desktop.Stock.Buyout
{
    partial class BuyoutForm
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
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlCreatedBy = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.XPInstantFeedbackSourceCreatedBy = new DevExpress.Xpo.XPInstantFeedbackSource();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFullname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.lcgIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.itmShortName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.grdTransactions = new DevExpress.XtraGrid.GridControl();
            this.XPInstantFeedbackSourceTransactions = new DevExpress.Xpo.XPInstantFeedbackSource();
            this.grvTransactions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmTransactions = new DevExpress.XtraLayout.LayoutControlItem();
            this.rpStock = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgActionsStock = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnCreateStockItem = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Entity);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.grdTransactions);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtShortName);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.ddlCreatedBy);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(912, 500, 250, 350);
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
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgHistory,
            this.lcgIdentity,
            this.itmTransactions});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCreateStockItem});
            this.RibbonControl.MaxItemId = 27;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpStock});
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
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedBy,
            this.itmCreatedOn});
            this.lcgHistory.Location = new System.Drawing.Point(0, 498);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(988, 67);
            this.lcgHistory.Text = "History";
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.ddlCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(473, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(56, 13);
            // 
            // ddlCreatedBy
            // 
            this.ddlCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.ddlCreatedBy.Location = new System.Drawing.Point(84, 541);
            this.ddlCreatedBy.MenuManager = this.RibbonControl;
            this.ddlCreatedBy.Name = "ddlCreatedBy";
            this.ddlCreatedBy.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.ddlCreatedBy.Properties.DataSource = this.XPInstantFeedbackSourceCreatedBy;
            this.ddlCreatedBy.Properties.DisplayMember = "Fullname";
            this.ddlCreatedBy.Properties.NullText = "";
            this.ddlCreatedBy.Properties.ReadOnly = true;
            this.ddlCreatedBy.Properties.ValueMember = "Id";
            this.ddlCreatedBy.Properties.View = this.searchLookUpEdit1View;
            this.ddlCreatedBy.Size = new System.Drawing.Size(409, 20);
            this.ddlCreatedBy.StyleController = this.LayoutControl;
            this.ddlCreatedBy.TabIndex = 4;
            this.ddlCreatedBy.TabStop = false;
            // 
            // XPInstantFeedbackSourceCreatedBy
            // 
            this.XPInstantFeedbackSourceCreatedBy.DisplayableProperties = "Id;Fullname";
            this.XPInstantFeedbackSourceCreatedBy.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.SYS_Person);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullname});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colFullname
            // 
            this.colFullname.FieldName = "Fullname";
            this.colFullname.Name = "colFullname";
            this.colFullname.Visible = true;
            this.colFullname.VisibleIndex = 0;
            // 
            // itmCreatedOn
            // 
            this.itmCreatedOn.Control = this.txtCreatedOn;
            this.itmCreatedOn.CustomizationFormText = "Created On";
            this.itmCreatedOn.Location = new System.Drawing.Point(473, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(491, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(557, 541);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Properties.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(427, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 5;
            this.txtCreatedOn.TabStop = false;
            // 
            // lcgIdentity
            // 
            this.lcgIdentity.CustomizationFormText = "Identity";
            this.lcgIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmName,
            this.itmShortName,
            this.itmDescription});
            this.lcgIdentity.Location = new System.Drawing.Point(0, 0);
            this.lcgIdentity.Name = "lcgIdentity";
            this.lcgIdentity.Size = new System.Drawing.Size(988, 115);
            this.lcgIdentity.Text = "Identity";
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Code";
            this.itmName.Location = new System.Drawing.Point(0, 0);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(964, 24);
            this.itmName.Text = "Code";
            this.itmName.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(84, 43);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(900, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 6;
            this.txtName.TabStop = false;
            // 
            // itmShortName
            // 
            this.itmShortName.Control = this.txtShortName;
            this.itmShortName.CustomizationFormText = "Name";
            this.itmShortName.Location = new System.Drawing.Point(0, 24);
            this.itmShortName.Name = "itmShortName";
            this.itmShortName.Size = new System.Drawing.Size(964, 24);
            this.itmShortName.Text = "Name";
            this.itmShortName.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtShortName
            // 
            this.txtShortName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ShortName", true));
            this.txtShortName.Location = new System.Drawing.Point(84, 67);
            this.txtShortName.MenuManager = this.RibbonControl;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Properties.ReadOnly = true;
            this.txtShortName.Size = new System.Drawing.Size(900, 20);
            this.txtShortName.StyleController = this.LayoutControl;
            this.txtShortName.TabIndex = 7;
            this.txtShortName.TabStop = false;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 48);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(964, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(84, 91);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(900, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 8;
            this.txtDescription.TabStop = false;
            // 
            // grdTransactions
            // 
            this.grdTransactions.DataSource = this.XPInstantFeedbackSourceTransactions;
            this.grdTransactions.Location = new System.Drawing.Point(12, 127);
            this.grdTransactions.MainView = this.grvTransactions;
            this.grdTransactions.MenuManager = this.RibbonControl;
            this.grdTransactions.Name = "grdTransactions";
            this.grdTransactions.Size = new System.Drawing.Size(984, 379);
            this.grdTransactions.TabIndex = 9;
            this.grdTransactions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTransactions});
            // 
            // XPInstantFeedbackSourceTransactions
            // 
            this.XPInstantFeedbackSourceTransactions.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.IBO_TRX_Header);
            // 
            // grvTransactions
            // 
            this.grvTransactions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerId,
            this.colCustomer,
            this.colSupplierId,
            this.colSupplier,
            this.colQuantity,
            this.colUnitCost,
            this.colUnitPrice,
            this.colCreatedBy,
            this.colCreatedOn});
            this.grvTransactions.GridControl = this.grdTransactions;
            this.grvTransactions.Name = "grvTransactions";
            this.grvTransactions.OptionsView.ShowAutoFilterRow = true;
            this.grvTransactions.OptionsView.ShowGroupPanel = false;
            this.grvTransactions.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCreatedOn, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colCustomerId
            // 
            this.colCustomerId.Caption = "Customer";
            this.colCustomerId.FieldName = "CustomerId.EntityId.Name";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.OptionsColumn.AllowEdit = false;
            this.colCustomerId.OptionsColumn.AllowFocus = false;
            this.colCustomerId.OptionsColumn.AllowMove = false;
            this.colCustomerId.OptionsColumn.ReadOnly = true;
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 0;
            // 
            // colCustomer
            // 
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.OptionsColumn.AllowEdit = false;
            this.colCustomer.OptionsColumn.AllowFocus = false;
            this.colCustomer.OptionsColumn.AllowMove = false;
            this.colCustomer.OptionsColumn.ReadOnly = true;
            this.colCustomer.Visible = true;
            this.colCustomer.VisibleIndex = 1;
            // 
            // colSupplierId
            // 
            this.colSupplierId.Caption = "Supplier";
            this.colSupplierId.FieldName = "SupplierId.EntityId.Name";
            this.colSupplierId.Name = "colSupplierId";
            this.colSupplierId.OptionsColumn.AllowEdit = false;
            this.colSupplierId.OptionsColumn.AllowFocus = false;
            this.colSupplierId.OptionsColumn.AllowMove = false;
            this.colSupplierId.OptionsColumn.ReadOnly = true;
            this.colSupplierId.Visible = true;
            this.colSupplierId.VisibleIndex = 2;
            // 
            // colSupplier
            // 
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.OptionsColumn.AllowEdit = false;
            this.colSupplier.OptionsColumn.AllowFocus = false;
            this.colSupplier.OptionsColumn.AllowMove = false;
            this.colSupplier.OptionsColumn.ReadOnly = true;
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 3;
            // 
            // colQuantity
            // 
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.OptionsColumn.AllowFocus = false;
            this.colQuantity.OptionsColumn.AllowMove = false;
            this.colQuantity.OptionsColumn.ReadOnly = true;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            // 
            // colUnitCost
            // 
            this.colUnitCost.FieldName = "UnitCost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.OptionsColumn.AllowEdit = false;
            this.colUnitCost.OptionsColumn.AllowFocus = false;
            this.colUnitCost.OptionsColumn.AllowMove = false;
            this.colUnitCost.OptionsColumn.ReadOnly = true;
            this.colUnitCost.Visible = true;
            this.colUnitCost.VisibleIndex = 5;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowEdit = false;
            this.colUnitPrice.OptionsColumn.AllowFocus = false;
            this.colUnitPrice.OptionsColumn.AllowMove = false;
            this.colUnitPrice.OptionsColumn.ReadOnly = true;
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 6;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Caption = "Created By";
            this.colCreatedBy.FieldName = "CreatedBy.Fullname";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsColumn.AllowEdit = false;
            this.colCreatedBy.OptionsColumn.AllowFocus = false;
            this.colCreatedBy.OptionsColumn.AllowMove = false;
            this.colCreatedBy.OptionsColumn.ReadOnly = true;
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 7;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.FieldName = "CreatedOn";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.OptionsColumn.AllowEdit = false;
            this.colCreatedOn.OptionsColumn.AllowFocus = false;
            this.colCreatedOn.OptionsColumn.AllowMove = false;
            this.colCreatedOn.OptionsColumn.ReadOnly = true;
            this.colCreatedOn.Visible = true;
            this.colCreatedOn.VisibleIndex = 8;
            // 
            // itmTransactions
            // 
            this.itmTransactions.Control = this.grdTransactions;
            this.itmTransactions.CustomizationFormText = "Transactions";
            this.itmTransactions.Location = new System.Drawing.Point(0, 115);
            this.itmTransactions.Name = "itmTransactions";
            this.itmTransactions.Size = new System.Drawing.Size(988, 383);
            this.itmTransactions.Text = "Transactions";
            this.itmTransactions.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmTransactions.TextSize = new System.Drawing.Size(0, 0);
            this.itmTransactions.TextVisible = false;
            // 
            // rpStock
            // 
            this.rpStock.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgActionsStock});
            this.rpStock.Name = "rpStock";
            this.rpStock.Text = "Stock";
            // 
            // rpgActionsStock
            // 
            this.rpgActionsStock.AllowTextClipping = false;
            this.rpgActionsStock.ItemLinks.Add(this.btnCreateStockItem);
            this.rpgActionsStock.Name = "rpgActionsStock";
            this.rpgActionsStock.Text = "Actions";
            // 
            // btnCreateStockItem
            // 
            this.btnCreateStockItem.Caption = "Create\r\nStock Item";
            this.btnCreateStockItem.Glyph = global::CDS.Client.Desktop.Stock.Properties.Resources.box_16;
            this.btnCreateStockItem.Id = 26;
            this.btnCreateStockItem.LargeGlyph = global::CDS.Client.Desktop.Stock.Properties.Resources.box_32;
            this.btnCreateStockItem.Name = "btnCreateStockItem";
            this.btnCreateStockItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateStockItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateStockItem_ItemClick);
            // 
            // BuyoutForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "BuyoutForm";
            this.TabIcon = global::CDS.Client.Desktop.Stock.Properties.Resources.platform_truck_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Stock.Properties.Resources.platform_truck_16;
            this.Text = "Buyout";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourceCreatedBy;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlCreatedBy;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtShortName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIdentity;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlItem itmShortName;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraGrid.GridControl grdTransactions;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTransactions;
        private DevExpress.XtraLayout.LayoutControlItem itmTransactions;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourceTransactions;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierId;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colFullname;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpStock;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActionsStock;
        private DevExpress.XtraBars.BarButtonItem btnCreateStockItem;
    }
}
