using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum ORG_CostCategory : byte
    {
        SellingPriceIncludingSalesTax = 1,
        SellingPriceExcludingSalesTax = 2,
        CostIncludingSalesTax = 3,
        CostExcludingSalesTax = 4,
        AverageCostExcludingSalesTax = 5
    }
}
