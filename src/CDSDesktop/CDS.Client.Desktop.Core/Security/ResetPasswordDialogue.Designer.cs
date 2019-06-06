namespace CDS.Client.Desktop.Core.Security
{
    partial class ResetPasswordDialogue
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
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.itmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRepeatPassword = new DevExpress.XtraEditors.TextEdit();
            this.itmRepeatPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.itmAccept = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.itmCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.barPasswordStrength = new DevExpress.XtraEditors.ProgressBarControl();
            this.itmPasswordStrength = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlResetPassword = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeatPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRepeatPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barPasswordStrength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPasswordStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResetPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.barPasswordStrength);
            this.LayoutControl.Controls.Add(this.btnCancel);
            this.LayoutControl.Controls.Add(this.btnAccept);
            this.LayoutControl.Controls.Add(this.txtRepeatPassword);
            this.LayoutControl.Controls.Add(this.txtPassword);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(944, 123, 250, 350);
            this.LayoutControl.Size = new System.Drawing.Size(423, 194);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCancel,
            this.emptySpaceItem1,
            this.itmAccept,
            this.pnlResetPassword});
            this.LayoutGroup.Size = new System.Drawing.Size(423, 194);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 37);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(292, 20);
            this.txtPassword.StyleController = this.LayoutControl;
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // itmPassword
            // 
            this.itmPassword.Control = this.txtPassword;
            this.itmPassword.CustomizationFormText = "Password";
            this.itmPassword.Location = new System.Drawing.Point(0, 0);
            this.itmPassword.Name = "itmPassword";
            this.itmPassword.Size = new System.Drawing.Size(391, 24);
            this.itmPassword.Text = "Password";
            this.itmPassword.TextSize = new System.Drawing.Size(91, 13);
            // 
            // txtRepeatPassword
            // 
            this.txtRepeatPassword.Location = new System.Drawing.Point(113, 61);
            this.txtRepeatPassword.Name = "txtRepeatPassword";
            this.txtRepeatPassword.Properties.UseSystemPasswordChar = true;
            this.txtRepeatPassword.Size = new System.Drawing.Size(292, 20);
            this.txtRepeatPassword.StyleController = this.LayoutControl;
            this.txtRepeatPassword.TabIndex = 5;
            // 
            // itmRepeatPassword
            // 
            this.itmRepeatPassword.Control = this.txtRepeatPassword;
            this.itmRepeatPassword.CustomizationFormText = "Repeat Password";
            this.itmRepeatPassword.Location = new System.Drawing.Point(0, 24);
            this.itmRepeatPassword.Name = "itmRepeatPassword";
            this.itmRepeatPassword.Size = new System.Drawing.Size(391, 24);
            this.itmRepeatPassword.Text = "Repeat Password";
            this.itmRepeatPassword.TextSize = new System.Drawing.Size(91, 13);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(282, 166);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(66, 22);
            this.btnAccept.StyleController = this.LayoutControl;
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // itmAccept
            // 
            this.itmAccept.Control = this.btnAccept;
            this.itmAccept.CustomizationFormText = "Accept";
            this.itmAccept.Location = new System.Drawing.Point(276, 160);
            this.itmAccept.Name = "itmAccept";
            this.itmAccept.Size = new System.Drawing.Size(70, 26);
            this.itmAccept.Text = "Accept";
            this.itmAccept.TextSize = new System.Drawing.Size(0, 0);
            this.itmAccept.TextToControlDistance = 0;
            this.itmAccept.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(352, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 22);
            this.btnCancel.StyleController = this.LayoutControl;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            // 
            // itmCancel
            // 
            this.itmCancel.Control = this.btnCancel;
            this.itmCancel.CustomizationFormText = "Cancel";
            this.itmCancel.Location = new System.Drawing.Point(346, 160);
            this.itmCancel.Name = "itmCancel";
            this.itmCancel.Size = new System.Drawing.Size(69, 26);
            this.itmCancel.Text = "Cancel";
            this.itmCancel.TextSize = new System.Drawing.Size(0, 0);
            this.itmCancel.TextToControlDistance = 0;
            this.itmCancel.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(276, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 86);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(391, 31);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // barPasswordStrength
            // 
            this.barPasswordStrength.Location = new System.Drawing.Point(18, 101);
            this.barPasswordStrength.Name = "barPasswordStrength";
            this.barPasswordStrength.Properties.AllowFocused = false;
            this.barPasswordStrength.Properties.EndColor = System.Drawing.Color.Empty;
            this.barPasswordStrength.Properties.Maximum = 10;
            this.barPasswordStrength.Properties.PercentView = false;
            this.barPasswordStrength.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.barPasswordStrength.Properties.ReadOnly = true;
            this.barPasswordStrength.Properties.ShowTitle = true;
            this.barPasswordStrength.Properties.StartColor = System.Drawing.Color.Empty;
            this.barPasswordStrength.Properties.Step = 1;
            this.barPasswordStrength.Size = new System.Drawing.Size(387, 18);
            this.barPasswordStrength.StyleController = this.LayoutControl;
            this.barPasswordStrength.TabIndex = 8;
            this.barPasswordStrength.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.barPasswordStrength_CustomDisplayText);
            // 
            // itmPasswordStrength
            // 
            this.itmPasswordStrength.Control = this.barPasswordStrength;
            this.itmPasswordStrength.CustomizationFormText = "Password Strength";
            this.itmPasswordStrength.Location = new System.Drawing.Point(0, 48);
            this.itmPasswordStrength.Name = "itmPasswordStrength";
            this.itmPasswordStrength.Size = new System.Drawing.Size(391, 38);
            this.itmPasswordStrength.Text = "Password Strength";
            this.itmPasswordStrength.TextLocation = DevExpress.Utils.Locations.Top;
            this.itmPasswordStrength.TextSize = new System.Drawing.Size(91, 13);
            // 
            // pnlResetPassword
            // 
            this.pnlResetPassword.CustomizationFormText = "Reset Password";
            this.pnlResetPassword.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.itmPasswordStrength,
            this.itmRepeatPassword,
            this.itmPassword});
            this.pnlResetPassword.Location = new System.Drawing.Point(0, 0);
            this.pnlResetPassword.Name = "pnlResetPassword";
            this.pnlResetPassword.Size = new System.Drawing.Size(415, 160);
            this.pnlResetPassword.Text = "Reset Password";
            // 
            // ResetPasswordDialogue
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(433, 248);
            this.Name = "ResetPasswordDialogue";
            this.TabHeading = "This will reset the user\'s password. The next time the user signs in he will be r" +
    "equired to use this new password. Ensure that the password is typed correctly in" +
    " both boxes below.";
            this.TabIcon = global::CDS.Client.Desktop.Core.Properties.Resources.key_32;
            this.Text = "Reset Password";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeatPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmRepeatPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barPasswordStrength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmPasswordStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResetPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControlItem itmPassword;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.TextEdit txtRepeatPassword;
        private DevExpress.XtraLayout.LayoutControlItem itmRepeatPassword;
        private DevExpress.XtraLayout.LayoutControlItem itmAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem itmCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.ProgressBarControl barPasswordStrength;
        private DevExpress.XtraLayout.LayoutControlItem itmPasswordStrength;
        private DevExpress.XtraLayout.LayoutControlGroup pnlResetPassword;
    }
}
