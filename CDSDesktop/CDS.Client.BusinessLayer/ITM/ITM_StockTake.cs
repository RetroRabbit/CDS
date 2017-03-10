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
    public class ITM_StockTake
    {

        public static DB.ITM_StockTake New
        {
            get
            {
                DB.ITM_StockTake entry = new DB.ITM_StockTake() { Description = "Stock Take on " + ApplicationDataContext.Instance.ServerDateTime.ToString(System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern), StatusId = (int)ITM.ITM_StockTakeStatus.New };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.StartDate = ApplicationDataContext.Instance.ServerDateTime;
                return entry;
            }
        }

        public static DB.ITM_StockTake Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_StockTake.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_StockTake Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        public static String Save(DB.ITM_StockTake entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_StockTake.Add(entry);  
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.EntityInventoryContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ITM_StockTake GetNextItem(DB.ITM_StockTake ITM_StockTake, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_StockTake.OrderBy(o => o.StartDate).Where(n => n.StartDate > ITM_StockTake.StartDate).FirstOrDefault();
        }

        public static DB.ITM_StockTake GetPreviousItem(DB.ITM_StockTake ITM_StockTake, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_StockTake.OrderByDescending(o => o.StartDate).Where(n => n.StartDate < ITM_StockTake.StartDate).FirstOrDefault();
        }
    }
}
