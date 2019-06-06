namespace CDS.Client.Desktop.Ordering.AOR
{
    partial class AutomaticOrderingList
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
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
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
            // 
            // GridView
            // 
            this.GridView.ActiveFilterString = "StartsWith([Status], \'Open\')";
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStartDate,
            this.colOrderDate,
            this.colFilter,
            this.colName,
            this.colStatus,
            this.colTotal,
            this.colCreatedBy,
            this.colCreatedOn});
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
            this.GridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStartDate, DevExpress.Data.ColumnSortOrder.Descending)});
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
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.AOR_Order);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
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
            // colStartDate
            // 
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colStartDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 0;
            this.colStartDate.Width = 100;
            // 
            // colOrderDate
            // 
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colOrderDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 1;
            this.colOrderDate.Width = 100;
            // 
            // colFilter
            // 
            this.colFilter.FieldName = "Filter";
            this.colFilter.Name = "colFilter";
            this.colFilter.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFilter.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colFilter.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colFilter.Visible = true;
            this.colFilter.VisibleIndex = 3;
            this.colFilter.Width = 243;
            // 
            // colName
            // 
            this.colName.Caption = "Supplier";
            this.colName.FieldName = "SupplierId.Title";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 193;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTotal.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 5;
            this.colTotal.Width = 100;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Caption = "Created By";
            this.colCreatedBy.FieldName = "CreatedBy.Fullname";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCreatedBy.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCreatedBy.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.FieldName = "CreatedOn";
            this.colCreatedOn.Name = "colCreatedOn";
            this.colCreatedOn.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colCreatedOn.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusId.Name";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colStatus.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStatus.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;
            this.colStatus.Width = 90;
            // 
            // AutomaticOrderingList
            // 
            this.ActiveFilter = "StartsWith([Status], \'Open\')";
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "AutomaticOrderingList";
            this.Text = "Automatic Ordering";
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

        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
