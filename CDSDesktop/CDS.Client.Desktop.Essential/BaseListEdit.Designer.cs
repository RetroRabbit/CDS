namespace CDS.Client.Desktop.Essential
{
    partial class BaseListEdit
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
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.popSave = new DevExpress.XtraBars.PopupMenu();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.XPCollection = new DevExpress.Xpo.XPCollection();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).BeginInit();
            this.LayoutControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.DataSource = this.XPCollection;
            // 
            // GridView
            // 
            this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.GridView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            // 
            // LayoutControlGrid
            // 
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnEdit,
            this.btnUndo,
            this.btnSave,
            this.btnSaveAndClose});
            this.RibbonControl.MaxItemId = 10;
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnSave);
            this.rpgActions.ItemLinks.Add(this.btnEdit);
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
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::CDS.Client.Desktop.Essential.Properties.Resources.edit_16;
            this.btnEdit.Id = 6;
            this.btnEdit.LargeGlyph = global::CDS.Client.Desktop.Essential.Properties.Resources.edit_32;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = global::CDS.Client.Desktop.Essential.Properties.Resources.undo_16;
            this.btnUndo.Id = 7;
            this.btnUndo.LargeGlyph = global::CDS.Client.Desktop.Essential.Properties.Resources.undo_32;
            this.btnUndo.Name = "btnUndo";
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
            // 
            // BaseListEdit
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "BaseListEdit";
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).EndInit();
            this.LayoutControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.PopupMenu popSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        protected DevExpress.Xpo.XPCollection XPCollection;
    }
}
