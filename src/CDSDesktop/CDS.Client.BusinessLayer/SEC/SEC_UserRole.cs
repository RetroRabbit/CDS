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
    public class SEC_UserRole
    {
        public static DB.SEC_UserRole New
        {
            get
            {
                DB.SEC_UserRole entry = new DB.SEC_UserRole();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.SEC_UserRole Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySecurityContext.SEC_UserRole.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SEC_UserRole Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.SEC_UserRole entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySecurityContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySecurityContext.SEC_UserRole.Add(entry); 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static void DeleteUserRole(DB.SEC_UserRole sec_userrole, DataContext dataContext)
        {
            dataContext.EntitySecurityContext.SEC_UserRole.Remove(sec_userrole);
            //dataContext.EntityContext.SaveChanges();
        }
    }

}
