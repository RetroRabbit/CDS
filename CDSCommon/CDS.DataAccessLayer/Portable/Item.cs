using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.Portable
{
    public class Item
    {
        public long id { get; set; }
        public string codeMain { get; set; }
        public string codeSub { get; set; }
        public string shortName { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
