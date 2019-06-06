namespace CDS.Client.Desktop.Essential
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.rpgNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.popSave = new DevExpress.XtraBars.PopupMenu();
            this.btnSaveAndEmail = new DevExpress.XtraBars.BarButtonItem();
            this.ValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.btnArchive = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefreshEntry = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // rpHome
            // 
            this.rpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgNavigation});
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrevious,
            this.btnNext,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnSaveAndNew,
            this.btnSaveAndClose,
            this.btnSave,
            this.btnSaveAndEmail,
            this.btnArchive,
            this.btnRefreshEntry});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RibbonControl.MaxItemId = 26;
            this.RibbonControl.Size = new System.Drawing.Size(1008, 147);
            // 
            // rpgActions
            // 
            this.rpgActions.AllowTextClipping = false;
            this.rpgActions.ItemLinks.Add(this.btnSave);
            this.rpgActions.ItemLinks.Add(this.btnArchive);
            this.rpgActions.ItemLinks.Add(this.btnRefreshEntry);
            // 
            // rpgPrint
            // 
            this.rpgPrint.AllowTextClipping = false;
            // 
            // LayoutControl
            // 
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 147);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.Root = this.LayoutGroup;
            this.LayoutControl.Size = new System.Drawing.Size(1008, 582);
            this.LayoutControl.TabIndex = 2;
            this.LayoutControl.Text = "layoutControl1";
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.CustomizationFormText = "LayoutGroup";
            this.LayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutGroup.GroupBordersVisible = false;
            this.LayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.LayoutGroup.Name = "LayoutGroup";
            this.LayoutGroup.Size = new System.Drawing.Size(1008, 582);
            this.LayoutGroup.Text = "LayoutGroup";
            this.LayoutGroup.TextVisible = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Caption = "Previous";
            this.btnPrevious.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Glyph")));
            this.btnPrevious.Id = 9;
            this.btnPrevious.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPrevious.LargeGlyph")));
            this.btnPrevious.Name = "btnPrevious";
            toolTipTitleItem1.Text = "Previous";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click this button to navigate to the previous {0}";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnPrevious.SuperTip = superToolTip1;
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrevious_ItemClick);
            // 
            // btnNext
            // 
            this.btnNext.Caption = "Next";
            this.btnNext.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNext.Glyph")));
            this.btnNext.Id = 10;
            this.btnNext.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNext.LargeGlyph")));
            this.btnNext.Name = "btnNext";
            toolTipTitleItem2.Text = "Next";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Click this button to navigate to the next {0}";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnNext.SuperTip = superToolTip2;
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNext_ItemClick);
            // 
            // rpgNavigation
            // 
            this.rpgNavigation.AllowTextClipping = false;
            this.rpgNavigation.ItemLinks.Add(this.btnPrevious);
            this.rpgNavigation.ItemLinks.Add(this.btnNext);
            this.rpgNavigation.MergeOrder = 300;
            this.rpgNavigation.Name = "rpgNavigation";
            this.rpgNavigation.ShowCaptionButton = false;
            this.rpgNavigation.Text = "Navigation";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Caption = "Save and New";
            this.btnSaveAndNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndNew.Glyph")));
            this.btnSaveAndNew.Id = 19;
            this.btnSaveAndNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndNew.LargeGlyph")));
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            toolTipTitleItem3.Text = "Save";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Click button to save {0} and create new {0}";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnSaveAndNew.SuperTip = superToolTip3;
            this.btnSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndNew_ItemClick);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Caption = "Save and Close";
            this.btnSaveAndClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Glyph")));
            this.btnSaveAndClose.Id = 20;
            this.btnSaveAndClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.LargeGlyph")));
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            toolTipTitleItem4.Text = "Save";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Click button to save {0} and close screen";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnSaveAndClose.SuperTip = superToolTip4;
            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndClose_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnSave.Caption = "Save";
            this.btnSave.DropDownControl = this.popSave;
            this.btnSave.Id = 21;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.Name = "btnSave";
            toolTipTitleItem6.Text = "Save";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "Click button to save {0}";
            toolTipTitleItem7.LeftIndent = 6;
            toolTipTitleItem7.Text = "Click arrow to see more options";
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            superToolTip6.Items.Add(toolTipSeparatorItem1);
            superToolTip6.Items.Add(toolTipTitleItem7);
            this.btnSave.SuperTip = superToolTip6;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // popSave
            // 
            this.popSave.ItemLinks.Add(this.btnSaveAndNew);
            this.popSave.ItemLinks.Add(this.btnSaveAndEmail);
            this.popSave.ItemLinks.Add(this.btnSaveAndClose);
            this.popSave.Name = "popSave";
            this.popSave.Ribbon = this.RibbonControl;
            // 
            // btnSaveAndEmail
            // 
            this.btnSaveAndEmail.Caption = "Save and E-Mail";
            this.btnSaveAndEmail.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndEmail.Glyph")));
            this.btnSaveAndEmail.Id = 22;
            this.btnSaveAndEmail.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndEmail.LargeGlyph")));
            this.btnSaveAndEmail.Name = "btnSaveAndEmail";
            toolTipTitleItem5.Text = "Save";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "Click button to save and email {0}";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnSaveAndEmail.SuperTip = superToolTip5;
            this.btnSaveAndEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndEmail_ItemClick);
            // 
            // btnArchive
            // 
            this.btnArchive.Caption = "Archive";
            this.btnArchive.Glyph = ((System.Drawing.Image)(resources.GetObject("btnArchive.Glyph")));
            this.btnArchive.Id = 23;
            this.btnArchive.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnArchive.LargeGlyph")));
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnArchive.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnArchive_ItemClick);
            // 
            // btnRefreshEntry
            // 
            this.btnRefreshEntry.Caption = "Refresh";
            this.btnRefreshEntry.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnRefreshEntry.Glyph = global::CDS.Client.Desktop.Essential.Properties.Resources.refresh_16;
            this.btnRefreshEntry.Id = 25;
            this.btnRefreshEntry.LargeGlyph = global::CDS.Client.Desktop.Essential.Properties.Resources.refresh_32;
            this.btnRefreshEntry.Name = "btnRefreshEntry";
            this.btnRefreshEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRefreshEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefreshEntry_ItemClick);
            // 
            // BaseForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.LayoutControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BaseForm";
            this.TabIcon = global::CDS.Client.Desktop.Essential.Properties.Resources.cube_blue;
            this.TabIconBackup = global::CDS.Client.Desktop.Essential.Properties.Resources.cube_blue;
            this.Resize += new System.EventHandler(this.BaseForm_Resize);
            this.Controls.SetChildIndex(this.RibbonControl, 0);
            this.Controls.SetChildIndex(this.LayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        protected System.Windows.Forms.BindingSource BindingSource;
        protected DevExpress.XtraLayout.LayoutControl LayoutControl;
        protected DevExpress.XtraLayout.LayoutControlGroup LayoutGroup;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        protected DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.PopupMenu popSave;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgNavigation;
        protected DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ValidationProvider;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndEmail;
        protected DevExpress.XtraBars.BarButtonItem btnArchive;
        private DevExpress.XtraBars.BarButtonItem btnRefreshEntry;


    }
}
