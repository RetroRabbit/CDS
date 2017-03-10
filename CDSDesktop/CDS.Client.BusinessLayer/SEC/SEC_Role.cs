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
    public class SEC_Role
    {
        public static DB.SEC_Role New
        {
            get
            {
                DB.SEC_Role entry = new DB.SEC_Role();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.SEC_Role Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySecurityContext.SEC_Role.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SEC_Role Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SEC_Role entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySecurityContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySecurityContext.SEC_Role.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SEC_Role GetNextItem(DB.SEC_Role sec_role, DataContext dataContext)
        {
            return dataContext.EntitySecurityContext.SEC_Role.OrderBy(o => o.Code).FirstOrDefault(n => n.Code.CompareTo(sec_role.Code) > 0 && n.Code.CompareTo(sec_role.Code) != 0);
        }

        public static DB.SEC_Role GetPreviousItem(DB.SEC_Role sec_role, DataContext dataContext)
        {
            return dataContext.EntitySecurityContext.SEC_Role.OrderByDescending(o => o.Code).FirstOrDefault(n => n.Code.CompareTo(sec_role.Code) < 0 && n.Code.CompareTo(sec_role.Code) != 0);
        }

        public static void UpdateAccessModifiedFlags(DB.SEC_Role secRole)
        {
            //TODO : Make this work again
            //secRole.AccessModifiedOn = DateTime.Now;
            //secRole.AccessModifiedBy = ApplicationDataContext.Instance.LoggedInUser.DisplayName;

            //dataContext.EntityContext.SaveChanges();
        }
    }
}
