using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;
using DevExpress.XtraPivotGrid;
using DevExpress.Data;
using DevExpress.Utils.Menu;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;


namespace CDS.Client.Desktop.Reporting.Analytic
{
    public partial class AnalyticForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.RPT_Analytic rpt_Analytic;
        SqlDataAdapter adapter;

        public AnalyticForm()
        {
            InitializeComponent();
        }

        public AnalyticForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                tcgData.SelectedTabPage = tabAnalysis;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void BindDefaultDate()
        {
            dtDateStart.EditValue = DateTime.Today;
            dtDateEnd.EditValue = DateTime.Today;
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            rpt_Analytic = BL.RPT.RPT_Analytic.New;
        }

        public override void OpenRecord(long Id)
        {
            try
            {
                base.OpenRecord(Id);

                rpt_Analytic = BL.RPT.RPT_Analytic.Load(Id, DataContext); 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = rpt_Analytic;

            if (rpt_Analytic.DataLayout != null)
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
                    System.IO.StreamWriter sr2 = new System.IO.StreamWriter(stream2);
                    sr2.WriteLine(rpt_Analytic.DataLayout);
                    sr2.Flush();
                    stream2.Seek(0, System.IO.SeekOrigin.Begin);
                    Pivot.RestoreLayoutFromStream(stream2, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                    foreach (PivotGridField field in Pivot.Fields)
                    {
                        if (field.UnboundExpression != String.Empty)
                        {
                            field.Options.ShowUnboundExpressionMenu = true;
                            field.UnboundType = UnboundColumnType.Decimal;
                            if (field.DataControllerColumnName.Contains("%"))
                                field.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
                        }
                    }
                }
            }

            BindingSourceAnalyticSource.DataSource = DataContext.ReadonlyContext.VW_AnalyticSource.ToList();
            ddlDatePeriodSelect.Properties.DataSource = DataContext.ReadonlyContext.VW_Period.Select(n => n.Code).Distinct().OrderByDescending(n => n).ToList();
            ddlDateQuarterSelect.Properties.DataSource = DataContext.ReadonlyContext.VW_Period.Select(n => new { n.FinancialYear, n.FinancialQuarter }).Distinct().OrderByDescending(n => n).ToList().Select(n => n.FinancialYear + " " + n.FinancialQuarter);
            ddlDateYearSelect.Properties.DataSource = DataContext.ReadonlyContext.VW_Period.Select(n => n.FinancialYear).Distinct().OrderByDescending(n => n).ToList();
            BindDefaultDate();
            Pivot.FieldsCustomization(pnlFields);
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();

                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    Pivot.SaveLayoutToStream(stream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                    ((DB.RPT_Analytic)BindingSource.DataSource).DataLayout = sr.ReadToEnd();
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        BL.EntityController.SaveRPT_Analytic(((DB.RPT_Analytic)BindingSource.DataSource), DataContext);
                        DataContext.SaveChangesEntityReportContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityReportContext.AcceptAllChanges();
                    DataContext.EntitySystemContext.AcceptAllChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                DataContext.EntityReportContext.RejectChanges();
                DataContext.EntitySystemContext.RejectChanges();
                HasErrors = true;
                CurrentException = ex;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
        }

        private bool IsFieldUnboundExpression(PivotGridField field)
        {
            try
            {
                if (field != null && field.UnboundType != UnboundColumnType.Bound)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsFieldSummaryExpression(PivotGridField field)
        {
            try
            {
                if (IsFieldUnboundExpression(field) && field.Area == PivotArea.DataArea)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private PivotGridField removeField;
        private void RemoveField(object sender, EventArgs e)
        {
            try
            {
                if (removeField != null)
                    Pivot.Fields.Remove(removeField);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void GetData(bool ReloadFields)
        {
            try
            {
                if (ddlDataSource.EditValue.ToString() != "")
                {
                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        SetWaitFormDescription("Retrieving Data");
                        string datefilter = "";
                        if (((DB.VW_AnalyticSource)ddlDataSource.GetSelectedDataRow()).DateFilter)
                        {
                            if (chkDateDays.Checked)
                            {
                                datefilter = String.Format("where Date BETWEEN '{0}' AND '{1}'", ((DateTime)dtDateStart.EditValue).ToString("yyyy-MM-dd HH:mm:ss.fff"), ((DateTime)dtDateEnd.EditValue).ToString("yyyy-MM-dd 23:59:59"));

                            }
                            else if (chkDatePeriod.Checked)
                            {
                                datefilter = String.Format("where FinancialPeriod IN ('{0}')", ddlDatePeriodSelect.Properties.GetCheckedItems().ToString().Replace(", ", "','"));
                            }
                            else if (chkDateQuarter.Checked && (ddlDateQuarterSelect.Properties.GetCheckedItems().ToString().Length > 0))
                            {
                                datefilter = String.Format("where CAST(FinancialYear AS NVARCHAR(4))+' '+CAST(FinancialQuarter AS NVARCHAR(1)) IN ('{0}')", ddlDateQuarterSelect.Properties.GetCheckedItems().ToString().Replace(", ", "','"));
                            }
                            else if (chkDateYear.Checked && (ddlDateYearSelect.Properties.GetCheckedItems().ToString().Length > 0))
                            {
                                datefilter = String.Format("where FinancialYear IN ({0})", ddlDateYearSelect.Properties.GetCheckedItems());
                            }
                        }
                        string query = "";

                        if (((DB.VW_AnalyticSource)ddlDataSource.GetSelectedDataRow()).DateFilter)
                            query = String.Format("select {0} * from {1} {2}", ReloadFields ? "TOP 1" : "", ((DB.VW_AnalyticSource)ddlDataSource.GetSelectedDataRow()).Source, datefilter);
                        else
                            query = String.Format("select {0} * from {1}", ReloadFields ? "TOP 1" : "", ((DB.VW_AnalyticSource)ddlDataSource.GetSelectedDataRow()).Source);

                        //switch (ddlDataSource.EditValue.ToString())
                        //{
                        //    case "Sales Analysis":
                        //        query = String.Format("select {1} * from VW_Sales where {0}", datefilter, ReloadFields ? "TOP 1" : "");
                        //        break;
                        //    case "Purchases Analysis":
                        //        query = String.Format("select {1} * from VW_Purchases where {0}", datefilter, ReloadFields ? "TOP 1" : "");
                        //        break;
                        //    case "Inventory Analysis":
                        //        query = String.Format("select {1} * from VW_Inventory", datefilter, ReloadFields ? "TOP 1" : "");
                        //        break;
                        //    case "Finance Analysis":
                        //        query = String.Format("select {1} * from VW_Finance where {0}", datefilter, ReloadFields ? "TOP 1" : "");
                        //        break;
                        //    case "Workshop Analysis":
                        //        query = String.Format("select {1} * from VW_Workshop", datefilter, ReloadFields ? "TOP 1" : "");
                        //        break;
                        //}

                        try
                        { 
                            DataTable data = new DataTable();
                            adapter = BL.ApplicationDataContext.Instance.GetAdapter(query);
                            adapter.Fill(data);
                            adapter.Dispose();
                            BindingSourcePivot.DataSource = data;
                            System.IO.MemoryStream layoutStream = new System.IO.MemoryStream();
                            Pivot.SaveLayoutToStream(layoutStream);
                            List<PivotGridField> calculatedFields = new List<PivotGridField>();
                            List<DevExpress.Utils.FormatInfo> calculatedFieldsFormat = new List<DevExpress.Utils.FormatInfo>();

                            foreach (PivotGridField field in Pivot.Fields)
                            {
                                if (field.UnboundExpression != String.Empty)
                                { 
                                    calculatedFields.Add(field);
                                    calculatedFieldsFormat.Add(field.CellFormat);
                                }
                            }

                            //if (ReloadFields)
                            {
                                Pivot.RetrieveFields(PivotArea.DataArea, false);
                                foreach (PivotGridField f in Pivot.Fields)
                                {
                                    if (f.Caption.EndsWith("Id"))
                                        f.Options.ShowInCustomizationForm = false;

                                    f.Options.AllowRunTimeSummaryChange = true;
                                    f.Options.ShowSummaryTypeName = true;
                                }
                                layoutStream.Seek(0, System.IO.SeekOrigin.Begin);
                                Pivot.RestoreLayoutFromStream(layoutStream);
                            }
                            
                            Pivot.BestFitRowArea(); Pivot.BestFitDataHeaders(true);
                            
                            //Pivot.Fields.AddRange(calculatedFields.ToArray());

                            for (int i = 0; i < calculatedFields.Count; i++)
                            {
                                PivotGridField field = calculatedFields[i];
                                PivotGridField newField = new DevExpress.XtraPivotGrid.PivotGridField();
                                BL.ApplicationDataContext.DeepClone(field, newField);
                                newField.Options.ShowUnboundExpressionMenu = true;
                                newField.UnboundType = UnboundColumnType.Decimal;
                                Pivot.Fields.Add(newField);
                            }
                            

                        }
                        catch (SqlException ex)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void OnPrintPreview()
        {
            try
            {
                if (tcgData.SelectedTabPage == tabAnalysis)
                {
                    if (Pivot.IsPrintingAvailable)
                        Pivot.ShowRibbonPrintPreview();
                }
                else if (tcgData.SelectedTabPage == tabChart)
                {
                    if (Chart.IsPrintingAvailable)
                        Chart.ShowRibbonPrintPreview();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.REANRECR);
            AllowExport = true;
            AllowPrint = true;
        }

        protected override void Archive()
        {
            ((DB.RPT_Analytic)BindingSource.DataSource).Archived = true;
            OnSaveRecord();
        }

        private void btnAddCustomField_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (AnalyticCustomFieldDialogue addNewBonus = new AnalyticCustomFieldDialogue())
                {
                    addNewBonus.PivotGrid = Pivot;
                    if (addNewBonus.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void Pivot_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.ValueInfo != null && IsFieldSummaryExpression(e.HitInfo.ValueInfo.Field))
                {
                    removeField = e.HitInfo.ValueInfo.Field;
                    DXMenuItem item = new DXMenuItem("Remove Custom Field", RemoveField);
                    item.BeginGroup = true;
                    e.Menu.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlDataSource_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDataSource.Text != string.Empty && ddlDataSource.Text != ((DB.RPT_Analytic)BindingSource.DataSource).DataSource)
                    GetData(true);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlPeriodFilter_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetData(false);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            try
            {
                GetData(false);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnSwapDataAxis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Pivot.OptionsChartDataSource.ProvideDataByColumns = !Pivot.OptionsChartDataSource.ProvideDataByColumns;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void DateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtDateStart.Enabled = chkDateDays.Checked;
            dtDateEnd.Enabled = chkDateDays.Checked;
            ddlDatePeriodSelect.Enabled = chkDatePeriod.Checked;
            ddlDateQuarterSelect.Enabled = chkDateQuarter.Checked;
            ddlDateYearSelect.Enabled = chkDateYear.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            adapter.SelectCommand.Cancel();
        }
    }
}
