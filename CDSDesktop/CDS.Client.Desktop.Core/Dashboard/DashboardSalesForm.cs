using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using XDB = CDS.Client.DataAccessLayer.XDB;
using DevExpress.Xpo;

namespace CDS.Client.Desktop.Core.Dashboard
{
    public partial class DashboardSalesForm : CDS.Client.Desktop.Essential.BaseForm
    {
        long? defaultSiteId;
        public DashboardSalesForm()
        {
            InitializeComponent(); 
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                AllowArchive = false;
                AllowSave = false;
                AllowRefresh = true;
                ddlIntervals.DataSource = Enum.GetNames(typeof(DevExpress.XtraCharts.DateTimeMeasureUnit)).ToList();

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();

            DateTime start;
            DateTime end;

            
            Session uow = DashboardSession;
            
            //using (UnitOfWork uow = new UnitOfWork())
            {
                end = uow.Query<XDB.SYS_DOC_Header>().Max(n => n.ORG_TRX_Header.DatePosted);
                if (end == DateTime.MinValue)
                    return;

                start = end.AddDays(-30);

                XPCollectionAreaCode.AddRange(uow.Query<XDB.ORG_Company>().Where(n => n.AreaCode != null).Select(l => l.AreaCode).Distinct().ToList().Select(l => new AreaCode(DashboardSession) { Value = l }).ToList());
            }

            deStartDate.EditValue = start;
            deEndDate.EditValue = end;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ccbeAreaCode.CheckAll();
            BackgroundWorker.RunWorkerAsync();
        }

        public override void RefreshRecord()
        {
            base.RefreshRecord();
            ValidateLayout();
            BackgroundWorker.RunWorkerAsync();
        }

        private void beiIntervals_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                object value = Enum.Parse(typeof(DevExpress.XtraCharts.DateTimeMeasureUnit), beiIntervals.EditValue.ToString());
                
