namespace CDS.Client.Desktop.Catalogue.CAT
{
    partial class CatalogueImportExportDialogue
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogueImportExportDialogue));
            this.grdStatus = new DevExpress.XtraGrid.GridControl();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grvStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pbProgress = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.itmStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imageCollectionStatus = new DevExpress.Utils.ImageCollection(this.components);
            this.itmStatusGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.catalogueLocation = new System.Windows.Forms.OpenFileDialog();
            this.btnCatalogueLocation = new DevExpress.XtraEditors.ButtonEdit();
            this.itmCatalogueLocation = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlCatalogue = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ServerModeSourceCatalogue = new DevExpress.Data.Linq.LinqServerModeSource();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPublisher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmCatalogue = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnImageLocation = new DevExpress.XtraEditors.ButtonEdit();
            this.itmImageLocation = new DevExpress.XtraLayout.LayoutControlItem();
            this.catalogueImageLocation = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatusGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCatalogueLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCatalogueLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCatalogue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCatalogue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCatalogue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImageLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnImageLocation);
            this.LayoutControl.Controls.Add(this.ddlCatalogue);
            this.LayoutControl.Controls.Add(this.btnCatalogueLocation);
            this.LayoutControl.Controls.Add(this.btnClose);
            this.LayoutControl.Controls.Add(this.btnStart);
            this.LayoutControl.Controls.Add(this.grdStatus);
            this.LayoutControl.Size = new System.Drawing.Size(456, 300);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmStatusGrid,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.itmCatalogueLocation,
            this.itmImageLocation,
            this.itmCatalogue,
            this.emptySpaceItem1});
            this.LayoutGroup.Size = new System.Drawing.Size(456, 300);
            // 
            // grdStatus
            // 
            this.grdStatus.DataSource = this.BindingSource;
            this.grdStatus.Location = new System.Drawing.Point(6, 78);
            this.grdStatus.MainView = this.grvStatus;
            this.grdStatus.Name = "grdStatus";
            this.grdStatus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.pbProgress,
            this.itmStatus,
            this.repositoryItemPictureEdit1});
            this.grdStatus.Size = new System.Drawing.Size(444, 190);
            this.grdStatus.TabIndex = 4;
            this.grdStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStatus});
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.Desktop.Catalogue.CAT.ImportExportStatus);
            // 
            // grvStatus
            // 
            this.grvStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescription,
            this.colProgress,
            this.colImage});
            this.grvStatus.GridControl = this.grdStatus;
            this.grvStatus.Name = "grvStatus";
            this.grvStatus.OptionsView.ShowGroupPanel = false;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.MaxWidth = 210;
            this.colDescription.MinWidth = 210;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            this.colDescription.Width = 210;
            // 
            // colProgress
            // 
            this.colProgress.ColumnEdit = this.pbProgress;
            this.colProgress.FieldName = "Progress";
            this.colProgress.Name = "colProgress";
            this.colProgress.OptionsColumn.AllowEdit = false;
            this.colProgress.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colProgress.OptionsColumn.ReadOnly = true;
            this.colProgress.Visible = true;
            this.colProgress.VisibleIndex = 1;
            this.colProgress.Width = 1479;
            // 
            // pbProgress
            // 
            this.pbProgress.Name = "pbProgress";
            // 
            // colImage
            // 
            this.colImage.Caption = "Status";
            this.colImage.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colImage.FieldName = "Image";
            this.colImage.MaxWidth = 45;
            this.colImage.MinWidth = 45;
            this.colImage.Name = "colImage";
            this.colImage.OptionsColumn.AllowEdit = false;
            this.colImage.OptionsColumn.AllowSize = false;
            this.colImage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colImage.OptionsColumn.ReadOnly = true;
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 2;
            this.colImage.Width = 45;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // itmStatus
            // 
            this.itmStatus.AutoHeight = false;
            this.itmStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itmStatus.Name = "itmStatus";
            // 
            // imageCollectionStatus
            // 
            this.imageCollectionStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionStatus.ImageStream")));
            this.imageCollectionStatus.Images.SetKeyName(0, "information2_16.png");
            this.imageCollectionStatus.Images.SetKeyName(1, "check_16.png");
            this.imageCollectionStatus.Images.SetKeyName(2, "delete_16.png");
            // 
            // itmStatusGrid
            // 
            this.itmStatusGrid.Control = this.grdStatus;
            this.itmStatusGrid.CustomizationFormText = "StatusGrid";
            this.itmStatusGrid.Location = new System.Drawing.Point(0, 72);
            this.itmStatusGrid.Name = "itmStatusGrid";
            this.itmStatusGrid.Size = new System.Drawing.Size(448, 194);
            this.itmStatusGrid.Text = "itmStatusGrid";
            this.itmStatusGrid.TextSize = new System.Drawing.Size(0, 0);
            this.itmStatusGrid.TextToControlDistance = 0;
            this.itmStatusGrid.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 266);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(310, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(386, 272);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 22);
            this.btnStart.StyleController = this.LayoutControl;
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnStart;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(380, 266);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(68, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(316, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 22);
            this.btnClose.StyleController = this.LayoutControl;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(310, 266);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(70, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // catalogueLocation
            // 
            this.catalogueLocation.Filter = "Zip File (*.zip)|*.zip";
            // 
            // btnCatalogueLocation
            // 
            this.btnCatalogueLocation.EditValue = "Please select Catalogue Zip file ...";
            this.btnCatalogueLocation.Location = new System.Drawing.Point(102, 30);
            this.btnCatalogueLocation.Name = "btnCatalogueLocation";
            this.btnCatalogueLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnCatalogueLocation.Properties.ReadOnly = true;
            this.btnCatalogueLocation.Size = new System.Drawing.Size(348, 20);
            this.btnCatalogueLocation.StyleController = this.LayoutControl;
            this.btnCatalogueLocation.TabIndex = 7;
            this.btnCatalogueLocation.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnCatalogueLocation_ButtonClick);
            // 
            // itmCatalogueLocation
            // 
            this.itmCatalogueLocation.Control = this.btnCatalogueLocation;
            this.itmCatalogueLocation.CustomizationFormText = "Catalogue Location";
            this.itmCatalogueLocation.Location = new System.Drawing.Point(0, 24);
            this.itmCatalogueLocation.Name = "itmCatalogueLocation";
            this.itmCatalogueLocation.Size = new System.Drawing.Size(448, 24);
            this.itmCatalogueLocation.Text = "Catalogue Location";
            this.itmCatalogueLocation.TextSize = new System.Drawing.Size(92, 13);
            // 
            // ddlCatalogue
            // 
            this.ddlCatalogue.Location = new System.Drawing.Point(102, 6);
            this.ddlCatalogue.Name = "ddlCatalogue";
            this.ddlCatalogue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCatalogue.Properties.DataSource = this.ServerModeSourceCatalogue;
            this.ddlCatalogue.Properties.DisplayMember = "Name";
            this.ddlCatalogue.Properties.NullText = "Please select Catalogue ...";
            this.ddlCatalogue.Properties.ValueMember = "Id";
            this.ddlCatalogue.Properties.View = this.gridLookUpEdit1View;
            this.ddlCatalogue.Size = new System.Drawing.Size(348, 20);
            this.ddlCatalogue.StyleController = this.LayoutControl;
            this.ddlCatalogue.TabIndex = 8;
            this.ddlCatalogue.EditValueChanged += new System.EventHandler(this.ddlCatalogue_EditValueChanged);
            // 
            // ServerModeSourceCatalogue
            // 
            this.ServerModeSourceCatalogue.ElementType = typeof(CDS.Client.DataAccessLayer.DB.CAT_Catalogue);
            this.ServerModeSourceCatalogue.KeyExpression = "[Id]";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPublisher,
            this.colRevision,
            this.colDescription1});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colPublisher
            // 
            this.colPublisher.FieldName = "Publisher";
            this.colPublisher.Name = "colPublisher";
            this.colPublisher.Visible = true;
            this.colPublisher.VisibleIndex = 1;
            // 
            // colRevision
            // 
            this.colRevision.FieldName = "Revision";
            this.colRevision.Name = "colRevision";
            this.colRevision.Visible = true;
            this.colRevision.VisibleIndex = 2;
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.Visible = true;
            this.colDescription1.VisibleIndex = 3;
            // 
            // itmCatalogue
            // 
            this.itmCatalogue.Control = this.ddlCatalogue;
            this.itmCatalogue.CustomizationFormText = "Catalogue";
            this.itmCatalogue.Location = new System.Drawing.Point(0, 0);
            this.itmCatalogue.Name = "itmCatalogue";
            this.itmCatalogue.Size = new System.Drawing.Size(448, 24);
            this.itmCatalogue.Text = "Catalogue";
            this.itmCatalogue.TextSize = new System.Drawing.Size(92, 13);
            // 
            // btnImageLocation
            // 
            this.btnImageLocation.Location = new System.Drawing.Point(102, 54);
            this.btnImageLocation.Name = "btnImageLocation";
            this.btnImageLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnImageLocation.Properties.NullText = "Please select Image Location ...";
            this.btnImageLocation.Properties.ReadOnly = true;
            this.btnImageLocation.Size = new System.Drawing.Size(348, 20);
            this.btnImageLocation.StyleController = this.LayoutControl;
            this.btnImageLocation.TabIndex = 9;
            this.btnImageLocation.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnImageLocation_ButtonClick);
            // 
            // itmImageLocation
            // 
            this.itmImageLocation.Control = this.btnImageLocation;
            this.itmImageLocation.CustomizationFormText = "Image Location";
            this.itmImageLocation.Location = new System.Drawing.Point(0, 48);
            this.itmImageLocation.Name = "itmImageLocation";
            this.itmImageLocation.Size = new System.Drawing.Size(448, 24);
            this.itmImageLocation.Text = "Image Location";
            this.itmImageLocation.TextSize = new System.Drawing.Size(92, 13);
            // 
            // CatalogueImportExportDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(466, 354);
            this.Name = "CatalogueImportExportDialogue";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatusGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCatalogueLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCatalogueLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCatalogue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCatalogue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCatalogue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImageLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStatus;
        private DevExpress.XtraLayout.LayoutControlItem itmStatusGrid;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar pbProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit itmStatus;
        private DevExpress.Utils.ImageCollection imageCollectionStatus;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private System.Windows.Forms.OpenFileDialog catalogueLocation;
        private DevExpress.XtraEditors.ButtonEdit btnCatalogueLocation;
        private DevExpress.XtraLayout.LayoutControlItem itmCatalogueLocation;
        private DevExpress.XtraEditors.GridLookUpEdit ddlCatalogue;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCatalogue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPublisher;
        private DevExpress.XtraGrid.Columns.GridColumn colRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription1;
        private DevExpress.XtraLayout.LayoutControlItem itmCatalogue;
        private DevExpress.XtraEditors.ButtonEdit btnImageLocation;
        private DevExpress.XtraLayout.LayoutControlItem itmImageLocation;
        private System.Windows.Forms.FolderBrowserDialog catalogueImageLocation;
    }
}
