﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.Wizards;
using DevExpress.XtraReports.Design;
using System.IO;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    [ToolboxItem(false)]
    public class WizPageStylesCustom : DevExpress.Utils.InteriorWizardPage
    {
        [ToolboxItem(false)]
        public class PreviewBox : System.Windows.Forms.PictureBox
        {
            string srTitle = "Title";
            string srCaption = "Caption";
            string srData = "data";
            
            [Category("String Resources")]
            [Localizable(true)]
            public string SRTitle { get { return srTitle; } set { srTitle = value; } }
            [Category("String Resources")]
            [Localizable(true)]
            public string SRCaption { get { return srCaption; } set { srCaption = value; } }
            [Category("String Resources")]
            [Localizable(true)]
            public string SRData { get { return srData; } set { srData = value; } }
        }
        
        [ToolboxItem(false)]
        public class StyleListView : System.Windows.Forms.ListView
        {
            string srBold = "Bold";
            string srCasual = "Casual";
            string srCompact = "Compact";
            string srCorporate = "Corporate";
            string srFormal = "Formal";
            string srBaseBlueStyle = "CDSBlue";
            //string srSeaLevel = "SeaLevel";

            //[Category("String Resources")]
            //[Localizable(true)]
            //public string SRBold { get { return srBold; } set { srBold = value; } }
            //[Category("String Resources")]
            //[Localizable(true)]
            //public string SRCasual { get { return srCasual; } set { srCasual = value; } }
            //[Category("String Resources")]
            //[Localizable(true)]
            //public string SRCompact { get { return srCompact; } set { srCompact = value; } }
            //[Category("String Resources")]
            //[Localizable(true)]
            //public string SRCorporate { get { return srCorporate; } set { srCorporate = value; } }
            //[Category("String Resources")]
            //[Localizable(true)]
            //public string SRFormal { get { return srFormal; } set { srFormal = value; } }
            [Category("String Resources")]
            [Localizable(true)]
            public string SRBaseBlueStyle { get { return srBaseBlueStyle; } set { srBaseBlueStyle = value; } }
            //[Localizable(true), Category("Files Resources")]
            //public string SRSeaLevel { get { return srSeaLevel; } set { srSeaLevel = value; } }
        }

        private DevExpress.XtraReports.Design.WizPageStyle.PreviewBox picPreview;
        //private DevExpress.XtraReports.Design.WizPageStyle.StyleListView lvStyles;
        private StyleListView lvStyles;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        StandardReportWizard wizard;
        StringFormat stringFormat = StringFormat.GenericDefault.Clone() as StringFormat;
        ReportStyle[] styles;
        
        public WizPageStylesCustom(XRWizardRunnerBase runner)
            : this()
        {
            this.wizard = (StandardReportWizard)runner.Wizard;
        }

        WizPageStylesCustom()
        {
            InitializeComponent();
            //headerPicture.Image = ResourceImageHelper.CreateBitmapFromResources("Images.WizTopStyles.gif", typeof(LocalResFinder));
            stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
            styles = new ReportStyle[] {
                //new ReportStyle().StyleSheet.
                //new ReportStyle(lvStyles.SRBold, "Wizards.Bold.repss", typeof(DevExpress.XtraReports.ResFinder)),
                //new ReportStyle(lvStyles.SRCasual, "Wizards.Casual.repss", typeof(DevExpress.XtraReports.ResFinder)),
                //new ReportStyle(lvStyles.SRCompact, "Wizards.Compact.repss", typeof(DevExpress.XtraReports.ResFinder)),
                //new ReportStyle(lvStyles.SRCorporate, "Wizards.Corporate.repss", typeof(DevExpress.XtraReports.ResFinder)),
                //new ReportStyle(lvStyles.SRFormal, "Wizards.Formal.repss", typeof(DevExpress.XtraReports.ResFinder)),
                new ReportStyle(lvStyles.SRBaseBlueStyle, "BaseBlueStyle.repss", typeof(DevExpress.XtraReports.ResFinder))//,
                //new ReportStyle(lvStyles.SRSeaLevel, "SeaLevel.repx", typeof(DevExpress.XtraReports.Template))
									   };

            //Stream stream0 = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BaseBlueStyle.repss");

            Stream stream0 = new MemoryStream(global::CDS.Shared.Resources.Properties.Resources.BaseBlueStyle);
            
            styles[0].StyleSheet.LoadFromStream(stream0);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                stringFormat.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizPageStyle));
            this.picPreview = new DevExpress.XtraReports.Design.WizPageStyle.PreviewBox();
            //this.lvStyles = new DevExpress.XtraReports.Design.WizPageStyle.StyleListView();
            this.lvStyles = new StyleListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            resources.ApplyResources(this.titleLabel, "titleLabel");
            resources.ApplyResources(this.subtitleLabel, "subtitleLabel");
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.picPreview, "picPreview");
            this.picPreview.Name = "picPreview";
            this.picPreview.TabStop = false;
            this.lvStyles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1});
            this.lvStyles.FullRowSelect = true;
            this.lvStyles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStyles.HideSelection = false;
            resources.ApplyResources(this.lvStyles, "lvStyles");
            this.lvStyles.MultiSelect = false;
            this.lvStyles.Name = "lvStyles";
            this.lvStyles.UseCompatibleStateImageBehavior = false;
            this.lvStyles.View = System.Windows.Forms.View.Details;
            this.lvStyles.Resize += new System.EventHandler(this.lvStyles_Resize);
            this.lvStyles.SelectedIndexChanged += new System.EventHandler(this.lvStyles_SelectedIndexChanged);
            this.lvStyles.DoubleClick += new System.EventHandler(this.lvStyles_DoubleClick);
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            this.Controls.Add(this.lvStyles);
            this.Controls.Add(this.picPreview);
            this.Name = "WizPageStyle";
            this.Controls.SetChildIndex(this.headerPanel, 0);
            this.Controls.SetChildIndex(this.headerSeparator, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.subtitleLabel, 0);
            this.Controls.SetChildIndex(this.headerPicture, 0);
            this.Controls.SetChildIndex(this.picPreview, 0);
            this.Controls.SetChildIndex(this.lvStyles, 0);
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        XRControlStyleSheet GetStyleSheet()
        {
            ListViewItem item = null;
            if (lvStyles.SelectedItems.Count <= 0 && lvStyles.FocusedItem == null)
            {
                if (lvStyles.Items.Count <= 0)
                    return null;
                item = lvStyles.Items[0];
            }
            else
            {
                if (lvStyles.SelectedItems.Count > 0)
                    item = lvStyles.SelectedItems[0];
                else
                    item = lvStyles.FocusedItem;
            }
            ReportStyle style = (ReportStyle)item.Tag;
            return style.StyleSheet;
        }

        void DrawLineByStyle(Graphics gr, ref RectangleF rect, XRControlStyle style, string text)
        {
            rect.Height = gr.MeasureString(text, style.Font, rect.Size, stringFormat).Height;
            Brush brush = new SolidBrush(style.ForeColor);
            using (brush)
            {
                gr.DrawString(text, style.Font, brush, rect, stringFormat);
            }
            rect.Offset(0, rect.Height);
        }

        void DrawStyleSample(Graphics gr, Rectangle rect, XRControlStyleSheet styleSheet)
        {
            Region oldClip = gr.Clip;
            try
            {
                gr.Clip = new Region(rect);
                XRControlStyle titleStyle = styleSheet[ReportBuilder.StyleNameTitle];
                XRControlStyle fieldCaptionStyle = styleSheet[ReportBuilder.StyleNameFieldCaption];
                XRControlStyle fieldStyle = styleSheet[ReportBuilder.StyleNameDataField];
                RectangleF lineRect = rect;
                DrawLineByStyle(gr, ref lineRect, titleStyle, picPreview.SRTitle);
                DrawLineByStyle(gr, ref lineRect, fieldCaptionStyle, picPreview.SRCaption);
                DrawLineByStyle(gr, ref lineRect, fieldStyle, picPreview.SRData);
            }
            finally
            {
                gr.Clip = oldClip;
                oldClip.Dispose();
            }
        }

        void UpdateImage()
        {
            Image img = new Bitmap(CDS.Shared.Resources.Properties.Resources.WizStyles);
            //ResourceImageHelper.CreateBitmapFromResources("Images.WizStyles.gif", typeof(LocalResFinder));
            XRControlStyleSheet styleSheet = GetStyleSheet();
            if (styleSheet != null)
            {
                Bitmap newImage = new Bitmap(img.Width, img.Height);
                Graphics gr = Graphics.FromImage(newImage);
                using (gr)
                {
                    gr.DrawImage(img, 0, 0);
                    Rectangle rect = new Rectangle(43, 87, 148, 127);
                    DrawStyleSample(gr, rect, styleSheet);
                    img.Dispose();
                    img = newImage;
                }
            }
            picPreview.Image = img;

            //Image img = ResourceImageHelper.CreateBitmapFromResources("Images.WizStyles.gif", typeof(LocalResFinder));
            //XRControlStyleSheet styleSheet = GetStyleSheet();
            //if (styleSheet != null)
            //{
            //    Bitmap newImage = new Bitmap(img.Width, img.Height);
            //    Graphics gr = Graphics.FromImage(newImage);
            //    using (gr)
            //    {
            //        gr.DrawImage(img, 0, 0);
            //        Rectangle rect = new Rectangle(43, 87, 148, 127);
            //        DrawStyleSample(gr, rect, styleSheet);
            //        img.Dispose();
            //        img = newImage;
            //    }
            //}
            //picPreview.Image = img;
        }

        static void UpdateListViewColumnWidth(ListView lv)
        {
            lv.Columns[0].Width = lv.ClientRectangle.Width;
        }

        private void lvStyles_Resize(object sender, System.EventArgs e)
        {
            UpdateListViewColumnWidth(lvStyles);
        }

        protected override bool OnSetActive()
        {
            lvStyles.Items.Clear();
            int count = styles.Length;
            for (int i = 0; i < count; i++)
            {
                ListViewItem item = new ListViewItem(styles[i].Name);
                item.Tag = styles[i];
                lvStyles.Items.Add(item);
            }
            UpdateListViewColumnWidth(lvStyles);
            UpdateImage();
            lvStyles.Items[0].Selected = true;
            lvStyles.Items[0].Focused = true;
            lvStyles.Focus();

            WizardHelper.LastDataSourceWizardType = "WizPageStylesCustom";

            return base.OnSetActive(); 
        }

        protected override void UpdateWizardButtons()
        {
            Wizard.WizardButtons = WizardButton.Next | WizardButton.Back | WizardButton.Finish;
        }

        void ApplyChanges()
        {
            if (lvStyles.SelectedItems.Count > 0)
                wizard.Style = (ReportStyle)lvStyles.SelectedItems[0].Tag;
        }

        void RollbackChanges()
        {
            if (lvStyles.Items.Count > 0)
                wizard.Style = (ReportStyle)lvStyles.Items[0].Tag;
        }

        protected override string OnWizardBack()
        {
            RollbackChanges();
            return wizard.GroupingFieldsSet.Count > 0 ? "WizPageGroupedLayout" : "WizPageUngroupedLayout";
        }

        protected override string OnWizardNext()
        {
            ApplyChanges();
            base.OnWizardNext();
            return WizardForm.NextPage;
        }

        protected override bool OnWizardFinish()
        {
            ApplyChanges();
            base.OnWizardFinish();
            return true;
        }

        private void lvStyles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateImage();
        }

        private void lvStyles_DoubleClick(object sender, System.EventArgs e)
        {
            Wizard.PressButton(WizardButton.Next);
        }
    }
}
