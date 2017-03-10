using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_Person")]
    public partial class SYS_Person
    {
        public SYS_Person(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
