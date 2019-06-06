namespace CDS.Client.Desktop.Stock.Inventory
{
    partial class StockTakeForm
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
            this.wizStockTake = new DevExpress.XtraWizard.WizardControl();
            this.wizStockTakeWelcome = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizStockTakeStart = new DevExpress.XtraWizard.WizardPage();
            this.grdStockTakeItems = new DevExpress.XtraGrid.GridControl();
            this.InstantFeedbackSourceInventory = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.grvStockTakeItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationSecondary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wizStockTakeCompleted = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizStockTakeQuantities = new DevExpress.XtraWizard.WizardPage();
            this.grdStockTakeQuantity = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceStockTakeItem = new System.Windows.Forms.BindingSource(this.components);
            this.grvStockTakeQuantity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInventoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repInventory2 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.InstantFeedbackSourceRepositoryInventory = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPageNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityCount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityCount2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuccessfullyChanged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repInventory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.wizStockTakeVariance = new DevExpress.XtraWizard.WizardPage();
            this.grdStockTakeVariance = new CDS.Client.Desktop.Essential.UTL.CustomGridControl();
            this.ServerModeSourceVariance = new DevExpress.Data.Linq.LinqServerModeSource();
            this.grvStockTakeVariance = new CDS.Client.Desktop.Essential.UTL.CustomGridView();
            this.colVarianceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceUnitAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceSubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceLocationMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceLocationSecondary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceStockType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceQuantityCount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceQuantityCount2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceVarianceCount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceVarianceCount2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceTotalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarianceVarianceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wizStockTakeSummary = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdStockTakeVarianceSummary = new DevExpress.XtraGrid.GridControl();
            this.InstantFeedbackSourceVariance = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.grvStockTakeVarianceSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStockTakeVarianceSummary = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmStockTakeWizard = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnPrintCountSheet = new DevExpress.XtraBars.BarButtonItem();
            this.popPrint = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnSecondCount = new DevExpress.XtraBars.BarButtonItem();
            this.rpStockTake = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpStockTakePrint = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizStockTake)).BeginInit();
            this.wizStockTake.SuspendLayout();
            this.wizStockTakeStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeItems)).BeginInit();
            this.wizStockTakeQuantities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceStockTakeItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repInventory2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repInventory)).BeginInit();
            this.wizStockTakeVariance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeVariance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceVariance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeVariance)).BeginInit();
            this.wizStockTakeSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeVarianceSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeVarianceSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStockTakeVarianceSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStockTakeWizard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ITM_StockTake);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.wizStockTake);
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
            this.LayoutControl.Size = new System.Drawing.Size(790, 421);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmStockTakeWizard});
            this.LayoutGroup.Size = new System.Drawing.Size(790, 421);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrintCountSheet,
            this.btnSecondCount});
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpStockTake});
            this.RibbonControl.Size = new System.Drawing.Size(790, 147);
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
            // wizStockTake
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.wizStockTake, DevExpress.Utils.DefaultBoolean.Default);
            this.wizStockTake.Controls.Add(this.wizStockTakeWelcome);
            this.wizStockTake.Controls.Add(this.wizStockTakeStart);
            this.wizStockTake.Controls.Add(this.wizStockTakeCompleted);
            this.wizStockTake.Controls.Add(this.wizStockTakeQuantities);
            this.wizStockTake.Controls.Add(this.wizStockTakeVariance);
            this.wizStockTake.Controls.Add(this.wizStockTakeSummary);
            this.wizStockTake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizStockTake.Location = new System.Drawing.Point(12, 12);
            this.wizStockTake.LookAndFeel.SkinName = "Office 2013";
            this.wizStockTake.Name = "wizStockTake";
            this.wizStockTake.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wizStockTakeWelcome,
            this.wizStockTakeStart,
            this.wizStockTakeQuantities,
            this.wizStockTakeVariance,
            this.wizStockTakeSummary,
            this.wizStockTakeCompleted});
            this.wizStockTake.Size = new System.Drawing.Size(766, 397);
            this.wizStockTake.SelectedPageChanged += new DevExpress.XtraWizard.WizardPageChangedEventHandler(this.wizStockTake_SelectedPageChanged);
            this.wizStockTake.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizStockTake_CancelClick);
            this.wizStockTake.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizStockTake_FinishClick);
            this.wizStockTake.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizStockTake_NextClick);
            this.wizStockTake.PrevClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizStockTake_PrevClick);
            // 
            // wizStockTakeWelcome
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.wizStockTakeWelcome, DevExpress.Utils.DefaultBoolean.Default);
            this.wizStockTakeWelcome.IntroductionText = "This wizard simplifies the stock take process by guiding you through a series of " +
    "simple steps";
            this.wizStockTakeWelcome.Name = "wizStockTakeWelcome";
            this.wizStockTakeWelcome.Size = new System.Drawing.Size(549, 265);
            // 
            // wizStockTakeStart
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.wizStockTakeStart, DevExpress.Utils.DefaultBoolean.Default);
            this.wizStockTakeStart.Controls.Add(this.grdStockTakeItems);
            this.wizStockTakeStart.DescriptionText = "Below you can filter and sort the items you want on the stock take";
            this.wizStockTakeStart.Name = "wizStockTakeStart";
            this.wizStockTakeStart.Size = new System.Drawing.Size(734, 254);
            this.wizStockTakeStart.Text = "Start Stock Take";
            // 
            // grdStockTakeItems
            // 
            this.grdStockTakeItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdStockTakeItems.DataSource = this.InstantFeedbackSourceInventory;
            this.grdStockTakeItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockTakeItems.Location = new System.Drawing.Point(0, 0);
            this.grdStockTakeItems.MainView = this.grvStockTakeItems;
            this.grdStockTakeItems.MenuManager = this.RibbonControl;
            this.grdStockTakeItems.Name = "grdStockTakeItems";
            this.grdStockTakeItems.Size = new System.Drawing.Size(734, 254);
            this.grdStockTakeItems.TabIndex = 0;
            this.grdStockTakeItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockTakeItems});
            // 
            // InstantFeedbackSourceInventory
            // 
            this.InstantFeedbackSourceInventory.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Inventory);
            this.InstantFeedbackSourceInventory.KeyExpression = "Id";
            this.InstantFeedbackSourceInventory.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceInventory_GetQueryable);
            // 
            // grvStockTakeItems
            // 
            this.grvStockTakeItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colDescription,
            this.colCategory,
            this.colSubCategory,
            this.colStockType,
            this.colLocationMain,
            this.colLocationSecondary,
            this.colOnHand});
            this.grvStockTakeItems.GridControl = this.grdStockTakeItems;
            this.grvStockTakeItems.Name = "grvStockTakeItems";
            this.grvStockTakeItems.OptionsView.ShowAutoFilterRow = true;
            this.grvStockTakeItems.OptionsView.ShowFooter = true;
            this.grvStockTakeItems.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "Name";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "ShortName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowEdit = false;
            this.colCategory.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCategory.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 3;
            // 
            // colSubCategory
            // 
            this.colSubCategory.FieldName = "SubCategory";
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.OptionsColumn.AllowEdit = false;
            this.colSubCategory.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSubCategory.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSubCategory.Visible = true;
            this.colSubCategory.VisibleIndex = 4;
            // 
            // colStockType
            // 
            this.colStockType.FieldName = "StockType";
            this.colStockType.Name = "colStockType";
            this.colStockType.OptionsColumn.AllowEdit = false;
            this.colStockType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colStockType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colStockType.Visible = true;
            this.colStockType.VisibleIndex = 5;
            // 
            // colLocationMain
            // 
            this.colLocationMain.FieldName = "LocationMain";
            this.colLocationMain.Name = "colLocationMain";
            this.colLocationMain.OptionsColumn.AllowEdit = false;
            this.colLocationMain.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colLocationMain.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLocationMain.Visible = true;
            this.colLocationMain.VisibleIndex = 6;
            // 
            // colLocationSecondary
            // 
            this.colLocationSecondary.FieldName = "LocationSecondary";
            this.colLocationSecondary.Name = "colLocationSecondary";
            this.colLocationSecondary.OptionsColumn.AllowEdit = false;
            this.colLocationSecondary.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colLocationSecondary.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLocationSecondary.Visible = true;
            this.colLocationSecondary.VisibleIndex = 7;
            // 
            // colOnHand
            // 
            this.colOnHand.FieldName = "OnHand";
            this.colOnHand.Name = "colOnHand";
            this.colOnHand.OptionsColumn.AllowEdit = false;
            this.colOnHand.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colOnHand.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colOnHand.Visible = true;
            this.colOnHand.VisibleIndex = 8;
            // 
            // wizStockTakeCompleted
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.wizStockTakeCompleted, DevExpress.Utils.DefaultBoolean.Default);
            this.wizStockTakeCompleted.FinishText = "You have successfully completed the stock take.";
            this.wizStockTakeCompleted.Name = "wizStockTakeCompleted";
            this.wizStockTakeCompleted.Size = new System.Drawing.Size(549, 265);
            // 
            // wizStockTakeQuantities
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.wizStockTakeQuantities, DevExpress.Utils.DefaultBoolean.Default);
            this.wizStockTakeQuantities.Controls.Add(this.grdStockTakeQuantity);
            this.wizStockTakeQuantities.DescriptionText = "Below you can enter the counted quantities";
            this.wizStockTakeQuantities.Name = "wizStockTakeQuantities";
            this.wizStockTakeQuantities.Size = new System.Drawing.Size(734, 254);
            this.wizStockTakeQuantities.Text = "Enter quantities";
            // 
            // grdStockTakeQuantity
            // 
            this.grdStockTakeQuantity.DataSource = this.BindingSourceStockTakeItem;
            this.grdStockTakeQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockTakeQuantity.Location = new System.Drawing.Point(0, 0);
            this.grdStockTakeQuantity.MainView = this.grvStockTakeQuantity;
            this.grdStockTakeQuantity.MenuManager = this.RibbonControl;
            this.grdStockTakeQuantity.Name = "grdStockTakeQuantity";
            this.grdStockTakeQuantity.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repInventory,
            this.repInventory2});
            this.grdStockTakeQuantity.Size = new System.Drawing.Size(734, 254);
            this.grdStockTakeQuantity.TabIndex = 0;
            this.grdStockTakeQuantity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockTakeQuantity});
            // 
            // BindingSourceStockTakeItem
            // 
            this.BindingSourceStockTakeItem.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ITM_StockTakeItem);
            // 
            // grvStockTakeQuantity
            // 
            this.grvStockTakeQuantity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInventoryId,
            this.colLineNumber,
            this.colPageNumber,
            this.colOnHand1,
            this.colQuantityCount1,
            this.colQuantityCount2,
            this.colUnitPrice,
            this.colUnitCost,
            this.colUnitAverage,
            this.colSuccessfullyChanged});
            this.grvStockTakeQuantity.GridControl = this.grdStockTakeQuantity;
            this.grvStockTakeQuantity.Name = "grvStockTakeQuantity";
            this.grvStockTakeQuantity.OptionsView.ShowAutoFilterRow = true;
            this.grvStockTakeQuantity.OptionsView.ShowFooter = true;
            this.grvStockTakeQuantity.OptionsView.ShowGroupPanel = false;
            // 
            // colInventoryId
            // 
            this.colInventoryId.Caption = "Code";
            this.colInventoryId.ColumnEdit = this.repInventory2;
            this.colInventoryId.CustomizationCaption = "Code";
            this.colInventoryId.FieldName = "InventoryId";
            this.colInventoryId.Name = "colInventoryId";
            this.colInventoryId.OptionsColumn.AllowEdit = false;
            this.colInventoryId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInventoryId.Visible = true;
            this.colInventoryId.VisibleIndex = 0;
            // 
            // repInventory2
            // 
            this.repInventory2.AutoHeight = false;
            this.repInventory2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repInventory2.DataSource = this.InstantFeedbackSourceRepositoryInventory;
            this.repInventory2.DisplayMember = "Name";
            this.repInventory2.Name = "repInventory2";
            this.repInventory2.ValueMember = "EntityId";
            this.repInventory2.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // InstantFeedbackSourceRepositoryInventory
            // 
            this.InstantFeedbackSourceRepositoryInventory.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Inventory);
            this.InstantFeedbackSourceRepositoryInventory.KeyExpression = "Id";
            this.InstantFeedbackSourceRepositoryInventory.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceRepositoryInventory_GetQueryable);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colLineNumber
            // 
            this.colLineNumber.FieldName = "LineNumber";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.OptionsColumn.AllowEdit = false;
            this.colLineNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colPageNumber
            // 
            this.colPageNumber.FieldName = "PageNumber";
            this.colPageNumber.Name = "colPageNumber";
            this.colPageNumber.OptionsColumn.AllowEdit = false;
            this.colPageNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPageNumber.Visible = true;
            this.colPageNumber.VisibleIndex = 1;
            // 
            // colOnHand1
            // 
            this.colOnHand1.FieldName = "OnHand";
            this.colOnHand1.Name = "colOnHand1";
            this.colOnHand1.OptionsColumn.AllowEdit = false;
            this.colOnHand1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOnHand1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colOnHand1.Visible = true;
            this.colOnHand1.VisibleIndex = 2;
            // 
            // colQuantityCount1
            // 
            this.colQuantityCount1.FieldName = "QuantityCount1";
            this.colQuantityCount1.Name = "colQuantityCount1";
            this.colQuantityCount1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantityCount1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colQuantityCount1.Visible = true;
            this.colQuantityCount1.VisibleIndex = 3;
            // 
            // colQuantityCount2
            // 
            this.colQuantityCount2.FieldName = "QuantityCount2";
            this.colQuantityCount2.Name = "colQuantityCount2";
            this.colQuantityCount2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantityCount2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colQuantityCount2.Visible = true;
            this.colQuantityCount2.VisibleIndex = 4;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowEdit = false;
            this.colUnitPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colUnitCost
            // 
            this.colUnitCost.FieldName = "UnitCost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.OptionsColumn.AllowEdit = false;
            this.colUnitCost.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colUnitAverage
            // 
            this.colUnitAverage.FieldName = "UnitAverage";
            this.colUnitAverage.Name = "colUnitAverage";
            this.colUnitAverage.OptionsColumn.AllowEdit = false;
            this.colUnitAverage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colSuccessfullyChanged
            // 
            this.colSuccessfullyChanged.FieldName = "SuccessfullyChanged";
            this.colSuccessfullyChanged.Name = "colSuccessfullyChanged";
            this.colSuccessfullyChanged.OptionsColumn.AllowEdit = false;
            this.colSuccessfullyChanged.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repInventory
            // 
            this.repInventory.AutoHeight = false;
            this.repInventory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repInventory.Name = "repInventory";
            // 
            // wizStockTakeVariance
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.wizStockTakeVariance, DevExpress.Utils.DefaultBoolean.Default);
            this.wizStockTakeVariance.Controls.Add(this.grdStockTakeVariance);
            this.wizStockTakeVariance.DescriptionText = "Below shows you a detail stock variance";
            this.wizStockTakeVariance.Name = "wizStockTakeVariance";
            this.wizStockTakeVariance.Size = new System.Drawing.Size(734, 254);
            this.wizStockTakeVariance.Text = "Stock Variance";
            // 
            // grdStockTakeVariance
            // 
            this.grdStockTakeVariance.DataSource = this.ServerModeSourceVariance;
            this.grdStockTakeVariance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockTakeVariance.Location = new System.Drawing.Point(0, 0);
            this.grdStockTakeVariance.MainView = this.grvStockTakeVariance;
            this.grdStockTakeVariance.MenuManager = this.RibbonControl;
            this.grdStockTakeVariance.Name = "grdStockTakeVariance";
            this.grdStockTakeVariance.Size = new System.Drawing.Size(734, 254);
            this.grdStockTakeVariance.TabIndex = 0;
            this.grdStockTakeVariance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockTakeVariance});
            // 
            // ServerModeSourceVariance
            // 
            this.ServerModeSourceVariance.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_StockTakeVariance);
            this.ServerModeSourceVariance.KeyExpression = "Id";
            // 
            // grvStockTakeVariance
            // 
            this.grvStockTakeVariance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVarianceCode,
            this.colVarianceName,
            this.colVarianceOnHand,
            this.colVarianceUnitAverage,
            this.colVarianceCategory,
            this.colVarianceSubCategory,
            this.colVarianceLocationMain,
            this.colVarianceLocationSecondary,
            this.colVarianceStockType,
            this.colVarianceQuantityCount1,
            this.colVarianceQuantityCount2,
            this.colVarianceVarianceCount1,
            this.colVarianceVarianceCount2,
            this.colVarianceTotalValue,
            this.colVarianceVarianceTotal});
            this.grvStockTakeVariance.GridControl = this.grdStockTakeVariance;
            this.grvStockTakeVariance.Name = "grvStockTakeVariance";
            this.grvStockTakeVariance.OptionsView.ShowFooter = true;
            this.grvStockTakeVariance.OptionsView.ShowGroupPanel = false;
            this.grvStockTakeVariance.PreviewRowEdit = null;
            // 
            // colVarianceCode
            // 
            this.colVarianceCode.Caption = "Name";
            this.colVarianceCode.FieldName = "ShortName";
            this.colVarianceCode.Name = "colVarianceCode";
            this.colVarianceCode.OptionsColumn.AllowEdit = false;
            this.colVarianceCode.Visible = true;
            this.colVarianceCode.VisibleIndex = 1;
            // 
            // colVarianceName
            // 
            this.colVarianceName.Caption = "Code";
            this.colVarianceName.FieldName = "Name";
            this.colVarianceName.Name = "colVarianceName";
            this.colVarianceName.OptionsColumn.AllowEdit = false;
            this.colVarianceName.Visible = true;
            this.colVarianceName.VisibleIndex = 0;
            // 
            // colVarianceOnHand
            // 
            this.colVarianceOnHand.FieldName = "OnHand";
            this.colVarianceOnHand.Name = "colVarianceOnHand";
            this.colVarianceOnHand.OptionsColumn.AllowEdit = false;
            this.colVarianceOnHand.Visible = true;
            this.colVarianceOnHand.VisibleIndex = 2;
            // 
            // colVarianceUnitAverage
            // 
            this.colVarianceUnitAverage.FieldName = "UnitAverage";
            this.colVarianceUnitAverage.Name = "colVarianceUnitAverage";
            this.colVarianceUnitAverage.OptionsColumn.AllowEdit = false;
            this.colVarianceUnitAverage.Visible = true;
            this.colVarianceUnitAverage.VisibleIndex = 3;
            // 
            // colVarianceCategory
            // 
            this.colVarianceCategory.FieldName = "Category";
            this.colVarianceCategory.Name = "colVarianceCategory";
            this.colVarianceCategory.OptionsColumn.AllowEdit = false;
            // 
            // colVarianceSubCategory
            // 
            this.colVarianceSubCategory.FieldName = "SubCategory";
            this.colVarianceSubCategory.Name = "colVarianceSubCategory";
            this.colVarianceSubCategory.OptionsColumn.AllowEdit = false;
            // 
            // colVarianceLocationMain
            // 
            this.colVarianceLocationMain.FieldName = "LocationMain";
            this.colVarianceLocationMain.Name = "colVarianceLocationMain";
            this.colVarianceLocationMain.OptionsColumn.AllowEdit = false;
            // 
            // colVarianceLocationSecondary
            // 
            this.colVarianceLocationSecondary.FieldName = "LocationSecondary";
            this.colVarianceLocationSecondary.Name = "colVarianceLocationSecondary";
            this.colVarianceLocationSecondary.OptionsColumn.AllowEdit = false;
            // 
            // colVarianceStockType
            // 
            this.colVarianceStockType.FieldName = "StockType";
            this.colVarianceStockType.Name = "colVarianceStockType";
            this.colVarianceStockType.OptionsColumn.AllowEdit = false;
            // 
            // colVarianceQuantityCount1
            // 
            this.colVarianceQuantityCount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVarianceQuantityCount1.FieldName = "QuantityCount1";
            this.colVarianceQuantityCount1.Name = "colVarianceQuantityCount1";
            this.colVarianceQuantityCount1.OptionsColumn.AllowEdit = false;
            this.colVarianceQuantityCount1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantityCount1", "{0:0.00}")});
            this.colVarianceQuantityCount1.Visible = true;
            this.colVarianceQuantityCount1.VisibleIndex = 4;
            // 
            // colVarianceQuantityCount2
            // 
            this.colVarianceQuantityCount2.DisplayFormat.FormatString = "N2";
            this.colVarianceQuantityCount2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVarianceQuantityCount2.FieldName = "QuantityCount2";
            this.colVarianceQuantityCount2.Name = "colVarianceQuantityCount2";
            this.colVarianceQuantityCount2.OptionsColumn.AllowEdit = false;
            this.colVarianceQuantityCount2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantityCount2", "{0:0.00}")});
            this.colVarianceQuantityCount2.Visible = true;
            this.colVarianceQuantityCount2.VisibleIndex = 5;
            // 
            // colVarianceVarianceCount1
            // 
            this.colVarianceVarianceCount1.DisplayFormat.FormatString = "N2";
            this.colVarianceVarianceCount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVarianceVarianceCount1.FieldName = "VarianceCount1";
            this.colVarianceVarianceCount1.Name = "colVarianceVarianceCount1";
            this.colVarianceVarianceCount1.OptionsColumn.AllowEdit = false;
            this.colVarianceVarianceCount1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VarianceCount1", "{0:0.00}")});
            this.colVarianceVarianceCount1.Visible = true;
            this.colVarianceVarianceCount1.VisibleIndex = 6;
            // 
            // colVarianceVarianceCount2
            // 
            this.colVarianceVarianceCount2.DisplayFormat.FormatString = "N2";
            this.colVarianceVarianceCount2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVarianceVarianceCount2.FieldName = "VarianceCount2";
            this.colVarianceVarianceCount2.Name = "colVarianceVarianceCount2";
            this.colVarianceVarianceCount2.OptionsColumn.AllowEdit = false;
            this.colVarianceVarianceCount2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VarianceCount2", "{0:0.00}")});
            this.colVarianceVarianceCount2.Visible = true;
            this.colVarianceVarianceCount2.VisibleIndex = 7;
            // 
            // colVarianceTotalValue
            // 
            this.colVarianceTotalValue.DisplayFormat.FormatString = "N2";
            this.colVarianceTotalValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVarianceTotalValue.FieldName = "TotalValue";
            this.colVarianceTotalValue.Name = "colVarianceTotalValue";
            this.colVarianceTotalValue.OptionsColumn.AllowEdit = false;
            this.colVarianceTotalValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalValue", "{0:0.00}")});
            this.colVarianceTotalValue.Visible = true;
            this.colVarianceTotalValue.VisibleIndex = 8;
            // 
            // colVarianceVarianceTotal
            // 
            this.colVarianceVarianceTotal.DisplayFormat.FormatString = "N2";
            this.colVarianceVarianceTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVarianceVarianceTotal.FieldName = "VarianceTotal";
            this.colVarianceVarianceTotal.Name = "colVarianceVarianceTotal";
            this.colVarianceVarianceTotal.OptionsColumn.AllowEdit = false;
            this.colVarianceVarianceTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VarianceTotal", "{0:0.00}")});
            this.colVarianceVarianceTotal.Visible = true;
            this.colVarianceVarianceTotal.VisibleIndex = 9;
            // 
            // wizStockTakeSummary
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.wizStockTakeSummary, DevExpress.Utils.DefaultBoolean.Default);
            this.wizStockTakeSummary.Controls.Add(this.layoutControl1);
            this.wizStockTakeSummary.DescriptionText = "Below is a quick summary of this stock take";
            this.wizStockTakeSummary.Name = "wizStockTakeSummary";
            this.wizStockTakeSummary.Size = new System.Drawing.Size(734, 254);
            this.wizStockTakeSummary.Text = "Summary";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdStockTakeVarianceSummary);
            this.layoutControl1.Controls.Add(this.lblDescription);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1197, 300, 702, 633);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(734, 254);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdStockTakeVarianceSummary
            // 
            this.grdStockTakeVarianceSummary.DataSource = this.InstantFeedbackSourceVariance;
            this.grdStockTakeVarianceSummary.Location = new System.Drawing.Point(12, 45);
            this.grdStockTakeVarianceSummary.MainView = this.grvStockTakeVarianceSummary;
            this.grdStockTakeVarianceSummary.MenuManager = this.RibbonControl;
            this.grdStockTakeVarianceSummary.Name = "grdStockTakeVarianceSummary";
            this.grdStockTakeVarianceSummary.Size = new System.Drawing.Size(710, 197);
            this.grdStockTakeVarianceSummary.TabIndex = 6;
            this.grdStockTakeVarianceSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStockTakeVarianceSummary});
            // 
            // InstantFeedbackSourceVariance
            // 
            this.InstantFeedbackSourceVariance.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_StockTakeVariance);
            this.InstantFeedbackSourceVariance.KeyExpression = "Id";
            this.InstantFeedbackSourceVariance.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceVariance_GetQueryable);
            // 
            // grvStockTakeVarianceSummary
            // 
            this.grvStockTakeVarianceSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.grvStockTakeVarianceSummary.GridControl = this.grdStockTakeVarianceSummary;
            this.grvStockTakeVarianceSummary.Name = "grvStockTakeVarianceSummary";
            this.grvStockTakeVarianceSummary.OptionsView.ShowFooter = true;
            this.grvStockTakeVarianceSummary.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Name";
            this.gridColumn1.FieldName = "ShortName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Code";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "OnHand";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "UnitAverage";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "Category";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.FieldName = "SubCategory";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "LocationMain";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "LocationSecondary";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "StockType";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "QuantityCount1";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantityCount1", "{0:0.00}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.DisplayFormat.FormatString = "N2";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "QuantityCount2";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantityCount2", "{0:0.00}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gridColumn12
            // 
            this.gridColumn12.DisplayFormat.FormatString = "N2";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "VarianceCount1";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VarianceCount1", "{0:0.00}")});
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            // 
            // gridColumn13
            // 
            this.gridColumn13.DisplayFormat.FormatString = "N2";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "VarianceCount2";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VarianceCount2", "{0:0.00}")});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            // 
            // gridColumn14
            // 
            this.gridColumn14.DisplayFormat.FormatString = "N2";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "TotalValue";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalValue", "{0:0.00}")});
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gridColumn15
            // 
            this.gridColumn15.DisplayFormat.FormatString = "N2";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "VarianceTotal";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VarianceTotal", "{0:0.00}")});
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Description", true));
            this.lblDescription.Location = new System.Drawing.Point(12, 12);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(53, 13);
            this.lblDescription.StyleController = this.layoutControl1;
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDescription,
            this.lciStockTakeVarianceSummary});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(734, 254);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // lciDescription
            // 
            this.lciDescription.Control = this.lblDescription;
            this.lciDescription.CustomizationFormText = "Description";
            this.lciDescription.Location = new System.Drawing.Point(0, 0);
            this.lciDescription.Name = "lciDescription";
            this.lciDescription.Size = new System.Drawing.Size(714, 17);
            this.lciDescription.Text = "lciDescription";
            this.lciDescription.TextSize = new System.Drawing.Size(0, 0);
            this.lciDescription.TextVisible = false;
            // 
            // lciStockTakeVarianceSummary
            // 
            this.lciStockTakeVarianceSummary.Control = this.grdStockTakeVarianceSummary;
            this.lciStockTakeVarianceSummary.CustomizationFormText = "Stock Take Variance Summary";
            this.lciStockTakeVarianceSummary.Location = new System.Drawing.Point(0, 17);
            this.lciStockTakeVarianceSummary.Name = "lciStockTakeVarianceSummary";
            this.lciStockTakeVarianceSummary.Size = new System.Drawing.Size(714, 217);
            this.lciStockTakeVarianceSummary.Text = "Stock Take Variance Summary";
            this.lciStockTakeVarianceSummary.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciStockTakeVarianceSummary.TextSize = new System.Drawing.Size(143, 13);
            // 
            // itmStockTakeWizard
            // 
            this.itmStockTakeWizard.Control = this.wizStockTake;
            this.itmStockTakeWizard.CustomizationFormText = "Stock Take Wizard";
            this.itmStockTakeWizard.Location = new System.Drawing.Point(0, 0);
            this.itmStockTakeWizard.Name = "itmStockTakeWizard";
            this.itmStockTakeWizard.Size = new System.Drawing.Size(770, 401);
            this.itmStockTakeWizard.Text = "Stock Take Wizard";
            this.itmStockTakeWizard.TextSize = new System.Drawing.Size(0, 0);
            this.itmStockTakeWizard.TextVisible = false;
            // 
            // btnPrintCountSheet
            // 
            this.btnPrintCountSheet.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnPrintCountSheet.Caption = "Print First Count";
            this.btnPrintCountSheet.DropDownControl = this.popPrint;
            this.btnPrintCountSheet.Glyph = global::CDS.Client.Desktop.Stock.Properties.Resources.printer_16;
            this.btnPrintCountSheet.Id = 24;
            this.btnPrintCountSheet.LargeGlyph = global::CDS.Client.Desktop.Stock.Properties.Resources.printer_32;
            this.btnPrintCountSheet.Name = "btnPrintCountSheet";
            this.btnPrintCountSheet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintCountSheet_ItemClick);
            // 
            // popPrint
            // 
            this.popPrint.ItemLinks.Add(this.btnSecondCount);
            this.popPrint.Name = "popPrint";
            this.popPrint.Ribbon = this.RibbonControl;
            // 
            // btnSecondCount
            // 
            this.btnSecondCount.Caption = "Print Second Count";
            this.btnSecondCount.Glyph = global::CDS.Client.Desktop.Stock.Properties.Resources.printer_16;
            this.btnSecondCount.Id = 25;
            this.btnSecondCount.LargeGlyph = global::CDS.Client.Desktop.Stock.Properties.Resources.printer_32;
            this.btnSecondCount.Name = "btnSecondCount";
            this.btnSecondCount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSecondCount_ItemClick);
            // 
            // rpStockTake
            // 
            this.rpStockTake.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpStockTakePrint});
            this.rpStockTake.Name = "rpStockTake";
            this.rpStockTake.Text = "Stock Take";
            // 
            // rpStockTakePrint
            // 
            this.rpStockTakePrint.ItemLinks.Add(this.btnPrintCountSheet);
            this.rpStockTakePrint.Name = "rpStockTakePrint";
            this.rpStockTakePrint.Text = "Print";
            // 
            // StockTakeForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Description", true));
            this.Name = "StockTakeForm";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizStockTake)).EndInit();
            this.wizStockTake.ResumeLayout(false);
            this.wizStockTakeStart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeItems)).EndInit();
            this.wizStockTakeQuantities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceStockTakeItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repInventory2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repInventory)).EndInit();
            this.wizStockTakeVariance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeVariance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceVariance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeVariance)).EndInit();
            this.wizStockTakeSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockTakeVarianceSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStockTakeVarianceSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStockTakeVarianceSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStockTakeWizard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizStockTake;
        private DevExpress.XtraWizard.WelcomeWizardPage wizStockTakeWelcome;
        private DevExpress.XtraWizard.WizardPage wizStockTakeStart;
        private DevExpress.XtraWizard.CompletionWizardPage wizStockTakeCompleted;
        private DevExpress.XtraLayout.LayoutControlItem itmStockTakeWizard;
        private DevExpress.XtraWizard.WizardPage wizStockTakeQuantities;
        private DevExpress.XtraWizard.WizardPage wizStockTakeVariance;
        private DevExpress.XtraGrid.GridControl grdStockTakeItems;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStockTakeItems;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colStockType;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationMain;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationSecondary;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand;
        private DevExpress.XtraGrid.GridControl grdStockTakeQuantity;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStockTakeQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repInventory;
        private DevExpress.XtraGrid.Columns.GridColumn colLineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPageNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityCount1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityCount2;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitAverage;
        private DevExpress.XtraGrid.Columns.GridColumn colSuccessfullyChanged;
        private System.Windows.Forms.BindingSource BindingSourceStockTakeItem;
        private DevExpress.XtraBars.BarButtonItem btnPrintCountSheet;
        private DevExpress.XtraBars.BarButtonItem btnSecondCount;
        private DevExpress.XtraBars.PopupMenu popPrint;
        private Essential.UTL.CustomGridControl grdStockTakeVariance;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceVariance;
        private Essential.UTL.CustomGridView grvStockTakeVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceName;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceOnHand;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceUnitAverage;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceSubCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceLocationMain;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceLocationSecondary;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceStockType;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceQuantityCount1;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceQuantityCount2;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceVarianceCount1;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceVarianceCount2;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceTotalValue;
        private DevExpress.XtraGrid.Columns.GridColumn colVarianceVarianceTotal;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceInventory;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceRepositoryInventory;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repInventory2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraWizard.WizardPage wizStockTakeSummary;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lciDescription;
        private DevExpress.XtraGrid.GridControl grdStockTakeVarianceSummary;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceVariance;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStockTakeVarianceSummary;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraLayout.LayoutControlItem lciStockTakeVarianceSummary;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpStockTake;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpStockTakePrint;
    }
}
