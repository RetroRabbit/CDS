using CDS.Client.Desktop.Reporting.Report.Design;
using DevExpress.XtraReports.Extensions;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

// Developer Express Code Central Example:
// How to implement custom XML serialization of a report that is bound to a dataset
// 
// This example demonstrates the capability to serialize a report to XML along with
// its data source.
// 
// In this example, a report that is bound to a dataset can be
// saved to a file, and then restored along with its data source.
// 
// To do this,
// override the ReportStorageExtension class, and use the
// XtraReport.SaveLayoutToXml() method. And, you can use an opposite
// LoadLayoutFromXml() method, to de-serialize an XML report from a file or
// stream.
// 
// In addition, it is required to register a custom
// ReportDesignExtension, which implements the data source serialization
// functionality.
// 
// See also: http://www.devexpress.com/scid=E3169
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3157
namespace CDS.Client.Desktop.Reporting.Report.Extensions
{
    public class ReportExtension : ReportStorageExtension
    {
        BL.DataContext DataContext { get; set; }

        public ReportExtension()
        {
            DataContext = new BL.DataContext();
        }

        public override void SetData(XtraReport report, Stream stream)
        {
            report.SaveLayoutToXml(stream);
        }

        public override byte[] GetData(string url)
        {
            string[] urlvalues = url.Split(new char[] { '|' });
            DB.RPT_Report rpt_report = BL.RPT.RPT_Report.Load(Convert.ToInt64(urlvalues[0]), DataContext);

            if (rpt_report != null)
                return System.Text.Encoding.UTF8.GetBytes(rpt_report.Data);

            return new byte[] { };
        }

        public override void SetData(XtraReport report, string url)
        {
            //DevExpress.XtraReports.Extensions.ReportDesignExtension.RegisterExtension(Program.DesignExtension, "Custom");
            DevExpress.XtraReports.Extensions.ReportDesignExtension.AssociateReportWithExtension(report, "Custom");
            string[] urlvalues = url.Split(new char[] { '|' });
            DB.RPT_Report rpt_report = BL.RPT.RPT_Report.Load(Convert.ToInt64(urlvalues[0]), DataContext);

            if (rpt_report == null)
                rpt_report = BL.RPT.RPT_Report.New;

            rpt_report.Code = urlvalues[1];
            rpt_report.Name = urlvalues[2];
            rpt_report.Description = urlvalues[3];
            rpt_report.Category = urlvalues[4];
            rpt_report.SubCategory = urlvalues[5];
            rpt_report.SecurityLevel = Convert.ToInt16(urlvalues[6]);
            rpt_report.Data = GetData(report);
            //using (new Essential.UTL.WaitCursor())
            {
                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        BL.EntityController.SaveRPT_Report(rpt_report, DataContext);
                        DataContext.SaveChangesEntityReportContext();
                        urlvalues[0] = rpt_report.Id.ToString();
                        report.Tag = String.Join("|", urlvalues);
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityReportContext.AcceptAllChanges();
                    DataContext.EntitySystemContext.AcceptAllChanges();
                }
                catch (Exception ex)
                {
                    DataContext.EntityReportContext.RejectChanges();
                    DataContext.EntitySystemContext.RejectChanges();

                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }

        }

        string GetData(XtraReport report)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                report.SaveLayoutToXml(ms);
                using (StreamReader sr = new StreamReader(ms))
                {
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    return sr.ReadToEnd();
                }
            }
        }

        public override string GetNewUrl()
        {
            SaveReportDialogue dialogue = new SaveReportDialogue();

            if (dialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialogue.ReportUrl;

            }
            return string.Empty;
            //StorageEditorForm form = CreateForm();
            //form.textBox1.Enabled = false;
            //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    return form.textBox1.Text;
            //return string.Empty;

            //return "RAND" + new Random().Next(100);
        }

        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            ; SaveReportDialogue dialogue = new SaveReportDialogue();

            if (report.Tag != null && report.Tag != String.Empty)
                dialogue.ReportUrl = Convert.ToString(report.Tag);

            if (dialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SetData(report, dialogue.ReportUrl);
                return dialogue.ReportUrl;
            }
            else
            {
                //MessageBox.Show("Incorrect report name", "Error",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            return string.Empty;
        }
    }
}