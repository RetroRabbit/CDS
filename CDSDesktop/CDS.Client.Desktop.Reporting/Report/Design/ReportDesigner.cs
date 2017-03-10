using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UserDesigner;
using CDS.Client.Desktop.Reporting.Report.Wizard;
using System.IO;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Reporting.Report.Design
{
    public partial class ReportDesigner : DevExpress.XtraBars.Ribbon.RibbonForm, Essential.UTL.ITabbedForm
    {
        BL.DataContext dataContext = new BL.DataContext();

        BL.DataContext DataContext { get { return dataContext; } }

        public ReportDesigner()
        {
            InitializeComponent();
            
        }

        private void ReportDesigner_Load(object sender, EventArgs e)
        {
          //  ((XRDesignFormEx)sender).DesignPanel.ExecCommand(ReportCommand.NewReportWizard);
            commandBarItem31.Visibility = BarItemVisibility.Never;
            commandBarItem34.Visibility = BarItemVisibility.Never;
        }

        /// <summary>
        /// Returns the icon image that must be used for the tab in the main form.
        /// </summary>
        /// <remarks>Created: Theo Crous 02/03/2011</remarks>
        public Image TabIcon
        {
            get
            {
                return global::CDS.Client.Desktop.Reporting.Properties.Resources.presentation_chart_16;
            }
        }

        string xtraReport_ParametersRequestBeforeShow = 
            "private void XtraReport_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) "+Environment.NewLine+
       "{                                                                                                                                       "+Environment.NewLine+
       "    for (int i = 0; i < e.ParametersInformation.Length; i++)                                                                            "+Environment.NewLine+
       "    {                                                                                                                                   "+Environment.NewLine+
       "                                                                                                                                        "+Environment.NewLine+
       "        DevExpress.XtraEditors.LookUpEdit oldEditor = (e.ParametersInformation[i].Editor as DevExpress.XtraEditors.LookUpEdit);         "+Environment.NewLine+
       "                                                                                                                                        "+Environment.NewLine+
       "        DevExpress.XtraEditors.SearchLookUpEdit newEditor = new DevExpress.XtraEditors.SearchLookUpEdit();                              "+Environment.NewLine+
       "                                                                                                                                        "+Environment.NewLine+
       "        DevExpress.XtraGrid.Columns.GridColumn colDescription = new DevExpress.XtraGrid.Columns.GridColumn();                           "+Environment.NewLine+
       "        colDescription.FieldName = \"Description\";                                                                                     "+Environment.NewLine+
       "        colDescription.Name = \"colDescription\";                                                                                       "+Environment.NewLine+
       "        colDescription.Visible = true;                                                                                                  "+Environment.NewLine+
       "        colDescription.VisibleIndex = 0;                                                                                                "+Environment.NewLine+
       "        colDescription.Width = 150;                                                                                                     "+Environment.NewLine+
       "                                                                                                                                        "+Environment.NewLine+
       "        DevExpress.XtraGrid.Views.Grid.GridView vwView = new DevExpress.XtraGrid.Views.Grid.GridView();                                 "+Environment.NewLine+
       "        vwView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDescription });                                       "+Environment.NewLine+
       "                                                                                                                                        "+Environment.NewLine+
       "        newEditor.Properties.DisplayMember = oldEditor.Properties.DisplayMember;                                                        "+Environment.NewLine+
       "        newEditor.Properties.DataSource = oldEditor.Properties.DataSource;                                                              "+Environment.NewLine+
       "        newEditor.Properties.ValueMember = oldEditor.Properties.ValueMember;                                                            "+Environment.NewLine+
       "        newEditor.Properties.View = vwView;                                                                                             "+Environment.NewLine+
       "        e.ParametersInformation[i].Editor = newEditor;                                                                                  "+Environment.NewLine+
       "    }                                                                                                                                   " +Environment.NewLine+
       "}                                                                                                                                       ";

        internal bool NewRecord()
        {
            try
            {
                Templates.BaseReportTemplate report = new Templates.BaseReportTemplate();
                //XtraReport report = new XtraReport();
                //reportDesigner1.OpenReport(report);
                reportDesigner1.CreateNewReport();
                reportDesigner1.AddCommandHandler(new WizardCommandHandler(reportDesigner1.ActiveDesignPanel));
                reportDesigner1.ActiveDesignPanel.ExecCommand(ReportCommand.NewReportWizard);
                //reportDesigner1.CreateNewReportWizard();
                while (xrDesignDockManager1.HiddenPanels.Count > 0)
                    xrDesignDockManager1.HiddenPanels[0].Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;

                reportDesigner1.ActiveDesignPanel.Report.Scripts.OnParametersRequestBeforeShow  ="XtraReport_ParametersRequestBeforeShow";
                reportDesigner1.ActiveDesignPanel.Report.ScriptsSource = xtraReport_ParametersRequestBeforeShow;
               
                if (reportDesigner1.ActiveDesignPanel.ReportState == ReportState.Changed)
                    return true;
                else
                    return false;

                //if (reportDesigner1.ActiveDesignPanel.ReportState != ReportState.Opened)
                //    return false;
                //else
                //    return true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

       

        public void OpenRecord(Int64 Id)
        {
            try
            {
                DB.RPT_Report rptReport = BL.RPT.RPT_Report.Load(Id, DataContext);

                Templates.BaseReportTemplate report = new Templates.BaseReportTemplate();
                report.LoadLayoutFromXml(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(rptReport.Data)));
                report.Tag = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", rptReport.Id, rptReport.Code, rptReport.Name, rptReport.Description, rptReport.Category, rptReport.SubCategory, rptReport.SecurityLevel);

                //report.Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "Period", Type = typeof(DateTime), });

                //if (report.DataSource is DevExpress.DataAccess.Sql.SqlDataSource)
                //    ((DevExpress.DataAccess.Sql.SqlDataSource)(report.DataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
                //else if (report.DataSource is DevExpress.DataAccess.EntityFramework.EFDataSource)
                //    ((DevExpress.DataAccess.EntityFramework.EFDataSource)(report.DataSource)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString;
                //else
                //    throw new Exception("Data Source type not implemented in reports");

                reportDesigner1.OpenReport(report);

                foreach (var componenet in report.Container.Components)
                {
                    if (!(componenet is DevExpress.DataAccess.Native.DataComponentBase))
                        continue;

                    if (componenet is DevExpress.DataAccess.Sql.SqlDataSource)
                        ((DevExpress.DataAccess.Sql.SqlDataSource)(componenet)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
                    else if (componenet is DevExpress.DataAccess.EntityFramework.EFDataSource)
                    {
                        if (((DevExpress.DataAccess.EntityFramework.EFDataSource)(componenet)).Connection != null)
                            ((DevExpress.DataAccess.EntityFramework.EFDataSource)(componenet)).Connection.ConnectionString = BL.ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString;
                    }
                  
                }
                while (xrDesignDockManager1.HiddenPanels.Count > 0)
                    xrDesignDockManager1.HiddenPanels[0].Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;

                //if (reportDesigner1.ActiveDesignPanel.Report.Scripts.OnParametersRequestBeforeShow == string.Empty)
                //{
                //    reportDesigner1.ActiveDesignPanel.Report.Scripts.OnParametersRequestBeforeShow = "XtraReport_ParametersRequestBeforeShow";
                //    reportDesigner1.ActiveDesignPanel.Report.ScriptsSource = xtraReport_ParametersRequestBeforeShow;
                //}
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        void report_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {

            //for(int i=0;i<e.ParametersInformation.Length;i++)
            //{
            //    e.ParametersInformation[i].Editor = new DevExpress.XtraEditors.SearchLookUpEdit();
            //}
        }

        void Report_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
             
        }

        private void bbiCopyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            reportDesigner1.ActiveDesignPanel.Report.SaveLayout(ms, true);
            ms.Position = 0;
            Templates.BaseReportTemplate report = new Templates.BaseReportTemplate();
            report.LoadLayout(ms);
            report.Tag = null;
            reportDesigner1.OpenReport(report);             
        }
         
    }
}