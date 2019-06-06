namespace CDS.Client.Desktop.Document.Customer
{
    partial class TAXInvoiceForm
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
            this.btnCreateCreditNote = new DevExpress.XtraBars.BarButtonItem();
            this.popCredits = new DevExpress.XtraBars.PopupMenu();
            this.btnViewCredits = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnViewCredits, true);
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
            this.btnCreateCreditNote,
            this.btnViewCredits});
            this.RibbonControl.MaxItemId = 27;
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
            // btnCreateCreditNote
            // 
            this.btnCreateCreditNote.Caption = "Create Credit Note";
            this.btnCreateCreditNote.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_credit_new_16;
            this.btnCreateCreditNote.Id = 25;
            this.btnCreateCreditNote.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_credit_new_32;
            this.btnCreateCreditNote.Name = "btnCreateCreditNote";
            this.btnCreateCreditNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateCreditNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateCreditNote_ItemClick);
            // 
            // popCredits
            // 
            this.popCredits.ItemLinks.Add(this.btnCreateCreditNote);
            this.popCredits.Name = "popCredits";
            this.popCredits.Ribbon = this.RibbonControl;
            // 
            // btnViewCredits
            // 
            this.btnViewCredits.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnViewCredits.Caption = "View\r\nCredit Note(s)";
            this.btnViewCredits.DropDownControl = this.popCredits;
            this.btnViewCredits.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_credit_16;
            this.btnViewCredits.Id = 26;
            this.btnViewCredits.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.document_credit_32;
            this.btnViewCredits.Name = "btnViewCredits";
            this.btnViewCredits.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewCredits.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewCredits_ItemClick);
            // 
            // TAXInvoiceForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.DocumentType = CDS.Client.BusinessLayer.SYS.SYS_DOC_Type.TAXInvoice;
            this.Name = "TAXInvoiceForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.SalesDocument;
            this.TabColor = System.Drawing.Color.LightCyan;
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
            ((System.ComponentModel.ISupportInitialize)(this.popCredits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnCreateCreditNote;
        private DevExpress.XtraBars.PopupMenu popCredits;
        private DevExpress.XtraBars.BarButtonItem btnViewCredits;


    }
}
