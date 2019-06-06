using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_GLX.GLX_History")]
    public partial class GLX_History
    {
        public GLX_History(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
          
    }

}
