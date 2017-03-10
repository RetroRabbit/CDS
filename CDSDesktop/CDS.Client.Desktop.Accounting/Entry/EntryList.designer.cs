namespace CDS.Client.Desktop.Accounting.Entry
{
    partial class EntryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryList));
            this.colHeaderReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeaderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrackNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCenterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountTitle = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPeriodCode,
            this.colHeaderDate,
            this.colHeaderReference,
            this.colHeaderDescription,
            this.colAccountTitle,
            this.colTrackNumber,
            this.colCenterCode,
            this.colStatusCode,
            this.colAmount});
            this.GridView.GroupCount = 2;
            this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowFooter = true;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPeriodCode, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colHeaderDate, DevExpress.Data.ColumnSortOrder.Descending)});
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
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.GLX_Line);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.Size = new System.Drawing.Size(630, 144);
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
            // colHeaderReference
            // 
            this.colHeaderReference.Caption = "Reference";
            this.colHeaderReference.FieldName = "HeaderId.Reference";
            this.colHeaderReference.Name = "colHeaderReference";
            this.colHeaderReference.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHeaderReference.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colHeaderReference.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colHeaderReference.Visible = true;
            this.colHeaderReference.VisibleIndex = 1;
            this.colHeaderReference.Width = 258;
            // 
            // colHeaderDescription
            // 
            this.colHeaderDescription.Caption = "Description";
            this.colHeaderDescription.FieldName = "HeaderId.Description";
            this.colHeaderDescription.Name = "colHeaderDescription";
            this.colHeaderDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHeaderDescription.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colHeaderDescription.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colHeaderDescription.Visible = true;
            this.colHeaderDescription.VisibleIndex = 2;
            this.colHeaderDescription.Width = 594;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Amount";
            this.colAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 100;
            this.colAmount.MinWidth = 100;
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colAmount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0: # ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 6;
            this.colAmount.Width = 100;
            // 
            // colHeaderDate
            // 
            this.colHeaderDate.Caption = "Date";
            this.colHeaderDate.DisplayFormat.FormatString = "d";
            this.colHeaderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHeaderDate.FieldName = "HeaderId.Date";
            this.colHeaderDate.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.colHeaderDate.MaxWidth = 80;
            this.colHeaderDate.MinWidth = 80;
            this.colHeaderDate.Name = "colHeaderDate";
            this.colHeaderDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colHeaderDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colHeaderDate.Width = 80;
            // 
            // colTrackNumber
            // 
            this.colTrackNumber.Caption = "Track #";
            this.colTrackNumber.FieldName = "HeaderId.TrackId.Id";
            this.colTrackNumber.MaxWidth = 60;
            this.colTrackNumber.MinWidth = 60;
            this.colTrackNumber.Name = "colTrackNumber";
            this.colTrackNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTrackNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTrackNumber.Visible = true;
            this.colTrackNumber.VisibleIndex = 3;
            this.colTrackNumber.Width = 60;
            // 
            // colStatusCode
            // 
            this.colStatusCode.Caption = "Status";
            this.colStatusCode.FieldName = "HeaderId.StatusId.Name";
            this.colStatusCode.MaxWidth = 60;
            this.colStatusCode.MinWidth = 60;
            this.colStatusCode.Name = "colStatusCode";
            this.colStatusCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colStatusCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStatusCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStatusCode.Visible = true;
            this.colStatusCode.VisibleIndex = 5;
            this.colStatusCode.Width = 60;
            // 
            // colCenterCode
            // 
            this.colCenterCode.Caption = "Center";
            this.colCenterCode.FieldName = "CenterId.CodeMain";
            this.colCenterCode.MaxWidth = 100;
            this.colCenterCode.MinWidth = 100;
            this.colCenterCode.Name = "colCenterCode";
            this.colCenterCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCenterCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCenterCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCenterCode.Visible = true;
            this.colCenterCode.VisibleIndex = 4;
            this.colCenterCode.Width = 100;
            // 
            // colPeriodCode
            // 
            this.colPeriodCode.Caption = "Period";
            this.colPeriodCode.FieldName = "HeaderId.PeriodId.Code";
            this.colPeriodCode.MaxWidth = 80;
            this.colPeriodCode.MinWidth = 80;
            this.colPeriodCode.Name = "colPeriodCode";
            this.colPeriodCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPeriodCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colPeriodCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colPeriodCode.Width = 80;
            // 
            // colAccountTitle
            // 
            this.colAccountTitle.Caption = "Account";
            this.colAccountTitle.FieldName = "EntityId.Title";
            this.colAccountTitle.Name = "colAccountTitle";
            this.colAccountTitle.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAccountTitle.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colAccountTitle.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAccountTitle.Visible = true;
            this.colAccountTitle.VisibleIndex = 0;
            this.colAccountTitle.Width = 562;
            // 
            // EntryList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(630, 362);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "EntryList";
            this.SuperTipParameter = "entry,entries";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.Text = "Entries";
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

        private DevExpress.XtraGrid.Columns.GridColumn colHeaderReference;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colHeaderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTrackNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCenterCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountTitle;




    }
}
