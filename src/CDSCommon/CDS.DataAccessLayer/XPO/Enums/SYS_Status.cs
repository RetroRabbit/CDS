using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.XPO.Enums
{
    public enum SYS_Status : byte
    {
        Open = 1,
        Closed = 2,
        Posted = 3,
        Unposted = 4,
        Rejected = 5,
        Active = 6,
        Canceled = 7
    }
}
