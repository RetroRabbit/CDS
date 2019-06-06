using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_SEC_SEC_Role
    {
        public CDS_SEC_SEC_Role(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
