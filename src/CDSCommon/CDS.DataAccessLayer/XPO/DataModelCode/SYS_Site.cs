using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.DataAccessLayer.XPO.Datamodel
{

    public partial class SYS_Site
    {
        public SYS_Site(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
