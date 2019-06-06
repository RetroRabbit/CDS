using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_Site")]
    public partial class SYS_Site
    {
        public SYS_Site(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("EntityId.Archived")]
        public Boolean Archived
        {
            get { return Convert.ToBoolean(EvaluateAlias("Archived")); }
        }

        [PersistentAlias("EntityId.Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }
    }

}
