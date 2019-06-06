namespace CDS.Client.Desktop.Core.Period
{
    partial class PostPeriodDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostPeriodDialogue));
            this.grdLines = new DevExpress.XtraGrid.GridControl();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.grvLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ServerModeSourceAccount = new DevExpress.Data.Linq.LinqServerModeSource();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnPostPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ddlAccount);
            this.LayoutControl.Controls.Add(this.grdLines);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.btnPostPeriod);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.itmAccount,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            // 
            // grdLines
            // 
            this.grdLines.DataSource = this.BindingSource;
            this.grdLines.Location = new System.Drawing.Point(6, 30);
            this.grdLines.MainView = this.grvLines;
            this.grdLines.Name = "grdLines";
            this.grdLines.Size = new System.Drawing.Size(485, 132);
            this.grdLines.TabIndex = 4;
            this.grdLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLines});
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_PostPeriodFigures);
            // 
            // grvLines
            // 
            this.grvLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCenter,
            this.colTitle1,
            this.colAmount});
            this.grvLines.GridControl = this.grdLines;
            this.grvLines.Name = "grvLines";
            this.grvLines.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.grvLines.OptionsCustomization.AllowColumnMoving = false;
            this.grvLines.OptionsCustomization.AllowFilter = false;
            this.grvLines.OptionsCustomization.AllowGroup = false;
            this.grvLines.OptionsCustomization.AllowQuickHideColumns = false;
            this.grvLines.OptionsFilter.AllowFilterEditor = false;
            this.grvLines.OptionsFind.AllowFindPanel = false;
            this.grvLines.OptionsMenu.EnableColumnMenu = false;
            this.grvLines.OptionsMenu.EnableFooterMenu = false;
            this.grvLines.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvLines.OptionsMenu.ShowAutoFilterRowItem = false;
            this.grvLines.OptionsView.ShowFooter = true;
            this.grvLines.OptionsView.ShowGroupPanel = false;
            // 
            // colCenter
            // 
            this.colCenter.FieldName = "Center";
            this.colCenter.Name = "colCenter";
            this.colCenter.Visible = true;
            this.colCenter.VisibleIndex = 0;
            this.colCenter.Width = 303;
            // 
            // colTitle1
            // 
            this.colTitle1.FieldName = "Title";
            this.colTitle1.Name = "colTitle1";
            this.colTitle1.Visible = true;
            this.colTitle1.VisibleIndex = 1;
            this.colTitle1.Width = 1033;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; BALANCED}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 2;
            this.colAmount.Width = 356;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdLines;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(489, 136);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // ddlAccount
            // 
            this.ddlAccount.EditValue = -1;
            this.ddlAccount.Location = new System.Drawing.Point(49, 6);
            this.ddlAccount.Name = "ddlAccount";
            this.ddlAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAccount.Properties.DataSource = this.ServerModeSourceAccount;
            this.ddlAccount.Properties.DisplayMember = "Title";
            this.ddlAccount.Properties.NullText = "Select Account...";
            this.ddlAccount.Properties.NullValuePrompt = "Select Account...";
            this.ddlAccount.Properties.ReadOnly = true;
            this.ddlAccount.Properties.ValueMember = "Id";
            this.ddlAccount.Properties.View = this.gridLookUpEdit1View;
            this.ddlAccount.Size = new System.Drawing.Size(442, 20);
            this.ddlAccount.StyleController = this.LayoutControl;
            this.ddlAccount.TabIndex = 5;
            // 
            // ServerModeSourceAccount
            // 
            this.ServerModeSourceAccount.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.ServerModeSourceAccount.KeyExpression = "Id";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colDescription,
            this.colAmount1});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsCustomization.AllowColumnMoving = false;
            this.gridLookUpEdit1View.OptionsCustomization.AllowColumnResizing = false;
            this.gridLookUpEdit1View.OptionsMenu.EnableColumnMenu = false;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.OptionsView.ShowIndicator = false;
            this.gridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTitle, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colAmount1
            // 
            this.colAmount1.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount1.FieldName = "Amount";
            this.colAmount1.Name = "colAmount1";
            this.colAmount1.Visible = true;
            this.colAmount1.VisibleIndex = 2;
            // 
            // itmAccount
            // 
            this.itmAccount.Control = this.ddlAccount;
            this.itmAccount.CustomizationFormText = "layoutControlItem2";
            this.itmAccount.Location = new System.Drawing.Point(0, 0);
            this.itmAccount.Name = "itmAccount";
            this.itmAccount.Size = new System.Drawing.Size(489, 24);
            this.itmAccount.Text = "Account";
            this.itmAccount.TextSize = new System.Drawing.Size(39, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(332, 26);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(332, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(332, 26);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnPostPeriod
            // 
            this.btnPostPeriod.Location = new System.Drawing.Point(416, 166);
            this.btnPostPeriod.Name = "btnPostPeriod";
            this.btnPostPeriod.Size = new System.Drawing.Size(75, 22);
            this.btnPostPeriod.StyleController = this.LayoutControl;
            this.btnPostPeriod.TabIndex = 6;
            this.btnPostPeriod.Text = "Post Period";
            this.btnPostPeriod.Click += new System.EventHandler(this.btnPostPeriod_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPostPeriod;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(410, 160);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(79, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(338, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCancel;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(332, 160);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // PostPeriodDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.Name = "PostPeriodDialogue";
            this.TabHeading = resources.GetString("$this.TabHeading");
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit ddlAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.GridControl grdLines;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLines;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem itmAccount;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnPostPeriod;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount1;
        private DevExpress.XtraGrid.Columns.GridColumn colCenter;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;

    }
}
