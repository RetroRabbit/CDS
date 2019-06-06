using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_CAT_CAT_Item
    {
        public CDS_CAT_CAT_Item(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
