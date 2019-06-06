namespace CDS.Client.Desktop.Essential
{
    partial class OpenFolderDialogue
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
            this.tlFolders = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.BindingSource = new System.Windows.Forms.BindingSource();
            this.itmFolderTree = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFolderTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.btnOk);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.tlFolders);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2656, 45, 250, 350);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmFolderTree,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Text = "Root";
            // 
            // tlFolders
            // 
            this.tlFolders.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.tlFolders.DataSource = this.BindingSource;
            this.tlFolders.KeyFieldName = "Id";
            this.tlFolders.Location = new System.Drawing.Point(6, 6);
            this.tlFolders.Name = "tlFolders";
            this.tlFolders.ParentFieldName = "ParentId";
            this.tlFolders.Size = new System.Drawing.Size(485, 156);
            this.tlFolders.TabIndex = 4;
            this.tlFolders.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.tlFolders_BeforeExpand);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 456;
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.Desktop.Essential.OpenFolderDialogue.Directory);
            // 
            // itmFolderTree
            // 
            this.itmFolderTree.Control = this.tlFolders;
            this.itmFolderTree.CustomizationFormText = "Folder Tree";
            this.itmFolderTree.Location = new System.Drawing.Point(0, 0);
            this.itmFolderTree.Name = "itmFolderTree";
            this.itmFolderTree.Size = new System.Drawing.Size(489, 160);
            this.itmFolderTree.Text = "Folder Tree";
            this.itmFolderTree.TextSize = new System.Drawing.Size(0, 0);
            this.itmFolderTree.TextToControlDistance = 0;
            this.itmFolderTree.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(415, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(409, 160);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(329, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(335, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 22);
            this.btnOk.StyleController = this.LayoutControl;
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOk;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(329, 160);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // OpenFolderDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.Name = "OpenFolderDialogue";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmFolderTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlFolders;
        private DevExpress.XtraLayout.LayoutControlItem itmFolderTree;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
    }
}
