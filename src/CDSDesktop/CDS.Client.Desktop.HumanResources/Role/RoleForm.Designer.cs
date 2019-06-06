namespace CDS.Client.Desktop.HRS
{
    partial class RoleForm
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
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.itmCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCreatedBy = new DevExpress.Data.Linq.LinqServerModeSource();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.pnlIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.chkAppointments = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tbcRoleForm = new DevExpress.XtraLayout.TabbedControlGroup();
            this.pnlSettings = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAppointments = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabEmployees = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmGridEmployees = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdEmployees = new DevExpress.XtraGrid.GridControl();
            this.ServerModeSourceEmployees = new DevExpress.Data.Linq.LinqServerModeSource();
            this.grvEmployees = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstnames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastname = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcRoleForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.HRS_Role);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.chkAppointments);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.txtCode);
            this.LayoutControl.Controls.Add(this.grdEmployees);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Location = new System.Drawing.Point(8, 162);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(470, 275, 250, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(775, 400);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgHistory,
            this.pnlIdentity,
            this.tbcRoleForm});
            this.LayoutGroup.Size = new System.Drawing.Size(775, 400);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Location = new System.Drawing.Point(8, 9);
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.Size = new System.Drawing.Size(775, 153);
            // 
            // txtCode
            // 
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Code", true));
            this.txtCode.Location = new System.Drawing.Point(93, 46);
            this.txtCode.MenuManager = this.RibbonControl;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(658, 22);
            this.txtCode.StyleController = this.LayoutControl;
            this.txtCode.TabIndex = 4;
            // 
            // itmCode
            // 
            this.itmCode.Control = this.txtCode;
            this.itmCode.CustomizationFormText = "Code";
            this.itmCode.Location = new System.Drawing.Point(0, 0);
            this.itmCode.Name = "itmCode";
            this.itmCode.Size = new System.Drawing.Size(731, 26);
            this.itmCode.Text = "Code";
            this.itmCode.TextSize = new System.Drawing.Size(65, 16);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(93, 72);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(658, 22);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 5;
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 26);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(731, 26);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(65, 16);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(93, 98);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(658, 22);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 6;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 52);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(731, 26);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(65, 16);
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(361, 26);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(65, 16);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(93, 354);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.DataSource = this.ServerModeSourceCreatedBy;
            this.txtCreatedBy.Properties.DisplayMember = "Fullname";
            this.txtCreatedBy.Properties.NullText = "";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Properties.ValueMember = "Id";
            this.txtCreatedBy.Size = new System.Drawing.Size(288, 22);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 7;
            // 
            // ServerModeSourceCreatedBy
            // 
            this.ServerModeSourceCreatedBy.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Person);
            this.ServerModeSourceCreatedBy.KeyExpression = "Id";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(454, 354);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Properties.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(297, 22);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 9;
            // 
            // itmCreatedOn
            // 
            this.itmCreatedOn.Control = this.txtCreatedOn;
            this.itmCreatedOn.CustomizationFormText = "Created On";
            this.itmCreatedOn.Location = new System.Drawing.Point(361, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(370, 26);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(65, 16);
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedBy,
            this.itmCreatedOn});
            this.lcgHistory.Location = new System.Drawing.Point(0, 308);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(755, 72);
            this.lcgHistory.Text = "History";
            // 
            // pnlIdentity
            // 
            this.pnlIdentity.CustomizationFormText = "Identity";
            this.pnlIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmDescription,
            this.itmName,
            this.itmCode});
            this.pnlIdentity.Location = new System.Drawing.Point(0, 0);
            this.pnlIdentity.Name = "pnlIdentity";
            this.pnlIdentity.Size = new System.Drawing.Size(755, 124);
            this.pnlIdentity.Text = "Identity";
            // 
            // chkAppointments
            // 
            this.chkAppointments.CheckOnClick = true;
            this.chkAppointments.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Appointment", "General Appointment"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("PurchaseAppointment", "Purchase Appointment"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("SaleAppointment", "Sale Appointment"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("WorkshopAppointment", "Workshop Appointment")});
            this.chkAppointments.Location = new System.Drawing.Point(24, 192);
            this.chkAppointments.MultiColumn = true;
            this.chkAppointments.Name = "chkAppointments";
            this.chkAppointments.Size = new System.Drawing.Size(727, 18);
            this.chkAppointments.StyleController = this.LayoutControl;
            this.chkAppointments.TabIndex = 11;
            // 
            // tbcRoleForm
            // 
            this.tbcRoleForm.CustomizationFormText = "tabbedControlGroup1";
            this.tbcRoleForm.Location = new System.Drawing.Point(0, 124);
            this.tbcRoleForm.Name = "tbcRoleForm";
            this.tbcRoleForm.SelectedTabPage = this.pnlSettings;
            this.tbcRoleForm.SelectedTabPageIndex = 0;
            this.tbcRoleForm.Size = new System.Drawing.Size(755, 184);
            this.tbcRoleForm.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pnlSettings,
            this.tabEmployees});
            this.tbcRoleForm.Text = "tbcRoleForm";
            // 
            // pnlSettings
            // 
            this.pnlSettings.CustomizationFormText = "Settings";
            this.pnlSettings.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAppointments,
            this.emptySpaceItem1});
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(731, 135);
            this.pnlSettings.Text = "Settings";
            // 
            // itmAppointments
            // 
            this.itmAppointments.Control = this.chkAppointments;
            this.itmAppointments.CustomizationFormText = "Calendars";
            this.itmAppointments.Location = new System.Drawing.Point(0, 0);
            this.itmAppointments.MaxSize = new System.Drawing.Size(0, 41);
            this.itmAppointments.MinSize = new System.Drawing.Size(115, 41);
            this.itmAppointments.Name = "itmAppointments";
            this.itmAppointments.Size = new System.Drawing.Size(731, 41);
            this.itmAppointments.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmAppointments.Text = "Calendars";
            this.itmAppointments.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmAppointments.TextSize = new System.Drawing.Size(65, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 41);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(731, 94);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabEmployees
            // 
            this.tabEmployees.CustomizationFormText = "layoutControlGroup1";
            this.tabEmployees.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmGridEmployees});
            this.tabEmployees.Location = new System.Drawing.Point(0, 0);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Size = new System.Drawing.Size(731, 135);
            this.tabEmployees.Text = "Employees";
            // 
            // itmGridEmployees
            // 
            this.itmGridEmployees.Control = this.grdEmployees;
            this.itmGridEmployees.CustomizationFormText = "itmGridEmployees";
            this.itmGridEmployees.Location = new System.Drawing.Point(0, 0);
            this.itmGridEmployees.Name = "itmGridEmployees";
            this.itmGridEmployees.Size = new System.Drawing.Size(731, 135);
            this.itmGridEmployees.Text = "itmGridEmployees";
            this.itmGridEmployees.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridEmployees.TextVisible = false;
            // 
            // grdEmployees
            // 
            this.grdEmployees.DataSource = this.ServerModeSourceEmployees;
            this.grdEmployees.Location = new System.Drawing.Point(24, 173);
            this.grdEmployees.MainView = this.grvEmployees;
            this.grdEmployees.MenuManager = this.RibbonControl;
            this.grdEmployees.Name = "grdEmployees";
            this.grdEmployees.Size = new System.Drawing.Size(727, 131);
            this.grdEmployees.TabIndex = 12;
            this.grdEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployees});
            // 
            // ServerModeSourceEmployees
            // 
            this.ServerModeSourceEmployees.ElementType = typeof(CDS.Client.DataAccessLayer.DB.HRS_Employee);
            this.ServerModeSourceEmployees.KeyExpression = "[Id]";
            // 
            // grvEmployees
            // 
            this.grvEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colFirstnames,
            this.colLastname});
            this.grvEmployees.GridControl = this.grdEmployees;
            this.grvEmployees.Name = "grvEmployees";
            this.grvEmployees.OptionsBehavior.Editable = false;
            this.grvEmployees.OptionsBehavior.ReadOnly = true;
            this.grvEmployees.OptionsCustomization.AllowFilter = false;
            this.grvEmployees.OptionsCustomization.AllowGroup = false;
            this.grvEmployees.OptionsLayout.Columns.AddNewColumns = false;
            this.grvEmployees.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grvEmployees.OptionsMenu.EnableColumnMenu = false;
            this.grvEmployees.OptionsMenu.EnableFooterMenu = false;
            this.grvEmployees.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvEmployees.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowMove = false;
            this.colCode.OptionsColumn.AllowSize = false;
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 67;
            // 
            // colFirstnames
            // 
            this.colFirstnames.FieldName = "Firstnames";
            this.colFirstnames.Name = "colFirstnames";
            this.colFirstnames.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colFirstnames.Visible = true;
            this.colFirstnames.VisibleIndex = 1;
            this.colFirstnames.Width = 258;
            // 
            // colLastname
            // 
            this.colLastname.FieldName = "Lastname";
            this.colLastname.Name = "colLastname";
            this.colLastname.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLastname.Visible = true;
            this.colLastname.VisibleIndex = 2;
            this.colLastname.Width = 260;
            // 
            // RoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(791, 571);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Name", true));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "RoleForm";
            this.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.TabIcon = global::CDS.Client.Desktop.HumanResources.Properties.Resources.contract_16;
            this.TabIconBackup = global::CDS.Client.Desktop.HumanResources.Properties.Resources.contract_16;
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcRoleForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.XtraLayout.LayoutControlGroup pnlIdentity;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlItem itmCode;
        private DevExpress.XtraEditors.CheckedListBoxControl chkAppointments;
        private DevExpress.XtraLayout.TabbedControlGroup tbcRoleForm;
        private DevExpress.XtraLayout.LayoutControlGroup pnlSettings;
        private DevExpress.XtraLayout.LayoutControlItem itmAppointments;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup tabEmployees;
        private DevExpress.XtraGrid.GridControl grdEmployees;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEmployees;
        private DevExpress.XtraLayout.LayoutControlItem itmGridEmployees;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceEmployees;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstnames;
        private DevExpress.XtraGrid.Columns.GridColumn colLastname;
        private DevExpress.XtraEditors.LookUpEdit txtCreatedBy;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCreatedBy;
    }
}
