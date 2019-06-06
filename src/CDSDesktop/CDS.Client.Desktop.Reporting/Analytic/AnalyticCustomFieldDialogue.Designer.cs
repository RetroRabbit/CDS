namespace CDS.Client.Desktop.Reporting.Analytic
{
    partial class AnalyticCustomFieldDialogue
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
            this.txtFieldExpression = new DevExpress.XtraEditors.ButtonEdit();
            this.itmFieldExpression = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtFieldName = new DevExpress.XtraEditors.TextEdit();
            this.itmFieldName = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.itmAccept = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.itmCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlCustomField = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldExpression.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFieldExpression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFieldName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.btnAccept);
            this.LayoutControl.Controls.Add(this.txtFieldName);
            this.LayoutControl.Controls.Add(this.txtFieldExpression);
            this.LayoutControl.Size = new System.Drawing.Size(382, 169);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmAccept,
            this.itmCancel,
            this.pnlCustomField,
            this.emptySpaceItem1});
            this.LayoutGroup.Size = new System.Drawing.Size(382, 169);
            // 
            // txtFieldExpression
            // 
            this.txtFieldExpression.Location = new System.Drawing.Point(99, 61);
            this.txtFieldExpression.Name = "txtFieldExpression";
            this.txtFieldExpression.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFieldExpression.Size = new System.Drawing.Size(265, 20);
            this.txtFieldExpression.StyleController = this.LayoutControl;
            this.txtFieldExpression.TabIndex = 4;
            this.txtFieldExpression.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFieldExpression_ButtonClick);
            // 
            // itmFieldExpression
            // 
            this.itmFieldExpression.Control = this.txtFieldExpression;
            this.itmFieldExpression.CustomizationFormText = "Field Expression";
            this.itmFieldExpression.Location = new System.Drawing.Point(0, 24);
            this.itmFieldExpression.Name = "itmFieldExpression";
            this.itmFieldExpression.Size = new System.Drawing.Size(350, 24);
            this.itmFieldExpression.Text = "Field Expression";
            this.itmFieldExpression.TextSize = new System.Drawing.Size(77, 13);
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(99, 37);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(265, 20);
            this.txtFieldName.StyleController = this.LayoutControl;
            this.txtFieldName.TabIndex = 5;
            this.txtFieldName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtFieldName_EditValueChanging);
            // 
            // itmFieldName
            // 
            this.itmFieldName.Control = this.txtFieldName;
            this.itmFieldName.CustomizationFormText = "Field Name";
            this.itmFieldName.Location = new System.Drawing.Point(0, 0);
            this.itmFieldName.Name = "itmFieldName";
            this.itmFieldName.Size = new System.Drawing.Size(350, 24);
            this.itmFieldName.Text = "Field Name";
            this.itmFieldName.TextSize = new System.Drawing.Size(77, 13);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(255, 141);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(58, 22);
            this.btnAccept.StyleController = this.LayoutControl;
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // itmAccept
            // 
            this.itmAccept.Control = this.btnAccept;
            this.itmAccept.CustomizationFormText = "Accept";
            this.itmAccept.Location = new System.Drawing.Point(249, 135);
            this.itmAccept.Name = "itmAccept";
            this.itmAccept.Size = new System.Drawing.Size(62, 26);
            this.itmAccept.Text = "Accept";
            this.itmAccept.TextSize = new System.Drawing.Size(0, 0);
            this.itmAccept.TextToControlDistance = 0;
            this.itmAccept.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(317, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // itmCancel
            // 
            this.itmCancel.Control = this.btnCancel;
            this.itmCancel.CustomizationFormText = "Cancel";
            this.itmCancel.Location = new System.Drawing.Point(311, 135);
            this.itmCancel.Name = "itmCancel";
            this.itmCancel.Size = new System.Drawing.Size(63, 26);
            this.itmCancel.Text = "Cancel";
            this.itmCancel.TextSize = new System.Drawing.Size(0, 0);
            this.itmCancel.TextToControlDistance = 0;
            this.itmCancel.TextVisible = false;
            // 
            // pnlCustomField
            // 
            this.pnlCustomField.CustomizationFormText = "Custom Field";
            this.pnlCustomField.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmFieldExpression,
            this.itmFieldName,
            this.emptySpaceItem2});
            this.pnlCustomField.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomField.Name = "pnlCustomField";
            this.pnlCustomField.Size = new System.Drawing.Size(374, 135);
            this.pnlCustomField.Text = "Custom Field";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(325, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(465, 69);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AnalyticCustomFieldDialogue
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(392, 223);
            this.Name = "AnalyticCustomFieldDialogue";
            this.TabHeading = "Add Custom Analytic Field";
            this.Text = "Add Custom Analytic Field";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldExpression.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFieldExpression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFieldName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCustomField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txtFieldExpression;
        private DevExpress.XtraLayout.LayoutControlItem itmFieldExpression;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.TextEdit txtFieldName;
        private DevExpress.XtraLayout.LayoutControlItem itmAccept;
        private DevExpress.XtraLayout.LayoutControlItem itmCancel;
        private DevExpress.XtraLayout.LayoutControlGroup pnlCustomField;
        private DevExpress.XtraLayout.LayoutControlItem itmFieldName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
