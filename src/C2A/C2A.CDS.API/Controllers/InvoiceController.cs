using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using DevExpress.Xpo;
using Newtonsoft.Json;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;
using BL = CDS.BusinessLayer;

namespace CDS.C2A.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/invoice")]
    public class InvoiceController : ApiController
    {
        [Route("")]
        public List<PORT.Document> Get()
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;

                return BL.Web.ORG.ORG_TRX_HeaderProvider.GetHeaders(conn);
            }
            catch
            {
                return new List<PORT.Document>();// "Error connecting to database";
            }

        }

        [Route("")]
        public string Post([FromBody]string value)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;
                String uName = identity.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value;

                BL.Web.Common.DocumentController.SaveDocument(conn, uName, value);

                return "Saved Successfully";
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.ToString();
            }
        }

        [Route("")]
        public PORT.Document Get(Int64 id)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;

                return BL.Web.ORG.ORG_TRX_HeaderProvider.GetById(conn, id);
            }
            catch
            {
                return new PORT.Document();// "Error connecting to database";
            }
        }
    }

    class ResponseMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}