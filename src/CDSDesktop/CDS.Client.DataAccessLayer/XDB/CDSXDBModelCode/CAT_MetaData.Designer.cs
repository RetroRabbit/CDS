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

    public partial class CAT_MetaData : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CAT_Meta _MetaId;
        [Association(@"CAT_MetaDataReferencesCAT_Meta")]
        public CAT_Meta MetaId
        {
            get { return _MetaId; }
            set { SetPropertyValue<CAT_Meta>("MetaId", ref _MetaId, value); }
        }
        CAT_Item _ItemId;
        [Association(@"CAT_MetaDataReferencesCAT_Item")]
        public CAT_Item ItemId
        {
            get { return _ItemId; }
            set { SetPropertyValue<CAT_Item>("ItemId", ref _ItemId, value); }
        }
        CAT_Category _CategoryId;
        [Association(@"CAT_MetaDataReferencesCAT_Category")]
        public CAT_Category CategoryId
        {
            get { return _CategoryId; }
            set { SetPropertyValue<CAT_Category>("CategoryId", ref _CategoryId, value); }
        }
        string _Data;
        [Size(4000)]
        public string Data
        {
            get { return _Data; }
            set { SetPropertyValue<string>("Data", ref _Data, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        SYS_Person _CreatedBy;
        [Association(@"CAT_MetaDataReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
    }

}
