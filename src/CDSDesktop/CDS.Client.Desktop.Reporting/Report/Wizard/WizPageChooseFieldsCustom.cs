using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.Design;
using DevExpress.Utils;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public class WizPageChooseFieldsCustom : WizPageChooseFields
    {
        bool nextAvailable = true;

        public WizPageChooseFieldsCustom(XRWizardRunnerBase runner)
            : base(runner)
        {
            nextAvailable = !(runner is DataWizard);
        }

        protected override bool OnSetActive()
        {
            base.OnSetActive();

            if (nextAvailable)
                Wizard.WizardButtons = WizardButton.Back | WizardButton.Next | WizardButton.DisabledFinish;
            else
                Wizard.WizardButtons = WizardButton.Back | WizardButton.Finish;

            return true;
        }

        protected override string OnWizardBack()
        {
            base.OnWizardBack();

            return WizardHelper.LastDataSourceWizardType;
        }

    }
}
