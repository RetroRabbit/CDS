using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_Address
    {
        public static DB.SYS_Address NewBillingAddress
        {
            get
            {
                DB.SYS_Address entry = new DB.SYS_Address();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.TypeId = (byte)SYS.SYS_Type.BillingAddress;
                return entry;
            }
        }

        public static DB.SYS_Address NewShippingAddress
        {
            get
            {
                DB.SYS_Address entry = new DB.SYS_Address();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.TypeId = (byte)SYS.SYS_Type.ShippingAddress;
                return entry;
            }
        }

        public static DB.SYS_Address Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Address.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Address Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SYS_Address entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Address.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_Address GetNextItem(DB.SYS_Address SYS_Address, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Address.OrderBy(o => o.Id).FirstOrDefault(n => n.Id > SYS_Address.Id);
        }

        public static DB.SYS_Address GetPreviousItem(DB.SYS_Address SYS_Address, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Address.OrderByDescending(o => o.Id).FirstOrDefault(n => n.Id < SYS_Address.Id);
        }

    }
}
