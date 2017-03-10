namespace CDS.Client.Desktop.Document.Supplier
{
    partial class PurchaseOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrderForm));
            this.btnOnline = new DevExpress.XtraBars.BarButtonItem();
            this.popOnline = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnValidate = new DevExpress.XtraBars.BarButtonItem();
            this.btnSentOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateGoodsReceived = new DevExpress.XtraBars.BarButtonItem();
            this.popGoodsReceived = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnViewGoodsReceived = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGoodsReceived)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnOnline, true);
            this.rpgActionDocument.ItemLinks.Add(this.btnCancel);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewGoodsReceived);
            // 
            // LayoutControl
            // 
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1105, 275, 659, 852);
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
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnOnline,
            this.btnSentOrder,
            this.btnValidate,
            this.btnCreateGoodsReceived,
            this.btnViewGoodsReceived,
            this.btnCancel});
            this.RibbonControl.MaxItemId = 30;
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
            // btnOnline
            // 
            this.btnOnline.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnOnline.Caption = "Online";
            this.btnOnline.DropDownControl = this.popOnline;
            this.btnOnline.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOnline.Glyph")));
            this.btnOnline.Id = 24;
            this.btnOnline.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOnline.LargeGlyph")));
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // popOnline
            // 
            this.popOnline.ItemLinks.Add(this.btnValidate);
            this.popOnline.ItemLinks.Add(this.btnSentOrder);
            this.popOnline.Name = "popOnline";
            this.popOnline.Ribbon = this.RibbonControl;
            // 
            // btnValidate
            // 
            this.btnValidate.Caption = "Validate";
            this.btnValidate.Glyph = ((System.Drawing.Image)(resources.GetObject("btnValidate.Glyph")));
            this.btnValidate.Id = 26;
            this.btnValidate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnValidate.LargeGlyph")));
            this.btnValidate.Name = "btnValidate";
            // 
            // btnSentOrder
            // 
            this.btnSentOrder.Caption = "Send Order";
            this.btnSentOrder.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSentOrder.Glyph")));
            this.btnSentOrder.Id = 25;
            this.btnSentOrder.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSentOrder.LargeGlyph")));
            this.btnSentOrder.Name = "btnSentOrder";
            // 
            // btnCreateGoodsReceived
            // 
            this.btnCreateGoodsReceived.Caption = "Create\r\nGoods Received";
            this.btnCreateGoodsReceived.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCreateGoodsReceived.Glyph")));
            this.btnCreateGoodsReceived.Id = 27;
            this.btnCreateGoodsReceived.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCreateGoodsReceived.LargeGlyph")));
            this.btnCreateGoodsReceived.Name = "btnCreateGoodsReceived";
            this.btnCreateGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateGoodsReceived.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateGoodsReceived_ItemClick);
            // 
            // popGoodsReceived
            // 
            this.popGoodsReceived.ItemLinks.Add(this.btnCreateGoodsReceived);
            this.popGoodsReceived.Name = "popGoodsReceived";
            this.popGoodsReceived.Ribbon = this.RibbonControl;
            // 
            // btnViewGoodsReceived
            // 
            this.btnViewGoodsReceived.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnViewGoodsReceived.Caption = "View Goods Received";
            this.btnViewGoodsReceived.DropDownControl = this.popGoodsReceived;
            this.btnViewGoodsReceived.Glyph = ((System.Drawing.Image)(resources.GetObject("btnViewGoodsReceived.Glyph")));
            this.btnViewGoodsReceived.Id = 28;
            this.btnViewGoodsReceived.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnViewGoodsReceived.LargeGlyph")));
            this.btnViewGoodsReceived.Name = "btnViewGoodsReceived";
            this.btnViewGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewGoodsReceived.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewGoodsReceived_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.Glyph")));
            this.btnCancel.Id = 29;
            this.btnCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.LargeGlyph")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // PurchaseOrderForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.CompanyType = CDS.Client.BusinessLayer.ORG.ORG_Type.Supplier;
            this.DocumentType = CDS.Client.BusinessLayer.SYS.SYS_DOC_Type.PurchaseOrder;
            this.Name = "PurchaseOrderForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.PurchaseDocument;
            this.TabColor = System.Drawing.Color.LightSeaGreen;
            this.TabIcon = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_16;
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGoodsReceived)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnOnline;
        private DevExpress.XtraBars.PopupMenu popOnline;
        private DevExpress.XtraBars.BarButtonItem btnValidate;
        private DevExpress.XtraBars.BarButtonItem btnSentOrder;
        private DevExpress.XtraBars.BarButtonItem btnCreateGoodsReceived;
        private DevExpress.XtraBars.PopupMenu popGoodsReceived;
        private DevExpress.XtraBars.BarButtonItem btnViewGoodsReceived;
        private DevExpress.XtraBars.BarButtonItem btnCancel; 
    }
}
