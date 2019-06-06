using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_Layout")]
    public partial class SYS_Layout
    {
        public SYS_Layout(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
