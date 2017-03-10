using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;

namespace CDS.BusinessLayer.Core.GLX
{
    internal static class GLX_AccountProvider
    {
        internal static List<Int64> ProfitDistributionEntriesRequired(UnitOfWork uow)
        {
    //        var status in Order.Status.Where(status => 
    //status.OrderCode.In(
    //    OrderStatus.Valid, 
    //    OrderStatus.Active, 
    //    OrderStatus.Processed,
    //    OrderStatus.Completed));

            return uow.Query<DAL.Datamodel.GLX_Account>().Where(n => (new DAL.Enums.GLX_Type[] { DAL.Enums.GLX_Type.Sales, DAL.Enums.GLX_Type.CostofSales, DAL.Enums.GLX_Type.Expenses }).Contains(n.AccountTypeId)).Select(l => l.EntityId.Id).ToList();
        }
    }
}
