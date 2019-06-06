// Developer Express Code Central Example:
// How to customize a Report Wizard
// 
// This example demonstrates how to create a Custom Report Wizard with the
// capability to define the SQL query, based on which the resulting report's data
// source will be generated (see the corresponding suggestion:
// http://www.devexpress.com/scid=AS4685).
// 
// In order to run you custom wizard in
// the corresponding handler, override the ReportCommand.NewReportWizard,
// ReportCommand.AddNewDataSource, and ReportCommand.VerbReportWizard commands (as
// described in this documentation article: How to: Override Commands in the
// End-User Designer (Custom Saving)
// (ms-help://DevExpress.NETv9.1/DevExpress.XtraReports/CustomDocument2211.htm). A
// Custom Report Wizard inherits from the XRWizardRunnerBase class, custom wizard
// pages are inherited from the InteriorWizardPage class.
// 
// Note that for most
// custom wizard pages, you should override the InteriorWizardPage.OnWizardBack()
// and InteriorWizardPage.OnWizardNext() virtual methods, to provide proper wizard
// navigation logic.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E1538

using DevExpress.Utils;
using DevExpress.XtraReports.Design;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public partial class WizPageDataOption : DevExpress.Utils.InteriorWizardPage
    {
        XtraReportWizardBase standardWizard;

        public WizPageDataOption(XRWizardRunnerBase runner)
        {
            this.standardWizard = runner.Wizard;

            InitializeComponent();
        }

        protected override bool OnSetActive()
        {
            Wizard.WizardButtons = WizardButton.Back | WizardButton.Next | WizardButton.DisabledFinish;

            return true;
        }

        protected override string OnWizardNext()
        {
            if (radioGroup1.SelectedIndex != 0)
            {
                return "WizPageTables";
            }
            else
            {
                return "WizPageQuery";
            }
        }
    }
}