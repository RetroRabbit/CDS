using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_AOR_AOR_OrderLine
    {
        public CDS_AOR_AOR_OrderLine(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
