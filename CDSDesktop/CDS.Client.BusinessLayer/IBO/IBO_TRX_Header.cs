using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.IBO
{
    public class IBO_TRX_Header
    {

        public static DB.IBO_TRX_Header New
        {
            get
            {
                DB.IBO_TRX_Header entry = new DB.IBO_TRX_Header();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                return entry;
            }
        }

        public static DB.IBO_TRX_Header Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityBuyoutContext.IBO_TRX_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.IBO_TRX_Header Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.IBO_TRX_Header entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityBuyoutContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityBuyoutContext.IBO_TRX_Header.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

      //  public static DB.IBO_TRX_Header GetNextItem(DB.IBO_TRX_Header IBO_TRX_Header, DataContext dataContext)
      //  {
      //      return dataContext.EntityBuyoutContext.IBO_TRX_Header.OrderBy(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(IBO_TRX_Header.Name) > 0 && n.Name.CompareTo(IBO_TRX_Header.Name) != 0);
      //  }
      //
      //  public static DB.IBO_TRX_Header GetPreviousItem(DB.IBO_TRX_Header IBO_TRX_Header, DataContext dataContext)
      //  {
      //      return dataContext.EntityBuyoutContext.IBO_TRX_Header.OrderByDescending(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(IBO_TRX_Header.Name) < 0 && n.Name.CompareTo(IBO_TRX_Header.Name) != 0);
      //  } 
    }
}
