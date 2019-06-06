using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum GLX_Type : byte
    {
        Sales = 1,
        CostofSales = 2,
        Expenses = 3,
        CurrentAssets = 4,
        CurrentLiabilities = 5,
        Equity = 6,
        Tax = 7,
        LongTermDebt = 8,
        FixedAssets = 9
    }
}
