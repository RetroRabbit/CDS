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

    [Persistent(@"CDS_SEC.SEC_Role")]
    public partial class CDS_SEC_SEC_Role : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        string _Code;
        [Size(50)]
        public string Code
        {
            get { return _Code; }
            set { SetPropertyValue<string>("Code", ref _Code, value); }
        }
        string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>("Name", ref _Name, value); }
        }
        string _Description;
        [Size(2000)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>("Description", ref _Description, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_SEC_SEC_RoleReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        [Association(@"CDS_SEC_SEC_RoleAccessReferencesCDS_SEC_SEC_Role", typeof(CDS_SEC_SEC_RoleAccess))]
        public XPCollection<CDS_SEC_SEC_RoleAccess> CDS_SEC_SEC_RoleAccesss { get { return GetCollection<CDS_SEC_SEC_RoleAccess>("CDS_SEC_SEC_RoleAccesss"); } }
        [Association(@"CDS_SEC_SEC_UserRoleReferencesCDS_SEC_SEC_Role", typeof(CDS_SEC_SEC_UserRole))]
        public XPCollection<CDS_SEC_SEC_UserRole> CDS_SEC_SEC_UserRoles { get { return GetCollection<CDS_SEC_SEC_UserRole>("CDS_SEC_SEC_UserRoles"); } }
    }

}
