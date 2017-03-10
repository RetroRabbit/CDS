namespace CDS.Client.Desktop.Essential
{
    partial class BaseDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDialogue));
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.lblHeading = new DevExpress.XtraEditors.LabelControl();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Controls.Add(this.lblHeading);
            this.pnlTop.Controls.Add(this.imgIcon);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(497, 44);
            this.pnlTop.TabIndex = 1;
            // 
            // lblHeading
            // 
            this.lblHeading.AllowHtmlString = true;
            this.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeading.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblHeading.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeading.Location = new System.Drawing.Point(44, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(448, 38);
            this.lblHeading.TabIndex = 1;
            // 
            // imgIcon
            // 
            this.imgIcon.Image = ((System.Drawing.Image)(resources.GetObject("imgIcon.Image")));
            this.imgIcon.Location = new System.Drawing.Point(5, 5);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(32, 32);
            this.imgIcon.TabIndex = 0;
            this.imgIcon.TabStop = false;
            // 
            // LayoutControl
            // 
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(5, 49);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.Root = this.LayoutGroup;
            this.LayoutControl.Size = new System.Drawing.Size(497, 194);
            this.LayoutControl.TabIndex = 2;
            this.LayoutControl.Text = "LayoutControl";
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.CustomizationFormText = "LayoutGroup";
            this.LayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutGroup.GroupBordersVisible = false;
            this.LayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.LayoutGroup.Name = "LayoutGroup";
            this.LayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.LayoutGroup.Size = new System.Drawing.Size(497, 194);
            this.LayoutGroup.Text = "LayoutGroup";
            this.LayoutGroup.TextVisible = false;
            // 
            // BaseDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseDialogue";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.BaseDialogue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        protected DevExpress.XtraLayout.LayoutControl LayoutControl;
        protected DevExpress.XtraLayout.LayoutControlGroup LayoutGroup;
        private DevExpress.XtraEditors.LabelControl lblHeading;
        private System.Windows.Forms.PictureBox imgIcon;

    }
}