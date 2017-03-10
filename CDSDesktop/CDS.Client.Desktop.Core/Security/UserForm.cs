using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using CDS.Client.Desktop.Essential.UTL;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;


namespace CDS.Client.Desktop.Core.Security
{
    public partial class UserForm : CDS.Client.Desktop.Essential.BaseForm
    {
        private bool RollHasChanged = false;
        private bool Startup = true;

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                AllowSave = BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SYSEURREED);

                ServerModeSourceUserRoles.QueryableSource = DataContext.EntitySecurityContext.SEC_Role;
                BindingSourcePrinter.DataSource = DataContext.EntitySystemContext.SYS_Printer.ToList();
                BindingSourceSite.DataSource = DataContext.ReadonlyContext.VW_Site.ToList();


                //Matches payment accounts to site selector instead of company site
                //Sean Hill 15/9/2016
                if (ddlDefaultSite.EditValue != null)
                { 
                    String paymentAccounts = BL.ApplicationDataContext.Instance.SystemEntityContext.SYS_Site.Include("SYS_Entity").FirstOrDefault(n => n.SYS_Entity.Id == (long?)ddlDefaultSite.EditValue).PaymentAccounts;
                    BindingSourcePayableAccounts.DataSource = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(paymentAccounts, typeof(List<BL.GLX.PaymentAccount>));
                }

                //Now that sites differ, the list needs to come from selection
                //this if used to be:
                //BindingSourcePayableAccounts.DataSource = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(BL.ApplicationDataContext.Instance.CompanySite.PaymentAccounts, typeof(List<BL.GLX.PaymentAccount>));


