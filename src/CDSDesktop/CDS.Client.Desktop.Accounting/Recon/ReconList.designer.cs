namespace CDS.Client.Desktop.Accounting
{
    partial class ReconList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReconList));
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDifference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GridControl.Size = new System.Drawing.Size(626, 211);
            // 
            // GridView
            // 
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccount,
            this.colReference,
            this.colDescription,
            this.colStartDate,
            this.colEndDate,
            this.colStartAmount,
            this.colEndAmount,
            this.colAmount,
            this.colDifference,
            this.colStatusCode});
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(630, 215);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(630, 215);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(630, 215);
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.GLX_Recon);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.Size = new System.Drawing.Size(630, 147);
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
            // colAccount
            // 
            this.colAccount.FieldName = "Account";
            this.colAccount.MinWidth = 100;
            this.colAccount.Name = "colAccount";
            this.colAccount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAccount.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colAccount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 0;
            this.colAccount.Width = 499;
            // 
            // colReference
            // 
            this.colReference.Caption = "Reference";
            this.colReference.FieldName = "Reference";
            this.colReference.MaxWidth = 90;
            this.colReference.MinWidth = 90;
            this.colReference.Name = "colReference";
            this.colReference.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReference.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReference.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 1;
            this.colReference.Width = 90;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 60;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescription.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colDescription.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 725;
            // 
            // colStartDate
            // 
            this.colStartDate.Caption = "Start Date";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.MaxWidth = 80;
            this.colStartDate.MinWidth = 80;
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colStartDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 4;
            this.colStartDate.Width = 80;
            // 
            // colEndDate
            // 
            this.colEndDate.Caption = "End Date";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.MaxWidth = 80;
            this.colEndDate.MinWidth = 80;
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colEndDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 5;
            this.colEndDate.Width = 80;
            // 
            // colStartAmount
            // 
            this.colStartAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colStartAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStartAmount.Caption = "Start Amount";
            this.colStartAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colStartAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colStartAmount.FieldName = "StartAmount";
            this.colStartAmount.MaxWidth = 90;
            this.colStartAmount.MinWidth = 90;
            this.colStartAmount.Name = "colStartAmount";
            this.colStartAmount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colStartAmount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStartAmount.Visible = true;
            this.colStartAmount.VisibleIndex = 6;
            this.colStartAmount.Width = 90;
            // 
            // colEndAmount
            // 
            this.colEndAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colEndAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colEndAmount.Caption = "End Amount";
            this.colEndAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colEndAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEndAmount.FieldName = "EndAmount";
            this.colEndAmount.MaxWidth = 90;
            this.colEndAmount.MinWidth = 90;
            this.colEndAmount.Name = "colEndAmount";
            this.colEndAmount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colEndAmount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colEndAmount.Visible = true;
            this.colEndAmount.VisibleIndex = 7;
            this.colEndAmount.Width = 90;
            // 
            // colStatusCode
            // 
            this.colStatusCode.Caption = "Status";
            this.colStatusCode.FieldName = "StatusId.Name";
            this.colStatusCode.MaxWidth = 80;
            this.colStatusCode.MinWidth = 80;
            this.colStatusCode.Name = "colStatusCode";
            this.colStatusCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colStatusCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStatusCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStatusCode.Visible = true;
            this.colStatusCode.VisibleIndex = 3;
            this.colStatusCode.Width = 80;
            // 
            // colDifference
            // 
            this.colDifference.AppearanceCell.Options.UseTextOptions = true;
            this.colDifference.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDifference.Caption = "Difference";
            this.colDifference.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colDifference.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDifference.FieldName = "Difference";
            this.colDifference.Name = "colDifference";
            this.colDifference.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colDifference.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colAmount
            // 
            this.colAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAmount.Caption = "Amount";
            this.colAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colAmount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // ReconList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(630, 362);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ReconList";
            this.SuperTipParameter = "recon";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.Text = "Recons";
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

        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colReference;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStartAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colEndAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDifference;












    }
}
