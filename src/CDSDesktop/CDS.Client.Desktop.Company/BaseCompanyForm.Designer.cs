namespace CDS.Client.Desktop.Company
{
    partial class BaseCompanyForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lcgDetails = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.BindingSourceORGEntity = new System.Windows.Forms.BindingSource();
            this.itmVatNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVatNumber = new DevExpress.XtraEditors.TextEdit();
            this.itmSalesContact = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlSalesContact = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ServerModeSourceContactSales = new DevExpress.Data.Linq.LinqServerModeSource();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmAccountingContact = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlAccountContact = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ServerModeSourceContactAccount = new DevExpress.Data.Linq.LinqServerModeSource();
            this.gridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullname1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceORGEntitySYSEntity = new System.Windows.Forms.BindingSource();
            this.itmPrefix = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPrefix = new DevExpress.XtraEditors.TextEdit();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.itmRegistrationNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRegistrationNumber = new DevExpress.XtraEditors.TextEdit();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtAreaCode = new DevExpress.XtraEditors.TextEdit();
            this.txtDiscountCode = new DevExpress.XtraEditors.TextEdit();
            this.txtRepCode = new DevExpress.XtraEditors.TextEdit();
            this.txtSalesmanCode = new DevExpress.XtraEditors.TextEdit();
            this.txtTagCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCountryCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomValue1 = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomValue2 = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomValue3 = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomValue4 = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomValue5 = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomValue6 = new DevExpress.XtraEditors.TextEdit();
            this.tcgInformation = new DevExpress.XtraLayout.TabbedControlGroup();
            this.tabAccountingInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgAccountTypeInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmPaymentTerm = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlPaymentTerm = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourcePaymentTerm = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmCostCategory = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlCostCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCostCategory = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmAccountLimit = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAccountLimit = new DevExpress.XtraEditors.TextEdit();
            this.itmOpenItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkOpenItem = new DevExpress.XtraEditors.CheckEdit();
            this.itmOverrideAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkOverrideAccount = new DevExpress.XtraEditors.CheckEdit();
            this.itmStatementPreference = new DevExpress.XtraLayout.LayoutControlItem();
            this.clbStatementPreference = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.ServerModeSourceStatementPreference = new DevExpress.Data.Linq.LinqServerModeSource();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabGeneralInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgCustomValues = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCustomValue1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCustomValue2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCustomValue3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCustomValue4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCustomValue5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCustomValue6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgCompanyCode = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAreaCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmRepCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmTagCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmDiscountCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmSalesmanCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCountryCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabAddressInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgShippingAddress = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmShippingLine1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingLine1 = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceShippingAddress = new System.Windows.Forms.BindingSource();
            this.itmShippingLine2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingLine2 = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingLine3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingLine3 = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingLine4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingLine4 = new DevExpress.XtraEditors.TextEdit();
            this.itmShippingCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShippingCode = new DevExpress.XtraEditors.TextEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgBillingAddress = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmBillingLine1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingLine1 = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceBillingAddress = new System.Windows.Forms.BindingSource();
            this.itmBillingLine2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingLine2 = new DevExpress.XtraEditors.TextEdit();
            this.itmBillingLine3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingLine3 = new DevExpress.XtraEditors.TextEdit();
            this.itmBillingLine4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingLine4 = new DevExpress.XtraEditors.TextEdit();
            this.itmBillingCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingCode = new DevExpress.XtraEditors.TextEdit();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabTransactions = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmGridTransactions = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdTransactions = new DevExpress.XtraGrid.GridControl();
            this.InstantFeedbackSourceTransaction = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.grvTransactions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocumentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnReserve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnOrder2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitAverage1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYourReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOurReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesManCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceShort4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceShort5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstPrintedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrintedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstPrintedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPrintedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRounding = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabOrdering = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgTeccomDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmTeccomHeader = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTeccomHeader = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceORGDistribution = new System.Windows.Forms.BindingSource();
            this.itmPath = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPath = new DevExpress.XtraEditors.ButtonEdit();
            this.itmCustomerCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.itmDistributionNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDistributionNumber = new DevExpress.XtraEditors.TextEdit();
            this.itmSupplierCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSupplierCode = new DevExpress.XtraEditors.TextEdit();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmDistributionType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlDistributionType = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceDistributionType = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmDistributionUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDistributionUserName = new DevExpress.XtraEditors.TextEdit();
            this.itmUrl = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUrl = new DevExpress.XtraEditors.TextEdit();
            this.itmDistributionPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDistributionPassword = new DevExpress.XtraEditors.TextEdit();
            this.itmInventoryViewLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtInventoryViewLevel = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkViewCost = new DevExpress.XtraEditors.CheckEdit();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgCustomerGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.itmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.tabHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmHistory = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdHistory = new DevExpress.XtraGrid.GridControl();
            this.InstantFeedbackSourceHistory = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.grvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFinancialYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcgFilters = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.clbDocumentType = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.ServerModeSourceDocumentType = new DevExpress.Data.Linq.LinqServerModeSource();
            this.BindingSourceCompanyShippingAddress = new System.Windows.Forms.BindingSource();
            this.BindingSourceCompanyBillingAddress = new System.Windows.Forms.BindingSource();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCreatedBy = new DevExpress.Data.Linq.LinqServerModeSource();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.BindingSourceContacts = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceORGEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmVatNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSalesContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSalesContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContactSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountingContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccountContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContactAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceORGEntitySYSEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPrefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRegistrationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesmanCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTagCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountryCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAccountingInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAccountTypeInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPaymentTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPaymentTerm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePaymentTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCostCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCostCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCostCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountLimit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOpenItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpenItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOverrideAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOverrideAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatementPreference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbStatementPreference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceStatementPreference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGeneralInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCustomValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompanyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTagCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDiscountCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSalesmanCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCountryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAddressInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgShippingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceShippingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBillingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBillingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOrdering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgTeccomDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTeccomHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeccomHeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceORGDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistributionNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDistributionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDistributionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistributionUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistributionPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmInventoryViewLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventoryViewLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCustomerGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbDocumentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDocumentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompanyShippingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompanyBillingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_Company);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.clbStatementPreference);
            this.LayoutControl.Controls.Add(this.grdHistory);
            this.LayoutControl.Controls.Add(this.txtPassword);
            this.LayoutControl.Controls.Add(this.txtUserName);
            this.LayoutControl.Controls.Add(this.clbDocumentType);
            this.LayoutControl.Controls.Add(this.grdTransactions);
            this.LayoutControl.Controls.Add(this.txtDistributionPassword);
            this.LayoutControl.Controls.Add(this.txtDistributionUserName);
            this.LayoutControl.Controls.Add(this.txtUrl);
            this.LayoutControl.Controls.Add(this.chkViewCost);
            this.LayoutControl.Controls.Add(this.txtSupplierCode);
            this.LayoutControl.Controls.Add(this.txtCustomerCode);
            this.LayoutControl.Controls.Add(this.txtTeccomHeader);
            this.LayoutControl.Controls.Add(this.txtInventoryViewLevel);
            this.LayoutControl.Controls.Add(this.ddlDistributionType);
            this.LayoutControl.Controls.Add(this.txtDistributionNumber);
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.txtPrefix);
            this.LayoutControl.Controls.Add(this.txtAccountLimit);
            this.LayoutControl.Controls.Add(this.chkOverrideAccount);
            this.LayoutControl.Controls.Add(this.chkOpenItem);
            this.LayoutControl.Controls.Add(this.ddlCostCategory);
            this.LayoutControl.Controls.Add(this.ddlPaymentTerm);
            this.LayoutControl.Controls.Add(this.txtBillingCode);
            this.LayoutControl.Controls.Add(this.txtShippingCode);
            this.LayoutControl.Controls.Add(this.txtBillingLine4);
            this.LayoutControl.Controls.Add(this.txtShippingLine4);
            this.LayoutControl.Controls.Add(this.txtBillingLine3);
            this.LayoutControl.Controls.Add(this.txtShippingLine3);
            this.LayoutControl.Controls.Add(this.txtBillingLine2);
            this.LayoutControl.Controls.Add(this.txtShippingLine2);
            this.LayoutControl.Controls.Add(this.txtBillingLine1);
            this.LayoutControl.Controls.Add(this.txtShippingLine1);
            this.LayoutControl.Controls.Add(this.txtCustomValue6);
            this.LayoutControl.Controls.Add(this.txtCustomValue5);
            this.LayoutControl.Controls.Add(this.txtCustomValue4);
            this.LayoutControl.Controls.Add(this.txtCustomValue3);
            this.LayoutControl.Controls.Add(this.txtCustomValue2);
            this.LayoutControl.Controls.Add(this.txtCustomValue1);
            this.LayoutControl.Controls.Add(this.txtCountryCode);
            this.LayoutControl.Controls.Add(this.txtTagCode);
            this.LayoutControl.Controls.Add(this.txtSalesmanCode);
            this.LayoutControl.Controls.Add(this.txtRepCode);
            this.LayoutControl.Controls.Add(this.txtDiscountCode);
            this.LayoutControl.Controls.Add(this.txtAreaCode);
            this.LayoutControl.Controls.Add(this.txtVatNumber);
            this.LayoutControl.Controls.Add(this.txtNote);
            this.LayoutControl.Controls.Add(this.ddlAccountContact);
            this.LayoutControl.Controls.Add(this.ddlSalesContact);
            this.LayoutControl.Controls.Add(this.txtRegistrationNumber);
            this.LayoutControl.Controls.Add(this.txtCode);
            this.LayoutControl.Controls.Add(this.txtPath);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgFilters});
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1043, 173, 631, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(1008, 631);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgDetails,
            this.tcgInformation,
            this.lcgHistory});
            this.LayoutGroup.Size = new System.Drawing.Size(1008, 631);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            // lcgDetails
            // 
            this.lcgDetails.CustomizationFormText = "Details";
            this.lcgDetails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmNote,
            this.itmVatNumber,
            this.itmSalesContact,
            this.itmAccountingContact,
            this.itmCode,
            this.itmPrefix,
            this.itmName,
            this.itmRegistrationNumber,
            this.emptySpaceItem2});
            this.lcgDetails.Location = new System.Drawing.Point(0, 0);
            this.lcgDetails.Name = "lcgDetails";
            this.lcgDetails.Size = new System.Drawing.Size(988, 167);
            this.lcgDetails.Text = "Details";
            // 
            // itmNote
            // 
            this.itmNote.Control = this.txtNote;
            this.itmNote.CustomizationFormText = "Note";
            this.itmNote.Location = new System.Drawing.Point(0, 96);
            this.itmNote.Name = "itmNote";
            this.itmNote.Size = new System.Drawing.Size(964, 28);
            this.itmNote.Text = "Note";
            this.itmNote.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtNote
            // 
            this.txtNote.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGEntity, "Note", true));
            this.txtNote.Location = new System.Drawing.Point(134, 139);
            this.txtNote.MenuManager = this.RibbonControl;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(850, 24);
            this.txtNote.StyleController = this.LayoutControl;
            this.txtNote.TabIndex = 9;
            // 
            // BindingSourceORGEntity
            // 
            this.BindingSourceORGEntity.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_Entity);
            // 
            // itmVatNumber
            // 
            this.itmVatNumber.Control = this.txtVatNumber;
            this.itmVatNumber.CustomizationFormText = "Vat Number";
            this.itmVatNumber.Location = new System.Drawing.Point(0, 48);
            this.itmVatNumber.Name = "itmVatNumber";
            this.itmVatNumber.Size = new System.Drawing.Size(494, 24);
            this.itmVatNumber.Text = "Vat Number";
            this.itmVatNumber.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtVatNumber
            // 
            this.txtVatNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGEntity, "VatNumber", true));
            this.txtVatNumber.Location = new System.Drawing.Point(134, 91);
            this.txtVatNumber.MenuManager = this.RibbonControl;
            this.txtVatNumber.Name = "txtVatNumber";
            this.txtVatNumber.Size = new System.Drawing.Size(380, 20);
            this.txtVatNumber.StyleController = this.LayoutControl;
            this.txtVatNumber.TabIndex = 17;
            // 
            // itmSalesContact
            // 
            this.itmSalesContact.Control = this.ddlSalesContact;
            this.itmSalesContact.CustomizationFormText = "Sales Contact";
            this.itmSalesContact.Location = new System.Drawing.Point(0, 72);
            this.itmSalesContact.Name = "itmSalesContact";
            this.itmSalesContact.Size = new System.Drawing.Size(494, 24);
            this.itmSalesContact.Text = "Sales Contact";
            this.itmSalesContact.TextSize = new System.Drawing.Size(106, 13);
            // 
            // ddlSalesContact
            // 
            this.ddlSalesContact.Location = new System.Drawing.Point(134, 115);
            this.ddlSalesContact.MenuManager = this.RibbonControl;
            this.ddlSalesContact.Name = "ddlSalesContact";
            this.ddlSalesContact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)), serializableAppearanceObject2, "", "New", null, true)});
            this.ddlSalesContact.Properties.DataSource = this.ServerModeSourceContactSales;
            this.ddlSalesContact.Properties.DisplayMember = "Fullname";
            this.ddlSalesContact.Properties.NullText = "Sales Contact...";
            this.ddlSalesContact.Properties.ValueMember = "Id";
            this.ddlSalesContact.Properties.View = this.gridLookUpEdit1View;
            this.ddlSalesContact.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ddlSalesContact_Properties_ButtonClick);
            this.ddlSalesContact.Size = new System.Drawing.Size(380, 20);
            this.ddlSalesContact.StyleController = this.LayoutControl;
            this.ddlSalesContact.TabIndex = 7;
            this.ddlSalesContact.EditValueChanged += new System.EventHandler(this.ddlSalesContact_EditValueChanged);
            // 
            // ServerModeSourceContactSales
            // 
            this.ServerModeSourceContactSales.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Contact);
            this.ServerModeSourceContactSales.KeyExpression = "Id";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.ChildGridLevelName = "s";
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colCompanyId,
            this.colDepartmentId,
            this.colName,
            this.colSurname,
            this.colFullname,
            this.colEmail,
            this.colFax,
            this.colTelephone1,
            this.colTelephone2,
            this.colNote});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colCompanyId
            // 
            this.colCompanyId.FieldName = "CompanyId";
            this.colCompanyId.Name = "colCompanyId";
            // 
            // colDepartmentId
            // 
            this.colDepartmentId.FieldName = "DepartmentId";
            this.colDepartmentId.Name = "colDepartmentId";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            // 
            // colSurname
            // 
            this.colSurname.FieldName = "Surname";
            this.colSurname.Name = "colSurname";
            // 
            // colFullname
            // 
            this.colFullname.FieldName = "Fullname";
            this.colFullname.Name = "colFullname";
            this.colFullname.Visible = true;
            this.colFullname.VisibleIndex = 0;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 1;
            // 
            // colFax
            // 
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 2;
            // 
            // colTelephone1
            // 
            this.colTelephone1.FieldName = "Telephone1";
            this.colTelephone1.Name = "colTelephone1";
            this.colTelephone1.Visible = true;
            this.colTelephone1.VisibleIndex = 3;
            // 
            // colTelephone2
            // 
            this.colTelephone2.FieldName = "Telephone2";
            this.colTelephone2.Name = "colTelephone2";
            this.colTelephone2.Visible = true;
            this.colTelephone2.VisibleIndex = 4;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            // 
            // itmAccountingContact
            // 
            this.itmAccountingContact.Control = this.ddlAccountContact;
            this.itmAccountingContact.CustomizationFormText = "Accounting Contact";
            this.itmAccountingContact.Location = new System.Drawing.Point(494, 72);
            this.itmAccountingContact.Name = "itmAccountingContact";
            this.itmAccountingContact.Size = new System.Drawing.Size(470, 24);
            this.itmAccountingContact.Text = "Accounting Contact";
            this.itmAccountingContact.TextSize = new System.Drawing.Size(106, 13);
            // 
            // ddlAccountContact
            // 
            this.ddlAccountContact.Location = new System.Drawing.Point(628, 115);
            this.ddlAccountContact.MenuManager = this.RibbonControl;
            this.ddlAccountContact.Name = "ddlAccountContact";
            this.ddlAccountContact.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)), serializableAppearanceObject1, "", "New", null, true)});
            this.ddlAccountContact.Properties.DataSource = this.ServerModeSourceContactAccount;
            this.ddlAccountContact.Properties.DisplayMember = "Fullname";
            this.ddlAccountContact.Properties.NullText = "Account Contact...";
            this.ddlAccountContact.Properties.ValueMember = "Id";
            this.ddlAccountContact.Properties.View = this.gridLookUpEdit2View;
            this.ddlAccountContact.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ddlAccountContact_Properties_ButtonClick);
            this.ddlAccountContact.Size = new System.Drawing.Size(356, 20);
            this.ddlAccountContact.StyleController = this.LayoutControl;
            this.ddlAccountContact.TabIndex = 8;
            this.ddlAccountContact.EditValueChanged += new System.EventHandler(this.ddlAccountContact_EditValueChanged);
            // 
            // ServerModeSourceContactAccount
            // 
            this.ServerModeSourceContactAccount.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Contact);
            this.ServerModeSourceContactAccount.KeyExpression = "Id";
            // 
            // gridLookUpEdit2View
            // 
            this.gridLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId1,
            this.colCompanyId1,
            this.colDepartmentId1,
            this.colName1,
            this.colSurname1,
            this.colFullname1,
            this.colEmail1,
            this.colFax1,
            this.colTelephone11,
            this.colTelephone21,
            this.colNote1});
            this.gridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit2View.Name = "gridLookUpEdit2View";
            this.gridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // colId1
            // 
            this.colId1.FieldName = "Id";
            this.colId1.Name = "colId1";
            // 
            // colCompanyId1
            // 
            this.colCompanyId1.FieldName = "CompanyId";
            this.colCompanyId1.Name = "colCompanyId1";
            // 
            // colDepartmentId1
            // 
            this.colDepartmentId1.FieldName = "DepartmentId";
            this.colDepartmentId1.Name = "colDepartmentId1";
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            // 
            // colSurname1
            // 
            this.colSurname1.FieldName = "Surname";
            this.colSurname1.Name = "colSurname1";
            // 
            // colFullname1
            // 
            this.colFullname1.FieldName = "Fullname";
            this.colFullname1.Name = "colFullname1";
            this.colFullname1.Visible = true;
            this.colFullname1.VisibleIndex = 0;
            // 
            // colEmail1
            // 
            this.colEmail1.FieldName = "Email";
            this.colEmail1.Name = "colEmail1";
            this.colEmail1.Visible = true;
            this.colEmail1.VisibleIndex = 1;
            // 
            // colFax1
            // 
            this.colFax1.FieldName = "Fax";
            this.colFax1.Name = "colFax1";
            this.colFax1.Visible = true;
            this.colFax1.VisibleIndex = 2;
            // 
            // colTelephone11
            // 
            this.colTelephone11.FieldName = "Telephone1";
            this.colTelephone11.Name = "colTelephone11";
            this.colTelephone11.Visible = true;
            this.colTelephone11.VisibleIndex = 3;
            // 
            // colTelephone21
            // 
            this.colTelephone21.FieldName = "Telephone2";
            this.colTelephone21.Name = "colTelephone21";
            this.colTelephone21.Visible = true;
            this.colTelephone21.VisibleIndex = 4;
            // 
            // colNote1
            // 
            this.colNote1.FieldName = "Note";
            this.colNote1.Name = "colNote1";
            // 
            // itmCode
            // 
            this.itmCode.Control = this.txtCode;
            this.itmCode.CustomizationFormText = "Code";
            this.itmCode.Location = new System.Drawing.Point(0, 0);
            this.itmCode.Name = "itmCode";
            this.itmCode.Size = new System.Drawing.Size(246, 24);
            this.itmCode.Text = "Code";
            this.itmCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtCode
            // 
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGEntitySYSEntity, "CodeSub", true));
            this.txtCode.Location = new System.Drawing.Point(134, 43);
            this.txtCode.MenuManager = this.RibbonControl;
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(132, 20);
            this.txtCode.StyleController = this.LayoutControl;
            this.txtCode.TabIndex = 5;
            this.txtCode.TabStop = false;
            // 
            // BindingSourceORGEntitySYSEntity
            // 
            this.BindingSourceORGEntitySYSEntity.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Entity);
            // 
            // itmPrefix
            // 
            this.itmPrefix.Control = this.txtPrefix;
            this.itmPrefix.CustomizationFormText = "itmPrefix";
            this.itmPrefix.DataBindings.Add(new System.Windows.Forms.Binding("CustomizationFormText", this.BindingSource, "Prefix", true));
            this.itmPrefix.Location = new System.Drawing.Point(246, 0);
            this.itmPrefix.Name = "itmPrefix";
            this.itmPrefix.Size = new System.Drawing.Size(246, 24);
            this.itmPrefix.Text = "Prefix";
            this.itmPrefix.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtPrefix
            // 
            this.txtPrefix.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Prefix", true));
            this.txtPrefix.Location = new System.Drawing.Point(380, 43);
            this.txtPrefix.MenuManager = this.RibbonControl;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(132, 20);
            this.txtPrefix.StyleController = this.LayoutControl;
            this.txtPrefix.TabIndex = 48;
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 24);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(964, 24);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGEntitySYSEntity, "Name", true));
            this.txtName.Location = new System.Drawing.Point(134, 67);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Properties.ValidateOnEnterKey = true;
            this.txtName.Size = new System.Drawing.Size(850, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 4;
            // 
            // itmRegistrationNumber
            // 
            this.itmRegistrationNumber.Control = this.txtRegistrationNumber;
            this.itmRegistrationNumber.CustomizationFormText = "Registration Number";
            this.itmRegistrationNumber.Location = new System.Drawing.Point(494, 48);
            this.itmRegistrationNumber.Name = "itmRegistrationNumber";
            this.itmRegistrationNumber.Size = new System.Drawing.Size(470, 24);
            this.itmRegistrationNumber.Text = "Registration Number";
            this.itmRegistrationNumber.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtRegistrationNumber
            // 
            this.txtRegistrationNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGEntity, "RegistrationNumber", true));
            this.txtRegistrationNumber.Location = new System.Drawing.Point(628, 91);
            this.txtRegistrationNumber.MenuManager = this.RibbonControl;
            this.txtRegistrationNumber.Name = "txtRegistrationNumber";
            this.txtRegistrationNumber.Size = new System.Drawing.Size(356, 20);
            this.txtRegistrationNumber.StyleController = this.LayoutControl;
            this.txtRegistrationNumber.TabIndex = 6;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(492, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(472, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AreaCode", true));
            this.txtAreaCode.Location = new System.Drawing.Point(146, 245);
            this.txtAreaCode.MenuManager = this.RibbonControl;
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(355, 20);
            this.txtAreaCode.StyleController = this.LayoutControl;
            this.txtAreaCode.TabIndex = 18;
            // 
            // txtDiscountCode
            // 
            this.txtDiscountCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DiscountCode", true));
            this.txtDiscountCode.Location = new System.Drawing.Point(615, 245);
            this.txtDiscountCode.MenuManager = this.RibbonControl;
            this.txtDiscountCode.Name = "txtDiscountCode";
            this.txtDiscountCode.Size = new System.Drawing.Size(357, 20);
            this.txtDiscountCode.StyleController = this.LayoutControl;
            this.txtDiscountCode.TabIndex = 19;
            // 
            // txtRepCode
            // 
            this.txtRepCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "RepCode", true));
            this.txtRepCode.Location = new System.Drawing.Point(146, 269);
            this.txtRepCode.MenuManager = this.RibbonControl;
            this.txtRepCode.Name = "txtRepCode";
            this.txtRepCode.Size = new System.Drawing.Size(355, 20);
            this.txtRepCode.StyleController = this.LayoutControl;
            this.txtRepCode.TabIndex = 20;
            // 
            // txtSalesmanCode
            // 
            this.txtSalesmanCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SalesmanCode", true));
            this.txtSalesmanCode.Location = new System.Drawing.Point(615, 269);
            this.txtSalesmanCode.MenuManager = this.RibbonControl;
            this.txtSalesmanCode.Name = "txtSalesmanCode";
            this.txtSalesmanCode.Size = new System.Drawing.Size(357, 20);
            this.txtSalesmanCode.StyleController = this.LayoutControl;
            this.txtSalesmanCode.TabIndex = 21;
            // 
            // txtTagCode
            // 
            this.txtTagCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TagCode", true));
            this.txtTagCode.Location = new System.Drawing.Point(146, 293);
            this.txtTagCode.MenuManager = this.RibbonControl;
            this.txtTagCode.Name = "txtTagCode";
            this.txtTagCode.Size = new System.Drawing.Size(355, 20);
            this.txtTagCode.StyleController = this.LayoutControl;
            this.txtTagCode.TabIndex = 22;
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CountryCode", true));
            this.txtCountryCode.Location = new System.Drawing.Point(615, 293);
            this.txtCountryCode.MenuManager = this.RibbonControl;
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(357, 20);
            this.txtCountryCode.StyleController = this.LayoutControl;
            this.txtCountryCode.TabIndex = 23;
            // 
            // txtCustomValue1
            // 
            this.txtCustomValue1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CustomValue1", true));
            this.txtCustomValue1.EditValue = "";
            this.txtCustomValue1.Location = new System.Drawing.Point(146, 360);
            this.txtCustomValue1.Name = "txtCustomValue1";
            this.txtCustomValue1.Size = new System.Drawing.Size(355, 20);
            this.txtCustomValue1.StyleController = this.LayoutControl;
            this.txtCustomValue1.TabIndex = 26;
            // 
            // txtCustomValue2
            // 
            this.txtCustomValue2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CustomValue2", true));
            this.txtCustomValue2.Location = new System.Drawing.Point(146, 384);
            this.txtCustomValue2.MenuManager = this.RibbonControl;
            this.txtCustomValue2.Name = "txtCustomValue2";
            this.txtCustomValue2.Size = new System.Drawing.Size(355, 20);
            this.txtCustomValue2.StyleController = this.LayoutControl;
            this.txtCustomValue2.TabIndex = 27;
            // 
            // txtCustomValue3
            // 
            this.txtCustomValue3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CustomValue3", true));
            this.txtCustomValue3.Location = new System.Drawing.Point(146, 408);
            this.txtCustomValue3.MenuManager = this.RibbonControl;
            this.txtCustomValue3.Name = "txtCustomValue3";
            this.txtCustomValue3.Size = new System.Drawing.Size(355, 20);
            this.txtCustomValue3.StyleController = this.LayoutControl;
            this.txtCustomValue3.TabIndex = 28;
            // 
            // txtCustomValue4
            // 
            this.txtCustomValue4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CustomValue4", true));
            this.txtCustomValue4.Location = new System.Drawing.Point(615, 360);
            this.txtCustomValue4.MenuManager = this.RibbonControl;
            this.txtCustomValue4.Name = "txtCustomValue4";
            this.txtCustomValue4.Size = new System.Drawing.Size(357, 20);
            this.txtCustomValue4.StyleController = this.LayoutControl;
            this.txtCustomValue4.TabIndex = 29;
            // 
            // txtCustomValue5
            // 
            this.txtCustomValue5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CustomValue5", true));
            this.txtCustomValue5.Location = new System.Drawing.Point(615, 384);
            this.txtCustomValue5.MenuManager = this.RibbonControl;
            this.txtCustomValue5.Name = "txtCustomValue5";
            this.txtCustomValue5.Size = new System.Drawing.Size(357, 20);
            this.txtCustomValue5.StyleController = this.LayoutControl;
            this.txtCustomValue5.TabIndex = 30;
            // 
            // txtCustomValue6
            // 
            this.txtCustomValue6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CustomValue6", true));
            this.txtCustomValue6.Location = new System.Drawing.Point(615, 408);
            this.txtCustomValue6.MenuManager = this.RibbonControl;
            this.txtCustomValue6.Name = "txtCustomValue6";
            this.txtCustomValue6.Size = new System.Drawing.Size(357, 20);
            this.txtCustomValue6.StyleController = this.LayoutControl;
            this.txtCustomValue6.TabIndex = 31;
            // 
            // tcgInformation
            // 
            this.tcgInformation.CustomizationFormText = "Information";
            this.tcgInformation.Location = new System.Drawing.Point(0, 167);
            this.tcgInformation.Name = "tcgInformation";
            this.tcgInformation.SelectedTabPage = this.tabAccountingInformation;
            this.tcgInformation.SelectedTabPageIndex = 2;
            this.tcgInformation.Size = new System.Drawing.Size(988, 377);
            this.tcgInformation.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabGeneralInformation,
            this.tabAddressInformation,
            this.tabAccountingInformation,
            this.tabTransactions,
            this.tabOrdering,
            this.tabHistory});
            this.tcgInformation.Text = "Information";
            // 
            // tabAccountingInformation
            // 
            this.tabAccountingInformation.CustomizationFormText = "Accounting Information";
            this.tabAccountingInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgAccountTypeInformation,
            this.emptySpaceItem6});
            this.tabAccountingInformation.Location = new System.Drawing.Point(0, 0);
            this.tabAccountingInformation.Name = "tabAccountingInformation";
            this.tabAccountingInformation.Size = new System.Drawing.Size(964, 330);
            this.tabAccountingInformation.Text = "Accounting Information";
            // 
            // lcgAccountTypeInformation
            // 
            this.lcgAccountTypeInformation.CustomizationFormText = "Account Type Information";
            this.lcgAccountTypeInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmPaymentTerm,
            this.itmCostCategory,
            this.itmAccountLimit,
            this.itmOpenItem,
            this.itmOverrideAccount,
            this.itmStatementPreference,
            this.emptySpaceItem7});
            this.lcgAccountTypeInformation.Location = new System.Drawing.Point(0, 0);
            this.lcgAccountTypeInformation.Name = "lcgAccountTypeInformation";
            this.lcgAccountTypeInformation.Size = new System.Drawing.Size(964, 185);
            this.lcgAccountTypeInformation.Text = "Account Type Information";
            // 
            // itmPaymentTerm
            // 
            this.itmPaymentTerm.Control = this.ddlPaymentTerm;
            this.itmPaymentTerm.CustomizationFormText = "Payment Term";
            this.itmPaymentTerm.Location = new System.Drawing.Point(0, 0);
            this.itmPaymentTerm.Name = "itmPaymentTerm";
            this.itmPaymentTerm.Size = new System.Drawing.Size(478, 24);
            this.itmPaymentTerm.Text = "Payment Term";
            this.itmPaymentTerm.TextSize = new System.Drawing.Size(106, 13);
            // 
            // ddlPaymentTerm
            // 
            this.ddlPaymentTerm.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PaymentTermId", true));
            this.ddlPaymentTerm.Location = new System.Drawing.Point(146, 245);
            this.ddlPaymentTerm.MenuManager = this.RibbonControl;
            this.ddlPaymentTerm.Name = "ddlPaymentTerm";
            this.ddlPaymentTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlPaymentTerm.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.False)});
            this.ddlPaymentTerm.Properties.DataSource = this.ServerModeSourcePaymentTerm;
            this.ddlPaymentTerm.Properties.DisplayMember = "Name";
            this.ddlPaymentTerm.Properties.NullText = "Payment Term...";
            this.ddlPaymentTerm.Properties.ValueMember = "Id";
            this.ddlPaymentTerm.Size = new System.Drawing.Size(364, 20);
            this.ddlPaymentTerm.StyleController = this.LayoutControl;
            this.ddlPaymentTerm.TabIndex = 42;
            // 
            // ServerModeSourcePaymentTerm
            // 
            this.ServerModeSourcePaymentTerm.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_PaymentTerm);
            this.ServerModeSourcePaymentTerm.KeyExpression = "Id";
            // 
            // itmCostCategory
            // 
            this.itmCostCategory.Control = this.ddlCostCategory;
            this.itmCostCategory.CustomizationFormText = "Cost Category";
            this.itmCostCategory.Location = new System.Drawing.Point(0, 24);
            this.itmCostCategory.Name = "itmCostCategory";
            this.itmCostCategory.Size = new System.Drawing.Size(478, 24);
            this.itmCostCategory.Text = "Cost Category";
            this.itmCostCategory.TextSize = new System.Drawing.Size(106, 13);
            // 
            // ddlCostCategory
            // 
            this.ddlCostCategory.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CostCategoryId", true));
            this.ddlCostCategory.Location = new System.Drawing.Point(146, 269);
            this.ddlCostCategory.MenuManager = this.RibbonControl;
            this.ddlCostCategory.Name = "ddlCostCategory";
            this.ddlCostCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCostCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.False)});
            this.ddlCostCategory.Properties.DataSource = this.ServerModeSourceCostCategory;
            this.ddlCostCategory.Properties.DisplayMember = "Name";
            this.ddlCostCategory.Properties.NullText = "Cost Category...";
            this.ddlCostCategory.Properties.ValueMember = "Id";
            this.ddlCostCategory.Size = new System.Drawing.Size(364, 20);
            this.ddlCostCategory.StyleController = this.LayoutControl;
            this.ddlCostCategory.TabIndex = 43;
            // 
            // ServerModeSourceCostCategory
            // 
            this.ServerModeSourceCostCategory.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_CostCategory);
            this.ServerModeSourceCostCategory.KeyExpression = "Id";
            // 
            // itmAccountLimit
            // 
            this.itmAccountLimit.Control = this.txtAccountLimit;
            this.itmAccountLimit.CustomizationFormText = "Account Limit";
            this.itmAccountLimit.Location = new System.Drawing.Point(0, 48);
            this.itmAccountLimit.Name = "itmAccountLimit";
            this.itmAccountLimit.Size = new System.Drawing.Size(478, 24);
            this.itmAccountLimit.Text = "Account Limit";
            this.itmAccountLimit.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtAccountLimit
            // 
            this.txtAccountLimit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AccountLimit", true));
            this.txtAccountLimit.Location = new System.Drawing.Point(146, 293);
            this.txtAccountLimit.MenuManager = this.RibbonControl;
            this.txtAccountLimit.Name = "txtAccountLimit";
            this.txtAccountLimit.Size = new System.Drawing.Size(364, 20);
            this.txtAccountLimit.StyleController = this.LayoutControl;
            this.txtAccountLimit.TabIndex = 46;
            // 
            // itmOpenItem
            // 
            this.itmOpenItem.Control = this.chkOpenItem;
            this.itmOpenItem.CustomizationFormText = "Open Item";
            this.itmOpenItem.Location = new System.Drawing.Point(0, 72);
            this.itmOpenItem.Name = "itmOpenItem";
            this.itmOpenItem.Size = new System.Drawing.Size(478, 23);
            this.itmOpenItem.Text = "Open Item";
            this.itmOpenItem.TextSize = new System.Drawing.Size(0, 0);
            this.itmOpenItem.TextVisible = false;
            // 
            // chkOpenItem
            // 
            this.chkOpenItem.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OpenItem", true));
            this.chkOpenItem.Location = new System.Drawing.Point(36, 317);
            this.chkOpenItem.MenuManager = this.RibbonControl;
            this.chkOpenItem.Name = "chkOpenItem";
            this.chkOpenItem.Properties.Caption = "Open Item";
            this.chkOpenItem.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkOpenItem.Size = new System.Drawing.Size(474, 19);
            this.chkOpenItem.StyleController = this.LayoutControl;
            this.chkOpenItem.TabIndex = 44;
            // 
            // itmOverrideAccount
            // 
            this.itmOverrideAccount.Control = this.chkOverrideAccount;
            this.itmOverrideAccount.CustomizationFormText = "Override Account";
            this.itmOverrideAccount.Location = new System.Drawing.Point(0, 95);
            this.itmOverrideAccount.Name = "itmOverrideAccount";
            this.itmOverrideAccount.Size = new System.Drawing.Size(478, 23);
            this.itmOverrideAccount.Text = "Override Account";
            this.itmOverrideAccount.TextSize = new System.Drawing.Size(0, 0);
            this.itmOverrideAccount.TextVisible = false;
            // 
            // chkOverrideAccount
            // 
            this.chkOverrideAccount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OverrideAccount", true));
            this.chkOverrideAccount.Location = new System.Drawing.Point(36, 340);
            this.chkOverrideAccount.MenuManager = this.RibbonControl;
            this.chkOverrideAccount.Name = "chkOverrideAccount";
            this.chkOverrideAccount.Properties.Caption = "Override Account";
            this.chkOverrideAccount.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkOverrideAccount.Size = new System.Drawing.Size(474, 19);
            this.chkOverrideAccount.StyleController = this.LayoutControl;
            this.chkOverrideAccount.TabIndex = 45;
            // 
            // itmStatementPreference
            // 
            this.itmStatementPreference.Control = this.clbStatementPreference;
            this.itmStatementPreference.CustomizationFormText = "Statement Preference";
            this.itmStatementPreference.Location = new System.Drawing.Point(0, 118);
            this.itmStatementPreference.Name = "itmStatementPreference";
            this.itmStatementPreference.Size = new System.Drawing.Size(478, 24);
            this.itmStatementPreference.Text = "Statement Preference";
            this.itmStatementPreference.TextSize = new System.Drawing.Size(106, 13);
            // 
            // clbStatementPreference
            // 
            this.clbStatementPreference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "StatementPreference", true));
            this.clbStatementPreference.Location = new System.Drawing.Point(146, 363);
            this.clbStatementPreference.MenuManager = this.RibbonControl;
            this.clbStatementPreference.Name = "clbStatementPreference";
            this.clbStatementPreference.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clbStatementPreference.Properties.DataSource = this.ServerModeSourceStatementPreference;
            this.clbStatementPreference.Properties.DisplayMember = "Name";
            this.clbStatementPreference.Properties.ValueMember = "Name";
            this.clbStatementPreference.Size = new System.Drawing.Size(364, 20);
            this.clbStatementPreference.StyleController = this.LayoutControl;
            this.clbStatementPreference.TabIndex = 67;
            // 
            // ServerModeSourceStatementPreference
            // 
            this.ServerModeSourceStatementPreference.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_StatementPreference);
            this.ServerModeSourceStatementPreference.KeyExpression = "Id";
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(478, 0);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(462, 142);
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 185);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(964, 145);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabGeneralInformation
            // 
            this.tabGeneralInformation.CustomizationFormText = "Information";
            this.tabGeneralInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgCustomValues,
            this.lcgCompanyCode,
            this.emptySpaceItem4});
            this.tabGeneralInformation.Location = new System.Drawing.Point(0, 0);
            this.tabGeneralInformation.Name = "tabGeneralInformation";
            this.tabGeneralInformation.Size = new System.Drawing.Size(964, 330);
            this.tabGeneralInformation.Text = "General Information";
            // 
            // lcgCustomValues
            // 
            this.lcgCustomValues.CustomizationFormText = "Custom Values";
            this.lcgCustomValues.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCustomValue1,
            this.itmCustomValue2,
            this.itmCustomValue3,
            this.itmCustomValue4,
            this.itmCustomValue5,
            this.itmCustomValue6});
            this.lcgCustomValues.Location = new System.Drawing.Point(0, 115);
            this.lcgCustomValues.Name = "lcgCustomValues";
            this.lcgCustomValues.Size = new System.Drawing.Size(964, 115);
            this.lcgCustomValues.Text = "Custom Values";
            // 
            // itmCustomValue1
            // 
            this.itmCustomValue1.Control = this.txtCustomValue1;
            this.itmCustomValue1.CustomizationFormText = "layoutControlItem10";
            this.itmCustomValue1.Location = new System.Drawing.Point(0, 0);
            this.itmCustomValue1.Name = "itmCustomValue1";
            this.itmCustomValue1.Size = new System.Drawing.Size(469, 24);
            this.itmCustomValue1.Text = "Custom Value 1";
            this.itmCustomValue1.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmCustomValue2
            // 
            this.itmCustomValue2.Control = this.txtCustomValue2;
            this.itmCustomValue2.CustomizationFormText = "layoutControlItem11";
            this.itmCustomValue2.Location = new System.Drawing.Point(0, 24);
            this.itmCustomValue2.Name = "itmCustomValue2";
            this.itmCustomValue2.Size = new System.Drawing.Size(469, 24);
            this.itmCustomValue2.Text = "Custom Value 2";
            this.itmCustomValue2.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmCustomValue3
            // 
            this.itmCustomValue3.Control = this.txtCustomValue3;
            this.itmCustomValue3.CustomizationFormText = "layoutControlItem12";
            this.itmCustomValue3.Location = new System.Drawing.Point(0, 48);
            this.itmCustomValue3.Name = "itmCustomValue3";
            this.itmCustomValue3.Size = new System.Drawing.Size(469, 24);
            this.itmCustomValue3.Text = "Custom Value 3";
            this.itmCustomValue3.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmCustomValue4
            // 
            this.itmCustomValue4.Control = this.txtCustomValue4;
            this.itmCustomValue4.CustomizationFormText = "layoutControlItem13";
            this.itmCustomValue4.Location = new System.Drawing.Point(469, 0);
            this.itmCustomValue4.Name = "itmCustomValue4";
            this.itmCustomValue4.Size = new System.Drawing.Size(471, 24);
            this.itmCustomValue4.Text = "Custom Value 4";
            this.itmCustomValue4.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmCustomValue5
            // 
            this.itmCustomValue5.Control = this.txtCustomValue5;
            this.itmCustomValue5.CustomizationFormText = "layoutControlItem14";
            this.itmCustomValue5.Location = new System.Drawing.Point(469, 24);
            this.itmCustomValue5.Name = "itmCustomValue5";
            this.itmCustomValue5.Size = new System.Drawing.Size(471, 24);
            this.itmCustomValue5.Text = "Custom Value 5";
            this.itmCustomValue5.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmCustomValue6
            // 
            this.itmCustomValue6.Control = this.txtCustomValue6;
            this.itmCustomValue6.CustomizationFormText = "layoutControlItem15";
            this.itmCustomValue6.Location = new System.Drawing.Point(469, 48);
            this.itmCustomValue6.Name = "itmCustomValue6";
            this.itmCustomValue6.Size = new System.Drawing.Size(471, 24);
            this.itmCustomValue6.Text = "Custom Value 6";
            this.itmCustomValue6.TextSize = new System.Drawing.Size(106, 13);
            // 
            // lcgCompanyCode
            // 
            this.lcgCompanyCode.CustomizationFormText = "Company Code";
            this.lcgCompanyCode.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAreaCode,
            this.itmRepCode,
            this.itmTagCode,
            this.itmDiscountCode,
            this.itmSalesmanCode,
            this.itmCountryCode});
            this.lcgCompanyCode.Location = new System.Drawing.Point(0, 0);
            this.lcgCompanyCode.Name = "lcgCompanyCode";
            this.lcgCompanyCode.Size = new System.Drawing.Size(964, 115);
            this.lcgCompanyCode.Text = "Company Code";
            // 
            // itmAreaCode
            // 
            this.itmAreaCode.Control = this.txtAreaCode;
            this.itmAreaCode.CustomizationFormText = "layoutControlItem2";
            this.itmAreaCode.Location = new System.Drawing.Point(0, 0);
            this.itmAreaCode.Name = "itmAreaCode";
            this.itmAreaCode.Size = new System.Drawing.Size(469, 24);
            this.itmAreaCode.Text = "Area Code";
            this.itmAreaCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmRepCode
            // 
            this.itmRepCode.Control = this.txtRepCode;
            this.itmRepCode.CustomizationFormText = "layoutControlItem4";
            this.itmRepCode.Location = new System.Drawing.Point(0, 24);
            this.itmRepCode.Name = "itmRepCode";
            this.itmRepCode.Size = new System.Drawing.Size(469, 24);
            this.itmRepCode.Text = "Rep Code";
            this.itmRepCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmTagCode
            // 
            this.itmTagCode.Control = this.txtTagCode;
            this.itmTagCode.CustomizationFormText = "layoutControlItem6";
            this.itmTagCode.Location = new System.Drawing.Point(0, 48);
            this.itmTagCode.Name = "itmTagCode";
            this.itmTagCode.Size = new System.Drawing.Size(469, 24);
            this.itmTagCode.Text = "Tag Code";
            this.itmTagCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmDiscountCode
            // 
            this.itmDiscountCode.Control = this.txtDiscountCode;
            this.itmDiscountCode.CustomizationFormText = "layoutControlItem3";
            this.itmDiscountCode.Location = new System.Drawing.Point(469, 0);
            this.itmDiscountCode.Name = "itmDiscountCode";
            this.itmDiscountCode.Size = new System.Drawing.Size(471, 24);
            this.itmDiscountCode.Text = "Discount Code";
            this.itmDiscountCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmSalesmanCode
            // 
            this.itmSalesmanCode.Control = this.txtSalesmanCode;
            this.itmSalesmanCode.CustomizationFormText = "layoutControlItem5";
            this.itmSalesmanCode.Location = new System.Drawing.Point(469, 24);
            this.itmSalesmanCode.Name = "itmSalesmanCode";
            this.itmSalesmanCode.Size = new System.Drawing.Size(471, 24);
            this.itmSalesmanCode.Text = "Salesman Code";
            this.itmSalesmanCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // itmCountryCode
            // 
            this.itmCountryCode.Control = this.txtCountryCode;
            this.itmCountryCode.CustomizationFormText = "layoutControlItem7";
            this.itmCountryCode.Location = new System.Drawing.Point(469, 48);
            this.itmCountryCode.Name = "itmCountryCode";
            this.itmCountryCode.Size = new System.Drawing.Size(471, 24);
            this.itmCountryCode.Text = "Country Code";
            this.itmCountryCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 230);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(964, 100);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabAddressInformation
            // 
            this.tabAddressInformation.CustomizationFormText = "Address Information";
            this.tabAddressInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgShippingAddress,
            this.lcgBillingAddress,
            this.emptySpaceItem5});
            this.tabAddressInformation.Location = new System.Drawing.Point(0, 0);
            this.tabAddressInformation.Name = "tabAddressInformation";
            this.tabAddressInformation.Size = new System.Drawing.Size(964, 330);
            this.tabAddressInformation.Text = "Address Information";
            // 
            // lcgShippingAddress
            // 
            this.lcgShippingAddress.CustomizationFormText = "Shipping Address";
            this.lcgShippingAddress.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmShippingLine1,
            this.itmShippingLine2,
            this.itmShippingLine3,
            this.itmShippingLine4,
            this.itmShippingCode,
            this.emptySpaceItem1});
            this.lcgShippingAddress.Location = new System.Drawing.Point(0, 0);
            this.lcgShippingAddress.Name = "lcgShippingAddress";
            this.lcgShippingAddress.Size = new System.Drawing.Size(479, 163);
            this.lcgShippingAddress.Text = "Shipping Address";
            // 
            // itmShippingLine1
            // 
            this.itmShippingLine1.Control = this.txtShippingLine1;
            this.itmShippingLine1.CustomizationFormText = "Shipping Line 1";
            this.itmShippingLine1.Location = new System.Drawing.Point(0, 0);
            this.itmShippingLine1.Name = "itmShippingLine1";
            this.itmShippingLine1.Size = new System.Drawing.Size(455, 24);
            this.itmShippingLine1.Text = "Line 1";
            this.itmShippingLine1.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtShippingLine1
            // 
            this.txtShippingLine1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceShippingAddress, "Line1", true));
            this.txtShippingLine1.Location = new System.Drawing.Point(146, 245);
            this.txtShippingLine1.MenuManager = this.RibbonControl;
            this.txtShippingLine1.Name = "txtShippingLine1";
            this.txtShippingLine1.Size = new System.Drawing.Size(341, 20);
            this.txtShippingLine1.StyleController = this.LayoutControl;
            this.txtShippingLine1.TabIndex = 32;
            // 
            // BindingSourceShippingAddress
            // 
            this.BindingSourceShippingAddress.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Address);
            // 
            // itmShippingLine2
            // 
            this.itmShippingLine2.Control = this.txtShippingLine2;
            this.itmShippingLine2.CustomizationFormText = "Shipping Line 2";
            this.itmShippingLine2.Location = new System.Drawing.Point(0, 24);
            this.itmShippingLine2.Name = "itmShippingLine2";
            this.itmShippingLine2.Size = new System.Drawing.Size(455, 24);
            this.itmShippingLine2.Text = "Line 2";
            this.itmShippingLine2.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtShippingLine2
            // 
            this.txtShippingLine2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceShippingAddress, "Line2", true));
            this.txtShippingLine2.Location = new System.Drawing.Point(146, 269);
            this.txtShippingLine2.MenuManager = this.RibbonControl;
            this.txtShippingLine2.Name = "txtShippingLine2";
            this.txtShippingLine2.Size = new System.Drawing.Size(341, 20);
            this.txtShippingLine2.StyleController = this.LayoutControl;
            this.txtShippingLine2.TabIndex = 34;
            // 
            // itmShippingLine3
            // 
            this.itmShippingLine3.Control = this.txtShippingLine3;
            this.itmShippingLine3.CustomizationFormText = "Shipping Line 3";
            this.itmShippingLine3.Location = new System.Drawing.Point(0, 48);
            this.itmShippingLine3.Name = "itmShippingLine3";
            this.itmShippingLine3.Size = new System.Drawing.Size(455, 24);
            this.itmShippingLine3.Text = "Line 3";
            this.itmShippingLine3.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtShippingLine3
            // 
            this.txtShippingLine3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceShippingAddress, "Line3", true));
            this.txtShippingLine3.Location = new System.Drawing.Point(146, 293);
            this.txtShippingLine3.MenuManager = this.RibbonControl;
            this.txtShippingLine3.Name = "txtShippingLine3";
            this.txtShippingLine3.Size = new System.Drawing.Size(341, 20);
            this.txtShippingLine3.StyleController = this.LayoutControl;
            this.txtShippingLine3.TabIndex = 36;
            // 
            // itmShippingLine4
            // 
            this.itmShippingLine4.Control = this.txtShippingLine4;
            this.itmShippingLine4.CustomizationFormText = "Shipping Line 4";
            this.itmShippingLine4.Location = new System.Drawing.Point(0, 72);
            this.itmShippingLine4.Name = "itmShippingLine4";
            this.itmShippingLine4.Size = new System.Drawing.Size(455, 24);
            this.itmShippingLine4.Text = "Line 4";
            this.itmShippingLine4.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtShippingLine4
            // 
            this.txtShippingLine4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceShippingAddress, "Line4", true));
            this.txtShippingLine4.Location = new System.Drawing.Point(146, 317);
            this.txtShippingLine4.MenuManager = this.RibbonControl;
            this.txtShippingLine4.Name = "txtShippingLine4";
            this.txtShippingLine4.Size = new System.Drawing.Size(341, 20);
            this.txtShippingLine4.StyleController = this.LayoutControl;
            this.txtShippingLine4.TabIndex = 38;
            // 
            // itmShippingCode
            // 
            this.itmShippingCode.Control = this.txtShippingCode;
            this.itmShippingCode.CustomizationFormText = "Shipping Code";
            this.itmShippingCode.Location = new System.Drawing.Point(0, 96);
            this.itmShippingCode.Name = "itmShippingCode";
            this.itmShippingCode.Size = new System.Drawing.Size(202, 24);
            this.itmShippingCode.Text = "Code";
            this.itmShippingCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtShippingCode
            // 
            this.txtShippingCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceShippingAddress, "Code", true));
            this.txtShippingCode.Location = new System.Drawing.Point(146, 341);
            this.txtShippingCode.MenuManager = this.RibbonControl;
            this.txtShippingCode.Name = "txtShippingCode";
            this.txtShippingCode.Size = new System.Drawing.Size(88, 20);
            this.txtShippingCode.StyleController = this.LayoutControl;
            this.txtShippingCode.TabIndex = 40;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(202, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(253, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgBillingAddress
            // 
            this.lcgBillingAddress.CustomizationFormText = "Billing Address";
            this.lcgBillingAddress.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmBillingLine1,
            this.itmBillingLine2,
            this.itmBillingLine3,
            this.itmBillingLine4,
            this.itmBillingCode,
            this.emptySpaceItem3});
            this.lcgBillingAddress.Location = new System.Drawing.Point(479, 0);
            this.lcgBillingAddress.Name = "lcgBillingAddress";
            this.lcgBillingAddress.Size = new System.Drawing.Size(485, 163);
            this.lcgBillingAddress.Text = "Billing Address";
            // 
            // itmBillingLine1
            // 
            this.itmBillingLine1.Control = this.txtBillingLine1;
            this.itmBillingLine1.CustomizationFormText = "Billing Line 1";
            this.itmBillingLine1.Location = new System.Drawing.Point(0, 0);
            this.itmBillingLine1.Name = "itmBillingLine1";
            this.itmBillingLine1.Size = new System.Drawing.Size(461, 24);
            this.itmBillingLine1.Text = "Line 1";
            this.itmBillingLine1.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtBillingLine1
            // 
            this.txtBillingLine1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceBillingAddress, "Line1", true));
            this.txtBillingLine1.Location = new System.Drawing.Point(625, 245);
            this.txtBillingLine1.MenuManager = this.RibbonControl;
            this.txtBillingLine1.Name = "txtBillingLine1";
            this.txtBillingLine1.Size = new System.Drawing.Size(347, 20);
            this.txtBillingLine1.StyleController = this.LayoutControl;
            this.txtBillingLine1.TabIndex = 33;
            // 
            // BindingSourceBillingAddress
            // 
            this.BindingSourceBillingAddress.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Address);
            // 
            // itmBillingLine2
            // 
            this.itmBillingLine2.Control = this.txtBillingLine2;
            this.itmBillingLine2.CustomizationFormText = "Billing Line 2";
            this.itmBillingLine2.Location = new System.Drawing.Point(0, 24);
            this.itmBillingLine2.Name = "itmBillingLine2";
            this.itmBillingLine2.Size = new System.Drawing.Size(461, 24);
            this.itmBillingLine2.Text = "Line 2";
            this.itmBillingLine2.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtBillingLine2
            // 
            this.txtBillingLine2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceBillingAddress, "Line2", true));
            this.txtBillingLine2.Location = new System.Drawing.Point(625, 269);
            this.txtBillingLine2.MenuManager = this.RibbonControl;
            this.txtBillingLine2.Name = "txtBillingLine2";
            this.txtBillingLine2.Size = new System.Drawing.Size(347, 20);
            this.txtBillingLine2.StyleController = this.LayoutControl;
            this.txtBillingLine2.TabIndex = 35;
            // 
            // itmBillingLine3
            // 
            this.itmBillingLine3.Control = this.txtBillingLine3;
            this.itmBillingLine3.CustomizationFormText = "Billing Line 3";
            this.itmBillingLine3.Location = new System.Drawing.Point(0, 48);
            this.itmBillingLine3.Name = "itmBillingLine3";
            this.itmBillingLine3.Size = new System.Drawing.Size(461, 24);
            this.itmBillingLine3.Text = "Line 3";
            this.itmBillingLine3.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtBillingLine3
            // 
            this.txtBillingLine3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceBillingAddress, "Line3", true));
            this.txtBillingLine3.Location = new System.Drawing.Point(625, 293);
            this.txtBillingLine3.MenuManager = this.RibbonControl;
            this.txtBillingLine3.Name = "txtBillingLine3";
            this.txtBillingLine3.Size = new System.Drawing.Size(347, 20);
            this.txtBillingLine3.StyleController = this.LayoutControl;
            this.txtBillingLine3.TabIndex = 37;
            // 
            // itmBillingLine4
            // 
            this.itmBillingLine4.Control = this.txtBillingLine4;
            this.itmBillingLine4.CustomizationFormText = "Billing Line 4";
            this.itmBillingLine4.Location = new System.Drawing.Point(0, 72);
            this.itmBillingLine4.Name = "itmBillingLine4";
            this.itmBillingLine4.Size = new System.Drawing.Size(461, 24);
            this.itmBillingLine4.Text = "Line 4";
            this.itmBillingLine4.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtBillingLine4
            // 
            this.txtBillingLine4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceBillingAddress, "Line4", true));
            this.txtBillingLine4.Location = new System.Drawing.Point(625, 317);
            this.txtBillingLine4.MenuManager = this.RibbonControl;
            this.txtBillingLine4.Name = "txtBillingLine4";
            this.txtBillingLine4.Size = new System.Drawing.Size(347, 20);
            this.txtBillingLine4.StyleController = this.LayoutControl;
            this.txtBillingLine4.TabIndex = 39;
            // 
            // itmBillingCode
            // 
            this.itmBillingCode.Control = this.txtBillingCode;
            this.itmBillingCode.CustomizationFormText = "Billing Code";
            this.itmBillingCode.Location = new System.Drawing.Point(0, 96);
            this.itmBillingCode.Name = "itmBillingCode";
            this.itmBillingCode.Size = new System.Drawing.Size(203, 24);
            this.itmBillingCode.Text = "Code";
            this.itmBillingCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtBillingCode
            // 
            this.txtBillingCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceBillingAddress, "Code", true));
            this.txtBillingCode.Location = new System.Drawing.Point(625, 341);
            this.txtBillingCode.MenuManager = this.RibbonControl;
            this.txtBillingCode.Name = "txtBillingCode";
            this.txtBillingCode.Size = new System.Drawing.Size(89, 20);
            this.txtBillingCode.StyleController = this.LayoutControl;
            this.txtBillingCode.TabIndex = 41;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(203, 96);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(258, 24);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 163);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(964, 167);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabTransactions
            // 
            this.tabTransactions.CustomizationFormText = "Transactions";
            this.tabTransactions.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmGridTransactions});
            this.tabTransactions.Location = new System.Drawing.Point(0, 0);
            this.tabTransactions.Name = "tabTransactions";
            this.tabTransactions.Size = new System.Drawing.Size(964, 330);
            this.tabTransactions.Text = "Transactions";
            // 
            // itmGridTransactions
            // 
            this.itmGridTransactions.Control = this.grdTransactions;
            this.itmGridTransactions.CustomizationFormText = "Grid Transactions";
            this.itmGridTransactions.Location = new System.Drawing.Point(0, 0);
            this.itmGridTransactions.Name = "itmGridTransactions";
            this.itmGridTransactions.Size = new System.Drawing.Size(964, 330);
            this.itmGridTransactions.Text = "Grid Transactions";
            this.itmGridTransactions.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridTransactions.TextVisible = false;
            // 
            // grdTransactions
            // 
            this.grdTransactions.DataSource = this.InstantFeedbackSourceTransaction;
            this.grdTransactions.Location = new System.Drawing.Point(24, 214);
            this.grdTransactions.MainView = this.grvTransactions;
            this.grdTransactions.MenuManager = this.RibbonControl;
            this.grdTransactions.Name = "grdTransactions";
            this.grdTransactions.Size = new System.Drawing.Size(960, 326);
            this.grdTransactions.TabIndex = 62;
            this.grdTransactions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTransactions});
            // 
            // InstantFeedbackSourceTransaction
            // 
            this.InstantFeedbackSourceTransaction.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Transaction);
            this.InstantFeedbackSourceTransaction.KeyExpression = "Id";
            this.InstantFeedbackSourceTransaction.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceTransaction_GetQueryable);
            // 
            // grvTransactions
            // 
            this.grvTransactions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocumentType,
            this.colDocumentNumber,
            this.colPostedDate,
            this.colTransactionWarehouseName,
            this.colCompanyName,
            this.colQuantity,
            this.colOnHand2,
            this.colOnReserve,
            this.colOnOrder2,
            this.colDiscount,
            this.colUnitPrice1,
            this.colUnitCost3,
            this.colUnitAverage1,
            this.colTotal,
            this.colYourReference,
            this.colOurReference,
            this.colReferenceLong3,
            this.colReferenceLong4,
            this.colReferenceLong5,
            this.colOrderNumber1,
            this.colRepCode,
            this.colSalesManCode,
            this.colReferenceShort4,
            this.colReferenceShort5,
            this.colCreatedOn,
            this.colCreatedBy,
            this.colFirstPrintedDate,
            this.colLastPrintedDate,
            this.colFirstPrintedBy,
            this.colLastPrintedBy,
            this.colValidDate,
            this.colTotalCash,
            this.colTotalCredit,
            this.colTotalAccount,
            this.colTotalRounding});
            this.grvTransactions.GridControl = this.grdTransactions;
            this.grvTransactions.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grvTransactions.Name = "grvTransactions";
            this.grvTransactions.OptionsView.ColumnAutoWidth = false;
            this.grvTransactions.OptionsView.EnableAppearanceEvenRow = true;
            this.grvTransactions.OptionsView.EnableAppearanceOddRow = true;
            this.grvTransactions.OptionsView.ShowAutoFilterRow = true;
            this.grvTransactions.OptionsView.ShowGroupPanel = false;
            this.grvTransactions.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCreatedOn, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvTransactions.VertScrollTipFieldName = "DocumentType";
            this.grvTransactions.DoubleClick += new System.EventHandler(this.grvTransactions_DoubleClick);
            // 
            // colDocumentType
            // 
            this.colDocumentType.FieldName = "DocumentType";
            this.colDocumentType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colDocumentType.Name = "colDocumentType";
            this.colDocumentType.OptionsColumn.AllowEdit = false;
            this.colDocumentType.Visible = true;
            this.colDocumentType.VisibleIndex = 0;
            this.colDocumentType.Width = 108;
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.FieldName = "DocumentNumber";
            this.colDocumentNumber.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.OptionsColumn.AllowEdit = false;
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 1;
            this.colDocumentNumber.Width = 124;
            // 
            // colPostedDate
            // 
            this.colPostedDate.FieldName = "DatePosted";
            this.colPostedDate.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colPostedDate.Name = "colPostedDate";
            this.colPostedDate.OptionsColumn.AllowEdit = false;
            this.colPostedDate.Visible = true;
            this.colPostedDate.VisibleIndex = 2;
            this.colPostedDate.Width = 88;
            // 
            // colTransactionWarehouseName
            // 
            this.colTransactionWarehouseName.FieldName = "WarehouseName";
            this.colTransactionWarehouseName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colTransactionWarehouseName.Name = "colTransactionWarehouseName";
            this.colTransactionWarehouseName.OptionsColumn.AllowEdit = false;
            // 
            // colCompanyName
            // 
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.OptionsColumn.AllowEdit = false;
            this.colCompanyName.Width = 107;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.FieldName = "QuantityHolding";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            this.colQuantity.Width = 68;
            // 
            // colOnHand2
            // 
            this.colOnHand2.FieldName = "OnHand";
            this.colOnHand2.Name = "colOnHand2";
            this.colOnHand2.OptionsColumn.AllowEdit = false;
            this.colOnHand2.Visible = true;
            this.colOnHand2.VisibleIndex = 4;
            this.colOnHand2.Width = 66;
            // 
            // colOnReserve
            // 
            this.colOnReserve.FieldName = "OnReserve";
            this.colOnReserve.Name = "colOnReserve";
            this.colOnReserve.OptionsColumn.AllowEdit = false;
            this.colOnReserve.Visible = true;
            this.colOnReserve.VisibleIndex = 5;
            this.colOnReserve.Width = 84;
            // 
            // colOnOrder2
            // 
            this.colOnOrder2.FieldName = "OnOrder";
            this.colOnOrder2.Name = "colOnOrder2";
            this.colOnOrder2.OptionsColumn.AllowEdit = false;
            this.colOnOrder2.Visible = true;
            this.colOnOrder2.VisibleIndex = 6;
            this.colOnOrder2.Width = 69;
            // 
            // colDiscount
            // 
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.OptionsColumn.AllowEdit = false;
            // 
            // colUnitPrice1
            // 
            this.colUnitPrice1.FieldName = "UnitPrice";
            this.colUnitPrice1.Name = "colUnitPrice1";
            this.colUnitPrice1.OptionsColumn.AllowEdit = false;
            this.colUnitPrice1.Visible = true;
            this.colUnitPrice1.VisibleIndex = 7;
            this.colUnitPrice1.Width = 73;
            // 
            // colUnitCost3
            // 
            this.colUnitCost3.FieldName = "UnitCost";
            this.colUnitCost3.Name = "colUnitCost3";
            this.colUnitCost3.OptionsColumn.AllowEdit = false;
            this.colUnitCost3.Visible = true;
            this.colUnitCost3.VisibleIndex = 8;
            this.colUnitCost3.Width = 70;
            // 
            // colUnitAverage1
            // 
            this.colUnitAverage1.FieldName = "UnitAverage";
            this.colUnitAverage1.Name = "colUnitAverage1";
            this.colUnitAverage1.OptionsColumn.AllowEdit = false;
            this.colUnitAverage1.Visible = true;
            this.colUnitAverage1.VisibleIndex = 9;
            this.colUnitAverage1.Width = 93;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 10;
            this.colTotal.Width = 54;
            // 
            // colYourReference
            // 
            this.colYourReference.FieldName = "YourReference";
            this.colYourReference.Name = "colYourReference";
            this.colYourReference.OptionsColumn.AllowEdit = false;
            this.colYourReference.Visible = true;
            this.colYourReference.VisibleIndex = 11;
            this.colYourReference.Width = 106;
            // 
            // colOurReference
            // 
            this.colOurReference.FieldName = "OurReference";
            this.colOurReference.Name = "colOurReference";
            this.colOurReference.OptionsColumn.AllowEdit = false;
            this.colOurReference.Visible = true;
            this.colOurReference.VisibleIndex = 12;
            this.colOurReference.Width = 100;
            // 
            // colReferenceLong3
            // 
            this.colReferenceLong3.FieldName = "ReferenceLong3";
            this.colReferenceLong3.Name = "colReferenceLong3";
            this.colReferenceLong3.OptionsColumn.AllowEdit = false;
            this.colReferenceLong3.Visible = true;
            this.colReferenceLong3.VisibleIndex = 13;
            this.colReferenceLong3.Width = 114;
            // 
            // colReferenceLong4
            // 
            this.colReferenceLong4.FieldName = "ReferenceLong4";
            this.colReferenceLong4.Name = "colReferenceLong4";
            this.colReferenceLong4.OptionsColumn.AllowEdit = false;
            this.colReferenceLong4.Visible = true;
            this.colReferenceLong4.VisibleIndex = 14;
            this.colReferenceLong4.Width = 114;
            // 
            // colReferenceLong5
            // 
            this.colReferenceLong5.FieldName = "ReferenceLong5";
            this.colReferenceLong5.Name = "colReferenceLong5";
            this.colReferenceLong5.OptionsColumn.AllowEdit = false;
            this.colReferenceLong5.Visible = true;
            this.colReferenceLong5.VisibleIndex = 15;
            this.colReferenceLong5.Width = 114;
            // 
            // colOrderNumber1
            // 
            this.colOrderNumber1.FieldName = "OrderNumber";
            this.colOrderNumber1.Name = "colOrderNumber1";
            this.colOrderNumber1.OptionsColumn.AllowEdit = false;
            this.colOrderNumber1.Visible = true;
            this.colOrderNumber1.VisibleIndex = 16;
            this.colOrderNumber1.Width = 98;
            // 
            // colRepCode
            // 
            this.colRepCode.FieldName = "RepCode";
            this.colRepCode.Name = "colRepCode";
            this.colRepCode.OptionsColumn.AllowEdit = false;
            this.colRepCode.Visible = true;
            this.colRepCode.VisibleIndex = 17;
            this.colRepCode.Width = 72;
            // 
            // colSalesManCode
            // 
            this.colSalesManCode.FieldName = "SalesManCode";
            this.colSalesManCode.Name = "colSalesManCode";
            this.colSalesManCode.OptionsColumn.AllowEdit = false;
            this.colSalesManCode.Visible = true;
            this.colSalesManCode.VisibleIndex = 18;
            this.colSalesManCode.Width = 107;
            // 
            // colReferenceShort4
            // 
            this.colReferenceShort4.FieldName = "ReferenceShort4";
            this.colReferenceShort4.Name = "colReferenceShort4";
            this.colReferenceShort4.OptionsColumn.AllowEdit = false;
            this.colReferenceShort4.Visible = true;
            this.colReferenceShort4.VisibleIndex = 19;
            this.colReferenceShort4.Width = 118;
            // 
            // colReferenceShort5
            // 
            this.colReferenceShort5.FieldName = "ReferenceShort5";
            this.colReferenceShort5.Name = "colReferenceShort5";
            this.colReferenceShort5.OptionsColumn.AllowEdit = false;
            this.colReferenceShort5.Visible = true;
            this.colReferenceShort5.VisibleIndex = 20;
            this.colReferenceShort5.Width = 118;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.DisplayFormat.FormatString = "{yyyy/MM/dd HH:MM:ss:0}";
            this.colCreatedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colCreatedOn.FieldName = "CreatedOn";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.OptionsColumn.AllowEdit = false;
            this.colCreatedOn.Visible = true;
            this.colCreatedOn.VisibleIndex = 21;
            this.colCreatedOn.Width = 82;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsColumn.AllowEdit = false;
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 22;
            this.colCreatedBy.Width = 81;
            // 
            // colFirstPrintedDate
            // 
            this.colFirstPrintedDate.FieldName = "DateFirstPrinted";
            this.colFirstPrintedDate.Name = "colFirstPrintedDate";
            this.colFirstPrintedDate.OptionsColumn.AllowEdit = false;
            // 
            // colLastPrintedDate
            // 
            this.colLastPrintedDate.FieldName = "DateLastPrinted";
            this.colLastPrintedDate.Name = "colLastPrintedDate";
            this.colLastPrintedDate.OptionsColumn.AllowEdit = false;
            // 
            // colFirstPrintedBy
            // 
            this.colFirstPrintedBy.FieldName = "FirstPrintedBy";
            this.colFirstPrintedBy.Name = "colFirstPrintedBy";
            this.colFirstPrintedBy.OptionsColumn.AllowEdit = false;
            // 
            // colLastPrintedBy
            // 
            this.colLastPrintedBy.FieldName = "LastPrintedBy";
            this.colLastPrintedBy.Name = "colLastPrintedBy";
            this.colLastPrintedBy.OptionsColumn.AllowEdit = false;
            // 
            // colValidDate
            // 
            this.colValidDate.FieldName = "ValidDate";
            this.colValidDate.Name = "colValidDate";
            this.colValidDate.OptionsColumn.AllowEdit = false;
            // 
            // colTotalCash
            // 
            this.colTotalCash.FieldName = "TotalCash";
            this.colTotalCash.Name = "colTotalCash";
            this.colTotalCash.OptionsColumn.AllowEdit = false;
            this.colTotalCash.Visible = true;
            this.colTotalCash.VisibleIndex = 23;
            this.colTotalCash.Width = 78;
            // 
            // colTotalCredit
            // 
            this.colTotalCredit.FieldName = "TotalCredit";
            this.colTotalCredit.Name = "colTotalCredit";
            this.colTotalCredit.OptionsColumn.AllowEdit = false;
            this.colTotalCredit.Visible = true;
            this.colTotalCredit.VisibleIndex = 24;
            this.colTotalCredit.Width = 85;
            // 
            // colTotalAccount
            // 
            this.colTotalAccount.FieldName = "TotalAccount";
            this.colTotalAccount.Name = "colTotalAccount";
            this.colTotalAccount.OptionsColumn.AllowEdit = false;
            this.colTotalAccount.Visible = true;
            this.colTotalAccount.VisibleIndex = 25;
            this.colTotalAccount.Width = 97;
            // 
            // colTotalRounding
            // 
            this.colTotalRounding.FieldName = "TotalRounding";
            this.colTotalRounding.Name = "colTotalRounding";
            this.colTotalRounding.OptionsColumn.AllowEdit = false;
            this.colTotalRounding.Visible = true;
            this.colTotalRounding.VisibleIndex = 26;
            this.colTotalRounding.Width = 116;
            // 
            // tabOrdering
            // 
            this.tabOrdering.CustomizationFormText = "Ordering";
            this.tabOrdering.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgTeccomDetail,
            this.lcgGeneral,
            this.emptySpaceItem8,
            this.lcgCustomerGeneral});
            this.tabOrdering.Location = new System.Drawing.Point(0, 0);
            this.tabOrdering.Name = "tabOrdering";
            this.tabOrdering.Size = new System.Drawing.Size(964, 330);
            this.tabOrdering.Text = "Ordering";
            // 
            // lcgTeccomDetail
            // 
            this.lcgTeccomDetail.CustomizationFormText = "Teccom Detail";
            this.lcgTeccomDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmTeccomHeader,
            this.itmPath,
            this.itmCustomerCode,
            this.itmDistributionNumber,
            this.itmSupplierCode});
            this.lcgTeccomDetail.Location = new System.Drawing.Point(0, 138);
            this.lcgTeccomDetail.Name = "lcgTeccomDetail";
            this.lcgTeccomDetail.Size = new System.Drawing.Size(964, 115);
            this.lcgTeccomDetail.Text = "Teccom Detail";
            // 
            // itmTeccomHeader
            // 
            this.itmTeccomHeader.Control = this.txtTeccomHeader;
            this.itmTeccomHeader.CustomizationFormText = "Teccom Header";
            this.itmTeccomHeader.Location = new System.Drawing.Point(0, 0);
            this.itmTeccomHeader.Name = "itmTeccomHeader";
            this.itmTeccomHeader.Size = new System.Drawing.Size(469, 24);
            this.itmTeccomHeader.Text = "Teccom Header";
            this.itmTeccomHeader.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtTeccomHeader
            // 
            this.txtTeccomHeader.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "TeccomHeader", true));
            this.txtTeccomHeader.Location = new System.Drawing.Point(146, 383);
            this.txtTeccomHeader.MenuManager = this.RibbonControl;
            this.txtTeccomHeader.Name = "txtTeccomHeader";
            this.txtTeccomHeader.Size = new System.Drawing.Size(355, 20);
            this.txtTeccomHeader.StyleController = this.LayoutControl;
            this.txtTeccomHeader.TabIndex = 55;
            // 
            // BindingSourceORGDistribution
            // 
            this.BindingSourceORGDistribution.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_Distribution);
            // 
            // itmPath
            // 
            this.itmPath.Control = this.txtPath;
            this.itmPath.CustomizationFormText = "Path";
            this.itmPath.Location = new System.Drawing.Point(0, 48);
            this.itmPath.Name = "itmPath";
            this.itmPath.Size = new System.Drawing.Size(940, 24);
            this.itmPath.Text = "Path";
            this.itmPath.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtPath
            // 
            this.txtPath.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "Path", true));
            this.txtPath.Location = new System.Drawing.Point(146, 431);
            this.txtPath.MenuManager = this.RibbonControl;
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPath.Size = new System.Drawing.Size(826, 20);
            this.txtPath.StyleController = this.LayoutControl;
            this.txtPath.TabIndex = 53;
            this.txtPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtPath_ButtonClick);
            // 
            // itmCustomerCode
            // 
            this.itmCustomerCode.Control = this.txtCustomerCode;
            this.itmCustomerCode.CustomizationFormText = "Customer Code";
            this.itmCustomerCode.Location = new System.Drawing.Point(469, 0);
            this.itmCustomerCode.Name = "itmCustomerCode";
            this.itmCustomerCode.Size = new System.Drawing.Size(471, 24);
            this.itmCustomerCode.Text = "Customer Code";
            this.itmCustomerCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "CustomerCode", true));
            this.txtCustomerCode.Location = new System.Drawing.Point(615, 383);
            this.txtCustomerCode.MenuManager = this.RibbonControl;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(357, 20);
            this.txtCustomerCode.StyleController = this.LayoutControl;
            this.txtCustomerCode.TabIndex = 56;
            // 
            // itmDistributionNumber
            // 
            this.itmDistributionNumber.Control = this.txtDistributionNumber;
            this.itmDistributionNumber.CustomizationFormText = "Distribution Number";
            this.itmDistributionNumber.Location = new System.Drawing.Point(0, 24);
            this.itmDistributionNumber.Name = "itmDistributionNumber";
            this.itmDistributionNumber.Size = new System.Drawing.Size(469, 24);
            this.itmDistributionNumber.Text = "Distribution Number";
            this.itmDistributionNumber.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtDistributionNumber
            // 
            this.txtDistributionNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "DistributionNumber", true));
            this.txtDistributionNumber.Location = new System.Drawing.Point(146, 407);
            this.txtDistributionNumber.MenuManager = this.RibbonControl;
            this.txtDistributionNumber.Name = "txtDistributionNumber";
            this.txtDistributionNumber.Size = new System.Drawing.Size(355, 20);
            this.txtDistributionNumber.StyleController = this.LayoutControl;
            this.txtDistributionNumber.TabIndex = 51;
            // 
            // itmSupplierCode
            // 
            this.itmSupplierCode.Control = this.txtSupplierCode;
            this.itmSupplierCode.CustomizationFormText = "Supplier Code";
            this.itmSupplierCode.Location = new System.Drawing.Point(469, 24);
            this.itmSupplierCode.Name = "itmSupplierCode";
            this.itmSupplierCode.Size = new System.Drawing.Size(471, 24);
            this.itmSupplierCode.Text = "Supplier Code";
            this.itmSupplierCode.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "SupplierCode", true));
            this.txtSupplierCode.Location = new System.Drawing.Point(615, 407);
            this.txtSupplierCode.MenuManager = this.RibbonControl;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(357, 20);
            this.txtSupplierCode.StyleController = this.LayoutControl;
            this.txtSupplierCode.TabIndex = 57;
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.CustomizationFormText = "General";
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmDistributionType,
            this.itmDistributionUserName,
            this.itmUrl,
            this.itmDistributionPassword,
            this.itmInventoryViewLevel,
            this.layoutControlItem8});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(964, 138);
            this.lcgGeneral.Text = "General";
            // 
            // itmDistributionType
            // 
            this.itmDistributionType.Control = this.ddlDistributionType;
            this.itmDistributionType.CustomizationFormText = "Distribution Type";
            this.itmDistributionType.Location = new System.Drawing.Point(0, 0);
            this.itmDistributionType.Name = "itmDistributionType";
            this.itmDistributionType.Size = new System.Drawing.Size(940, 24);
            this.itmDistributionType.Text = "Distribution Type";
            this.itmDistributionType.TextSize = new System.Drawing.Size(106, 13);
            // 
            // ddlDistributionType
            // 
            this.ddlDistributionType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "DistributionTypeId", true));
            this.ddlDistributionType.Location = new System.Drawing.Point(146, 245);
            this.ddlDistributionType.MenuManager = this.RibbonControl;
            this.ddlDistributionType.Name = "ddlDistributionType";
            this.ddlDistributionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlDistributionType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlDistributionType.Properties.DataSource = this.ServerModeSourceDistributionType;
            this.ddlDistributionType.Properties.DisplayMember = "Name";
            this.ddlDistributionType.Properties.NullText = "Select Distribution type ...";
            this.ddlDistributionType.Properties.ValueMember = "Id";
            this.ddlDistributionType.Size = new System.Drawing.Size(826, 20);
            this.ddlDistributionType.StyleController = this.LayoutControl;
            this.ddlDistributionType.TabIndex = 52;
            this.ddlDistributionType.EditValueChanged += new System.EventHandler(this.ddlDistributionType_EditValueChanged);
            // 
            // ServerModeSourceDistributionType
            // 
            this.ServerModeSourceDistributionType.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_DistributionType);
            this.ServerModeSourceDistributionType.KeyExpression = "Id";
            // 
            // itmDistributionUserName
            // 
            this.itmDistributionUserName.Control = this.txtDistributionUserName;
            this.itmDistributionUserName.CustomizationFormText = "Distribution User Name";
            this.itmDistributionUserName.Location = new System.Drawing.Point(0, 24);
            this.itmDistributionUserName.Name = "itmDistributionUserName";
            this.itmDistributionUserName.Size = new System.Drawing.Size(469, 24);
            this.itmDistributionUserName.Text = "User Name";
            this.itmDistributionUserName.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtDistributionUserName
            // 
            this.txtDistributionUserName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "UserName", true));
            this.txtDistributionUserName.Location = new System.Drawing.Point(146, 269);
            this.txtDistributionUserName.MenuManager = this.RibbonControl;
            this.txtDistributionUserName.Name = "txtDistributionUserName";
            this.txtDistributionUserName.Size = new System.Drawing.Size(355, 20);
            this.txtDistributionUserName.StyleController = this.LayoutControl;
            this.txtDistributionUserName.TabIndex = 60;
            // 
            // itmUrl
            // 
            this.itmUrl.Control = this.txtUrl;
            this.itmUrl.CustomizationFormText = "Url";
            this.itmUrl.Location = new System.Drawing.Point(0, 48);
            this.itmUrl.Name = "itmUrl";
            this.itmUrl.Size = new System.Drawing.Size(469, 24);
            this.itmUrl.Text = "Url";
            this.itmUrl.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtUrl
            // 
            this.txtUrl.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "Url", true));
            this.txtUrl.Location = new System.Drawing.Point(146, 293);
            this.txtUrl.MenuManager = this.RibbonControl;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(355, 20);
            this.txtUrl.StyleController = this.LayoutControl;
            this.txtUrl.TabIndex = 59;
            // 
            // itmDistributionPassword
            // 
            this.itmDistributionPassword.Control = this.txtDistributionPassword;
            this.itmDistributionPassword.CustomizationFormText = "Distribution Password";
            this.itmDistributionPassword.Location = new System.Drawing.Point(469, 24);
            this.itmDistributionPassword.Name = "itmDistributionPassword";
            this.itmDistributionPassword.Size = new System.Drawing.Size(471, 24);
            this.itmDistributionPassword.Text = "Password";
            this.itmDistributionPassword.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtDistributionPassword
            // 
            this.txtDistributionPassword.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "Password", true));
            this.txtDistributionPassword.Location = new System.Drawing.Point(615, 269);
            this.txtDistributionPassword.MenuManager = this.RibbonControl;
            this.txtDistributionPassword.Name = "txtDistributionPassword";
            this.txtDistributionPassword.Size = new System.Drawing.Size(357, 20);
            this.txtDistributionPassword.StyleController = this.LayoutControl;
            this.txtDistributionPassword.TabIndex = 61;
            // 
            // itmInventoryViewLevel
            // 
            this.itmInventoryViewLevel.Control = this.txtInventoryViewLevel;
            this.itmInventoryViewLevel.CustomizationFormText = "Inventory View Level";
            this.itmInventoryViewLevel.Location = new System.Drawing.Point(469, 48);
            this.itmInventoryViewLevel.Name = "itmInventoryViewLevel";
            this.itmInventoryViewLevel.Size = new System.Drawing.Size(471, 24);
            this.itmInventoryViewLevel.Text = "Inventory View Level";
            this.itmInventoryViewLevel.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtInventoryViewLevel
            // 
            this.txtInventoryViewLevel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "InventoryViewLevel", true));
            this.txtInventoryViewLevel.Location = new System.Drawing.Point(615, 293);
            this.txtInventoryViewLevel.MenuManager = this.RibbonControl;
            this.txtInventoryViewLevel.Name = "txtInventoryViewLevel";
            this.txtInventoryViewLevel.Size = new System.Drawing.Size(357, 20);
            this.txtInventoryViewLevel.StyleController = this.LayoutControl;
            this.txtInventoryViewLevel.TabIndex = 54;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.chkViewCost;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(940, 23);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // chkViewCost
            // 
            this.chkViewCost.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceORGDistribution, "ViewCost", true));
            this.chkViewCost.Location = new System.Drawing.Point(36, 317);
            this.chkViewCost.MenuManager = this.RibbonControl;
            this.chkViewCost.Name = "chkViewCost";
            this.chkViewCost.Properties.Caption = "View Cost";
            this.chkViewCost.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkViewCost.Size = new System.Drawing.Size(936, 19);
            this.chkViewCost.StyleController = this.LayoutControl;
            this.chkViewCost.TabIndex = 58;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(0, 320);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(964, 10);
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgCustomerGeneral
            // 
            this.lcgCustomerGeneral.CustomizationFormText = "General";
            this.lcgCustomerGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmUserName,
            this.itmPassword});
            this.lcgCustomerGeneral.Location = new System.Drawing.Point(0, 253);
            this.lcgCustomerGeneral.Name = "lcgCustomerGeneral";
            this.lcgCustomerGeneral.Size = new System.Drawing.Size(964, 67);
            this.lcgCustomerGeneral.Text = "General";
            // 
            // itmUserName
            // 
            this.itmUserName.Control = this.txtUserName;
            this.itmUserName.CustomizationFormText = "User Name";
            this.itmUserName.Location = new System.Drawing.Point(0, 0);
            this.itmUserName.Name = "itmUserName";
            this.itmUserName.Size = new System.Drawing.Size(469, 24);
            this.itmUserName.Text = "User Name";
            this.itmUserName.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtUserName
            // 
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Username", true));
            this.txtUserName.Location = new System.Drawing.Point(146, 498);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserName.MenuManager = this.RibbonControl;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(355, 20);
            this.txtUserName.StyleController = this.LayoutControl;
            this.txtUserName.TabIndex = 64;
            // 
            // itmPassword
            // 
            this.itmPassword.Control = this.txtPassword;
            this.itmPassword.CustomizationFormText = "Password";
            this.itmPassword.Location = new System.Drawing.Point(469, 0);
            this.itmPassword.Name = "itmPassword";
            this.itmPassword.Size = new System.Drawing.Size(471, 24);
            this.itmPassword.Text = "Password";
            this.itmPassword.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Password", true));
            this.txtPassword.Location = new System.Drawing.Point(615, 498);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.MenuManager = this.RibbonControl;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(357, 20);
            this.txtPassword.StyleController = this.LayoutControl;
            this.txtPassword.TabIndex = 65;
            // 
            // tabHistory
            // 
            this.tabHistory.CustomizationFormText = "History";
            this.tabHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmHistory});
            this.tabHistory.Location = new System.Drawing.Point(0, 0);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(964, 330);
            this.tabHistory.Text = "History";
            // 
            // itmHistory
            // 
            this.itmHistory.Control = this.grdHistory;
            this.itmHistory.CustomizationFormText = "History";
            this.itmHistory.Location = new System.Drawing.Point(0, 0);
            this.itmHistory.Name = "itmHistory";
            this.itmHistory.Size = new System.Drawing.Size(964, 330);
            this.itmHistory.Text = "History";
            this.itmHistory.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmHistory.TextSize = new System.Drawing.Size(0, 0);
            this.itmHistory.TextVisible = false;
            // 
            // grdHistory
            // 
            this.grdHistory.DataSource = this.InstantFeedbackSourceHistory;
            this.grdHistory.Location = new System.Drawing.Point(24, 214);
            this.grdHistory.MainView = this.grvHistory;
            this.grdHistory.MenuManager = this.RibbonControl;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.Size = new System.Drawing.Size(960, 326);
            this.grdHistory.TabIndex = 66;
            this.grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHistory});
            // 
            // InstantFeedbackSourceHistory
            // 
            this.InstantFeedbackSourceHistory.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_CompanyHistory);
            this.InstantFeedbackSourceHistory.KeyExpression = "Id";
            this.InstantFeedbackSourceHistory.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceHistory_GetQueryable);
            // 
            // grvHistory
            // 
            this.grvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFinancialYear,
            this.colDate,
            this.colCode,
            this.colAmount});
            this.grvHistory.GridControl = this.grdHistory;
            this.grvHistory.Name = "grvHistory";
            this.grvHistory.OptionsView.ShowGroupPanel = false;
            this.grvHistory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFinancialYear, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colFinancialYear
            // 
            this.colFinancialYear.FieldName = "FinancialYear";
            this.colFinancialYear.Name = "colFinancialYear";
            this.colFinancialYear.Visible = true;
            this.colFinancialYear.VisibleIndex = 0;
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 2;
            // 
            // lcgFilters
            // 
            this.lcgFilters.CustomizationFormText = "Filters";
            this.lcgFilters.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgFilters.Location = new System.Drawing.Point(0, 0);
            this.lcgFilters.Name = "lcgFilters";
            this.lcgFilters.Size = new System.Drawing.Size(933, 95);
            this.lcgFilters.Text = "Filters";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.clbDocumentType;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(909, 52);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // clbDocumentType
            // 
            this.clbDocumentType.DataSource = this.ServerModeSourceDocumentType;
            this.clbDocumentType.DisplayMember = "Name";
            this.clbDocumentType.Location = new System.Drawing.Point(36, 237);
            this.clbDocumentType.MultiColumn = true;
            this.clbDocumentType.Name = "clbDocumentType";
            this.clbDocumentType.Size = new System.Drawing.Size(905, 48);
            this.clbDocumentType.StyleController = this.LayoutControl;
            this.clbDocumentType.TabIndex = 63;
            this.clbDocumentType.ValueMember = "Id";
            // 
            // ServerModeSourceDocumentType
            // 
            this.ServerModeSourceDocumentType.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Type);
            this.ServerModeSourceDocumentType.KeyExpression = "Id";
            // 
            // BindingSourceCompanyShippingAddress
            // 
            this.BindingSourceCompanyShippingAddress.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_CompanyAddress);
            // 
            // BindingSourceCompanyBillingAddress
            // 
            this.BindingSourceCompanyBillingAddress.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_CompanyAddress);
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(481, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(134, 587);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Fullname", "Fullname", 52, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.txtCreatedBy.Properties.DataSource = this.ServerModeSourceCreatedBy;
            this.txtCreatedBy.Properties.DisplayMember = "Fullname";
            this.txtCreatedBy.Properties.NullText = "";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Properties.ValueMember = "Id";
            this.txtCreatedBy.Size = new System.Drawing.Size(367, 20);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 49;
            // 
            // ServerModeSourceCreatedBy
            // 
            this.ServerModeSourceCreatedBy.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Person);
            this.ServerModeSourceCreatedBy.KeyExpression = "Id";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(615, 587);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Properties.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(369, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 50;
            // 
            // itmCreatedOn
            // 
            this.itmCreatedOn.Control = this.txtCreatedOn;
            this.itmCreatedOn.CustomizationFormText = "Created On";
            this.itmCreatedOn.Location = new System.Drawing.Point(481, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(483, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(106, 13);
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedOn,
            this.itmCreatedBy});
            this.lcgHistory.Location = new System.Drawing.Point(0, 544);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(988, 67);
            this.lcgHistory.Text = "History";
            // 
            // BindingSourceContacts
            // 
            this.BindingSourceContacts.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_Contact);
            // 
            // BaseCompanyForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 778);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceORGEntitySYSEntity, "Title", true));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "BaseCompanyForm";
            this.Text = "Company";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceORGEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmVatNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSalesContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSalesContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContactSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountingContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccountContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContactAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceORGEntitySYSEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPrefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRegistrationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesmanCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTagCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountryCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomValue6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAccountingInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAccountTypeInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPaymentTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPaymentTerm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePaymentTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCostCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCostCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCostCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccountLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountLimit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOpenItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpenItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOverrideAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOverrideAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatementPreference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbStatementPreference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceStatementPreference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabGeneralInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCustomValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomValue6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompanyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTagCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDiscountCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSalesmanCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCountryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAddressInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgShippingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceShippingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingLine4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShippingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBillingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBillingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingLine4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmBillingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOrdering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgTeccomDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTeccomHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeccomHeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceORGDistribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistributionNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDistributionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDistributionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistributionUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDistributionPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistributionPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmInventoryViewLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventoryViewLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCustomerGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbDocumentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDocumentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompanyShippingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompanyBillingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup lcgDetails;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraEditors.TextEdit txtRegistrationNumber;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem itmCode;
        private DevExpress.XtraLayout.LayoutControlItem itmRegistrationNumber;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.GridLookUpEdit ddlAccountContact;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit2View;
        private DevExpress.XtraEditors.GridLookUpEdit ddlSalesContact;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem itmSalesContact;
        private DevExpress.XtraLayout.LayoutControlItem itmAccountingContact;
        private DevExpress.XtraLayout.LayoutControlItem itmNote;
        private DevExpress.XtraEditors.TextEdit txtCustomValue6;
        private DevExpress.XtraEditors.TextEdit txtCustomValue5;
        private DevExpress.XtraEditors.TextEdit txtCustomValue4;
        private DevExpress.XtraEditors.TextEdit txtCustomValue3;
        private DevExpress.XtraEditors.TextEdit txtCustomValue2;
        private DevExpress.XtraEditors.TextEdit txtCustomValue1;
        private DevExpress.XtraEditors.TextEdit txtCountryCode;
        private DevExpress.XtraEditors.TextEdit txtTagCode;
        private DevExpress.XtraEditors.TextEdit txtSalesmanCode;
        private DevExpress.XtraEditors.TextEdit txtRepCode;
        private DevExpress.XtraEditors.TextEdit txtDiscountCode;
        private DevExpress.XtraEditors.TextEdit txtAreaCode;
        private DevExpress.XtraEditors.TextEdit txtVatNumber;
        private DevExpress.XtraLayout.TabbedControlGroup tcgInformation;
        private DevExpress.XtraLayout.LayoutControlGroup tabGeneralInformation;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem itmVatNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmAreaCode;
        private DevExpress.XtraLayout.LayoutControlItem itmDiscountCode;
        private DevExpress.XtraLayout.LayoutControlItem itmRepCode;
        private DevExpress.XtraLayout.LayoutControlItem itmSalesmanCode;
        private DevExpress.XtraLayout.LayoutControlItem itmTagCode;
        private DevExpress.XtraLayout.LayoutControlItem itmCountryCode;
        private DevExpress.XtraLayout.LayoutControlItem itmCustomValue1;
        private DevExpress.XtraLayout.LayoutControlItem itmCustomValue2;
        private DevExpress.XtraLayout.LayoutControlItem itmCustomValue3;
        private DevExpress.XtraLayout.LayoutControlItem itmCustomValue4;
        private DevExpress.XtraLayout.LayoutControlItem itmCustomValue5;
        private DevExpress.XtraLayout.LayoutControlItem itmCustomValue6;
        private System.Windows.Forms.BindingSource BindingSourceORGEntity;
        private System.Windows.Forms.BindingSource BindingSourceORGEntitySYSEntity;
        private DevExpress.XtraEditors.TextEdit txtBillingCode;
        private DevExpress.XtraEditors.TextEdit txtShippingCode;
        private DevExpress.XtraEditors.TextEdit txtBillingLine4;
        private DevExpress.XtraEditors.TextEdit txtShippingLine4;
        private DevExpress.XtraEditors.TextEdit txtBillingLine3;
        private DevExpress.XtraEditors.TextEdit txtShippingLine3;
        private DevExpress.XtraEditors.TextEdit txtBillingLine2;
        private DevExpress.XtraEditors.TextEdit txtShippingLine2;
        private DevExpress.XtraEditors.TextEdit txtBillingLine1;
        private DevExpress.XtraEditors.TextEdit txtShippingLine1;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingLine1;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingLine2;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingLine3;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingLine4;
        private DevExpress.XtraLayout.LayoutControlItem itmBillingCode;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup lcgShippingAddress;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingLine1;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingLine2;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingLine3;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingLine4;
        private DevExpress.XtraLayout.LayoutControlItem itmShippingCode;
        private System.Windows.Forms.BindingSource BindingSourceShippingAddress;
        private System.Windows.Forms.BindingSource BindingSourceBillingAddress;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCustomValues;
        private DevExpress.XtraLayout.LayoutControlGroup tabAddressInformation;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBillingAddress;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCompanyCode;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceContactSales;
        private DevExpress.XtraGrid.Columns.GridColumn colId1;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyId1;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentId1;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullname1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail1;
        private DevExpress.XtraGrid.Columns.GridColumn colFax1;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone11;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone21;
        private DevExpress.XtraGrid.Columns.GridColumn colNote1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colFullname;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone1;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone2;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private System.Windows.Forms.BindingSource BindingSourceCompanyShippingAddress;
        private System.Windows.Forms.BindingSource BindingSourceCompanyBillingAddress;
        private DevExpress.XtraLayout.LayoutControlGroup tabAccountingInformation;
        private DevExpress.XtraEditors.LookUpEdit ddlPaymentTerm;
        private DevExpress.XtraLayout.LayoutControlGroup lcgAccountTypeInformation;
        private DevExpress.XtraLayout.LayoutControlItem itmPaymentTerm;
        private DevExpress.XtraEditors.LookUpEdit ddlCostCategory;
        private DevExpress.XtraLayout.LayoutControlItem itmCostCategory;
        private DevExpress.XtraEditors.CheckEdit chkOpenItem;
        private DevExpress.XtraLayout.LayoutControlItem itmOpenItem;
        private DevExpress.XtraEditors.CheckEdit chkOverrideAccount;
        private DevExpress.XtraLayout.LayoutControlItem itmOverrideAccount;
        private DevExpress.XtraEditors.TextEdit txtAccountLimit;
        private DevExpress.XtraLayout.LayoutControlItem itmAccountLimit;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePaymentTerm;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCostCategory;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceStatementPreference;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraEditors.TextEdit txtPrefix;
        private DevExpress.XtraLayout.LayoutControlItem itmPrefix;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource BindingSourceContacts;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceContactAccount;
        private DevExpress.XtraLayout.LayoutControlGroup tabOrdering;
        private DevExpress.XtraLayout.LayoutControlGroup tabTransactions;
        private DevExpress.XtraEditors.TextEdit txtDistributionPassword;
        private DevExpress.XtraEditors.TextEdit txtDistributionUserName;
        private DevExpress.XtraEditors.TextEdit txtUrl;
        private DevExpress.XtraEditors.CheckEdit chkViewCost;
        private DevExpress.XtraEditors.TextEdit txtSupplierCode;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private DevExpress.XtraEditors.TextEdit txtTeccomHeader;
        private DevExpress.XtraEditors.TextEdit txtInventoryViewLevel;
        private DevExpress.XtraEditors.LookUpEdit ddlDistributionType;
        private DevExpress.XtraEditors.TextEdit txtDistributionNumber;
        private DevExpress.XtraEditors.ButtonEdit txtPath;
        private DevExpress.XtraLayout.LayoutControlItem itmDistributionNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmDistributionType;
        private DevExpress.XtraLayout.LayoutControlItem itmPath;
        private DevExpress.XtraLayout.LayoutControlItem itmInventoryViewLevel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem itmUrl;
        private DevExpress.XtraLayout.LayoutControlItem itmDistributionUserName;
        private DevExpress.XtraLayout.LayoutControlItem itmDistributionPassword;
        private DevExpress.XtraLayout.LayoutControlGroup lcgTeccomDetail;
        private DevExpress.XtraLayout.LayoutControlItem itmSupplierCode;
        private DevExpress.XtraLayout.LayoutControlItem itmCustomerCode;
        private DevExpress.XtraLayout.LayoutControlItem itmTeccomHeader;
        private System.Windows.Forms.BindingSource BindingSourceORGDistribution;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceDistributionType;
        private DevExpress.XtraLayout.LayoutControlGroup lcgGeneral;
        private DevExpress.XtraGrid.GridControl grdTransactions;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTransactions;
        private DevExpress.XtraLayout.LayoutControlItem itmGridTransactions;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceTransaction;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFilters;
        private DevExpress.XtraEditors.CheckedListBoxControl clbDocumentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceDocumentType;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentType;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPostedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand2;
        private DevExpress.XtraGrid.Columns.GridColumn colOnReserve;
        private DevExpress.XtraGrid.Columns.GridColumn colOnOrder2;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost3;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitAverage1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colYourReference;
        private DevExpress.XtraGrid.Columns.GridColumn colOurReference;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong3;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong4;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong5;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn colRepCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesManCode;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceShort4;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceShort5;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstPrintedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrintedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstPrintedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPrintedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colValidDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCash;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalRounding;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCreatedBy;
        private DevExpress.XtraEditors.LookUpEdit txtCreatedBy;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCustomerGeneral;
        private DevExpress.XtraLayout.LayoutControlItem itmUserName;
        private DevExpress.XtraLayout.LayoutControlItem itmPassword;
        private DevExpress.XtraLayout.LayoutControlGroup tabHistory;
        private DevExpress.XtraGrid.GridControl grdHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHistory;
        private DevExpress.XtraLayout.LayoutControlItem itmHistory;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceHistory;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialYear;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraEditors.CheckedComboBoxEdit clbStatementPreference;
        private DevExpress.XtraLayout.LayoutControlItem itmStatementPreference;
    }
}