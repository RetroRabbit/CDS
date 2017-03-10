using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CDS.Client.BusinessLayer.SYS
{
    [Browsable(true)]
    public enum SYS_SafetyStockPeriod : byte
    {
        Days = 0,
        Weeks = 1
    }
}