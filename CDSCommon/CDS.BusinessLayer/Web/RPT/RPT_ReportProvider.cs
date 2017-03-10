using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace CDS.BusinessLayer.Web.RPT
{
    public static class RPT_ReportProvider
    {
        public static System.IO.MemoryStream DocumentPreview(string connectionString, Int64 documentId, Int64 reportId)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();

                DAL.Datamodel.RPT_Report rptReport = uow.Query<DAL.Datamodel.RPT_Report>().Where(r => r.Id == reportId).FirstOrDefault();

                System.IO.Stream xmlstream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(rptReport.Data));

                DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
                report.LoadLayoutFromXml(xmlstream);

                foreach (object oObject in report.ObjectStorage)
                {
                    if (oObject is DevExpress.XtraReports.Parameters.LookUpSettings)
                    {
                        object dataSource = (oObject as DevExpress.XtraReports.Parameters.LookUpSettings).DataSource;

                        if (dataSource is DevExpress.DataAccess.Sql.SqlDataSource)
                            ((DevExpress.DataAccess.Sql.SqlDataSource)(dataSource)).Connection.ConnectionString = connectionString;
                        else
                            throw new Exception("Data Source type not implemented in reports");
                    }
                }

                foreach (object oObject in report.ComponentStorage)
                {
                    if (oObject is DevExpress.DataAccess.Sql.SqlDataSource)
                    {
                        ((DevExpress.DataAccess.Sql.SqlDataSource)(oObject)).Connection.ConnectionString = connectionString;
                    }
                }

                DevExpress.XtraReports.Parameters.ParameterCollection Parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();

                Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "DocumentId", Value = documentId.ToString() });
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

                report.ExportToPdf(ms);
            }

            return ms;
        }
    }
}
