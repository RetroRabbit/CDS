using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using System.Xml;
using CDS.Util.TextPrinter.Document;
using CDS.Util.TextPrinter.Statement;
using DevExpress.Xpo;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Web.DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CDSService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CDSService.svc or CDSService.svc.cs at the Solution Explorer and start debugging.
    public class CDSService : ICDSService
    {
        static object _lock = new object();
        BL.DataContext DataContext { get; set; }

        private static List<CDS.Client.DataAccessLayer.Types.Statement> statements;

        private static List<CDS.Client.DataAccessLayer.Types.Statement> Statements
        {
            get
            {
                return statements;
            }
            set
            {
                statements = value;
            }
        }

        private static XmlDocument salesSalesPrintTemplate = null;

        private static XmlDocument purchaseSalesPrintTemplate = null;

        private static XmlDocument adjustmentSalesPrintTemplate = null;

        private static XmlDocument receiptSalesPrintTemplate = null;

        private static XmlDocument pickingSlipSalesPrintTemplate = null;

        private static XmlDocument workSalesPrintTemplate = null;

        private static XmlDocument statementCustomerPrintTemplate = null;

        private static XmlDocument statementSupplierPrintTemplate = null;

        private static XmlDocument SalesPrintTemplate
        {
            get
            {
                if (salesSalesPrintTemplate == null)
                {
                    salesSalesPrintTemplate = new XmlDocument();
                    salesSalesPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SALES_PRINTER_TEMPLATE"]));
                }
                return salesSalesPrintTemplate;
            }
        }

        private static XmlDocument PurchaseSalesPrintTemplate
        {
            get
            {
                if (purchaseSalesPrintTemplate == null)
                {
                    purchaseSalesPrintTemplate = new XmlDocument();
                    purchaseSalesPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["PURCHASE_PRINTER_TEMPLATE"]));
                }
                return purchaseSalesPrintTemplate;
            }
        }

        private static XmlDocument AdjustmentSalesPrintTemplate
        {
            get
            {
                if (adjustmentSalesPrintTemplate == null)
                {
                    adjustmentSalesPrintTemplate = new XmlDocument();
                    adjustmentSalesPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ADJUSTMENT_PRINTER_TEMPLATE"]));
                }
                return adjustmentSalesPrintTemplate;
            }
        }

        private static XmlDocument ReceiptSalesPrintTemplate
        {
            get
            {
                if (receiptSalesPrintTemplate == null)
                {
                    receiptSalesPrintTemplate = new XmlDocument();
                    receiptSalesPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["RECEIPT_PRINTER_TEMPLATE"]));
                }
                return receiptSalesPrintTemplate;
            }
        }

        private static XmlDocument PickingSlipSalesPrintTemplate
        {
            get
            {
                if (pickingSlipSalesPrintTemplate == null)
                {
                    pickingSlipSalesPrintTemplate = new XmlDocument();
                    pickingSlipSalesPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["PICKING_SLIP_PRINTER_TEMPLATE"]));
                }
                return pickingSlipSalesPrintTemplate;
            }
        }

        private static XmlDocument WorkSalesPrintTemplate
        {
            get
            {
                if (workSalesPrintTemplate == null)
                {
                    workSalesPrintTemplate = new XmlDocument();
                    workSalesPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["WORK_PRINTER_TEMPLATE"]));
                }
                return workSalesPrintTemplate;
            }
        }

        private static XmlDocument StatementCustomerPrintTemplate
        {
            get
            {
                if (statementCustomerPrintTemplate == null)
                {
                    statementCustomerPrintTemplate = new XmlDocument();
                    statementCustomerPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["CUSTOMER_STATEMENT_PRINTER_TEMPLATE"]));
                }
                return statementCustomerPrintTemplate;
            }
        }

        private static XmlDocument StatementSupplierPrintTemplate
        {
            get
            {
                if (statementSupplierPrintTemplate == null)
                {
                    statementSupplierPrintTemplate = new XmlDocument();
                    statementSupplierPrintTemplate.Load(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SUPPLIER_STATEMENT_PRINTER_TEMPLATE"]));
                }
                return statementSupplierPrintTemplate;
            }
        }

        public CDSService()
        {
            BL.ApplicationDataContext.Instance.SetConnections(ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString, true);
            BL.ApplicationDataContext.Instance.SqlCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"]);
            DataContext = new BL.DataContext();
        }

        public String PrintDocument(DB.SYS_DOC_Header entity, long printer)
        {
            String message = "";
            try
            {
                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(entity.CreatedBy.Value, DataContext);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                message += String.Format("Success,{0},{1}", entity.DocumentNumber, entity.TrackId);
                if (printer != 0) RegisterPrintJob(entity.Id, printer);
            }
            catch (Exception ex)
            {
                message = "Exception : " + ex.ToString();
            }
            return message;
        }

        public String SaveDocument(DB.SYS_DOC_Header entity, long printer)
        {
            String message = "";
            try
            {
                long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                //Clear the document number as it is only assigned if equal to NULL or -1
                entity.DocumentNumber = null;
                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(entity.CreatedBy.Value, DataContext);
                BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSite = BL.ApplicationDataContext.Instance.SystemEntityContext.SYS_Site.Include("SYS_Entity").FirstOrDefault(n => n.EntityId == defaultSiteId);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                BL.EntityController.SaveSYS_DOC_Header(entity, DataContext);
                //TODO : Need to check if this works
                entity = DataContext.EntitySystemContext.SYS_DOC_Header.FirstOrDefault(n => n.Id == entity.Id);
                message += String.Format("Success,{0},{1}", entity?.DocumentNumber, entity?.TrackId);
                if (printer != 0) RegisterPrintJob(entity.Id, printer);
            }
            catch (Exception ex)
            {
                message = "Exception : " + ex.ToString();
            }
            return message;
        }

        public String PrintDocument(long id, long printerBy, long printer)
        {
            String message = "";
            try
            {

                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(printerBy, DataContext);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                if (printer != 0) RegisterPrintJob(id, printer);
                message += String.Format("Success");
            }
            catch (Exception ex)
            {
                message = "Exception : " + ex.ToString();
            }
            return message;
        }

        /// <summary>
        /// Approve a document.
        /// Credit Note: - Create GLX Account entries for credit note if GLX module is enabled 
        ///              - Create ITM Movement entries for C/N if ITM module is enabled
        /// </summary>
        /// <param name="entityId">SYS_DOC_Header Id of document to be approved</param>
        /// <param name="personId">SYS_Person Id of user approving document</param>
        /// <returns>Success message on success.
        /// Exception message on exception
        /// </returns>
        public String ApproveDocument(long entityId, long personId)
        {
            String message = "";
            try
            {
                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(personId, DataContext);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                DB.SYS_DOC_Header entity = BL.SYS.SYS_DOC_Header.Load(entityId, DataContext, new List<string> { "SYS_DOC_Line" });
                entity.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.LoadByHeaderId(entityId, DataContext);
                BL.EntityController.ApproveSYS_DOC_Header(entity, DataContext);
                message += String.Format("Success,{0},{1}", entity.DocumentNumber, entity.TrackId);
            }
            catch (Exception ex)
            {
                message = "Exception : " + ex.ToString();
            }
            return message;
        }

        /// <summary>
        /// Cancels document with Holding Movement
        /// </summary>
        /// <param name="entityId">SYS_DOC_Header Id of document to be approved</param>
        /// <param name="personId">SYS_Person Id of user approving document</param>
        /// <returns>Success message on success.
        /// Exception message on exception
        /// </returns>
        public String CancelDocument(long entityId, long personId)
        {
            String message = "";
            try
            {
                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(personId, DataContext);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                DB.SYS_DOC_Header entity = BL.SYS.SYS_DOC_Header.Load(entityId, DataContext, new List<string> { "SYS_DOC_Line" });
                entity.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.LoadByHeaderId(entityId, DataContext);
                BL.EntityController.CancelSYS_DOC_Header(entity, DataContext);
                message += String.Format("Success,{0},{1}", entity.DocumentNumber, entity.TrackId);
            }
            catch (Exception ex)
            {
                message = "Exception : " + ex.ToString();
            }
            return message;
        }

        /// <summary>
        /// Cancel a document.
        /// Purchase Order: ???
        /// Credit Note: ???
        /// </summary>
        /// <param name="entityId">SYS_DOC_Header Id of document to be approved</param>
        /// <param name="personId">SYS_Person Id of user approving document</param>
        /// <returns>Success message on success.
        /// Exception message on exception
        /// </returns>
        public String RejectDocument(long entityId, long personId)
        {
            String message = "";
            try
            {
                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(personId, DataContext);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                DB.SYS_DOC_Header entity = BL.SYS.SYS_DOC_Header.Load(entityId, DataContext, new List<string> { "SYS_DOC_Line" });
                entity.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.LoadByHeaderId(entityId, DataContext);
                BL.EntityController.RejectSYS_DOC_Header(entity, DataContext);
                message += String.Format("Success,{0},{1}", entity.DocumentNumber, entity.TrackId);
            }
            catch (Exception ex)
            {
                message = "Exception : " + ex.ToString();
            }
            return message;
        }

        /// <summary>
        /// Saves all the new job lines for a specified Job Header
        /// </summary>
        /// <param name="headerid">Job Header Id</param>
        /// <param name="lines">New lines to be saved</param>
        /// <param name="printer">Printer Id of the printer where the job is to be printed</param>
        /// <returns>A message is returned to notify if lines were saved successfully or if an error occurred</returns>
        public String SaveJobLines(long headerid, List<DB.SYS_DOC_Line> lines, long printer)
        {
            String message = "";
            try
            {
                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(lines[0].CreatedBy.Value, DataContext);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                DB.SYS_DOC_Header entity = BL.SYS.SYS_DOC_Header.Load(headerid, DataContext);
                BL.EntityController.AddJobLines(entity, lines, DataContext);
                message += String.Format("Success,{0},{1}", entity.DocumentNumber, entity.TrackId);
                if (printer != 0) RegisterPrintJob(entity.Id, printer);
            }
            catch (Exception ex)
            {
                message = "Exception : " + ex.ToString();
            }

            return message;
        }

        /// <summary>
        /// Received AOR_Order object and created Purchase Order Documents
        /// </summary>
        /// <param name="order"></param>
        /// <param name="printer"></param>
        /// <returns></returns>
        public String GenerateOrder(long orderId, long createdBy, long printer)
        {
            string message = "";
            try
            {
                var order = BL.AOR.AOR_Order.Load(orderId, DataContext, new List<string>() { "AOR_OrderLine" });
                BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(createdBy, DataContext);
                BL.ApplicationDataContext.Instance.PopulateModuleAccess();
                BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
                decimal vatPercentage = BL.ApplicationDataContext.Instance.CompanySite.VatPercentage;
                List<DB.SYS_DOC_Header> purchaseOrders = new List<DB.SYS_DOC_Header>();
                foreach (var supplier in order.AOR_OrderLine.GroupBy(n => n.SupplierId).Select(n => new { EntityId = n.Key, Lines = n }))
                {
                    var supplierdetail = DataContext.ReadonlyContext.VW_Company.Where(n => n.EntityId == supplier.EntityId && n.TypeId == (byte)BL.ORG.ORG_Type.Supplier).Select(n => new { n.Id, CostCategory = n.CostCategoryId }).FirstOrDefault();

                    DB.SYS_DOC_Header header = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.PurchaseOrder);
                    header.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.New;
                    header.ORG_TRX_Header.CompanyId = supplierdetail.Id;
                    header.ORG_TRX_Header.ReferenceShort1 = orderId.ToString("D10");
                    System.Threading.Tasks.Parallel.ForEach(supplier.Lines, line =>
                    {
                        DB.SYS_DOC_Line docLine = BL.SYS.SYS_DOC_Line.New;
                        docLine.ItemId = line.InventoryId;
                        docLine.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == docLine.ItemId);
                        docLine.Description = line.Name;
                        docLine.Amount = line.UnitCost.Value;
                        docLine.Quantity = line.OrderAmount.Value;
                        docLine.Total = line.Total.Value;
                        switch (supplierdetail.CostCategory)
                        {
                            case (byte)BL.ORG.ORG_CostCategory.SellingPriceIncludingSalesTax:
                                docLine.TotalTax = docLine.Total * vatPercentage / 100;
                                break;
                            case (byte)BL.ORG.ORG_CostCategory.SellingPriceExcludingSalesTax:
                                docLine.TotalTax = 0;
                                break;
                            case (byte)BL.ORG.ORG_CostCategory.CostIncludingSalesTax:
                                docLine.TotalTax = docLine.Total * vatPercentage / 100;
                                break;
                            case (byte)BL.ORG.ORG_CostCategory.CostExcludingSalesTax:
                                docLine.TotalTax = 0;
                                break;
                            case (byte)BL.ORG.ORG_CostCategory.AverageCostExcludingSalesTax:
                                docLine.TotalTax = 0;
                                break;
                        }
                        line.TotalTax = docLine.TotalTax;
                        lock (header.SYS_DOC_Line)
                        {
                            header.SYS_DOC_Line.Add(docLine);
                            docLine.LineOrder = header.SYS_DOC_Line.Count();
                        }
                    });
                    purchaseOrders.Add(header);
                }



                try
                {
                    purchaseOrders.ForEach(n =>
                    {
                        string result = SaveDocument(n, printer);
                        if (result.StartsWith("Exception"))
                            throw new Exception(result.Split(':')[1]);
                        else
                            message += String.Format(";{0},{1}", n.DocumentNumber, n.TrackId);
                    });

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        order.OrderDate = BL.ApplicationDataContext.Instance.ServerDateTime;
                        BL.EntityController.SaveAOR_Order(order, DataContext);
                        DataContext.SaveChangesEntityOrderingContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityOrderingContext.AcceptAllChanges();

                }
                catch (Exception ex)
                {
                    DataContext.EntityOrderingContext.RejectChanges();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                return "Exception : " + ex.ToString();
            }
            return "Success" + message;
        }

        public List<string> GetAvailablePrinter(string excludeLocation)
        {
            List<string> printers = new List<string>();
            String pkInstalledPrinters;
            for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i];
                printers.Add(pkInstalledPrinters);
            }
            var locations = DataContext.EntitySystemContext.SYS_Printer.Select(l => l.Location).ToList<string>();
            return printers.Where(n => n == excludeLocation || !locations.Contains(n)).ToList();
        }

        //Distributed Transaction Coordinator
        public bool DistributedTransactionServiceRunning()
        {
            System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController("MSDTC");
            if (sc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
            {
                sc.Start();
                try
                {
                    sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                }
                catch (System.ServiceProcess.TimeoutException)
                {
                    return false;
                }
            }
            return sc.Status == System.ServiceProcess.ServiceControllerStatus.Running;
        }

        private void RegisterPrintJob(long documentId, long printerId)
        {
            try
            {
                using (TransactionScope transaction = DataContext.GetTransactionScope())
                {
                    DB.SYS_Printer printer = BL.SYS.SYS_Printer.Load(printerId, DataContext);
                    DB.SYS_DOC_Header document = BL.SYS.SYS_DOC_Header.Load(documentId, DataContext);


                    switch (printer.PrinterType)
                    {
                        case "DOTMATRIX":
                            switch (document.TypeId)
                            {
                                case (byte)BL.SYS.SYS_DOC_Type.Quote:
                                case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                                case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, SalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                                    if (BL.SYS.SYS_DOC_Header.LoadByTrackId(document.TrackId, BL.SYS.SYS_DOC_Type.TAXInvoice, DataContext) != null)
                                    {
                                        document = BL.SYS.SYS_DOC_Header.LoadByTrackId(document.TrackId, BL.SYS.SYS_DOC_Type.TAXInvoice, DataContext);
                                        DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, SalesPrintTemplate.OuterXml, document.Id, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    }
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, SalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, PickingSlipSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                                case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                                case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, PurchaseSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                                case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                                case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                                case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, AdjustmentSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.Job:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, WorkSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                            }
                            break;
                        case "INKJET":
                            PrintReportDocument(printer.Location, document.Title, document.TypeId.Value, documentId);
                            break;
                        case "RECEIPT":
                            switch (document.TypeId)
                            {
                                case (byte)BL.SYS.SYS_DOC_Type.Quote:
                                case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                                case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, ReceiptSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                                    if (BL.SYS.SYS_DOC_Header.LoadByTrackId(document.TrackId, BL.SYS.SYS_DOC_Type.TAXInvoice, DataContext) != null)
                                    {
                                        document = BL.SYS.SYS_DOC_Header.LoadByTrackId(document.TrackId, BL.SYS.SYS_DOC_Type.TAXInvoice, DataContext);
                                        if (printer.PrinterType == "RECEIPT")
                                            DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, ReceiptSalesPrintTemplate.OuterXml, document.Id, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    }
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, ReceiptSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, ReceiptSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                                case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                                case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, ReceiptSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                                case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                                case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                                case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, ReceiptSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.Job:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                                case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                                    DocumentPrinter.Instance.PrintDocument(printer.Location, printer.PrinterModel, ReceiptSalesPrintTemplate.OuterXml, documentId, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                                    break;
                            }
                            break;
                    }

                    BL.ORG.ORG_TRX_Header.SetDateFirstPrinted(document.Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, DataContext);
                    BL.ORG.ORG_TRX_Header.SetDateLastPrinted(document.Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, DataContext);
                    DataContext.EntityOrganisationContext.SaveChanges();
                    DataContext.CompleteTransaction(transaction);
                }
                DataContext.EntityOrganisationContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                DataContext.EntityOrganisationContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                throw new Exception("Failed to Register print job /n" + ex.ToString());
            }
        }

        private void PrintReportDocument(string location, string jobName, byte typeId, long documentId)
        {
            DB.RPT_Report rptReport = null;

            switch (typeId)
            {
                case (byte)BL.SYS.SYS_DOC_Type.Quote:
                case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                    rptReport = BL.RPT.RPT_Report.LoadByName("Sales Document Template", DataContext);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                    rptReport = BL.RPT.RPT_Report.LoadByName("Picking Slip Document Template", DataContext);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                    rptReport = BL.RPT.RPT_Report.LoadByName("Purchase Document Template", DataContext);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                    rptReport = BL.RPT.RPT_Report.LoadByName("Transfer Document Template", DataContext);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    rptReport = BL.RPT.RPT_Report.LoadByName("Stock Document Template", DataContext);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.Job:
                    rptReport = BL.RPT.RPT_Report.LoadByName("Work Document Template", DataContext);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                    rptReport = BL.RPT.RPT_Report.LoadByName("Work Document Template", DataContext);
                    break;
            }

            System.IO.Stream xmlstream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(rptReport.Data));

            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
            report.LoadLayoutFromXml(xmlstream);

            foreach (object oObject in report.ObjectStorage)
            {
                if (oObject is DevExpress.XtraReports.Parameters.LookUpSettings)
                {
                    object dataSource = (oObject as DevExpress.XtraReports.Parameters.LookUpSettings).DataSource;

                    if (dataSource is DevExpress.DataAccess.Sql.SqlDataSource)
                        ((DevExpress.DataAccess.Sql.SqlDataSource)(dataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
                    else if (dataSource is DevExpress.DataAccess.EntityFramework.EFDataSource)
                        ((DevExpress.DataAccess.EntityFramework.EFDataSource)(dataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString;
                    else
                        throw new Exception("Data Source type not implemented in reports");
                }
            }

            foreach (object oObject in report.ComponentStorage)
            {
                if (oObject is DevExpress.DataAccess.Sql.SqlDataSource)
                    ((DevExpress.DataAccess.Sql.SqlDataSource)(oObject)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
                else if (oObject is DevExpress.DataAccess.EntityFramework.EFDataSource)
                    ((DevExpress.DataAccess.EntityFramework.EFDataSource)(oObject)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString;
                else
                    throw new Exception("Data Source type not implemented in reports");
            }

            if (report.Parameters.Count != 0)
            {
                foreach (var extparam in report.Parameters)
                {
                    if (extparam.Name == "DocumentId")
                    {
                        extparam.Value = documentId;
                    }
                }
            }

            try
            {
                report.CreateDocument(false);
                report.PrintingSystem.Document.Name = jobName;
                using (DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report))
                {
                    // Send the report to the specified printer.
                    printTool.Print(location);
                }
            }
            catch (Exception ex)
            {
                DataContext.EntityOrganisationContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void ProcessStatements(long personId, long periodId, long? printerId, List<CDS.Client.DataAccessLayer.Types.Statement> statements)
        {
            BL.ApplicationDataContext.Instance.LoggedInUser = (DB.SEC_User)BL.SEC.SEC_User.LoadByPerson(personId, DataContext);
            BL.ApplicationDataContext.Instance.PopulateModuleAccess();
            BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();

            Statements = statements;
            using (var uow = new DevExpress.Xpo.UnitOfWork())
            {
                Statements.ForEach(s =>
                {
                    var period = uow.Query<XDB.SYS_Period>().SingleOrDefault(n => n.Id == periodId);
                    var currentuser = uow.Query<XDB.SYS_Person>().SingleOrDefault(n => n.Id == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId);
                    var entity = uow.Query<XDB.SYS_Entity>().SingleOrDefault(n => n.Id == s.EntityId);
                    XDB.GLX_Statement stmt = new XDB.GLX_Statement(uow)
                    {
                        EntityId = entity,
                        CreatedBy = currentuser,
                        PeriodId = period,
                        ShouldEmail = s.ShouldEmail,
                        ShouldPrint = s.ShouldPrint
                    };
                });

                uow.CommitChanges();
            }
            using (var uow = new DevExpress.Xpo.UnitOfWork())
            {
                //System.Threading.Tasks.Parallel.ForEach(
                    foreach(var s in
                    uow.Query<XDB.GLX_Statement>().Where(n =>
                    n.ShouldEmail && n.HasMailed == null ||
                    n.ShouldPrint && n.HasPrinted == null)
                    )
                //, s =>
                {
                    using (var iuow = new DevExpress.Xpo.UnitOfWork())
                    {
                        if (s.ShouldPrint)
                            Statements.SingleOrDefault(n => n.EntityId == s.EntityId.Id).HasPrinted = ProcessStatementPrint(s.Id, printerId); 

                        //System.Threading.Thread.Sleep(2000);

                        if (s.ShouldEmail)
                            Statements.SingleOrDefault(n => n.EntityId == s.EntityId.Id).HasMailed = ProcessStatementEmail(s.Id);

                        //System.Threading.Thread.Sleep(2000);

                        iuow.CommitChanges();
                    }
                }
                //);
            }

            Statements = null;
        }

        private bool ProcessStatementEmail(long statementId)
        {
            bool HasMailed;

            using (var uow = new DevExpress.Xpo.UnitOfWork())
            {
                XDB.GLX_Statement statement = uow.Query<XDB.GLX_Statement>().SingleOrDefault(n => n.Id == statementId);

                var account = uow.Query<XDB.GLX_Account>().SingleOrDefault(n => n.EntityId.Id == statement.EntityId.Id);
                XDB.ORG_Company company = null;

                if (account.EntityId.CodeMain == BL.ApplicationDataContext.Instance.SiteAccounts.DebtorsEntity.CodeMain)
                {
                    company = uow.Query<XDB.ORG_Company>().SingleOrDefault(n => n.TypeId.Id == (byte)BL.ORG.ORG_Type.Customer && n.EntityId.EntityId.CodeSub == account.EntityId.CodeSub);
                }
                else
                    if (account.EntityId.CodeMain == BL.ApplicationDataContext.Instance.SiteAccounts.CreditorsEntity.CodeMain)
                    {
                        company = uow.Query<XDB.ORG_Company>().SingleOrDefault(n => n.TypeId.Id == (byte)BL.ORG.ORG_Type.Supplier && n.EntityId.EntityId.CodeSub == account.EntityId.CodeSub);
                    }

                if (!System.Text.RegularExpressions.Regex.IsMatch(company.AccountsContactEmail,
                     @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    return false;



                try
                {
                    DB.RPT_Report rptReport = BL.RPT.RPT_Report.LoadByName("Account Statement", DataContext);

                    System.IO.Stream xmlstream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(rptReport.Data));

                    DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
                    report.LoadLayoutFromXml(xmlstream);

                    if (report.DataSource is DevExpress.DataAccess.Sql.SqlDataSource)
                        ((DevExpress.DataAccess.Sql.SqlDataSource)(report.DataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
                    else
                        throw new Exception("Data Source type not implemented in reports");

                    DevExpress.XtraReports.Parameters.ParameterCollection Parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();
                    Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "Account", Value = statement.EntityId.Id });
                    Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "Period", Value = statement.PeriodId.Id });

                    if (Parameters.Count != 0)
                    {
                        foreach (var extparam in Parameters)
                        {
                            foreach (var param in report.Parameters)
                            {
                                if (extparam.Name == param.Name)
                                {
                                    param.Value = extparam.Value;
                                    break;
                                }
                            }
                        }
                    }

                 

                    // Create a new memory stream and export the report into it as PDF.
                    System.IO.MemoryStream mem = new System.IO.MemoryStream();
                    report.ExportToPdf(mem);

                    // Create a new attachment and put the PDF report into it.
                    mem.Seek(0, System.IO.SeekOrigin.Begin);
                    System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(mem, account.EntityId.CodeMain + ".pdf", "application/pdf");

                    // Create a new message and attach the PDF report to it.
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.Attachments.Add(att);

                    report.ExportOptions.Email.RecipientAddress = company.AccountsContactEmail;
                    report.ExportOptions.Email.RecipientName = company.AccountsContactName;
                    report.ExportOptions.Email.Subject = "Statement of Account for ACC# " + account.EntityId.CodeSub;
                    report.ExportOptions.Email.Body = string.Format("Please see attached Statement of Account for ACC# {0} ({1:N2})", account.EntityId.CodeSub, account.EntityId.AccountBalance);

                    // Specify sender and recipient options for the e-mail message.
                    mail.From = new System.Net.Mail.MailAddress(BL.ApplicationDataContext.Instance.CompanySite.AccountEmailAddress, BL.ApplicationDataContext.Instance.LoggedInUser.DisplayName);
                    mail.To.Add(new System.Net.Mail.MailAddress(report.ExportOptions.Email.RecipientAddress,
                        report.ExportOptions.Email.RecipientName));

                    // Specify other e-mail options.
                    mail.Subject = report.ExportOptions.Email.Subject;
                    mail.Body = report.ExportOptions.Email.Body;

                    // Send the e-mail message via the specified SMTP server.
                    System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(BL.ApplicationDataContext.Instance.CompanySite.SMTPServerLocation, 587);
                    if (BL.ApplicationDataContext.Instance.CompanySite.AccountEmailPassword != null && BL.ApplicationDataContext.Instance.CompanySite.AccountEmailPassword != string.Empty)
                    {
                        System.Net.NetworkCredential credential =
                            new System.Net.NetworkCredential(BL.ApplicationDataContext.Instance.CompanySite.AccountEmailUsername, BL.ApplicationDataContext.Instance.CompanySite.AccountEmailPassword);

                        if (BL.ApplicationDataContext.Instance.CompanySite.AccountEmailDomain != string.Empty)
                            credential.Domain = BL.ApplicationDataContext.Instance.CompanySite.AccountEmailDomain;

                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = credential;
                        smtpClient.EnableSsl = true;
                    }
                    smtpClient.Send(mail);

                    // Close the memory stream.
                    mem.Close();
                    mem.Flush();
                    statement.HasMailed = HasMailed = true;
                }
                catch (Exception ex) 
                {
                    statement.HasMailed = HasMailed = false;
                }

                uow.CommitChanges();
            }
            return HasMailed;
        }

        private bool ProcessStatementPrint(long statementId, long? printerId)
        {
            bool HasPrinted;

            if (!printerId.HasValue)
                return false;

            using (var uow = new DevExpress.Xpo.UnitOfWork())
            {
                XDB.GLX_Statement statement = uow.Query<XDB.GLX_Statement>().SingleOrDefault(n => n.Id == statementId);

                XDB.SYS_Printer printer = uow.Query<XDB.SYS_Printer>().SingleOrDefault(n => n.Id == printerId.Value);

                try
                {
                    var account = uow.Query<XDB.GLX_Account>().Where(n => n.EntityId.Id == statement.EntityId.Id).Select(l => new { l.EntityId.CodeMain, l.EntityId.CodeSub }).FirstOrDefault();

                    if (account.CodeMain == BL.ApplicationDataContext.Instance.SiteAccounts.DebtorsEntity.CodeMain)
                    {

                        StatementPrinter sp = new StatementPrinter();
                        sp.PrintStatement(printer.Location, printer.PrinterModel, StatementCustomerPrintTemplate.OuterXml, statement.EntityId.Id, statement.PeriodId.Id, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);

                        //sp = new StatementPrinter();
                        //if (!System.IO.Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Statements"))
                        //    System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Statements");
                        //
                        //sp.PrintStatementToFile(string.Format(@"{0}\STATEMENT_{1}.txt", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Statements", statement.EntityId.Id), printer.PrinterModel, StatementCustomerPrintTemplate.OuterXml, statement.EntityId.Id, statement.PeriodId.Id, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                    }
                    else
                        if (account.CodeMain == BL.ApplicationDataContext.Instance.SiteAccounts.CreditorsEntity.CodeMain)
                        {
                            StatementPrinter sp = new StatementPrinter();
                            sp.PrintStatement(printer.Location, printer.PrinterModel, StatementSupplierPrintTemplate.OuterXml, statement.EntityId.Id, statement.PeriodId.Id, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);

                            //sp = new StatementPrinter();
                            //if (!System.IO.Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Statements"))
                            //    System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Statements");
                            //
                            //sp.PrintStatementToFile(string.Format(@"{0}\STATEMENT_{1}.txt", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Statements", statement.EntityId.Id), printer.PrinterModel, StatementSupplierPrintTemplate.OuterXml, statement.EntityId.Id, statement.PeriodId.Id, ConfigurationManager.ConnectionStrings["BaseConnection"].ConnectionString);
                        }

                    statement.HasPrinted = HasPrinted = true;
                }
                catch 
                {
                    statement.HasPrinted = HasPrinted = false;
                }

                uow.CommitChanges();
            }

            return HasPrinted;
        }

        public List<CDS.Client.DataAccessLayer.Types.Statement> ProcessStatementsUpdate()
        {
            return Statements;
        }

    }
}