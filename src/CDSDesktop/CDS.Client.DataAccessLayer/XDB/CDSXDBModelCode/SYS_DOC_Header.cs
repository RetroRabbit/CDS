using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_DOC_Header")]
    public partial class SYS_DOC_Header
    {
        public SYS_DOC_Header(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        [PersistentAlias("SYS_DOC_Lines[].Sum(Total)")]
        public Decimal TotalExcl
        {
            get { return Convert.ToDecimal(EvaluateAlias("TotalExcl")); }
        }

        [PersistentAlias("SYS_DOC_Lines[].Sum(TotalTax)")]
        public Decimal TotalTax
        {
            get { return Convert.ToDecimal(EvaluateAlias("TotalTax")); }
        }

        [PersistentAlias("TotalTax + TotalExcl")]
        public Decimal Total
        {
            get { return Convert.ToDecimal(EvaluateAlias("Total")); }
        }

        [PersistentAlias("ORG_TRX_Headers[].Single()")]
        public ORG_TRX_Header ORG_TRX_Header
        {
            get { return (ORG_TRX_Header)EvaluateAlias("ORG_TRX_Header"); }
        }

        [NonPersistent]
        public bool HasOutstandingLines
        {
            get
            {
                return Session.Query<SYS_DOC_Line>().Where(n => n.HeaderId == this)
                    .GroupBy(n => new { n.ItemId, n.DiscountPercentage, n.Description, n.Amount })
                    .Select(l => new { Key = l.Key, Sum = l.Sum(n => n.Quantity) })
                    .Where(n => n.Sum != 0).Count() > 0;
            }
        }
    }

}
