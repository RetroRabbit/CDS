namespace CDS.Client.Installer.Prerequisites
{
    partial class SystemInstallDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemInstallDialogue));
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblBottomMessage = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.LinkLabel();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInstallClient = new System.Windows.Forms.Button();
            this.btnInstallServer = new System.Windows.Forms.Button();
            this.btnInstallDemo = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(541, 168);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 15);
            this.lblProgress.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.SystemColors.Window;
            this.lblWelcome.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.lblWelcome.Location = new System.Drawing.Point(162, 84);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(359, 48);
            this.lblWelcome.TabIndex = 7;
            this.lblWelcome.Text = "Complete Distribution System Installer {0}\r\nSelect installation option below";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBottomMessage
            // 
            this.lblBottomMessage.AutoSize = true;
            this.lblBottomMessage.BackColor = System.Drawing.SystemColors.Window;
            this.lblBottomMessage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.lblBottomMessage.Location = new System.Drawing.Point(40, 319);
            this.lblBottomMessage.Name = "lblBottomMessage";
            this.lblBottomMessage.Size = new System.Drawing.Size(603, 38);
            this.lblBottomMessage.TabIndex = 8;
            this.lblBottomMessage.Text = "If you have any question regarding thus installer or need assistance with the set" +
    "up process,\r\nfeel free to contact us at                      ";
            this.lblBottomMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.ActiveLinkColor = System.Drawing.Color.SteelBlue;
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.SystemColors.Window;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(165)))), ((int)(((byte)(192)))));
            this.lblEmail.Location = new System.Drawing.Point(378, 338);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(171, 19);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.TabStop = true;
            this.lblEmail.Text = "support@cdsonline.co.za";
            this.lblEmail.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.lblEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBackground.Controls.Add(this.btnClose);
            this.pnlBackground.Controls.Add(this.lblStatus);
            this.pnlBackground.Controls.Add(this.lblEmail);
            this.pnlBackground.Controls.Add(this.lblBottomMessage);
            this.pnlBackground.Controls.Add(this.btnInstallClient);
            this.pnlBackground.Controls.Add(this.btnInstallServer);
            this.pnlBackground.Controls.Add(this.btnInstallDemo);
            this.pnlBackground.Controls.Add(this.lblWelcome);
            this.pnlBackground.Controls.Add(this.pbLogo);
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(701, 403);
            this.pnlBackground.TabIndex = 10;
            this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBackground_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Window;
            this.btnClose.BackgroundImage = global::CDS.Client.Installer.Prerequisites.Properties.Resources.navigate_cross_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.btnClose.Location = new System.Drawing.Point(661, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 16);
            this.btnClose.TabIndex = 5;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Paint += new System.Windows.Forms.PaintEventHandler(this.RemoveButtonFocusBorder_Paint);
            // 
            // btnInstallClient
            // 
            this.btnInstallClient.BackColor = System.Drawing.SystemColors.Window;
            this.btnInstallClient.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnInstallClient.FlatAppearance.BorderSize = 0;
            this.btnInstallClient.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.btnInstallClient.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnInstallClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.btnInstallClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.btnInstallClient.Image = ((System.Drawing.Image)(resources.GetObject("btnInstallClient.Image")));
            this.btnInstallClient.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInstallClient.Location = new System.Drawing.Point(138, 164);
            this.btnInstallClient.Name = "btnInstallClient";
            this.btnInstallClient.Size = new System.Drawing.Size(140, 149);
            this.btnInstallClient.TabIndex = 0;
            this.btnInstallClient.Text = "Install Client";
            this.btnInstallClient.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInstallClient.UseVisualStyleBackColor = false;
            this.btnInstallClient.Click += new System.EventHandler(this.btnInstallClient_Click);
            this.btnInstallClient.Paint += new System.Windows.Forms.PaintEventHandler(this.RemoveButtonFocusBorder_Paint);
            // 
            // btnInstallServer
            // 
            this.btnInstallServer.BackColor = System.Drawing.SystemColors.Window;
            this.btnInstallServer.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnInstallServer.FlatAppearance.BorderSize = 0;
            this.btnInstallServer.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.btnInstallServer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnInstallServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.btnInstallServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.btnInstallServer.Image = ((System.Drawing.Image)(resources.GetObject("btnInstallServer.Image")));
            this.btnInstallServer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInstallServer.Location = new System.Drawing.Point(284, 164);
            this.btnInstallServer.Name = "btnInstallServer";
            this.btnInstallServer.Size = new System.Drawing.Size(141, 149);
            this.btnInstallServer.TabIndex = 0;
            this.btnInstallServer.Text = "Install Server";
            this.btnInstallServer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInstallServer.UseVisualStyleBackColor = false;
            this.btnInstallServer.Click += new System.EventHandler(this.btnInstallServer_Click);
            this.btnInstallServer.Paint += new System.Windows.Forms.PaintEventHandler(this.RemoveButtonFocusBorder_Paint);
            // 
            // btnInstallDemo
            // 
            this.btnInstallDemo.BackColor = System.Drawing.SystemColors.Window;
            this.btnInstallDemo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnInstallDemo.FlatAppearance.BorderSize = 0;
            this.btnInstallDemo.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.btnInstallDemo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnInstallDemo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.btnInstallDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallDemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(143)))));
            this.btnInstallDemo.Image = ((System.Drawing.Image)(resources.GetObject("btnInstallDemo.Image")));
            this.btnInstallDemo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInstallDemo.Location = new System.Drawing.Point(431, 164);
            this.btnInstallDemo.Name = "btnInstallDemo";
            this.btnInstallDemo.Size = new System.Drawing.Size(141, 149);
            this.btnInstallDemo.TabIndex = 0;
            this.btnInstallDemo.Text = "Install Demo";
            this.btnInstallDemo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInstallDemo.UseVisualStyleBackColor = false;
            this.btnInstallDemo.Click += new System.EventHandler(this.btnInstallDemo_Click);
            this.btnInstallDemo.Paint += new System.Windows.Forms.PaintEventHandler(this.RemoveButtonFocusBorder_Paint);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.SystemColors.Window;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(252, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 78);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // SystemInstallDialogue
            // 
            this.AcceptButton = this.btnInstallClient;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.ControlBox = false;
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemInstallDialogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Complete Distribution System Install";
            this.Load += new System.EventHandler(this.SystemInstallDialogue_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SystemInstallDialogue_MouseDown);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstallClient;
        private System.Windows.Forms.Button btnInstallServer;
        private System.Windows.Forms.Button btnInstallDemo;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblBottomMessage;
        private System.Windows.Forms.LinkLabel lblEmail;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Button btnClose;
    }
}