using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;

namespace CDS.BusinessLayer.Core.SYS
{
    internal static class SYS_TrackingProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="initiator"></param>
        /// <returns></returns>
        internal static DAL.Datamodel.SYS_Tracking New(UnitOfWork uow, string initiator)
        {
            return new DAL.Datamodel.SYS_Tracking(uow) { Initiator = initiator , Archived = false };
        }
    }
}
