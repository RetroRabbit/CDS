namespace CDS.Client.Desktop.Stock.Inventory
{
    partial class InventoryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryList));
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationSecondary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinimumStockLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaximumStockLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSafetyStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehousingCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrouping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfitMatgin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLabelFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnReserve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.colOnHold = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).BeginInit();
            this.LayoutControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl.Size = new System.Drawing.Size(1018, 619);
            // 
            // GridView
            // 
            this.GridView.ActiveFilterString = "[EntityId.Archived] = False";
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShortName,
            this.colName,
            this.colDescription,
            this.colArchived,
            this.colItemCreatedOn,
            this.colItemCreatedBy,
            this.colCategory,
            this.colSubCategory,
            this.colStockType,
            this.colLocationMain,
            this.colLocationSecondary,
            this.colMinimumStockLevel,
            this.colMaximumStockLevel,
            this.colSafetyStock,
            this.colWarehousingCost,
            this.colDiscountCode,
            this.colGrouping,
            this.colProfitMatgin,
            this.colLabelFlag,
            this.colOnHand,
            this.colOnHold,
            this.colOnOrder,
            this.colOnReserve,
            this.colUnitAverage,
            this.colUnitCost,
            this.colUnitPrice,
            this.colSupplierStockCode});
            this.GridView.CustomizationFormBounds = new System.Drawing.Rectangle(1704, 332, 216, 185);
            this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowGroupPanel = false;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // LayoutControlGrid
            // 
            this.LayoutControlGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.XPOInstantFeedbackSource.DisplayableProperties = resources.GetString("XPOInstantFeedbackSource.DisplayableProperties");
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.ITM_Inventory);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnImport});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RibbonControl.MaxItemId = 8;
            this.RibbonControl.Size = new System.Drawing.Size(1022, 144);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnImport);
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
            // colShortName
            // 
            this.colShortName.Caption = "Name";
            this.colShortName.FieldName = "EntityId.ShortName";
            this.colShortName.MinWidth = 50;
            this.colShortName.Name = "colShortName";
            this.colShortName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShortName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShortName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 1;
            this.colShortName.Width = 50;
            // 
            // colName
            // 
            this.colName.Caption = "Code";
            this.colName.FieldName = "EntityId.Name";
            this.colName.MinWidth = 50;
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "EntityId.Description";
            this.colDescription.MinWidth = 50;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colDescription.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 50;
            // 
            // colArchived
            // 
            this.colArchived.Caption = "Archived";
            this.colArchived.FieldName = "EntityId.Archived";
            this.colArchived.MinWidth = 40;
            this.colArchived.Name = "colArchived";
            this.colArchived.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colArchived.Width = 50;
            // 
            // colItemCreatedOn
            // 
            this.colItemCreatedOn.Caption = "Created On";
            this.colItemCreatedOn.FieldName = "EntityId.CreatedOn";
            this.colItemCreatedOn.MinWidth = 40;
            this.colItemCreatedOn.Name = "colItemCreatedOn";
            this.colItemCreatedOn.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colItemCreatedOn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colItemCreatedOn.Width = 50;
            // 
            // colItemCreatedBy
            // 
            this.colItemCreatedBy.Caption = "Created By";
            this.colItemCreatedBy.FieldName = "EntityId.CreatedBy.Fullname";
            this.colItemCreatedBy.MinWidth = 40;
            this.colItemCreatedBy.Name = "colItemCreatedBy";
            this.colItemCreatedBy.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colItemCreatedBy.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colItemCreatedBy.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colItemCreatedBy.Width = 50;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Category";
            this.colCategory.FieldName = "Category";
            this.colCategory.MinWidth = 40;
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCategory.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCategory.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 3;
            this.colCategory.Width = 50;
            // 
            // colSubCategory
            // 
            this.colSubCategory.FieldName = "SubCategory";
            this.colSubCategory.MinWidth = 40;
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSubCategory.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colSubCategory.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colSubCategory.Width = 50;
            // 
            // colStockType
            // 
            this.colStockType.FieldName = "StockType";
            this.colStockType.MinWidth = 40;
            this.colStockType.Name = "colStockType";
            this.colStockType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colStockType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStockType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStockType.Width = 50;
            // 
            // colLocationMain
            // 
            this.colLocationMain.FieldName = "LocationMain";
            this.colLocationMain.MinWidth = 40;
            this.colLocationMain.Name = "colLocationMain";
            this.colLocationMain.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLocationMain.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colLocationMain.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colLocationMain.Width = 50;
            // 
            // colLocationSecondary
            // 
            this.colLocationSecondary.FieldName = "LocationSecondary";
            this.colLocationSecondary.MinWidth = 40;
            this.colLocationSecondary.Name = "colLocationSecondary";
            this.colLocationSecondary.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLocationSecondary.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colLocationSecondary.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colLocationSecondary.Width = 50;
            // 
            // colMinimumStockLevel
            // 
            this.colMinimumStockLevel.FieldName = "MinimumStockLevel";
            this.colMinimumStockLevel.MinWidth = 40;
            this.colMinimumStockLevel.Name = "colMinimumStockLevel";
            this.colMinimumStockLevel.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colMinimumStockLevel.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colMinimumStockLevel.Width = 50;
            // 
            // colMaximumStockLevel
            // 
            this.colMaximumStockLevel.FieldName = "MaximumStockLevel";
            this.colMaximumStockLevel.MinWidth = 40;
            this.colMaximumStockLevel.Name = "colMaximumStockLevel";
            this.colMaximumStockLevel.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colMaximumStockLevel.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colMaximumStockLevel.Width = 50;
            // 
            // colSafetyStock
            // 
            this.colSafetyStock.FieldName = "SafetyStock";
            this.colSafetyStock.MinWidth = 40;
            this.colSafetyStock.Name = "colSafetyStock";
            this.colSafetyStock.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colSafetyStock.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colSafetyStock.Width = 50;
            // 
            // colWarehousingCost
            // 
            this.colWarehousingCost.FieldName = "WarehousingCost";
            this.colWarehousingCost.MinWidth = 40;
            this.colWarehousingCost.Name = "colWarehousingCost";
            this.colWarehousingCost.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colWarehousingCost.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colWarehousingCost.Width = 50;
            // 
            // colDiscountCode
            // 
            this.colDiscountCode.FieldName = "DiscountCode";
            this.colDiscountCode.MinWidth = 40;
            this.colDiscountCode.Name = "colDiscountCode";
            this.colDiscountCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDiscountCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colDiscountCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDiscountCode.Width = 50;
            // 
            // colGrouping
            // 
            this.colGrouping.FieldName = "Grouping";
            this.colGrouping.MinWidth = 40;
            this.colGrouping.Name = "colGrouping";
            this.colGrouping.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGrouping.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colGrouping.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colGrouping.Width = 50;
            // 
            // colProfitMatgin
            // 
            this.colProfitMatgin.FieldName = "ProfitMargin";
            this.colProfitMatgin.MinWidth = 40;
            this.colProfitMatgin.Name = "colProfitMatgin";
            this.colProfitMatgin.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colProfitMatgin.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colProfitMatgin.Width = 50;
            // 
            // colLabelFlag
            // 
            this.colLabelFlag.FieldName = "LabelFlag";
            this.colLabelFlag.MinWidth = 40;
            this.colLabelFlag.Name = "colLabelFlag";
            this.colLabelFlag.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLabelFlag.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colLabelFlag.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colLabelFlag.Width = 50;
            // 
            // colOnHand
            // 
            this.colOnHand.Caption = "On Hand";
            this.colOnHand.FieldName = "OnHand";
            this.colOnHand.Name = "colOnHand";
            this.colOnHand.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colOnHand.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colOnHand.Visible = true;
            this.colOnHand.VisibleIndex = 4;
            // 
            // colOnOrder
            // 
            this.colOnOrder.Caption = "On Order";
            this.colOnOrder.FieldName = "OnOrder";
            this.colOnOrder.Name = "colOnOrder";
            this.colOnOrder.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colOnOrder.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colOnOrder.Visible = true;
            this.colOnOrder.VisibleIndex = 6;
            // 
            // colOnReserve
            // 
            this.colOnReserve.Caption = "On Reserve";
            this.colOnReserve.FieldName = "EntityId.OnReserve";
            this.colOnReserve.Name = "colOnReserve";
            this.colOnReserve.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colOnReserve.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colUnitAverage
            // 
            this.colUnitAverage.Caption = "Unit Average";
            this.colUnitAverage.FieldName = "UnitAverage";
            this.colUnitAverage.Name = "colUnitAverage";
            this.colUnitAverage.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colUnitAverage.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colUnitAverage.Visible = true;
            this.colUnitAverage.VisibleIndex = 7;
            // 
            // colUnitCost
            // 
            this.colUnitCost.Caption = "Unit Cost";
            this.colUnitCost.FieldName = "UnitCost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colUnitCost.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colUnitCost.Visible = true;
            this.colUnitCost.VisibleIndex = 9;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "Unit Price";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colUnitPrice.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 8;
            // 
            // colSupplierStockCode
            // 
            this.colSupplierStockCode.Caption = "Supplier Stock Code";
            this.colSupplierStockCode.FieldName = "EntityId.SupplierStockCode";
            this.colSupplierStockCode.Name = "colSupplierStockCode";
            this.colSupplierStockCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSupplierStockCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colSupplierStockCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Import Inventory";
            this.btnImport.Id = 7;
            this.btnImport.Name = "btnImport";
            this.btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // colOnHold
            // 
            this.colOnHold.Caption = "On Hold";
            this.colOnHold.FieldName = "OnHold";
            this.colOnHold.Name = "colOnHold";
            this.colOnHold.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colOnHold.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colOnHold.Visible = true;
            this.colOnHold.VisibleIndex = 5;
            // 
            // InventoryList
            // 
            this.ActiveFilter = "[EntityId.Archived] = False";
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1022, 767);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "InventoryList";
            this.SuperTipParameter = "Inventory Item,Inventory Items";
            this.TabIcon = global::CDS.Client.Desktop.Stock.Properties.Resources.box_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Stock.Properties.Resources.box_16;
            this.Text = "Stock";
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).EndInit();
            this.LayoutControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colArchived;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colStockType;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationMain;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationSecondary;
        private DevExpress.XtraGrid.Columns.GridColumn colMinimumStockLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colMaximumStockLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colSafetyStock;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehousingCost;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGrouping;
        private DevExpress.XtraGrid.Columns.GridColumn colProfitMatgin;
        private DevExpress.XtraGrid.Columns.GridColumn colLabelFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand;
        private DevExpress.XtraGrid.Columns.GridColumn colOnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colOnReserve;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitAverage;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierStockCode;
        private DevExpress.XtraBars.BarButtonItem btnImport;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHold;

    }
}
