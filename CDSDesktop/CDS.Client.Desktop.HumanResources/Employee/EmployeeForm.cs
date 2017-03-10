using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.HumanResources.Employee
{
    public partial class EmployeeForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.HRS_Employee hrsEmployee;
        DB.SYS_Person sysPerson;
        /// <summary>
        /// Boolean that returns true if Document has never been submited to the database (Is a new document)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (hrsEmployee != null)
                    return (DataContext.EntityHumanResourcesContext.GetEntityState(hrsEmployee) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
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
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public EmployeeForm()
        {
            InitializeComponent();
        }

        public EmployeeForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        /// <summary>
        /// Load any necesary lookup values.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2012</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                AllowRefresh = true;
                ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
                ServerModeSourceRole.QueryableSource = DataContext.EntityHumanResourcesContext.HRS_Role; 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = hrsEmployee;
            BindingSourcePerson.DataSource = sysPerson;
        }

        /// <summary>
        /// The binding source is bound to a new instance of an Employee. This is for the instances where a new record is to be created.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2012</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                hrsEmployee = BL.HRS.HRS_Employee.New;
                sysPerson = BL.SYS.SYS_Person.New;
                txtDateOfBirth.EditValue = DateTime.Now;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open a Employee record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the Employee to open.</param>
        /// <remarks>Created: Werner Scheffer 24/07/2012</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                base.OpenRecord(Id);
                hrsEmployee = BL.HRS.HRS_Employee.Load(Id, DataContext);
                sysPerson = BL.SYS.SYS_Person.Load(hrsEmployee.PersonId.Value, DataContext);
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
                this.OnSaveRecord();
                if (!IsValid)
                    return false;
                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        BL.EntityController.SaveSYS_Person(sysPerson, DataContext);
                        DataContext.SaveChangesEntitySystemContext();
                        hrsEmployee.PersonId = (sysPerson).Id;
                        BL.EntityController.SaveHRS_Employee(hrsEmployee, DataContext);
                        DataContext.SaveChangesEntityHumanResourcesContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntitySystemContext.AcceptAllChanges();
                    DataContext.EntityHumanResourcesContext.AcceptAllChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    DataContext.EntitySystemContext.RejectChanges();
                    DataContext.EntityHumanResourcesContext.RejectChanges();
                    HasErrors = true;
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    return false;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Commit all changes of the Employee record to the database.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2012</remarks>
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
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.HREMREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.HREMRECR);
        }

        public override void RefreshRecord()
        {
            base.RefreshRecord();
            if (!IsNew)
            {
                DataContext.EntityHumanResourcesContext.ReloadEntry(hrsEmployee);
                DataContext.EntitySystemContext.ReloadEntry(sysPerson);
                ServerModeSourceRole.Reload();
                InstantFeedbackSourceUser.Refresh();
            }
            else
            {
                ServerModeSourceRole.Reload();
                InstantFeedbackSourceUser.Refresh();
            }
        }

        private void ddlSystemUser_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlSystemUser.EditValue != null && ddlSystemUser.EditValue != DBNull.Value && Convert.ToInt64(ddlSystemUser.EditValue) != 0)
            {
                sysPerson = BL.SYS.SYS_Person.Load((long)ddlSystemUser.EditValue, DataContext);
                BindData();
                ValidateLayout();                
            }
        }

        private void imgPhoto_DoubleClick(object sender, EventArgs e)
        {
            imgPhoto.LoadImage();
        }

        private void InstantFeedbackSourceUser_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_User.Where(n => n.Archived == false);
        }
    }
}