                if (BindingSource.DataSource != null)
                {
                    List<Int64> current = ((DB.SEC_User)BindingSource.DataSource).SEC_UserRole.Select(n => n.RoleId).ToList();

                    for (int i = 0; i < lstRoles.ItemCount; i++)
                    {
                        if (current.Contains((lstRoles.GetItem(i) as DB.SEC_Role).Id))
                        {
                            lstRoles.SetItemChecked(i, true);
                        }
                    }
                }
                Startup = false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                BindingSource.DataSource = BL.SEC.SEC_User.New;
                BindingSourcePerson.DataSource = BL.SYS.SYS_Person.New;
                btnResetPassword.Caption = "Set Password";
                BindData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            try
            {
                base.BindData();
                ddlTitle.Properties.DataSource = Enum.GetNames(typeof(BL.SYS.SYS_Title));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void OpenRecord(Int64 Id)
        {
            try
            {
                BindingSource.DataSource = BL.SEC.SEC_User.LoadByPerson(Id, DataContext, new List<string>() { "SEC_UserRole" });//DataContext.EntitySecurityContext.SEC_User.FirstOrDefault(n => n.Id == (int)Id);
                BindingSourcePerson.DataSource = BL.SYS.SYS_Person.Load(Id, DataContext);
                BindData();

                //((BL.SEC.SEC_User)BindingSource.DataSource).SEC_Roles

                //lstRoles.SetItemChecked(Xceed, true);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    if (!IsValid)
                        return false;

                    DB.SEC_User secUser = (DB.SEC_User)BindingSource.DataSource;
                    DB.SYS_Person sys_person = (DB.SYS_Person)BindingSourcePerson.DataSource;
                    List<DB.SEC_UserRole> current = secUser.SEC_UserRole.Select(n => n as DB.SEC_UserRole).ToList();
                    List<DB.SEC_Role> selectedroles = lstRoles.CheckedItems.Cast<DB.SEC_Role>().ToList();
                    // Get all the roles that have been added to the user.
                    List<Int64> roleidsrequired = selectedroles.Where(n => !current.Select(m => m.RoleId).Contains(n.Id)).Select(n => n.Id).ToList();
                    foreach (Int64 id in roleidsrequired)
                    {
                        DB.SEC_UserRole userrole = BL.SEC.SEC_UserRole.New;
                        userrole.UserId = secUser.Id;
                        userrole.RoleId = id;
                        secUser.SEC_UserRole.Add(userrole);
                    }
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Person(sys_person, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            secUser.PersonId = sys_person.Id;
                            BL.EntityController.SaveSEC_User(secUser, DataContext);
                            if (RollHasChanged)
                            {
                                // Remove the roles that are on the user and not in the checked list.
                                List<DB.SEC_UserRole> roleidsdeleted = current.Where(n => !selectedroles.Select(m => m.Id).Contains(n.RoleId)).ToList();

                                foreach (DB.SEC_UserRole ur in roleidsdeleted)
                                {
                                    BL.SEC.SEC_UserRole.DeleteUserRole(ur, DataContext);
                                }

                                //TODO : Remove this when log system is added
                                //BL.SEC.SEC_User.UpdateRoleModifiedFlags(secUser, DataContext);
                            }
                            DataContext.SaveChangesEntitySecurityContext();
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySecurityContext.AcceptAllChanges();
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySecurityContext.RejectChanges();
                        DataContext.EntitySystemContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        protected override void Archive()
        {
            try
            {
                base.Archive();

                //var entity = DataContext.EntitySystemContext.SYS_Person.FirstOrDefault(n => n.Id == ((DB.SYS_Person)BindingSourcePerson.DataSource).Id);
                var entity = (DB.SYS_Person)BindingSourcePerson.DataSource;
                entity.Archived = !entity.Archived;
                DataContext.EntitySystemContext.SaveChanges();

                btnArchive.Caption = entity.Archived ? "Un-Archive" : "Archive";
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                isValid = IsPasswordValid() && IsUserNameValid() && IsDisplayNameValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsDisplayNameValid()
        {
            try
            {
                bool isValid = true;
                isValid = !DataContext.EntitySecurityContext.SEC_User.Any(n => n.Id != ((DB.SEC_User)BindingSource.DataSource).Id && n.DisplayName == ((DB.SEC_User)BindingSource.DataSource).DisplayName);
                if (!isValid)
                    Essential.BaseAlert.ShowAlert("Invalid Display Name", "The display name you have entered already exists enter another display name.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsUserNameValid()
        {
            try
            {
                bool isValid = true;
                isValid = !DataContext.EntitySecurityContext.SEC_User.Any(n => n.Id != ((DB.SEC_User)BindingSource.DataSource).Id && n.Username == ((DB.SEC_User)BindingSource.DataSource).Username);
                if (!isValid)
                    Essential.BaseAlert.ShowAlert("Invalid Username", "The username you have entered already exists enter another username.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsPasswordValid()
        {
            try
            {
                bool isValid = true;

                if (((DB.SEC_User)BindingSource.DataSource).Password == null || ((DB.SEC_User)BindingSource.DataSource).Password == string.Empty)
                {
                    using (ResetPasswordDialogue dialogue = new ResetPasswordDialogue())
                    {
                        if (dialogue.ShowDialog() == DialogResult.OK)
                        {
                            ((DB.SEC_User)BindingSource.DataSource).Password = dialogue.Password;
                            txtPassword.Text = dialogue.Password;
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                }

                if (!isValid)
                    Essential.BaseAlert.ShowAlert("Invalid Password", "The user needs to have a password to be able to save.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }


        /// <summary>
        /// Loads and opens the next User record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 23/07/2012</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                DB.SEC_User secUser = BL.SEC.SEC_User.GetNextItem((DB.SEC_User)BindingSource.DataSource, DataContext);
                if (secUser != null)
                {
                    BindingSource.DataSource = secUser;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous User record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 23/07/2012</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();


                DB.SEC_User secUser = BL.SEC.SEC_User.GetPreviousItem((DB.SEC_User)BindingSource.DataSource, DataContext);
                if (secUser != null)
                {
                    BindingSource.DataSource = secUser;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE01));
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSEURREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSEURRECR);

            btnResetPassword.Visibility = (AllowSave) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnResetPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ValidateLayout();
                using (ResetPasswordDialogue dialogue = new ResetPasswordDialogue())
                {
                    if (dialogue.ShowDialog() == DialogResult.OK)
                    {
                        ((DB.SEC_User)BindingSource.DataSource).Password = dialogue.Password;
                        txtPassword.Text = dialogue.Password;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        //TODO : Remove this when log system is added
        /// <summary>
        /// Sets boolean to true that identifies that roll has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 28/02/2013</remarks>
        private void lstRoles_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (!Startup)
                RollHasChanged = true;
        }

        private void ddlDefaultSite_EditValueChanged(object sender, EventArgs e)
        {
            if(ddlDefaultSite.EditValue != ddlDefaultSite.OldEditValue)
            {
                ddlDefaultCashAccount.EditValue = null;
                if (ddlDefaultSite.EditValue != null)
                {
                    String paymentAccounts = BL.ApplicationDataContext.Instance.SystemEntityContext.SYS_Site.Include("SYS_Entity").FirstOrDefault(n => n.SYS_Entity.Id == (long?)ddlDefaultSite.EditValue).PaymentAccounts;
                    BindingSourcePayableAccounts.DataSource = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(paymentAccounts, typeof(List<BL.GLX.PaymentAccount>));
                }
            }
        }

        private void ddlDefaultCashAccount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ddlDefaultPrinter_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
