using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UserDesigner;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public class WizardCommandHandler : ICommandHandler
    {
        XRDesignPanel panel;

        public WizardCommandHandler(XRDesignPanel panel)
        {
            this.panel = panel;
        }

        public virtual bool CanHandleCommand(ReportCommand command)
        {
            return command == ReportCommand.NewReportWizard || command == ReportCommand.AddNewDataSource || command == ReportCommand.VerbReportWizard;
        }

        public virtual void HandleCommand(ReportCommand command, object[] args, ref bool handled)
        {
            if (!CanHandleCommand(command))
                return;



            switch (command)
            {
                case ReportCommand.AddNewDataSource:
                    DataWizard dataWizard = new DataWizard(panel.Report);
                    dataWizard.Run();
                    break;
                default:
                    CustomWizard customWizard = new CustomWizard(panel.Report);
                    customWizard.Run();

                    break;
            }

            handled = true;
        }

        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.NewReportWizard || command == ReportCommand.AddNewDataSource || command == ReportCommand.VerbReportWizard);
            return !useNextHandler;// command == ReportCommand.NewReportWizard || command == ReportCommand.AddNewDataSource || command == ReportCommand.VerbReportWizard;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {
            if (!CanHandleCommand(command))
                return;

            switch (command)
            {
                case ReportCommand.AddNewDataSource:
                    DataWizard dataWizard = new DataWizard(panel.Report);
                    dataWizard.Run();
                    break;
                default:
                    //CustomWizard customWizard = new CustomWizard(panel.Report);
                    //customWizard.Run();
                    panel.ExecCommand(ReportCommand.NewReportWizard);               
                    break;
            }
        }

    }
}
