using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.BusinessLayer.GLX
{
    public class PaymentAccount
    {
        public Int64 AccountId { get; set; }
        public string AccountShortName { get; set; }
        public string AccountDescription { get; set; }
        public Boolean AccountDefault { get; set; }
        public Int16? TaxId { get; set; }
    }
}
