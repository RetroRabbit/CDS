namespace CDS.Client.Desktop.Core.Printer
{
    partial class PrinterForm
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
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmGeneralInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmDisplayName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDisplayName = new DevExpress.XtraEditors.TextEdit();
            this.itmNetworkLocation = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlNetworkLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.itmModel = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlModel = new DevExpress.XtraEditors.LookUpEdit();
            this.itmType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlType = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGeneralInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDisplayName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNetworkLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNetworkLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Printer);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtDisplayName);
            this.LayoutControl.Controls.Add(this.ddlModel);
            this.LayoutControl.Controls.Add(this.ddlType);
            this.LayoutControl.Controls.Add(this.ddlNetworkLocation);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.Size = new System.Drawing.Size(754, 384);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmGeneralInformation});
            this.LayoutGroup.Size = new System.Drawing.Size(754, 384);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Size = new System.Drawing.Size(754, 140);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(710, 225);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmGeneralInformation
            // 
            this.itmGeneralInformation.CustomizationFormText = "General Information";
            this.itmGeneralInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.itmDisplayName,
            this.itmNetworkLocation,
            this.itmModel,
            this.itmType});
            this.itmGeneralInformation.Location = new System.Drawing.Point(0, 0);
            this.itmGeneralInformation.Name = "itmGeneralInformation";
            this.itmGeneralInformation.Size = new System.Drawing.Size(734, 364);
            this.itmGeneralInformation.Text = "General Information";
            // 
            // itmDisplayName
            // 
            this.itmDisplayName.Control = this.txtDisplayName;
            this.itmDisplayName.CustomizationFormText = "Display Name";
            this.itmDisplayName.Location = new System.Drawing.Point(0, 0);
            this.itmDisplayName.Name = "itmDisplayName";
            this.itmDisplayName.Size = new System.Drawing.Size(710, 24);
            this.itmDisplayName.Text = "Display Name";
            this.itmDisplayName.TextSize = new System.Drawing.Size(79, 13);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Name", true));
            this.txtDisplayName.Location = new System.Drawing.Point(107, 43);
            this.txtDisplayName.MenuManager = this.RibbonControl;
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(623, 20);
            this.txtDisplayName.StyleController = this.LayoutControl;
            this.txtDisplayName.TabIndex = 4;
            // 
            // itmNetworkLocation
            // 
            this.itmNetworkLocation.Control = this.ddlNetworkLocation;
            this.itmNetworkLocation.CustomizationFormText = "Nework Location";
            this.itmNetworkLocation.Location = new System.Drawing.Point(0, 24);
            this.itmNetworkLocation.Name = "itmNetworkLocation";
            this.itmNetworkLocation.Size = new System.Drawing.Size(710, 24);
            this.itmNetworkLocation.Text = "Nework Location";
            this.itmNetworkLocation.TextSize = new System.Drawing.Size(79, 13);
            // 
            // ddlNetworkLocation
            // 
            this.ddlNetworkLocation.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Location", true));
            this.ddlNetworkLocation.Location = new System.Drawing.Point(107, 67);
            this.ddlNetworkLocation.MenuManager = this.RibbonControl;
            this.ddlNetworkLocation.Name = "ddlNetworkLocation";
            this.ddlNetworkLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlNetworkLocation.Properties.NullText = "";
            this.ddlNetworkLocation.Size = new System.Drawing.Size(623, 20);
            this.ddlNetworkLocation.StyleController = this.LayoutControl;
            this.ddlNetworkLocation.TabIndex = 5;
            // 
            // itmModel
            // 
            this.itmModel.Control = this.ddlModel;
            this.itmModel.CustomizationFormText = "Model";
            this.itmModel.Location = new System.Drawing.Point(0, 48);
            this.itmModel.Name = "itmModel";
            this.itmModel.Size = new System.Drawing.Size(710, 24);
            this.itmModel.Text = "Model";
            this.itmModel.TextSize = new System.Drawing.Size(79, 13);
            // 
            // ddlModel
            // 
            this.ddlModel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PrinterModel", true));
            this.ddlModel.Location = new System.Drawing.Point(107, 91);
            this.ddlModel.MenuManager = this.RibbonControl;
            this.ddlModel.Name = "ddlModel";
            this.ddlModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlModel.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Model")});
            this.ddlModel.Properties.DataSource = this.BindingSource;
            this.ddlModel.Properties.DisplayMember = "Key";
            this.ddlModel.Properties.ImmediatePopup = true;
            this.ddlModel.Properties.NullText = "";
            this.ddlModel.Properties.PopupSizeable = false;
            this.ddlModel.Properties.ValueMember = "Value";
            this.ddlModel.Size = new System.Drawing.Size(623, 20);
            this.ddlModel.StyleController = this.LayoutControl;
            this.ddlModel.TabIndex = 6;
            this.ddlModel.Enter += new System.EventHandler(this.ddlModel_Enter);
            // 
            // itmType
            // 
            this.itmType.Control = this.ddlType;
            this.itmType.CustomizationFormText = "Type";
            this.itmType.Location = new System.Drawing.Point(0, 72);
            this.itmType.Name = "itmType";
            this.itmType.Size = new System.Drawing.Size(710, 24);
            this.itmType.Text = "Type";
            this.itmType.TextSize = new System.Drawing.Size(79, 13);
            // 
            // ddlType
            // 
            this.ddlType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PrinterType", true));
            this.ddlType.Location = new System.Drawing.Point(107, 115);
            this.ddlType.MenuManager = this.RibbonControl;
            this.ddlType.Name = "ddlType";
            this.ddlType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Type")});
            this.ddlType.Properties.DisplayMember = "Key";
            this.ddlType.Properties.ImmediatePopup = true;
            this.ddlType.Properties.NullText = "";
            this.ddlType.Properties.PopupSizeable = false;
            this.ddlType.Properties.ValueMember = "Value";
            this.ddlType.Size = new System.Drawing.Size(623, 20);
            this.ddlType.StyleController = this.LayoutControl;
            this.ddlType.TabIndex = 7;
            this.ddlType.Enter += new System.EventHandler(this.ddlType_Enter);
            // 
            // PrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(766, 536);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Name", true));
            this.Name = "PrinterForm";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmGeneralInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDisplayName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNetworkLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNetworkLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDisplayName;
        private DevExpress.XtraLayout.LayoutControlGroup itmGeneralInformation;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem itmDisplayName;
        private DevExpress.XtraLayout.LayoutControlItem itmNetworkLocation;
        private DevExpress.XtraLayout.LayoutControlItem itmModel;
        private DevExpress.XtraLayout.LayoutControlItem itmType;
        private DevExpress.XtraEditors.LookUpEdit ddlModel;
        private DevExpress.XtraEditors.LookUpEdit ddlType;
        private DevExpress.XtraEditors.LookUpEdit ddlNetworkLocation;
    }
}
