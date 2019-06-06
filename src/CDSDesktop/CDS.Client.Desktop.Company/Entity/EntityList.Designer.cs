namespace CDS.Client.Desktop.Company.Entity
{
    partial class EntityList
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
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegistrationNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHasCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHasSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GridControl.Size = new System.Drawing.Size(803, 393);
            // 
            // GridView
            // 
            this.GridView.ActiveFilterString = "[EntityId.Archived] = False";
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colDescription,
            this.colArchived,
            this.colTitle,
            this.colRegistrationNumber,
            this.colVatNumber,
            this.colHasCustomer,
            this.colHasSupplier});
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
            this.GridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.GridView_CustomUnboundColumnData);
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(807, 397);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(807, 397);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(807, 397);
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.ORG_Entity);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.Size = new System.Drawing.Size(807, 144);
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
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "EntityId.Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 207;
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
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 207;
            // 
            // colArchived
            // 
            this.colArchived.Caption = "Archived";
            this.colArchived.FieldName = "EntityId.Archived";
            this.colArchived.Name = "colArchived";
            this.colArchived.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colArchived.Width = 72;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Title";
            this.colTitle.FieldName = "EntityId.Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTitle.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colTitle.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 1;
            this.colTitle.Width = 207;
            // 
            // colRegistrationNumber
            // 
            this.colRegistrationNumber.FieldName = "RegistrationNumber";
            this.colRegistrationNumber.Name = "colRegistrationNumber";
            this.colRegistrationNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRegistrationNumber.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colRegistrationNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colRegistrationNumber.Visible = true;
            this.colRegistrationNumber.VisibleIndex = 3;
            this.colRegistrationNumber.Width = 207;
            // 
            // colVatNumber
            // 
            this.colVatNumber.FieldName = "VatNumber";
            this.colVatNumber.Name = "colVatNumber";
            this.colVatNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVatNumber.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colVatNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colVatNumber.Visible = true;
            this.colVatNumber.VisibleIndex = 4;
            this.colVatNumber.Width = 343;
            // 
            // colHasCustomer
            // 
            this.colHasCustomer.Caption = "Has Customer";
            this.colHasCustomer.FieldName = "hasCustomer";
            this.colHasCustomer.Name = "colHasCustomer";
            this.colHasCustomer.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colHasCustomer.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colHasCustomer.Visible = true;
            this.colHasCustomer.VisibleIndex = 5;
            // 
            // colHasSupplier
            // 
            this.colHasSupplier.Caption = "Has Supplier";
            this.colHasSupplier.FieldName = "hasSupplier";
            this.colHasSupplier.Name = "colHasSupplier";
            this.colHasSupplier.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colHasSupplier.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colHasSupplier.Visible = true;
            this.colHasSupplier.VisibleIndex = 6;
            // 
            // EntityList
            // 
            this.ActiveFilter = "[EntityId.Archived] = False";
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(807, 541);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "EntityList";
            this.SuperTipParameter = "Entity,Entities";
            this.TabIcon = global::CDS.Client.Desktop.Company.Properties.Resources.handshake_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Company.Properties.Resources.handshake_16;
            this.Text = "Entities";
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

        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colArchived;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colRegistrationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colVatNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colHasCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colHasSupplier;

    }
}
