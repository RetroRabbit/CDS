using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_ORG_ORG_Company
    {
        public CDS_ORG_ORG_Company(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
