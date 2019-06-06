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
    
    public partial class VW_StockTakeVariance
    {
        public long Id { get; set; }
        public long StockTakeId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> OnHand { get; set; }
        public decimal UnitAverage { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string LocationMain { get; set; }
        public string LocationSecondary { get; set; }
        public string StockType { get; set; }
        public Nullable<decimal> QuantityCount1 { get; set; }
        public Nullable<decimal> QuantityCount2 { get; set; }
        public Nullable<decimal> VarianceCount1 { get; set; }
        public Nullable<decimal> VarianceCount2 { get; set; }
        public Nullable<decimal> TotalValue { get; set; }
        public Nullable<decimal> VarianceTotal { get; set; }
    }
}