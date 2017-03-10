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
    public class ITM_History
    {

        public static DB.ITM_History New
        {
            get
            {
                DB.ITM_History entry = new DB.ITM_History() { Amount = 0.00M, Movement = 0.00M, OnHand = 0.00M, OnReserve = 0.00M, OnOrder = 0.00M, UnitPrice = 0.00M, UnitCost = 0.00M, UnitAverage = 0.00M };
                return entry;
            }
        }

        public static DB.ITM_History Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_History.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_History Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.ITM_History entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityInventoryContext.ITM_History.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ITM_History GetItemCurrentHistory(DB.ITM_Inventory entry, DataContext dataContext)
        {
            DB.SYS_Period currentPeriod = SYS.SYS_Period.GetCurrentPeriod(dataContext);
            DB.ITM_History history = dataContext.EntityInventoryContext.ITM_History.FirstOrDefault(n => n.InventoryId ==
                entry.EntityId && n.PeriodId == currentPeriod.Id && n.SiteId == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);

            return history;
        }

        internal static int UpdateHistoryUnitCost(Int64 itemId, decimal amount, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ExecuteSqlCommand(string.Format("EXEC CDS_SYS.spUpdateInventoryHistoryUnitCost {0},{1},{2}", itemId, amount, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId));
        }

        internal static int UpdateHistoryUnitPrice(Int64 itemId, decimal amount, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ExecuteSqlCommand(string.Format("EXEC CDS_SYS.spUpdateInventoryHistoryUnitPrice {0},{1},{2}", itemId, amount, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId));
        }

        internal static int UpdateHistoryUnitAverage(Int64 itemId, decimal amount, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ExecuteSqlCommand(string.Format("EXEC CDS_SYS.spUpdateInventoryHistoryUnitAverage {0},{1},{2}", itemId, amount, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId));
        }

        internal static int UpdateHistoryOnHand(byte documentTypeId, Int64 itemId, decimal quantity, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryOnHand {0},{1},{2},{3}", itemId, documentTypeId, quantity,ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistoryOnHold(byte documentTypeId, Int64 itemId, decimal quantity, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryOnHold {0},{1},{2},{3}", itemId, documentTypeId, quantity, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistoryOnOrder(byte documentTypeId, Int64 itemId, decimal quantity, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryOnOrder {0},{1},{2},{3}", itemId, documentTypeId, quantity, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistoryOnReserve(byte documentTypeId, Int64 itemId, decimal quantity, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryOnReserve {0},{1},{2},{3}", itemId, documentTypeId, quantity, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistoryAmount(byte documentTypeId, Int64 itemId, decimal amount, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryAmount {0},{1},{2},{3}", itemId, documentTypeId, amount, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistoryMovement(byte documentTypeId, Int64 itemId, decimal quantity, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryMovement {0},{1},{2},{3}", itemId, documentTypeId, quantity, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistoryPurchaseDates(Int64 itemId, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryPurchaseDate {0},{1}", itemId, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistorySalesDates(Int64 itemId, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistorySalesDate {0},{1}", itemId, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static int UpdateHistoryMovementDates(Int64 itemId, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateInventoryHistoryMovementDate {0},{1}", itemId, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        internal static void UpdateHistoryUnitAverageAndProfitMargin(DB.SYS_DOC_Line line, byte typeId, DataContext dataContext)
        {
            //Get current History
            DB.ITM_History itm_history = BL.ITM.ITM_History.GetItemCurrentHistory(dataContext.EntityInventoryContext.ITM_Inventory.FirstOrDefault(n => n.EntityId == line.ItemId), dataContext);
            //Force Reload history from DB
            dataContext.EntityInventoryContext.Entry(itm_history).Reload();
            //Calculate new Average Cost
            decimal? newAverageCost = GetNewAverageCost(ref itm_history, line, typeId, dataContext);

            //Update Unit Selling form profit margin
            if (newAverageCost > itm_history.UnitAverage && line.LineItem.ProfitMargin != null)
            {
                //Added for the Log entry for UnitPrice
                itm_history.UnitPrice = Convert.ToDecimal(Math.Round(newAverageCost.Value / ((100.00M - (decimal)line.LineItem.ProfitMargin.Value) / 100.00M), 2));
                BL.ITM.ITM_History.UpdateHistoryUnitPrice(line.ItemId, itm_history.UnitPrice, dataContext);
            }
            //Change Price to new Average Cost (so that we cannot set stock at a loss
            if (newAverageCost > itm_history.UnitPrice)
            {
                itm_history.UnitPrice = newAverageCost.Value;
                BL.ITM.ITM_History.UpdateHistoryUnitPrice(line.ItemId, itm_history.UnitPrice, dataContext);
            }
            //If OnHand + OnReserve != 0
            if (newAverageCost != null && newAverageCost != itm_history.UnitAverage)
            {
                //Added for the Log entry for UnitAverage
                itm_history.UnitAverage = newAverageCost.Value;
                BL.ITM.ITM_History.UpdateHistoryUnitAverage(line.ItemId, newAverageCost.Value, dataContext);
            }
        }

        private static decimal? GetNewAverageCost(ref DB.ITM_History itm_history, DB.SYS_DOC_Line line, byte documentType, DataContext dataContext)
        {
            long stockModifier = dataContext.EntitySystemContext.SYS_DOC_Type.Where(n => n.Id == documentType).Select(n => n.StockModifier).FirstOrDefault();
            decimal? newAverageCost = null;
            if (((itm_history.OnHand + itm_history.OnReserve) + (stockModifier * line.Quantity)) != 0)
            {
                switch (documentType)
                {
                    case (byte)BL.SYS.SYS_DOC_Type.Quote:
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.UnitAverage)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.UnitAverage)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.Amount)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.Amount)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.Job:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.UnitAverage)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.UnitAverage)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.Amount)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.Amount)) / ((itm_history.OnHand + itm_history.OnReserve) + stockModifier * line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.UnitAverage)) / ((itm_history.OnHand + itm_history.OnReserve) + line.Quantity);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                        newAverageCost = (((itm_history.OnHand + itm_history.OnReserve) * itm_history.UnitAverage) + ((stockModifier * line.Quantity) * line.UnitAverage)) / ((itm_history.OnHand + itm_history.OnReserve) + line.Quantity);
                        break;
                }
            }
            return newAverageCost;

        }

    }
}
