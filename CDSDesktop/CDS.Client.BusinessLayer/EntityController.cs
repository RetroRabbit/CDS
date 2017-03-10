using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;

namespace CDS.Client.BusinessLayer
{
    public class EntityController
    {

        public static bool SaveCAL_Attachment(DB.CAL_Attachment entity, DataContext dataContext)
        {
            return BL.CAL.CAL_Attachment.Save(entity, dataContext) == "Success";
        }

        public static bool SaveCAL_Calendar(DB.CAL_Calendar entity, DataContext dataContext)
        {
            return BL.CAL.CAL_Calendar.Save(entity, dataContext) == "Success";
        }

        public static bool SaveCAT_Catalogue(DB.CAT_Catalogue entity, DataContext dataContext)
        {
            return BL.CAT.CAT_Catalogue.Save(entity, dataContext) == "Success";
        }

        public static bool SaveCAT_Category(DB.CAT_Category entity, DataContext dataContext)
        {
            return BL.CAT.CAT_Category.Save(entity, dataContext) == "Success";
        }

        public static bool SaveCAT_Meta(DB.CAT_Meta entity, DataContext dataContext)
        {
            return BL.CAT.CAT_Meta.Save(entity, dataContext) == "Success";
        }

        public static bool SaveCAT_Item(DB.CAT_Item entity, DataContext dataContext)
        {
            return BL.CAT.CAT_Item.Save(entity, dataContext) == "Success";
        }

        public static bool SaveCAT_MetaData(DB.CAT_MetaData entity, DataContext dataContext)
        {
            return BL.CAT.CAT_MetaData.Save(entity, dataContext) == "Success";
        }

