using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;
using resources.api.cdsonline.co.za.Services;
using System.Security.Claims;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace resources.api.cdsonline.co.za.Controllers
{
    [Authorize]
    [RoutePrefix("api/attribute")]
    public class AttributeController : ApiController
    {
        private AttributeRepository attributeRepository;
        
        public AttributeController()
        {
            this.attributeRepository = new AttributeRepository();
        }

        [Route("")]
        public string GetByName(string attributeName)
        {
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            String clientId = identity.Claims.Where(n => n.Type == "applicationId").SingleOrDefault().Value;

            return this.attributeRepository.GetAttributeByName(clientId, attributeName);
        }

        [Route("")]
        public List<PORT.Attribute> GetByNames([FromUri] string attributeClaims)
        {
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            String applicationId = identity.Claims.Where(n => n.Type == "applicationId").SingleOrDefault().Value;
            String userName = identity.Claims.Where(n => n.Type == ClaimTypes.Name).SingleOrDefault().Value;
            List<PORT.AttributeClaim> attributes = (List<PORT.AttributeClaim>)JsonConvert.DeserializeObject(attributeClaims, typeof(List<PORT.AttributeClaim>));
            
            var attr = this.attributeRepository.GetAttributeByNames(applicationId, userName, attributes.Select(at => at.attributeCode).ToArray());
            attr.Where(a => a.type == "user").ToList().ForEach(a => identity.AddClaim(new Claim(a.code, a.value)));

            return attr.Where(a => a.type == "company").ToList();
        }
    }
}