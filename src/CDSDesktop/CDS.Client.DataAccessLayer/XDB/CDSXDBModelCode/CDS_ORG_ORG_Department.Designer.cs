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

    [Persistent(@"CDS_ORG.ORG_Department")]
    public partial class CDS_ORG_ORG_Department : XPLiteObject
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
        string _Note;
        public string Note
        {
            get { return _Note; }
            set { SetPropertyValue<string>("Note", ref _Note, value); }
        }
        [Association(@"CDS_ORG_ORG_ContactReferencesCDS_ORG_ORG_Department", typeof(CDS_ORG_ORG_Contact))]
        public XPCollection<CDS_ORG_ORG_Contact> CDS_ORG_ORG_Contacts { get { return GetCollection<CDS_ORG_ORG_Contact>("CDS_ORG_ORG_Contacts"); } }
    }

}
