using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ITM
{
    public class ITM_Surcharge
    {

        public static DB.ITM_Surcharge New
        {
            get
            {
                DB.ITM_Surcharge entry = new DB.ITM_Surcharge() {  }; 
                return entry;
            }
        }

        public static DB.ITM_Surcharge Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_Surcharge.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_Surcharge Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null); 
        }

        internal static String Save(DB.ITM_Surcharge entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_Surcharge.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }




        //public static DB.ITM_Surcharge GetNextItem(DB.ITM_Surcharge ITM_Surcharge, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Surcharge.OrderBy(o => o.SYS_Entity.CodeMain).ThenBy(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(ITM_Surcharge.SYS_Entity.CodeMain) > 0 && n.SYS_Entity.CodeMain.CompareTo(ITM_Surcharge.SYS_Entity.CodeMain) != 0);
        //}

        //public static DB.ITM_Surcharge GetPreviousItem(DB.ITM_Surcharge ITM_Surcharge, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Surcharge.OrderByDescending(o => o.SYS_Entity.CodeMain).ThenByDescending(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(ITM_Surcharge.SYS_Entity.CodeMain) < 0 && n.SYS_Entity.CodeMain.CompareTo(ITM_Surcharge.SYS_Entity.CodeMain) != 0);
        //}

        public static IQueryable<DB.ITM_Surcharge> LoadByEntityId(Int64 EntityId, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_Surcharge.Where(n => n.EntityId == EntityId);
        }
    }
}
