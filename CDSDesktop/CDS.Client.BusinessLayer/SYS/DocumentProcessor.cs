using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;

namespace CDS.Client.BusinessLayer.SYS
{
    public static class DocumentProcessor
    {
        private static DB.SYS_DOC_Header CopyDocument(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = ApplicationDataContext.DeepClone<DB.SYS_DOC_Header>(entity, SYS.SYS_DOC_Document.New(SYS.SYS_DOC_Type.Quote));
            docHeader.DocumentNumber = null;
            DB.ORG_TRX_Header trxHeader = null;
            if (entity.ORG_TRX_Header != null)
                trxHeader = ApplicationDataContext.DeepClone<DB.ORG_TRX_Header>(entity.ORG_TRX_Header, ORG.ORG_TRX_Header.New);
            DB.JOB_Header jobHeader = null;
            if (entity.JOB_Header != null)
                jobHeader = ApplicationDataContext.DeepClone<DB.JOB_Header>(entity.JOB_Header, JOB.JOB_Header.New);

            foreach (DB.SYS_DOC_Line line in entity.SYS_DOC_Line)
            {
                DB.SYS_DOC_Line newLine = ApplicationDataContext.DeepClone<DB.SYS_DOC_Line>(line, SYS.SYS_DOC_Line.New);

                //Werner: Wanted to do this here but some of the document needs these values to generate another document
                ////Need to clear these when copying a documents lines
                //newLine.QtyReceived = 0;
                //newLine.QtyOutstanding = 0;
                //TODO : Just check but this should always be null as the DeepCopy
                //ignores all DB.* types
                if (line.LineItem != null)
                    newLine.LineItem = line.LineItem;
                else
                {
                    if (!dataContext.ReadonlyContext.VW_LineItem.Any(n => n.Id == newLine.ItemId && n.TypeId == (byte)SYS.SYS_Type.Account))
                    {
                        newLine.LineItem = dataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == newLine.ItemId);
                        newLine.UnitAverage = newLine.LineItem.UnitAverage;
                        newLine.UnitCost = newLine.LineItem.UnitCost;
                    }
                }

                docHeader.SYS_DOC_Line.Add(newLine);
            }

            docHeader.ORG_TRX_Header = trxHeader;
            docHeader.JOB_Header = jobHeader;

            return docHeader;
        }

