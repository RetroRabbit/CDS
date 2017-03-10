using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ORG
{
    public class ORG_Distribution
    {

        public static DB.ORG_Distribution New
        {
            get
            {
                DB.ORG_Distribution entry = new DB.ORG_Distribution() { /*SYS_Person = SYS.SYS_Person.New*/ };
                entry.DistributionTypeId = (byte)ORG_DistributionType.Internal;
                entry.InventoryViewLevel = 10;
                entry.ViewCost = false;
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        internal static String Save(DB.ORG_Distribution entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrganisationContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached) 
                    dataContext.EntityOrganisationContext.ORG_Distribution.Add(entry); 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ORG_Distribution Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_Distribution.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ORG_Distribution Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }  
    }
}
