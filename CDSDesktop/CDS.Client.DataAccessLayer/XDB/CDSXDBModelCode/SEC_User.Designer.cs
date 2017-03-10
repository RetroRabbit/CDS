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

    public partial class SEC_User : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        SYS_Person _PersonId;
        [Association(@"SEC_UserReferencesSYS_Person")]
        public SYS_Person PersonId
        {
            get { return _PersonId; }
            set { SetPropertyValue<SYS_Person>("PersonId", ref _PersonId, value); }
        }
        string _Username;
        [Size(20)]
        public string Username
        {
            get { return _Username; }
            set { SetPropertyValue<string>("Username", ref _Username, value); }
        }
        string _Password;
        [Size(50)]
        public string Password
        {
            get { return _Password; }
            set { SetPropertyValue<string>("Password", ref _Password, value); }
        }
        string _DisplayName;
        [Size(50)]
        public string DisplayName
        {
            get { return _DisplayName; }
            set { SetPropertyValue<string>("DisplayName", ref _DisplayName, value); }
        }
        SYS_Printer _DefaultPrinterId;
        [Association(@"SEC_UserReferencesSYS_Printer")]
        public SYS_Printer DefaultPrinterId
        {
            get { return _DefaultPrinterId; }
            set { SetPropertyValue<SYS_Printer>("DefaultPrinterId", ref _DefaultPrinterId, value); }
        }
        SYS_Entity _DefaultCashAccountId;
        [Association(@"SEC_UserReferencesSYS_Entity")]
        public SYS_Entity DefaultCashAccountId
        {
            get { return _DefaultCashAccountId; }
            set { SetPropertyValue<SYS_Entity>("DefaultCashAccountId", ref _DefaultCashAccountId, value); }
        }
        DateTime _LastDate;
        public DateTime LastDate
        {
            get { return _LastDate; }
            set { SetPropertyValue<DateTime>("LastDate", ref _LastDate, value); }
        }
        string _LastVersion;
        [Size(50)]
        public string LastVersion
        {
            get { return _LastVersion; }
            set { SetPropertyValue<string>("LastVersion", ref _LastVersion, value); }
        }
        string _LastLocation;
        [Size(200)]
        public string LastLocation
        {
            get { return _LastLocation; }
            set { SetPropertyValue<string>("LastLocation", ref _LastLocation, value); }
        }
        decimal _DiscountLimit;
        public decimal DiscountLimit
        {
            get { return _DiscountLimit; }
            set { SetPropertyValue<decimal>("DiscountLimit", ref _DiscountLimit, value); }
        }
        bool _UseServerPrinting;
        public bool UseServerPrinting
        {
            get { return _UseServerPrinting; }
            set { SetPropertyValue<bool>("UseServerPrinting", ref _UseServerPrinting, value); }
        }
        string _RoleModifiedBy;
        [Size(200)]
        public string RoleModifiedBy
        {
            get { return _RoleModifiedBy; }
            set { SetPropertyValue<string>("RoleModifiedBy", ref _RoleModifiedBy, value); }
        }
        DateTime _RoleModifiedOn;
        public DateTime RoleModifiedOn
        {
            get { return _RoleModifiedOn; }
            set { SetPropertyValue<DateTime>("RoleModifiedOn", ref _RoleModifiedOn, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        SYS_Person _CreatedBy;
        [Association(@"SEC_UserReferencesSYS_Person1")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        SYS_Entity _DefaultSiteId;
        [Association(@"SEC_UserReferencesSYS_Entity1")]
        public SYS_Entity DefaultSiteId
        {
            get { return _DefaultSiteId; }
            set { SetPropertyValue<SYS_Entity>("DefaultSiteId", ref _DefaultSiteId, value); }
        }
        [Association(@"SEC_UserRoleReferencesSEC_User", typeof(SEC_UserRole))]
        public XPCollection<SEC_UserRole> SEC_UserRoles { get { return GetCollection<SEC_UserRole>("SEC_UserRoles"); } }
    }

}
