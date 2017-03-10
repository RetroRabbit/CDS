namespace CDS.Client.Desktop.Document.LostSale
{
    partial class LostSaleDialogue
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
            this.ServerModeSourceCompany = new DevExpress.Data.Linq.LinqServerModeSource();
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.itmShortName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtReason = new DevExpress.XtraEditors.TextEdit();
            this.itmReason = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.itmQuantity = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.ddlCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.itmCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccountsTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ddlCompany);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.btnSave);
            this.LayoutControl.Controls.Add(this.txtQuantity);
            this.LayoutControl.Controls.Add(this.txtReason);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtShortName);
            this.LayoutControl.Size = new System.Drawing.Size(497, 156);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmShortName,
            this.itmDescription,
            this.itmReason,
            this.itmQuantity,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.itmCompany});
            this.LayoutGroup.Size = new System.Drawing.Size(497, 156);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.ORG_TRX_LostSale);
            // 
            // ServerModeSourceCompany
            // 
            this.ServerModeSourceCompany.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Company);
            this.ServerModeSourceCompany.KeyExpression = "Id";
            // 
            // txtShortName
            // 
            this.txtShortName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ShortName", true));
            this.txtShortName.Location = new System.Drawing.Point(63, 30);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(428, 20);
            this.txtShortName.StyleController = this.LayoutControl;
            this.txtShortName.TabIndex = 5;
            // 
            // itmShortName
            // 
            this.itmShortName.Control = this.txtShortName;
            this.itmShortName.CustomizationFormText = "Code";
            this.itmShortName.Location = new System.Drawing.Point(0, 24);
            this.itmShortName.Name = "itmShortName";
            this.itmShortName.Size = new System.Drawing.Size(489, 24);
            this.itmShortName.Text = "Code";
            this.itmShortName.TextSize = new System.Drawing.Size(53, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(63, 54);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(428, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 6;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 48);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(489, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(53, 13);
            // 
            // txtReason
            // 
            this.txtReason.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Reason", true));
            this.txtReason.Location = new System.Drawing.Point(63, 78);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(428, 20);
            this.txtReason.StyleController = this.LayoutControl;
            this.txtReason.TabIndex = 7;
            // 
            // itmReason
            // 
            this.itmReason.Control = this.txtReason;
            this.itmReason.CustomizationFormText = "Reason";
            this.itmReason.Location = new System.Drawing.Point(0, 72);
            this.itmReason.Name = "itmReason";
            this.itmReason.Size = new System.Drawing.Size(489, 24);
            this.itmReason.Text = "Reason";
            this.itmReason.TextSize = new System.Drawing.Size(53, 13);
            // 
            // txtQuantity
            // 
            this.txtQuantity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Quantity", true));
            this.txtQuantity.Location = new System.Drawing.Point(63, 102);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(428, 20);
            this.txtQuantity.StyleController = this.LayoutControl;
            this.txtQuantity.TabIndex = 8;
            // 
            // itmQuantity
            // 
            this.itmQuantity.Control = this.txtQuantity;
            this.itmQuantity.CustomizationFormText = "Quantity";
            this.itmQuantity.Location = new System.Drawing.Point(0, 96);
            this.itmQuantity.Name = "itmQuantity";
            this.itmQuantity.Size = new System.Drawing.Size(489, 24);
            this.itmQuantity.Text = "Quantity";
            this.itmQuantity.TextSize = new System.Drawing.Size(53, 13);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(240, 22);
            this.btnSave.StyleController = this.LayoutControl;
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSave;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(244, 28);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(241, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnCancel;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(244, 120);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(245, 28);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // ddlCompany
            // 
            this.ddlCompany.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CompanyId", true));
            this.ddlCompany.EditValue = "Select Company ...";
            this.ddlCompany.Location = new System.Drawing.Point(63, 6);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCompany.Properties.DataSource = this.ServerModeSourceCompany;
            this.ddlCompany.Properties.DisplayMember = "Title";
            this.ddlCompany.Properties.NullText = "Select Company ...";
            this.ddlCompany.Properties.ValueMember = "Id";
            this.ddlCompany.Properties.View = this.searchLookUpEdit1View;
            this.ddlCompany.Size = new System.Drawing.Size(428, 20);
            this.ddlCompany.StyleController = this.LayoutControl;
            this.ddlCompany.TabIndex = 11;
            // 
            // itmCompany
            // 
            this.itmCompany.Control = this.ddlCompany;
            this.itmCompany.CustomizationFormText = "Company";
            this.itmCompany.Location = new System.Drawing.Point(0, 0);
            this.itmCompany.Name = "itmCompany";
            this.itmCompany.Size = new System.Drawing.Size(489, 24);
            this.itmCompany.Text = "Company";
            this.itmCompany.TextSize = new System.Drawing.Size(53, 13);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colAccountsContact,
            this.colAccountsTelephone,
            this.colSalesContact,
            this.colSalesTelephone,
            this.colActive});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTitle, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 150;
            // 
            // colAccountsContact
            // 
            this.colAccountsContact.FieldName = "AccountsContact";
            this.colAccountsContact.Name = "colAccountsContact";
            this.colAccountsContact.Visible = true;
            this.colAccountsContact.VisibleIndex = 1;
            this.colAccountsContact.Width = 50;
            // 
            // colAccountsTelephone
            // 
            this.colAccountsTelephone.FieldName = "AccountsTelephone";
            this.colAccountsTelephone.Name = "colAccountsTelephone";
            this.colAccountsTelephone.Visible = true;
            this.colAccountsTelephone.VisibleIndex = 2;
            this.colAccountsTelephone.Width = 50;
            // 
            // colSalesContact
            // 
            this.colSalesContact.FieldName = "SalesContact";
            this.colSalesContact.Name = "colSalesContact";
            this.colSalesContact.Visible = true;
            this.colSalesContact.VisibleIndex = 3;
            this.colSalesContact.Width = 50;
            // 
            // colSalesTelephone
            // 
            this.colSalesTelephone.FieldName = "SalesTelephone";
            this.colSalesTelephone.Name = "colSalesTelephone";
            this.colSalesTelephone.Visible = true;
            this.colSalesTelephone.VisibleIndex = 4;
            this.colSalesTelephone.Width = 50;
            // 
            // colActive
            // 
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 5;
            this.colActive.Width = 23;
            // 
            // LostSaleDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 210);
            this.ControlBox = false;
            this.Name = "LostSaleDialogue";
            this.TabHeading = "Please fill in the details below to report a lost sale";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtShortName;
        private DevExpress.XtraLayout.LayoutControlItem itmShortName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.TextEdit txtReason;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmReason;
        private DevExpress.XtraLayout.LayoutControlItem itmQuantity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider ValidationProvider;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCompany;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsContact;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountsTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesContact;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraLayout.LayoutControlItem itmCompany;
    }
}
