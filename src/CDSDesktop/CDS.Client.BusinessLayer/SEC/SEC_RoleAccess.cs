using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SEC
{
    public class SEC_RoleAccess
    {
        public static DB.SEC_RoleAccess New
        {
            get
            {
                DB.SEC_RoleAccess entry = new DB.SEC_RoleAccess();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.SEC_RoleAccess Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySecurityContext.SEC_RoleAccess.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SEC_RoleAccess Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.SEC_RoleAccess entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySecurityContext.SEC_RoleAccess.Add(entry); 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static void DeleteRoleAccess(DB.SEC_RoleAccess sec_roleaccess, DataContext dataContext)
        {
            dataContext.EntitySecurityContext.SEC_RoleAccess.Remove(sec_roleaccess); 
        }
    }
}
