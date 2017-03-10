namespace CDS.Client.Desktop.Document.Stock
{
    partial class ScanItemDialogue
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
            this.grdItem = new DevExpress.XtraGrid.GridControl();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.grvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lciItems = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.lciOk = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.lciBarcode = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtBarcode);
            this.LayoutControl.Controls.Add(this.btnOk);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.grdItem);
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
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciItems,
            this.emptySpaceItem1,
            this.lciCancel,
            this.lciOk,
            this.lciBarcode});
            // 
            // grdItem
            // 
            this.grdItem.DataSource = this.BindingSource;
            this.grdItem.Location = new System.Drawing.Point(6, 30);
            this.grdItem.MainView = this.grvItems;
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(485, 132);
            this.grdItem.TabIndex = 4;
            this.grdItem.TabStop = false;
            this.grdItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvItems});
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.Desktop.Document.Stock.ScanItemDialogue.BarcodeItem);
            // 
            // grvItems
            // 
            this.grvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBarcode,
            this.colQuantity});
            this.grvItems.GridControl = this.grdItem;
            this.grvItems.Name = "grvItems";
            this.grvItems.OptionsView.ShowGroupPanel = false;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.OptionsColumn.AllowEdit = false;
            this.colBarcode.OptionsColumn.AllowFocus = false;
            this.colBarcode.OptionsColumn.AllowMove = false;
            this.colBarcode.OptionsColumn.AllowSize = false;
            this.colBarcode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colBarcode.OptionsColumn.ReadOnly = true;
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 0;
            // 
            // colQuantity
            // 
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.OptionsColumn.AllowFocus = false;
            this.colQuantity.OptionsColumn.AllowMove = false;
            this.colQuantity.OptionsColumn.AllowSize = false;
            this.colQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colQuantity.OptionsColumn.ReadOnly = true;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 1;
            // 
            // lciItems
            // 
            this.lciItems.Control = this.grdItem;
            this.lciItems.CustomizationFormText = "Items";
            this.lciItems.Location = new System.Drawing.Point(0, 24);
            this.lciItems.Name = "lciItems";
            this.lciItems.Size = new System.Drawing.Size(489, 136);
            this.lciItems.Text = "lciItems";
            this.lciItems.TextSize = new System.Drawing.Size(0, 0);
            this.lciItems.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(329, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(415, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.btnCancel;
            this.lciCancel.CustomizationFormText = "Cancel";
            this.lciCancel.Location = new System.Drawing.Point(409, 160);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(80, 26);
            this.lciCancel.Text = "lciCancel";
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(335, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 22);
            this.btnOk.StyleController = this.LayoutControl;
            this.btnOk.TabIndex = 6;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "&Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lciOk
            // 
            this.lciOk.Control = this.btnOk;
            this.lciOk.CustomizationFormText = "lciOk";
            this.lciOk.Location = new System.Drawing.Point(329, 160);
            this.lciOk.Name = "lciOk";
            this.lciOk.Size = new System.Drawing.Size(80, 26);
            this.lciOk.Text = "lciOk";
            this.lciOk.TextSize = new System.Drawing.Size(0, 0);
            this.lciOk.TextVisible = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(49, 6);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(442, 20);
            this.txtBarcode.StyleController = this.LayoutControl;
            this.txtBarcode.TabIndex = 7;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // lciBarcode
            // 
            this.lciBarcode.Control = this.txtBarcode;
            this.lciBarcode.CustomizationFormText = "Barcode";
            this.lciBarcode.Location = new System.Drawing.Point(0, 0);
            this.lciBarcode.Name = "lciBarcode";
            this.lciBarcode.Size = new System.Drawing.Size(489, 24);
            this.lciBarcode.Text = "Barcode";
            this.lciBarcode.TextSize = new System.Drawing.Size(39, 13);
            // 
            // ScanItemsDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.Name = "ScanItemsDialogue";
            this.TabHeading = "Scan each barcode and click Ok button to add items to document.";
            this.Text = " Scan Barcode";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBarcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdItem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvItems;
        private DevExpress.XtraLayout.LayoutControlItem lciItems;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem lciOk;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraLayout.LayoutControlItem lciBarcode;
    }
}
