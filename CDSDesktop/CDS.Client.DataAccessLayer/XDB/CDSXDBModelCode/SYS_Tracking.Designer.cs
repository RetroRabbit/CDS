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

    public partial class SYS_Tracking : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        string _Initiator;
        [Size(1000)]
        public string Initiator
        {
            get { return _Initiator; }
            set { SetPropertyValue<string>("Initiator", ref _Initiator, value); }
        }
        [Association(@"GLX_HeaderReferencesSYS_Tracking", typeof(GLX_Header))]
        public XPCollection<GLX_Header> GLX_Headers { get { return GetCollection<GLX_Header>("GLX_Headers"); } }
        [Association(@"SYS_DOC_HeaderReferencesSYS_Tracking", typeof(SYS_DOC_Header))]
        public XPCollection<SYS_DOC_Header> SYS_DOC_Headers { get { return GetCollection<SYS_DOC_Header>("SYS_DOC_Headers"); } }
    }

}