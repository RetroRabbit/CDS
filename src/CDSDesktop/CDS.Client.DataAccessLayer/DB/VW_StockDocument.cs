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
    
    public partial class VW_StockDocument
    {
        public long Id { get; set; }
        public Nullable<byte> TypeId { get; set; }
        public long TrackId { get; set; }
        public string TransactionType { get; set; }
        public Nullable<long> DocumentNumber { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<decimal> TotalExcl { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> TotalTax { get; set; }
    }
}
