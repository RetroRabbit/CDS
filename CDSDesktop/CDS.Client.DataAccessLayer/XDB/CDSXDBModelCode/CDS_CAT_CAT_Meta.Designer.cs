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

    [Persistent(@"CDS_CAT.CAT_Meta")]
    public partial class CDS_CAT_CAT_Meta : XPLiteObject
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
        string _Grouping;
        public string Grouping
        {
            get { return _Grouping; }
            set { SetPropertyValue<string>("Grouping", ref _Grouping, value); }
        }
        CDS_CAT_CAT_Category _CategoryId;
        [Association(@"CDS_CAT_CAT_MetaReferencesCDS_CAT_CAT_Category")]
        public CDS_CAT_CAT_Category CategoryId
        {
            get { return _CategoryId; }
            set { SetPropertyValue<CDS_CAT_CAT_Category>("CategoryId", ref _CategoryId, value); }
        }
        string _Type;
        public string Type
        {
            get { return _Type; }
            set { SetPropertyValue<string>("Type", ref _Type, value); }
        }
        bool _Grouped;
        public bool Grouped
        {
            get { return _Grouped; }
            set { SetPropertyValue<bool>("Grouped", ref _Grouped, value); }
        }
        int _SortOrder;
        public int SortOrder
        {
            get { return _SortOrder; }
            set { SetPropertyValue<int>("SortOrder", ref _SortOrder, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_CAT_CAT_MetaReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        [Association(@"CDS_CAT_CAT_MetaDataReferencesCDS_CAT_CAT_Meta", typeof(CDS_CAT_CAT_MetaData))]
        public XPCollection<CDS_CAT_CAT_MetaData> CDS_CAT_CAT_MetaDatas { get { return GetCollection<CDS_CAT_CAT_MetaData>("CDS_CAT_CAT_MetaDatas"); } }
    }

}