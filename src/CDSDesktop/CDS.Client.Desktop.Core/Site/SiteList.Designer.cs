namespace CDS.Client.Desktop.Core.Site
{
    partial class SiteList
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
            this.colCodeMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCopySite = new DevExpress.XtraBars.BarButtonItem();
            this.colRegistrationNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatNumber = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl.Size = new System.Drawing.Size(626, 214);
            // 
            // GridView
            // 
            this.GridView.ActiveFilterString = "[EntityId.Archived] = False";
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeMain,
            this.colShortName,
            this.colName,
            this.colDescription,
            this.colArchived,
            this.colRegistrationNumber,
            this.colVatNumber});
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(630, 218);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(630, 218);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(630, 218);
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.SYS_Site);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCopySite});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.MaxItemId = 8;
            this.RibbonControl.Size = new System.Drawing.Size(630, 144);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnCopySite);
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
            // colCodeMain
            // 
            this.colCodeMain.Caption = "Code Main";
            this.colCodeMain.FieldName = "EntityId.CodeMain";
            this.colCodeMain.Name = "colCodeMain";
            this.colCodeMain.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodeMain.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCodeMain.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCodeMain.Visible = true;
            this.colCodeMain.VisibleIndex = 0;
            // 
            // colShortName
            // 
            this.colShortName.Caption = "Short Name";
            this.colShortName.FieldName = "EntityId.ShortName";
            this.colShortName.Name = "colShortName";
            this.colShortName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShortName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShortName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "EntityId.Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "EntityId.Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colDescription.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            // 
            // colArchived
            // 
            this.colArchived.Caption = "Archived";
            this.colArchived.FieldName = "EntityId.Archived";
            this.colArchived.Name = "colArchived";
            this.colArchived.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colArchived.Visible = true;
            this.colArchived.VisibleIndex = 4;
            // 
            // btnCopySite
            // 
            this.btnCopySite.Caption = "Copy Site";
            this.btnCopySite.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.copy_16;
            this.btnCopySite.Id = 7;
            this.btnCopySite.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.copy_32;
            this.btnCopySite.Name = "btnCopySite";
            this.btnCopySite.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopySite_ItemClick);
            // 
            // colRegistrationNumber
            // 
            this.colRegistrationNumber.Caption = "Registration Number";
            this.colRegistrationNumber.FieldName = "RegistrationNumber";
            this.colRegistrationNumber.Name = "colRegistrationNumber";
            this.colRegistrationNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRegistrationNumber.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colRegistrationNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colVatNumber
            // 
            this.colVatNumber.Caption = "Vat Number";
            this.colVatNumber.FieldName = "VatNumber";
            this.colVatNumber.Name = "colVatNumber";
            this.colVatNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVatNumber.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colVatNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // SiteList
            // 
            this.ActiveFilter = "[EntityId.Archived] = False";
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(630, 362);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SiteList";
            this.SuperTipParameter = "Site,Sites";
            this.TabIcon = global::CDS.Client.Desktop.Core.Properties.Resources.factory_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Core.Properties.Resources.factory_16;
            this.Text = "Site List";
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

        private DevExpress.XtraGrid.Columns.GridColumn colCodeMain;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colArchived;
        private DevExpress.XtraBars.BarButtonItem btnCopySite;
        private DevExpress.XtraGrid.Columns.GridColumn colRegistrationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colVatNumber;
    }
}
