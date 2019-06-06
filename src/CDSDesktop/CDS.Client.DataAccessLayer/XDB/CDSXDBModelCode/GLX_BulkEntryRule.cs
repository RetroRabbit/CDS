using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_GLX.GLX_BulkEntryRule")]
    public partial class GLX_BulkEntryRule
    {
        public GLX_BulkEntryRule(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
