using CDS.Client.Desktop.Essential.UTL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;


namespace CDS.Client.Desktop.Main
{
    partial class MainForm
    {
        private void btnPersonalSetttings_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnAboutCDS_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSignOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Application.Restart();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void bvbSignout_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            try
            {
                foreach (var child in this.MdiChildren)
                {
                    child.Close();
                }

                if (this.MdiChildren.Count() == 0)
                    Application.Restart();
                else
                    BackstageView.Visible = false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void bvbExit_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnChangeLoginDetails_Click(object sender, EventArgs e)
        {
            try
            {
                BL.ApplicationDataContext.Instance.LoggedInUser.Username = txtUsername.Text;
                BL.ApplicationDataContext.Instance.LoggedInUser.DisplayName = txtDisplayName.Text;
                using (TransactionScope transaction = BL.ApplicationDataContext.Instance.DataContext.GetTransactionScope())
                {
                    BL.ApplicationDataContext.Instance.DataContext.SaveChangesEntitySecurityContext();
                    BL.ApplicationDataContext.Instance.DataContext.CompleteTransaction(transaction);
                }


                //Reloads the security
                BL.ApplicationDataContext.Instance.LoggedInUser = BL.ApplicationDataContext.Instance.LoggedInUser;
                ApplyMenuSecurity();
                //BL.ApplicationDataContext.Instance.SiteContext.SaveChanges();

                //Werner: This should work but it doesn't. If we ever fix it we just need to run the NavSecurity method again
                //long[] roleids = BL.ApplicationDataContext.Instance.SecurityEntityContext.SEC_UserRole.Where(n => n.UserId == BL.ApplicationDataContext.Instance.LoggedInUser.Id).Select(n => n.RoleId).ToArray();
                //BL.ApplicationDataContext.Instance.AccessIds = BL.ApplicationDataContext.Instance.SecurityEntityContext.SEC_RoleAccess.Where(n => roleids.Contains(n.RoleId)).Select(n => n.AccessId).Distinct().ToArray();


                Ribbon.HideApplicationButtonContentControl();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                using (CDS.Client.Desktop.Core.Security.ResetPasswordDialogue dialogue = new CDS.Client.Desktop.Core.Security.ResetPasswordDialogue())
                {
                    if (dialogue.ShowDialog() == DialogResult.OK)
                    {
                        BL.ApplicationDataContext.Instance.LoggedInUser.Password = dialogue.Password;
                        //BL.ApplicationDataContext.Instance.SiteContext.SaveChanges();
                        BL.ApplicationDataContext.Instance.DataContext.SaveChangesEntitySecurityContext();

                        Ribbon.HideApplicationButtonContentControl();
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = ddlStyle.SelectedItem.ToString();
            CustomApplicationSettings.Instance.ApplicationStyle = ddlStyle.SelectedItem.ToString();
            CustomApplicationSettings.Instance.Save();
        }

        private void tbFontSize_EditValueChanged(object sender, EventArgs e)
        {
            switch (((DevExpress.XtraEditors.TrackBarControl)(sender)).Value)
            {
                case 0: CustomApplicationSettings.Instance.FontSize = 8.25f; break;
                case 1: CustomApplicationSettings.Instance.FontSize = 10f; break;
                case 2: CustomApplicationSettings.Instance.FontSize = 12f; break;
                case 3: CustomApplicationSettings.Instance.FontSize = 14f; break;
            }
            CustomApplicationSettings.Instance.Save();

            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font(CustomApplicationSettings.Instance.FontType, CustomApplicationSettings.Instance.FontSize);

            //DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font(DevExpress.Utils.AppearanceObject.DefaultFont.FontFamily.Name, CustomApplicationSettings.Instance.FontSize);
        }

        private void ddlFontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomApplicationSettings.Instance.FontType =
            ((DevExpress.XtraEditors.FontEdit)sender).EditValue.ToString();

            CustomApplicationSettings.Instance.Save();
        }

        private void BackstageView_VisibleChanged(object sender, EventArgs e)
        {
            if (ddlStyle.Properties.Items.Count == 0)
            {

                foreach (DevExpress.Skins.SkinContainer item in DevExpress.Skins.SkinManager.Default.Skins)
                {
                    ddlStyle.Properties.Items.Add(item.CommonSkin.Name);
                }

                ddlStyle.SelectedItem = CustomApplicationSettings.Instance.ApplicationStyle;
            }

            ddlFontType.EditValue = CustomApplicationSettings.Instance.FontType;
        }

    }
}
