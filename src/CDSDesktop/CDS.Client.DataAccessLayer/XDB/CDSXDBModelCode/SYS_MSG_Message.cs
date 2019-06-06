using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_MSG_Message")]
    public partial class SYS_MSG_Message
    {
        public SYS_MSG_Message(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }
    }

}
