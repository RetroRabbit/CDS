using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ORG.ORG_History")]
    public partial class ORG_History
    {
        public ORG_History(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
