using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_CAT.CAT_ItemData")]
    public partial class CAT_ItemData
    {
        public CAT_ItemData(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
