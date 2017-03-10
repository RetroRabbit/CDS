using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.HRS
{
    public class HRS_Role
    {

        public static DB.HRS_Role New
        {
            get
            {
                DB.HRS_Role entry = new DB.HRS_Role() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        } 

        public static DB.HRS_Role Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityHumanResourcesContext.HRS_Role.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.HRS_Role Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null); 
        } 

        internal static String Save(DB.HRS_Role entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityHumanResourcesContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityHumanResourcesContext.HRS_Role.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }  
    }
}
