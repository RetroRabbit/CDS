namespace CDS.Client.Desktop.Stock.Inventory
{
    partial class ChangeAverageCostDialogue
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
            this.grdItems = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceLines = new System.Windows.Forms.BindingSource();
            this.grvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLineEntity = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.InstantFeedbackSource = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.repViewLineEntity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockType1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationMain1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationSecondary1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrouping1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfitMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnReserve1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnOrder1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitAverage1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalanceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmGridItems = new DevExpress.XtraLayout.LayoutControlItem();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewLineEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.btnOk);
            this.LayoutControl.Controls.Add(this.grdItems);
            this.LayoutControl.Location = new System.Drawing.Point(6, 50);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2656, 44, 250, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(495, 191);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmGridItems,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(495, 191);
            this.LayoutGroup.Text = "Root";
            // 
            // grdItems
            // 
            this.grdItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdItems.DataSource = this.BindingSourceLines;
            this.grdItems.Location = new System.Drawing.Point(6, 6);
            this.grdItems.MainView = this.grvItems;
            this.grdItems.Name = "grdItems";
            this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLineEntity});
            this.grdItems.Size = new System.Drawing.Size(483, 153);
            this.grdItems.TabIndex = 0;
            this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvItems});
            // 
            // BindingSourceLines
            // 
            this.BindingSourceLines.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Line);
            // 
            // grvItems
            // 
            this.grvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemId,
            this.colDescription,
            this.colOnHand,
            this.colAmount});
            this.grvItems.GridControl = this.grdItems;
            this.grvItems.Name = "grvItems";
            this.grvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvItems.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvItems.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvItems.OptionsView.ShowGroupPanel = false;
            this.grvItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvItems_CellValueChanged);
            // 
            // colItemId
            // 
            this.colItemId.Caption = "Item";
            this.colItemId.ColumnEdit = this.repLineEntity;
            this.colItemId.FieldName = "ItemId";
            this.colItemId.MinWidth = 120;
            this.colItemId.Name = "colItemId";
            this.colItemId.OptionsColumn.AllowMove = false;
            this.colItemId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colItemId.Visible = true;
            this.colItemId.VisibleIndex = 0;
            this.colItemId.Width = 133;
            // 
            // repLineEntity
            // 
            this.repLineEntity.AutoHeight = false;
            this.repLineEntity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLineEntity.DataSource = this.InstantFeedbackSource;
            this.repLineEntity.DisplayMember = "Title";
            this.repLineEntity.Name = "repLineEntity";
            this.repLineEntity.NullText = "Select Item ...";
            this.repLineEntity.ValueMember = "Id";
            this.repLineEntity.View = this.repViewLineEntity;
            // 
            // InstantFeedbackSource
            // 
            this.InstantFeedbackSource.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_LineItem);
            this.InstantFeedbackSource.KeyExpression = "Id";
            this.InstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSource_GetQueryable);
            // 
            // repViewLineEntity
            // 
            this.repViewLineEntity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShortName,
            this.colName1,
            this.colDescription2,
            this.colSupplierStockCode,
            this.colCategory1,
            this.colSubCategory1,
            this.colStockType1,
            this.colLocationMain1,
            this.colLocationSecondary1,
            this.colDiscountCode1,
            this.colGrouping1,
            this.colProfitMargin,
            this.colOnHand1,
            this.colOnReserve1,
            this.colOnOrder1,
            this.colUnitPrice,
            this.colUnitCost1,
            this.colUnitAverage1,
            this.colBalanceAmount});
            this.repViewLineEntity.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repViewLineEntity.Name = "repViewLineEntity";
            this.repViewLineEntity.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repViewLineEntity.OptionsView.ShowGroupPanel = false;
            this.repViewLineEntity.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colShortName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colShortName
            // 
            this.colShortName.FieldName = "ShortName";
            this.colShortName.Name = "colShortName";
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 0;
            this.colShortName.Width = 238;
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 1;
            this.colName1.Width = 195;
            // 
            // colDescription2
            // 
            this.colDescription2.FieldName = "Description";
            this.colDescription2.Name = "colDescription2";
            this.colDescription2.Visible = true;
            this.colDescription2.VisibleIndex = 2;
            this.colDescription2.Width = 228;
            // 
            // colSupplierStockCode
            // 
            this.colSupplierStockCode.FieldName = "SupplierStockCode";
            this.colSupplierStockCode.Name = "colSupplierStockCode";
            // 
            // colCategory1
            // 
            this.colCategory1.FieldName = "Category";
            this.colCategory1.Name = "colCategory1";
            this.colCategory1.Visible = true;
            this.colCategory1.VisibleIndex = 3;
            this.colCategory1.Width = 108;
            // 
            // colSubCategory1
            // 
            this.colSubCategory1.FieldName = "SubCategory";
            this.colSubCategory1.Name = "colSubCategory1";
            // 
            // colStockType1
            // 
            this.colStockType1.FieldName = "StockType";
            this.colStockType1.Name = "colStockType1";
            this.colStockType1.Width = 105;
            // 
            // colLocationMain1
            // 
            this.colLocationMain1.FieldName = "LocationMain";
            this.colLocationMain1.Name = "colLocationMain1";
            this.colLocationMain1.Visible = true;
            this.colLocationMain1.VisibleIndex = 4;
            this.colLocationMain1.Width = 108;
            // 
            // colLocationSecondary1
            // 
            this.colLocationSecondary1.FieldName = "LocationSecondary";
            this.colLocationSecondary1.Name = "colLocationSecondary1";
            // 
            // colDiscountCode1
            // 
            this.colDiscountCode1.FieldName = "DiscountCode";
            this.colDiscountCode1.Name = "colDiscountCode1";
            this.colDiscountCode1.Visible = true;
            this.colDiscountCode1.VisibleIndex = 5;
            this.colDiscountCode1.Width = 108;
            // 
            // colGrouping1
            // 
            this.colGrouping1.FieldName = "Grouping";
            this.colGrouping1.Name = "colGrouping1";
            // 
            // colProfitMargin
            // 
            this.colProfitMargin.FieldName = "ProfitMargin";
            this.colProfitMargin.Name = "colProfitMargin";
            // 
            // colOnHand1
            // 
            this.colOnHand1.FieldName = "OnHand";
            this.colOnHand1.Name = "colOnHand1";
            this.colOnHand1.Visible = true;
            this.colOnHand1.VisibleIndex = 6;
            this.colOnHand1.Width = 108;
            // 
            // colOnReserve1
            // 
            this.colOnReserve1.FieldName = "OnReserve";
            this.colOnReserve1.Name = "colOnReserve1";
            this.colOnReserve1.Width = 105;
            // 
            // colOnOrder1
            // 
            this.colOnOrder1.FieldName = "OnOrder";
            this.colOnOrder1.Name = "colOnOrder1";
            this.colOnOrder1.Width = 105;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 7;
            this.colUnitPrice.Width = 108;
            // 
            // colUnitCost1
            // 
            this.colUnitCost1.FieldName = "UnitCost";
            this.colUnitCost1.Name = "colUnitCost1";
            this.colUnitCost1.Visible = true;
            this.colUnitCost1.VisibleIndex = 8;
            this.colUnitCost1.Width = 108;
            // 
            // colUnitAverage1
            // 
            this.colUnitAverage1.FieldName = "UnitAverage";
            this.colUnitAverage1.Name = "colUnitAverage1";
            this.colUnitAverage1.Visible = true;
            this.colUnitAverage1.VisibleIndex = 9;
            this.colUnitAverage1.Width = 108;
            // 
            // colBalanceAmount
            // 
            this.colBalanceAmount.FieldName = "BalanceAmount";
            this.colBalanceAmount.Name = "colBalanceAmount";
            this.colBalanceAmount.Visible = true;
            this.colBalanceAmount.VisibleIndex = 10;
            this.colBalanceAmount.Width = 149;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 185;
            // 
            // colOnHand
            // 
            this.colOnHand.Caption = "On Hand";
            this.colOnHand.FieldName = "LineItem.OnHand";
            this.colOnHand.Name = "colOnHand";
            this.colOnHand.OptionsColumn.AllowEdit = false;
            this.colOnHand.OptionsColumn.AllowFocus = false;
            this.colOnHand.OptionsColumn.ReadOnly = true;
            this.colOnHand.Visible = true;
            this.colOnHand.VisibleIndex = 2;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "New Average";
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 80;
            this.colAmount.MinWidth = 60;
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsColumn.AllowMove = false;
            this.colAmount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            this.colAmount.Width = 60;
            // 
            // itmGridItems
            // 
            this.itmGridItems.Control = this.grdItems;
            this.itmGridItems.CustomizationFormText = "Grid Items";
            this.itmGridItems.Location = new System.Drawing.Point(0, 0);
            this.itmGridItems.Name = "itmGridItems";
            this.itmGridItems.Size = new System.Drawing.Size(487, 157);
            this.itmGridItems.Text = "Grid Items";
            this.itmGridItems.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridItems.TextVisible = false;
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_DOC_Header);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 157);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(328, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(334, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 22);
            this.btnOk.StyleController = this.LayoutControl;
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOk;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(328, 157);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(414, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(408, 157);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(79, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ChangeAverageCostDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 247);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChangeAverageCostDialogue";
            this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TabHeading = " Select the items you want to change there average cost";
            this.Text = "Change Average Cost";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLineEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repViewLineEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdItems;
        private System.Windows.Forms.BindingSource BindingSourceLines;
        private DevExpress.XtraGrid.Views.Grid.GridView grvItems;
        private DevExpress.XtraGrid.Columns.GridColumn colItemId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repLineEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView repViewLineEntity;
        private DevExpress.XtraLayout.LayoutControlItem itmGridItems;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription2;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory1;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCategory1;
        private DevExpress.XtraGrid.Columns.GridColumn colStockType1;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationMain1;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationSecondary1;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colGrouping1;
        private DevExpress.XtraGrid.Columns.GridColumn colProfitMargin;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand1;
        private DevExpress.XtraGrid.Columns.GridColumn colOnReserve1;
        private DevExpress.XtraGrid.Columns.GridColumn colOnOrder1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitAverage1;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSource;
    }
}
