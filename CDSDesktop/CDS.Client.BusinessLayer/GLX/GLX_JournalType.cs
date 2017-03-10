using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CDS.Client.BusinessLayer.GLX
{
    [Browsable(true)]
    public enum GLX_JournalType
    {
        Invoice = 1,
        Journal = 2,
        Payment = 3,
        Receipts = 4,
        CreditNote = 5,
        GoodsRecieved = 6,
        GoodsReturned = 7,
        SettlementDiscount = 8,
        Reversal = 9,
        //ONLY FOR USE ON YEAREND HEADER
        Posting = 10,
        BulkJournal = 11
    }
}
