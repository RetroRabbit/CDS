namespace CDS.Client.Desktop.Core.Abbreviation
{
    partial class AbbreviationForm
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
            this.lcgIdentity = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmAbbreviation = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAbbreviation = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAbbreviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbreviation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.SYS_Abbreviation);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtAbbreviation);
            this.LayoutControl.Location = new System.Drawing.Point(6, 146);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.Size = new System.Drawing.Size(996, 576);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgIdentity,
            this.lcgHistory});
            this.LayoutGroup.Size = new System.Drawing.Size(996, 576);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(952, 398);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgIdentity
            // 
            this.lcgIdentity.CustomizationFormText = "Identity";
            this.lcgIdentity.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.itmAbbreviation,
            this.itmDescription});
            this.lcgIdentity.Location = new System.Drawing.Point(0, 0);
            this.lcgIdentity.Name = "lcgIdentity";
            this.lcgIdentity.Size = new System.Drawing.Size(976, 489);
            this.lcgIdentity.Text = "Identity";
            // 
            // itmAbbreviation
            // 
            this.itmAbbreviation.Control = this.txtAbbreviation;
            this.itmAbbreviation.CustomizationFormText = "Abbreviation";
            this.itmAbbreviation.Location = new System.Drawing.Point(0, 0);
            this.itmAbbreviation.Name = "itmAbbreviation";
            this.itmAbbreviation.Size = new System.Drawing.Size(952, 24);
            this.itmAbbreviation.Text = "Abbreviation";
            this.itmAbbreviation.TextSize = new System.Drawing.Size(61, 13);
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Abbreviation", true));
            this.txtAbbreviation.Location = new System.Drawing.Point(89, 43);
            this.txtAbbreviation.MenuManager = this.RibbonControl;
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(883, 20);
            this.txtAbbreviation.StyleController = this.LayoutControl;
            this.txtAbbreviation.TabIndex = 4;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 24);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(952, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(61, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(89, 67);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(883, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 5;
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedBy,
            this.itmCreatedOn});
            this.lcgHistory.Location = new System.Drawing.Point(0, 489);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(976, 67);
            this.lcgHistory.Text = "History";
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(497, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(61, 13);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(89, 532);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(428, 20);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 6;
            // 
            // itmCreatedOn
            // 
            this.itmCreatedOn.Control = this.txtCreatedOn;
            this.itmCreatedOn.CustomizationFormText = "Created On";
            this.itmCreatedOn.Location = new System.Drawing.Point(497, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(455, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(61, 13);
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(586, 532);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Size = new System.Drawing.Size(386, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 7;
            // 
            // AbbreviationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Abbreviation", true));
            this.Name = "AbbreviationForm";
            this.SuperTipParameter = "abbreviation";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgIdentity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAbbreviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbreviation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgIdentity;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtAbbreviation;
        private DevExpress.XtraLayout.LayoutControlItem itmAbbreviation;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
    }
}
