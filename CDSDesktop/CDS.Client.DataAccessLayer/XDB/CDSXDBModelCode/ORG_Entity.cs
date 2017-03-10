using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ORG.ORG_Entity")]
    public partial class ORG_Entity
    {
        public ORG_Entity(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("EntityId.Name")]
        public String Name
        {
            get { return Convert.ToString(EvaluateAlias("Name")); }
        }

        [PersistentAlias("ORG_Companys[TypeId.Name == 'Customer'].Exists")]
        public Boolean HasCustomer
        {
            get { return Convert.ToBoolean(EvaluateAlias("HasCustomer")); }
        }

        [PersistentAlias("ORG_Companys[TypeId.Name == 'Supplier'].Exists")]
        public Boolean HasSupplier
        {
            get { return Convert.ToBoolean(EvaluateAlias("HasSupplier")); }
        }

        [PersistentAlias("EntityId.Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        [PersistentAlias("EntityId.Archived")]
        public Boolean Archived
        {
            get { return Convert.ToBoolean(EvaluateAlias("Archived")); }
        }
    }

}
