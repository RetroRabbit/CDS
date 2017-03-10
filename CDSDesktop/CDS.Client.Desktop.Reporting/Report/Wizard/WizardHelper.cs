using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public class WizardHelper
    {
        private static string _lastDataSourceWizardType;

        public static string LastDataSourceWizardType
        {
            get { return WizardHelper._lastDataSourceWizardType; }
            set { WizardHelper._lastDataSourceWizardType = value; }
        }
    }
}
