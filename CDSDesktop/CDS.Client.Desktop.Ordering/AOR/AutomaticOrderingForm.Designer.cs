namespace CDS.Client.Desktop.Ordering.AOR
{
    partial class AutomaticOrderingForm
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.ddlCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.InstantFeedbackSourceSupplier = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSupplierCodeFrom = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceFilters = new System.Windows.Forms.BindingSource();
            this.itmCodeFrom = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSupplierCodeTo = new DevExpress.XtraEditors.TextEdit();
            this.itmCodeTo = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCategoryFrom = new DevExpress.XtraEditors.TextEdit();
            this.itmCategoryFrom = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCategoryTo = new DevExpress.XtraEditors.TextEdit();
            this.itmCategoryTo = new DevExpress.XtraLayout.LayoutControlItem();
            this.tcgSupplierFilter = new DevExpress.XtraLayout.TabbedControlGroup();
            this.tabSingleSupplier = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSupplier = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabMultipleSuppliers = new DevExpress.XtraLayout.LayoutControlGroup();
            this.grdOrderItems = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceLines = new System.Windows.Forms.BindingSource();
            this.grvOrderItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnReserve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSafetyStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEOQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAvgDemand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderAmountCalculated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCompany = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.InstantFeedbackSourceSupplierRepository = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmGridItems = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMonthWeight3 = new DevExpress.XtraEditors.TextEdit();
            this.itmMonthWeight3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMonthWeight6 = new DevExpress.XtraEditors.TextEdit();
            this.itmMonthWeight6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMonthWeight12 = new DevExpress.XtraEditors.TextEdit();
            this.itmMonthWeight12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMonthWeight24 = new DevExpress.XtraEditors.TextEdit();
            this.itmMonthWeight24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMonthWeight36 = new DevExpress.XtraEditors.TextEdit();
            this.itmMonthWeight36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.rgItems = new DevExpress.XtraEditors.RadioGroup();
            this.lciItems = new DevExpress.XtraLayout.LayoutControlItem();
            this.rgSales = new DevExpress.XtraEditors.RadioGroup();
            this.lciSalesFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCalculate = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelOrder = new DevExpress.XtraBars.BarButtonItem();
            this.lcgWeights = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.AutoSaveTimer = new System.Windows.Forms.Timer();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgItems = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgSalesFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.rgOrdering = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgOrderingActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnOrder = new DevExpress.XtraBars.BarButtonItem();
            this.lcgCategoryFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCodeFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCodeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCodeTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCodeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgSupplierFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSingleSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMultipleSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight12.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight24.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight36.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgItems.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSalesFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgWeights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSalesFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCategoryFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.AOR_Order);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.rgSales);
            this.LayoutControl.Controls.Add(this.rgItems);
            this.LayoutControl.Controls.Add(this.txtMonthWeight36);
            this.LayoutControl.Controls.Add(this.txtMonthWeight24);
            this.LayoutControl.Controls.Add(this.txtMonthWeight12);
            this.LayoutControl.Controls.Add(this.txtMonthWeight6);
            this.LayoutControl.Controls.Add(this.txtMonthWeight3);
            this.LayoutControl.Controls.Add(this.grdOrderItems);
            this.LayoutControl.Controls.Add(this.txtCategoryTo);
            this.LayoutControl.Controls.Add(this.txtCategoryFrom);
            this.LayoutControl.Controls.Add(this.txtSupplierCodeTo);
            this.LayoutControl.Controls.Add(this.txtSupplierCodeFrom);
            this.LayoutControl.Controls.Add(this.ddlCompany);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2569, 522, 250, 350);
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
            this.itmGridItems,
            this.tcgSupplierFilter,
            this.emptySpaceItem2,
            this.lcgWeights,
            this.lcgItems,
            this.lcgCategoryFilter,
            this.lcgSalesFilter});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(1008, 584);
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCalculate,
            this.btnCancelOrder,
            this.btnOrder});
            this.RibbonControl.MaxItemId = 27;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rgOrdering});
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
            // ddlCompany
            // 
            this.ddlCompany.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SupplierId", true));
            this.ddlCompany.Location = new System.Drawing.Point(110, 46);
            this.ddlCompany.MenuManager = this.RibbonControl;
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCompany.Properties.DataSource = this.InstantFeedbackSourceSupplier;
            this.ddlCompany.Properties.DisplayMember = "Title";
            this.ddlCompany.Properties.NullText = "Select Supplier ...";
            this.ddlCompany.Properties.ValueMember = "EntityId";
            this.ddlCompany.Properties.View = this.searchLookUpEdit1View;
            this.ddlCompany.Size = new System.Drawing.Size(391, 20);
            this.ddlCompany.StyleController = this.LayoutControl;
            this.ddlCompany.TabIndex = 5;
            this.ddlCompany.EditValueChanged += new System.EventHandler(this.ddlCompany_EditValueChanged);
            // 
            // InstantFeedbackSourceSupplier
            // 
            this.InstantFeedbackSourceSupplier.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Company);
            this.InstantFeedbackSourceSupplier.KeyExpression = "Id";
            this.InstantFeedbackSourceSupplier.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceSupplier_GetQueryable);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colAccountsContact,
            this.colAccountsTelephone,
            this.colSalesContact,
            this.colSalesTelephone,
            this.colActive});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTitle, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 150;
            // 
            // colAccountsContact
            // 
            this.colAccountsContact.FieldName = "AccountsContact";
            this.colAccountsContact.Name = "colAccountsContact";
            this.colAccountsContact.Visible = true;
            this.colAccountsContact.VisibleIndex = 1;
            this.colAccountsContact.Width = 50;
            // 
            // colAccountsTelephone
            // 
            this.colAccountsTelephone.FieldName = "AccountsTelephone";
            this.colAccountsTelephone.Name = "colAccountsTelephone";
            this.colAccountsTelephone.Visible = true;
            this.colAccountsTelephone.VisibleIndex = 2;
            this.colAccountsTelephone.Width = 50;
            // 
            // colSalesContact
            // 
            this.colSalesContact.FieldName = "SalesContact";
            this.colSalesContact.Name = "colSalesContact";
            this.colSalesContact.Visible = true;
            this.colSalesContact.VisibleIndex = 3;
            this.colSalesContact.Width = 50;
            // 
            // colSalesTelephone
            // 
            this.colSalesTelephone.FieldName = "SalesTelephone";
            this.colSalesTelephone.Name = "colSalesTelephone";
            this.colSalesTelephone.Visible = true;
            this.colSalesTelephone.VisibleIndex = 4;
            this.colSalesTelephone.Width = 50;
            // 
            // colActive
            // 
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 5;
            this.colActive.Width = 23;
            // 
            // txtSupplierCodeFrom
            // 
            this.txtSupplierCodeFrom.Location = new System.Drawing.Point(110, 46);
            this.txtSupplierCodeFrom.MenuManager = this.RibbonControl;
            this.txtSupplierCodeFrom.Name = "txtSupplierCodeFrom";
            this.txtSupplierCodeFrom.Size = new System.Drawing.Size(150, 20);
            this.txtSupplierCodeFrom.StyleController = this.LayoutControl;
            this.txtSupplierCodeFrom.TabIndex = 6;
            this.txtSupplierCodeFrom.EditValueChanged += new System.EventHandler(this.txtSupplierCodeFrom_EditValueChanged);
            // 
            // BindingSourceFilters
            // 
            this.BindingSourceFilters.DataSource = typeof(CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingForm.AutomaticOrderingFilters);
            // 
            // itmCodeFrom
            // 
            this.itmCodeFrom.Control = this.txtSupplierCodeFrom;
            this.itmCodeFrom.CustomizationFormText = "Code from";
            this.itmCodeFrom.Location = new System.Drawing.Point(0, 0);
            this.itmCodeFrom.Name = "itmCodeFrom";
            this.itmCodeFrom.Size = new System.Drawing.Size(240, 24);
            this.itmCodeFrom.Text = "Code from";
            this.itmCodeFrom.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtSupplierCodeTo
            // 
            this.txtSupplierCodeTo.Location = new System.Drawing.Point(350, 46);
            this.txtSupplierCodeTo.MenuManager = this.RibbonControl;
            this.txtSupplierCodeTo.Name = "txtSupplierCodeTo";
            this.txtSupplierCodeTo.Size = new System.Drawing.Size(151, 20);
            this.txtSupplierCodeTo.StyleController = this.LayoutControl;
            this.txtSupplierCodeTo.TabIndex = 7;
            this.txtSupplierCodeTo.EditValueChanged += new System.EventHandler(this.txtSupplierCodeTo_EditValueChanged);
            // 
            // itmCodeTo
            // 
            this.itmCodeTo.Control = this.txtSupplierCodeTo;
            this.itmCodeTo.CustomizationFormText = "Code to";
            this.itmCodeTo.Location = new System.Drawing.Point(240, 0);
            this.itmCodeTo.Name = "itmCodeTo";
            this.itmCodeTo.Size = new System.Drawing.Size(241, 24);
            this.itmCodeTo.Text = "Code to";
            this.itmCodeTo.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtCategoryFrom
            // 
            this.txtCategoryFrom.Location = new System.Drawing.Point(110, 113);
            this.txtCategoryFrom.MenuManager = this.RibbonControl;
            this.txtCategoryFrom.Name = "txtCategoryFrom";
            this.txtCategoryFrom.Size = new System.Drawing.Size(150, 20);
            this.txtCategoryFrom.StyleController = this.LayoutControl;
            this.txtCategoryFrom.TabIndex = 8;
            // 
            // itmCategoryFrom
            // 
            this.itmCategoryFrom.Control = this.txtCategoryFrom;
            this.itmCategoryFrom.CustomizationFormText = "Category from";
            this.itmCategoryFrom.Location = new System.Drawing.Point(0, 0);
            this.itmCategoryFrom.Name = "itmCategoryFrom";
            this.itmCategoryFrom.Size = new System.Drawing.Size(240, 24);
            this.itmCategoryFrom.Text = "Category from";
            this.itmCategoryFrom.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtCategoryTo
            // 
            this.txtCategoryTo.Location = new System.Drawing.Point(350, 113);
            this.txtCategoryTo.MenuManager = this.RibbonControl;
            this.txtCategoryTo.Name = "txtCategoryTo";
            this.txtCategoryTo.Size = new System.Drawing.Size(151, 20);
            this.txtCategoryTo.StyleController = this.LayoutControl;
            this.txtCategoryTo.TabIndex = 9;
            // 
            // itmCategoryTo
            // 
            this.itmCategoryTo.Control = this.txtCategoryTo;
            this.itmCategoryTo.CustomizationFormText = "Category to";
            this.itmCategoryTo.Location = new System.Drawing.Point(240, 0);
            this.itmCategoryTo.Name = "itmCategoryTo";
            this.itmCategoryTo.Size = new System.Drawing.Size(241, 24);
            this.itmCategoryTo.Text = "Category to";
            this.itmCategoryTo.TextSize = new System.Drawing.Size(82, 13);
            // 
            // tcgSupplierFilter
            // 
            this.tcgSupplierFilter.CustomizationFormText = "tcgSupplierFilter";
            this.tcgSupplierFilter.Location = new System.Drawing.Point(0, 0);
            this.tcgSupplierFilter.Name = "tcgSupplierFilter";
            this.tcgSupplierFilter.SelectedTabPage = this.tabSingleSupplier;
            this.tcgSupplierFilter.SelectedTabPageIndex = 0;
            this.tcgSupplierFilter.Size = new System.Drawing.Size(505, 70);
            this.tcgSupplierFilter.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabSingleSupplier,
            this.tabMultipleSuppliers});
            this.tcgSupplierFilter.Text = "tcgSupplierFilter";
            // 
            // tabSingleSupplier
            // 
            this.tabSingleSupplier.CustomizationFormText = "Single Supplier";
            this.tabSingleSupplier.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSupplier});
            this.tabSingleSupplier.Location = new System.Drawing.Point(0, 0);
            this.tabSingleSupplier.Name = "tabSingleSupplier";
            this.tabSingleSupplier.Size = new System.Drawing.Size(481, 24);
            this.tabSingleSupplier.Text = "Single Supplier";
            // 
            // lciSupplier
            // 
            this.lciSupplier.Control = this.ddlCompany;
            this.lciSupplier.CustomizationFormText = "Supplier";
            this.lciSupplier.Location = new System.Drawing.Point(0, 0);
            this.lciSupplier.Name = "lciSupplier";
            this.lciSupplier.Size = new System.Drawing.Size(481, 24);
            this.lciSupplier.Text = "Supplier";
            this.lciSupplier.TextSize = new System.Drawing.Size(82, 13);
            // 
            // tabMultipleSuppliers
            // 
            this.tabMultipleSuppliers.CustomizationFormText = "Multiple Suppliers";
            this.tabMultipleSuppliers.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCodeFrom,
            this.itmCodeTo});
            this.tabMultipleSuppliers.Location = new System.Drawing.Point(0, 0);
            this.tabMultipleSuppliers.Name = "tabMultipleSuppliers";
            this.tabMultipleSuppliers.Size = new System.Drawing.Size(481, 24);
            this.tabMultipleSuppliers.Text = "Multiple Suppliers";
            // 
            // grdOrderItems
            // 
            this.grdOrderItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdOrderItems.DataSource = this.BindingSourceLines;
            this.grdOrderItems.Location = new System.Drawing.Point(12, 213);
            this.grdOrderItems.MainView = this.grvOrderItems;
            this.grdOrderItems.MenuManager = this.RibbonControl;
            this.grdOrderItems.Name = "grdOrderItems";
            this.grdOrderItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCompany});
            this.grdOrderItems.Size = new System.Drawing.Size(984, 359);
            this.grdOrderItems.TabIndex = 10;
            this.grdOrderItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOrderItems});
            this.grdOrderItems.DoubleClick += new System.EventHandler(this.grdOrderItems_DoubleClick);
            this.grdOrderItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdOrderItems_KeyDown);
            // 
            // BindingSourceLines
            // 
            this.BindingSourceLines.DataSource = typeof(CDS.Client.DataAccessLayer.DB.AOR_OrderLine);
            // 
            // grvOrderItems
            // 
            this.grvOrderItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSupplier,
            this.colCode,
            this.colName,
            this.colOnHand,
            this.colOnReserve,
            this.colOnOrder,
            this.colSafetyStock,
            this.colUnitCost,
            this.colUnitPrice,
            this.colUnitAverage,
            this.colEOQ,
            this.colAvgDemand,
            this.colOrderPoint,
            this.colOrderAmountCalculated,
            this.colTotal,
            this.colOrderAmount});
            this.grvOrderItems.GridControl = this.grdOrderItems;
            this.grvOrderItems.Name = "grvOrderItems";
            this.grvOrderItems.OptionsView.ShowFooter = true;
            this.grvOrderItems.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSupplier, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCode, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOnHand, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvOrderItems.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvOrderItems_FocusedRowChanged);
            this.grvOrderItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvOrderItems_CellValueChanged);
            // 
            // colSupplier
            // 
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.OptionsColumn.AllowFocus = false;
            this.colSupplier.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colSupplier.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplier.OptionsColumn.ReadOnly = true;
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 0;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "Name";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowFocus = false;
            this.colCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "ShortName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colOnHand
            // 
            this.colOnHand.DisplayFormat.FormatString = "N4";
            this.colOnHand.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOnHand.FieldName = "OnHand";
            this.colOnHand.Name = "colOnHand";
            this.colOnHand.OptionsColumn.AllowFocus = false;
            this.colOnHand.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOnHand.OptionsColumn.ReadOnly = true;
            this.colOnHand.Visible = true;
            this.colOnHand.VisibleIndex = 3;
            // 
            // colOnReserve
            // 
            this.colOnReserve.DisplayFormat.FormatString = "N4";
            this.colOnReserve.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOnReserve.FieldName = "OnReserve";
            this.colOnReserve.Name = "colOnReserve";
            this.colOnReserve.OptionsColumn.AllowFocus = false;
            this.colOnReserve.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOnReserve.OptionsColumn.ReadOnly = true;
            this.colOnReserve.Visible = true;
            this.colOnReserve.VisibleIndex = 4;
            // 
            // colOnOrder
            // 
            this.colOnOrder.DisplayFormat.FormatString = "N4";
            this.colOnOrder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOnOrder.FieldName = "OnOrder";
            this.colOnOrder.Name = "colOnOrder";
            this.colOnOrder.OptionsColumn.AllowFocus = false;
            this.colOnOrder.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOnOrder.OptionsColumn.ReadOnly = true;
            this.colOnOrder.Visible = true;
            this.colOnOrder.VisibleIndex = 5;
            this.colOnOrder.Width = 63;
            // 
            // colSafetyStock
            // 
            this.colSafetyStock.DisplayFormat.FormatString = "N4";
            this.colSafetyStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSafetyStock.FieldName = "SafetyStock";
            this.colSafetyStock.Name = "colSafetyStock";
            this.colSafetyStock.OptionsColumn.AllowFocus = false;
            this.colSafetyStock.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSafetyStock.OptionsColumn.ReadOnly = true;
            this.colSafetyStock.Visible = true;
            this.colSafetyStock.VisibleIndex = 6;
            this.colSafetyStock.Width = 77;
            // 
            // colUnitCost
            // 
            this.colUnitCost.DisplayFormat.FormatString = "N4";
            this.colUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitCost.FieldName = "UnitCost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.OptionsColumn.AllowFocus = false;
            this.colUnitCost.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitCost.OptionsColumn.ReadOnly = true;
            this.colUnitCost.Visible = true;
            this.colUnitCost.VisibleIndex = 7;
            this.colUnitCost.Width = 59;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DisplayFormat.FormatString = "N4";
            this.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowFocus = false;
            this.colUnitPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsColumn.ReadOnly = true;
            // 
            // colUnitAverage
            // 
            this.colUnitAverage.DisplayFormat.FormatString = "N4";
            this.colUnitAverage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitAverage.FieldName = "UnitAverage";
            this.colUnitAverage.Name = "colUnitAverage";
            this.colUnitAverage.OptionsColumn.AllowFocus = false;
            this.colUnitAverage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitAverage.OptionsColumn.ReadOnly = true;
            this.colUnitAverage.Visible = true;
            this.colUnitAverage.VisibleIndex = 8;
            this.colUnitAverage.Width = 74;
            // 
            // colEOQ
            // 
            this.colEOQ.DisplayFormat.FormatString = "N4";
            this.colEOQ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEOQ.FieldName = "Eoq";
            this.colEOQ.Name = "colEOQ";
            this.colEOQ.OptionsColumn.AllowFocus = false;
            this.colEOQ.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colEOQ.OptionsColumn.ReadOnly = true;
            this.colEOQ.Visible = true;
            this.colEOQ.VisibleIndex = 10;
            this.colEOQ.Width = 42;
            // 
            // colAvgDemand
            // 
            this.colAvgDemand.DisplayFormat.FormatString = "N4";
            this.colAvgDemand.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAvgDemand.FieldName = "AvgDemand";
            this.colAvgDemand.Name = "colAvgDemand";
            this.colAvgDemand.OptionsColumn.AllowFocus = false;
            this.colAvgDemand.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAvgDemand.OptionsColumn.ReadOnly = true;
            this.colAvgDemand.Visible = true;
            this.colAvgDemand.VisibleIndex = 9;
            this.colAvgDemand.Width = 78;
            // 
            // colOrderPoint
            // 
            this.colOrderPoint.DisplayFormat.FormatString = "N4";
            this.colOrderPoint.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOrderPoint.FieldName = "OrderPoint";
            this.colOrderPoint.Name = "colOrderPoint";
            this.colOrderPoint.OptionsColumn.AllowFocus = false;
            this.colOrderPoint.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderPoint.OptionsColumn.ReadOnly = true;
            this.colOrderPoint.Visible = true;
            this.colOrderPoint.VisibleIndex = 11;
            this.colOrderPoint.Width = 79;
            // 
            // colOrderAmountCalculated
            // 
            this.colOrderAmountCalculated.DisplayFormat.FormatString = "N4";
            this.colOrderAmountCalculated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOrderAmountCalculated.FieldName = "OrderAmountCalculated";
            this.colOrderAmountCalculated.Name = "colOrderAmountCalculated";
            this.colOrderAmountCalculated.OptionsColumn.AllowFocus = false;
            this.colOrderAmountCalculated.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderAmountCalculated.OptionsColumn.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.DisplayFormat.FormatString = "N4";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowFocus = false;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N4}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 12;
            // 
            // colOrderAmount
            // 
            this.colOrderAmount.DisplayFormat.FormatString = "N4";
            this.colOrderAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOrderAmount.FieldName = "OrderAmount";
            this.colOrderAmount.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colOrderAmount.Name = "colOrderAmount";
            this.colOrderAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderAmount.Visible = true;
            this.colOrderAmount.VisibleIndex = 13;
            this.colOrderAmount.Width = 96;
            // 
            // repCompany
            // 
            this.repCompany.AutoHeight = false;
            this.repCompany.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCompany.DataSource = this.InstantFeedbackSourceSupplierRepository;
            this.repCompany.DisplayMember = "Code";
            this.repCompany.Name = "repCompany";
            this.repCompany.ValueMember = "Code";
            this.repCompany.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // InstantFeedbackSourceSupplierRepository
            // 
            this.InstantFeedbackSourceSupplierRepository.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Company);
            this.InstantFeedbackSourceSupplierRepository.KeyExpression = "Id";
            this.InstantFeedbackSourceSupplierRepository.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceSupplierRepository_GetQueryable);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Title";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "AccountsContact";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 50;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "AccountsTelephone";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "SalesContact";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "SalesTelephone";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 50;
            // 
            // gridColumn6
            // 
            this.gridColumn6.FieldName = "Active";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 23;
            // 
            // itmGridItems
            // 
            this.itmGridItems.Control = this.grdOrderItems;
            this.itmGridItems.CustomizationFormText = "Grid Items";
            this.itmGridItems.Location = new System.Drawing.Point(0, 201);
            this.itmGridItems.Name = "itmGridItems";
            this.itmGridItems.Size = new System.Drawing.Size(988, 363);
            this.itmGridItems.Text = "Grid Items";
            this.itmGridItems.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmGridItems.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridItems.TextVisible = false;
            // 
            // txtMonthWeight3
            // 
            this.txtMonthWeight3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MonthWeight3", true));
            this.txtMonthWeight3.EditValue = "1";
            this.txtMonthWeight3.Location = new System.Drawing.Point(615, 43);
            this.txtMonthWeight3.MenuManager = this.RibbonControl;
            this.txtMonthWeight3.Name = "txtMonthWeight3";
            this.txtMonthWeight3.Size = new System.Drawing.Size(139, 20);
            this.txtMonthWeight3.StyleController = this.LayoutControl;
            this.txtMonthWeight3.TabIndex = 11;
            this.txtMonthWeight3.TabStop = false;
            // 
            // itmMonthWeight3
            // 
            this.itmMonthWeight3.Control = this.txtMonthWeight3;
            this.itmMonthWeight3.CustomizationFormText = "3 Month Weight";
            this.itmMonthWeight3.Location = new System.Drawing.Point(0, 0);
            this.itmMonthWeight3.Name = "itmMonthWeight3";
            this.itmMonthWeight3.Size = new System.Drawing.Size(229, 24);
            this.itmMonthWeight3.Text = "3 Month Weight";
            this.itmMonthWeight3.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtMonthWeight6
            // 
            this.txtMonthWeight6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MonthWeight6", true));
            this.txtMonthWeight6.EditValue = "2";
            this.txtMonthWeight6.Location = new System.Drawing.Point(615, 67);
            this.txtMonthWeight6.MenuManager = this.RibbonControl;
            this.txtMonthWeight6.Name = "txtMonthWeight6";
            this.txtMonthWeight6.Size = new System.Drawing.Size(139, 20);
            this.txtMonthWeight6.StyleController = this.LayoutControl;
            this.txtMonthWeight6.TabIndex = 12;
            this.txtMonthWeight6.TabStop = false;
            // 
            // itmMonthWeight6
            // 
            this.itmMonthWeight6.Control = this.txtMonthWeight6;
            this.itmMonthWeight6.CustomizationFormText = "6 Month Weight";
            this.itmMonthWeight6.Location = new System.Drawing.Point(0, 24);
            this.itmMonthWeight6.Name = "itmMonthWeight6";
            this.itmMonthWeight6.Size = new System.Drawing.Size(229, 24);
            this.itmMonthWeight6.Text = "6 Month Weight";
            this.itmMonthWeight6.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtMonthWeight12
            // 
            this.txtMonthWeight12.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MonthWeight12", true));
            this.txtMonthWeight12.EditValue = "3";
            this.txtMonthWeight12.Location = new System.Drawing.Point(615, 91);
            this.txtMonthWeight12.MenuManager = this.RibbonControl;
            this.txtMonthWeight12.Name = "txtMonthWeight12";
            this.txtMonthWeight12.Size = new System.Drawing.Size(139, 20);
            this.txtMonthWeight12.StyleController = this.LayoutControl;
            this.txtMonthWeight12.TabIndex = 13;
            this.txtMonthWeight12.TabStop = false;
            // 
            // itmMonthWeight12
            // 
            this.itmMonthWeight12.Control = this.txtMonthWeight12;
            this.itmMonthWeight12.CustomizationFormText = "12 Month Weight";
            this.itmMonthWeight12.Location = new System.Drawing.Point(0, 48);
            this.itmMonthWeight12.Name = "itmMonthWeight12";
            this.itmMonthWeight12.Size = new System.Drawing.Size(229, 24);
            this.itmMonthWeight12.Text = "12 Month Weight";
            this.itmMonthWeight12.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtMonthWeight24
            // 
            this.txtMonthWeight24.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MonthWeight24", true));
            this.txtMonthWeight24.EditValue = "4";
            this.txtMonthWeight24.Location = new System.Drawing.Point(844, 43);
            this.txtMonthWeight24.MenuManager = this.RibbonControl;
            this.txtMonthWeight24.Name = "txtMonthWeight24";
            this.txtMonthWeight24.Size = new System.Drawing.Size(140, 20);
            this.txtMonthWeight24.StyleController = this.LayoutControl;
            this.txtMonthWeight24.TabIndex = 14;
            this.txtMonthWeight24.TabStop = false;
            // 
            // itmMonthWeight24
            // 
            this.itmMonthWeight24.Control = this.txtMonthWeight24;
            this.itmMonthWeight24.CustomizationFormText = "24 Month Weight";
            this.itmMonthWeight24.Location = new System.Drawing.Point(229, 0);
            this.itmMonthWeight24.Name = "itmMonthWeight24";
            this.itmMonthWeight24.Size = new System.Drawing.Size(230, 24);
            this.itmMonthWeight24.Text = "24 Month Weight";
            this.itmMonthWeight24.TextSize = new System.Drawing.Size(82, 13);
            // 
            // txtMonthWeight36
            // 
            this.txtMonthWeight36.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MonthWeight36", true));
            this.txtMonthWeight36.EditValue = "5";
            this.txtMonthWeight36.Location = new System.Drawing.Point(844, 67);
            this.txtMonthWeight36.MenuManager = this.RibbonControl;
            this.txtMonthWeight36.Name = "txtMonthWeight36";
            this.txtMonthWeight36.Size = new System.Drawing.Size(140, 20);
            this.txtMonthWeight36.StyleController = this.LayoutControl;
            this.txtMonthWeight36.TabIndex = 15;
            this.txtMonthWeight36.TabStop = false;
            // 
            // itmMonthWeight36
            // 
            this.itmMonthWeight36.Control = this.txtMonthWeight36;
            this.itmMonthWeight36.CustomizationFormText = "36 Month Weight";
            this.itmMonthWeight36.Location = new System.Drawing.Point(229, 24);
            this.itmMonthWeight36.Name = "itmMonthWeight36";
            this.itmMonthWeight36.Size = new System.Drawing.Size(230, 24);
            this.itmMonthWeight36.Text = "36 Month Weight";
            this.itmMonthWeight36.TextSize = new System.Drawing.Size(82, 13);
            // 
            // rgItems
            // 
            this.rgItems.EditValue = ((short)(1));
            this.rgItems.Location = new System.Drawing.Point(529, 158);
            this.rgItems.MenuManager = this.RibbonControl;
            this.rgItems.Name = "rgItems";
            this.rgItems.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgItems.Properties.Columns = 1;
            this.rgItems.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Recommended Order")});
            this.rgItems.Size = new System.Drawing.Size(149, 39);
            this.rgItems.StyleController = this.LayoutControl;
            this.rgItems.TabIndex = 16;
            this.rgItems.TabStop = false;
            this.rgItems.EditValueChanged += new System.EventHandler(this.rgItems_EditValueChanged);
            // 
            // lciItems
            // 
            this.lciItems.BestFitWeight = 0;
            this.lciItems.Control = this.rgItems;
            this.lciItems.CustomizationFormText = "Items";
            this.lciItems.FillControlToClientArea = false;
            this.lciItems.Location = new System.Drawing.Point(0, 0);
            this.lciItems.Name = "lciItems";
            this.lciItems.Size = new System.Drawing.Size(153, 43);
            this.lciItems.Text = "Items";
            this.lciItems.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciItems.TextSize = new System.Drawing.Size(0, 0);
            this.lciItems.TextVisible = false;
            // 
            // rgSales
            // 
            this.rgSales.EditValue = ((short)(0));
            this.rgSales.Location = new System.Drawing.Point(706, 158);
            this.rgSales.MenuManager = this.RibbonControl;
            this.rgSales.Name = "rgSales";
            this.rgSales.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSales.Properties.Columns = 2;
            this.rgSales.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Not Applicable"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "3 Month Sales"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "6 Month Sales"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "12 Month Sales")});
            this.rgSales.Size = new System.Drawing.Size(278, 39);
            this.rgSales.StyleController = this.LayoutControl;
            this.rgSales.TabIndex = 17;
            this.rgSales.TabStop = false;
            // 
            // lciSalesFilter
            // 
            this.lciSalesFilter.BestFitWeight = 0;
            this.lciSalesFilter.Control = this.rgSales;
            this.lciSalesFilter.CustomizationFormText = "Sales filter";
            this.lciSalesFilter.FillControlToClientArea = false;
            this.lciSalesFilter.Location = new System.Drawing.Point(0, 0);
            this.lciSalesFilter.Name = "lciSalesFilter";
            this.lciSalesFilter.Size = new System.Drawing.Size(282, 43);
            this.lciSalesFilter.Text = "Sales filter";
            this.lciSalesFilter.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciSalesFilter.TextSize = new System.Drawing.Size(0, 0);
            this.lciSalesFilter.TextVisible = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Caption = "Calculate";
            this.btnCalculate.Glyph = global::CDS.Client.Desktop.Ordering.Properties.Resources.calculator_16;
            this.btnCalculate.Id = 24;
            this.btnCalculate.LargeGlyph = global::CDS.Client.Desktop.Ordering.Properties.Resources.calculator_32;
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCalculate_ItemClick);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Caption = "Cancel \r\nOrder";
            this.btnCancelOrder.Glyph = global::CDS.Client.Desktop.Ordering.Properties.Resources.delete_16;
            this.btnCancelOrder.Id = 25;
            this.btnCancelOrder.LargeGlyph = global::CDS.Client.Desktop.Ordering.Properties.Resources.delete_32;
            this.btnCancelOrder.Name = "btnCancelOrder";
            toolTipTitleItem1.Text = "Cancel Order";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "This with undo any changes made to the current {0} and mark it as canceled";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnCancelOrder.SuperTip = superToolTip1;
            this.btnCancelOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelOrder_ItemClick);
            // 
            // lcgWeights
            // 
            this.lcgWeights.CustomizationFormText = "Weights";
            this.lcgWeights.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmMonthWeight3,
            this.itmMonthWeight6,
            this.itmMonthWeight12,
            this.itmMonthWeight24,
            this.itmMonthWeight36,
            this.emptySpaceItem1});
            this.lcgWeights.Location = new System.Drawing.Point(505, 0);
            this.lcgWeights.Name = "lcgWeights";
            this.lcgWeights.Size = new System.Drawing.Size(483, 115);
            this.lcgWeights.Text = "Weights";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(229, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(230, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AutoSaveTimer
            // 
            this.AutoSaveTimer.Interval = 10000;
            this.AutoSaveTimer.Tick += new System.EventHandler(this.AutoSaveTimer_Tick);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 137);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(505, 64);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgItems
            // 
            this.lcgItems.CustomizationFormText = "Items";
            this.lcgItems.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciItems});
            this.lcgItems.Location = new System.Drawing.Point(505, 115);
            this.lcgItems.Name = "lcgItems";
            this.lcgItems.Size = new System.Drawing.Size(177, 86);
            this.lcgItems.Text = "Items";
            // 
            // lcgSalesFilter
            // 
            this.lcgSalesFilter.CustomizationFormText = "Sales Filter";
            this.lcgSalesFilter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSalesFilter});
            this.lcgSalesFilter.Location = new System.Drawing.Point(682, 115);
            this.lcgSalesFilter.Name = "lcgSalesFilter";
            this.lcgSalesFilter.Size = new System.Drawing.Size(306, 86);
            this.lcgSalesFilter.Text = "Sales Filter";
            this.lcgSalesFilter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // rgOrdering
            // 
            this.rgOrdering.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgOrderingActions});
            this.rgOrdering.Name = "rgOrdering";
            this.rgOrdering.Text = "Ordering";
            // 
            // rpgOrderingActions
            // 
            this.rpgOrderingActions.ItemLinks.Add(this.btnCalculate);
            this.rpgOrderingActions.ItemLinks.Add(this.btnCancelOrder);
            this.rpgOrderingActions.ItemLinks.Add(this.btnOrder);
            this.rpgOrderingActions.Name = "rpgOrderingActions";
            this.rpgOrderingActions.Text = "Actions";
            // 
            // btnOrder
            // 
            this.btnOrder.Caption = "Order";
            this.btnOrder.Glyph = global::CDS.Client.Desktop.Ordering.Properties.Resources.document_order_new_16;
            this.btnOrder.Id = 26;
            this.btnOrder.LargeGlyph = global::CDS.Client.Desktop.Ordering.Properties.Resources.document_order_new_32;
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOrder_ItemClick);
            // 
            // lcgCategoryFilter
            // 
            this.lcgCategoryFilter.CustomizationFormText = "Category Filter";
            this.lcgCategoryFilter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCategoryTo,
            this.itmCategoryFrom});
            this.lcgCategoryFilter.Location = new System.Drawing.Point(0, 70);
            this.lcgCategoryFilter.Name = "lcgCategoryFilter";
            this.lcgCategoryFilter.Size = new System.Drawing.Size(505, 67);
            this.lcgCategoryFilter.Text = "Category Filter";
            // 
            // AutomaticOrderingForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.Name = "AutomaticOrderingForm";
            this.ShouldRecover = true;
            this.SuperTipParameter = "Order";
            this.TabIcon = global::CDS.Client.Desktop.Ordering.Properties.Resources.truck_blue_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Ordering.Properties.Resources.truck_blue_16;
            this.Text = "Order";
            this.WaitFormNewRecordDescription = "Creating new Order...";
            this.WaitFormOpenRecordDescription = "Opening Order...";
            this.VisibleChanged += new System.EventHandler(this.AutomaticOrderingForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCodeFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCodeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCodeTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCodeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgSupplierFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSingleSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMultipleSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight12.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight24.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthWeight36.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonthWeight36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgItems.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSalesFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgWeights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSalesFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCategoryFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCategoryTo;
        private DevExpress.XtraEditors.TextEdit txtCategoryFrom;
        private DevExpress.XtraEditors.TextEdit txtSupplierCodeTo;
        private DevExpress.XtraEditors.TextEdit txtSupplierCodeFrom;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem itmCodeFrom;
        private DevExpress.XtraLayout.LayoutControlItem itmCodeTo;
        private DevExpress.XtraLayout.LayoutControlItem itmCategoryFrom;
        private DevExpress.XtraLayout.LayoutControlItem itmCategoryTo;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsContact;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesContact;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraLayout.TabbedControlGroup tcgSupplierFilter;
        private DevExpress.XtraLayout.LayoutControlGroup tabSingleSupplier;
        private DevExpress.XtraLayout.LayoutControlItem lciSupplier;
        private DevExpress.XtraLayout.LayoutControlGroup tabMultipleSuppliers;
        private DevExpress.XtraEditors.RadioGroup rgItems;
        private DevExpress.XtraEditors.TextEdit txtMonthWeight36;
        private DevExpress.XtraEditors.TextEdit txtMonthWeight24;
        private DevExpress.XtraEditors.TextEdit txtMonthWeight12;
        private DevExpress.XtraEditors.TextEdit txtMonthWeight6;
        private DevExpress.XtraEditors.TextEdit txtMonthWeight3;
        private DevExpress.XtraGrid.GridControl grdOrderItems;
        private DevExpress.XtraGrid.Views.Grid.GridView grvOrderItems;
        private DevExpress.XtraLayout.LayoutControlItem itmGridItems;
        private DevExpress.XtraLayout.LayoutControlItem itmMonthWeight3;
        private DevExpress.XtraLayout.LayoutControlItem itmMonthWeight6;
        private DevExpress.XtraLayout.LayoutControlItem itmMonthWeight12;
        private DevExpress.XtraLayout.LayoutControlItem itmMonthWeight24;
        private DevExpress.XtraLayout.LayoutControlItem itmMonthWeight36;
        private DevExpress.XtraLayout.LayoutControlItem lciItems;
        private DevExpress.XtraEditors.RadioGroup rgSales;
        private DevExpress.XtraLayout.LayoutControlItem lciSalesFilter;
        private DevExpress.XtraBars.BarButtonItem btnCalculate;
        private System.Windows.Forms.BindingSource BindingSourceLines;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand;
        private DevExpress.XtraGrid.Columns.GridColumn colOnReserve;
        private DevExpress.XtraGrid.Columns.GridColumn colOnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colSafetyStock;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colEOQ;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderPoint;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceSupplierRepository;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colAvgDemand;
        private DevExpress.XtraBars.BarButtonItem btnCancelOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderAmountCalculated;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitAverage;
        private DevExpress.XtraLayout.LayoutControlGroup lcgWeights;
        private System.Windows.Forms.Timer AutoSaveTimer;
        private System.Windows.Forms.BindingSource BindingSourceFilters;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgItems;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSalesFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPage rgOrdering;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOrderingActions;
        private DevExpress.XtraBars.BarButtonItem btnOrder;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCategoryFilter;
    }
}
