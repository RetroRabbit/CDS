using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Security
{
    public partial class ResetPasswordDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public ResetPasswordDialogue()
        {
            InitializeComponent();
        }

        private static int RatePassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                    return 0;
                int result = Math.Min(password.Length, 7); //max 8/10 for length
                //+1 for a letter
                if (System.Text.RegularExpressions.Regex.Match(password, "[a-zA-Z]").Success)
                    result += 1;
                //+1 for a number
                if (System.Text.RegularExpressions.Regex.Match(password, "[0-9]").Success)
                    result += 1;
                //+1 for a special char
                if (System.Text.RegularExpressions.Regex.Match(password, "[\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\{\\}\\[\\]\\:\\'\\;\\\"\\/\\?\\.\\>\\,\\<\\~\\`\\-\\\\_\\=\\+\\|]").Success)
                    result += 1;
                return result;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return 0;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateProgressBar();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void UpdateProgressBar()
        {
            try
            {
                int strength = RatePassword(txtPassword.Text);
                barPasswordStrength.EditValue = strength;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public string Password
        {
            get
            {
                return BL.SEC.SecurityLibrary.EncodePassword(this.txtPassword.Text);
            }
        }

        private void barPasswordStrength_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            try
            {
                switch ((int)e.Value)
                {
                    case 0:
                        e.DisplayText = "Blank";
                        break;
                    case 1:
                    case 2:
                        e.DisplayText = "Very Weak";
                        break;
                    case 3:
                    case 4:
                        e.DisplayText = "Weak";
                        break;
                    case 5:
                    case 6:
                        e.DisplayText = "Medium";
                        break;
                    case 7:
                    case 8:
                        e.DisplayText = "Strong";
                        break;
                    case 9:
                    case 10:
                        e.DisplayText = "Very Strong";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == txtRepeatPassword.Text)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
