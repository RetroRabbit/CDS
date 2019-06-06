using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using XDB = CDS.Client.DataAccessLayer.XDB;
using SECL = CDS.Client.BusinessLayer.SEC;
using DevExpress.Xpo;

namespace CDS.Client.Desktop.Document
{
    public partial class BaseDocumentList : CDS.Client.Desktop.Essential.BaseList
    {
        public BL.SYS.SYS_DOC_Type? DocumentType { get; set; }
        private Int64? TrackId { get; set; }
          
        public BaseDocumentList()
        {
            InitializeComponent();
        }

        public BaseDocumentList(BL.SYS.SYS_DOC_Type documentType)
        {
            InitializeComponent();
            DocumentType = documentType;
        }

        public BaseDocumentList(BL.SYS.SYS_DOC_Type? documentType, Int64 trackId)
        {
            InitializeComponent();
            DocumentType = documentType;
            this.TrackId = trackId;
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (DocumentType != null)
            {
                
                byte documentType = (byte)DocumentType;
                this.Text = DataContext.EntitySystemContext.SYS_DOC_Type.Where(n => n.Id.Equals(documentType)).Select(n => n.Name).FirstOrDefault();
                
                if (ReferenceEquals(XPOInstantFeedbackSource.FixedFilterCriteria, null))
                    XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[HeaderId.TypeId.Id] = ? AND [HeaderId.SiteId.Id] = ?", (byte)DocumentType.Value, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);

                XPQuery<XDB.SYS_DOC_Header> customers = Session.DefaultSession.Query<XDB.SYS_DOC_Header>();

                var docs = customers.Take(50).Select(c => c);
            }
            this.SuperTipParameter = this.Text + "," + this.Text;
        }

        protected override void BindData()
        { 
            try
            {
                base.BindData();
                //GridView.ActiveFilterString = String.Format("[HeaderId.SiteId.Id] = {0}", BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSite.EntityId);
                if (TrackId != null)
                    GridView.ActiveFilterString = String.Format("[HeaderId.TrackId.Id] = {0}", TrackId);
                
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (DocumentType == null)
            {
                AllowNewRecord = false;
            }
            else
            {
                switch ((byte)DocumentType)
                {
                    case (byte)BL.SYS.SYS_DOC_Type.Quote:
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.JobQuote:
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                        //Werner: This will open a new Sales Order
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOTIRECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSCRECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOPORECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOGRRECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                        AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDORURECR);
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                        //Werner - Users aren't allowed to create Sales Back Orders from scratch need to be generated from Sales Order
                        //AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR);
                        AllowNewRecord = false;
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                        //Henko - TODO: Transfer removed for now
                        //AllowNewRecord = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INDOTF);
                        AllowNewRecord = false;
                        break;
                    case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                        //Werner: You will no longer be able to create Inventory Adjustment from scratch will be done from the Inventory Form
                        AllowNewRecord = false;
                        break;
                }
            }
        }

        protected override void OnOpenRecord(long Id)
        {
            base.OnOpenRecord(Id);

            if (DocumentType == null)
            {
                XDB.SYS_DOC_Header entry = ((XDB.ORG_TRX_Header)((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(GridView.GetFocusedRow())).OriginalRow).HeaderId;
                DocumentType = ((BL.SYS.SYS_DOC_Type)entry.TypeId.Id);
            }
            Essential.BaseForm child = null;

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    child = new Document.Customer.QuoteForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    child = new Document.Customer.SalesOrderForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    child = new Document.Customer.TAXInvoiceForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    child = new Document.Customer.CreditNoteForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    child = new Document.Supplier.PurchaseOrderForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    child = new Document.Supplier.GoodsReceivedForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    child = new Document.Supplier.GoodsReturnedForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    child = new Document.Customer.BackOrderForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.JobQuote:
                    child = new Document.Customer.JobQuoteForm(Id);
                    break;
            }
            ShowForm(child);
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();

            Essential.BaseForm child = null;

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    child = new Document.Customer.QuoteForm();
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    child = new Document.Customer.SalesOrderForm();
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    //Werner: Cannot create TAX Invoice from scratch
                    child = new Document.Customer.SalesOrderForm();
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    child = new Document.Customer.CreditNoteForm();
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    child = new Document.Supplier.PurchaseOrderForm();
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    child = new Document.Supplier.GoodsReceivedForm();
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    child = new Document.Supplier.GoodsReturnedForm();
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    child = new Document.Customer.BackOrderForm();
                    break;
                case BL.SYS.SYS_DOC_Type.JobQuote:
                    child = new Document.Customer.JobQuoteForm();
                    break;
            }

            ShowForm(child);
        }
    }
}
