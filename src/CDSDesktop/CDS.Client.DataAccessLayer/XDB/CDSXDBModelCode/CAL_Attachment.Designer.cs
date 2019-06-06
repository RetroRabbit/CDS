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

    public partial class CAL_Attachment : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CAL_Calendar _CalendarId;
        [Association(@"CAL_AttachmentReferencesCAL_Calendar")]
        public CAL_Calendar CalendarId
        {
            get { return _CalendarId; }
            set { SetPropertyValue<CAL_Calendar>("CalendarId", ref _CalendarId, value); }
        }
        SYS_DOC_Header _DocumentId;
        [Association(@"CAL_AttachmentReferencesSYS_DOC_Header")]
        public SYS_DOC_Header DocumentId
        {
            get { return _DocumentId; }
            set { SetPropertyValue<SYS_DOC_Header>("DocumentId", ref _DocumentId, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        SYS_Person _CreatedBy;
        [Association(@"CAL_AttachmentReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
    }

}
