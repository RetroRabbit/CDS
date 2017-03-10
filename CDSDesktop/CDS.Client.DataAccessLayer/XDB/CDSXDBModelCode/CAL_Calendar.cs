using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_CAL.CAL_Calendar")]
    public partial class CAL_Calendar
    {
        public CAL_Calendar(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
