using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Reporting.Report
{
    public class ReportEmailer
    {
        public static void EmailtoPDF(Essential.BaseForm.ReportTemplateType reportTemplate, long id, string filename, BL.DataContext dataContext)
        {
            string reportName = null;

                    //rptReport = BL.RPT.RPT_Report.LoadByName("Sales Document Template", DataContext);
                    //
                    //rptReport = BL.RPT.RPT_Report.LoadByName("Picking Slip Document Template", DataContext);
                    //
                    //rptReport = BL.RPT.RPT_Report.LoadByName("Purchase Document Template", DataContext);
                    //
                    //rptReport = BL.RPT.RPT_Report.LoadByName("Transfer Document Template", DataContext);
                    //
                    //rptReport = BL.RPT.RPT_Report.LoadByName("Stock Document Template", DataContext);
                    //
                    //rptReport = BL.RPT.RPT_Report.LoadByName("Work Document Template", DataContext);
                    //
                    //rptReport = BL.RPT.RPT_Report.LoadByName("Work Document Template", DataContext);

            switch (reportTemplate)
            {
                case Essential.BaseForm.ReportTemplateType.None:
                    reportName = "";
                    break;
                case Essential.BaseForm.ReportTemplateType.SalesDocument:
                    reportName = "Sales Document Template";
                    break;
                case Essential.BaseForm.ReportTemplateType.PurchaseDocument:
                    reportName = "Purchase Document Template";
                    break;
                case Essential.BaseForm.ReportTemplateType.PickerDocument:
                    reportName = "Picking Slip Document Template";
                    break;
                case Essential.BaseForm.ReportTemplateType.StockDocument:
                    reportName = "Stock Document Template";
                    break;
                case Essential.BaseForm.ReportTemplateType.WorkDocument:
                    reportName = "Work Document Template";
                    break;
                case Essential.BaseForm.ReportTemplateType.TransferDocument:
                    reportName = "Transfer Document Template";
                    break;
            }

            DB.RPT_Report rptReport = BL.RPT.RPT_Report.LoadByName(reportName, dataContext);
            
            if (rptReport == null)
                return;

            System.IO.Stream xmlstream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(rptReport.Data));

            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
            report.LoadLayoutFromXml(xmlstream);

            if (report.DataSource is DevExpress.DataAccess.Sql.SqlDataSource)
                ((DevExpress.DataAccess.Sql.SqlDataSource)(report.DataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
            else if (report.DataSource is DevExpress.DataAccess.EntityFramework.EFDataSource)
                ((DevExpress.DataAccess.EntityFramework.EFDataSource)(report.DataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString;
            else
                throw new Exception("Data Source type not implemented in reports");

            //adp.SelectCommand.Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
            DevExpress.XtraReports.Parameters.ParameterCollection Parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();
            Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "DocumentId", Value = id });
            if (Parameters.Count != 0)
            {
                foreach (var extparam in Parameters)
                {
                    foreach (var param in report.Parameters)
                    {
                        if (extparam.Name == param.Name)
                        {
                            param.Value = extparam.Value;
                            break;
                        }
                    }
                }
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            report.ExportToPdf(ms);
            CDS.Client.Desktop.Essential.UTL.SendMailForm mail = new CDS.Client.Desktop.Essential.UTL.SendMailForm();
            mail.AttachFile(ms, filename);
            mail.ShowDialog();

        }
    }
}
