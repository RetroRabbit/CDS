using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public enum SYS_Modules : byte
    {

        CAL = 1,
        CAT = 2,
        DIS = 3,
        GLX = 4,
        IBO = 5,
        ITM = 6,
        ORG = 7,
        RPT = 8,
        SEC = 9,
        SYS = 10,
        SYS_DOC = 11,
        HR = 12,
        WS = 13,
        JOB = 14
    }
}
