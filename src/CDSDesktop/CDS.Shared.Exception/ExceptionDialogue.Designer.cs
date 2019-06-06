namespace CDS.Shared.Exception
{
    partial class ExceptionDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionDialogue));
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.lblHeading = new DevExpress.XtraEditors.LabelControl();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.txtException = new DevExpress.XtraEditors.MemoEdit();
            this.btnRestart = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuit = new DevExpress.XtraEditors.SimpleButton();
            this.peImage = new DevExpress.XtraEditors.PictureEdit();
            this.LayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmImage = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmMessage = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtCallStock = new DevExpress.XtraEditors.MemoExEdit();
            this.itmCallStack = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtException.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCallStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCallStack)).BeginInit();
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
            this.lblHeading.Text = "An unrecoverable application error has occured.\r\nThe system will attempt to send " +
    "a email to the support team";
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
            this.LayoutControl.Controls.Add(this.txtCallStock);
            this.LayoutControl.Controls.Add(this.txtException);
            this.LayoutControl.Controls.Add(this.btnRestart);
            this.LayoutControl.Controls.Add(this.btnQuit);
            this.LayoutControl.Controls.Add(this.peImage);
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCallStack});
            this.LayoutControl.Location = new System.Drawing.Point(5, 49);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2571, 175, 250, 350);
            this.LayoutControl.Root = this.LayoutGroup;
            this.LayoutControl.Size = new System.Drawing.Size(497, 194);
            this.LayoutControl.TabIndex = 2;
            this.LayoutControl.Text = "LayoutControl";
            // 
            // txtException
            // 
            this.txtException.Location = new System.Drawing.Point(206, 22);
            this.txtException.Name = "txtException";
            this.txtException.Properties.ReadOnly = true;
            this.txtException.Size = new System.Drawing.Size(285, 140);
            this.txtException.StyleController = this.LayoutControl;
            this.txtException.TabIndex = 8;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(415, 166);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(76, 22);
            this.btnRestart.StyleController = this.LayoutControl;
            this.btnRestart.TabIndex = 7;
            this.btnRestart.Text = "Restart";
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(335, 166);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(76, 22);
            this.btnQuit.StyleController = this.LayoutControl;
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // peImage
            // 
            this.peImage.Location = new System.Drawing.Point(6, 22);
            this.peImage.Name = "peImage";
            this.peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.peImage.Size = new System.Drawing.Size(196, 140);
            this.peImage.StyleController = this.LayoutControl;
            this.peImage.TabIndex = 5;
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.CustomizationFormText = "LayoutGroup";
            this.LayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutGroup.GroupBordersVisible = false;
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmImage,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.itmMessage,
            this.emptySpaceItem1});
            this.LayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.LayoutGroup.Name = "LayoutGroup";
            this.LayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.LayoutGroup.Size = new System.Drawing.Size(497, 194);
            this.LayoutGroup.Text = "LayoutGroup";
            this.LayoutGroup.TextVisible = false;
            // 
            // itmImage
            // 
            this.itmImage.Control = this.peImage;
            this.itmImage.CustomizationFormText = "Image";
            this.itmImage.Location = new System.Drawing.Point(0, 16);
            this.itmImage.Name = "itmImage";
            this.itmImage.Size = new System.Drawing.Size(200, 144);
            this.itmImage.Text = "Image";
            this.itmImage.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmImage.TextSize = new System.Drawing.Size(0, 0);
            this.itmImage.TextToControlDistance = 0;
            this.itmImage.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnQuit;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(329, 160);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnRestart;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(409, 160);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(329, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmMessage
            // 
            this.itmMessage.Control = this.txtException;
            this.itmMessage.CustomizationFormText = "Exception message";
            this.itmMessage.Location = new System.Drawing.Point(200, 0);
            this.itmMessage.Name = "itmMessage";
            this.itmMessage.Size = new System.Drawing.Size(289, 160);
            this.itmMessage.Text = "Exception message";
            this.itmMessage.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmMessage.TextSize = new System.Drawing.Size(92, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(200, 16);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtCallStock
            // 
            this.txtCallStock.Location = new System.Drawing.Point(206, 142);
            this.txtCallStock.Name = "txtCallStock";
            this.txtCallStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCallStock.Properties.ReadOnly = true;
            this.txtCallStock.Size = new System.Drawing.Size(285, 20);
            this.txtCallStock.StyleController = this.LayoutControl;
            this.txtCallStock.TabIndex = 9;
            // 
            // itmCallStack
            // 
            this.itmCallStack.Control = this.txtCallStock;
            this.itmCallStack.CustomizationFormText = "Call Stack";
            this.itmCallStack.Location = new System.Drawing.Point(200, 120);
            this.itmCallStack.Name = "itmCallStack";
            this.itmCallStack.Size = new System.Drawing.Size(289, 40);
            this.itmCallStack.Text = "Call Stack";
            this.itmCallStack.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmCallStack.TextSize = new System.Drawing.Size(50, 20);
            this.itmCallStack.TextToControlDistance = 5;
            // 
            // ExceptionDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 248);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionDialogue";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Complete Distribution Error";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExceptionDialogue_FormClosing);
            this.Load += new System.EventHandler(this.BaseDialogue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtException.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCallStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCallStack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        protected DevExpress.XtraLayout.LayoutControl LayoutControl;
        protected DevExpress.XtraLayout.LayoutControlGroup LayoutGroup;
        private DevExpress.XtraEditors.LabelControl lblHeading;
        private System.Windows.Forms.PictureBox imgIcon;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraLayout.LayoutControlItem itmImage;
        private DevExpress.XtraEditors.SimpleButton btnRestart;
        private DevExpress.XtraEditors.SimpleButton btnQuit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.MemoEdit txtException;
        private DevExpress.XtraLayout.LayoutControlItem itmMessage;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.MemoExEdit txtCallStock;
        private DevExpress.XtraLayout.LayoutControlItem itmCallStack;

    }
}