namespace CDS.Client.Desktop.Accounting.Tracking
{
    partial class ChangeTrackingNumberDialogue
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
            this.lcgPaymentInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmPeriod = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPeriod = new DevExpress.XtraEditors.TextEdit();
            this.BindingSourceLine = new System.Windows.Forms.BindingSource(this.components);
            this.itmReference = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReference = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmTrackingNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTrackingNumber = new DevExpress.XtraEditors.TextEdit();
            this.itmDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.deDate = new DevExpress.XtraEditors.DateEdit();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgNewTrackingNumber = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmNewTrackingNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlNewTrackingNumber = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInitiator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.XPInstantFeedbackSourceTracking = new DevExpress.Xpo.XPInstantFeedbackSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPaymentInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTrackingNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrackingNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgNewTrackingNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNewTrackingNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNewTrackingNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ddlNewTrackingNumber);
            this.LayoutControl.Controls.Add(this.deDate);
            this.LayoutControl.Controls.Add(this.txtTrackingNumber);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtReference);
            this.LayoutControl.Controls.Add(this.txtPeriod);
            this.LayoutControl.Controls.Add(this.btnAccept);
            this.LayoutControl.Controls.Add(this.btnCancel);
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
            this.LayoutControl.Size = new System.Drawing.Size(497, 217);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgPaymentInformation,
            this.lcgNewTrackingNumber,
            this.emptySpaceItem3,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.LayoutGroup.Size = new System.Drawing.Size(497, 217);
            // 
            // lcgPaymentInformation
            // 
            this.lcgPaymentInformation.CustomizationFormText = "Payment Information";
            this.lcgPaymentInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmPeriod,
            this.itmReference,
            this.itmDescription,
            this.itmTrackingNumber,
            this.itmDate});
            this.lcgPaymentInformation.Location = new System.Drawing.Point(0, 0);
            this.lcgPaymentInformation.Name = "lcgPaymentInformation";
            this.lcgPaymentInformation.Size = new System.Drawing.Size(489, 115);
            this.lcgPaymentInformation.Text = "Payment Information";
            // 
            // itmPeriod
            // 
            this.itmPeriod.Control = this.txtPeriod;
            this.itmPeriod.CustomizationFormText = "Period";
            this.itmPeriod.Location = new System.Drawing.Point(0, 0);
            this.itmPeriod.Name = "itmPeriod";
            this.itmPeriod.Size = new System.Drawing.Size(232, 24);
            this.itmPeriod.Text = "Period";
            this.itmPeriod.TextSize = new System.Drawing.Size(104, 13);
            // 
            // txtPeriod
            // 
            this.txtPeriod.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceLine, "PeriodCode", true));
            this.txtPeriod.Enabled = false;
            this.txtPeriod.Location = new System.Drawing.Point(126, 37);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Properties.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(120, 20);
            this.txtPeriod.StyleController = this.LayoutControl;
            this.txtPeriod.TabIndex = 6;
            // 
            // BindingSourceLine
            // 
            this.BindingSourceLine.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_Line);
            // 
            // itmReference
            // 
            this.itmReference.Control = this.txtReference;
            this.itmReference.CustomizationFormText = "Reference";
            this.itmReference.Location = new System.Drawing.Point(0, 24);
            this.itmReference.Name = "itmReference";
            this.itmReference.Size = new System.Drawing.Size(232, 24);
            this.itmReference.Text = "Reference";
            this.itmReference.TextSize = new System.Drawing.Size(104, 13);
            // 
            // txtReference
            // 
            this.txtReference.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceLine, "HeaderReference", true));
            this.txtReference.Enabled = false;
            this.txtReference.Location = new System.Drawing.Point(126, 61);
            this.txtReference.Name = "txtReference";
            this.txtReference.Properties.ReadOnly = true;
            this.txtReference.Size = new System.Drawing.Size(120, 20);
            this.txtReference.StyleController = this.LayoutControl;
            this.txtReference.TabIndex = 7;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 48);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(465, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(104, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceLine, "HeaderDescription", true));
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(126, 85);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(353, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 8;
            // 
            // itmTrackingNumber
            // 
            this.itmTrackingNumber.Control = this.txtTrackingNumber;
            this.itmTrackingNumber.CustomizationFormText = "Tracking Number";
            this.itmTrackingNumber.Location = new System.Drawing.Point(232, 24);
            this.itmTrackingNumber.Name = "itmTrackingNumber";
            this.itmTrackingNumber.Size = new System.Drawing.Size(233, 24);
            this.itmTrackingNumber.Text = "Tracking Number";
            this.itmTrackingNumber.TextSize = new System.Drawing.Size(104, 13);
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceLine, "TrackId", true));
            this.txtTrackingNumber.Enabled = false;
            this.txtTrackingNumber.Location = new System.Drawing.Point(358, 61);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Properties.ReadOnly = true;
            this.txtTrackingNumber.Size = new System.Drawing.Size(121, 20);
            this.txtTrackingNumber.StyleController = this.LayoutControl;
            this.txtTrackingNumber.TabIndex = 9;
            // 
            // itmDate
            // 
            this.itmDate.Control = this.deDate;
            this.itmDate.CustomizationFormText = "Date";
            this.itmDate.Location = new System.Drawing.Point(232, 0);
            this.itmDate.Name = "itmDate";
            this.itmDate.Size = new System.Drawing.Size(233, 24);
            this.itmDate.Text = "Date";
            this.itmDate.TextSize = new System.Drawing.Size(104, 13);
            // 
            // deDate
            // 
            this.deDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSourceLine, "HeaderDay", true));
            this.deDate.EditValue = null;
            this.deDate.Enabled = false;
            this.deDate.Location = new System.Drawing.Point(358, 37);
            this.deDate.Name = "deDate";
            this.deDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDate.Properties.ReadOnly = true;
            this.deDate.Size = new System.Drawing.Size(121, 20);
            this.deDate.StyleController = this.LayoutControl;
            this.deDate.TabIndex = 10;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(232, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(233, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgNewTrackingNumber
            // 
            this.lcgNewTrackingNumber.CustomizationFormText = "New Tracking Number";
            this.lcgNewTrackingNumber.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.itmNewTrackingNumber});
            this.lcgNewTrackingNumber.Location = new System.Drawing.Point(0, 115);
            this.lcgNewTrackingNumber.Name = "lcgNewTrackingNumber";
            this.lcgNewTrackingNumber.Size = new System.Drawing.Size(489, 67);
            this.lcgNewTrackingNumber.Text = "New Tracking Number";
            // 
            // itmNewTrackingNumber
            // 
            this.itmNewTrackingNumber.Control = this.ddlNewTrackingNumber;
            this.itmNewTrackingNumber.CustomizationFormText = "New Tracking Number";
            this.itmNewTrackingNumber.Location = new System.Drawing.Point(0, 0);
            this.itmNewTrackingNumber.Name = "itmNewTrackingNumber";
            this.itmNewTrackingNumber.Size = new System.Drawing.Size(232, 24);
            this.itmNewTrackingNumber.Text = "New Tracking Number";
            this.itmNewTrackingNumber.TextSize = new System.Drawing.Size(104, 13);
            // 
            // ddlNewTrackingNumber
            // 
            this.ddlNewTrackingNumber.EditValue = "";
            this.ddlNewTrackingNumber.Location = new System.Drawing.Point(126, 152);
            this.ddlNewTrackingNumber.Name = "ddlNewTrackingNumber";
            this.ddlNewTrackingNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlNewTrackingNumber.Properties.DisplayMember = "Id";
            this.ddlNewTrackingNumber.Properties.NullText = "Select Tracking Number ...";
            this.ddlNewTrackingNumber.Properties.ValueMember = "Id";
            this.ddlNewTrackingNumber.Properties.View = this.searchLookUpEdit1View;
            this.ddlNewTrackingNumber.Size = new System.Drawing.Size(120, 20);
            this.ddlNewTrackingNumber.StyleController = this.LayoutControl;
            this.ddlNewTrackingNumber.TabIndex = 12;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colInitiator});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "Tracking Number";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colInitiator
            // 
            this.colInitiator.FieldName = "Initiator";
            this.colInitiator.Name = "colInitiator";
            this.colInitiator.Visible = true;
            this.colInitiator.VisibleIndex = 1;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 182);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(329, 27);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(415, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(409, 182);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(80, 27);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(335, 188);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(76, 22);
            this.btnAccept.StyleController = this.LayoutControl;
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAccept;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(329, 182);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 27);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // XPInstantFeedbackSourceTracking
            // 
            this.XPInstantFeedbackSourceTracking.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.SYS_Tracking);
            // 
            // ChangeTrackingNumberDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 271);
            this.MaximumSize = new System.Drawing.Size(523, 310);
            this.Name = "ChangeTrackingNumberDialogue";
            this.TabHeading = "Link this transaction to an existing tracking number.";
            this.TabIcon = global::CDS.Client.Desktop.Accounting.Properties.Resources.view_next_32;
            this.Text = "Link Tracking Number";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPaymentInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTrackingNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrackingNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgNewTrackingNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNewTrackingNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNewTrackingNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup lcgPaymentInformation;
        private DevExpress.XtraLayout.LayoutControlGroup lcgNewTrackingNumber;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtReference;
        private DevExpress.XtraEditors.TextEdit txtPeriod;
        private DevExpress.XtraLayout.LayoutControlItem itmPeriod;
        private DevExpress.XtraLayout.LayoutControlItem itmReference;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraEditors.DateEdit deDate;
        private DevExpress.XtraEditors.TextEdit txtTrackingNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmTrackingNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmDate;
        private System.Windows.Forms.BindingSource BindingSourceLine;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlNewTrackingNumber;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colInitiator;
        private DevExpress.XtraLayout.LayoutControlItem itmNewTrackingNumber;
        private DevExpress.Xpo.XPInstantFeedbackSource XPInstantFeedbackSourceTracking;
    }
}
