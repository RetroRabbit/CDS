using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        [Route("")]
        public HttpResponseMessage Post(long documentId, long reportId)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                var identity = User.Identity as ClaimsIdentity;

                String conn = identity.Claims.Where(n => n.Type == "conn").FirstOrDefault().Value;

                ms = BL.Web.RPT.RPT_ReportProvider.DocumentPreview(conn, documentId, reportId);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.GetBuffer())
                };
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Document.pdf"
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return result;
            }
            catch (Exception e)
            {
                System.Web.HttpContext.Current.Response.Headers.Add("Access-Control-Expose-Headers", "Exception");
                System.Web.HttpContext.Current.Response.Headers.Add("Exception", e.ToString() + Environment.NewLine + e.Message);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return result;
            }
        }
    }
}