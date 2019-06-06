using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.DataAccessLayer.Types
{
    public class Statement
    {
        public long EntityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public bool ShouldPrint { get; set; }
        public bool ShouldEmail { get; set; }
        public bool? HasPrinted { get; set; }
        public bool? HasMailed { get; set; }
    }
}
