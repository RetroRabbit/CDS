using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.BusinessLayer.ORG
{
    public enum ORG_StatementPreference : byte
    {
        Print = 1,
        Email = 2,
        Ignore = 3
    }
}
