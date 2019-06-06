namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    partial class BulkReceiptsForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContraAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceSettlementAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriodAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSettlementAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEntries
            // 
            gridLevelNode1.LevelTemplate = this.grvItems;
            gridLevelNode1.RelationName = "BulkReceivableItems";
            this.grdEntries.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemLookUpEdit1.DataSource = this.ServerModeSourcePeriod;
            repositoryItemLookUpEdit1.DisplayMember = "Code";
            repositoryItemLookUpEdit1.Name = "repPeriod";
            repositoryItemLookUpEdit1.NullText = "Select period ...";
            repositoryItemLookUpEdit1.ValueMember = "Id";
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemLookUpEdit2.DataSource = this.ServerModeSourcePeriodAll;
            repositoryItemLookUpEdit2.DisplayMember = "Code";
            repositoryItemLookUpEdit2.Name = "repPeriodAll";
            repositoryItemLookUpEdit2.NullText = "Select period ...";
            repositoryItemLookUpEdit2.ValueMember = "Id";
            repositoryItemDateEdit1.AutoHeight = false;
            repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemDateEdit1.Name = "dtDate";
            repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            repositoryItemLookUpEdit3.AutoHeight = false;
            repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemLookUpEdit3.DataSource = this.ServerModeSourceAging;
            repositoryItemLookUpEdit3.DisplayMember = "Code";
            repositoryItemLookUpEdit3.Name = "ddlAging";
            repositoryItemLookUpEdit3.NullText = "Select aging ...";
            repositoryItemLookUpEdit3.ValueMember = "Id";
            repositoryItemGridLookUpEdit1.AutoHeight = false;
            repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemGridLookUpEdit1.DataSource = this.ServerModeSourceContraAccount;
            repositoryItemGridLookUpEdit1.DisplayMember = "Title";
            repositoryItemGridLookUpEdit1.Name = "ddlContraAccount";
            repositoryItemGridLookUpEdit1.NullText = "Select account ...";
            repositoryItemGridLookUpEdit1.ValueMember = "Id";
            this.grdEntries.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            repositoryItemLookUpEdit1,
            repositoryItemLookUpEdit2,
            repositoryItemDateEdit1,
            repositoryItemLookUpEdit3,
            repositoryItemGridLookUpEdit1});
            this.grdEntries.Size = new System.Drawing.Size(712, 241);
            // 
            // grvEntries
            // 
            this.grvEntries.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvEntries.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvEntries.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.grvEntries.OptionsCustomization.AllowFilter = false;
            this.grvEntries.OptionsCustomization.AllowGroup = false;
            this.grvEntries.OptionsView.ShowFooter = true;
            this.grvEntries.OptionsView.ShowGroupPanel = false;
            // 
            // itmEntries
            // 
            this.itmEntries.Size = new System.Drawing.Size(716, 245);
            // 
            // grvItems
            // 
            this.grvItems.OptionsView.ShowFooter = true;
            this.grvItems.OptionsView.ShowGroupPanel = false;
            // 
            // colBalance
            // 
            this.colBalance.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            // 
            // colSettlement
            // 
            this.colSettlement.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colSettlement.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            // 
            // ddlSettlementAccount
            // 
            this.ddlSettlementAccount.Size = new System.Drawing.Size(590, 20);
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.ValidationProvider.SetValidationRule(this.ddlSettlementAccount, conditionValidationRule1);
            // 
            // ddlAccount
            // 
            this.ddlAccount.Size = new System.Drawing.Size(590, 20);
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.ValidationProvider.SetValidationRule(this.ddlAccount, conditionValidationRule2);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Size = new System.Drawing.Size(736, 356);
            this.LayoutControl.Controls.SetChildIndex(this.ddlAccount, 0);
            this.LayoutControl.Controls.SetChildIndex(this.ddlSettlementAccount, 0);
            this.LayoutControl.Controls.SetChildIndex(this.grdEntries, 0);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Size = new System.Drawing.Size(736, 356);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Size = new System.Drawing.Size(736, 142);
            // 
            // BulkReceiptsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(748, 510);
            this.Name = "BulkReceiptsForm";
            this.TabIcon = global::CDS.Shared.Resources.Properties.Resources.money2_add_16;
            this.TabIconBackup = global::CDS.Shared.Resources.Properties.Resources.money2_add_16;
            this.Text = "Bulk Receipts";
            ((System.ComponentModel.ISupportInitialize)(repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceContraAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceSettlementAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriodAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSettlementAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
