using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CDS.Client.BusinessLayer.GLX
{
    [Browsable(true)]
    public enum GLX_Type
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
