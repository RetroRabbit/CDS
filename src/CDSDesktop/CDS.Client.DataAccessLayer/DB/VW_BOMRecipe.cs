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
    
    public partial class VW_BOMRecipe
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal QuantityResult { get; set; }
        public Nullable<decimal> Building { get; set; }
        public Nullable<decimal> UnBuilding { get; set; }
        public bool Archived { get; set; }
        public string CreatedBy { get; set; }
    }
}