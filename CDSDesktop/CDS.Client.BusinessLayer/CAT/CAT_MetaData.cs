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
    public class CAT_MetaData
    {

        public static DB.CAT_MetaData New
        {
            get
            {
                DB.CAT_MetaData entry = new DB.CAT_MetaData() { Data = "" };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        internal static String Save(DB.CAT_MetaData entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityCatalogueContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityCatalogueContext.CAT_MetaData.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.CAT_MetaData Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityCatalogueContext.CAT_MetaData.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.CAT_MetaData Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        //public static DB.CAT_MetaData GetNextItem(DB.CAT_MetaData CAT_MetaData, DataContext dataContext)
        //{
        //    return dataContext.EntityCatalogueContext.CAT_MetaData.OrderBy(o => o.SYS_Person.Surname).FirstOrDefault(n => n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) > 0 && n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) != 0);
        //}

        //public static DB.CAT_MetaData GetPreviousItem(DB.CAT_MetaData CAT_MetaData, DataContext dataContext)
        //{
        //    return dataContext.EntityCatalogueContext.CAT_MetaData.OrderByDescending(o => o.SYS_Person.Surname).FirstOrDefault(n => n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) < 0 && n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) != 0);
        //}
    }
}
