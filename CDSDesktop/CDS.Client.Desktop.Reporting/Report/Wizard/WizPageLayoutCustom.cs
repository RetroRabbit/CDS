using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.Design;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public partial class WizPageLayoutCustom : DevExpress.XtraReports.Design.WizPageGroupedLayout
    {
        public WizPageLayoutCustom(XRWizardRunnerBase runner)
            :base(runner)
        {
            InitializeComponent();
        }
    }
}
