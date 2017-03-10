using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.Design;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public class WizPageTablesCustom : WizPageTables
    {
        private XtraReportWizardBase standardWizard;

        public WizPageTablesCustom(XRWizardRunnerBase runner)
            : base(runner)
        {
            standardWizard = (NewStandardReportWizard)runner.Wizard;
        }

        protected override bool OnSetActive()
        {
            WizardHelper.LastDataSourceWizardType = "WizPageTables";

            return base.OnSetActive();
        }

        protected override string OnWizardNext()
        {
            base.OnWizardNext();

            return "WizPageChooseFields";
        }
    }
}
