using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SEC.SEC_UserRole")]
    public partial class SEC_UserRole
    {
        public SEC_UserRole(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
