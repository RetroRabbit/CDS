using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ITM.ITM_Movement")]
    public partial class ITM_Movement
    {
        public ITM_Movement(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
