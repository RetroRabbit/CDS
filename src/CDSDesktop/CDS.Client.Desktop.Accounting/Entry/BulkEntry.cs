using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Accounting.Entry
{
    public class BulkEntry
    {
        public Decimal? exclusive;
        public Decimal? inclusive;

        public Int64? PeriodId { get; set; }
        public DateTime? Date { get; set; }
        public Int64? AccountId { get; set; }
        public String Reference { get; set; }
        public String Description { get; set; }
        public byte? AgingId { get; set; }
        public Int64? TaxId { get; set; }
        public Decimal? Exclusive { get { if (exclusive == null) return 0.00M; else return exclusive; } set { exclusive = value; } }
        public Decimal? Inclusive { get { if (inclusive == null) return 0.00M; else return inclusive; } set { inclusive = value; } }
    }
}
