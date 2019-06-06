using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_CAL.CAL_Attachment")]
    public partial class CAL_Attachment
    {
        public CAL_Attachment(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
