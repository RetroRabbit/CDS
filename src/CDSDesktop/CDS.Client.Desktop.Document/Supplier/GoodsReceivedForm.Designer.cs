namespace CDS.Client.Desktop.Document.Supplier
{
    partial class GoodsReceivedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsReceivedForm));
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.btnCreateGoodsReturned = new DevExpress.XtraBars.BarButtonItem();
            this.popCredits = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnViewGoodsReturned = new DevExpress.XtraBars.BarButtonItem();
            this.rpStock = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgActionStock = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnBarcodeScanner = new DevExpress.XtraBars.BarButtonItem();
            this.btnBuyout = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.AllowMinimize = false;
            this.rpgActionDocument.ItemLinks.Add(this.btnViewGoodsReturned, true);
            // 
            // LayoutControl
            // 
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2745, 664, 659, 852);
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
            this.btnCreateGoodsReturned,
            this.btnViewGoodsReturned,
            this.btnBuyout,
            this.btnBarcodeScanner});
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
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // btnCreateGoodsReturned
            // 
            this.btnCreateGoodsReturned.Caption = "Create\r\nGoods Returned";
            this.btnCreateGoodsReturned.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCreateGoodsReturned.Glyph")));
            this.btnCreateGoodsReturned.Id = 22;
            this.btnCreateGoodsReturned.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCreateGoodsReturned.LargeGlyph")));
            this.btnCreateGoodsReturned.Name = "btnCreateGoodsReturned";
            this.btnCreateGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateGoodsReturned.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateGoodsReturned_ItemClick);
            // 
            // popCredits
            // 
            this.popCredits.ItemLinks.Add(this.btnCreateGoodsReturned);
            this.popCredits.Name = "popCredits";
            this.popCredits.Ribbon = this.RibbonControl;
            // 
            // btnViewGoodsReturned
            // 
            this.btnViewGoodsReturned.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnViewGoodsReturned.Caption = "View Goods Returned(s)";
            this.btnViewGoodsReturned.DropDownControl = this.popCredits;
            this.btnViewGoodsReturned.Glyph = ((System.Drawing.Image)(resources.GetObject("btnViewGoodsReturned.Glyph")));
            this.btnViewGoodsReturned.Id = 23;
            this.btnViewGoodsReturned.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnViewGoodsReturned.LargeGlyph")));
            this.btnViewGoodsReturned.Name = "btnViewGoodsReturned";
            this.btnViewGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewGoodsReturned.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewGoodsReturned_ItemClick);
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
            this.rpgActionStock.AllowTextClipping = false;
            this.rpgActionStock.ItemLinks.Add(this.btnBarcodeScanner);
            this.rpgActionStock.ItemLinks.Add(this.btnBuyout);
            this.rpgActionStock.Name = "rpgActionStock";
            this.rpgActionStock.Text = "Action";
            // 
            // btnBarcodeScanner
            // 
            this.btnBarcodeScanner.Caption = "Scan\r\nItems";
            this.btnBarcodeScanner.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.barcode_new_16;
            this.btnBarcodeScanner.Id = 30;
            this.btnBarcodeScanner.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.barcode_new_32;
            this.btnBarcodeScanner.Name = "btnBarcodeScanner";
            this.btnBarcodeScanner.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBarcodeScanner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBarcodeScanner_ItemClick);
            // 
            // btnBuyout
            // 
            this.btnBuyout.Caption = "Buyout";
            this.btnBuyout.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnBuyout.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.platform_truck_16;
            this.btnBuyout.Id = 29;
            this.btnBuyout.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.platform_truck_32;
            this.btnBuyout.Name = "btnBuyout";
            this.btnBuyout.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBuyout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuyout_ItemClick);
            // 
            // GoodsReceivedForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.CompanyType = CDS.Client.BusinessLayer.ORG.ORG_Type.Supplier;
            this.DocumentType = CDS.Client.BusinessLayer.SYS.SYS_DOC_Type.GoodsReceived;
            this.Name = "GoodsReceivedForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.PurchaseDocument;
            this.TabColor = System.Drawing.Color.Thistle;
            this.TabIcon = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_16;
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popCredits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnCreateGoodsReturned;
        private DevExpress.XtraBars.BarButtonItem btnViewGoodsReturned;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraBars.PopupMenu popCredits;
        private DevExpress.XtraBars.BarButtonItem btnBuyout;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpStock;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActionStock;
        private DevExpress.XtraBars.BarButtonItem btnBarcodeScanner;
    }
}
