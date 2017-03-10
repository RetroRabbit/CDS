namespace CDS.Client.Desktop.Document.Customer
{
    partial class CreditNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditNoteForm));
            this.btnApprove = new DevExpress.XtraBars.BarButtonItem();
            this.popCreditAction = new DevExpress.XtraBars.PopupMenu();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewTAXInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popCreditAction)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnApprove, true);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewTAXInvoice);
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
            this.btnApprove,
            this.btnCancel,
            this.btnViewTAXInvoice,
            this.barButtonItem1});
            this.RibbonControl.MaxItemId = 31;
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
            // btnApprove
            // 
            this.btnApprove.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnApprove.Caption = "Approve";
            this.btnApprove.DropDownControl = this.popCreditAction;
            this.btnApprove.Glyph = ((System.Drawing.Image)(resources.GetObject("btnApprove.Glyph")));
            this.btnApprove.Id = 22;
            this.btnApprove.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnApprove.LargeGlyph")));
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApprove_ItemClick);
            // 
            // popCreditAction
            // 
            this.popCreditAction.ItemLinks.Add(this.btnCancel);
            this.popCreditAction.Name = "popCreditAction";
            this.popCreditAction.Ribbon = this.RibbonControl;
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.Glyph")));
            this.btnCancel.Id = 23;
            this.btnCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.LargeGlyph")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnViewTAXInvoice
            // 
            this.btnViewTAXInvoice.Caption = "View\r\nTAX Invoice";
            this.btnViewTAXInvoice.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_16;
            this.btnViewTAXInvoice.Id = 29;
            this.btnViewTAXInvoice.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_invoice_32;
            this.btnViewTAXInvoice.Name = "btnViewTAXInvoice";
            this.btnViewTAXInvoice.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewTAXInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewTAXInvoice_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "btnCreateCreditNote";
            this.barButtonItem1.Id = 30;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // CreditNoteForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.DocumentType = CDS.Client.BusinessLayer.SYS.SYS_DOC_Type.CreditNote;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "CreditNoteForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.SalesDocument;
            this.TabColor = System.Drawing.Color.LightGoldenrodYellow;
            this.TabIcon = global::CDS.Client.Desktop.Document.Properties.Resources.document_credit_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Document.Properties.Resources.document_credit_16;
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popCreditAction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnApprove;
        private DevExpress.XtraBars.PopupMenu popCreditAction;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnViewTAXInvoice;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
