namespace CDS.Client.Desktop.Core.Period
{
    partial class NewFinancialYearDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFinancialYearDialogue));
            this.btnCreateYear = new DevExpress.XtraEditors.SimpleButton();
            this.itmCreateYear = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtFinancialYear = new DevExpress.XtraEditors.SpinEdit();
            this.itmFinancialYear = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdPeriods = new DevExpress.XtraGrid.GridControl();
            this.BindingSourcePeriod = new System.Windows.Forms.BindingSource();
            this.grvPeriods = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialQuarter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmPeriods = new DevExpress.XtraLayout.LayoutControlItem();
            this.grpNewFinancialYear = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmMonth = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.itmCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreateYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinancialYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFinancialYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNewFinancialYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ddlMonth);
            this.LayoutControl.Controls.Add(this.grdPeriods);
            this.LayoutControl.Controls.Add(this.txtFinancialYear);
            this.LayoutControl.Controls.Add(this.btnCreateYear);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(788, 132, 250, 350);
            this.LayoutControl.Size = new System.Drawing.Size(497, 269);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.grpNewFinancialYear});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(497, 269);
            this.LayoutGroup.Text = "Root";
            // 
            // btnCreateYear
            // 
            this.btnCreateYear.Location = new System.Drawing.Point(384, 229);
            this.btnCreateYear.Name = "btnCreateYear";
            this.btnCreateYear.Size = new System.Drawing.Size(95, 22);
            this.btnCreateYear.StyleController = this.LayoutControl;
            this.btnCreateYear.TabIndex = 4;
            this.btnCreateYear.Text = "Create &Periods";
            this.btnCreateYear.Click += new System.EventHandler(this.btnCreateYear_Click);
            // 
            // itmCreateYear
            // 
            this.itmCreateYear.Control = this.btnCreateYear;
            this.itmCreateYear.CustomizationFormText = "Create Year";
            this.itmCreateYear.Location = new System.Drawing.Point(366, 192);
            this.itmCreateYear.Name = "itmCreateYear";
            this.itmCreateYear.Size = new System.Drawing.Size(99, 26);
            this.itmCreateYear.Text = "Create Year";
            this.itmCreateYear.TextSize = new System.Drawing.Size(0, 0);
            this.itmCreateYear.TextToControlDistance = 0;
            this.itmCreateYear.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 192);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(307, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtFinancialYear
            // 
            this.txtFinancialYear.EditValue = new decimal(new int[] {
            2012,
            0,
            0,
            0});
            this.txtFinancialYear.Location = new System.Drawing.Point(88, 37);
            this.txtFinancialYear.Name = "txtFinancialYear";
            this.txtFinancialYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFinancialYear.Properties.DisplayFormat.FormatString = "0000";
            this.txtFinancialYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFinancialYear.Properties.EditFormat.FormatString = "0000";
            this.txtFinancialYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtFinancialYear.Properties.IsFloatValue = false;
            this.txtFinancialYear.Properties.Mask.EditMask = "0000";
            this.txtFinancialYear.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtFinancialYear.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtFinancialYear.Size = new System.Drawing.Size(60, 20);
            this.txtFinancialYear.StyleController = this.LayoutControl;
            this.txtFinancialYear.TabIndex = 5;
            this.txtFinancialYear.EditValueChanged += new System.EventHandler(this.txtFinancialYear_EditValueChanged);
            // 
            // itmFinancialYear
            // 
            this.itmFinancialYear.Control = this.txtFinancialYear;
            this.itmFinancialYear.CustomizationFormText = "Financial Year";
            this.itmFinancialYear.Location = new System.Drawing.Point(0, 0);
            this.itmFinancialYear.Name = "itmFinancialYear";
            this.itmFinancialYear.Size = new System.Drawing.Size(134, 24);
            this.itmFinancialYear.Text = "Financial Year";
            this.itmFinancialYear.TextSize = new System.Drawing.Size(66, 13);
            // 
            // grdPeriods
            // 
            this.grdPeriods.DataSource = this.BindingSourcePeriod;
            this.grdPeriods.Location = new System.Drawing.Point(18, 61);
            this.grdPeriods.MainView = this.grvPeriods;
            this.grdPeriods.Name = "grdPeriods";
            this.grdPeriods.Size = new System.Drawing.Size(461, 164);
            this.grdPeriods.TabIndex = 6;
            this.grdPeriods.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPeriods});
            // 
            // BindingSourcePeriod
            // 
            this.BindingSourcePeriod.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Period);
            // 
            // grvPeriods
            // 
            this.grvPeriods.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colFinancialQuarter,
            this.colStartDate,
            this.colEndDate});
            this.grvPeriods.GridControl = this.grdPeriods;
            this.grvPeriods.Name = "grvPeriods";
            this.grvPeriods.OptionsBehavior.Editable = false;
            this.grvPeriods.OptionsBehavior.ReadOnly = true;
            this.grvPeriods.OptionsCustomization.AllowColumnMoving = false;
            this.grvPeriods.OptionsCustomization.AllowColumnResizing = false;
            this.grvPeriods.OptionsCustomization.AllowFilter = false;
            this.grvPeriods.OptionsCustomization.AllowGroup = false;
            this.grvPeriods.OptionsCustomization.AllowSort = false;
            this.grvPeriods.OptionsMenu.EnableColumnMenu = false;
            this.grvPeriods.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvPeriods.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.grvPeriods.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MaxWidth = 80;
            this.colCode.MinWidth = 80;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 80;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 185;
            // 
            // colFinancialQuarter
            // 
            this.colFinancialQuarter.Caption = "F Quarter";
            this.colFinancialQuarter.DisplayFormat.FormatString = "Q 00";
            this.colFinancialQuarter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colFinancialQuarter.FieldName = "FinancialQuarter";
            this.colFinancialQuarter.MaxWidth = 80;
            this.colFinancialQuarter.MinWidth = 80;
            this.colFinancialQuarter.Name = "colFinancialQuarter";
            this.colFinancialQuarter.Visible = true;
            this.colFinancialQuarter.VisibleIndex = 2;
            this.colFinancialQuarter.Width = 80;
            // 
            // colStartDate
            // 
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.MaxWidth = 80;
            this.colStartDate.MinWidth = 80;
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 3;
            this.colStartDate.Width = 80;
            // 
            // colEndDate
            // 
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.MaxWidth = 80;
            this.colEndDate.MinWidth = 80;
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 4;
            this.colEndDate.Width = 80;
            // 
            // itmPeriods
            // 
            this.itmPeriods.Control = this.grdPeriods;
            this.itmPeriods.CustomizationFormText = "Periods";
            this.itmPeriods.Location = new System.Drawing.Point(0, 24);
            this.itmPeriods.Name = "itmPeriods";
            this.itmPeriods.Size = new System.Drawing.Size(465, 168);
            this.itmPeriods.Text = "Periods";
            this.itmPeriods.TextSize = new System.Drawing.Size(0, 0);
            this.itmPeriods.TextToControlDistance = 0;
            this.itmPeriods.TextVisible = false;
            // 
            // grpNewFinancialYear
            // 
            this.grpNewFinancialYear.CustomizationFormText = "New Financial Year";
            this.grpNewFinancialYear.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmFinancialYear,
            this.itmPeriods,
            this.emptySpaceItem2,
            this.itmMonth,
            this.emptySpaceItem1,
            this.itmCancel,
            this.itmCreateYear});
            this.grpNewFinancialYear.Location = new System.Drawing.Point(0, 0);
            this.grpNewFinancialYear.Name = "grpNewFinancialYear";
            this.grpNewFinancialYear.Size = new System.Drawing.Size(489, 261);
            this.grpNewFinancialYear.Text = "New Financial Year";
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(344, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(121, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmMonth
            // 
            this.itmMonth.Control = this.ddlMonth;
            this.itmMonth.CustomizationFormText = "Final Month";
            this.itmMonth.Location = new System.Drawing.Point(134, 0);
            this.itmMonth.Name = "itmMonth";
            this.itmMonth.Size = new System.Drawing.Size(210, 24);
            this.itmMonth.Text = "Final Month";
            this.itmMonth.TextSize = new System.Drawing.Size(66, 13);
            // 
            // ddlMonth
            // 
            this.ddlMonth.EditValue = "February";
            this.ddlMonth.Location = new System.Drawing.Point(222, 37);
            this.ddlMonth.Name = "ddlMonth";
            this.ddlMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.ddlMonth.Size = new System.Drawing.Size(136, 20);
            this.ddlMonth.StyleController = this.LayoutControl;
            this.ddlMonth.TabIndex = 7;
            this.ddlMonth.EditValueChanged += new System.EventHandler(this.ddlMonth_EditValueChanged);
            // 
            // itmCancel
            // 
            this.itmCancel.Control = this.btnCancel;
            this.itmCancel.CustomizationFormText = "Cancel";
            this.itmCancel.Location = new System.Drawing.Point(307, 192);
            this.itmCancel.Name = "itmCancel";
            this.itmCancel.Size = new System.Drawing.Size(59, 26);
            this.itmCancel.Text = "Cancel";
            this.itmCancel.TextSize = new System.Drawing.Size(0, 0);
            this.itmCancel.TextToControlDistance = 0;
            this.itmCancel.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(325, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewFinancialYearDialogue
            // 
            this.AcceptButton = this.btnCreateYear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(507, 323);
            this.Name = "NewFinancialYearDialogue";
            this.TabHeading = "This action creates the total of 12 periods for a financial year. Note that this " +
    "does not relate to the calendar year, unless the organisation has a year end on " +
    "the last day of December.";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.Text = " New Financial Year";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreateYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinancialYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFinancialYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNewFinancialYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit ddlMonth;
        private DevExpress.XtraGrid.GridControl grdPeriods;
        private System.Windows.Forms.BindingSource BindingSourcePeriod;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPeriods;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraEditors.SpinEdit txtFinancialYear;
        private DevExpress.XtraLayout.LayoutControlGroup grpNewFinancialYear;
        private DevExpress.XtraLayout.LayoutControlItem itmFinancialYear;
        private DevExpress.XtraLayout.LayoutControlItem itmPeriods;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem itmCreateYear;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem itmMonth;
        private DevExpress.XtraEditors.SimpleButton btnCreateYear;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialQuarter;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem itmCancel;
    }
}
