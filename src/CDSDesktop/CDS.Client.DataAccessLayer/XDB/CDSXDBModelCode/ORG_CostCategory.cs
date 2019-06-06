using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ORG.ORG_CostCategory")]
    public partial class ORG_CostCategory
    {
        public ORG_CostCategory(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