        /// <summary>
        /// Creates a Sales Order from Quote
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateSalesOrderFromQuote(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);

            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.SalesOrder;
            docHeader.Quote = entity;
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                line.QtyOutstanding = line.QtyReceived = 0;
                if (line.Quantity > line.LineItem.OnHand)
                {
                    if (!SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR))
                    {
                        line.Quantity = line.LineItem.OnHand;
                    }
                    else if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR))
                    {
                        line.QtyOutstanding = line.Quantity - line.LineItem.OnHand;
                    }
                }
            }
            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Creates a Sales Order from Back Order
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateSalesOrderFromBackOrder(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);

            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.SalesOrder;
            docHeader.BackOrder = CopyDocument(entity, dataContext);
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                if (line.QtyOutstanding > line.LineItem.OnHand)
                {
                    line.Quantity = line.LineItem.OnHand;
                }
                else
                {
                    line.Quantity = line.QtyOutstanding;
                }
                line.QtyOutstanding = line.QtyReceived = 0;
            }
            docHeader.Generated = true;
            return docHeader;
        }
        
        /// <summary>
        /// Creates a Purchase Order from Back Order
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreatePurchaseOrderFromBackOrder(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);
            //Need to clear SelectedCompany
            docHeader.ORG_TRX_Header.CompanyId = 0;
            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.PurchaseOrder;
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                line.QtyOutstanding = line.QtyReceived = 0; 
                switch (line.LineItem.TypeId)
                { 
                    case (byte)SYS.SYS_Type.Inventory:
                        line.Amount = line.LineItem.UnitCost;
                        break;
                    case (byte)SYS.SYS_Type.Account:
                        line.Amount = line.Amount - line.AmountInvoiced;
                        break;
                } 
            }
            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Only for use when saving a Sales Order
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateTaxInvoiceFromSalesOrder(DB.SYS_DOC_Header entity, DataContext dataContext)
        {

            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);

            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.TAXInvoice;
            docHeader.SalesOrder = entity;

            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                //Need to do this as total needs to change if only partially invoiced
                line.Quantity = line.Quantity - line.QtyOutstanding;
                line.Total = Math.Round(line.Amount * (line.LineItem.TypeId == (byte)SYS.SYS_Type.Account ? 1 : line.Quantity), 2, MidpointRounding.AwayFromZero);
                // Henko - TODO: Check if Tax should be added for this company - no access to company....
                line.TotalTax = line.Total * ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
            }

            //if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR))
            //    docHeader.BackOrder = CreateBackOrderFromSalesOrder(entity, dataContext);

            return docHeader;
        }

        /// <summary>
        /// For use in this class only 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateBackOrderFromSalesOrder(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            //If there is no BackOrder quantities return null
            if (!entity.SYS_DOC_Line.Any(n => n.QtyOutstanding != 0))
                return null;

            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);

            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.BackOrder;
            docHeader.SalesOrder = entity;
            docHeader.SiteId = Convert.ToInt64(ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                line.Quantity = line.QtyOutstanding;
                line.Total = Math.Round(line.Amount * (line.LineItem.TypeId == (byte)SYS.SYS_Type.Account ? 1 : line.Quantity), 2, MidpointRounding.AwayFromZero);
                // Henko - TODO: Check if Tax should be added for this company - no access to company....
                line.TotalTax = line.Total * ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
            }
            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Creates a Sales Credit Note from TAX Invoice
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateCreditNoteFromTAXInvoice(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);

            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.CreditNote;
            docHeader.TaxInvoice = CopyDocument(entity, dataContext);
            //Remove lines that you have no received items for
            List<DB.SYS_DOC_Line> removeLines = new List<DB.SYS_DOC_Line>();
            Parallel.ForEach(docHeader.SYS_DOC_Line.Where(n => (n.LineItem.TypeId == (byte)SYS.SYS_Type.Account && n.Amount == n.AmountCredited)
                                                                            || (n.LineItem.TypeId == (byte)SYS.SYS_Type.Inventory && n.QtyReceived == 0)),
            line =>
            {
                removeLines.Add(line);
            });

            removeLines.ForEach(n => docHeader.SYS_DOC_Line.Remove(n));

            //Populate Quantity on Goods Returned for returnable items 
            Parallel.ForEach(docHeader.SYS_DOC_Line.Where(n => (n.LineItem.TypeId == (byte)SYS.SYS_Type.Account && n.Amount != n.AmountCredited)
                                                                        || (n.LineItem.TypeId == (byte)SYS.SYS_Type.Inventory && n.QtyReceived != 0)),
            line =>
            {
                switch (line.LineItem.TypeId)
                {
                    case (byte)SYS.SYS_Type.Account:
                        line.Amount = line.Amount - line.AmountCredited;
                        break;
                    case (byte)SYS.SYS_Type.Inventory:
                        line.Quantity = line.QtyReceived;
                        break;
                }
            }); 
            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Creates Goods Returned from Goods Received
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateGoodsReturnedFromGoodsReceived(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);

            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.GoodsReturned;

            //Remove lines that you have no received items for
            List<DB.SYS_DOC_Line> removeLines = new List<DB.SYS_DOC_Line>();
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line.Where(n => (n.LineItem.TypeId == (byte)SYS.SYS_Type.Account && n.Amount == n.AmountCredited)
                                                                            || (n.LineItem.TypeId == (byte)SYS.SYS_Type.Inventory && n.QtyReceived == 0)))
            {
                removeLines.Add(line);
            }
            removeLines.ForEach(n => docHeader.SYS_DOC_Line.Remove(n));
            
            //Populate Quantity on Goods Returned for returnable items
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line.Where(n => (n.LineItem.TypeId == (byte)SYS.SYS_Type.Account && n.Amount != n.AmountCredited)
                                                                            || (n.LineItem.TypeId == (byte)SYS.SYS_Type.Inventory && n.QtyReceived != 0)))
            {
                switch (line.LineItem.TypeId)
                {
                    case (byte)SYS.SYS_Type.Account:
                        line.Amount = Math.Min(line.Amount, line.Amount - line.AmountCredited);
                        break;
                    case (byte)SYS.SYS_Type.Inventory:
                        line.Quantity = Math.Min(line.Quantity, line.QtyReceived);
                        break;
                }
            }

           
            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Creates Goods Received from Purchase Order
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateGoodsReceivedFromPurchaseOrder(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);
            docHeader.PurchaseOrder = CopyDocument(entity, dataContext);
            //Is already set not sure why I did it
            //docHeader.PurchaseOrder.TypeId = (byte)SYS.SYS_DOC_Type.PurchaseOrder;
            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.GoodsReceived;

            //Remove lines that you have no received items for
            List<DB.SYS_DOC_Line> removeLines = new List<DB.SYS_DOC_Line>();
            Parallel.ForEach(docHeader.SYS_DOC_Line.Where(n => (n.LineItem.TypeId == (byte)SYS.SYS_Type.Account && n.Amount == n.AmountInvoiced)
                                                                            || (n.LineItem.TypeId == (byte)SYS.SYS_Type.Inventory && n.QtyOutstanding == 0)),
            line =>
            {
                removeLines.Add(line);
            });
            removeLines.ForEach(n => docHeader.SYS_DOC_Line.Remove(n));

            Parallel.ForEach(docHeader.SYS_DOC_Line, line=> {
                line.Quantity = line.QtyOutstanding;
                if (line.LineItem.TypeId == (byte)SYS.SYS_Type.Account)
                    line.Amount = line.Amount - line.AmountInvoiced;
            });

            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Creates Quote from Job
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateQuoteFromJob(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);
            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.Quote;
            docHeader.ORG_TRX_Header = ORG.ORG_TRX_Header.New;            

            docHeader.ORG_TRX_Header.CompanyId = docHeader.JOB_Header.CompanyId;
            docHeader.ORG_TRX_Header.Telephone = docHeader.JOB_Header.Telephone;
            docHeader.ORG_TRX_Header.ContactPerson = docHeader.JOB_Header.ContactPerson;
            docHeader.ORG_TRX_Header.ContactTelephone = docHeader.JOB_Header.ContactTelephone; 
            docHeader.ORG_TRX_Header.ReferenceShort1 = docHeader.JOB_Header.ReferenceShort1;
            docHeader.ORG_TRX_Header.ReferenceShort2 = docHeader.JOB_Header.ReferenceShort2;
            docHeader.ORG_TRX_Header.ReferenceShort3 = docHeader.JOB_Header.ReferenceShort3;
            docHeader.ORG_TRX_Header.ReferenceShort4 = docHeader.JOB_Header.ReferenceShort4;
            docHeader.ORG_TRX_Header.ReferenceShort5 = docHeader.JOB_Header.ReferenceShort5;
            docHeader.ORG_TRX_Header.ReferenceLong1 = docHeader.JOB_Header.ReferenceLong1;
            docHeader.ORG_TRX_Header.ReferenceLong2 = docHeader.JOB_Header.ReferenceLong2;
            docHeader.ORG_TRX_Header.ReferenceLong3 = docHeader.JOB_Header.ReferenceLong3;
            docHeader.ORG_TRX_Header.ReferenceLong4 = docHeader.JOB_Header.ReferenceLong4;
            docHeader.ORG_TRX_Header.ReferenceLong5 = docHeader.JOB_Header.ReferenceLong5;
            docHeader.ORG_TRX_Header.ShippingAddressLine1 = docHeader.JOB_Header.ShippingAddressLine1;
            docHeader.ORG_TRX_Header.ShippingAddressLine2 = docHeader.JOB_Header.ShippingAddressLine2;
            docHeader.ORG_TRX_Header.ShippingAddressLine3 = docHeader.JOB_Header.ShippingAddressLine3;
            docHeader.ORG_TRX_Header.ShippingAddressLine4 = docHeader.JOB_Header.ShippingAddressLine4;
            docHeader.ORG_TRX_Header.ShippingAddressCode = docHeader.JOB_Header.ShippingAddressCode;
            docHeader.ORG_TRX_Header.BillingAddressLine1 = docHeader.JOB_Header.BillingAddressLine1;
            docHeader.ORG_TRX_Header.BillingAddressLine2 = docHeader.JOB_Header.BillingAddressLine2;
            docHeader.ORG_TRX_Header.BillingAddressLine3 = docHeader.JOB_Header.BillingAddressLine3;
            docHeader.ORG_TRX_Header.BillingAddressLine4 = docHeader.JOB_Header.BillingAddressLine4;
            docHeader.ORG_TRX_Header.BillingAddressCode = docHeader.JOB_Header.BillingAddressCode;

            DB.VW_Company company = dataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == docHeader.ORG_TRX_Header.CompanyId);
            decimal sellPrice, discountPrice, discountPercentage;
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                ORG.ORG_TRX_PriceHelper.GetSellPrice(line, company, line.Quantity, true, out sellPrice, out discountPrice, out discountPercentage, dataContext);
                line.Amount = discountPrice;
                line.DiscountPercentage = discountPercentage;
                //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;

                line.Total = line.Amount * line.Quantity;
                 
                switch (company.CostCategoryId)
                {
                    case (byte)ORG.ORG_CostCategory.SellingPriceIncludingSalesTax:
                        line.TotalTax = (line.Amount * line.Quantity) * ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)ORG.ORG_CostCategory.SellingPriceExcludingSalesTax:
                        break;
                    case (byte)ORG.ORG_CostCategory.CostIncludingSalesTax:
                        line.TotalTax = (line.Amount * line.Quantity) * ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)ORG.ORG_CostCategory.CostExcludingSalesTax:
                        break;
                    case (byte)ORG.ORG_CostCategory.AverageCostExcludingSalesTax:
                        break;
                }

                line.TotalTax = Math.Round(line.TotalTax, 2, MidpointRounding.AwayFromZero);
            }
            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Creates Quote from Job
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateSalesOrderFromJob(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);
            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.SalesOrder;
            docHeader.ORG_TRX_Header = ORG.ORG_TRX_Header.New;

            docHeader.ORG_TRX_Header.CompanyId = docHeader.JOB_Header.CompanyId;
            docHeader.ORG_TRX_Header.Telephone = docHeader.JOB_Header.Telephone;
            docHeader.ORG_TRX_Header.ContactPerson = docHeader.JOB_Header.ContactPerson;
            docHeader.ORG_TRX_Header.ContactTelephone = docHeader.JOB_Header.ContactTelephone;
            docHeader.ORG_TRX_Header.ReferenceShort1 = docHeader.JOB_Header.ReferenceShort1;
            docHeader.ORG_TRX_Header.ReferenceShort2 = docHeader.JOB_Header.ReferenceShort2;
            docHeader.ORG_TRX_Header.ReferenceShort3 = docHeader.JOB_Header.ReferenceShort3;
            docHeader.ORG_TRX_Header.ReferenceShort4 = docHeader.JOB_Header.ReferenceShort4;
            docHeader.ORG_TRX_Header.ReferenceShort5 = docHeader.JOB_Header.ReferenceShort5;
            docHeader.ORG_TRX_Header.ReferenceLong1 = docHeader.JOB_Header.ReferenceLong1;
            docHeader.ORG_TRX_Header.ReferenceLong2 = docHeader.JOB_Header.ReferenceLong2;
            docHeader.ORG_TRX_Header.ReferenceLong3 = docHeader.JOB_Header.ReferenceLong3;
            docHeader.ORG_TRX_Header.ReferenceLong4 = docHeader.JOB_Header.ReferenceLong4;
            docHeader.ORG_TRX_Header.ReferenceLong5 = docHeader.JOB_Header.ReferenceLong5;
            docHeader.ORG_TRX_Header.ShippingAddressLine1 = docHeader.JOB_Header.ShippingAddressLine1;
            docHeader.ORG_TRX_Header.ShippingAddressLine2 = docHeader.JOB_Header.ShippingAddressLine2;
            docHeader.ORG_TRX_Header.ShippingAddressLine3 = docHeader.JOB_Header.ShippingAddressLine3;
            docHeader.ORG_TRX_Header.ShippingAddressLine4 = docHeader.JOB_Header.ShippingAddressLine4;
            docHeader.ORG_TRX_Header.ShippingAddressCode = docHeader.JOB_Header.ShippingAddressCode;
            docHeader.ORG_TRX_Header.BillingAddressLine1 = docHeader.JOB_Header.BillingAddressLine1;
            docHeader.ORG_TRX_Header.BillingAddressLine2 = docHeader.JOB_Header.BillingAddressLine2;
            docHeader.ORG_TRX_Header.BillingAddressLine3 = docHeader.JOB_Header.BillingAddressLine3;
            docHeader.ORG_TRX_Header.BillingAddressLine4 = docHeader.JOB_Header.BillingAddressLine4;
            docHeader.ORG_TRX_Header.BillingAddressCode = docHeader.JOB_Header.BillingAddressCode;

            DB.VW_Company company = dataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == docHeader.ORG_TRX_Header.CompanyId);
            
            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                decimal sellPrice = 0, discountPrice = 0, discountPercentage = 0;

                if ((new byte[] { (byte)SYS.SYS_Type.Inventory, (byte)SYS.SYS_Type.BuyOut }).Contains(line.LineItem.TypeId))
                {
                    ORG.ORG_TRX_PriceHelper.GetSellPrice(line, company, line.Quantity, true, out sellPrice, out discountPrice, out discountPercentage, dataContext);

                    line.Amount = discountPrice;
                    line.DiscountPercentage = discountPercentage; 
                }
                line.Total = Math.Round(line.Amount * (line.LineItem.TypeId == (byte)SYS.SYS_Type.Account ? 1 : line.Quantity), 2, MidpointRounding.AwayFromZero);

                //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;                

                switch (company.CostCategoryId)
                {
                    case (byte)ORG.ORG_CostCategory.SellingPriceIncludingSalesTax:
                        line.TotalTax = line.Total * ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)ORG.ORG_CostCategory.SellingPriceExcludingSalesTax:
                        line.TotalTax = 0;
                        break;
                    case (byte)ORG.ORG_CostCategory.CostIncludingSalesTax:
                        line.TotalTax = line.Total * ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)ORG.ORG_CostCategory.CostExcludingSalesTax:
                        line.TotalTax = 0;
                        break;
                    case (byte)ORG.ORG_CostCategory.AverageCostExcludingSalesTax:
                        line.TotalTax = 0;
                        break;
                }

                line.TotalTax = Math.Round(line.TotalTax, 2, MidpointRounding.AwayFromZero);
                line.FromJob = true;
            }
            docHeader.Generated = true;
            return docHeader;
        }

        /// <summary>
        /// Creates Job from Quote
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DB.SYS_DOC_Header CreateJobFromJobQuote(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            DB.SYS_DOC_Header docHeader = CopyDocument(entity, dataContext);
            docHeader.TypeId = (byte)SYS.SYS_DOC_Type.Job;
            docHeader.JOB_Header = JOB.JOB_Header.New;

            docHeader.JOB_Header.CompanyId = docHeader.ORG_TRX_Header.CompanyId;
            docHeader.JOB_Header.Telephone = docHeader.ORG_TRX_Header.Telephone;
            docHeader.JOB_Header.ContactPerson = docHeader.ORG_TRX_Header.ContactPerson;
            docHeader.JOB_Header.ContactTelephone = docHeader.ORG_TRX_Header.ContactTelephone;
            docHeader.JOB_Header.ReferenceShort1 = docHeader.ORG_TRX_Header.ReferenceShort1;
            docHeader.JOB_Header.ReferenceShort2 = docHeader.ORG_TRX_Header.ReferenceShort2;
            docHeader.JOB_Header.ReferenceShort3 = docHeader.ORG_TRX_Header.ReferenceShort3;
            docHeader.JOB_Header.ReferenceShort4 = docHeader.ORG_TRX_Header.ReferenceShort4;
            docHeader.JOB_Header.ReferenceShort5 = docHeader.ORG_TRX_Header.ReferenceShort5;
            docHeader.JOB_Header.ReferenceLong1 = docHeader.ORG_TRX_Header.ReferenceLong1;
            docHeader.JOB_Header.ReferenceLong2 = docHeader.ORG_TRX_Header.ReferenceLong2;
            docHeader.JOB_Header.ReferenceLong3 = docHeader.ORG_TRX_Header.ReferenceLong3;
            docHeader.JOB_Header.ReferenceLong4 = docHeader.ORG_TRX_Header.ReferenceLong4;
            docHeader.JOB_Header.ReferenceLong5 = docHeader.ORG_TRX_Header.ReferenceLong5;
            docHeader.JOB_Header.ShippingAddressLine1 = docHeader.ORG_TRX_Header.ShippingAddressLine1;
            docHeader.JOB_Header.ShippingAddressLine2 = docHeader.ORG_TRX_Header.ShippingAddressLine2;
            docHeader.JOB_Header.ShippingAddressLine3 = docHeader.ORG_TRX_Header.ShippingAddressLine3;
            docHeader.JOB_Header.ShippingAddressLine4 = docHeader.ORG_TRX_Header.ShippingAddressLine4;
            docHeader.JOB_Header.ShippingAddressCode = docHeader.ORG_TRX_Header.ShippingAddressCode;
            docHeader.JOB_Header.BillingAddressLine1 = docHeader.ORG_TRX_Header.BillingAddressLine1;
            docHeader.JOB_Header.BillingAddressLine2 = docHeader.ORG_TRX_Header.BillingAddressLine2;
            docHeader.JOB_Header.BillingAddressLine3 = docHeader.ORG_TRX_Header.BillingAddressLine3;
            docHeader.JOB_Header.BillingAddressLine4 = docHeader.ORG_TRX_Header.BillingAddressLine4;
            docHeader.JOB_Header.BillingAddressCode = docHeader.ORG_TRX_Header.BillingAddressCode;
            docHeader.JOB_Header.Date1 = null;
            docHeader.JOB_Header.Date2 = null;
            docHeader.JOB_Header.Date3 = null;

            foreach (DB.SYS_DOC_Line line in docHeader.SYS_DOC_Line)
            {
                switch (line.LineItem.TypeId)
                {
                    case (byte)SYS.SYS_Type.Account:
                        break;
                    case (byte)SYS.SYS_Type.Inventory:
                    case (byte)SYS.SYS_Type.BuyOut:
                        line.Quantity = Math.Min(line.Quantity, line.LineItem.OnHand);
                        line.Amount = line.LineItem.UnitAverage;
                        line.Total = line.Quantity * line.Amount;
                        line.TotalTax = 0;
                        break;
                }
            }

            return docHeader;
        }
    }
}
