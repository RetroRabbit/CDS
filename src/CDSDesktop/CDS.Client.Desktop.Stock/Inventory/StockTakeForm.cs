using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;

namespace CDS.Client.Desktop.Stock.Inventory
{
    public partial class StockTakeForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.ITM_StockTake itmStockTake;
        long? defaultSiteId;
        public StockTakeForm()
        {
            InitializeComponent();
        }

        public StockTakeForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            AllowPrint = false;
            AllowSaveAndEmail = false;
            AllowSaveAndNew = false;

        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            itmStockTake = BL.ITM.ITM_StockTake.New;
            itmStockTake.SiteId = defaultSiteId;
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            itmStockTake = BL.ITM.ITM_StockTake.Load(Id, DataContext, new List<string>() { "ITM_StockTakeItem" });//DataContext.EntityInventoryContext.ITM_StockTake.Where(n => n.Id == Id).FirstOrDefault();
        }

        protected override void BindData()
        {
            base.BindData();

            BindingSource.DataSource = itmStockTake;

            if (((DB.ITM_StockTake)BindingSource.DataSource).StatusId == (byte)BL.ITM.ITM_StockTakeStatus.Completed)
                AllowSave = false;

            //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
               
                //THIS MUST BE BEFORE THE CASE STATEMENT
                if (itmStockTake.StatusId == (byte)BL.ITM.ITM_StockTakeStatus.Cancelled || itmStockTake.StatusId == (byte)BL.ITM.ITM_StockTakeStatus.Completed)
                {
                    ReadOnly = true;
                }

                switch (itmStockTake.StatusId)
                {
                    case (byte)BL.ITM.ITM_StockTakeStatus.New:
                        //wizStockTake.SelectedPage = wizStockTakeStart; 
                        wizStockTake.SelectedPageIndex = 0;
                        break;
                    case (byte)BL.ITM.ITM_StockTakeStatus.StocktakeCount:
                        //wizStockTake.SelectedPage = wizStockTakeQuantities; 
                        wizStockTake.SelectedPageIndex = 2;
                        break;
                    case (byte)BL.ITM.ITM_StockTakeStatus.StocktakeCountVariance:
                        //wizStockTake.SelectedPage = wizStockTakeVariance; 
                        wizStockTake.SelectedPageIndex = 3;
                        break;
                    case (byte)BL.ITM.ITM_StockTakeStatus.Cancelled:
                        //wizStockTake.SelectedPage = wizStockTakeStart; 
                        wizStockTake.SelectedPageIndex = 4;
                        break;
                    case (byte)BL.ITM.ITM_StockTakeStatus.Completed:
                        //wizStockTake.SelectedPage = wizStockTakeVariance; 
                        wizStockTake.SelectedPageIndex = 4;
                        break;
                    default:
                        //wizStockTake.SelectedPage = wizStockTakeWelcome;
                        wizStockTake.SelectedPageIndex = 4;
                        break;
                }


            }
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    if (!ReadOnly)
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            if (itmStockTake.StatusId == (byte)BL.ITM.ITM_StockTakeStatus.Completed ||
                                itmStockTake.StatusId == (byte)BL.ITM.ITM_StockTakeStatus.Cancelled)
                            {
                                itmStockTake.CompletedDate = BL.ApplicationDataContext.Instance.ServerDateTime.Date;
                            }
                            
                            BL.EntityController.SaveITM_StockTake(itmStockTake, DataContext);
                            DataContext.EntityInventoryContext.SaveChanges();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityInventoryContext.AcceptAllChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                DataContext.EntityInventoryContext.RejectChanges();
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
            if (itmStockTake.StatusId == (byte)BL.ITM.ITM_StockTakeStatus.Completed)
            {
                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        string message = string.Empty;

                        message = BL.ApplicationDataContext.Instance.Service.SaveDocument(GenerateStockTakeDocument(), 0);
                        if (!message.StartsWith("Success"))
                        {
                            Essential.BaseAlert.ShowAlert("Exception", message, Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

                            ((DB.ITM_StockTake)BindingSource.DataSource).StatusId = (byte)BL.ITM.ITM_StockTakeStatus.StocktakeCountVariance;
                        }

                        DataContext.EntityInventoryContext.SaveChanges();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityInventoryContext.AcceptAllChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    DataContext.EntityInventoryContext.RejectChanges();
                    HasErrors = true;
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }

                    return false;
                }
            }
            // TODO: Fix this screen.....
            return false;
        } 

        private DB.SYS_DOC_Header GenerateStockTakeDocument()
        {
            DB.SYS_DOC_Header sys_header = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.InventoryAdjustment);
            sys_header.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.New;
            sys_header.ORG_TRX_Header.ReferenceLong2 = ((DB.ITM_StockTake)BindingSource.DataSource).Description;
            
            foreach (DB.ITM_StockTakeItem item in ((DB.ITM_StockTake)BindingSource.DataSource).ITM_StockTakeItem)
            {
                if (item.QuantityCount2 == null)
                    item.QuantityCount2 = item.QuantityCount1;

                //DB.VW_Inventory inventory = DataContext.ReadonlyContext.VW_Inventory.FirstOrDefault(n => n.Id == item.InventoryId);
                DB.SYS_DOC_Line line = BL.SYS.SYS_DOC_Line.New;
                line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == item.InventoryId);
                line.ItemId = line.LineItem.Id;
                line.Quantity = item.QuantityCount2.Value - item.OnHand.Value;
                line.Amount = line.LineItem.UnitAverage;
                line.Total = line.Quantity * line.Amount;
                sys_header.SYS_DOC_Line.Add(line);
            }
            return sys_header;
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INSKRECR); 
        }

        private void wizStockTake_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizStockTake.SelectedPage == wizStockTakeVariance)
            {
                if (Essential.BaseAlert.ShowAlert("Complete Stock Take", "You are about to finalize the current stock take do you wish to continue ?\nPlease note that this action cannot be undone", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    itmStockTake.StatusId = (byte)BL.ITM.ITM_StockTakeStatus.Completed;
                    //TODO: Create and Save Inventory Adjustment Document
                    SaveSuccessful();
                    Close();
                }
                else 
                {
                    e.Handled = true;
                }
            }
        }

        private void wizStockTake_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
        }

        private void wizStockTake_CancelClick(object sender, CancelEventArgs e)
        {
            if (Essential.BaseAlert.ShowAlert("Complete Stock Take", " You are about to cancel the current stock take do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) == System.Windows.Forms.DialogResult.OK)
            {
                itmStockTake.StatusId = (byte)BL.ITM.ITM_StockTakeStatus.Cancelled;
                SaveSuccessful();
                Close();
            }
        }

        private void wizStockTake_FinishClick(object sender, CancelEventArgs e)
        {
            SaveSuccessful();
            Close();
        }

        private void wizStockTake_SelectedPageChanged(object sender, DevExpress.XtraWizard.WizardPageChangedEventArgs e)
        {
            if (AllowSave)
            {
                SaveSuccessful();
                OpenRecord(((DB.ITM_StockTake)BindingSource.DataSource).Id);
            }
            DB.ITM_StockTake stockTake = (DB.ITM_StockTake)BindingSource.DataSource;

            if (wizStockTake.SelectedPage == wizStockTakeWelcome)
            {
                AllowExport = false;
            }
            else if (wizStockTake.SelectedPage == wizStockTakeStart)
            {
                stockTake.StatusId = (byte)BL.ITM.ITM_StockTakeStatus.New;
                AllowExport = true;
            }
            else if (wizStockTake.SelectedPage == wizStockTakeQuantities)
            {
                if (!itmStockTake.Description.Contains("Filter : "))
                    itmStockTake.Description += " Filter : " + grvStockTakeItems.ActiveFilterString;

                if (itmStockTake.ITM_StockTakeItem.Count == 0)
                {
                    //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        List<DB.ITM_StockTakeItem> stockTakeItems = new List<DB.ITM_StockTakeItem>();
                        int dataRowCount = grvStockTakeItems.DataRowCount;

                        for (int i = 0; i < dataRowCount; i++)
                        {
                            while (grvStockTakeItems.GetRow(i) is DevExpress.Data.NotLoadedObject)
                            {
                                Application.DoEvents();
                            }

                            DB.VW_Inventory VW_Inventory = (DB.VW_Inventory)((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(grvStockTakeItems.GetRow(i))).OriginalRow;// grvStockTakeItems.GetRow(i);

                            if (VW_Inventory != null)
                            {
                                DB.ITM_StockTakeItem item = BL.ITM.ITM_StockTakeItem.New;
                                item.InventoryId = VW_Inventory.EntityId;
                                item.LineNumber = i;
                                item.OnHand = VW_Inventory.OnHand;
                                item.UnitAverage = VW_Inventory.UnitAverage;
                                item.UnitPrice = VW_Inventory.UnitPrice;
                                item.UnitCost = VW_Inventory.UnitCost;
                                stockTakeItems.Add(item);
                            }
                            else
                            {

                            }
                        }
                        foreach (DB.ITM_StockTakeItem item in stockTakeItems.OrderBy(o => o.LineNumber))
                            itmStockTake.ITM_StockTakeItem.Add(item);

                        SaveSuccessful();
                        OpenRecord(((DB.ITM_StockTake)BindingSource.DataSource).Id);
                    }
                }
                BindingSourceStockTakeItem.DataSource = itmStockTake.ITM_StockTakeItem;
                grvStockTakeQuantity.RefreshData();
                wizStockTakeQuantities.AllowBack = false;
                stockTake.StatusId = (byte)BL.ITM.ITM_StockTakeStatus.StocktakeCount;
                btnPrintCountSheet.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                AllowExport = true;
            }
            else if (wizStockTake.SelectedPage == wizStockTakeVariance)
            {
                ServerModeSourceVariance.QueryableSource = DataContext.ReadonlyContext.VW_StockTakeVariance.Where(n => n.StockTakeId == itmStockTake.Id);
                stockTake.StatusId = (byte)BL.ITM.ITM_StockTakeStatus.StocktakeCountVariance;

                wizStockTake.SelectedPage.AllowNext = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INSKRE02);

                if (!wizStockTake.SelectedPage.AllowNext)
                {
                    wizStockTakeVariance.DescriptionText = "Below shows you a detail stock variance" + Environment.NewLine +
                    "You do not have access to complete the stock take. \nPlease log in with a user that has access to finalize stock takes (INST07)." + Environment.NewLine +
                    "Close tab to save stock take at its current status";
                }
                btnPrintCountSheet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                AllowExport = true;
            }
            else if (wizStockTake.SelectedPage == wizStockTakeSummary)
            { 
                AllowExport = false;
            }
            else if (wizStockTake.SelectedPage == wizStockTakeCompleted)
            {
                AllowExport = false;
            }
            if (AllowSave)
            {
                SaveSuccessful();
                OpenRecord(((DB.ITM_StockTake)BindingSource.DataSource).Id);
            }

            if (ReadOnly)
            {
                e.Page.AllowCancel = false;
                e.Page.AllowNext = false;
                e.Page.AllowBack = false;
                btnPrintCountSheet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

        }

        private void InstantFeedbackSourceInventory_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Inventory.Where(n => !n.Archived && n.SiteId == defaultSiteId);
        }

        private void InstantFeedbackSourceRepositoryInventory_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Inventory.Where(n => !n.Archived && n.SiteId == defaultSiteId);
        }

        private void InstantFeedbackSourceVariance_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_StockTakeVariance.Where(n => n.StockTakeId == itmStockTake.Id);
        }

        private void btnPrintCountSheet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();
            parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() { Name = "StockTakeId", Value = itmStockTake.Id });

            ShowReport("Stock Take First Count", parameters);
        }

        private void btnSecondCount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var parameters = new DevExpress.XtraReports.Parameters.ParameterCollection();
            parameters.Add(new DevExpress.XtraReports.Parameters.Parameter() {Name = "StockTakeId",Value = itmStockTake.Id});

            ShowReport("Stock Take Second Count", parameters);
        }
         
    }
}

