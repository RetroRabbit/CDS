namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    partial class ReportParameterDialogue
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
            this.grdParameters = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceParameters = new System.Windows.Forms.BindingSource(this.components);
            this.grvParameters = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlTypes = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.BindingSourceTypes = new System.Windows.Forms.BindingSource(this.components);
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riParameterDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.riParameterNumber = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.riParameterText = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.riParameterBoolean = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.itmGridParameters = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterBoolean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnAccept);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.grdParameters);
            this.LayoutControl.Size = new System.Drawing.Size(493, 190);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmGridParameters,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.LayoutGroup.Size = new System.Drawing.Size(493, 190);
            // 
            // grdParameters
            // 
            this.grdParameters.DataSource = this.BindingSourceParameters;
            this.grdParameters.Location = new System.Drawing.Point(6, 6);
            this.grdParameters.MainView = this.grvParameters;
            this.grdParameters.Name = "grdParameters";
            this.grdParameters.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ddlTypes,
            this.riParameterDate,
            this.riParameterNumber,
            this.riParameterText,
            this.riParameterBoolean});
            this.grdParameters.Size = new System.Drawing.Size(481, 152);
            this.grdParameters.TabIndex = 4;
            this.grdParameters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvParameters});
            // 
            // BindingSourceParameters
            // 
            this.BindingSourceParameters.DataSource = typeof(CDS.Client.Desktop.Reporting.Report.Wizard.ReportParameterDialogue.SQLParameter);
            // 
            // grvParameters
            // 
            this.grvParameters.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colType,
            this.colValue});
            this.grvParameters.GridControl = this.grdParameters;
            this.grvParameters.Name = "grvParameters";
            this.grvParameters.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvParameters.OptionsView.ShowGroupPanel = false;
            this.grvParameters.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvParameters_CustomRowCellEdit);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colType
            // 
            this.colType.ColumnEdit = this.ddlTypes;
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            // 
            // ddlTypes
            // 
            this.ddlTypes.AutoHeight = false;
            this.ddlTypes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlTypes.DataSource = this.BindingSourceTypes;
            this.ddlTypes.DisplayMember = "Name";
            this.ddlTypes.Name = "ddlTypes";
            this.ddlTypes.ValueMember = "SQLDataType";
            // 
            // BindingSourceTypes
            // 
            this.BindingSourceTypes.DataSource = typeof(CDS.Client.Desktop.Reporting.Report.Wizard.ReportParameterDialogue.SQLType);
            // 
            // colValue
            // 
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 2;
            // 
            // riParameterDate
            // 
            this.riParameterDate.AutoHeight = false;
            this.riParameterDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riParameterDate.Name = "riParameterDate";
            this.riParameterDate.NullText = "Enter value ...";
            this.riParameterDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // riParameterNumber
            // 
            this.riParameterNumber.AutoHeight = false;
            this.riParameterNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riParameterNumber.Name = "riParameterNumber";
            this.riParameterNumber.NullText = "Enter value ...";
            // 
            // riParameterText
            // 
            this.riParameterText.AutoHeight = false;
            this.riParameterText.Name = "riParameterText";
            this.riParameterText.NullText = "Enter value ...";
            // 
            // riParameterBoolean
            // 
            this.riParameterBoolean.AutoHeight = false;
            this.riParameterBoolean.Name = "riParameterBoolean";
            this.riParameterBoolean.NullText = "Enter value ...";
            // 
            // itmGridParameters
            // 
            this.itmGridParameters.Control = this.grdParameters;
            this.itmGridParameters.CustomizationFormText = "layoutControlItem1";
            this.itmGridParameters.Location = new System.Drawing.Point(0, 0);
            this.itmGridParameters.Name = "itmGridParameters";
            this.itmGridParameters.Size = new System.Drawing.Size(485, 156);
            this.itmGridParameters.Text = "itmGridParameters";
            this.itmGridParameters.TextSize = new System.Drawing.Size(0, 0);
            this.itmGridParameters.TextToControlDistance = 0;
            this.itmGridParameters.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 156);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(330, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(416, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(410, 156);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(75, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(336, 162);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(76, 22);
            this.btnAccept.StyleController = this.LayoutControl;
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAccept;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(330, 156);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // ReportParameterDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(503, 244);
            this.Name = "ReportParameterDialogue";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riParameterBoolean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdParameters;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParameters;
        private DevExpress.XtraLayout.LayoutControlItem itmGridParameters;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource BindingSourceParameters;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlTypes;
        private System.Windows.Forms.BindingSource BindingSourceTypes;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit riParameterDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit riParameterNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riParameterText;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riParameterBoolean;
    }
}
