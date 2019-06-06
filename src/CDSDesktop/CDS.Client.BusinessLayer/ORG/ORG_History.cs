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
    public class ORG_History
    {
        public static int GenerateCompanyHistory(DB.ORG_Company orgCompany, DataContext DataContext)
        {
            return DataContext.EntityOrganisationContext.Database.ExecuteSqlCommand(string.Format("EXEC CDS_SYS.spGenerateCompanyHistory {0}", orgCompany.Id));
        }

        public static int UpdateCompanyHistory(Int64 companyId, decimal amount, DataContext dataContext)
        {
            return dataContext.EntityOrganisationContext.Database.ExecuteSqlCommand("EXEC CDS_SYS.spUpdateCompanyHistory {0},{1},{2}", companyId, amount,ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }
    }
}
