using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_GLX_GLX_Recon
    {
        public CDS_GLX_GLX_Recon(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}