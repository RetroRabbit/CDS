using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.DataAccessLayer.DB
{
    public class LogEntry
    {
        public static DB.SYS_Log New<T>(String fieldName, String tableName, Int64 entityId, T oldValue, T newValue)
        {
            SYS_Log returnValue = new SYS_Log();
            returnValue.FieldName = fieldName;
            returnValue.TableName = tableName;
            returnValue.EntityId = entityId;
            returnValue.OldValue = oldValue.ToString();
            returnValue.NewValue = newValue.ToString();

            return returnValue;
        }
    }

    public partial class CAT_Item
    {
        Nullable<long> StockId { get; set; }
    }

    public partial class AOR_OrderLine
    {
        //This should only be used During calculation cannot be used after OpenRecord
        public DB.VW_OrderInventoryHistory InventoryHistory { get; set; }
        public decimal WarehousingCost { get; set; }

        public decimal Average3Months { get; set; }
        public decimal Average6Months { get; set; }
        public decimal Average12Months { get; set; }
        public decimal Average24Months { get; set; }
        public decimal Average36Months { get; set; }

        public decimal Average3MonthsPrevious { get; set; }
        public decimal Average6MonthsPrevious { get; set; }
        public decimal Average12MonthsPrevious { get; set; }
        public decimal Average24MonthsPrevious { get; set; }
        public decimal Average36MonthsPrevious { get; set; } 
    }

    public partial class SEC_User
    {
        public DB.SYS_Person Person { get; set; }
        public DB.SYS_Printer DefaultPrinter { get; set; }
        public DB.SYS_Site DefaultSite { get; set; }

    } 

    public partial class ORG_Company
    {
        public bool IsNewEntity { get; set; }
    }

    public partial class ORG_TRX_Header
    {
        //Used on WebPortal to display Company name on document
        public string CompanyName { get; set; }
    }

    public partial class ITM_Inventory
    {
        public DB.ITM_History CurrentHolding { get; set; }
        
        //Used on WebPortal to bind to SYS_Entity
        public DB.SYS_Entity Entity { get; set; }

        public bool FromBuyout { get; set; }
    }

    public partial class ITM_History
    {
        public decimal Available { get { return OnHand - OnHold; } }
    }

    public partial class ITM_BOM_Document
    {
        /// <summary>
        /// Should only be used to identify the BOM Cancel parent
        /// </summary>
        public Int64 CancelParent { get; set; }
    }

    public partial class ITM_BOM_RecipeLine
    {
        public DB.VW_LineItem LineItem { get; set; }
        /// <summary>
        /// Does not persist only used to show On Hand on BOM Recipe Grid
        /// </summary>
        public decimal? OnHand { get; set; }
        /// <summary>
        /// Does not persist only used to show Total value on BOM Recipe Grid
        /// </summary>
        public decimal? Total { get; set; }
    }

    public partial class SYS_DOC_Header
    {
        //Quote - Used to Cancel difference
        //TAX Invoice - Origin Document
        //Back Order - Origin Document
        public SYS_DOC_Header SalesOrder { get; set; }
        
        //Sales Credit - Origin Document
        public SYS_DOC_Header TaxInvoice { get; set; }
        
        //Sales Order - Used to subtract On Reserved
        public SYS_DOC_Header BackOrder { get; set; }
        
        //Client : The below property is used on the Document form in order to calculate the Qty Outstanding column
        //Printing Service : The below property is used to calculate the amount that needs to be deducted from the On Order
        [System.Runtime.Serialization.IgnoreDataMember]
        public SYS_DOC_Header PurchaseOrder { get; set; }
        
        //Sales Order - Used to find out what quantity need to be cancelled when converting Quote to Sales Order
        [System.Runtime.Serialization.IgnoreDataMember]
        public SYS_DOC_Header Quote { get; set; }
        
        //Transaction objects
        public ORG_TRX_Header ORG_TRX_Header { get; set; }
        public ITM_BOM_Document ITM_BOM_Document { get; set; }
        public JOB_Header JOB_Header { get; set; }

        /// <summary>
        /// This is used when Saving the BOM Canceled or BOM Complete
        /// When saving the BOM Assembly Started and BOM Disassembly Started its fine to use the ITM_BOM_Document but when the ITM_BOM_Document has 
        /// already been saved the Proxy Object cannot be sent to the service
        /// </summary>
        Int64 bomDocumentId;
        public Int64 BOMDocumentId
        {
            get { return ITM_BOM_Document == null ? bomDocumentId : ITM_BOM_Document.Id; }
            set { if (bomDocumentId != value) bomDocumentId = value; }
        }

        [System.Runtime.Serialization.IgnoreDataMember]
        public System.Windows.Forms.Form OriginForm { get; set; }

        public Int64? CalendarId { get; set; }

        decimal total;
        public decimal Total
        {
            get { return this.SYS_DOC_Line.Sum(n => n.Total); }
            internal set { total = value; }
        }
        decimal totaltax;
        public decimal TotalTax
        {
            get { return Math.Round(this.SYS_DOC_Line.Sum(n => n.TotalTax), 2, MidpointRounding.AwayFromZero); }
            internal set { totaltax = value; }
        }
        decimal totalIncl;
        public decimal TotalIncl
        {
            get { return Math.Round(this.SYS_DOC_Line.Sum(n => n.Total + n.TotalTax), 2, MidpointRounding.AwayFromZero); }
            internal set { totalIncl = value; }
        }

        /// <summary>
        /// TAX Invoice = True if Completely credited
        /// Back Order = True if Invoiced or canceled
        /// Purchase Order = True if fully invoiced/canceled
        /// Goods Received = True if Completely credited
        /// Sales Quote = True if Sales Order has been created
        /// </summary>
        public bool Processed { get; set; }

        /// <summary>
        /// True when document has been generated from another document
        /// </summary>
        public bool Generated { get; set; }
    }

    public partial class SYS_DOC_Line
    {
        public SYS_DOC_Line()
        {
            this.Surcharge = new List<SYS_DOC_Line>();
        }

        //Used on WebPortal to display Item name on document
        public string ItemName { get; set; }
        
        /// <summary>
        /// Place holder does not persist
        /// </summary>
        public decimal UnitCost { get; set; }
        
        /// <summary>
        /// Place holder does not persist
        /// </summary>
        public decimal UnitAverage { get; set; }
        
        /// <summary>
        /// Purchase Order = Shows the Quantity that has been received
        /// Purchase Invoice = Shows the Quantity that has been received
        /// Goods Returned = The total Quantity received if generated from a Purchase Order
        /// TAX Invoice = The total Quantity that has been credited
        /// </summary> 
        public decimal QtyReceived { get; set; }
        
        /// <summary>
        /// Purchase Order = Shows the Quantity that is still receivable
        /// Purchase Invoice = Shows the Quantity that is still receivable
        /// </summary>
        decimal qtyOutstanding = 0;
        
        public decimal QtyOutstanding
        {
            get
            {
                return qtyOutstanding;
            }
            set
            {
               qtyOutstanding = value;
            }
        }

        /// <summary>
        /// TAX Invoice = The total amount that has been credited
        /// Goods Received = The total amount that has been credited
        /// </summary>
        public decimal AmountCredited { get; set; }
        
        /// <summary>
        /// TAX Invoice = The total amount that has been invoiced 
        /// Purchase Order = The total amount that has been invoiced 
        /// </summary>
        public decimal AmountInvoiced { get; set; }
        
        public decimal? ProfitPercentage { get { return (this.Amount > 0) ? (this.Amount - this.UnitAverage) / this.Amount : 0M; } }
        
        public bool PriceChanged { get; set; }
        
        public DB.ITM_Movement Movement { get; set; } 
        
        public DB.VW_LineItem LineItem { get; set; }

        /// <summary>
        /// Temporary storage for Buyout Transaction
        /// </summary>
        public DB.IBO_TRX_Header IBO_TRX_Header { get; set; }

        public bool IsBOMCompleteResultItem { get; set; }

        /// <summary>
        /// Returns the total of the line this property does not persist
        /// </summary>
        public decimal TotalAmount {
            get { return Math.Round(Total + TotalTax, 2, MidpointRounding.AwayFromZero); } 
        }

        //JOB Variables
        public bool NewJobLine { get; set; }
        public Int64 ParentLineId { get; set; }
        public bool FromJob { get; set; }

        public List<SYS_DOC_Line> Surcharge { get; set; }
    }

    public partial class GLX_Header
    {
        public bool IsYearendHeader { get; set; }
        public Int64 ReferencePeriodId { get; set; }
    }

    public partial class GLX_Recon
    {
        public Int64 EntityId { get; set; }
    }

    public partial class GLX_SiteAccount
    {
        public bool MakeSiteDefault { get; set; }
    }

    public partial class GLX_Account
    {
        public bool IsNewAccount { get; set; }
        public GLX_SiteAccount SiteAccount { get; set; }
    }

    public partial class GLX_Tax
    {
        public decimal Percentage { get { return this.Amount / 100; } }
    }

    public interface IBaseEntity
    {
        /// <summary>
        /// Is set to true when Properties on and Entity is changed
        /// </summary>
        bool HasChanges { get; set; }
        /// <summary>
        /// List of Properties that have changes on the entity
        /// </summary>
        List<string> ChangeList { get; set; }
        /// <summary>
        /// The next change on the Entity will not trigger the HasChanges
        /// </summary>
        bool IgnoreChanges { get; set; }
    }
}


 