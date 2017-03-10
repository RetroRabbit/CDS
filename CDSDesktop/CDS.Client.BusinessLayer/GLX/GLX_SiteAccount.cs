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
    public class GLX_SiteAccount
    {

        public static DB.GLX_SiteAccount New
        {
            get
            {
                DB.GLX_SiteAccount entry = new DB.GLX_SiteAccount() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.GLX_SiteAccount Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_SiteAccount.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_SiteAccount Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        public static DB.GLX_SiteAccount LoadByAccount(Int64 EntityId, DataContext dataContext)
        {
            return dataContext.EntityAccountingContext.GLX_SiteAccount.FirstOrDefault(n => n.EntityId == EntityId);
        } 

        internal static String Save(DB.GLX_SiteAccount entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_SiteAccount.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static String Delete(DB.GLX_SiteAccount entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) != System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_SiteAccount.Remove(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.GLX_SiteAccount GetNextItem(DB.GLX_SiteAccount GLX_SiteAccount, DataContext dataContext)
        //{
        //    return dataContext.EntityAccountingContext.GLX_SiteAccount.OrderBy(o => o.SYS_Entity.CodeMain).ThenBy(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(GLX_SiteAccount.SYS_Entity.CodeMain) > 0 && n.SYS_Entity.CodeMain.CompareTo(GLX_SiteAccount.SYS_Entity.CodeMain) != 0 && n.SYS_Entity.CodeSub.CompareTo(GLX_SiteAccount.SYS_Entity.CodeSub) > 0 && n.SYS_Entity.CodeSub.CompareTo(GLX_SiteAccount.SYS_Entity.CodeSub) != 0);
        //}

        //public static DB.GLX_SiteAccount GetPreviousItem(DB.GLX_SiteAccount GLX_SiteAccount, DataContext dataContext)
        //{
        //    return dataContext.EntityAccountingContext.GLX_SiteAccount.OrderByDescending(o => o.SYS_Entity.CodeMain).ThenByDescending(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(GLX_SiteAccount.SYS_Entity.CodeMain) < 0 && n.SYS_Entity.CodeMain.CompareTo(GLX_SiteAccount.SYS_Entity.CodeMain) != 0 && n.SYS_Entity.CodeSub.CompareTo(GLX_SiteAccount.SYS_Entity.CodeSub) < 0 && n.SYS_Entity.CodeSub.CompareTo(GLX_SiteAccount.SYS_Entity.CodeSub) != 0);
        //}
    }
}
