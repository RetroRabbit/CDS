using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.Xpo;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.Desktop.Stock.Inventory
{
    public partial class InventoryForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.SYS_Entity sysInventoryEntity;
        DB.ITM_Inventory itmInventory;
        DB.ITM_History itmHistory;
        List<DB.ITM_InventorySupplier> itmInventorySupplier = new List<DB.ITM_InventorySupplier>();
        List<DB.ITM_Surcharge> itmSurcharge = new List<DB.ITM_Surcharge>();
        long? defaultSiteId;
        bool fromBuyout = false;
        bool FromBuyout { get { return fromBuyout; } set { fromBuyout = value; } }

        /// <summary>
        /// Boolean that returns true if Stock Item has never been submited to the database (Is a new Stock Item)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (itmInventory != null)
                    return (DataContext.EntityInventoryContext.GetEntityState(itmInventory) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public bool ShowTransaction {
            get;
            set;
        }

        private bool HasNoHoldingValues()
        {
            List<Int64> sites = DataContext.EntitySystemContext.SYS_Entity.Where(n => n.TypeId == (byte)BL.SYS.SYS_Type.Site).Select(n => n.Id).ToList();
            Int64 periodId = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext).Id;

            bool isValid = true;

            foreach (var history in DataContext.EntityInventoryContext.ITM_History.Where(n => n.InventoryId == itmInventory.EntityId && n.PeriodId == periodId))
            {
                if (history.OnHand != 0 | history.OnOrder != 0 | history.OnReserve != 0)
                {
                    isValid = !isValid;
                    break;
                }
            }

            return isValid;
        }

        private bool HideActionButtons
        {
            set
            {
                AllowRefresh = false;
                btnGenerateBarcode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private bool OrderingTabSelected
        {
            get { return tcgCategories.SelectedTabPage == tabOrdering; }
            set
            {
                if (value)
                {
                    AllowRefresh = false;
                    btnGenerateBarcode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    AllowRefresh = false;
                    btnGenerateBarcode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        private bool TransactionsTabSelected
        {
            get { return tcgCategories.SelectedTabPage == tabTransactions; }
            set
            {
                if (value)
                {
                    AllowRefresh = true;
                    btnGenerateBarcode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    AllowRefresh = false;
                    btnGenerateBarcode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        /// <summary>
        /// Checks that below conditions are valid.
        /// * Has Valid Suppliers
        /// *  
        /// *  
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 06/03/2012</remarks>
        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;

                bool isValid = true;
                isValid = IsSuppliersValid() && IsCodeValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsCodeValid()
        {
            bool isValid = true;
            isValid = !DataContext.ReadonlyContext.VW_LineItem.Any(n => n.Name == sysInventoryEntity.Name && n.Id != sysInventoryEntity.Id);
            if (!isValid)
            {
                Essential.BaseAlert.ShowAlert("Invalid Code", "This item code already exists please check Inventory List for stock code \"" + sysInventoryEntity.Name + "\"", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                txtCode.ErrorText = "Duplicate Code not allowed";
            }
            else
            {
                txtCode.ErrorText = String.Empty;
            }
            return isValid;
        }

        private bool IsSuppliersValid()
        {
            bool isValid = true;
            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ORG && n.Code == "YES"))
            {
                isValid = (itmInventorySupplier != null && itmInventorySupplier.Where(n => n.PrimarySupplier == true).Count() == 1);
                if (!isValid)
                {
                    Essential.BaseAlert.ShowAlert("Invalid Suppliers", "Mark at least one Supplier as Primary Supplier", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    tcgCategories.SelectedTabPage = tabOrdering;
                }
            }
            return isValid;
        }

        private bool IsProfitMarginValid()
        {
            return false;
        }

        private DateTime TransactionDate
        {
            get
            {
                if (rgMonths.EditValue == null)
                {
                    return DateTime.Today.AddDays(-10000);
                }
                else
                {
                    DateTime date = DateTime.Today.AddDays(-Convert.ToInt32(rgMonths.EditValue));
                    date = date.AddDays(DateTime.DaysInMonth(date.Year, date.Month) - date.Day);
                    return date;
                }
            }
        }

        private List<Int64> TransactionsTypes
        {
            get
            {
                List<Int64> selectedDocumentTypes = new List<Int64>();

                for (int i = 0; i < clbDocumentType.ItemCount; i++)
                {
                    if (clbDocumentType.GetItemChecked(i))
                        selectedDocumentTypes.Add((clbDocumentType.GetItem(i) as DB.SYS_DOC_Type).Id);
                }

                return selectedDocumentTypes;
            }
        }

        public InventoryForm()
        {
            InitializeComponent();
        }

        public InventoryForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            AllowSaveAndEmail = false;
            BindingSourceLabelFlag.Add(new ITM_LabelFlag("Do not print", "N"));
            BindingSourceLabelFlag.Add(new ITM_LabelFlag("Print Code", "L"));
            BindingSourceLabelFlag.Add(new ITM_LabelFlag("Print code and price", "P"));
            ServerModeSourceDocumentType.QueryableSource = DataContext.EntitySystemContext.SYS_DOC_Type;
            ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
            tcgCategories.SelectedTabPage = tabOrdering;
            tcgCategories.SelectedTabPage = tabTransactions;
            tcgCategories.SelectedTabPage = tabInformation;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            clbDocumentType.CheckAll();
            InstantFeedbackSourceTransaction.Refresh();
            InstantFeedbackSourceOutstandingOrders.Refresh();
            InstantFeedbackSourceOutstandingTransfers.Refresh();
            InstantFeedbackSourceSalesHistory.Refresh();

            if (this.ReadOnly)
            {
                foreach (DevExpress.XtraBars.BarButtonItemLink buttonLink in rpgActions.ItemLinks)
                {
                    buttonLink.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                AllowRefresh = true;
            }

            if (ShowTransaction)
            {
                lcgFilters.BeginUpdate();
                LayoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
                tcgCategories.SelectedTabPage = tabTransactions;
                clbDocumentType.Enabled = true;
                rgMonths.Enabled = true;
                rgMonths.Properties.ReadOnly = false;
                chkAllSites.Enabled = true;
                chkAllSites.Properties.ReadOnly = false;
                lcgFilters.EndUpdate();
            }

            Essential.GridFilterDefaults.ApplyStandards(new List<DevExpress.XtraGrid.Views.Grid.GridView> { grvTransactions, grvSalesHistory });
            grvTransactions.ActiveFilterString = "Not [DocumentType] In ('Sales Order', 'Quote','Job Quote', 'Purchase Order')";
            grvSalesHistory.BestFitColumns();
           // grvSuppliers.BestFitColumns();
            grvTransactions.BestFitColumns();
          
        }

        protected override void BindData()
        {
            base.BindData();
            if (IsNew)
            {
                //TODO : Fix this when documents have been added
                decimal onReserve = 0;//Context.ITM_Inventory.FirstOrDefault(n => n.Id == itm_inventory.Id).SYS_Entity.SYS_DOC_Header.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.BackOrder).Select(l=>l.SYS_DOC_Line).Sum(n => n.Quantity);
                decimal taxAmount = Math.Round(itmHistory.UnitPrice * (BL.ApplicationDataContext.Instance.CompanySite.VatPercentage / 100M), 2, MidpointRounding.AwayFromZero);

                decimal normalProfitPercentage = 0;
                decimal normalProfitAmount = 0;

                normalProfitAmount = (itmHistory.UnitPrice - itmHistory.UnitAverage);

                if (itmHistory.UnitPrice > 0)
                    normalProfitPercentage = (normalProfitAmount / itmHistory.UnitPrice) * 100M;

                txtOnReserve.Text = onReserve.ToString();
                txtAvailable.Text = (itmHistory.OnHand - onReserve).ToString();

                txtTaxAmount.Text = taxAmount.ToString();
                txtUnitPriceIncl.Text = (itmHistory.UnitPrice + taxAmount).ToString();

                txtNormalProfitPercentage.Text = normalProfitPercentage.ToString();
                txtNormalProfit.Text = normalProfitAmount.ToString();
            }

            BindingSource.DataSource = itmInventory;
            BindingSourceEntity.DataSource = sysInventoryEntity;
            BindingSourceHistory.DataSource = itmHistory; 
            BindingSourceInventorySupplier.DataSource = itmInventorySupplier;
            BindingSourceInventorySurcharge.DataSource = itmSurcharge;
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            AllowArchive = false;
            AllowRefresh = false;
            itmInventory = BL.ITM.ITM_Inventory.New;
            sysInventoryEntity = BL.SYS.SYS_Entity.NewInventory;
            itmHistory = BL.ITM.ITM_History.New;
            itmHistory.PeriodId = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext).Id;
            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
            {
                itmInventory.InventoryId = BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                itmInventory.CostofSalesId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId; 
            }
            txtName.Properties.ReadOnly = false;
            txtName.BackColor = Color.White;
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            AllowRefresh = true;
            itmInventory = BL.ITM.ITM_Inventory.Load(Id, DataContext);
            sysInventoryEntity = BL.SYS.SYS_Entity.Load(itmInventory.EntityId, DataContext);
            itmHistory = BL.ITM.ITM_History.GetItemCurrentHistory(itmInventory, DataContext);
             
            foreach (var item in BL.ITM.ITM_Surcharge.LoadByEntityId(sysInventoryEntity.Id, DataContext))
            {
                itmSurcharge.Add(item);
            }

            foreach (var item in BL.ITM.ITM_InventorySupplier.LoadByEntityId(sysInventoryEntity.Id, DataContext))
            {
                itmInventorySupplier.Add(item);
            }
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    if (!IsValid)
                        return false;

                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    { 
                        //Passthrough current History for price updates
                        ((DB.ITM_Inventory)BindingSource.DataSource).CurrentHolding = (DB.ITM_History)BindingSourceHistory.DataSource;
                        BL.EntityController.SaveSYS_Entity((DB.SYS_Entity)BindingSourceEntity.DataSource, DataContext);
                        DataContext.SaveChangesEntitySystemContext();
                        //Added new Suppliers
                        foreach (var supplier in itmInventorySupplier)
                        {
                            if (DataContext.EntityInventoryContext.GetEntityState(supplier) == System.Data.Entity.EntityState.Detached)
                            {
                                supplier.InventoryId = ((DB.SYS_Entity)BindingSourceEntity.DataSource).Id;
                                BL.EntityController.SaveITM_InventorySupplier(supplier,DataContext);
                            }
                        }
                        //Added new Surcharge
                        foreach (var surcharge in itmSurcharge)
                        {
                            if (DataContext.EntityInventoryContext.GetEntityState(surcharge) == System.Data.Entity.EntityState.Detached)
                            {
                                surcharge.EntityId = ((DB.SYS_Entity)BindingSourceEntity.DataSource).Id;
                                BL.EntityController.SaveITM_Surcharge(surcharge, DataContext);
                            }
                        }
                        ((DB.ITM_Inventory)BindingSource.DataSource).EntityId = ((DB.SYS_Entity)BindingSourceEntity.DataSource).Id;
                        //if (itmInventory.CurrentHolding.UnitAverage != 0 && itmInventory.ProfitMargin > 0)
                        //{
                        //    if (itmInventory.CurrentHolding.UnitAverage / ((100.00M - (decimal)itmInventory.ProfitMargin.Value) / 100.00M) > itmInventory.CurrentHolding.UnitPrice)
                        //        itmInventory.CurrentHolding.UnitPrice = Math.Round(itmInventory.CurrentHolding.UnitAverage / ((100.00M - (decimal)itmInventory.ProfitMargin.Value) / 100.00M),2);
                        //}

                        ((DB.ITM_Inventory)BindingSource.DataSource).FromBuyout = FromBuyout;
                        ((DB.ITM_Inventory)BindingSource.DataSource).SiteId = Convert.ToInt64(BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSite.EntityId);
                        BL.EntityController.SaveITM_Inventory((DB.ITM_Inventory)BindingSource.DataSource, DataContext);

                        //Need to clear datasource because it is marked as HasChanges 
                        //and this is never realy used or saved
                        DataContext.SaveChangesEntityInventoryContext();
                        DataContext.SaveChangesEntityAccountingContext();
                        DataContext.SaveChangesEntitySystemContext();
                        //DataContext.SaveChangesEntitySystemContext();
                        ((DB.ITM_History)BindingSourceHistory.DataSource).HasChanges = false;
                        ((DB.ITM_Inventory)BindingSource.DataSource).HasChanges = false;
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityInventoryContext.AcceptAllChanges();
                    DataContext.EntityAccountingContext.AcceptAllChanges();
                    DataContext.EntitySystemContext.AcceptAllChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                DataContext.EntityInventoryContext.RejectChanges();
                DataContext.EntitySystemContext.RejectChanges();
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        protected override void OnNextRecord()
        {
            base.OnNextRecord();
        }

        protected override void OnPreviousRecord()
        {
            base.OnPreviousRecord();
        }

        protected override void Archive()
        {
            try
            {
                base.Archive();

                var entity = DataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.Id == itmInventory.EntityId);

                switch (entity.Archived)
                {
                    //If currently Archived
                    case true:
                        entity.Archived = !entity.Archived;
                        DataContext.EntitySystemContext.SaveChanges();
                        break;
                    case false:
                        if (HasNoHoldingValues())
                        {
                            entity.Archived = !entity.Archived;
                            DataContext.EntitySystemContext.SaveChanges();
                        }
                        else
                        {
                            Essential.BaseAlert.ShowAlert("Archive", "Holding values not euqal to Zero cannot Archive", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        }
                        break;
                }
                btnArchive.Caption = entity.Archived ? "Un-Archive" : "Archive";
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }            
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE01));
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSTREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSTRECR);

            //If you have access to the Item Module
            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
            {
                if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INDOADRECR))
                {
                    //Make button visible
                    btnChangeAverageCost.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    //If there is nothing on hand or there is a quantity on reserve make button invisible
                    if ((((DB.ITM_History)BindingSourceHistory.DataSource).OnHand == 0 || ((DB.ITM_History)BindingSourceHistory.DataSource).OnReserve != 0))
                    {
                        btnChangeAverageCost.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
                else
                {
                    btnChangeAverageCost.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            //Make invisible when you do not have access to view cost price
            itmAverageCost.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSTRE03) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            //Change Archive button text dependant on Entity Archive State
            if (itmInventory.EntityId != 0)
                btnArchive.Caption = DataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => n.Id == itmInventory.EntityId).Archived ? "Un-Archive" : "Archive";

            if (IsNew)
            {
                //If this is a new item do not show Change Average Cost Button
                btnChangeAverageCost.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //If this is a new item do not show History Tab
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //If this is a new item do not show Archive
                btnArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //If this is a new item do not show Query Suppliers
                btnQuerySuppliers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            
        }
   
        public override void RefreshRecord()
        {
            base.RefreshRecord();
            if (chkAllSites.CheckState == CheckState.Unchecked)
            {
                colTransactionSiteName.Visible = false;
            }
            else
            {
                colTransactionSiteName.Visible = true;
            }

            DataContext.EntityInventoryContext.ReloadEntry(itmInventory);
            DataContext.EntitySystemContext.ReloadEntry(sysInventoryEntity);
            itmHistory = BL.ITM.ITM_History.GetItemCurrentHistory(itmInventory, DataContext);
            DataContext.EntityInventoryContext.ReloadEntry(itmHistory);
            InstantFeedbackSourceTransaction = new DevExpress.Data.Linq.LinqInstantFeedbackSource(InstantFeedbackSourceTransaction_GetQueryable);
            grdTransactions.DataSource = InstantFeedbackSourceTransaction;
            grvTransactions.RefreshData();
            InstantFeedbackSourceTransaction.Refresh();
            InstantFeedbackSourceOutstandingOrders.Refresh();
            InstantFeedbackSourceOutstandingTransfers.Refresh();
            InstantFeedbackSourceSalesHistory.Refresh();
        }

        protected override void XPOPostBindDataFilter()
        {
            base.XPOPostBindDataFilter();
            XPInstantFeedbackSourceHistory.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[InventoryId.Id] = ? and [PeriodId.StartDate] < ? AND [SiteId.Id] = ?", sysInventoryEntity.Id, BL.ApplicationDataContext.Instance.ServerDateTime, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        private decimal CalculateUnitPricefromProfitMargin(double profitMargin)
        {
            if (itmInventory.ProfitMargin.HasValue)
                return Convert.ToDecimal(Math.Round((double)itmHistory.UnitAverage / ((100.00 - profitMargin) / 100.00), 2));
            else
                return itmHistory.UnitPrice;
        }

        private void btnQuerySupplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tcgCategories.SelectedTabPage = tabOrdering;
        }   

        private void grvSuppliers_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private void grdSuppliers_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void grvSuppliers_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (colPrimarySupplier == e.Column)
            {
                DB.ITM_InventorySupplier currentRow = (DB.ITM_InventorySupplier)grvSuppliers.GetFocusedRow();
                if (currentRow == null)
                    return;

                //If you clikced on the current Primary Supplier
                if (!currentRow.PrimarySupplier.Value && itmInventorySupplier.Where(n => n.PrimarySupplier == true).Count() == 1)
                    currentRow.PrimarySupplier = true;
                else
                {
                    itmInventorySupplier.ForEach(n => n.PrimarySupplier = false);
                    currentRow.PrimarySupplier = Convert.ToBoolean(e.Value);
                }

                grdSuppliers.RefreshDataSource();
            }
        }

        private void repPrimarySupplier_CheckedChanged(object sender, EventArgs e)
        {
            if ((grvSuppliers.GetFocusedRow() as DB.ITM_InventorySupplier).SupplierId == 0)
            {
                grvSuppliers.SetFocusedValue(false);
                return;
            }

            if (Convert.ToBoolean((grvSuppliers.GetFocusedRow() as DB.ITM_InventorySupplier).PrimarySupplier))
            {
                grvSuppliers.SetFocusedValue(true);
            }
            else
            {
                foreach (var item in itmInventorySupplier)
                {
                    if (item != (grvSuppliers.GetFocusedRow() as DB.ITM_InventorySupplier))
                    {
                        item.PrimarySupplier = false;
                    }
                }
                grvSuppliers.SetFocusedValue(true);
                grvSuppliers.RefreshRow(grvSuppliers.FocusedRowHandle);
            }

        }

        private void tcCategories_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            //Always do the = true one last
            if (e.Page == tabInformation)
            {
               // HideActionButtons = true;
            }
            else if (e.Page == tabOrdering)
            {
               // HideActionButtons = true;
               // OrderingTabSelected = true;
            }
            else if (e.Page == tabWarehouses)
            {
               // HideActionButtons = true;
            }
            else if (e.Page == tabTransactions)
            {
              //  HideActionButtons = true;
              //  TransactionsTabSelected = true;
            }
            else if (e.Page == tabHistory)
            {
              //  HideActionButtons = true;
            }
        }

        private void btnGenerateBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Need to do this so that if the user just removed the Barcode but did not deselect the text box 
                //it will lose focus and change the bound property value 
                ValidateLayout();
                if (itmInventory.Barcode == null || itmInventory.Barcode.Length == 0)
                {
                    itmInventory.Barcode = BL.ITM.ITM_Inventory.GenerateBarcode(DataContext);
                }
                tcgCategories.SelectedTabPage = tabInformation;
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
           
        }

        private void grvSuppliers_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (grvSuppliers.GetFocusedRow() != null)
            {
                if (grvSuppliers.FocusedColumn == colSupplierId)
                {
                    (grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier).SupplierId = Convert.ToInt64(grvSuppliers.ActiveEditor.EditValue);
                    (grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier).SupplierStockCode = ((DB.SYS_Entity)BindingSourceEntity.DataSource).Name;
                    (grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier).LeadTime = 0;
                    (grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier).PackSize = 1;
                    (grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier).MinimumOrderLevel = 0;
                    (grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier).MaximumOrderLevel = 0;
                    (grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier).PrimarySupplier = itmInventorySupplier.Count == 1;
                }
                grvSuppliers.RefreshData();
            }
        }

        private void cbDocumentType_VisibleChanged(object sender, EventArgs e)
        {
            if (clbDocumentType.Visible && clbDocumentType.CheckedItemsCount == 0)
            {

            }
        }

        private void InstantFeedbackSourceTransaction_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Transaction.Where(n => n.EntityId == itmInventory.EntityId && n.CreatedOn >= TransactionDate && n.SiteId == defaultSiteId);
        }

        private void InstantFeedbackSourceSalesHistory_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            DB.SYS_Period currentPeriod = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext);
            DateTime dateAfter = DateTime.Today.AddYears(-2);
            e.QueryableSource = DataContext.ReadonlyContext.VW_ItemHistory.Where(n => n.EntityId == itmInventory.EntityId && n.Date > dateAfter && n.Date <= currentPeriod.EndDate && n.SiteId == defaultSiteId);
        } 

        private void InstantFeedbackSourceOutstandingOrders_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_OutstandingOrders.Where(n => n.EntityId == itmInventory.EntityId && n.SiteId == defaultSiteId);
        }

        private void InstantFeedbackSourceOutstandingTransfers_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            //TODO : Need to implement this again once we have the new Multiple Sites concept
            e.QueryableSource = DataContext.ReadonlyContext.VW_OutstandingTransfers.Where(n => n.EntityId == itmInventory.EntityId && n.SiteId == defaultSiteId);
        }

        private void grvSuppliers_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvSuppliers.FocusedColumn != colSupplierId && Convert.ToInt64(grvSuppliers.GetFocusedRowCellValue(colSupplierId)) == 0)
                e.Cancel = true;
        }

        private void grvSalesHistory_DoubleClick(object sender, EventArgs e)
        {

        }

        private void grvTransactions_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRow() is DevExpress.Data.NotLoadedObject)
                return;

            ShowDocumentForm(
            (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(grvTransactions.GetFocusedRow())).OriginalRow as DB.VW_Transaction).DocumentId.Value,
                (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(grvTransactions.GetFocusedRow())).OriginalRow as DB.VW_Transaction).TypeId.Value);

        }

        private void grvOutstandingOrders_DoubleClick(object sender, EventArgs e)
        {
            ShowDocumentForm(
             (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(grvOutstandingOrders.GetFocusedRow())).OriginalRow as DB.VW_OutstandingOrders).Id.Value,
                 (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder);

        }

        private void btnChangeAverageCost_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ChangeAverageCostDialogue dialogue = new ChangeAverageCostDialogue(itmInventory.EntityId))
            {
                if (dialogue.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
        }

        private void InstantFeedbackSourceSupplier_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Entity.Where(n => n.HasSupplier && !n.Archived);
        }

        private void InstantFeedbackSourceCOSAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.AccountTypeId == (byte)BL.GLX.GLX_Type.CostofSales && n.Archived == false && n.SiteId == defaultSiteId);
        }

        private void InstantFeedbackSourceInventoryAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.AccountTypeId == (byte)BL.GLX.GLX_Type.CurrentAssets && n.Archived == false  && n.SiteId == defaultSiteId);
        }

        private void grvSuppliers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                if (Essential.BaseAlert.ShowAlert("Delete Supplier", "You are about to delete the selected supplier do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    //if (DataContext.EntityInventoryContext.GetEntityState(grvSuppliers.GetFocusedRow()) == System.Data.Entity.EntityState.Unchanged)
                    {
                        BL.EntityController.Remove(DataContext.EntityInventoryContext.ITM_InventorySupplier, grvSuppliers.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_InventorySupplier);
                    }
                    grvSuppliers.DeleteSelectedRows();
                    //grvSuppliers.RefreshData();
                }
            }
        }  

        private void txtProfitMargin_EditValueChanged(object sender, EventArgs e)
        {
            ValidateLayout();
            if (itmHistory != null)
                itmHistory.UnitPrice = CalculateUnitPricefromProfitMargin(txtProfitMargin.EditValue != null ? Convert.ToDouble(txtProfitMargin.EditValue) : 0);
        }

        public partial class ITM_LabelFlag
        {
            public ITM_LabelFlag(string displayMember, string valueMember)
            {
                this.DisplayMember = displayMember;
                this.ValueMember = valueMember;
            }

            public string DisplayMember { get; set; }
            public string ValueMember { get; set; }
        }
         
        internal void CreateBuyoutItem(DB.SYS_Entity sysEntity)
        {
            FromBuyout = true;

            sysInventoryEntity = BL.SYS.SYS_Entity.Load(sysEntity.Id,DataContext);
            sysInventoryEntity.TypeId = (byte)BL.SYS.SYS_Type.Inventory;

            using (UnitOfWork uow = new UnitOfWork())
            {
                var iboTRXHeader = uow.Query<XDB.IBO_TRX_Header>().Where(n => n.EntityId.Id == sysEntity.Id).OrderByDescending(l => l.CreatedOn).Take(1).FirstOrDefault();
                itmHistory.OnHand = uow.Query<XDB.IBO_TRX_Header>().Where(n => n.EntityId.Id == sysEntity.Id).Sum(n=>n.Quantity);
                itmHistory.UnitCost = iboTRXHeader.UnitCost;
                itmHistory.UnitAverage = iboTRXHeader.UnitCost;
                itmHistory.UnitPrice = iboTRXHeader.UnitPrice;
            }
            BindData();
        }

        private void grvSurcharge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                if (Essential.BaseAlert.ShowAlert("Delete Surcharge", "You are about to remove the selected surcharge do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    BL.EntityController.Remove(DataContext.EntityInventoryContext.ITM_Surcharge, grvSurcharge.GetFocusedRow() as CDS.Client.DataAccessLayer.DB.ITM_Surcharge);
                    grvSurcharge.DeleteRow(grvSurcharge.FocusedRowHandle);
                }               
            }
        }
    }
}
