using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDS.Client.Desktop.Company.Statements;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Company.Supplier
{
    public partial class SupplierForm : BaseCompanyForm
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        public SupplierForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSUREED);
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSURE01))
                btnRemittance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            if (IsNew)
            {
                btnRemittance.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void btnRemittance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (StatementDialogue dlg = new StatementDialogue())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DevExpress.XtraReports.Parameters.ParameterCollection parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();
                    parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "Period", Value = dlg.Period });
                    parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "Account", Value = BL.SYS.SYS_Entity.LoadCompanyDebtorEntity(CompanyCode, DataContext).Id });
                    parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "Site_", Value = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSite.EntityId });

                    Int64 reportId = DataContext.ReadonlyContext.VW_Report.FirstOrDefault(n => n.Name == "Account Statement").Id;

                    ShowReport(reportId, parameters);
                }
            }
        }
    }
}
