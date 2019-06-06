using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;

namespace CDS.Client.Desktop.Company.Entity
{
    public partial class EntityForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.SYS_Entity orgEntitySYSEntity;
        DB.ORG_Entity orgEntity;
        long? defaultSiteId;

        /// <summary>
        /// Boolean that returns true if Entity has never been submited to the database (Is a new Entity)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (orgEntity != null)
                    return (DataContext.EntityOrganisationContext.GetEntityState(orgEntity) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public EntityForm()
        {
            InitializeComponent();
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
        }

        public EntityForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            try
            {
                ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
                base.OnStart();
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
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORENREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORENRECR);

            if (IsNew)
            {
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                AllowArchive = false;
                btnCreateCustomer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnCreateSupplier.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnCreateCustomer.Visibility = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORCURECR) && !orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Customer && n.SiteId == defaultSiteId)) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnCreateSupplier.Visibility = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSURECR) && !orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier && n.SiteId == defaultSiteId)) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                btnViewCustomer.Visibility = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORCURE) && orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Customer && n.SiteId == defaultSiteId)) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnViewSupplier.Visibility = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSURE) && orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier && n.SiteId == defaultSiteId)) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
            
            if (orgEntitySYSEntity.Archived)
            {
                btnArchive.Caption = "Un-Archive";
            }
            else
            {
                btnArchive.Caption = "Archive";
            }
        }

        protected override void Archive()
        {
            base.Archive();
            throw new Exception("Fix this");
            DB.ORG_Entity org_entity = (DB.ORG_Entity)BindingSource.DataSource;
            DB.SYS_Entity sys_entity = BL.SYS.SYS_Entity.Load(org_entity.EntityId, DataContext);
            if (!sys_entity.Archived)
            {
                try
                {
                    //000 = Archived or Un-Archived
                    //001 = Outstanding Balance
                    //002 = Control Account
                    //003 = Is Parent
                    //004 = Parent is Archived
                    int code = -1;/* Context.Database.SqlQuery<int>(
                    "DECLARE	@return_value int" + Environment.NewLine +
                    "EXEC	@return_value = [dbo].[spArchiveAccount]" + Environment.NewLine +
                    "        @AccountId = " + glxAccount.Id + "," + Environment.NewLine +
                    "        @Archive = 1" + Environment.NewLine +
                    "SELECT	@return_value");
                    */


                    if (code.Equals(0))
                    {
                        sys_entity.Archived = !sys_entity.Archived;
                        btnArchive.Caption = sys_entity.Archived ? "Un-Archive" : "Archive";
                    }
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
            else
            {
                try
                {
                    //TODO: Find a way to do this
                    //returns 1 if sp was able to unarchive account
                    int code = -1; /* Context.Database.SqlQuery<int>(
                    "DECLARE	@return_value int" + Environment.NewLine +
                    "EXEC	@return_value = [dbo].[spArchiveAccount]" + Environment.NewLine +
                    "        @AccountId = " + glxAccount.Id + "," + Environment.NewLine +
                    "        @Archive = 0" + Environment.NewLine +
                    "SELECT	@return_value");
                    */

                    if (code.Equals(0))
                    {
                        sys_entity.Archived = !sys_entity.Archived;
                        btnArchive.Caption = sys_entity.Archived ? "Un-Archive" : "Archive";
                    }
                    else
                    {
                        Essential.BaseAlert.ShowAlert("Archive", "Entity could not be un-archived.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }


                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
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

                orgEntity = BL.ORG.ORG_Entity.New;
                orgEntitySYSEntity = BL.SYS.SYS_Entity.NewCompany;
                orgEntitySYSEntity.CodeSub = "00000";
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();

            BindingSource.DataSource = (DB.ORG_Entity)orgEntity;
            BindingSourceEntity.DataSource = (DB.SYS_Entity)orgEntitySYSEntity;
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
                base.OpenRecord(Id);

                orgEntitySYSEntity = BL.SYS.SYS_Entity.Load(Id, DataContext);
                orgEntity = BL.ORG.ORG_Entity.LoadByEntity(Id, DataContext, new List<string>() { "ORG_Company" });
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

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            orgEntitySYSEntity.Title = "New Entity";
                            BL.EntityController.SaveSYS_Entity(orgEntitySYSEntity, DataContext);
                            if (orgEntitySYSEntity.ChangeList.Contains("Name") && BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                                BL.SYS.SYS_Entity.AllignCompanyAccountNames(orgEntitySYSEntity, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            orgEntity.EntityId = orgEntitySYSEntity.Id;
                            BL.EntityController.SaveORG_Entity(orgEntity, DataContext);
                            DataContext.SaveChangesEntityOrganisationContext();
                            // If this is the first time you are saving this ORG Entity, it needs to get a new Code Sub.
                            if (orgEntitySYSEntity.CodeSub == "00000")
                                BL.SYS.SYS_Entity.AssignNewCodeSub(orgEntitySYSEntity.Id, DataContext);
                            DataContext.EntitySystemContext.Entry(orgEntitySYSEntity).Reload();
                            orgEntitySYSEntity.HasChanges = false;
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        btnCreateCustomer.Visibility = !orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Customer) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                        btnCreateSupplier.Visibility = !orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                        btnViewCustomer.Visibility = orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Customer) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                        btnViewSupplier.Visibility = orgEntity.ORG_Company.Any(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                CurrentException = ex;
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

        /// <summary>
        /// Checks that the Entity had a name.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 24/05/2013</remarks>
        private bool IsEntityNameValid()
        {
            try
            {
                if (txtName.Text.Length == 0)
                {
                    txtName.ErrorText = "Enter Account Name...";
                    return false;
                }
                else
                {
                    txtName.ErrorText = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
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
                isValid = IsEntityNameValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private void btnCreateCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer.CustomerForm childForm = new Customer.CustomerForm();
            childForm.Type = BL.ORG.ORG_Type.Customer;
            childForm.orgEntityId = ((DB.ORG_Entity)BindingSource.DataSource).Id;
            this.Close();
            ShowForm(childForm);
        }

        private void btnCreateSupplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Supplier.SupplierForm childForm = new Supplier.SupplierForm();
            childForm.Type = BL.ORG.ORG_Type.Supplier;
            childForm.orgEntityId = ((DB.ORG_Entity)BindingSource.DataSource).Id;
            this.Close();
            ShowForm(childForm);
        }

        private void btnViewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer.CustomerForm childForm = new Customer.CustomerForm(orgEntity.ORG_Company.FirstOrDefault(n => n.TypeId == (byte)BL.ORG.ORG_Type.Customer).Id);
            this.Close();
            ShowForm(childForm);
        }

        private void btnViewSupplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Supplier.SupplierForm childForm = new Supplier.SupplierForm(orgEntity.ORG_Company.FirstOrDefault(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier).Id);
            this.Close();
            ShowForm(childForm);
        }
    }
}
