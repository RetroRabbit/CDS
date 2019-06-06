using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum ITM_DIS_Type : byte
    {
        StockCodevsAccountNumber = 1,
        StockCodevsAccountDiscountCode = 2,
        StockDiscountCodevsAccountNumber = 3,
        StockDiscountCodevsAccountDiscountCode = 4
    }
}
