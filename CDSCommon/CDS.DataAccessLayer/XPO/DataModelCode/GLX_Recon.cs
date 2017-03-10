using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.DataAccessLayer.XPO.Datamodel
{

    public partial class GLX_Recon
    {
        public GLX_Recon(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
