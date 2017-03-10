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
    public class GLX_Budget
    {
        public static DB.GLX_Budget New
        {
            get
            {
                DB.GLX_Budget entry = new DB.GLX_Budget();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.GLX_Budget Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_Budget.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_Budget Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.GLX_Budget entry,DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_Budget.Add(entry);
                
                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.GLX_Budget GetNextItem(DB.GLX_Budget glx_budget, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Budget.OrderBy(o => o.Id).Where(n => n.Id > glx_budget.Id && n.Id != glx_budget.Id).FirstOrDefault();
        //}

        //public static DB.GLX_Budget GetPreviousItem(DB.GLX_Budget glx_budget, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Budget.OrderByDescending(o => o.Id).Where(n => n.Id > glx_budget.Id && n.Id != glx_budget.Id).FirstOrDefault();
        //}

       
    }
}
