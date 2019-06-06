using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_DOC_Document
    {
        /// <summary>
        /// Returns a new blank document should only be used for the copy document method 
        /// </summary>
        /// <param name="TypeId">Document Type Id</param>
        /// <returns>The will return a new document of the type specified</returns>
        public static DB.SYS_DOC_Header New(SYS_DOC_Type type)
        {
            DB.SYS_DOC_Header document = SYS_DOC_Header.New;
            document.TypeId = (byte)type;
            //Tried to do this here but the server cant save for some reason
            //document.SYS_Tracking = SYS.SYS_Tracking.New;
            //document.ORG_TRX_Header.Add(BL.ORG.ORG_TRX_Header.New);

            return document;
        }

        internal static String Save(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntitySystemContext.SYS_DOC_Header.Add(entry);
                }

                return "Success";
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }
            catch (Exception ex)
            {
                return "Exception" + Environment.NewLine + ex.ToString();
            }

        }

        public static int HasDocumentsLeft(DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_DOC_Header.Where(n => n.CreatedOn.Value.Date == DateTime.Today).Count();
        }

        public static decimal CalculateRounding(decimal total)
        {
            decimal totalRounding = 0.00M;
            if (BL.ApplicationDataContext.Instance.CompanySite.RoundingAmount <= 0)
                return 0.00M;

            decimal centsRemainder = (total) - System.Decimal.Truncate(total);
            decimal roundingMultiple = System.Decimal.Truncate(centsRemainder / BL.ApplicationDataContext.Instance.CompanySite.RoundingAmount);
            decimal roundedCents = roundingMultiple * BL.ApplicationDataContext.Instance.CompanySite.RoundingAmount;
            totalRounding = centsRemainder - roundedCents;
            return totalRounding;
        }

        public static IQueryable<DB.SYS_DOC_Header> LinkedDocuments(Int64 trackId, DataContext dataContext)
        {
            return LinkedDocuments(trackId, dataContext, new List<string>() { "SYS_DOC_Line" });
        }

        public static IQueryable<DB.SYS_DOC_Header> LinkedDocuments(Int64 trackId, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_DOC_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.Where(n => n.TrackId == trackId).AsQueryable();

            //return (IQueryable<DB.SYS_DOC_Header>)dataContext.EntitySystemContext.SYS_DOC_Header.Include("SYS_DOC_Line").Where(n => n.TrackId == trackId);
        }

        /// <summary>
        /// Gets the Maximum Line Order for the given transaction id
        /// </summary>
        /// <param name="trackId">Transaction id to search on </param>
        /// <param name="dataContext">The DataContext to search in</param>
        /// <returns>Integer representing the Maximum Line Order</returns>
        public static int MaxLineOrder(Int64 trackId, DataContext dataContext)
        {
            return MaxLineOrder(LinkedDocuments(trackId, dataContext, new List<string>() { "SYS_DOC_Line" }));
        }

        /// <summary>
        /// Gets the Maximum Line Order for the all the lines for the given list of SYS_DOC_Headers
        /// </summary>
        /// <param name="refDocs">Queryable List of SYS_DOC_Headers</param>
        /// <returns>Integer representing the Maximum Line Order</returns>
        public static int MaxLineOrder(IQueryable<DB.SYS_DOC_Header> refDocs)
        {
            return MaxLineOrder(refDocs.ToList());
        }

        /// <summary>
        /// Gets the Maximum Line Order for the all the lines for the given list of SYS_DOC_Headers
        /// </summary>
        /// <param name="refDocs">List of SYS_DOC_Headers</param>
        /// <returns>Integer representing the Maximum Line Order</returns>
        public static int MaxLineOrder(List<DB.SYS_DOC_Header> refDocs)
        {
            if (refDocs.Count() == 0)
                return 1;

            return refDocs.Select(n => n.SYS_DOC_Line.Count > 0 ? n.SYS_DOC_Line.Max(f => f.LineOrder) : 1).Max();
        }
    }
}
