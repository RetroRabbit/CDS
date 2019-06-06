using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace CDS.BusinessLayer.Web.ORG
{
    public static class ORG_CompanyProvider
    {
        public static List<PORT.Company> GetCompanies(string connectionString, byte type, string searchValue)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();

                XPQuery<DAL.Datamodel.SYS_Entity> companies = uow.Query<DAL.Datamodel.SYS_Entity>();

                if (type == 1)
                {
                    //return companies.Where(c => c.TypeId.Id == 3 && c.CodeMain == "" && (c.CodeSub.Contains(searchValue) || (c.Name.Contains(searchValue))))
                    //    .Take(10)
                    //    .Select(n => new { Id = n.Id, Code = n.CodeSub, Name = n.Name })
                    //    .ToList();
                    return companies.Where(c => c.TypeId == DAL.Enums.SYS_Type.Company && c.CodeMain == "")
                        .Select(n => new PORT.Company { id = n.Id, code = n.CodeSub, name = n.Name })
                        .ToList();
                }
                else
                {
                    //return companies.Where(c => c.TypeId.Id == 3 && c.CodeMain == "" && (c.CodeSub.Contains(searchValue) || (c.Name.Contains(searchValue))))
                    //    .Take(10)
                    //    .Select(n => new { Id = n.Id, Code = n.CodeSub, Name = n.Name })
                    //    .ToList();
                    return companies.Where(c => c.TypeId == DAL.Enums.SYS_Type.Company && c.CodeMain == "")
                        .Select(n => new PORT.Company { id = n.Id, code = n.CodeSub, name = n.Name })
                        .ToList();
                }
            }
        }

        public static PORT.Company GetCompany(string connectionString, Int64 id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();

                PORT.Company company = new PORT.Company();

                DAL.Datamodel.ORG_Company xdp_company = uow.Query<DAL.Datamodel.ORG_Company>().Where(c => c.EntityId.EntityId.Id == id).FirstOrDefault();

                DAL.Datamodel.SYS_Address billing = uow.Query<DAL.Datamodel.ORG_CompanyAddress>().Where(a => a.CompanyId == xdp_company && a.AddressId.TypeId == DAL.Enums.SYS_Type.BillingAddress).FirstOrDefault().AddressId;

                company.billingAddressLine1 = billing.Line1;
                company.billingAddressLine2 = billing.Line2;
                company.billingAddressLine3 = billing.Line3;
                company.billingAddressLine4 = billing.Line4;
                company.billingAddressCode = billing.Code;
                company.referenceShort1 = xdp_company.SalesmanCode;
                company.referenceShort2 = xdp_company.RepCode;
                company.code = xdp_company.EntityId.EntityId.CodeSub;
                company.name = xdp_company.EntityId.EntityId.Name;

                return company;
            }
        }
    }
}
