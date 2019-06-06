using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ITM
{
    public class ITM_BOM_Document
    {

        public static DB.ITM_BOM_Document New
        {
            get
            {
                DB.ITM_BOM_Document entry = new DB.ITM_BOM_Document() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                return entry;
            }
        }

        public static DB.ITM_BOM_Document Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_BOM_Document.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_BOM_Document Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.ITM_BOM_Document LoadByHeaderId(Int64 headerId, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_BOM_Document.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.HeaderId == headerId);
        }

        public static DB.ITM_BOM_Document LoadByHeaderId(Int64 Id, DataContext dataContext)
        {
            return LoadByHeaderId(Id, dataContext, null);
        }

        internal static String Save(DB.ITM_BOM_Document entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_BOM_Document.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ITM_BOM_Document GetNextItem(DB.ITM_BOM_Document ITM_BOM_Document, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_BOM_Document.OrderBy(o => o.Id).Where(n => n.Id == ITM_BOM_Document.Id && n.Id > ITM_BOM_Document.Id).FirstOrDefault();
        }

        public static DB.ITM_BOM_Document GetPreviousItem(DB.ITM_BOM_Document ITM_BOM_Document, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_BOM_Document.OrderByDescending(o => o.Id).Where(n => n.Id == ITM_BOM_Document.Id && n.Id < ITM_BOM_Document.Id).FirstOrDefault();
        } 
    }
}
