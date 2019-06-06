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

    public partial class CAT_Catalogue : XPLiteObject
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
        SYS_Person _CreatedBy;
        [Association(@"CAT_CatalogueReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        [Association(@"CAT_CategoryReferencesCAT_Catalogue", typeof(CAT_Category))]
        public XPCollection<CAT_Category> CAT_Categorys { get { return GetCollection<CAT_Category>("CAT_Categorys"); } }
    }

}