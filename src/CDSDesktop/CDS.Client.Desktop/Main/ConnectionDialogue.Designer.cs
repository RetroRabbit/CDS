namespace CDS.Client.Desktop.Main
{
    partial class ConnectionDialogue
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDialogue));
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.ddlServer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ddlDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnDiagnose = new DevExpress.XtraEditors.SimpleButton();
            this.ddlAuthentication = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmServer = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmAccept = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmDiagnose = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmAuthentication = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmUsername = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlCompany = new DevExpress.XtraLayout.LayoutControlGroup();
            this.pnlConnection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmTimeout = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTimeout = new DevExpress.XtraEditors.SpinEdit();
            this.itmDatabaseFile = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnDBFileLocation = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkUpdateLocation = new DevExpress.XtraEditors.CheckEdit();
            this.databaseFileLocation = new System.Windows.Forms.OpenFileDialog();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.SplashManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::CDS.Client.Desktop.Main.WaitPopup), true, true);
            this.itmProvider = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDiagnose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDatabaseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDBFileLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdateLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.chkUpdateLocation);
            this.LayoutControl.Controls.Add(this.btnDBFileLocation);
            this.LayoutControl.Controls.Add(this.txtTimeout);
            this.LayoutControl.Controls.Add(this.ddlDatabase);
            this.LayoutControl.Controls.Add(this.txtPassword);
            this.LayoutControl.Controls.Add(this.txtUsername);
            this.LayoutControl.Controls.Add(this.btnAccept);
            this.LayoutControl.Controls.Add(this.btnDiagnose);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.ddlAuthentication);
            this.LayoutControl.Controls.Add(this.ddlServer);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(788, 57, 250, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(394, 336);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pnlCompany,
            this.pnlConnection});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(394, 336);
            this.LayoutGroup.Text = "Root";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(284, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 4;
            conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule6.ErrorText = "Enter name ...";
            conditionValidationRule6.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.txtName, conditionValidationRule6);
            // 
            // ddlServer
            // 
            this.ddlServer.Location = new System.Drawing.Point(92, 104);
            this.ddlServer.Name = "ddlServer";
            this.ddlServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlServer.Size = new System.Drawing.Size(284, 20);
            this.ddlServer.StyleController = this.LayoutControl;
            this.ddlServer.TabIndex = 5;
            this.ddlServer.ToolTip = "Enter Server Instance location\r\nYou can click the button on the right to search f" +
    "or instances on the network";
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "Select server ...";
            conditionValidationRule5.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.ddlServer, conditionValidationRule5);
            this.ddlServer.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ddlServer_ButtonPressed);
            // 
            // ddlDatabase
            // 
            this.ddlDatabase.Location = new System.Drawing.Point(92, 200);
            this.ddlDatabase.Name = "ddlDatabase";
            this.ddlDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlDatabase.Size = new System.Drawing.Size(284, 20);
            this.ddlDatabase.StyleController = this.LayoutControl;
            this.ddlDatabase.TabIndex = 9;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Select database ...";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.ddlDatabase, conditionValidationRule1);
            this.ddlDatabase.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ddlDatabase_ButtonPressed);
            this.ddlDatabase.EditValueChanged += new System.EventHandler(this.ddlDatabase_EditValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 295);
            this.btnCancel.MaximumSize = new System.Drawing.Size(82, 0);
            this.btnCancel.MinimumSize = new System.Drawing.Size(82, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(208, 295);
            this.btnAccept.MaximumSize = new System.Drawing.Size(82, 0);
            this.btnAccept.MinimumSize = new System.Drawing.Size(82, 0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(82, 22);
            this.btnAccept.StyleController = this.LayoutControl;
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDiagnose
            // 
            this.btnDiagnose.Location = new System.Drawing.Point(122, 295);
            this.btnDiagnose.MaximumSize = new System.Drawing.Size(82, 0);
            this.btnDiagnose.MinimumSize = new System.Drawing.Size(82, 0);
            this.btnDiagnose.Name = "btnDiagnose";
            this.btnDiagnose.Size = new System.Drawing.Size(82, 22);
            this.btnDiagnose.StyleController = this.LayoutControl;
            this.btnDiagnose.TabIndex = 12;
            this.btnDiagnose.Text = "&Diagnose";
            this.btnDiagnose.Click += new System.EventHandler(this.btnDiagnose_Click);
            // 
            // ddlAuthentication
            // 
            this.ddlAuthentication.EditValue = "SQL Server Authentication";
            this.ddlAuthentication.Location = new System.Drawing.Point(92, 128);
            this.ddlAuthentication.Name = "ddlAuthentication";
            this.ddlAuthentication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAuthentication.Properties.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.ddlAuthentication.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ddlAuthentication.Size = new System.Drawing.Size(284, 20);
            this.ddlAuthentication.StyleController = this.LayoutControl;
            this.ddlAuthentication.TabIndex = 6;
            this.ddlAuthentication.ToolTip = "Select the authentication type for you server";
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Select authentication ...";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.ddlAuthentication, conditionValidationRule4);
            this.ddlAuthentication.EditValueChanged += new System.EventHandler(this.ddlAuthentication_EditValueChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(92, 152);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(284, 20);
            this.txtUsername.StyleController = this.LayoutControl;
            this.txtUsername.TabIndex = 7;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Enter username ...";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.txtUsername, conditionValidationRule3);
            this.txtUsername.EnabledChanged += new System.EventHandler(this.txtUsername_EnabledChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(92, 176);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(284, 20);
            this.txtPassword.StyleController = this.LayoutControl;
            this.txtPassword.TabIndex = 8;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Enter password ...";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.txtPassword, conditionValidationRule2);
            this.txtPassword.EnabledChanged += new System.EventHandler(this.txtPassword_EnabledChanged);
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 0);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(362, 24);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(70, 13);
            // 
            // itmServer
            // 
            this.itmServer.Control = this.ddlServer;
            this.itmServer.CustomizationFormText = "Server";
            this.itmServer.Location = new System.Drawing.Point(0, 0);
            this.itmServer.Name = "itmServer";
            this.itmServer.Size = new System.Drawing.Size(362, 24);
            this.itmServer.Text = "Server";
            this.itmServer.TextSize = new System.Drawing.Size(70, 13);
            // 
            // itmDatabase
            // 
            this.itmDatabase.Control = this.ddlDatabase;
            this.itmDatabase.CustomizationFormText = "Database";
            this.itmDatabase.Location = new System.Drawing.Point(0, 96);
            this.itmDatabase.Name = "itmDatabase";
            this.itmDatabase.Size = new System.Drawing.Size(362, 24);
            this.itmDatabase.Text = "Database";
            this.itmDatabase.TextSize = new System.Drawing.Size(70, 13);
            // 
            // itmCancel
            // 
            this.itmCancel.Control = this.btnCancel;
            this.itmCancel.CustomizationFormText = "Cancel";
            this.itmCancel.Location = new System.Drawing.Point(276, 191);
            this.itmCancel.Name = "itmCancel";
            this.itmCancel.Size = new System.Drawing.Size(86, 27);
            this.itmCancel.Text = "Cancel";
            this.itmCancel.TextSize = new System.Drawing.Size(0, 0);
            this.itmCancel.TextVisible = false;
            // 
            // itmAccept
            // 
            this.itmAccept.Control = this.btnAccept;
            this.itmAccept.CustomizationFormText = "Accept";
            this.itmAccept.Location = new System.Drawing.Point(190, 191);
            this.itmAccept.Name = "itmAccept";
            this.itmAccept.Size = new System.Drawing.Size(86, 27);
            this.itmAccept.Text = "Accept";
            this.itmAccept.TextSize = new System.Drawing.Size(0, 0);
            this.itmAccept.TextVisible = false;
            // 
            // itmDiagnose
            // 
            this.itmDiagnose.Control = this.btnDiagnose;
            this.itmDiagnose.CustomizationFormText = "Diagnose";
            this.itmDiagnose.Location = new System.Drawing.Point(104, 191);
            this.itmDiagnose.Name = "itmDiagnose";
            this.itmDiagnose.Size = new System.Drawing.Size(86, 27);
            this.itmDiagnose.Text = "Diagnose";
            this.itmDiagnose.TextSize = new System.Drawing.Size(0, 0);
            this.itmDiagnose.TextVisible = false;
            // 
            // itmAuthentication
            // 
            this.itmAuthentication.Control = this.ddlAuthentication;
            this.itmAuthentication.CustomizationFormText = "Authentication";
            this.itmAuthentication.Location = new System.Drawing.Point(0, 24);
            this.itmAuthentication.Name = "itmAuthentication";
            this.itmAuthentication.Size = new System.Drawing.Size(362, 24);
            this.itmAuthentication.Text = "Authentication";
            this.itmAuthentication.TextSize = new System.Drawing.Size(70, 13);
            // 
            // itmUsername
            // 
            this.itmUsername.Control = this.txtUsername;
            this.itmUsername.CustomizationFormText = "Username";
            this.itmUsername.Location = new System.Drawing.Point(0, 48);
            this.itmUsername.Name = "itmUsername";
            this.itmUsername.Size = new System.Drawing.Size(362, 24);
            this.itmUsername.Text = "Username";
            this.itmUsername.TextSize = new System.Drawing.Size(70, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 191);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(104, 27);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmPassword
            // 
            this.itmPassword.Control = this.txtPassword;
            this.itmPassword.CustomizationFormText = "Password";
            this.itmPassword.Location = new System.Drawing.Point(0, 72);
            this.itmPassword.Name = "itmPassword";
            this.itmPassword.Size = new System.Drawing.Size(362, 24);
            this.itmPassword.Text = "Password";
            this.itmPassword.TextSize = new System.Drawing.Size(70, 13);
            // 
            // pnlCompany
            // 
            this.pnlCompany.CustomizationFormText = "Company";
            this.pnlCompany.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmName});
            this.pnlCompany.Location = new System.Drawing.Point(0, 0);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(386, 67);
            this.pnlCompany.Text = "Company";
            // 
            // pnlConnection
            // 
            this.pnlConnection.CustomizationFormText = "Connection";
            this.pnlConnection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.itmCancel,
            this.itmDatabase,
            this.itmUsername,
            this.itmAuthentication,
            this.itmServer,
            this.itmTimeout,
            this.itmAccept,
            this.itmDiagnose,
            this.itmDatabaseFile,
            this.itmPassword,
            this.layoutControlItem1});
            this.pnlConnection.Location = new System.Drawing.Point(0, 67);
            this.pnlConnection.Name = "pnlConnection";
            this.pnlConnection.Size = new System.Drawing.Size(386, 261);
            this.pnlConnection.Text = "Connection";
            // 
            // itmTimeout
            // 
            this.itmTimeout.Control = this.txtTimeout;
            this.itmTimeout.CustomizationFormText = "Timeout";
            this.itmTimeout.Location = new System.Drawing.Point(0, 144);
            this.itmTimeout.Name = "itmTimeout";
            this.itmTimeout.Size = new System.Drawing.Size(362, 24);
            this.itmTimeout.Text = "Timeout";
            this.itmTimeout.TextSize = new System.Drawing.Size(70, 13);
            // 
            // txtTimeout
            // 
            this.txtTimeout.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTimeout.Location = new System.Drawing.Point(92, 248);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtTimeout.Properties.DisplayFormat.FormatString = "0 second(s)";
            this.txtTimeout.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtTimeout.Properties.MaxValue = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.txtTimeout.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTimeout.Size = new System.Drawing.Size(284, 20);
            this.txtTimeout.StyleController = this.LayoutControl;
            this.txtTimeout.TabIndex = 13;
            this.txtTimeout.ToolTip = "This sets how long CDS will wait for a connection to the database before givving " +
    "a timout error";
            // 
            // itmDatabaseFile
            // 
            this.itmDatabaseFile.Control = this.btnDBFileLocation;
            this.itmDatabaseFile.CustomizationFormText = "Database file";
            this.itmDatabaseFile.Location = new System.Drawing.Point(0, 120);
            this.itmDatabaseFile.Name = "itmDatabaseFile";
            this.itmDatabaseFile.Size = new System.Drawing.Size(362, 24);
            this.itmDatabaseFile.Text = "Database file";
            this.itmDatabaseFile.TextSize = new System.Drawing.Size(70, 13);
            // 
            // btnDBFileLocation
            // 
            this.btnDBFileLocation.Location = new System.Drawing.Point(92, 224);
            this.btnDBFileLocation.Name = "btnDBFileLocation";
            this.btnDBFileLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDBFileLocation.Size = new System.Drawing.Size(284, 20);
            this.btnDBFileLocation.StyleController = this.LayoutControl;
            this.btnDBFileLocation.TabIndex = 14;
            this.btnDBFileLocation.ToolTip = "If you are running an single user instance select the database file";
            this.btnDBFileLocation.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnDBFileLocation_ButtonClick);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkUpdateLocation;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(362, 23);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // chkUpdateLocation
            // 
            this.chkUpdateLocation.Location = new System.Drawing.Point(18, 272);
            this.chkUpdateLocation.Name = "chkUpdateLocation";
            this.chkUpdateLocation.Properties.Caption = "Default Update Site";
            this.chkUpdateLocation.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkUpdateLocation.Size = new System.Drawing.Size(358, 19);
            this.chkUpdateLocation.StyleController = this.LayoutControl;
            this.chkUpdateLocation.TabIndex = 15;
            this.chkUpdateLocation.ToolTip = "This sets you default update site.\r\nUpdates will be downloaded from the selected " +
    "site";
            this.chkUpdateLocation.CheckedChanged += new System.EventHandler(this.chkUpdateLocation_CheckedChanged);
            // 
            // databaseFileLocation
            // 
            this.databaseFileLocation.Filter = "MDF File (*.mdf)|*.mdf";
            this.databaseFileLocation.InitialDirectory = "C:\\CDSData";
            // 
            // itmProvider
            // 
            this.itmProvider.Control = this.ddlServer;
            this.itmProvider.CustomizationFormText = "Server";
            this.itmProvider.Location = new System.Drawing.Point(0, 0);
            this.itmProvider.Name = "itmServer";
            this.itmProvider.Size = new System.Drawing.Size(391, 24);
            this.itmProvider.Text = "Server";
            this.itmProvider.TextSize = new System.Drawing.Size(70, 13);
            // 
            // ConnectionDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(404, 390);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectionDialogue";
            this.TabHeading = "Company Connections allow you to modify the server access settings of existing co" +
    "nnections or to create new connections to new or existing databases";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.Text = "Company Connection";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDiagnose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDatabaseFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDBFileLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdateLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.ComboBoxEdit ddlServer;
        private DevExpress.XtraEditors.ComboBoxEdit ddlAuthentication;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.ComboBoxEdit ddlDatabase;
        private DevExpress.XtraEditors.SimpleButton btnDiagnose;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlGroup pnlCompany;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlGroup pnlConnection;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem itmAccept;
        private DevExpress.XtraLayout.LayoutControlItem itmDiagnose;
        private DevExpress.XtraLayout.LayoutControlItem itmCancel;
        private DevExpress.XtraLayout.LayoutControlItem itmDatabase;
        private DevExpress.XtraLayout.LayoutControlItem itmPassword;
        private DevExpress.XtraLayout.LayoutControlItem itmUsername;
        private DevExpress.XtraLayout.LayoutControlItem itmAuthentication;
        private DevExpress.XtraLayout.LayoutControlItem itmServer;
        private DevExpress.XtraEditors.SpinEdit txtTimeout;
        private DevExpress.XtraLayout.LayoutControlItem itmTimeout;
        private DevExpress.XtraEditors.ButtonEdit btnDBFileLocation;
        private DevExpress.XtraLayout.LayoutControlItem itmDatabaseFile;
        private System.Windows.Forms.OpenFileDialog databaseFileLocation;
        private DevExpress.XtraEditors.CheckEdit chkUpdateLocation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraLayout.LayoutControlItem itmProvider;
        private DevExpress.XtraSplashScreen.SplashScreenManager SplashManager;
    }
}
