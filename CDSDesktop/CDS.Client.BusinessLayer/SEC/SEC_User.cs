using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.BusinessLayer.SEC
{
    public class SEC_User
    {
        /// <summary>
        /// Retrieves a User for the give Username and Password
        /// Make check case sensitive http://stackoverflow.com/questions/3843060/linq-to-entities-case-sensitive-comparison
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Logged in User</returns>
        public static DB.SEC_User Authenticate(string username, string password)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                //Werner: I only did this so that the XPO creates tables before EntityFramework is used
                if (uow.Query<XDB.SEC_User>().Any(n => n.Username.Equals(username) && n.Password.Equals(password)))
                {
                    return ApplicationDataContext.Instance.SecurityEntityContext.SEC_User.FirstOrDefault(n => n.Username.Equals(username) && n.Password.Equals(password));
                }
                else return null;
            }
        }

        public static DB.SEC_User New
        {
            get
            {
                DB.SEC_User entry = new DB.SEC_User() {
                    DefaultPrinterId = ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId
                };

                if (BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(BL.ApplicationDataContext.Instance.CompanySite.PaymentAccounts, typeof(List<BL.GLX.PaymentAccount>)).Count > 0)
                    entry.DefaultCashAccountId = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(BL.ApplicationDataContext.Instance.CompanySite.PaymentAccounts, typeof(List<BL.GLX.PaymentAccount>)).FirstOrDefault(n => n.AccountDefault).AccountId;
                
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.DefaultSiteId = ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                return entry;
            }
        }

        public static DB.SEC_User Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySecurityContext.SEC_User.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SEC_User Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.SEC_User LoadByName(string displayName, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySecurityContext.SEC_User.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.DisplayName == displayName);
        }

        public static DB.SEC_User LoadByName(string displayName, DataContext dataContext)
        {
            return LoadByName(displayName, dataContext, null); 
        }

        public static DB.SEC_User LoadByPerson(Int64 id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySecurityContext.SEC_User.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            return query.FirstOrDefault(n => n.PersonId == id);
        }

        public static DB.SEC_User LoadByPerson(Int64 id, DataContext dataContext)
        {
            return LoadByPerson(id, dataContext, null);  
        }

        internal static String Save(DB.SEC_User entry,DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySecurityContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySecurityContext.SEC_User.Add(entry); 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static byte[] SerializeUser(SEC_User user)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binary = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            binary.Serialize(memStream, user);
            return memStream.ToArray();
        }

        public static SEC_User DeSerializeUser(byte[] data)
        {
            System.IO.MemoryStream memStream = new System.IO.MemoryStream(data);
            memStream.Position = 0;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binary = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            SEC_User newobj = binary.Deserialize(memStream) as SEC_User;
            memStream.Close();
            return newobj;
        } 

        public static DB.SEC_User GetNextItem(DB.SEC_User sec_user, DataContext dataContext)
        {
            return dataContext.EntitySecurityContext.SEC_User.OrderBy(o => o.DisplayName).FirstOrDefault(n => n.DisplayName.CompareTo(sec_user.DisplayName) > 0 && n.DisplayName.CompareTo(sec_user.DisplayName) != 0);
        }

        public static DB.SEC_User GetPreviousItem(DB.SEC_User sec_user, DataContext dataContext)
        {
            return dataContext.EntitySecurityContext.SEC_User.OrderByDescending(o => o.DisplayName).FirstOrDefault(n => n.DisplayName.CompareTo(sec_user.DisplayName) < 0 && n.DisplayName.CompareTo(sec_user.DisplayName) != 0);
        }         
    }

}
