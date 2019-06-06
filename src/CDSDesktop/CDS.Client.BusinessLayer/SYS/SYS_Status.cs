using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CDS.Client.BusinessLayer.SYS
{
    [Browsable(true)]
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