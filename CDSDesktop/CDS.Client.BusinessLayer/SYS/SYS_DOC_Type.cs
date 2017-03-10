using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CDS.Client.BusinessLayer.SYS
{
    [Browsable(true)]
    public enum SYS_DOC_Type : byte
    {
        Quote = 1,
        SalesOrder = 2,
        TAXInvoice = 3,
        CreditNote = 4,
        PickingSlip = 5,
        PurchaseOrder = 6,
        GoodsReceived = 7,
        GoodsReturned = 8,
        Job = 9,
        TransferRequest = 10,
        TransferShipment = 11,
        TransferReceived = 12,
        InventoryAdjustment = 13,
        BackOrder = 14,
        BOMAssemblyStarted = 15,
        BOMDisassemblyStarted = 16,
        BOMCanceled = 17,
        BOMComplete = 18,
        JobQuote = 19
    }
}