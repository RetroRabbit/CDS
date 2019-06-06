using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;

namespace CDS.BusinessLayer.Core.GLX
{
    internal static class GLX_HeaderProvider
    {
        internal static DataAccessLayer.XPO.Datamodel.GLX_Header NewInvoice(UnitOfWork uow, DAL.Datamodel.ORG_TRX_Header orgHeaderInvoice)
        {
            DAL.Datamodel.GLX_Header glx_invoice_header = new DAL.Datamodel.GLX_Header(uow);

            glx_invoice_header.CreatedBy = orgHeaderInvoice.CreatedBy;
            glx_invoice_header.Date = orgHeaderInvoice.DatePosted;
            glx_invoice_header.Description = string.Format("Debtor Sale to Acc #: {0}.", orgHeaderInvoice.CompanyId.EntityId.EntityId.CodeSub);
            glx_invoice_header.PeriodId = uow.Query<DAL.Datamodel.SYS_Period>().Where(p => p.StartDate <= orgHeaderInvoice.DatePosted && p.EndDate >= orgHeaderInvoice.DatePosted).FirstOrDefault();
            glx_invoice_header.PostedDate = orgHeaderInvoice.DatePosted;
            glx_invoice_header.JournalTypeId = DAL.Enums.GLX_JournalType.Invoice;
            glx_invoice_header.StatusId = DAL.Enums.SYS_Status.Posted;
            glx_invoice_header.TrackId = orgHeaderInvoice.HeaderId.TrackId;
            glx_invoice_header.ReferenceId = orgHeaderInvoice.Id;
            glx_invoice_header.Reference = String.Format("Doc #: {0}", orgHeaderInvoice.HeaderId.DocumentNumber);

            DAL.Datamodel.GLX_SiteAccount debtorsControl = uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(e => e.TypeId == DAL.Enums.GLX_SystemAccountType.Debtors).FirstOrDefault();
            DAL.Datamodel.SYS_Entity debtorsControlEntity = debtorsControl.EntityId;

            // DEBTORS ENTRY
            DAL.Datamodel.GLX_Line glx_line_debtor = new DAL.Datamodel.GLX_Line(uow);
            glx_line_debtor.EntityId =
            glx_line_debtor.EntityId = uow.Query<DAL.Datamodel.SYS_Entity>().Where(e => e.CodeSub == orgHeaderInvoice.CompanyId.EntityId.EntityId.CodeSub && e.CodeMain == debtorsControlEntity.CodeMain && e.TypeId == DAL.Enums.SYS_Type.Account).FirstOrDefault();
            //CURRENT
            glx_line_debtor.AgingId = uow.Query<DAL.Datamodel.GLX_Aging>().Where(n => n.Id == (byte)1).FirstOrDefault();
            glx_line_debtor.Amount = orgHeaderInvoice.HeaderId.SYS_DOC_Lines.Sum(l => l.Total + l.TotalTax);
            //glx_line_debtor.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_debtor.EntityId, dataContext).CenterId;
            glx_invoice_header.GLX_Lines.Add(glx_line_debtor);

            // SALES ENTRY WITHOUT TAX
            DAL.Datamodel.GLX_Line glx_line_sales = new DAL.Datamodel.GLX_Line(uow);
            glx_line_sales.EntityId = uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(e => e.TypeId == DAL.Enums.GLX_SystemAccountType.Sales).FirstOrDefault().EntityId;
            //CURRENT
            glx_line_sales.AgingId = uow.Query<DAL.Datamodel.GLX_Aging>().Where(n => n.Id == (byte)1).FirstOrDefault();
            glx_line_sales.Amount = -(orgHeaderInvoice.HeaderId.SYS_DOC_Lines.Sum(l => l.Total));
            //glx_line_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_sales.EntityId, dataContext).CenterId;
            glx_invoice_header.GLX_Lines.Add(glx_line_sales);

            // TAX ENTRY
            DAL.Datamodel.GLX_Line glx_line_vat = new DAL.Datamodel.GLX_Line(uow);
            glx_line_vat.EntityId = uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(e => e.TypeId == DAL.Enums.GLX_SystemAccountType.VatOutput).FirstOrDefault().EntityId;
            //CURRENT
            glx_line_vat.AgingId = uow.Query<DAL.Datamodel.GLX_Aging>().Where(n => n.Id == (byte)1).FirstOrDefault();
            glx_line_vat.Amount = -(orgHeaderInvoice.HeaderId.SYS_DOC_Lines.Sum(l => l.TotalTax));
            //glx_line_vat.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_vat.EntityId, dataContext).CenterId;
            glx_invoice_header.GLX_Lines.Add(glx_line_vat);

            //SALES & COS
            foreach (DAL.Datamodel.SYS_DOC_Line line in orgHeaderInvoice.HeaderId.SYS_DOC_Lines)
            {
                DAL.Datamodel.GLX_Line glx_line_Account = new DAL.Datamodel.GLX_Line(uow);
                glx_line_Account.EntityId = line.ItemId;
                //CURRENT
                glx_line_Account.AgingId = uow.Query<DAL.Datamodel.GLX_Aging>().Where(n => n.Id == (byte)1).FirstOrDefault();
                glx_line_Account.Amount = -line.Total;
                //glx_line_Account.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_Account.EntityId, dataContext).CenterId;
                glx_invoice_header.GLX_Lines.Add(glx_line_Account);

                //Add the contra entry for all other lines that are accounts Should be COS
                DAL.Datamodel.GLX_Line glx_line_contra_cost_of_sales = new DAL.Datamodel.GLX_Line(uow);
                glx_line_contra_cost_of_sales.EntityId = uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(e => e.TypeId == DAL.Enums.GLX_SystemAccountType.CostofSales).FirstOrDefault().EntityId;
                //CURRENT
                glx_line_contra_cost_of_sales.AgingId = uow.Query<DAL.Datamodel.GLX_Aging>().Where(n => n.Id == (byte)1).FirstOrDefault();
                glx_line_contra_cost_of_sales.Amount = line.Total;
                //glx_line_contra_cost_of_sales.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_contra_cost_of_sales.EntityId, dataContext).CenterId;
                glx_invoice_header.GLX_Lines.Add(glx_line_contra_cost_of_sales);
            }

            InsertProfitDistributionEntries(uow, glx_invoice_header);
            
            return glx_invoice_header;
        }

