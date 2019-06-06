using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_ITM_ITM_BOM_Document
    {
        public CDS_ITM_ITM_BOM_Document(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
