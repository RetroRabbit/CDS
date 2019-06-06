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
using System.Transactions;

namespace CDS.Client.Desktop.Ordering.AOR
{
    public partial class AutomaticOrderingForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.AOR_Order aorOrder;
        List<DB.AOR_OrderLine> aorOrderLines;
        AutomaticOrderingFilters aorFilters;
        long? defaultSiteId;
        public CDS.Client.Desktop.Essential.BaseForm DetailForm { get; set; }

        /// <summary>
        /// Interval in Seconds for Auto Save
        /// </summary>
        [BrowsableAttribute(true)]
        [DisplayName("Auto Save Interval")]
        public int AutoSaveInterval
        {
            get { return AutoSaveTimer.Interval / 1000; }
            set { AutoSaveTimer.Interval = value * 1000; }
        }

        public override string Description
        {
            get
            {
                return base.Description + aorOrder.Filter;
            }
        }

        public AutomaticOrderingForm()
        {
            InitializeComponent();
        }

        public AutomaticOrderingForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    try
                    {
                        //aorOrder.AOR_OrderLine = BindingSourceLines.DataSource as List<DB.AOR_OrderLine>;
                        aorOrder.LastChangedLine = grvOrderItems.FocusedRowHandle;
                        if (tcgSupplierFilter.SelectedTabPage == tabMultipleSuppliers)
                        {
                            aorOrder.SupplierId = null;
                        }
                        using (TransactionScope transaction = new TransactionScope())
                        {
                            BL.EntityController.SaveAOR_Order(aorOrder, DataContext);
                            DataContext.SaveChangesEntityOrderingContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityOrderingContext.AcceptAllChanges(); 
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityOrderingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true; CurrentException = ex;
                return false;
            }
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            //Werner: This need to happen before the BL.AOR.AOR_Order.New or devexpress EditValue_Changed freaks out

            aorOrder = BL.AOR.AOR_Order.New;
            aorOrderLines = aorOrder.AOR_OrderLine as List<DB.AOR_OrderLine>;
            aorFilters = new AutomaticOrderingFilters();
            btnCancelOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        protected override void OnStart()
        {
            base.OnStart();
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            AllowArchive = false;
            AutoSaveTimer.Start();
            BindData();
            txtSupplierCodeFrom.DataBindings.Add(new Binding("EditValue", aorFilters, "SupplierCodeFrom", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSupplierCodeTo.DataBindings.Add(new Binding("EditValue", aorFilters, "SupplierCodeTo", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            grdOrderItems.ForceInitialize();
            grvOrderItems.FocusedRowHandle = aorOrder.LastChangedLine;
            grvOrderItems.MakeRowVisible(grvOrderItems.FocusedRowHandle, true);
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = aorOrder;
            BindingSourceLines.DataSource =aorOrderLines;
            BindingSourceFilters.DataSource = aorFilters;
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            //ShouldRecover = false; is set in base.OpenRecord(Id);
            //Werner : Need to enable this once I figure out how to solve the recursive reference issue caused by Include
            //ShouldRecover = true;

            aorOrder = BL.AOR.AOR_Order.Load(Id, DataContext, new List<string>() { "AOR_OrderLine" });
            aorOrderLines = aorOrder.AOR_OrderLine as List<DB.AOR_OrderLine>;
            aorFilters = new AutomaticOrderingFilters();
            btnCalculate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (aorOrder.StatusId == (byte)BL.SYS.SYS_Status.Canceled
                || aorOrder.StatusId == (byte)BL.SYS.SYS_Status.Closed)
            {
                AllowSave = false;
                grvOrderItems.OptionsBehavior.Editable = false;
                btnCancelOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            grvOrderItems.FocusedRowHandle = aorOrder.LastChangedLine;
            //Disable all the filters at the top 
            rgItems.Enabled = false;
            rgSales.Enabled = false;
            txtCategoryFrom.Enabled = false;
            txtCategoryTo.Enabled = false;
            lcgWeights.Enabled = false;
            ddlCompany.Enabled = false;
            txtSupplierCodeFrom.Enabled = false;
            txtSupplierCodeTo.Enabled = false;

            PopulateFilters();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INAORECR);
        }   

        private void OpenDetailForm()
        {
            //AutomaticOrderingDetailForm childForm = new AutomaticOrderingDetailForm();

            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                if (aorOrderLines.FindIndex(0, n => n == ((CDS.Client.DataAccessLayer.DB.AOR_OrderLine)(grvOrderItems.GetFocusedRow()))) == -1)
                    return;

                if (DetailForm == null)
                    DetailForm = new AutomaticOrderingDetailForm(aorOrderLines, aorOrderLines.FindIndex(0, n => n == ((CDS.Client.DataAccessLayer.DB.AOR_OrderLine)(grvOrderItems.GetFocusedRow()))));
                else if (DetailForm.IsDisposed)
                    DetailForm = new AutomaticOrderingDetailForm(aorOrderLines, aorOrderLines.FindIndex(0, n => n == ((CDS.Client.DataAccessLayer.DB.AOR_OrderLine)(grvOrderItems.GetFocusedRow()))));

                BindingSourceLines.DataSource = aorOrderLines.OrderBy(n => n.Site).ThenBy(n => n.Supplier).ThenBy(n => n.ShortName).ThenBy(n => n.Name).ThenBy(n => n.OnHand).ToList();

                //aorOrderLines.IndexOf(
                DetailForm.Owner = this;
                //(DetailForm as AutomaticOrderingDetailForm).OpenRecord(aorOrderLines, grvOrderItems.FocusedRowHandle);
                ShowForm(DetailForm);
            }
        }

        public void RefreshList()
        {
            grvOrderItems.RefreshData();
        }

        private void CalculateOrder()
        {
            try
            {
                //This line makes that when you select a supplier and click Calculate that it selects the supplier before calculating
                ValidateLayout();

                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    aorOrder.AOR_OrderLine.Clear();
                    aorOrder.Filter = string.Empty;

                    string query = "SELECT * FROM [CDS_ORG].[VW_OrderInventoryHistory]";

                    //Filter Items
                    switch (Convert.ToByte(rgItems.EditValue))
                    {
                        case (byte)ItemsFilter.All:
                            aorOrder.Filter += "Items:All,";
                            break;
                        case (byte)ItemsFilter.RecommendedReorder:
                            aorOrder.Filter += "Items:RecommendedReorder,";
                            break;
                    }

                    //Filter Sales
                    switch (Convert.ToByte(rgSales.EditValue))
                    {
                        case (byte)SalesFilter.NotApplicable:
                            aorOrder.Filter += "Sales:NotApplicable,";
                            break;
                        case (byte)SalesFilter.MonthSales3:
                            aorOrder.Filter += "Sales:MonthSales3,";
                            query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                            query += " (ABS(ISNULL(d01Month,0))+ABS(ISNULL(d02Month,0))+ABS(ISNULL(d03Month,0))) > 0";

                            break;
                        case (byte)SalesFilter.MonthSales6:
                            aorOrder.Filter += "Sales:MonthSales6,";
                            query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                            query += " (ABS(ISNULL(d01Month,0))+ABS(ISNULL(d02Month,0))+ABS(ISNULL(d03Month,0))+" +
                                "ABS(ISNULL(d04Month,0))+ABS(ISNULL(d05Month,0))+ABS(ISNULL(d06Month,0))) > 0";
                            break;
                        case (byte)SalesFilter.MonthSales12:
                            aorOrder.Filter += "Sales:MonthSales12,";
                            query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                            query += " (ABS(ISNULL(d01Month,0))+ABS(ISNULL(d02Month,0))+ABS(ISNULL(d03Month,0))+" +
                                "ABS(ISNULL(d04Month,0))+ABS(ISNULL(d05Month,0))+ABS(ISNULL(d06Month,0))+" +
                                "ABS(ISNULL(d07Month,0))+ABS(ISNULL(d08Month,0))+ABS(ISNULL(d09Month,0))+" +
                                "ABS(ISNULL(d10Month,0))+ABS(ISNULL(d11Month,0))+ABS(ISNULL(d12Month,0))) > 0";
                            break;
                    }

                    //Filter Supplier
                    if (tcgSupplierFilter.SelectedTabPage == tabMultipleSuppliers)
                    {
                        ddlCompany.EditValue = null;

                        if (txtSupplierCodeFrom.Text == string.Empty)
                        {
                            txtSupplierCodeFrom.ErrorText = "Enter Code ...";
                            return;
                        }
                        else
                        {
                            ddlCompany.ErrorText = string.Empty;
                        }

                        if (txtSupplierCodeTo.Text == string.Empty && txtSupplierCodeFrom.Text != string.Empty)
                        {
                            aorOrder.Filter += "Supplier:>= " + txtSupplierCodeFrom.Text + ",";
                            query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                            query += "SupplierCode >= " + txtSupplierCodeFrom.Text;
                        }
                        else if (txtSupplierCodeFrom.Text != string.Empty && txtSupplierCodeTo.Text != string.Empty)
                        {
                            aorOrder.Filter += "Supplier:BETWEEN '" + txtSupplierCodeFrom.Text + "' AND '" + txtSupplierCodeTo.Text + "',";
                            query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                            query += "SupplierCode >= '" + txtSupplierCodeFrom.Text + "' AND SupplierCode <= '" + txtSupplierCodeTo.Text + "'";
                        }
                    }
                    else if (tcgSupplierFilter.SelectedTabPage == tabSingleSupplier)
                    {
                        if (ddlCompany.EditValue == System.DBNull.Value || ddlCompany.EditValue == null)
                        {
                            ddlCompany.ErrorText = "Select Supplier ...";
                            return;
                        }
                        else
                        {
                            ddlCompany.ErrorText = string.Empty;
                        }
                        aorOrder.Filter += "Supplier:" + ddlCompany.EditValue + ",";
                        query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                        query += "SupplierId = " + ddlCompany.EditValue;
                    }


                    //Both Categories blank
                    if (txtCategoryFrom.Text == string.Empty && txtCategoryTo.Text == string.Empty)
                    {

                    }
                    //If both have a value
                    else if (txtCategoryFrom.Text != string.Empty && txtCategoryTo.Text != string.Empty)
                    {
                        aorOrder.Filter += "Category:BETWEEN'" + txtCategoryFrom.Text + "' AND '" + txtCategoryTo.Text + "',";
                        query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                        query += "Category >= '" + txtCategoryFrom.Text + "' AND Category <= '" + txtCategoryTo.Text + "'";
                    }
                    //If "from" has a value and "to" doesnt
                    else if (txtCategoryFrom.Text != string.Empty && txtCategoryTo.Text == string.Empty)
                    {
                        aorOrder.Filter += "Category:>='" + txtCategoryFrom.Text + "',";
                        query += !query.Contains(" WHERE ") ? " WHERE " : " AND ";
                        query += "Category >= '" + txtCategoryFrom.Text + "'";
                    }
                    else if (txtCategoryFrom.Text == string.Empty && txtCategoryTo.Text != string.Empty)
                    {
                        if (txtCategoryFrom.Text == string.Empty)
                        {
                            txtCategoryFrom.ErrorText = "Enter Category ...";
                            return;
                        }
                    }

                    //query += @" AND MinStockLevel > TotalOnHand AND ROUND(( d00Month + d01Month + d02Month + d03Month + d04Month + d05Month + d06Month + d07Month + d08Month + d09Month + d10Month + d11Month + d12Month + d13Month + d14Month + d15Month + d16Month + d17Month + d18Month + d19Month + d20Month + d21Month + d22Month + d23Month + d24Month + d25Month + d26Month + d27Month + d28Month + d29Month + d30Month + d31Month + d32Month + d33Month + d34Month + d35Month + d36Month + d37Month + d38Month + d39Month + d40Month + d41Month + d42Month + d43Month + d44Month + d45Month + d46Month + d47Month + d48Month ) / 48, 0) > 0";

                    List<DB.AOR_OrderLine> tempItems = new List<DB.AOR_OrderLine>();
                    var readonlyContext = DataContext.ReadonlyContext;
                    readonlyContext.Database.CommandTimeout = 60 * 5;
                    System.Threading.Tasks.Parallel.ForEach(readonlyContext.Database.SqlQuery<DB.VW_OrderInventoryHistory>(query), n =>
                    {
                        tempItems.Add(new DB.AOR_OrderLine()
                        {
                            InventoryHistory = n, 
                            InventoryId = n.EntityId,
                            SupplierId = n.SupplierId,
                            Supplier = n.SupplierCode,
                            ShortName = n.Code,
                            Name = n.Name,
                            OnHand = n.TotalOnHand,
                            OnOrder = n.TotalOnOrder,
                            OnReserve = n.TotalOnHold,
                            SafetyStock = n.SafetyStock,
                            UnitCost = n.UnitCost,
                            UnitAverage = n.UnitAverage,
                            UnitPrice = n.UnitPrice,
                            WarehousingCost = n.WarehousingCost,
                            Average3Months = Math.Round(((n.d01Month + n.d02Month + n.d03Month) / 3), 4, MidpointRounding.AwayFromZero),
                            Average6Months = Math.Round(((n.d01Month + n.d02Month + n.d03Month + n.d04Month + n.d05Month + n.d06Month) / 6), 4, MidpointRounding.AwayFromZero),
                            Average12Months = Math.Round(((n.d01Month + n.d02Month + n.d03Month + n.d04Month + n.d05Month + n.d06Month + n.d07Month + n.d08Month + n.d09Month + n.d10Month + n.d11Month + n.d12Month) / 12), 4, MidpointRounding.AwayFromZero),
                            Average24Months = Math.Round(((n.d01Month + n.d02Month + n.d03Month + n.d04Month + n.d05Month + n.d06Month + n.d07Month + n.d08Month + n.d09Month + n.d10Month + n.d11Month + n.d12Month + n.d13Month + n.d14Month + n.d15Month + n.d16Month + n.d17Month + n.d18Month + n.d19Month + n.d20Month + n.d21Month + n.d22Month + n.d23Month + n.d24Month) / 24), 4, MidpointRounding.AwayFromZero),
                            Average36Months = Math.Round(((n.d01Month + n.d02Month + n.d03Month + n.d04Month + n.d05Month + n.d06Month + n.d07Month + n.d08Month + n.d09Month + n.d10Month + n.d11Month + n.d12Month + n.d13Month + n.d14Month + n.d15Month + n.d16Month + n.d17Month + n.d18Month + n.d19Month + n.d20Month + n.d21Month + n.d22Month + n.d23Month + n.d24Month + n.d25Month + n.d26Month + n.d27Month + n.d28Month + n.d29Month + n.d30Month + n.d31Month + n.d32Month + n.d33Month + n.d34Month + n.d35Month + n.d36Month) / 36), 4, MidpointRounding.AwayFromZero),

                            Average3MonthsPrevious = Math.Round(((n.d13Month + n.d14Month + n.d15Month) / 3), 4, MidpointRounding.AwayFromZero),
                            Average6MonthsPrevious = Math.Round(((n.d13Month + n.d14Month + n.d15Month + n.d16Month + n.d17Month + n.d18Month) / 6), 4, MidpointRounding.AwayFromZero),
                            Average12MonthsPrevious = Math.Round(((n.d13Month + n.d14Month + n.d15Month + n.d16Month + n.d17Month + n.d18Month + n.d19Month + n.d20Month + n.d21Month + n.d22Month + n.d23Month + n.d24Month) / 12), 4, MidpointRounding.AwayFromZero),
                            Average24MonthsPrevious = Math.Round(((n.d13Month + n.d14Month + n.d15Month + n.d16Month + n.d17Month + n.d18Month + n.d19Month + n.d20Month + n.d21Month + n.d22Month + n.d23Month + n.d24Month + n.d25Month + n.d26Month + n.d27Month + n.d28Month + n.d29Month + n.d30Month + n.d31Month + n.d32Month + n.d33Month + n.d34Month + n.d35Month + n.d36Month) / 24), 4, MidpointRounding.AwayFromZero),
                            Average36MonthsPrevious = Math.Round(((n.d13Month + n.d14Month + n.d15Month + n.d16Month + n.d17Month + n.d18Month + n.d19Month + n.d20Month + n.d21Month + n.d22Month + n.d23Month + n.d24Month + n.d25Month + n.d26Month + n.d27Month + n.d28Month + n.d29Month + n.d30Month + n.d31Month + n.d32Month + n.d33Month + n.d34Month + n.d35Month + n.d36Month + n.d37Month + n.d38Month + n.d39Month + n.d40Month + n.d41Month + n.d42Month + n.d43Month + n.d44Month + n.d45Month + n.d46Month + n.d47Month + n.d48Month) / 36), 4, MidpointRounding.AwayFromZero),
                            CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId
                        });
                    });
                     

                    try
                    {
                        System.Threading.Tasks.Parallel.ForEach(tempItems, e =>
                        {
                            e.AvgDemand = BL.AOR.AOR_Order.CalculateAvgDemand(
                            new decimal[] {
                    e.InventoryHistory.d01Month,
                    e.InventoryHistory.d02Month, 
                    e.InventoryHistory.d03Month,
                    e.InventoryHistory.d04Month,
                    e.InventoryHistory.d05Month,
                    e.InventoryHistory.d06Month,
                    e.InventoryHistory.d07Month,
                    e.InventoryHistory.d08Month,
                    e.InventoryHistory.d09Month,
                    e.InventoryHistory.d10Month,
                    e.InventoryHistory.d11Month,
                    e.InventoryHistory.d12Month,
                    e.InventoryHistory.d13Month,
                    e.InventoryHistory.d14Month,
                    e.InventoryHistory.d15Month,
                    e.InventoryHistory.d16Month,
                    e.InventoryHistory.d17Month,
                    e.InventoryHistory.d18Month,
                    e.InventoryHistory.d19Month,
                    e.InventoryHistory.d20Month,
                    e.InventoryHistory.d21Month,
                    e.InventoryHistory.d22Month,
                    e.InventoryHistory.d23Month,
                    e.InventoryHistory.d24Month,
                    e.InventoryHistory.d25Month,
                    e.InventoryHistory.d26Month,
                    e.InventoryHistory.d27Month,
                    e.InventoryHistory.d28Month,
                    e.InventoryHistory.d29Month,
                    e.InventoryHistory.d30Month,
                    e.InventoryHistory.d31Month,
                    e.InventoryHistory.d32Month,
                    e.InventoryHistory.d33Month,
                    e.InventoryHistory.d34Month,
                    e.InventoryHistory.d35Month,
                    e.InventoryHistory.d36Month
                }
                            , Convert.ToDecimal(txtMonthWeight3.Text)
                            , Convert.ToDecimal(txtMonthWeight6.Text)
                            , Convert.ToDecimal(txtMonthWeight12.Text)
                            , Convert.ToDecimal(txtMonthWeight24.Text)
                            , Convert.ToDecimal(txtMonthWeight36.Text)
                            );
                        });
                    }
                    catch (Exception ex)
                    {
                        Essential.BaseAlert.ShowAlert("error", ex.ToString(), Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        if (CDS.Shared.Exception.BusinessLogicExceptionHandler.HandleException(ref ex)) throw ex;
                    }
                    //Calculate EOQ
                    //tempItems.ForEach(n => n.Eoq = BL.AOR.AOR_Order.CalculateEOQ(n.AvgDemand.Value, BL.ApplicationDataContext.Instance.CompanySite.FixedOrderCost, n.WarehousingCost, n.UnitCode.Value));
                    System.Threading.Tasks.Parallel.ForEach(tempItems, e => { e.Eoq = BL.AOR.AOR_Order.CalculateEOQ(e.AvgDemand.Value, BL.ApplicationDataContext.Instance.CompanySite.FixedOrderCost, e.WarehousingCost, e.UnitAverage.Value); });
                    //System.Threading.Tasks.Parallel.ForEach(System.Collections.Concurrent.Partitioner.Create(tempItems, System.Collections.Concurrent.EnumerablePartitionerOptions.NoBuffering), e => { e.Eoq = BL.AOR.AOR_Order.CalculateEOQ(e.AvgDemand.Value, BL.ApplicationDataContext.Instance.CompanySite.FixedOrderCost, e.WarehousingCost, e.UnitCode.Value); });


                    //Calculate EOQ
                    //tempItems.ForEach(n => n.OrderPoint = BL.AOR.AOR_Order.CalculateOrderPoint(BL.ApplicationDataContext.Instance.CompanySite.SafetyStockPeriod, n.AvgDemand.Value, n.InventoryHistory.OrderLeadTime, n.InventoryHistory.SafetyStock));
                    System.Threading.Tasks.Parallel.ForEach(tempItems, e => { e.OrderPoint = BL.AOR.AOR_Order.CalculateOrderPoint(BL.ApplicationDataContext.Instance.CompanySite.SafetyStockPeriod, e.AvgDemand.Value, e.InventoryHistory.OrderLeadTime, e.InventoryHistory.SafetyStock); });
                    //System.Threading.Tasks.Parallel.ForEach(System.Collections.Concurrent.Partitioner.Create(tempItems, System.Collections.Concurrent.EnumerablePartitionerOptions.NoBuffering), e => { e.OrderPoint = BL.AOR.AOR_Order.CalculateOrderPoint(BL.ApplicationDataContext.Instance.CompanySite.SafetyStockPeriod, e.AvgDemand.Value, e.InventoryHistory.OrderLeadTime, e.InventoryHistory.SafetyStock); });


                    //Calculate Reorder Amount
                    //tempItems.ForEach(n => n.OrderAmountCalculated = BL.AOR.AOR_Order.CalculateRecommendedReorderLevel(n.OnHand.Value, n.OnReserve.Value, n.OnOrder.Value, n.InventoryHistory.PackSize, n.OrderPoint.Value, n.Eoq.Value, n.InventoryHistory.StockType, n.InventoryHistory.MinStockLevel, n.InventoryHistory.MaxStockLevel, n.InventoryHistory.MinimumOrderLevel, n.InventoryHistory.MaximumOrderLevel));
                    //tempItems.ForEach(n => n.OrderAmount = n.OrderAmountCalculated);
                    System.Threading.Tasks.Parallel.ForEach(tempItems, e => { e.OrderAmountCalculated = BL.AOR.AOR_Order.CalculateRecommendedReorderLevel(e.OnHand, e.OnReserve, e.OnOrder, e.InventoryHistory.PackSize, e.OrderPoint.Value, e.Eoq.Value, e.InventoryHistory.StockType, e.InventoryHistory.MinStockLevel, e.InventoryHistory.MaxStockLevel, e.InventoryHistory.MinimumOrderLevel, e.InventoryHistory.MaximumOrderLevel); e.OrderAmount = e.OrderAmountCalculated; });
                    //System.Threading.Tasks.Parallel.ForEach(System.Collections.Concurrent.Partitioner.Create(tempItems, System.Collections.Concurrent.EnumerablePartitionerOptions.NoBuffering), e => { e.OrderAmountCalculated = BL.AOR.AOR_Order.CalculateRecommendedReorderLevel(e.OnHand.Value, e.OnReserve.Value, e.OnOrder.Value, e.InventoryHistory.PackSize, e.OrderPoint.Value, e.Eoq.Value, e.InventoryHistory.StockType, e.InventoryHistory.MinStockLevel, e.InventoryHistory.MaxStockLevel, e.InventoryHistory.MinimumOrderLevel, e.InventoryHistory.MaximumOrderLevel); e.OrderAmount = e.OrderAmountCalculated; });


                    System.Threading.Tasks.Parallel.ForEach(tempItems, e => { e.Total = e.OrderAmount * e.UnitCost.Value; });
                    if (Convert.ToByte(rgItems.EditValue) == (byte)ItemsFilter.RecommendedReorder)
                    {
                        tempItems.Where(n => n.OrderAmount > 0).ToList().ForEach(n => aorOrder.AOR_OrderLine.Add(n));
                    }
                    else
                    {
                        tempItems.ToList().ForEach(n => aorOrder.AOR_OrderLine.Add(n));
                    }
                    //BindData();
                    RefreshList();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
         
        private void PopulateFilters()
        {
            string[] filters = aorOrder.Filter.Split(',');
             
            string itemsFilter = filters[0];
            string salesFilter = filters[1];
            string supplierFilter = filters[2];
            string categoryFilter = filters[3];

            rgItems.EditValue = (Int16)(ItemsFilter)Enum.Parse(typeof(ItemsFilter), itemsFilter.Split(':')[1]);
            rgSales.EditValue = (Int16)(SalesFilter)Enum.Parse(typeof(SalesFilter), salesFilter.Split(':')[1]);
            tcgSupplierFilter.SelectedTabPage = tabSingleSupplier;

            if (supplierFilter.Split(':')[1].StartsWith(">"))
            {

            }
            else if (supplierFilter.Split(':')[1].StartsWith("B"))
            {
                tcgSupplierFilter.SelectedTabPage = tabMultipleSuppliers;
                var suppliers = supplierFilter.Split(':')[1].Split(new string[]{"BETWEEN ","AND "},StringSplitOptions.RemoveEmptyEntries);
                aorFilters.SupplierCodeFrom = suppliers[0].Replace("'", "");
                aorFilters.SupplierCodeTo = suppliers[1].Replace("'", "");
                
            }

            if (categoryFilter.Split(':')[1].StartsWith(">"))
            {

            }
            else if (categoryFilter.Split(':')[1].StartsWith("B"))
            {
                var categories = categoryFilter.Split(':')[1].Split(new string[] { "BETWEEN", "AND" }, StringSplitOptions.RemoveEmptyEntries);
                txtCategoryFrom.EditValue = categories[0].Replace("'", "");
                txtCategoryTo.EditValue = categories[1].Replace("'", "");
                
            }


        }

        public override void Recover(List<BindingSource> bindingSources)
        {
            base.Recover(bindingSources);

            BindData();
        }

        private void btnCalculate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CalculateOrder();
        }

        private void InstantFeedbackSourceSupplier_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier && !n.Archived && n.SiteId == defaultSiteId); 
        }

        private void filterControl1_BeforeShowValueEditor(object sender, DevExpress.XtraEditors.Filtering.ShowValueEditorEventArgs e)
        {
            e.CustomRepositoryItem = repCompany;
        }

        private void InstantFeedbackSourceSupplierRepository_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier); 
        }

        private void grdOrderItems_DoubleClick(object sender, EventArgs e)
        {
            OpenDetailForm();
        }

        private void grdOrderItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.I)
            {
                OpenDetailForm();
            }
        }

