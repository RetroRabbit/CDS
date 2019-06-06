using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ORG
{
    public class ORG_TRX_PriceHelper
    {
        public static void GetSellPrice(DB.SYS_DOC_Line line, DB.VW_Company entity, decimal amount, bool useWarehouseDiscount, out decimal sellPrice, out decimal discountPrice, out decimal discountPercentage, DataContext dataContext)
        {
            if (line == null || line.LineItem == null || (line.LineItem as DB.VW_LineItem).InventoryId == null)
            {
                sellPrice = line.Amount;
                discountPrice = line.Amount;
                discountPercentage = 0M;
                return;
            }

            sellPrice = line.Amount;
            discountPrice = 0M;
            discountPercentage = 0M;
            if ((entity == null))
            {
                // NO entity SELECTED
                //sellPrice = inventoryItem.UnitPrice;
                return;
            }

            DB.VW_LineItem inventory = line.LineItem as DB.VW_LineItem;
            var discounts = dataContext.ReadonlyContext.VW_Discount.Where(n => (n.CompanyDiscountCode == entity.DiscountCode || n.EntityId == entity.OrgEntityId) && (n.InventoryDiscountCode == inventory.DiscountCode || n.InventoryId == inventory.InventoryId)).ToList();


            //If any of the discounts are fixed price discounts
            if (discounts.Any(n => n.DiscountAmountTypeId == (byte)BL.ITM.ITM_DIS_AmountType.FixedPriceDiscount))
            {
                if (!useWarehouseDiscount)
                    sellPrice = discounts.Min(n => n.CompanyDiscount).Value;
                else
                    sellPrice = discounts.Min(n => n.WorkshopDiscount).Value;
                discountPrice = sellPrice;
                discountPercentage = 0;
                return;
            }
            else
            {
                //Henko: I am pretty sure if anything this should be MIN not MAX? But either way this is really badly done...
                if (!useWarehouseDiscount)
                    discountPercentage = discounts.Count() > 0 ? discounts.Max(n => n.CompanyDiscount).Value : 0;
                else
                    discountPercentage = discounts.Count() > 0 ? discounts.Max(n => n.WorkshopDiscount).Value : 0;

            }

            if ((entity.CostCategoryId == (byte)BL.ORG.ORG_CostCategory.CostExcludingSalesTax) || (entity.CostCategoryId == (byte)BL.ORG.ORG_CostCategory.CostIncludingSalesTax))
            {
                // COST INCLUDING or COST EXCLUDING
                if (discountPercentage < 0)
                {
                    discountPrice = inventory.UnitCost - (inventory.UnitCost * discountPercentage / 100);
                    sellPrice = inventory.UnitCost;
                }
                else
                {
                    discountPrice = (inventory.UnitCost * (100 - discountPercentage)) / 100;
                    sellPrice = inventory.UnitCost;
                }
                //sellPrice = line.UnitCost;
                return;
            }
            else if (entity.CostCategoryId == (byte)BL.ORG.ORG_CostCategory.AverageCostExcludingSalesTax)
            {
                // AVG COST EXCLUDING
                if (discountPercentage < 0)
                {
                    discountPrice = inventory.UnitAverage - (line.UnitAverage * discountPercentage / 100);
                    sellPrice = inventory.UnitAverage;
                }
                else
                {
                    discountPrice = (inventory.UnitAverage * (100 - discountPercentage)) / 100;
                    sellPrice = inventory.UnitAverage;
                }
                //sellPrice = line.UnitAverage;
                return;
            }
            else if ((entity.CostCategoryId == (byte)BL.ORG.ORG_CostCategory.SellingPriceExcludingSalesTax) || (entity.CostCategoryId == (byte)BL.ORG.ORG_CostCategory.SellingPriceIncludingSalesTax))
            {
                // SELLING PRICE INCLUDING or SELLING PRICE EXCLUDING
                if (discountPercentage < 0)
                {
                    discountPrice = inventory.UnitPrice - (inventory.UnitPrice * discountPercentage / 100);
                    sellPrice = inventory.UnitPrice;
                }
                else
                {
                    discountPrice = (inventory.UnitPrice * (100 - discountPercentage)) / 100;
                    sellPrice = inventory.UnitPrice;
                }
                //sellPrice = line.UnitAverage;
                return;
            }
        }
    }
}
