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
    
    public partial class VW_PaymentItems
    {
        public string Type { get; set; }
        public long AccountId { get; set; }
        public string Title { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Internal { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<long> PeriodId { get; set; }
        public string Period { get; set; }
        public Nullable<byte> AgingId { get; set; }
        public string Aging { get; set; }
        public Nullable<long> TrackNumber { get; set; }
        public string Name { get; set; }
        public string CodeSub { get; set; }
        public string CodeMain { get; set; }
        public Nullable<long> LineId { get; set; }
        public Nullable<long> HeaderId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public long SiteId { get; set; }
    }
}