        public static bool SaveCAT_ItemData(DB.CAT_ItemData entity, DataContext dataContext)
        {
            return BL.CAT.CAT_ItemData.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_DIS_Discount(DB.ITM_DIS_Discount entity, DataContext dataContext)
        {
            return BL.ITM.ITM_DIS_Discount.Save(entity, dataContext) == "Success";
        }

        public static bool SaveGLX_Account(DB.GLX_Account entity, DataContext dataContext)
        {
            string result = string.Empty;
            BL.GLX.GLX_Account.Save(entity, dataContext);
            if (entity.SiteAccount != null)
            {
                if (entity.SiteAccount.TypeId != -1)
                {
                    entity.SiteAccount.EntityId = entity.EntityId;
                    if (entity.SiteAccount.MakeSiteDefault)
                    {
                        if (BL.GLX.SiteAccounts.ClearSiteAccounts(entity.SiteAccount.TypeId, dataContext) == 0)
                        {
                            throw new CDS.Shared.Exception.DataAccessException("Error saving", "Could not mark as Default Site Account", new Exception());
                        }
                    }
                    SaveGLX_SiteAccount(entity.SiteAccount, dataContext);
                }
                else
                {
                    BL.GLX.GLX_SiteAccount.Delete(entity.SiteAccount, dataContext);
                }
            }
            dataContext.SaveChangesEntityAccountingContext();
            //Check that this is a new entity 
            if (entity.IsNewAccount)
            {
                BL.ApplicationDataContext.Instance.ReloadProfitDistributionAccount();
                if (BL.GLX.GLX_History.GenerateAccountBalances(entity, dataContext) == 0)
                {
                    throw new CDS.Shared.Exception.DataAccessException("Error saving", "Could not generate Account Balances", new Exception());
                }
            }
            return result == "Success";
        }

        public static bool SaveGLX_Budget(DB.GLX_Budget entity, DataContext dataContext)
        {
            return BL.GLX.GLX_Budget.Save(entity, dataContext) == "Success";
        }

        public static bool SaveGLX_BulkEntryRule(DB.GLX_BulkEntryRule entity, DataContext dataContext)
        {
            return BL.GLX.GLX_BulkEntryRule.Save(entity, dataContext) == "Success";
        }

        public static bool SaveGLX_Header(DB.GLX_Header entity, DataContext dataContext)
        {
            return BL.GLX.GLX_Header.Save(entity, dataContext) == "Success";
        }

        public static bool SaveGLX_Line(DB.GLX_Line entity, DataContext dataContext)
        {
            return BL.GLX.GLX_Line.Save(entity, dataContext) == "Success";
        }

        public static bool SaveGLX_Recon(DB.GLX_Recon entity, DataContext dataContext)
        {
            return BL.GLX.GLX_Recon.Save(entity, dataContext) == "Success";
        }

        public static bool SaveGLX_SiteAccount(DB.GLX_SiteAccount entity, DataContext dataContext)
        {
            return BL.GLX.GLX_SiteAccount.Save(entity, dataContext) == "Success";
        }

        public static bool SaveGLX_Tax(DB.GLX_Tax entity, DataContext dataContext)
        {
            return BL.GLX.GLX_Tax.Save(entity, dataContext) == "Success";
        }

        public static bool SaveHRS_Role(DB.HRS_Role entity, DataContext dataContext)
        {
            return BL.HRS.HRS_Role.Save(entity, dataContext) == "Success";
        }

        public static bool SaveHRS_Employee(DB.HRS_Employee entity, DataContext dataContext)
        {
            return BL.HRS.HRS_Employee.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_BOM_Document(DB.ITM_BOM_Document entity, DataContext dataContext)
        {
            return BL.ITM.ITM_BOM_Document.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_BOM_Recipe(DB.ITM_BOM_Recipe entity, DataContext dataContext)
        {
            return BL.ITM.ITM_BOM_Recipe.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_BOM_RecipeLine(DB.ITM_BOM_RecipeLine entity, DataContext dataContext)
        {
            return BL.ITM.ITM_BOM_RecipeLine.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_History(DB.ITM_History entity, DataContext dataContext)
        {
            return BL.ITM.ITM_History.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_Inventory(DB.ITM_Inventory entity, DataContext dataContext)
        {
            string result = string.Empty;
            //DONT SAVE THE INVENTORY ITEM IT WILL BE GENERATED BELOW
            //entity IS USED AS A TEMPLATE
            //If this is a new item add the item for all sites and generate history
            if (dataContext.EntityInventoryContext.GetEntityState(entity) == System.Data.Entity.EntityState.Detached)
            {
                //List<DB.ITM_Inventory> newInventories = new List<DB.ITM_Inventory>();
                //foreach (DB.SYS_Site site in dataContext.EntitySystemContext.SYS_Site)
                //{
                DB.ITM_Inventory inventory = (DB.ITM_Inventory)BL.ApplicationDataContext.DeepClone(entity, BL.ITM.ITM_Inventory.New);
                //    newInventory.Id = 0; 
                //    newInventories.Add(newInventory);
                //}
                //foreach (DB.ITM_Inventory inventory in newInventories)
                {
                    inventory.EntityId = entity.EntityId;
                    BL.ITM.ITM_Inventory.Save(inventory, dataContext);
                    dataContext.SaveChangesEntityInventoryContext();
                    BL.ITM.ITM_Inventory.GenerateInventoryHistory(inventory, dataContext);

                    //Werner C Scheffer
                    //Need to place entity into CurrentHolding.ITM_Inventory so that I can use the UpdateUnitCost and UpdateUnitPrice
                    entity.CurrentHolding.InventoryId = entity.EntityId;
                    BL.ITM.ITM_History.UpdateHistoryUnitCost(entity.EntityId, entity.CurrentHolding.UnitCost, dataContext);
                    BL.ITM.ITM_History.UpdateHistoryUnitPrice(entity.EntityId, entity.CurrentHolding.UnitPrice, dataContext);

                    if (entity.FromBuyout)
                    {
                        BL.ITM.ITM_History.UpdateHistoryUnitAverage(entity.EntityId, entity.CurrentHolding.UnitCost, dataContext);
                        BL.ITM.ITM_History.UpdateHistoryOnHand((byte)BL.SYS.SYS_DOC_Type.GoodsReceived, entity.EntityId, entity.CurrentHolding.OnHand, dataContext);

                        if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                        {
                            DB.GLX_Header glxHeader = BL.GLX.GLX_Header.New;
                            glxHeader.Date = BL.ApplicationDataContext.Instance.ServerDateTime;
                            glxHeader.Description = string.Format("Buyout movement for item");
                            glxHeader.ReferencePeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
                            glxHeader.PeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
                            glxHeader.PostedDate = glxHeader.Date;
                            glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Journal;
                            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
                            glxHeader.ReferenceId = null;
                            glxHeader.Reference = String.Format("Buyout Movement");

                            DB.SYS_Tracking tracking = BL.SYS.SYS_Tracking.New;
                            BL.EntityController.SaveSYS_Tracking(tracking, dataContext);
                            //TODO: Werner - I'm not allowed to do this but i dont see any other way except to move the GLX code to the Form
                            dataContext.SaveChangesEntitySystemContext();
                            glxHeader.TrackId = tracking.Id;


                            // INVENTORY BUYOUT
                            DB.GLX_Line glx_line_inventory_buyout = BL.GLX.GLX_Line.New;
                            glx_line_inventory_buyout.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.InventoryBuyout.EntityId;
                            glx_line_inventory_buyout.AgingId = 1;
                            glx_line_inventory_buyout.Amount = -(entity.CurrentHolding.OnHand * entity.CurrentHolding.UnitAverage);
                            glx_line_inventory_buyout.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory_buyout.EntityId, dataContext).CenterId;
                            glxHeader.GLX_Line.Add(glx_line_inventory_buyout);

                            // INVENTORY ENTRY
                            DB.GLX_Line glx_line_inventory = BL.GLX.GLX_Line.New;
                            glx_line_inventory.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                            glx_line_inventory.AgingId = 1;
                            glx_line_inventory.Amount = entity.CurrentHolding.OnHand * entity.CurrentHolding.UnitAverage;
                            glx_line_inventory.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory.EntityId, dataContext).CenterId;
                            glxHeader.GLX_Line.Add(glx_line_inventory);

                            BL.GLX.GLX_Header.InsertProfitDistributionEntries(glxHeader, dataContext);
                            BL.EntityController.SaveGLX_Header(glxHeader, dataContext);
                            BL.GLX.GLX_Header.UpdateLedgerAccountBalance(glxHeader, dataContext);

                        }
                    }
                }
            }
            else
            {
                if (dataContext.EntityInventoryContext.GetChangedEntries().FirstOrDefault(n => n.Entity == entity.CurrentHolding) != null)
                    if (entity.CurrentHolding.UnitCost != (dataContext.EntityInventoryContext.GetOriginal<DB.ITM_History>(entity.CurrentHolding)).UnitCost)
                    {
                        BL.ITM.ITM_History.UpdateHistoryUnitCost(entity.EntityId, entity.CurrentHolding.UnitCost, dataContext);
                    }
                if (dataContext.EntityInventoryContext.GetChangedEntries().FirstOrDefault(n => n.Entity == entity.CurrentHolding) != null)
                    if (entity.CurrentHolding.UnitPrice != (dataContext.EntityInventoryContext.GetOriginal<DB.ITM_History>(entity.CurrentHolding)).UnitPrice)
                    {
                        BL.ITM.ITM_History.UpdateHistoryUnitPrice(entity.EntityId, entity.CurrentHolding.UnitPrice, dataContext);
                    }
            }
            return result == "Success";
        }

        public static bool SaveITM_InventorySupplier(DB.ITM_InventorySupplier entity, DataContext dataContext)
        {
            return BL.ITM.ITM_InventorySupplier.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_Movement(DB.ITM_Movement entity, DataContext dataContext)
        {
            return BL.ITM.ITM_Movement.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_Surcharge(DB.ITM_Surcharge entity, DataContext dataContext)
        {
            return BL.ITM.ITM_Surcharge.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_StockTake(DB.ITM_StockTake entity, DataContext dataContext)
        {
            return BL.ITM.ITM_StockTake.Save(entity, dataContext) == "Success";
        }

        public static bool SaveITM_StockTakeItem(DB.ITM_StockTakeItem entity, DataContext dataContext)
        {
            return BL.ITM.ITM_StockTakeItem.Save(entity, dataContext) == "Success";
        }

        public static bool SaveORG_Company(DB.ORG_Company entity, DataContext dataContext)
        {
            return BL.ORG.ORG_Company.Save(entity, dataContext) == "Success";
        }

        public static bool SaveORG_CompanyAddress(DB.ORG_CompanyAddress entity, DataContext dataContext)
        {
            return BL.ORG.ORG_CompanyAddress.Save(entity, dataContext) == "Success";
        }

        public static bool SaveORG_Contact(DB.ORG_Contact entity, DataContext dataContext)
        {
            return BL.ORG.ORG_Contact.Save(entity, dataContext) == "Success";
        }

        public static bool SaveORG_Entity(DB.ORG_Entity entity, DataContext dataContext)
        {
            return BL.ORG.ORG_Entity.Save(entity, dataContext) == "Success";
        }

        public static bool SaveORG_TRX_Header(DB.ORG_TRX_Header entity, DataContext dataContext)
        {
            return BL.ORG.ORG_TRX_Header.Save(entity, dataContext) == "Success";
        }

        public static bool SaveORG_TRX_LostSale(DB.ORG_TRX_LostSale entity, DataContext dataContext)
        {
            return BL.ORG.ORG_TRX_LostSale.Save(entity, dataContext) == "Success";
        }

        public static bool SaveRPT_Analytic(DB.RPT_Analytic entity, DataContext dataContext)
        {
            return BL.RPT.RPT_Analytic.Save(entity, dataContext) == "Success";
        }

        public static bool SaveRPT_Report(DB.RPT_Report entity, DataContext dataContext)
        {
            return BL.RPT.RPT_Report.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSEC_Role(DB.SEC_Role entity, DataContext dataContext)
        {
            return BL.SEC.SEC_Role.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSEC_RoleAccess(DB.SEC_RoleAccess entity, DataContext dataContext)
        {
            return BL.SEC.SEC_RoleAccess.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSEC_User(DB.SEC_User entity, DataContext dataContext)
        {
            return BL.SEC.SEC_User.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSEC_UserRole(DB.SEC_UserRole entity, DataContext dataContext)
        {
            return BL.SEC.SEC_UserRole.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Abbreviation(DB.SYS_Abbreviation entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Abbreviation.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Address(DB.SYS_Address entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Address.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_DOC_Header(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            string result = string.Empty;
            List<DB.ITM_Movement> movements = new List<DB.ITM_Movement>();
            try
            {
                DB.GLX_Header glxHeader = null;
                using (TransactionScope transaction = dataContext.GetTransactionScope())
                {
                    //If there is not tracking object assign a new one
                    if (entity.TrackId == 0)
                    {
                        DB.SYS_Tracking sysTracking = BL.SYS.SYS_Tracking.New;
                        switch (entity.TypeId)
                        {
                            case (byte)BL.SYS.SYS_DOC_Type.Quote: sysTracking.Initiator = "Quote";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.SalesOrder: sysTracking.Initiator = "Sales Order";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.BackOrder: sysTracking.Initiator = "Back Order";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice: sysTracking.Initiator = "TAX Invoice";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.CreditNote: sysTracking.Initiator = "Credit Note";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.PickingSlip: sysTracking.Initiator = "Picking Slip";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder: sysTracking.Initiator = "Purchase Order";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived: sysTracking.Initiator = "Goods Received";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned: sysTracking.Initiator = "Goods Returned";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.Job: sysTracking.Initiator = "Job";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.TransferRequest: sysTracking.Initiator = "Transfer Request";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.TransferShipment: sysTracking.Initiator = "Transfer Shipment";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.TransferReceived: sysTracking.Initiator = "Transfer Received";
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment: sysTracking.Initiator = "Inventory Adjustment";
                                break;
                            default:
                                break;
                        }
                        BL.EntityController.SaveSYS_Tracking(sysTracking, dataContext);
                        dataContext.SaveChangesEntitySystemContext();
                        entity.SYS_Tracking = sysTracking;
                    }
                    else
                    {
                        entity.SYS_Tracking = dataContext.EntitySystemContext.SYS_Tracking.FirstOrDefault(n => n.Id == entity.TrackId);
                    }

                    //Populate Buyouts

                    //Items selected from grid
                    if (entity.SYS_DOC_Line.Any(n => n.IBO_TRX_Header == null && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut))
                    {
                        entity.ORG_TRX_Header.CompanyName = dataContext.ReadonlyContext.VW_Company.Where(n => n.Id == entity.ORG_TRX_Header.CompanyId).Select(l => l.Title).FirstOrDefault();
                        entity.SYS_DOC_Type = dataContext.EntitySystemContext.SYS_DOC_Type.FirstOrDefault(n => n.Id == entity.TypeId);

                        switch (entity.TypeId)
                        {
                            case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                            case (byte)BL.SYS.SYS_DOC_Type.CreditNote:

                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.IBO_TRX_Header == null && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut))
                                {
                                    var iBO_TRX_Header = BL.IBO.IBO_TRX_Header.New;
                                    iBO_TRX_Header.CustomerId = entity.ORG_TRX_Header.CompanyId;
                                    iBO_TRX_Header.Customer = entity.ORG_TRX_Header.CompanyName;
                                    iBO_TRX_Header.EntityId = line.ItemId;
                                    iBO_TRX_Header.Quantity = line.Quantity * entity.SYS_DOC_Type.HoldingModifier;
                                    iBO_TRX_Header.UnitCost = line.LineItem.UnitCost;
                                    iBO_TRX_Header.UnitPrice = line.LineItem.UnitPrice;
                                    line.IBO_TRX_Header = iBO_TRX_Header;
                                    BL.IBO.IBO_TRX_Header.Save(line.IBO_TRX_Header, dataContext);
                                    line.LineItem = dataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);
                                }
                                break;
                            case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                            case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.IBO_TRX_Header == null && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut))
                                {
                                    var iBO_TRX_Header = BL.IBO.IBO_TRX_Header.New;
                                    iBO_TRX_Header.SupplierId = entity.ORG_TRX_Header.CompanyId;
                                    iBO_TRX_Header.Supplier = entity.ORG_TRX_Header.CompanyName;
                                    iBO_TRX_Header.EntityId = line.ItemId;
                                    iBO_TRX_Header.Quantity = line.Quantity * entity.SYS_DOC_Type.HoldingModifier;
                                    iBO_TRX_Header.UnitCost = line.LineItem.UnitCost;
                                    iBO_TRX_Header.UnitPrice = line.LineItem.UnitPrice;
                                    line.IBO_TRX_Header = iBO_TRX_Header;
                                    BL.IBO.IBO_TRX_Header.Save(line.IBO_TRX_Header, dataContext);
                                    line.LineItem = dataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);
                                }
                                break;
                            default:
                                break;
                        }

                        dataContext.SaveChangesEntityBuyoutContext();

                    }
                    // Items added from Buyout Dialogue
                    else if (entity.SYS_DOC_Line.Any(n => n.IBO_TRX_Header != null))
                    {
                        // Need to populate LineItem at this point 
                        foreach (var line in entity.SYS_DOC_Line.Where(n => n.IBO_TRX_Header != null))
                        {
                            BL.IBO.IBO_TRX_Header.Save(line.IBO_TRX_Header, dataContext);
                            dataContext.SaveChangesEntityBuyoutContext();
                            line.LineItem = dataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);
                        }

                    }

                    //Save Document
                    switch (entity.TypeId)
                    {
                        case (byte)BL.SYS.SYS_DOC_Type.Quote:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);

                            DB.SYS_DOC_Header backorder;
                            DB.SYS_DOC_Header invoice;
                            //Henko: Now save invoice and back orders

                            if ((entity.SYS_DOC_Line.Any(n => n.Quantity - n.QtyOutstanding != 0) || entity.SYS_DOC_Line.Count == entity.SYS_DOC_Line.Count(n => n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)) && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR))
                            {
                                invoice = BL.SYS.DocumentProcessor.CreateTaxInvoiceFromSalesOrder(entity, dataContext);
                                invoice.SYS_Tracking = entity.SYS_Tracking;
                                BL.SYS.SYS_DOC_Header.Save(invoice, dataContext);
                                dataContext.SaveChangesEntitySystemContext();
                                invoice.ORG_TRX_Header.HeaderId = invoice.Id;
                                invoice.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                                BL.ORG.ORG_TRX_Header.Save(invoice.ORG_TRX_Header, dataContext);
                                //Henko - TODO: Maybe add setting for sales history is tax excl or incl
                                BL.ORG.ORG_History.UpdateCompanyHistory(invoice.ORG_TRX_Header.CompanyId, invoice.Total, dataContext);
                                //Cancels the quote if the quantities were changed on the Sales Order
                                var refDoc = BL.SYS.SYS_DOC_Document.LinkedDocuments(entity.TrackId, dataContext, new List<string>() { "SYS_DOC_Line" }).Where(n => (n.TypeId.Value == (byte)BL.SYS.SYS_DOC_Type.Quote || n.TypeId.Value == (byte)BL.SYS.SYS_DOC_Type.SalesOrder));
                                if (!refDoc.Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.SalesOrder) && refDoc.Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.Quote))
                                {
                                    var quote = refDoc.FirstOrDefault(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.Quote);

                                    quote.ORG_TRX_Header = dataContext.EntityOrganisationContext.ORG_TRX_Header.FirstOrDefault(n => n.HeaderId == quote.Id);
                                    RejectSYS_DOC_Header(quote, entity, dataContext);
                                }

                                BL.SYS.SYS_DOC_Header.Save(invoice, dataContext);
                                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                                {
                                    foreach (var line in invoice.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, invoice.TypeId.Value, dataContext);
                                        if (!line.FromJob)
                                            BL.ITM.ITM_History.UpdateHistoryOnHand(invoice.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                        else
                                            BL.ITM.ITM_History.UpdateHistoryOnReserve(invoice.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryMovement(invoice.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                        //Henko - TODO: Maybe add setting for sales history is tax excl or incl
                                        BL.ITM.ITM_History.UpdateHistoryAmount(invoice.TypeId.Value, line.ItemId, line.Total, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                        BL.ITM.ITM_History.UpdateHistorySalesDates(line.ItemId, dataContext);
                                        if (entity.BackOrder != null)
                                        {
                                            decimal boQuantity = entity.BackOrder.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder).Quantity;

                                            if (line.Quantity > boQuantity)
                                            {
                                                BL.ITM.ITM_History.UpdateHistoryOnHold(entity.TypeId.Value, line.ItemId, boQuantity, dataContext);
                                            }
                                            else
                                            {
                                                BL.ITM.ITM_History.UpdateHistoryOnHold(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                            }
                                        }
                                    }

                                    foreach (var line in invoice.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut))
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    }

                                    dataContext.SaveChangesEntitySystemContext();
                                    foreach (var line in invoice.SYS_DOC_Line.Where(n => n.Quantity != 0 && new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(n.LineItem.TypeId)))
                                    {
                                        line.Movement.LineId = line.Id;
                                        dataContext.EntitySystemContext.Entry(line);
                                        BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                    }
                                    dataContext.SaveChangesEntityInventoryContext();
                                    if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                                    {
                                        glxHeader = CreateAccountMovement(invoice, dataContext);
                                    }
                                }

                            }

                            //Werner : Must save Back Order after Sales Order/TAX Invoice or Outstanding on Back ORder will not calculate correctly 
                            if (entity.SYS_DOC_Line.Any(n => n.FromJob != true) && entity.SYS_DOC_Line.Any(n => n.QtyOutstanding != 0) && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR))
                            {
                                backorder = BL.SYS.DocumentProcessor.CreateBackOrderFromSalesOrder(entity, dataContext);
                                backorder.SYS_Tracking = entity.SYS_Tracking;
                                BL.SYS.SYS_DOC_Header.Save(backorder, dataContext);
                                dataContext.SaveChangesEntitySystemContext();
                                backorder.ORG_TRX_Header.HeaderId = backorder.Id;
                                backorder.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                                BL.ORG.ORG_TRX_Header.Save(backorder.ORG_TRX_Header, dataContext);

                                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                                {
                                    foreach (var line in backorder.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryOnHold(backorder.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    }
                                    dataContext.SaveChangesEntitySystemContext();
                                    foreach (var line in backorder.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                    {
                                        line.Movement.LineId = line.Id;
                                        dataContext.EntitySystemContext.Entry(line);
                                        BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                    }
                                    dataContext.SaveChangesEntityInventoryContext();
                                }

                            }

                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            // Henko : Do not auto post credit notes. Needs to be checked against user access.
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            //Henko - TODO: Maybe add setting for sales history is tax excl or incl
                            BL.ORG.ORG_History.UpdateCompanyHistory(entity.ORG_TRX_Header.CompanyId, -entity.Total, dataContext);
                            // Henko : Where is the security checks for approve credit note?
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                if (BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SADOSCRE01))
                                {
                                    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryMovement(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                        //Henko - TODO: Maybe add setting for sales history is tax excl or incl
                                        BL.ITM.ITM_History.UpdateHistoryAmount(entity.TypeId.Value, line.ItemId, line.Total, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                    }

                                    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut))
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    }

                                    dataContext.SaveChangesEntitySystemContext();
                                    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(n.LineItem.TypeId)))
                                    {
                                        line.Movement.LineId = line.Id;
                                        dataContext.EntitySystemContext.Entry(line);
                                        BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                    }
                                    dataContext.SaveChangesEntityInventoryContext();
                                }
                            }
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                            {
                                glxHeader = CreateAccountMovement(entity, dataContext);
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    BL.ITM.ITM_History.UpdateHistoryOnOrder(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                }
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            //Henko - TODO: Maybe add setting for purchase history is tax excl or incl
                            BL.ORG.ORG_History.UpdateCompanyHistory(entity.ORG_TRX_Header.CompanyId, entity.Total, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                //Need to load the Purchase Order as it is not possible at the time to just detach the object before sending it to the service
                                entity.PurchaseOrder = BL.SYS.SYS_DOC_Header.LoadByTrackId(entity.TrackId, BL.SYS.SYS_DOC_Type.PurchaseOrder, dataContext, new List<String>() { "SYS_DOC_Line" });
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    if (entity.PurchaseOrder != null)
                                    {
                                        if (dataContext.ReadonlyContext.VW_DocumentLine.Any(n => n.TrackId == (entity).TrackId && (n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived || n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReturned) && n.LineOrder == line.LineOrder))
                                            line.QtyReceived = dataContext.ReadonlyContext.VW_DocumentLine.Where(n => n.TrackId == (entity).TrackId && (n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived || n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReturned) && n.LineOrder == line.LineOrder).Sum(n => n.Quantity * n.StockModifier);

                                        line.QtyOutstanding = entity.PurchaseOrder.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.ItemId == line.ItemId).Quantity - line.QtyReceived;
                                    }
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryPurchaseDates(line.ItemId, dataContext);
                                    // Henko - TODO: Removed the this security option from roles... Still need to replace it with suitable solution
                                    //if (BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.PUDOGR05))
                                    {
                                        BL.ITM.ITM_History.UpdateHistoryUnitCost(line.ItemId, line.Amount, dataContext);
                                    }
                                    if (entity.PurchaseOrder != null)
                                    {
                                        if (line.Quantity > line.QtyOutstanding)
                                        {
                                            BL.ITM.ITM_History.UpdateHistoryOnOrder(entity.TypeId.Value, line.ItemId, -line.QtyOutstanding, dataContext);
                                        }
                                        else
                                        {
                                            BL.ITM.ITM_History.UpdateHistoryOnOrder(entity.TypeId.Value, line.ItemId, -line.Quantity, dataContext);
                                        }
                                    }
                                }

                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut))
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                }

                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(n.LineItem.TypeId)))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                dataContext.SaveChangesEntityInventoryContext();
                            }
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                            {
                                glxHeader = CreateAccountMovement(entity, dataContext);
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            //Henko - TODO: Maybe add setting for purchase history is tax excl or incl
                            BL.ORG.ORG_History.UpdateCompanyHistory(entity.ORG_TRX_Header.CompanyId, -entity.Total, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                }

                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut))
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                }

                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(n.LineItem.TypeId)))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }

                                dataContext.SaveChangesEntityInventoryContext();
                            }
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                            {
                                glxHeader = CreateAccountMovement(entity, dataContext);
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.Job:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.JOB_Header.HeaderId = entity.Id;
                            BL.JOB.JOB_Header.Save(entity.JOB_Header, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.NewJobLine == true && n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryOnReserve(entity.TypeId.Value, line.ItemId, -line.Quantity, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                }
                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                dataContext.SaveChangesEntityInventoryContext();
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    BL.ITM.ITM_History.UpdateHistoryOnOrder(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                }
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                }
                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                dataContext.SaveChangesEntityInventoryContext();
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                    /* Henko - TODO: Implement same solution for tx recieved
                                    if (entity.PurchaseOrder != null)
                                    {
                                        if (line.Quantity > line.QtyOutstanding)
                                        {
                                            BL.ITM.ITM_History.UpdateHistoryOnOrder(entity.TypeId.Value, line.ItemId, -line.QtyOutstanding, dataContext);
                                        }
                                        else
                                        {
                                            BL.ITM.ITM_History.UpdateHistoryOnOrder(entity.TypeId.Value, line.ItemId, -line.Quantity, dataContext);
                                        }
                                    }
                                     * */
                                }
                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                dataContext.SaveChangesEntityInventoryContext();
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line)
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    BL.ITM.ITM_History.UpdateHistoryMovementDates(line.ItemId, dataContext);
                                }
                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                dataContext.SaveChangesEntityInventoryContext();
                            }

                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                            {
                                glxHeader = CreateAccountMovement(entity, dataContext);
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                            //entity.SalesOrder.SYS_Tracking = entity.SYS_Tracking;
                            //BL.SYS.SYS_DOC_Header.Save(entity.SalesOrder, dataContext);
                            //dataContext.SaveChangesEntitySystemContext();
                            //entity.SalesOrder.ORG_TRX_Header.HeaderId = entity.SalesOrder.Id;
                            //entity.SalesOrder.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            //BL.ORG.ORG_TRX_Header.Save(entity.SalesOrder.ORG_TRX_Header, dataContext);
                            //BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            //dataContext.SaveChangesEntitySystemContext();
                            //entity.ORG_TRX_Header.HeaderId = entity.Id;
                            //entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            //BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext); 
                            //if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            //{
                            //    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                            //    {
                            //        //Record Movement before history change
                            //        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                            //        BL.ITM.ITM_History.UpdateHistoryOnHold(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                            //    }
                            //    dataContext.SaveChangesEntitySystemContext();
                            //    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                            //    {
                            //        line.Movement.LineId = line.Id;
                            //        dataContext.EntitySystemContext.Entry(line);
                            //        BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                            //    }
                            //    dataContext.SaveChangesEntityInventoryContext();
                            //}
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                        case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    //Werner: Only do movement for items take out of stock to work with will always be
                                    //the negative Quantity Assemble or Disassemble
                                    if (line.Quantity < 0)
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                        //Get current History
                                        DB.ITM_History itm_history = BL.ITM.ITM_History.GetItemCurrentHistory(dataContext.EntityInventoryContext.ITM_Inventory.FirstOrDefault(n => n.EntityId == line.ItemId), dataContext);
                                        //Force Reload history from DB
                                        dataContext.EntityInventoryContext.Entry(itm_history).Reload();
                                        BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                        //Henko - Not 100% sure about this.....
                                        BL.ITM.ITM_History.UpdateHistoryOnReserve(entity.TypeId.Value, line.ItemId, -line.Quantity, dataContext);
                                    }
                                }
                                dataContext.SaveChangesEntitySystemContext();
                                //Link BOM DOcument to SYS_Doc_Header
                                entity.ITM_BOM_Document.HeaderId = entity.Id;
                                BL.ITM.ITM_BOM_Document.Save(entity.ITM_BOM_Document, dataContext);
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory && n.Movement != null))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                dataContext.SaveChangesEntityInventoryContext();
                            }
                            DB.ITM_BOM_Recipe recipe = BL.ITM.ITM_BOM_Recipe.Load(entity.ITM_BOM_Document.RecipeId, dataContext);
                            switch (entity.TypeId)
                            {
                                case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                                    recipe.Building += recipe.QuantityResult;
                                    break;
                                case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                                    recipe.Building -= recipe.QuantityResult;
                                    break;
                            }
                            dataContext.SaveChangesEntityInventoryContext();
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            Int64 cancleDocumentId = entity.BOMDocumentId;
                            DB.ITM_BOM_Document cancleDocument = dataContext.EntityInventoryContext.ITM_BOM_Document.FirstOrDefault(n => n.Id == cancleDocumentId);
                            cancleDocument.QuantityActualResult = 0;
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line)
                                {
                                    if (line.Quantity < 0)
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                        line.Quantity = -line.Quantity;
                                        BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, -line.Quantity, dataContext);
                                    }
                                }
                                //Need to save Changes in order to get the LineId
                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory && n.Movement != null))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                DB.ITM_BOM_Recipe cancelRecipe = BL.ITM.ITM_BOM_Recipe.Load(cancleDocument.RecipeId, dataContext);
                                cancelRecipe.Building -= cancelRecipe.QuantityResult;
                                dataContext.SaveChangesEntityInventoryContext();
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                            //TODO: Werner - Need to rethink implementation of BOMCompleted currently does not work with how we to the AVG Cost
                            //BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            //if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            //{
                            //    decimal quantityActualResult = 0.00M;
                            //    foreach (var line in entity.SYS_DOC_Line)
                            //    {
                            //        if (line.Quantity == 0)
                            //            continue;

                            //        DB.ITM_Movement lineMovement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);

                            //        //Get current History
                            //        DB.ITM_History itm_history = BL.ITM.ITM_History.GetItemHistory(dataContext.EntityInventoryContext.ITM_Inventory.FirstOrDefault(n => n.EntityId == line.ItemId && n.SiteId == BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId), dataContext);
                            //        //Force Reload history from DB
                            //        dataContext.EntityInventoryContext.Entry(itm_history).Reload();
                            //        if (line.IsBOMCompleteResultItem)
                            //        {
                            //            //Werner: Record QuantityActualResult for later use
                            //            quantityActualResult = line.Quantity;
                            //        }
                            //       if (line.Quantity > 0)
                            //        {
                            //            decimal totalCostValue = 0M;
                            //            line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                            //            //Work out Per Unit Cost
                            //            if (line.IsBOMCompleteResultItem)
                            //            {

                            //                foreach (DB.SYS_DOC_Line sourceItemline in entity.SYS_DOC_Line.Where(n => n.IsBOMCompleteResultItem == false))
                            //                {
                            //                    DB.ITM_History itm_sourceItemhistory = BL.ITM.ITM_History.GetItemHistory(dataContext.EntityInventoryContext.ITM_Inventory.FirstOrDefault(n => n.EntityId == sourceItemline.ItemId && n.SiteId == BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId), dataContext);
                            //                    if (sourceItemline.Quantity < 0)
                            //                    {
                            //                        totalCostValue += -sourceItemline.Quantity * itm_sourceItemhistory.UnitAverage;
                            //                    }
                            //                    else
                            //                    {
                            //                        totalCostValue += sourceItemline.Quantity * itm_sourceItemhistory.UnitAverage;
                            //                    }
                            //                    sourceItemline.Amount = itm_sourceItemhistory.UnitAverage;
                            //                }
                            //                line.UnitAverage = totalCostValue / line.Quantity;
                            //            }
                            //            else
                            //            {
                            //                line.UnitAverage = itm_history.UnitAverage;
                            //            }
                            //            //Calculate new Average Cost
                            //            decimal? newAverageCost = GetNewAverageCost(ref itm_history, line, entity.TypeId.Value, dataContext);
                            //            //Update Unit Selling form profit margin
                            //            if (newAverageCost > itm_history.UnitAverage)
                            //            {
                            //                //Added for the Log entry for UnitPrice
                            //                itm_history.UnitPrice = Convert.ToDecimal(Math.Round(newAverageCost.Value / ((100.00M - (decimal)line.Parent.ProfitMargin.Value) / 100.00M), 2));
                            //                BL.ITM.ITM_History.UpdateHistoryUnitPrice(line.ItemId, itm_history.UnitPrice, dataContext);
                            //            }
                            //            //If OnHand + OnReserve != 0
                            //            if (newAverageCost != null && newAverageCost != itm_history.UnitAverage)
                            //            {
                            //                //Added for the Log entry for UnitAverage
                            //                itm_history.UnitAverage = newAverageCost.Value;
                            //                BL.ITM.ITM_History.UpdateHistoryUnitAverage(line.ItemId, newAverageCost.Value, dataContext);
                            //            }  

                            //            BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                            //        }
                            //        else if (line.Quantity < 0)
                            //        {
                            //            line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                            //            line.Amount = itm_history.UnitAverage;
                            //            BL.ITM.ITM_History.UpdateHistoryOnReserve(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                            //            line.Quantity = -line.Quantity;
                            //        }
                            //    }
                            //    //Need to save Changes in order to get the LineId
                            //    dataContext.SaveChangesEntitySystemContext();
                            //    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory && n.Movement != null))
                            //    {
                            //        line.Movement.LineId = line.Id;
                            //        dataContext.EntitySystemContext.Entry(line);
                            //        BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                            //    }
                            //    DB.ITM_BOM_Document itm_bom_document_complete = dataContext.EntityInventoryContext.ITM_BOM_Document.FirstOrDefault(n => n.Id == entity.BOMDocumentId);
                            //    itm_bom_document_complete.QuantityActualResult = quantityActualResult;
                            //    DB.ITM_BOM_Recipe completeRecipe = BL.ITM.ITM_BOM_Recipe.Load(itm_bom_document_complete.RecipeId, dataContext);
                            //    completeRecipe.Building -= completeRecipe.QuantityResult * Math.Sign(quantityActualResult);
                            //    dataContext.SaveChangesEntityInventoryContext();
                            //} 
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.JobQuote:
                            BL.SYS.SYS_DOC_Header.Save(entity, dataContext);
                            dataContext.SaveChangesEntitySystemContext();
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            break;
                        default:
                            result = "Document Type not supported : " + entity.TypeId.Value;
                            break;
                    }
                    dataContext.SaveChangesEntitySystemContext();
                    dataContext.EntitySystemContext.Entry(entity).Reload();
                    //Entity has to be reloaded before Document number can be used...?
                    if (glxHeader != null)
                    {
                        glxHeader.TrackId = entity.TrackId;
                        BL.GLX.GLX_Header.InsertProfitDistributionEntries(glxHeader, dataContext);
                        BL.EntityController.SaveGLX_Header(glxHeader, dataContext);
                        BL.GLX.GLX_Header.UpdateLedgerAccountBalance(glxHeader, dataContext);
                    }

                    if (entity.CalendarId.HasValue)
                    {
                        DB.CAL_Attachment attachment = BL.CAL.CAL_Attachment.New;
                        attachment.DocumentId = entity.Id;
                        attachment.CalendarId = entity.CalendarId.Value;
                        BL.EntityController.SaveCAL_Attachment(attachment, dataContext);
                    }
                    dataContext.SaveChangesEntityCalendarContext();
                    dataContext.SaveChangesEntityBuyoutContext();
                    dataContext.SaveChangesEntityAccountingContext();
                    dataContext.EntityOrganisationContext.SaveChanges();
                    dataContext.SaveChangesEntityInventoryContext();
                    dataContext.EntityWorkshopContext.SaveChanges();
                    dataContext.SaveChangesEntitySystemContext();
                    dataContext.CompleteTransaction(transaction);
                }
                dataContext.EntityCalendarContext.AcceptAllChanges();
                dataContext.EntityBuyoutContext.AcceptAllChanges();
                dataContext.EntityAccountingContext.AcceptAllChanges();
                dataContext.EntityOrganisationContext.AcceptAllChanges();
                dataContext.EntityInventoryContext.AcceptAllChanges();
                dataContext.EntityWorkshopContext.AcceptAllChanges();
                dataContext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                dataContext.EntityCalendarContext.RejectChanges();
                dataContext.EntityBuyoutContext.RejectChanges();
                dataContext.EntityAccountingContext.RejectChanges();
                dataContext.EntityOrganisationContext.RejectChanges();
                dataContext.EntityInventoryContext.RejectChanges();
                dataContext.EntitySystemContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex))
                    throw ex;
            }
            return result == "Success";
        }

        public static bool ApproveSYS_DOC_Header(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            string result = string.Empty;
            List<DB.ITM_Movement> movements = new List<DB.ITM_Movement>();
            try
            {
                DB.GLX_Header glxHeader = null;
                //Henko: Why is this outside the transaction scope?
                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                {
                    glxHeader = CreateAccountMovement(entity, dataContext);
                }
                using (TransactionScope transaction = dataContext.GetTransactionScope())
                {
                    switch (entity.TypeId)
                    {
                        case (byte)BL.SYS.SYS_DOC_Type.Quote:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                            /* Henko : TODO - glxHeader = CreateAccountMovement(entity, dataContext);
                             *              - Create ITM_Movement
                             */
                            entity.ORG_TRX_Header.HeaderId = entity.Id;
                            // Henko : Do not auto post credit notes. Needs to be checked against user access.
                            entity.ORG_TRX_Header.DatePosted = BL.ApplicationDataContext.Instance.ServerDateTime;
                            BL.ORG.ORG_TRX_Header.Save(entity.ORG_TRX_Header, dataContext);
                            // Henko : Where is the security checks for approve credit note?
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                if (BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SADOSCRE01))
                                {
                                    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                    {
                                        //Record Movement before history change
                                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                                        BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    }
                                    dataContext.SaveChangesEntitySystemContext();
                                    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                    {
                                        line.Movement.LineId = line.Id;
                                        dataContext.EntitySystemContext.Entry(line);
                                        BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                    }
                                    dataContext.SaveChangesEntityInventoryContext();
                                }
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.Job:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                        case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                            break;
                        default:
                            result = "Document Type not supported : " + entity.TypeId.Value;
                            break;
                    }

                    //Entity has to be reloaded before Document number can be used...?
                    if (glxHeader != null)
                    {
                        //dataContext.SaveChangesEntitySystemContext();
                        glxHeader.TrackId = entity.TrackId;
                        glxHeader.Reference = String.Format("Doc #: {0}", entity.DocumentNumber);
                        BL.GLX.GLX_Header.InsertProfitDistributionEntries(glxHeader, dataContext);
                        BL.EntityController.SaveGLX_Header(glxHeader, dataContext);
                        BL.GLX.GLX_Header.UpdateLedgerAccountBalance(glxHeader, dataContext);
                    }

                    dataContext.SaveChangesEntityAccountingContext();
                    dataContext.SaveChangesEntityOrganisationContext();
                    dataContext.SaveChangesEntityInventoryContext();
                    dataContext.SaveChangesEntitySystemContext();
                    dataContext.CompleteTransaction(transaction);
                }
                dataContext.EntityAccountingContext.AcceptAllChanges();
                dataContext.EntityOrganisationContext.AcceptAllChanges();
                dataContext.EntityInventoryContext.AcceptAllChanges();
                dataContext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                dataContext.EntityAccountingContext.RejectChanges();
                dataContext.EntityOrganisationContext.RejectChanges();
                dataContext.EntityInventoryContext.RejectChanges();
                dataContext.EntitySystemContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            return result == "Success";
        }

        /// <summary>
        /// Negates outstanding quantities
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="dataContext"></param>
        /// <returns></returns>
        public static bool RejectSYS_DOC_Header(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            string result = string.Empty;
            try
            {
                using (TransactionScope transaction = dataContext.GetTransactionScope())
                {
                    RejectSYS_DOC_Header(entity, null, dataContext);
                    dataContext.SaveChangesEntitySystemContext();
                    dataContext.CompleteTransaction(transaction);
                }
                dataContext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                dataContext.EntitySystemContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            return result == "Success";
        }

        private static bool RejectSYS_DOC_Header(DB.SYS_DOC_Header entity, DB.SYS_DOC_Header negation, DataContext dataContext)
        {
            string result = "Success";
            List<DB.SYS_DOC_Line> cancelLines = new List<DB.SYS_DOC_Line>();
            Int32 lineOrder = BL.SYS.SYS_DOC_Document.MaxLineOrder(entity.TrackId, dataContext);
            DB.VW_Company company = dataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == entity.ORG_TRX_Header.CompanyId);
            switch (entity.TypeId)
            {
                case (byte)BL.SYS.SYS_DOC_Type.Quote:
                    Parallel.ForEach(entity.SYS_DOC_Line, line =>
                    {
                        DB.SYS_DOC_Line tempLine = BL.ApplicationDataContext.DeepClone(line, BL.SYS.SYS_DOC_Line.New);
                        var orderline = negation.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder);
                        tempLine.Quantity = 0;

                        //If Sales Order has a matching line
                        if (orderline != null)
                        {
                            //If Quantity Differs
                            if (line.Quantity > orderline.Quantity)
                                tempLine.Quantity = -(line.Quantity - orderline.Quantity);
                        }
                        //If Sales Order does not have a matching line it means that the line was removed
                        else
                        {
                            tempLine.Quantity = -line.Quantity;
                        }

                        tempLine.LineItem = dataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == tempLine.ItemId);
                        CalculateLineTotals(tempLine, company);

                        lock (cancelLines)
                        {
                            if (tempLine.Quantity != 0)
                                cancelLines.Add(tempLine);
                        }
                    });
                    Parallel.ForEach(cancelLines, line => { entity.SYS_DOC_Line.Add(line); });
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.CreditNote:

                    Parallel.ForEach(entity.SYS_DOC_Line, line =>
                    {
                        DB.SYS_DOC_Line tempLine = BL.ApplicationDataContext.DeepClone(line, BL.SYS.SYS_DOC_Line.New);
                        tempLine.Quantity = 0;
                        if (line.Quantity != 0)
                            tempLine.Quantity = -line.Quantity;
                        tempLine.Amount = 0.00M;
                        if (line.Quantity == 0 && line.Amount != 0)
                            tempLine.Amount = -line.Amount;
                        tempLine.Total = 0.00M;
                        tempLine.TotalTax = 0.00M;
                        lock (cancelLines)
                        {
                            cancelLines.Add(tempLine);
                        }
                    });
                    Parallel.ForEach(cancelLines, line => { entity.SYS_DOC_Line.Add(line); });
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.Job:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                    break;
                default:
                    result = "Document Type not supported : " + entity.TypeId.Value;
                    break;
            }

            return result == "Success";
        }

        /// <summary>
        /// Cancels document with Holding Movement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="dataContext"></param>
        /// <returns></returns>
        public static bool CancelSYS_DOC_Header(DB.SYS_DOC_Header entity, DataContext dataContext)
        {
            string result = string.Empty;
            List<DB.SYS_DOC_Line> cancelLines = new List<DB.SYS_DOC_Line>();
            Int32 lineOrder = BL.SYS.SYS_DOC_Document.MaxLineOrder(entity.TrackId, dataContext);
            try
            {
                using (TransactionScope transaction = dataContext.GetTransactionScope())
                {
                    switch (entity.TypeId)
                    {
                        case (byte)BL.SYS.SYS_DOC_Type.Quote:
                            //Quote should never be here
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                            //Credit Note should never be here
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                            foreach (DB.SYS_DOC_Line line in entity.SYS_DOC_Line)
                            {
                                if (dataContext.ReadonlyContext.VW_DocumentLine.Any(n => n.TrackId == entity.TrackId && n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived && n.LineOrder == line.LineOrder))
                                    line.QtyReceived = dataContext.ReadonlyContext.VW_DocumentLine.Where(n => n.TrackId == entity.TrackId && n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived && n.LineOrder == line.LineOrder).Sum(n => n.Quantity);

                                line.QtyOutstanding = line.Quantity - line.QtyReceived;
                            }

                            Parallel.ForEach(entity.SYS_DOC_Line.Where(n => n.QtyOutstanding > 0), line =>
                            {
                                DB.SYS_DOC_Line tempLine = BL.ApplicationDataContext.DeepClone(line, BL.SYS.SYS_DOC_Line.New);
                                tempLine.Quantity = -line.QtyOutstanding;
                                tempLine.Amount = 0.00M;
                                tempLine.Total = 0.00M;
                                tempLine.TotalTax = 0.00M;
                                lock (cancelLines)
                                {
                                    cancelLines.Add(tempLine);
                                }
                            });
                            Parallel.ForEach(cancelLines, line => { entity.SYS_DOC_Line.Add(line); });
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in cancelLines)
                                {
                                    BL.ITM.ITM_History.UpdateHistoryOnOrder(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                }
                            }
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.Job:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                            Parallel.ForEach(entity.SYS_DOC_Line, line =>
                            {
                                line.QtyOutstanding = line.Quantity;

                                Parallel.ForEach((BL.SYS.SYS_DOC_Document.LinkedDocuments(entity.TrackId, dataContext).Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.TAXInvoice && n.CreatedOn > entity.CreatedOn)), refInvoices =>
                                {
                                    lock (line)
                                    {
                                        line.QtyOutstanding -= refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder).Quantity;
                                        line.QtyReceived += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder).Quantity;
                                        line.AmountInvoiced += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder).Amount;
                                    }
                                });

                            });

                            Parallel.ForEach(entity.SYS_DOC_Line, line =>
                            {
                                DB.SYS_DOC_Line tempLine = BL.ApplicationDataContext.DeepClone(line, BL.SYS.SYS_DOC_Line.New);
                                tempLine.Quantity = 0;
                                if (line.Quantity != 0)
                                    tempLine.Quantity = -line.QtyOutstanding;
                                tempLine.Amount = 0.00M;
                                tempLine.Total = 0.00M;
                                tempLine.TotalTax = 0.00M;
                                lock (cancelLines)
                                {
                                    cancelLines.Add(tempLine);
                                }
                            });
                            Parallel.ForEach(cancelLines, line => { entity.SYS_DOC_Line.Add(line); });

                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0))
                                {
                                    line.LineItem = dataContext.ReadonlyContext.VW_LineItem
                                        .Where(n => n.Id == line.ItemId)
                                        .Select(l => l.TypeId)
                                        .ToList()
                                        .Select(l => new DB.VW_LineItem() { TypeId = l })
                                        .FirstOrDefault();
                                }

                                //23-03-2016
                                //Jan de Bruyn
                                //Added so it will not update for cancelLines

                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    //Record Movement before history change
                                    line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                                    //Added so it will not update for cancelLines
                                    if(line.Quantity < 0)
                                    {
                                        BL.ITM.ITM_History.UpdateHistoryOnHold(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                                    }
                                }
                                dataContext.SaveChangesEntitySystemContext();
                                foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0 && n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
                                {
                                    line.Movement.LineId = line.Id;
                                    dataContext.EntitySystemContext.Entry(line);
                                    BL.ITM.ITM_Movement.Save(line.Movement, dataContext);
                                }
                                dataContext.SaveChangesEntityInventoryContext();
                            }

                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted:
                        case (byte)BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMCanceled:
                            break;
                        case (byte)BL.SYS.SYS_DOC_Type.BOMComplete:
                            break;
                        default:
                            result = "Document Type not supported : " + entity.TypeId.Value;
                            break;
                    }
                    dataContext.SaveChangesEntitySystemContext();
                    dataContext.CompleteTransaction(transaction);
                }
                dataContext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                dataContext.EntitySystemContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            return result == "Success";
        }

        public static bool SaveSYS_DOC_Line(DB.SYS_DOC_Line entity, DataContext dataContext)
        {
            return BL.SYS.SYS_DOC_Line.Save(entity, dataContext) == "Success";
        }

        public static bool AddJobLines(DB.SYS_DOC_Header entity, List<DB.SYS_DOC_Line> lines, DataContext dataContext)
        {
            string result = string.Empty;
            try
            {
                using (TransactionScope transaction = dataContext.GetTransactionScope())
                {
                    foreach (DB.SYS_DOC_Line line in lines.Where(n => n.Quantity != 0))
                    {
                        //Record Movement before history change
                        line.Movement = BL.ITM.ITM_Movement.Populate(line.ItemId, dataContext);
                        BL.ITM.ITM_History.UpdateHistoryUnitAverageAndProfitMargin(line, entity.TypeId.Value, dataContext);
                        BL.ITM.ITM_History.UpdateHistoryOnHand(entity.TypeId.Value, line.ItemId, line.Quantity, dataContext);
                        BL.ITM.ITM_History.UpdateHistoryOnReserve(entity.TypeId.Value, line.ItemId, -line.Quantity, dataContext);
                        line.HeaderId = entity.Id;
                        BL.EntityController.SaveSYS_DOC_Line(line, dataContext);
                    }
                    dataContext.SaveChangesEntitySystemContext();
                    foreach (var line in entity.SYS_DOC_Line.Where(n => n.Quantity != 0))
                    {
                        line.Movement.LineId = line.Id;
                        dataContext.EntitySystemContext.Entry(line);
                        BL.EntityController.SaveITM_Movement(line.Movement, dataContext);
                    }
                    dataContext.SaveChangesEntityInventoryContext();
                    dataContext.SaveChangesEntitySystemContext();
                    dataContext.CompleteTransaction(transaction);
                    result = "Success";
                }
                dataContext.EntityInventoryContext.AcceptAllChanges();
                dataContext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                dataContext.EntityInventoryContext.RejectChanges();
                dataContext.EntitySystemContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            return result == "Success";
        }

        public static bool SaveSYS_Entity(DB.SYS_Entity entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Entity.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Layout(DB.SYS_Layout entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Layout.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Log(DB.SYS_Log entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Log.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Module(DB.SYS_Module entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Module.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_MSG_Message(DB.SYS_MSG_Message entity, DataContext dataContext)
        {
            return BL.SYS.SYS_MSG_Message.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Period(DB.SYS_Period entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Period.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Person(DB.SYS_Person entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Person.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Printer(DB.SYS_Printer entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Printer.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Site(DB.SYS_Site entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Site.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Surcharge(DB.SYS_Surcharge entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Surcharge.Save(entity, dataContext) == "Success";
        }

        public static bool SaveSYS_Tracking(DB.SYS_Tracking entity, DataContext dataContext)
        {
            return BL.SYS.SYS_Tracking.Save(entity, dataContext) == "Success";
        }

        public static bool SaveAOR_Order(DB.AOR_Order entity, DataContext dataContext)
        {
            return BL.AOR.AOR_Order.Save(entity, dataContext) == "Success";
        }

        public static bool SaveAOR_OrderLine(DB.AOR_OrderLine entity, DataContext dataContext)
        {
            return BL.AOR.AOR_OrderLine.Save(entity, dataContext) == "Success";
        }

        public static void Remove(System.Data.Entity.DbSet dbSet, object entity)
        {
            dbSet.Remove(entity);
        }

        public static DB.GLX_Header CreateAccountMovement(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            switch (entry.TypeId)
            {
                case (byte)BL.SYS.SYS_DOC_Type.Quote:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                    return CreateTaxInvoiceHeader(entry, dataContext);
                case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                    return CreateCreditNoteHeader(entry, dataContext);
                case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                    return CreateGoodsReceivedHeader(entry, dataContext);
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                    return CreateGoodsReturnedHeader(entry, dataContext);
                case (byte)BL.SYS.SYS_DOC_Type.Job:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    return CreateInventoryAdjustmentHeader(entry, dataContext);
                case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
                default:
                    break;
            }
            return null;
        }

        private static DB.GLX_Header CreateGoodsReturnedHeader(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            long companyId = entry.ORG_TRX_Header.CompanyId;
            DB.EntityViews readonlyContext = dataContext.ReadonlyContext;
            string companyCode = readonlyContext.VW_Company
                .Join(readonlyContext.VW_Entity, c => c.EntityId, e => e.Id, (c, e) => new { c.Id, e.CodeSub })
                .FirstOrDefault(n => n.Id == companyId).CodeSub;

            DB.GLX_Header glxHeader = BL.GLX.GLX_Header.New;
            glxHeader.Date = BL.ApplicationDataContext.Instance.ServerDateTime;
            glxHeader.Description = string.Format("Creditor Goods Returned to Acc #: {0}.", companyCode);
            glxHeader.ReferencePeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PostedDate = glxHeader.Date;
            glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.GoodsReturned;
            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
            glxHeader.TrackId = entry.TrackId;
            glxHeader.ReferenceId = entry.Id;
            glxHeader.Reference = String.Format("Doc #: {0}", entry.DocumentNumber);

            // CREDITOR ENTRY
            DB.GLX_Line glx_line_creditor = BL.GLX.GLX_Line.New;
            glx_line_creditor.EntityId = //dataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == companyId).AccountId.Value;
                BL.SYS.SYS_Entity.LoadCompanyCreditorEntity(companyCode, dataContext).Id;
            glx_line_creditor.AgingId = 1;
            glx_line_creditor.Amount = entry.TotalIncl;
            glx_line_creditor.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_creditor.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_creditor);

            // TAX ENTRY
            DB.GLX_Line glx_line_vat = BL.GLX.GLX_Line.New;
            glx_line_vat.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.VATInput.EntityId;
            glx_line_vat.AgingId = 1;
            glx_line_vat.Amount = -entry.TotalTax;
            glx_line_vat.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_vat.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_vat);

            // INVENTORY ENTRIES
            foreach (var inventoryAccount in entry.SYS_DOC_Line.Where(l => l.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory).GroupBy(n => n.LineItem.AccountInventoryId.Value).Select(l => new { InventoryId = l.Key, Amount = l.Sum(n => n.Quantity * n.Amount) }))
            {
                DB.GLX_Line glx_line_inventory = BL.GLX.GLX_Line.New;
                glx_line_inventory.EntityId = inventoryAccount.InventoryId; //BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                glx_line_inventory.AgingId = 1;
                glx_line_inventory.Amount = -inventoryAccount.Amount;//entry.SYS_DOC_Line.Where(n=> n.LineItem.Type == "Inventory").Sum(n => n.Quantity * n.Amount);
                glx_line_inventory.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory);
            }

            if (entry.SYS_DOC_Line.Any(n => n.LineItem.Type == "Buy Out"))
            {
                // INVENTORY BUYOUT
                DB.GLX_Line glx_line_inventory_buyout = BL.GLX.GLX_Line.New;
                glx_line_inventory_buyout.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.InventoryBuyout.EntityId;
                glx_line_inventory_buyout.AgingId = 1;
                // CURRENT
                glx_line_inventory_buyout.Amount = -entry.SYS_DOC_Line.Where(n => n.LineItem.Type == "Buy Out").Sum(n => n.Quantity * n.Amount);
                glx_line_inventory_buyout.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory_buyout.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory_buyout);
            }

            foreach (DB.SYS_DOC_Line line in entry.SYS_DOC_Line)
            {
                if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)
                {
                    DB.GLX_Line glx_line_Account = BL.GLX.GLX_Line.New;
                    glx_line_Account.EntityId = line.LineItem.Id;
                    glx_line_Account.AgingId = 1;
                    glx_line_Account.Amount = -line.Amount;
                    glx_line_Account.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_Account.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_Account);
                }
            }

            return glxHeader;
        }

        private static DB.GLX_Header CreateGoodsReceivedHeader(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            long companyId = entry.ORG_TRX_Header.CompanyId;
            DB.EntityViews readonlyContext = dataContext.ReadonlyContext;
            string companyCode = readonlyContext.VW_Company
                .Join(readonlyContext.VW_Entity, c => c.EntityId, e => e.Id, (c, e) => new { c.Id, e.CodeSub })
                .FirstOrDefault(n => n.Id == companyId).CodeSub;

            DB.GLX_Header glxHeader = BL.GLX.GLX_Header.New;
            glxHeader.Date = BL.ApplicationDataContext.Instance.ServerDateTime;
            glxHeader.Description = string.Format("Creditor Goods Received to Acc #: {0}.", companyCode);
            glxHeader.ReferencePeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PostedDate = glxHeader.Date;
            glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.GoodsRecieved;
            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
            glxHeader.TrackId = entry.TrackId;
            glxHeader.ReferenceId = entry.Id;
            glxHeader.Reference = String.Format("Doc #: {0}", entry.DocumentNumber);

            // CREDITOR ENTRY
            DB.GLX_Line glx_line_creditor = BL.GLX.GLX_Line.New;
            glx_line_creditor.EntityId = //dataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == companyId).AccountId.Value;
                     BL.SYS.SYS_Entity.LoadCompanyCreditorEntity(companyCode, dataContext).Id;
            glx_line_creditor.AgingId = 1;
            glx_line_creditor.Amount = -entry.TotalIncl;
            glx_line_creditor.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_creditor.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_creditor);

            // TAX ENTRY
            DB.GLX_Line glx_line_vat = BL.GLX.GLX_Line.New;
            glx_line_vat.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.VATInput.EntityId;
            glx_line_vat.AgingId = 1;
            glx_line_vat.Amount = entry.TotalTax;
            glx_line_vat.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_vat.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_vat);

            // INVENTORY ENTRIES
            foreach (var inventoryAccount in entry.SYS_DOC_Line.Where(l => l.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory).GroupBy(n => n.LineItem.AccountInventoryId.Value).Select(l => new { InventoryId = l.Key, Amount = l.Sum(n => n.Quantity * n.Amount) }))
            {
                DB.GLX_Line glx_line_inventory = BL.GLX.GLX_Line.New;
                glx_line_inventory.EntityId = inventoryAccount.InventoryId; //BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                glx_line_inventory.AgingId = 1;
                glx_line_inventory.Amount = inventoryAccount.Amount;//entry.SYS_DOC_Line.Where(n=> n.LineItem.Type == "Inventory").Sum(n => n.Quantity * n.Amount);
                glx_line_inventory.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory);
            }

            if (entry.SYS_DOC_Line.Any(n => n.LineItem.Type == "Buy Out"))
            {
                // INVENTORY BUYOUT
                DB.GLX_Line glx_line_inventory_buyout = BL.GLX.GLX_Line.New;
                glx_line_inventory_buyout.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.InventoryBuyout.EntityId;
                glx_line_inventory_buyout.AgingId = 1;
                glx_line_inventory_buyout.Amount = entry.SYS_DOC_Line.Where(n => n.LineItem.Type == "Buy Out").Sum(n => n.Quantity * n.Amount);
                glx_line_inventory_buyout.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory_buyout.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory_buyout);
            }

            foreach (DB.SYS_DOC_Line line in entry.SYS_DOC_Line)
            {
                // ACCOUNT ENTRIES
                if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)
                {
                    DB.GLX_Line glx_line_Account = BL.GLX.GLX_Line.New;
                    glx_line_Account.EntityId = line.LineItem.Id;
                    glx_line_Account.AgingId = 1;
                    glx_line_Account.Amount = line.Amount;
                    glx_line_Account.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_Account.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_Account);
                }
            }

            return glxHeader;
        }

        private static DB.GLX_Header CreateCreditNoteHeader(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            if (!BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SADOSCRE01))
                return null;

            long companyId = entry.ORG_TRX_Header.CompanyId;
            DB.EntityViews readonlyContext = dataContext.ReadonlyContext;
            string companyCode = readonlyContext.VW_Company
                .Join(readonlyContext.VW_Entity, c => c.EntityId, e => e.Id, (c, e) => new { c.Id, e.CodeSub })
                .FirstOrDefault(n => n.Id == companyId).CodeSub;

            DB.GLX_Header glxHeader = BL.GLX.GLX_Header.New;
            glxHeader.Date = BL.ApplicationDataContext.Instance.ServerDateTime;

            glxHeader.Description = string.Format("Debtor Credit to Acc #: {0}.", companyCode);
            glxHeader.ReferencePeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.CreditNote;
            glxHeader.ReferenceId = entry.Id;

            // This needs to be checked against the user...?
            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
            glxHeader.PostedDate = glxHeader.Date;
            glxHeader.TrackId = entry.TrackId;
            glxHeader.Reference = String.Format("Doc #: {0}", entry.DocumentNumber);

            // DEBTORS ENTRY
            DB.GLX_Line glx_line_debtor = BL.GLX.GLX_Line.New;
            glx_line_debtor.EntityId = //dataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == companyId).AccountId.Value;
                BL.SYS.SYS_Entity.LoadCompanyDebtorEntity(companyCode, dataContext).Id;
            glx_line_debtor.AgingId = 1;
            glx_line_debtor.Amount = -entry.TotalIncl;
            glx_line_debtor.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_debtor.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_debtor);

            // SALES ENTRY WITHOUT TAX
            DB.GLX_Line glx_line_sales = BL.GLX.GLX_Line.New;
            glx_line_sales.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.Sales.EntityId;
            glx_line_sales.AgingId = 1;
            glx_line_sales.Amount = entry.Total;
            glx_line_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_sales.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_sales);

            // TAX ENTRY
            DB.GLX_Line glx_line_vat = BL.GLX.GLX_Line.New;
            glx_line_vat.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.VATOutput.EntityId;
            glx_line_vat.AgingId = 1;
            glx_line_vat.Amount = entry.TotalTax;
            glx_line_vat.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_vat.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_vat);

            // INVENTORY ENTRIES
            foreach (var inventoryAccount in entry.SYS_DOC_Line.Where(l => l.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory).GroupBy(n => n.LineItem.AccountInventoryId.Value).Select(l => new { InventoryId = l.Key, UnitAverage = l.Sum(n => n.Quantity * n.UnitAverage) }))
            {
                DB.GLX_Line glx_line_inventory = BL.GLX.GLX_Line.New;
                glx_line_inventory.EntityId = inventoryAccount.InventoryId; //BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                glx_line_inventory.AgingId = 1;
                glx_line_inventory.Amount = inventoryAccount.UnitAverage;//entry.SYS_DOC_Line.Where(n=> n.LineItem.Type == "Inventory").Sum(n => n.Quantity * n.Amount);
                glx_line_inventory.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory);
            }

            if (entry.SYS_DOC_Line.Any(n => n.LineItem.Type == "Buy Out"))
            {
                // INVENTORY BUYOUT
                DB.GLX_Line glx_line_inventory_buyout = BL.GLX.GLX_Line.New;
                glx_line_inventory_buyout.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.InventoryBuyout.EntityId;
                //CURRENT
                glx_line_inventory_buyout.AgingId = 1;
                glx_line_inventory_buyout.Amount = entry.SYS_DOC_Line.Where(n => n.LineItem.Type == "Buy Out").Sum(n => n.Quantity * n.UnitAverage);
                glx_line_inventory_buyout.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory_buyout.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory_buyout);

                // COST OF SALES BUYOUTS
                DB.GLX_Line glx_line_cost_of_sales_buyout = BL.GLX.GLX_Line.New;
                glx_line_cost_of_sales_buyout.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId;
                //CURRENT
                glx_line_cost_of_sales_buyout.AgingId = 1;
                glx_line_cost_of_sales_buyout.Amount = -entry.SYS_DOC_Line.Where(n => n.LineItem.Type == "Buy Out").Sum(n => n.Quantity * n.UnitAverage);
                glx_line_cost_of_sales_buyout.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_cost_of_sales_buyout.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_cost_of_sales_buyout);
            }

            // COST OF SALES ENTRY
            List<long> items = entry.SYS_DOC_Line.Select(l => l.ItemId).ToList();
            foreach (var account in dataContext.ReadonlyContext.VW_LineItem.Where(n => n.InventoryId.HasValue == true && items.Contains(n.Id)).Select(n => new { n.Id, n.AccountCostofSalesId }).Distinct())
            {
                DB.GLX_Line glx_line_cost_of_sales = BL.GLX.GLX_Line.New;
                glx_line_cost_of_sales.EntityId = account.AccountCostofSalesId.Value;
                glx_line_cost_of_sales.AgingId = 1;
                glx_line_cost_of_sales.Amount = -entry.SYS_DOC_Line.Where(n => n.ItemId == account.Id).GroupBy(n => n.ItemId).Select(n => n.Sum(s => s.Quantity * s.UnitAverage)).FirstOrDefault();
                glx_line_cost_of_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_cost_of_sales.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_cost_of_sales);
            }

            foreach (DB.SYS_DOC_Line line in entry.SYS_DOC_Line)
            {
                if (line.LineItem == null)
                    line.LineItem = dataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);

                if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)
                {
                    DB.GLX_Line glx_line_Account = BL.GLX.GLX_Line.New;
                    glx_line_Account.EntityId = line.LineItem.Id;
                    glx_line_Account.AgingId = 1;
                    glx_line_Account.Amount = line.Amount;
                    glx_line_Account.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_Account.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_Account);

                    DB.GLX_Line glx_line_contra_cost_of_sales = BL.GLX.GLX_Line.New;
                    glx_line_contra_cost_of_sales.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId;
                    glx_line_contra_cost_of_sales.AgingId = 1;
                    glx_line_contra_cost_of_sales.Amount = -line.Amount;
                    glx_line_contra_cost_of_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_contra_cost_of_sales.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_contra_cost_of_sales);
                }
                else if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Surcharge)
                {

                    var surcharge = dataContext.EntitySystemContext.SYS_Surcharge.FirstOrDefault(n => n.EntityId == line.LineItem.Id);
                    // SURCHARGE
                    DB.GLX_Line glx_line_surcharge = BL.GLX.GLX_Line.New;
                    glx_line_surcharge.EntityId = Convert.ToInt64(surcharge.AccountId);
                    //CURRENT
                    glx_line_surcharge.AgingId = 1;
                    glx_line_surcharge.Amount = Convert.ToDecimal(surcharge.Amount);
                    glx_line_surcharge.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_surcharge.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_surcharge);

                    DB.GLX_Line glx_line_contra_cost_of_sales = BL.GLX.GLX_Line.New;
                    glx_line_contra_cost_of_sales.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId;
                    glx_line_contra_cost_of_sales.AgingId = 1;
                    glx_line_contra_cost_of_sales.Amount = -Convert.ToDecimal(surcharge.Amount);
                    glx_line_contra_cost_of_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_contra_cost_of_sales.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_contra_cost_of_sales);
                }
            }
            return glxHeader;
        }

        private static DB.GLX_Header CreateTaxInvoiceHeader(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            long companyId = entry.ORG_TRX_Header.CompanyId;
            DB.EntityViews readonlyContext = dataContext.ReadonlyContext;
            string companyCode = readonlyContext.VW_Company
                .Join(readonlyContext.VW_Entity, c => c.EntityId, e => e.Id, (c, e) => new { c.Id, e.CodeSub })
                .FirstOrDefault(n => n.Id == companyId).CodeSub;

            DB.GLX_Header glxHeader = BL.GLX.GLX_Header.New;
            glxHeader.Date = BL.ApplicationDataContext.Instance.ServerDateTime;
            glxHeader.Description = string.Format("Debtor Sale to Acc #: {0}.", companyCode);
            glxHeader.ReferencePeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PostedDate = glxHeader.Date;
            glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Invoice;
            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
            glxHeader.TrackId = entry.TrackId;
            glxHeader.ReferenceId = entry.Id;
            glxHeader.Reference = String.Format("Doc #: {0}", entry.DocumentNumber);

            // DEBTORS ENTRY
            DB.GLX_Line glx_line_debtor = BL.GLX.GLX_Line.New;
            glx_line_debtor.EntityId = //dataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == companyId).AccountId.Value;
                 BL.SYS.SYS_Entity.LoadCompanyDebtorEntity(companyCode, dataContext).Id;
            //CURRENT
            glx_line_debtor.AgingId = 1;
            glx_line_debtor.Amount = (entry.ORG_TRX_Header.Rounding.HasValue) ? entry.TotalIncl + entry.ORG_TRX_Header.Rounding.Value : entry.TotalIncl;
            glx_line_debtor.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_debtor.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_debtor);

            // SALES ENTRY WITHOUT TAX
            DB.GLX_Line glx_line_sales = BL.GLX.GLX_Line.New;
            glx_line_sales.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.Sales.EntityId;
            //CURRENT
            glx_line_sales.AgingId = 1;
            glx_line_sales.Amount = -entry.Total;
            glx_line_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_sales.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_sales);

            // TAX ENTRY
            DB.GLX_Line glx_line_vat = BL.GLX.GLX_Line.New;
            glx_line_vat.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.VATOutput.EntityId;
            //CURRENT
            glx_line_vat.AgingId = 1;
            glx_line_vat.Amount = -entry.TotalTax;
            glx_line_vat.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_vat.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_vat);

            // INVENTORY ENTRIES
            if (entry.SYS_DOC_Line.Any(l => l.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory))
            {
                foreach (var inventoryAccount in entry.SYS_DOC_Line.Where(l => l.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory).GroupBy(n => n.LineItem.AccountInventoryId.Value).Select(l => new { InventoryId = l.Key, UnitAverage = l.Sum(n => n.Quantity * n.UnitAverage) }))
                {
                    DB.GLX_Line glx_line_inventory = BL.GLX.GLX_Line.New;
                    glx_line_inventory.EntityId = inventoryAccount.InventoryId; //BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                    glx_line_inventory.AgingId = 1;
                    glx_line_inventory.Amount = -inventoryAccount.UnitAverage;//entry.SYS_DOC_Line.Where(n=> n.LineItem.Type == "Inventory").Sum(n => n.Quantity * n.Amount);
                    glx_line_inventory.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_inventory);
                }
            }

            // Fix these string test to use enums that will alwasy be correct -- see above test for inventory
            if (entry.SYS_DOC_Line.Any(n => n.LineItem.Type == "Buy Out"))
            {
                // INVENTORY BUYOUT
                DB.GLX_Line glx_line_inventory_buyout = BL.GLX.GLX_Line.New;
                glx_line_inventory_buyout.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.InventoryBuyout.EntityId;
                //CURRENT
                glx_line_inventory_buyout.AgingId = 1;
                glx_line_inventory_buyout.Amount = -entry.SYS_DOC_Line.Where(n => n.LineItem.Type == "Buy Out").Sum(n => n.Quantity * n.UnitAverage);
                glx_line_inventory_buyout.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory_buyout.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory_buyout);

                // COST OF SALES BUYOUTS
                DB.GLX_Line glx_line_cost_of_sales_buyout = BL.GLX.GLX_Line.New;
                glx_line_cost_of_sales_buyout.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId;
                //CURRENT
                glx_line_cost_of_sales_buyout.AgingId = 1;
                glx_line_cost_of_sales_buyout.Amount = entry.SYS_DOC_Line.Where(n => n.LineItem.Type == "Buy Out").Sum(n => n.Quantity * n.UnitAverage);
                glx_line_cost_of_sales_buyout.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_cost_of_sales_buyout.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_cost_of_sales_buyout);
            }

            // COST OF SALES ENTRY
            List<long> items = entry.SYS_DOC_Line.Select(l => l.ItemId).ToList();
            foreach (var account in dataContext.ReadonlyContext.VW_LineItem.Where(n => n.InventoryId.HasValue == true && items.Contains(n.Id)).Select(n => new { n.Id, n.AccountCostofSalesId }).Distinct())
            {
                DB.GLX_Line glx_line_cost_of_sales = BL.GLX.GLX_Line.New;
                glx_line_cost_of_sales.EntityId = account.AccountCostofSalesId.Value;
                //CURRENT
                glx_line_cost_of_sales.AgingId = 1;
                glx_line_cost_of_sales.Amount = entry.SYS_DOC_Line.Where(n => n.ItemId == account.Id).GroupBy(n => n.ItemId).Select(n => n.Sum(s => s.Quantity * s.UnitAverage)).FirstOrDefault();
                glx_line_cost_of_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_cost_of_sales.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_cost_of_sales);
            }

            //Add the contra entry for the rounding the debtor account entry is added on the form so that the line totals are correct
            if (entry.ORG_TRX_Header.Rounding.HasValue && entry.ORG_TRX_Header.Rounding.Value != 0)
            {
                DB.GLX_Line glx_line_rounding = BL.GLX.GLX_Line.New;
                glx_line_rounding.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.Rounding.EntityId;
                glx_line_rounding.AgingId = 1;
                glx_line_rounding.Amount = -entry.ORG_TRX_Header.Rounding.Value;
                glx_line_rounding.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_rounding.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_rounding);
            }

            foreach (DB.SYS_DOC_Line line in entry.SYS_DOC_Line)
            {
                if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)
                {
                    DB.GLX_Line glx_line_Account = BL.GLX.GLX_Line.New;
                    glx_line_Account.EntityId = line.LineItem.Id;
                    //CURRENT
                    glx_line_Account.AgingId = 1;
                    glx_line_Account.Amount = -line.Amount;
                    glx_line_Account.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_Account.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_Account);

                    //Add the contra entry for all other lines that are accounts Should be COS
                    DB.GLX_Line glx_line_contra_cost_of_sales = BL.GLX.GLX_Line.New;
                    glx_line_contra_cost_of_sales.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId;
                    //CURRENT
                    glx_line_contra_cost_of_sales.AgingId = 1;
                    glx_line_contra_cost_of_sales.Amount = line.Amount;
                    glx_line_contra_cost_of_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_contra_cost_of_sales.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_contra_cost_of_sales);
                }
                else if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Surcharge)
                {

                    var surcharge = dataContext.EntitySystemContext.SYS_Surcharge.FirstOrDefault(n => n.EntityId == line.LineItem.Id);
                    // SURCHARGE
                    DB.GLX_Line glx_line_surcharge = BL.GLX.GLX_Line.New;
                    glx_line_surcharge.EntityId = Convert.ToInt64(surcharge.AccountId);
                    //CURRENT
                    glx_line_surcharge.AgingId = 1;
                    glx_line_surcharge.Amount = -Convert.ToDecimal(surcharge.Amount);
                    glx_line_surcharge.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_surcharge.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_surcharge);

                    DB.GLX_Line glx_line_contra_cost_of_sales = BL.GLX.GLX_Line.New;
                    glx_line_contra_cost_of_sales.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId;
                    //CURRENT
                    glx_line_contra_cost_of_sales.AgingId = 1;
                    glx_line_contra_cost_of_sales.Amount = Convert.ToDecimal(surcharge.Amount);
                    glx_line_contra_cost_of_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_contra_cost_of_sales.EntityId, dataContext).CenterId;
                    glxHeader.GLX_Line.Add(glx_line_contra_cost_of_sales);
                }
            }

            return glxHeader;
        }

        private static DB.GLX_Header CreateInventoryAdjustmentHeader(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            DB.GLX_Header glxHeader = BL.GLX.GLX_Header.New;
            glxHeader.Date = BL.ApplicationDataContext.Instance.ServerDateTime;
            glxHeader.Description = "Inventory Adjustment.";
            glxHeader.ReferencePeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(dataContext).Id;
            glxHeader.PostedDate = glxHeader.Date;
            glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Journal;
            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
            glxHeader.TrackId = entry.TrackId;
            glxHeader.ReferenceId = entry.Id;
            glxHeader.Reference = String.Format("Doc #: {0}", entry.DocumentNumber);

            // Stock Adjustment ENTRY
            DB.GLX_Line glx_line_stock_adjustment = BL.GLX.GLX_Line.New;
            glx_line_stock_adjustment.EntityId = BL.ApplicationDataContext.Instance.SiteAccounts.StockAdjustment.EntityId;
            glx_line_stock_adjustment.AgingId = 1;
            glx_line_stock_adjustment.Amount = -entry.TotalIncl;
            glx_line_stock_adjustment.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_stock_adjustment.EntityId, dataContext).CenterId;
            glxHeader.GLX_Line.Add(glx_line_stock_adjustment);

            // INVENTORY ENTRIES
            foreach (var inventoryAccount in entry.SYS_DOC_Line.Where(l => l.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory).GroupBy(n => n.LineItem.AccountInventoryId.Value).Select(l => new { InventoryId = l.Key, Amount = l.Sum(n => n.Quantity * n.Amount) }))
            {
                DB.GLX_Line glx_line_inventory = BL.GLX.GLX_Line.New;
                glx_line_inventory.EntityId = inventoryAccount.InventoryId; //BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                glx_line_inventory.AgingId = 1;
                glx_line_inventory.Amount = inventoryAccount.Amount;//entry.SYS_DOC_Line.Where(n=> n.LineItem.Type == "Inventory").Sum(n => n.Quantity * n.Amount);
                glx_line_inventory.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_inventory.EntityId, dataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_inventory);
            }

            return glxHeader;
        }

        /// <summary>
        /// Calculate a lines Total and Tax
        /// </summary>
        /// <param name="line">The line which totals you wish to calculate</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private static void CalculateLineTotals(DB.SYS_DOC_Line line, DB.VW_Company SelectedCompany)
        {
            // Accounts do not have a quantity also not allowed to change qty so always use 1 if Parent Type = 5 (Account)
            line.Total = Math.Round(line.Amount * (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account ? 1 : line.Quantity), 2, MidpointRounding.AwayFromZero);

            if (SelectedCompany != null)
            {
                //TODO: Check if item is VAT Exempt
                switch (SelectedCompany.CostCategoryId)
                {
                    case (byte)BL.ORG.ORG_CostCategory.SellingPriceIncludingSalesTax:
                        line.TotalTax = line.Total * BL.ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.SellingPriceExcludingSalesTax:
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.CostIncludingSalesTax:
                        line.TotalTax = line.Total * BL.ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.CostExcludingSalesTax:
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.AverageCostExcludingSalesTax:
                        break;
                }
            }
        }

        
    }
}

