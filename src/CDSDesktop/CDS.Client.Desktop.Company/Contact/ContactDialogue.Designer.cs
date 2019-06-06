namespace CDS.Client.Desktop.Company.Contact
{
    partial class ContactDialogue
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
            this.ddlTitle = new DevExpress.XtraEditors.LookUpEdit();
            this.itmTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.itmSurname = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTelepone1 = new DevExpress.XtraEditors.TextEdit();
            this.itmTelephone1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTelephone2 = new DevExpress.XtraEditors.TextEdit();
            this.itmTelephone2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.itmFax = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.itmEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.BindingSourceTitle = new System.Windows.Forms.BindingSource();
            this.ServerModeSourceDepartment = new DevExpress.Data.Linq.LinqServerModeSource();
            this.ServerModeSourceCompany = new DevExpress.Data.Linq.LinqServerModeSource();
            this.BindingSourcePerson = new System.Windows.Forms.BindingSource();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.ValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSurname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelepone1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnSave);
            this.LayoutControl.Controls.Add(this.txtEmail);
            this.LayoutControl.Controls.Add(this.txtFax);
            this.LayoutControl.Controls.Add(this.txtTelephone2);
            this.LayoutControl.Controls.Add(this.txtTelepone1);
            this.LayoutControl.Controls.Add(this.txtSurname);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.ddlTitle);
            this.LayoutControl.Controls.Add(this.txtNote);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2734, 44, 250, 350);
            this.LayoutControl.Size = new System.Drawing.Size(497, 227);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmTitle,
            this.itmName,
            this.itmSurname,
            this.itmTelephone1,
            this.itmTelephone2,
            this.itmFax,
            this.itmEmail,
            this.itmNote,
            this.layoutControlItem1});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(497, 227);
            this.LayoutGroup.Text = "Root";
            // 
            // ddlTitle
            // 
            this.ddlTitle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourcePerson, "Title", true));
            this.ddlTitle.Location = new System.Drawing.Point(69, 6);
            this.ddlTitle.Name = "ddlTitle";
            this.ddlTitle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlTitle.Properties.NullText = "Select Title ...";
            this.ddlTitle.Size = new System.Drawing.Size(422, 20);
            this.ddlTitle.StyleController = this.LayoutControl;
            this.ddlTitle.TabIndex = 4;
            // 
            // itmTitle
            // 
            this.itmTitle.Control = this.ddlTitle;
            this.itmTitle.CustomizationFormText = "Title";
            this.itmTitle.Location = new System.Drawing.Point(0, 0);
            this.itmTitle.Name = "itmTitle";
            this.itmTitle.Size = new System.Drawing.Size(489, 24);
            this.itmTitle.Text = "Title";
            this.itmTitle.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourcePerson, "Name", true));
            this.txtName.Location = new System.Drawing.Point(69, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(422, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 5;
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 24);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(489, 24);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtSurname
            // 
            this.txtSurname.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourcePerson, "Surname", true));
            this.txtSurname.Location = new System.Drawing.Point(69, 54);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(422, 20);
            this.txtSurname.StyleController = this.LayoutControl;
            this.txtSurname.TabIndex = 6;
            // 
            // itmSurname
            // 
            this.itmSurname.Control = this.txtSurname;
            this.itmSurname.CustomizationFormText = "Surname";
            this.itmSurname.Location = new System.Drawing.Point(0, 48);
            this.itmSurname.Name = "itmSurname";
            this.itmSurname.Size = new System.Drawing.Size(489, 24);
            this.itmSurname.Text = "Surname";
            this.itmSurname.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtTelepone1
            // 
            this.txtTelepone1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Telephone1", true));
            this.txtTelepone1.Location = new System.Drawing.Point(69, 78);
            this.txtTelepone1.Name = "txtTelepone1";
            this.txtTelepone1.Size = new System.Drawing.Size(422, 20);
            this.txtTelepone1.StyleController = this.LayoutControl;
            this.txtTelepone1.TabIndex = 7;
            // 
            // itmTelephone1
            // 
            this.itmTelephone1.Control = this.txtTelepone1;
            this.itmTelephone1.CustomizationFormText = "Telephone 1";
            this.itmTelephone1.Location = new System.Drawing.Point(0, 72);
            this.itmTelephone1.Name = "itmTelephone1";
            this.itmTelephone1.Size = new System.Drawing.Size(489, 24);
            this.itmTelephone1.Text = "Telephone 1";
            this.itmTelephone1.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtTelephone2
            // 
            this.txtTelephone2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Telephone2", true));
            this.txtTelephone2.Location = new System.Drawing.Point(69, 102);
            this.txtTelephone2.Name = "txtTelephone2";
            this.txtTelephone2.Size = new System.Drawing.Size(422, 20);
            this.txtTelephone2.StyleController = this.LayoutControl;
            this.txtTelephone2.TabIndex = 8;
            // 
            // itmTelephone2
            // 
            this.itmTelephone2.Control = this.txtTelephone2;
            this.itmTelephone2.CustomizationFormText = "Telephone 2";
            this.itmTelephone2.Location = new System.Drawing.Point(0, 96);
            this.itmTelephone2.Name = "itmTelephone2";
            this.itmTelephone2.Size = new System.Drawing.Size(489, 24);
            this.itmTelephone2.Text = "Telephone 2";
            this.itmTelephone2.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtFax
            // 
            this.txtFax.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Fax", true));
            this.txtFax.Location = new System.Drawing.Point(69, 126);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(422, 20);
            this.txtFax.StyleController = this.LayoutControl;
            this.txtFax.TabIndex = 9;
            // 
            // itmFax
            // 
            this.itmFax.Control = this.txtFax;
            this.itmFax.CustomizationFormText = "Fax";
            this.itmFax.Location = new System.Drawing.Point(0, 120);
            this.itmFax.Name = "itmFax";
            this.itmFax.Size = new System.Drawing.Size(489, 24);
            this.itmFax.Text = "Fax";
            this.itmFax.TextSize = new System.Drawing.Size(59, 13);
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Email", true));
            this.txtEmail.Location = new System.Drawing.Point(69, 150);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(422, 20);
            this.txtEmail.StyleController = this.LayoutControl;
            this.txtEmail.TabIndex = 10;
            // 
            // itmEmail
            // 
            this.itmEmail.Control = this.txtEmail;
            this.itmEmail.CustomizationFormText = "Email";
            this.itmEmail.Location = new System.Drawing.Point(0, 144);
            this.itmEmail.Name = "itmEmail";
            this.itmEmail.Size = new System.Drawing.Size(489, 24);
            this.itmEmail.Text = "Email";
            this.itmEmail.TextSize = new System.Drawing.Size(59, 13);
            // 
            // itmNote
            // 
            this.itmNote.Control = this.txtNote;
            this.itmNote.CustomizationFormText = "Note";
            this.itmNote.Location = new System.Drawing.Point(0, 168);
            this.itmNote.Name = "itmNote";
            this.itmNote.Size = new System.Drawing.Size(489, 25);
            this.itmNote.Text = "Note";
            this.itmNote.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ServerModeSourceDepartment
            // 
            this.ServerModeSourceDepartment.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_Department);
            this.ServerModeSourceDepartment.KeyExpression = "Id";
            // 
            // ServerModeSourceCompany
            // 
            this.ServerModeSourceCompany.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Company);
            this.ServerModeSourceCompany.KeyExpression = "Id";
            // 
            // BindingSourcePerson
            // 
            this.BindingSourcePerson.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Person);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_Contact);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(485, 22);
            this.btnSave.StyleController = this.LayoutControl;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 193);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(489, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // txtNote
            // 
            this.txtNote.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Note", true));
            this.txtNote.Location = new System.Drawing.Point(69, 174);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(422, 21);
            this.txtNote.StyleController = this.LayoutControl;
            this.txtNote.TabIndex = 11;
            // 
            // ContactDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 281);
            this.Name = "ContactDialogue";
            this.Text = " Contact";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSurname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelepone1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit ddlTitle;
        private DevExpress.XtraLayout.LayoutControlItem itmTitle;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.TextEdit txtTelephone2;
        private DevExpress.XtraEditors.TextEdit txtTelepone1;
        private DevExpress.XtraEditors.TextEdit txtSurname;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlItem itmSurname;
        private DevExpress.XtraLayout.LayoutControlItem itmTelephone1;
        private DevExpress.XtraLayout.LayoutControlItem itmTelephone2;
        private DevExpress.XtraLayout.LayoutControlItem itmFax;
        private DevExpress.XtraLayout.LayoutControlItem itmEmail;
        private DevExpress.XtraLayout.LayoutControlItem itmNote;
        private System.Windows.Forms.BindingSource BindingSourceTitle;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceDepartment;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCompany;
        private System.Windows.Forms.BindingSource BindingSourcePerson;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ValidationProvider;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.MemoEdit txtNote;
    }
}
