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
    public class ITM_Inventory
    {

        public static DB.ITM_Inventory New
        {
            get
            {
                DB.ITM_Inventory entry = new DB.ITM_Inventory() { LabelFlag = "N", RequireSerial = false };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ITM_Inventory Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_Inventory.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id && n.SiteId == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        public static DB.ITM_Inventory Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null); 
        }

        internal static String Save(DB.ITM_Inventory entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_Inventory.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.ITM_Inventory GetNextItem(DB.ITM_Inventory ITM_Inventory, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Inventory.OrderBy(o => o.SYS_Entity.CodeMain).ThenBy(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(ITM_Inventory.SYS_Entity.CodeMain) > 0 && n.SYS_Entity.CodeMain.CompareTo(ITM_Inventory.SYS_Entity.CodeMain) != 0);
        //}

        //public static DB.ITM_Inventory GetPreviousItem(DB.ITM_Inventory ITM_Inventory, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Inventory.OrderByDescending(o => o.SYS_Entity.CodeMain).ThenByDescending(o => o.SYS_Entity.CodeSub).FirstOrDefault(n => n.SYS_Entity.CodeMain.CompareTo(ITM_Inventory.SYS_Entity.CodeMain) < 0 && n.SYS_Entity.CodeMain.CompareTo(ITM_Inventory.SYS_Entity.CodeMain) != 0);
        //}

        public static int GenerateInventoryHistory(DB.ITM_Inventory inventory, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spGenerateInventoryHistory {0}, {1}", inventory.EntityId, inventory.SiteId);
        }

        public static string GenerateBarcode(DataContext dataContext)
        {
            string newBarcode = "";

            do
            {
                long i = 1; foreach (byte b in Guid.NewGuid().ToByteArray())
                {
                    i *= ((int)b + 1);

                }

                newBarcode = (string.Format("{0:d}", Math.Abs(i - DateTime.Now.Millisecond))).Substring(0, 10);

            }
            while (BarcodeExists(newBarcode, dataContext));

            return newBarcode;
        }

        private static bool BarcodeExists(string newBarcode, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_Inventory.Count(n => n.Barcode == newBarcode) > 0;
        }

        public static int GenerateSiteInventory(Int64 entityId, DataContext dataContext)
        {
            int rows = 0;
            
            rows += dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spGenerateSiteInventory {0},{1}", entityId, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId);

            return rows;
        }
    }
}
