using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class CDS_CAL_CAL_Attachment
    {
        public CDS_CAL_CAL_Attachment(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
