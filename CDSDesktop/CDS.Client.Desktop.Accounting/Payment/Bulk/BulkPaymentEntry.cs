using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    public class BulkPaymentEntry
    {
        private Decimal settlement;
        private Decimal amount;
        private List<BulkPaymentItem> bulkPaymentItem = new List<BulkPaymentItem>();

        public Int64? PeriodId { get; set; }
        public DateTime? Date { get; set; }
        public Int64? AccountId { get; set; }
        public String Reference { get; set; }
        public String Description { get; set; }
        public Int16 AgingId { get; set; }
        public Decimal Settlement { get { return settlement; } set { settlement = value; } }
        public Decimal Amount { get { return amount; } set { amount = value; } }
        public List<BulkPaymentItem> BulkPaymentItems { get { return bulkPaymentItem; } set { bulkPaymentItem = value; } }
    }
}
