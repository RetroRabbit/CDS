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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("")]
        public object Get()
        {
            try
            {                
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;
                String uName = identity.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value;

                PORT.UserProfile userProfile = BL.Web.SEC.SEC_UserProvider.GetUserProfile(conn, uName);

                return userProfile;
                
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }   
    }
}