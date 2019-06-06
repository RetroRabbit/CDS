namespace CDS.Client.Desktop.Essential.SYS
{
    partial class ScheduledTaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduledTaskList));
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTriggers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNextRunTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastRunTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastRunResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreated = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GridControl.Size = new System.Drawing.Size(731, 287);
            // 
            // GridView
            // 
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colStatus,
            this.colTriggers,
            this.colNextRunTime,
            this.colLastRunTime,
            this.colLastRunResult,
            this.colAuthor,
            this.colCreated});
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
            this.LayoutControlGrid.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(735, 291);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(735, 291);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(735, 291);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.RibbonControl.Size = new System.Drawing.Size(735, 155);
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
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 1;
            // 
            // colTriggers
            // 
            this.colTriggers.Caption = "Triggers";
            this.colTriggers.FieldName = "Triggers";
            this.colTriggers.Name = "colTriggers";
            this.colTriggers.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTriggers.Visible = true;
            this.colTriggers.VisibleIndex = 2;
            // 
            // colNextRunTime
            // 
            this.colNextRunTime.Caption = "Next Run Time";
            this.colNextRunTime.FieldName = "NextRunTime";
            this.colNextRunTime.Name = "colNextRunTime";
            this.colNextRunTime.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colNextRunTime.Visible = true;
            this.colNextRunTime.VisibleIndex = 3;
            // 
            // colLastRunTime
            // 
            this.colLastRunTime.Caption = "Last Run Time";
            this.colLastRunTime.FieldName = "LastRunTime";
            this.colLastRunTime.Name = "colLastRunTime";
            this.colLastRunTime.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colLastRunTime.Visible = true;
            this.colLastRunTime.VisibleIndex = 4;
            // 
            // colLastRunResult
            // 
            this.colLastRunResult.Caption = "Last Run Result";
            this.colLastRunResult.FieldName = "LastRunResult";
            this.colLastRunResult.Name = "colLastRunResult";
            this.colLastRunResult.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colLastRunResult.Visible = true;
            this.colLastRunResult.VisibleIndex = 5;
            // 
            // colAuthor
            // 
            this.colAuthor.Caption = "Author";
            this.colAuthor.FieldName = "Author";
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAuthor.Visible = true;
            this.colAuthor.VisibleIndex = 6;
            // 
            // colCreated
            // 
            this.colCreated.Caption = "Created";
            this.colCreated.FieldName = "Created";
            this.colCreated.Name = "colCreated";
            this.colCreated.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCreated.Visible = true;
            this.colCreated.VisibleIndex = 7;
            // 
            // ScheduledTaskList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(735, 446);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "ScheduledTaskList";
            this.SuperTipParameter = "Scheduled Task";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.Text = "Scheduled Tasks";
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
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTriggers;
        private DevExpress.XtraGrid.Columns.GridColumn colNextRunTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLastRunTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLastRunResult;
        private DevExpress.XtraGrid.Columns.GridColumn colAuthor;
        private DevExpress.XtraGrid.Columns.GridColumn colCreated;
    }
}
