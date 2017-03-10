namespace CDS.Client.Desktop.Core.Surcharge
{
    partial class SurchargeForm
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
            this.lcgIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceEntity = new System.Windows.Forms.BindingSource();
            this.itmShortName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlAccount = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.BindingSourceAccount = new System.Windows.Forms.BindingSource();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.XPInstantFeedbackSourceAccount = new DevExpress.Xpo.XPInstantFeedbackSource();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Surcharge);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtCode);
            this.LayoutControl.Controls.Add(this.ddlAccount);
            this.LayoutControl.Controls.Add(this.txtAmount);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtShortName);
            this.LayoutControl.Controls.Add(this.txtName);
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
            this.lcgIdentity,
            this.emptySpaceItem2});
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
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
            // lcgIdentity
            // 
            this.lcgIdentity.CustomizationFormText = "Identity";
            this.lcgIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmName,
            this.itmShortName,
            this.itmDescription,
            this.itmAccount,
            this.itmAmount,
            this.layoutControlItem1});
            this.lcgIdentity.Location = new System.Drawing.Point(0, 0);
            this.lcgIdentity.Name = "lcgIdentity";
            this.lcgIdentity.Size = new System.Drawing.Size(988, 163);
            this.lcgIdentity.Text = "Identity";
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Short Name";
            this.itmName.Location = new System.Drawing.Point(0, 24);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(964, 24);
            this.itmName.Text = "Short Name";
            this.itmName.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceEntity, "ShortName", true));
            this.txtName.Location = new System.Drawing.Point(84, 67);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(900, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 4;
            // 
            // BindingSourceEntity
            // 
            this.BindingSourceEntity.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Entity);
            // 
            // itmShortName
            // 
            this.itmShortName.Control = this.txtShortName;
            this.itmShortName.CustomizationFormText = "Name";
            this.itmShortName.Location = new System.Drawing.Point(0, 48);
            this.itmShortName.Name = "itmShortName";
            this.itmShortName.Size = new System.Drawing.Size(964, 24);
            this.itmShortName.Text = "Name";
            this.itmShortName.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtShortName
            // 
            this.txtShortName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceEntity, "Name", true));
            this.txtShortName.Location = new System.Drawing.Point(84, 91);
            this.txtShortName.MenuManager = this.RibbonControl;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(900, 20);
            this.txtShortName.StyleController = this.LayoutControl;
            this.txtShortName.TabIndex = 5;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 72);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(964, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceEntity, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(84, 115);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(900, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 6;
            // 
            // itmAccount
            // 
            this.itmAccount.Control = this.ddlAccount;
            this.itmAccount.CustomizationFormText = "Account";
            this.itmAccount.Location = new System.Drawing.Point(482, 96);
            this.itmAccount.Name = "itmAccount";
            this.itmAccount.Size = new System.Drawing.Size(482, 24);
            this.itmAccount.Text = "Account";
            this.itmAccount.TextSize = new System.Drawing.Size(56, 13);
            // 
            // ddlAccount
            // 
            this.ddlAccount.EditValue = "";
            this.ddlAccount.Location = new System.Drawing.Point(566, 139);
            this.ddlAccount.MenuManager = this.RibbonControl;
            this.ddlAccount.Name = "ddlAccount";
            this.ddlAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAccount.Properties.DataSource = this.BindingSourceAccount;
            this.ddlAccount.Properties.DisplayMember = "Title";
            this.ddlAccount.Properties.NullText = "Select Account ...";
            this.ddlAccount.Properties.ValueMember = "Id";
            this.ddlAccount.Properties.View = this.searchLookUpEdit1View;
            this.ddlAccount.Size = new System.Drawing.Size(418, 20);
            this.ddlAccount.StyleController = this.LayoutControl;
            this.ddlAccount.TabIndex = 8;
            this.ddlAccount.EditValueChanged += new System.EventHandler(this.ddlAccount_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeMain,
            this.colCodeSub,
            this.colName});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeSub, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCodeMain
            // 
            this.colCodeMain.Caption = "Code Main";
            this.colCodeMain.FieldName = "CodeMain";
            this.colCodeMain.Name = "colCodeMain";
            this.colCodeMain.Visible = true;
            this.colCodeMain.VisibleIndex = 0;
            // 
            // colCodeSub
            // 
            this.colCodeSub.Caption = "Code Sub";
            this.colCodeSub.FieldName = "CodeSub";
            this.colCodeSub.Name = "colCodeSub";
            this.colCodeSub.Visible = true;
            this.colCodeSub.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // itmAmount
            // 
            this.itmAmount.Control = this.txtAmount;
            this.itmAmount.CustomizationFormText = "Amount";
            this.itmAmount.Location = new System.Drawing.Point(0, 96);
            this.itmAmount.Name = "itmAmount";
            this.itmAmount.Size = new System.Drawing.Size(482, 24);
            this.itmAmount.Text = "Amount";
            this.itmAmount.TextSize = new System.Drawing.Size(56, 13);
            // 
            // txtAmount
            // 
            this.txtAmount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Amount", true));
            this.txtAmount.Location = new System.Drawing.Point(84, 139);
            this.txtAmount.MenuManager = this.RibbonControl;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(418, 20);
            this.txtAmount.StyleController = this.LayoutControl;
            this.txtAmount.TabIndex = 7;
            // 
            // XPInstantFeedbackSourceAccount
            // 
            this.XPInstantFeedbackSourceAccount.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.GLX_Account);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 163);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(988, 402);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtCode
            // 
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceEntity, "CodeSub", true));
            this.txtCode.Location = new System.Drawing.Point(84, 43);
            this.txtCode.MenuManager = this.RibbonControl;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(900, 20);
            this.txtCode.StyleController = this.LayoutControl;
            this.txtCode.TabIndex = 9;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCode;
            this.layoutControlItem1.CustomizationFormText = "Code";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(964, 24);
            this.layoutControlItem1.Text = "Code";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 13);
            // 
            // SurchargeForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "SurchargeForm";
            this.TabIcon = global::CDS.Client.Desktop.Core.Properties.Resources.shopping_cart_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Core.Properties.Resources.shopping_cart_16;
            this.Text = "Surcharge";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup lcgIdentity;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource BindingSourceEntity;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtShortName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraLayout.LayoutControlItem itmShortName;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmAmount;
        private DevExpress.XtraLayout.LayoutControlItem itmAccount;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourceAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSub;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private System.Windows.Forms.BindingSource BindingSourceAccount;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
