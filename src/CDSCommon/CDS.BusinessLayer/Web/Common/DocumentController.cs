using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace CDS.BusinessLayer.Web.Common
{
    public static class DocumentController
    {
        /// <summary>
        /// Saves all the parts of a Document from Portable document created online - ORG_TRX_Header, SYS_DOC_Header, SYS_DOC_Line, GLX_Header, GLX_Line and all movement and history
        /// </summary>
        /// <param name="connectionString">Connection string for the XPO datasource</param>
        /// <param name="userName">Username that created the document</param>
        /// <param name="jsonDoc">Portable document sent from web to be saved</param>
        /// <returns>Returns true if saved successfully.</returns>
        public static bool SaveDocument(string connectionString, string userName, string jsonDoc)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();

                // Starts an explicit transaction. 
                uow.ExplicitBeginTransaction();
                try
                {
                    PORT.Document document = (PORT.Document)JsonConvert.DeserializeObject(jsonDoc, typeof(PORT.Document));
                    document.documentheader.documentType = (byte)DAL.Enums.SYS_DOC_Type.SalesOrder;
                    DAL.Datamodel.SEC_User sec_user = uow.Query<DAL.Datamodel.SEC_User>().Where(u => u.Username == userName).FirstOrDefault();

                    DAL.Datamodel.SYS_Tracking sysTracking = Core.SYS.SYS_TrackingProvider.New(uow, "WEB");
                    uow.CommitChanges();

                    DAL.Datamodel.ORG_TRX_Header orgHeader = Web.ORG.ORG_TRX_HeaderProvider.Create(uow, sec_user, sysTracking, document.documentheader.documentType, document);

                    orgHeader.HeaderId = Web.SYS.SYS_DOC_HeaderProvider.New(uow, sec_user, sysTracking, document);

                    uow.CommitChanges();
                    orgHeader.HeaderId.DocumentNumber = uow.Query<DAL.Datamodel.SYS_DOC_Header>().Where(d => d.TypeId == (DAL.Enums.SYS_DOC_Type)document.documentheader.documentType).Max(d => d.DocumentNumber) + 1;
                    sysTracking.Initiator = String.Format("WEB - {0} {1}", "Sales Order", orgHeader.HeaderId.DocumentNumber.ToString());
                    uow.CommitChanges();

                    //CREATE TAX INVOICE FROM SALES ORDER
                    //////////////////////////////////////////////////
                    document.documentheader.documentType = (byte)DAL.Enums.SYS_DOC_Type.TAXInvoice;
                    DAL.Datamodel.ORG_TRX_Header orgHeaderInvoice = Web.ORG.ORG_TRX_HeaderProvider.Create(uow, sec_user, sysTracking, document.documentheader.documentType, document);

                    orgHeaderInvoice.HeaderId = Web.SYS.SYS_DOC_HeaderProvider.New(uow, sec_user, sysTracking, document);

                    uow.CommitChanges();
                    orgHeaderInvoice.HeaderId.DocumentNumber = uow.Query<DAL.Datamodel.SYS_DOC_Header>().Where(d => d.TypeId == (DAL.Enums.SYS_DOC_Type)document.documentheader.documentType).Max(d => d.DocumentNumber) + 1;
                    uow.CommitChanges();
                    //////////////////////////////////////////////////

                    Core.ORG.ORG_CompanyProvider.UpdateCompanyHistory(uow, orgHeaderInvoice.CompanyId.Id, orgHeaderInvoice.HeaderId.SYS_DOC_Lines.Sum(l => l.Total));

                    DAL.Datamodel.GLX_Header glx_Header = Core.GLX.GLX_HeaderProvider.NewInvoice(uow, orgHeaderInvoice);

                    Core.GLX.GLX_HeaderProvider.UpdateLedgerAccountBalance(uow, glx_Header);

                    uow.CommitChanges();

                    uow.ExplicitCommitTransaction();
                }
                catch
                {
                    uow.ExplicitRollbackTransaction();
                    throw;
                }
            }
            return true;
        }
    }
}
