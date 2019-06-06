namespace CDS.Client.Desktop.Main
{
    partial class RecoveryDialogue
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
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.grdRecoveryItems = new DevExpress.XtraGrid.GridControl();
            this.grvRecoveryItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecover = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmRecoveryItems = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecoveryItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecoveryItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRecoveryItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnOk);
            this.LayoutControl.Controls.Add(this.grdRecoveryItems);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2746, 44, 250, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(497, 193);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmRecoveryItems,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(497, 193);
            this.LayoutGroup.Text = "Root";
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.Desktop.Main.RecoveryDialogue.RecoveryItem);
            // 
            // grdRecoveryItems
            // 
            this.grdRecoveryItems.DataSource = this.BindingSource;
            this.grdRecoveryItems.Location = new System.Drawing.Point(6, 6);
            this.grdRecoveryItems.MainView = this.grvRecoveryItems;
            this.grdRecoveryItems.Name = "grdRecoveryItems";
            this.grdRecoveryItems.Size = new System.Drawing.Size(485, 155);
            this.grdRecoveryItems.TabIndex = 4;
            this.grdRecoveryItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRecoveryItems});
            // 
            // grvRecoveryItems
            // 
            this.grvRecoveryItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRecover,
            this.colDescription});
            this.grvRecoveryItems.GridControl = this.grdRecoveryItems;
            this.grvRecoveryItems.Name = "grvRecoveryItems";
            this.grvRecoveryItems.OptionsDetail.EnableMasterViewMode = false;
            this.grvRecoveryItems.OptionsView.ShowGroupPanel = false;
            this.grvRecoveryItems.OptionsView.ShowIndicator = false;
            // 
            // colRecover
            // 
            this.colRecover.FieldName = "Recover";
            this.colRecover.Name = "colRecover";
            this.colRecover.Visible = true;
            this.colRecover.VisibleIndex = 0;
            this.colRecover.Width = 70;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 386;
            // 
            // itmRecoveryItems
            // 
            this.itmRecoveryItems.Control = this.grdRecoveryItems;
            this.itmRecoveryItems.CustomizationFormText = "Recovery Items";
            this.itmRecoveryItems.Location = new System.Drawing.Point(0, 0);
            this.itmRecoveryItems.Name = "itmRecoveryItems";
            this.itmRecoveryItems.Size = new System.Drawing.Size(489, 159);
            this.itmRecoveryItems.Text = "Recovery Items";
            this.itmRecoveryItems.TextSize = new System.Drawing.Size(0, 0);
            this.itmRecoveryItems.TextVisible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(406, 165);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 22);
            this.btnOk.StyleController = this.LayoutControl;
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOk;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(400, 159);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 159);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(400, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // RecoveryDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 247);
            this.ControlBox = false;
            this.Name = "RecoveryDialogue";
            this.TabHeading = "Check the items below that you would like to recover";
            this.Text = " Recovery";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecoveryItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecoveryItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRecoveryItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraGrid.GridControl grdRecoveryItems;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRecoveryItems;
        private DevExpress.XtraGrid.Columns.GridColumn colRecover;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmRecoveryItems;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
