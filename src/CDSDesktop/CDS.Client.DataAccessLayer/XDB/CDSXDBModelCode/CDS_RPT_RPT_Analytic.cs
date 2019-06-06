using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_RPT_RPT_Analytic
    {
        public CDS_RPT_RPT_Analytic(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
