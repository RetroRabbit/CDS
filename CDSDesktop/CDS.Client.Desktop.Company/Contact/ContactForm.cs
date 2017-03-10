using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;

namespace CDS.Client.Desktop.Company.Contact
{
    public partial class ContactForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.ORG_Contact orgContact;
        DB.SYS_Person sysContact;

        /// <summary>
        /// Boolean that returns true if Contact has never been submited to the database (Is a new Contact)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (orgContact != null)
                    return (DataContext.EntityOrganisationContext.GetEntityState(orgContact) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public ContactForm()
        {
            InitializeComponent();
        }

        public ContactForm(Int64 id)
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
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();
            try
            {
                BindingSource.DataSource = orgContact;
                BindingSourcePerson.DataSource = sysContact; 
                ServerModeSourceDepartment.QueryableSource = DataContext.EntityOrganisationContext.ORG_Department;
                ddlTitle.Properties.DataSource = Enum.GetNames(typeof(BL.SYS.SYS_Title));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void Archive()
        {
            base.Archive();
            DB.ORG_Contact orgContact = (DB.ORG_Contact)BindingSource.DataSource;
            DB.SYS_Person sysPerson = BL.SYS.SYS_Person.Load(orgContact.PersonId, DataContext);

            sysPerson.Archived = !sysPerson.Archived;
            btnArchive.Caption = sysPerson.Archived ? "Un-Archive" : "Archive";
            try
            {
                using (TransactionScope transaction = DataContext.GetTransactionScope())
                {
                    DataContext.SaveChangesEntitySystemContext();
                    DataContext.CompleteTransaction(transaction);
                }
                DataContext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                DataContext.EntitySystemContext.RejectChanges();
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// The binding source is bound to a new instance of an ORG Entity. This is for the instances where a new record is to be created.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                orgContact = BL.ORG.ORG_Contact.New;
                sysContact = BL.SYS.SYS_Person.New; 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open an ORG Entity record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the ORG Entity to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    base.OpenRecord(Id);

                    orgContact = BL.ORG.ORG_Contact.Load(Id, DataContext);
                    sysContact = BL.SYS.SYS_Person.Load(orgContact.PersonId, DataContext);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Checks that below conditions are valid.
        /// * Type for control account has been selected
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 06/03/2012</remarks>
        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;

                bool isValid = true;
                //NO CHECKS currently
                //isValid = ???
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
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

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Person(sysContact, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            orgContact.PersonId = sysContact.Id;

                            if (orgContact.CompanyId != null)
                                BL.ORG.ORG_Contact.ClearCompanyContact(Convert.ToInt64(ddlCompany.EditValue), Convert.ToInt64(ddlDepartment.EditValue), DataContext);

                            BL.EntityController.SaveORG_Contact(orgContact, DataContext);
                            DataContext.SaveChangesEntityOrganisationContext();
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityOrganisationContext.AcceptAllChanges();
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityOrganisationContext.RejectChanges();
                        DataContext.EntitySystemContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true; CurrentException = ex;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Commit all changes of the Account record to the database.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE01));
            if (IsNew)
            {
                AllowArchive = false;
            }
            if (sysContact.Archived)
            {
                btnArchive.Caption = "Un-Archive";
            }
            else
            {
                btnArchive.Caption = "Archive";
            }
        }

        private void InstantFeedbackSourceCompany_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Organisations;
        }

    }
}
