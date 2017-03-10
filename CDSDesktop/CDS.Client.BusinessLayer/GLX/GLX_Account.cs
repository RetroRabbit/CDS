using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.GLX
{
    public class GLX_Account
    {

        public static DB.GLX_Account New
        {
            get
            {
                DB.GLX_Account entry = new DB.GLX_Account() { /*SYS_Entity = SYS.SYS_Entity.NewAccount,*/ AgingAccount = false, IsNewAccount = true };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.SiteId = ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                return entry;
            }
        }

        public static DB.GLX_Account NewCustomerAccount
        {
            get
            {
                DB.GLX_Account entry = new DB.GLX_Account()
                {
                    AgingAccount = true,
                    AccountTypeId = (int)GLX.GLX_Type.CurrentAssets
                };

                entry.ControlId = ApplicationDataContext.Instance.SiteAccounts.Debtors.EntityId;
                entry.MasterControlId = ApplicationDataContext.Instance.SiteAccounts.Debtors.EntityId;
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.SiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                return entry;
            }
        }

        public static DB.GLX_Account NewSupplierAccount
        {
            get
            {
                DB.GLX_Account entry = new DB.GLX_Account()
                {
                    AgingAccount = true,
                    AccountTypeId = (int)GLX.GLX_Type.CurrentLiabilities
                };
                entry.ControlId = ApplicationDataContext.Instance.SiteAccounts.Creditors.EntityId;
                entry.MasterControlId = ApplicationDataContext.Instance.SiteAccounts.Creditors.EntityId;
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.SiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                return entry;
            }
        }

        public static DB.GLX_Account Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_Account.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_Account Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.GLX_Account LoadByEntityId(Int64 EntityId, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_Account.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.EntityId == EntityId);
        }

        public static DB.GLX_Account LoadByEntityId(Int64 EntityId, DataContext dataContext)
        {
            return LoadByEntityId(EntityId, dataContext, null);
        }

        internal static String Save(DB.GLX_Account entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_Account.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.GLX_Account GetNextItem(DB.GLX_Account glx_account, DataContext dataContext)
        //{
        //    return dataContext.EntityAccountingContext.GLX_Account.OrderBy(o => o.SYS_Entity.CodeMain).ThenBy(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(glx_account.SYS_Entity.CodeMain) > 0 && n.SYS_Entity.CodeMain.CompareTo(glx_account.SYS_Entity.CodeMain) != 0 && n.SYS_Entity.CodeSub.CompareTo(glx_account.SYS_Entity.CodeSub) > 0 && n.SYS_Entity.CodeSub.CompareTo(glx_account.SYS_Entity.CodeSub) != 0);
        //}

        //public static DB.GLX_Account GetPreviousItem(DB.GLX_Account glx_account, DataContext dataContext)
        //{
        //    return dataContext.EntityAccountingContext.GLX_Account.OrderByDescending(o => o.SYS_Entity.CodeMain).ThenByDescending(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(glx_account.SYS_Entity.CodeMain) < 0 && n.SYS_Entity.CodeMain.CompareTo(glx_account.SYS_Entity.CodeMain) != 0 && n.SYS_Entity.CodeSub.CompareTo(glx_account.SYS_Entity.CodeSub) < 0 && n.SYS_Entity.CodeSub.CompareTo(glx_account.SYS_Entity.CodeSub) != 0);
        //}

        public static DB.GLX_Account CreateORG_CompanyGLX_Account(byte typeId, string codeSub, string description, string name)
        {
            DB.GLX_Account glx_account = null;

            switch (typeId)
            {
                case (byte)ORG.ORG_Type.Customer:
                    glx_account = BL.GLX.GLX_Account.NewCustomerAccount;
                    break;
                case (byte)ORG.ORG_Type.Supplier:
                    glx_account = BL.GLX.GLX_Account.NewSupplierAccount;
                    break;
            }

            return glx_account;
        }

        public static DB.GLX_Account LoadControlAccountByCode(string codeMain, DataContext dataContext)
        {
            var returnAccountId = dataContext.EntitySystemContext.SYS_Entity.Where(n => n.CodeMain == codeMain && n.CodeSub == "00000" && n.TypeId == (byte)BL.SYS.SYS_Type.Account).Select(n=>n.Id).FirstOrDefault();
            return dataContext.EntityAccountingContext.GLX_Account.FirstOrDefault(n => n.EntityId == returnAccountId);
        }
    }
}