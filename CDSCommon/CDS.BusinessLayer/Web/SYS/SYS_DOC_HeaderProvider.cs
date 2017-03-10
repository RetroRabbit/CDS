using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace CDS.BusinessLayer.Web.SYS
{
    internal static class SYS_DOC_HeaderProvider
    {
        internal static DAL.Datamodel.SYS_DOC_Header New(UnitOfWork uow, DAL.Datamodel.SEC_User sec_user, DAL.Datamodel.SYS_Tracking sysTracking, PORT.Document document)
        {
            DAL.Datamodel.SYS_DOC_Header doc_header = new DAL.Datamodel.SYS_DOC_Header(uow)
            {
                TrackId = sysTracking
                ,
                CreatedBy = sec_user.PersonId
                ,
                TypeId = (DAL.Enums.SYS_DOC_Type)document.documentheader.documentType
            };

            List<DAL.Datamodel.SYS_DOC_Line> lines = new List<DAL.Datamodel.SYS_DOC_Line>();

            foreach (PORT.DocumentLines line in document.documentheader.documentLines)
            {
                lines.Add(new DAL.Datamodel.SYS_DOC_Line(uow) { Amount = line.amount, CreatedBy = sec_user.PersonId, Description = line.description, LineOrder = line.lineOrder, Quantity = line.quantity, Total = line.total - line.totalVat, TotalTax = line.totalVat, ItemId = uow.Query<DAL.Datamodel.SYS_Entity>().Where(i => i.Id == line.itemId).FirstOrDefault() });
            }

            doc_header.SYS_DOC_Lines.AddRange(lines);

            return doc_header;
        }
    }
}
