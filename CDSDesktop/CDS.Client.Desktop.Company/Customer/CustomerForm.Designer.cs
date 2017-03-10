namespace CDS.Client.Desktop.Company.Customer
{
    partial class CustomerForm
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
            this.btnStatement = new DevExpress.XtraBars.BarButtonItem();
            this.rpCompany = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgAccount = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(926, 376, 631, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(1022, 620);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Size = new System.Drawing.Size(1005, 623);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnStatement});
            this.RibbonControl.MaxItemId = 27;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpCompany});
            this.RibbonControl.Size = new System.Drawing.Size(1022, 147);
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
            // btnStatement
            // 
            this.btnStatement.Caption = "View\r\nStatement";
            this.btnStatement.Glyph = global::CDS.Client.Desktop.Company.Properties.Resources.mail_sealed_16;
            this.btnStatement.Id = 26;
            this.btnStatement.LargeGlyph = global::CDS.Client.Desktop.Company.Properties.Resources.mail_sealed_32;
            this.btnStatement.Name = "btnStatement";
            this.btnStatement.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnStatement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStatement_ItemClick);
            // 
            // rpCompany
            // 
            this.rpCompany.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgAccount});
            this.rpCompany.Name = "rpCompany";
            this.rpCompany.Text = "Company";
            // 
            // rpgAccount
            // 
            this.rpgAccount.ItemLinks.Add(this.btnStatement);
            this.rpgAccount.Name = "rpgAccount";
            this.rpgAccount.Text = "Account";
            // 
            // CustomerForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 767);
            this.Name = "CustomerForm";
            this.SuperTipParameter = "Customer,Customers";
            this.TabIcon = global::CDS.Client.Desktop.Company.Properties.Resources.businessman_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Company.Properties.Resources.businessman_16;
            this.Text = "Customer";
            this.Type = CDS.Client.BusinessLayer.ORG.ORG_Type.Customer;
            this.WaitFormNewRecordDescription = "Creating new Customer...";
            this.WaitFormOpenRecordDescription = "Opening Customer...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnStatement;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpCompany;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAccount;
    }
}