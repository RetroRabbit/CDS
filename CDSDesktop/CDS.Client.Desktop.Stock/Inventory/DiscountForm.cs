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


namespace CDS.Client.Desktop.Stock.Inventory
{
    public partial class DiscountForm : CDS.Client.Desktop.Essential.BaseForm
    {
        long? defaultSiteId;
        public DiscountForm()
        {
            InitializeComponent();
        }

        public DiscountForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            DataContext.ReadonlyContext.VW_Company.Where(n => n.Archived == false 
                && (n.TypeId == (byte)BL.ORG.ORG_Type.Customer) 
                && n.DiscountCode != null).Select(l => l.DiscountCode).Distinct().ToList().ForEach(n => txtCompanyDiscountCode.Properties.Items.Add(n));

            DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false 
                && n.TypeId == (byte)BL.SYS.SYS_Type.Inventory
                && n.DiscountCode != null).Select(l => l.DiscountCode).Distinct().ToList().ForEach(n => txtInventoryDiscountCode.Properties.Items.Add(n));
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                BindingSource.DataSource = BL.ITM.ITM_DIS_Discount.New;
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void OpenRecord(long Id)
        {
            try
            {
                base.OpenRecord(Id);

                BindingSource.DataSource = BL.ITM.ITM_DIS_Discount.Load(Id, DataContext);

                rgDiscountType.SelectedIndex = ((DB.ITM_DIS_Discount)BindingSource.DataSource).DiscountAmountTypeId.Value - 1;
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; } 
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

                    DB.ITM_DIS_Discount ITM_DIS_Discount = ((DB.ITM_DIS_Discount)BindingSource.DataSource);
                    ITM_DIS_Discount.DiscountAmountTypeId = Convert.ToByte(rgDiscountType.EditValue);
                    //1	STOCK CODE vs ACCOUNT NUMBER
                    if (ITM_DIS_Discount.InventoryId != null && ITM_DIS_Discount.EntityId != null)
                        ITM_DIS_Discount.DiscountTypeId = (byte)BL.ITM.ITM_DIS_Type.StockCodevsAccountNumber;
                    //2	STOCK CODE vs ACCOUNT Discount CODE
                    else if (ITM_DIS_Discount.InventoryId != null && ITM_DIS_Discount.CompanyDiscountCode != null)
                        ITM_DIS_Discount.DiscountTypeId = (byte)BL.ITM.ITM_DIS_Type.StockCodevsAccountDiscountCode;
                    //3	STOCK Discount CODE vs ACCOUNT NUMBER
                    else if (ITM_DIS_Discount.InventoryDiscountCode != null && ITM_DIS_Discount.EntityId != null)
                        ITM_DIS_Discount.DiscountTypeId = (byte)BL.ITM.ITM_DIS_Type.StockDiscountCodevsAccountNumber;
                    //4	STOCK Discount CODE vs ACCOUNT Discount CODE
                    else if (ITM_DIS_Discount.InventoryDiscountCode != null && ITM_DIS_Discount.CompanyDiscountCode != null)
                        ITM_DIS_Discount.DiscountTypeId = (byte)BL.ITM.ITM_DIS_Type.StockDiscountCodevsAccountDiscountCode;

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveITM_DIS_Discount((DB.ITM_DIS_Discount)BindingSource.DataSource, DataContext);
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
            }
            catch (Exception ex)
            {
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

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INDIREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INDIRECR);
        }

        /// <summary>
        /// Checks that below conditions are valid.
        /// * Code Main doen not exist
        /// * Code Sub does not exist
        /// * Type for control account has been selected
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
                isValid = IsDiscountValid() & IsCustomerValueValid() & IsInventoryValueValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsDiscountValid()
        {
            bool isValid = true;
            DB.ITM_DIS_Discount ITM_DIS_Discount = ((DB.ITM_DIS_Discount)BindingSource.DataSource);

            if (ITM_DIS_Discount.CompanyDiscount != null || ITM_DIS_Discount.WorkshopDiscount != null)
            {
                txtCompanyDiscount.ErrorText = String.Empty;
                txtWorkshopDiscount.ErrorText = String.Empty;
                isValid = true;
            }
            else
            {
                txtCompanyDiscount.ErrorText = "Enter discount amount";
                txtWorkshopDiscount.ErrorText = "Enter discount amount";
                isValid = false;
            }

            return isValid;
        }

        private bool IsInventoryValueValid()
        {
            bool isValid = true;
            DB.ITM_DIS_Discount ITM_DIS_Discount = ((DB.ITM_DIS_Discount)BindingSource.DataSource);

            if (ITM_DIS_Discount.CompanyDiscountCode != null || ITM_DIS_Discount.EntityId != null)
            {
                txtCompanyDiscountCode.ErrorText = String.Empty;
                ddlCompany.ErrorText = String.Empty;
                isValid = true;
            }
            else
            {
                txtCompanyDiscountCode.ErrorText = "Enter discount code";
                ddlCompany.ErrorText = "Select Company ...";
                isValid = false;
            }

            return isValid;
        }

        private bool IsCustomerValueValid()
        {
            bool isValid = true;
            DB.ITM_DIS_Discount ITM_DIS_Discount = ((DB.ITM_DIS_Discount)BindingSource.DataSource);

            if (ITM_DIS_Discount.InventoryDiscountCode != null || ITM_DIS_Discount.InventoryId != null)
            {
                txtInventoryDiscountCode.ErrorText = String.Empty;
                ddlInventory.ErrorText = String.Empty;
                isValid = true;
            }
            else
            {
                txtInventoryDiscountCode.ErrorText = "Enter discount code";
                ddlInventory.ErrorText = "Select Item ...";
                isValid = false;
            }

            return isValid;
        } 

        private void ddlCompany_TextChanged(object sender, EventArgs e)
        {
            //if (ddlCompany.Text.Length == 0)
            //    ((DB.ITM_DIS_Discount)BindingSource.DataSource).EntityId = null;
        }

        private void ddlInventory_TextChanged(object sender, EventArgs e)
        {
            //if (ddlInventory.Text.Length == 0)
            //    ((DB.ITM_DIS_Discount)BindingSource.DataSource).InventoryId = null;
        }

        private void ddlCompany_EditValueChanged(object sender, EventArgs e)
        {
            //if (ddlCompany.EditValue != DBNull.Value)
            //    ((DB.ITM_DIS_Discount)BindingSource.DataSource).CompanyDiscountCode = null;
        }

        private void ddlInventory_EditValueChanged(object sender, EventArgs e)
        {
            //if (ddlInventory.EditValue != DBNull.Value)
            //    ((DB.ITM_DIS_Discount)BindingSource.DataSource).InventoryDiscountCode = null;
        }

        private void txtCompanyDiscountCode_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (txtCompanyDiscountCode.Text.Length != 0)
            //    ((DB.ITM_DIS_Discount)BindingSource.DataSource).EntityId = null;
        }

        private void txtInventoryDiscountCode_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (txtInventoryDiscountCode.Text.Length != 0)
            //    ((DB.ITM_DIS_Discount)BindingSource.DataSource).InventoryId = null;
        }

        private void InstantFeedbackSourceCompany_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Entity.Where(n => n.HasCustomer && !n.Archived && n.CompanySiteId == defaultSiteId );
        }

        private void InstantFeedbackSourceItem_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.InventorySiteId == defaultSiteId
                );
        
        }      
    }
}
