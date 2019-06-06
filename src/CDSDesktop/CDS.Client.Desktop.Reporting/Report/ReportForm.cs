using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Reporting.Report
{
    public partial class ReportForm : CDS.Client.Desktop.Essential.BaseForm
    {
        private const string ExtensionName = "Custom";
        public bool WebServiceCall = false;
        public DevExpress.XtraPrinting.Preview.DocumentViewer DvReport { get { return dvReport; } }
        public DevExpress.XtraReports.Parameters.ParameterCollection Parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();
        public MemoryStream ReportMemoryStream = new MemoryStream();

        public ReportForm()
        {
            InitializeComponent();
        }

        public class ExportToExcel : DevExpress.XtraPrinting.ICommandHandler
        {
            public bool CanHandleCommand(PrintingSystemCommand command, IPrintControl printControl)
            {
                return (command == PrintingSystemCommand.ExportXls || command == PrintingSystemCommand.ExportXlsx);
            }

            public void HandleCommand(PrintingSystemCommand command, object[] args, IPrintControl printControl, ref bool handled)
            {
                if (!CanHandleCommand(command, printControl)) return;

                //handled = true;
            }
        }

        public override void OpenRecord(Int64 Id)
        {
            try
            {
                if (!WebServiceCall)
                {
                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        base.OpenRecord(Id);

                        LoadReport(Id);
                    }
                }
                //Used when generating reports from web
                //base.OpenRecord(Id); not declared because it has windows forms specific code declared
                else
                {
                    LoadReport(Id);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void LoadReport(Int64 Id)
        {
            try
            {

                DB.RPT_Report rptReport = BL.RPT.RPT_Report.Load(Id, DataContext);
                this.Text = rptReport.Name;
                Stream xmlstream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(rptReport.Data));
                
                //XtraReport report = new XtraReport();
                CDS.Client.Desktop.Reporting.Report.Design.Templates.BaseReportTemplate report = new CDS.Client.Desktop.Reporting.Report.Design.Templates.BaseReportTemplate();
                report.LoadLayoutFromXml(xmlstream);
                //report.CurrentPrintControl = PrintControl;
                //SqlDataAdapter adp = (SqlDataAdapter)report.DataAdapter;

                foreach (object oObject in report.ObjectStorage)
                {
                    if (oObject is DevExpress.XtraReports.Parameters.LookUpSettings)
                    {
                        object dataSource = (oObject as DevExpress.XtraReports.Parameters.LookUpSettings).DataSource;

                        if (dataSource is DevExpress.DataAccess.Sql.SqlDataSource)
                            ((DevExpress.DataAccess.Sql.SqlDataSource)(dataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
                        else if (dataSource is DevExpress.DataAccess.EntityFramework.EFDataSource)
                            ((DevExpress.DataAccess.EntityFramework.EFDataSource)(dataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString;
                        else
                            throw new Exception("Data Source type not implemented in reports");
                    }
                }


               

                //adp.SelectCommand.Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
                dvReport.PrintingSystem = report.PrintingSystem;
                if (Parameters.Count != 0)
                {
                    report.RequestParameters = false;
                    
                    foreach (var extparam in Parameters)
                    { 
                        foreach (var param in report.Parameters)
                        {
                            if (extparam.Name == param.Name)
                            {
                                param.Visible = false;
                                param.Value = extparam.Value;
                                break;
                            }
                        } 
                    }
                }
             
              
                dvReport.DocumentSource = report;
                report.CreateDocument(true);                
                //new DevExpress.XtraReports.UI.ReportPrintTool(report).ShowPreview();
                report.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, new object[] { true });

                //printRibbonController1.PrintControl.PrintingSystem.AddCommandHandler(new ExportToExcel());
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        } 
        
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private void CloseAfterServiceCall(object sender, EventArgs e)
        {
            if (WebServiceCall)
            { 
                DvReport.PrintingSystem.ExportToPdf(ReportMemoryStream);
                DvReport.PrintingSystem.ExportToPdf(@"c:\Accounts_report.pdf");
                myTimer.Stop();
                this.Close();
            }
        }

        private void ReportForm_Shown(object sender, EventArgs e)
        {
            myTimer.Interval = 2000;
            myTimer.Tick += CloseAfterServiceCall;
            myTimer.Start();

            //this.BeginInvoke(new Action(() => CloseAfterServiceCall()));
        } 
    }
}
