namespace CDS.Client.Desktop.Company.Contact
{
    partial class ContactForm
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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourcePerson = new System.Windows.Forms.BindingSource();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.itmSurname = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTelephone1 = new DevExpress.XtraEditors.TextEdit();
            this.itmTelephone1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTelephone2 = new DevExpress.XtraEditors.TextEdit();
            this.itmTelephone2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.itmFax = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.itmEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.BindingSourceTitle = new System.Windows.Forms.BindingSource();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.itmNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceDepartment = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmDepartment = new DevExpress.XtraLayout.LayoutControlItem();
            this.InstantFeedbackSourceCompany = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.itmCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHasCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHasSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlTitle = new DevExpress.XtraEditors.LookUpEdit();
            this.itmTitle = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSurname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_Contact);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ddlTitle);
            this.LayoutControl.Controls.Add(this.ddlDepartment);
            this.LayoutControl.Controls.Add(this.txtNote);
            this.LayoutControl.Controls.Add(this.txtEmail);
            this.LayoutControl.Controls.Add(this.txtFax);
            this.LayoutControl.Controls.Add(this.txtTelephone2);
            this.LayoutControl.Controls.Add(this.txtTelephone1);
            this.LayoutControl.Controls.Add(this.txtSurname);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.ddlCompany);
            this.LayoutControl.Location = new System.Drawing.Point(8, 162);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            this.LayoutControl.Size = new System.Drawing.Size(1167, 734);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmName,
            this.emptySpaceItem1,
            this.itmSurname,
            this.itmTelephone1,
            this.itmTelephone2,
            this.itmFax,
            this.itmEmail,
            this.itmNote,
            this.itmDepartment,
            this.itmCompany,
            this.itmTitle});
            this.LayoutGroup.Size = new System.Drawing.Size(1167, 734);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Location = new System.Drawing.Point(8, 9);
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.Size = new System.Drawing.Size(1167, 153);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourcePerson, "Name", true));
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(87, 38);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(1068, 22);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 4;
            // 
            // BindingSourcePerson
            // 
            this.BindingSourcePerson.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Person);
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 26);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(1147, 26);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(71, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 260);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1147, 454);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtSurname
            // 
            this.txtSurname.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourcePerson, "Surname", true));
            this.txtSurname.EnterMoveNextControl = true;
            this.txtSurname.Location = new System.Drawing.Point(87, 64);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSurname.MenuManager = this.RibbonControl;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(1068, 22);
            this.txtSurname.StyleController = this.LayoutControl;
            this.txtSurname.TabIndex = 5;
            // 
            // itmSurname
            // 
            this.itmSurname.Control = this.txtSurname;
            this.itmSurname.CustomizationFormText = "Surname";
            this.itmSurname.Location = new System.Drawing.Point(0, 52);
            this.itmSurname.Name = "itmSurname";
            this.itmSurname.Size = new System.Drawing.Size(1147, 26);
            this.itmSurname.Text = "Surname";
            this.itmSurname.TextSize = new System.Drawing.Size(71, 16);
            // 
            // txtTelephone1
            // 
            this.txtTelephone1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Telephone1", true));
            this.txtTelephone1.EnterMoveNextControl = true;
            this.txtTelephone1.Location = new System.Drawing.Point(87, 90);
            this.txtTelephone1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelephone1.MenuManager = this.RibbonControl;
            this.txtTelephone1.Name = "txtTelephone1";
            this.txtTelephone1.Size = new System.Drawing.Size(1068, 22);
            this.txtTelephone1.StyleController = this.LayoutControl;
            this.txtTelephone1.TabIndex = 6;
            // 
            // itmTelephone1
            // 
            this.itmTelephone1.Control = this.txtTelephone1;
            this.itmTelephone1.CustomizationFormText = "Telephone 1";
            this.itmTelephone1.Location = new System.Drawing.Point(0, 78);
            this.itmTelephone1.Name = "itmTelephone1";
            this.itmTelephone1.Size = new System.Drawing.Size(1147, 26);
            this.itmTelephone1.Text = "Telephone 1";
            this.itmTelephone1.TextSize = new System.Drawing.Size(71, 16);
            // 
            // txtTelephone2
            // 
            this.txtTelephone2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Telephone2", true));
            this.txtTelephone2.EnterMoveNextControl = true;
            this.txtTelephone2.Location = new System.Drawing.Point(87, 116);
            this.txtTelephone2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelephone2.MenuManager = this.RibbonControl;
            this.txtTelephone2.Name = "txtTelephone2";
            this.txtTelephone2.Size = new System.Drawing.Size(1068, 22);
            this.txtTelephone2.StyleController = this.LayoutControl;
            this.txtTelephone2.TabIndex = 7;
            // 
            // itmTelephone2
            // 
            this.itmTelephone2.Control = this.txtTelephone2;
            this.itmTelephone2.CustomizationFormText = "Telephone 2";
            this.itmTelephone2.Location = new System.Drawing.Point(0, 104);
            this.itmTelephone2.Name = "itmTelephone2";
            this.itmTelephone2.Size = new System.Drawing.Size(1147, 26);
            this.itmTelephone2.Text = "Telephone 2";
            this.itmTelephone2.TextSize = new System.Drawing.Size(71, 16);
            // 
            // txtFax
            // 
            this.txtFax.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Fax", true));
            this.txtFax.EnterMoveNextControl = true;
            this.txtFax.Location = new System.Drawing.Point(87, 142);
            this.txtFax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFax.MenuManager = this.RibbonControl;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(1068, 22);
            this.txtFax.StyleController = this.LayoutControl;
            this.txtFax.TabIndex = 8;
            // 
            // itmFax
            // 
            this.itmFax.Control = this.txtFax;
            this.itmFax.CustomizationFormText = "Fax";
            this.itmFax.Location = new System.Drawing.Point(0, 130);
            this.itmFax.Name = "itmFax";
            this.itmFax.Size = new System.Drawing.Size(1147, 26);
            this.itmFax.Text = "Fax";
            this.itmFax.TextSize = new System.Drawing.Size(71, 16);
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Email", true));
            this.txtEmail.EnterMoveNextControl = true;
            this.txtEmail.Location = new System.Drawing.Point(87, 168);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.MenuManager = this.RibbonControl;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(1068, 22);
            this.txtEmail.StyleController = this.LayoutControl;
            this.txtEmail.TabIndex = 9;
            // 
            // itmEmail
            // 
            this.itmEmail.Control = this.txtEmail;
            this.itmEmail.CustomizationFormText = "Email";
            this.itmEmail.Location = new System.Drawing.Point(0, 156);
            this.itmEmail.Name = "itmEmail";
            this.itmEmail.Size = new System.Drawing.Size(1147, 26);
            this.itmEmail.Text = "Email";
            this.itmEmail.TextSize = new System.Drawing.Size(71, 16);
            // 
            // txtNote
            // 
            this.txtNote.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Note", true));
            this.txtNote.EnterMoveNextControl = true;
            this.txtNote.Location = new System.Drawing.Point(87, 194);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNote.MenuManager = this.RibbonControl;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(1068, 22);
            this.txtNote.StyleController = this.LayoutControl;
            this.txtNote.TabIndex = 11;
            // 
            // itmNote
            // 
            this.itmNote.Control = this.txtNote;
            this.itmNote.CustomizationFormText = "Note";
            this.itmNote.Location = new System.Drawing.Point(0, 182);
            this.itmNote.Name = "itmNote";
            this.itmNote.Size = new System.Drawing.Size(1147, 26);
            this.itmNote.Text = "Note";
            this.itmNote.TextSize = new System.Drawing.Size(71, 16);
            // 
            // ddlDepartment
            // 
            this.ddlDepartment.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DepartmentId", true));
            this.ddlDepartment.EnterMoveNextControl = true;
            this.ddlDepartment.Location = new System.Drawing.Point(87, 220);
            this.ddlDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlDepartment.MenuManager = this.RibbonControl;
            this.ddlDepartment.Name = "ddlDepartment";
            this.ddlDepartment.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ddlDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlDepartment.Properties.DataSource = this.ServerModeSourceDepartment;
            this.ddlDepartment.Properties.DisplayMember = "Name";
            this.ddlDepartment.Properties.NullText = "Select Department ...";
            this.ddlDepartment.Properties.ValueMember = "Id";
            this.ddlDepartment.Size = new System.Drawing.Size(1068, 22);
            this.ddlDepartment.StyleController = this.LayoutControl;
            this.ddlDepartment.TabIndex = 12;
            // 
            // ServerModeSourceDepartment
            // 
            this.ServerModeSourceDepartment.ElementType = typeof(CDS.Client.DataAccessLayer.DB.ORG_Department);
            this.ServerModeSourceDepartment.KeyExpression = "Id";
            // 
            // itmDepartment
            // 
            this.itmDepartment.Control = this.ddlDepartment;
            this.itmDepartment.CustomizationFormText = "Department";
            this.itmDepartment.Location = new System.Drawing.Point(0, 208);
            this.itmDepartment.Name = "itmDepartment";
            this.itmDepartment.Size = new System.Drawing.Size(1147, 26);
            this.itmDepartment.Text = "Department";
            this.itmDepartment.TextSize = new System.Drawing.Size(71, 16);
            // 
            // InstantFeedbackSourceCompany
            // 
            this.InstantFeedbackSourceCompany.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Organisations);
            this.InstantFeedbackSourceCompany.KeyExpression = "Id";
            this.InstantFeedbackSourceCompany.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceCompany_GetQueryable);
            // 
            // itmCompany
            // 
            this.itmCompany.Control = this.ddlCompany;
            this.itmCompany.CustomizationFormText = "Company";
            this.itmCompany.Location = new System.Drawing.Point(0, 234);
            this.itmCompany.Name = "itmCompany";
            this.itmCompany.Size = new System.Drawing.Size(1147, 26);
            this.itmCompany.Text = "Company";
            this.itmCompany.TextSize = new System.Drawing.Size(71, 16);
            // 
            // ddlCompany
            // 
            this.ddlCompany.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CompanyId", true));
            this.ddlCompany.Location = new System.Drawing.Point(87, 246);
            this.ddlCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlCompany.MenuManager = this.RibbonControl;
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ddlCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCompany.Properties.DataSource = this.InstantFeedbackSourceCompany;
            this.ddlCompany.Properties.DisplayMember = "Name";
            this.ddlCompany.Properties.NullText = "Select Company ...";
            this.ddlCompany.Properties.ValueMember = "Id";
            this.ddlCompany.Properties.View = this.searchLookUpEdit1View;
            this.ddlCompany.Size = new System.Drawing.Size(1068, 22);
            this.ddlCompany.StyleController = this.LayoutControl;
            this.ddlCompany.TabIndex = 13;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colName,
            this.colDescription,
            this.colHasCustomer,
            this.colHasSupplier});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // colHasCustomer
            // 
            this.colHasCustomer.FieldName = "HasCustomer";
            this.colHasCustomer.Name = "colHasCustomer";
            this.colHasCustomer.Visible = true;
            this.colHasCustomer.VisibleIndex = 3;
            // 
            // colHasSupplier
            // 
            this.colHasSupplier.FieldName = "HasSupplier";
            this.colHasSupplier.Name = "colHasSupplier";
            this.colHasSupplier.Visible = true;
            this.colHasSupplier.VisibleIndex = 4;
            // 
            // ddlTitle
            // 
            this.ddlTitle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourcePerson, "Title", true));
            this.ddlTitle.EnterMoveNextControl = true;
            this.ddlTitle.Location = new System.Drawing.Point(87, 12);
            this.ddlTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddlTitle.MenuManager = this.RibbonControl;
            this.ddlTitle.Name = "ddlTitle";
            this.ddlTitle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlTitle.Properties.NullText = "Select Title ...";
            this.ddlTitle.Size = new System.Drawing.Size(1068, 22);
            this.ddlTitle.StyleController = this.LayoutControl;
            this.ddlTitle.TabIndex = 14;
            // 
            // itmTitle
            // 
            this.itmTitle.Control = this.ddlTitle;
            this.itmTitle.CustomizationFormText = "Title";
            this.itmTitle.Location = new System.Drawing.Point(0, 0);
            this.itmTitle.Name = "itmTitle";
            this.itmTitle.Size = new System.Drawing.Size(1147, 26);
            this.itmTitle.Text = "Title";
            this.itmTitle.TextSize = new System.Drawing.Size(71, 16);
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1183, 905);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourcePerson, "Fullname", true));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "ContactForm";
            this.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Text = "Contact";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSurname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTelephone2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.TextEdit txtTelephone2;
        private DevExpress.XtraEditors.TextEdit txtTelephone1;
        private DevExpress.XtraEditors.TextEdit txtSurname;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem itmSurname;
        private DevExpress.XtraLayout.LayoutControlItem itmTelephone1;
        private DevExpress.XtraLayout.LayoutControlItem itmTelephone2;
        private DevExpress.XtraLayout.LayoutControlItem itmFax;
        private DevExpress.XtraLayout.LayoutControlItem itmEmail;
        private System.Windows.Forms.BindingSource BindingSourcePerson;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraLayout.LayoutControlItem itmNote;
        private DevExpress.XtraEditors.LookUpEdit ddlDepartment;
        private DevExpress.XtraLayout.LayoutControlItem itmDepartment;
        private DevExpress.XtraLayout.LayoutControlItem itmCompany;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceDepartment;
        private System.Windows.Forms.BindingSource BindingSourceTitle;
        private DevExpress.XtraEditors.LookUpEdit ddlTitle;
        private DevExpress.XtraLayout.LayoutControlItem itmTitle;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceCompany;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colHasCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colHasSupplier;
    }
}
