namespace CDS.Client.Desktop.Ordering.AOR
{
    partial class AutomaticOrderingDetailForm
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
            this.tcgDetail = new DevExpress.XtraLayout.TabbedControlGroup();
            this.tabHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmGridHistory = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdHistory = new CDS.Client.Desktop.Essential.UTL.CustomGridControl();
            this.InstantFeedbackSourceSalesHistory = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.grvHistory = new CDS.Client.Desktop.Essential.UTL.CustomGridView();
            this.colHistoryFinancialYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryMovement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryOnReserve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryOnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryUnitAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryFirstSold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryFirstPurchased = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryLastSold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryLastPurchased = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryLastMovement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoryModifiedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistorySales12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistorySales6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistorySales3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabLinkedBranches = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.itmCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAvgDemand = new DevExpress.XtraEditors.TextEdit();
            this.itmAvgDemand = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtEOQ = new DevExpress.XtraEditors.TextEdit();
            this.itmEOQ = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtOnHand = new DevExpress.XtraEditors.TextEdit();
            this.itmOnHand = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtOnReserve = new DevExpress.XtraEditors.TextEdit();
            this.itmOnReserve = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtOnOrder = new DevExpress.XtraEditors.TextEdit();
            this.itmOnOrder = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtOrderPoint = new DevExpress.XtraEditors.TextEdit();
            this.itmOrderPoint = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReOrder = new DevExpress.XtraEditors.TextEdit();
            this.itmReOrder = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage3Month = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage3Month = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage6Month = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage6Month = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage12Month = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage12Month = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt24MonthAverage = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage24Month = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage36Month = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage36Month = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.BindingSourceHistory = new System.Windows.Forms.BindingSource();
            this.lcgHoldingInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmMinimumLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMinimumLevel = new DevExpress.XtraEditors.TextEdit();
            this.itmMaximumLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMaximumLevel = new DevExpress.XtraEditors.TextEdit();
            this.lciMaxOrderLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lciMinOrderLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAverage3MonthPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage3MonthPrev = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage6MonthPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage6MonthPrev = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage12MonthPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage12MonthPrev = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage24MonthPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage24MonthPrev = new DevExpress.XtraEditors.TextEdit();
            this.itmAverage36MonthPrev = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAverage36MonthPrev = new DevExpress.XtraEditors.TextEdit();
            this.lcgFinancialFigures = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmUnitPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnitPrice = new DevExpress.XtraEditors.TextEdit();
            this.itmUnitReplacement = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnitReplacement = new DevExpress.XtraEditors.TextEdit();
            this.itmWarehousingCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtWarehousingCode = new DevExpress.XtraEditors.TextEdit();
            this.itmUnitCost = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnitCost = new DevExpress.XtraEditors.TextEdit();
            this.lcgIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCategory = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCategory = new DevExpress.XtraEditors.TextEdit();
            this.itmSubCategory = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSubCategory = new DevExpress.XtraEditors.TextEdit();
            this.itmLocation = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.itmStockType = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtStockType = new DevExpress.XtraEditors.TextEdit();
            this.itmSafetyStock = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSafetyStock = new DevExpress.XtraEditors.TextEdit();
            this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
            this.itmMaximumOrderSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgPrimarySupplier = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmMinimumOrderSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMinimumOrderSize = new DevExpress.XtraEditors.TextEdit();
            this.itmPackSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPackSize = new DevExpress.XtraEditors.TextEdit();
            this.itmOrderLeadTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtOrderLeadTime = new DevExpress.XtraEditors.TextEdit();
            this.itmCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCompany = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLinkedBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvgDemand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAvgDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEOQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEOQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnHand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOnHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnReserve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOnReserve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderPoint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOrderPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage3Month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage3Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage6Month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage6Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage12Month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage12Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt24MonthAverage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage24Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage36Month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage36Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHoldingInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMinimumLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimumLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMaximumLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximumLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaxOrderLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMinOrderLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage3MonthPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage3MonthPrev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage6MonthPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage6MonthPrev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage12MonthPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage12MonthPrev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage24MonthPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage24MonthPrev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage36MonthPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage36MonthPrev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFinancialFigures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUnitReplacement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitReplacement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmWarehousingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehousingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSubCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStockType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSafetyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSafetyStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMaximumOrderSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrimarySupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMinimumOrderSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimumOrderSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPackSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOrderLeadTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderLeadTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.AOR_OrderLine);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.textEdit2);
            this.LayoutControl.Controls.Add(this.textEdit1);
            this.LayoutControl.Controls.Add(this.txtUnitCost);
            this.LayoutControl.Controls.Add(this.txtAverage36MonthPrev);
            this.LayoutControl.Controls.Add(this.txtAverage24MonthPrev);
            this.LayoutControl.Controls.Add(this.txtAverage12MonthPrev);
            this.LayoutControl.Controls.Add(this.txtAverage6MonthPrev);
            this.LayoutControl.Controls.Add(this.txtAverage3MonthPrev);
            this.LayoutControl.Controls.Add(this.txtWarehousingCode);
            this.LayoutControl.Controls.Add(this.txtUnitReplacement);
            this.LayoutControl.Controls.Add(this.txtUnitPrice);
            this.LayoutControl.Controls.Add(this.txtCompany);
            this.LayoutControl.Controls.Add(this.txtOrderLeadTime);
            this.LayoutControl.Controls.Add(this.txtPackSize);
            this.LayoutControl.Controls.Add(this.txtMinimumOrderSize);
            this.LayoutControl.Controls.Add(this.textEdit6);
            this.LayoutControl.Controls.Add(this.txtSafetyStock);
            this.LayoutControl.Controls.Add(this.txtStockType);
            this.LayoutControl.Controls.Add(this.txtLocation);
            this.LayoutControl.Controls.Add(this.txtSubCategory);
            this.LayoutControl.Controls.Add(this.txtCategory);
            this.LayoutControl.Controls.Add(this.txtMinimumLevel);
            this.LayoutControl.Controls.Add(this.txtMaximumLevel);
            this.LayoutControl.Controls.Add(this.txtAverage36Month);
            this.LayoutControl.Controls.Add(this.txt24MonthAverage);
            this.LayoutControl.Controls.Add(this.txtAverage12Month);
            this.LayoutControl.Controls.Add(this.txtAverage6Month);
            this.LayoutControl.Controls.Add(this.txtAverage3Month);
            this.LayoutControl.Controls.Add(this.txtReOrder);
            this.LayoutControl.Controls.Add(this.txtOrderPoint);
            this.LayoutControl.Controls.Add(this.txtOnOrder);
            this.LayoutControl.Controls.Add(this.txtOnReserve);
            this.LayoutControl.Controls.Add(this.txtOnHand);
            this.LayoutControl.Controls.Add(this.txtEOQ);
            this.LayoutControl.Controls.Add(this.txtAvgDemand);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.txtCode);
            this.LayoutControl.Controls.Add(this.grdHistory);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2844, 524, 250, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(1008, 584);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tcgDetail,
            this.simpleSeparator1,
            this.lcgIdentity,
            this.lcgFinancialFigures,
            this.lcgHoldingInformation,
            this.lcgHistory,
            this.lcgPrimarySupplier});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(1008, 584);
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.MaxItemId = 25;
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
            // tcgDetail
            // 
            this.tcgDetail.CustomizationFormText = "tabbedControlGroup1";
            this.tcgDetail.Location = new System.Drawing.Point(0, 374);
            this.tcgDetail.Name = "tcgDetail";
            this.tcgDetail.SelectedTabPage = this.tabHistory;
            this.tcgDetail.SelectedTabPageIndex = 0;
            this.tcgDetail.Size = new System.Drawing.Size(988, 190);
            this.tcgDetail.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabHistory,
            this.tabLinkedBranches});
            this.tcgDetail.Text = "tcgDetail";
            // 
            // tabHistory
            // 
            this.tabHistory.CustomizationFormText = "History";
            this.tabHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmGridHistory});
            this.tabHistory.Location = new System.Drawing.Point(0, 0);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(964, 144);
            this.tabHistory.Text = "History";
            // 
            // itmGridHistory
            // 
            this.itmGridHistory.Control = this.grdHistory;
            this.itmGridHistory.CustomizationFormText = "Grid History";
            this.itmGridHistory.Location = new System.Drawing.Point(0, 0);
            this.itmGridHistory.Name = "itmGridHistory";
            this.itmGridHistory.Size = new System.Drawing.Size(964, 144);
            this.itmGridHistory.Text = "Grid History";
            this.itmGridHistory.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridHistory.TextVisible = false;
            // 
            // grdHistory
            // 
            this.grdHistory.DataSource = this.InstantFeedbackSourceSalesHistory;
            this.grdHistory.Location = new System.Drawing.Point(24, 420);
            this.grdHistory.MainView = this.grvHistory;
            this.grdHistory.MenuManager = this.RibbonControl;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.Size = new System.Drawing.Size(960, 140);
            this.grdHistory.TabIndex = 3;
            this.grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHistory});
            // 
            // InstantFeedbackSourceSalesHistory
            // 
            this.InstantFeedbackSourceSalesHistory.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_ItemHistory);
            this.InstantFeedbackSourceSalesHistory.KeyExpression = "Id";
            this.InstantFeedbackSourceSalesHistory.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceSalesHistory_GetQueryable);
            // 
            // grvHistory
            // 
            this.grvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHistoryFinancialYear,
            this.colHistoryCode,
            this.colHistoryAmount,
            this.colHistoryMovement,
            this.colHistoryOnHand,
            this.colHistoryOnReserve,
            this.colHistoryOnOrder,
            this.colHistoryUnitPrice,
            this.colHistoryUnitCost,
            this.colHistoryUnitAverage,
            this.colHistoryFirstSold,
            this.colHistoryFirstPurchased,
            this.colHistoryLastSold,
            this.colHistoryLastPurchased,
            this.colHistoryLastMovement,
            this.colHistoryModifiedBy,
            this.colHistoryCreatedOn,
            this.colHistoryCreatedBy,
            this.colHistoryModifiedOn,
            this.colHistorySales12,
            this.colHistorySales6,
            this.colHistorySales3});
            this.grvHistory.GridControl = this.grdHistory;
            this.grvHistory.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvHistory.Name = "grvHistory";
            this.grvHistory.OptionsView.ColumnAutoWidth = false;
            this.grvHistory.OptionsView.EnableAppearanceEvenRow = true;
            this.grvHistory.OptionsView.EnableAppearanceOddRow = true;
            this.grvHistory.OptionsView.ShowAutoFilterRow = true;
            this.grvHistory.OptionsView.ShowGroupPanel = false;
            this.grvHistory.PreviewFieldName = "Code";
            this.grvHistory.PreviewRowEdit = null;
            this.grvHistory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colHistoryFinancialYear, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colHistoryFinancialYear
            // 
            this.colHistoryFinancialYear.FieldName = "FinancialYear";
            this.colHistoryFinancialYear.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colHistoryFinancialYear.Name = "colHistoryFinancialYear";
            this.colHistoryFinancialYear.OptionsColumn.AllowEdit = false;
            this.colHistoryFinancialYear.Visible = true;
            this.colHistoryFinancialYear.VisibleIndex = 0;
            this.colHistoryFinancialYear.Width = 97;
            // 
            // colHistoryCode
            // 
            this.colHistoryCode.FieldName = "Code";
            this.colHistoryCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colHistoryCode.Name = "colHistoryCode";
            this.colHistoryCode.OptionsColumn.AllowEdit = false;
            this.colHistoryCode.Visible = true;
            this.colHistoryCode.VisibleIndex = 1;
            // 
            // colHistoryAmount
            // 
            this.colHistoryAmount.FieldName = "Amount";
            this.colHistoryAmount.Name = "colHistoryAmount";
            this.colHistoryAmount.OptionsColumn.AllowEdit = false;
            this.colHistoryAmount.Visible = true;
            this.colHistoryAmount.VisibleIndex = 2;
            // 
            // colHistoryMovement
            // 
            this.colHistoryMovement.FieldName = "Movement";
            this.colHistoryMovement.Name = "colHistoryMovement";
            this.colHistoryMovement.OptionsColumn.AllowEdit = false;
            this.colHistoryMovement.Visible = true;
            this.colHistoryMovement.VisibleIndex = 3;
            // 
            // colHistoryOnHand
            // 
            this.colHistoryOnHand.FieldName = "OnHand";
            this.colHistoryOnHand.Name = "colHistoryOnHand";
            this.colHistoryOnHand.OptionsColumn.AllowEdit = false;
            this.colHistoryOnHand.Visible = true;
            this.colHistoryOnHand.VisibleIndex = 4;
            // 
            // colHistoryOnReserve
            // 
            this.colHistoryOnReserve.FieldName = "OnReserve";
            this.colHistoryOnReserve.Name = "colHistoryOnReserve";
            this.colHistoryOnReserve.OptionsColumn.AllowEdit = false;
            this.colHistoryOnReserve.Visible = true;
            this.colHistoryOnReserve.VisibleIndex = 5;
            this.colHistoryOnReserve.Width = 91;
            // 
            // colHistoryOnOrder
            // 
            this.colHistoryOnOrder.FieldName = "OnOrder";
            this.colHistoryOnOrder.Name = "colHistoryOnOrder";
            this.colHistoryOnOrder.OptionsColumn.AllowEdit = false;
            this.colHistoryOnOrder.Visible = true;
            this.colHistoryOnOrder.VisibleIndex = 6;
            // 
            // colHistoryUnitPrice
            // 
            this.colHistoryUnitPrice.FieldName = "UnitPrice";
            this.colHistoryUnitPrice.Name = "colHistoryUnitPrice";
            this.colHistoryUnitPrice.OptionsColumn.AllowEdit = false;
            this.colHistoryUnitPrice.Visible = true;
            this.colHistoryUnitPrice.VisibleIndex = 7;
            // 
            // colHistoryUnitCost
            // 
            this.colHistoryUnitCost.FieldName = "UnitCost";
            this.colHistoryUnitCost.Name = "colHistoryUnitCost";
            this.colHistoryUnitCost.OptionsColumn.AllowEdit = false;
            this.colHistoryUnitCost.Visible = true;
            this.colHistoryUnitCost.VisibleIndex = 8;
            // 
            // colHistoryUnitAverage
            // 
            this.colHistoryUnitAverage.FieldName = "UnitAverage";
            this.colHistoryUnitAverage.Name = "colHistoryUnitAverage";
            this.colHistoryUnitAverage.OptionsColumn.AllowEdit = false;
            this.colHistoryUnitAverage.Visible = true;
            this.colHistoryUnitAverage.VisibleIndex = 9;
            this.colHistoryUnitAverage.Width = 93;
            // 
            // colHistoryFirstSold
            // 
            this.colHistoryFirstSold.FieldName = "FirstSold";
            this.colHistoryFirstSold.Name = "colHistoryFirstSold";
            this.colHistoryFirstSold.OptionsColumn.AllowEdit = false;
            this.colHistoryFirstSold.Visible = true;
            this.colHistoryFirstSold.VisibleIndex = 10;
            // 
            // colHistoryFirstPurchased
            // 
            this.colHistoryFirstPurchased.FieldName = "FirstPurchased";
            this.colHistoryFirstPurchased.Name = "colHistoryFirstPurchased";
            this.colHistoryFirstPurchased.OptionsColumn.AllowEdit = false;
            this.colHistoryFirstPurchased.Visible = true;
            this.colHistoryFirstPurchased.VisibleIndex = 11;
            this.colHistoryFirstPurchased.Width = 106;
            // 
            // colHistoryLastSold
            // 
            this.colHistoryLastSold.FieldName = "LastSold";
            this.colHistoryLastSold.Name = "colHistoryLastSold";
            this.colHistoryLastSold.OptionsColumn.AllowEdit = false;
            this.colHistoryLastSold.Visible = true;
            this.colHistoryLastSold.VisibleIndex = 12;
            // 
            // colHistoryLastPurchased
            // 
            this.colHistoryLastPurchased.FieldName = "LastPurchased";
            this.colHistoryLastPurchased.Name = "colHistoryLastPurchased";
            this.colHistoryLastPurchased.OptionsColumn.AllowEdit = false;
            this.colHistoryLastPurchased.Visible = true;
            this.colHistoryLastPurchased.VisibleIndex = 13;
            this.colHistoryLastPurchased.Width = 105;
            // 
            // colHistoryLastMovement
            // 
            this.colHistoryLastMovement.FieldName = "LastMovement";
            this.colHistoryLastMovement.Name = "colHistoryLastMovement";
            this.colHistoryLastMovement.OptionsColumn.AllowEdit = false;
            this.colHistoryLastMovement.Visible = true;
            this.colHistoryLastMovement.VisibleIndex = 14;
            this.colHistoryLastMovement.Width = 107;
            // 
            // colHistoryModifiedBy
            // 
            this.colHistoryModifiedBy.FieldName = "ModifiedBy";
            this.colHistoryModifiedBy.Name = "colHistoryModifiedBy";
            this.colHistoryModifiedBy.OptionsColumn.AllowEdit = false;
            this.colHistoryModifiedBy.Visible = true;
            this.colHistoryModifiedBy.VisibleIndex = 15;
            // 
            // colHistoryCreatedOn
            // 
            this.colHistoryCreatedOn.FieldName = "CreatedOn";
            this.colHistoryCreatedOn.Name = "colHistoryCreatedOn";
            this.colHistoryCreatedOn.OptionsColumn.AllowEdit = false;
            this.colHistoryCreatedOn.Visible = true;
            this.colHistoryCreatedOn.VisibleIndex = 16;
            this.colHistoryCreatedOn.Width = 82;
            // 
            // colHistoryCreatedBy
            // 
            this.colHistoryCreatedBy.FieldName = "CreatedBy";
            this.colHistoryCreatedBy.Name = "colHistoryCreatedBy";
            this.colHistoryCreatedBy.OptionsColumn.AllowEdit = false;
            this.colHistoryCreatedBy.Visible = true;
            this.colHistoryCreatedBy.VisibleIndex = 17;
            this.colHistoryCreatedBy.Width = 81;
            // 
            // colHistoryModifiedOn
            // 
            this.colHistoryModifiedOn.FieldName = "ModifiedOn";
            this.colHistoryModifiedOn.Name = "colHistoryModifiedOn";
            this.colHistoryModifiedOn.OptionsColumn.AllowEdit = false;
            this.colHistoryModifiedOn.Visible = true;
            this.colHistoryModifiedOn.VisibleIndex = 18;
            this.colHistoryModifiedOn.Width = 85;
            // 
            // colHistorySales12
            // 
            this.colHistorySales12.FieldName = "Sales12";
            this.colHistorySales12.Name = "colHistorySales12";
            this.colHistorySales12.OptionsColumn.AllowEdit = false;
            this.colHistorySales12.Visible = true;
            this.colHistorySales12.VisibleIndex = 19;
            // 
            // colHistorySales6
            // 
            this.colHistorySales6.FieldName = "Sales6";
            this.colHistorySales6.Name = "colHistorySales6";
            this.colHistorySales6.OptionsColumn.AllowEdit = false;
            this.colHistorySales6.Visible = true;
            this.colHistorySales6.VisibleIndex = 20;
            // 
            // colHistorySales3
            // 
            this.colHistorySales3.FieldName = "Sales3";
            this.colHistorySales3.Name = "colHistorySales3";
            this.colHistorySales3.OptionsColumn.AllowEdit = false;
            this.colHistorySales3.Visible = true;
            this.colHistorySales3.VisibleIndex = 21;
            // 
            // tabLinkedBranches
            // 
            this.tabLinkedBranches.CustomizationFormText = "Linked Branches";
            this.tabLinkedBranches.Location = new System.Drawing.Point(0, 0);
            this.tabLinkedBranches.Name = "tabLinkedBranches";
            this.tabLinkedBranches.Size = new System.Drawing.Size(964, 144);
            this.tabLinkedBranches.Text = "Linked Branches";
            // 
            // txtCode
            // 
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ShortName", true));
            this.txtCode.Location = new System.Drawing.Point(167, 43);
            this.txtCode.MenuManager = this.RibbonControl;
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(215, 20);
            this.txtCode.StyleController = this.LayoutControl;
            this.txtCode.TabIndex = 4;
            this.txtCode.TabStop = false;
            // 
            // itmCode
            // 
            this.itmCode.Control = this.txtCode;
            this.itmCode.CustomizationFormText = "Code";
            this.itmCode.Location = new System.Drawing.Point(0, 0);
            this.itmCode.Name = "itmCode";
            this.itmCode.Size = new System.Drawing.Size(362, 24);
            this.itmCode.Text = "Code";
            this.itmCode.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(167, 67);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtName.Properties.Appearance.Options.UseBackColor = true;
            this.txtName.Properties.Appearance.Options.UseForeColor = true;
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(215, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 5;
            this.txtName.TabStop = false;
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 24);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(362, 24);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAvgDemand
            // 
            this.txtAvgDemand.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AvgDemand", true));
            this.txtAvgDemand.Location = new System.Drawing.Point(553, 139);
            this.txtAvgDemand.MenuManager = this.RibbonControl;
            this.txtAvgDemand.Name = "txtAvgDemand";
            this.txtAvgDemand.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAvgDemand.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtAvgDemand.Properties.Appearance.Options.UseBackColor = true;
            this.txtAvgDemand.Properties.Appearance.Options.UseForeColor = true;
            this.txtAvgDemand.Properties.ReadOnly = true;
            this.txtAvgDemand.Size = new System.Drawing.Size(191, 20);
            this.txtAvgDemand.StyleController = this.LayoutControl;
            this.txtAvgDemand.TabIndex = 6;
            this.txtAvgDemand.TabStop = false;
            // 
            // itmAvgDemand
            // 
            this.itmAvgDemand.Control = this.txtAvgDemand;
            this.itmAvgDemand.CustomizationFormText = "Avg Demand";
            this.itmAvgDemand.Location = new System.Drawing.Point(0, 96);
            this.itmAvgDemand.Name = "itmAvgDemand";
            this.itmAvgDemand.Size = new System.Drawing.Size(338, 24);
            this.itmAvgDemand.Text = "Avg Demand";
            this.itmAvgDemand.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtEOQ
            // 
            this.txtEOQ.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "EOQ", true));
            this.txtEOQ.Location = new System.Drawing.Point(553, 163);
            this.txtEOQ.MenuManager = this.RibbonControl;
            this.txtEOQ.Name = "txtEOQ";
            this.txtEOQ.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEOQ.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtEOQ.Properties.Appearance.Options.UseBackColor = true;
            this.txtEOQ.Properties.Appearance.Options.UseForeColor = true;
            this.txtEOQ.Properties.ReadOnly = true;
            this.txtEOQ.Size = new System.Drawing.Size(191, 20);
            this.txtEOQ.StyleController = this.LayoutControl;
            this.txtEOQ.TabIndex = 7;
            this.txtEOQ.TabStop = false;
            // 
            // itmEOQ
            // 
            this.itmEOQ.Control = this.txtEOQ;
            this.itmEOQ.CustomizationFormText = "EOQ";
            this.itmEOQ.Location = new System.Drawing.Point(0, 120);
            this.itmEOQ.Name = "itmEOQ";
            this.itmEOQ.Size = new System.Drawing.Size(338, 24);
            this.itmEOQ.Text = "EOQ";
            this.itmEOQ.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtOnHand
            // 
            this.txtOnHand.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OnHand", true));
            this.txtOnHand.Location = new System.Drawing.Point(167, 254);
            this.txtOnHand.MenuManager = this.RibbonControl;
            this.txtOnHand.Name = "txtOnHand";
            this.txtOnHand.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOnHand.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtOnHand.Properties.Appearance.Options.UseBackColor = true;
            this.txtOnHand.Properties.Appearance.Options.UseForeColor = true;
            this.txtOnHand.Properties.ReadOnly = true;
            this.txtOnHand.Size = new System.Drawing.Size(252, 20);
            this.txtOnHand.StyleController = this.LayoutControl;
            this.txtOnHand.TabIndex = 8;
            this.txtOnHand.TabStop = false;
            // 
            // itmOnHand
            // 
            this.itmOnHand.Control = this.txtOnHand;
            this.itmOnHand.CustomizationFormText = "On Hand";
            this.itmOnHand.Location = new System.Drawing.Point(0, 0);
            this.itmOnHand.Name = "itmOnHand";
            this.itmOnHand.Size = new System.Drawing.Size(399, 24);
            this.itmOnHand.Text = "On Hand";
            this.itmOnHand.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtOnReserve
            // 
            this.txtOnReserve.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OnReserve", true));
            this.txtOnReserve.Location = new System.Drawing.Point(367, 278);
            this.txtOnReserve.MenuManager = this.RibbonControl;
            this.txtOnReserve.Name = "txtOnReserve";
            this.txtOnReserve.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOnReserve.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtOnReserve.Properties.Appearance.Options.UseBackColor = true;
            this.txtOnReserve.Properties.Appearance.Options.UseForeColor = true;
            this.txtOnReserve.Properties.ReadOnly = true;
            this.txtOnReserve.Size = new System.Drawing.Size(52, 20);
            this.txtOnReserve.StyleController = this.LayoutControl;
            this.txtOnReserve.TabIndex = 9;
            this.txtOnReserve.TabStop = false;
            // 
            // itmOnReserve
            // 
            this.itmOnReserve.Control = this.txtOnReserve;
            this.itmOnReserve.CustomizationFormText = "itmOn Reserve";
            this.itmOnReserve.Location = new System.Drawing.Point(200, 24);
            this.itmOnReserve.Name = "itmOnReserve";
            this.itmOnReserve.Size = new System.Drawing.Size(199, 24);
            this.itmOnReserve.Text = "On Reserve";
            this.itmOnReserve.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtOnOrder
            // 
            this.txtOnOrder.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OnOrder", true));
            this.txtOnOrder.Location = new System.Drawing.Point(167, 278);
            this.txtOnOrder.MenuManager = this.RibbonControl;
            this.txtOnOrder.Name = "txtOnOrder";
            this.txtOnOrder.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOnOrder.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtOnOrder.Properties.Appearance.Options.UseBackColor = true;
            this.txtOnOrder.Properties.Appearance.Options.UseForeColor = true;
            this.txtOnOrder.Properties.ReadOnly = true;
            this.txtOnOrder.Size = new System.Drawing.Size(53, 20);
            this.txtOnOrder.StyleController = this.LayoutControl;
            this.txtOnOrder.TabIndex = 10;
            this.txtOnOrder.TabStop = false;
            // 
            // itmOnOrder
            // 
            this.itmOnOrder.Control = this.txtOnOrder;
            this.itmOnOrder.CustomizationFormText = "On Order";
            this.itmOnOrder.Location = new System.Drawing.Point(0, 24);
            this.itmOnOrder.Name = "itmOnOrder";
            this.itmOnOrder.Size = new System.Drawing.Size(200, 24);
            this.itmOnOrder.Text = "On Order";
            this.itmOnOrder.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtOrderPoint
            // 
            this.txtOrderPoint.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OrderPoint", true));
            this.txtOrderPoint.Location = new System.Drawing.Point(553, 187);
            this.txtOrderPoint.MenuManager = this.RibbonControl;
            this.txtOrderPoint.Name = "txtOrderPoint";
            this.txtOrderPoint.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOrderPoint.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtOrderPoint.Properties.Appearance.Options.UseBackColor = true;
            this.txtOrderPoint.Properties.Appearance.Options.UseForeColor = true;
            this.txtOrderPoint.Properties.ReadOnly = true;
            this.txtOrderPoint.Size = new System.Drawing.Size(191, 20);
            this.txtOrderPoint.StyleController = this.LayoutControl;
            this.txtOrderPoint.TabIndex = 11;
            this.txtOrderPoint.TabStop = false;
            // 
            // itmOrderPoint
            // 
            this.itmOrderPoint.Control = this.txtOrderPoint;
            this.itmOrderPoint.CustomizationFormText = "Order Point";
            this.itmOrderPoint.Location = new System.Drawing.Point(0, 144);
            this.itmOrderPoint.Name = "itmOrderPoint";
            this.itmOrderPoint.Size = new System.Drawing.Size(338, 24);
            this.itmOrderPoint.Text = "Order Point";
            this.itmOrderPoint.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtReOrder
            // 
            this.txtReOrder.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OrderAmount", true));
            this.txtReOrder.Location = new System.Drawing.Point(167, 350);
            this.txtReOrder.MenuManager = this.RibbonControl;
            this.txtReOrder.Name = "txtReOrder";
            this.txtReOrder.Size = new System.Drawing.Size(252, 20);
            this.txtReOrder.StyleController = this.LayoutControl;
            this.txtReOrder.TabIndex = 12;
            // 
            // itmReOrder
            // 
            this.itmReOrder.Control = this.txtReOrder;
            this.itmReOrder.CustomizationFormText = "Re Order";
            this.itmReOrder.Location = new System.Drawing.Point(0, 96);
            this.itmReOrder.Name = "itmReOrder";
            this.itmReOrder.Size = new System.Drawing.Size(399, 24);
            this.itmReOrder.Text = "Re Order";
            this.itmReOrder.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage3Month
            // 
            this.txtAverage3Month.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average3Months", true));
            this.txtAverage3Month.Location = new System.Drawing.Point(590, 254);
            this.txtAverage3Month.MenuManager = this.RibbonControl;
            this.txtAverage3Month.Name = "txtAverage3Month";
            this.txtAverage3Month.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage3Month.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage3Month.Properties.ReadOnly = true;
            this.txtAverage3Month.Size = new System.Drawing.Size(123, 20);
            this.txtAverage3Month.StyleController = this.LayoutControl;
            this.txtAverage3Month.TabIndex = 13;
            this.txtAverage3Month.TabStop = false;
            // 
            // itmAverage3Month
            // 
            this.itmAverage3Month.Control = this.txtAverage3Month;
            this.itmAverage3Month.CustomizationFormText = "3 Month Average";
            this.itmAverage3Month.Location = new System.Drawing.Point(0, 0);
            this.itmAverage3Month.Name = "itmAverage3Month";
            this.itmAverage3Month.Size = new System.Drawing.Size(270, 24);
            this.itmAverage3Month.Text = "3 Month Average";
            this.itmAverage3Month.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage6Month
            // 
            this.txtAverage6Month.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average6Months", true));
            this.txtAverage6Month.Location = new System.Drawing.Point(590, 278);
            this.txtAverage6Month.MenuManager = this.RibbonControl;
            this.txtAverage6Month.Name = "txtAverage6Month";
            this.txtAverage6Month.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage6Month.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage6Month.Properties.ReadOnly = true;
            this.txtAverage6Month.Size = new System.Drawing.Size(123, 20);
            this.txtAverage6Month.StyleController = this.LayoutControl;
            this.txtAverage6Month.TabIndex = 14;
            this.txtAverage6Month.TabStop = false;
            // 
            // itmAverage6Month
            // 
            this.itmAverage6Month.Control = this.txtAverage6Month;
            this.itmAverage6Month.CustomizationFormText = "6 Month Average";
            this.itmAverage6Month.Location = new System.Drawing.Point(0, 24);
            this.itmAverage6Month.Name = "itmAverage6Month";
            this.itmAverage6Month.Size = new System.Drawing.Size(270, 24);
            this.itmAverage6Month.Text = "6 Month Average";
            this.itmAverage6Month.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage12Month
            // 
            this.txtAverage12Month.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average12Months", true));
            this.txtAverage12Month.Location = new System.Drawing.Point(590, 302);
            this.txtAverage12Month.MenuManager = this.RibbonControl;
            this.txtAverage12Month.Name = "txtAverage12Month";
            this.txtAverage12Month.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage12Month.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage12Month.Properties.ReadOnly = true;
            this.txtAverage12Month.Size = new System.Drawing.Size(123, 20);
            this.txtAverage12Month.StyleController = this.LayoutControl;
            this.txtAverage12Month.TabIndex = 15;
            this.txtAverage12Month.TabStop = false;
            // 
            // itmAverage12Month
            // 
            this.itmAverage12Month.Control = this.txtAverage12Month;
            this.itmAverage12Month.CustomizationFormText = "12 Month Average";
            this.itmAverage12Month.Location = new System.Drawing.Point(0, 48);
            this.itmAverage12Month.Name = "itmAverage12Month";
            this.itmAverage12Month.Size = new System.Drawing.Size(270, 24);
            this.itmAverage12Month.Text = "12 Month Average";
            this.itmAverage12Month.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txt24MonthAverage
            // 
            this.txt24MonthAverage.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average24Months", true));
            this.txt24MonthAverage.Location = new System.Drawing.Point(590, 326);
            this.txt24MonthAverage.MenuManager = this.RibbonControl;
            this.txt24MonthAverage.Name = "txt24MonthAverage";
            this.txt24MonthAverage.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txt24MonthAverage.Properties.Appearance.Options.UseBackColor = true;
            this.txt24MonthAverage.Properties.ReadOnly = true;
            this.txt24MonthAverage.Size = new System.Drawing.Size(123, 20);
            this.txt24MonthAverage.StyleController = this.LayoutControl;
            this.txt24MonthAverage.TabIndex = 16;
            this.txt24MonthAverage.TabStop = false;
            // 
            // itmAverage24Month
            // 
            this.itmAverage24Month.Control = this.txt24MonthAverage;
            this.itmAverage24Month.CustomizationFormText = "24 Month Average";
            this.itmAverage24Month.Location = new System.Drawing.Point(0, 72);
            this.itmAverage24Month.Name = "itmAverage24Month";
            this.itmAverage24Month.Size = new System.Drawing.Size(270, 24);
            this.itmAverage24Month.Text = "24 Month Average";
            this.itmAverage24Month.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage36Month
            // 
            this.txtAverage36Month.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average36Months", true));
            this.txtAverage36Month.Location = new System.Drawing.Point(590, 350);
            this.txtAverage36Month.MenuManager = this.RibbonControl;
            this.txtAverage36Month.Name = "txtAverage36Month";
            this.txtAverage36Month.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage36Month.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage36Month.Properties.ReadOnly = true;
            this.txtAverage36Month.Size = new System.Drawing.Size(123, 20);
            this.txtAverage36Month.StyleController = this.LayoutControl;
            this.txtAverage36Month.TabIndex = 17;
            this.txtAverage36Month.TabStop = false;
            // 
            // itmAverage36Month
            // 
            this.itmAverage36Month.Control = this.txtAverage36Month;
            this.itmAverage36Month.CustomizationFormText = "36 Month Average";
            this.itmAverage36Month.Location = new System.Drawing.Point(0, 96);
            this.itmAverage36Month.Name = "itmAverage36Month";
            this.itmAverage36Month.Size = new System.Drawing.Size(270, 24);
            this.itmAverage36Month.Text = "36 Month Average";
            this.itmAverage36Month.TextSize = new System.Drawing.Size(139, 13);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(986, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(2, 374);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // BindingSourceHistory
            // 
            this.BindingSourceHistory.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_OrderInventoryHistory);
            // 
            // lcgHoldingInformation
            // 
            this.lcgHoldingInformation.CustomizationFormText = "Holding Information";
            this.lcgHoldingInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmOnHand,
            this.itmMinimumLevel,
            this.itmOnReserve,
            this.itmMaximumLevel,
            this.itmReOrder,
            this.lciMaxOrderLevel,
            this.lciMinOrderLevel,
            this.itmOnOrder});
            this.lcgHoldingInformation.Location = new System.Drawing.Point(0, 211);
            this.lcgHoldingInformation.Name = "lcgHoldingInformation";
            this.lcgHoldingInformation.Size = new System.Drawing.Size(423, 163);
            this.lcgHoldingInformation.Text = "Holding Information";
            // 
            // itmMinimumLevel
            // 
            this.itmMinimumLevel.Control = this.txtMinimumLevel;
            this.itmMinimumLevel.CustomizationFormText = "Minimum Level";
            this.itmMinimumLevel.Location = new System.Drawing.Point(0, 72);
            this.itmMinimumLevel.Name = "itmMinimumLevel";
            this.itmMinimumLevel.Size = new System.Drawing.Size(200, 24);
            this.itmMinimumLevel.Text = "Minimum Level";
            this.itmMinimumLevel.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtMinimumLevel
            // 
            this.txtMinimumLevel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "MinStockLevel", true));
            this.txtMinimumLevel.Location = new System.Drawing.Point(167, 326);
            this.txtMinimumLevel.MenuManager = this.RibbonControl;
            this.txtMinimumLevel.Name = "txtMinimumLevel";
            this.txtMinimumLevel.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMinimumLevel.Properties.Appearance.Options.UseBackColor = true;
            this.txtMinimumLevel.Properties.ReadOnly = true;
            this.txtMinimumLevel.Size = new System.Drawing.Size(53, 20);
            this.txtMinimumLevel.StyleController = this.LayoutControl;
            this.txtMinimumLevel.TabIndex = 19;
            this.txtMinimumLevel.TabStop = false;
            // 
            // itmMaximumLevel
            // 
            this.itmMaximumLevel.Control = this.txtMaximumLevel;
            this.itmMaximumLevel.CustomizationFormText = "Maximum Level";
            this.itmMaximumLevel.Location = new System.Drawing.Point(0, 48);
            this.itmMaximumLevel.Name = "itmMaximumLevel";
            this.itmMaximumLevel.Size = new System.Drawing.Size(200, 24);
            this.itmMaximumLevel.Text = "Maximum Level";
            this.itmMaximumLevel.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtMaximumLevel
            // 
            this.txtMaximumLevel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "MaxStockLevel", true));
            this.txtMaximumLevel.Location = new System.Drawing.Point(167, 302);
            this.txtMaximumLevel.MenuManager = this.RibbonControl;
            this.txtMaximumLevel.Name = "txtMaximumLevel";
            this.txtMaximumLevel.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMaximumLevel.Properties.Appearance.Options.UseBackColor = true;
            this.txtMaximumLevel.Properties.ReadOnly = true;
            this.txtMaximumLevel.Size = new System.Drawing.Size(53, 20);
            this.txtMaximumLevel.StyleController = this.LayoutControl;
            this.txtMaximumLevel.TabIndex = 18;
            this.txtMaximumLevel.TabStop = false;
            // 
            // lciMaxOrderLevel
            // 
            this.lciMaxOrderLevel.Control = this.textEdit1;
            this.lciMaxOrderLevel.CustomizationFormText = "Max Order Level";
            this.lciMaxOrderLevel.Location = new System.Drawing.Point(200, 48);
            this.lciMaxOrderLevel.Name = "lciMaxOrderLevel";
            this.lciMaxOrderLevel.Size = new System.Drawing.Size(199, 24);
            this.lciMaxOrderLevel.Text = "Maximum Order Level";
            this.lciMaxOrderLevel.TextSize = new System.Drawing.Size(139, 13);
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "MaximumOrderLevel", true));
            this.textEdit1.Location = new System.Drawing.Point(367, 302);
            this.textEdit1.MenuManager = this.RibbonControl;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(52, 20);
            this.textEdit1.StyleController = this.LayoutControl;
            this.textEdit1.TabIndex = 39;
            this.textEdit1.TabStop = false;
            // 
            // lciMinOrderLevel
            // 
            this.lciMinOrderLevel.Control = this.textEdit2;
            this.lciMinOrderLevel.CustomizationFormText = "Min Order Level";
            this.lciMinOrderLevel.Location = new System.Drawing.Point(200, 72);
            this.lciMinOrderLevel.Name = "lciMinOrderLevel";
            this.lciMinOrderLevel.Size = new System.Drawing.Size(199, 24);
            this.lciMinOrderLevel.Text = "Minimum Order Level";
            this.lciMinOrderLevel.TextSize = new System.Drawing.Size(139, 13);
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "MinimumOrderLevel", true));
            this.textEdit2.Location = new System.Drawing.Point(367, 326);
            this.textEdit2.MenuManager = this.RibbonControl;
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(52, 20);
            this.textEdit2.StyleController = this.LayoutControl;
            this.textEdit2.TabIndex = 40;
            this.textEdit2.TabStop = false;
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAverage36Month,
            this.itmAverage24Month,
            this.itmAverage12Month,
            this.itmAverage6Month,
            this.itmAverage3Month,
            this.itmAverage3MonthPrev,
            this.itmAverage6MonthPrev,
            this.itmAverage12MonthPrev,
            this.itmAverage24MonthPrev,
            this.itmAverage36MonthPrev});
            this.lcgHistory.Location = new System.Drawing.Point(423, 211);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(563, 163);
            this.lcgHistory.Text = "History";
            // 
            // itmAverage3MonthPrev
            // 
            this.itmAverage3MonthPrev.Control = this.txtAverage3MonthPrev;
            this.itmAverage3MonthPrev.CustomizationFormText = "3 Month Average Prev";
            this.itmAverage3MonthPrev.Location = new System.Drawing.Point(270, 0);
            this.itmAverage3MonthPrev.Name = "itmAverage3MonthPrev";
            this.itmAverage3MonthPrev.Size = new System.Drawing.Size(269, 24);
            this.itmAverage3MonthPrev.Text = "3 Month Average Prev";
            this.itmAverage3MonthPrev.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage3MonthPrev
            // 
            this.txtAverage3MonthPrev.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average3MonthsPrevious", true));
            this.txtAverage3MonthPrev.Location = new System.Drawing.Point(860, 254);
            this.txtAverage3MonthPrev.MenuManager = this.RibbonControl;
            this.txtAverage3MonthPrev.Name = "txtAverage3MonthPrev";
            this.txtAverage3MonthPrev.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage3MonthPrev.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage3MonthPrev.Properties.ReadOnly = true;
            this.txtAverage3MonthPrev.Size = new System.Drawing.Size(122, 20);
            this.txtAverage3MonthPrev.StyleController = this.LayoutControl;
            this.txtAverage3MonthPrev.TabIndex = 33;
            this.txtAverage3MonthPrev.TabStop = false;
            // 
            // itmAverage6MonthPrev
            // 
            this.itmAverage6MonthPrev.Control = this.txtAverage6MonthPrev;
            this.itmAverage6MonthPrev.CustomizationFormText = "6 Month Average Prev";
            this.itmAverage6MonthPrev.Location = new System.Drawing.Point(270, 24);
            this.itmAverage6MonthPrev.Name = "itmAverage6MonthPrev";
            this.itmAverage6MonthPrev.Size = new System.Drawing.Size(269, 24);
            this.itmAverage6MonthPrev.Text = "6 Month Average Prev";
            this.itmAverage6MonthPrev.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage6MonthPrev
            // 
            this.txtAverage6MonthPrev.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average6MonthsPrevious", true));
            this.txtAverage6MonthPrev.Location = new System.Drawing.Point(860, 278);
            this.txtAverage6MonthPrev.MenuManager = this.RibbonControl;
            this.txtAverage6MonthPrev.Name = "txtAverage6MonthPrev";
            this.txtAverage6MonthPrev.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage6MonthPrev.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage6MonthPrev.Properties.ReadOnly = true;
            this.txtAverage6MonthPrev.Size = new System.Drawing.Size(122, 20);
            this.txtAverage6MonthPrev.StyleController = this.LayoutControl;
            this.txtAverage6MonthPrev.TabIndex = 34;
            this.txtAverage6MonthPrev.TabStop = false;
            // 
            // itmAverage12MonthPrev
            // 
            this.itmAverage12MonthPrev.Control = this.txtAverage12MonthPrev;
            this.itmAverage12MonthPrev.CustomizationFormText = "12 Month Average Prev";
            this.itmAverage12MonthPrev.Location = new System.Drawing.Point(270, 48);
            this.itmAverage12MonthPrev.Name = "itmAverage12MonthPrev";
            this.itmAverage12MonthPrev.Size = new System.Drawing.Size(269, 24);
            this.itmAverage12MonthPrev.Text = "12 Month Average Prev";
            this.itmAverage12MonthPrev.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage12MonthPrev
            // 
            this.txtAverage12MonthPrev.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average12MonthsPrevious", true));
            this.txtAverage12MonthPrev.Location = new System.Drawing.Point(860, 302);
            this.txtAverage12MonthPrev.MenuManager = this.RibbonControl;
            this.txtAverage12MonthPrev.Name = "txtAverage12MonthPrev";
            this.txtAverage12MonthPrev.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage12MonthPrev.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage12MonthPrev.Properties.ReadOnly = true;
            this.txtAverage12MonthPrev.Size = new System.Drawing.Size(122, 20);
            this.txtAverage12MonthPrev.StyleController = this.LayoutControl;
            this.txtAverage12MonthPrev.TabIndex = 35;
            this.txtAverage12MonthPrev.TabStop = false;
            // 
            // itmAverage24MonthPrev
            // 
            this.itmAverage24MonthPrev.Control = this.txtAverage24MonthPrev;
            this.itmAverage24MonthPrev.CustomizationFormText = "24 Month Average Prev";
            this.itmAverage24MonthPrev.Location = new System.Drawing.Point(270, 72);
            this.itmAverage24MonthPrev.Name = "itmAverage24MonthPrev";
            this.itmAverage24MonthPrev.Size = new System.Drawing.Size(269, 24);
            this.itmAverage24MonthPrev.Text = "24 Month Average Prev";
            this.itmAverage24MonthPrev.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage24MonthPrev
            // 
            this.txtAverage24MonthPrev.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average24MonthsPrevious", true));
            this.txtAverage24MonthPrev.Location = new System.Drawing.Point(860, 326);
            this.txtAverage24MonthPrev.MenuManager = this.RibbonControl;
            this.txtAverage24MonthPrev.Name = "txtAverage24MonthPrev";
            this.txtAverage24MonthPrev.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage24MonthPrev.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage24MonthPrev.Properties.ReadOnly = true;
            this.txtAverage24MonthPrev.Size = new System.Drawing.Size(122, 20);
            this.txtAverage24MonthPrev.StyleController = this.LayoutControl;
            this.txtAverage24MonthPrev.TabIndex = 36;
            this.txtAverage24MonthPrev.TabStop = false;
            // 
            // itmAverage36MonthPrev
            // 
            this.itmAverage36MonthPrev.Control = this.txtAverage36MonthPrev;
            this.itmAverage36MonthPrev.CustomizationFormText = "36 Month Prev Average Prev";
            this.itmAverage36MonthPrev.Location = new System.Drawing.Point(270, 96);
            this.itmAverage36MonthPrev.Name = "itmAverage36MonthPrev";
            this.itmAverage36MonthPrev.Size = new System.Drawing.Size(269, 24);
            this.itmAverage36MonthPrev.Text = "36 Month Prev Average Prev";
            this.itmAverage36MonthPrev.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtAverage36MonthPrev
            // 
            this.txtAverage36MonthPrev.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Average36MonthsPrevious", true));
            this.txtAverage36MonthPrev.Location = new System.Drawing.Point(860, 350);
            this.txtAverage36MonthPrev.MenuManager = this.RibbonControl;
            this.txtAverage36MonthPrev.Name = "txtAverage36MonthPrev";
            this.txtAverage36MonthPrev.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAverage36MonthPrev.Properties.Appearance.Options.UseBackColor = true;
            this.txtAverage36MonthPrev.Properties.ReadOnly = true;
            this.txtAverage36MonthPrev.Size = new System.Drawing.Size(122, 20);
            this.txtAverage36MonthPrev.StyleController = this.LayoutControl;
            this.txtAverage36MonthPrev.TabIndex = 37;
            this.txtAverage36MonthPrev.TabStop = false;
            // 
            // lcgFinancialFigures
            // 
            this.lcgFinancialFigures.CustomizationFormText = "Financial Figures";
            this.lcgFinancialFigures.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAvgDemand,
            this.itmUnitPrice,
            this.itmEOQ,
            this.itmOrderPoint,
            this.itmUnitReplacement,
            this.itmWarehousingCode,
            this.itmUnitCost});
            this.lcgFinancialFigures.Location = new System.Drawing.Point(386, 0);
            this.lcgFinancialFigures.Name = "lcgFinancialFigures";
            this.lcgFinancialFigures.Size = new System.Drawing.Size(362, 211);
            this.lcgFinancialFigures.Text = "Financial Figures";
            // 
            // itmUnitPrice
            // 
            this.itmUnitPrice.Control = this.txtUnitPrice;
            this.itmUnitPrice.CustomizationFormText = "Unit Price";
            this.itmUnitPrice.Location = new System.Drawing.Point(0, 0);
            this.itmUnitPrice.Name = "itmUnitPrice";
            this.itmUnitPrice.Size = new System.Drawing.Size(338, 24);
            this.itmUnitPrice.Text = "Unit Price";
            this.itmUnitPrice.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "UnitPrice", true));
            this.txtUnitPrice.Location = new System.Drawing.Point(553, 43);
            this.txtUnitPrice.MenuManager = this.RibbonControl;
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUnitPrice.Properties.Appearance.Options.UseBackColor = true;
            this.txtUnitPrice.Properties.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(191, 20);
            this.txtUnitPrice.StyleController = this.LayoutControl;
            this.txtUnitPrice.TabIndex = 30;
            this.txtUnitPrice.TabStop = false;
            // 
            // itmUnitReplacement
            // 
            this.itmUnitReplacement.Control = this.txtUnitReplacement;
            this.itmUnitReplacement.CustomizationFormText = "Unit Replacement";
            this.itmUnitReplacement.Location = new System.Drawing.Point(0, 48);
            this.itmUnitReplacement.Name = "itmUnitReplacement";
            this.itmUnitReplacement.Size = new System.Drawing.Size(338, 24);
            this.itmUnitReplacement.Text = "Unit Replacement";
            this.itmUnitReplacement.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtUnitReplacement
            // 
            this.txtUnitReplacement.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "UnitReplacementCost", true));
            this.txtUnitReplacement.Location = new System.Drawing.Point(553, 91);
            this.txtUnitReplacement.MenuManager = this.RibbonControl;
            this.txtUnitReplacement.Name = "txtUnitReplacement";
            this.txtUnitReplacement.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUnitReplacement.Properties.Appearance.Options.UseBackColor = true;
            this.txtUnitReplacement.Properties.ReadOnly = true;
            this.txtUnitReplacement.Size = new System.Drawing.Size(191, 20);
            this.txtUnitReplacement.StyleController = this.LayoutControl;
            this.txtUnitReplacement.TabIndex = 31;
            this.txtUnitReplacement.TabStop = false;
            // 
            // itmWarehousingCode
            // 
            this.itmWarehousingCode.Control = this.txtWarehousingCode;
            this.itmWarehousingCode.CustomizationFormText = "Warehousing Code";
            this.itmWarehousingCode.Location = new System.Drawing.Point(0, 72);
            this.itmWarehousingCode.Name = "itmWarehousingCode";
            this.itmWarehousingCode.Size = new System.Drawing.Size(338, 24);
            this.itmWarehousingCode.Text = "Warehousing Code";
            this.itmWarehousingCode.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtWarehousingCode
            // 
            this.txtWarehousingCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "WarehousingCost", true));
            this.txtWarehousingCode.Location = new System.Drawing.Point(553, 115);
            this.txtWarehousingCode.MenuManager = this.RibbonControl;
            this.txtWarehousingCode.Name = "txtWarehousingCode";
            this.txtWarehousingCode.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtWarehousingCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtWarehousingCode.Properties.ReadOnly = true;
            this.txtWarehousingCode.Size = new System.Drawing.Size(191, 20);
            this.txtWarehousingCode.StyleController = this.LayoutControl;
            this.txtWarehousingCode.TabIndex = 32;
            this.txtWarehousingCode.TabStop = false;
            // 
            // itmUnitCost
            // 
            this.itmUnitCost.Control = this.txtUnitCost;
            this.itmUnitCost.CustomizationFormText = "Unit Cost";
            this.itmUnitCost.Location = new System.Drawing.Point(0, 24);
            this.itmUnitCost.Name = "itmUnitCost";
            this.itmUnitCost.Size = new System.Drawing.Size(338, 24);
            this.itmUnitCost.Text = "Unit Cost";
            this.itmUnitCost.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "UnitCost", true));
            this.txtUnitCost.Location = new System.Drawing.Point(553, 67);
            this.txtUnitCost.MenuManager = this.RibbonControl;
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUnitCost.Properties.Appearance.Options.UseBackColor = true;
            this.txtUnitCost.Properties.ReadOnly = true;
            this.txtUnitCost.Size = new System.Drawing.Size(191, 20);
            this.txtUnitCost.StyleController = this.LayoutControl;
            this.txtUnitCost.TabIndex = 38;
            this.txtUnitCost.TabStop = false;
            // 
            // lcgIdentity
            // 
            this.lcgIdentity.CustomizationFormText = "Identity";
            this.lcgIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCode,
            this.itmName,
            this.itmCategory,
            this.itmSubCategory,
            this.itmLocation,
            this.itmStockType,
            this.itmSafetyStock});
            this.lcgIdentity.Location = new System.Drawing.Point(0, 0);
            this.lcgIdentity.Name = "lcgIdentity";
            this.lcgIdentity.Size = new System.Drawing.Size(386, 211);
            this.lcgIdentity.Text = "Identity";
            // 
            // itmCategory
            // 
            this.itmCategory.Control = this.txtCategory;
            this.itmCategory.CustomizationFormText = "Category";
            this.itmCategory.Location = new System.Drawing.Point(0, 48);
            this.itmCategory.Name = "itmCategory";
            this.itmCategory.Size = new System.Drawing.Size(362, 24);
            this.itmCategory.Text = "Category";
            this.itmCategory.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtCategory
            // 
            this.txtCategory.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "Category", true));
            this.txtCategory.Location = new System.Drawing.Point(167, 91);
            this.txtCategory.MenuManager = this.RibbonControl;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCategory.Properties.Appearance.Options.UseBackColor = true;
            this.txtCategory.Properties.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(215, 20);
            this.txtCategory.StyleController = this.LayoutControl;
            this.txtCategory.TabIndex = 20;
            this.txtCategory.TabStop = false;
            // 
            // itmSubCategory
            // 
            this.itmSubCategory.Control = this.txtSubCategory;
            this.itmSubCategory.CustomizationFormText = "Sub Category";
            this.itmSubCategory.Location = new System.Drawing.Point(0, 72);
            this.itmSubCategory.Name = "itmSubCategory";
            this.itmSubCategory.Size = new System.Drawing.Size(362, 24);
            this.itmSubCategory.Text = "Sub Category";
            this.itmSubCategory.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(167, 115);
            this.txtSubCategory.MenuManager = this.RibbonControl;
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSubCategory.Properties.Appearance.Options.UseBackColor = true;
            this.txtSubCategory.Properties.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(215, 20);
            this.txtSubCategory.StyleController = this.LayoutControl;
            this.txtSubCategory.TabIndex = 21;
            this.txtSubCategory.TabStop = false;
            // 
            // itmLocation
            // 
            this.itmLocation.Control = this.txtLocation;
            this.itmLocation.CustomizationFormText = "Location";
            this.itmLocation.Location = new System.Drawing.Point(0, 96);
            this.itmLocation.Name = "itmLocation";
            this.itmLocation.Size = new System.Drawing.Size(362, 24);
            this.itmLocation.Text = "Location";
            this.itmLocation.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtLocation
            // 
            this.txtLocation.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "LocationMain", true));
            this.txtLocation.Location = new System.Drawing.Point(167, 139);
            this.txtLocation.MenuManager = this.RibbonControl;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtLocation.Properties.Appearance.Options.UseBackColor = true;
            this.txtLocation.Properties.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(215, 20);
            this.txtLocation.StyleController = this.LayoutControl;
            this.txtLocation.TabIndex = 22;
            this.txtLocation.TabStop = false;
            // 
            // itmStockType
            // 
            this.itmStockType.Control = this.txtStockType;
            this.itmStockType.CustomizationFormText = "Stock Type";
            this.itmStockType.Location = new System.Drawing.Point(0, 120);
            this.itmStockType.Name = "itmStockType";
            this.itmStockType.Size = new System.Drawing.Size(362, 24);
            this.itmStockType.Text = "Stock Type";
            this.itmStockType.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtStockType
            // 
            this.txtStockType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "StockType", true));
            this.txtStockType.Location = new System.Drawing.Point(167, 163);
            this.txtStockType.MenuManager = this.RibbonControl;
            this.txtStockType.Name = "txtStockType";
            this.txtStockType.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtStockType.Properties.Appearance.Options.UseBackColor = true;
            this.txtStockType.Properties.ReadOnly = true;
            this.txtStockType.Size = new System.Drawing.Size(215, 20);
            this.txtStockType.StyleController = this.LayoutControl;
            this.txtStockType.TabIndex = 23;
            this.txtStockType.TabStop = false;
            // 
            // itmSafetyStock
            // 
            this.itmSafetyStock.Control = this.txtSafetyStock;
            this.itmSafetyStock.CustomizationFormText = "Safety Stock (weeks)";
            this.itmSafetyStock.Location = new System.Drawing.Point(0, 144);
            this.itmSafetyStock.Name = "itmSafetyStock";
            this.itmSafetyStock.Size = new System.Drawing.Size(362, 24);
            this.itmSafetyStock.Text = "Safety Stock (weeks)";
            this.itmSafetyStock.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtSafetyStock
            // 
            this.txtSafetyStock.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "SafetyStock", true));
            this.txtSafetyStock.Location = new System.Drawing.Point(167, 187);
            this.txtSafetyStock.MenuManager = this.RibbonControl;
            this.txtSafetyStock.Name = "txtSafetyStock";
            this.txtSafetyStock.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSafetyStock.Properties.Appearance.Options.UseBackColor = true;
            this.txtSafetyStock.Properties.ReadOnly = true;
            this.txtSafetyStock.Size = new System.Drawing.Size(215, 20);
            this.txtSafetyStock.StyleController = this.LayoutControl;
            this.txtSafetyStock.TabIndex = 24;
            this.txtSafetyStock.TabStop = false;
            // 
            // textEdit6
            // 
            this.textEdit6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "MaximumOrderLevel", true));
            this.textEdit6.Location = new System.Drawing.Point(915, 139);
            this.textEdit6.MenuManager = this.RibbonControl;
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.textEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit6.Properties.ReadOnly = true;
            this.textEdit6.Size = new System.Drawing.Size(67, 20);
            this.textEdit6.StyleController = this.LayoutControl;
            this.textEdit6.TabIndex = 25;
            this.textEdit6.TabStop = false;
            // 
            // itmMaximumOrderSize
            // 
            this.itmMaximumOrderSize.Control = this.textEdit6;
            this.itmMaximumOrderSize.CustomizationFormText = "Maximum Order Size";
            this.itmMaximumOrderSize.Location = new System.Drawing.Point(0, 96);
            this.itmMaximumOrderSize.Name = "itmMaximumOrderSize";
            this.itmMaximumOrderSize.Size = new System.Drawing.Size(214, 72);
            this.itmMaximumOrderSize.Text = "Maximum Order Size";
            this.itmMaximumOrderSize.TextSize = new System.Drawing.Size(139, 13);
            // 
            // lcgPrimarySupplier
            // 
            this.lcgPrimarySupplier.CustomizationFormText = "Primary Supplier";
            this.lcgPrimarySupplier.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmMaximumOrderSize,
            this.itmMinimumOrderSize,
            this.itmPackSize,
            this.itmOrderLeadTime,
            this.itmCompany});
            this.lcgPrimarySupplier.Location = new System.Drawing.Point(748, 0);
            this.lcgPrimarySupplier.Name = "lcgPrimarySupplier";
            this.lcgPrimarySupplier.Size = new System.Drawing.Size(238, 211);
            this.lcgPrimarySupplier.Text = "Primary Supplier";
            // 
            // itmMinimumOrderSize
            // 
            this.itmMinimumOrderSize.Control = this.txtMinimumOrderSize;
            this.itmMinimumOrderSize.CustomizationFormText = "Minimum Order Size";
            this.itmMinimumOrderSize.Location = new System.Drawing.Point(0, 72);
            this.itmMinimumOrderSize.Name = "itmMinimumOrderSize";
            this.itmMinimumOrderSize.Size = new System.Drawing.Size(214, 24);
            this.itmMinimumOrderSize.Text = "Minimum Order Size";
            this.itmMinimumOrderSize.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtMinimumOrderSize
            // 
            this.txtMinimumOrderSize.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "MinimumOrderLevel", true));
            this.txtMinimumOrderSize.Location = new System.Drawing.Point(915, 115);
            this.txtMinimumOrderSize.MenuManager = this.RibbonControl;
            this.txtMinimumOrderSize.Name = "txtMinimumOrderSize";
            this.txtMinimumOrderSize.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMinimumOrderSize.Properties.Appearance.Options.UseBackColor = true;
            this.txtMinimumOrderSize.Properties.ReadOnly = true;
            this.txtMinimumOrderSize.Size = new System.Drawing.Size(67, 20);
            this.txtMinimumOrderSize.StyleController = this.LayoutControl;
            this.txtMinimumOrderSize.TabIndex = 26;
            this.txtMinimumOrderSize.TabStop = false;
            // 
            // itmPackSize
            // 
            this.itmPackSize.Control = this.txtPackSize;
            this.itmPackSize.CustomizationFormText = "Pack Size (Quantity)";
            this.itmPackSize.Location = new System.Drawing.Point(0, 48);
            this.itmPackSize.Name = "itmPackSize";
            this.itmPackSize.Size = new System.Drawing.Size(214, 24);
            this.itmPackSize.Text = "Pack Size (Quantity)";
            this.itmPackSize.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtPackSize
            // 
            this.txtPackSize.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "PackSize", true));
            this.txtPackSize.Location = new System.Drawing.Point(915, 91);
            this.txtPackSize.MenuManager = this.RibbonControl;
            this.txtPackSize.Name = "txtPackSize";
            this.txtPackSize.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPackSize.Properties.Appearance.Options.UseBackColor = true;
            this.txtPackSize.Properties.ReadOnly = true;
            this.txtPackSize.Size = new System.Drawing.Size(67, 20);
            this.txtPackSize.StyleController = this.LayoutControl;
            this.txtPackSize.TabIndex = 27;
            this.txtPackSize.TabStop = false;
            // 
            // itmOrderLeadTime
            // 
            this.itmOrderLeadTime.Control = this.txtOrderLeadTime;
            this.itmOrderLeadTime.CustomizationFormText = "Order Lead Time (days)";
            this.itmOrderLeadTime.Location = new System.Drawing.Point(0, 24);
            this.itmOrderLeadTime.Name = "itmOrderLeadTime";
            this.itmOrderLeadTime.Size = new System.Drawing.Size(214, 24);
            this.itmOrderLeadTime.Text = "Order Lead Time (days)";
            this.itmOrderLeadTime.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtOrderLeadTime
            // 
            this.txtOrderLeadTime.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceHistory, "OrderLeadTime", true));
            this.txtOrderLeadTime.Location = new System.Drawing.Point(915, 67);
            this.txtOrderLeadTime.MenuManager = this.RibbonControl;
            this.txtOrderLeadTime.Name = "txtOrderLeadTime";
            this.txtOrderLeadTime.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtOrderLeadTime.Properties.Appearance.Options.UseBackColor = true;
            this.txtOrderLeadTime.Properties.ReadOnly = true;
            this.txtOrderLeadTime.Size = new System.Drawing.Size(67, 20);
            this.txtOrderLeadTime.StyleController = this.LayoutControl;
            this.txtOrderLeadTime.TabIndex = 28;
            this.txtOrderLeadTime.TabStop = false;
            // 
            // itmCompany
            // 
            this.itmCompany.Control = this.txtCompany;
            this.itmCompany.CustomizationFormText = "Company";
            this.itmCompany.Location = new System.Drawing.Point(0, 0);
            this.itmCompany.Name = "itmCompany";
            this.itmCompany.Size = new System.Drawing.Size(214, 24);
            this.itmCompany.Text = "Company";
            this.itmCompany.TextSize = new System.Drawing.Size(139, 13);
            // 
            // txtCompany
            // 
            this.txtCompany.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Supplier", true));
            this.txtCompany.Location = new System.Drawing.Point(915, 43);
            this.txtCompany.MenuManager = this.RibbonControl;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCompany.Properties.Appearance.Options.UseBackColor = true;
            this.txtCompany.Properties.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(67, 20);
            this.txtCompany.StyleController = this.LayoutControl;
            this.txtCompany.TabIndex = 29;
            this.txtCompany.TabStop = false;
            // 
            // AutomaticOrderingDetailForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.Name = "AutomaticOrderingDetailForm";
            this.Text = "Order Item Detail";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLinkedBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvgDemand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAvgDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEOQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEOQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnHand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOnHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnReserve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOnReserve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderPoint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOrderPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage3Month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage3Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage6Month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage6Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage12Month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage12Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt24MonthAverage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage24Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage36Month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage36Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHoldingInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMinimumLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimumLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMaximumLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximumLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaxOrderLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMinOrderLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage3MonthPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage3MonthPrev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage6MonthPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage6MonthPrev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage12MonthPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage12MonthPrev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage24MonthPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage24MonthPrev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAverage36MonthPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage36MonthPrev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFinancialFigures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUnitReplacement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitReplacement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmWarehousingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehousingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSubCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStockType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSafetyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSafetyStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMaximumOrderSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrimarySupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMinimumOrderSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimumOrderSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPackSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOrderLeadTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderLeadTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.TabbedControlGroup tcgDetail;
        private DevExpress.XtraLayout.LayoutControlGroup tabHistory;
        private DevExpress.XtraLayout.LayoutControlGroup tabLinkedBranches;
        private Essential.UTL.CustomGridControl grdHistory;
        private Essential.UTL.CustomGridView grvHistory;
        private DevExpress.XtraLayout.LayoutControlItem itmGridHistory;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceSalesHistory;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryFinancialYear;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryMovement;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryOnHand;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryOnReserve;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryOnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryUnitAverage;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryFirstSold;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryFirstPurchased;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryLastSold;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryLastPurchased;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryLastMovement;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoryModifiedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colHistorySales12;
        private DevExpress.XtraGrid.Columns.GridColumn colHistorySales6;
        private DevExpress.XtraGrid.Columns.GridColumn colHistorySales3;
        private DevExpress.XtraEditors.TextEdit txtEOQ;
        private DevExpress.XtraEditors.TextEdit txtAvgDemand;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem itmCode;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlItem itmAvgDemand;
        private DevExpress.XtraLayout.LayoutControlItem itmEOQ;
        private DevExpress.XtraEditors.TextEdit txtOrderPoint;
        private DevExpress.XtraEditors.TextEdit txtOnOrder;
        private DevExpress.XtraEditors.TextEdit txtOnReserve;
        private DevExpress.XtraEditors.TextEdit txtOnHand;
        private DevExpress.XtraLayout.LayoutControlItem itmOnHand;
        private DevExpress.XtraLayout.LayoutControlItem itmOnReserve;
        private DevExpress.XtraLayout.LayoutControlItem itmOrderPoint;
        private DevExpress.XtraLayout.LayoutControlItem itmOnOrder;
        private DevExpress.XtraEditors.TextEdit txtReOrder;
        private DevExpress.XtraLayout.LayoutControlItem itmReOrder;
        private DevExpress.XtraEditors.TextEdit txtAverage36Month;
        private DevExpress.XtraEditors.TextEdit txt24MonthAverage;
        private DevExpress.XtraEditors.TextEdit txtAverage12Month;
        private DevExpress.XtraEditors.TextEdit txtAverage6Month;
        private DevExpress.XtraEditors.TextEdit txtAverage3Month;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage3Month;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage6Month;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage12Month;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage24Month;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage36Month;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.TextEdit txtWarehousingCode;
        private System.Windows.Forms.BindingSource BindingSourceHistory;
        private DevExpress.XtraEditors.TextEdit txtUnitReplacement;
        private DevExpress.XtraEditors.TextEdit txtUnitPrice;
        private DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.TextEdit txtOrderLeadTime;
        private DevExpress.XtraEditors.TextEdit txtPackSize;
        private DevExpress.XtraEditors.TextEdit txtMinimumOrderSize;
        private DevExpress.XtraEditors.TextEdit textEdit6;
        private DevExpress.XtraEditors.TextEdit txtSafetyStock;
        private DevExpress.XtraEditors.TextEdit txtStockType;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.TextEdit txtSubCategory;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private DevExpress.XtraEditors.TextEdit txtMinimumLevel;
        private DevExpress.XtraEditors.TextEdit txtMaximumLevel;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHoldingInformation;
        private DevExpress.XtraLayout.LayoutControlItem itmMaximumLevel;
        private DevExpress.XtraLayout.LayoutControlItem itmMinimumLevel;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIdentity;
        private DevExpress.XtraLayout.LayoutControlItem itmCategory;
        private DevExpress.XtraLayout.LayoutControlItem itmSubCategory;
        private DevExpress.XtraLayout.LayoutControlItem itmLocation;
        private DevExpress.XtraLayout.LayoutControlItem itmStockType;
        private DevExpress.XtraLayout.LayoutControlItem itmSafetyStock;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPrimarySupplier;
        private DevExpress.XtraLayout.LayoutControlItem itmMaximumOrderSize;
        private DevExpress.XtraLayout.LayoutControlItem itmMinimumOrderSize;
        private DevExpress.XtraLayout.LayoutControlItem itmPackSize;
        private DevExpress.XtraLayout.LayoutControlItem itmOrderLeadTime;
        private DevExpress.XtraLayout.LayoutControlItem itmCompany;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFinancialFigures;
        private DevExpress.XtraLayout.LayoutControlItem itmUnitPrice;
        private DevExpress.XtraLayout.LayoutControlItem itmUnitReplacement;
        private DevExpress.XtraLayout.LayoutControlItem itmWarehousingCode;
        private DevExpress.XtraEditors.TextEdit txtAverage36MonthPrev;
        private DevExpress.XtraEditors.TextEdit txtAverage24MonthPrev;
        private DevExpress.XtraEditors.TextEdit txtAverage12MonthPrev;
        private DevExpress.XtraEditors.TextEdit txtAverage6MonthPrev;
        private DevExpress.XtraEditors.TextEdit txtAverage3MonthPrev;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage3MonthPrev;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage6MonthPrev;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage12MonthPrev;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage24MonthPrev;
        private DevExpress.XtraLayout.LayoutControlItem itmAverage36MonthPrev;
        private DevExpress.XtraEditors.TextEdit txtUnitCost;
        private DevExpress.XtraLayout.LayoutControlItem itmUnitCost;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem lciMaxOrderLevel;
        private DevExpress.XtraLayout.LayoutControlItem lciMinOrderLevel;
    }
}
