using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum ORG_PaymentTerm : byte
    {
        Cash = 1,
        Days30 = 2,
        Days60 = 3,
        Days90 = 4,
        Days120 = 5
    }
}
