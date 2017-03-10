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

namespace CDS.Client.Desktop.Stock.Inventory
{
    public partial class InventoryList : CDS.Client.Desktop.Essential.BaseList
    { 
        public InventoryList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[EntityId.TypeId.Id] = ? AND [SiteId.Id] = ?", (byte)BL.SYS.SYS_Type.Inventory, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                InventoryForm childForm = new InventoryForm(Id);
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
                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                {
                    if (!DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier && n.Archived == false).Any())
                    {
                        Essential.BaseAlert.ShowAlert("No Suppliers Available", "Please create suppliers before creating stock items.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Warning);
                        return;
                    }
                }
                base.OnNewRecord();
                Inventory.InventoryForm childForm = new Inventory.InventoryForm();
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSTRECR);
        }

        /*
        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.ShowDialog();

                if (dlg.FileName != string.Empty)
                {
                    using (new Essential.UTL.WaitCursor())
                    {
                        using (LumenWorks.Framework.IO.Csv.CsvReader csv = new LumenWorks.Framework.IO.Csv.CsvReader(new System.IO.StreamReader(dlg.FileName), true))
                        {

                            DB.VW_Supplier defaultSupplier = DataContext.ReadonlyContext.VW_Supplier.FirstOrDefault();
                            var periodid = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext).Id;
                            var inventoryId = BL.ApplicationDataContext.Instance.SiteAccounts.Inventory.EntityId;
                            var costofSalesId = BL.ApplicationDataContext.Instance.SiteAccounts.CostOfSales.EntityId;

                            while (csv.ReadNextRecord())
                            {
                                try
                                {
                                    string tempName = csv[0];
                                    if (DataContext.ReadonlyContext.VW_Inventory.Any(n => n.Name == tempName))
                                        continue;


                                    using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
                                    {

                                        DB.ITM_Inventory itm_inventory = BL.ITM.ITM_Inventory.New;
                                        DB.SYS_Entity sys_entity = BL.SYS.SYS_Entity.NewInventory;// itm_inventory.SYS_Entity;
                                        DB.ITM_History itm_history = BL.ITM.ITM_History.New;
                                        itm_history.PeriodId = periodid;
                                        // if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                                        //{
                                        itm_inventory.InventoryId = inventoryId;
                                        itm_inventory.CostofSalesId = costofSalesId;
                                        // }

                                        //Stock Code
                                        sys_entity.Name = csv[0];
                                        //Name
                                        sys_entity.ShortName = csv[1];
                                        //Description
                                        sys_entity.Description = csv[2];
                                        //Stock Type
                                        itm_inventory.StockType = csv[3];
                                        //Category
                                        itm_inventory.Category = csv[4];
                                        //Sub Category
                                        itm_inventory.SubCategory = csv[5];
                                        //Group
                                        itm_inventory.Grouping = csv[6];
                                        //Item Location
                                        itm_inventory.LocationMain = csv[7];
                                        //Item Location 2
                                        itm_inventory.LocationSecondary = csv[8];
                                        //Discount Code
                                        itm_inventory.DiscountCode = csv[9];
                                        //Comment
                                        itm_inventory.Comment = csv[10];
                                        //Barcode
                                        itm_inventory.Barcode = csv[11];
                                        //Selling Price
                                        itm_history.UnitPrice = Convert.ToDecimal(csv[12]);
                                        //Replacement Cost
                                        itm_history.UnitCost = Convert.ToDecimal(csv[13]);
                                        //Surcharge Amount

                                        //Warehousing Cost
                                        itm_inventory.WarehousingCost = Convert.ToDecimal(csv[15] == string.Empty ? "0" : csv[15]);
                                        //Profit Margin
                                        itm_inventory.ProfitMargin = Convert.ToDouble(csv[16] == string.Empty ? "0" : csv[16]);
                                        //Minimum Stock Level
                                        itm_inventory.MinimumStockLevel = Convert.ToDecimal(csv[17] == string.Empty ? "0" : csv[17]);

                                        DB.ITM_InventorySupplier supplier = BL.ITM.ITM_InventorySupplier.New;


                                        supplier.SupplierId = defaultSupplier.Id;
                                        supplier.SupplierStockCode = (sys_entity).ShortName;
                                        supplier.LeadTime = 0;
                                        supplier.PackSize = 1;
                                        supplier.MinimumOrderLevel = 0;
                                        supplier.MaximumOrderLevel = 0;
                                        supplier.PrimarySupplier = true;

                                        itm_inventory.ITM_InventorySupplier.Add(supplier);
                                        //Passthrough current History for price updates
                                        itm_inventory.CurrentHolding = itm_history;
                                        BL.EntityController.SaveSYS_Entity(sys_entity, DataContext);
                                        DataContext.SaveChangesEntitySystemContext();
                                        itm_inventory.EntityId = (sys_entity).Id;
                                        BL.EntityController.SaveITM_Inventory(itm_inventory, DataContext);



                                        DataContext.SaveChangesEntityInventoryContext(System.Data.Entity.Core.Objects.SaveOptions.None);
                                        DataContext.SaveChangesEntitySystemContext(System.Data.Entity.Core.Objects.SaveOptions.None);
                                        DataContext.CompleteTransaction(transaction);
                                    }
                                    DataContext.EntityInventoryContext.AcceptAllChanges();
                                    DataContext.EntitySystemContext.AcceptAllChanges();

                                }
                                catch (Exception ex)
                                {
                                    DataContext.EntityInventoryContext.RejectChanges();
                                    DataContext.EntitySystemContext.RejectChanges();

                                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                                }
                            }
                        }
                    }
                }
            }
        }

        */
    }
}
