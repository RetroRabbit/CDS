using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.JOB
{
    public class JOB_Header
    {
        public static DB.JOB_Header New
        {
            get
            {
                DB.JOB_Header entry = new DB.JOB_Header();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId; 
                return entry;
            }
        }

        internal static String Save(DB.JOB_Header entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityWorkshopContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityWorkshopContext.JOB_Header.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.JOB_Header Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityWorkshopContext.JOB_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.JOB_Header Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.JOB_Header LoadByHeaderId(Int64 headerId, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityWorkshopContext.JOB_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.HeaderId == headerId);
        }

        public static DB.JOB_Header LoadByHeaderId(Int64 headerId, DataContext dataContext)
        {
            return LoadByHeaderId(headerId, dataContext, null);
        } 

        //public static DB.JOB_Header GetNextItem(DB.JOB_Header JOB_Header, DataContext dataContext)
        //{
        //    return dataContext.EntityWorkshopContext.JOB_Header.OrderBy(o => o.CreatedOn).FirstOrDefault(n => n.SYS_DOC_Header.TypeId == JOB_Header.SYS_DOC_Header.TypeId && n.SYS_DOC_Header.DocumentNumber.Value.CompareTo(JOB_Header.SYS_DOC_Header.DocumentNumber.Value) > 0 && n.SYS_DOC_Header.DocumentNumber.Value.CompareTo(JOB_Header.SYS_DOC_Header.DocumentNumber.Value) != 0);
        //}

        //public static DB.JOB_Header GetPreviousItem(DB.JOB_Header JOB_Header, DataContext dataContext)
        //{
        //    return dataContext.EntityWorkshopContext.JOB_Header.OrderByDescending(o => o.CreatedOn).FirstOrDefault(n => n.SYS_DOC_Header.TypeId == JOB_Header.SYS_DOC_Header.TypeId && n.SYS_DOC_Header.DocumentNumber.Value.CompareTo(JOB_Header.SYS_DOC_Header.DocumentNumber.Value) < 0 && n.SYS_DOC_Header.DocumentNumber.Value.CompareTo(JOB_Header.SYS_DOC_Header.DocumentNumber.Value) != 0);
        //}
         
    }
}
