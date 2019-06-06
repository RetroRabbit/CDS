using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ITM.ITM_StockTake")]
    public partial class ITM_StockTake
    {
        public ITM_StockTake(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("(ITM_StockTakeItems[].Sum(Iif(QuantityCount2 is null, QuantityCount1, QuantityCount2)*UnitCost))-(ITM_StockTakeItems[].Sum(OnHand*UnitCost))")]
        public decimal Variance
        {
            get { return Convert.ToDecimal(EvaluateAlias("Variance")); }
        }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }
    }

}
