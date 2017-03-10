namespace CDS.Client.Desktop.Essential
{
    partial class AlternativeDialogue
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
            this.grdAlternative = new DevExpress.XtraGrid.GridControl();
            this.InstantFeedbackSourceAlternative = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.grvAlternative = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAlternativeItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnHand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmAlternative = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlternative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAlternative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAlternative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnOk);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.grdAlternative);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(788, 45, 250, 350);
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
            this.itmAlternative,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Text = "Root";
            // 
            // grdAlternative
            // 
            this.grdAlternative.DataSource = this.InstantFeedbackSourceAlternative;
            this.grdAlternative.Location = new System.Drawing.Point(6, 6);
            this.grdAlternative.MainView = this.grvAlternative;
            this.grdAlternative.Name = "grdAlternative";
            this.grdAlternative.Size = new System.Drawing.Size(485, 156);
            this.grdAlternative.TabIndex = 0;
            this.grdAlternative.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAlternative});
            // 
            // InstantFeedbackSourceAlternative
            // 
            this.InstantFeedbackSourceAlternative.DefaultSorting = null;
            this.InstantFeedbackSourceAlternative.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Alternative);
            this.InstantFeedbackSourceAlternative.KeyExpression = "Id";
            this.InstantFeedbackSourceAlternative.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceAlternative_GetQueryable);
            // 
            // grvAlternative
            // 
            this.grvAlternative.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAlternativeItemName,
            this.colShortName,
            this.colOnHand});
            this.grvAlternative.GridControl = this.grdAlternative;
            this.grvAlternative.Name = "grvAlternative";
            this.grvAlternative.OptionsView.ShowGroupPanel = false;
            this.grvAlternative.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAlternativeItemName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvAlternative.AsyncCompleted += new System.EventHandler(this.grvAlternative_AsyncCompleted);
            this.grvAlternative.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvAlternative_KeyDown);
            this.grvAlternative.DoubleClick += new System.EventHandler(this.grvAlternative_DoubleClick);
            // 
            // colAlternativeItemName
            // 
            this.colAlternativeItemName.FieldName = "AlternativeItemName";
            this.colAlternativeItemName.Name = "colAlternativeItemName";
            this.colAlternativeItemName.OptionsColumn.AllowEdit = false;
            this.colAlternativeItemName.OptionsColumn.AllowMove = false;
            this.colAlternativeItemName.Visible = true;
            this.colAlternativeItemName.VisibleIndex = 0;
            // 
            // colShortName
            // 
            this.colShortName.FieldName = "ShortName";
            this.colShortName.Name = "colShortName";
            this.colShortName.OptionsColumn.AllowEdit = false;
            this.colShortName.OptionsColumn.AllowMove = false;
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 1;
            // 
            // colOnHand
            // 
            this.colOnHand.FieldName = "OnHand";
            this.colOnHand.Name = "colOnHand";
            this.colOnHand.OptionsColumn.AllowEdit = false;
            this.colOnHand.OptionsColumn.AllowMove = false;
            this.colOnHand.Visible = true;
            this.colOnHand.VisibleIndex = 2;
            // 
            // itmAlternative
            // 
            this.itmAlternative.Control = this.grdAlternative;
            this.itmAlternative.CustomizationFormText = "Alternative";
            this.itmAlternative.Location = new System.Drawing.Point(0, 0);
            this.itmAlternative.Name = "itmAlternative";
            this.itmAlternative.Size = new System.Drawing.Size(489, 160);
            this.itmAlternative.Text = "Alternative";
            this.itmAlternative.TextSize = new System.Drawing.Size(0, 0);
            this.itmAlternative.TextVisible = false;
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(335, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(329, 160);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(415, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 22);
            this.btnOk.StyleController = this.LayoutControl;
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOk;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(409, 160);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // AlternativeDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.Name = "AlternativeDialogue";
            this.TabHeading = "Shows possible alternatives for the selected item";
            this.Text = " Alternatives";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlternative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAlternative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAlternative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAlternative;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAlternative;
        private DevExpress.XtraLayout.LayoutControlItem itmAlternative;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource InstantFeedbackSourceAlternative;
        private DevExpress.XtraGrid.Columns.GridColumn colAlternativeItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colOnHand;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
