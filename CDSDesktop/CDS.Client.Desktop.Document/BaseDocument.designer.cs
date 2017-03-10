namespace CDS.Client.Desktop.Document
{
    partial class BaseDocument
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDocument));
            this.colQtyOutstanding = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNumberFourDecimal = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNumber = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdItems = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceLine = new System.Windows.Forms.BindingSource(this.components);
            this.grvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colDiscountPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfitPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceChanged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitAverage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XPInstantFeedbackSourceItem = new DevExpress.Xpo.XPInstantFeedbackSource(this.components);
            this.itmItems = new DevExpress.XtraLayout.LayoutControlItem();
            this.BindingSourceTransaction = new System.Windows.Forms.BindingSource(this.components);
            this.txtReferenceLong1 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceLong1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceLong2 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceLong2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceLong3 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceLong3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTelephone = new DevExpress.XtraEditors.TextEdit();
            this.itmTelephone = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtContactPerson = new DevExpress.XtraEditors.TextEdit();
            this.itmContact = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVatNumber = new DevExpress.XtraEditors.TextEdit();
            this.itmVatNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmBillingAddressLine1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingAddress = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingAddressLine1 = new DevExpress.XtraEditors.TextEdit();
            this.btnLostSale = new DevExpress.XtraBars.BarButtonItem();
            this.itmDetails = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmTypeDropdownSpace = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmExpirationDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtExpirationDate = new DevExpress.XtraEditors.DateEdit();
            this.itmDueDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtDueDate = new DevExpress.XtraEditors.DateEdit();
            this.lcgBillingAddress = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmBillingAddressLine2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingAddressLine2 = new DevExpress.XtraEditors.TextEdit();
            this.itmBillingAddressLine3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingAddressLine3 = new DevExpress.XtraEditors.TextEdit();
            this.itmBillingAddressLine4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingAddressLine4 = new DevExpress.XtraEditors.TextEdit();
            this.itmBillingAddressCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingAddressCode = new DevExpress.XtraEditors.TextEdit();
            this.simpleSeparator3 = new DevExpress.XtraLayout.SimpleSeparator();
            this.itmMessage = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
            this.lcgShippingAddress = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmShippingAddressLine2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingAddressLine2 = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingAddressLine3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingAddressLine3 = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingAddressLine4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingAddressLine4 = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingAddressCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingAddressCode = new DevExpress.XtraEditors.TextEdit();
            this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.simpleSeparator4 = new DevExpress.XtraLayout.SimpleSeparator();
            this.itmCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.InstantFeedbackSourceCompany = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.ddlCompanyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmReferenceShort1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceShort1 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceShort3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceShort3 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceShort4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceShort4 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceShort2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceShort2 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceShort5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceShort5 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceLong4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceLong4 = new DevExpress.XtraEditors.TextEdit();
            this.itmReferenceLong5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReferenceLong5 = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlShippingType = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceShippingType = new DevExpress.Data.Linq.LinqServerModeSource();
            this.ServerModeSourcePaymentType = new DevExpress.Data.Linq.LinqServerModeSource();
            this.radMenu = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCreatedBy = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.repositoryItemOfficeColorPickEdit1 = new DevExpress.Office.UI.RepositoryItemOfficeColorPickEdit();
            this.btnEmailOnly = new DevExpress.XtraBars.BarButtonItem();
            this.rpDocument = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgActionDocument = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumberFourDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmVatNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTypeDropdownSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmExpirationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExpirationDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExpirationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDueDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBillingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgShippingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShippingType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceShippingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePaymentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemOfficeColorPickEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Header);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtReferenceLong5);
            this.LayoutControl.Controls.Add(this.txtReferenceLong4);
            this.LayoutControl.Controls.Add(this.txtReferenceShort5);
            this.LayoutControl.Controls.Add(this.txtReferenceShort4);
            this.LayoutControl.Controls.Add(this.txtReferenceShort3);
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.txtShippingAddressCode);
            this.LayoutControl.Controls.Add(this.txtBillingAddressCode);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine4);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine3);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine2);
            this.LayoutControl.Controls.Add(this.txtBillingAddressLine4);
            this.LayoutControl.Controls.Add(this.txtBillingAddressLine3);
            this.LayoutControl.Controls.Add(this.txtBillingAddressLine2);
            this.LayoutControl.Controls.Add(this.dtDueDate);
            this.LayoutControl.Controls.Add(this.dtExpirationDate);
            this.LayoutControl.Controls.Add(this.txtMessage);
            this.LayoutControl.Controls.Add(this.ddlShippingType);
            this.LayoutControl.Controls.Add(this.txtReferenceShort2);
            this.LayoutControl.Controls.Add(this.txtReferenceShort1);
            this.LayoutControl.Controls.Add(this.txtVatNumber);
            this.LayoutControl.Controls.Add(this.txtContactPerson);
            this.LayoutControl.Controls.Add(this.txtTelephone);
            this.LayoutControl.Controls.Add(this.txtReferenceLong3);
            this.LayoutControl.Controls.Add(this.txtReferenceLong2);
            this.LayoutControl.Controls.Add(this.txtReferenceLong1);
            this.LayoutControl.Controls.Add(this.grdItems);
            this.LayoutControl.Controls.Add(this.txtBillingAddress);
            this.LayoutControl.Controls.Add(this.txtShippingAddressLine1);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Controls.Add(this.ddlCompany);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1461, 76, 918, 852);
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
            this.itmItems,
            this.itmDetails,
            this.lcgHistory});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnEmailOnly});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RibbonControl.MaxItemId = 29;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpDocument});
            this.RibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemOfficeColorPickEdit1});
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
            // colQtyOutstanding
            // 
            this.colQtyOutstanding.Caption = "Qty Out";
            this.colQtyOutstanding.ColumnEdit = this.repNumberFourDecimal;
            this.colQtyOutstanding.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colQtyOutstanding.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyOutstanding.FieldName = "QtyOutstanding";
            this.colQtyOutstanding.MaxWidth = 90;
            this.colQtyOutstanding.MinWidth = 60;
            this.colQtyOutstanding.Name = "colQtyOutstanding";
            this.colQtyOutstanding.OptionsColumn.AllowEdit = false;
            this.colQtyOutstanding.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQtyOutstanding.OptionsColumn.ShowInExpressionEditor = false;
            this.colQtyOutstanding.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyOutstanding", "{0:##,0.00}")});
            this.colQtyOutstanding.Visible = true;
            this.colQtyOutstanding.VisibleIndex = 4;
            this.colQtyOutstanding.Width = 90;
            // 
            // repNumberFourDecimal
            // 
            this.repNumberFourDecimal.AutoHeight = false;
            this.repNumberFourDecimal.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNumberFourDecimal.DisplayFormat.FormatString = "N4";
            this.repNumberFourDecimal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumberFourDecimal.EditFormat.FormatString = "N4";
            this.repNumberFourDecimal.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumberFourDecimal.Mask.EditMask = "N4";
            this.repNumberFourDecimal.Mask.UseMaskAsDisplayFormat = true;
            this.repNumberFourDecimal.Name = "repNumberFourDecimal";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Unit Price";
            this.colAmount.ColumnEdit = this.repNumber;
            this.colAmount.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 80;
            this.colAmount.MinWidth = 60;
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsColumn.AllowMove = false;
            this.colAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 6;
            this.colAmount.Width = 72;
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
            this.repNumber.Mask.EditMask = "N2";
            this.repNumber.Mask.UseMaskAsDisplayFormat = true;
            this.repNumber.Name = "repNumber";
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.ColumnEdit = this.repNumber;
            this.colTotalAmount.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAmount.FieldName = "TotalAmount";
            this.colTotalAmount.MaxWidth = 120;
            this.colTotalAmount.MinWidth = 90;
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.OptionsColumn.AllowEdit = false;
            this.colTotalAmount.OptionsColumn.AllowFocus = false;
            this.colTotalAmount.OptionsColumn.AllowMove = false;
            this.colTotalAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalAmount.OptionsColumn.ReadOnly = true;
            this.colTotalAmount.OptionsColumn.ShowInExpressionEditor = false;
            this.colTotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TotalAmount", "{0:##,0.00}")});
            this.colTotalAmount.Visible = true;
            this.colTotalAmount.VisibleIndex = 11;
            this.colTotalAmount.Width = 102;
            // 
            // grdItems
            // 
            this.grdItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdItems.DataSource = this.BindingSourceLine;
            this.grdItems.Location = new System.Drawing.Point(12, 292);
            this.grdItems.MainView = this.grvItems;
            this.grdItems.MenuManager = this.RibbonControl;
            this.grdItems.Name = "grdItems";
            this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repNumber,
            this.repLineEntity,
            this.repNumberFourDecimal});
            this.grdItems.Size = new System.Drawing.Size(984, 214);
            this.grdItems.TabIndex = 12;
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
            this.colCount,
            this.colItemId,
            this.colDescription,
            this.colDiscountPercentage,
            this.colQuantity,
            this.colQtyOutstanding,
            this.colQtyReceived,
            this.colAmount,
            this.colProfitPercentage,
            this.colTotal,
            this.colTotalTax,
            this.colTotalAmount,
            this.colPriceChanged,
            this.colUnitAverage,
            this.colUnitCost});
            this.grvItems.CustomizationFormBounds = new System.Drawing.Rectangle(0, 546, 216, 190);
            gridFormatRule1.Column = this.colQtyOutstanding;
            gridFormatRule1.Name = "QtyOutstandingGTZero";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(224)))), ((int)(((byte)(149)))));
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue1.Expression = "[QtyOutstanding]";
            formatConditionRuleValue1.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = this.colAmount;
            gridFormatRule2.Name = "PriceEqualToAverage";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Expression = "[UnitAverage] == [Amount]";
            gridFormatRule2.Rule = formatConditionRuleExpression1;
            gridFormatRule3.Column = this.colTotalAmount;
            gridFormatRule3.Name = "ExcessiveAmount";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue2.Expression = "[TotalAmount]";
            formatConditionRuleValue2.Value1 = "1000000";
            gridFormatRule3.Rule = formatConditionRuleValue2;
            this.grvItems.FormatRules.Add(gridFormatRule1);
            this.grvItems.FormatRules.Add(gridFormatRule2);
            this.grvItems.FormatRules.Add(gridFormatRule3);
            this.grvItems.GridControl = this.grdItems;
            this.grvItems.Name = "grvItems";
            this.grvItems.OptionsBehavior.Editable = false;
            this.grvItems.OptionsMenu.ShowConditionalFormattingItem = true;
            this.grvItems.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvItems.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvItems.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvItems.OptionsView.ShowDetailButtons = false;
            this.grvItems.OptionsView.ShowFooter = true;
            this.grvItems.OptionsView.ShowGroupPanel = false;
            this.grvItems.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCount, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvItems.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.grvItems_CustomSummaryCalculate);
            this.grvItems.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvItems_ShowingEditor);
            this.grvItems.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvItems_InitNewRow);
            this.grvItems.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvItems_FocusedRowChanged);
            this.grvItems.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.grvItems_FocusedColumnChanged);
            this.grvItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvItems_CellValueChanged);
            this.grvItems.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvItems_CellValueChanging);
            this.grvItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvItems_KeyDown);
            // 
            // colCount
            // 
            this.colCount.Caption = " ";
            this.colCount.CustomizationCaption = "Row Number";
            this.colCount.FieldName = "LineOrder";
            this.colCount.MaxWidth = 80;
            this.colCount.Name = "colCount";
            this.colCount.OptionsColumn.AllowEdit = false;
            this.colCount.OptionsColumn.AllowFocus = false;
            this.colCount.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCount.OptionsColumn.AllowMove = false;
            this.colCount.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 0;
            this.colCount.Width = 20;
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
            this.colItemId.Width = 157;
            // 
            // repLineEntity
            // 
            this.repLineEntity.AutoHeight = false;
            this.repLineEntity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLineEntity.DisplayMember = "Title";
            this.repLineEntity.EditValueChangedDelay = 2000;
            this.repLineEntity.Name = "repLineEntity";
            this.repLineEntity.NullText = "Select Item ...";
            this.repLineEntity.PopupFindMode = DevExpress.XtraEditors.FindMode.FindClick;
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
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 376;
            // 
            // colDiscountPercentage
            // 
            this.colDiscountPercentage.Caption = "Disc %";
            this.colDiscountPercentage.ColumnEdit = this.repNumber;
            this.colDiscountPercentage.FieldName = "DiscountPercentage";
            this.colDiscountPercentage.MaxWidth = 80;
            this.colDiscountPercentage.MinWidth = 60;
            this.colDiscountPercentage.Name = "colDiscountPercentage";
            this.colDiscountPercentage.OptionsColumn.AllowMove = false;
            this.colDiscountPercentage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDiscountPercentage.Visible = true;
            this.colDiscountPercentage.VisibleIndex = 7;
            this.colDiscountPercentage.Width = 60;
            // 
            // colQuantity
            // 
            this.colQuantity.ColumnEdit = this.repNumberFourDecimal;
            this.colQuantity.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 90;
            this.colQuantity.MinWidth = 60;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowMove = false;
            this.colQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:##,0.00}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            this.colQuantity.Width = 60;
            // 
            // colQtyReceived
            // 
            this.colQtyReceived.ColumnEdit = this.repNumberFourDecimal;
            this.colQtyReceived.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colQtyReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyReceived.FieldName = "QtyReceived";
            this.colQtyReceived.MaxWidth = 90;
            this.colQtyReceived.MinWidth = 60;
            this.colQtyReceived.Name = "colQtyReceived";
            this.colQtyReceived.OptionsColumn.AllowEdit = false;
            this.colQtyReceived.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colQtyReceived.OptionsColumn.ShowInExpressionEditor = false;
            this.colQtyReceived.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyReceived", "{0:##,0.00}")});
            this.colQtyReceived.Visible = true;
            this.colQtyReceived.VisibleIndex = 5;
            this.colQtyReceived.Width = 90;
            // 
            // colProfitPercentage
            // 
            this.colProfitPercentage.Caption = "Prof %";
            this.colProfitPercentage.DisplayFormat.FormatString = "{0:#0.##%}";
            this.colProfitPercentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colProfitPercentage.FieldName = "ProfitPercentage";
            this.colProfitPercentage.MaxWidth = 80;
            this.colProfitPercentage.MinWidth = 60;
            this.colProfitPercentage.Name = "colProfitPercentage";
            this.colProfitPercentage.OptionsColumn.AllowEdit = false;
            this.colProfitPercentage.OptionsColumn.AllowFocus = false;
            this.colProfitPercentage.OptionsColumn.AllowMove = false;
            this.colProfitPercentage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colProfitPercentage.Visible = true;
            this.colProfitPercentage.VisibleIndex = 8;
            this.colProfitPercentage.Width = 72;
            // 
            // colTotal
            // 
            this.colTotal.ColumnEdit = this.repNumber;
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
            this.colTotal.OptionsColumn.ShowInExpressionEditor = false;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:##,0.00}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 9;
            this.colTotal.Width = 90;
            // 
            // colTotalTax
            // 
            this.colTotalTax.ColumnEdit = this.repNumber;
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
            this.colTotalTax.OptionsColumn.ShowInExpressionEditor = false;
            this.colTotalTax.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalTax", "{0:##,0.00}")});
            this.colTotalTax.Visible = true;
            this.colTotalTax.VisibleIndex = 10;
            this.colTotalTax.Width = 90;
            // 
            // colPriceChanged
            // 
            this.colPriceChanged.FieldName = "PriceChanged";
            this.colPriceChanged.MaxWidth = 80;
            this.colPriceChanged.MinWidth = 60;
            this.colPriceChanged.Name = "colPriceChanged";
            this.colPriceChanged.OptionsColumn.AllowEdit = false;
            this.colPriceChanged.OptionsColumn.AllowFocus = false;
            this.colPriceChanged.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPriceChanged.OptionsColumn.ReadOnly = true;
            this.colPriceChanged.Width = 60;
            // 
            // colUnitAverage
            // 
            this.colUnitAverage.FieldName = "UnitAverage";
            this.colUnitAverage.Name = "colUnitAverage";
            this.colUnitAverage.OptionsColumn.AllowEdit = false;
            this.colUnitAverage.OptionsColumn.AllowFocus = false;
            this.colUnitAverage.OptionsColumn.ReadOnly = true;
            // 
            // colUnitCost
            // 
            this.colUnitCost.FieldName = "UnitCost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.OptionsColumn.AllowEdit = false;
            this.colUnitCost.OptionsColumn.AllowFocus = false;
            this.colUnitCost.OptionsColumn.ReadOnly = true;
            // 
            // XPInstantFeedbackSourceItem
            // 
            this.XPInstantFeedbackSourceItem.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.SYS_Entity);
            // 
            // itmItems
            // 
            this.itmItems.Control = this.grdItems;
            this.itmItems.CustomizationFormText = "itmItems";
            this.itmItems.Location = new System.Drawing.Point(0, 280);
            this.itmItems.Name = "itmItems";
            this.itmItems.Size = new System.Drawing.Size(988, 218);
            this.itmItems.Text = "itmItems";
            this.itmItems.TextSize = new System.Drawing.Size(0, 0);
            this.itmItems.TextVisible = false;
            // 
            // BindingSourceTransaction
            // 
            this.BindingSourceTransaction.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_TRX_Header);
            // 
            // txtReferenceLong1
            // 
            this.txtReferenceLong1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong1", true));
            this.txtReferenceLong1.EnterMoveNextControl = true;
            this.txtReferenceLong1.Location = new System.Drawing.Point(360, 67);
            this.txtReferenceLong1.MenuManager = this.RibbonControl;
            this.txtReferenceLong1.Name = "txtReferenceLong1";
            this.txtReferenceLong1.Size = new System.Drawing.Size(170, 20);
            this.txtReferenceLong1.StyleController = this.LayoutControl;
            this.txtReferenceLong1.TabIndex = 3;
            // 
            // itmReferenceLong1
            // 
            this.itmReferenceLong1.Control = this.txtReferenceLong1;
            this.itmReferenceLong1.CustomizationFormText = "Reference Long 1";
            this.itmReferenceLong1.Location = new System.Drawing.Point(244, 24);
            this.itmReferenceLong1.Name = "itmReferenceLong1";
            this.itmReferenceLong1.Size = new System.Drawing.Size(266, 24);
            this.itmReferenceLong1.Text = "Reference Long 1";
            this.itmReferenceLong1.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceLong2
            // 
            this.txtReferenceLong2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong2", true));
            this.txtReferenceLong2.EnterMoveNextControl = true;
            this.txtReferenceLong2.Location = new System.Drawing.Point(360, 91);
            this.txtReferenceLong2.MenuManager = this.RibbonControl;
            this.txtReferenceLong2.Name = "txtReferenceLong2";
            this.txtReferenceLong2.Size = new System.Drawing.Size(170, 20);
            this.txtReferenceLong2.StyleController = this.LayoutControl;
            this.txtReferenceLong2.TabIndex = 5;
            // 
            // itmReferenceLong2
            // 
            this.itmReferenceLong2.Control = this.txtReferenceLong2;
            this.itmReferenceLong2.CustomizationFormText = "Reference Long 2";
            this.itmReferenceLong2.Location = new System.Drawing.Point(244, 48);
            this.itmReferenceLong2.Name = "itmReferenceLong2";
            this.itmReferenceLong2.Size = new System.Drawing.Size(266, 24);
            this.itmReferenceLong2.Text = "Reference Long 2";
            this.itmReferenceLong2.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceLong3
            // 
            this.txtReferenceLong3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong3", true));
            this.txtReferenceLong3.EnterMoveNextControl = true;
            this.txtReferenceLong3.Location = new System.Drawing.Point(360, 115);
            this.txtReferenceLong3.MenuManager = this.RibbonControl;
            this.txtReferenceLong3.Name = "txtReferenceLong3";
            this.txtReferenceLong3.Size = new System.Drawing.Size(170, 20);
            this.txtReferenceLong3.StyleController = this.LayoutControl;
            this.txtReferenceLong3.TabIndex = 7;
            // 
            // itmReferenceLong3
            // 
            this.itmReferenceLong3.Control = this.txtReferenceLong3;
            this.itmReferenceLong3.CustomizationFormText = "Reference Long 3";
            this.itmReferenceLong3.Location = new System.Drawing.Point(244, 72);
            this.itmReferenceLong3.Name = "itmReferenceLong3";
            this.itmReferenceLong3.Size = new System.Drawing.Size(266, 24);
            this.itmReferenceLong3.Text = "Reference Long 3";
            this.itmReferenceLong3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtTelephone
            // 
            this.txtTelephone.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ContactTelephone", true));
            this.txtTelephone.EnterMoveNextControl = true;
            this.txtTelephone.Location = new System.Drawing.Point(628, 91);
            this.txtTelephone.MenuManager = this.RibbonControl;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(356, 20);
            this.txtTelephone.StyleController = this.LayoutControl;
            this.txtTelephone.TabIndex = 1;
            this.txtTelephone.TabStop = false;
            // 
            // itmTelephone
            // 
            this.itmTelephone.Control = this.txtTelephone;
            this.itmTelephone.CustomizationFormText = "Telephone";
            this.itmTelephone.Location = new System.Drawing.Point(512, 48);
            this.itmTelephone.Name = "itmTelephone";
            this.itmTelephone.Size = new System.Drawing.Size(452, 24);
            this.itmTelephone.Text = "Telephone";
            this.itmTelephone.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ContactPerson", true));
            this.txtContactPerson.EnterMoveNextControl = true;
            this.txtContactPerson.Location = new System.Drawing.Point(628, 67);
            this.txtContactPerson.MenuManager = this.RibbonControl;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(356, 20);
            this.txtContactPerson.StyleController = this.LayoutControl;
            this.txtContactPerson.TabIndex = 1;
            this.txtContactPerson.TabStop = false;
            // 
            // itmContact
            // 
            this.itmContact.Control = this.txtContactPerson;
            this.itmContact.CustomizationFormText = "Contact";
            this.itmContact.Location = new System.Drawing.Point(512, 24);
            this.itmContact.Name = "itmContact";
            this.itmContact.Size = new System.Drawing.Size(452, 24);
            this.itmContact.Text = "Contact";
            this.itmContact.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtVatNumber
            // 
            this.txtVatNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "VatNumber", true));
            this.txtVatNumber.EnterMoveNextControl = true;
            this.txtVatNumber.Location = new System.Drawing.Point(628, 43);
            this.txtVatNumber.MenuManager = this.RibbonControl;
            this.txtVatNumber.Name = "txtVatNumber";
            this.txtVatNumber.Size = new System.Drawing.Size(356, 20);
            this.txtVatNumber.StyleController = this.LayoutControl;
            this.txtVatNumber.TabIndex = 1;
            this.txtVatNumber.TabStop = false;
            // 
            // itmVatNumber
            // 
            this.itmVatNumber.Control = this.txtVatNumber;
            this.itmVatNumber.CustomizationFormText = "Vat Number";
            this.itmVatNumber.Location = new System.Drawing.Point(512, 0);
            this.itmVatNumber.Name = "itmVatNumber";
            this.itmVatNumber.Size = new System.Drawing.Size(452, 24);
            this.itmVatNumber.Text = "Vat Number";
            this.itmVatNumber.TextSize = new System.Drawing.Size(88, 13);
            // 
            // itmBillingAddressLine1
            // 
            this.itmBillingAddressLine1.Control = this.txtBillingAddress;
            this.itmBillingAddressLine1.CustomizationFormText = "Billing Address Line 1";
            this.itmBillingAddressLine1.Location = new System.Drawing.Point(0, 0);
            this.itmBillingAddressLine1.Name = "itmBillingAddressLine1";
            this.itmBillingAddressLine1.Size = new System.Drawing.Size(225, 24);
            this.itmBillingAddressLine1.Text = "Line 1";
            this.itmBillingAddressLine1.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtBillingAddress
            // 
            this.txtBillingAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine1", true));
            this.txtBillingAddress.EnterMoveNextControl = true;
            this.txtBillingAddress.Location = new System.Drawing.Point(632, 148);
            this.txtBillingAddress.MenuManager = this.RibbonControl;
            this.txtBillingAddress.Name = "txtBillingAddress";
            this.txtBillingAddress.Size = new System.Drawing.Size(129, 20);
            this.txtBillingAddress.StyleController = this.LayoutControl;
            this.txtBillingAddress.TabIndex = 1;
            this.txtBillingAddress.TabStop = false;
            // 
            // itmShippingAddress
            // 
            this.itmShippingAddress.Control = this.txtShippingAddressLine1;
            this.itmShippingAddress.CustomizationFormText = "Shipping Address Line 1";
            this.itmShippingAddress.Location = new System.Drawing.Point(0, 0);
            this.itmShippingAddress.Name = "itmShippingAddress";
            this.itmShippingAddress.Size = new System.Drawing.Size(211, 24);
            this.itmShippingAddress.Text = "Line 1";
            this.itmShippingAddress.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtShippingAddressLine1
            // 
            this.txtShippingAddressLine1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine1", true));
            this.txtShippingAddressLine1.EnterMoveNextControl = true;
            this.txtShippingAddressLine1.Location = new System.Drawing.Point(865, 148);
            this.txtShippingAddressLine1.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine1.Name = "txtShippingAddressLine1";
            this.txtShippingAddressLine1.Size = new System.Drawing.Size(115, 20);
            this.txtShippingAddressLine1.StyleController = this.LayoutControl;
            this.txtShippingAddressLine1.TabIndex = 1;
            this.txtShippingAddressLine1.TabStop = false;
            // 
            // btnLostSale
            // 
            this.btnLostSale.Caption = "Lost Sale";
            this.btnLostSale.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLostSale.Glyph")));
            this.btnLostSale.Id = 23;
            this.btnLostSale.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLostSale.LargeGlyph")));
            this.btnLostSale.Name = "btnLostSale";
            // 
            // itmDetails
            // 
            this.itmDetails.CustomizationFormText = "Details";
            this.itmDetails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmVatNumber,
            this.itmTypeDropdownSpace,
            this.itmExpirationDate,
            this.itmDueDate,
            this.lcgBillingAddress,
            this.itmContact,
            this.simpleSeparator3,
            this.itmTelephone,
            this.itmMessage,
            this.lcgShippingAddress,
            this.simpleSeparator2,
            this.simpleSeparator4,
            this.itmCompany,
            this.itmReferenceShort1,
            this.itmReferenceShort3,
            this.itmReferenceShort4,
            this.itmReferenceShort2,
            this.itmReferenceLong1,
            this.itmReferenceLong2,
            this.itmReferenceLong3,
            this.itmReferenceShort5,
            this.itmReferenceLong4,
            this.itmReferenceLong5,
            this.itmShippingType});
            this.itmDetails.Location = new System.Drawing.Point(0, 0);
            this.itmDetails.Name = "itmDetails";
            this.itmDetails.Size = new System.Drawing.Size(988, 280);
            this.itmDetails.Text = "Details";
            // 
            // itmTypeDropdownSpace
            // 
            this.itmTypeDropdownSpace.AllowHotTrack = false;
            this.itmTypeDropdownSpace.CustomizationFormText = "itmTypeDropdownSpace";
            this.itmTypeDropdownSpace.Location = new System.Drawing.Point(244, 168);
            this.itmTypeDropdownSpace.Name = "itmTypeDropdownSpace";
            this.itmTypeDropdownSpace.Size = new System.Drawing.Size(266, 24);
            this.itmTypeDropdownSpace.Text = "itmTypeDropdownSpace";
            this.itmTypeDropdownSpace.TextSize = new System.Drawing.Size(0, 0);
            this.itmTypeDropdownSpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // itmExpirationDate
            // 
            this.itmExpirationDate.Control = this.dtExpirationDate;
            this.itmExpirationDate.CustomizationFormText = "Expiration Date";
            this.itmExpirationDate.Location = new System.Drawing.Point(0, 144);
            this.itmExpirationDate.Name = "itmExpirationDate";
            this.itmExpirationDate.Size = new System.Drawing.Size(242, 24);
            this.itmExpirationDate.Text = "Expiration Date";
            this.itmExpirationDate.TextSize = new System.Drawing.Size(88, 13);
            this.itmExpirationDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // dtExpirationDate
            // 
            this.dtExpirationDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "DateValid", true));
            this.dtExpirationDate.EditValue = null;
            this.dtExpirationDate.EnterMoveNextControl = true;
            this.dtExpirationDate.Location = new System.Drawing.Point(116, 187);
            this.dtExpirationDate.MenuManager = this.RibbonControl;
            this.dtExpirationDate.Name = "dtExpirationDate";
            this.dtExpirationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtExpirationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtExpirationDate.Properties.NullText = "Select Date ...";
            this.dtExpirationDate.Size = new System.Drawing.Size(146, 20);
            this.dtExpirationDate.StyleController = this.LayoutControl;
            this.dtExpirationDate.TabIndex = 1;
            this.dtExpirationDate.TabStop = false;
            // 
            // itmDueDate
            // 
            this.itmDueDate.Control = this.dtDueDate;
            this.itmDueDate.CustomizationFormText = "Due Date";
            this.itmDueDate.Location = new System.Drawing.Point(0, 168);
            this.itmDueDate.Name = "itmDueDate";
            this.itmDueDate.Size = new System.Drawing.Size(242, 24);
            this.itmDueDate.Text = "Due Date";
            this.itmDueDate.TextSize = new System.Drawing.Size(88, 13);
            this.itmDueDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // dtDueDate
            // 
            this.dtDueDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "DateValid", true));
            this.dtDueDate.EditValue = null;
            this.dtDueDate.EnterMoveNextControl = true;
            this.dtDueDate.Location = new System.Drawing.Point(116, 211);
            this.dtDueDate.MenuManager = this.RibbonControl;
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDueDate.Properties.NullText = "Select Date ...";
            this.dtDueDate.Size = new System.Drawing.Size(146, 20);
            this.dtDueDate.StyleController = this.LayoutControl;
            this.dtDueDate.TabIndex = 1;
            this.dtDueDate.TabStop = false;
            // 
            // lcgBillingAddress
            // 
            this.lcgBillingAddress.CustomizationFormText = "Billing Address";
            this.lcgBillingAddress.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmBillingAddressLine1,
            this.itmBillingAddressLine2,
            this.itmBillingAddressLine3,
            this.itmBillingAddressLine4,
            this.itmBillingAddressCode});
            this.lcgBillingAddress.Location = new System.Drawing.Point(512, 74);
            this.lcgBillingAddress.Name = "lcgBillingAddress";
            this.lcgBillingAddress.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 9, 9);
            this.lcgBillingAddress.Size = new System.Drawing.Size(233, 163);
            this.lcgBillingAddress.Text = "Billing Address";
            // 
            // itmBillingAddressLine2
            // 
            this.itmBillingAddressLine2.Control = this.txtBillingAddressLine2;
            this.itmBillingAddressLine2.CustomizationFormText = "Billing Address Line 2";
            this.itmBillingAddressLine2.Location = new System.Drawing.Point(0, 24);
            this.itmBillingAddressLine2.Name = "itmBillingAddressLine2";
            this.itmBillingAddressLine2.Size = new System.Drawing.Size(225, 24);
            this.itmBillingAddressLine2.Text = "Line 2";
            this.itmBillingAddressLine2.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtBillingAddressLine2
            // 
            this.txtBillingAddressLine2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine2", true));
            this.txtBillingAddressLine2.EnterMoveNextControl = true;
            this.txtBillingAddressLine2.Location = new System.Drawing.Point(632, 172);
            this.txtBillingAddressLine2.MenuManager = this.RibbonControl;
            this.txtBillingAddressLine2.Name = "txtBillingAddressLine2";
            this.txtBillingAddressLine2.Size = new System.Drawing.Size(129, 20);
            this.txtBillingAddressLine2.StyleController = this.LayoutControl;
            this.txtBillingAddressLine2.TabIndex = 1;
            this.txtBillingAddressLine2.TabStop = false;
            // 
            // itmBillingAddressLine3
            // 
            this.itmBillingAddressLine3.Control = this.txtBillingAddressLine3;
            this.itmBillingAddressLine3.CustomizationFormText = "Billing Address Line 3";
            this.itmBillingAddressLine3.Location = new System.Drawing.Point(0, 48);
            this.itmBillingAddressLine3.Name = "itmBillingAddressLine3";
            this.itmBillingAddressLine3.Size = new System.Drawing.Size(225, 24);
            this.itmBillingAddressLine3.Text = "Line 3";
            this.itmBillingAddressLine3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtBillingAddressLine3
            // 
            this.txtBillingAddressLine3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine3", true));
            this.txtBillingAddressLine3.EnterMoveNextControl = true;
            this.txtBillingAddressLine3.Location = new System.Drawing.Point(632, 196);
            this.txtBillingAddressLine3.MenuManager = this.RibbonControl;
            this.txtBillingAddressLine3.Name = "txtBillingAddressLine3";
            this.txtBillingAddressLine3.Size = new System.Drawing.Size(129, 20);
            this.txtBillingAddressLine3.StyleController = this.LayoutControl;
            this.txtBillingAddressLine3.TabIndex = 1;
            this.txtBillingAddressLine3.TabStop = false;
            // 
            // itmBillingAddressLine4
            // 
            this.itmBillingAddressLine4.Control = this.txtBillingAddressLine4;
            this.itmBillingAddressLine4.CustomizationFormText = "Billing Address Line 4";
            this.itmBillingAddressLine4.Location = new System.Drawing.Point(0, 72);
            this.itmBillingAddressLine4.Name = "itmBillingAddressLine4";
            this.itmBillingAddressLine4.Size = new System.Drawing.Size(225, 24);
            this.itmBillingAddressLine4.Text = "Line 4";
            this.itmBillingAddressLine4.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtBillingAddressLine4
            // 
            this.txtBillingAddressLine4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressLine4", true));
            this.txtBillingAddressLine4.EnterMoveNextControl = true;
            this.txtBillingAddressLine4.Location = new System.Drawing.Point(632, 220);
            this.txtBillingAddressLine4.MenuManager = this.RibbonControl;
            this.txtBillingAddressLine4.Name = "txtBillingAddressLine4";
            this.txtBillingAddressLine4.Size = new System.Drawing.Size(129, 20);
            this.txtBillingAddressLine4.StyleController = this.LayoutControl;
            this.txtBillingAddressLine4.TabIndex = 1;
            this.txtBillingAddressLine4.TabStop = false;
            // 
            // itmBillingAddressCode
            // 
            this.itmBillingAddressCode.Control = this.txtBillingAddressCode;
            this.itmBillingAddressCode.CustomizationFormText = "Billing Address Code";
            this.itmBillingAddressCode.Location = new System.Drawing.Point(0, 96);
            this.itmBillingAddressCode.Name = "itmBillingAddressCode";
            this.itmBillingAddressCode.Size = new System.Drawing.Size(225, 24);
            this.itmBillingAddressCode.Text = "Code";
            this.itmBillingAddressCode.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtBillingAddressCode
            // 
            this.txtBillingAddressCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "BillingAddressCode", true));
            this.txtBillingAddressCode.EnterMoveNextControl = true;
            this.txtBillingAddressCode.Location = new System.Drawing.Point(632, 244);
            this.txtBillingAddressCode.MenuManager = this.RibbonControl;
            this.txtBillingAddressCode.Name = "txtBillingAddressCode";
            this.txtBillingAddressCode.Size = new System.Drawing.Size(129, 20);
            this.txtBillingAddressCode.StyleController = this.LayoutControl;
            this.txtBillingAddressCode.TabIndex = 1;
            this.txtBillingAddressCode.TabStop = false;
            // 
            // simpleSeparator3
            // 
            this.simpleSeparator3.AllowHotTrack = false;
            this.simpleSeparator3.CustomizationFormText = "simpleSeparator3";
            this.simpleSeparator3.Location = new System.Drawing.Point(242, 24);
            this.simpleSeparator3.Name = "simpleSeparator3";
            this.simpleSeparator3.Size = new System.Drawing.Size(2, 168);
            this.simpleSeparator3.Text = "simpleSeparator3";
            // 
            // itmMessage
            // 
            this.itmMessage.Control = this.txtMessage;
            this.itmMessage.CustomizationFormText = "Message";
            this.itmMessage.Location = new System.Drawing.Point(0, 192);
            this.itmMessage.Name = "itmMessage";
            this.itmMessage.Size = new System.Drawing.Size(510, 45);
            this.itmMessage.Text = "Message";
            this.itmMessage.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmMessage.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtMessage
            // 
            this.txtMessage.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Comment", true));
            this.txtMessage.Location = new System.Drawing.Point(24, 251);
            this.txtMessage.MenuManager = this.RibbonControl;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(506, 25);
            this.txtMessage.StyleController = this.LayoutControl;
            this.txtMessage.TabIndex = 1;
            this.txtMessage.TabStop = false;
            // 
            // lcgShippingAddress
            // 
            this.lcgShippingAddress.CustomizationFormText = "Shipping Address";
            this.lcgShippingAddress.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmShippingAddress,
            this.itmShippingAddressLine2,
            this.itmShippingAddressLine3,
            this.itmShippingAddressLine4,
            this.itmShippingAddressCode});
            this.lcgShippingAddress.Location = new System.Drawing.Point(745, 74);
            this.lcgShippingAddress.Name = "lcgShippingAddress";
            this.lcgShippingAddress.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 9, 9);
            this.lcgShippingAddress.Size = new System.Drawing.Size(219, 163);
            this.lcgShippingAddress.Text = "Shipping Address";
            // 
            // itmShippingAddressLine2
            // 
            this.itmShippingAddressLine2.Control = this.txtShippingAddressLine2;
            this.itmShippingAddressLine2.CustomizationFormText = "Shipping Address Line 2";
            this.itmShippingAddressLine2.Location = new System.Drawing.Point(0, 24);
            this.itmShippingAddressLine2.Name = "itmShippingAddressLine2";
            this.itmShippingAddressLine2.Size = new System.Drawing.Size(211, 24);
            this.itmShippingAddressLine2.Text = "Line 2";
            this.itmShippingAddressLine2.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtShippingAddressLine2
            // 
            this.txtShippingAddressLine2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine2", true));
            this.txtShippingAddressLine2.EnterMoveNextControl = true;
            this.txtShippingAddressLine2.Location = new System.Drawing.Point(865, 172);
            this.txtShippingAddressLine2.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine2.Name = "txtShippingAddressLine2";
            this.txtShippingAddressLine2.Size = new System.Drawing.Size(115, 20);
            this.txtShippingAddressLine2.StyleController = this.LayoutControl;
            this.txtShippingAddressLine2.TabIndex = 1;
            this.txtShippingAddressLine2.TabStop = false;
            // 
            // itmShippingAddressLine3
            // 
            this.itmShippingAddressLine3.Control = this.txtShippingAddressLine3;
            this.itmShippingAddressLine3.CustomizationFormText = "Shipping Address Line 3";
            this.itmShippingAddressLine3.Location = new System.Drawing.Point(0, 48);
            this.itmShippingAddressLine3.Name = "itmShippingAddressLine3";
            this.itmShippingAddressLine3.Size = new System.Drawing.Size(211, 24);
            this.itmShippingAddressLine3.Text = "Line 3";
            this.itmShippingAddressLine3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtShippingAddressLine3
            // 
            this.txtShippingAddressLine3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine3", true));
            this.txtShippingAddressLine3.EnterMoveNextControl = true;
            this.txtShippingAddressLine3.Location = new System.Drawing.Point(865, 196);
            this.txtShippingAddressLine3.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine3.Name = "txtShippingAddressLine3";
            this.txtShippingAddressLine3.Size = new System.Drawing.Size(115, 20);
            this.txtShippingAddressLine3.StyleController = this.LayoutControl;
            this.txtShippingAddressLine3.TabIndex = 1;
            this.txtShippingAddressLine3.TabStop = false;
            // 
            // itmShippingAddressLine4
            // 
            this.itmShippingAddressLine4.Control = this.txtShippingAddressLine4;
            this.itmShippingAddressLine4.CustomizationFormText = "Shipping Address Line 4";
            this.itmShippingAddressLine4.Location = new System.Drawing.Point(0, 72);
            this.itmShippingAddressLine4.Name = "itmShippingAddressLine4";
            this.itmShippingAddressLine4.Size = new System.Drawing.Size(211, 24);
            this.itmShippingAddressLine4.Text = "Line 4";
            this.itmShippingAddressLine4.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtShippingAddressLine4
            // 
            this.txtShippingAddressLine4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressLine4", true));
            this.txtShippingAddressLine4.EnterMoveNextControl = true;
            this.txtShippingAddressLine4.Location = new System.Drawing.Point(865, 220);
            this.txtShippingAddressLine4.MenuManager = this.RibbonControl;
            this.txtShippingAddressLine4.Name = "txtShippingAddressLine4";
            this.txtShippingAddressLine4.Size = new System.Drawing.Size(115, 20);
            this.txtShippingAddressLine4.StyleController = this.LayoutControl;
            this.txtShippingAddressLine4.TabIndex = 1;
            this.txtShippingAddressLine4.TabStop = false;
            // 
            // itmShippingAddressCode
            // 
            this.itmShippingAddressCode.Control = this.txtShippingAddressCode;
            this.itmShippingAddressCode.CustomizationFormText = "Shipping Address Code";
            this.itmShippingAddressCode.Location = new System.Drawing.Point(0, 96);
            this.itmShippingAddressCode.Name = "itmShippingAddressCode";
            this.itmShippingAddressCode.Size = new System.Drawing.Size(211, 24);
            this.itmShippingAddressCode.Text = "Code";
            this.itmShippingAddressCode.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtShippingAddressCode
            // 
            this.txtShippingAddressCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingAddressCode", true));
            this.txtShippingAddressCode.EnterMoveNextControl = true;
            this.txtShippingAddressCode.Location = new System.Drawing.Point(865, 244);
            this.txtShippingAddressCode.MenuManager = this.RibbonControl;
            this.txtShippingAddressCode.Name = "txtShippingAddressCode";
            this.txtShippingAddressCode.Size = new System.Drawing.Size(115, 20);
            this.txtShippingAddressCode.StyleController = this.LayoutControl;
            this.txtShippingAddressCode.TabIndex = 1;
            this.txtShippingAddressCode.TabStop = false;
            // 
            // simpleSeparator2
            // 
            this.simpleSeparator2.AllowHotTrack = false;
            this.simpleSeparator2.CustomizationFormText = "simpleSeparator2";
            this.simpleSeparator2.Location = new System.Drawing.Point(510, 0);
            this.simpleSeparator2.Name = "simpleSeparator2";
            this.simpleSeparator2.Size = new System.Drawing.Size(2, 237);
            this.simpleSeparator2.Text = "simpleSeparator2";
            // 
            // simpleSeparator4
            // 
            this.simpleSeparator4.AllowHotTrack = false;
            this.simpleSeparator4.CustomizationFormText = "simpleSeparator4";
            this.simpleSeparator4.Location = new System.Drawing.Point(512, 72);
            this.simpleSeparator4.Name = "simpleSeparator4";
            this.simpleSeparator4.Size = new System.Drawing.Size(452, 2);
            this.simpleSeparator4.Text = "simpleSeparator4";
            // 
            // itmCompany
            // 
            this.itmCompany.Control = this.ddlCompany;
            this.itmCompany.CustomizationFormText = "Company";
            this.itmCompany.Location = new System.Drawing.Point(0, 0);
            this.itmCompany.Name = "itmCompany";
            this.itmCompany.Size = new System.Drawing.Size(510, 24);
            this.itmCompany.Text = "Company";
            this.itmCompany.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ddlCompany
            // 
            this.ddlCompany.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "CompanyId", true));
            this.ddlCompany.EnterMoveNextControl = true;
            this.ddlCompany.Location = new System.Drawing.Point(116, 43);
            this.ddlCompany.MenuManager = this.RibbonControl;
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCompany.Properties.DataSource = this.InstantFeedbackSourceCompany;
            this.ddlCompany.Properties.DisplayMember = "Title";
            this.ddlCompany.Properties.NullText = "Select Company ...";
            this.ddlCompany.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ddlCompany.Properties.ValueMember = "Id";
            this.ddlCompany.Properties.View = this.ddlCompanyView;
            this.ddlCompany.Size = new System.Drawing.Size(414, 20);
            this.ddlCompany.StyleController = this.LayoutControl;
            this.ddlCompany.TabIndex = 0;
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
            // ddlCompanyView
            // 
            this.ddlCompanyView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCode,
            this.colAreaCode,
            this.colAccountsContact,
            this.colAccountsTelephone,
            this.colSalesContact,
            this.colSalesTelephone,
            this.colActive});
            this.ddlCompanyView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ddlCompanyView.Name = "ddlCompanyView";
            this.ddlCompanyView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ddlCompanyView.OptionsView.ShowGroupPanel = false;
            this.ddlCompanyView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
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
            // itmReferenceShort1
            // 
            this.itmReferenceShort1.Control = this.txtReferenceShort1;
            this.itmReferenceShort1.CustomizationFormText = "Reference Short 1";
            this.itmReferenceShort1.Location = new System.Drawing.Point(0, 24);
            this.itmReferenceShort1.Name = "itmReferenceShort1";
            this.itmReferenceShort1.Size = new System.Drawing.Size(242, 24);
            this.itmReferenceShort1.Text = "Reference Short 1";
            this.itmReferenceShort1.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceShort1
            // 
            this.txtReferenceShort1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort1", true));
            this.txtReferenceShort1.EnterMoveNextControl = true;
            this.txtReferenceShort1.Location = new System.Drawing.Point(116, 67);
            this.txtReferenceShort1.MenuManager = this.RibbonControl;
            this.txtReferenceShort1.Name = "txtReferenceShort1";
            this.txtReferenceShort1.Size = new System.Drawing.Size(146, 20);
            this.txtReferenceShort1.StyleController = this.LayoutControl;
            this.txtReferenceShort1.TabIndex = 2;
            // 
            // itmReferenceShort3
            // 
            this.itmReferenceShort3.Control = this.txtReferenceShort3;
            this.itmReferenceShort3.CustomizationFormText = "Reference Short 3";
            this.itmReferenceShort3.Location = new System.Drawing.Point(0, 72);
            this.itmReferenceShort3.Name = "itmReferenceShort3";
            this.itmReferenceShort3.Size = new System.Drawing.Size(242, 24);
            this.itmReferenceShort3.Text = "Reference Short 3";
            this.itmReferenceShort3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceShort3
            // 
            this.txtReferenceShort3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort3", true));
            this.txtReferenceShort3.EnterMoveNextControl = true;
            this.txtReferenceShort3.Location = new System.Drawing.Point(116, 115);
            this.txtReferenceShort3.MenuManager = this.RibbonControl;
            this.txtReferenceShort3.Name = "txtReferenceShort3";
            this.txtReferenceShort3.Size = new System.Drawing.Size(146, 20);
            this.txtReferenceShort3.StyleController = this.LayoutControl;
            this.txtReferenceShort3.TabIndex = 6;
            // 
            // itmReferenceShort4
            // 
            this.itmReferenceShort4.Control = this.txtReferenceShort4;
            this.itmReferenceShort4.CustomizationFormText = "Reference Short 4";
            this.itmReferenceShort4.Location = new System.Drawing.Point(0, 96);
            this.itmReferenceShort4.Name = "itmReferenceShort4";
            this.itmReferenceShort4.Size = new System.Drawing.Size(242, 24);
            this.itmReferenceShort4.Text = "Reference Short 4";
            this.itmReferenceShort4.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceShort4
            // 
            this.txtReferenceShort4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort4", true));
            this.txtReferenceShort4.EnterMoveNextControl = true;
            this.txtReferenceShort4.Location = new System.Drawing.Point(116, 139);
            this.txtReferenceShort4.MenuManager = this.RibbonControl;
            this.txtReferenceShort4.Name = "txtReferenceShort4";
            this.txtReferenceShort4.Size = new System.Drawing.Size(146, 20);
            this.txtReferenceShort4.StyleController = this.LayoutControl;
            this.txtReferenceShort4.TabIndex = 8;
            // 
            // itmReferenceShort2
            // 
            this.itmReferenceShort2.Control = this.txtReferenceShort2;
            this.itmReferenceShort2.CustomizationFormText = "Reference Short 2";
            this.itmReferenceShort2.Location = new System.Drawing.Point(0, 48);
            this.itmReferenceShort2.Name = "itmReferenceShort2";
            this.itmReferenceShort2.Size = new System.Drawing.Size(242, 24);
            this.itmReferenceShort2.Text = "Reference Short 2";
            this.itmReferenceShort2.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceShort2
            // 
            this.txtReferenceShort2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort2", true));
            this.txtReferenceShort2.EnterMoveNextControl = true;
            this.txtReferenceShort2.Location = new System.Drawing.Point(116, 91);
            this.txtReferenceShort2.MenuManager = this.RibbonControl;
            this.txtReferenceShort2.Name = "txtReferenceShort2";
            this.txtReferenceShort2.Size = new System.Drawing.Size(146, 20);
            this.txtReferenceShort2.StyleController = this.LayoutControl;
            this.txtReferenceShort2.TabIndex = 4;
            // 
            // itmReferenceShort5
            // 
            this.itmReferenceShort5.Control = this.txtReferenceShort5;
            this.itmReferenceShort5.CustomizationFormText = "Reference Short 5";
            this.itmReferenceShort5.Location = new System.Drawing.Point(0, 120);
            this.itmReferenceShort5.Name = "itmReferenceShort5";
            this.itmReferenceShort5.Size = new System.Drawing.Size(242, 24);
            this.itmReferenceShort5.Text = "Reference Short 5";
            this.itmReferenceShort5.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceShort5
            // 
            this.txtReferenceShort5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceShort5", true));
            this.txtReferenceShort5.EnterMoveNextControl = true;
            this.txtReferenceShort5.Location = new System.Drawing.Point(116, 163);
            this.txtReferenceShort5.MenuManager = this.RibbonControl;
            this.txtReferenceShort5.Name = "txtReferenceShort5";
            this.txtReferenceShort5.Size = new System.Drawing.Size(146, 20);
            this.txtReferenceShort5.StyleController = this.LayoutControl;
            this.txtReferenceShort5.TabIndex = 10;
            // 
            // itmReferenceLong4
            // 
            this.itmReferenceLong4.Control = this.txtReferenceLong4;
            this.itmReferenceLong4.CustomizationFormText = "Reference Long 4";
            this.itmReferenceLong4.Location = new System.Drawing.Point(244, 96);
            this.itmReferenceLong4.Name = "itmReferenceLong4";
            this.itmReferenceLong4.Size = new System.Drawing.Size(266, 24);
            this.itmReferenceLong4.Text = "Reference Long 4";
            this.itmReferenceLong4.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceLong4
            // 
            this.txtReferenceLong4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong4", true));
            this.txtReferenceLong4.EnterMoveNextControl = true;
            this.txtReferenceLong4.Location = new System.Drawing.Point(360, 139);
            this.txtReferenceLong4.MenuManager = this.RibbonControl;
            this.txtReferenceLong4.Name = "txtReferenceLong4";
            this.txtReferenceLong4.Size = new System.Drawing.Size(170, 20);
            this.txtReferenceLong4.StyleController = this.LayoutControl;
            this.txtReferenceLong4.TabIndex = 9;
            // 
            // itmReferenceLong5
            // 
            this.itmReferenceLong5.Control = this.txtReferenceLong5;
            this.itmReferenceLong5.CustomizationFormText = "Reference Long 5";
            this.itmReferenceLong5.Location = new System.Drawing.Point(244, 120);
            this.itmReferenceLong5.Name = "itmReferenceLong5";
            this.itmReferenceLong5.Size = new System.Drawing.Size(266, 24);
            this.itmReferenceLong5.Text = "Reference Long 5";
            this.itmReferenceLong5.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtReferenceLong5
            // 
            this.txtReferenceLong5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ReferenceLong5", true));
            this.txtReferenceLong5.EnterMoveNextControl = true;
            this.txtReferenceLong5.Location = new System.Drawing.Point(360, 163);
            this.txtReferenceLong5.MenuManager = this.RibbonControl;
            this.txtReferenceLong5.Name = "txtReferenceLong5";
            this.txtReferenceLong5.Size = new System.Drawing.Size(170, 20);
            this.txtReferenceLong5.StyleController = this.LayoutControl;
            this.txtReferenceLong5.TabIndex = 11;
            // 
            // itmShippingType
            // 
            this.itmShippingType.Control = this.ddlShippingType;
            this.itmShippingType.CustomizationFormText = "Shipping Type";
            this.itmShippingType.Location = new System.Drawing.Point(244, 144);
            this.itmShippingType.Name = "itmShippingType";
            this.itmShippingType.Size = new System.Drawing.Size(266, 24);
            this.itmShippingType.Text = "Shipping Type";
            this.itmShippingType.TextSize = new System.Drawing.Size(88, 13);
            this.itmShippingType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // ddlShippingType
            // 
            this.ddlShippingType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceTransaction, "ShippingTypeId", true));
            this.ddlShippingType.EnterMoveNextControl = true;
            this.ddlShippingType.Location = new System.Drawing.Point(360, 187);
            this.ddlShippingType.MenuManager = this.RibbonControl;
            this.ddlShippingType.Name = "ddlShippingType";
            this.ddlShippingType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlShippingType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlShippingType.Properties.DataSource = this.ServerModeSourceShippingType;
            this.ddlShippingType.Properties.DisplayMember = "Name";
            this.ddlShippingType.Properties.NullText = "Select Shipping Type...";
            this.ddlShippingType.Properties.ValueMember = "Id";
            this.ddlShippingType.Size = new System.Drawing.Size(170, 20);
            this.ddlShippingType.StyleController = this.LayoutControl;
            this.ddlShippingType.TabIndex = 1;
            this.ddlShippingType.TabStop = false;
            // 
            // ServerModeSourceShippingType
            // 
            this.ServerModeSourceShippingType.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_TRX_ShippingType);
            this.ServerModeSourceShippingType.KeyExpression = "Id";
            // 
            // ServerModeSourcePaymentType
            // 
            this.ServerModeSourcePaymentType.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_PaymentTerm);
            this.ServerModeSourcePaymentType.KeyExpression = "Id";
            // 
            // radMenu
            // 
            this.radMenu.ItemLinks.Add(this.btnSave);
            this.radMenu.Name = "radMenu";
            this.radMenu.Ribbon = this.RibbonControl;
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
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(443, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(116, 541);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Fullname", "Fullname", 52, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.txtCreatedBy.Properties.DataSource = this.ServerModeSourceCreatedBy;
            this.txtCreatedBy.Properties.DisplayMember = "Fullname";
            this.txtCreatedBy.Properties.NullText = "";
            this.txtCreatedBy.Properties.ValueMember = "Id";
            this.txtCreatedBy.Size = new System.Drawing.Size(347, 20);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 13;
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
            this.itmCreatedOn.Location = new System.Drawing.Point(443, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(521, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(88, 13);
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(559, 541);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Size = new System.Drawing.Size(425, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 14;
            // 
            // repositoryItemOfficeColorPickEdit1
            // 
            this.repositoryItemOfficeColorPickEdit1.AutoHeight = false;
            this.repositoryItemOfficeColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemOfficeColorPickEdit1.Name = "repositoryItemOfficeColorPickEdit1";
            // 
            // btnEmailOnly
            // 
            this.btnEmailOnly.Caption = "Email";
            this.btnEmailOnly.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.mail_16;
            this.btnEmailOnly.Id = 28;
            this.btnEmailOnly.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.mail_32;
            this.btnEmailOnly.Name = "btnEmailOnly";
            this.btnEmailOnly.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEmailOnly.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmailOnly_ItemClick);
            // 
            // rpDocument
            // 
            this.rpDocument.Appearance.BorderColor = System.Drawing.Color.Lime;
            this.rpDocument.Appearance.Options.UseBorderColor = true;
            this.rpDocument.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgActionDocument});
            this.rpDocument.Name = "rpDocument";
            this.rpDocument.Text = "Document";
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnEmailOnly);
            this.rpgActionDocument.Name = "rpgActionDocument";
            this.rpgActionDocument.Text = "Action";
            // 
            // BaseDocument
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "BaseDocument";
            this.ShouldRecover = true;
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseDocument_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumberFourDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmVatNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTypeDropdownSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmExpirationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExpirationDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExpirationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDueDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBillingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressLine4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingAddressCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAddressCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgShippingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressLine4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingAddressCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAddressCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceShort5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceShort5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReferenceLong5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferenceLong5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShippingType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceShippingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePaymentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemOfficeColorPickEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnLostSale;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort2;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort1;
        protected System.Windows.Forms.BindingSource BindingSourceLine;
        private DevExpress.XtraEditors.LookUpEdit ddlShippingType;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingType;
        private DevExpress.XtraEditors.TextEdit txtVatNumber;
        private DevExpress.XtraEditors.TextEdit txtContactPerson;
        private DevExpress.XtraEditors.TextEdit txtTelephone;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong3;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong2;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong1;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong1;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong2;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong3;
        private DevExpress.XtraLayout.LayoutControlItem itmTelephone;
        private DevExpress.XtraLayout.LayoutControlItem itmContact;
        private DevExpress.XtraLayout.LayoutControlItem itmVatNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine1;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddress;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort1;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repNumber;
        private DevExpress.XtraEditors.MemoEdit txtMessage;
        private DevExpress.XtraGrid.GridControl grdItems;
        private DevExpress.XtraGrid.Views.Grid.GridView grvItems;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceChanged;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyOutstanding;
        private DevExpress.XtraGrid.Columns.GridColumn colProfitPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn colItemId;
        private DevExpress.XtraLayout.LayoutControlItem itmMessage;
        private DevExpress.XtraLayout.LayoutControlItem itmItems;
        private DevExpress.XtraEditors.DateEdit dtDueDate;
        private DevExpress.XtraEditors.DateEdit dtExpirationDate;
        private DevExpress.XtraLayout.LayoutControlItem itmExpirationDate;
        private DevExpress.XtraLayout.LayoutControlItem itmDueDate;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraLayout.EmptySpaceItem itmTypeDropdownSpace;
        private DevExpress.XtraLayout.LayoutControlGroup itmDetails;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceShippingType;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePaymentType;
        protected DevExpress.XtraBars.Ribbon.RadialMenu radMenu;
        protected System.Windows.Forms.BindingSource BindingSourceTransaction;
        private DevExpress.XtraEditors.TextEdit txtBillingAddress;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBillingAddress;
        private DevExpress.XtraLayout.LayoutControlGroup lcgShippingAddress;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressCode;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressCode;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine4;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine3;
        private DevExpress.XtraEditors.TextEdit txtShippingAddressLine2;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressLine4;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressLine3;
        private DevExpress.XtraEditors.TextEdit txtBillingAddressLine2;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine2;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine3;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressLine4;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingAddressCode;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressLine2;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressLine3;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressLine4;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingAddressCode;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator3;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator4;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repLineEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView repViewEntity;
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
        private DevExpress.XtraGrid.Columns.GridColumn colSearchType;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyReceived;
        private DevExpress.XtraLayout.LayoutControlItem itmCompany;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCreatedBy;
        private DevExpress.XtraEditors.LookUpEdit txtCreatedBy;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong5;
        private DevExpress.XtraEditors.TextEdit txtReferenceLong4;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort5;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort4;
        private DevExpress.XtraEditors.TextEdit txtReferenceShort3;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort3;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort4;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceShort5;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong4;
        private DevExpress.XtraLayout.LayoutControlItem itmReferenceLong5;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceCompany;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView ddlCompanyView;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsContact;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesContact;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repNumberFourDecimal;
        private DevExpress.Office.UI.RepositoryItemOfficeColorPickEdit repositoryItemOfficeColorPickEdit1;
        private DevExpress.XtraBars.BarButtonItem btnEmailOnly;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDocument;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActionDocument;
        private DevExpress.XtraGrid.Columns.GridColumn colAreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitAverage;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourceItem;
    }
}
