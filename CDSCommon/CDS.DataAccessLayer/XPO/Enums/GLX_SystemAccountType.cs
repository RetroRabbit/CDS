using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum GLX_SystemAccountType : byte
    {
        Bank = 1,
        CardControl = 2,
        CashControl = 3,
        ChequeControl = 4,
        CostDifference = 5,
        CostofSales = 6,
        CreditControl = 7,
        Creditors = 8,
        Debtors = 9,
        Distributedreserves = 10,
        Eftcontrol = 11,
        InterestCharged = 12,
        Inventory = 13,
        Profit = 14,
        //TODO : This needs to be removed
        PurchaseDifference = 15,
        Rounding = 16,
        Sales = 17,
        SettlementDiscountAllowed = 18,
        SettlementDiscountReceived = 19,
        StockAdjustment = 20,
        VatControl = 21,
        VatInput = 22,
        VatOutput = 23
    }
}
