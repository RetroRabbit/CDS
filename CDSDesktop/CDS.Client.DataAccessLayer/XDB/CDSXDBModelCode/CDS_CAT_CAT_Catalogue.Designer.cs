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

    [Persistent(@"CDS_CAT.CAT_Catalogue")]
    public partial class CDS_CAT_CAT_Catalogue : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        string _Name;
        [Size(50)]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>("Name", ref _Name, value); }
        }
        string _Publisher;
        [Size(50)]
        public string Publisher
        {
            get { return _Publisher; }
            set { SetPropertyValue<string>("Publisher", ref _Publisher, value); }
        }
        string _Revision;
        [Size(50)]
        public string Revision
        {
            get { return _Revision; }
            set { SetPropertyValue<string>("Revision", ref _Revision, value); }
        }
        string _Description;
        [Size(1000)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>("Description", ref _Description, value); }
        }
        string _ImageDestination;
        [Size(200)]
        public string ImageDestination
        {
            get { return _ImageDestination; }
            set { SetPropertyValue<string>("ImageDestination", ref _ImageDestination, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_CAT_CAT_CatalogueReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        [Association(@"CDS_CAT_CAT_CategoryReferencesCDS_CAT_CAT_Catalogue", typeof(CDS_CAT_CAT_Category))]
        public XPCollection<CDS_CAT_CAT_Category> CDS_CAT_CAT_Categorys { get { return GetCollection<CDS_CAT_CAT_Category>("CDS_CAT_CAT_Categorys"); } }
    }

}