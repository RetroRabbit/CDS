using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ITM.ITM_StockTakeStatus")]
    public partial class ITM_StockTakeStatus
    {
        public ITM_StockTakeStatus(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
