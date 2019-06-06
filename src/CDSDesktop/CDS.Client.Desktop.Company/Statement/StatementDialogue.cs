using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Company.Statements
{
    public partial class StatementDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public StatementDialogue()
        {
            InitializeComponent();
        }

        public Int64 Period
        {
            get
            {
                return Convert.ToInt64(ddlPeriod.EditValue);
            }
        }

        private void InstantFeedbackSourcePeriod_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Period.Where(n=>n.StartDate < DateTime.Now);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
