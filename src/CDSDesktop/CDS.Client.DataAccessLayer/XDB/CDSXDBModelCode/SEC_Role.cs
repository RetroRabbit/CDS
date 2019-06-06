using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SEC.SEC_Role")]
    public partial class SEC_Role
    {
        public SEC_Role(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }
    }

}
