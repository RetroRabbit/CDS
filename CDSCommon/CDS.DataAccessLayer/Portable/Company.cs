using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.Portable
{
    public class Company
    {
        public string billingAddressLine1 { get; set; }
        public string billingAddressLine2 { get; set; }
        public string billingAddressLine3 { get; set; }
        public string billingAddressLine4 { get; set; }
        public string billingAddressCode { get; set; }
        public string referenceShort1 { get; set; }
        public string referenceShort2 { get; set; }
        public string referenceShort3 { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Int64 id { get; set; }
    }
}
