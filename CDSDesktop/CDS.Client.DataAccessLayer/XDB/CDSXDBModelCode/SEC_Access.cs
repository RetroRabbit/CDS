using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SEC.SEC_Access")]
    public partial class SEC_Access
    {
        public SEC_Access(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
