using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_GLX.GLX_Recon")]
    public partial class GLX_Recon
    {
        public GLX_Recon(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("IIF(GLX_Lines[].Exists,GLX_Lines[].Sum(Amount),0)")]
        public Decimal Amount
        {
            get { return Convert.ToDecimal(EvaluateAlias("Amount")); }
        }

        [PersistentAlias("StartAmount-EndAmount+Amount")]
        public Decimal Difference
        {
            get { return Convert.ToDecimal(EvaluateAlias("Difference")); }
        }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        [PersistentAlias("IIF(GLX_Lines[].Exists,GLX_Lines[].Min(EntityId.Title),'')")]
        public string Account
        {
            get { return Convert.ToString(EvaluateAlias("Account")); }
        }
    }

}
