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

    public partial class SYS_Surcharge : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        SYS_Entity _EntityId;
        [Association(@"SYS_SurchargeReferencesSYS_Entity")]
        public SYS_Entity EntityId
        {
            get { return _EntityId; }
            set { SetPropertyValue<SYS_Entity>("EntityId", ref _EntityId, value); }
        }
        SYS_Entity _AccountId;
        [Association(@"SYS_SurchargeReferencesSYS_Entity1")]
        public SYS_Entity AccountId
        {
            get { return _AccountId; }
            set { SetPropertyValue<SYS_Entity>("AccountId", ref _AccountId, value); }
        }
        decimal _Amount;
        public decimal Amount
        {
            get { return _Amount; }
            set { SetPropertyValue<decimal>("Amount", ref _Amount, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        SYS_Person _CreatedBy;
        [Association(@"SYS_SurchargeReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
    }

}