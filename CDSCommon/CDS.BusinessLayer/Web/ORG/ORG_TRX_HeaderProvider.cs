using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace CDS.BusinessLayer.Web.ORG
{
    public static class ORG_TRX_HeaderProvider
    {
        /// <summary>
        /// Creates a new ORG_TRX_Header from a Portable Document created online.
        /// </summary>
        /// <param name="uow">Unit of Work to create the Header on</param>
        /// <param name="createdBy">The user that created the Document</param>
        /// <param name="sysTracking">The tracking number for the Header</param>
        /// <param name="documentType">The Document type you want to create a header for</param>
        /// <param name="document">The Portable document to create the header from</param>
        /// <returns>A new ORG_TRX_Header created from a Portable document</returns>
        internal static DAL.Datamodel.ORG_TRX_Header Create(UnitOfWork uow, DAL.Datamodel.SEC_User createdBy, DAL.Datamodel.SYS_Tracking sysTracking, byte documentType, PORT.Document document)
        {
            DAL.Datamodel.ORG_TRX_Header org_trx_header = new DAL.Datamodel.ORG_TRX_Header(uow);

            org_trx_header.BillingAddressLine1 = document.billingAddressLine1;
            org_trx_header.BillingAddressLine2 = document.billingAddressLine2;
            org_trx_header.BillingAddressLine3 = document.billingAddressLine3;
            org_trx_header.BillingAddressLine4 = document.billingAddressLine4;
            org_trx_header.BillingAddressCode = document.billingAddressCode;
            org_trx_header.DatePosted = document.datePosted;
            org_trx_header.ReferenceShort1 = document.referenceShort1;
            org_trx_header.ReferenceShort2 = document.referenceShort2;
            org_trx_header.ReferenceShort3 = document.referenceShort3;
            org_trx_header.ShippingTypeId = DAL.Enums.ORG_TRX_ShippingType.Normal;
            org_trx_header.CompanyId = uow.Query<DAL.Datamodel.ORG_Company>().Where(c => c.EntityId.EntityId.Id == document.companyId).FirstOrDefault();
            org_trx_header.CreatedBy = createdBy.PersonId;

            return org_trx_header;
        }

        public static List<PORT.Document> GetHeaders(string connectionString)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();

                XPQuery<DAL.Datamodel.ORG_TRX_Header> docs = new XPQuery<DAL.Datamodel.ORG_TRX_Header>(uow);

                List<PORT.Document> list = docs.Where(d => d.HeaderId.TypeId == DAL.Enums.SYS_DOC_Type.TAXInvoice)
                    .Select(d => new PORT.Document()
                    {
                        id = d.Id,
                        datePosted = d.DatePosted,
                        referenceShort1 = d.ReferenceShort1,
                        referenceShort2 = d.ReferenceShort2,
                        referenceShort3 = d.ReferenceShort3,
                        companyId = d.CompanyId.EntityId.EntityId.Id,
                        companyName = d.CompanyId.EntityId.EntityId.Name,
                        documentheader = new PORT.DocumentHeader()
                        {
                            documentNumber = d.HeaderId.DocumentNumber.ToString(),
                            total = d.HeaderId.SYS_DOC_Lines.Sum(l => l.Total),
                            totalVat = d.HeaderId.SYS_DOC_Lines.Sum(l => l.TotalTax),
                        }
                    })
                    .ToList();
                return list;
            }
        }

        public static PORT.Document GetById(string connectionString, long id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();

                XPQuery<DAL.Datamodel.ORG_TRX_Header> docs = new XPQuery<DAL.Datamodel.ORG_TRX_Header>(uow);

                PORT.Document document = docs.Where(d => d.Id == id)
                    .Select(d => new PORT.Document()
                    {
                        id = d.HeaderId.Id,
                        companyId = d.CompanyId.EntityId.EntityId.Id,
                        companyName = d.CompanyId.EntityId.EntityId.Name,
                        datePosted = d.DatePosted,
                        referenceShort1 = d.ReferenceShort1,
                        referenceShort2 = d.ReferenceShort2,
                        referenceShort3 = d.ReferenceShort3,
                        documentheader = new PORT.DocumentHeader()
                        {
                            documentNumber = d.HeaderId.DocumentNumber.ToString(),
                            total = d.HeaderId.SYS_DOC_Lines.Sum(l => l.Total),
                            totalVat = d.HeaderId.SYS_DOC_Lines.Sum(l => l.TotalTax),
                            documentLines = d.HeaderId.SYS_DOC_Lines.Select(l => new PORT.DocumentLines()
                            {
                                amount = l.Amount,
                                description = l.Description,
                                itemId = l.ItemId.Id,
                                lineOrder = l.LineOrder,
                                quantity = l.Quantity,
                                total = l.Total,
                                totalVat = l.TotalTax,
                                isNew = false
                            }).ToList()
                        }
                    }).FirstOrDefault();

                DAL.Datamodel.SYS_Address billing = uow.Query<DAL.Datamodel.ORG_CompanyAddress>().Where(a => a.CompanyId.EntityId.EntityId.Id == document.companyId && a.AddressId.TypeId == DAL.Enums.SYS_Type.BillingAddress).FirstOrDefault().AddressId;

                document.billingAddressLine1 = String.IsNullOrEmpty(billing.Line1) ? " " : billing.Line1;
                document.billingAddressLine2 = String.IsNullOrEmpty(billing.Line2) ? " " : billing.Line2;
                document.billingAddressLine3 = String.IsNullOrEmpty(billing.Line3) ? " " : billing.Line3;
                document.billingAddressLine4 = String.IsNullOrEmpty(billing.Line4) ? " " : billing.Line4;
                document.billingAddressCode = String.IsNullOrEmpty(billing.Code) ? " " : billing.Code;

                return document;
            }
        }
    }
}
