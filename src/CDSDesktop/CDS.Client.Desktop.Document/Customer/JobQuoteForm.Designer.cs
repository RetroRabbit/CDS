namespace CDS.Client.Desktop.Document.Customer
{
    partial class JobQuoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobQuoteForm));
            this.btnLostSale = new DevExpress.XtraBars.BarButtonItem();
            this.btnCatalogue = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateJob = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewJob = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu
            // 
            this.radMenu.ItemLinks.Add(this.btnLostSale);
            this.radMenu.ItemLinks.Add(this.btnCatalogue);
            this.radMenu.ItemLinks.Add(this.btnCreateJob);
            // 
            // rpgActionDocument
            // 
            this.rpgActionDocument.ItemLinks.Add(this.btnCreateJob);
            this.rpgActionDocument.ItemLinks.Add(this.btnViewJob);
            this.rpgActionDocument.ItemLinks.Add(this.btnLostSale);
            this.rpgActionDocument.ItemLinks.Add(this.btnCatalogue);
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
            this.btnCreateJob,
            this.btnViewJob});
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
            // 
            // btnCreateJob
            // 
            this.btnCreateJob.Caption = "Create Job";
            this.btnCreateJob.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.wrench_new_16;
            this.btnCreateJob.Id = 25;
            this.btnCreateJob.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.wrench_new_32;
            this.btnCreateJob.Name = "btnCreateJob";
            this.btnCreateJob.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCreateJob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateJob_ItemClick);
            // 
            // btnViewJob
            // 
            this.btnViewJob.Caption = "View Job";
            this.btnViewJob.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewJob.Glyph = global::CDS.Client.Desktop.Document.Properties.Resources.wrench_16;
            this.btnViewJob.Id = 26;
            this.btnViewJob.LargeGlyph = global::CDS.Client.Desktop.Document.Properties.Resources.wrench_32;
            this.btnViewJob.Name = "btnViewJob";
            this.btnViewJob.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewJob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewJob_ItemClick);
            // 
            // JobQuoteForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.DocumentType = CDS.Client.BusinessLayer.SYS.SYS_DOC_Type.JobQuote;
            this.Name = "JobQuoteForm";
            this.ReportTemplate = CDS.Client.Desktop.Essential.BaseForm.ReportTemplateType.SalesDocument;
            this.SuperTipParameter = "Job Quote";
            this.TabColor = System.Drawing.Color.DarkOrange;
            this.TabIcon = global::CDS.Client.Desktop.Document.Properties.Resources.document_quote_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Document.Properties.Resources.document_quote_16;
            this.WaitFormNewRecordDescription = "Creating new Job Quote...";
            this.WaitFormOpenRecordDescription = "Opening Job Quote...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnLostSale;
        private DevExpress.XtraBars.BarButtonItem btnCatalogue;
        private DevExpress.XtraBars.BarButtonItem btnCreateJob;
        private DevExpress.XtraBars.BarButtonItem btnViewJob; 
    }
}
