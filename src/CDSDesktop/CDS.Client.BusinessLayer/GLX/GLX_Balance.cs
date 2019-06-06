using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.GLX
{
    public class GLX_History
    {
        public static int GenerateAccountBalances(DB.GLX_Account Account,DataContext dataContext)
        {
            return dataContext.EntityAccountingContext.ExecuteSqlCommand(string.Format("EXEC CDS_SYS.spGenerateAccountBalances {0},{1}", Account.EntityId, Account.AgingAccount ? 1 : 0));
        }
    }
}
