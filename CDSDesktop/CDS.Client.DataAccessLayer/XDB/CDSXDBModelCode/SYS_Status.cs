using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_Status")]
    public partial class SYS_Status
    {
        public SYS_Status(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
