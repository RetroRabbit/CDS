using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace CDS.BusinessLayer.Web.SEC
{
    public class SEC_UserProvider
    {
        public static PORT.UserProfile GetUserProfile(string connectionString, string userName)
        {
            PORT.UserProfile userProfile = new PORT.UserProfile();
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();
                //XPQuery<DAL.XPO.Datamodel.SEC_User> users = uow.Query<DAL.XPO.Datamodel.SEC_User>();
                //userProfile = users.Where(u => u.Username == uName).Select(n => new Models.UserProfile { DisplayName = n.DisplayName, Avatar = n.PersonId.HRS_Employees1.FirstOrDefault(e => e.PersonId == n.PersonId).Photo, Online = true }).FirstOrDefault();
                //return userProfile;

                XPCollection<DAL.Datamodel.SEC_User> users = new XPCollection<DAL.Datamodel.SEC_User>(uow);
                userProfile = users.Where(u => u.Username == userName).Select(n => new PORT.UserProfile { displayName = n.DisplayName, avatar = n.PersonId.HRS_Employees1.FirstOrDefault(e => e.PersonId == n.PersonId).Photo, online = true }).FirstOrDefault();
            }
            return userProfile;

        }
    }
}
