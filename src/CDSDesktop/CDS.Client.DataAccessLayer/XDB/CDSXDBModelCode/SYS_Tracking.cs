using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_Tracking")]
    public partial class SYS_Tracking
    {
        public SYS_Tracking(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
