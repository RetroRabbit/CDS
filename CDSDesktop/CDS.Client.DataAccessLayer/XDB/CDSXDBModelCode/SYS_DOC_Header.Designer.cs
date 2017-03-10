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

    public partial class SYS_DOC_Header : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        SYS_Tracking _TrackId;
        [Association(@"SYS_DOC_HeaderReferencesSYS_Tracking")]
        public SYS_Tracking TrackId
        {
            get { return _TrackId; }
            set { SetPropertyValue<SYS_Tracking>("TrackId", ref _TrackId, value); }
        }
        SYS_DOC_Type _TypeId;
        [Association(@"SYS_DOC_HeaderReferencesSYS_DOC_Type")]
        public SYS_DOC_Type TypeId
        {
            get { return _TypeId; }
            set { SetPropertyValue<SYS_DOC_Type>("TypeId", ref _TypeId, value); }
        }
        long _DocumentNumber;
        public long DocumentNumber
        {
            get { return _DocumentNumber; }
            set { SetPropertyValue<long>("DocumentNumber", ref _DocumentNumber, value); }
        }
        string _Comment;
        [Size(1000)]
        public string Comment
        {
            get { return _Comment; }
            set { SetPropertyValue<string>("Comment", ref _Comment, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        SYS_Person _CreatedBy;
        [Association(@"SYS_DOC_HeaderReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        string _Title;
        [Size(8000)]
        public string Title
        {
            get { return _Title; }
            set { SetPropertyValue<string>("Title", ref _Title, value); }
        }
        SYS_Entity _SiteId;
        [Association(@"SYS_DOC_HeaderReferencesSYS_Entity")]
        public SYS_Entity SiteId
        {
            get { return _SiteId; }
            set { SetPropertyValue<SYS_Entity>("SiteId", ref _SiteId, value); }
        }
        [Association(@"CAL_AttachmentReferencesSYS_DOC_Header", typeof(CAL_Attachment))]
        public XPCollection<CAL_Attachment> CAL_Attachments { get { return GetCollection<CAL_Attachment>("CAL_Attachments"); } }
        [Association(@"CAL_CalendarReferencesSYS_DOC_Header", typeof(CAL_Calendar))]
        public XPCollection<CAL_Calendar> CAL_Calendars { get { return GetCollection<CAL_Calendar>("CAL_Calendars"); } }
        [Association(@"ITM_BOM_DocumentReferencesSYS_DOC_Header", typeof(ITM_BOM_Document))]
        public XPCollection<ITM_BOM_Document> ITM_BOM_Documents { get { return GetCollection<ITM_BOM_Document>("ITM_BOM_Documents"); } }
        [Association(@"ORG_TRX_HeaderReferencesSYS_DOC_Header", typeof(ORG_TRX_Header))]
        public XPCollection<ORG_TRX_Header> ORG_TRX_Headers { get { return GetCollection<ORG_TRX_Header>("ORG_TRX_Headers"); } }
        [Association(@"SYS_DOC_LineReferencesSYS_DOC_Header", typeof(SYS_DOC_Line))]
        public XPCollection<SYS_DOC_Line> SYS_DOC_Lines { get { return GetCollection<SYS_DOC_Line>("SYS_DOC_Lines"); } }
        [Association(@"JOB_HeaderReferencesSYS_DOC_Header", typeof(JOB_Header))]
        public XPCollection<JOB_Header> JOB_Headers { get { return GetCollection<JOB_Header>("JOB_Headers"); } }
    }

}