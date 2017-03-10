using CDS.Client.Desktop.Reporting.Report.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Reporting.Report
{
    public partial class ReportList : CDS.Client.Desktop.Essential.BaseList
    {
        Report.Design.ReportDesigner reportDesignerInstance;
      
        public ReportList()
        {
            InitializeComponent();
        }

        private Report.Design.ReportDesigner ReportDesignerInstance
        {
            get
            {
                if (reportDesignerInstance == null || reportDesignerInstance.IsDisposed)
                    reportDesignerInstance = new ReportDesigner();

                return reportDesignerInstance;
            }
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                AllowNewRecord = BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.RERPRECR);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                 ReportForm childForm = new ReportForm();
                 childForm.OpenRecord(Id);
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                //Report.Design.ReportDesigner childForm = new Report.Design.ReportDesigner();
                if (ReportDesignerInstance.NewRecord())
                    //ShowForm(childForm);  
                    ReportDesignerInstance.Show();
                
                    
            }   
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.RERPRECR);
        } 

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    if (this.SelectedRowId == -1)
                        return;

                    ReportDesignerInstance.OpenRecord(this.SelectedRowId);
                    ReportDesignerInstance.Show();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ReportDesignerInstance.Close();
            if (!reportDesignerInstance.IsDisposed)
            {
                e.Cancel = true;
                reportDesignerInstance.BringToFront();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DB.RPT_Report rptReport = BL.RPT.RPT_Report.Load(1, DataContext);
            //this.Text = rptReport.Name;
            System.IO.Stream xmlstream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(rptReport.Data));

            //XtraReport report = new XtraReport();
            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
            report.LoadLayoutFromXml(xmlstream);
            //report.CurrentPrintControl = PrintControl;
            //SqlDataAdapter adp = (SqlDataAdapter)report.DataAdapter;

            if (report.DataSource is DevExpress.DataAccess.Sql.SqlDataSource)
                ((DevExpress.DataAccess.Sql.SqlDataSource)(report.DataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
            else if (report.DataSource is DevExpress.DataAccess.EntityFramework.EFDataSource)
                ((DevExpress.DataAccess.EntityFramework.EFDataSource)(report.DataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString;
            else
                throw new Exception("Data Source type not implemented in reports");

            //adp.SelectCommand.Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
            DevExpress.XtraReports.Parameters.ParameterCollection Parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();
            Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "Code_Main_starts_with", Value = "00100" });
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
            report.ExportToPdf(@"C:\accounts_report.pdf");
                
        }
    }
}
