namespace CDS.Client.Desktop.Document.Customer
{
    partial class QuoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuoteForm));
            this.btnLostSale = new DevExpress.XtraBars.BarButtonItem();
            this.btnCatalogue = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewSalesOrder = new DevExpress.XtraBars.BarButtonItem();
            this.popSalesOrder = new DevExpress.XtraBars.PopupMenu();
            this.btnCreateSalesOrder = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSalesOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu
            // 
            this.radMenu.ItemLinks.Add(this.btnLostSale);
            this.radMenu.ItemLinks.Add(this.btnCatalogue);
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnCatalogue, true);
            this.rpgActionDocument.ItemLinks.Add(this.btnLostSale);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewSalesOrder);
            // 
            // LayoutControl
            // 
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1097, 251, 250, 350);
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
            this.btnViewSalesOrder,
            this.btnCreateSalesOrder});
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
            // btnLostSale
            // 
            this.btnLostSale.Caption = "Lost Sale";
            this.btnLostSale.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLostSale.Glyph")));
            this.btnLostSale.Id = 23;
            this.btnLostSale.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLostSale.LargeGlyph")));
            this.btnLostSale.Name = "btnLostSale";
            this.btnLostSale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLostSale_ItemClick);
            // 
            // btnCatalogue
            // 
            this.btnCatalogue.Caption = "Catalogue";
            this.btnCatalogue.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCatalogue.Glyph")));
            this.btnCatalogue.Id = 24;
            this.btnCatalogue.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCatalogue.LargeGlyph")));
            this.btnCatalogue.Name = "btnCatalogue";
            this.btnCatalogue.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCatalogue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCatalogue_ItemClick);
            // 
            // btnViewSalesOrder
            // 
            this.btnViewSalesOrder.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnViewSalesOrder.Caption = "View Sales Order";
            this.btnViewSalesOrder.DropDownControl = this.popSalesOrder;
            this.btnViewSalesOrder.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_16;
            this.btnViewSalesOrder.Id = 28;
            this.btnViewSalesOrder.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_32;
            this.btnViewSalesOrder.Name = "btnViewSalesOrder";
            this.btnViewSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewSalesOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewSalesOrder_ItemClick);
            // 
            // popSalesOrder
            // 
            this.popSalesOrder.ItemLinks.Add(this.btnCreateSalesOrder);
            this.popSalesOrder.Name = "popSalesOrder";
            this.popSalesOrder.Ribbon = this.RibbonControl;
            // 
            // btnCreateSalesOrder
            // 
            this.btnCreateSalesOrder.Caption = "Create Sales Order";
            this.btnCreateSalesOrder.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnCreateSalesOrder.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_new_16;
            this.btnCreateSalesOrder.Id = 29;
            this.btnCreateSalesOrder.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_new_32;
            this.btnCreateSalesOrder.Name = "btnCreateSalesOrder";
            this.btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateSalesOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateSalesOrder_ItemClick);
            // 
            // QuoteForm
            // 
            this.TabColor = System.Drawing.Color.LightGreen;
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "QuoteForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.SalesDocument;
            this.SuperTipParameter = "Quote";
            this.TabIcon = global::CDS.Client.Desktop.Document.Properties.Resources.document_quote_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Document.Properties.Resources.document_quote_16;
            this.WaitFormNewRecordDescription = "Opening new Quote...";
            this.WaitFormOpenRecordDescription = "Opening Quote...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSalesOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnLostSale;
        private DevExpress.XtraBars.BarButtonItem btnCatalogue;
        private DevExpress.XtraBars.BarButtonItem btnViewSalesOrder;
        private DevExpress.XtraBars.PopupMenu popSalesOrder;
        private DevExpress.XtraBars.BarButtonItem btnCreateSalesOrder; 
    }
}
