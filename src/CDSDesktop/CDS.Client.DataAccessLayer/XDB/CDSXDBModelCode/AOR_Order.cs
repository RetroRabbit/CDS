using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_AOR.AOR_Order")]
    public partial class AOR_Order
    {
        public AOR_Order(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        [PersistentAlias("AOR_OrderLines.Sum(Total)")]
        public decimal Total
        {
            get { return Convert.ToDecimal(EvaluateAlias("Total")); }
        }
    }

}
