using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_Person
    {
        public static DB.SYS_Person New
        {
            get
            {
                DB.SYS_Person entry = new DB.SYS_Person();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        internal static String Save(DB.SYS_Person entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Person.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_Person Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Person.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Person Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        public static DB.SYS_Person GetNextItem(DB.SYS_Person SYS_Person, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Person.OrderBy(o => o.Fullname).FirstOrDefault(n => n.Fullname.CompareTo(SYS_Person.Fullname) > 0 && n.Fullname.CompareTo(SYS_Person.Fullname) != 0);
        }

        public static DB.SYS_Person GetPreviousItem(DB.SYS_Person SYS_Person, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Person.OrderByDescending(o => o.Fullname).FirstOrDefault(n => n.Fullname.CompareTo(SYS_Person.Fullname) < 0 && n.Fullname.CompareTo(SYS_Person.Fullname) != 0);
        } 
    }
}
