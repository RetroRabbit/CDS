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

    [Persistent(@"CDS_GLX.GLX_Account")]
    public partial class CDS_GLX_GLX_Account : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CDS_SYS_SYS_Entity _EntityId;
        [Association(@"CDS_GLX_GLX_AccountReferencesCDS_SYS_SYS_Entity")]
        public CDS_SYS_SYS_Entity EntityId
        {
            get { return _EntityId; }
            set { SetPropertyValue<CDS_SYS_SYS_Entity>("EntityId", ref _EntityId, value); }
        }
        CDS_GLX_GLX_Type _AccountTypeId;
        [Association(@"CDS_GLX_GLX_AccountReferencesCDS_GLX_GLX_Type")]
        public CDS_GLX_GLX_Type AccountTypeId
        {
            get { return _AccountTypeId; }
            set { SetPropertyValue<CDS_GLX_GLX_Type>("AccountTypeId", ref _AccountTypeId, value); }
        }
        CDS_SYS_SYS_Entity _CenterId;
        [Association(@"CDS_GLX_GLX_AccountReferencesCDS_SYS_SYS_Entity1")]
        public CDS_SYS_SYS_Entity CenterId
        {
            get { return _CenterId; }
            set { SetPropertyValue<CDS_SYS_SYS_Entity>("CenterId", ref _CenterId, value); }
        }
        bool _AgingAccount;
        public bool AgingAccount
        {
            get { return _AgingAccount; }
            set { SetPropertyValue<bool>("AgingAccount", ref _AgingAccount, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_GLX_GLX_AccountReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        CDS_SYS_SYS_Entity _ControlId;
        [Association(@"CDS_GLX_GLX_AccountReferencesCDS_SYS_SYS_Entity2")]
        public CDS_SYS_SYS_Entity ControlId
        {
            get { return _ControlId; }
            set { SetPropertyValue<CDS_SYS_SYS_Entity>("ControlId", ref _ControlId, value); }
        }
        CDS_SYS_SYS_Entity _MasterControlId;
        [Association(@"CDS_GLX_GLX_AccountReferencesCDS_SYS_SYS_Entity3")]
        public CDS_SYS_SYS_Entity MasterControlId
        {
            get { return _MasterControlId; }
            set { SetPropertyValue<CDS_SYS_SYS_Entity>("MasterControlId", ref _MasterControlId, value); }
        }
        string _BalanceGroup;
        [Size(10)]
        public string BalanceGroup
        {
            get { return _BalanceGroup; }
            set { SetPropertyValue<string>("BalanceGroup", ref _BalanceGroup, value); }
        }
    }

}