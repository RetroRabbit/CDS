using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace resources.api.cdsonline.co.za.Services
{
    public class AttributeRepository
    {
        public string[] GetAllAttributes(string clientId)
        {
            try
            {
                using (Session result = XpoHelper.GetNewSession())
                {
                    XPQuery<DAL.Datamodel.APP_CompanyValue> items = result.Query<DAL.Datamodel.APP_CompanyValue>();
                    return items.Where(a => a.EntityId.Name == clientId && a.AttributeId.Id == 1).Select(a => a.Value).ToArray();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal string GetAttributeByName(string clientId, string attributeName)
        {
            try
            {
                using (Session result = XpoHelper.GetNewSession())
                {
                    XPQuery<DAL.Datamodel.APP_CompanyValue> items = result.Query<DAL.Datamodel.APP_CompanyValue>();
                    return items.SingleOrDefault(a => a.EntityId.Name == clientId && a.AttributeId.Code == attributeName).Value;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal List<PORT.Attribute> GetAttributeByNames(string applicationId, string userName, string[] attributeNames)
        {
            try
            {
                using (var result = XpoHelper.GetNewSession())
                {
                    var attributes = result.Query<DAL.Datamodel.APP_Attribute>();
                    var userValues = result.Query<DAL.Datamodel.APP_UserValue>();
                    var companyValues = result.Query<DAL.Datamodel.APP_CompanyValue>();

                    var user = result.Query<DAL.Datamodel.ORG_Contact>().SingleOrDefault(u => u.Email == userName);
                    var person = user.PersonId;
                    var company = user.CompanyId;

                    List<PORT.Attribute> re = new List<PORT.Attribute>();
                    re.AddRange(userValues
                        .Where(a => a.PersonId.Id == person.Id && a.ApplicationId.Name == applicationId && attributeNames.Contains(a.AttributeId.Code))
                        .Select(pa => new PORT.Attribute() { code = pa.AttributeId.Code, name = pa.AttributeId.Name, value = pa.Value, type = "user" }).ToList());

                    re.AddRange(companyValues
                        .Where(a => a.EntityId.Id == company.Id && a.ApplicationId.Name == applicationId && attributeNames.Contains(a.AttributeId.Code))
                        .Select(pa => new PORT.Attribute() { code = pa.AttributeId.Code, name = pa.AttributeId.Name, value = pa.Value, type = "company" }).ToList());

                    //return items.SingleOrDefault(a => a.EntityId.Id == 24 && a.AttributeId.Code == attributeName).Value;
                    return re;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}