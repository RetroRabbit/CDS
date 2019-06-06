using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.CAL
{
    public class CAL_Attachment
    {

        public static DB.CAL_Attachment New
        {
            get
            {
                DB.CAL_Attachment entry = new DB.CAL_Attachment() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        } 

        public static DB.CAL_Attachment Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityCalendarContext.CAL_Attachment.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.CAL_Attachment Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null); 
        } 

        internal static String Save(DB.CAL_Attachment entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityCalendarContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityCalendarContext.CAL_Attachment.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }  
    }
}
