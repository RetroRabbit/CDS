using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_AOR.AOR_OrderLine")]
    public partial class AOR_OrderLine
    {
        public AOR_OrderLine(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
