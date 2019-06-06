using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.Design;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public partial class WizPageWelcomeCustom : WizPageWelcome
    {
        private XtraReportWizardBase standardWizard;

        public WizPageWelcomeCustom(XRWizardRunnerBase runner)
            : base(runner)
        {
            standardWizard = (NewStandardReportWizard)runner.Wizard;
        }
    }
}