                ((DevExpress.XtraCharts.XYDiagram)((chartBarController1.Control as DevExpress.XtraCharts.ChartControl).Diagram)).AxisX.DateTimeScaleOptions.MeasureUnit = (DevExpress.XtraCharts.DateTimeMeasureUnit)value;
                ((DevExpress.XtraCharts.XYDiagram)((chartBarController1.Control as DevExpress.XtraCharts.ChartControl).Diagram)).AxisX.DateTimeScaleOptions.GridAlignment = (DevExpress.XtraCharts.DateTimeGridAlignment)value;
                
            }
            catch (Exception ex)
            {
                //  if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ChangeChartBarControl(object sender, EventArgs e)
        {
            chartBarController1.Control = sender as DevExpress.XtraCharts.ChartControl;

            try
            {
                //object value = Enum.Parse(typeof(DevExpress.XtraCharts.DateTimeMeasureUnit), beiIntervals.EditValue.ToString());

                beiIntervals.EditValue = Enum.GetName(typeof(DevExpress.XtraCharts.DateTimeMeasureUnit), ((DevExpress.XtraCharts.XYDiagram)((chartBarController1.Control as DevExpress.XtraCharts.ChartControl).Diagram)).AxisX.DateTimeScaleOptions.GridAlignment);
                tsiSeries.Checked = (
                    (chartBarController1.Control as DevExpress.XtraCharts.ChartControl).Legend.Visibility == DevExpress.Utils.DefaultBoolean.True ||
                    (chartBarController1.Control as DevExpress.XtraCharts.ChartControl).Legend.Visibility == DevExpress.Utils.DefaultBoolean.Default
                                    ) ? true : false;

                rcDateRange.Client = sender as DevExpress.XtraCharts.ChartControl;
                DateTimeChartRangeControlClient.DataProvider.DataSource = (sender as DevExpress.XtraCharts.ChartControl).DataSource;
            }
            catch (Exception ex)
            {
                //  if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
         
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (deStartDate.EditValue == null)
                return;

            var data = new DashboardData();
            using (new Essential.UTL.WaitCursor())
            {
                string[] areaCodes = ccbeAreaCode.EditValue.ToString().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
              

                DateTime start = (DateTime)deStartDate.EditValue;
                DateTime end = (DateTime)deEndDate.EditValue;
                
                Session uow = DashboardSession;
              
                //using (UnitOfWork uow = new UnitOfWork())
                {
                    if (end == DateTime.MinValue)
                        return;
                    //added siteId to each Where clause
                    var sales = uow.Query<XDB.SYS_DOC_Header>()
                        .Where(n => new byte[] { 3, 4 }.Contains(n.TypeId.Id) && ((n.ORG_TRX_Header.CompanyId.AreaCode == null) || (n.ORG_TRX_Header.CompanyId.AreaCode != null && areaCodes.Contains(n.ORG_TRX_Header.CompanyId.AreaCode))) && n.ORG_TRX_Header.DatePosted >= start && n.ORG_TRX_Header.DatePosted <= end && n.SiteId.Id == defaultSiteId)
                        .GroupBy(n => new { Date = n.ORG_TRX_Header.DatePosted, n.TypeId.Name })
                        .Select(n => new { Series = n.Key.Name, Argument = n.Key.Date, Value = n.Sum(s => s.Total) })
                        .OrderBy(o => o.Argument).ToList();


                    var groupedSales = sales
                        .GroupBy(n => n.Argument)
                        .Select(n => new { Series = "Total", Argument = n.Key.Date, Value = n.Sum(s => s.Series == "TAX Invoice" ? s.Value : -s.Value) })
                        .OrderBy(o => o.Argument).ToList();

                    foreach (var value in sales)
                    {
                        SalesRecord record = new SalesRecord(DashboardSession);
                        record.Series = value.Series;
                        record.Argument = value.Argument;
                        record.Value = value.Value;
                        data.DailySales.Add(record);
                    }

                    foreach (var value in groupedSales)
                    {
                        SalesRecord record = new SalesRecord(DashboardSession);
                        record.Series = value.Series;
                        record.Argument = value.Argument;
                        record.Value = value.Value;
                        data.DailySales.Add(record);
                    }

                    var topSalesByPerson = uow.Query<XDB.SYS_DOC_Header>()
                        .Where(n => new byte[] { 3, 4 }.Contains(n.TypeId.Id) && ((n.ORG_TRX_Header.CompanyId.AreaCode == null) || (n.ORG_TRX_Header.CompanyId.AreaCode != null && areaCodes.Contains(n.ORG_TRX_Header.CompanyId.AreaCode))) && n.ORG_TRX_Header.DatePosted >= start && n.ORG_TRX_Header.DatePosted <= end && n.SiteId.Id == defaultSiteId)
                        .GroupBy(n => n.CreatedBy)
                        .Select(n => new { n.Key, Value = n.Sum(s => s.TypeId.Id == 3 ? s.Total : -s.Total) })
                        .OrderByDescending(o => o.Value)
                        .Take(10)
                        .Select(n => n.Key);

                    var salesByPerson = uow.Query<XDB.SYS_DOC_Header>()
                        .Where(n => topSalesByPerson.Contains(n.ORG_TRX_Header.CreatedBy) && new byte[] { 3, 4 }.Contains(n.TypeId.Id) && ((n.ORG_TRX_Header.CompanyId.AreaCode == null) || (n.ORG_TRX_Header.CompanyId.AreaCode != null && areaCodes.Contains(n.ORG_TRX_Header.CompanyId.AreaCode))) && n.ORG_TRX_Header.DatePosted >= start && n.ORG_TRX_Header.DatePosted <= end && n.SiteId.Id == defaultSiteId)
                        .GroupBy(n => new { n.ORG_TRX_Header.DatePosted.Date, n.CreatedBy.Fullname })
                        .Select(n => new { Series = n.Key.Fullname, Argument = n.Key.Date, Value = n.Sum(s => s.TypeId.Id == 3 ? s.Total : -s.Total) })
                        .OrderBy(o => o.Argument).ToList();

                    foreach (var value in salesByPerson)
                    {
                        SalesRecord record = new SalesRecord(DashboardSession);
                        record.Series = value.Series;
                        record.Argument = value.Argument;
                        record.Value = value.Value;
                        data.SalesByPerson.Add(record);
                    }

                    var topSalesCustomers = uow.Query<XDB.SYS_DOC_Header>()
                       .Where(n => new byte[] { 3, 4 }.Contains(n.TypeId.Id) && ((n.ORG_TRX_Header.CompanyId.AreaCode == null) || (n.ORG_TRX_Header.CompanyId.AreaCode != null && areaCodes.Contains(n.ORG_TRX_Header.CompanyId.AreaCode))) && n.ORG_TRX_Header.DatePosted >= start && n.ORG_TRX_Header.DatePosted <= end && n.SiteId.Id == defaultSiteId)
                       .GroupBy(n => n.ORG_TRX_Header.CompanyId.EntityId.EntityId.Name)
                       .Select(n => new { n.Key, Value = n.Sum(s => s.TypeId.Id == 3 ? s.Total : -s.Total) })
                       .OrderByDescending(o => o.Value)
                       .Take(10)
                       .Select(n => n.Key);

                    var salesByCustomer = uow.Query<XDB.SYS_DOC_Header>()
                       .Where(n => topSalesCustomers.Contains(n.ORG_TRX_Header.CompanyId.EntityId.EntityId.Name) && new byte[] { 3, 4 }.Contains(n.TypeId.Id) && n.ORG_TRX_Header.DatePosted >= start && n.ORG_TRX_Header.DatePosted <= end && n.SiteId.Id == defaultSiteId)
                       .GroupBy(n => new { n.ORG_TRX_Header.DatePosted.Date, n.ORG_TRX_Header.CompanyId.EntityId.EntityId.Name })
                       .Select(n => new { Series = n.Key.Name, Argument = n.Key.Date, Value = n.Sum(s => s.TypeId.Id == 3 ? s.Total : -s.Total) })
                       .OrderBy(o => o.Argument).ToList();

                    foreach (var value in salesByCustomer)
                    {
                        SalesRecord record = new SalesRecord(DashboardSession);
                        record.Series = value.Series;
                        record.Argument = value.Argument;
                        record.Value = value.Value;
                        data.SalesByCustomer.Add(record);
                    }
                }
            }
            e.Result = data; 
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var data = e.Result as DashboardData;
            if (data == null)
                return;

            xpCollectionDailySales.Reload();
            xpCollectionSalesByPerson.Reload();
            xpCollectionSalesByCustomer.Reload();

            xpCollectionDailySales.AddRange(data.DailySales);
            xpCollectionSalesByPerson.AddRange(data.SalesByPerson);
            xpCollectionSalesByCustomer.AddRange(data.SalesByCustomer);
        }
         
        public class SalesRecord : XPLiteObject
        {
            public SalesRecord(Session session)
                : base(session)
            {

            }

            public string Series;
            public DateTime Argument;
            public decimal Value;
        }

        public class AreaCode : XPLiteObject
        {
            public AreaCode(Session session)
                : base(session)
            {

            }
            public string Value;
        }


        class DashboardData
        {
            List<SalesRecord> dailySales = new List<SalesRecord>();
            List<SalesRecord> salesByPerson = new List<SalesRecord>();
            List<SalesRecord> salesByCustomer = new List<SalesRecord>();

            public List<SalesRecord> DailySales { get { return dailySales; } set { dailySales = value; } }
            public List<SalesRecord> SalesByPerson { get { return salesByPerson; } set { salesByPerson = value; } }
            public List<SalesRecord> SalesByCustomer { get { return salesByCustomer; } set { salesByCustomer = value; } }
        }

        private void tsiSeries_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (chartBarController1.Control as DevExpress.XtraCharts.ChartControl).Legend.Visibility = !tsiSeries.Checked ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
        } 
    }
}

