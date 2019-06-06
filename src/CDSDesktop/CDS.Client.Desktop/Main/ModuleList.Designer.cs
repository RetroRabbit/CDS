namespace CDS.Client.Desktop.Main
{
    partial class ModuleList
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
            this.colModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnActivateModule = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeActivate = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).BeginInit();
            this.LayoutControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl.Size = new System.Drawing.Size(1004, 577);
            // 
            // GridView
            // 
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModule,
            this.colDescription,
            this.colAccess});
            this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowGroupPanel = false;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridView_FocusedRowChanged);
            // 
            // LayoutControlGrid
            // 
            this.LayoutControlGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(1008, 581);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(1008, 581);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(1008, 581);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnActivateModule,
            this.btnDeActivate});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.MaxItemId = 9;
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnActivateModule);
            this.rpgActions.ItemLinks.Add(this.btnDeActivate);
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
            // colModule
            // 
            this.colModule.FieldName = "Module";
            this.colModule.Name = "colModule";
            this.colModule.OptionsColumn.AllowMove = false;
            this.colModule.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colModule.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colModule.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colModule.Visible = true;
            this.colModule.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colAccess
            // 
            this.colAccess.FieldName = "Access";
            this.colAccess.Name = "colAccess";
            this.colAccess.OptionsColumn.AllowMove = false;
            this.colAccess.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colAccess.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAccess.Visible = true;
            this.colAccess.VisibleIndex = 2;
            // 
            // btnActivateModule
            // 
            this.btnActivateModule.Caption = "Activate\r\nModule";
            this.btnActivateModule.Glyph = global::CDS.Client.Desktop.Properties.Resources.checkbox_16;
            this.btnActivateModule.Id = 7;
            this.btnActivateModule.LargeGlyph = global::CDS.Client.Desktop.Properties.Resources.checkbox_32;
            this.btnActivateModule.Name = "btnActivateModule";
            this.btnActivateModule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActivateModule_ItemClick);
            // 
            // btnDeActivate
            // 
            this.btnDeActivate.Caption = "De-Activate\r\nModule";
            this.btnDeActivate.Glyph = global::CDS.Client.Desktop.Properties.Resources.unchecked_16;
            this.btnDeActivate.Id = 8;
            this.btnDeActivate.LargeGlyph = global::CDS.Client.Desktop.Properties.Resources.unchecked_32;
            this.btnDeActivate.Name = "btnDeActivate";
            this.btnDeActivate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDeActivate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeActivate_ItemClick);
            // 
            // ModuleList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ModuleList";
            this.Text = "Modules";
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).EndInit();
            this.LayoutControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colModule;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAccess;
        private DevExpress.XtraBars.BarButtonItem btnActivateModule;
        private DevExpress.XtraBars.BarButtonItem btnDeActivate;
    }
}
