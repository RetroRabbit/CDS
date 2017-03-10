namespace CDS.Client.Desktop.Stock.Inventory
{
    partial class DiscountList
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
            this.colAmountType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryDiscountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyDiscountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVolumeNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriorityDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkshopDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVolumeDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GridControl.Size = new System.Drawing.Size(608, 188);
            // 
            // GridView
            // 
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAmountType,
            this.colType,
            this.colInventory,
            this.colCompany,
            this.colInventoryDiscountCode,
            this.colCompanyDiscountCode,
            this.colVolumeNumber,
            this.colPriorityDiscount,
            this.colCompanyDiscount,
            this.colWorkshopDiscount,
            this.colVolumeDiscount,
            this.colStartDate,
            this.colEndDate});
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(612, 192);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(612, 192);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(612, 192);
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.ITM_DIS_Discount);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.Size = new System.Drawing.Size(612, 144);
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
            // colAmountType
            // 
            this.colAmountType.Caption = "Amount Type";
            this.colAmountType.FieldName = "DiscountAmountTypeId.Name";
            this.colAmountType.Name = "colAmountType";
            this.colAmountType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAmountType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colAmountType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colAmountType.Visible = true;
            this.colAmountType.VisibleIndex = 0;
            this.colAmountType.Width = 227;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "DiscountTypeId.Name";
            this.colType.Name = "colType";
            this.colType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            this.colType.Width = 174;
            // 
            // colInventory
            // 
            this.colInventory.Caption = "Inventory";
            this.colInventory.FieldName = "InventoryId.ShortName";
            this.colInventory.Name = "colInventory";
            this.colInventory.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colInventory.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colInventory.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colInventory.Visible = true;
            this.colInventory.VisibleIndex = 2;
            this.colInventory.Width = 412;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Company";
            this.colCompany.FieldName = "EntityId.Title";
            this.colCompany.Name = "colCompany";
            this.colCompany.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCompany.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCompany.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 3;
            this.colCompany.Width = 389;
            // 
            // colInventoryDiscountCode
            // 
            this.colInventoryDiscountCode.FieldName = "InventoryDiscountCode";
            this.colInventoryDiscountCode.Name = "colInventoryDiscountCode";
            this.colInventoryDiscountCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colInventoryDiscountCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colInventoryDiscountCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colInventoryDiscountCode.Visible = true;
            this.colInventoryDiscountCode.VisibleIndex = 4;
            this.colInventoryDiscountCode.Width = 253;
            // 
            // colCompanyDiscountCode
            // 
            this.colCompanyDiscountCode.FieldName = "CompanyDiscountCode";
            this.colCompanyDiscountCode.Name = "colCompanyDiscountCode";
            this.colCompanyDiscountCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCompanyDiscountCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCompanyDiscountCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCompanyDiscountCode.Visible = true;
            this.colCompanyDiscountCode.VisibleIndex = 5;
            this.colCompanyDiscountCode.Width = 268;
            // 
            // colVolumeNumber
            // 
            this.colVolumeNumber.FieldName = "VolumeNumber";
            this.colVolumeNumber.Name = "colVolumeNumber";
            this.colVolumeNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colVolumeNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colPriorityDiscount
            // 
            this.colPriorityDiscount.FieldName = "PriorityDiscount";
            this.colPriorityDiscount.Name = "colPriorityDiscount";
            this.colPriorityDiscount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colWorkshopDiscount
            // 
            this.colWorkshopDiscount.FieldName = "WorkshopDiscount";
            this.colWorkshopDiscount.Name = "colWorkshopDiscount";
            this.colWorkshopDiscount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colWorkshopDiscount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colVolumeDiscount
            // 
            this.colVolumeDiscount.FieldName = "VolumeDiscount";
            this.colVolumeDiscount.Name = "colVolumeDiscount";
            this.colVolumeDiscount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colVolumeDiscount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colStartDate
            // 
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colStartDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colEndDate
            // 
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colEndDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colCompanyDiscount
            // 
            this.colCompanyDiscount.FieldName = "CompanyDiscount";
            this.colCompanyDiscount.Name = "colCompanyDiscount";
            this.colCompanyDiscount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colCompanyDiscount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // DiscountList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(612, 336);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "DiscountList";
            this.TabIcon = global::CDS.Client.Desktop.Stock.Properties.Resources.symbol_percent_16;
            this.TabIconBackup = global::CDS.Client.Desktop.Stock.Properties.Resources.symbol_percent_16;
            this.Text = "Discount";
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

        private DevExpress.XtraGrid.Columns.GridColumn colAmountType;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colInventory;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryDiscountCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyDiscountCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVolumeNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPriorityDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkshopDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colVolumeDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyDiscount;




    }
}
