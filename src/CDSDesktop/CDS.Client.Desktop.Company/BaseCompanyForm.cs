using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Company
{
    public partial class BaseCompanyForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.SYS_Entity orgEntitysysEntity;
        DB.ORG_Entity orgEntity;
        DB.ORG_Company orgCompany;
        DB.ORG_Distribution orgDistribution;
        DB.ORG_CompanyAddress orgBillingAddress;
        DB.ORG_CompanyAddress orgShippingAddress;
        DB.SYS_Address sysBillingAddress;
        DB.SYS_Address sysShippingAddress;
        DB.ORG_Contact orgSalesContact;
        DB.ORG_Contact orgAccountsContact;

        [BrowsableAttribute(true)]
        public BL.ORG.ORG_Type Type { get; set; }

        [DefaultValue(null)]
        private Int64? OldSalesContact { get; set; }

        [DefaultValue(null)]
        private Int64? OldAccountsContact { get; set; }

        public Int64 orgEntityId { get; set; }

        public DB.ORG_Company OrgCompany { get { return orgCompany; } }

        protected string CompanyCode { get { return ((DB.SYS_Entity)BindingSourceORGEntitySYSEntity.DataSource).CodeSub; } }

        /// <summary>
        /// Boolean that returns true if Company has never been submited to the database (Is a new Company)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (orgCompany != null)
                    return (DataContext.EntityOrganisationContext.GetEntityState(orgCompany) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public BaseCompanyForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            AllowRefresh = true;

            ServerModeSourceCostCategory.QueryableSource = DataContext.EntityOrganisationContext.ORG_CostCategory;
            ServerModeSourcePaymentTerm.QueryableSource = DataContext.EntityOrganisationContext.ORG_PaymentTerm;
            ServerModeSourceStatementPreference.QueryableSource = DataContext.EntityOrganisationContext.ORG_StatementPreference;
            ServerModeSourceContactSales.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == orgEntitysysEntity.Id) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Sales);
            ServerModeSourceContactAccount.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == orgEntitysysEntity.Id) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Accounts);
            ServerModeSourceDistributionType.QueryableSource = DataContext.EntityOrganisationContext.ORG_DistributionType;
            ServerModeSourceDocumentType.QueryableSource = DataContext.EntitySystemContext.SYS_DOC_Type;
            ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;

            tcgInformation.SelectedTabPage = tabAccountingInformation;
            tcgInformation.SelectedTabPage = tabAddressInformation;
            tcgInformation.SelectedTabPage = tabTransactions;
            tcgInformation.SelectedTabPage = tabGeneralInformation;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!DesignMode)
            {
                //if (((DB.ORG_Company)BindingSource.DataSource).StatementPreference != null)
                //    for (int i = 0; i < clbStatementPreferenceo.ItemCount; i++)
                //    {
                //        if (((DB.ORG_Company)BindingSource.DataSource).StatementPreference.Contains((clbStatementPreferenceo.GetItem(i) as DB.ORG_StatementPreference).Id.ToString()))
                //            clbStatementPreferenceo.SetItemChecked(i, true);
                //    }

                clbDocumentType.CheckAll();

                for (int i = 0; i < clbDocumentType.ItemCount; i++)
                {
                    if ((clbDocumentType.GetItem(i) as DB.SYS_DOC_Type).Id == (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder
                        || (clbDocumentType.GetItem(i) as DB.SYS_DOC_Type).Id == (byte)BL.SYS.SYS_DOC_Type.Quote
                        || (clbDocumentType.GetItem(i) as DB.SYS_DOC_Type).Id == (byte)BL.SYS.SYS_DOC_Type.SalesOrder)
                    {
                        clbDocumentType.SetItemChecked(i, false);
                        break;
                    }
                }
                InstantFeedbackSourceTransaction.Refresh();
                switch (Type)
                {
                    case BL.ORG.ORG_Type.Customer:
                        {
                            lcgGeneral.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                            lcgTeccomDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        }
                        break;
                    case BL.ORG.ORG_Type.Supplier:
                        {
                            lcgCustomerGeneral.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        }
                        break;
                }
                Essential.GridFilterDefaults.ApplyStandards(new List<DevExpress.XtraGrid.Views.Grid.GridView> { grvTransactions });
                grvTransactions.ActiveFilterString = "Not [DocumentType] In ('Sales Order', 'Quote', 'Purchase Order')";
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSourceORGEntity.DataSource = orgEntity;
            BindingSourceORGEntitySYSEntity.DataSource = orgEntitysysEntity;
            BindingSource.DataSource = orgCompany;
            BindingSourceORGDistribution.DataSource = orgDistribution;
            BindingSourceCompanyBillingAddress.DataSource = orgBillingAddress;
            BindingSourceCompanyShippingAddress.DataSource = orgShippingAddress;
            BindingSourceBillingAddress.DataSource = sysBillingAddress;
            BindingSourceShippingAddress.DataSource = sysShippingAddress;
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            orgEntity = BL.ORG.ORG_Entity.Load(orgEntityId, DataContext, new List<string> { });
            orgEntitysysEntity = BL.SYS.SYS_Entity.Load(orgEntity.EntityId, DataContext);
            switch (Type)
            {
                case BL.ORG.ORG_Type.Customer:
                    {
                        orgCompany = BL.ORG.ORG_Company.NewCustomerCompany;
                        orgCompany.ORG_Entity = orgEntity;
                    }
                    break;
                case BL.ORG.ORG_Type.Supplier:
                    {
                        orgCompany = BL.ORG.ORG_Company.NewSupplierCompany;
                        orgCompany.ORG_Entity = orgEntity;
                    }
                    break;
            }

            if (orgCompany.ORG_Distribution.Count == 0)
            {
                orgDistribution = BL.ORG.ORG_Distribution.New;
                orgCompany.ORG_Distribution.Add(orgDistribution);
            }
            else
            {
                orgDistribution = orgCompany.ORG_Distribution.FirstOrDefault();
            }
            orgBillingAddress = BL.ORG.ORG_CompanyAddress.NewCompanyBillingAddress;
            orgShippingAddress = BL.ORG.ORG_CompanyAddress.NewCompanyShippingAddress;
            orgCompany.ORG_CompanyAddress.Add(orgBillingAddress);
            orgCompany.ORG_CompanyAddress.Add(orgShippingAddress);
            sysBillingAddress = BL.SYS.SYS_Address.NewBillingAddress;
            sysShippingAddress = BL.SYS.SYS_Address.NewShippingAddress;
            orgCompany.SiteId = Convert.ToInt64(BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);

            if (BL.ORG.ORG_Contact.LoadSalesContact(orgEntitysysEntity.Id, DataContext) != null)
            {
                orgSalesContact = BL.ORG.ORG_Contact.LoadSalesContact(orgEntitysysEntity.Id, DataContext);
            }
            //else
            //{
            //    orgSalesContact = BL.ORG.ORG_Contact.NewSalesContact;
            //}
            
            if (BL.ORG.ORG_Contact.LoadAccountsContact(orgEntitysysEntity.Id, DataContext) != null)
            {
                orgAccountsContact = BL.ORG.ORG_Contact.LoadAccountsContact(orgEntitysysEntity.Id, DataContext);
            }
            //else
            //{
            //    orgAccountsContact = BL.ORG.ORG_Contact.NewAccountsContact;
            //}
        }

        public override void OpenRecord(long Id)
        {
            try
            {
                base.OpenRecord(Id);
                orgCompany = BL.ORG.ORG_Company.Load(Id, DataContext, new List<string>() { "ORG_Entity" });
                orgEntity = (DB.ORG_Entity)orgCompany.ORG_Entity;
                orgEntitysysEntity = BL.SYS.SYS_Entity.Load(orgEntity.EntityId, DataContext);
                if (BL.ORG.ORG_Contact.LoadSalesContact(orgEntitysysEntity.Id, DataContext) != null)
                {
                    orgSalesContact = BL.ORG.ORG_Contact.LoadSalesContact(orgEntitysysEntity.Id, DataContext);
                    ddlSalesContact.EditValue = orgSalesContact.Id;
                }
                //else
                //{
                //    orgSalesContact = BL.ORG.ORG_Contact.NewSalesContact;
                //}
                if (BL.ORG.ORG_Contact.LoadAccountsContact(orgEntitysysEntity.Id, DataContext) != null)
                {
                    orgAccountsContact = BL.ORG.ORG_Contact.LoadAccountsContact(orgEntitysysEntity.Id, DataContext);
                    ddlAccountContact.EditValue = orgAccountsContact.Id;
                }
                //else
                //{
                //    orgAccountsContact = BL.ORG.ORG_Contact.NewAccountsContact;
                //}

                orgDistribution = DataContext.EntityOrganisationContext.ORG_Distribution.FirstOrDefault(n => n.EntityId == orgCompany.Id);
                var orgCompanyAddress = DataContext.EntityOrganisationContext.ORG_CompanyAddress.Where(n => n.CompanyId == orgCompany.Id && n.AddressId.HasValue == true);
                List<Int64> addressIds = orgCompanyAddress.Select(l => l.AddressId.Value).ToList();
                var sysAddress = DataContext.EntitySystemContext.SYS_Address.Where(n => addressIds.Contains(n.Id)).ToList();
                sysBillingAddress = sysAddress.FirstOrDefault(n => n.TypeId == (byte)BL.SYS.SYS_Type.BillingAddress);
                orgBillingAddress = orgCompanyAddress.FirstOrDefault(n => n.AddressId == sysBillingAddress.Id && n.CompanyId == orgCompany.Id);
                sysShippingAddress = sysAddress.FirstOrDefault(n => n.TypeId == (byte)BL.SYS.SYS_Type.ShippingAddress);
                orgShippingAddress = orgCompanyAddress.FirstOrDefault(n => n.AddressId == sysShippingAddress.Id && n.CompanyId == orgCompany.Id);
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

                    //orgCompany.StatementPreference = "";
                    //for (int i = 0; i < clbStatementPreference.ItemCount; i++)
                    //{
                    //    string value = (clbStatementPreference.GetItem(i) as DB.ORG_StatementPreference).Id.ToString();
                    //    orgCompany.StatementPreference = String.Format("{0}{1}", orgCompany.StatementPreference, clbStatementPreference.GetItemChecked(i) ? value + "," : "");
                    //}

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            //Link the ORG_Company entities to the ORG_Entity's SYS_Entity 
                            if (orgSalesContact != null)
                            {
                                orgSalesContact.IsDefault = true;
                                orgSalesContact.CompanyId = orgEntitysysEntity.Id;
                            }
                            if (orgAccountsContact != null)
                            {
                                orgAccountsContact.IsDefault = true;
                                orgAccountsContact.CompanyId = orgEntitysysEntity.Id;
                            }

                            if (OldSalesContact != null && ddlSalesContact.EditValue != null && OldSalesContact != Convert.ToInt64(ddlSalesContact.EditValue))
                                BL.ORG.ORG_Contact.RemoveContact(OldSalesContact.Value, DataContext);

                            if (OldAccountsContact != null && ddlAccountContact.EditValue != null && OldAccountsContact != Convert.ToInt64(ddlAccountContact.EditValue))
                                BL.ORG.ORG_Contact.RemoveContact(OldAccountsContact.Value, DataContext);

                            if (IsNew)
                            {
                                //Maybe dont allow change of SYS_Entity
                                BL.EntityController.SaveSYS_Entity(orgEntitysysEntity, DataContext);
                                DataContext.SaveChangesEntitySystemContext(); 
                                BL.EntityController.SaveORG_Company(orgCompany, DataContext);
                                DataContext.SaveChangesEntityOrganisationContext();
                                BL.EntityController.SaveSYS_Address(sysBillingAddress, DataContext);
                                BL.EntityController.SaveSYS_Address(sysShippingAddress, DataContext);
                                DataContext.SaveChangesEntitySystemContext();
                                //Links the SYS_Access entities to the ORG_CompanyAddress entities
                                orgBillingAddress.AddressId = sysBillingAddress.Id;
                                orgShippingAddress.AddressId = sysShippingAddress.Id;
                                BL.EntityController.SaveORG_CompanyAddress(orgBillingAddress, DataContext);
                                BL.EntityController.SaveORG_CompanyAddress(orgShippingAddress, DataContext);
                                //Save changes to the ORG_Company Entity
                                BL.EntityController.SaveORG_Company(orgCompany, DataContext);
                                DataContext.SaveChangesEntityOrganisationContext();
                                BL.ORG.ORG_History.GenerateCompanyHistory(orgCompany, DataContext);
                                //If the GLX Module is accessable add and link GLX_Account and SYS_Entity to ORG_Company
                                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                                {
                                    DB.GLX_Account glxAccount = BL.GLX.GLX_Account.New;
                                    DB.SYS_Entity sysEntityAccount = BL.SYS.SYS_Entity.NewAccount;
                                    glxAccount.AgingAccount = true;
                                    switch (Type)
                                    {
                                        case BL.ORG.ORG_Type.Customer:
                                            DB.GLX_Account glxDebtor = BL.GLX.GLX_Account.LoadByEntityId(BL.ApplicationDataContext.Instance.SiteAccounts.Debtors.EntityId, DataContext);
                                            DB.SYS_Entity sysDebtor = BL.SYS.SYS_Entity.Load(BL.ApplicationDataContext.Instance.SiteAccounts.Debtors.EntityId, DataContext);
                                            sysEntityAccount.CodeMain = sysDebtor.CodeMain;
                                            glxAccount.AccountTypeId = glxDebtor.AccountTypeId;
                                            glxAccount.MasterControlId = sysDebtor.Id;
                                            break;
                                        case BL.ORG.ORG_Type.Supplier:
                                            DB.GLX_Account glxCreditor = BL.GLX.GLX_Account.LoadByEntityId(BL.ApplicationDataContext.Instance.SiteAccounts.Creditors.EntityId, DataContext);
                                            DB.SYS_Entity sysCreditor = BL.SYS.SYS_Entity.Load(BL.ApplicationDataContext.Instance.SiteAccounts.Creditors.EntityId, DataContext);
                                            sysEntityAccount.CodeMain = sysCreditor.CodeMain;
                                            glxAccount.AccountTypeId = glxCreditor.AccountTypeId;
                                            glxAccount.MasterControlId = sysCreditor.Id;
                                            break;
                                    }

                                    sysEntityAccount.CodeSub = orgEntitysysEntity.CodeSub;
                                    sysEntityAccount.Description = orgEntitysysEntity.Description;
                                    sysEntityAccount.Name = orgEntitysysEntity.Name;
                                    sysEntityAccount.ShortName = orgEntitysysEntity.ShortName;
                                    BL.EntityController.SaveSYS_Entity(sysEntityAccount, DataContext);
                                    DataContext.SaveChangesEntitySystemContext();
                                    glxAccount.EntityId = sysEntityAccount.Id;
                                    //ControlId Represents the Rollup Account
                                    //on New Accounts it is its own control
                                    glxAccount.ControlId = sysEntityAccount.Id;
                                    BL.EntityController.SaveGLX_Account(glxAccount, DataContext);
                                    DataContext.SaveChangesEntityAccountingContext();
                                    //orgCompany.AccountId = sysEntityAccount.Id;
                                    DataContext.SaveChangesEntityOrganisationContext();
                                }

                                DataContext.SaveChangesEntityOrganisationContext();
                                DataContext.SaveChangesEntityAccountingContext();
                                DataContext.SaveChangesEntitySystemContext();
                            }
                            else
                            {
                                if (orgEntitysysEntity.ChangeList.Contains("Name") && BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                                    BL.SYS.SYS_Entity.AllignCompanyAccountNames(orgEntitysysEntity, DataContext);
                                DataContext.SaveChangesEntityOrganisationContext();
                                DataContext.SaveChangesEntityAccountingContext();
                                DataContext.SaveChangesEntitySystemContext();
                                orgCompany.HasChanges = false;
                            }
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityOrganisationContext.AcceptAllChanges();
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                        DataContext.EntitySystemContext.AcceptAllChanges();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityOrganisationContext.RejectChanges();
                        DataContext.EntityAccountingContext.RejectChanges();
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

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        /// <summary>
        /// Checks that below conditions are valid.
        /// * Code Main doen not exist
        /// * Code Sub does not exist
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
                isValid = IsNameValid() && IsPaymentTermValid() && IsCostCategoryValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsNameValid()
        {
            bool isValid = true;
            
            if (IsNew)
            {
                isValid = DataContext.ReadonlyContext.VW_Company.Count(n => n.Name == txtName.Text && n.TypeId == (int)Type && n.SiteId == BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId) == 0;

                if (!isValid)
                {
                    Essential.BaseAlert.ShowAlert("Invalid Name", "There is already Company with the name \"" + orgEntitysysEntity.Name + "\" regestered to this site", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    txtName.ErrorText = "Duplicate Name not allowed";
                }
                else
                {
                    txtName.ErrorText = String.Empty;
                }
            }
            return isValid;
        }

        private bool IsCostCategoryValid()
        {
            bool isValid = true;
            isValid = OrgCompany.CostCategoryId != 0;

            if (!isValid)
            {
                ddlCostCategory.ErrorText = "Select Cost Category";
                tcgInformation.SelectedTabPage = tabAccountingInformation;
            }
            else
            {
                ddlCostCategory.ErrorText = String.Empty;
            }

            return isValid;
        }

        private bool IsPaymentTermValid()
        {
            bool isValid = true;
            isValid = OrgCompany.PaymentTermId != 0;

            if (!isValid)
            {
                ddlPaymentTerm.ErrorText = "Select Payment Term";
                tcgInformation.SelectedTabPage = tabAccountingInformation;
            }
            else
            {
                ddlPaymentTerm.ErrorText = String.Empty;
            }

            return isValid;
        }

        private List<Int64> TransactionsTypes
        {
            get
            {
                List<Int64> selectedDocumentTypes = new List<Int64>();

                for (int i = 0; i < clbDocumentType.ItemCount; i++)
                {
                    if (clbDocumentType.GetItemChecked(i))
                        selectedDocumentTypes.Add((clbDocumentType.GetItem(i) as DB.SYS_DOC_Type).Id);
                }

                return selectedDocumentTypes;
            }
        }

        protected override void Archive()
        {
            base.Archive();
            DB.SYS_Entity sysEntity = (DB.SYS_Entity)BindingSourceORGEntitySYSEntity.DataSource;

            if (sysEntity.Archived)
                sysEntity.Archived = !sysEntity.Archived;
            else
            {
                DB.VW_Company vwCompany = DataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.EntityId == sysEntity.Id);
                if (DataContext.EntityAccountingContext.GLX_History.Any(n => n.EntityId == sysEntity.Id && n.Amount != 0))
                {
                    Essential.BaseAlert.ShowAlert("Archive",
                        "This company can not be archive." + Environment.NewLine +
                        "\t• Account has outstanding balances.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                }
            }
            btnArchive.Caption = sysEntity.Archived ? "Un-Archive" : "Archive";
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

        public override void RefreshRecord()
        {
            base.RefreshRecord();

            if (IsNew)
            {
                ServerModeSourceContactSales.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == orgEntitysysEntity.Id) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Sales);
                ServerModeSourceContactSales.Reload();
                ServerModeSourceContactAccount.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == orgEntitysysEntity.Id) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Accounts);
                ServerModeSourceContactAccount.Reload();
            }
            else
            {
                DataContext.EntityOrganisationContext.ReloadEntry(BindingSource.DataSource);
                DataContext.EntityOrganisationContext.ReloadEntry(BindingSourceORGEntity.DataSource);
                DataContext.EntityOrganisationContext.ReloadEntry(orgSalesContact);
                DataContext.EntityOrganisationContext.ReloadEntry(orgAccountsContact);
                DataContext.EntitySystemContext.ReloadEntry(BindingSourceORGEntitySYSEntity.DataSource);
                DataContext.EntitySystemContext.ReloadEntry(BindingSourceShippingAddress.DataSource);
                DataContext.EntitySystemContext.ReloadEntry(BindingSourceBillingAddress.DataSource);
                DataContext.EntityOrganisationContext.ReloadEntry(BindingSourceORGDistribution.DataSource);
                InstantFeedbackSourceTransaction.Refresh();
                InstantFeedbackSourceHistory.Refresh();
                ServerModeSourceContactSales.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == orgEntitysysEntity.Id) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Sales);
                ServerModeSourceContactSales.Reload();
                ServerModeSourceContactAccount.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == orgEntitysysEntity.Id) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Accounts);
                ServerModeSourceContactAccount.Reload();
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE01));
            if (IsNew)
            {
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                AllowArchive = false;
            }
            switch (Type)
            {
                case BL.ORG.ORG_Type.Customer:
                    //Henko - TODO: Transactions option removed from roles. Need to be better implemented 
                    //lcgTransactions.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORCU04) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    ddlCostCategory.Enabled = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORCURE03);
                    ddlPaymentTerm.Enabled = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORCURE04);
                    break;
                case BL.ORG.ORG_Type.Supplier:
                    //Henko - TODO: Transactions option removed from roles. Need to be better implemented 
                    //lcgTransactions.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSU04) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    ddlCostCategory.Enabled = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSURE03);
                    ddlPaymentTerm.Enabled = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSURE04);
                    break;
            }

            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
            {
                if (IsNew)
                    chkOpenItem.Enabled = true;
                else
                {
                    string codeMain = null;
                    switch (Type)
                    {
                        case BL.ORG.ORG_Type.Customer: codeMain = BL.ApplicationDataContext.Instance.SiteAccounts.DebtorsEntity.CodeMain; 
                            break;
                        case BL.ORG.ORG_Type.Supplier: codeMain = BL.ApplicationDataContext.Instance.SiteAccounts.CreditorsEntity.CodeMain;
                            break;
                    }

                    chkOpenItem.Enabled = DataContext.ReadonlyContext.VW_Account.FirstOrDefault(n => n.CodeSub == orgEntitysysEntity.CodeSub && n.CodeMain == codeMain).Amount == 0;
                }
            }

            if (orgEntitysysEntity.Archived)
            {
                btnArchive.Caption = "Un-Archive";
            }
            else
            {
                btnArchive.Caption = "Archive";
            }
        }

        //private void clbStatementPreference_ItemChecking(object sender, DevExpress.XtraEditors.Controls.ItemCheckingEventArgs e)
        //{
        //    if ((clbStatementPreferenceo.GetItem(e.Index) as DB.ORG_StatementPreference).Id == (byte)BL.ORG.ORG_StatementPreference.Ignore && e.NewValue == CheckState.Checked)
        //    {
        //        clbStatementPreferenceo.UnCheckAll();
        //    }
        //    else if ((clbStatementPreferenceo.GetItem(e.Index) as DB.ORG_StatementPreference).Id != (byte)BL.ORG.ORG_StatementPreference.Ignore && e.NewValue == CheckState.Checked)
        //    {
        //        for (int i = 0; i < clbStatementPreferenceo.ItemCount; i++)
        //        {
        //            DB.ORG_StatementPreference pref = (clbStatementPreferenceo.GetItem(i) as DB.ORG_StatementPreference);
        //            if (pref.Id == (byte)BL.ORG.ORG_StatementPreference.Ignore && clbStatementPreferenceo.GetItemChecked(i))
        //                clbStatementPreferenceo.SetItemChecked(i, false);
        //        }
        //    }
        //}

        private void ddlSalesContact_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && Convert.ToString(e.Button.Tag).Equals("New"))
            {
                Contact.ContactDialogue childform = new Contact.ContactDialogue();
                childform.Department = BL.ORG.ORG_Department.Sales;
                childform.ShowDialog();
                if (childform.ORGContact != null)
                {
                    ServerModeSourceContactSales.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == childform.ORGContact.CompanyId) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Sales);
                    ServerModeSourceContactSales.Reload();
                    if (ddlSalesContact.EditValue != DBNull.Value && Convert.ToInt64(ddlSalesContact.EditValue) > 0)
                    {
                        OldSalesContact = Convert.ToInt64(ddlSalesContact.EditValue);
                    }

                    orgSalesContact = childform.ORGContact;
                    ddlSalesContact.EditValue = childform.ORGContact.Id;
                }
            }
        }

        private void ddlAccountContact_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && Convert.ToString(e.Button.Tag).Equals("New"))
            {
                Contact.ContactDialogue childform = new Contact.ContactDialogue();
                childform.Department = BL.ORG.ORG_Department.Accounts;
                childform.ShowDialog();

                if (childform.ORGContact != null)
                {
                    ServerModeSourceContactAccount.QueryableSource = DataContext.ReadonlyContext.VW_Contact.Where(n => (n.CompanyId == null || n.CompanyId == childform.ORGContact.CompanyId) && n.DepartmentId == (byte)BL.ORG.ORG_Department.Accounts);
                    ServerModeSourceContactAccount.Reload();
                    if (ddlAccountContact.EditValue != DBNull.Value && Convert.ToInt64(ddlAccountContact.EditValue) > 0)
                        OldAccountsContact = Convert.ToInt64(ddlAccountContact.EditValue);

                    orgAccountsContact = childform.ORGContact;
                    ddlAccountContact.EditValue = childform.ORGContact.Id;
                }
            }
        }

        private void txtPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (Essential.OpenFolderDialogue dialogue = new Essential.OpenFolderDialogue())
            {
                dialogue.ShowDialog();
                this.txtPath.Text = dialogue.FolderLocation;
            }
        }

        private void ddlSalesContact_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlSalesContact.OldEditValue != null && ddlSalesContact.OldEditValue != DBNull.Value && ddlSalesContact.OldEditValue.GetType() != typeof(System.String) && OldSalesContact == null && ddlSalesContact.OldEditValue != ddlSalesContact.EditValue && Convert.ToInt64(ddlSalesContact.OldEditValue) != 0)
                OldSalesContact = Convert.ToInt64(ddlSalesContact.OldEditValue);

            if (ddlSalesContact.EditValue != DBNull.Value && Convert.ToInt64(ddlSalesContact.EditValue) > 0)
                orgSalesContact = BL.ORG.ORG_Contact.Load((Int64)ddlSalesContact.EditValue, DataContext);
        }

        private void ddlAccountContact_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlAccountContact.OldEditValue != null && ddlAccountContact.OldEditValue != DBNull.Value && ddlAccountContact.OldEditValue.GetType() != typeof(System.String) && OldAccountsContact == null && ddlAccountContact.OldEditValue != ddlAccountContact.EditValue && Convert.ToInt64(ddlAccountContact.OldEditValue) != 0)
                OldAccountsContact = Convert.ToInt64(ddlAccountContact.OldEditValue);
            
            if (ddlAccountContact.EditValue != DBNull.Value && Convert.ToInt64(ddlAccountContact.EditValue) > 0)
                orgAccountsContact = BL.ORG.ORG_Contact.Load((Int64)ddlAccountContact.EditValue, DataContext);
        }

        private void ddlDistributionType_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlDistributionType.ItemIndex != -1 && Convert.ToInt64(ddlDistributionType.EditValue) == 2)
            {
                lcgTeccomDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lcgTeccomDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void InstantFeedbackSourceTransaction_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Transaction.Where(n => n.CompanyId == (((DB.ORG_Company)BindingSource.DataSource)).Id /*&& TransactionsTypes.Contains(n.TypeId.Value)*/);
        }

        private void InstantFeedbackSourceHistory_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            DB.SYS_Period currentPeriod = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext);
            DateTime dateAfter = DateTime.Today.AddYears(-2);
            e.QueryableSource = DataContext.ReadonlyContext.VW_CompanyHistory.Where(n => n.CompanyId == orgCompany.Id && n.Date > dateAfter && n.Date <= currentPeriod.EndDate);

        }

        private void grvTransactions_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRow() is DevExpress.Data.NotLoadedObject)
                return;

            ShowDocumentForm(
            (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(grvTransactions.GetFocusedRow())).OriginalRow as DB.VW_Transaction).DocumentId.Value,
                (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(grvTransactions.GetFocusedRow())).OriginalRow as DB.VW_Transaction).TypeId.Value);
        }
    }
}
