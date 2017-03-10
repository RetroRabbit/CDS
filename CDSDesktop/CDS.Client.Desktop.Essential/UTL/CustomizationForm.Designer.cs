namespace CDS.Client.Desktop.Essential.UTL
{
    partial class CustomizationForm
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
            this.bpCustomButtons = new DevExpress.XtraLayout.Customization.Controls.ButtonsPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cbeUsers = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.BindingSourceUsers = new System.Windows.Forms.BindingSource();
            this.ddlUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.InstantFeedbackSourceUsers = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRestoreFactoryDefault = new DevExpress.XtraEditors.SimpleButton();
            this.CustomizationPropertyGrid = new DevExpress.XtraLayout.Customization.Controls.CustomizationPropertyGrid();
            this.hiddenItemsList1 = new DevExpress.XtraLayout.Customization.Controls.HiddenItemsList();
            this.layoutTreeView1 = new DevExpress.XtraLayout.Customization.Controls.LayoutTreeView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgHiddenItemList = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgItemTree = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmLayoutTree = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgPropertyGrid = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmPropertyGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.itmUsers = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenItemsList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHiddenItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgItemTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmLayoutTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPropertyGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPropertyGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // bpCustomButtons
            // 
            this.bpCustomButtons.Location = new System.Drawing.Point(2, 2);
            this.bpCustomButtons.Name = "bpCustomButtons";
            this.bpCustomButtons.Size = new System.Drawing.Size(100, 25);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbeUsers);
            this.layoutControl1.Controls.Add(this.ddlUser);
            this.layoutControl1.Controls.Add(this.btnRestoreFactoryDefault);
            this.layoutControl1.Controls.Add(this.CustomizationPropertyGrid);
            this.layoutControl1.Controls.Add(this.bpCustomButtons);
            this.layoutControl1.Controls.Add(this.hiddenItemsList1);
            this.layoutControl1.Controls.Add(this.layoutTreeView1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(639, 326);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cbeUsers
            // 
            this.cbeUsers.Location = new System.Drawing.Point(374, 2);
            this.cbeUsers.Name = "cbeUsers";
            this.cbeUsers.Properties.AllowMultiSelect = true;
            this.cbeUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeUsers.Properties.DataSource = this.BindingSourceUsers;
            this.cbeUsers.Properties.DisplayMember = "DisplayName";
            this.cbeUsers.Properties.NullText = "Select Users...";
            this.cbeUsers.Properties.ValueMember = "Id";
            this.cbeUsers.Size = new System.Drawing.Size(263, 20);
            this.cbeUsers.StyleController = this.layoutControl1;
            this.cbeUsers.TabIndex = 18;
            // 
            // BindingSourceUsers
            // 
            this.BindingSourceUsers.DataSource = typeof(CDS.Client.DataAccessLayer.DB.VW_User);
            // 
            // ddlUser
            // 
            this.ddlUser.Location = new System.Drawing.Point(106, 2);
            this.ddlUser.Name = "ddlUser";
            this.ddlUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlUser.Properties.DataSource = this.InstantFeedbackSourceUsers;
            this.ddlUser.Properties.DisplayMember = "DisplayName";
            this.ddlUser.Properties.NullText = "Select Role ...";
            this.ddlUser.Properties.ValueMember = "Id";
            this.ddlUser.Properties.View = this.searchLookUpEdit1View;
            this.ddlUser.Size = new System.Drawing.Size(264, 20);
            this.ddlUser.StyleController = this.layoutControl1;
            this.ddlUser.TabIndex = 13;
            // 
            // InstantFeedbackSourceUsers
            // 
            this.InstantFeedbackSourceUsers.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_User);
            this.InstantFeedbackSourceUsers.KeyExpression = "Id";
            this.InstantFeedbackSourceUsers.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceRole_GetQueryable);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colName,
            this.colSurname,
            this.colUsername,
            this.colDisplayName});
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
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colSurname
            // 
            this.colSurname.FieldName = "Surname";
            this.colSurname.Name = "colSurname";
            this.colSurname.Visible = true;
            this.colSurname.VisibleIndex = 2;
            // 
            // colUsername
            // 
            this.colUsername.FieldName = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 3;
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.Visible = true;
            this.colDisplayName.VisibleIndex = 4;
            // 
            // btnRestoreFactoryDefault
            // 
            this.btnRestoreFactoryDefault.Location = new System.Drawing.Point(2, 302);
            this.btnRestoreFactoryDefault.Name = "btnRestoreFactoryDefault";
            this.btnRestoreFactoryDefault.Size = new System.Drawing.Size(635, 22);
            this.btnRestoreFactoryDefault.StyleController = this.layoutControl1;
            this.btnRestoreFactoryDefault.TabIndex = 8;
            this.btnRestoreFactoryDefault.Text = "Restore Factory Default";
            this.btnRestoreFactoryDefault.Click += new System.EventHandler(this.btnRestoreFactoryDefault_Click);
            // 
            // CustomizationPropertyGrid
            // 
            this.CustomizationPropertyGrid.Location = new System.Drawing.Point(14, 66);
            this.CustomizationPropertyGrid.Name = "CustomizationPropertyGrid";
            this.CustomizationPropertyGrid.Size = new System.Drawing.Size(611, 220);
            this.CustomizationPropertyGrid.SelectedObjectsChanged += new System.EventHandler(this.CustomizationPropertyGrid_SelectedObjectsChanged);
            // 
            // hiddenItemsList1
            // 
            this.hiddenItemsList1.Location = new System.Drawing.Point(14, 66);
            this.hiddenItemsList1.Name = "hiddenItemsList1";
            this.hiddenItemsList1.Size = new System.Drawing.Size(611, 220);
            // 
            // layoutTreeView1
            // 
            this.layoutTreeView1.Location = new System.Drawing.Point(14, 66);
            this.layoutTreeView1.Name = "layoutTreeView1";
            this.layoutTreeView1.Role = DevExpress.XtraLayout.Customization.Controls.TreeViewRoles.LayoutTreeView;
            this.layoutTreeView1.ShowHiddenItemsInTreeView = true;
            this.layoutTreeView1.Size = new System.Drawing.Size(611, 220);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.tabbedControlGroup1,
            this.layoutControlItem3,
            this.itmUser,
            this.itmUsers});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(639, 326);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.bpCustomButtons;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 29);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 29);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcgHiddenItemList;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(639, 271);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgHiddenItemList,
            this.lcgItemTree,
            this.lcgPropertyGrid});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // lcgHiddenItemList
            // 
            this.lcgHiddenItemList.CustomizationFormText = "Hidden Item List";
            this.lcgHiddenItemList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.lcgHiddenItemList.Location = new System.Drawing.Point(0, 0);
            this.lcgHiddenItemList.Name = "lcgHiddenItemList";
            this.lcgHiddenItemList.Size = new System.Drawing.Size(615, 224);
            this.lcgHiddenItemList.Text = "Hidden Item List";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.hiddenItemsList1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(615, 224);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lcgItemTree
            // 
            this.lcgItemTree.CustomizationFormText = "Item Tree";
            this.lcgItemTree.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmLayoutTree});
            this.lcgItemTree.Location = new System.Drawing.Point(0, 0);
            this.lcgItemTree.Name = "lcgItemTree";
            this.lcgItemTree.Size = new System.Drawing.Size(615, 224);
            this.lcgItemTree.Text = "Item Tree";
            // 
            // itmLayoutTree
            // 
            this.itmLayoutTree.Control = this.layoutTreeView1;
            this.itmLayoutTree.CustomizationFormText = "Layout Tree";
            this.itmLayoutTree.Location = new System.Drawing.Point(0, 0);
            this.itmLayoutTree.Name = "itmLayoutTree";
            this.itmLayoutTree.Size = new System.Drawing.Size(615, 224);
            this.itmLayoutTree.Text = "Layout Tree";
            this.itmLayoutTree.TextSize = new System.Drawing.Size(0, 0);
            this.itmLayoutTree.TextVisible = false;
            // 
            // lcgPropertyGrid
            // 
            this.lcgPropertyGrid.CustomizationFormText = "Property Grid";
            this.lcgPropertyGrid.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmPropertyGrid});
            this.lcgPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.lcgPropertyGrid.Name = "lcgPropertyGrid";
            this.lcgPropertyGrid.Size = new System.Drawing.Size(615, 224);
            this.lcgPropertyGrid.Text = "Property Grid";
            // 
            // itmPropertyGrid
            // 
            this.itmPropertyGrid.Control = this.CustomizationPropertyGrid;
            this.itmPropertyGrid.CustomizationFormText = "Property Grid";
            this.itmPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.itmPropertyGrid.Name = "itmPropertyGrid";
            this.itmPropertyGrid.Size = new System.Drawing.Size(615, 224);
            this.itmPropertyGrid.Text = "Property Grid";
            this.itmPropertyGrid.TextSize = new System.Drawing.Size(0, 0);
            this.itmPropertyGrid.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnRestoreFactoryDefault;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 300);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(639, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // itmUser
            // 
            this.itmUser.Control = this.ddlUser;
            this.itmUser.CustomizationFormText = "User";
            this.itmUser.Location = new System.Drawing.Point(104, 0);
            this.itmUser.Name = "itmUser";
            this.itmUser.Size = new System.Drawing.Size(268, 29);
            this.itmUser.Text = "User";
            this.itmUser.TextSize = new System.Drawing.Size(0, 0);
            this.itmUser.TextVisible = false;
            // 
            // itmUsers
            // 
            this.itmUsers.Control = this.cbeUsers;
            this.itmUsers.CustomizationFormText = "Users";
            this.itmUsers.Location = new System.Drawing.Point(372, 0);
            this.itmUsers.Name = "itmUsers";
            this.itmUsers.Size = new System.Drawing.Size(267, 29);
            this.itmUsers.Text = "Users";
            this.itmUsers.TextSize = new System.Drawing.Size(0, 0);
            this.itmUsers.TextVisible = false;
            // 
            // CustomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 326);
            this.Controls.Add(this.layoutControl1);
            this.MinimumSize = new System.Drawing.Size(655, 365);
            this.Name = "CustomizationForm";
            this.Text = "Customizaton Dialogue";
            this.Load += new System.EventHandler(this.CustomizatonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbeUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenItemsList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHiddenItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgItemTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmLayoutTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPropertyGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPropertyGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.Customization.Controls.ButtonsPanel bpCustomButtons;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.Customization.Controls.CustomizationPropertyGrid CustomizationPropertyGrid;
        private DevExpress.XtraLayout.Customization.Controls.LayoutTreeView layoutTreeView1;
        private DevExpress.XtraLayout.Customization.Controls.HiddenItemsList hiddenItemsList1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHiddenItemList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup lcgItemTree;
        private DevExpress.XtraLayout.LayoutControlItem itmLayoutTree;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPropertyGrid;
        private DevExpress.XtraLayout.LayoutControlItem itmPropertyGrid;
        private DevExpress.XtraEditors.SimpleButton btnRestoreFactoryDefault;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SearchLookUpEdit ddlUser;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem itmUser;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource InstantFeedbackSourceUsers;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbeUsers;
        private DevExpress.XtraLayout.LayoutControlItem itmUsers;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private System.Windows.Forms.BindingSource BindingSourceUsers;
    }
}