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
    public class SYS_Surcharge
    {

        public static DB.SYS_Surcharge New
        {
            get
            {
                DB.SYS_Surcharge entry = new DB.SYS_Surcharge();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId; 
                return entry;
            }
        }

        public static DB.SYS_Surcharge Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Surcharge.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Surcharge Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SYS_Surcharge entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Surcharge.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.SYS_Surcharge GetNextItem(DB.SYS_Surcharge SYS_Surcharge, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Surcharge.OrderBy(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(SYS_Surcharge.Name) > 0 && n.Name.CompareTo(SYS_Surcharge.Name) != 0);
        //}
        //
        //public static DB.SYS_Surcharge GetPreviousItem(DB.SYS_Surcharge SYS_Surcharge, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Surcharge.OrderByDescending(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(SYS_Surcharge.Name) < 0 && n.Name.CompareTo(SYS_Surcharge.Name) != 0);
        //}


        public static DB.SYS_Surcharge LoadByEntityId(Int64 EntityId, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Surcharge.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.EntityId == EntityId);
        }

        public static DB.SYS_Surcharge LoadByEntityId(Int64 EntityId, DataContext dataContext)
        {
            return LoadByEntityId(EntityId, dataContext, null);
        }
    }
}
