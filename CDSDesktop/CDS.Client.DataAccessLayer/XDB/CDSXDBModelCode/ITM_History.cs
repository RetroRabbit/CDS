using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ITM.ITM_History")]
    public partial class ITM_History
    {
        public ITM_History(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
 
        [PersistentAlias("PeriodId.ITM_Historys[PeriodId.EndDate > AddDays(AddMonths(now(),-3),-GetDay(now())-1)].Sum(Amount) / 3")]
        public decimal? AverageSales3
        {
            get { return Math.Round(Convert.ToDecimal(EvaluateAlias("AverageSales3")), 2); }
        }

        [PersistentAlias("PeriodId.ITM_Historys[PeriodId.EndDate > AddDays(AddMonths(now(),-6),-GetDay(now())-1)].Sum(Amount) / 6")]
        public decimal? AverageSales6
        {
            get { return Math.Round(Convert.ToDecimal(EvaluateAlias("AverageSales6")), 2); }
        }

        [PersistentAlias("PeriodId.ITM_Historys[PeriodId.EndDate > AddDays(AddMonths(now(),-12),-GetDay(now())-1)].Sum(Amount) / 12")]
        public decimal? AverageSales12
        {
            get { return Math.Round(Convert.ToDecimal(EvaluateAlias("AverageSales12")), 2); }
        }

        [PersistentAlias("Concat([SiteId.Id], '|', [InventoryId.Id])")]
        public string CombinedKey
        {
            get { return (string)EvaluateAlias("CombinedKey"); }
        }

    }

}
