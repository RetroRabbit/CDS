using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_CAT.CAT_Item")]
    public partial class CAT_Item
    {
        public CAT_Item(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