        internal static void InsertProfitDistributionEntries(UnitOfWork uow,  DAL.Datamodel.GLX_Header glx_header)
        {
            decimal total = 0;
            decimal currentProfitTotal = 0;
            decimal currentDistributionTotal = 0;

            foreach (DAL.Datamodel.GLX_Line line in glx_header.GLX_Lines)
            {
                if (Core.GLX.GLX_AccountProvider.ProfitDistributionEntriesRequired(uow).Contains(line.EntityId.Id))
                {
                    total += line.Amount;
                }

                //Total of current headers Profit Amount
                if (line.EntityId.Id == uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(p => p.SystemDefaultAccount && p.TypeId == DAL.Enums.GLX_SystemAccountType.Profit).FirstOrDefault().EntityId.Id)
                {
                    currentProfitTotal += line.Amount;
                }

                //Total of current headers Distribution Amount
                if (line.EntityId.Id == uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(p => p.SystemDefaultAccount && p.TypeId == DAL.Enums.GLX_SystemAccountType.Distributedreserves).FirstOrDefault().EntityId.Id)
                {
                    currentDistributionTotal += line.Amount;
                }
            }

            if ((total - currentDistributionTotal) != 0 || (total + currentProfitTotal) != 0)
            {
                // DISTRIBUTION ENTRY
                DAL.Datamodel.GLX_Line glx_line_distribution = new DAL.Datamodel.GLX_Line(uow);
                glx_line_distribution.CreatedBy = glx_header.CreatedBy;
                glx_line_distribution.EntityId = uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(p => p.SystemDefaultAccount && p.TypeId == DAL.Enums.GLX_SystemAccountType.Distributedreserves).FirstOrDefault().EntityId;
                //CURRENT
                glx_line_distribution.AgingId = uow.Query<DAL.Datamodel.GLX_Aging>().Where(n => n.Id == (byte)1).FirstOrDefault();
                glx_line_distribution.Amount = total - currentDistributionTotal;
                //glx_line_distribution.CenterId = GLX_Account.LoadByEntityId(glx_line_distribution.EntityId, dataContext).CenterId;
                glx_header.GLX_Lines.Add(glx_line_distribution);

                // PROFIT ENTRY
                DAL.Datamodel.GLX_Line glx_line_profit = new DAL.Datamodel.GLX_Line(uow);
                glx_line_profit.EntityId = uow.Query<DAL.Datamodel.GLX_SiteAccount>().Where(p => p.SystemDefaultAccount && p.TypeId == DAL.Enums.GLX_SystemAccountType.Profit).FirstOrDefault().EntityId;
                //CURRENT
                glx_line_profit.AgingId = uow.Query<DAL.Datamodel.GLX_Aging>().Where(n => n.Id == (byte)1).FirstOrDefault();
                glx_line_profit.Amount = -(total + currentProfitTotal);
                //glx_line_profit.CenterId = GLX_Account.LoadByEntityId(glx_line_profit.EntityId, dataContext).CenterId;
                glx_header.GLX_Lines.Add(glx_line_profit);
            }
        }

        internal static void UpdateLedgerAccountBalance(UnitOfWork uow, DAL.Datamodel.GLX_Header glx_header)
        {
            foreach (DAL.Datamodel.GLX_Line line in glx_header.GLX_Lines)
            {
                uow.ExecuteNonQuery(String.Format("EXEC CDS_SYS.spUpdateAccountBalance {0},{1},{2},{3},{4}", line.EntityId.Id, glx_header.PeriodId.Id, glx_header.PeriodId.Id, line.AgingId.Id, line.Amount));
            }
        }
    }
}
