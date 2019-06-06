namespace CDS.Client.Desktop.Accounting
{
    partial class TaxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxForm));
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmPercentage = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPercentage = new DevExpress.XtraEditors.TextEdit();
            this.itmAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlAccount = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.InstantFeedbackSourceAccount = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCreatedBy = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.pnlSettings = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.GLX_Tax);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.txtPercentage);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.txtCode);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Controls.Add(this.ddlAccount);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(875, 373, 250, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(784, 415);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgIdentity,
            this.lcgHistory,
            this.pnlSettings});
            this.LayoutGroup.Size = new System.Drawing.Size(784, 415);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RibbonControl.Size = new System.Drawing.Size(784, 147);
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
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 25);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(740, 145);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgIdentity
            // 
            this.lcgIdentity.CustomizationFormText = "lcgIdentity";
            this.lcgIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCode,
            this.itmName,
            this.itmDescription});
            this.lcgIdentity.Location = new System.Drawing.Point(0, 0);
            this.lcgIdentity.Name = "lcgIdentity";
            this.lcgIdentity.Size = new System.Drawing.Size(764, 115);
            this.lcgIdentity.Text = "Identity";
            // 
            // itmCode
            // 
            this.itmCode.Control = this.txtCode;
            this.itmCode.CustomizationFormText = "Code";
            this.itmCode.Location = new System.Drawing.Point(0, 0);
            this.itmCode.Name = "itmCode";
            this.itmCode.Size = new System.Drawing.Size(740, 24);
            this.itmCode.Text = "Code";
            this.itmCode.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtCode
            // 
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Code", true));
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(84, 43);
            this.txtCode.MenuManager = this.RibbonControl;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(676, 20);
            this.txtCode.StyleController = this.LayoutControl;
            this.txtCode.TabIndex = 4;
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 24);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(740, 24);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Name", true));
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(84, 67);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(676, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 5;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 48);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(740, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(84, 91);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(676, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 6;
            // 
            // itmPercentage
            // 
            this.itmPercentage.Control = this.txtPercentage;
            this.itmPercentage.CustomizationFormText = "Percentage";
            this.itmPercentage.Location = new System.Drawing.Point(369, 0);
            this.itmPercentage.Name = "itmPercentage";
            this.itmPercentage.Size = new System.Drawing.Size(371, 25);
            this.itmPercentage.Text = "Percentage";
            this.itmPercentage.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtPercentage
            // 
            this.txtPercentage.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Amount", true));
            this.txtPercentage.EnterMoveNextControl = true;
            this.txtPercentage.Location = new System.Drawing.Point(453, 158);
            this.txtPercentage.MenuManager = this.RibbonControl;
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Properties.DisplayFormat.FormatString = "N2";
            this.txtPercentage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPercentage.Properties.EditFormat.FormatString = "N2";
            this.txtPercentage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPercentage.Properties.Mask.EditMask = "P";
            this.txtPercentage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercentage.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPercentage.Size = new System.Drawing.Size(307, 20);
            this.txtPercentage.StyleController = this.LayoutControl;
            this.txtPercentage.TabIndex = 7;
            // 
            // itmAccount
            // 
            this.itmAccount.Control = this.ddlAccount;
            this.itmAccount.CustomizationFormText = "Account";
            this.itmAccount.Location = new System.Drawing.Point(0, 0);
            this.itmAccount.MinSize = new System.Drawing.Size(50, 25);
            this.itmAccount.Name = "itmAccount";
            this.itmAccount.Size = new System.Drawing.Size(369, 25);
            this.itmAccount.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmAccount.Text = "Account";
            this.itmAccount.TextSize = new System.Drawing.Size(56, 13);
            // 
            // ddlAccount
            // 
            this.ddlAccount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "EntityId", true));
            this.ddlAccount.Location = new System.Drawing.Point(84, 158);
            this.ddlAccount.MenuManager = this.RibbonControl;
            this.ddlAccount.Name = "ddlAccount";
            this.ddlAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAccount.Properties.DataSource = this.InstantFeedbackSourceAccount;
            this.ddlAccount.Properties.DisplayMember = "Title";
            this.ddlAccount.Properties.NullText = "Select Account...";
            this.ddlAccount.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ddlAccount.Properties.ValueMember = "Id";
            this.ddlAccount.Properties.View = this.searchLookUpEdit1View;
            this.ddlAccount.Size = new System.Drawing.Size(305, 20);
            this.ddlAccount.StyleController = this.LayoutControl;
            this.ddlAccount.TabIndex = 12;
            // 
            // InstantFeedbackSourceAccount
            // 
            this.InstantFeedbackSourceAccount.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.InstantFeedbackSourceAccount.KeyExpression = "Id";
            this.InstantFeedbackSourceAccount.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceAccount_GetQueryable);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Title";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "CodeMain";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "CodeSub";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "lcgHistory";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedBy,
            this.itmCreatedOn});
            this.lcgHistory.Location = new System.Drawing.Point(0, 328);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(764, 67);
            this.lcgHistory.Text = "History";
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(373, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(84, 371);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.DataSource = this.ServerModeSourceCreatedBy;
            this.txtCreatedBy.Properties.DisplayMember = "Fullname";
            this.txtCreatedBy.Properties.NullText = "";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Properties.ValueMember = "Id";
            this.txtCreatedBy.Size = new System.Drawing.Size(309, 20);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 8;
            this.txtCreatedBy.TabStop = false;
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
            this.itmCreatedOn.Location = new System.Drawing.Point(373, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(367, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(457, 371);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Properties.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(303, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 9;
            this.txtCreatedOn.TabStop = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.CustomizationFormText = "Settings";
            this.pnlSettings.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.itmPercentage,
            this.itmAccount});
            this.pnlSettings.Location = new System.Drawing.Point(0, 115);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(764, 213);
            this.pnlSettings.Text = "Settings";
            // 
            // TaxForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Title", true));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "TaxForm";
            this.SuperTipParameter = "tax entry";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.WaitFormNewRecordDescription = "Creating new tax entry...";
            this.WaitFormOpenRecordDescription = "Opening tax entry...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIdentity;
        private DevExpress.XtraEditors.TextEdit txtPercentage;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem itmCode;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmPercentage;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem itmAccount;
        private DevExpress.XtraLayout.LayoutControlGroup pnlSettings;
        private DevExpress.XtraEditors.LookUpEdit txtCreatedBy;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCreatedBy;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource InstantFeedbackSourceAccount;
    }
}
