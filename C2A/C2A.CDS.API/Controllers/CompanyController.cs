using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;
using BL = CDS.BusinessLayer;

namespace CDS.C2A.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        [Route("")]
        public object Get(byte type, string searchValue)
        {
            try
            {
                
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;

                List<PORT.Company> companyResults = BL.Web.ORG.ORG_CompanyProvider.GetCompanies(conn, type, searchValue);

                return companyResults;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [Route("")]
        public object Get(Int64 id)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;

                PORT.Company selectedCompany = BL.Web.ORG.ORG_CompanyProvider.GetCompany(conn, id);

                return selectedCompany;

            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}