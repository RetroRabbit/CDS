using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;

namespace CDS.Client.Desktop.HRS
{
    public partial class RoleForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.HRS_Role hrsRole;
        /// <summary>
        /// Boolean that returns true if Document has never been submited to the database (Is a new document)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (hrsRole != null)
                    return (DataContext.EntityHumanResourcesContext.GetEntityState(hrsRole) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public RoleForm()
        {
            InitializeComponent();
        }

        public RoleForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        /// <summary>
        /// Load any necesary lookup values.
        /// </summary>
        /// <remarks>Created: Theo Crous 24/07/2012</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = hrsRole;
            ServerModeSourceEmployees.QueryableSource = DataContext.EntityHumanResourcesContext.HRS_Employee.Where(n => n.RoleId == hrsRole.Id);
        }

        /// <summary>
        /// The binding source is bound to a new instance of an Role. This is for the instances where a new record is to be created.
        /// </summary>
        /// <remarks>Created: Theo Crous 24/07/2012</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                hrsRole = BL.HRS.HRS_Role.New;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open a Role record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the Role to open.</param>
        /// <remarks>Created: Theo Crous 24/07/2012</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                base.OpenRecord(Id);
                hrsRole = BL.HRS.HRS_Role.Load(Id, DataContext);
                chkAppointments.SetItemChecked(0, hrsRole.Appointment.Value);
                chkAppointments.SetItemChecked(1, hrsRole.PurchaseAppointment.Value);
                chkAppointments.SetItemChecked(2, hrsRole.SaleAppointment.Value);
                chkAppointments.SetItemChecked(3, hrsRole.WorkshopAppointment.Value);

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
                hrsRole.Appointment = chkAppointments.GetItemChecked(0);
                hrsRole.PurchaseAppointment = chkAppointments.GetItemChecked(1);
                hrsRole.SaleAppointment = chkAppointments.GetItemChecked(2);
                hrsRole.WorkshopAppointment = chkAppointments.GetItemChecked(3);
                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        BL.EntityController.SaveHRS_Role(hrsRole, DataContext);
                        DataContext.SaveChangesEntityHumanResourcesContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityHumanResourcesContext.AcceptAllChanges();
                    return true;
                }
                catch (Exception ex)
                {
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
        /// Commit all changes of the Role record to the database.
        /// </summary>
        /// <remarks>Created: Theo Crous 24/07/2012</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (IsNew)
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.HRRLREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.HRRLRECR);
        }
    }
} 