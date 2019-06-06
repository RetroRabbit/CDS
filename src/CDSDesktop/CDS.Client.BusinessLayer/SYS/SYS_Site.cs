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
    public class SYS_Site
    {

        public static DB.SYS_Site New
        {
            get
            {
                DB.SYS_Site entry = new DB.SYS_Site() { SYS_Entity = SYS_Entity.NewSite };
                entry.SYS_Address_BillingAddress = SYS.SYS_Address.NewBillingAddress;
                entry.SYS_Address_ShippingAddress = SYS.SYS_Address.NewShippingAddress;
                entry.SYS_Entity.ShortName = "New Site";
                entry.SYS_Entity.Name = "New Site";
                entry.SYS_Entity.Description = "New Site";
                entry.UpdateCheckTime = "16,00,00";
                entry.QuoteValidDays = 7;
                entry.QuoteValidMax = 30;
                entry.NegativeDiscountEffects = 0;
                entry.RoundingAmount = 0;
                entry.PaymentAccounts = "<?xml version=\"1.0\" encoding=\"utf-16\"?>  <ArrayOfPaymentAccount xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"></ArrayOfPaymentAccount>";
                return entry;
            }
        }

        public static DB.SYS_Site Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Site.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Site Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SYS_Site entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntitySystemContext.SYS_Site.Add(entry);
                   //TODO : Generate Stock items and history for this site
                }
              
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        } 

        public static DB.SYS_Site GetNextItem(DB.SYS_Site SYS_Site, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Site.OrderBy(o => o.SYS_Entity.Name).FirstOrDefault(n => n.SYS_Entity.Name.CompareTo(SYS_Site.SYS_Entity.Name) > 0 && n.SYS_Entity.Name.CompareTo(SYS_Site.SYS_Entity.Name) != 0);
        }

        public static DB.SYS_Site GetPreviousItem(DB.SYS_Site SYS_Site, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Site.OrderByDescending(o => o.SYS_Entity.Name).FirstOrDefault(n => n.SYS_Entity.Name.CompareTo(SYS_Site.SYS_Entity.Name) < 0 && n.SYS_Entity.Name.CompareTo(SYS_Site.SYS_Entity.Name) != 0);
        } 

        public static DB.SYS_Site LoadByEntityId(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Site.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.EntityId == Id);
        }

        public static DB.SYS_Site LoadByEntityId(Int64 Id, DataContext dataContext)
        {
            return LoadByEntityId(Id, dataContext, null);
        } 
    }
}
