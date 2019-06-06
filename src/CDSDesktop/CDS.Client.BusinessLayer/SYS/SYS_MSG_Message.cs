using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_MSG_Message
    {
        public static DB.SYS_MSG_Message New
        {
            get
            {
                DB.SYS_MSG_Message entry = new DB.SYS_MSG_Message();
                entry.FromId = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                return entry;
            }
        }

        internal static String Save(DB.SYS_MSG_Message entry,DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_MSG_Message.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_MSG_Message GetNextItem(DB.SYS_MSG_Message SYS_MSG_Message, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_MSG_Message.OrderBy(o => o.Id).FirstOrDefault(n => n.Id.CompareTo(SYS_MSG_Message.Id) > 0 && n.Id.CompareTo(SYS_MSG_Message.Id) != 0);
        }

        public static DB.SYS_MSG_Message GetPreviousItem(DB.SYS_MSG_Message SYS_MSG_Message, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_MSG_Message.OrderByDescending(o => o.Id).FirstOrDefault(n => n.Id.CompareTo(SYS_MSG_Message.Id) < 0 && n.Id.CompareTo(SYS_MSG_Message.Id) != 0);
        } 
    }
}
