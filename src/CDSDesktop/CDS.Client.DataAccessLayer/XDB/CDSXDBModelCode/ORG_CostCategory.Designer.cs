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

    public partial class ORG_CostCategory : XPLiteObject
    {
        byte _Id;
        [Key]
        public byte Id
        {
            get { return _Id; }
            set { SetPropertyValue<byte>("Id", ref _Id, value); }
        }
        string _Name;
        [Size(50)]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>("Name", ref _Name, value); }
        }
        [Association(@"ORG_CompanyReferencesORG_CostCategory", typeof(ORG_Company))]
        public XPCollection<ORG_Company> ORG_Companys { get { return GetCollection<ORG_Company>("ORG_Companys"); } }
    }

}
