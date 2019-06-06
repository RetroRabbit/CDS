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
    public class GLX_Tax
    {

        public static DB.GLX_Tax New
        {
            get
            {
                DB.GLX_Tax entry = new DB.GLX_Tax();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.GLX_Tax Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_Tax.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_Tax Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.GLX_Tax entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_Tax.Add(entry);

                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }


        public static DB.GLX_Tax GetNextItem(DB.GLX_Tax glx_tax, DataContext dataContext)
        {
            return dataContext.EntityAccountingContext.GLX_Tax.OrderBy(o => o.Name).Where(n => n.Name.CompareTo(glx_tax.Name) > 0 && n.Name.CompareTo(glx_tax.Name) != 0).FirstOrDefault();
        }

        public static DB.GLX_Tax GetPreviousItem(DB.GLX_Tax glx_tax, DataContext dataContext)
        {
            return dataContext.EntityAccountingContext.GLX_Tax.OrderByDescending(o => o.Name).Where(n => n.Name.CompareTo(glx_tax.Name) < 0 && n.Name.CompareTo(glx_tax.Name) != 0).FirstOrDefault();
        }
    }
}
