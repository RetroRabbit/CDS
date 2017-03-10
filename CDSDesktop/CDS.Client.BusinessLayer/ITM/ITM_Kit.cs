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
    public class ITM_Kit
    {

        public static DB.ITM_Kit New
        {
            get
            {
                DB.ITM_Kit entry = new DB.ITM_Kit() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ITM_Kit Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_Kit.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_Kit Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.ITM_Kit entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_Kit.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.ITM_Kit GetNextItem(DB.ITM_Kit ITM_Kit, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Kit.OrderBy(o => o.SYS_Entity.CodeMain).ThenBy(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(ITM_Kit.SYS_Entity.CodeMain) > 0 && n.SYS_Entity.CodeMain.CompareTo(ITM_Kit.SYS_Entity.CodeMain) != 0);
        //}

        //public static DB.ITM_Kit GetPreviousItem(DB.ITM_Kit ITM_Kit, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Kit.OrderByDescending(o => o.SYS_Entity.CodeMain).ThenByDescending(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(ITM_Kit.SYS_Entity.CodeMain) < 0 && n.SYS_Entity.CodeMain.CompareTo(ITM_Kit.SYS_Entity.CodeMain) != 0);
        //}         
    }
}
