using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_SYS_SYS_DOC_Header
    {
        public CDS_SYS_SYS_DOC_Header(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
