namespace CDS.Client.Desktop.Company.Contact
{
    partial class ContactList
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
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GridControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.GridControl.Size = new System.Drawing.Size(979, 395);
            // 
            // GridView
            // 
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSurname,
            this.colFullname,
            this.colEmail,
            this.colFax,
            this.colTelephone1,
            this.colTitle});
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
            this.GridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTitle, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.LayoutControlGrid.Size = new System.Drawing.Size(983, 399);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(983, 399);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(983, 399); 
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.ORG_Contact);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RibbonControl.Size = new System.Drawing.Size(983, 155);
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
            this.colName.FieldName = "PersonId.Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colSurname
            // 
            this.colSurname.Caption = "Surname";
            this.colSurname.FieldName = "PersonId.Surname";
            this.colSurname.Name = "colSurname";
            this.colSurname.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSurname.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colSurname.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colSurname.Visible = true;
            this.colSurname.VisibleIndex = 1;
            // 
            // colFullname
            // 
            this.colFullname.Caption = "Fullname";
            this.colFullname.FieldName = "PersonId.Fullname";
            this.colFullname.Name = "colFullname";
            this.colFullname.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFullname.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colFullname.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colFullname.Visible = true;
            this.colFullname.VisibleIndex = 2;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmail.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colEmail.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            // 
            // colFax
            // 
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFax.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colFax.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 5;
            // 
            // colTelephone1
            // 
            this.colTelephone1.Caption = "Telephone";
            this.colTelephone1.FieldName = "Telephone1";
            this.colTelephone1.Name = "colTelephone1";
            this.colTelephone1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTelephone1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colTelephone1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTelephone1.Visible = true;
            this.colTelephone1.VisibleIndex = 3;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Title";
            this.colTitle.FieldName = "PersonId.Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTitle.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colTitle.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // ContactList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(983, 554);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "ContactList";
            this.Text = "Contact List";
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
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colFullname;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone1;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
    }
}
