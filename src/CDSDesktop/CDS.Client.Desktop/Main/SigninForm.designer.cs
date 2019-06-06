namespace CDS.Client.Desktop.Main
{
    partial class SigninForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SigninForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSignin = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdCompany = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceCompany = new System.Windows.Forms.BindingSource(this.components);
            this.grvCompany = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imgStatus = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barItemText = new DevExpress.XtraBars.BarStaticItem();
            this.barItemProgress = new DevExpress.XtraBars.BarEditItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnDiagnose = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.MRUEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(311, 83);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(60, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(311, 54);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(311, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 23);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // imageCollectionSmall
            // 
            this.imageCollectionSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionSmall.ImageStream")));
            this.imageCollectionSmall.InsertImage(global::CDS.Client.Desktop.Properties.Resources.data_blue, "data_blue", typeof(global::CDS.Client.Desktop.Properties.Resources), 0);
            this.imageCollectionSmall.Images.SetKeyName(0, "data_blue");
            this.imageCollectionSmall.InsertImage(global::CDS.Client.Desktop.Properties.Resources.data_green, "data_green", typeof(global::CDS.Client.Desktop.Properties.Resources), 1);
            this.imageCollectionSmall.Images.SetKeyName(1, "data_green");
            this.imageCollectionSmall.InsertImage(global::CDS.Client.Desktop.Properties.Resources.data_red, "data_red", typeof(global::CDS.Client.Desktop.Properties.Resources), 2);
            this.imageCollectionSmall.Images.SetKeyName(2, "data_red");
            this.imageCollectionSmall.InsertImage(global::CDS.Client.Desktop.Properties.Resources.data_yellow, "data_yellow", typeof(global::CDS.Client.Desktop.Properties.Resources), 3);
            this.imageCollectionSmall.Images.SetKeyName(3, "data_yellow");
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(306, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSignin
            // 
            this.btnSignin.Location = new System.Drawing.Point(218, 362);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(82, 23);
            this.btnSignin.TabIndex = 4;
            this.btnSignin.Text = "Sign in";
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdCompany);
            this.groupControl1.Controls.Add(this.btnDiagnose);
            this.groupControl1.Controls.Add(this.btnRemove);
            this.groupControl1.Controls.Add(this.btnEdit);
            this.groupControl1.Controls.Add(this.btnNew);
            this.groupControl1.Location = new System.Drawing.Point(12, 216);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(376, 140);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Companies";
            // 
            // grdCompany
            // 
            this.grdCompany.DataSource = this.BindingSourceCompany;
            this.grdCompany.Location = new System.Drawing.Point(5, 24);
            this.grdCompany.MainView = this.grvCompany;
            this.grdCompany.MenuManager = this.barManager;
            this.grdCompany.Name = "grdCompany";
            this.grdCompany.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.imgStatus});
            this.grdCompany.Size = new System.Drawing.Size(300, 111);
            this.grdCompany.TabIndex = 4;
            this.grdCompany.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCompany});
            // 
            // BindingSourceCompany
            // 
            this.BindingSourceCompany.DataSource = typeof(CDS.Client.Desktop.Main.CompanyConnection);
            // 
            // grvCompany
            // 
            this.grvCompany.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImage,
            this.colCompany,
            this.colVersion});
            this.grvCompany.GridControl = this.grdCompany;
            this.grvCompany.Name = "grvCompany";
            this.grvCompany.OptionsCustomization.AllowFilter = false;
            this.grvCompany.OptionsCustomization.AllowGroup = false;
            this.grvCompany.OptionsCustomization.AllowSort = false;
            this.grvCompany.OptionsFilter.AllowFilterEditor = false;
            this.grvCompany.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCompany.OptionsView.ShowDetailButtons = false;
            this.grvCompany.OptionsView.ShowGroupPanel = false;
            this.grvCompany.OptionsView.ShowIndicator = false;
            // 
            // colImage
            // 
            this.colImage.Caption = " ";
            this.colImage.ColumnEdit = this.imgStatus;
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.OptionsColumn.AllowEdit = false;
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 0;
            this.colImage.Width = 39;
            // 
            // imgStatus
            // 
            this.imgStatus.Name = "imgStatus";
            // 
            // colCompany
            // 
            this.colCompany.FieldName = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.OptionsColumn.AllowEdit = false;
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 1;
            this.colCompany.Width = 847;
            // 
            // colVersion
            // 
            this.colVersion.FieldName = "Version";
            this.colVersion.Name = "colVersion";
            this.colVersion.OptionsColumn.AllowEdit = false;
            this.colVersion.Visible = true;
            this.colVersion.VisibleIndex = 2;
            this.colVersion.Width = 848;
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imageCollectionSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemText,
            this.barItemProgress});
            this.barManager.MaxItemId = 2;
            this.barManager.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemText),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barItemProgress, "", false, true, true, 207)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barItemText
            // 
            this.barItemText.Caption = "##.##.##.##";
            this.barItemText.Glyph = ((System.Drawing.Image)(resources.GetObject("barItemText.Glyph")));
            this.barItemText.Id = 0;
            this.barItemText.Name = "barItemText";
            this.barItemText.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemText.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barItemProgress
            // 
            this.barItemProgress.AutoFillWidth = true;
            this.barItemProgress.Edit = this.repositoryItemProgressBar1;
            this.barItemProgress.Id = 1;
            this.barItemProgress.Name = "barItemProgress";
            this.barItemProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barItemProgress.Width = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(404, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 395);
            this.barDockControlBottom.Size = new System.Drawing.Size(404, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 395);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(404, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 395);
            // 
            // btnDiagnose
            // 
            this.btnDiagnose.Enabled = false;
            this.btnDiagnose.Location = new System.Drawing.Point(311, 112);
            this.btnDiagnose.Name = "btnDiagnose";
            this.btnDiagnose.Size = new System.Drawing.Size(60, 23);
            this.btnDiagnose.TabIndex = 9;
            this.btnDiagnose.Text = "Diagnose";
            this.btnDiagnose.Click += new System.EventHandler(this.btnDiagnose_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.EnterMoveNextControl = true;
            this.txtPassword.Location = new System.Drawing.Point(96, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(292, 20);
            this.txtPassword.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.txtPassword, conditionValidationRule1);
            // 
            // txtUsername
            // 
            this.txtUsername.EnterMoveNextControl = true;
            this.txtUsername.Location = new System.Drawing.Point(96, 164);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUsername.Size = new System.Drawing.Size(292, 20);
            this.txtUsername.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.txtUsername, conditionValidationRule2);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 193);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "&Password";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 167);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "&Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CDS.Client.Desktop.Properties.Resources.cds_banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(404, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // dxValidationProvider
            // 
            this.dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // SigninForm
            // 
            this.AcceptButton = this.btnSignin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 421);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSignin);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.MaximizeBox = false;
            this.Name = "SigninForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign in to Complete Distribution";
            this.Load += new System.EventHandler(this.frmSignin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSignin;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.MRUEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barItemText;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barItemProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraEditors.SimpleButton btnDiagnose;
        private DevExpress.XtraGrid.GridControl grdCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCompany;
        private System.Windows.Forms.BindingSource BindingSourceCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colVersion;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit imgStatus;

    }
}