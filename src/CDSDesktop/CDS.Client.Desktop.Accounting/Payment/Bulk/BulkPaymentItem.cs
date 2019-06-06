using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    public class BulkPaymentItem
    {
        public string Type { get; set; }
        public Int64 AccountId { get; set; }
        public string Title { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
        public Int64 PeriodId { get; set; }
        public byte AgingId { get; set; }
        public string TrackNumber { get; set; }
        public Int64 LineId { get; set; }
        public Int64 HeaderId { get; set; }
        public bool Checked { get; set; }
    }
}
