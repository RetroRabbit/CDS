using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    [Persistent("CDS_SEC.SEC_User")]
    public partial class SEC_User
    {
        public SEC_User(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("CreatedBy.Archived")]
        public Boolean Archived
        {
            get { return Convert.ToBoolean(EvaluateAlias("Archived")); }
        }

        [PersistentAlias("PersonId.Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }
    }

}
