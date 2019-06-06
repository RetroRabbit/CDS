namespace CDS.Client.Desktop.Company.Entity
{
    partial class EntityForm
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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceEntity = new System.Windows.Forms.BindingSource(this.components);
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRegistrationNumber = new DevExpress.XtraEditors.TextEdit();
            this.itmRegistrationNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVatNumber = new DevExpress.XtraEditors.TextEdit();
            this.itmVatNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.itmNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.lcgInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCreatedBy = new DevExpress.Data.Linq.LinqServerModeSource();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnCreateCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateSupplier = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewSupplier = new DevExpress.XtraBars.BarButtonItem();
            this.rpEntity = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgCompany = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRegistrationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmVatNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_Entity);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtCode);
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.txtNote);
            this.LayoutControl.Controls.Add(this.txtVatNumber);
            this.LayoutControl.Controls.Add(this.txtRegistrationNumber);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.LayoutControl.Size = new System.Drawing.Size(866, 499);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lcgIdentity,
            this.lcgInformation,
            this.lcgHistory});
            this.LayoutGroup.Size = new System.Drawing.Size(866, 499);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCreateCustomer,
            this.btnCreateSupplier,
            this.btnViewCustomer,
            this.btnViewSupplier});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RibbonControl.MaxItemId = 28;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpEntity});
            this.RibbonControl.Size = new System.Drawing.Size(866, 147);
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
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceEntity, "Name", true));
            this.txtName.Location = new System.Drawing.Point(126, 67);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(716, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 4;
            // 
            // BindingSourceEntity
            // 
            this.BindingSourceEntity.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Entity);
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 24);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(822, 24);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceEntity, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(126, 91);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(716, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 5;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 48);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(822, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtRegistrationNumber
            // 
            this.txtRegistrationNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "RegistrationNumber", true));
            this.txtRegistrationNumber.Location = new System.Drawing.Point(126, 158);
            this.txtRegistrationNumber.MenuManager = this.RibbonControl;
            this.txtRegistrationNumber.Name = "txtRegistrationNumber";
            this.txtRegistrationNumber.Size = new System.Drawing.Size(716, 20);
            this.txtRegistrationNumber.StyleController = this.LayoutControl;
            this.txtRegistrationNumber.TabIndex = 6;
            // 
            // itmRegistrationNumber
            // 
            this.itmRegistrationNumber.Control = this.txtRegistrationNumber;
            this.itmRegistrationNumber.CustomizationFormText = "Registration Number";
            this.itmRegistrationNumber.Location = new System.Drawing.Point(0, 0);
            this.itmRegistrationNumber.Name = "itmRegistrationNumber";
            this.itmRegistrationNumber.Size = new System.Drawing.Size(822, 24);
            this.itmRegistrationNumber.Text = "Registration Number";
            this.itmRegistrationNumber.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtVatNumber
            // 
            this.txtVatNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "VatNumber", true));
            this.txtVatNumber.Location = new System.Drawing.Point(126, 182);
            this.txtVatNumber.MenuManager = this.RibbonControl;
            this.txtVatNumber.Name = "txtVatNumber";
            this.txtVatNumber.Size = new System.Drawing.Size(716, 20);
            this.txtVatNumber.StyleController = this.LayoutControl;
            this.txtVatNumber.TabIndex = 7;
            // 
            // itmVatNumber
            // 
            this.itmVatNumber.Control = this.txtVatNumber;
            this.itmVatNumber.CustomizationFormText = "Vat Number";
            this.itmVatNumber.Location = new System.Drawing.Point(0, 24);
            this.itmVatNumber.Name = "itmVatNumber";
            this.itmVatNumber.Size = new System.Drawing.Size(822, 24);
            this.itmVatNumber.Text = "Vat Number";
            this.itmVatNumber.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtNote
            // 
            this.txtNote.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Note", true));
            this.txtNote.Location = new System.Drawing.Point(126, 206);
            this.txtNote.MenuManager = this.RibbonControl;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(716, 20);
            this.txtNote.StyleController = this.LayoutControl;
            this.txtNote.TabIndex = 8;
            // 
            // itmNote
            // 
            this.itmNote.Control = this.txtNote;
            this.itmNote.CustomizationFormText = "Note";
            this.itmNote.Location = new System.Drawing.Point(0, 48);
            this.itmNote.Name = "itmNote";
            this.itmNote.Size = new System.Drawing.Size(822, 24);
            this.itmNote.Text = "Note";
            this.itmNote.TextSize = new System.Drawing.Size(98, 13);
            // 
            // lcgIdentity
            // 
            this.lcgIdentity.CustomizationFormText = "Identity";
            this.lcgIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmName,
            this.itmDescription,
            this.itmCode});
            this.lcgIdentity.Location = new System.Drawing.Point(0, 0);
            this.lcgIdentity.Name = "lcgIdentity";
            this.lcgIdentity.Size = new System.Drawing.Size(846, 115);
            this.lcgIdentity.Text = "Identity";
            // 
            // itmCode
            // 
            this.itmCode.Control = this.txtCode;
            this.itmCode.CustomizationFormText = "Code";
            this.itmCode.Location = new System.Drawing.Point(0, 0);
            this.itmCode.Name = "itmCode";
            this.itmCode.Size = new System.Drawing.Size(822, 24);
            this.itmCode.Text = "Code";
            this.itmCode.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtCode
            // 
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceEntity, "CodeSub", true));
            this.txtCode.Location = new System.Drawing.Point(126, 43);
            this.txtCode.MenuManager = this.RibbonControl;
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(716, 20);
            this.txtCode.StyleController = this.LayoutControl;
            this.txtCode.TabIndex = 11;
            this.txtCode.TabStop = false;
            // 
            // lcgInformation
            // 
            this.lcgInformation.CustomizationFormText = "Information";
            this.lcgInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmNote,
            this.itmVatNumber,
            this.itmRegistrationNumber});
            this.lcgInformation.Location = new System.Drawing.Point(0, 115);
            this.lcgInformation.Name = "lcgInformation";
            this.lcgInformation.Size = new System.Drawing.Size(846, 115);
            this.lcgInformation.Text = "Information";
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(411, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(126, 455);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.DataSource = this.ServerModeSourceCreatedBy;
            this.txtCreatedBy.Properties.DisplayMember = "Fullname";
            this.txtCreatedBy.Properties.NullText = "";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Properties.ValueMember = "Id";
            this.txtCreatedBy.Size = new System.Drawing.Size(305, 20);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 9;
            // 
            // ServerModeSourceCreatedBy
            // 
            this.ServerModeSourceCreatedBy.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Person);
            this.ServerModeSourceCreatedBy.KeyExpression = "Id";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(537, 455);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Properties.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(305, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 10;
            // 
            // itmCreatedOn
            // 
            this.itmCreatedOn.Control = this.txtCreatedOn;
            this.itmCreatedOn.CustomizationFormText = "Created On";
            this.itmCreatedOn.Location = new System.Drawing.Point(411, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(411, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(98, 13);
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedOn,
            this.itmCreatedBy});
            this.lcgHistory.Location = new System.Drawing.Point(0, 412);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(846, 67);
            this.lcgHistory.Text = "History";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 230);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(846, 182);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.Caption = "Create Customer";
            this.btnCreateCustomer.Glyph = global::CDS.Client.Desktop.Company.Properties.Resources.businessman_16;
            this.btnCreateCustomer.Id = 24;
            this.btnCreateCustomer.LargeGlyph = global::CDS.Client.Desktop.Company.Properties.Resources.businessman_32;
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateCustomer_ItemClick);
            // 
            // btnCreateSupplier
            // 
            this.btnCreateSupplier.Caption = "Create Supplier";
            this.btnCreateSupplier.Glyph = global::CDS.Client.Desktop.Company.Properties.Resources.delivery_man_parcel_16;
            this.btnCreateSupplier.Id = 25;
            this.btnCreateSupplier.LargeGlyph = global::CDS.Client.Desktop.Company.Properties.Resources.delivery_man_parcel_32;
            this.btnCreateSupplier.Name = "btnCreateSupplier";
            this.btnCreateSupplier.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateSupplier_ItemClick);
            // 
            // btnViewCustomer
            // 
            this.btnViewCustomer.Caption = "View Customer";
            this.btnViewCustomer.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewCustomer.Glyph = global::CDS.Client.Desktop.Company.Properties.Resources.businessman_16;
            this.btnViewCustomer.Id = 26;
            this.btnViewCustomer.LargeGlyph = global::CDS.Client.Desktop.Company.Properties.Resources.businessman_32;
            this.btnViewCustomer.Name = "btnViewCustomer";
            this.btnViewCustomer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewCustomer_ItemClick);
            // 
            // btnViewSupplier
            // 
            this.btnViewSupplier.Caption = "View Supplier";
            this.btnViewSupplier.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewSupplier.Glyph = global::CDS.Client.Desktop.Company.Properties.Resources.delivery_man_parcel_16;
            this.btnViewSupplier.Id = 27;
            this.btnViewSupplier.LargeGlyph = global::CDS.Client.Desktop.Company.Properties.Resources.delivery_man_parcel_32;
            this.btnViewSupplier.Name = "btnViewSupplier";
            this.btnViewSupplier.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewSupplier.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewSupplier_ItemClick);
            // 
            // rpEntity
            // 
            this.rpEntity.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgCompany});
            this.rpEntity.Name = "rpEntity";
            this.rpEntity.Text = "Entity";
            // 
            // rpgCompany
            // 
            this.rpgCompany.ItemLinks.Add(this.btnCreateCustomer);
            this.rpgCompany.ItemLinks.Add(this.btnViewCustomer);
            this.rpgCompany.ItemLinks.Add(this.btnCreateSupplier);
            this.rpgCompany.ItemLinks.Add(this.btnViewSupplier);
            this.rpgCompany.Name = "rpgCompany";
            this.rpgCompany.Text = "Company";
            // 
            // EntityForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(866, 646);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceEntity, "Name", true));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "EntityForm";
            this.SuperTipParameter = "Entity,Entities";
            this.TabIcon = global::CDS.Client.Desktop.Company.Properties.Resources.handshake_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Company.Properties.Resources.handshake_16;
            this.WaitFormNewRecordDescription = "Creating new Entity...";
            this.WaitFormOpenRecordDescription = "Opening Entity...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRegistrationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVatNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmVatNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.TextEdit txtVatNumber;
        private DevExpress.XtraEditors.TextEdit txtRegistrationNumber;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmRegistrationNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmVatNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmNote;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIdentity;
        private System.Windows.Forms.BindingSource BindingSourceEntity;
        private DevExpress.XtraLayout.LayoutControlGroup lcgInformation;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarButtonItem btnCreateCustomer;
        private DevExpress.XtraBars.BarButtonItem btnCreateSupplier;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem itmCode;
        private DevExpress.XtraEditors.LookUpEdit txtCreatedBy;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCreatedBy;
        private DevExpress.XtraBars.BarButtonItem btnViewCustomer;
        private DevExpress.XtraBars.BarButtonItem btnViewSupplier;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpEntity;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCompany;
    }
}
