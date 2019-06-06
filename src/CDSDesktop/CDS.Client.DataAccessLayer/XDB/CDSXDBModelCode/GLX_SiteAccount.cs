using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_GLX.GLX_SiteAccount")]
    public partial class GLX_SiteAccount
    {
        public GLX_SiteAccount(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
