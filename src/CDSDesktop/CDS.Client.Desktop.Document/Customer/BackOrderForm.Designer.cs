namespace CDS.Client.Desktop.Document.Customer
{
    partial class BackOrderForm
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
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnCreateSalesOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewTAXInvoices = new DevExpress.XtraBars.BarButtonItem();
            this.popTAXInvoices = new DevExpress.XtraBars.PopupMenu();
            this.btnCreatePurchaseOrder = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewPurchaseOrders = new DevExpress.XtraBars.BarButtonItem();
            this.popPurchaseOrders = new DevExpress.XtraBars.PopupMenu();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popTAXInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popPurchaseOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnCancel, true);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewTAXInvoices);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewPurchaseOrders);
            // 
            // LayoutControl
            // 
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(924, 275, 659, 852);
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
            this.btnCreateSalesOrder,
            this.btnViewTAXInvoices,
            this.btnCreatePurchaseOrder,
            this.btnViewPurchaseOrders,
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
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(166, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(169, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnCreateSalesOrder
            // 
            this.btnCreateSalesOrder.Caption = "Create \r\nSales Order";
            this.btnCreateSalesOrder.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_new_16;
            this.btnCreateSalesOrder.Id = 24;
            this.btnCreateSalesOrder.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_new_32;
            this.btnCreateSalesOrder.Name = "btnCreateSalesOrder";
            this.btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateSalesOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateSalesOrder_ItemClick);
            // 
            // btnViewTAXInvoices
            // 
            this.btnViewTAXInvoices.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnViewTAXInvoices.Caption = "View\r\nTAX Invoice(s)";
            this.btnViewTAXInvoices.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewTAXInvoices.DropDownControl = this.popTAXInvoices;
            this.btnViewTAXInvoices.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_16;
            this.btnViewTAXInvoices.Id = 26;
            this.btnViewTAXInvoices.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_32;
            this.btnViewTAXInvoices.Name = "btnViewTAXInvoices";
            this.btnViewTAXInvoices.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewTAXInvoices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewTAXInvoices_ItemClick);
            // 
            // popTAXInvoices
            // 
            this.popTAXInvoices.ItemLinks.Add(this.btnCreateSalesOrder);
            this.popTAXInvoices.Name = "popTAXInvoices";
            this.popTAXInvoices.Ribbon = this.RibbonControl;
            // 
            // btnCreatePurchaseOrder
            // 
            this.btnCreatePurchaseOrder.Caption = "Create\r\nPurchace Order";
            this.btnCreatePurchaseOrder.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnCreatePurchaseOrder.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_new_16;
            this.btnCreatePurchaseOrder.Id = 27;
            this.btnCreatePurchaseOrder.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_new_32;
            this.btnCreatePurchaseOrder.Name = "btnCreatePurchaseOrder";
            this.btnCreatePurchaseOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreatePurchaseOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreatePurchaseOrder_ItemClick);
            // 
            // btnViewPurchaseOrders
            // 
            this.btnViewPurchaseOrders.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnViewPurchaseOrders.Caption = "View\r\nPurchase Order(s)";
            this.btnViewPurchaseOrders.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewPurchaseOrders.DropDownControl = this.popPurchaseOrders;
            this.btnViewPurchaseOrders.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_16;
            this.btnViewPurchaseOrders.Id = 28;
            this.btnViewPurchaseOrders.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_order_32;
            this.btnViewPurchaseOrders.Name = "btnViewPurchaseOrders";
            this.btnViewPurchaseOrders.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewPurchaseOrders.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewPurchaseOrders_ItemClick);
            // 
            // popPurchaseOrders
            // 
            this.popPurchaseOrders.ItemLinks.Add(this.btnCreatePurchaseOrder);
            this.popPurchaseOrders.Name = "popPurchaseOrders";
            this.popPurchaseOrders.Ribbon = this.RibbonControl;
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.delete_16;
            this.btnCancel.Id = 29;
            this.btnCancel.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.delete_32;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // BackOrderForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.DocumentType = CDS.Client.BusinessLayer.SYS.SYS_DOC_Type.BackOrder;
            this.Name = "BackOrderForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.SalesDocument;
            this.TabColor = System.Drawing.Color.LightSalmon;
            this.TabIcon = global::CDS.Client.Desktop.Document.Properties.Resources.document_back_order_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Document.Properties.Resources.document_back_order_16;
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popTAXInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popPurchaseOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarButtonItem btnCreateSalesOrder;
        private DevExpress.XtraBars.BarButtonItem btnViewTAXInvoices;
        private DevExpress.XtraBars.PopupMenu popTAXInvoices;
        private DevExpress.XtraBars.BarButtonItem btnCreatePurchaseOrder;
        private DevExpress.XtraBars.BarButtonItem btnViewPurchaseOrders;
        private DevExpress.XtraBars.PopupMenu popPurchaseOrders;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
    }
}
