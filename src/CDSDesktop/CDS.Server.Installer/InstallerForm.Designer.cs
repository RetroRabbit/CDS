namespace CDS.Server.Installer
{
    partial class InstallerForm
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
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerForm));
            this.txtSAPassword = new DevExpress.XtraEditors.TextEdit();
            this.lcSQLInstallation = new DevExpress.XtraLayout.LayoutControl();
            this.meAdministratorsMemo = new DevExpress.XtraEditors.MemoEdit();
            this.gcSQLServerAdministrators = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceSQLServerAdministrators = new System.Windows.Forms.BindingSource();
            this.gvSQLServerAdministrators = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPassword = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtSAPassworkConfirm = new DevExpress.XtraEditors.TextEdit();
            this.rgAuthenticationMode = new DevExpress.XtraEditors.RadioGroup();
            this.rgInstanceType = new DevExpress.XtraEditors.RadioGroup();
            this.txtInstanceName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgServerConfiguration = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmInstanceName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmInstanceType = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgAuthentication = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAuthenticationMode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgSAAccount = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSAPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSAPasswordConfirm = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgSQLServerAdministrators = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAdministratorsMemo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcuAdministratorUsers = new DevExpress.XtraLayout.LayoutControlItem();
            this.lvSite = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colTelephone = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colTelephone = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colEmailAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colEmailAddress = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colRegistrationNumber = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colRegistrationNumber = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colVatPercentage = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colVatPercentage = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colVatNumber = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colVatNumber = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCurrency = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCurrency = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCashierRefreshIntervals = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCashierRefreshIntervals = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colSMTPServerLocation = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colSMTPServerLocation = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colAccountEmailAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colAccountEmailAddress = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colAccountEmailUsername = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colAccountEmailUsername = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colAccountEmailPassword = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colAccountEmailPassword = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colAccountEmailDomain = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colAccountEmailDomain = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colAccountEmailBCCAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colAccountEmailBCCAddress = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDocumentEmailAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDocumentEmailAddress = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDocumentEmailUsername = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDocumentEmailUsername = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDocumentEmailPassword = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDocumentEmailPassword = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDocumentEmailDomain = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDocumentEmailDomain = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDocumentEmailBCCAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDocumentEmailBCCAddress = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colProxyServerLocation = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colProxyServerLocation = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colProxyServerUsername = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colProxyServerUsername = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colProxyServerPassword = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colProxyServerPassword = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colPrintServerLocation = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colPrintServerLocation = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colBankName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colBankName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colBankBranch = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colBankBranch = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colBankCode = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colBankCode = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colBankAccountNumber = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colBankAccountNumber = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDefaultMessageDocument = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDefaultMessageDocument = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDefaultMessageStatement = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDefaultMessageStatement = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colPrinterBarcode = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colPrinterBarcode = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colPrinterPicker = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colPrinterPicker = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colPrinterReceipt = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colPrinterReceipt = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colUpdateURL = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colUpdateURL = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMinimizeNavigation = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMinimizeNavigation = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colUpdateCheckTime = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colUpdateCheckTime = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colPaymentAccounts = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colPaymentAccounts = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colUseBarcodes = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colUseBarcodes = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colUseLabels = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colUseLabels = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCopyInvoiceOrderNumbertoCreditNote = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colAutoWriteoffOpenItemCredits = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colAutoWriteoffOpenItemCredits = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNegativeDiscountEffects = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colNegativeDiscountEffects = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNotifyonZeroMarkupSale = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colNotifyonZeroMarkupSale = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNotifyonZeroProfitSale = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colNotifyonZeroProfitSale = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colQuoteValidDays = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colQuoteValidDays = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colQuoteValidMax = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colQuoteValidMax = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colRoundingAmount = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colRoundingAmount = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCashierPaymentsFullAmount = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCashierPaymentsFullAmount = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colCODAccountLimit = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colCODAccountLimit = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDebtorGracePeriod = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDebtorGracePeriod = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDefaultInterestCharged = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDefaultInterestCharged = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMonthWeight3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMonthWeight3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMonthWeight6 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMonthWeight6 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMonthWeight12 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMonthWeight12 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMonthWeight24 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMonthWeight24 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMonthWeight36 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMonthWeight36 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colFixedOrderCost = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colFixedOrderCost = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMaxOrderLines = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMaxOrderLines = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colSafetyStockPeriod = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colSafetyStockPeriod = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colDistributionNumber = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colDistributionNumber = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colBackupLocation = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colBackupLocation = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNotifyonBackOrder = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colNotifyonBackOrder = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.grdEntity = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceEntity = new System.Windows.Forms.BindingSource();
            this.grvAddress = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvEntity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.item1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.grvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colImportUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPerson = new DevExpress.XtraGrid.GridControl();
            this.BindingSourcePerson = new System.Windows.Forms.BindingSource();
            this.grvPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colImportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportArchived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlRole = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.ServerModeSourceRoles = new DevExpress.Data.Linq.LinqServerModeSource();
            this.ddlRoleView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRoleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lvUser = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.SplashManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::CDS.Server.Installer.WaitPopup), true, true);
            this.wcInstaller = new DevExpress.XtraWizard.WizardControl();
            this.wpWelcome = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wpConnection = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.txtTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.cbeAuthentication = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ddlServer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCompanyConnectionName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgCompany = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgConnection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmServer = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmAuthentication = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmUsername = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmTimeout = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpComplete = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wpSiteSetup = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtPrintServerLocation = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmPrintServerLocation = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmSiteGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpSqlSetupOption = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.btnInstallSQLExpress = new DevExpress.XtraEditors.CheckButton();
            this.btnChooseSql = new DevExpress.XtraEditors.CheckButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.wpSqlInstall = new DevExpress.XtraWizard.WizardPage();
            this.wpDataDirectories = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl4 = new DevExpress.XtraLayout.LayoutControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.layoutControl5 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDatabaseNameMasked = new DevExpress.XtraEditors.TextEdit();
            this.txtDatabaseName = new DevExpress.XtraEditors.TextEdit();
            this.bceDefaultDirectory = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceMainData = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceMainLog = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceAutomaticOrdering = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceCalendar = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceCatalogue = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceLedger = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceHumanResources = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceItemBuyout = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceIndex = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceItem = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceItemBOM = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceItemDiscount = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceJob = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceOrganisation = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceOrganisationTransactions = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceReport = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceSecurity = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceSystem = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceSystemDocument = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.bceSystemMessage = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.lcgDatabaseFileLocations = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDefaultDirectory = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDatabaseName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDatabaseNameMasked = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgDataDirectories = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpNewOrImport = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl6 = new DevExpress.XtraLayout.LayoutControl();
            this.btnImportChimera = new DevExpress.XtraEditors.CheckButton();
            this.btnNewCompany = new DevExpress.XtraEditors.CheckButton();
            this.btnImportCDS = new DevExpress.XtraEditors.CheckButton();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpImportConnection = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl7 = new DevExpress.XtraLayout.LayoutControl();
            this.txtOldCDSDatabase = new DevExpress.XtraEditors.TextEdit();
            this.ddlOldCDSServer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbeOldCDSAuthentication = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtOldCDSUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtOldCDSPassword = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmImportServer = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmImportAuthentication = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmImportUsername = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmImportPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmImportDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpSetupUsers = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl8 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmUsersGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpImportOldData = new DevExpress.XtraWizard.WizardPage();
            this.lcImportOldCDS = new DevExpress.XtraLayout.LayoutControl();
            this.meConsoleErrors = new DevExpress.XtraEditors.MemoEdit();
            this.meConsole = new DevExpress.XtraEditors.MemoEdit();
            this.grdImportCDS = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceImportWork = new System.Windows.Forms.BindingSource();
            this.grvImportCDS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colImportWorkDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRows = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imgState = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmImportOldCDSGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.lgcImportConsole = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmConsoleErrors = new DevExpress.XtraLayout.LayoutControlItem();
            this.ValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.ImageCollectionState = new DevExpress.Utils.ImageCollection();
            this.txtUpdateURL = new DevExpress.XtraEditors.TextEdit();
            this.itmUpdateURL = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtClientZipLocation = new DevExpress.XtraEditors.TextEdit();
            this.itmClientZipLocation = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtSAPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSQLInstallation)).BeginInit();
            this.lcSQLInstallation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meAdministratorsMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSQLServerAdministrators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSQLServerAdministrators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSQLServerAdministrators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSAPassworkConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAuthenticationMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgInstanceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstanceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgServerConfiguration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmInstanceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmInstanceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAuthenticationMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSAAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSAPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSAPasswordConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSQLServerAdministrators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAdministratorsMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcuAdministratorUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEmailAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRegistrationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colVatPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colVatNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCashierRefreshIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSMTPServerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailDomain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailBCCAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailDomain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailBCCAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colProxyServerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colProxyServerUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colProxyServerPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrintServerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankAccountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDefaultMessageDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDefaultMessageStatement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrinterBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrinterPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrinterReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUpdateURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMinimizeNavigation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUpdateCheckTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPaymentAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUseBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUseLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAutoWriteoffOpenItemCredits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNegativeDiscountEffects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNotifyonZeroMarkupSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNotifyonZeroProfitSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colQuoteValidDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colQuoteValidMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRoundingAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCashierPaymentsFullAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCODAccountLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDebtorGracePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDefaultInterestCharged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFixedOrderCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMaxOrderLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSafetyStockPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDistributionNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBackupLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNotifyonBackOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRoleView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcInstaller)).BeginInit();
            this.wcInstaller.SuspendLayout();
            this.wpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyConnectionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDatabase)).BeginInit();
            this.wpSiteSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintServerLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPrintServerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSiteGrid)).BeginInit();
            this.wpSqlSetupOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            this.wpSqlInstall.SuspendLayout();
            this.wpDataDirectories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).BeginInit();
            this.layoutControl4.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl5)).BeginInit();
            this.layoutControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseNameMasked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceDefaultDirectory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceMainData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceMainLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceAutomaticOrdering.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceCalendar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceCatalogue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceLedger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceHumanResources.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItemBuyout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItemBOM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItemDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceOrganisation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceOrganisationTransactions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSecurity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSystemDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSystemMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDatabaseFileLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDefaultDirectory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabaseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabaseNameMasked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDataDirectories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            this.wpNewOrImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl6)).BeginInit();
            this.layoutControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            this.wpImportConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).BeginInit();
            this.layoutControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldCDSDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOldCDSServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeOldCDSAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldCDSUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldCDSPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportDatabase)).BeginInit();
            this.wpSetupUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl8)).BeginInit();
            this.layoutControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsersGrid)).BeginInit();
            this.wpImportOldData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcImportOldCDS)).BeginInit();
            this.lcImportOldCDS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meConsoleErrors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meConsole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImportCDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceImportWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImportCDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportOldCDSGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgcImportConsole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmConsoleErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateURL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUpdateURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientZipLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClientZipLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSAPassword
            // 
            this.txtSAPassword.Enabled = false;
            this.txtSAPassword.Location = new System.Drawing.Point(155, 256);
            this.txtSAPassword.Name = "txtSAPassword";
            this.txtSAPassword.Properties.PasswordChar = '*';
            this.txtSAPassword.Size = new System.Drawing.Size(680, 22);
            this.txtSAPassword.StyleController = this.lcSQLInstallation;
            this.txtSAPassword.TabIndex = 7;
            compareAgainstControlValidationRule2.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Equals;
            compareAgainstControlValidationRule2.Control = this.txtSAPassworkConfirm;
            compareAgainstControlValidationRule2.ErrorText = "Password does not match";
            this.ValidationProvider.SetValidationRule(this.txtSAPassword, compareAgainstControlValidationRule2);
            // 
            // lcSQLInstallation
            // 
            this.lcSQLInstallation.Controls.Add(this.meAdministratorsMemo);
            this.lcSQLInstallation.Controls.Add(this.gcSQLServerAdministrators);
            this.lcSQLInstallation.Controls.Add(this.txtSAPassworkConfirm);
            this.lcSQLInstallation.Controls.Add(this.txtSAPassword);
            this.lcSQLInstallation.Controls.Add(this.rgAuthenticationMode);
            this.lcSQLInstallation.Controls.Add(this.rgInstanceType);
            this.lcSQLInstallation.Controls.Add(this.txtInstanceName);
            this.lcSQLInstallation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcSQLInstallation.Location = new System.Drawing.Point(0, 0);
            this.lcSQLInstallation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lcSQLInstallation.Name = "lcSQLInstallation";
            this.lcSQLInstallation.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2712, 302, 581, 413);
            this.lcSQLInstallation.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcSQLInstallation.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcSQLInstallation.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcSQLInstallation.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcSQLInstallation.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcSQLInstallation.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcSQLInstallation.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcSQLInstallation.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcSQLInstallation.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcSQLInstallation.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcSQLInstallation.Root = this.layoutControlGroup3;
            this.lcSQLInstallation.Size = new System.Drawing.Size(883, 518);
            this.lcSQLInstallation.TabIndex = 0;
            this.lcSQLInstallation.Text = "layoutControl4";
            // 
            // meAdministratorsMemo
            // 
            this.meAdministratorsMemo.EditValue = "SQL Server administrators have unrestricted access to the Database Engine";
            this.meAdministratorsMemo.Location = new System.Drawing.Point(663, 342);
            this.meAdministratorsMemo.Name = "meAdministratorsMemo";
            this.meAdministratorsMemo.Properties.ReadOnly = true;
            this.meAdministratorsMemo.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.meAdministratorsMemo.Size = new System.Drawing.Size(160, 116);
            this.meAdministratorsMemo.StyleController = this.lcSQLInstallation;
            this.meAdministratorsMemo.TabIndex = 10;
            // 
            // gcSQLServerAdministrators
            // 
            this.gcSQLServerAdministrators.DataSource = this.BindingSourceSQLServerAdministrators;
            this.gcSQLServerAdministrators.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSQLServerAdministrators.Enabled = false;
            this.gcSQLServerAdministrators.Location = new System.Drawing.Point(60, 342);
            this.gcSQLServerAdministrators.MainView = this.gvSQLServerAdministrators;
            this.gcSQLServerAdministrators.Name = "gcSQLServerAdministrators";
            this.gcSQLServerAdministrators.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repPassword});
            this.gcSQLServerAdministrators.Size = new System.Drawing.Size(599, 116);
            this.gcSQLServerAdministrators.TabIndex = 9;
            this.gcSQLServerAdministrators.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSQLServerAdministrators});
            // 
            // BindingSourceSQLServerAdministrators
            // 
            this.BindingSourceSQLServerAdministrators.DataSource = typeof(CDS.Server.Installer.InstallerForm.SQLServerAdministrators);
            // 
            // gvSQLServerAdministrators
            // 
            this.gvSQLServerAdministrators.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsername,
            this.colPassword});
            this.gvSQLServerAdministrators.GridControl = this.gcSQLServerAdministrators;
            this.gvSQLServerAdministrators.Name = "gvSQLServerAdministrators";
            this.gvSQLServerAdministrators.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvSQLServerAdministrators.OptionsView.ShowGroupPanel = false;
            // 
            // colUsername
            // 
            this.colUsername.FieldName = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 0;
            // 
            // colPassword
            // 
            this.colPassword.ColumnEdit = this.repPassword;
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.Visible = true;
            this.colPassword.VisibleIndex = 1;
            // 
            // repPassword
            // 
            this.repPassword.AutoHeight = false;
            this.repPassword.Name = "repPassword";
            this.repPassword.PasswordChar = '*';
            // 
            // txtSAPassworkConfirm
            // 
            this.txtSAPassworkConfirm.Enabled = false;
            this.txtSAPassworkConfirm.Location = new System.Drawing.Point(155, 282);
            this.txtSAPassworkConfirm.Name = "txtSAPassworkConfirm";
            this.txtSAPassworkConfirm.Properties.PasswordChar = '*';
            this.txtSAPassworkConfirm.Size = new System.Drawing.Size(680, 22);
            this.txtSAPassworkConfirm.StyleController = this.lcSQLInstallation;
            this.txtSAPassworkConfirm.TabIndex = 8;
            compareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Equals;
            compareAgainstControlValidationRule1.Control = this.txtSAPassword;
            compareAgainstControlValidationRule1.ErrorText = "Password does not match";
            this.ValidationProvider.SetValidationRule(this.txtSAPassworkConfirm, compareAgainstControlValidationRule1);
            // 
            // rgAuthenticationMode
            // 
            this.rgAuthenticationMode.EditValue = true;
            this.rgAuthenticationMode.Location = new System.Drawing.Point(36, 149);
            this.rgAuthenticationMode.Name = "rgAuthenticationMode";
            this.rgAuthenticationMode.Properties.Columns = 1;
            this.rgAuthenticationMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Windows Authentication Mode"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Mixed Mode (SQL Server authentication and Windows authentication)")});
            this.rgAuthenticationMode.Size = new System.Drawing.Size(811, 69);
            this.rgAuthenticationMode.StyleController = this.lcSQLInstallation;
            this.rgAuthenticationMode.TabIndex = 6;
            this.rgAuthenticationMode.SelectedIndexChanged += new System.EventHandler(this.rgAuthenticationMode_SelectedIndexChanged);
            // 
            // rgInstanceType
            // 
            this.rgInstanceType.EditValue = true;
            this.rgInstanceType.Location = new System.Drawing.Point(24, 46);
            this.rgInstanceType.Name = "rgInstanceType";
            this.rgInstanceType.Properties.Columns = 1;
            this.rgInstanceType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Default Instance", true, true),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Named Instance", true, false)});
            this.rgInstanceType.Size = new System.Drawing.Size(143, 65);
            this.rgInstanceType.StyleController = this.lcSQLInstallation;
            this.rgInstanceType.TabIndex = 5;
            this.rgInstanceType.SelectedIndexChanged += new System.EventHandler(this.rgInstanceType_SelectedIndexChanged);
            // 
            // txtInstanceName
            // 
            this.txtInstanceName.Enabled = false;
            this.txtInstanceName.Location = new System.Drawing.Point(171, 89);
            this.txtInstanceName.Name = "txtInstanceName";
            this.txtInstanceName.Size = new System.Drawing.Size(688, 22);
            this.txtInstanceName.StyleController = this.lcSQLInstallation;
            this.txtInstanceName.TabIndex = 4;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgServerConfiguration});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup3.Text = "Root";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // lcgServerConfiguration
            // 
            this.lcgServerConfiguration.CustomizationFormText = "Server Configuration";
            this.lcgServerConfiguration.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmInstanceName,
            this.emptySpaceItem8,
            this.itmInstanceType,
            this.lcgAuthentication});
            this.lcgServerConfiguration.Location = new System.Drawing.Point(0, 0);
            this.lcgServerConfiguration.Name = "lcgServerConfiguration";
            this.lcgServerConfiguration.Size = new System.Drawing.Size(863, 498);
            this.lcgServerConfiguration.Text = "Server Configuration";
            // 
            // itmInstanceName
            // 
            this.itmInstanceName.Control = this.txtInstanceName;
            this.itmInstanceName.CustomizationFormText = "Instance Name";
            this.itmInstanceName.Location = new System.Drawing.Point(147, 43);
            this.itmInstanceName.Name = "itmInstanceName";
            this.itmInstanceName.Size = new System.Drawing.Size(692, 26);
            this.itmInstanceName.Text = "Instance Name";
            this.itmInstanceName.TextSize = new System.Drawing.Size(0, 0);
            this.itmInstanceName.TextVisible = false;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(147, 0);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(692, 43);
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmInstanceType
            // 
            this.itmInstanceType.Control = this.rgInstanceType;
            this.itmInstanceType.CustomizationFormText = "Instance Type";
            this.itmInstanceType.Location = new System.Drawing.Point(0, 0);
            this.itmInstanceType.Name = "itmInstanceType";
            this.itmInstanceType.Size = new System.Drawing.Size(147, 69);
            this.itmInstanceType.Text = "Instance Type";
            this.itmInstanceType.TextSize = new System.Drawing.Size(0, 0);
            this.itmInstanceType.TextVisible = false;
            // 
            // lcgAuthentication
            // 
            this.lcgAuthentication.CustomizationFormText = "Authentication";
            this.lcgAuthentication.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAuthenticationMode,
            this.lcgSAAccount});
            this.lcgAuthentication.Location = new System.Drawing.Point(0, 69);
            this.lcgAuthentication.Name = "lcgAuthentication";
            this.lcgAuthentication.Size = new System.Drawing.Size(839, 383);
            this.lcgAuthentication.Text = "Authentication";
            // 
            // itmAuthenticationMode
            // 
            this.itmAuthenticationMode.Control = this.rgAuthenticationMode;
            this.itmAuthenticationMode.CustomizationFormText = "Authentication Mode";
            this.itmAuthenticationMode.Location = new System.Drawing.Point(0, 0);
            this.itmAuthenticationMode.Name = "itmAuthenticationMode";
            this.itmAuthenticationMode.Size = new System.Drawing.Size(815, 73);
            this.itmAuthenticationMode.Text = "Authentication Mode";
            this.itmAuthenticationMode.TextSize = new System.Drawing.Size(0, 0);
            this.itmAuthenticationMode.TextVisible = false;
            // 
            // lcgSAAccount
            // 
            this.lcgSAAccount.CustomizationFormText = "SA Account";
            this.lcgSAAccount.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSAPassword,
            this.lciSAPasswordConfirm,
            this.lcgSQLServerAdministrators});
            this.lcgSAAccount.Location = new System.Drawing.Point(0, 73);
            this.lcgSAAccount.Name = "lcgSAAccount";
            this.lcgSAAccount.Size = new System.Drawing.Size(815, 264);
            this.lcgSAAccount.Text = "Specify the password for SQL Server system administrator (sa) account";
            // 
            // lciSAPassword
            // 
            this.lciSAPassword.Control = this.txtSAPassword;
            this.lciSAPassword.CustomizationFormText = "Password";
            this.lciSAPassword.Location = new System.Drawing.Point(0, 0);
            this.lciSAPassword.Name = "lciSAPassword";
            this.lciSAPassword.Size = new System.Drawing.Size(791, 26);
            this.lciSAPassword.Text = "Password";
            this.lciSAPassword.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lciSAPasswordConfirm
            // 
            this.lciSAPasswordConfirm.Control = this.txtSAPassworkConfirm;
            this.lciSAPasswordConfirm.CustomizationFormText = "SA Password Confirm";
            this.lciSAPasswordConfirm.Location = new System.Drawing.Point(0, 26);
            this.lciSAPasswordConfirm.Name = "lciSAPasswordConfirm";
            this.lciSAPasswordConfirm.Size = new System.Drawing.Size(791, 26);
            this.lciSAPasswordConfirm.Text = "Password Confirm";
            this.lciSAPasswordConfirm.TextSize = new System.Drawing.Size(104, 16);
            // 
            // lcgSQLServerAdministrators
            // 
            this.lcgSQLServerAdministrators.CustomizationFormText = "SQL Server administrators";
            this.lcgSQLServerAdministrators.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAdministratorsMemo,
            this.lcuAdministratorUsers});
            this.lcgSQLServerAdministrators.Location = new System.Drawing.Point(0, 52);
            this.lcgSQLServerAdministrators.Name = "lcgSQLServerAdministrators";
            this.lcgSQLServerAdministrators.Size = new System.Drawing.Size(791, 166);
            this.lcgSQLServerAdministrators.Text = "Specify SQL Server administrators";
            // 
            // lciAdministratorsMemo
            // 
            this.lciAdministratorsMemo.Control = this.meAdministratorsMemo;
            this.lciAdministratorsMemo.CustomizationFormText = "Administrators Memo";
            this.lciAdministratorsMemo.Location = new System.Drawing.Point(603, 0);
            this.lciAdministratorsMemo.Name = "lciAdministratorsMemo";
            this.lciAdministratorsMemo.Size = new System.Drawing.Size(164, 120);
            this.lciAdministratorsMemo.Text = "Administrators Memo";
            this.lciAdministratorsMemo.TextSize = new System.Drawing.Size(0, 0);
            this.lciAdministratorsMemo.TextVisible = false;
            // 
            // lcuAdministratorUsers
            // 
            this.lcuAdministratorUsers.Control = this.gcSQLServerAdministrators;
            this.lcuAdministratorUsers.CustomizationFormText = "Administrator Users";
            this.lcuAdministratorUsers.Location = new System.Drawing.Point(0, 0);
            this.lcuAdministratorUsers.Name = "lcuAdministratorUsers";
            this.lcuAdministratorUsers.Size = new System.Drawing.Size(603, 120);
            this.lcuAdministratorUsers.Text = "Administrator Users";
            this.lcuAdministratorUsers.TextSize = new System.Drawing.Size(0, 0);
            this.lcuAdministratorUsers.TextVisible = false;
            // 
            // lvSite
            // 
            this.lvSite.CardHorzInterval = 1;
            this.lvSite.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colTelephone,
            this.colEmailAddress,
            this.colRegistrationNumber,
            this.colVatPercentage,
            this.colVatNumber,
            this.colCurrency,
            this.colCashierRefreshIntervals,
            this.colSMTPServerLocation,
            this.colAccountEmailAddress,
            this.colAccountEmailUsername,
            this.colAccountEmailPassword,
            this.colAccountEmailDomain,
            this.colAccountEmailBCCAddress,
            this.colDocumentEmailAddress,
            this.colDocumentEmailUsername,
            this.colDocumentEmailPassword,
            this.colDocumentEmailDomain,
            this.colDocumentEmailBCCAddress,
            this.colProxyServerLocation,
            this.colProxyServerUsername,
            this.colProxyServerPassword,
            this.colPrintServerLocation,
            this.colBankName,
            this.colBankBranch,
            this.colBankCode,
            this.colBankAccountNumber,
            this.colDefaultMessageDocument,
            this.colDefaultMessageStatement,
            this.colPrinterBarcode,
            this.colPrinterPicker,
            this.colPrinterReceipt,
            this.colUpdateURL,
            this.colMinimizeNavigation,
            this.colUpdateCheckTime,
            this.colPaymentAccounts,
            this.colUseBarcodes,
            this.colUseLabels,
            this.colCopyInvoiceOrderNumbertoCreditNote,
            this.colAutoWriteoffOpenItemCredits,
            this.colNegativeDiscountEffects,
            this.colNotifyonZeroMarkupSale,
            this.colNotifyonZeroProfitSale,
            this.colQuoteValidDays,
            this.colQuoteValidMax,
            this.colRoundingAmount,
            this.colCashierPaymentsFullAmount,
            this.colCODAccountLimit,
            this.colDebtorGracePeriod,
            this.colDefaultInterestCharged,
            this.colMonthWeight3,
            this.colMonthWeight6,
            this.colMonthWeight12,
            this.colMonthWeight24,
            this.colMonthWeight36,
            this.colFixedOrderCost,
            this.colMaxOrderLines,
            this.colSafetyStockPeriod,
            this.colDistributionNumber,
            this.colBackupLocation,
            this.colNotifyonBackOrder});
            this.lvSite.GridControl = this.grdEntity;
            this.lvSite.Name = "lvSite";
            this.lvSite.OptionsItemText.TextToControlDistance = 2;
            this.lvSite.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.lvSite.OptionsView.DefaultColumnCount = 5;
            this.lvSite.OptionsView.ShowCardCaption = false;
            this.lvSite.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.lvSite.OptionsView.ShowHeaderPanel = false;
            this.lvSite.TemplateCard = this.layoutViewCard1;
            // 
            // colTelephone
            // 
            this.colTelephone.FieldName = "Telephone";
            this.colTelephone.LayoutViewField = this.layoutViewField_colTelephone;
            this.colTelephone.Name = "colTelephone";
            // 
            // layoutViewField_colTelephone
            // 
            this.layoutViewField_colTelephone.EditorPreferredWidth = 204;
            this.layoutViewField_colTelephone.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colTelephone.Name = "layoutViewField_colTelephone";
            this.layoutViewField_colTelephone.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colTelephone.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colEmailAddress
            // 
            this.colEmailAddress.FieldName = "EmailAddress";
            this.colEmailAddress.LayoutViewField = this.layoutViewField_colEmailAddress;
            this.colEmailAddress.Name = "colEmailAddress";
            // 
            // layoutViewField_colEmailAddress
            // 
            this.layoutViewField_colEmailAddress.EditorPreferredWidth = 202;
            this.layoutViewField_colEmailAddress.Location = new System.Drawing.Point(417, 0);
            this.layoutViewField_colEmailAddress.Name = "layoutViewField_colEmailAddress";
            this.layoutViewField_colEmailAddress.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colEmailAddress.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colRegistrationNumber
            // 
            this.colRegistrationNumber.FieldName = "RegistrationNumber";
            this.colRegistrationNumber.LayoutViewField = this.layoutViewField_colRegistrationNumber;
            this.colRegistrationNumber.Name = "colRegistrationNumber";
            // 
            // layoutViewField_colRegistrationNumber
            // 
            this.layoutViewField_colRegistrationNumber.EditorPreferredWidth = 204;
            this.layoutViewField_colRegistrationNumber.Location = new System.Drawing.Point(831, 0);
            this.layoutViewField_colRegistrationNumber.Name = "layoutViewField_colRegistrationNumber";
            this.layoutViewField_colRegistrationNumber.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colRegistrationNumber.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colVatPercentage
            // 
            this.colVatPercentage.FieldName = "VatPercentage";
            this.colVatPercentage.LayoutViewField = this.layoutViewField_colVatPercentage;
            this.colVatPercentage.Name = "colVatPercentage";
            // 
            // layoutViewField_colVatPercentage
            // 
            this.layoutViewField_colVatPercentage.EditorPreferredWidth = 204;
            this.layoutViewField_colVatPercentage.Location = new System.Drawing.Point(0, 24);
            this.layoutViewField_colVatPercentage.Name = "layoutViewField_colVatPercentage";
            this.layoutViewField_colVatPercentage.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colVatPercentage.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colVatNumber
            // 
            this.colVatNumber.FieldName = "VatNumber";
            this.colVatNumber.LayoutViewField = this.layoutViewField_colVatNumber;
            this.colVatNumber.Name = "colVatNumber";
            // 
            // layoutViewField_colVatNumber
            // 
            this.layoutViewField_colVatNumber.EditorPreferredWidth = 202;
            this.layoutViewField_colVatNumber.Location = new System.Drawing.Point(417, 24);
            this.layoutViewField_colVatNumber.Name = "layoutViewField_colVatNumber";
            this.layoutViewField_colVatNumber.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colVatNumber.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colCurrency
            // 
            this.colCurrency.FieldName = "Currency";
            this.colCurrency.LayoutViewField = this.layoutViewField_colCurrency;
            this.colCurrency.Name = "colCurrency";
            // 
            // layoutViewField_colCurrency
            // 
            this.layoutViewField_colCurrency.EditorPreferredWidth = 204;
            this.layoutViewField_colCurrency.Location = new System.Drawing.Point(831, 24);
            this.layoutViewField_colCurrency.Name = "layoutViewField_colCurrency";
            this.layoutViewField_colCurrency.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colCurrency.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colCashierRefreshIntervals
            // 
            this.colCashierRefreshIntervals.FieldName = "CashierRefreshIntervals";
            this.colCashierRefreshIntervals.LayoutViewField = this.layoutViewField_colCashierRefreshIntervals;
            this.colCashierRefreshIntervals.Name = "colCashierRefreshIntervals";
            // 
            // layoutViewField_colCashierRefreshIntervals
            // 
            this.layoutViewField_colCashierRefreshIntervals.EditorPreferredWidth = 204;
            this.layoutViewField_colCashierRefreshIntervals.Location = new System.Drawing.Point(0, 48);
            this.layoutViewField_colCashierRefreshIntervals.Name = "layoutViewField_colCashierRefreshIntervals";
            this.layoutViewField_colCashierRefreshIntervals.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colCashierRefreshIntervals.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colSMTPServerLocation
            // 
            this.colSMTPServerLocation.FieldName = "SMTPServerLocation";
            this.colSMTPServerLocation.LayoutViewField = this.layoutViewField_colSMTPServerLocation;
            this.colSMTPServerLocation.Name = "colSMTPServerLocation";
            // 
            // layoutViewField_colSMTPServerLocation
            // 
            this.layoutViewField_colSMTPServerLocation.EditorPreferredWidth = 202;
            this.layoutViewField_colSMTPServerLocation.Location = new System.Drawing.Point(417, 48);
            this.layoutViewField_colSMTPServerLocation.Name = "layoutViewField_colSMTPServerLocation";
            this.layoutViewField_colSMTPServerLocation.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colSMTPServerLocation.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colAccountEmailAddress
            // 
            this.colAccountEmailAddress.FieldName = "AccountEmailAddress";
            this.colAccountEmailAddress.LayoutViewField = this.layoutViewField_colAccountEmailAddress;
            this.colAccountEmailAddress.Name = "colAccountEmailAddress";
            // 
            // layoutViewField_colAccountEmailAddress
            // 
            this.layoutViewField_colAccountEmailAddress.EditorPreferredWidth = 204;
            this.layoutViewField_colAccountEmailAddress.Location = new System.Drawing.Point(831, 48);
            this.layoutViewField_colAccountEmailAddress.Name = "layoutViewField_colAccountEmailAddress";
            this.layoutViewField_colAccountEmailAddress.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colAccountEmailAddress.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colAccountEmailUsername
            // 
            this.colAccountEmailUsername.FieldName = "AccountEmailUsername";
            this.colAccountEmailUsername.LayoutViewField = this.layoutViewField_colAccountEmailUsername;
            this.colAccountEmailUsername.Name = "colAccountEmailUsername";
            // 
            // layoutViewField_colAccountEmailUsername
            // 
            this.layoutViewField_colAccountEmailUsername.EditorPreferredWidth = 204;
            this.layoutViewField_colAccountEmailUsername.Location = new System.Drawing.Point(0, 72);
            this.layoutViewField_colAccountEmailUsername.Name = "layoutViewField_colAccountEmailUsername";
            this.layoutViewField_colAccountEmailUsername.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colAccountEmailUsername.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colAccountEmailPassword
            // 
            this.colAccountEmailPassword.FieldName = "AccountEmailPassword";
            this.colAccountEmailPassword.LayoutViewField = this.layoutViewField_colAccountEmailPassword;
            this.colAccountEmailPassword.Name = "colAccountEmailPassword";
            // 
            // layoutViewField_colAccountEmailPassword
            // 
            this.layoutViewField_colAccountEmailPassword.EditorPreferredWidth = 202;
            this.layoutViewField_colAccountEmailPassword.Location = new System.Drawing.Point(417, 72);
            this.layoutViewField_colAccountEmailPassword.Name = "layoutViewField_colAccountEmailPassword";
            this.layoutViewField_colAccountEmailPassword.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colAccountEmailPassword.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colAccountEmailDomain
            // 
            this.colAccountEmailDomain.FieldName = "AccountEmailDomain";
            this.colAccountEmailDomain.LayoutViewField = this.layoutViewField_colAccountEmailDomain;
            this.colAccountEmailDomain.Name = "colAccountEmailDomain";
            // 
            // layoutViewField_colAccountEmailDomain
            // 
            this.layoutViewField_colAccountEmailDomain.EditorPreferredWidth = 204;
            this.layoutViewField_colAccountEmailDomain.Location = new System.Drawing.Point(831, 72);
            this.layoutViewField_colAccountEmailDomain.Name = "layoutViewField_colAccountEmailDomain";
            this.layoutViewField_colAccountEmailDomain.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colAccountEmailDomain.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colAccountEmailBCCAddress
            // 
            this.colAccountEmailBCCAddress.FieldName = "AccountEmailBCCAddress";
            this.colAccountEmailBCCAddress.LayoutViewField = this.layoutViewField_colAccountEmailBCCAddress;
            this.colAccountEmailBCCAddress.Name = "colAccountEmailBCCAddress";
            // 
            // layoutViewField_colAccountEmailBCCAddress
            // 
            this.layoutViewField_colAccountEmailBCCAddress.EditorPreferredWidth = 204;
            this.layoutViewField_colAccountEmailBCCAddress.Location = new System.Drawing.Point(0, 96);
            this.layoutViewField_colAccountEmailBCCAddress.Name = "layoutViewField_colAccountEmailBCCAddress";
            this.layoutViewField_colAccountEmailBCCAddress.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colAccountEmailBCCAddress.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDocumentEmailAddress
            // 
            this.colDocumentEmailAddress.FieldName = "DocumentEmailAddress";
            this.colDocumentEmailAddress.LayoutViewField = this.layoutViewField_colDocumentEmailAddress;
            this.colDocumentEmailAddress.Name = "colDocumentEmailAddress";
            // 
            // layoutViewField_colDocumentEmailAddress
            // 
            this.layoutViewField_colDocumentEmailAddress.EditorPreferredWidth = 202;
            this.layoutViewField_colDocumentEmailAddress.Location = new System.Drawing.Point(417, 96);
            this.layoutViewField_colDocumentEmailAddress.Name = "layoutViewField_colDocumentEmailAddress";
            this.layoutViewField_colDocumentEmailAddress.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colDocumentEmailAddress.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDocumentEmailUsername
            // 
            this.colDocumentEmailUsername.FieldName = "DocumentEmailUsername";
            this.colDocumentEmailUsername.LayoutViewField = this.layoutViewField_colDocumentEmailUsername;
            this.colDocumentEmailUsername.Name = "colDocumentEmailUsername";
            // 
            // layoutViewField_colDocumentEmailUsername
            // 
            this.layoutViewField_colDocumentEmailUsername.EditorPreferredWidth = 204;
            this.layoutViewField_colDocumentEmailUsername.Location = new System.Drawing.Point(831, 96);
            this.layoutViewField_colDocumentEmailUsername.Name = "layoutViewField_colDocumentEmailUsername";
            this.layoutViewField_colDocumentEmailUsername.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDocumentEmailUsername.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDocumentEmailPassword
            // 
            this.colDocumentEmailPassword.FieldName = "DocumentEmailPassword";
            this.colDocumentEmailPassword.LayoutViewField = this.layoutViewField_colDocumentEmailPassword;
            this.colDocumentEmailPassword.Name = "colDocumentEmailPassword";
            // 
            // layoutViewField_colDocumentEmailPassword
            // 
            this.layoutViewField_colDocumentEmailPassword.EditorPreferredWidth = 204;
            this.layoutViewField_colDocumentEmailPassword.Location = new System.Drawing.Point(0, 120);
            this.layoutViewField_colDocumentEmailPassword.Name = "layoutViewField_colDocumentEmailPassword";
            this.layoutViewField_colDocumentEmailPassword.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDocumentEmailPassword.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDocumentEmailDomain
            // 
            this.colDocumentEmailDomain.FieldName = "DocumentEmailDomain";
            this.colDocumentEmailDomain.LayoutViewField = this.layoutViewField_colDocumentEmailDomain;
            this.colDocumentEmailDomain.Name = "colDocumentEmailDomain";
            // 
            // layoutViewField_colDocumentEmailDomain
            // 
            this.layoutViewField_colDocumentEmailDomain.EditorPreferredWidth = 202;
            this.layoutViewField_colDocumentEmailDomain.Location = new System.Drawing.Point(417, 120);
            this.layoutViewField_colDocumentEmailDomain.Name = "layoutViewField_colDocumentEmailDomain";
            this.layoutViewField_colDocumentEmailDomain.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colDocumentEmailDomain.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDocumentEmailBCCAddress
            // 
            this.colDocumentEmailBCCAddress.FieldName = "DocumentEmailBCCAddress";
            this.colDocumentEmailBCCAddress.LayoutViewField = this.layoutViewField_colDocumentEmailBCCAddress;
            this.colDocumentEmailBCCAddress.Name = "colDocumentEmailBCCAddress";
            // 
            // layoutViewField_colDocumentEmailBCCAddress
            // 
            this.layoutViewField_colDocumentEmailBCCAddress.EditorPreferredWidth = 204;
            this.layoutViewField_colDocumentEmailBCCAddress.Location = new System.Drawing.Point(831, 120);
            this.layoutViewField_colDocumentEmailBCCAddress.Name = "layoutViewField_colDocumentEmailBCCAddress";
            this.layoutViewField_colDocumentEmailBCCAddress.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDocumentEmailBCCAddress.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colProxyServerLocation
            // 
            this.colProxyServerLocation.FieldName = "ProxyServerLocation";
            this.colProxyServerLocation.LayoutViewField = this.layoutViewField_colProxyServerLocation;
            this.colProxyServerLocation.Name = "colProxyServerLocation";
            // 
            // layoutViewField_colProxyServerLocation
            // 
            this.layoutViewField_colProxyServerLocation.EditorPreferredWidth = 204;
            this.layoutViewField_colProxyServerLocation.Location = new System.Drawing.Point(0, 144);
            this.layoutViewField_colProxyServerLocation.Name = "layoutViewField_colProxyServerLocation";
            this.layoutViewField_colProxyServerLocation.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colProxyServerLocation.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colProxyServerUsername
            // 
            this.colProxyServerUsername.FieldName = "ProxyServerUsername";
            this.colProxyServerUsername.LayoutViewField = this.layoutViewField_colProxyServerUsername;
            this.colProxyServerUsername.Name = "colProxyServerUsername";
            // 
            // layoutViewField_colProxyServerUsername
            // 
            this.layoutViewField_colProxyServerUsername.EditorPreferredWidth = 202;
            this.layoutViewField_colProxyServerUsername.Location = new System.Drawing.Point(417, 144);
            this.layoutViewField_colProxyServerUsername.Name = "layoutViewField_colProxyServerUsername";
            this.layoutViewField_colProxyServerUsername.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colProxyServerUsername.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colProxyServerPassword
            // 
            this.colProxyServerPassword.FieldName = "ProxyServerPassword";
            this.colProxyServerPassword.LayoutViewField = this.layoutViewField_colProxyServerPassword;
            this.colProxyServerPassword.Name = "colProxyServerPassword";
            // 
            // layoutViewField_colProxyServerPassword
            // 
            this.layoutViewField_colProxyServerPassword.EditorPreferredWidth = 204;
            this.layoutViewField_colProxyServerPassword.Location = new System.Drawing.Point(831, 144);
            this.layoutViewField_colProxyServerPassword.Name = "layoutViewField_colProxyServerPassword";
            this.layoutViewField_colProxyServerPassword.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colProxyServerPassword.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colPrintServerLocation
            // 
            this.colPrintServerLocation.FieldName = "PrintServerLocation";
            this.colPrintServerLocation.LayoutViewField = this.layoutViewField_colPrintServerLocation;
            this.colPrintServerLocation.Name = "colPrintServerLocation";
            // 
            // layoutViewField_colPrintServerLocation
            // 
            this.layoutViewField_colPrintServerLocation.EditorPreferredWidth = 204;
            this.layoutViewField_colPrintServerLocation.Location = new System.Drawing.Point(0, 168);
            this.layoutViewField_colPrintServerLocation.Name = "layoutViewField_colPrintServerLocation";
            this.layoutViewField_colPrintServerLocation.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colPrintServerLocation.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colBankName
            // 
            this.colBankName.FieldName = "BankName";
            this.colBankName.LayoutViewField = this.layoutViewField_colBankName;
            this.colBankName.Name = "colBankName";
            // 
            // layoutViewField_colBankName
            // 
            this.layoutViewField_colBankName.EditorPreferredWidth = 202;
            this.layoutViewField_colBankName.Location = new System.Drawing.Point(417, 168);
            this.layoutViewField_colBankName.Name = "layoutViewField_colBankName";
            this.layoutViewField_colBankName.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colBankName.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colBankBranch
            // 
            this.colBankBranch.FieldName = "BankBranch";
            this.colBankBranch.LayoutViewField = this.layoutViewField_colBankBranch;
            this.colBankBranch.Name = "colBankBranch";
            // 
            // layoutViewField_colBankBranch
            // 
            this.layoutViewField_colBankBranch.EditorPreferredWidth = 204;
            this.layoutViewField_colBankBranch.Location = new System.Drawing.Point(831, 168);
            this.layoutViewField_colBankBranch.Name = "layoutViewField_colBankBranch";
            this.layoutViewField_colBankBranch.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colBankBranch.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colBankCode
            // 
            this.colBankCode.FieldName = "BankCode";
            this.colBankCode.LayoutViewField = this.layoutViewField_colBankCode;
            this.colBankCode.Name = "colBankCode";
            // 
            // layoutViewField_colBankCode
            // 
            this.layoutViewField_colBankCode.EditorPreferredWidth = 204;
            this.layoutViewField_colBankCode.Location = new System.Drawing.Point(0, 192);
            this.layoutViewField_colBankCode.Name = "layoutViewField_colBankCode";
            this.layoutViewField_colBankCode.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colBankCode.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colBankAccountNumber
            // 
            this.colBankAccountNumber.FieldName = "BankAccountNumber";
            this.colBankAccountNumber.LayoutViewField = this.layoutViewField_colBankAccountNumber;
            this.colBankAccountNumber.Name = "colBankAccountNumber";
            // 
            // layoutViewField_colBankAccountNumber
            // 
            this.layoutViewField_colBankAccountNumber.EditorPreferredWidth = 202;
            this.layoutViewField_colBankAccountNumber.Location = new System.Drawing.Point(417, 192);
            this.layoutViewField_colBankAccountNumber.Name = "layoutViewField_colBankAccountNumber";
            this.layoutViewField_colBankAccountNumber.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colBankAccountNumber.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDefaultMessageDocument
            // 
            this.colDefaultMessageDocument.FieldName = "DefaultMessageDocument";
            this.colDefaultMessageDocument.LayoutViewField = this.layoutViewField_colDefaultMessageDocument;
            this.colDefaultMessageDocument.Name = "colDefaultMessageDocument";
            // 
            // layoutViewField_colDefaultMessageDocument
            // 
            this.layoutViewField_colDefaultMessageDocument.EditorPreferredWidth = 204;
            this.layoutViewField_colDefaultMessageDocument.Location = new System.Drawing.Point(831, 192);
            this.layoutViewField_colDefaultMessageDocument.Name = "layoutViewField_colDefaultMessageDocument";
            this.layoutViewField_colDefaultMessageDocument.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDefaultMessageDocument.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDefaultMessageStatement
            // 
            this.colDefaultMessageStatement.FieldName = "DefaultMessageStatement";
            this.colDefaultMessageStatement.LayoutViewField = this.layoutViewField_colDefaultMessageStatement;
            this.colDefaultMessageStatement.Name = "colDefaultMessageStatement";
            // 
            // layoutViewField_colDefaultMessageStatement
            // 
            this.layoutViewField_colDefaultMessageStatement.EditorPreferredWidth = 204;
            this.layoutViewField_colDefaultMessageStatement.Location = new System.Drawing.Point(0, 216);
            this.layoutViewField_colDefaultMessageStatement.Name = "layoutViewField_colDefaultMessageStatement";
            this.layoutViewField_colDefaultMessageStatement.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDefaultMessageStatement.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colPrinterBarcode
            // 
            this.colPrinterBarcode.FieldName = "PrinterBarcode";
            this.colPrinterBarcode.LayoutViewField = this.layoutViewField_colPrinterBarcode;
            this.colPrinterBarcode.Name = "colPrinterBarcode";
            // 
            // layoutViewField_colPrinterBarcode
            // 
            this.layoutViewField_colPrinterBarcode.EditorPreferredWidth = 202;
            this.layoutViewField_colPrinterBarcode.Location = new System.Drawing.Point(417, 216);
            this.layoutViewField_colPrinterBarcode.Name = "layoutViewField_colPrinterBarcode";
            this.layoutViewField_colPrinterBarcode.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colPrinterBarcode.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colPrinterPicker
            // 
            this.colPrinterPicker.FieldName = "PrinterPicker";
            this.colPrinterPicker.LayoutViewField = this.layoutViewField_colPrinterPicker;
            this.colPrinterPicker.Name = "colPrinterPicker";
            // 
            // layoutViewField_colPrinterPicker
            // 
            this.layoutViewField_colPrinterPicker.EditorPreferredWidth = 204;
            this.layoutViewField_colPrinterPicker.Location = new System.Drawing.Point(831, 216);
            this.layoutViewField_colPrinterPicker.Name = "layoutViewField_colPrinterPicker";
            this.layoutViewField_colPrinterPicker.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colPrinterPicker.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colPrinterReceipt
            // 
            this.colPrinterReceipt.FieldName = "PrinterReceipt";
            this.colPrinterReceipt.LayoutViewField = this.layoutViewField_colPrinterReceipt;
            this.colPrinterReceipt.Name = "colPrinterReceipt";
            // 
            // layoutViewField_colPrinterReceipt
            // 
            this.layoutViewField_colPrinterReceipt.EditorPreferredWidth = 204;
            this.layoutViewField_colPrinterReceipt.Location = new System.Drawing.Point(0, 240);
            this.layoutViewField_colPrinterReceipt.Name = "layoutViewField_colPrinterReceipt";
            this.layoutViewField_colPrinterReceipt.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colPrinterReceipt.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colUpdateURL
            // 
            this.colUpdateURL.FieldName = "UpdateURL";
            this.colUpdateURL.LayoutViewField = this.layoutViewField_colUpdateURL;
            this.colUpdateURL.Name = "colUpdateURL";
            // 
            // layoutViewField_colUpdateURL
            // 
            this.layoutViewField_colUpdateURL.EditorPreferredWidth = 202;
            this.layoutViewField_colUpdateURL.Location = new System.Drawing.Point(417, 240);
            this.layoutViewField_colUpdateURL.Name = "layoutViewField_colUpdateURL";
            this.layoutViewField_colUpdateURL.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colUpdateURL.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colMinimizeNavigation
            // 
            this.colMinimizeNavigation.FieldName = "MinimizeNavigation";
            this.colMinimizeNavigation.LayoutViewField = this.layoutViewField_colMinimizeNavigation;
            this.colMinimizeNavigation.Name = "colMinimizeNavigation";
            // 
            // layoutViewField_colMinimizeNavigation
            // 
            this.layoutViewField_colMinimizeNavigation.EditorPreferredWidth = 204;
            this.layoutViewField_colMinimizeNavigation.Location = new System.Drawing.Point(831, 240);
            this.layoutViewField_colMinimizeNavigation.Name = "layoutViewField_colMinimizeNavigation";
            this.layoutViewField_colMinimizeNavigation.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colMinimizeNavigation.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colUpdateCheckTime
            // 
            this.colUpdateCheckTime.FieldName = "UpdateCheckTime";
            this.colUpdateCheckTime.LayoutViewField = this.layoutViewField_colUpdateCheckTime;
            this.colUpdateCheckTime.Name = "colUpdateCheckTime";
            // 
            // layoutViewField_colUpdateCheckTime
            // 
            this.layoutViewField_colUpdateCheckTime.EditorPreferredWidth = 204;
            this.layoutViewField_colUpdateCheckTime.Location = new System.Drawing.Point(0, 264);
            this.layoutViewField_colUpdateCheckTime.Name = "layoutViewField_colUpdateCheckTime";
            this.layoutViewField_colUpdateCheckTime.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colUpdateCheckTime.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colPaymentAccounts
            // 
            this.colPaymentAccounts.FieldName = "PaymentAccounts";
            this.colPaymentAccounts.LayoutViewField = this.layoutViewField_colPaymentAccounts;
            this.colPaymentAccounts.Name = "colPaymentAccounts";
            // 
            // layoutViewField_colPaymentAccounts
            // 
            this.layoutViewField_colPaymentAccounts.EditorPreferredWidth = 202;
            this.layoutViewField_colPaymentAccounts.Location = new System.Drawing.Point(417, 264);
            this.layoutViewField_colPaymentAccounts.Name = "layoutViewField_colPaymentAccounts";
            this.layoutViewField_colPaymentAccounts.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colPaymentAccounts.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colUseBarcodes
            // 
            this.colUseBarcodes.FieldName = "UseBarcodes";
            this.colUseBarcodes.LayoutViewField = this.layoutViewField_colUseBarcodes;
            this.colUseBarcodes.Name = "colUseBarcodes";
            // 
            // layoutViewField_colUseBarcodes
            // 
            this.layoutViewField_colUseBarcodes.EditorPreferredWidth = 204;
            this.layoutViewField_colUseBarcodes.Location = new System.Drawing.Point(831, 264);
            this.layoutViewField_colUseBarcodes.Name = "layoutViewField_colUseBarcodes";
            this.layoutViewField_colUseBarcodes.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colUseBarcodes.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colUseLabels
            // 
            this.colUseLabels.FieldName = "UseLabels";
            this.colUseLabels.LayoutViewField = this.layoutViewField_colUseLabels;
            this.colUseLabels.Name = "colUseLabels";
            // 
            // layoutViewField_colUseLabels
            // 
            this.layoutViewField_colUseLabels.EditorPreferredWidth = 204;
            this.layoutViewField_colUseLabels.Location = new System.Drawing.Point(0, 288);
            this.layoutViewField_colUseLabels.Name = "layoutViewField_colUseLabels";
            this.layoutViewField_colUseLabels.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colUseLabels.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colCopyInvoiceOrderNumbertoCreditNote
            // 
            this.colCopyInvoiceOrderNumbertoCreditNote.FieldName = "CopyInvoiceOrderNumbertoCreditNote";
            this.colCopyInvoiceOrderNumbertoCreditNote.LayoutViewField = this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote;
            this.colCopyInvoiceOrderNumbertoCreditNote.Name = "colCopyInvoiceOrderNumbertoCreditNote";
            // 
            // layoutViewField_colCopyInvoiceOrderNumbertoCreditNote
            // 
            this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote.EditorPreferredWidth = 202;
            this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote.Location = new System.Drawing.Point(417, 288);
            this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote.Name = "layoutViewField_colCopyInvoiceOrderNumbertoCreditNote";
            this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colAutoWriteoffOpenItemCredits
            // 
            this.colAutoWriteoffOpenItemCredits.FieldName = "AutoWriteoffOpenItemCredits";
            this.colAutoWriteoffOpenItemCredits.LayoutViewField = this.layoutViewField_colAutoWriteoffOpenItemCredits;
            this.colAutoWriteoffOpenItemCredits.Name = "colAutoWriteoffOpenItemCredits";
            // 
            // layoutViewField_colAutoWriteoffOpenItemCredits
            // 
            this.layoutViewField_colAutoWriteoffOpenItemCredits.EditorPreferredWidth = 204;
            this.layoutViewField_colAutoWriteoffOpenItemCredits.Location = new System.Drawing.Point(831, 288);
            this.layoutViewField_colAutoWriteoffOpenItemCredits.Name = "layoutViewField_colAutoWriteoffOpenItemCredits";
            this.layoutViewField_colAutoWriteoffOpenItemCredits.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colAutoWriteoffOpenItemCredits.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colNegativeDiscountEffects
            // 
            this.colNegativeDiscountEffects.FieldName = "NegativeDiscountEffects";
            this.colNegativeDiscountEffects.LayoutViewField = this.layoutViewField_colNegativeDiscountEffects;
            this.colNegativeDiscountEffects.Name = "colNegativeDiscountEffects";
            // 
            // layoutViewField_colNegativeDiscountEffects
            // 
            this.layoutViewField_colNegativeDiscountEffects.EditorPreferredWidth = 204;
            this.layoutViewField_colNegativeDiscountEffects.Location = new System.Drawing.Point(0, 312);
            this.layoutViewField_colNegativeDiscountEffects.Name = "layoutViewField_colNegativeDiscountEffects";
            this.layoutViewField_colNegativeDiscountEffects.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colNegativeDiscountEffects.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colNotifyonZeroMarkupSale
            // 
            this.colNotifyonZeroMarkupSale.FieldName = "NotifyonZeroMarkupSale";
            this.colNotifyonZeroMarkupSale.LayoutViewField = this.layoutViewField_colNotifyonZeroMarkupSale;
            this.colNotifyonZeroMarkupSale.Name = "colNotifyonZeroMarkupSale";
            // 
            // layoutViewField_colNotifyonZeroMarkupSale
            // 
            this.layoutViewField_colNotifyonZeroMarkupSale.EditorPreferredWidth = 202;
            this.layoutViewField_colNotifyonZeroMarkupSale.Location = new System.Drawing.Point(417, 312);
            this.layoutViewField_colNotifyonZeroMarkupSale.Name = "layoutViewField_colNotifyonZeroMarkupSale";
            this.layoutViewField_colNotifyonZeroMarkupSale.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colNotifyonZeroMarkupSale.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colNotifyonZeroProfitSale
            // 
            this.colNotifyonZeroProfitSale.FieldName = "NotifyonZeroProfitSale";
            this.colNotifyonZeroProfitSale.LayoutViewField = this.layoutViewField_colNotifyonZeroProfitSale;
            this.colNotifyonZeroProfitSale.Name = "colNotifyonZeroProfitSale";
            // 
            // layoutViewField_colNotifyonZeroProfitSale
            // 
            this.layoutViewField_colNotifyonZeroProfitSale.EditorPreferredWidth = 204;
            this.layoutViewField_colNotifyonZeroProfitSale.Location = new System.Drawing.Point(831, 312);
            this.layoutViewField_colNotifyonZeroProfitSale.Name = "layoutViewField_colNotifyonZeroProfitSale";
            this.layoutViewField_colNotifyonZeroProfitSale.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colNotifyonZeroProfitSale.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colQuoteValidDays
            // 
            this.colQuoteValidDays.FieldName = "QuoteValidDays";
            this.colQuoteValidDays.LayoutViewField = this.layoutViewField_colQuoteValidDays;
            this.colQuoteValidDays.Name = "colQuoteValidDays";
            // 
            // layoutViewField_colQuoteValidDays
            // 
            this.layoutViewField_colQuoteValidDays.EditorPreferredWidth = 204;
            this.layoutViewField_colQuoteValidDays.Location = new System.Drawing.Point(0, 336);
            this.layoutViewField_colQuoteValidDays.Name = "layoutViewField_colQuoteValidDays";
            this.layoutViewField_colQuoteValidDays.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colQuoteValidDays.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colQuoteValidMax
            // 
            this.colQuoteValidMax.FieldName = "QuoteValidMax";
            this.colQuoteValidMax.LayoutViewField = this.layoutViewField_colQuoteValidMax;
            this.colQuoteValidMax.Name = "colQuoteValidMax";
            // 
            // layoutViewField_colQuoteValidMax
            // 
            this.layoutViewField_colQuoteValidMax.EditorPreferredWidth = 202;
            this.layoutViewField_colQuoteValidMax.Location = new System.Drawing.Point(417, 336);
            this.layoutViewField_colQuoteValidMax.Name = "layoutViewField_colQuoteValidMax";
            this.layoutViewField_colQuoteValidMax.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colQuoteValidMax.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colRoundingAmount
            // 
            this.colRoundingAmount.FieldName = "RoundingAmount";
            this.colRoundingAmount.LayoutViewField = this.layoutViewField_colRoundingAmount;
            this.colRoundingAmount.Name = "colRoundingAmount";
            // 
            // layoutViewField_colRoundingAmount
            // 
            this.layoutViewField_colRoundingAmount.EditorPreferredWidth = 204;
            this.layoutViewField_colRoundingAmount.Location = new System.Drawing.Point(831, 336);
            this.layoutViewField_colRoundingAmount.Name = "layoutViewField_colRoundingAmount";
            this.layoutViewField_colRoundingAmount.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colRoundingAmount.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colCashierPaymentsFullAmount
            // 
            this.colCashierPaymentsFullAmount.FieldName = "CashierPaymentsFullAmount";
            this.colCashierPaymentsFullAmount.LayoutViewField = this.layoutViewField_colCashierPaymentsFullAmount;
            this.colCashierPaymentsFullAmount.Name = "colCashierPaymentsFullAmount";
            // 
            // layoutViewField_colCashierPaymentsFullAmount
            // 
            this.layoutViewField_colCashierPaymentsFullAmount.EditorPreferredWidth = 204;
            this.layoutViewField_colCashierPaymentsFullAmount.Location = new System.Drawing.Point(0, 360);
            this.layoutViewField_colCashierPaymentsFullAmount.Name = "layoutViewField_colCashierPaymentsFullAmount";
            this.layoutViewField_colCashierPaymentsFullAmount.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colCashierPaymentsFullAmount.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colCODAccountLimit
            // 
            this.colCODAccountLimit.FieldName = "CODAccountLimit";
            this.colCODAccountLimit.LayoutViewField = this.layoutViewField_colCODAccountLimit;
            this.colCODAccountLimit.Name = "colCODAccountLimit";
            // 
            // layoutViewField_colCODAccountLimit
            // 
            this.layoutViewField_colCODAccountLimit.EditorPreferredWidth = 202;
            this.layoutViewField_colCODAccountLimit.Location = new System.Drawing.Point(417, 360);
            this.layoutViewField_colCODAccountLimit.Name = "layoutViewField_colCODAccountLimit";
            this.layoutViewField_colCODAccountLimit.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colCODAccountLimit.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDebtorGracePeriod
            // 
            this.colDebtorGracePeriod.FieldName = "DebtorGracePeriod";
            this.colDebtorGracePeriod.LayoutViewField = this.layoutViewField_colDebtorGracePeriod;
            this.colDebtorGracePeriod.Name = "colDebtorGracePeriod";
            // 
            // layoutViewField_colDebtorGracePeriod
            // 
            this.layoutViewField_colDebtorGracePeriod.EditorPreferredWidth = 204;
            this.layoutViewField_colDebtorGracePeriod.Location = new System.Drawing.Point(831, 360);
            this.layoutViewField_colDebtorGracePeriod.Name = "layoutViewField_colDebtorGracePeriod";
            this.layoutViewField_colDebtorGracePeriod.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDebtorGracePeriod.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDefaultInterestCharged
            // 
            this.colDefaultInterestCharged.FieldName = "DefaultInterestCharged";
            this.colDefaultInterestCharged.LayoutViewField = this.layoutViewField_colDefaultInterestCharged;
            this.colDefaultInterestCharged.Name = "colDefaultInterestCharged";
            // 
            // layoutViewField_colDefaultInterestCharged
            // 
            this.layoutViewField_colDefaultInterestCharged.EditorPreferredWidth = 204;
            this.layoutViewField_colDefaultInterestCharged.Location = new System.Drawing.Point(0, 384);
            this.layoutViewField_colDefaultInterestCharged.Name = "layoutViewField_colDefaultInterestCharged";
            this.layoutViewField_colDefaultInterestCharged.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDefaultInterestCharged.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colMonthWeight3
            // 
            this.colMonthWeight3.FieldName = "MonthWeight3";
            this.colMonthWeight3.LayoutViewField = this.layoutViewField_colMonthWeight3;
            this.colMonthWeight3.Name = "colMonthWeight3";
            // 
            // layoutViewField_colMonthWeight3
            // 
            this.layoutViewField_colMonthWeight3.EditorPreferredWidth = 202;
            this.layoutViewField_colMonthWeight3.Location = new System.Drawing.Point(417, 384);
            this.layoutViewField_colMonthWeight3.Name = "layoutViewField_colMonthWeight3";
            this.layoutViewField_colMonthWeight3.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colMonthWeight3.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colMonthWeight6
            // 
            this.colMonthWeight6.FieldName = "MonthWeight6";
            this.colMonthWeight6.LayoutViewField = this.layoutViewField_colMonthWeight6;
            this.colMonthWeight6.Name = "colMonthWeight6";
            // 
            // layoutViewField_colMonthWeight6
            // 
            this.layoutViewField_colMonthWeight6.EditorPreferredWidth = 204;
            this.layoutViewField_colMonthWeight6.Location = new System.Drawing.Point(831, 384);
            this.layoutViewField_colMonthWeight6.Name = "layoutViewField_colMonthWeight6";
            this.layoutViewField_colMonthWeight6.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colMonthWeight6.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colMonthWeight12
            // 
            this.colMonthWeight12.FieldName = "MonthWeight12";
            this.colMonthWeight12.LayoutViewField = this.layoutViewField_colMonthWeight12;
            this.colMonthWeight12.Name = "colMonthWeight12";
            // 
            // layoutViewField_colMonthWeight12
            // 
            this.layoutViewField_colMonthWeight12.EditorPreferredWidth = 204;
            this.layoutViewField_colMonthWeight12.Location = new System.Drawing.Point(0, 408);
            this.layoutViewField_colMonthWeight12.Name = "layoutViewField_colMonthWeight12";
            this.layoutViewField_colMonthWeight12.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colMonthWeight12.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colMonthWeight24
            // 
            this.colMonthWeight24.FieldName = "MonthWeight24";
            this.colMonthWeight24.LayoutViewField = this.layoutViewField_colMonthWeight24;
            this.colMonthWeight24.Name = "colMonthWeight24";
            // 
            // layoutViewField_colMonthWeight24
            // 
            this.layoutViewField_colMonthWeight24.EditorPreferredWidth = 202;
            this.layoutViewField_colMonthWeight24.Location = new System.Drawing.Point(417, 408);
            this.layoutViewField_colMonthWeight24.Name = "layoutViewField_colMonthWeight24";
            this.layoutViewField_colMonthWeight24.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colMonthWeight24.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colMonthWeight36
            // 
            this.colMonthWeight36.FieldName = "MonthWeight36";
            this.colMonthWeight36.LayoutViewField = this.layoutViewField_colMonthWeight36;
            this.colMonthWeight36.Name = "colMonthWeight36";
            // 
            // layoutViewField_colMonthWeight36
            // 
            this.layoutViewField_colMonthWeight36.EditorPreferredWidth = 204;
            this.layoutViewField_colMonthWeight36.Location = new System.Drawing.Point(831, 408);
            this.layoutViewField_colMonthWeight36.Name = "layoutViewField_colMonthWeight36";
            this.layoutViewField_colMonthWeight36.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colMonthWeight36.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colFixedOrderCost
            // 
            this.colFixedOrderCost.FieldName = "FixedOrderCost";
            this.colFixedOrderCost.LayoutViewField = this.layoutViewField_colFixedOrderCost;
            this.colFixedOrderCost.Name = "colFixedOrderCost";
            // 
            // layoutViewField_colFixedOrderCost
            // 
            this.layoutViewField_colFixedOrderCost.EditorPreferredWidth = 204;
            this.layoutViewField_colFixedOrderCost.Location = new System.Drawing.Point(0, 432);
            this.layoutViewField_colFixedOrderCost.Name = "layoutViewField_colFixedOrderCost";
            this.layoutViewField_colFixedOrderCost.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colFixedOrderCost.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colMaxOrderLines
            // 
            this.colMaxOrderLines.FieldName = "MaxOrderLines";
            this.colMaxOrderLines.LayoutViewField = this.layoutViewField_colMaxOrderLines;
            this.colMaxOrderLines.Name = "colMaxOrderLines";
            // 
            // layoutViewField_colMaxOrderLines
            // 
            this.layoutViewField_colMaxOrderLines.EditorPreferredWidth = 202;
            this.layoutViewField_colMaxOrderLines.Location = new System.Drawing.Point(417, 432);
            this.layoutViewField_colMaxOrderLines.Name = "layoutViewField_colMaxOrderLines";
            this.layoutViewField_colMaxOrderLines.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colMaxOrderLines.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colSafetyStockPeriod
            // 
            this.colSafetyStockPeriod.FieldName = "SafetyStockPeriod";
            this.colSafetyStockPeriod.LayoutViewField = this.layoutViewField_colSafetyStockPeriod;
            this.colSafetyStockPeriod.Name = "colSafetyStockPeriod";
            // 
            // layoutViewField_colSafetyStockPeriod
            // 
            this.layoutViewField_colSafetyStockPeriod.EditorPreferredWidth = 204;
            this.layoutViewField_colSafetyStockPeriod.Location = new System.Drawing.Point(831, 432);
            this.layoutViewField_colSafetyStockPeriod.Name = "layoutViewField_colSafetyStockPeriod";
            this.layoutViewField_colSafetyStockPeriod.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colSafetyStockPeriod.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colDistributionNumber
            // 
            this.colDistributionNumber.FieldName = "DistributionNumber";
            this.colDistributionNumber.LayoutViewField = this.layoutViewField_colDistributionNumber;
            this.colDistributionNumber.Name = "colDistributionNumber";
            // 
            // layoutViewField_colDistributionNumber
            // 
            this.layoutViewField_colDistributionNumber.EditorPreferredWidth = 204;
            this.layoutViewField_colDistributionNumber.Location = new System.Drawing.Point(0, 456);
            this.layoutViewField_colDistributionNumber.Name = "layoutViewField_colDistributionNumber";
            this.layoutViewField_colDistributionNumber.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colDistributionNumber.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colBackupLocation
            // 
            this.colBackupLocation.FieldName = "BackupLocation";
            this.colBackupLocation.LayoutViewField = this.layoutViewField_colBackupLocation;
            this.colBackupLocation.Name = "colBackupLocation";
            // 
            // layoutViewField_colBackupLocation
            // 
            this.layoutViewField_colBackupLocation.EditorPreferredWidth = 202;
            this.layoutViewField_colBackupLocation.Location = new System.Drawing.Point(417, 456);
            this.layoutViewField_colBackupLocation.Name = "layoutViewField_colBackupLocation";
            this.layoutViewField_colBackupLocation.Size = new System.Drawing.Size(414, 24);
            this.layoutViewField_colBackupLocation.TextSize = new System.Drawing.Size(242, 16);
            // 
            // colNotifyonBackOrder
            // 
            this.colNotifyonBackOrder.FieldName = "NotifyonBackOrder";
            this.colNotifyonBackOrder.LayoutViewField = this.layoutViewField_colNotifyonBackOrder;
            this.colNotifyonBackOrder.Name = "colNotifyonBackOrder";
            // 
            // layoutViewField_colNotifyonBackOrder
            // 
            this.layoutViewField_colNotifyonBackOrder.EditorPreferredWidth = 204;
            this.layoutViewField_colNotifyonBackOrder.Location = new System.Drawing.Point(831, 456);
            this.layoutViewField_colNotifyonBackOrder.Name = "layoutViewField_colNotifyonBackOrder";
            this.layoutViewField_colNotifyonBackOrder.Size = new System.Drawing.Size(417, 24);
            this.layoutViewField_colNotifyonBackOrder.TextSize = new System.Drawing.Size(242, 16);
            // 
            // grdEntity
            // 
            this.grdEntity.DataSource = this.BindingSourceEntity;
            this.grdEntity.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridLevelNode1.LevelTemplate = this.lvSite;
            gridLevelNode1.RelationName = "Site";
            gridLevelNode2.LevelTemplate = this.grvAddress;
            gridLevelNode2.RelationName = "Addresses";
            this.grdEntity.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.grdEntity.Location = new System.Drawing.Point(2, 80);
            this.grdEntity.MainView = this.grvEntity;
            this.grdEntity.Name = "grdEntity";
            this.grdEntity.Size = new System.Drawing.Size(879, 436);
            this.grdEntity.TabIndex = 8;
            this.grdEntity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAddress,
            this.grvEntity,
            this.lvSite});
            // 
            // BindingSourceEntity
            // 
            this.BindingSourceEntity.DataSource = typeof(CDS.Server.Installer.Entities.SYS_Entity);
            // 
            // grvAddress
            // 
            this.grvAddress.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle1,
            this.colLine1,
            this.colLine2,
            this.colLine3,
            this.colLine4,
            this.colCode});
            this.grvAddress.GridControl = this.grdEntity;
            this.grvAddress.Name = "grvAddress";
            this.grvAddress.OptionsView.ShowGroupPanel = false;
            // 
            // colTitle1
            // 
            this.colTitle1.FieldName = "Title";
            this.colTitle1.Name = "colTitle1";
            this.colTitle1.OptionsColumn.AllowEdit = false;
            this.colTitle1.OptionsColumn.AllowFocus = false;
            this.colTitle1.Visible = true;
            this.colTitle1.VisibleIndex = 0;
            // 
            // colLine1
            // 
            this.colLine1.FieldName = "Line1";
            this.colLine1.Name = "colLine1";
            this.colLine1.Visible = true;
            this.colLine1.VisibleIndex = 1;
            // 
            // colLine2
            // 
            this.colLine2.FieldName = "Line2";
            this.colLine2.Name = "colLine2";
            this.colLine2.Visible = true;
            this.colLine2.VisibleIndex = 2;
            // 
            // colLine3
            // 
            this.colLine3.FieldName = "Line3";
            this.colLine3.Name = "colLine3";
            this.colLine3.Visible = true;
            this.colLine3.VisibleIndex = 3;
            // 
            // colLine4
            // 
            this.colLine4.FieldName = "Line4";
            this.colLine4.Name = "colLine4";
            this.colLine4.Visible = true;
            this.colLine4.VisibleIndex = 4;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 5;
            // 
            // grvEntity
            // 
            this.grvEntity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeMain,
            this.colCodeSub,
            this.colShortName,
            this.colName,
            this.colDescription,
            this.colArchived,
            this.colCreatedBy,
            this.colCreatedOn,
            this.colTitle});
            this.grvEntity.GridControl = this.grdEntity;
            this.grvEntity.Name = "grvEntity";
            this.grvEntity.OptionsView.ShowGroupPanel = false;
            this.grvEntity.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvSite_InitNewRow);
            // 
            // colCodeMain
            // 
            this.colCodeMain.FieldName = "CodeMain";
            this.colCodeMain.Name = "colCodeMain";
            this.colCodeMain.Visible = true;
            this.colCodeMain.VisibleIndex = 0;
            // 
            // colCodeSub
            // 
            this.colCodeSub.FieldName = "CodeSub";
            this.colCodeSub.Name = "colCodeSub";
            this.colCodeSub.Visible = true;
            this.colCodeSub.VisibleIndex = 1;
            // 
            // colShortName
            // 
            this.colShortName.FieldName = "ShortName";
            this.colShortName.Name = "colShortName";
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 2;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            // 
            // colArchived
            // 
            this.colArchived.FieldName = "Archived";
            this.colArchived.Name = "colArchived";
            this.colArchived.Visible = true;
            this.colArchived.VisibleIndex = 5;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 6;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.FieldName = "CreatedOn";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.Visible = true;
            this.colCreatedOn.VisibleIndex = 7;
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 8;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colTelephone,
            this.layoutViewField_colEmailAddress,
            this.layoutViewField_colRegistrationNumber,
            this.layoutViewField_colVatPercentage,
            this.layoutViewField_colVatNumber,
            this.layoutViewField_colCurrency,
            this.layoutViewField_colCashierRefreshIntervals,
            this.layoutViewField_colSMTPServerLocation,
            this.layoutViewField_colAccountEmailAddress,
            this.layoutViewField_colAccountEmailUsername,
            this.layoutViewField_colAccountEmailPassword,
            this.layoutViewField_colAccountEmailDomain,
            this.layoutViewField_colAccountEmailBCCAddress,
            this.layoutViewField_colDocumentEmailAddress,
            this.layoutViewField_colDocumentEmailUsername,
            this.layoutViewField_colDocumentEmailPassword,
            this.layoutViewField_colDocumentEmailDomain,
            this.layoutViewField_colDocumentEmailBCCAddress,
            this.layoutViewField_colProxyServerLocation,
            this.layoutViewField_colProxyServerUsername,
            this.layoutViewField_colProxyServerPassword,
            this.layoutViewField_colPrintServerLocation,
            this.layoutViewField_colBankName,
            this.layoutViewField_colBankBranch,
            this.layoutViewField_colBankCode,
            this.layoutViewField_colBankAccountNumber,
            this.layoutViewField_colDefaultMessageDocument,
            this.layoutViewField_colDefaultMessageStatement,
            this.layoutViewField_colPrinterBarcode,
            this.layoutViewField_colPrinterPicker,
            this.layoutViewField_colPrinterReceipt,
            this.layoutViewField_colUpdateURL,
            this.layoutViewField_colMinimizeNavigation,
            this.layoutViewField_colUpdateCheckTime,
            this.layoutViewField_colPaymentAccounts,
            this.layoutViewField_colUseBarcodes,
            this.layoutViewField_colUseLabels,
            this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote,
            this.layoutViewField_colAutoWriteoffOpenItemCredits,
            this.layoutViewField_colNegativeDiscountEffects,
            this.layoutViewField_colNotifyonZeroMarkupSale,
            this.layoutViewField_colNotifyonZeroProfitSale,
            this.layoutViewField_colQuoteValidDays,
            this.layoutViewField_colQuoteValidMax,
            this.layoutViewField_colRoundingAmount,
            this.layoutViewField_colCashierPaymentsFullAmount,
            this.layoutViewField_colCODAccountLimit,
            this.layoutViewField_colDebtorGracePeriod,
            this.layoutViewField_colDefaultInterestCharged,
            this.layoutViewField_colMonthWeight3,
            this.layoutViewField_colMonthWeight6,
            this.layoutViewField_colMonthWeight12,
            this.layoutViewField_colMonthWeight24,
            this.layoutViewField_colMonthWeight36,
            this.layoutViewField_colFixedOrderCost,
            this.layoutViewField_colMaxOrderLines,
            this.layoutViewField_colSafetyStockPeriod,
            this.layoutViewField_colDistributionNumber,
            this.layoutViewField_colBackupLocation,
            this.layoutViewField_colNotifyonBackOrder,
            this.item1});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // item1
            // 
            this.item1.AllowHotTrack = false;
            this.item1.CustomizationFormText = "item1";
            this.item1.Location = new System.Drawing.Point(0, 480);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(1248, 231);
            this.item1.Text = "item1";
            this.item1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // grvUser
            // 
            this.grvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImportUsername,
            this.colImportPassword,
            this.colImportDisplayName,
            this.colDiscountLimit});
            this.grvUser.GridControl = this.grdPerson;
            this.grvUser.Name = "grvUser";
            this.grvUser.OptionsView.ShowGroupPanel = false;
            // 
            // colImportUsername
            // 
            this.colImportUsername.FieldName = "Username";
            this.colImportUsername.Name = "colImportUsername";
            this.colImportUsername.Visible = true;
            this.colImportUsername.VisibleIndex = 0;
            // 
            // colImportPassword
            // 
            this.colImportPassword.FieldName = "Password";
            this.colImportPassword.Name = "colImportPassword";
            // 
            // colImportDisplayName
            // 
            this.colImportDisplayName.FieldName = "DisplayName";
            this.colImportDisplayName.Name = "colImportDisplayName";
            this.colImportDisplayName.Visible = true;
            this.colImportDisplayName.VisibleIndex = 1;
            // 
            // colDiscountLimit
            // 
            this.colDiscountLimit.FieldName = "DiscountLimit";
            this.colDiscountLimit.Name = "colDiscountLimit";
            this.colDiscountLimit.Visible = true;
            this.colDiscountLimit.VisibleIndex = 2;
            // 
            // grdPerson
            // 
            this.grdPerson.DataSource = this.BindingSourcePerson;
            this.grdPerson.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridLevelNode3.LevelTemplate = this.grvUser;
            gridLevelNode3.RelationName = "User";
            this.grdPerson.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.grdPerson.Location = new System.Drawing.Point(2, 2);
            this.grdPerson.MainView = this.grvPerson;
            this.grdPerson.Name = "grdPerson";
            this.grdPerson.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ddlRole});
            this.grdPerson.Size = new System.Drawing.Size(879, 514);
            this.grdPerson.TabIndex = 4;
            this.grdPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPerson,
            this.lvUser,
            this.grvUser});
            // 
            // BindingSourcePerson
            // 
            this.BindingSourcePerson.DataSource = typeof(CDS.Server.Installer.Entities.SYS_Person);
            // 
            // grvPerson
            // 
            this.grvPerson.ChildGridLevelName = "Person";
            this.grvPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImportName,
            this.colImportSurname,
            this.colImportArchived,
            this.colRole});
            this.grvPerson.GridControl = this.grdPerson;
            this.grvPerson.Name = "grvPerson";
            this.grvPerson.OptionsView.ShowGroupPanel = false;
            // 
            // colImportName
            // 
            this.colImportName.FieldName = "Name";
            this.colImportName.Name = "colImportName";
            this.colImportName.Visible = true;
            this.colImportName.VisibleIndex = 0;
            // 
            // colImportSurname
            // 
            this.colImportSurname.FieldName = "Surname";
            this.colImportSurname.Name = "colImportSurname";
            this.colImportSurname.Visible = true;
            this.colImportSurname.VisibleIndex = 1;
            // 
            // colImportArchived
            // 
            this.colImportArchived.FieldName = "Archived";
            this.colImportArchived.Name = "colImportArchived";
            this.colImportArchived.Visible = true;
            this.colImportArchived.VisibleIndex = 2;
            // 
            // colRole
            // 
            this.colRole.ColumnEdit = this.ddlRole;
            this.colRole.FieldName = "Role";
            this.colRole.Name = "colRole";
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 3;
            // 
            // ddlRole
            // 
            this.ddlRole.AutoHeight = false;
            this.ddlRole.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlRole.DataSource = this.ServerModeSourceRoles;
            this.ddlRole.DisplayMember = "Name";
            this.ddlRole.Name = "ddlRole";
            this.ddlRole.NullText = "Select Role...";
            this.ddlRole.ValueMember = "Id";
            this.ddlRole.View = this.ddlRoleView;
            // 
            // ServerModeSourceRoles
            // 
            this.ServerModeSourceRoles.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SEC_Role);
            this.ServerModeSourceRoles.KeyExpression = "Id";
            // 
            // ddlRoleView
            // 
            this.ddlRoleView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRoleCode,
            this.colRoleName});
            this.ddlRoleView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ddlRoleView.Name = "ddlRoleView";
            this.ddlRoleView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ddlRoleView.OptionsView.ShowGroupPanel = false;
            // 
            // colRoleCode
            // 
            this.colRoleCode.Caption = "Code";
            this.colRoleCode.FieldName = "Code";
            this.colRoleCode.Name = "colRoleCode";
            this.colRoleCode.Visible = true;
            this.colRoleCode.VisibleIndex = 0;
            // 
            // colRoleName
            // 
            this.colRoleName.Caption = "Name";
            this.colRoleName.FieldName = "Name";
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.Visible = true;
            this.colRoleName.VisibleIndex = 1;
            // 
            // lvUser
            // 
            this.lvUser.GridControl = this.grdPerson;
            this.lvUser.Name = "lvUser";
            this.lvUser.TemplateCard = null;
            // 
            // wcInstaller
            // 
            this.wcInstaller.Controls.Add(this.wpWelcome);
            this.wcInstaller.Controls.Add(this.wpConnection);
            this.wcInstaller.Controls.Add(this.wpComplete);
            this.wcInstaller.Controls.Add(this.wpSiteSetup);
            this.wcInstaller.Controls.Add(this.wpSqlSetupOption);
            this.wcInstaller.Controls.Add(this.wpSqlInstall);
            this.wcInstaller.Controls.Add(this.wpDataDirectories);
            this.wcInstaller.Controls.Add(this.wpNewOrImport);
            this.wcInstaller.Controls.Add(this.wpImportConnection);
            this.wcInstaller.Controls.Add(this.wpSetupUsers);
            this.wcInstaller.Controls.Add(this.wpImportOldData);
            this.wcInstaller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcInstaller.Location = new System.Drawing.Point(0, 0);
            this.wcInstaller.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wcInstaller.MinimumSize = new System.Drawing.Size(117, 123);
            this.wcInstaller.Name = "wcInstaller";
            this.wcInstaller.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wpWelcome,
            this.wpSqlSetupOption,
            this.wpSqlInstall,
            this.wpConnection,
            this.wpDataDirectories,
            this.wpNewOrImport,
            this.wpImportConnection,
            this.wpSiteSetup,
            this.wpSetupUsers,
            this.wpImportOldData,
            this.wpComplete});
            this.wcInstaller.Size = new System.Drawing.Size(915, 690);
            this.wcInstaller.UseAcceptButton = false;
            this.wcInstaller.UseCancelButton = false;
            this.wcInstaller.SelectedPageChanged += new DevExpress.XtraWizard.WizardPageChangedEventHandler(this.wcInstaller_SelectedPageChanged);
            this.wcInstaller.SelectedPageChanging += new DevExpress.XtraWizard.WizardPageChangingEventHandler(this.wcInstaller_SelectedPageChanging);
            this.wcInstaller.CancelClick += new System.ComponentModel.CancelEventHandler(this.wcInstaller_CancelClick);
            this.wcInstaller.FinishClick += new System.ComponentModel.CancelEventHandler(this.wcInstaller_FinishClick);
            this.wcInstaller.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wcInstaller_NextClick);
            // 
            // wpWelcome
            // 
            this.wpWelcome.IntroductionText = "This wizard simplifies the installation and setup of you CDS system.";
            this.wpWelcome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpWelcome.Name = "wpWelcome";
            this.wpWelcome.Size = new System.Drawing.Size(698, 541);
            this.wpWelcome.Text = "Welcome to Complete Distribution System";
            // 
            // wpConnection
            // 
            this.wpConnection.Controls.Add(this.layoutControl1);
            this.wpConnection.DescriptionText = "Set up connection to system database";
            this.wpConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpConnection.Name = "wpConnection";
            this.wpConnection.Size = new System.Drawing.Size(883, 518);
            this.wpConnection.Text = "Connection";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDatabase);
            this.layoutControl1.Controls.Add(this.txtTimeout);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Controls.Add(this.txtUsername);
            this.layoutControl1.Controls.Add(this.cbeAuthentication);
            this.layoutControl1.Controls.Add(this.ddlServer);
            this.layoutControl1.Controls.Add(this.txtCompanyConnectionName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(883, 518);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(108, 170);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(751, 22);
            this.txtDatabase.StyleController = this.layoutControl1;
            this.txtDatabase.TabIndex = 12;
            // 
            // txtTimeout
            // 
            this.txtTimeout.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTimeout.Location = new System.Drawing.Point(108, 222);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTimeout.Size = new System.Drawing.Size(333, 22);
            this.txtTimeout.StyleController = this.layoutControl1;
            this.txtTimeout.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(529, 196);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(330, 22);
            this.txtPassword.StyleController = this.layoutControl1;
            this.txtPassword.TabIndex = 8;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(108, 196);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(333, 22);
            this.txtUsername.StyleController = this.layoutControl1;
            this.txtUsername.TabIndex = 7;
            // 
            // cbeAuthentication
            // 
            this.cbeAuthentication.Location = new System.Drawing.Point(108, 144);
            this.cbeAuthentication.Name = "cbeAuthentication";
            this.cbeAuthentication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeAuthentication.Properties.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbeAuthentication.Size = new System.Drawing.Size(751, 22);
            this.cbeAuthentication.StyleController = this.layoutControl1;
            this.cbeAuthentication.TabIndex = 6;
            this.cbeAuthentication.SelectedIndexChanged += new System.EventHandler(this.cbeAuthentication_SelectedIndexChanged);
            // 
            // ddlServer
            // 
            this.ddlServer.Location = new System.Drawing.Point(108, 118);
            this.ddlServer.Name = "ddlServer";
            this.ddlServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
            this.ddlServer.Size = new System.Drawing.Size(751, 22);
            this.ddlServer.StyleController = this.layoutControl1;
            this.ddlServer.TabIndex = 5;
            this.ddlServer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ddlServer_ButtonClick);
            // 
            // txtCompanyConnectionName
            // 
            this.txtCompanyConnectionName.Location = new System.Drawing.Point(108, 46);
            this.txtCompanyConnectionName.Name = "txtCompanyConnectionName";
            this.txtCompanyConnectionName.Properties.Mask.EditMask = "[a-zA-Z0-9_ ]+";
            this.txtCompanyConnectionName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCompanyConnectionName.Properties.Mask.ShowPlaceHolders = false;
            this.txtCompanyConnectionName.Size = new System.Drawing.Size(751, 22);
            this.txtCompanyConnectionName.StyleController = this.layoutControl1;
            this.txtCompanyConnectionName.TabIndex = 4;
            this.txtCompanyConnectionName.EditValueChanged += new System.EventHandler(this.txtCompanyConnectionName_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgCompany,
            this.lcgConnection});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lcgCompany
            // 
            this.lcgCompany.CustomizationFormText = "Company";
            this.lcgCompany.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmName});
            this.lcgCompany.Location = new System.Drawing.Point(0, 0);
            this.lcgCompany.Name = "lcgCompany";
            this.lcgCompany.Size = new System.Drawing.Size(863, 72);
            this.lcgCompany.Text = "Company";
            // 
            // itmName
            // 
            this.itmName.Control = this.txtCompanyConnectionName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 0);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(839, 26);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(81, 16);
            // 
            // lcgConnection
            // 
            this.lcgConnection.CustomizationFormText = "Connection";
            this.lcgConnection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmServer,
            this.itmAuthentication,
            this.itmUsername,
            this.itmPassword,
            this.itmTimeout,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.itmDatabase});
            this.lcgConnection.Location = new System.Drawing.Point(0, 72);
            this.lcgConnection.Name = "lcgConnection";
            this.lcgConnection.Size = new System.Drawing.Size(863, 426);
            this.lcgConnection.Text = "Connection";
            // 
            // itmServer
            // 
            this.itmServer.Control = this.ddlServer;
            this.itmServer.CustomizationFormText = "Server";
            this.itmServer.Location = new System.Drawing.Point(0, 0);
            this.itmServer.Name = "itmServer";
            this.itmServer.Size = new System.Drawing.Size(839, 26);
            this.itmServer.Text = "Server";
            this.itmServer.TextSize = new System.Drawing.Size(81, 16);
            // 
            // itmAuthentication
            // 
            this.itmAuthentication.Control = this.cbeAuthentication;
            this.itmAuthentication.CustomizationFormText = "Authentication";
            this.itmAuthentication.Location = new System.Drawing.Point(0, 26);
            this.itmAuthentication.Name = "itmAuthentication";
            this.itmAuthentication.Size = new System.Drawing.Size(839, 26);
            this.itmAuthentication.Text = "Authentication";
            this.itmAuthentication.TextSize = new System.Drawing.Size(81, 16);
            // 
            // itmUsername
            // 
            this.itmUsername.Control = this.txtUsername;
            this.itmUsername.CustomizationFormText = "Username";
            this.itmUsername.Location = new System.Drawing.Point(0, 78);
            this.itmUsername.Name = "itmUsername";
            this.itmUsername.Size = new System.Drawing.Size(421, 26);
            this.itmUsername.Text = "Username";
            this.itmUsername.TextSize = new System.Drawing.Size(81, 16);
            // 
            // itmPassword
            // 
            this.itmPassword.Control = this.txtPassword;
            this.itmPassword.CustomizationFormText = "Password";
            this.itmPassword.Location = new System.Drawing.Point(421, 78);
            this.itmPassword.Name = "itmPassword";
            this.itmPassword.Size = new System.Drawing.Size(418, 26);
            this.itmPassword.Text = "Password";
            this.itmPassword.TextSize = new System.Drawing.Size(81, 16);
            // 
            // itmTimeout
            // 
            this.itmTimeout.Control = this.txtTimeout;
            this.itmTimeout.CustomizationFormText = "Timeout";
            this.itmTimeout.Location = new System.Drawing.Point(0, 104);
            this.itmTimeout.Name = "itmTimeout";
            this.itmTimeout.Size = new System.Drawing.Size(421, 26);
            this.itmTimeout.Text = "Timeout";
            this.itmTimeout.TextSize = new System.Drawing.Size(81, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 130);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(839, 250);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(421, 104);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(418, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmDatabase
            // 
            this.itmDatabase.Control = this.txtDatabase;
            this.itmDatabase.CustomizationFormText = "Database";
            this.itmDatabase.Location = new System.Drawing.Point(0, 52);
            this.itmDatabase.Name = "itmDatabase";
            this.itmDatabase.Size = new System.Drawing.Size(839, 26);
            this.itmDatabase.Text = "Database";
            this.itmDatabase.TextSize = new System.Drawing.Size(81, 16);
            // 
            // wpComplete
            // 
            this.wpComplete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpComplete.Name = "wpComplete";
            this.wpComplete.Size = new System.Drawing.Size(698, 541);
            // 
            // wpSiteSetup
            // 
            this.wpSiteSetup.Controls.Add(this.layoutControl2);
            this.wpSiteSetup.DescriptionText = "Here you can setup the default sites";
            this.wpSiteSetup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpSiteSetup.Name = "wpSiteSetup";
            this.wpSiteSetup.Size = new System.Drawing.Size(883, 518);
            this.wpSiteSetup.Text = "Site Setup";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtClientZipLocation);
            this.layoutControl2.Controls.Add(this.txtUpdateURL);
            this.layoutControl2.Controls.Add(this.grdEntity);
            this.layoutControl2.Controls.Add(this.txtPrintServerLocation);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(883, 518);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtPrintServerLocation
            // 
            this.txtPrintServerLocation.Location = new System.Drawing.Point(124, 2);
            this.txtPrintServerLocation.Name = "txtPrintServerLocation";
            this.txtPrintServerLocation.Size = new System.Drawing.Size(757, 22);
            this.txtPrintServerLocation.StyleController = this.layoutControl2;
            this.txtPrintServerLocation.TabIndex = 7;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmPrintServerLocation,
            this.itmSiteGrid,
            this.itmUpdateURL,
            this.itmClientZipLocation});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // itmPrintServerLocation
            // 
            this.itmPrintServerLocation.Control = this.txtPrintServerLocation;
            this.itmPrintServerLocation.CustomizationFormText = "Print Server Location";
            this.itmPrintServerLocation.Location = new System.Drawing.Point(0, 0);
            this.itmPrintServerLocation.Name = "itmPrintServerLocation";
            this.itmPrintServerLocation.Size = new System.Drawing.Size(883, 26);
            this.itmPrintServerLocation.Text = "Print Server Location";
            this.itmPrintServerLocation.TextSize = new System.Drawing.Size(119, 16);
            // 
            // itmSiteGrid
            // 
            this.itmSiteGrid.Control = this.grdEntity;
            this.itmSiteGrid.CustomizationFormText = "itmSiteGrid";
            this.itmSiteGrid.Location = new System.Drawing.Point(0, 78);
            this.itmSiteGrid.Name = "itmSiteGrid";
            this.itmSiteGrid.Size = new System.Drawing.Size(883, 440);
            this.itmSiteGrid.Text = "itmSiteGrid";
            this.itmSiteGrid.TextSize = new System.Drawing.Size(0, 0);
            this.itmSiteGrid.TextVisible = false;
            // 
            // wpSqlSetupOption
            // 
            this.wpSqlSetupOption.Controls.Add(this.layoutControl3);
            this.wpSqlSetupOption.DescriptionText = "Please choose below SQL Setup option";
            this.wpSqlSetupOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpSqlSetupOption.Name = "wpSqlSetupOption";
            this.wpSqlSetupOption.Size = new System.Drawing.Size(883, 518);
            this.wpSqlSetupOption.Text = "SQL Setup";
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.btnInstallSQLExpress);
            this.layoutControl3.Controls.Add(this.btnChooseSql);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(0, 0);
            this.layoutControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1120, 132, 770, 762);
            this.layoutControl3.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl3.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl3.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl3.Root = this.Root;
            this.layoutControl3.Size = new System.Drawing.Size(883, 518);
            this.layoutControl3.TabIndex = 1;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // btnInstallSQLExpress
            // 
            this.btnInstallSQLExpress.Checked = true;
            this.btnInstallSQLExpress.GroupIndex = 1;
            this.btnInstallSQLExpress.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnInstallSQLExpress.Location = new System.Drawing.Point(286, 171);
            this.btnInstallSQLExpress.Name = "btnInstallSQLExpress";
            this.btnInstallSQLExpress.Size = new System.Drawing.Size(155, 176);
            this.btnInstallSQLExpress.StyleController = this.layoutControl3;
            this.btnInstallSQLExpress.TabIndex = 0;
            this.btnInstallSQLExpress.Text = "Install Sql Express";
            // 
            // btnChooseSql
            // 
            this.btnChooseSql.GroupIndex = 1;
            this.btnChooseSql.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnChooseSql.Location = new System.Drawing.Point(445, 171);
            this.btnChooseSql.Name = "btnChooseSql";
            this.btnChooseSql.Size = new System.Drawing.Size(157, 176);
            this.btnChooseSql.StyleController = this.layoutControl3;
            this.btnChooseSql.TabIndex = 0;
            this.btnChooseSql.TabStop = false;
            this.btnChooseSql.Text = "Choose SQL Instance";
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem7});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(883, 518);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnInstallSQLExpress;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(274, 159);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(159, 180);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnChooseSql;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(433, 159);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(161, 180);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(274, 0);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(320, 159);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(274, 339);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(320, 159);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(594, 0);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(269, 498);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(274, 498);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // wpSqlInstall
            // 
            this.wpSqlInstall.Controls.Add(this.lcSQLInstallation);
            this.wpSqlInstall.DescriptionText = "Please fill in the fieled below and click Next to install SQL Express";
            this.wpSqlInstall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpSqlInstall.Name = "wpSqlInstall";
            this.wpSqlInstall.Size = new System.Drawing.Size(883, 518);
            this.wpSqlInstall.Text = "Sql Installation";
            // 
            // wpDataDirectories
            // 
            this.wpDataDirectories.Controls.Add(this.layoutControl4);
            this.wpDataDirectories.DescriptionText = "Below you can select there the files of the database should be stored";
            this.wpDataDirectories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpDataDirectories.Name = "wpDataDirectories";
            this.wpDataDirectories.Size = new System.Drawing.Size(883, 518);
            this.wpDataDirectories.Text = "Data Directories";
            // 
            // layoutControl4
            // 
            this.layoutControl4.Controls.Add(this.xtraScrollableControl1);
            this.layoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl4.Location = new System.Drawing.Point(0, 0);
            this.layoutControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl4.Name = "layoutControl4";
            this.layoutControl4.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2712, 302, 635, 433);
            this.layoutControl4.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl4.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl4.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl4.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl4.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl4.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl4.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl4.Root = this.layoutControlGroup4;
            this.layoutControl4.Size = new System.Drawing.Size(883, 518);
            this.layoutControl4.TabIndex = 0;
            this.layoutControl4.Text = "layoutControl4";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.layoutControl5);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(24, 46);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(835, 448);
            this.xtraScrollableControl1.TabIndex = 30;
            // 
            // layoutControl5
            // 
            this.layoutControl5.Controls.Add(this.txtDatabaseNameMasked);
            this.layoutControl5.Controls.Add(this.txtDatabaseName);
            this.layoutControl5.Controls.Add(this.bceDefaultDirectory);
            this.layoutControl5.Controls.Add(this.bceMainData);
            this.layoutControl5.Controls.Add(this.bceMainLog);
            this.layoutControl5.Controls.Add(this.bceAutomaticOrdering);
            this.layoutControl5.Controls.Add(this.bceCalendar);
            this.layoutControl5.Controls.Add(this.bceCatalogue);
            this.layoutControl5.Controls.Add(this.bceLedger);
            this.layoutControl5.Controls.Add(this.bceHumanResources);
            this.layoutControl5.Controls.Add(this.bceItemBuyout);
            this.layoutControl5.Controls.Add(this.bceIndex);
            this.layoutControl5.Controls.Add(this.bceItem);
            this.layoutControl5.Controls.Add(this.bceItemBOM);
            this.layoutControl5.Controls.Add(this.bceItemDiscount);
            this.layoutControl5.Controls.Add(this.bceJob);
            this.layoutControl5.Controls.Add(this.bceOrganisation);
            this.layoutControl5.Controls.Add(this.bceOrganisationTransactions);
            this.layoutControl5.Controls.Add(this.bceReport);
            this.layoutControl5.Controls.Add(this.bceSecurity);
            this.layoutControl5.Controls.Add(this.bceSystem);
            this.layoutControl5.Controls.Add(this.bceSystemDocument);
            this.layoutControl5.Controls.Add(this.bceSystemMessage);
            this.layoutControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl5.Location = new System.Drawing.Point(0, 0);
            this.layoutControl5.Name = "layoutControl5";
            this.layoutControl5.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl5.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl5.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl5.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl5.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl5.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl5.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl5.Root = this.lcgDatabaseFileLocations;
            this.layoutControl5.Size = new System.Drawing.Size(835, 448);
            this.layoutControl5.TabIndex = 0;
            this.layoutControl5.Text = "layoutControl4";
            // 
            // txtDatabaseNameMasked
            // 
            this.txtDatabaseNameMasked.Enabled = false;
            this.txtDatabaseNameMasked.Location = new System.Drawing.Point(496, 12);
            this.txtDatabaseNameMasked.Name = "txtDatabaseNameMasked";
            this.txtDatabaseNameMasked.Size = new System.Drawing.Size(306, 22);
            this.txtDatabaseNameMasked.StyleController = this.layoutControl5;
            this.txtDatabaseNameMasked.TabIndex = 26;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(164, 12);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Properties.Mask.EditMask = "[a-z0-9_ ]+";
            this.txtDatabaseName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDatabaseName.Properties.Mask.ShowPlaceHolders = false;
            this.txtDatabaseName.Size = new System.Drawing.Size(328, 22);
            this.txtDatabaseName.StyleController = this.layoutControl5;
            this.txtDatabaseName.TabIndex = 25;
            this.txtDatabaseName.EditValueChanged += new System.EventHandler(this.txtDatabaseName_EditValueChanged);
            // 
            // bceDefaultDirectory
            // 
            this.bceDefaultDirectory.Location = new System.Drawing.Point(164, 38);
            this.bceDefaultDirectory.Name = "bceDefaultDirectory";
            this.bceDefaultDirectory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceDefaultDirectory.Properties.ReadOnly = false;
            this.bceDefaultDirectory.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceDefaultDirectory.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceDefaultDirectory.Size = new System.Drawing.Size(638, 24);
            this.bceDefaultDirectory.StyleController = this.layoutControl5;
            this.bceDefaultDirectory.TabIndex = 24;
            this.bceDefaultDirectory.Leave += new System.EventHandler(this.bceDefaultDirectory_Leave);
            // 
            // bceMainData
            // 
            this.bceMainData.Location = new System.Drawing.Point(164, 66);
            this.bceMainData.Name = "bceMainData";
            this.bceMainData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceMainData.Properties.ReadOnly = false;
            this.bceMainData.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceMainData.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceMainData.Size = new System.Drawing.Size(638, 24);
            this.bceMainData.StyleController = this.layoutControl5;
            this.bceMainData.TabIndex = 4;
            // 
            // bceMainLog
            // 
            this.bceMainLog.Location = new System.Drawing.Point(164, 94);
            this.bceMainLog.Name = "bceMainLog";
            this.bceMainLog.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceMainLog.Properties.ReadOnly = false;
            this.bceMainLog.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceMainLog.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceMainLog.Size = new System.Drawing.Size(638, 24);
            this.bceMainLog.StyleController = this.layoutControl5;
            this.bceMainLog.TabIndex = 19;
            // 
            // bceAutomaticOrdering
            // 
            this.bceAutomaticOrdering.Location = new System.Drawing.Point(164, 122);
            this.bceAutomaticOrdering.Name = "bceAutomaticOrdering";
            this.bceAutomaticOrdering.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceAutomaticOrdering.Properties.ReadOnly = false;
            this.bceAutomaticOrdering.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceAutomaticOrdering.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceAutomaticOrdering.Size = new System.Drawing.Size(638, 24);
            this.bceAutomaticOrdering.StyleController = this.layoutControl5;
            this.bceAutomaticOrdering.TabIndex = 5;
            // 
            // bceCalendar
            // 
            this.bceCalendar.Location = new System.Drawing.Point(164, 150);
            this.bceCalendar.Name = "bceCalendar";
            this.bceCalendar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceCalendar.Properties.ReadOnly = false;
            this.bceCalendar.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceCalendar.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceCalendar.Size = new System.Drawing.Size(638, 24);
            this.bceCalendar.StyleController = this.layoutControl5;
            this.bceCalendar.TabIndex = 6;
            // 
            // bceCatalogue
            // 
            this.bceCatalogue.Location = new System.Drawing.Point(164, 178);
            this.bceCatalogue.Name = "bceCatalogue";
            this.bceCatalogue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceCatalogue.Properties.ReadOnly = false;
            this.bceCatalogue.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceCatalogue.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceCatalogue.Size = new System.Drawing.Size(638, 24);
            this.bceCatalogue.StyleController = this.layoutControl5;
            this.bceCatalogue.TabIndex = 7;
            // 
            // bceLedger
            // 
            this.bceLedger.Location = new System.Drawing.Point(164, 206);
            this.bceLedger.Name = "bceLedger";
            this.bceLedger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceLedger.Properties.ReadOnly = false;
            this.bceLedger.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceLedger.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceLedger.Size = new System.Drawing.Size(638, 24);
            this.bceLedger.StyleController = this.layoutControl5;
            this.bceLedger.TabIndex = 8;
            // 
            // bceHumanResources
            // 
            this.bceHumanResources.Location = new System.Drawing.Point(164, 234);
            this.bceHumanResources.Name = "bceHumanResources";
            this.bceHumanResources.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceHumanResources.Properties.ReadOnly = false;
            this.bceHumanResources.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceHumanResources.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceHumanResources.Size = new System.Drawing.Size(638, 24);
            this.bceHumanResources.StyleController = this.layoutControl5;
            this.bceHumanResources.TabIndex = 9;
            // 
            // bceItemBuyout
            // 
            this.bceItemBuyout.Location = new System.Drawing.Point(164, 262);
            this.bceItemBuyout.Name = "bceItemBuyout";
            this.bceItemBuyout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceItemBuyout.Properties.ReadOnly = false;
            this.bceItemBuyout.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceItemBuyout.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceItemBuyout.Size = new System.Drawing.Size(638, 24);
            this.bceItemBuyout.StyleController = this.layoutControl5;
            this.bceItemBuyout.TabIndex = 10;
            // 
            // bceIndex
            // 
            this.bceIndex.Location = new System.Drawing.Point(164, 290);
            this.bceIndex.Name = "bceIndex";
            this.bceIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceIndex.Properties.ReadOnly = false;
            this.bceIndex.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceIndex.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceIndex.Size = new System.Drawing.Size(638, 24);
            this.bceIndex.StyleController = this.layoutControl5;
            this.bceIndex.TabIndex = 11;
            // 
            // bceItem
            // 
            this.bceItem.Location = new System.Drawing.Point(164, 318);
            this.bceItem.Name = "bceItem";
            this.bceItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceItem.Properties.ReadOnly = false;
            this.bceItem.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceItem.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceItem.Size = new System.Drawing.Size(638, 24);
            this.bceItem.StyleController = this.layoutControl5;
            this.bceItem.TabIndex = 12;
            // 
            // bceItemBOM
            // 
            this.bceItemBOM.Location = new System.Drawing.Point(164, 346);
            this.bceItemBOM.Name = "bceItemBOM";
            this.bceItemBOM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceItemBOM.Properties.ReadOnly = false;
            this.bceItemBOM.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceItemBOM.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceItemBOM.Size = new System.Drawing.Size(638, 24);
            this.bceItemBOM.StyleController = this.layoutControl5;
            this.bceItemBOM.TabIndex = 13;
            // 
            // bceItemDiscount
            // 
            this.bceItemDiscount.Location = new System.Drawing.Point(164, 374);
            this.bceItemDiscount.Name = "bceItemDiscount";
            this.bceItemDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceItemDiscount.Properties.ReadOnly = false;
            this.bceItemDiscount.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceItemDiscount.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceItemDiscount.Size = new System.Drawing.Size(638, 24);
            this.bceItemDiscount.StyleController = this.layoutControl5;
            this.bceItemDiscount.TabIndex = 14;
            // 
            // bceJob
            // 
            this.bceJob.Location = new System.Drawing.Point(164, 402);
            this.bceJob.Name = "bceJob";
            this.bceJob.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceJob.Properties.ReadOnly = false;
            this.bceJob.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceJob.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceJob.Size = new System.Drawing.Size(638, 24);
            this.bceJob.StyleController = this.layoutControl5;
            this.bceJob.TabIndex = 15;
            // 
            // bceOrganisation
            // 
            this.bceOrganisation.Location = new System.Drawing.Point(164, 430);
            this.bceOrganisation.Name = "bceOrganisation";
            this.bceOrganisation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceOrganisation.Properties.ReadOnly = false;
            this.bceOrganisation.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceOrganisation.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceOrganisation.Size = new System.Drawing.Size(638, 24);
            this.bceOrganisation.StyleController = this.layoutControl5;
            this.bceOrganisation.TabIndex = 16;
            // 
            // bceOrganisationTransactions
            // 
            this.bceOrganisationTransactions.Location = new System.Drawing.Point(164, 458);
            this.bceOrganisationTransactions.Name = "bceOrganisationTransactions";
            this.bceOrganisationTransactions.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceOrganisationTransactions.Properties.ReadOnly = false;
            this.bceOrganisationTransactions.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceOrganisationTransactions.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceOrganisationTransactions.Size = new System.Drawing.Size(638, 24);
            this.bceOrganisationTransactions.StyleController = this.layoutControl5;
            this.bceOrganisationTransactions.TabIndex = 17;
            // 
            // bceReport
            // 
            this.bceReport.Location = new System.Drawing.Point(164, 486);
            this.bceReport.Name = "bceReport";
            this.bceReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceReport.Properties.ReadOnly = false;
            this.bceReport.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceReport.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceReport.Size = new System.Drawing.Size(638, 24);
            this.bceReport.StyleController = this.layoutControl5;
            this.bceReport.TabIndex = 18;
            // 
            // bceSecurity
            // 
            this.bceSecurity.Location = new System.Drawing.Point(164, 514);
            this.bceSecurity.Name = "bceSecurity";
            this.bceSecurity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceSecurity.Properties.ReadOnly = false;
            this.bceSecurity.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceSecurity.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceSecurity.Size = new System.Drawing.Size(638, 24);
            this.bceSecurity.StyleController = this.layoutControl5;
            this.bceSecurity.TabIndex = 23;
            // 
            // bceSystem
            // 
            this.bceSystem.Location = new System.Drawing.Point(164, 542);
            this.bceSystem.Name = "bceSystem";
            this.bceSystem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceSystem.Properties.ReadOnly = false;
            this.bceSystem.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceSystem.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceSystem.Size = new System.Drawing.Size(638, 24);
            this.bceSystem.StyleController = this.layoutControl5;
            this.bceSystem.TabIndex = 22;
            // 
            // bceSystemDocument
            // 
            this.bceSystemDocument.Location = new System.Drawing.Point(164, 570);
            this.bceSystemDocument.Name = "bceSystemDocument";
            this.bceSystemDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceSystemDocument.Properties.ReadOnly = false;
            this.bceSystemDocument.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceSystemDocument.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceSystemDocument.Size = new System.Drawing.Size(638, 24);
            this.bceSystemDocument.StyleController = this.layoutControl5;
            this.bceSystemDocument.TabIndex = 21;
            // 
            // bceSystemMessage
            // 
            this.bceSystemMessage.Location = new System.Drawing.Point(164, 598);
            this.bceSystemMessage.Name = "bceSystemMessage";
            this.bceSystemMessage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bceSystemMessage.Properties.ReadOnly = false;
            this.bceSystemMessage.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.BreadCrumb_Properties_QueryChildNodes);
            this.bceSystemMessage.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.BreadCrumb_Properties_NewNodeAdding);
            this.bceSystemMessage.Size = new System.Drawing.Size(638, 24);
            this.bceSystemMessage.StyleController = this.layoutControl5;
            this.bceSystemMessage.TabIndex = 20;
            // 
            // lcgDatabaseFileLocations
            // 
            this.lcgDatabaseFileLocations.CustomizationFormText = "layoutControlGroup5";
            this.lcgDatabaseFileLocations.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgDatabaseFileLocations.GroupBordersVisible = false;
            this.lcgDatabaseFileLocations.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem18,
            this.layoutControlItem19,
            this.layoutControlItem20,
            this.layoutControlItem21,
            this.lciDefaultDirectory,
            this.layoutControlItem23,
            this.lciDatabaseName,
            this.lciDatabaseNameMasked});
            this.lcgDatabaseFileLocations.Location = new System.Drawing.Point(0, 0);
            this.lcgDatabaseFileLocations.Name = "lcgDatabaseFileLocations";
            this.lcgDatabaseFileLocations.Size = new System.Drawing.Size(814, 634);
            this.lcgDatabaseFileLocations.Text = "lcgDatabaseFileLocations";
            this.lcgDatabaseFileLocations.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.bceMainData;
            this.layoutControlItem3.CustomizationFormText = "Main Data";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem3.Name = "itmMainData";
            this.layoutControlItem3.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem3.Text = "Main Data";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.bceAutomaticOrdering;
            this.layoutControlItem4.CustomizationFormText = "Automatic Ordering";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 110);
            this.layoutControlItem4.Name = "itmAutomaticOrdering";
            this.layoutControlItem4.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem4.Text = "Automatic Ordering";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.bceCalendar;
            this.layoutControlItem5.CustomizationFormText = "Calendar";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem5.Name = "lciCalendar";
            this.layoutControlItem5.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem5.Text = "Calendar";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.bceCatalogue;
            this.layoutControlItem6.CustomizationFormText = "Catalogue";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 166);
            this.layoutControlItem6.Name = "lciCatalogue";
            this.layoutControlItem6.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem6.Text = "Catalogue";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.bceLedger;
            this.layoutControlItem7.CustomizationFormText = "Ledger";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 194);
            this.layoutControlItem7.Name = "lciLedger";
            this.layoutControlItem7.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem7.Text = "Ledger";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.bceHumanResources;
            this.layoutControlItem8.CustomizationFormText = "Human Resources";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 222);
            this.layoutControlItem8.Name = "lciHumanResources";
            this.layoutControlItem8.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem8.Text = "Human Resources";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.bceItemBuyout;
            this.layoutControlItem9.CustomizationFormText = "Item Buyouts";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 250);
            this.layoutControlItem9.Name = "lciItemBuyouts";
            this.layoutControlItem9.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem9.Text = "Item Buyouts";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.bceIndex;
            this.layoutControlItem10.CustomizationFormText = "Index";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 278);
            this.layoutControlItem10.Name = "lciIndex";
            this.layoutControlItem10.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem10.Text = "Index";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.bceItem;
            this.layoutControlItem11.CustomizationFormText = "Item";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 306);
            this.layoutControlItem11.Name = "lciItem";
            this.layoutControlItem11.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem11.Text = "Item";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.bceItemBOM;
            this.layoutControlItem12.CustomizationFormText = "Item BOM";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 334);
            this.layoutControlItem12.Name = "lciItemBOM";
            this.layoutControlItem12.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem12.Text = "Item BOM";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.bceItemDiscount;
            this.layoutControlItem13.CustomizationFormText = "Item Discount";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 362);
            this.layoutControlItem13.Name = "lciItemDiscount";
            this.layoutControlItem13.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem13.Text = "Item Discount";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.bceJob;
            this.layoutControlItem14.CustomizationFormText = "Job";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 390);
            this.layoutControlItem14.Name = "lciJob";
            this.layoutControlItem14.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem14.Text = "Job";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.bceOrganisation;
            this.layoutControlItem15.CustomizationFormText = "Organisation";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 418);
            this.layoutControlItem15.Name = "lciOrganisation";
            this.layoutControlItem15.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem15.Text = "Organisation";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.bceOrganisationTransactions;
            this.layoutControlItem16.CustomizationFormText = "Organisation Transactions";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 446);
            this.layoutControlItem16.Name = "lciOrganisationTransactions";
            this.layoutControlItem16.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem16.Text = "Organisation Transactions";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.bceReport;
            this.layoutControlItem17.CustomizationFormText = "Report";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 474);
            this.layoutControlItem17.Name = "lciReport";
            this.layoutControlItem17.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem17.Text = "Report";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.bceSystemMessage;
            this.layoutControlItem18.CustomizationFormText = "System Messages";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 586);
            this.layoutControlItem18.Name = "lciSystemMessages";
            this.layoutControlItem18.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem18.Text = "System Messages";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.bceSystemDocument;
            this.layoutControlItem19.CustomizationFormText = "System Documents";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 558);
            this.layoutControlItem19.Name = "lciSystemDocuments";
            this.layoutControlItem19.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem19.Text = "System Documents";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.bceSystem;
            this.layoutControlItem20.CustomizationFormText = "System";
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 530);
            this.layoutControlItem20.Name = "lciSystem";
            this.layoutControlItem20.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem20.Text = "System";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.bceSecurity;
            this.layoutControlItem21.CustomizationFormText = "Security";
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 502);
            this.layoutControlItem21.Name = "lciSecurity";
            this.layoutControlItem21.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem21.Text = "Security";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(149, 16);
            // 
            // lciDefaultDirectory
            // 
            this.lciDefaultDirectory.Control = this.bceDefaultDirectory;
            this.lciDefaultDirectory.CustomizationFormText = "Default Directory";
            this.lciDefaultDirectory.Location = new System.Drawing.Point(0, 26);
            this.lciDefaultDirectory.Name = "lciDefaultDirectory";
            this.lciDefaultDirectory.Size = new System.Drawing.Size(794, 28);
            this.lciDefaultDirectory.Text = "Default Directory";
            this.lciDefaultDirectory.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.bceMainLog;
            this.layoutControlItem23.CustomizationFormText = "Main Log";
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItem23.Name = "lciMainLog";
            this.layoutControlItem23.Size = new System.Drawing.Size(794, 28);
            this.layoutControlItem23.Text = "Main Log";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(149, 16);
            // 
            // lciDatabaseName
            // 
            this.lciDatabaseName.Control = this.txtDatabaseName;
            this.lciDatabaseName.CustomizationFormText = "Database Name";
            this.lciDatabaseName.Location = new System.Drawing.Point(0, 0);
            this.lciDatabaseName.Name = "lciDatabaseName";
            this.lciDatabaseName.Size = new System.Drawing.Size(484, 26);
            this.lciDatabaseName.Text = "Database Name";
            this.lciDatabaseName.TextSize = new System.Drawing.Size(149, 16);
            // 
            // lciDatabaseNameMasked
            // 
            this.lciDatabaseNameMasked.Control = this.txtDatabaseNameMasked;
            this.lciDatabaseNameMasked.CustomizationFormText = "Database Name Masked";
            this.lciDatabaseNameMasked.Location = new System.Drawing.Point(484, 0);
            this.lciDatabaseNameMasked.Name = "lciDatabaseNameMasked";
            this.lciDatabaseNameMasked.Size = new System.Drawing.Size(310, 26);
            this.lciDatabaseNameMasked.Text = "Database Name Masked";
            this.lciDatabaseNameMasked.TextSize = new System.Drawing.Size(0, 0);
            this.lciDatabaseNameMasked.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgDataDirectories});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup4.Text = "layoutControlGroup4";
            this.layoutControlGroup4.TextVisible = false;
            // 
            // lcgDataDirectories
            // 
            this.lcgDataDirectories.CustomizationFormText = "Data Directories";
            this.lcgDataDirectories.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem24});
            this.lcgDataDirectories.Location = new System.Drawing.Point(0, 0);
            this.lcgDataDirectories.Name = "lcgDataDirectories";
            this.lcgDataDirectories.Size = new System.Drawing.Size(863, 498);
            this.lcgDataDirectories.Text = "Data Directories";
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.xtraScrollableControl1;
            this.layoutControlItem24.CustomizationFormText = "layoutControlItem22";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(839, 452);
            this.layoutControlItem24.Text = "layoutControlItem22";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // wpNewOrImport
            // 
            this.wpNewOrImport.Controls.Add(this.layoutControl6);
            this.wpNewOrImport.DescriptionText = "Choose below to set up a New Company or Import from CDS 2";
            this.wpNewOrImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpNewOrImport.Name = "wpNewOrImport";
            this.wpNewOrImport.Size = new System.Drawing.Size(883, 518);
            this.wpNewOrImport.Text = "New or Import";
            // 
            // layoutControl6
            // 
            this.layoutControl6.Controls.Add(this.btnImportChimera);
            this.layoutControl6.Controls.Add(this.btnNewCompany);
            this.layoutControl6.Controls.Add(this.btnImportCDS);
            this.layoutControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl6.Location = new System.Drawing.Point(0, 0);
            this.layoutControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl6.Name = "layoutControl6";
            this.layoutControl6.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(938, 348, 855, 484);
            this.layoutControl6.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl6.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl6.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl6.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl6.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl6.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl6.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl6.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl6.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl6.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl6.Root = this.layoutControlGroup5;
            this.layoutControl6.Size = new System.Drawing.Size(883, 518);
            this.layoutControl6.TabIndex = 0;
            this.layoutControl6.Text = "layoutControl6";
            // 
            // btnImportChimera
            // 
            this.btnImportChimera.GroupIndex = 2;
            this.btnImportChimera.Image = global::CDS.Server.Installer.Properties.Resources.cdsicon2;
            this.btnImportChimera.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnImportChimera.Location = new System.Drawing.Point(519, 171);
            this.btnImportChimera.Name = "btnImportChimera";
            this.btnImportChimera.Size = new System.Drawing.Size(163, 214);
            this.btnImportChimera.StyleController = this.layoutControl6;
            this.btnImportChimera.TabIndex = 4;
            this.btnImportChimera.TabStop = false;
            this.btnImportChimera.Text = "Import from CDS \r\n(CHIMERA)";
            // 
            // btnNewCompany
            // 
            this.btnNewCompany.Checked = true;
            this.btnNewCompany.GroupIndex = 2;
            this.btnNewCompany.Image = global::CDS.Server.Installer.Properties.Resources.factory_64;
            this.btnNewCompany.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnNewCompany.Location = new System.Drawing.Point(179, 171);
            this.btnNewCompany.Name = "btnNewCompany";
            this.btnNewCompany.Size = new System.Drawing.Size(165, 214);
            this.btnNewCompany.StyleController = this.layoutControl6;
            this.btnNewCompany.TabIndex = 0;
            this.btnNewCompany.Text = "New Company";
            // 
            // btnImportCDS
            // 
            this.btnImportCDS.GroupIndex = 2;
            this.btnImportCDS.Image = global::CDS.Server.Installer.Properties.Resources.cashier_64x64;
            this.btnImportCDS.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnImportCDS.Location = new System.Drawing.Point(348, 171);
            this.btnImportCDS.Name = "btnImportCDS";
            this.btnImportCDS.Size = new System.Drawing.Size(167, 214);
            this.btnImportCDS.StyleController = this.layoutControl6;
            this.btnImportCDS.TabIndex = 0;
            this.btnImportCDS.TabStop = false;
            this.btnImportCDS.Text = "Import from CDS";
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5";
            this.layoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup5.GroupBordersVisible = false;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup7});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup5.Text = "layoutControlGroup5";
            this.layoutControlGroup5.TextVisible = false;
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.CustomizationFormText = "Root";
            this.layoutControlGroup7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup7.GroupBordersVisible = false;
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem22,
            this.layoutControlItem25,
            this.emptySpaceItem3,
            this.emptySpaceItem9,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.layoutControlItem27});
            this.layoutControlGroup7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup7.Name = "layoutControlGroup7";
            this.layoutControlGroup7.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup7.Size = new System.Drawing.Size(863, 498);
            this.layoutControlGroup7.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup7.Text = "Root";
            this.layoutControlGroup7.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.btnNewCompany;
            this.layoutControlItem22.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem22.Location = new System.Drawing.Point(167, 159);
            this.layoutControlItem22.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(169, 218);
            this.layoutControlItem22.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem22.Text = "layoutControlItem1";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.btnImportCDS;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem25.Location = new System.Drawing.Point(336, 159);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(171, 218);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.Text = "layoutControlItem2";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem3.Location = new System.Drawing.Point(167, 0);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(507, 159);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem4";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem9.Location = new System.Drawing.Point(167, 377);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(507, 121);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem9.Text = "emptySpaceItem5";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem10.Location = new System.Drawing.Point(674, 0);
            this.emptySpaceItem10.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(189, 498);
            this.emptySpaceItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem10.Text = "emptySpaceItem6";
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem11.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem11.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(167, 498);
            this.emptySpaceItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem11.Text = "emptySpaceItem7";
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.btnImportChimera;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem27.Location = new System.Drawing.Point(507, 159);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(167, 218);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "layoutControlItem27";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // wpImportConnection
            // 
            this.wpImportConnection.Controls.Add(this.layoutControl7);
            this.wpImportConnection.DescriptionText = "Setup connection to previous CDS";
            this.wpImportConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpImportConnection.Name = "wpImportConnection";
            this.wpImportConnection.Size = new System.Drawing.Size(883, 518);
            this.wpImportConnection.Text = "Import previous CDS";
            // 
            // layoutControl7
            // 
            this.layoutControl7.Controls.Add(this.txtOldCDSDatabase);
            this.layoutControl7.Controls.Add(this.ddlOldCDSServer);
            this.layoutControl7.Controls.Add(this.cbeOldCDSAuthentication);
            this.layoutControl7.Controls.Add(this.txtOldCDSUsername);
            this.layoutControl7.Controls.Add(this.txtOldCDSPassword);
            this.layoutControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl7.Location = new System.Drawing.Point(0, 0);
            this.layoutControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl7.Name = "layoutControl7";
            this.layoutControl7.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(804, 302, 910, 350);
            this.layoutControl7.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl7.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl7.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl7.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl7.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl7.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl7.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl7.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl7.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl7.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl7.Root = this.layoutControlGroup6;
            this.layoutControl7.Size = new System.Drawing.Size(883, 518);
            this.layoutControl7.TabIndex = 0;
            this.layoutControl7.Text = "layoutControl7";
            // 
            // txtOldCDSDatabase
            // 
            this.txtOldCDSDatabase.Location = new System.Drawing.Point(108, 98);
            this.txtOldCDSDatabase.Name = "txtOldCDSDatabase";
            this.txtOldCDSDatabase.Size = new System.Drawing.Size(751, 22);
            this.txtOldCDSDatabase.StyleController = this.layoutControl7;
            this.txtOldCDSDatabase.TabIndex = 9;
            // 
            // ddlOldCDSServer
            // 
            this.ddlOldCDSServer.Location = new System.Drawing.Point(108, 46);
            this.ddlOldCDSServer.Name = "ddlOldCDSServer";
            this.ddlOldCDSServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
            this.ddlOldCDSServer.Properties.ReadOnly = true;
            this.ddlOldCDSServer.Size = new System.Drawing.Size(751, 22);
            this.ddlOldCDSServer.StyleController = this.layoutControl7;
            this.ddlOldCDSServer.TabIndex = 5;
            this.ddlOldCDSServer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ddlServer_ButtonClick);
            // 
            // cbeOldCDSAuthentication
            // 
            this.cbeOldCDSAuthentication.Location = new System.Drawing.Point(108, 72);
            this.cbeOldCDSAuthentication.Name = "cbeOldCDSAuthentication";
            this.cbeOldCDSAuthentication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeOldCDSAuthentication.Properties.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbeOldCDSAuthentication.Properties.ReadOnly = true;
            this.cbeOldCDSAuthentication.Size = new System.Drawing.Size(751, 22);
            this.cbeOldCDSAuthentication.StyleController = this.layoutControl7;
            this.cbeOldCDSAuthentication.TabIndex = 6;
            // 
            // txtOldCDSUsername
            // 
            this.txtOldCDSUsername.Location = new System.Drawing.Point(108, 124);
            this.txtOldCDSUsername.Name = "txtOldCDSUsername";
            this.txtOldCDSUsername.Properties.ReadOnly = true;
            this.txtOldCDSUsername.Size = new System.Drawing.Size(333, 22);
            this.txtOldCDSUsername.StyleController = this.layoutControl7;
            this.txtOldCDSUsername.TabIndex = 7;
            // 
            // txtOldCDSPassword
            // 
            this.txtOldCDSPassword.Location = new System.Drawing.Point(529, 124);
            this.txtOldCDSPassword.Name = "txtOldCDSPassword";
            this.txtOldCDSPassword.Properties.PasswordChar = '*';
            this.txtOldCDSPassword.Properties.ReadOnly = true;
            this.txtOldCDSPassword.Size = new System.Drawing.Size(330, 22);
            this.txtOldCDSPassword.StyleController = this.layoutControl7;
            this.txtOldCDSPassword.TabIndex = 8;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "layoutControlGroup6";
            this.layoutControlGroup6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup6.GroupBordersVisible = false;
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup9});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup6.Text = "layoutControlGroup6";
            this.layoutControlGroup6.TextVisible = false;
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.CustomizationFormText = "Connection";
            this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmImportServer,
            this.itmImportAuthentication,
            this.itmImportUsername,
            this.itmImportPassword,
            this.emptySpaceItem13,
            this.itmImportDatabase});
            this.layoutControlGroup9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.Size = new System.Drawing.Size(863, 498);
            this.layoutControlGroup9.Text = "Connection";
            // 
            // itmImportServer
            // 
            this.itmImportServer.Control = this.ddlOldCDSServer;
            this.itmImportServer.CustomizationFormText = "Server";
            this.itmImportServer.Location = new System.Drawing.Point(0, 0);
            this.itmImportServer.Name = "itmImportServer";
            this.itmImportServer.Size = new System.Drawing.Size(839, 26);
            this.itmImportServer.Text = "Server";
            this.itmImportServer.TextSize = new System.Drawing.Size(81, 16);
            // 
            // itmImportAuthentication
            // 
            this.itmImportAuthentication.Control = this.cbeOldCDSAuthentication;
            this.itmImportAuthentication.CustomizationFormText = "Authentication";
            this.itmImportAuthentication.Location = new System.Drawing.Point(0, 26);
            this.itmImportAuthentication.Name = "itmImportAuthentication";
            this.itmImportAuthentication.Size = new System.Drawing.Size(839, 26);
            this.itmImportAuthentication.Text = "Authentication";
            this.itmImportAuthentication.TextSize = new System.Drawing.Size(81, 16);
            // 
            // itmImportUsername
            // 
            this.itmImportUsername.Control = this.txtOldCDSUsername;
            this.itmImportUsername.CustomizationFormText = "Username";
            this.itmImportUsername.Location = new System.Drawing.Point(0, 78);
            this.itmImportUsername.Name = "itmImportUsername";
            this.itmImportUsername.Size = new System.Drawing.Size(421, 26);
            this.itmImportUsername.Text = "Username";
            this.itmImportUsername.TextSize = new System.Drawing.Size(81, 16);
            // 
            // itmImportPassword
            // 
            this.itmImportPassword.Control = this.txtOldCDSPassword;
            this.itmImportPassword.CustomizationFormText = "Password";
            this.itmImportPassword.Location = new System.Drawing.Point(421, 78);
            this.itmImportPassword.Name = "itmImportPassword";
            this.itmImportPassword.Size = new System.Drawing.Size(418, 26);
            this.itmImportPassword.Text = "Password";
            this.itmImportPassword.TextSize = new System.Drawing.Size(81, 16);
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem13.Location = new System.Drawing.Point(0, 104);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(839, 348);
            this.emptySpaceItem13.Text = "emptySpaceItem1";
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmImportDatabase
            // 
            this.itmImportDatabase.Control = this.txtOldCDSDatabase;
            this.itmImportDatabase.CustomizationFormText = "Database";
            this.itmImportDatabase.Location = new System.Drawing.Point(0, 52);
            this.itmImportDatabase.Name = "itmImportDatabase";
            this.itmImportDatabase.Size = new System.Drawing.Size(839, 26);
            this.itmImportDatabase.Text = "Database";
            this.itmImportDatabase.TextSize = new System.Drawing.Size(81, 16);
            // 
            // wpSetupUsers
            // 
            this.wpSetupUsers.Controls.Add(this.layoutControl8);
            this.wpSetupUsers.DescriptionText = "Here you can setup the users";
            this.wpSetupUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpSetupUsers.Name = "wpSetupUsers";
            this.wpSetupUsers.Size = new System.Drawing.Size(883, 518);
            this.wpSetupUsers.Text = "User Setup";
            // 
            // layoutControl8
            // 
            this.layoutControl8.Controls.Add(this.grdPerson);
            this.layoutControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl8.Location = new System.Drawing.Point(0, 0);
            this.layoutControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl8.Name = "layoutControl8";
            this.layoutControl8.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl8.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl8.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl8.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl8.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl8.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl8.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl8.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl8.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl8.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl8.Root = this.layoutControlGroup8;
            this.layoutControl8.Size = new System.Drawing.Size(883, 518);
            this.layoutControl8.TabIndex = 0;
            this.layoutControl8.Text = "layoutControl8";
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.CustomizationFormText = "layoutControlGroup8";
            this.layoutControlGroup8.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup8.GroupBordersVisible = false;
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmUsersGrid});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup8.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup8.Text = "layoutControlGroup8";
            this.layoutControlGroup8.TextVisible = false;
            // 
            // itmUsersGrid
            // 
            this.itmUsersGrid.Control = this.grdPerson;
            this.itmUsersGrid.CustomizationFormText = "itmUsersGrid";
            this.itmUsersGrid.Location = new System.Drawing.Point(0, 0);
            this.itmUsersGrid.Name = "itmUsersGrid";
            this.itmUsersGrid.Size = new System.Drawing.Size(883, 518);
            this.itmUsersGrid.Text = "itmUsersGrid";
            this.itmUsersGrid.TextSize = new System.Drawing.Size(0, 0);
            this.itmUsersGrid.TextVisible = false;
            // 
            // wpImportOldData
            // 
            this.wpImportOldData.Controls.Add(this.lcImportOldCDS);
            this.wpImportOldData.DescriptionText = "The system will now import all your transactions for the previous CDS";
            this.wpImportOldData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wpImportOldData.Name = "wpImportOldData";
            this.wpImportOldData.Size = new System.Drawing.Size(883, 518);
            this.wpImportOldData.Text = "Import CDS Data";
            // 
            // lcImportOldCDS
            // 
            this.lcImportOldCDS.Controls.Add(this.meConsoleErrors);
            this.lcImportOldCDS.Controls.Add(this.meConsole);
            this.lcImportOldCDS.Controls.Add(this.grdImportCDS);
            this.lcImportOldCDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcImportOldCDS.Location = new System.Drawing.Point(0, 0);
            this.lcImportOldCDS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lcImportOldCDS.Name = "lcImportOldCDS";
            this.lcImportOldCDS.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcImportOldCDS.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcImportOldCDS.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcImportOldCDS.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcImportOldCDS.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcImportOldCDS.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcImportOldCDS.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcImportOldCDS.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcImportOldCDS.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcImportOldCDS.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcImportOldCDS.Root = this.layoutControlGroup10;
            this.lcImportOldCDS.Size = new System.Drawing.Size(883, 518);
            this.lcImportOldCDS.TabIndex = 0;
            this.lcImportOldCDS.Text = "layoutControl9";
            // 
            // meConsoleErrors
            // 
            this.meConsoleErrors.Location = new System.Drawing.Point(458, 271);
            this.meConsoleErrors.Name = "meConsoleErrors";
            this.meConsoleErrors.Size = new System.Drawing.Size(401, 223);
            this.meConsoleErrors.StyleController = this.lcImportOldCDS;
            this.meConsoleErrors.TabIndex = 6;
            // 
            // meConsole
            // 
            this.meConsole.Location = new System.Drawing.Point(458, 46);
            this.meConsole.Name = "meConsole";
            this.meConsole.Size = new System.Drawing.Size(401, 221);
            this.meConsole.StyleController = this.lcImportOldCDS;
            this.meConsole.TabIndex = 5;
            // 
            // grdImportCDS
            // 
            this.grdImportCDS.DataSource = this.BindingSourceImportWork;
            this.grdImportCDS.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdImportCDS.Location = new System.Drawing.Point(12, 12);
            this.grdImportCDS.MainView = this.grvImportCDS;
            this.grdImportCDS.Name = "grdImportCDS";
            this.grdImportCDS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.imgState});
            this.grdImportCDS.Size = new System.Drawing.Size(430, 494);
            this.grdImportCDS.TabIndex = 4;
            this.grdImportCDS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvImportCDS});
            // 
            // BindingSourceImportWork
            // 
            this.BindingSourceImportWork.DataSource = typeof(CDS.Server.Installer.SQL.SQLWorkItem);
            // 
            // grvImportCDS
            // 
            this.grvImportCDS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImportWorkDescription,
            this.colRows,
            this.colImage});
            this.grvImportCDS.GridControl = this.grdImportCDS;
            this.grvImportCDS.Name = "grvImportCDS";
            this.grvImportCDS.OptionsView.ShowGroupPanel = false;
            // 
            // colImportWorkDescription
            // 
            this.colImportWorkDescription.FieldName = "Description";
            this.colImportWorkDescription.Name = "colImportWorkDescription";
            this.colImportWorkDescription.OptionsColumn.AllowEdit = false;
            this.colImportWorkDescription.OptionsColumn.AllowFocus = false;
            this.colImportWorkDescription.Visible = true;
            this.colImportWorkDescription.VisibleIndex = 0;
            this.colImportWorkDescription.Width = 511;
            // 
            // colRows
            // 
            this.colRows.Caption = "Rows Effected";
            this.colRows.FieldName = "Rows";
            this.colRows.Name = "colRows";
            this.colRows.OptionsColumn.AllowEdit = false;
            this.colRows.OptionsColumn.AllowFocus = false;
            this.colRows.Visible = true;
            this.colRows.VisibleIndex = 1;
            this.colRows.Width = 97;
            // 
            // colImage
            // 
            this.colImage.ColumnEdit = this.imgState;
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.OptionsColumn.AllowEdit = false;
            this.colImage.OptionsColumn.AllowFocus = false;
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 2;
            this.colImage.Width = 99;
            // 
            // imgState
            // 
            this.imgState.Name = "imgState";
            // 
            // layoutControlGroup10
            // 
            this.layoutControlGroup10.CustomizationFormText = "layoutControlGroup10";
            this.layoutControlGroup10.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup10.GroupBordersVisible = false;
            this.layoutControlGroup10.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmImportOldCDSGrid,
            this.lgcImportConsole});
            this.layoutControlGroup10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup10.Name = "layoutControlGroup10";
            this.layoutControlGroup10.Size = new System.Drawing.Size(883, 518);
            this.layoutControlGroup10.Text = "layoutControlGroup10";
            this.layoutControlGroup10.TextVisible = false;
            // 
            // itmImportOldCDSGrid
            // 
            this.itmImportOldCDSGrid.Control = this.grdImportCDS;
            this.itmImportOldCDSGrid.CustomizationFormText = "itmImportOldCDSGrid";
            this.itmImportOldCDSGrid.Location = new System.Drawing.Point(0, 0);
            this.itmImportOldCDSGrid.Name = "itmImportOldCDSGrid";
            this.itmImportOldCDSGrid.Size = new System.Drawing.Size(434, 498);
            this.itmImportOldCDSGrid.Text = "itmImportOldCDSGrid";
            this.itmImportOldCDSGrid.TextSize = new System.Drawing.Size(0, 0);
            this.itmImportOldCDSGrid.TextVisible = false;
            // 
            // lgcImportConsole
            // 
            this.lgcImportConsole.CustomizationFormText = "Import Console";
            this.lgcImportConsole.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem26,
            this.itmConsoleErrors});
            this.lgcImportConsole.Location = new System.Drawing.Point(434, 0);
            this.lgcImportConsole.Name = "lgcImportConsole";
            this.lgcImportConsole.Size = new System.Drawing.Size(429, 498);
            this.lgcImportConsole.Text = "Import Console";
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.meConsole;
            this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(405, 225);
            this.layoutControlItem26.Text = "layoutControlItem26";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // itmConsoleErrors
            // 
            this.itmConsoleErrors.Control = this.meConsoleErrors;
            this.itmConsoleErrors.CustomizationFormText = "itmConsoleErrors";
            this.itmConsoleErrors.Location = new System.Drawing.Point(0, 225);
            this.itmConsoleErrors.Name = "itmConsoleErrors";
            this.itmConsoleErrors.Size = new System.Drawing.Size(405, 227);
            this.itmConsoleErrors.Text = "itmConsoleErrors";
            this.itmConsoleErrors.TextSize = new System.Drawing.Size(0, 0);
            this.itmConsoleErrors.TextVisible = false;
            // 
            // ImageCollectionState
            // 
            this.ImageCollectionState.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollectionState.ImageStream")));
            this.ImageCollectionState.InsertGalleryImage("editdatasource_16x16.png", "images/data/editdatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/editdatasource_16x16.png"), 0);
            this.ImageCollectionState.Images.SetKeyName(0, "editdatasource_16x16.png");
            this.ImageCollectionState.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 1);
            this.ImageCollectionState.Images.SetKeyName(1, "apply_16x16.png");
            this.ImageCollectionState.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 2);
            this.ImageCollectionState.Images.SetKeyName(2, "cancel_16x16.png");
            // 
            // txtUpdateURL
            // 
            this.txtUpdateURL.Location = new System.Drawing.Point(124, 28);
            this.txtUpdateURL.Name = "txtUpdateURL";
            this.txtUpdateURL.Size = new System.Drawing.Size(757, 22);
            this.txtUpdateURL.StyleController = this.layoutControl2;
            this.txtUpdateURL.TabIndex = 9;
            // 
            // itmUpdateURL
            // 
            this.itmUpdateURL.Control = this.txtUpdateURL;
            this.itmUpdateURL.CustomizationFormText = "Update URL";
            this.itmUpdateURL.Location = new System.Drawing.Point(0, 26);
            this.itmUpdateURL.Name = "itmUpdateURL";
            this.itmUpdateURL.Size = new System.Drawing.Size(883, 26);
            this.itmUpdateURL.Text = "Update URL";
            this.itmUpdateURL.TextSize = new System.Drawing.Size(119, 16);
            // 
            // txtClientZipLocation
            // 
            this.txtClientZipLocation.Location = new System.Drawing.Point(124, 54);
            this.txtClientZipLocation.Name = "txtClientZipLocation";
            this.txtClientZipLocation.Size = new System.Drawing.Size(757, 22);
            this.txtClientZipLocation.StyleController = this.layoutControl2;
            this.txtClientZipLocation.TabIndex = 10;
            // 
            // itmClientZipLocation
            // 
            this.itmClientZipLocation.Control = this.txtClientZipLocation;
            this.itmClientZipLocation.CustomizationFormText = "Client Zip Location";
            this.itmClientZipLocation.Location = new System.Drawing.Point(0, 52);
            this.itmClientZipLocation.Name = "itmClientZipLocation";
            this.itmClientZipLocation.Size = new System.Drawing.Size(883, 26);
            this.itmClientZipLocation.Text = "Client Zip Location";
            this.itmClientZipLocation.TextSize = new System.Drawing.Size(119, 16);
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 690);
            this.ControlBox = false;
            this.Controls.Add(this.wcInstaller);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InstallerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDS - Complete Distribution System";
            this.Load += new System.EventHandler(this.InstallerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSAPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSQLInstallation)).EndInit();
            this.lcSQLInstallation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meAdministratorsMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSQLServerAdministrators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSQLServerAdministrators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSQLServerAdministrators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSAPassworkConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAuthenticationMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgInstanceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstanceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgServerConfiguration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmInstanceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmInstanceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAuthenticationMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSAAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSAPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSAPasswordConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSQLServerAdministrators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAdministratorsMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcuAdministratorUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEmailAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRegistrationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colVatPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colVatNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCashierRefreshIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSMTPServerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailDomain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAccountEmailBCCAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailDomain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDocumentEmailBCCAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colProxyServerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colProxyServerUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colProxyServerPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrintServerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBankAccountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDefaultMessageDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDefaultMessageStatement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrinterBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrinterPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPrinterReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUpdateURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMinimizeNavigation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUpdateCheckTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPaymentAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUseBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUseLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCopyInvoiceOrderNumbertoCreditNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAutoWriteoffOpenItemCredits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNegativeDiscountEffects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNotifyonZeroMarkupSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNotifyonZeroProfitSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colQuoteValidDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colQuoteValidMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRoundingAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCashierPaymentsFullAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCODAccountLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDebtorGracePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDefaultInterestCharged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMonthWeight36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFixedOrderCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMaxOrderLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSafetyStockPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDistributionNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colBackupLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNotifyonBackOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRoleView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcInstaller)).EndInit();
            this.wcInstaller.ResumeLayout(false);
            this.wpConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyConnectionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDatabase)).EndInit();
            this.wpSiteSetup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintServerLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPrintServerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSiteGrid)).EndInit();
            this.wpSqlSetupOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            this.wpSqlInstall.ResumeLayout(false);
            this.wpDataDirectories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).EndInit();
            this.layoutControl4.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl5)).EndInit();
            this.layoutControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseNameMasked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceDefaultDirectory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceMainData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceMainLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceAutomaticOrdering.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceCalendar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceCatalogue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceLedger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceHumanResources.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItemBuyout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItemBOM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceItemDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceOrganisation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceOrganisationTransactions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSecurity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSystemDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bceSystemMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDatabaseFileLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDefaultDirectory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabaseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabaseNameMasked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDataDirectories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            this.wpNewOrImport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl6)).EndInit();
            this.layoutControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            this.wpImportConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).EndInit();
            this.layoutControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOldCDSDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOldCDSServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeOldCDSAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldCDSUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldCDSPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportDatabase)).EndInit();
            this.wpSetupUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl8)).EndInit();
            this.layoutControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsersGrid)).EndInit();
            this.wpImportOldData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcImportOldCDS)).EndInit();
            this.lcImportOldCDS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meConsoleErrors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meConsole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImportCDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceImportWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImportCDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImportOldCDSGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgcImportConsole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmConsoleErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateURL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUpdateURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientZipLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClientZipLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wcInstaller;
        private DevExpress.XtraWizard.WelcomeWizardPage wpWelcome;
        private DevExpress.XtraWizard.WizardPage wpConnection;
        private DevExpress.XtraWizard.CompletionWizardPage wpComplete;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtCompanyConnectionName;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCompany;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgConnection;
        private DevExpress.XtraEditors.ComboBoxEdit ddlServer;
        private DevExpress.XtraLayout.LayoutControlItem itmServer;
        private DevExpress.XtraEditors.ComboBoxEdit cbeAuthentication;
        private DevExpress.XtraLayout.LayoutControlItem itmAuthentication;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraLayout.LayoutControlItem itmUsername;
        private DevExpress.XtraLayout.LayoutControlItem itmPassword;
        private DevExpress.XtraEditors.SpinEdit txtTimeout;
        private DevExpress.XtraLayout.LayoutControlItem itmTimeout;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraWizard.WizardPage wpSiteSetup;
        private System.Windows.Forms.BindingSource BindingSourceEntity;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.TextEdit txtPrintServerLocation;
        private DevExpress.XtraLayout.LayoutControlItem itmPrintServerLocation;
        private DevExpress.XtraWizard.WizardPage wpSqlSetupOption;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraEditors.CheckButton btnInstallSQLExpress;
        private DevExpress.XtraEditors.CheckButton btnChooseSql;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraWizard.WizardPage wpSqlInstall;
        private DevExpress.XtraLayout.LayoutControl lcSQLInstallation;
        private DevExpress.XtraEditors.TextEdit txtInstanceName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.RadioGroup rgInstanceType;
        private DevExpress.XtraEditors.MemoEdit meAdministratorsMemo;
        private DevExpress.XtraGrid.GridControl gcSQLServerAdministrators;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSQLServerAdministrators;
        private DevExpress.XtraEditors.TextEdit txtSAPassworkConfirm;
        private DevExpress.XtraEditors.TextEdit txtSAPassword;
        private DevExpress.XtraEditors.RadioGroup rgAuthenticationMode;
        private System.Windows.Forms.BindingSource BindingSourceSQLServerAdministrators;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repPassword;
        private DevExpress.XtraWizard.WizardPage wpDataDirectories;
        private DevExpress.XtraLayout.LayoutControl layoutControl4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl5;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDatabaseFileLocations;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem lciDefaultDirectory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDataDirectories;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.TextEdit txtDatabaseNameMasked;
        private DevExpress.XtraEditors.TextEdit txtDatabaseName;
        private DevExpress.XtraLayout.LayoutControlItem lciDatabaseName;
        private DevExpress.XtraLayout.LayoutControlItem lciDatabaseNameMasked;
        private DevExpress.XtraLayout.LayoutControlGroup lcgServerConfiguration;
        private DevExpress.XtraLayout.LayoutControlItem itmInstanceName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.LayoutControlItem itmInstanceType;
        private DevExpress.XtraLayout.LayoutControlGroup lcgAuthentication;
        private DevExpress.XtraLayout.LayoutControlItem itmAuthenticationMode;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSAAccount;
        private DevExpress.XtraLayout.LayoutControlItem lciSAPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciSAPasswordConfirm;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSQLServerAdministrators;
        private DevExpress.XtraLayout.LayoutControlItem lciAdministratorsMemo;
        private DevExpress.XtraLayout.LayoutControlItem lcuAdministratorUsers;
        private DevExpress.XtraEditors.BreadCrumbEdit bceDefaultDirectory;
        private DevExpress.XtraEditors.BreadCrumbEdit bceMainData;
        private DevExpress.XtraEditors.BreadCrumbEdit bceMainLog;
        private DevExpress.XtraEditors.BreadCrumbEdit bceAutomaticOrdering;
        private DevExpress.XtraEditors.BreadCrumbEdit bceCalendar;
        private DevExpress.XtraEditors.BreadCrumbEdit bceCatalogue;
        private DevExpress.XtraEditors.BreadCrumbEdit bceLedger;
        private DevExpress.XtraEditors.BreadCrumbEdit bceHumanResources;
        private DevExpress.XtraEditors.BreadCrumbEdit bceItemBuyout;
        private DevExpress.XtraEditors.BreadCrumbEdit bceIndex;
        private DevExpress.XtraEditors.BreadCrumbEdit bceItem;
        private DevExpress.XtraEditors.BreadCrumbEdit bceItemBOM;
        private DevExpress.XtraEditors.BreadCrumbEdit bceItemDiscount;
        private DevExpress.XtraEditors.BreadCrumbEdit bceJob;
        private DevExpress.XtraEditors.BreadCrumbEdit bceOrganisation;
        private DevExpress.XtraEditors.BreadCrumbEdit bceOrganisationTransactions;
        private DevExpress.XtraEditors.BreadCrumbEdit bceReport;
        private DevExpress.XtraEditors.BreadCrumbEdit bceSecurity;
        private DevExpress.XtraEditors.BreadCrumbEdit bceSystem;
        private DevExpress.XtraEditors.BreadCrumbEdit bceSystemDocument;
        private DevExpress.XtraEditors.BreadCrumbEdit bceSystemMessage;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ValidationProvider;
        private DevExpress.XtraGrid.GridControl grdEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEntity;
        private DevExpress.XtraLayout.LayoutControlItem itmSiteGrid;
        private DevExpress.XtraWizard.WizardPage wpNewOrImport;
        private DevExpress.XtraLayout.LayoutControl layoutControl6;
        private DevExpress.XtraEditors.CheckButton btnNewCompany;
        private DevExpress.XtraEditors.CheckButton btnImportCDS;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraWizard.WizardPage wpImportConnection;
        private DevExpress.XtraLayout.LayoutControl layoutControl7;
        private DevExpress.XtraEditors.ComboBoxEdit ddlOldCDSServer;
        private DevExpress.XtraEditors.ComboBoxEdit cbeOldCDSAuthentication;
        private DevExpress.XtraEditors.TextEdit txtOldCDSUsername;
        private DevExpress.XtraEditors.TextEdit txtOldCDSPassword;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraLayout.LayoutControlItem itmImportServer;
        private DevExpress.XtraLayout.LayoutControlItem itmImportAuthentication;
        private DevExpress.XtraLayout.LayoutControlItem itmImportUsername;
        private DevExpress.XtraLayout.LayoutControlItem itmImportPassword;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraEditors.TextEdit txtOldCDSDatabase;
        private DevExpress.XtraLayout.LayoutControlItem itmImportDatabase;
        private DevExpress.XtraWizard.WizardPage wpSetupUsers;
        private DevExpress.XtraLayout.LayoutControl layoutControl8;
        private DevExpress.XtraGrid.GridControl grdPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPerson;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlItem itmUsersGrid;
        private System.Windows.Forms.BindingSource BindingSourcePerson;
        private DevExpress.XtraGrid.Views.Layout.LayoutView lvUser;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSub;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colArchived;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle1;
        private DevExpress.XtraGrid.Columns.GridColumn colLine1;
        private DevExpress.XtraGrid.Columns.GridColumn colLine2;
        private DevExpress.XtraGrid.Columns.GridColumn colLine3;
        private DevExpress.XtraGrid.Columns.GridColumn colLine4;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Views.Layout.LayoutView lvSite;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colTelephone;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colTelephone;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colEmailAddress;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colEmailAddress;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colRegistrationNumber;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colRegistrationNumber;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colVatPercentage;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colVatPercentage;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colVatNumber;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colVatNumber;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCurrency;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCurrency;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCashierRefreshIntervals;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCashierRefreshIntervals;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colSMTPServerLocation;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colSMTPServerLocation;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colAccountEmailAddress;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAccountEmailAddress;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colAccountEmailUsername;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAccountEmailUsername;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colAccountEmailPassword;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAccountEmailPassword;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colAccountEmailDomain;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAccountEmailDomain;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colAccountEmailBCCAddress;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAccountEmailBCCAddress;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDocumentEmailAddress;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDocumentEmailAddress;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDocumentEmailUsername;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDocumentEmailUsername;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDocumentEmailPassword;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDocumentEmailPassword;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDocumentEmailDomain;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDocumentEmailDomain;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDocumentEmailBCCAddress;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDocumentEmailBCCAddress;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colProxyServerLocation;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colProxyServerLocation;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colProxyServerUsername;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colProxyServerUsername;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colProxyServerPassword;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colProxyServerPassword;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPrintServerLocation;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPrintServerLocation;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colBankName;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colBankName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colBankBranch;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colBankBranch;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colBankCode;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colBankCode;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colBankAccountNumber;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colBankAccountNumber;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDefaultMessageDocument;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDefaultMessageDocument;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDefaultMessageStatement;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDefaultMessageStatement;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPrinterBarcode;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPrinterBarcode;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPrinterPicker;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPrinterPicker;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPrinterReceipt;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPrinterReceipt;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colUpdateURL;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colUpdateURL;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMinimizeNavigation;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMinimizeNavigation;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colUpdateCheckTime;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colUpdateCheckTime;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPaymentAccounts;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPaymentAccounts;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colUseBarcodes;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colUseBarcodes;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colUseLabels;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colUseLabels;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCopyInvoiceOrderNumbertoCreditNote;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCopyInvoiceOrderNumbertoCreditNote;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colAutoWriteoffOpenItemCredits;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAutoWriteoffOpenItemCredits;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNegativeDiscountEffects;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNegativeDiscountEffects;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNotifyonZeroMarkupSale;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNotifyonZeroMarkupSale;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNotifyonZeroProfitSale;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNotifyonZeroProfitSale;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colQuoteValidDays;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colQuoteValidDays;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colQuoteValidMax;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colQuoteValidMax;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colRoundingAmount;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colRoundingAmount;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCashierPaymentsFullAmount;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCashierPaymentsFullAmount;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colCODAccountLimit;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCODAccountLimit;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDebtorGracePeriod;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDebtorGracePeriod;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDefaultInterestCharged;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDefaultInterestCharged;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMonthWeight3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMonthWeight3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMonthWeight6;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMonthWeight6;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMonthWeight12;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMonthWeight12;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMonthWeight24;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMonthWeight24;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMonthWeight36;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMonthWeight36;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colFixedOrderCost;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colFixedOrderCost;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMaxOrderLines;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMaxOrderLines;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colSafetyStockPeriod;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colSafetyStockPeriod;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDistributionNumber;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDistributionNumber;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colBackupLocation;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colBackupLocation;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNotifyonBackOrder;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNotifyonBackOrder;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.EmptySpaceItem item1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUser;
        private DevExpress.XtraGrid.Columns.GridColumn colImportName;
        private DevExpress.XtraGrid.Columns.GridColumn colImportSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colImportArchived;
        private DevExpress.XtraGrid.Columns.GridColumn colImportUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colImportPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colImportDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountLimit;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceRoles;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit ddlRole;
        private DevExpress.XtraGrid.Views.Grid.GridView ddlRoleView;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleName;
        private DevExpress.XtraWizard.WizardPage wpImportOldData;
        private DevExpress.XtraLayout.LayoutControl lcImportOldCDS;
        private DevExpress.XtraGrid.GridControl grdImportCDS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvImportCDS;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup10;
        private DevExpress.XtraLayout.LayoutControlItem itmImportOldCDSGrid;
        private System.Windows.Forms.BindingSource BindingSourceImportWork;
        private DevExpress.XtraGrid.Columns.GridColumn colImportWorkDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colRows;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.Utils.ImageCollection ImageCollectionState;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit imgState;
        private DevExpress.XtraEditors.MemoEdit meConsole;
        private DevExpress.XtraLayout.LayoutControlGroup lgcImportConsole;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraEditors.MemoEdit meConsoleErrors;
        private DevExpress.XtraLayout.LayoutControlItem itmConsoleErrors;
        private DevExpress.XtraEditors.CheckButton btnImportChimera;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
        private DevExpress.XtraLayout.LayoutControlItem itmDatabase;
        private DevExpress.XtraEditors.TextEdit txtClientZipLocation;
        private DevExpress.XtraEditors.TextEdit txtUpdateURL;
        private DevExpress.XtraLayout.LayoutControlItem itmUpdateURL;
        private DevExpress.XtraLayout.LayoutControlItem itmClientZipLocation;
        private DevExpress.XtraSplashScreen.SplashScreenManager SplashManager;
    }
}