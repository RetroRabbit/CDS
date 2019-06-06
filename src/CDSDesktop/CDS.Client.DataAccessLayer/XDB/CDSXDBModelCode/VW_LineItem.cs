using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class VW_LineItem
    {
        public VW_LineItem(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
