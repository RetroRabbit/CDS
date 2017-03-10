using System;
using System.Collections.Generic;
using System.Text;

namespace CDS.Client.BusinessLayer.SYS
{
    public enum SYS_DOC_ShippingType : byte
    {
        Normal = 1,
        Express = 2,
        Pickup = 3,
        StockOrder = 4
    }
}