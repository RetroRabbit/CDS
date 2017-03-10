using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.AOR
{
    public class AOR_OrderLine
    {

        public static DB.AOR_OrderLine New
        {
            get
            {
                DB.AOR_OrderLine entry = new DB.AOR_OrderLine() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        } 

        public static DB.AOR_OrderLine Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrderingContext.AOR_OrderLine.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.AOR_OrderLine Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null); 
        } 

        internal static String Save(DB.AOR_OrderLine entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrderingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityOrderingContext.AOR_OrderLine.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }  
    }
}
