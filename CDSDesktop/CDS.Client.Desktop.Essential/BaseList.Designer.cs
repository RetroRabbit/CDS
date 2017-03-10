namespace CDS.Client.Desktop.Essential
{
    partial class BaseList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseList));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.XPOInstantFeedbackSource = new DevExpress.Xpo.XPInstantFeedbackSource();
            this.GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnOpenRecord = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewRecord = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.LayoutControlGrid = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmGridControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).BeginInit();
            this.LayoutControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnOpenRecord,
            this.btnNewRecord,
            this.btnRefresh});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RibbonControl.MaxItemId = 2;
            this.RibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchControl1});
            this.RibbonControl.Size = new System.Drawing.Size(1008, 147);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnOpenRecord);
            this.rpgActions.ItemLinks.Add(this.btnNewRecord);
            this.rpgActions.ItemLinks.Add(this.btnRefresh);
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
            // GridControl
            // 
            this.GridControl.DataSource = this.XPOInstantFeedbackSource;
            this.GridControl.Location = new System.Drawing.Point(2, 2);
            this.GridControl.MainView = this.GridView;
            this.GridControl.MenuManager = this.RibbonControl;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(1004, 578);
            this.GridControl.TabIndex = 0;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView});
            // 
            // GridView
            // 
            this.GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.GridView.GridControl = this.GridControl;
            this.GridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.GridView.Name = "GridView";
            //this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GridView_PopupMenuShowing);
            this.GridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyUp);
            this.GridView.DoubleClick += new System.EventHandler(this.GridView_DoubleClick);
            // 
            // btnOpenRecord
            // 
            this.btnOpenRecord.Caption = "Open";
            this.btnOpenRecord.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpenRecord.Glyph")));
            this.btnOpenRecord.Id = 3;
            this.btnOpenRecord.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpenRecord.LargeGlyph")));
            this.btnOpenRecord.Name = "btnOpenRecord";
            toolTipTitleItem1.Text = "Open";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click this button to open the selected {0} in the list";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnOpenRecord.SuperTip = superToolTip1;
            this.btnOpenRecord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenRecord_ItemClick);
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.Caption = "New";
            this.btnNewRecord.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNewRecord.Glyph")));
            this.btnNewRecord.Id = 5;
            this.btnNewRecord.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNewRecord.LargeGlyph")));
            this.btnNewRecord.Name = "btnNewRecord";
            toolTipTitleItem2.Text = "New";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Click this button to create a new {0}";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnNewRecord.SuperTip = superToolTip2;
            this.btnNewRecord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewRecord_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 6;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.Name = "btnRefresh";
            toolTipTitleItem3.Text = "Refresh";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Click this button to refresh the current list of {1}";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnRefresh.SuperTip = superToolTip3;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // LayoutControlGrid
            // 
            this.LayoutControlGrid.Controls.Add(this.GridControl);
            this.LayoutControlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControlGrid.Location = new System.Drawing.Point(0, 147);
            this.LayoutControlGrid.Name = "LayoutControlGrid";
            this.LayoutControlGrid.Root = this.layoutControlGroup1;
            this.LayoutControlGrid.Size = new System.Drawing.Size(1008, 582);
            this.LayoutControlGrid.TabIndex = 2;
            this.LayoutControlGrid.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmGridControl});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1008, 582);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // itmGridControl
            // 
            this.itmGridControl.Control = this.GridControl;
            this.itmGridControl.CustomizationFormText = "itmGridControl";
            this.itmGridControl.Location = new System.Drawing.Point(0, 0);
            this.itmGridControl.Name = "itmGridControl";
            this.itmGridControl.Size = new System.Drawing.Size(1008, 582);
            this.itmGridControl.Text = "itmGridControl";
            this.itmGridControl.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridControl.TextVisible = false;
            // 
            // repositoryItemSearchControl1
            // 
            this.repositoryItemSearchControl1.AutoHeight = false;
            this.repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.repositoryItemSearchControl1.Client = this.GridControl;
            this.repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            // 
            // BaseList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.LayoutControlGrid);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BaseList";
            this.Shown += new System.EventHandler(this.BaseList_Shown);
            this.Controls.SetChildIndex(this.RibbonControl, 0);
            this.Controls.SetChildIndex(this.LayoutControlGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).EndInit();
            this.LayoutControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraGrid.GridControl GridControl;
        protected DevExpress.XtraGrid.Views.Grid.GridView GridView;
        private DevExpress.XtraBars.BarButtonItem btnOpenRecord;
        private DevExpress.XtraBars.BarButtonItem btnNewRecord;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected DevExpress.XtraLayout.LayoutControl LayoutControlGrid;
        protected DevExpress.XtraLayout.LayoutControlItem itmGridControl;
        protected DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        protected DevExpress.Xpo.XPInstantFeedbackSource XPOInstantFeedbackSource;

    }
}
