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

    [Persistent(@"CDS_SYS.SYS_Address")]
    public partial class CDS_SYS_SYS_Address : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CDS_SYS_SYS_Type _TypeId;
        [Association(@"CDS_SYS_SYS_AddressReferencesCDS_SYS_SYS_Type")]
        public CDS_SYS_SYS_Type TypeId
        {
            get { return _TypeId; }
            set { SetPropertyValue<CDS_SYS_SYS_Type>("TypeId", ref _TypeId, value); }
        }
        string _Line1;
        [Size(50)]
        public string Line1
        {
            get { return _Line1; }
            set { SetPropertyValue<string>("Line1", ref _Line1, value); }
        }
        string _Line2;
        [Size(50)]
        public string Line2
        {
            get { return _Line2; }
            set { SetPropertyValue<string>("Line2", ref _Line2, value); }
        }
        string _Line3;
        [Size(50)]
        public string Line3
        {
            get { return _Line3; }
            set { SetPropertyValue<string>("Line3", ref _Line3, value); }
        }
        string _Line4;
        [Size(50)]
        public string Line4
        {
            get { return _Line4; }
            set { SetPropertyValue<string>("Line4", ref _Line4, value); }
        }
        string _Code;
        [Size(10)]
        public string Code
        {
            get { return _Code; }
            set { SetPropertyValue<string>("Code", ref _Code, value); }
        }
        string _Title;
        [Size(163)]
        public string Title
        {
            get { return _Title; }
            set { SetPropertyValue<string>("Title", ref _Title, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_SYS_SYS_AddressReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        [Association(@"CDS_SYS_SYS_SiteReferencesCDS_SYS_SYS_Address", typeof(CDS_SYS_SYS_Site))]
        public XPCollection<CDS_SYS_SYS_Site> CDS_SYS_SYS_Sites { get { return GetCollection<CDS_SYS_SYS_Site>("CDS_SYS_SYS_Sites"); } }
        [Association(@"CDS_SYS_SYS_SiteReferencesCDS_SYS_SYS_Address1", typeof(CDS_SYS_SYS_Site))]
        public XPCollection<CDS_SYS_SYS_Site> CDS_SYS_SYS_Sites1 { get { return GetCollection<CDS_SYS_SYS_Site>("CDS_SYS_SYS_Sites1"); } }
        [Association(@"CDS_ORG_ORG_CompanyAddressReferencesCDS_SYS_SYS_Address", typeof(CDS_ORG_ORG_CompanyAddress))]
        public XPCollection<CDS_ORG_ORG_CompanyAddress> CDS_ORG_ORG_CompanyAddresss { get { return GetCollection<CDS_ORG_ORG_CompanyAddress>("CDS_ORG_ORG_CompanyAddresss"); } }
    }

}
