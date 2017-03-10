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
    public class ITM_Movement
    {

        public static DB.ITM_Movement New
        {
            get
            {
                DB.ITM_Movement entry = new DB.ITM_Movement() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ITM_Movement Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_Movement.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_Movement Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.ITM_Movement LoadByLineId(Int64 lineId, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_Movement.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.LineId == lineId);
        }

        public static DB.ITM_Movement LoadByLineId(Int64 lineId, DataContext dataContext)
        {
            return LoadByLineId(lineId, dataContext, null);
        }

        public static DB.ITM_Movement Populate(Int64 itemId,DataContext dataContext)
        {
            DB.VW_LineItem inventory = dataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == itemId);
            DB.ITM_Movement movement = New;
            movement.OnHand = inventory.OnHand;
            movement.OnReserve = inventory.OnReserve;
            movement.OnOrder = inventory.OnOrder;
            movement.UnitPrice = inventory.UnitPrice;
            movement.UnitCost = inventory.UnitCost;
            movement.UnitAverage = inventory.UnitAverage;
            movement.OnHold = inventory.OnHold;

            return movement;
        }

        internal static String Save(DB.ITM_Movement entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_Movement.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.ITM_Movement GetNextItem(DB.ITM_Movement ITM_Movement, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Movement.OrderBy(o => o.CreatedOn).Where(n => n.InventoryId == ITM_Movement.InventoryId && n.CreatedOn > ITM_Movement.CreatedOn).FirstOrDefault();
        //}

        //public static DB.ITM_Movement GetPreviousItem(DB.ITM_Movement ITM_Movement, DataContext dataContext)
        //{
        //    return dataContext.EntityInventoryContext.ITM_Movement.OrderByDescending(o => o.CreatedOn).Where(n => n.InventoryId == ITM_Movement.InventoryId && n.CreatedOn < ITM_Movement.CreatedOn).FirstOrDefault();
        //}

    }
}
