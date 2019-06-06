using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.DataAccessLayer.XPO.Datamodel
{

    public partial class ITM_BOM_Document
    {
        public ITM_BOM_Document(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
