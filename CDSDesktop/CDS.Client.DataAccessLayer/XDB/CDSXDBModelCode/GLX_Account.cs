using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_GLX.GLX_Account")]
    public partial class GLX_Account
    {
        public GLX_Account(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("EntityId.Archived")]
        public Boolean Archived
        {
            get { return Convert.ToBoolean(EvaluateAlias("Archived")); }
        }

        [PersistentAlias("EntityId.Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }
         
        bool printStatement;
        [NonPersistent]
        public bool PrintStatement
        {
            get
            {
                return printStatement;
            }
            set
            {
                printStatement = value;
            }
        }

        bool emailStatement;
        [NonPersistent]
        public bool EmailStatement
        {
            get
            {
                return emailStatement;
            }
            set
            {
                emailStatement = value;
            }
        }
    }

}
