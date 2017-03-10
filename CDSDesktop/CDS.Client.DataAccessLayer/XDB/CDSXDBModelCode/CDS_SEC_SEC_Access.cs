using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_SEC_SEC_Access
    {
        public CDS_SEC_SEC_Access(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
