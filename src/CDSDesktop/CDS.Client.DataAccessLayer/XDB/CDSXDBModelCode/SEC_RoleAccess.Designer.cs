//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class SEC_RoleAccess : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        SEC_Role _RoleId;
        [Association(@"SEC_RoleAccessReferencesSEC_Role")]
        public SEC_Role RoleId
        {
            get { return _RoleId; }
            set { SetPropertyValue<SEC_Role>("RoleId", ref _RoleId, value); }
        }
        SEC_Access _AccessId;
        [Association(@"SEC_RoleAccessReferencesSEC_Access")]
        public SEC_Access AccessId
        {
            get { return _AccessId; }
            set { SetPropertyValue<SEC_Access>("AccessId", ref _AccessId, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        SYS_Person _CreatedBy;
        [Association(@"SEC_RoleAccessReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        DateTime _ModifiedOn;
        public DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { SetPropertyValue<DateTime>("ModifiedOn", ref _ModifiedOn, value); }
        }
        string _ModifiedBy;
        [Size(50)]
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { SetPropertyValue<string>("ModifiedBy", ref _ModifiedBy, value); }
        }
        DateTime _SecurityModifiedOn;
        public DateTime SecurityModifiedOn
        {
            get { return _SecurityModifiedOn; }
            set { SetPropertyValue<DateTime>("SecurityModifiedOn", ref _SecurityModifiedOn, value); }
        }
        string _SecurityModifiedBy;
        [Size(200)]
        public string SecurityModifiedBy
        {
            get { return _SecurityModifiedBy; }
            set { SetPropertyValue<string>("SecurityModifiedBy", ref _SecurityModifiedBy, value); }
        }
    }

}
