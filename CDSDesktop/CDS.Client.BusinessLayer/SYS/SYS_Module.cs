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
    public class SYS_Module
    {

        public static DB.SYS_Module Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Module.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Module Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SYS_Module entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Module.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_Module GetNextItem(DB.SYS_Module SYS_Module, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Module.OrderBy(o => o.Id).FirstOrDefault(n => n.Id > SYS_Module.Id);
        }

        public static DB.SYS_Module GetPreviousItem(DB.SYS_Module SYS_Module, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Module.OrderByDescending(o => o.Id).FirstOrDefault(n => n.Id < SYS_Module.Id);
        }


        public static DB.SYS_Module Deactivate(Int32 id, DataContext dataContext)
        {
          DB.SYS_Module module = Load(id, dataContext);
          module.Code = String.Empty;
          return module;
        }
    }
}
