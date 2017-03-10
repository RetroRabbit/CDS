namespace CDS.Client.Desktop.Workshop.Job
{
    partial class JobForm
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
            this.BindingSourceLine = new System.Windows.Forms.BindingSource();
            this.BindingSourceTransaction = new System.Windows.Forms.BindingSource();
            this.grdItems = new DevExpress.XtraGrid.GridControl();
            this.grvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLineEntity = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repViewEntity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSearchType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchSupplierStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchSubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchStockType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchLocationMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchLocationSecondary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchDiscountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchGrouping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchProfitMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchOnReserve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchOnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchUnitAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSearchBalanceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNumber = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceChanged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XPInstantFeedbackSourceItem = new DevExpress.Xpo.XPInstantFeedbackSource();
            this.InstantFeedbackSourceItem = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.ddlCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.InstantFeedbackSourceCompany = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTelephone = new DevExpress.XtraEditors.TextEdit();
            this.txtContactPerson = new DevExpress.XtraEditors.TextEdit();
            this.txtContactTelephone = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort1 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort2 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort3 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort4 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort5 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort6 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort7 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort8 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort9 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceShort10 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceLong1 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceLong2 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceLong3 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceLong4 = new DevExpress.XtraEditors.TextEdit();
            this.txtReferenceLong5 = new DevExpress.XtraEditors.TextEdit();
            this.txtBillingAddressLine1 = new DevExpress.XtraEditors.TextEdit();
            this.txtBillingAddressLine2 = new DevExpress.XtraEditors.TextEdit();
            this.txtBillingAddressLine3 = new DevExpress.XtraEditors.TextEdit();
            this.txtBillingAddressLine4 = new DevExpress.XtraEditors.TextEdit();
            this.txtBillingAddressCode = new DevExpress.XtraEditors.TextEdit();
            this.txtShippingAddressLine1 = new DevExpress.XtraEditors.TextEdit();
            this.txtShippingAddressLine2 = new DevExpress.XtraEditors.TextEdit();
            this.txtShippingAddressLine3 = new DevExpress.XtraEditors.TextEdit();
            this.txtShippingAddressLine4 = new DevExpress.XtraEditors.TextEdit();
            this.txtShippingAddressCode = new DevExpress.XtraEditors.TextEdit();
            this.itmGridLines = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgJobDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmTelephone = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmContactPerson = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmContactTelephone = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceLong1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceLong2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceLong3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceLong4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceLong5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.icgBillingAddress = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmBillingAddressLine1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmBillingAddressLine2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmBillingAddressLine3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmBillingAddressLine4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmBillingAddressCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmDate1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtDate1 = new DevExpress.XtraEditors.DateEdit();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.itmReferenceShort3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmReferenceShort6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator3 = new DevExpress.XtraLayout.SimpleSeparator();
            this.icgShippingAddress = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmShippingAddressLine1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmShippingAddressLine2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmShippingAddressLine3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmShippingAddressLine4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmShippingAddressCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmDate2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDate2 = new DevExpress.XtraEditors.DateEdit();
            this.itmDate3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDate3 = new DevExpress.XtraEditors.DateEdit();
            this.btnCreateSalesOrder = new DevExpress.XtraBars.BarButtonItem();
            this.popOrder = new DevExpress.XtraBars.PopupMenu();
            this.btnViewSalesOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateQuote = new DevExpress.XtraBars.BarButtonItem();
            this.popQuote = new DevExpress.XtraBars.PopupMenu();
            this.btnViewQuotes = new DevExpress.XtraBars.BarButtonItem();
            this.rpDocument = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgActionDocument = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnRemoveItem = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactTelephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgJobDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmContactPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmContactTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icgBillingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icgShippingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate3.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popQuote)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Header);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtDate3);
            this.LayoutControl.Controls.Add(this.txtDate2);
            this.LayoutControl.Controls.Add(this.dtDate1);
            this.LayoutControl.Controls.Add(this.txtShippingAddressCode);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine4);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine3);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine2);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine1);
            this.LayoutControl.Controls.Add(this.txtBillingAddressCode);
            this.LayoutControl.Controls.Add(this.txtBillingAddressLine4);
            this.LayoutControl.Controls.Add(this.txtBillingAddressLine3);
            this.LayoutControl.Controls.Add(this.txtBillingAddressLine2);
            this.LayoutControl.Controls.Add(this.txtBillingAddressLine1);
            this.LayoutControl.Controls.Add(this.txtReferenceLong5);
            this.LayoutControl.Controls.Add(this.txtReferenceLong4);
            this.LayoutControl.Controls.Add(this.txtReferenceLong3);
            this.LayoutControl.Controls.Add(this.txtReferenceLong2);
            this.LayoutControl.Controls.Add(this.txtReferenceLong1);
            this.LayoutControl.Controls.Add(this.txtReferenceShort10);
            this.LayoutControl.Controls.Add(this.txtReferenceShort9);
            this.LayoutControl.Controls.Add(this.txtReferenceShort8);
            this.LayoutControl.Controls.Add(this.txtReferenceShort7);
            this.LayoutControl.Controls.Add(this.txtReferenceShort6);
            this.LayoutControl.Controls.Add(this.txtReferenceShort5);
            this.LayoutControl.Controls.Add(this.txtReferenceShort4);
            this.LayoutControl.Controls.Add(this.txtReferenceShort3);
            this.LayoutControl.Controls.Add(this.txtReferenceShort2);
            this.LayoutControl.Controls.Add(this.txtReferenceShort1);
            this.LayoutControl.Controls.Add(this.txtContactTelephone);
            this.LayoutControl.Controls.Add(this.txtContactPerson);
            this.LayoutControl.Controls.Add(this.txtTelephone);
            this.LayoutControl.Controls.Add(this.ddlCompany);
            this.LayoutControl.Controls.Add(this.grdItems);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(3227, 125, 480, 823);
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
            this.itmGridLines,
            this.lcgJobDetail});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(1008, 584);
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCreateSalesOrder,
            this.btnViewSalesOrder,
            this.btnCreateQuote,
            this.btnViewQuotes,
            this.btnRemoveItem});
            this.RibbonControl.MaxItemId = 29;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpDocument});
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
            // BindingSourceLine
            // 
            this.BindingSourceLine.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Line);
            // 
            // BindingSourceTransaction
            // 
            this.BindingSourceTransaction.DataSource = typeof(CDS.Client.DataAccessLayer.DB.JOB_Header);
            // 
            // grdItems
            // 
            this.grdItems.DataSource = this.BindingSourceLine;
            this.grdItems.Location = new System.Drawing.Point(12, 295);
            this.grdItems.MainView = this.grvItems;
            this.grdItems.MenuManager = this.RibbonControl;
            this.grdItems.Name = "grdItems";
            this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLineEntity,
            this.repNumber});
            this.grdItems.Size = new System.Drawing.Size(984, 277);
            this.grdItems.TabIndex = 4;
            this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvItems});
            // 
            // grvItems
            // 
            this.grvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineOrder,
            this.colItemId,
            this.colDescription,
            this.colQuantity,
            this.colAmount,
            this.colPriceChanged});
            this.grvItems.GridControl = this.grdItems;
            this.grvItems.Name = "grvItems";
            this.grvItems.OptionsBehavior.Editable = false;
            this.grvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvItems.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvItems.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvItems.OptionsView.ShowFooter = true;
            this.grvItems.OptionsView.ShowGroupPanel = false;
            this.grvItems.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvItems_ShowingEditor);
            this.grvItems.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvItems_InitNewRow);
            this.grvItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvItems_CellValueChanged);
            this.grvItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvItems_KeyDown);
            // 
            // colLineOrder
            // 
            this.colLineOrder.Caption = " ";
            this.colLineOrder.FieldName = "LineOrder";
            this.colLineOrder.MaxWidth = 20;
            this.colLineOrder.Name = "colLineOrder";
            this.colLineOrder.Width = 20;
            // 
            // colItemId
            // 
            this.colItemId.Caption = "Item";
            this.colItemId.ColumnEdit = this.repLineEntity;
            this.colItemId.FieldName = "ItemId";
            this.colItemId.MinWidth = 130;
            this.colItemId.Name = "colItemId";
            this.colItemId.OptionsColumn.AllowMove = false;
            this.colItemId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colItemId.Visible = true;
            this.colItemId.VisibleIndex = 0;
            this.colItemId.Width = 143;
            // 
            // repLineEntity
            // 
            this.repLineEntity.AutoHeight = false;
            this.repLineEntity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLineEntity.DisplayMember = "Title";
            this.repLineEntity.Name = "repLineEntity";
            this.repLineEntity.NullText = "Select Item ...";
            this.repLineEntity.ValueMember = "Id";
            this.repLineEntity.View = this.repViewEntity;
            this.repLineEntity.Popup += new System.EventHandler(this.repLineEntity_Popup);
            this.repLineEntity.EditValueChanged += new System.EventHandler(this.repLineEntity_EditValueChanged);
            // 
            // repViewEntity
            // 
            this.repViewEntity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSearchType,
            this.colSearchShortName,
            this.colSearchName,
            this.colSearchDescription,
            this.colSearchSupplierStockCode,
            this.colSearchCategory,
            this.colSearchSubCategory,
            this.colSearchStockType,
            this.colSearchLocationMain,
            this.colSearchLocationSecondary,
            this.colSearchDiscountCode,
            this.colSearchGrouping,
            this.colSearchProfitMargin,
            this.colSearchOnHand,
            this.colSearchOnReserve,
            this.colSearchOnOrder,
            this.colSearchUnitPrice,
            this.colSearchUnitCost,
            this.colSearchUnitAverage,
            this.colSearchBalanceAmount});
            this.repViewEntity.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repViewEntity.Name = "repViewEntity";
            this.repViewEntity.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.repViewEntity.OptionsFind.ClearFindOnClose = false;
            this.repViewEntity.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repViewEntity.OptionsView.ShowGroupPanel = false;
            this.repViewEntity.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSearchType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSearchName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSearchType
            // 
            this.colSearchType.Caption = "Type";
            this.colSearchType.FieldName = "Type";
            this.colSearchType.Name = "colSearchType";
            this.colSearchType.Visible = true;
            this.colSearchType.VisibleIndex = 0;
            this.colSearchType.Width = 157;
            // 
            // colSearchShortName
            // 
            this.colSearchShortName.Caption = "Name";
            this.colSearchShortName.FieldName = "ShortName";
            this.colSearchShortName.Name = "colSearchShortName";
            this.colSearchShortName.Visible = true;
            this.colSearchShortName.VisibleIndex = 2;
            this.colSearchShortName.Width = 238;
            // 
            // colSearchName
            // 
            this.colSearchName.Caption = "Code";
            this.colSearchName.FieldName = "Name";
            this.colSearchName.Name = "colSearchName";
            this.colSearchName.Visible = true;
            this.colSearchName.VisibleIndex = 1;
            this.colSearchName.Width = 195;
            // 
            // colSearchDescription
            // 
            this.colSearchDescription.FieldName = "Description";
            this.colSearchDescription.Name = "colSearchDescription";
            this.colSearchDescription.Visible = true;
            this.colSearchDescription.VisibleIndex = 3;
            this.colSearchDescription.Width = 228;
            // 
            // colSearchSupplierStockCode
            // 
            this.colSearchSupplierStockCode.FieldName = "SupplierStockCode";
            this.colSearchSupplierStockCode.Name = "colSearchSupplierStockCode";
            // 
            // colSearchCategory
            // 
            this.colSearchCategory.FieldName = "Category";
            this.colSearchCategory.Name = "colSearchCategory";
            this.colSearchCategory.Visible = true;
            this.colSearchCategory.VisibleIndex = 4;
            this.colSearchCategory.Width = 108;
            // 
            // colSearchSubCategory
            // 
            this.colSearchSubCategory.FieldName = "SubCategory";
            this.colSearchSubCategory.Name = "colSearchSubCategory";
            // 
            // colSearchStockType
            // 
            this.colSearchStockType.FieldName = "StockType";
            this.colSearchStockType.Name = "colSearchStockType";
            this.colSearchStockType.Width = 105;
            // 
            // colSearchLocationMain
            // 
            this.colSearchLocationMain.FieldName = "LocationMain";
            this.colSearchLocationMain.Name = "colSearchLocationMain";
            this.colSearchLocationMain.Visible = true;
            this.colSearchLocationMain.VisibleIndex = 5;
            this.colSearchLocationMain.Width = 108;
            // 
            // colSearchLocationSecondary
            // 
            this.colSearchLocationSecondary.FieldName = "LocationSecondary";
            this.colSearchLocationSecondary.Name = "colSearchLocationSecondary";
            // 
            // colSearchDiscountCode
            // 
            this.colSearchDiscountCode.FieldName = "DiscountCode";
            this.colSearchDiscountCode.Name = "colSearchDiscountCode";
            this.colSearchDiscountCode.Visible = true;
            this.colSearchDiscountCode.VisibleIndex = 6;
            this.colSearchDiscountCode.Width = 108;
            // 
            // colSearchGrouping
            // 
            this.colSearchGrouping.FieldName = "Grouping";
            this.colSearchGrouping.Name = "colSearchGrouping";
            // 
            // colSearchProfitMargin
            // 
            this.colSearchProfitMargin.FieldName = "ProfitMargin";
            this.colSearchProfitMargin.Name = "colSearchProfitMargin";
            // 
            // colSearchOnHand
            // 
            this.colSearchOnHand.FieldName = "OnHand";
            this.colSearchOnHand.Name = "colSearchOnHand";
            this.colSearchOnHand.Visible = true;
            this.colSearchOnHand.VisibleIndex = 7;
            this.colSearchOnHand.Width = 108;
            // 
            // colSearchOnReserve
            // 
            this.colSearchOnReserve.FieldName = "OnReserve";
            this.colSearchOnReserve.Name = "colSearchOnReserve";
            this.colSearchOnReserve.Visible = true;
            this.colSearchOnReserve.VisibleIndex = 9;
            this.colSearchOnReserve.Width = 105;
            // 
            // colSearchOnOrder
            // 
            this.colSearchOnOrder.FieldName = "OnOrder";
            this.colSearchOnOrder.Name = "colSearchOnOrder";
            this.colSearchOnOrder.Visible = true;
            this.colSearchOnOrder.VisibleIndex = 8;
            this.colSearchOnOrder.Width = 105;
            // 
            // colSearchUnitPrice
            // 
            this.colSearchUnitPrice.FieldName = "UnitPrice";
            this.colSearchUnitPrice.Name = "colSearchUnitPrice";
            this.colSearchUnitPrice.Visible = true;
            this.colSearchUnitPrice.VisibleIndex = 10;
            this.colSearchUnitPrice.Width = 108;
            // 
            // colSearchUnitCost
            // 
            this.colSearchUnitCost.FieldName = "UnitCost";
            this.colSearchUnitCost.Name = "colSearchUnitCost";
            this.colSearchUnitCost.Visible = true;
            this.colSearchUnitCost.VisibleIndex = 11;
            this.colSearchUnitCost.Width = 108;
            // 
            // colSearchUnitAverage
            // 
            this.colSearchUnitAverage.FieldName = "UnitAverage";
            this.colSearchUnitAverage.Name = "colSearchUnitAverage";
            this.colSearchUnitAverage.Visible = true;
            this.colSearchUnitAverage.VisibleIndex = 12;
            this.colSearchUnitAverage.Width = 108;
            // 
            // colSearchBalanceAmount
            // 
            this.colSearchBalanceAmount.FieldName = "AccountBalance";
            this.colSearchBalanceAmount.Name = "colSearchBalanceAmount";
            this.colSearchBalanceAmount.Visible = true;
            this.colSearchBalanceAmount.VisibleIndex = 13;
            this.colSearchBalanceAmount.Width = 149;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 838;
            // 
            // colQuantity
            // 
            this.colQuantity.ColumnEdit = this.repNumber;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 80;
            this.colQuantity.MinWidth = 60;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowMove = false;
            this.colQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:0.00}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 2;
            this.colQuantity.Width = 68;
            // 
            // repNumber
            // 
            this.repNumber.AutoHeight = false;
            this.repNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNumber.DisplayFormat.FormatString = "N2";
            this.repNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumber.EditFormat.FormatString = "N2";
            this.repNumber.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumber.Name = "repNumber";
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            // 
            // colPriceChanged
            // 
            this.colPriceChanged.DisplayFormat.FormatString = "N2";
            this.colPriceChanged.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPriceChanged.FieldName = "PriceChanged";
            this.colPriceChanged.MaxWidth = 80;
            this.colPriceChanged.MinWidth = 60;
            this.colPriceChanged.Name = "colPriceChanged";
            this.colPriceChanged.OptionsColumn.AllowEdit = false;
            this.colPriceChanged.OptionsColumn.AllowFocus = false;
            this.colPriceChanged.OptionsColumn.AllowMove = false;
            this.colPriceChanged.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPriceChanged.OptionsColumn.ReadOnly = true;
            this.colPriceChanged.Width = 20;
            // 
            // XPInstantFeedbackSourceItem
            // 
            this.XPInstantFeedbackSourceItem.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.SYS_Entity);
            // 
            // InstantFeedbackSourceItem
            // 
            this.InstantFeedbackSourceItem.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_LineItem);
            this.InstantFeedbackSourceItem.KeyExpression = "Id";
            this.InstantFeedbackSourceItem.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceItem_GetQueryable);
            // 
            // ddlCompany
            // 
            this.ddlCompany.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "CompanyId", true));
            this.ddlCompany.EnterMoveNextControl = true;
            this.ddlCompany.Location = new System.Drawing.Point(122, 43);
            this.ddlCompany.MenuManager = this.RibbonControl;
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCompany.Properties.DataSource = this.InstantFeedbackSourceCompany;
            this.ddlCompany.Properties.DisplayMember = "Title";
            this.ddlCompany.Properties.NullText = "Select Company ...";
            this.ddlCompany.Properties.ValueMember = "Id";
            this.ddlCompany.Properties.View = this.searchLookUpEdit1View;
            this.ddlCompany.Size = new System.Drawing.Size(409, 20);
            this.ddlCompany.StyleController = this.LayoutControl;
            this.ddlCompany.TabIndex = 5;
            this.ddlCompany.EditValueChanged += new System.EventHandler(this.ddlCompany_EditValueChanged);
            this.ddlCompany.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ddlCompany_EditValueChanging);
            this.ddlCompany.Leave += new System.EventHandler(this.ddlCompany_Leave);
            this.ddlCompany.Validated += new System.EventHandler(this.ddlCompany_Validated);
            // 
            // InstantFeedbackSourceCompany
            // 
            this.InstantFeedbackSourceCompany.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Company);
            this.InstantFeedbackSourceCompany.KeyExpression = "Id";
            this.InstantFeedbackSourceCompany.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceCompany_GetQueryable);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCode,
            this.colAreaCode,
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAreaCode, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAccountsContact, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAccountsTelephone, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSalesContact, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSalesTelephone, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colActive, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 120;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 25;
            // 
            // colAreaCode
            // 
            this.colAreaCode.FieldName = "AreaCode";
            this.colAreaCode.Name = "colAreaCode";
            this.colAreaCode.Visible = true;
            this.colAreaCode.VisibleIndex = 2;
            this.colAreaCode.Width = 49;
            // 
            // colAccountsContact
            // 
            this.colAccountsContact.FieldName = "AccountsContact";
            this.colAccountsContact.Name = "colAccountsContact";
            this.colAccountsContact.Visible = true;
            this.colAccountsContact.VisibleIndex = 3;
            this.colAccountsContact.Width = 33;
            // 
            // colAccountsTelephone
            // 
            this.colAccountsTelephone.FieldName = "AccountsTelephone";
            this.colAccountsTelephone.Name = "colAccountsTelephone";
            this.colAccountsTelephone.Visible = true;
            this.colAccountsTelephone.VisibleIndex = 4;
            this.colAccountsTelephone.Width = 33;
            // 
            // colSalesContact
            // 
            this.colSalesContact.FieldName = "SalesContact";
            this.colSalesContact.Name = "colSalesContact";
            this.colSalesContact.Visible = true;
            this.colSalesContact.VisibleIndex = 5;
            this.colSalesContact.Width = 33;
            // 
            // colSalesTelephone
            // 
            this.colSalesTelephone.FieldName = "SalesTelephone";
            this.colSalesTelephone.Name = "colSalesTelephone";
            this.colSalesTelephone.Visible = true;
            this.colSalesTelephone.VisibleIndex = 6;
            this.colSalesTelephone.Width = 33;
            // 
            // colActive
            // 
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 7;
            this.colActive.Width = 30;
            // 
            // txtTelephone
            // 
            this.txtTelephone.EnterMoveNextControl = true;
            this.txtTelephone.Location = new System.Drawing.Point(635, 43);
            this.txtTelephone.MenuManager = this.RibbonControl;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(349, 20);
            this.txtTelephone.StyleController = this.LayoutControl;
            this.txtTelephone.TabIndex = 6;
            this.txtTelephone.TabStop = false;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.EnterMoveNextControl = true;
            this.txtContactPerson.Location = new System.Drawing.Point(635, 67);
            this.txtContactPerson.MenuManager = this.RibbonControl;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(349, 20);
            this.txtContactPerson.StyleController = this.LayoutControl;
            this.txtContactPerson.TabIndex = 7;
            this.txtContactPerson.TabStop = false;
            // 
            // txtContactTelephone
            // 
            this.txtContactTelephone.EnterMoveNextControl = true;
            this.txtContactTelephone.Location = new System.Drawing.Point(635, 91);
            this.txtContactTelephone.MenuManager = this.RibbonControl;
            this.txtContactTelephone.Name = "txtContactTelephone";
            this.txtContactTelephone.Size = new System.Drawing.Size(349, 20);
            this.txtContactTelephone.StyleController = this.LayoutControl;
            this.txtContactTelephone.TabIndex = 8;
            this.txtContactTelephone.TabStop = false;
            // 
            // txtReferenceShort1
            // 
            this.txtReferenceShort1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort1", true));
            this.txtReferenceShort1.EnterMoveNextControl = true;
            this.txtReferenceShort1.Location = new System.Drawing.Point(122, 67);
            this.txtReferenceShort1.MenuManager = this.RibbonControl;
            this.txtReferenceShort1.Name = "txtReferenceShort1";
            this.txtReferenceShort1.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceShort1.StyleController = this.LayoutControl;
            this.txtReferenceShort1.TabIndex = 17;
            // 
            // txtReferenceShort2
            // 
            this.txtReferenceShort2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort2", true));
            this.txtReferenceShort2.EnterMoveNextControl = true;
            this.txtReferenceShort2.Location = new System.Drawing.Point(382, 67);
            this.txtReferenceShort2.MenuManager = this.RibbonControl;
            this.txtReferenceShort2.Name = "txtReferenceShort2";
            this.txtReferenceShort2.Size = new System.Drawing.Size(149, 20);
            this.txtReferenceShort2.StyleController = this.LayoutControl;
            this.txtReferenceShort2.TabIndex = 18;
            // 
            // txtReferenceShort3
            // 
            this.txtReferenceShort3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort3", true));
            this.txtReferenceShort3.EnterMoveNextControl = true;
            this.txtReferenceShort3.Location = new System.Drawing.Point(122, 91);
            this.txtReferenceShort3.MenuManager = this.RibbonControl;
            this.txtReferenceShort3.Name = "txtReferenceShort3";
            this.txtReferenceShort3.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceShort3.StyleController = this.LayoutControl;
            this.txtReferenceShort3.TabIndex = 19;
            // 
            // txtReferenceShort4
            // 
            this.txtReferenceShort4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort4", true));
            this.txtReferenceShort4.EnterMoveNextControl = true;
            this.txtReferenceShort4.Location = new System.Drawing.Point(382, 91);
            this.txtReferenceShort4.MenuManager = this.RibbonControl;
            this.txtReferenceShort4.Name = "txtReferenceShort4";
            this.txtReferenceShort4.Size = new System.Drawing.Size(149, 20);
            this.txtReferenceShort4.StyleController = this.LayoutControl;
            this.txtReferenceShort4.TabIndex = 20;
            // 
            // txtReferenceShort5
            // 
            this.txtReferenceShort5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort5", true));
            this.txtReferenceShort5.EnterMoveNextControl = true;
            this.txtReferenceShort5.Location = new System.Drawing.Point(122, 115);
            this.txtReferenceShort5.MenuManager = this.RibbonControl;
            this.txtReferenceShort5.Name = "txtReferenceShort5";
            this.txtReferenceShort5.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceShort5.StyleController = this.LayoutControl;
            this.txtReferenceShort5.TabIndex = 21;
            // 
            // txtReferenceShort6
            // 
            this.txtReferenceShort6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort6", true));
            this.txtReferenceShort6.EnterMoveNextControl = true;
            this.txtReferenceShort6.Location = new System.Drawing.Point(382, 115);
            this.txtReferenceShort6.MenuManager = this.RibbonControl;
            this.txtReferenceShort6.Name = "txtReferenceShort6";
            this.txtReferenceShort6.Size = new System.Drawing.Size(149, 20);
            this.txtReferenceShort6.StyleController = this.LayoutControl;
            this.txtReferenceShort6.TabIndex = 22;
            // 
            // txtReferenceShort7
            // 
            this.txtReferenceShort7.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort7", true));
            this.txtReferenceShort7.EnterMoveNextControl = true;
            this.txtReferenceShort7.Location = new System.Drawing.Point(122, 139);
            this.txtReferenceShort7.MenuManager = this.RibbonControl;
            this.txtReferenceShort7.Name = "txtReferenceShort7";
            this.txtReferenceShort7.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceShort7.StyleController = this.LayoutControl;
            this.txtReferenceShort7.TabIndex = 23;
            // 
            // txtReferenceShort8
            // 
            this.txtReferenceShort8.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort8", true));
            this.txtReferenceShort8.EnterMoveNextControl = true;
            this.txtReferenceShort8.Location = new System.Drawing.Point(382, 139);
            this.txtReferenceShort8.MenuManager = this.RibbonControl;
            this.txtReferenceShort8.Name = "txtReferenceShort8";
            this.txtReferenceShort8.Size = new System.Drawing.Size(149, 20);
            this.txtReferenceShort8.StyleController = this.LayoutControl;
            this.txtReferenceShort8.TabIndex = 24;
            // 
            // txtReferenceShort9
            // 
            this.txtReferenceShort9.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort9", true));
            this.txtReferenceShort9.EnterMoveNextControl = true;
            this.txtReferenceShort9.Location = new System.Drawing.Point(122, 163);
            this.txtReferenceShort9.MenuManager = this.RibbonControl;
            this.txtReferenceShort9.Name = "txtReferenceShort9";
            this.txtReferenceShort9.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceShort9.StyleController = this.LayoutControl;
            this.txtReferenceShort9.TabIndex = 25;
            // 
            // txtReferenceShort10
            // 
            this.txtReferenceShort10.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort10", true));
            this.txtReferenceShort10.EnterMoveNextControl = true;
            this.txtReferenceShort10.Location = new System.Drawing.Point(382, 163);
            this.txtReferenceShort10.MenuManager = this.RibbonControl;
            this.txtReferenceShort10.Name = "txtReferenceShort10";
            this.txtReferenceShort10.Size = new System.Drawing.Size(149, 20);
            this.txtReferenceShort10.StyleController = this.LayoutControl;
            this.txtReferenceShort10.TabIndex = 26;
            // 
            // txtReferenceLong1
            // 
            this.txtReferenceLong1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong1", true));
            this.txtReferenceLong1.EnterMoveNextControl = true;
            this.txtReferenceLong1.Location = new System.Drawing.Point(122, 187);
            this.txtReferenceLong1.MenuManager = this.RibbonControl;
            this.txtReferenceLong1.Name = "txtReferenceLong1";
            this.txtReferenceLong1.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceLong1.StyleController = this.LayoutControl;
            this.txtReferenceLong1.TabIndex = 27;
            // 
            // txtReferenceLong2
            // 
            this.txtReferenceLong2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong2", true));
            this.txtReferenceLong2.EnterMoveNextControl = true;
            this.txtReferenceLong2.Location = new System.Drawing.Point(382, 187);
            this.txtReferenceLong2.MenuManager = this.RibbonControl;
            this.txtReferenceLong2.Name = "txtReferenceLong2";
            this.txtReferenceLong2.Size = new System.Drawing.Size(149, 20);
            this.txtReferenceLong2.StyleController = this.LayoutControl;
            this.txtReferenceLong2.TabIndex = 28;
            // 
            // txtReferenceLong3
            // 
            this.txtReferenceLong3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong3", true));
            this.txtReferenceLong3.EnterMoveNextControl = true;
            this.txtReferenceLong3.Location = new System.Drawing.Point(122, 211);
            this.txtReferenceLong3.MenuManager = this.RibbonControl;
            this.txtReferenceLong3.Name = "txtReferenceLong3";
            this.txtReferenceLong3.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceLong3.StyleController = this.LayoutControl;
            this.txtReferenceLong3.TabIndex = 29;
            // 
            // txtReferenceLong4
            // 
            this.txtReferenceLong4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong4", true));
            this.txtReferenceLong4.EnterMoveNextControl = true;
            this.txtReferenceLong4.Location = new System.Drawing.Point(382, 211);
            this.txtReferenceLong4.MenuManager = this.RibbonControl;
            this.txtReferenceLong4.Name = "txtReferenceLong4";
            this.txtReferenceLong4.Size = new System.Drawing.Size(149, 20);
            this.txtReferenceLong4.StyleController = this.LayoutControl;
            this.txtReferenceLong4.TabIndex = 30;
            // 
            // txtReferenceLong5
            // 
            this.txtReferenceLong5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong5", true));
            this.txtReferenceLong5.EnterMoveNextControl = true;
            this.txtReferenceLong5.Location = new System.Drawing.Point(122, 235);
            this.txtReferenceLong5.MenuManager = this.RibbonControl;
            this.txtReferenceLong5.Name = "txtReferenceLong5";
            this.txtReferenceLong5.Size = new System.Drawing.Size(156, 20);
            this.txtReferenceLong5.StyleController = this.LayoutControl;
            this.txtReferenceLong5.TabIndex = 31;
            // 
            // txtBillingAddressLine1
            // 
            this.txtBillingAddressLine1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine1", true));
            this.txtBillingAddressLine1.Location = new System.Drawing.Point(647, 146);
            this.txtBillingAddressLine1.MenuManager = this.RibbonControl;
            this.txtBillingAddressLine1.Name = "txtBillingAddressLine1";
            this.txtBillingAddressLine1.Size = new System.Drawing.Size(101, 20);
            this.txtBillingAddressLine1.StyleController = this.LayoutControl;
            this.txtBillingAddressLine1.TabIndex = 32;
            this.txtBillingAddressLine1.TabStop = false;
            // 
            // txtBillingAddressLine2
            // 
            this.txtBillingAddressLine2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine2", true));
            this.txtBillingAddressLine2.Location = new System.Drawing.Point(647, 170);
            this.txtBillingAddressLine2.MenuManager = this.RibbonControl;
            this.txtBillingAddressLine2.Name = "txtBillingAddressLine2";
            this.txtBillingAddressLine2.Size = new System.Drawing.Size(101, 20);
            this.txtBillingAddressLine2.StyleController = this.LayoutControl;
            this.txtBillingAddressLine2.TabIndex = 33;
            this.txtBillingAddressLine2.TabStop = false;
            // 
            // txtBillingAddressLine3
            // 
            this.txtBillingAddressLine3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine3", true));
            this.txtBillingAddressLine3.Location = new System.Drawing.Point(647, 194);
            this.txtBillingAddressLine3.MenuManager = this.RibbonControl;
            this.txtBillingAddressLine3.Name = "txtBillingAddressLine3";
            this.txtBillingAddressLine3.Size = new System.Drawing.Size(101, 20);
            this.txtBillingAddressLine3.StyleController = this.LayoutControl;
            this.txtBillingAddressLine3.TabIndex = 34;
            this.txtBillingAddressLine3.TabStop = false;
            // 
            // txtBillingAddressLine4
            // 
            this.txtBillingAddressLine4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine4", true));
            this.txtBillingAddressLine4.Location = new System.Drawing.Point(647, 218);
            this.txtBillingAddressLine4.MenuManager = this.RibbonControl;
            this.txtBillingAddressLine4.Name = "txtBillingAddressLine4";
            this.txtBillingAddressLine4.Size = new System.Drawing.Size(101, 20);
            this.txtBillingAddressLine4.StyleController = this.LayoutControl;
            this.txtBillingAddressLine4.TabIndex = 35;
            this.txtBillingAddressLine4.TabStop = false;
            // 
            // txtBillingAddressCode
            // 
            this.txtBillingAddressCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressCode", true));
            this.txtBillingAddressCode.Location = new System.Drawing.Point(647, 242);
            this.txtBillingAddressCode.MenuManager = this.RibbonControl;
            this.txtBillingAddressCode.Name = "txtBillingAddressCode";
            this.txtBillingAddressCode.Size = new System.Drawing.Size(101, 20);
            this.txtBillingAddressCode.StyleController = this.LayoutControl;
            this.txtBillingAddressCode.TabIndex = 36;
            this.txtBillingAddressCode.TabStop = false;
            // 
            // txtShippingAddressLine1
            // 
            this.txtShippingAddressLine1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine1", true));
            this.txtShippingAddressLine1.Location = new System.Drawing.Point(874, 146);
            this.txtShippingAddressLine1.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine1.Name = "txtShippingAddressLine1";
            this.txtShippingAddressLine1.Size = new System.Drawing.Size(98, 20);
            this.txtShippingAddressLine1.StyleController = this.LayoutControl;
            this.txtShippingAddressLine1.TabIndex = 37;
            this.txtShippingAddressLine1.TabStop = false;
            // 
            // txtShippingAddressLine2
            // 
            this.txtShippingAddressLine2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine2", true));
            this.txtShippingAddressLine2.Location = new System.Drawing.Point(874, 170);
            this.txtShippingAddressLine2.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine2.Name = "txtShippingAddressLine2";
            this.txtShippingAddressLine2.Size = new System.Drawing.Size(98, 20);
            this.txtShippingAddressLine2.StyleController = this.LayoutControl;
            this.txtShippingAddressLine2.TabIndex = 38;
            this.txtShippingAddressLine2.TabStop = false;
            // 
            // txtShippingAddressLine3
            // 
            this.txtShippingAddressLine3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine3", true));
            this.txtShippingAddressLine3.Location = new System.Drawing.Point(874, 194);
            this.txtShippingAddressLine3.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine3.Name = "txtShippingAddressLine3";
            this.txtShippingAddressLine3.Size = new System.Drawing.Size(98, 20);
            this.txtShippingAddressLine3.StyleController = this.LayoutControl;
            this.txtShippingAddressLine3.TabIndex = 39;
            this.txtShippingAddressLine3.TabStop = false;
            // 
            // txtShippingAddressLine4
            // 
            this.txtShippingAddressLine4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine4", true));
            this.txtShippingAddressLine4.Location = new System.Drawing.Point(874, 218);
            this.txtShippingAddressLine4.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine4.Name = "txtShippingAddressLine4";
            this.txtShippingAddressLine4.Size = new System.Drawing.Size(98, 20);
            this.txtShippingAddressLine4.StyleController = this.LayoutControl;
            this.txtShippingAddressLine4.TabIndex = 40;
            this.txtShippingAddressLine4.TabStop = false;
            // 
            // txtShippingAddressCode
            // 
            this.txtShippingAddressCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressCode", true));
            this.txtShippingAddressCode.Location = new System.Drawing.Point(874, 242);
            this.txtShippingAddressCode.MenuManager = this.RibbonControl;
            this.txtShippingAddressCode.Name = "txtShippingAddressCode";
            this.txtShippingAddressCode.Size = new System.Drawing.Size(98, 20);
            this.txtShippingAddressCode.StyleController = this.LayoutControl;
            this.txtShippingAddressCode.TabIndex = 41;
            this.txtShippingAddressCode.TabStop = false;
            // 
            // itmGridLines
            // 
            this.itmGridLines.Control = this.grdItems;
            this.itmGridLines.CustomizationFormText = "itmGridLines";
            this.itmGridLines.Location = new System.Drawing.Point(0, 283);
            this.itmGridLines.Name = "itmGridLines";
            this.itmGridLines.Size = new System.Drawing.Size(988, 281);
            this.itmGridLines.Text = "itmGridLines";
            this.itmGridLines.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridLines.TextVisible = false;
            // 
            // lcgJobDetail
            // 
            this.lcgJobDetail.CustomizationFormText = "Job Detail";
            this.lcgJobDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCompany,
            this.itmTelephone,
            this.itmContactPerson,
            this.itmContactTelephone,
            this.itmReferenceShort1,
            this.itmReferenceShort7,
            this.itmReferenceShort8,
            this.itmReferenceShort9,
            this.itmReferenceShort10,
            this.itmReferenceLong1,
            this.itmReferenceLong2,
            this.itmReferenceLong3,
            this.itmReferenceLong4,
            this.itmReferenceLong5,
            this.icgBillingAddress,
            this.itmDate1,
            this.simpleSeparator1,
            this.itmReferenceShort3,
            this.itmReferenceShort2,
            this.itmReferenceShort4,
            this.itmReferenceShort5,
            this.itmReferenceShort6,
            this.simpleSeparator3,
            this.icgShippingAddress,
            this.itmDate2,
            this.itmDate3});
            this.lcgJobDetail.Location = new System.Drawing.Point(0, 0);
            this.lcgJobDetail.Name = "lcgJobDetail";
            this.lcgJobDetail.Size = new System.Drawing.Size(988, 283);
            this.lcgJobDetail.Text = "Job Detail";
            // 
            // itmCompany
            // 
            this.itmCompany.Control = this.ddlCompany;
            this.itmCompany.CustomizationFormText = "Company";
            this.itmCompany.Location = new System.Drawing.Point(0, 0);
            this.itmCompany.Name = "itmCompany";
            this.itmCompany.Size = new System.Drawing.Size(511, 24);
            this.itmCompany.Text = "Company";
            this.itmCompany.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmTelephone
            // 
            this.itmTelephone.Control = this.txtTelephone;
            this.itmTelephone.CustomizationFormText = "Telephone";
            this.itmTelephone.Location = new System.Drawing.Point(513, 0);
            this.itmTelephone.Name = "itmTelephone";
            this.itmTelephone.Size = new System.Drawing.Size(451, 24);
            this.itmTelephone.Text = "Telephone";
            this.itmTelephone.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmContactPerson
            // 
            this.itmContactPerson.Control = this.txtContactPerson;
            this.itmContactPerson.CustomizationFormText = "Contact Person";
            this.itmContactPerson.Location = new System.Drawing.Point(513, 24);
            this.itmContactPerson.Name = "itmContactPerson";
            this.itmContactPerson.Size = new System.Drawing.Size(451, 24);
            this.itmContactPerson.Text = "Contact Person";
            this.itmContactPerson.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmContactTelephone
            // 
            this.itmContactTelephone.Control = this.txtContactTelephone;
            this.itmContactTelephone.CustomizationFormText = "Contact Telephone";
            this.itmContactTelephone.Location = new System.Drawing.Point(513, 48);
            this.itmContactTelephone.Name = "itmContactTelephone";
            this.itmContactTelephone.Size = new System.Drawing.Size(451, 24);
            this.itmContactTelephone.Text = "Contact Telephone";
            this.itmContactTelephone.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort1
            // 
            this.itmReferenceShort1.Control = this.txtReferenceShort1;
            this.itmReferenceShort1.CustomizationFormText = "Reference Short 1";
            this.itmReferenceShort1.Location = new System.Drawing.Point(0, 24);
            this.itmReferenceShort1.Name = "itmReferenceShort1";
            this.itmReferenceShort1.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceShort1.Text = "Reference Short 1";
            this.itmReferenceShort1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort7
            // 
            this.itmReferenceShort7.Control = this.txtReferenceShort7;
            this.itmReferenceShort7.CustomizationFormText = "Reference Short 7";
            this.itmReferenceShort7.Location = new System.Drawing.Point(0, 96);
            this.itmReferenceShort7.Name = "itmReferenceShort7";
            this.itmReferenceShort7.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceShort7.Text = "Reference Short 7";
            this.itmReferenceShort7.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort8
            // 
            this.itmReferenceShort8.Control = this.txtReferenceShort8;
            this.itmReferenceShort8.CustomizationFormText = "Reference Short 8";
            this.itmReferenceShort8.Location = new System.Drawing.Point(260, 96);
            this.itmReferenceShort8.Name = "itmReferenceShort8";
            this.itmReferenceShort8.Size = new System.Drawing.Size(251, 24);
            this.itmReferenceShort8.Text = "Reference Short 8";
            this.itmReferenceShort8.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort9
            // 
            this.itmReferenceShort9.Control = this.txtReferenceShort9;
            this.itmReferenceShort9.CustomizationFormText = "Reference Short 9";
            this.itmReferenceShort9.Location = new System.Drawing.Point(0, 120);
            this.itmReferenceShort9.Name = "itmReferenceShort9";
            this.itmReferenceShort9.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceShort9.Text = "Reference Short 9";
            this.itmReferenceShort9.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort10
            // 
            this.itmReferenceShort10.Control = this.txtReferenceShort10;
            this.itmReferenceShort10.CustomizationFormText = "Reference Short 10";
            this.itmReferenceShort10.Location = new System.Drawing.Point(260, 120);
            this.itmReferenceShort10.Name = "itmReferenceShort10";
            this.itmReferenceShort10.Size = new System.Drawing.Size(251, 24);
            this.itmReferenceShort10.Text = "Reference Short 10";
            this.itmReferenceShort10.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceLong1
            // 
            this.itmReferenceLong1.Control = this.txtReferenceLong1;
            this.itmReferenceLong1.CustomizationFormText = "Reference Long 1";
            this.itmReferenceLong1.Location = new System.Drawing.Point(0, 144);
            this.itmReferenceLong1.Name = "itmReferenceLong1";
            this.itmReferenceLong1.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceLong1.Text = "Reference Long 1";
            this.itmReferenceLong1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceLong2
            // 
            this.itmReferenceLong2.Control = this.txtReferenceLong2;
            this.itmReferenceLong2.CustomizationFormText = "Reference Long 2";
            this.itmReferenceLong2.Location = new System.Drawing.Point(260, 144);
            this.itmReferenceLong2.Name = "itmReferenceLong2";
            this.itmReferenceLong2.Size = new System.Drawing.Size(251, 24);
            this.itmReferenceLong2.Text = "Reference Long 2";
            this.itmReferenceLong2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceLong3
            // 
            this.itmReferenceLong3.Control = this.txtReferenceLong3;
            this.itmReferenceLong3.CustomizationFormText = "Reference Long 3";
            this.itmReferenceLong3.Location = new System.Drawing.Point(0, 168);
            this.itmReferenceLong3.Name = "itmReferenceLong3";
            this.itmReferenceLong3.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceLong3.Text = "Reference Long 3";
            this.itmReferenceLong3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceLong4
            // 
            this.itmReferenceLong4.Control = this.txtReferenceLong4;
            this.itmReferenceLong4.CustomizationFormText = "Reference Long 4";
            this.itmReferenceLong4.Location = new System.Drawing.Point(260, 168);
            this.itmReferenceLong4.Name = "itmReferenceLong4";
            this.itmReferenceLong4.Size = new System.Drawing.Size(251, 24);
            this.itmReferenceLong4.Text = "Reference Long 4";
            this.itmReferenceLong4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceLong5
            // 
            this.itmReferenceLong5.Control = this.txtReferenceLong5;
            this.itmReferenceLong5.CustomizationFormText = "Reference Long 5";
            this.itmReferenceLong5.Location = new System.Drawing.Point(0, 192);
            this.itmReferenceLong5.Name = "itmReferenceLong5";
            this.itmReferenceLong5.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceLong5.Text = "Reference Long 5";
            this.itmReferenceLong5.TextSize = new System.Drawing.Size(94, 13);
            // 
            // icgBillingAddress
            // 
            this.icgBillingAddress.CustomizationFormText = "Billing Address";
            this.icgBillingAddress.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmBillingAddressLine1,
            this.itmBillingAddressLine2,
            this.itmBillingAddressLine3,
            this.itmBillingAddressLine4,
            this.itmBillingAddressCode});
            this.icgBillingAddress.Location = new System.Drawing.Point(513, 72);
            this.icgBillingAddress.Name = "icgBillingAddress";
            this.icgBillingAddress.Size = new System.Drawing.Size(227, 168);
            this.icgBillingAddress.Text = "Billing Address";
            // 
            // itmBillingAddressLine1
            // 
            this.itmBillingAddressLine1.Control = this.txtBillingAddressLine1;
            this.itmBillingAddressLine1.CustomizationFormText = "Line 1";
            this.itmBillingAddressLine1.Location = new System.Drawing.Point(0, 0);
            this.itmBillingAddressLine1.Name = "itmBillingAddressLine1";
            this.itmBillingAddressLine1.Size = new System.Drawing.Size(203, 24);
            this.itmBillingAddressLine1.Text = "Line 1";
            this.itmBillingAddressLine1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmBillingAddressLine2
            // 
            this.itmBillingAddressLine2.Control = this.txtBillingAddressLine2;
            this.itmBillingAddressLine2.CustomizationFormText = "Line 2";
            this.itmBillingAddressLine2.Location = new System.Drawing.Point(0, 24);
            this.itmBillingAddressLine2.Name = "itmBillingAddressLine2";
            this.itmBillingAddressLine2.Size = new System.Drawing.Size(203, 24);
            this.itmBillingAddressLine2.Text = "Line 2";
            this.itmBillingAddressLine2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmBillingAddressLine3
            // 
            this.itmBillingAddressLine3.Control = this.txtBillingAddressLine3;
            this.itmBillingAddressLine3.CustomizationFormText = "Line 3";
            this.itmBillingAddressLine3.Location = new System.Drawing.Point(0, 48);
            this.itmBillingAddressLine3.Name = "itmBillingAddressLine3";
            this.itmBillingAddressLine3.Size = new System.Drawing.Size(203, 24);
            this.itmBillingAddressLine3.Text = "Line 3";
            this.itmBillingAddressLine3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmBillingAddressLine4
            // 
            this.itmBillingAddressLine4.Control = this.txtBillingAddressLine4;
            this.itmBillingAddressLine4.CustomizationFormText = "Line 4";
            this.itmBillingAddressLine4.Location = new System.Drawing.Point(0, 72);
            this.itmBillingAddressLine4.Name = "itmBillingAddressLine4";
            this.itmBillingAddressLine4.Size = new System.Drawing.Size(203, 24);
            this.itmBillingAddressLine4.Text = "Line 4";
            this.itmBillingAddressLine4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmBillingAddressCode
            // 
            this.itmBillingAddressCode.Control = this.txtBillingAddressCode;
            this.itmBillingAddressCode.CustomizationFormText = "Code";
            this.itmBillingAddressCode.Location = new System.Drawing.Point(0, 96);
            this.itmBillingAddressCode.Name = "itmBillingAddressCode";
            this.itmBillingAddressCode.Size = new System.Drawing.Size(203, 29);
            this.itmBillingAddressCode.Text = "Code";
            this.itmBillingAddressCode.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmDate1
            // 
            this.itmDate1.Control = this.dtDate1;
            this.itmDate1.CustomizationFormText = "Date 1";
            this.itmDate1.Location = new System.Drawing.Point(0, 216);
            this.itmDate1.Name = "itmDate1";
            this.itmDate1.Size = new System.Drawing.Size(258, 24);
            this.itmDate1.Text = "Date 1";
            this.itmDate1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // dtDate1
            // 
            this.dtDate1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "Date1", true));
            this.dtDate1.EditValue = null;
            this.dtDate1.EnterMoveNextControl = true;
            this.dtDate1.Location = new System.Drawing.Point(122, 259);
            this.dtDate1.MenuManager = this.RibbonControl;
            this.dtDate1.Name = "dtDate1";
            this.dtDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate1.Size = new System.Drawing.Size(156, 20);
            this.dtDate1.StyleController = this.LayoutControl;
            this.dtDate1.TabIndex = 42;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(511, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(2, 240);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // itmReferenceShort3
            // 
            this.itmReferenceShort3.Control = this.txtReferenceShort3;
            this.itmReferenceShort3.CustomizationFormText = "Reference Short 3";
            this.itmReferenceShort3.Location = new System.Drawing.Point(0, 48);
            this.itmReferenceShort3.Name = "itmReferenceShort3";
            this.itmReferenceShort3.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceShort3.Text = "Reference Short 3";
            this.itmReferenceShort3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort2
            // 
            this.itmReferenceShort2.Control = this.txtReferenceShort2;
            this.itmReferenceShort2.CustomizationFormText = "Reference Short 2";
            this.itmReferenceShort2.Location = new System.Drawing.Point(260, 24);
            this.itmReferenceShort2.Name = "itmReferenceShort2";
            this.itmReferenceShort2.Size = new System.Drawing.Size(251, 24);
            this.itmReferenceShort2.Text = "Reference Short 2";
            this.itmReferenceShort2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort4
            // 
            this.itmReferenceShort4.Control = this.txtReferenceShort4;
            this.itmReferenceShort4.CustomizationFormText = "Reference Short 4";
            this.itmReferenceShort4.Location = new System.Drawing.Point(260, 48);
            this.itmReferenceShort4.Name = "itmReferenceShort4";
            this.itmReferenceShort4.Size = new System.Drawing.Size(251, 24);
            this.itmReferenceShort4.Text = "Reference Short 4";
            this.itmReferenceShort4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort5
            // 
            this.itmReferenceShort5.Control = this.txtReferenceShort5;
            this.itmReferenceShort5.CustomizationFormText = "Reference Short 5";
            this.itmReferenceShort5.Location = new System.Drawing.Point(0, 72);
            this.itmReferenceShort5.Name = "itmReferenceShort5";
            this.itmReferenceShort5.Size = new System.Drawing.Size(258, 24);
            this.itmReferenceShort5.Text = "Reference Short 5";
            this.itmReferenceShort5.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmReferenceShort6
            // 
            this.itmReferenceShort6.Control = this.txtReferenceShort6;
            this.itmReferenceShort6.CustomizationFormText = "Reference Short 6";
            this.itmReferenceShort6.Location = new System.Drawing.Point(260, 72);
            this.itmReferenceShort6.Name = "itmReferenceShort6";
            this.itmReferenceShort6.Size = new System.Drawing.Size(251, 24);
            this.itmReferenceShort6.Text = "Reference Short 6";
            this.itmReferenceShort6.TextSize = new System.Drawing.Size(94, 13);
            // 
            // simpleSeparator3
            // 
            this.simpleSeparator3.AllowHotTrack = false;
            this.simpleSeparator3.CustomizationFormText = "simpleSeparator3";
            this.simpleSeparator3.Location = new System.Drawing.Point(258, 24);
            this.simpleSeparator3.Name = "simpleSeparator3";
            this.simpleSeparator3.Size = new System.Drawing.Size(2, 216);
            this.simpleSeparator3.Text = "simpleSeparator3";
            // 
            // icgShippingAddress
            // 
            this.icgShippingAddress.CustomizationFormText = "Shipping Address";
            this.icgShippingAddress.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmShippingAddressLine1,
            this.itmShippingAddressLine2,
            this.itmShippingAddressLine3,
            this.itmShippingAddressLine4,
            this.itmShippingAddressCode});
            this.icgShippingAddress.Location = new System.Drawing.Point(740, 72);
            this.icgShippingAddress.Name = "icgShippingAddress";
            this.icgShippingAddress.Size = new System.Drawing.Size(224, 168);
            this.icgShippingAddress.Text = "Shipping Address";
            // 
            // itmShippingAddressLine1
            // 
            this.itmShippingAddressLine1.Control = this.txtShippingAddressLine1;
            this.itmShippingAddressLine1.CustomizationFormText = "Line 1";
            this.itmShippingAddressLine1.Location = new System.Drawing.Point(0, 0);
            this.itmShippingAddressLine1.Name = "itmShippingAddressLine1";
            this.itmShippingAddressLine1.Size = new System.Drawing.Size(200, 24);
            this.itmShippingAddressLine1.Text = "Line 1";
            this.itmShippingAddressLine1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmShippingAddressLine2
            // 
            this.itmShippingAddressLine2.Control = this.txtShippingAddressLine2;
            this.itmShippingAddressLine2.CustomizationFormText = "Line 2";
            this.itmShippingAddressLine2.Location = new System.Drawing.Point(0, 24);
            this.itmShippingAddressLine2.Name = "itmShippingAddressLine2";
            this.itmShippingAddressLine2.Size = new System.Drawing.Size(200, 24);
            this.itmShippingAddressLine2.Text = "Line 2";
            this.itmShippingAddressLine2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmShippingAddressLine3
            // 
            this.itmShippingAddressLine3.Control = this.txtShippingAddressLine3;
            this.itmShippingAddressLine3.CustomizationFormText = "Line 3";
            this.itmShippingAddressLine3.Location = new System.Drawing.Point(0, 48);
            this.itmShippingAddressLine3.Name = "itmShippingAddressLine3";
            this.itmShippingAddressLine3.Size = new System.Drawing.Size(200, 24);
            this.itmShippingAddressLine3.Text = "Line 3";
            this.itmShippingAddressLine3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmShippingAddressLine4
            // 
            this.itmShippingAddressLine4.Control = this.txtShippingAddressLine4;
            this.itmShippingAddressLine4.CustomizationFormText = "Line 4";
            this.itmShippingAddressLine4.Location = new System.Drawing.Point(0, 72);
            this.itmShippingAddressLine4.Name = "itmShippingAddressLine4";
            this.itmShippingAddressLine4.Size = new System.Drawing.Size(200, 24);
            this.itmShippingAddressLine4.Text = "Line 4";
            this.itmShippingAddressLine4.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmShippingAddressCode
            // 
            this.itmShippingAddressCode.Control = this.txtShippingAddressCode;
            this.itmShippingAddressCode.CustomizationFormText = "Code";
            this.itmShippingAddressCode.Location = new System.Drawing.Point(0, 96);
            this.itmShippingAddressCode.Name = "itmShippingAddressCode";
            this.itmShippingAddressCode.Size = new System.Drawing.Size(200, 29);
            this.itmShippingAddressCode.Text = "Code";
            this.itmShippingAddressCode.TextSize = new System.Drawing.Size(94, 13);
            // 
            // itmDate2
            // 
            this.itmDate2.Control = this.txtDate2;
            this.itmDate2.CustomizationFormText = "Date 2";
            this.itmDate2.Location = new System.Drawing.Point(260, 192);
            this.itmDate2.Name = "itmDate2";
            this.itmDate2.Size = new System.Drawing.Size(251, 24);
            this.itmDate2.Text = "Date 2";
            this.itmDate2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // txtDate2
            // 
            this.txtDate2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "Date2", true));
            this.txtDate2.EditValue = null;
            this.txtDate2.EnterMoveNextControl = true;
            this.txtDate2.Location = new System.Drawing.Point(382, 235);
            this.txtDate2.MenuManager = this.RibbonControl;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDate2.Size = new System.Drawing.Size(149, 20);
            this.txtDate2.StyleController = this.LayoutControl;
            this.txtDate2.TabIndex = 43;
            // 
            // itmDate3
            // 
            this.itmDate3.Control = this.txtDate3;
            this.itmDate3.CustomizationFormText = "Date 3";
            this.itmDate3.Location = new System.Drawing.Point(260, 216);
            this.itmDate3.Name = "itmDate3";
            this.itmDate3.Size = new System.Drawing.Size(251, 24);
            this.itmDate3.Text = "Date 3";
            this.itmDate3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // txtDate3
            // 
            this.txtDate3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "Date3", true));
            this.txtDate3.EditValue = null;
            this.txtDate3.EnterMoveNextControl = true;
            this.txtDate3.Location = new System.Drawing.Point(382, 259);
            this.txtDate3.MenuManager = this.RibbonControl;
            this.txtDate3.Name = "txtDate3";
            this.txtDate3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate3.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDate3.Size = new System.Drawing.Size(149, 20);
            this.txtDate3.StyleController = this.LayoutControl;
            this.txtDate3.TabIndex = 44;
            // 
            // btnCreateSalesOrder
            // 
            this.btnCreateSalesOrder.Caption = "Create Sales Order";
            this.btnCreateSalesOrder.Glyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_order_new_16;
            this.btnCreateSalesOrder.Id = 24;
            this.btnCreateSalesOrder.LargeGlyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_order_new_32;
            this.btnCreateSalesOrder.Name = "btnCreateSalesOrder";
            this.btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateSalesOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalesOrder_ItemClick);
            // 
            // popOrder
            // 
            this.popOrder.ItemLinks.Add(this.btnViewSalesOrder);
            this.popOrder.Name = "popOrder";
            this.popOrder.Ribbon = this.RibbonControl;
            // 
            // btnViewSalesOrder
            // 
            this.btnViewSalesOrder.Caption = "View Sales Order";
            this.btnViewSalesOrder.Glyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_order_16;
            this.btnViewSalesOrder.Id = 25;
            this.btnViewSalesOrder.LargeGlyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_order_32;
            this.btnViewSalesOrder.Name = "btnViewSalesOrder";
            this.btnViewSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewSalesOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewSalesOrder_ItemClick);
            // 
            // btnCreateQuote
            // 
            this.btnCreateQuote.Caption = "Create Quote";
            this.btnCreateQuote.Glyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_quote_new_16;
            this.btnCreateQuote.Id = 26;
            this.btnCreateQuote.LargeGlyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_quote_new_32;
            this.btnCreateQuote.Name = "btnCreateQuote";
            this.btnCreateQuote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateQuote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateQuote_ItemClick);
            // 
            // popQuote
            // 
            this.popQuote.ItemLinks.Add(this.btnViewQuotes);
            this.popQuote.Name = "popQuote";
            this.popQuote.Ribbon = this.RibbonControl;
            // 
            // btnViewQuotes
            // 
            this.btnViewQuotes.Caption = "View Quote(s)";
            this.btnViewQuotes.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewQuotes.Glyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_quote_16;
            this.btnViewQuotes.Id = 27;
            this.btnViewQuotes.LargeGlyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.document_quote_32;
            this.btnViewQuotes.Name = "btnViewQuotes";
            this.btnViewQuotes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewQuotes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewQuotes_ItemClick);
            // 
            // rpDocument
            // 
            this.rpDocument.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgActionDocument});
            this.rpDocument.Name = "rpDocument";
            this.rpDocument.Text = "Document";
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnCreateSalesOrder);
            this.rpgActionDocument.ItemLinks.Add(this.btnCreateQuote);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewSalesOrder);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewQuotes);
            this.rpgActionDocument.ItemLinks.Add(this.btnRemoveItem);
            this.rpgActionDocument.Name = "rpgActionDocument";
            this.rpgActionDocument.Text = "Action";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Caption = "Remove\r\nItem";
            this.btnRemoveItem.Glyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.delete_16;
            this.btnRemoveItem.Id = 28;
            this.btnRemoveItem.LargeGlyph = global::CDS.Client.Desktop.Workshop.Properties.Resources.delete_32;
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRemoveItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveItem_ItemClick);
            // 
            // JobForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.Name = "JobForm";
            this.SuperTipParameter = "Job,Jobs";
            this.TabIcon = global::CDS.Client.Desktop.Workshop.Properties.Resources.wrench_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Workshop.Properties.Resources.wrench_16;
            this.Text = "Job";
            this.WaitFormNewRecordDescription = "Creating new Job...";
            this.WaitFormOpenRecordDescription = "Opening Job...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JobForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactTelephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgJobDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmContactPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmContactTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icgBillingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icgShippingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate3.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popQuote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.BindingSource BindingSourceLine;
        protected System.Windows.Forms.BindingSource BindingSourceTransaction;
        private DevExpress.XtraGrid.GridControl grdItems;
        private DevExpress.XtraGrid.Views.Grid.GridView grvItems;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsContact;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesContact;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraEditors.TextEdit txtTelephone;
        private DevExpress.XtraEditors.TextEdit txtContactTelephone;
        private DevExpress.XtraEditors.TextEdit txtContactPerson;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong5;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong4;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong3;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong2;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong1;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort10;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort9;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort8;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort7;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort6;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort5;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort4;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort3;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort2;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort1;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressCode;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine4;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine3;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine2;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine1;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressCode;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressLine4;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressLine3;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressLine2;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressLine1;
        private DevExpress.XtraLayout.LayoutControlItem itmGridLines;
        private DevExpress.XtraLayout.LayoutControlGroup lcgJobDetail;
        private DevExpress.XtraLayout.LayoutControlItem itmCompany;
        private DevExpress.XtraLayout.LayoutControlItem itmTelephone;
        private DevExpress.XtraLayout.LayoutControlItem itmContactPerson;
        private DevExpress.XtraLayout.LayoutControlItem itmContactTelephone;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort1;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort2;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort3;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort4;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort5;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort6;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort7;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort8;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort9;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort10;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong1;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong2;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong3;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong4;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong5;
        private DevExpress.XtraLayout.LayoutControlGroup icgBillingAddress;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine1;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine2;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine3;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine4;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressCode;
        private DevExpress.XtraLayout.LayoutControlGroup icgShippingAddress;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressLine1;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressLine2;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressLine3;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressLine4;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressCode;
        private DevExpress.XtraEditors.DateEdit txtDate3;
        private DevExpress.XtraEditors.DateEdit txtDate2;
        private DevExpress.XtraEditors.DateEdit dtDate1;
        private DevExpress.XtraLayout.LayoutControlItem itmDate1;
        private DevExpress.XtraLayout.LayoutControlItem itmDate2;
        private DevExpress.XtraLayout.LayoutControlItem itmDate3;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator3;
        private DevExpress.XtraGrid.Columns.GridColumn colItemId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceChanged;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repLineEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView repViewEntity;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repNumber;
        private DevExpress.XtraBars.BarButtonItem btnCreateSalesOrder;
        private DevExpress.XtraBars.BarButtonItem btnViewSalesOrder;
        private DevExpress.XtraBars.PopupMenu popOrder;
        private DevExpress.XtraBars.BarButtonItem btnCreateQuote;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceCompany;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceItem;
        private DevExpress.XtraGrid.Columns.GridColumn colLineOrder;
        private DevExpress.XtraBars.BarButtonItem btnViewQuotes;
        private DevExpress.XtraBars.PopupMenu popQuote;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchType;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchName;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchSupplierStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchSubCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchStockType;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchLocationMain;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchLocationSecondary;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchDiscountCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchGrouping;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchProfitMargin;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchOnHand;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchOnReserve;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchOnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchUnitAverage;
        private DevExpress.XtraGrid.Columns.GridColumn colSearchBalanceAmount;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDocument;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActionDocument;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAreaCode;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourceItem;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraBars.BarButtonItem btnRemoveItem;

    }
}
