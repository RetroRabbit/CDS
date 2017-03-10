using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum ITM_StockTakeStatus : byte
    {
        New = 1,
        StocktakeCount = 2,
        StocktakeRecount = 3,
        StocktakeCountVariance = 4,
        UpdateInventory = 5,
        Cancelled = 6,
        Completed = 7
    }
}
