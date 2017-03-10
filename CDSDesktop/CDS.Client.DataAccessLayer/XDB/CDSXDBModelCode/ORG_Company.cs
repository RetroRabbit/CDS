using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ORG.ORG_Company")]
    public partial class ORG_Company
    {
        public ORG_Company(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        [PersistentAlias("EntityId.EntityId.Archived")]
        public Boolean Archived
        {
            get { return Convert.ToBoolean(EvaluateAlias("Archived")); }
        }

        [PersistentAlias("EntityId.EntityId.Title")]
        public String Title
        {
            get { return Convert.ToString(EvaluateAlias("Title")); }
        }

        [PersistentAlias("[<ORG_Contact>][IsDefault = 1 and CompanyId.Id = ^.EntityId.EntityId.Id].Max([PersonId.Fullname])")]
        public String AccountsContactName
        {
            get { return Convert.ToString(EvaluateAlias("AccountsContactName")); }
        }

        [PersistentAlias("[<ORG_Contact>][IsDefault = 1 and CompanyId.Id = ^.EntityId.EntityId.Id].Max([Telephone1])")]
        public String AccountsContactTelephone
        {
            get { return Convert.ToString(EvaluateAlias("AccountsContactTelephone")); }
        }

        [PersistentAlias("[<ORG_Contact>][IsDefault = 1 and CompanyId.Id = ^.EntityId.EntityId.Id].Max([Email])")]
        public String AccountsContactEmail
        {
            get { return Convert.ToString(EvaluateAlias("AccountsContactEmail")); }
        }

        [PersistentAlias("[<ORG_Contact>][IsDefault = 1 and CompanyId.Id = ^.EntityId.EntityId.Id].Max([PersonId.Fullname])")]
        public String SalesContactName
        {
            get { return Convert.ToString(EvaluateAlias("SalesContactName")); }
        }

        [PersistentAlias("[<ORG_Contact>][IsDefault = 1 and CompanyId.Id = ^.EntityId.EntityId.Id].Max([Telephone1])")]
        public String SalesContactTelephone
        {
            get { return Convert.ToString(EvaluateAlias("SalesContactTelephone")); }
        }

        [PersistentAlias("[<ORG_Contact>][IsDefault = 1 and CompanyId.Id = ^.EntityId.EntityId.Id].Max([Email])")]
        public String SalesContactEmail
        {
            get { return Convert.ToString(EvaluateAlias("SalesContactEmail")); }
        }
    }
}
