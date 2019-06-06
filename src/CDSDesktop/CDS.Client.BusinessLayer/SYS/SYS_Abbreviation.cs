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
    public class SYS_Abbreviation
    {

        public static DB.SYS_Abbreviation New
        {
            get
            {
                DB.SYS_Abbreviation entry = new DB.SYS_Abbreviation();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                

                return entry;
            }
        }

        public static DB.SYS_Abbreviation Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Abbreviation.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Abbreviation Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SYS_Abbreviation entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Abbreviation.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_Abbreviation GetNextItem(DB.SYS_Abbreviation SYS_Abbreviation, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Abbreviation.OrderBy(o => o.Abbreviation).FirstOrDefault(n => n.Abbreviation.CompareTo(SYS_Abbreviation.Abbreviation) > 0 && n.Abbreviation.CompareTo(SYS_Abbreviation.Abbreviation) != 0);
        }

        public static DB.SYS_Abbreviation GetPreviousItem(DB.SYS_Abbreviation SYS_Abbreviation, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Abbreviation.OrderByDescending(o => o.Abbreviation).FirstOrDefault(n => n.Abbreviation.CompareTo(SYS_Abbreviation.Abbreviation) < 0 && n.Abbreviation.CompareTo(SYS_Abbreviation.Abbreviation) != 0);
        }
    }
}
