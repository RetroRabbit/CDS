using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ORG.ORG_Distribution")]
    public partial class ORG_Distribution
    {
        public ORG_Distribution(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
