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
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace CDS.Client.Desktop.Core.Site
{
    public partial class SiteForm : CDS.Client.Desktop.Essential.BaseForm
    {
        Int64 SiteId = -1;
        public SiteForm()
        {
            InitializeComponent();

            
        }

        public SiteForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
            SiteId = id;
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                //TODO : Add security for Site
                //AllowSave = BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SYSE02); 
                ServerModeSourcePrinter.QueryableSource = DataContext.ReadonlyContext.VW_Printer; 
                tcgItems.SelectedTabPage = tabGeneral;
                tcgItems.SelectedTabPage = tabServerSettings;
                tcgItems.SelectedTabPage = tabTransactions;
                tcgItems.SelectedTabPage = tabStock;
                tcgItems.SelectedTabPage = tabAccounting;
                tcgItems.SelectedTabPage = tabIdentity; 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            try
            {
                base.BindData();
                BindingSource.DataSource = (DB.SYS_Site)BindingSource.DataSource;
                BindingSourceEntity.DataSource = ((DB.SYS_Site)BindingSource.DataSource).SYS_Entity;
                BindingSourceBillingAddress.DataSource = ((DB.SYS_Site)BindingSource.DataSource).SYS_Address_BillingAddress;
                BindingSourceShippingAddress.DataSource = ((DB.SYS_Site)BindingSource.DataSource).SYS_Address_ShippingAddress;
                
                
                BindingSourcePaymentAccounts.DataSource = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(((DB.SYS_Site)BindingSource.DataSource).PaymentAccounts, typeof(List<BL.GLX.PaymentAccount>));
                
                BindingSourceNegativeDiscount.Add(new NegativeDiscountEffect() { Id = 0, Name = "Unit Price" });
                BindingSourceNegativeDiscount.Add(new NegativeDiscountEffect() { Id = 1, Name = "Unit Cost" });
                BindingSourceNegativeDiscount.Add(new NegativeDiscountEffect() { Id = 2, Name = "Unit Average" });
                string[] updateTime = ((DB.SYS_Site)BindingSource.DataSource).UpdateCheckTime.Split(',');
                teUpdateCheckTime.Time = DateTime.Parse(String.Format("0001-01-01 {0}:{1}:{2}", updateTime[0], updateTime[1], updateTime[2]));
                ddlSafetyStockPeriod.Properties.DataSource = Enum.GetNames(typeof(BL.SYS.SYS_SafetyStockPeriod));
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
                BindingSource.DataSource = BL.SYS.SYS_Site.New;
                //No accounts if new site
                //(BindingSource.DataSource as DB.SYS_Site).PaymentAccounts = BL.ApplicationDataContext.Instance.CompanySite.PaymentAccounts;
                //(BindingSource.DataSource as DB.SYS_Site).VatPercentage = BL.ApplicationDataContext.Instance.CompanySite.VatPercentage;
                
                ddlSafetyStockPeriod.EditValue = Enum.GetName(typeof(BL.SYS.SYS_SafetyStockPeriod), (byte)BL.SYS.SYS_SafetyStockPeriod.Weeks);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void OpenRecord(Int64 Id)
        { 
            try
            {
                //DB.SYS_Site sysSite = Context.SYS_Site.FirstOrDefault(n => n.Id == (int)Id);
                DB.SYS_Site sysSite = BL.SYS.SYS_Site.LoadByEntityId(Id, DataContext, new List<String>() { "SYS_Entity", "SYS_Address_BillingAddress", "SYS_Address_ShippingAddress", "SYS_Printer_Barcode", "SYS_Printer_Picker", "SYS_Printer_Receipt" });
                BindingSource.DataSource = sysSite;
                BindingSourcePaymentAccounts.DataSource = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(((DB.SYS_Site)BindingSource.DataSource).PaymentAccounts, typeof(List<BL.GLX.PaymentAccount>));
                ddlSafetyStockPeriod.EditValue = Enum.GetName(typeof(BL.SYS.SYS_SafetyStockPeriod), ((DB.SYS_Site)BindingSource.DataSource).SafetyStockPeriod);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void OpenRecord(DB.SYS_Site siteCopy)
        {
            try
            {
                BindingSource.DataSource = siteCopy;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void Archive()
        {
            base.Archive();
            DB.SYS_Entity entity = (DB.SYS_Entity)BindingSourceEntity.DataSource;
            entity.Archived = !entity.Archived;
            btnArchive.Caption = entity.Archived ? "Un-Archive" : "Archive";
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

                    try
                    {
                        ((DB.SYS_Site)BindingSource.DataSource).UpdateCheckTime = String.Format("{0},{1},{2}", teUpdateCheckTime.Time.Hour, teUpdateCheckTime.Time.Minute, teUpdateCheckTime.Time.Second);
                        ((DB.SYS_Site)BindingSource.DataSource).PaymentAccounts = BL.GLX.PaymentAccountSerializer.SerializePaymentAccounts(((List<BL.GLX.PaymentAccount>)BindingSourcePaymentAccounts.DataSource).Where(n => n.AccountId != 0).ToList());
                        ((DB.SYS_Site)BindingSource.DataSource).SafetyStockPeriod = (byte)Enum.Parse(typeof(BL.SYS.SYS_SafetyStockPeriod), Convert.ToString(ddlSafetyStockPeriod.EditValue));
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            bool isNew = DataContext.EntitySystemContext.GetEntityState((DB.SYS_Site)BindingSource.DataSource) == System.Data.Entity.EntityState.Detached;
                            BL.EntityController.SaveSYS_Site(((DB.SYS_Site)BindingSource.DataSource), DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                if (isNew)
                                {
                                   
                                    BL.ITM.ITM_Inventory.GenerateSiteInventory(((DB.SYS_Site)BindingSource.DataSource).EntityId, DataContext);
                                    //throw new Exception("");
                                    DataContext.EntityInventoryContext.SaveChanges();
                                }
                            }
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        DataContext.EntityInventoryContext.AcceptAllChanges();
                        
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        DataContext.EntityInventoryContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                CurrentException = ex;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();

            IsValid = ValidateBeforeSave();
        }

        /// <summary>
        /// Loads and opens the next Role record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 23/07/2012</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                DB.SYS_Site sysSite = BL.SYS.SYS_Site.GetNextItem((DB.SYS_Site)BindingSource.DataSource, DataContext);
                if (sysSite != null)
                {
                    BindingSource.DataSource = sysSite; 
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous Role record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 23/07/2012</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();


                DB.SYS_Site sysSite = BL.SYS.SYS_Site.GetPreviousItem((DB.SYS_Site)BindingSource.DataSource, DataContext);
                if (sysSite != null)
                {
                    BindingSource.DataSource = sysSite; 
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
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSIREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSIRECR);
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                 bool isValid = true;
                 isValid = IsCodeValid();
                 return isValid; 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void XPOPreBindDataFilter()
        {
            base.XPOPreBindDataFilter();
            XPInstantFeedbackSourceBuyoutSupplierAccount.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[TypeId.Id] = ?", (byte)BL.ORG.ORG_Type.Supplier);
             
            ddlBuyoutSupplierAccount.Properties.DataSource = XPInstantFeedbackSourceBuyoutSupplierAccount;
        }

        /// <summary>
        /// Checks if Code exists.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 23/05/2012</remarks>
        private bool IsCodeValid()
        {
            try
            {
                bool isValid = true;
                //if (DataContext.GetEntityState((DB.SEC_Role)BindingSource.DataSource) == System.Data.Entity.EntityState.Detached && Context.SEC_Role.Where(n => n.Code == txtCode.Text).Count() != 0)
                //{
                //    BaseAlert.ShowAlert("Duplicate Code", "The code you have entered aready exists please enter another Code.", BaseAlert.Buttons.Ok, BaseAlert.Icons.Error);
                //    isValid = false;
                //}

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        public class NegativeDiscountEffect
        {
            public byte Id { get; set; }
            public string Name { get; set; }
        }

        private void grvPaymentAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                if (Essential.BaseAlert.ShowAlert("Delete Line", "You are about to delete the seleced line do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                    grvPaymentAccount.DeleteSelectedRows();
            }
        }

        private void grvPaymentAccount_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (colAccountDefault == e.Column)
            {
                BL.GLX.PaymentAccount currentRow = (BL.GLX.PaymentAccount)grvPaymentAccount.GetFocusedRow();
               
                //If there is now account selected you cant set it to the Default account
                if (currentRow.AccountId == 0)
                {
                    currentRow.AccountDefault = false;
                    return;
                }
                    //If you are unticking the Default account it will be undone
                else if (!((List<BL.GLX.PaymentAccount>)BindingSourcePaymentAccounts.DataSource).Any(n => n.AccountDefault))
                {
                    currentRow.AccountDefault = true;                   
                }
                else
                {
                    Parallel.ForEach((List<BL.GLX.PaymentAccount>)BindingSourcePaymentAccounts.DataSource, account =>
                    //foreach (Essential.UTL.PaymentAccount account in (List<CDS.Client.Desktop.Essential.UTL.PaymentAccount>)BindingSourcePaymentAccounts.DataSource)
                    {
                        account.AccountDefault = false;
                    }
                    );
                    currentRow.AccountDefault = true;
                }   

                grdPaymentAccount.RefreshDataSource();
            }
        }

        private void grvPaymentAccount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void grvPaymentAccount_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void InstantFeedbackSourceAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.SiteId == SiteId);
        }

        private void InstantFeedbackSourceTaxAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Tax;
        } 
    }
}
