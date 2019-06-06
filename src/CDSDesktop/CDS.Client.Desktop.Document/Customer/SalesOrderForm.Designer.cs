namespace CDS.Client.Desktop.Document.Customer
{
    partial class SalesOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesOrderForm));
            this.btnCreateOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnLostSale = new DevExpress.XtraBars.BarButtonItem();
            this.btnCatalogue = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewTAXInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.popBackOrder = new DevExpress.XtraBars.PopupMenu();
            this.btnViewBackOrders = new DevExpress.XtraBars.BarButtonItem();
            this.btnBarcodeScanner = new DevExpress.XtraBars.BarButtonItem();
            this.btnBuyout = new DevExpress.XtraBars.BarButtonItem();
            this.rpStock = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgActionStock = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popBackOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnCatalogue, true);
            this.rpgActionDocument.ItemLinks.Add(this.btnLostSale);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewTAXInvoice);
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
            this.btnLostSale,
            this.btnCatalogue,
            this.btnViewTAXInvoice,
            this.btnViewBackOrders,
            this.btnCreateOrder,
            this.btnBarcodeScanner,
            this.btnBuyout});
            this.RibbonControl.MaxItemId = 31;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpStock});
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
            // btnCreateOrder
            // 
            this.btnCreateOrder.Caption = "Create Order";
            this.btnCreateOrder.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCreateOrder.Glyph")));
            this.btnCreateOrder.Id = 22;
            this.btnCreateOrder.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCreateOrder.LargeGlyph")));
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnLostSale
            // 
            this.btnLostSale.Caption = "Lost Sale";
            this.btnLostSale.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLostSale.Glyph")));
            this.btnLostSale.Id = 23;
            this.btnLostSale.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLostSale.LargeGlyph")));
            this.btnLostSale.Name = "btnLostSale";
            this.btnLostSale.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnLostSale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLostSale_ItemClick);
            // 
            // btnCatalogue
            // 
            this.btnCatalogue.Caption = "Catalogue";
            this.btnCatalogue.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCatalogue.Glyph")));
            this.btnCatalogue.Id = 22;
            this.btnCatalogue.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCatalogue.LargeGlyph")));
            this.btnCatalogue.Name = "btnCatalogue";
            this.btnCatalogue.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCatalogue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCatalogue_ItemClick);
            // 
            // btnViewTAXInvoice
            // 
            this.btnViewTAXInvoice.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnViewTAXInvoice.Caption = "View\r\nTAX Invoice";
            this.btnViewTAXInvoice.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewTAXInvoice.DropDownControl = this.popBackOrder;
            this.btnViewTAXInvoice.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_16;
            this.btnViewTAXInvoice.Id = 26;
            this.btnViewTAXInvoice.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_32;
            this.btnViewTAXInvoice.Name = "btnViewTAXInvoice";
            this.btnViewTAXInvoice.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewTAXInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewTAXInvoice_ItemClick);
            // 
            // popBackOrder
            // 
            this.popBackOrder.ItemLinks.Add(this.btnCreateOrder);
            this.popBackOrder.ItemLinks.Add(this.btnViewBackOrders);
            this.popBackOrder.Name = "popBackOrder";
            this.popBackOrder.Ribbon = this.RibbonControl;
            // 
            // btnViewBackOrders
            // 
            this.btnViewBackOrders.Caption = "View\r\nBack Order(s)";
            this.btnViewBackOrders.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewBackOrders.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_back_order_16;
            this.btnViewBackOrders.Id = 27;
            this.btnViewBackOrders.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_back_order_32;
            this.btnViewBackOrders.Name = "btnViewBackOrders";
            this.btnViewBackOrders.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewBackOrders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewBackOrders_ItemClick);
            // 
            // btnBarcodeScanner
            // 
            this.btnBarcodeScanner.Caption = "Scan\r\nItems";
            this.btnBarcodeScanner.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.barcode_new_16;
            this.btnBarcodeScanner.Id = 29;
            this.btnBarcodeScanner.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.barcode_new_32;
            this.btnBarcodeScanner.Name = "btnBarcodeScanner";
            this.btnBarcodeScanner.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBarcodeScanner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBarcodeScanner_ItemClick);
            // 
            // btnBuyout
            // 
            this.btnBuyout.Caption = "Buyout";
            this.btnBuyout.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.platform_truck_16;
            this.btnBuyout.Id = 30;
            this.btnBuyout.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.platform_truck_32;
            this.btnBuyout.Name = "btnBuyout";
            this.btnBuyout.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBuyout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuyout_ItemClick);
            // 
            // rpStock
            // 
            this.rpStock.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgActionStock});
            this.rpStock.Name = "rpStock";
            this.rpStock.Text = "Stock";
            // 
            // rpgActionStock
            // 
            this.rpgActionStock.ItemLinks.Add(this.btnBarcodeScanner);
            this.rpgActionStock.ItemLinks.Add(this.btnBuyout);
            this.rpgActionStock.Name = "rpgActionStock";
            this.rpgActionStock.Text = "Action";
            // 
            // SalesOrderForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.DocumentType = CDS.Client.BusinessLayer.SYS.SYS_DOC_Type.SalesOrder;
            this.Name = "SalesOrderForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.SalesDocument;
            this.TabColor = System.Drawing.Color.LightBlue;
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
            ((System.ComponentModel.ISupportInitialize)(this.popBackOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnCreateOrder;
        private DevExpress.XtraBars.BarButtonItem btnLostSale;
        private DevExpress.XtraBars.BarButtonItem btnCatalogue;
        private DevExpress.XtraBars.BarButtonItem btnViewTAXInvoice;
        private DevExpress.XtraBars.BarButtonItem btnViewBackOrders;
        private DevExpress.XtraBars.PopupMenu popBackOrder;
        private DevExpress.XtraBars.BarButtonItem btnBarcodeScanner;
        private DevExpress.XtraBars.BarButtonItem btnBuyout;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpStock;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActionStock;

    }
}
