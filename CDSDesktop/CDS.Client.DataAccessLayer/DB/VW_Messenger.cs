//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDS.Client.DataAccessLayer.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_Messenger
    {
        public long Id { get; set; }
        public Nullable<long> FromId { get; set; }
        public Nullable<long> ToId { get; set; }
        public string FromFullname { get; set; }
        public string ToFullname { get; set; }
        public Nullable<bool> Sent { get; set; }
        public Nullable<bool> Received { get; set; }
        public Nullable<System.DateTime> SentOn { get; set; }
        public Nullable<System.DateTime> ReceivedOn { get; set; }
        public string Message { get; set; }
    }
}