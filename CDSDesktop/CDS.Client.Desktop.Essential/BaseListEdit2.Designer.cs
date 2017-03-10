namespace CDS.Client.Desktop.Essential
{
    partial class BaseListEdit2
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseListEdit2));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnEditRecord = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewRecord = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmGridControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.popSave = new DevExpress.XtraBars.PopupMenu();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSave)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnEditRecord,
            this.btnNewRecord,
            this.btnUndo,
            this.btnSave,
            this.btnSaveAndClose});
            this.RibbonControl.Size = new System.Drawing.Size(1008, 147);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnSave);
            this.rpgActions.ItemLinks.Add(this.btnEditRecord);
            this.rpgActions.ItemLinks.Add(this.btnNewRecord);
            this.rpgActions.ItemLinks.Add(this.btnUndo);
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
            this.GridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridControl.DataSource = this.BindingSource;
            this.GridControl.Location = new System.Drawing.Point(2, 2);
            this.GridControl.MainView = this.GridView;
            this.GridControl.MenuManager = this.RibbonControl;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(1004, 578);
            this.GridControl.TabIndex = 0;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView});
            // 
            // BindingSource
            // 
            this.BindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.BindingSource_ListChanged);
            // 
            // GridView
            // 
            this.GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.GridView.GridControl = this.GridControl;
            this.GridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.GridView.Name = "GridView";
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowGroupPanel = false;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.GridView_ShowingEditor);
            this.GridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.GridView_InitNewRow);
            this.GridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyUp);
            this.GridView.DoubleClick += new System.EventHandler(this.GridView_DoubleClick);
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Caption = "Edit";
            this.btnEditRecord.Glyph = global::CDS.Client.Desktop.Essential.Properties.Resources.edit_16;
            this.btnEditRecord.Id = 3;
            this.btnEditRecord.LargeGlyph = global::CDS.Client.Desktop.Essential.Properties.Resources.edit_32;
            this.btnEditRecord.Name = "btnEditRecord";
            toolTipTitleItem1.Text = "Open";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click this button to open the selected {0} in the list";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnEditRecord.SuperTip = superToolTip1;
            this.btnEditRecord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditRecord_ItemClick);
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
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::CDS.Client.Desktop.Essential.Properties.Resources.undo_16;
            this.btnUndo.Id = 6;
            this.btnUndo.LargeGlyph = global::CDS.Client.Desktop.Essential.Properties.Resources.undo_32;
            this.btnUndo.Name = "btnUndo";
            toolTipTitleItem3.Text = "Refresh";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Click this button to refresh the current list of {1}";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnUndo.SuperTip = superToolTip3;
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.GridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 147);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1008, 582);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
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
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnSave.Caption = "Save";
            this.btnSave.DropDownControl = this.popSave;
            this.btnSave.Glyph = global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_16;
            this.btnSave.Id = 8;
            this.btnSave.LargeGlyph = global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_32;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // popSave
            // 
            this.popSave.ItemLinks.Add(this.btnSaveAndClose);
            this.popSave.Name = "popSave";
            this.popSave.Ribbon = this.RibbonControl;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Caption = "Save & Close";
            this.btnSaveAndClose.Glyph = global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_delete_16;
            this.btnSaveAndClose.Id = 9;
            this.btnSaveAndClose.LargeGlyph = global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_delete_32;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndClose_ItemClick);
            // 
            // BaseListEdit
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.layoutControl1);
            this.Name = "BaseListEdit";
            this.TabIcon = global::CDS.Client.Desktop.Essential.Properties.Resources.cube_blue;
            this.TabIconBackup = global::CDS.Client.Desktop.Essential.Properties.Resources.cube_blue;
            this.Shown += new System.EventHandler(this.BaseList_Shown);
            this.Controls.SetChildIndex(this.RibbonControl, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraGrid.GridControl GridControl;
        protected DevExpress.XtraGrid.Views.Grid.GridView GridView;
        private DevExpress.XtraBars.BarButtonItem btnEditRecord;
        private DevExpress.XtraBars.BarButtonItem btnNewRecord;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        protected DevExpress.XtraLayout.LayoutControl layoutControl1;
        protected DevExpress.XtraLayout.LayoutControlItem itmGridControl;
        protected DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        protected System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.PopupMenu popSave;

    }
}
