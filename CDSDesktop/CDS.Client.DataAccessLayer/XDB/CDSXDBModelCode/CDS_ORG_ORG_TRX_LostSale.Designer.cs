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

    [Persistent(@"CDS_ORG.ORG_TRX_LostSale")]
    public partial class CDS_ORG_ORG_TRX_LostSale : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CDS_ORG_ORG_Company _CompanyId;
        [Association(@"CDS_ORG_ORG_TRX_LostSaleReferencesCDS_ORG_ORG_Company")]
        public CDS_ORG_ORG_Company CompanyId
        {
            get { return _CompanyId; }
            set { SetPropertyValue<CDS_ORG_ORG_Company>("CompanyId", ref _CompanyId, value); }
        }
        string _ShortName;
        [Size(50)]
        public string ShortName
        {
            get { return _ShortName; }
            set { SetPropertyValue<string>("ShortName", ref _ShortName, value); }
        }
        string _Description;
        [Size(1000)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>("Description", ref _Description, value); }
        }
        string _Reason;
        [Size(1000)]
        public string Reason
        {
            get { return _Reason; }
            set { SetPropertyValue<string>("Reason", ref _Reason, value); }
        }
        decimal _Quantity;
        public decimal Quantity
        {
            get { return _Quantity; }
            set { SetPropertyValue<decimal>("Quantity", ref _Quantity, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_ORG_ORG_TRX_LostSaleReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
    }

}
