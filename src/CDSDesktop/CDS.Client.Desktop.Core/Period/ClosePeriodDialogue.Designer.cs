namespace CDS.Client.Desktop.Core.Period
{
    partial class ClosePeriodDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosePeriodDialogue));
            this.txtPeriod = new DevExpress.XtraEditors.TextEdit();
            this.itmPeriod = new DevExpress.XtraLayout.LayoutControlItem();
            this.grpClosePeriod = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmClosePeriod = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClosePeriod = new DevExpress.XtraEditors.SimpleButton();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.itmChecks = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdChecks = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceChecks = new System.Windows.Forms.BindingSource(this.components);
            this.grvChecks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imgStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.icStatus = new DevExpress.Utils.ImageCollection(this.components);
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpClosePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClosePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.grdChecks);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.btnClosePeriod);
            this.LayoutControl.Controls.Add(this.txtPeriod);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(788, 57, 250, 350);
            this.LayoutControl.Size = new System.Drawing.Size(497, 267);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.grpClosePeriod});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(497, 267);
            this.LayoutGroup.Text = "Root";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(52, 37);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Properties.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(427, 20);
            this.txtPeriod.StyleController = this.LayoutControl;
            this.txtPeriod.TabIndex = 4;
            // 
            // itmPeriod
            // 
            this.itmPeriod.Control = this.txtPeriod;
            this.itmPeriod.CustomizationFormText = "Period";
            this.itmPeriod.Location = new System.Drawing.Point(0, 0);
            this.itmPeriod.Name = "itmPeriod";
            this.itmPeriod.Size = new System.Drawing.Size(465, 24);
            this.itmPeriod.Text = "Period";
            this.itmPeriod.TextSize = new System.Drawing.Size(30, 13);
            // 
            // grpClosePeriod
            // 
            this.grpClosePeriod.CustomizationFormText = "Close Period";
            this.grpClosePeriod.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmPeriod,
            this.itmClosePeriod,
            this.emptySpaceItem2,
            this.itmCancel,
            this.itmChecks});
            this.grpClosePeriod.Location = new System.Drawing.Point(0, 0);
            this.grpClosePeriod.Name = "grpClosePeriod";
            this.grpClosePeriod.Size = new System.Drawing.Size(489, 259);
            this.grpClosePeriod.Text = "Close Period";
            // 
            // itmClosePeriod
            // 
            this.itmClosePeriod.Control = this.btnClosePeriod;
            this.itmClosePeriod.CustomizationFormText = "Close Period";
            this.itmClosePeriod.Location = new System.Drawing.Point(376, 190);
            this.itmClosePeriod.Name = "itmClosePeriod";
            this.itmClosePeriod.Size = new System.Drawing.Size(89, 26);
            this.itmClosePeriod.Text = "Close Period";
            this.itmClosePeriod.TextSize = new System.Drawing.Size(0, 0);
            this.itmClosePeriod.TextToControlDistance = 0;
            this.itmClosePeriod.TextVisible = false;
            // 
            // btnClosePeriod
            // 
            this.btnClosePeriod.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClosePeriod.Location = new System.Drawing.Point(394, 227);
            this.btnClosePeriod.Name = "btnClosePeriod";
            this.btnClosePeriod.Size = new System.Drawing.Size(85, 22);
            this.btnClosePeriod.StyleController = this.LayoutControl;
            this.btnClosePeriod.TabIndex = 5;
            this.btnClosePeriod.Text = "Close &Period";
            this.btnClosePeriod.Click += new System.EventHandler(this.btnClosePeriod_Click);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 190);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(314, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmCancel
            // 
            this.itmCancel.Control = this.btnCancel;
            this.itmCancel.CustomizationFormText = "Cancel";
            this.itmCancel.Location = new System.Drawing.Point(314, 190);
            this.itmCancel.Name = "itmCancel";
            this.itmCancel.Size = new System.Drawing.Size(62, 26);
            this.itmCancel.Text = "Cancel";
            this.itmCancel.TextSize = new System.Drawing.Size(0, 0);
            this.itmCancel.TextToControlDistance = 0;
            this.itmCancel.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(332, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // itmChecks
            // 
            this.itmChecks.Control = this.grdChecks;
            this.itmChecks.CustomizationFormText = "Checks";
            this.itmChecks.Location = new System.Drawing.Point(0, 24);
            this.itmChecks.Name = "itmChecks";
            this.itmChecks.Size = new System.Drawing.Size(465, 166);
            this.itmChecks.Text = "Checks";
            this.itmChecks.TextSize = new System.Drawing.Size(0, 0);
            this.itmChecks.TextToControlDistance = 0;
            this.itmChecks.TextVisible = false;
            // 
            // grdChecks
            // 
            this.grdChecks.DataSource = this.BindingSourceChecks;
            this.grdChecks.Location = new System.Drawing.Point(18, 61);
            this.grdChecks.MainView = this.grvChecks;
            this.grdChecks.Name = "grdChecks";
            this.grdChecks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.imgStatus});
            this.grdChecks.Size = new System.Drawing.Size(461, 162);
            this.grdChecks.TabIndex = 7;
            this.grdChecks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChecks});
            // 
            // grvChecks
            // 
            this.grvChecks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIcon,
            this.colStatus});
            this.grvChecks.GridControl = this.grdChecks;
            this.grvChecks.Name = "grvChecks";
            this.grvChecks.OptionsBehavior.Editable = false;
            this.grvChecks.OptionsBehavior.ReadOnly = true;
            this.grvChecks.OptionsMenu.EnableColumnMenu = false;
            this.grvChecks.OptionsMenu.EnableFooterMenu = false;
            this.grvChecks.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvChecks.OptionsMenu.ShowAutoFilterRowItem = false;
            this.grvChecks.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.grvChecks.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grvChecks.OptionsView.ShowDetailButtons = false;
            this.grvChecks.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.grvChecks.OptionsView.ShowGroupPanel = false;
            // 
            // colIcon
            // 
            this.colIcon.Caption = " ";
            this.colIcon.ColumnEdit = this.imgStatus;
            this.colIcon.FieldName = "ImageId";
            this.colIcon.MaxWidth = 20;
            this.colIcon.Name = "colIcon";
            this.colIcon.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colIcon.Visible = true;
            this.colIcon.VisibleIndex = 0;
            this.colIcon.Width = 20;
            // 
            // imgStatus
            // 
            this.imgStatus.AutoHeight = false;
            this.imgStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imgStatus.Images = this.icStatus;
            this.imgStatus.Name = "imgStatus";
            // 
            // icStatus
            // 
            this.icStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icStatus.ImageStream")));
            this.icStatus.Images.SetKeyName(0, "check_16.png");
            this.icStatus.Images.SetKeyName(1, "delete_16.png");
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "CheckStatus";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 1;
            // 
            // ClosePeriodDialogue
            // 
            this.AcceptButton = this.btnClosePeriod;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnClosePeriod;
            this.ClientSize = new System.Drawing.Size(507, 321);
            this.Name = "ClosePeriodDialogue";
            this.TabHeading = resources.GetString("$this.TabHeading");
            this.TabIcon = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_preferences_32;
            this.Text = "Close Period";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpClosePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClosePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnClosePeriod;
        private DevExpress.XtraEditors.TextEdit txtPeriod;
        private DevExpress.XtraLayout.LayoutControlGroup grpClosePeriod;
        private DevExpress.XtraLayout.LayoutControlItem itmPeriod;
        private DevExpress.XtraLayout.LayoutControlItem itmClosePeriod;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem itmCancel;
        private DevExpress.XtraGrid.GridControl grdChecks;
        private System.Windows.Forms.BindingSource BindingSourceChecks;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChecks;
        private DevExpress.XtraGrid.Columns.GridColumn colIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraLayout.LayoutControlItem itmChecks;
        private DevExpress.Utils.ImageCollection icStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit imgStatus;
    }
}
