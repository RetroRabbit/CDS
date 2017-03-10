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
    public class ITM_InventorySupplier
    {

        public static DB.ITM_InventorySupplier New
        {
            get
            {
                DB.ITM_InventorySupplier entry = new DB.ITM_InventorySupplier() { PrimarySupplier = false };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ITM_InventorySupplier Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_InventorySupplier.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_InventorySupplier Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.ITM_InventorySupplier entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityInventoryContext.ITM_InventorySupplier.Add(entry);
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.ITM_InventorySupplier GetNextItem(DB.ITM_InventorySupplier ITM_InventorySupplier, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_InventorySupplier.OrderBy(o => o.ITM_Inventory.SYS_Entity.CodeMain).ThenBy(o => o.ITM_Inventory.SYS_Entity.CodeMain).FirstOrDefault(n => n.ITM_Inventory.SYS_Entity.CodeMain.CompareTo(ITM_InventorySupplier.ITM_Inventory.SYS_Entity.CodeMain) > 0 && n.ITM_Inventory.SYS_Entity.CodeMain.CompareTo(ITM_InventorySupplier.ITM_Inventory.SYS_Entity.CodeMain) != 0);
        //}

        //public static DB.ITM_InventorySupplier GetPreviousItem(DB.ITM_InventorySupplier ITM_InventorySupplier, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_InventorySupplier.OrderByDescending(o => o.ITM_Inventory.SYS_Entity.CodeMain).ThenByDescending(o => o.ITM_Inventory.SYS_Entity.CodeMain).FirstOrDefault(n => n.ITM_Inventory.SYS_Entity.CodeMain.CompareTo(ITM_InventorySupplier.ITM_Inventory.SYS_Entity.CodeMain) < 0 && n.ITM_Inventory.SYS_Entity.CodeMain.CompareTo(ITM_InventorySupplier.ITM_Inventory.SYS_Entity.CodeMain) != 0);
        //}


        public static IQueryable<DB.ITM_InventorySupplier> LoadByEntityId(Int64 EntityId, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_InventorySupplier.Where(n => n.InventoryId == EntityId);
        }
    }
}
