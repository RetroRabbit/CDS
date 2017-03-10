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

    [Persistent(@"CDS_SYS.SYS_Notification")]
    public partial class CDS_SYS_SYS_Notification : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CDS_SYS_SYS_Person _PersonId;
        [Association(@"CDS_SYS_SYS_NotificationReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person PersonId
        {
            get { return _PersonId; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("PersonId", ref _PersonId, value); }
        }
        string _Title;
        [Size(200)]
        public string Title
        {
            get { return _Title; }
            set { SetPropertyValue<string>("Title", ref _Title, value); }
        }
        string _Description;
        [Size(500)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>("Description", ref _Description, value); }
        }
        bool _Read;
        public bool Read
        {
            get { return _Read; }
            set { SetPropertyValue<bool>("Read", ref _Read, value); }
        }
    }

}
