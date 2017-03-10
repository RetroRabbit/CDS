using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_Entity
    {
        private static DB.SYS_Entity New
        {
            get
            {
                DB.SYS_Entity entry = new DB.SYS_Entity() { Title = "New Entity", Archived = false };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.SYS_Entity NewCompany
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Company";
                entry.CodeMain = string.Empty;
                entry.CodeSub = string.Empty;
                entry.ShortName = string.Empty;
                entry.Description = string.Empty;
                entry.TypeId = (byte)SYS.SYS_Type.Company;
                return entry;
            }
        }

        public static DB.SYS_Entity NewInventory
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Item";
                entry.ShortName = "New Item";
                entry.CodeMain = string.Empty;
                entry.CodeSub = string.Empty;
                entry.TypeId = (byte)SYS.SYS_Type.Inventory;
                return entry;
            }
        }

        public static DB.SYS_Entity NewAccount
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Account";
                entry.ShortName = string.Empty;
                entry.Description = string.Empty;
                entry.TypeId = (byte)SYS.SYS_Type.Account;
                return entry;
            }
        }

        public static DB.SYS_Entity NewMessage
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Message";
                entry.ShortName = "New Message";
                entry.Description = string.Empty;
                entry.CodeMain = string.Empty;
                entry.CodeSub = string.Empty; 
                entry.TypeId = (byte)SYS.SYS_Type.Message;
                return entry;
            }
        }

        public static DB.SYS_Entity NewBuyOut
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Buy Out Item";
              
                entry.CodeMain = string.Empty;
                entry.CodeSub = string.Empty;
                entry.TypeId = (byte)SYS.SYS_Type.BuyOut;
                return entry;
            }
        }

        public static DB.SYS_Entity NewSurcharge
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Surcharge Item";
                entry.CodeMain = string.Empty;
                entry.CodeSub = string.Empty;
                entry.TypeId = (byte)SYS.SYS_Type.Surcharge;
                return entry;
            }
        }

        public static DB.SYS_Entity NewConsignment
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Consignment Item"; 
                entry.TypeId = (byte)SYS.SYS_Type.Consignment;
                return entry;
            }
        }

        public static DB.SYS_Entity NewCenter
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Center";
                entry.TypeId = (byte)SYS.SYS_Type.Center;
                return entry;
            }
        }

        public static DB.SYS_Entity NewSite
        {
            get
            {
                DB.SYS_Entity entry = New;
                entry.Title = "New Site";
                entry.CodeSub = "00000";
                entry.TypeId = (byte)SYS.SYS_Type.Site;
                return entry;
            }
        }

        public static DB.SYS_Entity NewCustomerAccountEntity
        {
            get
            {
                DB.SYS_Entity entry = NewAccount;
                //entry.CodeMain = ApplicationDataContext.Instance.SiteAccounts.Debtors.SYS_Entity.CodeMain;
                entry.CodeSub = "00000";
                return entry;
            }
        }

        public static DB.SYS_Entity NewSupplierAccountEntity
        {
            get
            {
                DB.SYS_Entity entry = NewAccount;
                //entry.CodeMain = ApplicationDataContext.Instance.SiteAccounts.Debtors.SYS_Entity.CodeMain;
                entry.CodeSub = "00000";
                return entry;
            }
        }

        public static DB.SYS_Entity Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Entity.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Entity Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.SYS_Entity LoadCompanyDebtorEntity(string code, DataContext dataContext)
        {
            String CodeMain = ApplicationDataContext.Instance.SiteAccounts.DebtorsEntity.CodeMain;
            return dataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.CodeMain == CodeMain 
                && n.CodeSub == code && n.TypeId == (byte)SYS.SYS_Type.Account);
        }

        public static DB.SYS_Entity LoadCompanyCreditorEntity(string code, DataContext dataContext)
        {
            String CodeMain = ApplicationDataContext.Instance.SiteAccounts.CreditorsEntity.CodeMain;
            return dataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.CodeMain == CodeMain
                && n.CodeSub == code && n.TypeId == (byte)SYS.SYS_Type.Account);
        }

        internal static String Save(DB.SYS_Entity entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Entity.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_Entity GetNextItem(DB.SYS_Entity entry, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Entity.OrderBy(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(entry.Name) > 0 && n.TypeId == entry.TypeId);
        }

        public static DB.SYS_Entity GetPreviousItem(DB.SYS_Entity entry, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Entity.OrderByDescending(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(entry.Name) < 0 && n.TypeId == entry.TypeId);
        }

        public static int AssignNewCodeSub(Int64 entryId, DataContext DataContext)
        {
            return DataContext.EntitySystemContext.ExecuteSqlCommand(string.Format("EXEC CDS_SYS.spAssignNewCodeSub {0}", entryId));
        }

        public static DB.SYS_Entity CreateORG_CompanySYS_Entity(byte typeId, string codeSub, string description, string name, DataContext dataContext)
        {
            DB.SYS_Entity sys_entity = null;

            switch (typeId)
            {
                case (byte)ORG.ORG_Type.Customer:
                    sys_entity = SYS.SYS_Entity.NewCustomerAccountEntity;
                    sys_entity.CodeMain = SYS.SYS_Entity.Load(ApplicationDataContext.Instance.SiteAccounts.Debtors.EntityId, dataContext).CodeMain;
                    break;
                case (byte)ORG.ORG_Type.Supplier:
                    sys_entity = SYS.SYS_Entity.NewSupplierAccountEntity;
                    sys_entity.CodeMain = SYS.SYS_Entity.Load(ApplicationDataContext.Instance.SiteAccounts.Creditors.EntityId, dataContext).CodeMain;
                    break;
            }

            sys_entity.CodeSub = codeSub;
            sys_entity.Description = description;
            sys_entity.Name = name;

            return sys_entity;
        }

        public static DB.SYS_Entity LoadControlEntityByCode(string codeMain, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.CodeMain == codeMain && n.CodeSub == "00000" && n.TypeId == (byte)SYS.SYS_Type.Account);
        }

        public static void AllignCompanyAccountNames(DB.SYS_Entity entry, DataContext dataContext)
        {
            DB.SYS_Entity sysCompany = dataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.CodeMain.Equals(String.Empty) && n.CodeSub == entry.CodeSub && n.TypeId == (byte)SYS.SYS_Type.Company);
            String CustomerAccountCode = SYS.SYS_Entity.Load(ApplicationDataContext.Instance.SiteAccounts.Debtors.EntityId, dataContext).CodeMain;
            String SupplierAccountCode = SYS.SYS_Entity.Load(ApplicationDataContext.Instance.SiteAccounts.Creditors.EntityId, dataContext).CodeMain;
            DB.SYS_Entity sysCustomerAccount = dataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.CodeMain == CustomerAccountCode && n.CodeSub == entry.CodeSub && n.CodeSub != "00000" && n.TypeId == (byte)SYS.SYS_Type.Account);
            DB.SYS_Entity sysSupplierAccount = dataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.CodeMain == SupplierAccountCode && n.CodeSub == entry.CodeSub && n.CodeSub != "00000" && n.TypeId == (byte)SYS.SYS_Type.Account);
            if (sysCompany != null)
                sysCompany.Name = entry.Name;
            if (sysCustomerAccount != null)
                sysCustomerAccount.Name = entry.Name;
            if (sysSupplierAccount != null)
                sysSupplierAccount.Name = entry.Name;
        }
    }
}
