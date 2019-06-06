using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.GLX
{
    public class GLX_Line
    {
        public static DB.GLX_Line New
        {
            get
            {
                DB.GLX_Line entry = new DB.GLX_Line();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.GLX_Line Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_Line.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_Line Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }  

        internal static String Save(DB.GLX_Line entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_Line.Add(entry);

                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }
    }
}
