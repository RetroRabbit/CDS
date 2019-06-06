namespace CDS.Client.Desktop.Catalogue.CAT
{
    partial class ViewImageDialogue
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
            this.peImage = new DevExpress.XtraEditors.PictureEdit();
            this.lciImage = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImage)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.peImage);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciImage});
            // 
            // peImage
            // 
            this.peImage.Location = new System.Drawing.Point(6, 6);
            this.peImage.Name = "peImage";
            this.peImage.Properties.ReadOnly = true;
            this.peImage.Properties.ShowScrollBars = true;
            this.peImage.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.peImage.Size = new System.Drawing.Size(485, 182);
            this.peImage.StyleController = this.LayoutControl;
            this.peImage.TabIndex = 4;
            // 
            // lciImage
            // 
            this.lciImage.Control = this.peImage;
            this.lciImage.CustomizationFormText = "lciPicture";
            this.lciImage.Location = new System.Drawing.Point(0, 0);
            this.lciImage.Name = "lciImage";
            this.lciImage.Size = new System.Drawing.Size(489, 186);
            this.lciImage.Text = "lciImage";
            this.lciImage.TextSize = new System.Drawing.Size(0, 0);
            this.lciImage.TextToControlDistance = 0;
            this.lciImage.TextVisible = false;
            // 
            // ViewImageDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.Name = "ViewImageDialogue";
            this.TabHeading = "Shows the image for the selected Meta Entry";
            this.Text = " Catalogue Image";
            this.Load += new System.EventHandler(this.ViewImageDialogue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraLayout.LayoutControlItem lciImage;
    }
}
