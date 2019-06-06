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
    public class SYS_DOC_Line
    {
        public static DB.SYS_DOC_Line New
        {
            get
            {
                DB.SYS_DOC_Line entry = new DB.SYS_DOC_Line();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.SYS_DOC_Line Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_DOC_Line.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_DOC_Line Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static List<DB.SYS_DOC_Line> LoadByHeaderId(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_DOC_Line.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.Where(n => n.HeaderId == Id).ToList();
        }

        public static List<DB.SYS_DOC_Line> LoadByHeaderId(Int64 Id, DataContext dataContext)
        {
            return LoadByHeaderId(Id, dataContext, null);
        }

        internal static String Save(DB.SYS_DOC_Line entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_DOC_Line.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.SYS_DOC_Line GetNextItem(DB.SYS_DOC_Line SYS_DOC_Line, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_DOC_Line.OrderBy(o => o.CreatedOn).FirstOrDefault(n => n.TypeId == SYS_DOC_Line.TypeId && n.DocumentNumber.Value.CompareTo(SYS_DOC_Line.DocumentNumber.Value) > 0 && n.DocumentNumber.Value.CompareTo(SYS_DOC_Line.DocumentNumber.Value) != 0);
        //}

        //public static DB.SYS_DOC_Line GetPreviousItem(DB.SYS_DOC_Line SYS_DOC_Line, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_DOC_Line.OrderByDescending(o => o.CreatedOn).FirstOrDefault(n => n.TypeId == SYS_DOC_Line.TypeId && n.DocumentNumber.Value.CompareTo(SYS_DOC_Line.DocumentNumber.Value) < 0 && n.DocumentNumber.Value.CompareTo(SYS_DOC_Line.DocumentNumber.Value) != 0);
        //}
    }
}
