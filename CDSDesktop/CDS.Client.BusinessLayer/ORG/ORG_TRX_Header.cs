using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ORG
{
    public class ORG_TRX_Header
    {
        public static DB.ORG_TRX_Header New
        {
            get
            {
                DB.ORG_TRX_Header entry = new DB.ORG_TRX_Header() { Rounding = 0.00M };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.ShippingTypeId = (byte)BL.SYS.SYS_DOC_ShippingType.Normal;
                return entry;
            }
        }

        internal static String Save(DB.ORG_TRX_Header entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrganisationContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityOrganisationContext.ORG_TRX_Header.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ORG_TRX_Header Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_TRX_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id && n.ORG_Company.SiteId == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        public static DB.ORG_TRX_Header Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.ORG_TRX_Header LoadByHeaderId(Int64 headerId, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_TRX_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.HeaderId == headerId && n.ORG_Company.SiteId == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        public static DB.ORG_TRX_Header LoadByHeaderId(Int64 headerId, DataContext dataContext)
        {
            return LoadByHeaderId(headerId, dataContext, null);
        }

        public static int SetDateFirstPrinted(Int64 documentId, Int64 printedById, DataContext dataContext)
        {
            return dataContext.EntityOrganisationContext.ExecuteSqlCommand(string.Format("UPDATE [CDS_ORG].[ORG_TRX_Header] SET DateFirstPrinted = getdate(), FirstPrintedBy = {0} WHERE DateFirstPrinted IS NULL AND HeaderId = {1} ", printedById, documentId));
        }

        public static int SetDateLastPrinted(Int64 documentId, Int64 printedById, DataContext dataContext)
        {
            return dataContext.EntityOrganisationContext.ExecuteSqlCommand(string.Format("UPDATE [CDS_ORG].[ORG_TRX_Header] SET DateLastPrinted = getdate(), LastPrintedBy = {0} WHERE HeaderId = {1} ", printedById, documentId));
        }

        public static DB.ORG_TRX_Header CopyDocument(DB.ORG_TRX_Header entry)
        {
            //DB.SYS_DOC_Header newDocument = BL.SYS.SYS_DOC_Document.New;
            DB.ORG_TRX_Header newTransaction = BL.ORG.ORG_TRX_Header.New;// newDocument.ORG_TRX_Header.FirstOrDefault();

            //BL.ApplicationDataContext.DeepClone(entry, newDocument);
            ////BL.ApplicationDataContext.DeepClone(entry.ORG_TRX_Header.FirstOrDefault(), newTransaction);
            //foreach (DB.SYS_DOC_Line line in entry.SYS_DOC_Line)
            //{
            //    DB.SYS_DOC_Line newLine = BL.SYS.SYS_DOC_Line.New;
            //    BL.ApplicationDataContext.DeepClone(line, newLine);
            //    newDocument.SYS_DOC_Line.Add(newLine);
            //}
            return newTransaction;
        }

    }
}
