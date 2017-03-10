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
    public class ORG_CompanyAddress
    {
        public static DB.ORG_CompanyAddress NewCompanyBillingAddress
        {
            get
            {
                DB.ORG_CompanyAddress entry = new DB.ORG_CompanyAddress() { /*SYS_Address = SYS.SYS_Address.NewBillingAddress*/ };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ORG_CompanyAddress NewCompanyShippingAddress
        {
            get
            {
                DB.ORG_CompanyAddress entry = new DB.ORG_CompanyAddress() { /*SYS_Address = SYS.SYS_Address.NewShippingAddress*/ };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ORG_CompanyAddress Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_CompanyAddress.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ORG_CompanyAddress Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        //public static DB.ORG_CompanyAddress LoadByCompany(DB.ORG_Company org_company, SYS.SYS_Type sys_type, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_CompanyAddress.Join(dataContext.EntitySystemContext.SYS_Address, companyAddress => companyAddress.AddressId, address => address.Id, (companyaddress, address) => new { companyaddress, address }).FirstOrDefault(n => n.companyaddress.CompanyId == org_company.Id && n.address.TypeId == (byte)sys_type).companyaddress;
        //}

        internal static String Save(DB.ORG_CompanyAddress entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrganisationContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityOrganisationContext.ORG_CompanyAddress.Add(entry);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.ORG_CompanyAddress GetNextItem(DB.ORG_CompanyAddress ORG_Address, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_CompanyAddress.OrderBy(o => o.SYS_Address.Title).FirstOrDefault(n => n.SYS_Address.Title.CompareTo(n.SYS_Address.Title) > 0 && n.SYS_Address.Title.CompareTo(n.SYS_Address.Title) != 0);
        //}

        //public static DB.ORG_CompanyAddress GetPreviousItem(DB.ORG_CompanyAddress ORG_Address, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_CompanyAddress.OrderByDescending(o => o.SYS_Address.Title).FirstOrDefault(n => n.SYS_Address.Title.CompareTo(n.SYS_Address.Title) < 0 && n.SYS_Address.Title.CompareTo(n.SYS_Address.Title) != 0);
        //} 
    }
}
