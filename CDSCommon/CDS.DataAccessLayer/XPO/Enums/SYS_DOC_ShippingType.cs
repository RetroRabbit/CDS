using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum SYS_DOC_ShippingType : byte
    {
        Normal = 1,
        Express = 2,
        Pickup = 3,
        StockOrder = 4
    }
}
