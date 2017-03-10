using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ITM.ITM_BOM_RecipeLine")]
    public partial class ITM_BOM_RecipeLine
    {
        public ITM_BOM_RecipeLine(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
