using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_DOC_Type")]
    public partial class SYS_DOC_Type
    {
        public SYS_DOC_Type(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}