using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.GLX
{
    public class GLX_BulkEntryRule
    {

        public static DB.GLX_BulkEntryRule New
        {
            get
            {
                DB.GLX_BulkEntryRule entry = new DB.GLX_BulkEntryRule();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.GLX_BulkEntryRule Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_BulkEntryRule.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_BulkEntryRule Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.GLX_BulkEntryRule entry,DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_BulkEntryRule.Add(entry);

                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }
    }
}
