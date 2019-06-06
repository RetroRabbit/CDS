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
    public class ITM_StockTakeItem
    {

        public static DB.ITM_StockTakeItem New
        {
            get
            {
                DB.ITM_StockTakeItem entry = new DB.ITM_StockTakeItem() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ITM_StockTakeItem Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_StockTakeItem.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_StockTakeItem Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        public static String Save(DB.ITM_StockTakeItem entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_StockTakeItem.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.EntityInventoryContext.PackageValidationException();
            }

            return "Success";
        }
    }
}
