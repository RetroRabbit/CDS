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
    public class SYS_DOC_Header
    {
        public static DB.SYS_DOC_Header New
        {
            get
            {
                DB.SYS_DOC_Header entry = new DB.SYS_DOC_Header();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                return entry;
            }
        }

        public static DB.SYS_DOC_Header Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_DOC_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id && n.SiteId == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        public static DB.SYS_DOC_Header Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.SYS_DOC_Header LoadByTrackId(Int64 trackId, SYS_DOC_Type type, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_DOC_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.TrackId == trackId && n.TypeId == (byte)type && n.SiteId == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        public static DB.SYS_DOC_Header LoadByTrackId(Int64 Id, SYS_DOC_Type type, DataContext dataContext)
        {
            return LoadByTrackId(Id, type, dataContext, null);
        }

        internal static String Save(DB.SYS_DOC_Header entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_DOC_Header.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_DOC_Header GetNextItem(DB.SYS_DOC_Header sys_doc_header, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_DOC_Header.OrderBy(o => o.CreatedOn).FirstOrDefault(n => n.TypeId == sys_doc_header.TypeId && n.DocumentNumber.Value.CompareTo(sys_doc_header.DocumentNumber.Value) > 0 && n.DocumentNumber.Value.CompareTo(sys_doc_header.DocumentNumber.Value) != 0);
        }

        public static DB.SYS_DOC_Header GetPreviousItem(DB.SYS_DOC_Header sys_doc_header, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_DOC_Header.OrderByDescending(o => o.CreatedOn).FirstOrDefault(n => n.TypeId == sys_doc_header.TypeId && n.DocumentNumber.Value.CompareTo(sys_doc_header.DocumentNumber.Value) < 0 && n.DocumentNumber.Value.CompareTo(sys_doc_header.DocumentNumber.Value) != 0);
        }
    }
}
