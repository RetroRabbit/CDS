using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ORG
{
    public class ORG_Company
    {
        public static DB.ORG_Company New
        {
            get
            {
                DB.ORG_Company entry = new DB.ORG_Company()
                {
                    ORG_Entity = ORG_Entity.New
                };
                entry.ORG_Distribution.Add(ORG_Distribution.New);
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ORG_Company NewCustomerCompany
        {
            get
            {
                DB.ORG_Company entry = new DB.ORG_Company()
                {
                    TypeId = (byte)ORG.ORG_Type.Customer
                    , Active = true
                    , OpenItem = true
                };

                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ORG_Company NewSupplierCompany
        {
            get
            {
                DB.ORG_Company entry = new DB.ORG_Company()
                {
                    TypeId = (byte)ORG.ORG_Type.Supplier
                    , Active = true
                    , OpenItem = true
                };

                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ORG_Company Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_Company.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ORG_Company Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.ORG_Company entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrganisationContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityOrganisationContext.ORG_Company.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.ORG_Company GetNextItem(DB.ORG_Company ORG_Company, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_Company.OrderBy(o => o.ORG_Entity.SYS_Entity.Name).FirstOrDefault(n => n.ORG_Entity.SYS_Entity.Name.CompareTo(ORG_Company.ORG_Entity.SYS_Entity.Name) > 0 && n.ORG_Entity.SYS_Entity.Name.CompareTo(ORG_Company.ORG_Entity.SYS_Entity.Name) != 0);
        //}

        //public static DB.ORG_Company GetPreviousItem(DB.ORG_Company ORG_Company, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_Company.OrderByDescending(o => o.ORG_Entity.SYS_Entity.Name).FirstOrDefault(n => n.ORG_Entity.SYS_Entity.Name.CompareTo(ORG_Company.ORG_Entity.SYS_Entity.Name) < 0 && n.ORG_Entity.SYS_Entity.Name.CompareTo(ORG_Company.ORG_Entity.SYS_Entity.Name) != 0);
        //}
    }
}
