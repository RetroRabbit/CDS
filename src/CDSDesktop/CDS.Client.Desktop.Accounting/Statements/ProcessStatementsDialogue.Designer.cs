namespace CDS.Client.Desktop.Accounting.Statement
{
    partial class ProcessStatementsDialogue
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessStatementsDialogue));
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdProgress = new DevExpress.XtraGrid.GridControl();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.grvProgress = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShouldPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cePrint = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colShouldEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ceEmail = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colHasPrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ceHasPrinted = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colHasMailed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ceHasMailed = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lciProgressGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ddlPrinter = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.XPInstantFeedbackSourcePrinter = new DevExpress.Xpo.XPInstantFeedbackSource();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlPeriod = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.XPInstantFeedbackSourcePeriod = new DevExpress.Xpo.XPInstantFeedbackSource();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pbcEmail = new DevExpress.XtraEditors.ProgressBarControl();
            this.pbcPrint = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblEmailProgress = new System.Windows.Forms.Label();
            this.lblEmailStatements = new System.Windows.Forms.Label();
            this.lblPrintProgress = new System.Windows.Forms.Label();
            this.lblPrintStatements = new System.Windows.Forms.Label();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPrintImage = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrintProgress = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmailProgress = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmailImage = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmPeriod = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmPrinter = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.itmOk = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.itmClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.ImageCollection = new DevExpress.Utils.ImageCollection();
            this.ValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.UpdateTimer = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHasPrinted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHasMailed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProgressGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPrinter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrintImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrintProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmailProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmailImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPrinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnClose);
            this.LayoutControl.Controls.Add(this.btnOk);
            this.LayoutControl.Controls.Add(this.layoutControl1);
            this.LayoutControl.Controls.Add(this.grdProgress);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(782, 166, 250, 350);
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
            this.LayoutControl.Size = new System.Drawing.Size(629, 315);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.lciProgressGrid,
            this.emptySpaceItem2,
            this.itmOk,
            this.itmClose});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(629, 315);
            this.LayoutGroup.Text = "Root";
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.OptionsColumn.AllowMove = false;
            this.colEmail.OptionsColumn.AllowSize = false;
            this.colEmail.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 7;
            this.colEmail.Width = 345;
            // 
            // grdProgress
            // 
            this.grdProgress.DataSource = this.BindingSource;
            this.grdProgress.Location = new System.Drawing.Point(6, 196);
            this.grdProgress.MainView = this.grvProgress;
            this.grdProgress.Name = "grdProgress";
            this.grdProgress.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ceEmail,
            this.cePrint,
            this.ceHasMailed,
            this.ceHasPrinted});
            this.grdProgress.Size = new System.Drawing.Size(617, 87);
            this.grdProgress.TabIndex = 4;
            this.grdProgress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProgress});
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.Types.Statement);
            // 
            // grvProgress
            // 
            this.grvProgress.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShouldPrint,
            this.colShouldEmail,
            this.colHasPrinted,
            this.colHasMailed,
            this.colCode,
            this.colName,
            this.colContact,
            this.colEmail});
            gridFormatRule1.Column = this.colEmail;
            gridFormatRule1.Name = "BlankEmail";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Expression = "Iif([ShouldEmail],Len([Email]) != 0 Or IsNull([Email]),false)";
            formatConditionRuleValue1.PredefinedName = "Red Fill, Red Text";
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule1.StopIfTrue = true;
            this.grvProgress.FormatRules.Add(gridFormatRule1);
            this.grvProgress.GridControl = this.grdProgress;
            this.grvProgress.Name = "grvProgress";
            this.grvProgress.OptionsBehavior.ReadOnly = true;
            this.grvProgress.OptionsMenu.ShowConditionalFormattingItem = true;
            this.grvProgress.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProgress.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvProgress.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvProgress.OptionsView.ShowGroupPanel = false;
            this.grvProgress.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.grvProgress_CustomDrawColumnHeader);
            // 
            // colShouldPrint
            // 
            this.colShouldPrint.Caption = " ";
            this.colShouldPrint.ColumnEdit = this.cePrint;
            this.colShouldPrint.FieldName = "ShouldPrint";
            this.colShouldPrint.MaxWidth = 20;
            this.colShouldPrint.Name = "colShouldPrint";
            this.colShouldPrint.OptionsColumn.AllowEdit = false;
            this.colShouldPrint.OptionsColumn.AllowMove = false;
            this.colShouldPrint.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colShouldPrint.Visible = true;
            this.colShouldPrint.VisibleIndex = 0;
            this.colShouldPrint.Width = 20;
            // 
            // cePrint
            // 
            this.cePrint.AutoHeight = false;
            this.cePrint.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.cePrint.Name = "cePrint";
            this.cePrint.PictureChecked = ((System.Drawing.Image)(resources.GetObject("cePrint.PictureChecked")));
            // 
            // colShouldEmail
            // 
            this.colShouldEmail.Caption = " ";
            this.colShouldEmail.ColumnEdit = this.ceEmail;
            this.colShouldEmail.FieldName = "ShouldEmail";
            this.colShouldEmail.MaxWidth = 20;
            this.colShouldEmail.Name = "colShouldEmail";
            this.colShouldEmail.OptionsColumn.AllowEdit = false;
            this.colShouldEmail.OptionsColumn.AllowMove = false;
            this.colShouldEmail.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colShouldEmail.Visible = true;
            this.colShouldEmail.VisibleIndex = 1;
            this.colShouldEmail.Width = 20;
            // 
            // ceEmail
            // 
            this.ceEmail.AutoHeight = false;
            this.ceEmail.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceEmail.Name = "ceEmail";
            this.ceEmail.PictureChecked = ((System.Drawing.Image)(resources.GetObject("ceEmail.PictureChecked")));
            // 
            // colHasPrinted
            // 
            this.colHasPrinted.Caption = " ";
            this.colHasPrinted.ColumnEdit = this.ceHasPrinted;
            this.colHasPrinted.FieldName = "HasPrinted";
            this.colHasPrinted.MaxWidth = 20;
            this.colHasPrinted.Name = "colHasPrinted";
            this.colHasPrinted.OptionsColumn.AllowEdit = false;
            this.colHasPrinted.OptionsColumn.AllowMove = false;
            this.colHasPrinted.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colHasPrinted.Visible = true;
            this.colHasPrinted.VisibleIndex = 2;
            this.colHasPrinted.Width = 20;
            // 
            // ceHasPrinted
            // 
            this.ceHasPrinted.AutoHeight = false;
            this.ceHasPrinted.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceHasPrinted.Name = "ceHasPrinted";
            this.ceHasPrinted.PictureChecked = ((System.Drawing.Image)(resources.GetObject("ceHasPrinted.PictureChecked")));
            this.ceHasPrinted.PictureGrayed = global::CDS.Client.Desktop.Accounting.Properties.Resources.transparent_16;
            this.ceHasPrinted.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("ceHasPrinted.PictureUnchecked")));
            // 
            // colHasMailed
            // 
            this.colHasMailed.Caption = " ";
            this.colHasMailed.ColumnEdit = this.ceHasMailed;
            this.colHasMailed.FieldName = "HasMailed";
            this.colHasMailed.MaxWidth = 20;
            this.colHasMailed.Name = "colHasMailed";
            this.colHasMailed.OptionsColumn.AllowEdit = false;
            this.colHasMailed.OptionsColumn.AllowMove = false;
            this.colHasMailed.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colHasMailed.Visible = true;
            this.colHasMailed.VisibleIndex = 3;
            this.colHasMailed.Width = 20;
            // 
            // ceHasMailed
            // 
            this.ceHasMailed.AutoHeight = false;
            this.ceHasMailed.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceHasMailed.Name = "ceHasMailed";
            this.ceHasMailed.PictureChecked = ((System.Drawing.Image)(resources.GetObject("ceHasMailed.PictureChecked")));
            this.ceHasMailed.PictureGrayed = global::CDS.Client.Desktop.Accounting.Properties.Resources.transparent_16;
            this.ceHasMailed.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("ceHasMailed.PictureUnchecked")));
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowMove = false;
            this.colCode.OptionsColumn.AllowSize = false;
            this.colCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 4;
            this.colCode.Width = 223;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 5;
            this.colName.Width = 441;
            // 
            // colContact
            // 
            this.colContact.FieldName = "Contact";
            this.colContact.Name = "colContact";
            this.colContact.OptionsColumn.AllowEdit = false;
            this.colContact.OptionsColumn.AllowMove = false;
            this.colContact.OptionsColumn.AllowSize = false;
            this.colContact.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colContact.Visible = true;
            this.colContact.VisibleIndex = 6;
            this.colContact.Width = 441;
            // 
            // lciProgressGrid
            // 
            this.lciProgressGrid.Control = this.grdProgress;
            this.lciProgressGrid.CustomizationFormText = "Progress Grid";
            this.lciProgressGrid.Location = new System.Drawing.Point(0, 190);
            this.lciProgressGrid.Name = "lciProgressGrid";
            this.lciProgressGrid.Size = new System.Drawing.Size(621, 91);
            this.lciProgressGrid.Text = "lciProgressGrid";
            this.lciProgressGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciProgressGrid.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ddlPrinter);
            this.layoutControl1.Controls.Add(this.ddlPeriod);
            this.layoutControl1.Controls.Add(this.pbcEmail);
            this.layoutControl1.Controls.Add(this.pbcPrint);
            this.layoutControl1.Controls.Add(this.lblEmailProgress);
            this.layoutControl1.Controls.Add(this.lblEmailStatements);
            this.layoutControl1.Controls.Add(this.lblPrintProgress);
            this.layoutControl1.Controls.Add(this.lblPrintStatements);
            this.layoutControl1.Controls.Add(this.pictureEdit2);
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Location = new System.Drawing.Point(6, 6);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(617, 186);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ddlPrinter
            // 
            this.ddlPrinter.Location = new System.Drawing.Point(310, 18);
            this.ddlPrinter.Name = "ddlPrinter";
            this.ddlPrinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlPrinter.Properties.DataSource = this.XPInstantFeedbackSourcePrinter;
            this.ddlPrinter.Properties.DisplayMember = "Name";
            this.ddlPrinter.Properties.NullText = "Select Printer ...";
            this.ddlPrinter.Properties.ValueMember = "Id";
            this.ddlPrinter.Properties.View = this.searchLookUpEdit2View;
            this.ddlPrinter.Size = new System.Drawing.Size(305, 20);
            this.ddlPrinter.StyleController = this.layoutControl1;
            this.ddlPrinter.TabIndex = 13;
            // 
            // XPInstantFeedbackSourcePrinter
            // 
            this.XPInstantFeedbackSourcePrinter.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.SYS_Printer);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 223;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "Location";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 917;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "PrinterModel";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 243;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "PrinterType";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 246;
            // 
            // ddlPeriod
            // 
            this.ddlPeriod.Location = new System.Drawing.Point(2, 18);
            this.ddlPeriod.Name = "ddlPeriod";
            this.ddlPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlPeriod.Properties.DataSource = this.XPInstantFeedbackSourcePeriod;
            this.ddlPeriod.Properties.DisplayMember = "Title";
            this.ddlPeriod.Properties.NullText = "Select Period ...";
            this.ddlPeriod.Properties.ValueMember = "Id";
            this.ddlPeriod.Properties.View = this.searchLookUpEdit1View;
            this.ddlPeriod.Size = new System.Drawing.Size(304, 20);
            this.ddlPeriod.StyleController = this.layoutControl1;
            this.ddlPeriod.TabIndex = 12;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.ValidationProvider.SetValidationRule(this.ddlPeriod, conditionValidationRule1);
            // 
            // XPInstantFeedbackSourcePeriod
            // 
            this.XPInstantFeedbackSourcePeriod.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.SYS_Period);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // pbcEmail
            // 
            this.pbcEmail.Location = new System.Drawing.Point(70, 158);
            this.pbcEmail.Name = "pbcEmail";
            this.pbcEmail.Size = new System.Drawing.Size(545, 16);
            this.pbcEmail.StyleController = this.layoutControl1;
            this.pbcEmail.TabIndex = 11;
            // 
            // pbcPrint
            // 
            this.pbcPrint.Location = new System.Drawing.Point(70, 90);
            this.pbcPrint.Name = "pbcPrint";
            this.pbcPrint.Size = new System.Drawing.Size(545, 16);
            this.pbcPrint.StyleController = this.layoutControl1;
            this.pbcPrint.TabIndex = 10;
            // 
            // lblEmailProgress
            // 
            this.lblEmailProgress.Location = new System.Drawing.Point(70, 134);
            this.lblEmailProgress.Name = "lblEmailProgress";
            this.lblEmailProgress.Size = new System.Drawing.Size(545, 20);
            this.lblEmailProgress.TabIndex = 9;
            this.lblEmailProgress.Text = "Now emailing 0 of 0";
            // 
            // lblEmailStatements
            // 
            this.lblEmailStatements.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblEmailStatements.Location = new System.Drawing.Point(70, 110);
            this.lblEmailStatements.Name = "lblEmailStatements";
            this.lblEmailStatements.Size = new System.Drawing.Size(545, 20);
            this.lblEmailStatements.TabIndex = 8;
            this.lblEmailStatements.Text = "Email Statements";
            // 
            // lblPrintProgress
            // 
            this.lblPrintProgress.Location = new System.Drawing.Point(70, 66);
            this.lblPrintProgress.Name = "lblPrintProgress";
            this.lblPrintProgress.Size = new System.Drawing.Size(545, 20);
            this.lblPrintProgress.TabIndex = 7;
            this.lblPrintProgress.Text = "Now printing 0 of 0";
            // 
            // lblPrintStatements
            // 
            this.lblPrintStatements.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrintStatements.Location = new System.Drawing.Point(70, 42);
            this.lblPrintStatements.Name = "lblPrintStatements";
            this.lblPrintStatements.Size = new System.Drawing.Size(545, 20);
            this.lblPrintStatements.TabIndex = 6;
            this.lblPrintStatements.Text = "Print Statements";
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(2, 110);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Size = new System.Drawing.Size(64, 64);
            this.pictureEdit2.StyleController = this.layoutControl1;
            this.pictureEdit2.TabIndex = 5;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(2, 42);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(64, 64);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPrintImage,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.lciPrintProgress,
            this.lciEmailProgress,
            this.lciEmailImage,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.itmPeriod,
            this.itmPrinter});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(617, 186);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // lciPrintImage
            // 
            this.lciPrintImage.Control = this.pictureEdit1;
            this.lciPrintImage.CustomizationFormText = "Print Image";
            this.lciPrintImage.Location = new System.Drawing.Point(0, 40);
            this.lciPrintImage.MaxSize = new System.Drawing.Size(68, 68);
            this.lciPrintImage.MinSize = new System.Drawing.Size(68, 68);
            this.lciPrintImage.Name = "lciPrintImage";
            this.lciPrintImage.Size = new System.Drawing.Size(68, 68);
            this.lciPrintImage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciPrintImage.Text = "Print Image";
            this.lciPrintImage.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrintImage.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lblPrintStatements;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(68, 40);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(549, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lblPrintProgress;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(68, 64);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(549, 24);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lblEmailProgress;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(68, 132);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(549, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // lciPrintProgress
            // 
            this.lciPrintProgress.Control = this.pbcPrint;
            this.lciPrintProgress.CustomizationFormText = "layoutControlItem9";
            this.lciPrintProgress.Location = new System.Drawing.Point(68, 88);
            this.lciPrintProgress.Name = "lciPrintProgress";
            this.lciPrintProgress.Size = new System.Drawing.Size(549, 20);
            this.lciPrintProgress.Text = "lciPrintProgress";
            this.lciPrintProgress.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrintProgress.TextVisible = false;
            // 
            // lciEmailProgress
            // 
            this.lciEmailProgress.Control = this.pbcEmail;
            this.lciEmailProgress.CustomizationFormText = "layoutControlItem10";
            this.lciEmailProgress.Location = new System.Drawing.Point(68, 156);
            this.lciEmailProgress.MaxSize = new System.Drawing.Size(0, 20);
            this.lciEmailProgress.MinSize = new System.Drawing.Size(54, 20);
            this.lciEmailProgress.Name = "lciEmailProgress";
            this.lciEmailProgress.Size = new System.Drawing.Size(549, 20);
            this.lciEmailProgress.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciEmailProgress.Text = "lciEmailProgress";
            this.lciEmailProgress.TextSize = new System.Drawing.Size(0, 0);
            this.lciEmailProgress.TextVisible = false;
            // 
            // lciEmailImage
            // 
            this.lciEmailImage.Control = this.pictureEdit2;
            this.lciEmailImage.CustomizationFormText = "Email Image";
            this.lciEmailImage.Location = new System.Drawing.Point(0, 108);
            this.lciEmailImage.MaxSize = new System.Drawing.Size(68, 68);
            this.lciEmailImage.MinSize = new System.Drawing.Size(68, 68);
            this.lciEmailImage.Name = "lciEmailImage";
            this.lciEmailImage.Size = new System.Drawing.Size(68, 68);
            this.lciEmailImage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciEmailImage.Text = "Email Image";
            this.lciEmailImage.TextSize = new System.Drawing.Size(0, 0);
            this.lciEmailImage.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lblEmailStatements;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(68, 108);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(549, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 176);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(617, 10);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmPeriod
            // 
            this.itmPeriod.Control = this.ddlPeriod;
            this.itmPeriod.CustomizationFormText = "Period";
            this.itmPeriod.Location = new System.Drawing.Point(0, 0);
            this.itmPeriod.Name = "itmPeriod";
            this.itmPeriod.Size = new System.Drawing.Size(308, 40);
            this.itmPeriod.Text = "Period";
            this.itmPeriod.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmPeriod.TextSize = new System.Drawing.Size(32, 13);
            // 
            // itmPrinter
            // 
            this.itmPrinter.Control = this.ddlPrinter;
            this.itmPrinter.CustomizationFormText = "Printer";
            this.itmPrinter.Location = new System.Drawing.Point(308, 0);
            this.itmPrinter.Name = "itmPrinter";
            this.itmPrinter.Size = new System.Drawing.Size(309, 40);
            this.itmPrinter.Text = "Printer";
            this.itmPrinter.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmPrinter.TextSize = new System.Drawing.Size(32, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.layoutControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(621, 190);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 281);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(460, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(466, 287);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 22);
            this.btnOk.StyleController = this.LayoutControl;
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // itmOk
            // 
            this.itmOk.Control = this.btnOk;
            this.itmOk.CustomizationFormText = "Ok";
            this.itmOk.Location = new System.Drawing.Point(460, 281);
            this.itmOk.Name = "itmOk";
            this.itmOk.Size = new System.Drawing.Size(81, 26);
            this.itmOk.Text = "Ok";
            this.itmOk.TextSize = new System.Drawing.Size(0, 0);
            this.itmOk.TextVisible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(547, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 22);
            this.btnClose.StyleController = this.LayoutControl;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // itmClose
            // 
            this.itmClose.Control = this.btnClose;
            this.itmClose.CustomizationFormText = "Close";
            this.itmClose.Location = new System.Drawing.Point(541, 281);
            this.itmClose.Name = "itmClose";
            this.itmClose.Size = new System.Drawing.Size(80, 26);
            this.itmClose.Text = "Close";
            this.itmClose.TextSize = new System.Drawing.Size(0, 0);
            this.itmClose.TextVisible = false;
            // 
            // ImageCollection
            // 
            this.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection.ImageStream")));
            this.ImageCollection.InsertGalleryImage("print_16x16.png", "office2013/print/print_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/print/print_16x16.png"), 0);
            this.ImageCollection.Images.SetKeyName(0, "print_16x16.png");
            this.ImageCollection.InsertGalleryImage("mail_16x16.png", "office2013/mail/mail_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/mail/mail_16x16.png"), 1);
            this.ImageCollection.Images.SetKeyName(1, "mail_16x16.png");
            this.ImageCollection.InsertGalleryImage("close_16x16.png", "office2013/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/close_16x16.png"), 2);
            this.ImageCollection.Images.SetKeyName(2, "close_16x16.png");
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 2000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // ProcessStatementsDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(639, 369);
            this.Name = "ProcessStatementsDialogue";
            this.TabHeading = "This dialogue is used to process statements. Below shows the status of statements" +
    " being processed.";
            this.Text = "Statement Processing";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHasPrinted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHasMailed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProgressGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlPrinter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrintImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrintProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmailProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmailImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPrinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdProgress;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProgress;
        private DevExpress.XtraLayout.LayoutControlItem lciProgressGrid;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ProgressBarControl pbcEmail;
        private DevExpress.XtraEditors.ProgressBarControl pbcPrint;
        private System.Windows.Forms.Label lblEmailProgress;
        private System.Windows.Forms.Label lblEmailStatements;
        private System.Windows.Forms.Label lblPrintProgress;
        private System.Windows.Forms.Label lblPrintStatements;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lciPrintImage;
        private DevExpress.XtraLayout.LayoutControlItem lciEmailImage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem lciPrintProgress;
        private DevExpress.XtraLayout.LayoutControlItem lciEmailProgress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem itmOk;
        private DevExpress.XtraLayout.LayoutControlItem itmClose;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colShouldPrint;
        private DevExpress.XtraGrid.Columns.GridColumn colShouldEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colContact;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.Utils.ImageCollection ImageCollection;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlPrinter;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourcePrinter;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlPeriod;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourcePeriod;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem itmPeriod;
        private DevExpress.XtraLayout.LayoutControlItem itmPrinter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit cePrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ceEmail;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ValidationProvider;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ceHasMailed;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ceHasPrinted;
        private DevExpress.XtraGrid.Columns.GridColumn colHasPrinted;
        private DevExpress.XtraGrid.Columns.GridColumn colHasMailed;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}
