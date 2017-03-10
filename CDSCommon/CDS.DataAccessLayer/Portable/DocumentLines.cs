using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.Portable
{
    public class DocumentLines
    {
        public int lineOrder { get; set; }
        public Int64 itemId { get; set; }
        public string description { get; set; }
        public decimal quantity { get; set; }
        public decimal amount { get; set; }
        public decimal totalVat { get; set; }
        public decimal total { get; set; }
        public bool isNew { get; set; }
    }
}
