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

    [Persistent(@"CDS_CAT.CAT_ItemData")]
    public partial class CDS_CAT_CAT_ItemData : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CDS_CAT_CAT_Item _ItemId;
        [Association(@"CDS_CAT_CAT_ItemDataReferencesCDS_CAT_CAT_Item")]
        public CDS_CAT_CAT_Item ItemId
        {
            get { return _ItemId; }
            set { SetPropertyValue<CDS_CAT_CAT_Item>("ItemId", ref _ItemId, value); }
        }
        CDS_CAT_CAT_Item _ParentItemId;
        [Association(@"CDS_CAT_CAT_ItemDataReferencesCDS_CAT_CAT_Item1")]
        public CDS_CAT_CAT_Item ParentItemId
        {
            get { return _ParentItemId; }
            set { SetPropertyValue<CDS_CAT_CAT_Item>("ParentItemId", ref _ParentItemId, value); }
        }
        CDS_CAT_CAT_Category _CategoryId;
        [Association(@"CDS_CAT_CAT_ItemDataReferencesCDS_CAT_CAT_Category")]
        public CDS_CAT_CAT_Category CategoryId
        {
            get { return _CategoryId; }
            set { SetPropertyValue<CDS_CAT_CAT_Category>("CategoryId", ref _CategoryId, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_CAT_CAT_ItemDataReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
    }

}
