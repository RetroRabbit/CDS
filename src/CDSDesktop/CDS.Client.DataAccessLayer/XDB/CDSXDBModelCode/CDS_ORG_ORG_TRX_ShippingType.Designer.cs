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

    [Persistent(@"CDS_ORG.ORG_TRX_ShippingType")]
    public partial class CDS_ORG_ORG_TRX_ShippingType : XPLiteObject
    {
        byte _Id;
        [Key]
        public byte Id
        {
            get { return _Id; }
            set { SetPropertyValue<byte>("Id", ref _Id, value); }
        }
        string _Name;
        [Size(20)]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>("Name", ref _Name, value); }
        }
        [Association(@"CDS_ORG_ORG_TRX_HeaderReferencesCDS_ORG_ORG_TRX_ShippingType", typeof(CDS_ORG_ORG_TRX_Header))]
        public XPCollection<CDS_ORG_ORG_TRX_Header> CDS_ORG_ORG_TRX_Headers { get { return GetCollection<CDS_ORG_ORG_TRX_Header>("CDS_ORG_ORG_TRX_Headers"); } }
    }

}
