using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.CAT
{
    public class CAT_Catalogue
    {

        public static DB.CAT_Catalogue New
        {
            get
            {
                DB.CAT_Catalogue entry = new DB.CAT_Catalogue();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        internal static String Save(DB.CAT_Catalogue entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityCatalogueContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityCatalogueContext.CAT_Catalogue.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.CAT_Catalogue Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityCatalogueContext.CAT_Catalogue.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.CAT_Catalogue Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        //public static DB.CAT_Catalogue GetNextItem(DB.CAT_Catalogue CAT_Catalogue, DataContext dataContext)
        //{
        //    return dataContext.EntityCatalogueContext.CAT_Catalogue.OrderBy(o => o.SYS_Person.Surname).FirstOrDefault(n => n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) > 0 && n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) != 0);
        //}

        //public static DB.CAT_Catalogue GetPreviousItem(DB.CAT_Catalogue CAT_Catalogue, DataContext dataContext)
        //{
        //    return dataContext.EntityCatalogueContext.CAT_Catalogue.OrderByDescending(o => o.SYS_Person.Surname).FirstOrDefault(n => n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) < 0 && n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) != 0);
        //}
    }
}
