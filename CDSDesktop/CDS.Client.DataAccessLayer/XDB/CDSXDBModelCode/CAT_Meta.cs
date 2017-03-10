using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_CAT.CAT_Meta")]
    public partial class CAT_Meta
    {
        public CAT_Meta(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
