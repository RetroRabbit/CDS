namespace CDS.Client.Desktop.Essential.UTL
{
    partial class SelectDocumentDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDocumentDialogue));
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.itmSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkTypeFilter = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.BindingSourceDocumentTypes = new System.Windows.Forms.BindingSource();
            this.itmTypeFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnGoSearch = new DevExpress.XtraEditors.SimpleButton();
            this.itmGoSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdResults = new DevExpress.XtraGrid.GridControl();
            this.InstantFeedbackSourceDocument = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.grvResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatePosted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDayPosted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController();
            this.itmResults = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.pnlDocumentSearch = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmPeriod = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourcePeriod = new DevExpress.Data.Linq.LinqServerModeSource();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTypeFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDocumentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTypeFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGoSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocumentSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ddlPeriod);
            this.LayoutControl.Controls.Add(this.grdResults);
            this.LayoutControl.Controls.Add(this.btnGoSearch);
            this.LayoutControl.Controls.Add(this.chkTypeFilter);
            this.LayoutControl.Controls.Add(this.txtSearch);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(788, 57, 250, 350);
            this.LayoutControl.Size = new System.Drawing.Size(574, 392);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pnlDocumentSearch});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(574, 392);
            this.LayoutGroup.Text = "Root";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(55, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(229, 20);
            this.txtSearch.StyleController = this.LayoutControl;
            this.txtSearch.TabIndex = 4;
            // 
            // itmSearch
            // 
            this.itmSearch.Control = this.txtSearch;
            this.itmSearch.CustomizationFormText = "Search";
            this.itmSearch.Location = new System.Drawing.Point(0, 0);
            this.itmSearch.Name = "itmSearch";
            this.itmSearch.Size = new System.Drawing.Size(270, 24);
            this.itmSearch.Text = "Search";
            this.itmSearch.TextSize = new System.Drawing.Size(33, 13);
            // 
            // chkTypeFilter
            // 
            this.chkTypeFilter.CheckOnClick = true;
            this.chkTypeFilter.DataSource = this.BindingSourceDocumentTypes;
            this.chkTypeFilter.DisplayMember = "Name";
            this.chkTypeFilter.Location = new System.Drawing.Point(18, 61);
            this.chkTypeFilter.MultiColumn = true;
            this.chkTypeFilter.Name = "chkTypeFilter";
            this.chkTypeFilter.Size = new System.Drawing.Size(538, 90);
            this.chkTypeFilter.StyleController = this.LayoutControl;
            this.chkTypeFilter.TabIndex = 5;
            this.chkTypeFilter.ValueMember = "DataLayerGuid";
            // 
            // BindingSourceDocumentTypes
            // 
            this.BindingSourceDocumentTypes.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Type);
            // 
            // itmTypeFilter
            // 
            this.itmTypeFilter.Control = this.chkTypeFilter;
            this.itmTypeFilter.CustomizationFormText = "Type Filter";
            this.itmTypeFilter.Location = new System.Drawing.Point(0, 24);
            this.itmTypeFilter.MaxSize = new System.Drawing.Size(0, 94);
            this.itmTypeFilter.MinSize = new System.Drawing.Size(54, 94);
            this.itmTypeFilter.Name = "itmTypeFilter";
            this.itmTypeFilter.Size = new System.Drawing.Size(542, 94);
            this.itmTypeFilter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmTypeFilter.Text = "Type Filter";
            this.itmTypeFilter.TextSize = new System.Drawing.Size(0, 0);
            this.itmTypeFilter.TextToControlDistance = 0;
            this.itmTypeFilter.TextVisible = false;
            // 
            // btnGoSearch
            // 
            this.btnGoSearch.Location = new System.Drawing.Point(469, 155);
            this.btnGoSearch.Name = "btnGoSearch";
            this.btnGoSearch.Size = new System.Drawing.Size(87, 22);
            this.btnGoSearch.StyleController = this.LayoutControl;
            this.btnGoSearch.TabIndex = 6;
            this.btnGoSearch.Text = "&Search";
            this.btnGoSearch.Click += new System.EventHandler(this.btnGoSearch_Click);
            // 
            // itmGoSearch
            // 
            this.itmGoSearch.Control = this.btnGoSearch;
            this.itmGoSearch.CustomizationFormText = "Go Search";
            this.itmGoSearch.Location = new System.Drawing.Point(451, 118);
            this.itmGoSearch.Name = "itmGoSearch";
            this.itmGoSearch.Size = new System.Drawing.Size(91, 26);
            this.itmGoSearch.Text = "Go Search";
            this.itmGoSearch.TextSize = new System.Drawing.Size(0, 0);
            this.itmGoSearch.TextToControlDistance = 0;
            this.itmGoSearch.TextVisible = false;
            // 
            // grdResults
            // 
            this.grdResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdResults.DataSource = this.InstantFeedbackSourceDocument;
            this.grdResults.Location = new System.Drawing.Point(18, 181);
            this.grdResults.MainView = this.grvResults;
            this.grdResults.Name = "grdResults";
            this.grdResults.Size = new System.Drawing.Size(538, 193);
            this.grdResults.TabIndex = 7;
            this.grdResults.ToolTipController = this.toolTipController1;
            this.grdResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvResults});
            this.grdResults.Paint += new System.Windows.Forms.PaintEventHandler(this.grdResults_Paint);
            this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
            this.grdResults.ParentChanged += new System.EventHandler(this.grdResults_ParentChanged);
            // 
            // InstantFeedbackSourceDocument
            // 
            this.InstantFeedbackSourceDocument.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Document);
            this.InstantFeedbackSourceDocument.KeyExpression = "Id";
            this.InstantFeedbackSourceDocument.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceDocument_GetQueryable);
            // 
            // grvResults
            // 
            this.grvResults.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocumentNumber,
            this.colDatePosted,
            this.colTotal,
            this.colCompanyName,
            this.colDayPosted});
            this.grvResults.GridControl = this.grdResults;
            this.grvResults.GroupCount = 1;
            this.grvResults.Name = "grvResults";
            this.grvResults.OptionsBehavior.Editable = false;
            this.grvResults.OptionsBehavior.ReadOnly = true;
            this.grvResults.OptionsMenu.EnableColumnMenu = false;
            this.grvResults.OptionsSelection.UseIndicatorForSelection = false;
            this.grvResults.OptionsView.ShowAutoFilterRow = true;
            this.grvResults.OptionsView.ShowGroupPanel = false;
            this.grvResults.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDayPosted, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.FieldName = "DocumentNumber";
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 1;
            // 
            // colDatePosted
            // 
            this.colDatePosted.FieldName = "DatePosted";
            this.colDatePosted.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.colDatePosted.Name = "colDatePosted";
            this.colDatePosted.Visible = true;
            this.colDatePosted.VisibleIndex = 0;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 2;
            // 
            // colCompanyName
            // 
            this.colCompanyName.FieldName = "CompanyName";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 3;
            // 
            // colDayPosted
            // 
            this.colDayPosted.FieldName = "DayPosted";
            this.colDayPosted.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.colDayPosted.Name = "colDayPosted";
            this.colDayPosted.Visible = true;
            this.colDayPosted.VisibleIndex = 1;
            // 
            // toolTipController1
            // 
            this.toolTipController1.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController1_BeforeShow);
            // 
            // itmResults
            // 
            this.itmResults.Control = this.grdResults;
            this.itmResults.CustomizationFormText = "Results";
            this.itmResults.Location = new System.Drawing.Point(0, 144);
            this.itmResults.Name = "itmResults";
            this.itmResults.Size = new System.Drawing.Size(542, 197);
            this.itmResults.Text = "Results";
            this.itmResults.TextSize = new System.Drawing.Size(0, 0);
            this.itmResults.TextToControlDistance = 0;
            this.itmResults.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 118);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(451, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // pnlDocumentSearch
            // 
            this.pnlDocumentSearch.CustomizationFormText = "Document Search";
            this.pnlDocumentSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmResults,
            this.itmGoSearch,
            this.emptySpaceItem1,
            this.itmTypeFilter,
            this.itmSearch,
            this.itmPeriod});
            this.pnlDocumentSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlDocumentSearch.Name = "pnlDocumentSearch";
            this.pnlDocumentSearch.Size = new System.Drawing.Size(566, 384);
            this.pnlDocumentSearch.Text = "Document Search";
            // 
            // itmPeriod
            // 
            this.itmPeriod.Control = this.ddlPeriod;
            this.itmPeriod.CustomizationFormText = "Period";
            this.itmPeriod.Location = new System.Drawing.Point(270, 0);
            this.itmPeriod.Name = "itmPeriod";
            this.itmPeriod.Size = new System.Drawing.Size(272, 24);
            this.itmPeriod.Text = "Period";
            this.itmPeriod.TextSize = new System.Drawing.Size(33, 13);
            // 
            // ddlPeriod
            // 
            this.ddlPeriod.Location = new System.Drawing.Point(325, 37);
            this.ddlPeriod.Name = "ddlPeriod";
            this.ddlPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlPeriod.Properties.DataSource = this.ServerModeSourcePeriod;
            this.ddlPeriod.Properties.DisplayMember = "Code";
            this.ddlPeriod.Properties.ValueMember = "Id";
            this.ddlPeriod.Size = new System.Drawing.Size(231, 20);
            this.ddlPeriod.StyleController = this.LayoutControl;
            this.ddlPeriod.TabIndex = 8;
            // 
            // ServerModeSourcePeriod
            // 
            this.ServerModeSourcePeriod.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Period);
            this.ServerModeSourcePeriod.KeyExpression = "[Id]";
            // 
            // SelectDocumentDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 446);
            this.Name = "SelectDocumentDialogue";
            this.TabHeading = "Search for and select an existing document in the system. Any document may be sea" +
    "rched for.";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.Text = " Select Document";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTypeFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDocumentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTypeFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGoSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocumentSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdResults;
        private DevExpress.XtraGrid.Views.Grid.GridView grvResults;
        private DevExpress.XtraEditors.SimpleButton btnGoSearch;
        private DevExpress.XtraEditors.CheckedListBoxControl chkTypeFilter;
        private System.Windows.Forms.BindingSource BindingSourceDocumentTypes;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraLayout.LayoutControlGroup pnlDocumentSearch;
        private DevExpress.XtraLayout.LayoutControlItem itmResults;
        private DevExpress.XtraLayout.LayoutControlItem itmGoSearch;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem itmTypeFilter;
        private DevExpress.XtraLayout.LayoutControlItem itmSearch;
        private DevExpress.XtraEditors.LookUpEdit ddlPeriod;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePeriod;
        private DevExpress.XtraLayout.LayoutControlItem itmPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDatePosted;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceDocument;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Columns.GridColumn colDayPosted;
    }
}
