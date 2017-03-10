using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.AOR
{
    public class AOR_Order
    {

        public static DB.AOR_Order New
        {
            get
            {
                DB.AOR_Order entry = new DB.AOR_Order()
                {
                    StartDate = ApplicationDataContext.Instance.ServerDateTime,
                    LastChangedLine = 0,
                    StatusId = (byte)SYS.SYS_Status.Open,
                    CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId,
                    MonthWeight3 = ApplicationDataContext.Instance.CompanySite.MonthWeight3,
                    MonthWeight6 = ApplicationDataContext.Instance.CompanySite.MonthWeight6,
                    MonthWeight12 = ApplicationDataContext.Instance.CompanySite.MonthWeight12,
                    MonthWeight24 = ApplicationDataContext.Instance.CompanySite.MonthWeight24,
                    MonthWeight36 = ApplicationDataContext.Instance.CompanySite.MonthWeight36
                };
                return entry;
            }
        } 

        public static DB.AOR_Order Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrderingContext.AOR_Order.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.AOR_Order Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null); 
        } 

        internal static String Save(DB.AOR_Order entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrderingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityOrderingContext.AOR_Order.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static decimal CalculateAvgDemand(decimal[] history, decimal threeMthWeight, decimal sixMthWeight, decimal twelveMthWeight, decimal twentyfourMthWeight, decimal thirtysixMthWeight)
        {

            decimal threeMthDemand = ((history[0] + history[1] + history[2]) / 3) * (threeMthWeight / (threeMthWeight + sixMthWeight + twelveMthWeight + twentyfourMthWeight + thirtysixMthWeight));
            decimal sixMthDemand = ((history[0] + history[1] + history[2] + history[3] + history[4] + history[5]) / 6) * (sixMthWeight / (threeMthWeight + sixMthWeight + twelveMthWeight + twentyfourMthWeight + thirtysixMthWeight));
            decimal twelveMthDemand = ((history[0] + history[1] + history[2] + history[3] + history[4] + history[5] + history[6] + history[7] + history[8] + history[9] + history[10] + history[11]) / 12) * (twelveMthWeight / (threeMthWeight + sixMthWeight + twelveMthWeight + twentyfourMthWeight + thirtysixMthWeight));
            decimal twentyfourMthDemand = ((history[0] + history[1] + history[2] + history[3] + history[4] + history[5] + history[6] + history[7] + history[8] + history[9] + history[10] + history[11] + history[12] + history[13] + history[14] + history[15] + history[16] + history[17] + history[18] + history[19] + history[20] + history[21] + history[22] + history[23]) / 24) * (twentyfourMthWeight / (threeMthWeight + sixMthWeight + twelveMthWeight + twentyfourMthWeight + thirtysixMthWeight));
            decimal thirtysixMthDemand = ((history[0] + history[1] + history[2] + history[3] + history[4] + history[5] + history[6] + history[7] + history[8] + history[9] + history[10] + history[11] + history[12] + history[13] + history[14] + history[15] + history[16] + history[17] + history[18] + history[19] + history[20] + history[21] + history[22] + history[23] + history[24] + history[25] + history[26] + history[27] + history[28] + history[29] + history[30] + history[31] + history[32] + history[33] + history[34] + history[35]) / 36) * (thirtysixMthWeight / (threeMthWeight + sixMthWeight + twelveMthWeight + twentyfourMthWeight + thirtysixMthWeight));

            if (threeMthDemand + sixMthDemand + twelveMthDemand + twentyfourMthDemand + thirtysixMthDemand <= 0)
                return 0.00M;
            else
                return Math.Round(threeMthDemand + sixMthDemand + twelveMthDemand + twentyfourMthDemand + thirtysixMthDemand, 4, MidpointRounding.AwayFromZero);

            return 0.00M;
        }

        public static decimal CalculateEOQ(decimal avgDemand, decimal orderCost, decimal carryingCost, decimal unitCost)
        {
            decimal dFraction = carryingCost * unitCost;
            if (dFraction > 0)
                return (decimal)Math.Ceiling(Math.Sqrt((double)((2M * avgDemand * orderCost) / (dFraction))));
            else
                return 0.00M;
        }

        public static decimal CalculateOrderPoint(Int16 safetyStockPeriod, decimal avgDemand, byte orderLeadTime, decimal safetyStock)
        {
            decimal leadTimeDemand = 0;
            decimal safetyStockDemand = 0;
            decimal weeklyDemand = (avgDemand * 12M) / 52M;

            //// AVG demand is Per Month - LeadTime is in days        
            leadTimeDemand = (orderLeadTime * (weeklyDemand / 7M));

            // Get whether safety stock is stored per week or per day.
            // string sSafetyStockPeriod = GetSafetyStockPeriod(conn);

            switch (safetyStockPeriod)
            {
                // Safety Stock is stored Daily 
                case (byte)BL.SYS.SYS_SafetyStockPeriod.Days:
                    safetyStockDemand = safetyStock * (weeklyDemand / 7M);
                    break;
                // Safety Stock is stored weekly 
                case (byte)BL.SYS.SYS_SafetyStockPeriod.Weeks:
                    safetyStockDemand = safetyStock * weeklyDemand;
                    break;
            }

            decimal demand = Math.Round((leadTimeDemand + safetyStockDemand), MidpointRounding.AwayFromZero);

            // TC: Moved min level stuff to calculate RR
            //demand = Math.Max(demand, minOrderLevel);

            return Math.Round(demand, 4, MidpointRounding.AwayFromZero);
        }

        public static decimal CalculateRecommendedReorderLevel(decimal onHand, decimal onHold, decimal onOrder, decimal packSize, decimal orderPoint, decimal eoq, string stockType, decimal minLevel, decimal maxLevel, decimal minOrderLevel, decimal maxOrderLevel)
        {
            decimal suggestedOrderLevel = 0;

            // Non movers are not considered
            //if ((stockType.Length >= 1) && (stockType.ToUpper().StartsWith("N") || stockType.ToUpper().StartsWith("C")))
            if (stockType.ToUpper().StartsWith("N") || stockType.ToUpper().StartsWith("C"))
                return 0.00M;


            decimal PackSize = Math.Max(packSize, 1);

            //if (((onHand + onOrder) - onHold) < orderPoint)
            {
                // TC: If there is something to order and the pack size is larger than the amount required order at least 1 packsize unit
                //suggestedOrderLevel = (int)(Math.Floor((double)Math.Max(eoq, orderPoint) / iPackSize) * iPackSize);
                //double toorder = (double)Math.Max(eoq, orderPoint) - ((onHand + onOrder) - onHold);



                decimal toorder = Math.Max(
                    ((onHand + onOrder) - onHold) < orderPoint ? eoq : 0, // if the current onhand is less than the OP then we order
                    ((eoq + orderPoint) - ((onHand + onOrder) - onHold)) // if the stock is much less than the OP then we must at least order to the OP
                    );
                suggestedOrderLevel = (Math.Ceiling(toorder / PackSize) * PackSize);

                //if (maxLevel > 0)
                //    suggestedOrderLevel = Convert.ToInt32(Math.Min(suggestedOrderLevel, Math.Max(maxLevel - ((onHand + onOrder) - onHold), 0)));
                if (maxLevel > 0 && (suggestedOrderLevel + ((onHand + onOrder) - onHold) > maxLevel))
                    suggestedOrderLevel = Convert.ToDecimal(maxLevel - ((onHand + onOrder) - onHold));

                //if (minLevel > 0)
                //    suggestedOrderLevel = Convert.ToInt32(Math.Max(suggestedOrderLevel, Math.Max(minLevel - ((onHand + onOrder) - onHold), 0)));
                if (minLevel > 0 && (suggestedOrderLevel + ((onHand + onOrder) - onHold) < minLevel))
                    suggestedOrderLevel = Convert.ToDecimal(minLevel - ((onHand + onOrder) - onHold));

                //suggestedOrderLevel = (Math.Ceiling(suggestedOrderLevel / PackSize) * PackSize);

                // Adjust order to use Minimum Order Size if something is to be ordered at all
                if (minOrderLevel > 0 && suggestedOrderLevel > 0)
                    suggestedOrderLevel = Math.Max(suggestedOrderLevel, minOrderLevel);

                // Adjust order to use Maximum Order Size if something is to be ordered at all
                if (maxOrderLevel > 0 && suggestedOrderLevel > 0)
                    suggestedOrderLevel = Math.Min(suggestedOrderLevel, maxOrderLevel);
                
            }

            //else
            //    suggestedOrderLevel = 0;

            // Always return atleast 0
            return Math.Max(suggestedOrderLevel, 0);
        } 
    }
}
