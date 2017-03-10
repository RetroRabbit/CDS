using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;

namespace CDS.BusinessLayer.Core.ORG
{
    internal static class ORG_CompanyProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="companyId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        internal static int UpdateCompanyHistory(UnitOfWork uow, Int64 companyId, decimal amount)
        {
            return uow.ExecuteNonQuery("EXEC CDS_SYS.spUpdateCompanyHistory @0,@1", new string[] { "0", "1" }, new object[] { companyId, amount });
        }
    }
}
