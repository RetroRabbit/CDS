using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_GLX.GLX_Statement")]
    public partial class GLX_Statement
    {
        public GLX_Statement(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            this.CreatedOn = DateTime.Now; //Convert.ToDateTime(Session.ExecuteScalar("SELECT GETDATE()"));
        }
    }

}
