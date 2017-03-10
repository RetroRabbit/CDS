namespace CDS.Client.Desktop.Catalogue.CAT
{
    partial class CatalogueManagementForm
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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.itmName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPublisher = new DevExpress.XtraEditors.TextEdit();
            this.itmPublisher = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRevision = new DevExpress.XtraEditors.TextEdit();
            this.itmRevision = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnImageLocation = new DevExpress.XtraEditors.ButtonEdit();
            this.itmImageLocation = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tcgCatalogue = new DevExpress.XtraLayout.TabbedControlGroup();
            this.tabContent = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmEntity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlEntity = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.BindingSourceTopEntities = new System.Windows.Forms.BindingSource(this.components);
            this.ddlEntityView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTopCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcgCatalogueEntry = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCategoryData = new DevExpress.XtraLayout.LayoutControlItem();
            this.tlCategoryData = new DevExpress.XtraTreeList.TreeList();
            this.colCatalogueDataName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCatalogueDataItems = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdMetaData = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceMetaData = new System.Windows.Forms.BindingSource(this.components);
            this.grvMetaData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaDataName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaDataGrouping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaDataSortOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaDataData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repImageLocation = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.itmTopCategory = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlTopCategory = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.InstantFeedbackSourceCategory = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.ddlTopCategoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTopCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabStructure = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCategoryTree = new DevExpress.XtraLayout.LayoutControlItem();
            this.tlCategory = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.BindingSourceCategory = new System.Windows.Forms.BindingSource(this.components);
            this.siStructure = new DevExpress.XtraLayout.SplitterItem();
            this.itmMeta = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdMeta = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceMeta = new System.Windows.Forms.BindingSource(this.components);
            this.grvMeta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMetaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaGrouping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repMetaType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colMetaGrouped = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMetaSortOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InstantFeedbackSourceDataItemStockCode = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.InstantFeedbackSourceEntity = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.rpManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgStructure = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnAddCategory = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddMeta = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveCategory = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveMeta = new DevExpress.XtraBars.BarButtonItem();
            this.rpgContent = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnAddEntity = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveEntity = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveItem = new DevExpress.XtraBars.BarButtonItem();
            this.BindingSourceMetaType = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublisher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPublisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImageLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgCatalogue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEntity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTopEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEntityView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCatalogueEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCategoryData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMetaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMetaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMetaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImageLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTopCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTopCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTopCategoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMetaType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMetaType)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.CAT_Catalogue);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.grdMetaData);
            this.LayoutControl.Controls.Add(this.tlCategoryData);
            this.LayoutControl.Controls.Add(this.grdMeta);
            this.LayoutControl.Controls.Add(this.tlCategory);
            this.LayoutControl.Controls.Add(this.btnImageLocation);
            this.LayoutControl.Controls.Add(this.txtRevision);
            this.LayoutControl.Controls.Add(this.txtPublisher);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtName);
            this.LayoutControl.Controls.Add(this.ddlTopCategory);
            this.LayoutControl.Controls.Add(this.ddlEntity);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2758, 529, 506, 502);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControl.Size = new System.Drawing.Size(1008, 581);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgIdentity,
            this.tcgCatalogue});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(1008, 581);
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddCategory,
            this.btnAddMeta,
            this.btnAddEntity,
            this.btnAddItem,
            this.btnRemoveCategory,
            this.btnRemoveMeta,
            this.btnRemoveEntity,
            this.btnRemoveItem});
            this.RibbonControl.MaxItemId = 32;
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpManage});
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
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(101, 43);
            this.txtName.MenuManager = this.RibbonControl;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(401, 20);
            this.txtName.StyleController = this.LayoutControl;
            this.txtName.TabIndex = 4;
            // 
            // itmName
            // 
            this.itmName.Control = this.txtName;
            this.itmName.CustomizationFormText = "Name";
            this.itmName.Location = new System.Drawing.Point(0, 0);
            this.itmName.Name = "itmName";
            this.itmName.Size = new System.Drawing.Size(482, 24);
            this.itmName.Text = "Name";
            this.itmName.TextSize = new System.Drawing.Size(73, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(101, 67);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(401, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 5;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 24);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(482, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(73, 13);
            // 
            // txtPublisher
            // 
            this.txtPublisher.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Publisher", true));
            this.txtPublisher.Location = new System.Drawing.Point(583, 43);
            this.txtPublisher.MenuManager = this.RibbonControl;
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(401, 20);
            this.txtPublisher.StyleController = this.LayoutControl;
            this.txtPublisher.TabIndex = 6;
            // 
            // itmPublisher
            // 
            this.itmPublisher.Control = this.txtPublisher;
            this.itmPublisher.CustomizationFormText = "Publisher";
            this.itmPublisher.Location = new System.Drawing.Point(482, 0);
            this.itmPublisher.Name = "itmPublisher";
            this.itmPublisher.Size = new System.Drawing.Size(482, 24);
            this.itmPublisher.Text = "Publisher";
            this.itmPublisher.TextSize = new System.Drawing.Size(73, 13);
            // 
            // txtRevision
            // 
            this.txtRevision.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Revision", true));
            this.txtRevision.Location = new System.Drawing.Point(583, 67);
            this.txtRevision.MenuManager = this.RibbonControl;
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(401, 20);
            this.txtRevision.StyleController = this.LayoutControl;
            this.txtRevision.TabIndex = 7;
            // 
            // itmRevision
            // 
            this.itmRevision.Control = this.txtRevision;
            this.itmRevision.CustomizationFormText = "Revision";
            this.itmRevision.Location = new System.Drawing.Point(482, 24);
            this.itmRevision.Name = "itmRevision";
            this.itmRevision.Size = new System.Drawing.Size(482, 24);
            this.itmRevision.Text = "Revision";
            this.itmRevision.TextSize = new System.Drawing.Size(73, 13);
            // 
            // btnImageLocation
            // 
            this.btnImageLocation.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ImageDestination", true));
            this.btnImageLocation.Location = new System.Drawing.Point(101, 91);
            this.btnImageLocation.MenuManager = this.RibbonControl;
            this.btnImageLocation.Name = "btnImageLocation";
            this.btnImageLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnImageLocation.Size = new System.Drawing.Size(883, 20);
            this.btnImageLocation.StyleController = this.LayoutControl;
            this.btnImageLocation.TabIndex = 8;
            this.btnImageLocation.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnImageLocation_ButtonClick);
            // 
            // itmImageLocation
            // 
            this.itmImageLocation.Control = this.btnImageLocation;
            this.itmImageLocation.CustomizationFormText = "Image Location";
            this.itmImageLocation.Location = new System.Drawing.Point(0, 48);
            this.itmImageLocation.Name = "itmImageLocation";
            this.itmImageLocation.Size = new System.Drawing.Size(964, 24);
            this.itmImageLocation.Text = "Image Location";
            this.itmImageLocation.TextSize = new System.Drawing.Size(73, 13);
            // 
            // lcgIdentity
            // 
            this.lcgIdentity.CustomizationFormText = "Identity";
            this.lcgIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmName,
            this.itmDescription,
            this.itmImageLocation,
            this.itmPublisher,
            this.itmRevision});
            this.lcgIdentity.Location = new System.Drawing.Point(0, 0);
            this.lcgIdentity.Name = "lcgIdentity";
            this.lcgIdentity.Size = new System.Drawing.Size(988, 115);
            this.lcgIdentity.Text = "Identity";
            // 
            // tcgCatalogue
            // 
            this.tcgCatalogue.CustomizationFormText = "Catalogue";
            this.tcgCatalogue.Location = new System.Drawing.Point(0, 115);
            this.tcgCatalogue.Name = "tcgCatalogue";
            this.tcgCatalogue.SelectedTabPage = this.tabContent;
            this.tcgCatalogue.SelectedTabPageIndex = 1;
            this.tcgCatalogue.Size = new System.Drawing.Size(988, 446);
            this.tcgCatalogue.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabStructure,
            this.tabContent});
            this.tcgCatalogue.Text = "tcgCatalogue";
            this.tcgCatalogue.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tcgCatalogue_SelectedPageChanged);
            // 
            // tabContent
            // 
            this.tabContent.CustomizationFormText = "Content";
            this.tabContent.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmEntity,
            this.lcgCatalogueEntry,
            this.itmTopCategory});
            this.tabContent.Location = new System.Drawing.Point(0, 0);
            this.tabContent.Name = "tabContent";
            this.tabContent.Size = new System.Drawing.Size(964, 399);
            this.tabContent.Text = "Content";
            // 
            // itmEntity
            // 
            this.itmEntity.Control = this.ddlEntity;
            this.itmEntity.CustomizationFormText = "Entity";
            this.itmEntity.Location = new System.Drawing.Point(0, 24);
            this.itmEntity.Name = "itmEntity";
            this.itmEntity.Size = new System.Drawing.Size(964, 24);
            this.itmEntity.Text = "Entity";
            this.itmEntity.TextSize = new System.Drawing.Size(73, 13);
            // 
            // ddlEntity
            // 
            this.ddlEntity.Location = new System.Drawing.Point(101, 186);
            this.ddlEntity.MenuManager = this.RibbonControl;
            this.ddlEntity.Name = "ddlEntity";
            this.ddlEntity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlEntity.Properties.DataSource = this.BindingSourceTopEntities;
            this.ddlEntity.Properties.DisplayMember = "Name";
            this.ddlEntity.Properties.NullText = "Select entity ...";
            this.ddlEntity.Properties.ValueMember = "Id";
            this.ddlEntity.Properties.View = this.ddlEntityView;
            this.ddlEntity.Size = new System.Drawing.Size(883, 20);
            this.ddlEntity.StyleController = this.LayoutControl;
            this.ddlEntity.TabIndex = 11;
            this.ddlEntity.EditValueChanged += new System.EventHandler(this.ddlEntity_EditValueChanged);
            // 
            // ddlEntityView
            // 
            this.ddlEntityView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTopCategoryName});
            this.ddlEntityView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ddlEntityView.Name = "ddlEntityView";
            this.ddlEntityView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ddlEntityView.OptionsView.ShowGroupPanel = false;
            this.ddlEntityView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTopCategoryName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.ddlEntityView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlEntityView_KeyDown);
            this.ddlEntityView.Click += new System.EventHandler(this.ddlEntityView_Click);
            // 
            // colTopCategoryName
            // 
            this.colTopCategoryName.Caption = "Name";
            this.colTopCategoryName.FieldName = "Name";
            this.colTopCategoryName.Name = "colTopCategoryName";
            this.colTopCategoryName.Visible = true;
            this.colTopCategoryName.VisibleIndex = 0;
            // 
            // lcgCatalogueEntry
            // 
            this.lcgCatalogueEntry.CustomizationFormText = "Catalogue Entry";
            this.lcgCatalogueEntry.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCategoryData,
            this.splitterItem1,
            this.layoutControlItem1});
            this.lcgCatalogueEntry.Location = new System.Drawing.Point(0, 48);
            this.lcgCatalogueEntry.Name = "lcgCatalogueEntry";
            this.lcgCatalogueEntry.Size = new System.Drawing.Size(964, 351);
            this.lcgCatalogueEntry.Text = "Catalogue Entry";
            // 
            // itmCategoryData
            // 
            this.itmCategoryData.Control = this.tlCategoryData;
            this.itmCategoryData.CustomizationFormText = "Category Data";
            this.itmCategoryData.Location = new System.Drawing.Point(0, 0);
            this.itmCategoryData.Name = "itmCategoryData";
            this.itmCategoryData.Size = new System.Drawing.Size(340, 308);
            this.itmCategoryData.Text = "Category Data";
            this.itmCategoryData.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmCategoryData.TextSize = new System.Drawing.Size(0, 0);
            this.itmCategoryData.TextVisible = false;
            // 
            // tlCategoryData
            // 
            this.tlCategoryData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colCatalogueDataName,
            this.colCatalogueDataItems});
            this.tlCategoryData.KeyFieldName = "Id";
            this.tlCategoryData.Location = new System.Drawing.Point(36, 241);
            this.tlCategoryData.Name = "tlCategoryData";
            this.tlCategoryData.OptionsBehavior.Editable = false;
            this.tlCategoryData.OptionsBehavior.EnableFiltering = true;
            this.tlCategoryData.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.tlCategoryData.OptionsMenu.EnableColumnMenu = false;
            this.tlCategoryData.OptionsMenu.EnableFooterMenu = false;
            this.tlCategoryData.OptionsMenu.ShowAutoFilterRowItem = false;
            this.tlCategoryData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tlCategoryData.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.tlCategoryData.OptionsView.ShowIndicator = false;
            this.tlCategoryData.ParentFieldName = "CategoryId";
            this.tlCategoryData.Size = new System.Drawing.Size(336, 304);
            this.tlCategoryData.TabIndex = 12;
            this.tlCategoryData.VertScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always;
            this.tlCategoryData.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlCategoryData_FocusedNodeChanged);
            // 
            // colCatalogueDataName
            // 
            this.colCatalogueDataName.Caption = "Name";
            this.colCatalogueDataName.FieldName = "Name";
            this.colCatalogueDataName.Name = "colCatalogueDataName";
            this.colCatalogueDataName.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colCatalogueDataName.Visible = true;
            this.colCatalogueDataName.VisibleIndex = 0;
            // 
            // colCatalogueDataItems
            // 
            this.colCatalogueDataItems.Caption = "Items";
            this.colCatalogueDataItems.FieldName = "Items";
            this.colCatalogueDataItems.Name = "colCatalogueDataItems";
            this.colCatalogueDataItems.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colCatalogueDataItems.Visible = true;
            this.colCatalogueDataItems.VisibleIndex = 1;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(928, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(12, 308);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdMetaData;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(340, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(588, 308);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // grdMetaData
            // 
            this.grdMetaData.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdMetaData.DataSource = this.BindingSourceMetaData;
            this.grdMetaData.Location = new System.Drawing.Point(376, 241);
            this.grdMetaData.MainView = this.grvMetaData;
            this.grdMetaData.MenuManager = this.RibbonControl;
            this.grdMetaData.Name = "grdMetaData";
            this.grdMetaData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repImageLocation});
            this.grdMetaData.Size = new System.Drawing.Size(584, 304);
            this.grdMetaData.TabIndex = 17;
            this.grdMetaData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMetaData});
            // 
            // BindingSourceMetaData
            // 
            this.BindingSourceMetaData.AllowNew = false;
            this.BindingSourceMetaData.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_MetaData);
            // 
            // grvMetaData
            // 
            this.grvMetaData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName,
            this.colMetaDataName,
            this.colMetaDataGrouping,
            this.colMetaDataType,
            this.colMetaDataSortOrder,
            this.colMetaDataData});
            this.grvMetaData.GridControl = this.grdMetaData;
            this.grvMetaData.Name = "grvMetaData";
            this.grvMetaData.OptionsView.ShowGroupPanel = false;
            this.grvMetaData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colItemName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMetaDataSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvMetaData.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvMetaData_CustomDrawCell);
            this.grvMetaData.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvMetaData_CustomRowCellEdit);
            this.grvMetaData.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvMetaData_CustomRowCellEditForEditing);
            this.grvMetaData.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvMetaData_CellValueChanged);
            this.grvMetaData.DoubleClick += new System.EventHandler(this.grvMetaData_DoubleClick);
            // 
            // colItemName
            // 
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 401;
            // 
            // colMetaDataName
            // 
            this.colMetaDataName.FieldName = "Name";
            this.colMetaDataName.Name = "colMetaDataName";
            this.colMetaDataName.OptionsColumn.AllowEdit = false;
            this.colMetaDataName.OptionsColumn.AllowFocus = false;
            this.colMetaDataName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colMetaDataName.OptionsColumn.AllowMove = false;
            this.colMetaDataName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMetaDataName.Visible = true;
            this.colMetaDataName.VisibleIndex = 1;
            this.colMetaDataName.Width = 315;
            // 
            // colMetaDataGrouping
            // 
            this.colMetaDataGrouping.FieldName = "Grouping";
            this.colMetaDataGrouping.Name = "colMetaDataGrouping";
            this.colMetaDataGrouping.OptionsColumn.AllowEdit = false;
            this.colMetaDataGrouping.OptionsColumn.AllowFocus = false;
            this.colMetaDataGrouping.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colMetaDataGrouping.OptionsColumn.AllowMove = false;
            this.colMetaDataGrouping.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMetaDataGrouping.Visible = true;
            this.colMetaDataGrouping.VisibleIndex = 2;
            this.colMetaDataGrouping.Width = 239;
            // 
            // colMetaDataType
            // 
            this.colMetaDataType.FieldName = "Type";
            this.colMetaDataType.Name = "colMetaDataType";
            this.colMetaDataType.OptionsColumn.AllowEdit = false;
            this.colMetaDataType.OptionsColumn.AllowFocus = false;
            this.colMetaDataType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colMetaDataType.OptionsColumn.AllowMove = false;
            this.colMetaDataType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMetaDataType.Visible = true;
            this.colMetaDataType.VisibleIndex = 3;
            this.colMetaDataType.Width = 239;
            // 
            // colMetaDataSortOrder
            // 
            this.colMetaDataSortOrder.FieldName = "SortOrder";
            this.colMetaDataSortOrder.Name = "colMetaDataSortOrder";
            this.colMetaDataSortOrder.OptionsColumn.AllowEdit = false;
            this.colMetaDataSortOrder.OptionsColumn.AllowFocus = false;
            this.colMetaDataSortOrder.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colMetaDataSortOrder.OptionsColumn.AllowMove = false;
            this.colMetaDataSortOrder.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMetaDataSortOrder.Width = 83;
            // 
            // colMetaDataData
            // 
            this.colMetaDataData.FieldName = "Data";
            this.colMetaDataData.Name = "colMetaDataData";
            this.colMetaDataData.Visible = true;
            this.colMetaDataData.VisibleIndex = 4;
            this.colMetaDataData.Width = 435;
            // 
            // repImageLocation
            // 
            this.repImageLocation.AutoHeight = false;
            this.repImageLocation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repImageLocation.Name = "repImageLocation";
            this.repImageLocation.ReadOnly = true;
            this.repImageLocation.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repImageLocation.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repImageLocation_ButtonClick);
            // 
            // itmTopCategory
            // 
            this.itmTopCategory.Control = this.ddlTopCategory;
            this.itmTopCategory.CustomizationFormText = "Category";
            this.itmTopCategory.Location = new System.Drawing.Point(0, 0);
            this.itmTopCategory.Name = "itmTopCategory";
            this.itmTopCategory.Size = new System.Drawing.Size(964, 24);
            this.itmTopCategory.Text = "Category";
            this.itmTopCategory.TextSize = new System.Drawing.Size(73, 13);
            // 
            // ddlTopCategory
            // 
            this.ddlTopCategory.Location = new System.Drawing.Point(101, 162);
            this.ddlTopCategory.MenuManager = this.RibbonControl;
            this.ddlTopCategory.Name = "ddlTopCategory";
            this.ddlTopCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlTopCategory.Properties.DataSource = this.InstantFeedbackSourceCategory;
            this.ddlTopCategory.Properties.DisplayMember = "Name";
            this.ddlTopCategory.Properties.NullText = "Select category ...";
            this.ddlTopCategory.Properties.ValueMember = "Id";
            this.ddlTopCategory.Properties.View = this.ddlTopCategoryView;
            this.ddlTopCategory.Size = new System.Drawing.Size(883, 20);
            this.ddlTopCategory.StyleController = this.LayoutControl;
            this.ddlTopCategory.TabIndex = 13;
            this.ddlTopCategory.EditValueChanged += new System.EventHandler(this.ddlTopCategory_EditValueChanged);
            // 
            // InstantFeedbackSourceCategory
            // 
            this.InstantFeedbackSourceCategory.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.CAT_Category);
            this.InstantFeedbackSourceCategory.KeyExpression = "Id";
            this.InstantFeedbackSourceCategory.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceCategory_GetQueryable);
            // 
            // ddlTopCategoryView
            // 
            this.ddlTopCategoryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTopCategory});
            this.ddlTopCategoryView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ddlTopCategoryView.Name = "ddlTopCategoryView";
            this.ddlTopCategoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ddlTopCategoryView.OptionsView.ShowGroupPanel = false;
            this.ddlTopCategoryView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTopCategory, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.ddlTopCategoryView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlTopCategoryView_KeyDown);
            this.ddlTopCategoryView.Click += new System.EventHandler(this.ddlTopCategoryView_Click);
            // 
            // colTopCategory
            // 
            this.colTopCategory.FieldName = "Name";
            this.colTopCategory.Name = "colTopCategory";
            this.colTopCategory.Visible = true;
            this.colTopCategory.VisibleIndex = 0;
            // 
            // tabStructure
            // 
            this.tabStructure.CustomizationFormText = "Structure";
            this.tabStructure.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCategoryTree,
            this.siStructure,
            this.itmMeta});
            this.tabStructure.Location = new System.Drawing.Point(0, 0);
            this.tabStructure.Name = "tabStructure";
            this.tabStructure.Size = new System.Drawing.Size(964, 399);
            this.tabStructure.Text = "Structure";
            // 
            // itmCategoryTree
            // 
            this.itmCategoryTree.Control = this.tlCategory;
            this.itmCategoryTree.CustomizationFormText = "Categories";
            this.itmCategoryTree.Location = new System.Drawing.Point(0, 0);
            this.itmCategoryTree.Name = "itmCategoryTree";
            this.itmCategoryTree.Size = new System.Drawing.Size(475, 399);
            this.itmCategoryTree.Text = "Categories";
            this.itmCategoryTree.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmCategoryTree.TextSize = new System.Drawing.Size(73, 13);
            // 
            // tlCategory
            // 
            this.tlCategory.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.tlCategory.DataSource = this.BindingSourceCategory;
            this.tlCategory.KeyFieldName = "Id";
            this.tlCategory.Location = new System.Drawing.Point(24, 178);
            this.tlCategory.Name = "tlCategory";
            this.tlCategory.OptionsBehavior.DragNodes = true;
            this.tlCategory.OptionsNavigation.AutoFocusNewNode = true;
            this.tlCategory.OptionsSelection.MultiSelect = true;
            this.tlCategory.ParentFieldName = "CategoryId";
            this.tlCategory.Size = new System.Drawing.Size(471, 379);
            this.tlCategory.TabIndex = 9;
            this.tlCategory.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlCategory_FocusedNodeChanged);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 43;
            // 
            // BindingSourceCategory
            // 
            this.BindingSourceCategory.DataSource = typeof(CDS.Client.DataAccessLayer.DB.CAT_Category);
            // 
            // siStructure
            // 
            this.siStructure.AllowHotTrack = true;
            this.siStructure.CustomizationFormText = "Splitter";
            this.siStructure.Location = new System.Drawing.Point(475, 0);
            this.siStructure.Name = "siStructure";
            this.siStructure.Size = new System.Drawing.Size(12, 399);
            // 
            // itmMeta
            // 
            this.itmMeta.Control = this.grdMeta;
            this.itmMeta.CustomizationFormText = "Properties";
            this.itmMeta.Location = new System.Drawing.Point(487, 0);
            this.itmMeta.Name = "itmMeta";
            this.itmMeta.Size = new System.Drawing.Size(477, 399);
            this.itmMeta.Text = "Meta";
            this.itmMeta.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmMeta.TextSize = new System.Drawing.Size(73, 13);
            // 
            // grdMeta
            // 
            this.grdMeta.DataSource = this.BindingSourceMeta;
            this.grdMeta.Location = new System.Drawing.Point(511, 178);
            this.grdMeta.MainView = this.grvMeta;
            this.grdMeta.MenuManager = this.RibbonControl;
            this.grdMeta.Name = "grdMeta";
            this.grdMeta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repMetaType});
            this.grdMeta.Size = new System.Drawing.Size(473, 379);
            this.grdMeta.TabIndex = 10;
            this.grdMeta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMeta});
            this.grdMeta.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdMeta_DragOver);
            this.grdMeta.DragOver += new System.Windows.Forms.DragEventHandler(this.grdMeta_DragOver);
            // 
            // BindingSourceMeta
            // 
            this.BindingSourceMeta.AllowNew = false;
            this.BindingSourceMeta.DataSource = typeof(CDS.Client.DataAccessLayer.DB.CAT_Meta);
            // 
            // grvMeta
            // 
            this.grvMeta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMetaName,
            this.colMetaGrouping,
            this.colMetaType,
            this.colMetaGrouped,
            this.colMetaCreatedOn,
            this.colMetaCreatedBy,
            this.colMetaSortOrder});
            this.grvMeta.GridControl = this.grdMeta;
            this.grvMeta.Name = "grvMeta";
            this.grvMeta.OptionsCustomization.AllowSort = false;
            this.grvMeta.OptionsView.ShowGroupPanel = false;
            this.grvMeta.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMetaSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvMeta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvMeta_MouseDown);
            this.grvMeta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grvMeta_MouseMove);
            // 
            // colMetaName
            // 
            this.colMetaName.FieldName = "Name";
            this.colMetaName.Name = "colMetaName";
            this.colMetaName.Visible = true;
            this.colMetaName.VisibleIndex = 0;
            // 
            // colMetaGrouping
            // 
            this.colMetaGrouping.FieldName = "Grouping";
            this.colMetaGrouping.Name = "colMetaGrouping";
            this.colMetaGrouping.Visible = true;
            this.colMetaGrouping.VisibleIndex = 1;
            // 
            // colMetaType
            // 
            this.colMetaType.ColumnEdit = this.repMetaType;
            this.colMetaType.FieldName = "Type";
            this.colMetaType.Name = "colMetaType";
            this.colMetaType.Visible = true;
            this.colMetaType.VisibleIndex = 2;
            // 
            // repMetaType
            // 
            this.repMetaType.AutoHeight = false;
            this.repMetaType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repMetaType.Items.AddRange(new object[] {
            "String",
            "Numeric",
            "Image",
            "Object"});
            this.repMetaType.Name = "repMetaType";
            this.repMetaType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colMetaGrouped
            // 
            this.colMetaGrouped.FieldName = "Grouped";
            this.colMetaGrouped.Name = "colMetaGrouped";
            this.colMetaGrouped.Visible = true;
            this.colMetaGrouped.VisibleIndex = 3;
            // 
            // colMetaCreatedOn
            // 
            this.colMetaCreatedOn.FieldName = "CreatedOn";
            this.colMetaCreatedOn.Name = "colMetaCreatedOn";
            // 
            // colMetaCreatedBy
            // 
            this.colMetaCreatedBy.FieldName = "CreatedBy";
            this.colMetaCreatedBy.Name = "colMetaCreatedBy";
            // 
            // colMetaSortOrder
            // 
            this.colMetaSortOrder.FieldName = "SortOrder";
            this.colMetaSortOrder.Name = "colMetaSortOrder";
            // 
            // InstantFeedbackSourceDataItemStockCode
            // 
            this.InstantFeedbackSourceDataItemStockCode.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_LineItem);
            this.InstantFeedbackSourceDataItemStockCode.KeyExpression = "Id";
            this.InstantFeedbackSourceDataItemStockCode.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceDataItemStockCode_GetQueryable);
            // 
            // rpManage
            // 
            this.rpManage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgStructure,
            this.rpgContent});
            this.rpManage.Name = "rpManage";
            this.rpManage.Text = "Manage";
            // 
            // rpgStructure
            // 
            this.rpgStructure.ItemLinks.Add(this.btnAddCategory);
            this.rpgStructure.ItemLinks.Add(this.btnAddMeta);
            this.rpgStructure.ItemLinks.Add(this.btnRemoveCategory, true);
            this.rpgStructure.ItemLinks.Add(this.btnRemoveMeta);
            this.rpgStructure.Name = "rpgStructure";
            this.rpgStructure.Text = "Structure";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Caption = "Add Category";
            this.btnAddCategory.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.book_blue_add_16;
            this.btnAddCategory.Id = 24;
            this.btnAddCategory.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.book_blue_add_32;
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddCategory_ItemClick);
            // 
            // btnAddMeta
            // 
            this.btnAddMeta.Caption = "Add Meta";
            this.btnAddMeta.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.tag_add_16;
            this.btnAddMeta.Id = 25;
            this.btnAddMeta.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.tag_add_32;
            this.btnAddMeta.Name = "btnAddMeta";
            this.btnAddMeta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddMeta_ItemClick);
            // 
            // btnRemoveCategory
            // 
            this.btnRemoveCategory.Caption = "Remove Category";
            this.btnRemoveCategory.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.book_blue_delete_16;
            this.btnRemoveCategory.Id = 28;
            this.btnRemoveCategory.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.book_blue_delete_32;
            this.btnRemoveCategory.Name = "btnRemoveCategory";
            this.btnRemoveCategory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveCategory_ItemClick);
            // 
            // btnRemoveMeta
            // 
            this.btnRemoveMeta.Caption = "Remove Meta";
            this.btnRemoveMeta.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.tag_delete_16;
            this.btnRemoveMeta.Id = 29;
            this.btnRemoveMeta.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.tag_delete_32;
            this.btnRemoveMeta.Name = "btnRemoveMeta";
            this.btnRemoveMeta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveMeta_ItemClick);
            // 
            // rpgContent
            // 
            this.rpgContent.ItemLinks.Add(this.btnAddEntity);
            this.rpgContent.ItemLinks.Add(this.btnAddItem);
            this.rpgContent.ItemLinks.Add(this.btnRemoveEntity, true);
            this.rpgContent.ItemLinks.Add(this.btnRemoveItem);
            this.rpgContent.Name = "rpgContent";
            this.rpgContent.Text = "Content";
            // 
            // btnAddEntity
            // 
            this.btnAddEntity.Caption = "Add Entity";
            this.btnAddEntity.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.components_add_16;
            this.btnAddEntity.Id = 26;
            this.btnAddEntity.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.components_add_32;
            this.btnAddEntity.Name = "btnAddEntity";
            this.btnAddEntity.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddEntity_ItemClick);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Caption = "Add Item";
            this.btnAddItem.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.component_blue_add_16;
            this.btnAddItem.Id = 27;
            this.btnAddItem.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.component_blue_add_32;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddItem_ItemClick);
            // 
            // btnRemoveEntity
            // 
            this.btnRemoveEntity.Caption = "Remove Entity";
            this.btnRemoveEntity.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.components_delete_16;
            this.btnRemoveEntity.Id = 30;
            this.btnRemoveEntity.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.components_delete_32;
            this.btnRemoveEntity.Name = "btnRemoveEntity";
            this.btnRemoveEntity.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveEntity_ItemClick);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Caption = "Remove Item";
            this.btnRemoveItem.Glyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.component_blue_delete_16;
            this.btnRemoveItem.Id = 31;
            this.btnRemoveItem.LargeGlyph = global::CDS.Client.Desktop.Catalogue.Properties.Resources.component_blue_delete_32;
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveItem_ItemClick);
            // 
            // BindingSourceMetaType
            // 
            this.BindingSourceMetaType.AllowNew = false;
            // 
            // CatalogueManagementForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Name", true));
            this.Name = "CatalogueManagementForm";
            this.TabIcon = global::CDS.Client.Desktop.Catalogue.Properties.Resources.book_bookmark_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Catalogue.Properties.Resources.book_bookmark_16;
            this.Text = "Manage Catalogue";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublisher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPublisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImageLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImageLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgCatalogue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEntity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTopEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEntityView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCatalogueEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCategoryData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMetaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMetaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMetaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImageLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTopCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTopCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTopCategoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCategoryTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMetaType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMetaType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem itmName;
        private DevExpress.XtraEditors.ButtonEdit btnImageLocation;
        private DevExpress.XtraEditors.TextEdit txtRevision;
        private DevExpress.XtraEditors.TextEdit txtPublisher;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIdentity;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmImageLocation;
        private DevExpress.XtraLayout.LayoutControlItem itmPublisher;
        private DevExpress.XtraLayout.LayoutControlItem itmRevision;
        private DevExpress.XtraGrid.GridControl grdMeta;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMeta;
        private DevExpress.XtraTreeList.TreeList tlCategory;
        private DevExpress.XtraLayout.TabbedControlGroup tcgCatalogue;
        private DevExpress.XtraLayout.LayoutControlGroup tabStructure;
        private DevExpress.XtraLayout.LayoutControlItem itmCategoryTree;
        private DevExpress.XtraLayout.SplitterItem siStructure;
        private DevExpress.XtraLayout.LayoutControlItem itmMeta;
        private DevExpress.XtraLayout.LayoutControlGroup tabContent;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.BindingSource BindingSourceCategory;
        private DevExpress.XtraBars.BarButtonItem btnAddCategory;
        private DevExpress.XtraBars.BarButtonItem btnAddMeta;
        private DevExpress.XtraBars.BarButtonItem btnAddEntity;
        private DevExpress.XtraBars.BarButtonItem btnAddItem;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgStructure;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgContent;
        private DevExpress.XtraBars.BarButtonItem btnRemoveCategory;
        private DevExpress.XtraBars.BarButtonItem btnRemoveMeta;
        private DevExpress.XtraBars.BarButtonItem btnRemoveEntity;
        private DevExpress.XtraBars.BarButtonItem btnRemoveItem;
        private System.Windows.Forms.BindingSource BindingSourceMeta;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaName;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaGrouping;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaType;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaGrouped;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaSortOrder;
        private DevExpress.XtraTreeList.TreeList tlCategoryData;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceEntity;
        private DevExpress.XtraLayout.LayoutControlItem itmEntity;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCatalogueEntry;
        private DevExpress.XtraLayout.LayoutControlItem itmCategoryData;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceCategory;
        private DevExpress.XtraLayout.LayoutControlItem itmTopCategory;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlTopCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView ddlTopCategoryView;
        private DevExpress.XtraGrid.Columns.GridColumn colTopCategory;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView ddlEntityView;
        private System.Windows.Forms.BindingSource BindingSourceTopEntities;
        private DevExpress.XtraGrid.Columns.GridColumn colTopCategoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repMetaType;
        private System.Windows.Forms.BindingSource BindingSourceMetaType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCatalogueDataName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCatalogueDataItems;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceDataItemStockCode;
        private System.Windows.Forms.BindingSource BindingSourceMetaData;
        private DevExpress.XtraGrid.GridControl grdMetaData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMetaData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaDataName;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaDataGrouping;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaDataSortOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colMetaDataData;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repImageLocation;
    }
}
