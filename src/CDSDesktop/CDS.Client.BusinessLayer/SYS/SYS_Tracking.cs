using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_Tracking
    {
        public static DB.SYS_Tracking New
        {
            get
            {
                DB.SYS_Tracking entry = new DB.SYS_Tracking();
                entry.Initiator = string.Empty;
                entry.Archived = false;
                return entry;
            }
        }

        public static DB.SYS_Tracking Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Tracking.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Tracking Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.SYS_Tracking entry,DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Tracking.Add(entry); 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        } 
    }
}
