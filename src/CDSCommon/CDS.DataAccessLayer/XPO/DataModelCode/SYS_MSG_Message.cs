using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.DataAccessLayer.XPO.Datamodel
{

    public partial class SYS_MSG_Message
    {
        public SYS_MSG_Message(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
