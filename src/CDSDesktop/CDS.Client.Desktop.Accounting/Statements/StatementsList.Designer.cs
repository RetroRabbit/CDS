namespace CDS.Client.Desktop.Accounting.Statement
{
    partial class StatementsList
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
            this.rpCompany = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpActionsCompany = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnProcessStatements = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewActiveProcessing = new DevExpress.XtraBars.BarButtonItem();
            this.colEmailStatement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrintStatement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdateTimer = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.XPCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).BeginInit();
            this.LayoutControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // XPCollection
            // 
            this.XPCollection.BindingBehavior = DevExpress.Xpo.CollectionBindingBehavior.AllowNone;
            this.XPCollection.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.GLX_Account);
            this.XPCollection.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.XPCollection_ListChanged);
            this.XPCollection.ResolveSession += new DevExpress.Xpo.ResolveSessionEventHandler(this.XPCollection_ResolveSession);
            // 
            // GridControl
            // 
            this.GridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl.Size = new System.Drawing.Size(1040, 429);
            // 
            // GridView
            // 
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmailStatement,
            this.colPrintStatement,
            this.colTitle,
            this.colAccountBalance});
            this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.GridView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowFooter = true;
            this.GridView.OptionsView.ShowGroupPanel = false;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.GridView_CustomDrawColumnHeader);
            this.GridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridView_CellValueChanged);
            this.GridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(1044, 433);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(1044, 433);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(1044, 433);
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.GLX_Account);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnProcessStatements,
            this.btnViewActiveProcessing});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.MaxItemId = 12;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpCompany});
            this.RibbonControl.Size = new System.Drawing.Size(1044, 147);
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
            // rpCompany
            // 
            this.rpCompany.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpActionsCompany});
            this.rpCompany.Name = "rpCompany";
            this.rpCompany.Text = "Company";
            // 
            // rpActionsCompany
            // 
            this.rpActionsCompany.ItemLinks.Add(this.btnProcessStatements);
            this.rpActionsCompany.ItemLinks.Add(this.btnViewActiveProcessing);
            this.rpActionsCompany.Name = "rpActionsCompany";
            this.rpActionsCompany.Text = "Actions";
            // 
            // btnProcessStatements
            // 
            this.btnProcessStatements.Caption = "Process\r\nStatements";
            this.btnProcessStatements.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnProcessStatements.Glyph = global::CDS.Client.Desktop.Accounting.Properties.Resources.mail_sealed_16;
            this.btnProcessStatements.Id = 10;
            this.btnProcessStatements.LargeGlyph = global::CDS.Client.Desktop.Accounting.Properties.Resources.mail_sealed_32;
            this.btnProcessStatements.Name = "btnProcessStatements";
            this.btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnProcessStatements.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcessStatements_ItemClick);
            // 
            // btnViewActiveProcessing
            // 
            this.btnViewActiveProcessing.Caption = "View Active\r\nProcessing";
            this.btnViewActiveProcessing.Glyph = global::CDS.Client.Desktop.Accounting.Properties.Resources.mail_view_16;
            this.btnViewActiveProcessing.Id = 11;
            this.btnViewActiveProcessing.LargeGlyph = global::CDS.Client.Desktop.Accounting.Properties.Resources.mail_view_32;
            this.btnViewActiveProcessing.Name = "btnViewActiveProcessing";
            this.btnViewActiveProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewActiveProcessing.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewActiveProcessing_ItemClick);
            // 
            // colEmailStatement
            // 
            this.colEmailStatement.Caption = " ";
            this.colEmailStatement.FieldName = "EmailStatement";
            this.colEmailStatement.MaxWidth = 20;
            this.colEmailStatement.Name = "colEmailStatement";
            this.colEmailStatement.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colEmailStatement.Visible = true;
            this.colEmailStatement.VisibleIndex = 0;
            this.colEmailStatement.Width = 20;
            // 
            // colPrintStatement
            // 
            this.colPrintStatement.Caption = " ";
            this.colPrintStatement.FieldName = "PrintStatement";
            this.colPrintStatement.MaxWidth = 20;
            this.colPrintStatement.Name = "colPrintStatement";
            this.colPrintStatement.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colPrintStatement.Visible = true;
            this.colPrintStatement.VisibleIndex = 1;
            this.colPrintStatement.Width = 20;
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
            this.colTitle.VisibleIndex = 2;
            this.colTitle.Width = 892;
            // 
            // colAccountBalance
            // 
            this.colAccountBalance.Caption = "Balance";
            this.colAccountBalance.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAccountBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAccountBalance.FieldName = "EntityId.AccountBalance";
            this.colAccountBalance.Name = "colAccountBalance";
            this.colAccountBalance.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colAccountBalance.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAccountBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EntityId.AccountBalance", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}")});
            this.colAccountBalance.Visible = true;
            this.colAccountBalance.VisibleIndex = 3;
            this.colAccountBalance.Width = 87;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 2000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // StatementsList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1044, 580);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "StatementsList";
            this.Text = "Statement of Account";
            ((System.ComponentModel.ISupportInitialize)(this.XPCollection)).EndInit();
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
         
        private DevExpress.XtraBars.BarButtonItem btnProcessStatements;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpCompany;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpActionsCompany;
        private DevExpress.XtraBars.BarButtonItem btnViewActiveProcessing;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailStatement;
        private DevExpress.XtraGrid.Columns.GridColumn colPrintStatement;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountBalance;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}
