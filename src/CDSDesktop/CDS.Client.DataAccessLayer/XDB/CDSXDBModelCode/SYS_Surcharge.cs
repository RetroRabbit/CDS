using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_Surcharge")]
    public partial class SYS_Surcharge
    {
        public SYS_Surcharge(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        [PersistentAlias("Concat([EntityId.ShortName], ' - ',[Amount])")]
        public String Title
        {
            get { return Convert.ToString(EvaluateAlias("Title")); }
        }
    }

}
