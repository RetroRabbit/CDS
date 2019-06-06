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
    [RoutePrefix("api/item")]
    public class ItemController : ApiController
    {
        [Route("")]
        public object Get(byte type)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;

                List<PORT.Item> items = BL.Web.ITM.ITM_ItemProvider.GetItems(conn, type);

                return items;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }
    }
}