        private void btnCancelOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataContext.EntityOrderingContext.RejectChanges();
                DataContext.EntitySystemContext.RejectChanges();

                aorOrder.StatusId = (byte)BL.SYS.SYS_Status.Canceled;
                OnSaveRecord();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void AutomaticOrderingForm_VisibleChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void grvOrderItems_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //If no line is selected
            //or if the entity is being opened
            //or if the LastChangedLine is equal to the FocusedRowHandle
            //dont set the LastChangedLine
            if (grvOrderItems.FocusedRowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle || IsOpening || aorOrder.LastChangedLine == grvOrderItems.FocusedRowHandle)
                return;

            aorOrder.LastChangedLine = grvOrderItems.FocusedRowHandle;
        }

        private void txtSupplierCodeFrom_EditValueChanged(object sender, EventArgs e)
        {
            //ddlCompany.EditValue = null;
            if (txtSupplierCodeFrom.EditValue != string.Empty && txtSupplierCodeFrom.EditValue != null && txtSupplierCodeFrom.EditValue != DBNull.Value)
                aorOrder.SupplierId = null;
        }

        private void txtSupplierCodeTo_EditValueChanged(object sender, EventArgs e)
        {
            //ddlCompany.EditValue = null;
            if (txtSupplierCodeTo.EditValue != string.Empty && txtSupplierCodeTo.EditValue != null && txtSupplierCodeTo.EditValue != DBNull.Value)
                aorOrder.SupplierId = null;
        }

        private void ddlCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (aorOrder.SupplierId != null)
            {
                aorFilters.SupplierCodeFrom = string.Empty;
                aorFilters.SupplierCodeTo = string.Empty;
            }
        }

        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            if (DataContext.EntityOrderingContext.GetEntityState(aorOrder) != System.Data.Entity.EntityState.Detached
                && aorOrder.StatusId != (byte)BL.SYS.SYS_Status.Canceled
                && aorOrder.StatusId != (byte)BL.SYS.SYS_Status.Closed
                && HasChangedEntities())
            {
                OnSaveRecord();
                ShowMessage("Auto Save Complete", 2000);
            }
        }

        private void grvOrderItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colOrderAmount)
            {
                (grvOrderItems.GetFocusedRow() as DB.AOR_OrderLine).Total = (grvOrderItems.GetFocusedRow() as DB.AOR_OrderLine).OrderAmount * (grvOrderItems.GetFocusedRow() as DB.AOR_OrderLine).UnitCost;
            }
        }

        private void rgItems_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToByte(rgItems.EditValue) == (byte)ItemsFilter.All)
            {
                lcgSalesFilter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lcgSalesFilter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        public enum WarehouseFilter
        {
            All = 0,
            Current = 1
        }

        public enum ItemsFilter
        {
            All = 0,
            RecommendedReorder = 1
        }

        public enum SalesFilter
        {
            NotApplicable = 0,
            MonthSales3 = 1,
            MonthSales6 = 2,
            MonthSales12 = 3
        }

        public class AutomaticOrderingFilters : INotifyPropertyChanged
        {
            String supplierCodeFrom;
            String supplierCodeTo;

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }

            public String SupplierCodeFrom
            {
                get { return supplierCodeFrom; }
                set
                {
                    if (value != this.supplierCodeFrom)
                    {
                        this.supplierCodeFrom = value;
                        NotifyPropertyChanged("SupplierCodeFrom");
                    }
                }
            }
            public String SupplierCodeTo
            {
                get { return supplierCodeTo; }
                set
                {
                    if (value != this.supplierCodeTo)
                    {
                        this.supplierCodeTo = value;
                        NotifyPropertyChanged("SupplierCodeTo");
                    }
                }
            }
        }

        private void btnOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            { 
                DialogResult result = Essential.DocumentAlert.ShowAlert("Create purchase orders", "Do you want to create Purchase orders for the selected stock items?", Essential.DocumentAlert.Buttons.SaveAndPrint);
           
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    string message = "";

                    switch (result)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            SaveSuccessful();
                            message = BL.ApplicationDataContext.Instance.Service.GenerateOrder(aorOrder.Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value);
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            SaveSuccessful();
                            message = BL.ApplicationDataContext.Instance.Service.GenerateOrder(aorOrder.Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, 0);
                            break;
                    } 

                    if (message.StartsWith("Success"))
                    {
                        aorOrder.StatusId = (byte)BL.SYS.SYS_Status.Closed;
                        SaveSuccessful();

                        var returns = message.Split(new string[] { "Success" }, System.StringSplitOptions.RemoveEmptyEntries)[0].Split(';');
                        foreach (string document in returns)
                        {
                            if (document == string.Empty)
                                continue;

                            //Normal Document number
                            if (document.Split(',')[0] != null)
                            {
                                ShowNotification("Document Saved", String.Format("{0} number {1} was saved successfully", this.Text, document.Split(',')[0]), 5000, false, null);
                            }

                            //Tracking number
                            if (document.Split(',')[1] != null)
                            {
                                ShowNotification("Document Saved", String.Format("{0} number {1} was saved successfully", "Tracking", document.Split(',')[1]), 5000, false, null);
                            }
                        }

                        //Werner: Because the Entities are sent to the Service the are disjoint from the context and the Reject Changes cannot be checked
                        //I am making the assumption that when the service returns Success there will not be any further changes to the document
                        //YOU SHOULD NOT BE ABLE TO EDIT ANY DOCUMENT SO I CAN MAKE THIS ASSUMPTION
                        ForceClose = true;
                        string stringHandle = Handle.ToString();
                        foreach (System.IO.FileInfo file in (new System.IO.DirectoryInfo(Environment.CurrentDirectory + @"\Recovery")).GetFiles().Where(n => n.Name.StartsWith(stringHandle)))
                        {
                            file.Delete();
                        }
                        AllowSave = false;
                        ReadOnly = true;
                        Close();
                    }
                    else if (message != string.Empty)
                    { 
                    } 
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                CurrentException = ex; 
            }

        
        }
    }
}

