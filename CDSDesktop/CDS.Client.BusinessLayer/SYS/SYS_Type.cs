using System;
using System.Collections.Generic;
using System.Text;

namespace CDS.Client.BusinessLayer.SYS
{
    public enum SYS_Type : byte
    {
        BillingAddress = 1,
        ShippingAddress = 2,
        Company = 3,
        Inventory = 4,
        Account = 5,
        Message = 6,
        BuyOut = 7,
        Consignment = 8,
        Center = 9,
        Site = 10,
        Surcharge = 11
    }
}