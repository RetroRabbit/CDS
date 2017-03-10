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

    [Persistent(@"CDS_GLX.GLX_BulkEntryRule")]
    public partial class CDS_GLX_GLX_BulkEntryRule : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>("Name", ref _Name, value); }
        }
        CDS_SYS_SYS_Entity _EntityId;
        [Association(@"CDS_GLX_GLX_BulkEntryRuleReferencesCDS_SYS_SYS_Entity")]
        public CDS_SYS_SYS_Entity EntityId
        {
            get { return _EntityId; }
            set { SetPropertyValue<CDS_SYS_SYS_Entity>("EntityId", ref _EntityId, value); }
        }
        CDS_SYS_SYS_Entity _EntityContraId;
        [Association(@"CDS_GLX_GLX_BulkEntryRuleReferencesCDS_SYS_SYS_Entity1")]
        public CDS_SYS_SYS_Entity EntityContraId
        {
            get { return _EntityContraId; }
            set { SetPropertyValue<CDS_SYS_SYS_Entity>("EntityContraId", ref _EntityContraId, value); }
        }
        CDS_GLX_GLX_Tax _TaxId;
        [Association(@"CDS_GLX_GLX_BulkEntryRuleReferencesCDS_GLX_GLX_Tax")]
        public CDS_GLX_GLX_Tax TaxId
        {
            get { return _TaxId; }
            set { SetPropertyValue<CDS_GLX_GLX_Tax>("TaxId", ref _TaxId, value); }
        }
        string _EntryRule;
        [Size(200)]
        public string EntryRule
        {
            get { return _EntryRule; }
            set { SetPropertyValue<string>("EntryRule", ref _EntryRule, value); }
        }
        char _EntryAction;
        public char EntryAction
        {
            get { return _EntryAction; }
            set { SetPropertyValue<char>("EntryAction", ref _EntryAction, value); }
        }
        short _Priority;
        public short Priority
        {
            get { return _Priority; }
            set { SetPropertyValue<short>("Priority", ref _Priority, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_GLX_GLX_BulkEntryRuleReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
    }

}
