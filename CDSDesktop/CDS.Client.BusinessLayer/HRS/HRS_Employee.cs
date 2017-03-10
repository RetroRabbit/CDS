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
    public class HRS_Employee
    {

        public static DB.HRS_Employee New
        {
            get
            {
                DB.HRS_Employee entry = new DB.HRS_Employee() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        } 

        public static DB.HRS_Employee Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityHumanResourcesContext.HRS_Employee.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.HRS_Employee Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null); 
        }

        public static DB.HRS_Employee LoadByPerson(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityHumanResourcesContext.HRS_Employee.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.PersonId == Id);
        }

        public static DB.HRS_Employee LoadByPerson(Int64 Id, DataContext dataContext)
        {
            return LoadByPerson(Id, dataContext, null); 
        }

        internal static String Save(DB.HRS_Employee entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityHumanResourcesContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityHumanResourcesContext.HRS_Employee.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        } 
    }
}
