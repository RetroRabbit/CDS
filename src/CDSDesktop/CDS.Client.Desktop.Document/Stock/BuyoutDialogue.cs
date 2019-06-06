using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using XDB = CDS.Client.DataAccessLayer.XDB;
using System.Transactions;

namespace CDS.Client.Desktop.Document.Stock
{
    public partial class BuyoutDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public DB.IBO_TRX_Header IBO_TRX_Header { get; set; }

        public DB.SYS_Entity SYS_Entity { get; set; }

        public DB.SYS_DOC_Header SYS_DOC_Header { get; set; }

        public DB.SYS_DOC_Header SYS_DOC_Header_GoodsReceived { get; set; }
        public DB.ORG_TRX_Header ORG_TRX_Header;
        long? defaultSiteId;
        public byte? CostCategory { get; set; }

        public BuyoutDialogue(DB.SYS_DOC_Header sYS_DOC_Header)
        {
            InitializeComponent();
            SYS_DOC_Header = sYS_DOC_Header;
        }
        //New databindings for lookupEdits
        protected override void OnStart()
        {
            base.OnStart();
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
           bindingSourceSuppliers.DataSource = DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (byte)BL.ORG.ORG_Type.Supplier && n.SiteId == defaultSiteId).Select(n=> new { n.Name, n.Id }).ToList();
            bindingSourceCustomers.DataSource = DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (byte)BL.ORG.ORG_Type.Customer && n.SiteId == defaultSiteId).Select(n => new { n.Name, n.Id }).ToList();
        }
        protected override void BindData()
        {
            base.BindData();

            SYS_Entity = BL.SYS.SYS_Entity.NewBuyOut;
            IBO_TRX_Header = BL.IBO.IBO_TRX_Header.New;

            BindingSource.DataSource = IBO_TRX_Header;
            BindingSourceEntity.DataSource = SYS_Entity;

            using (UnitOfWork uow = new UnitOfWork())
            {
                mruName.Properties.Items.AddRange(uow.Query<XDB.SYS_Entity>().Where(n => n.TypeId.Id == (byte)BL.SYS.SYS_Type.Inventory || (n.TypeId.Id == (byte)BL.SYS.SYS_Type.BuyOut && !n.HasBuyoutQuantity)).Select(l => l.Name).ToList());
                //mruCustomer.Properties.Items.AddRange(uow.Query<XDB.SYS_Entity>().Where(n => n.HasCustomer && n.SiteId == defaultSiteId).Select(l =>  l.Name).ToList());
                //mruSupplier.Properties.Items.AddRange(uow.Query<XDB.SYS_Entity>().Where(n => n.HasSupplier && n.SiteId == defaultSiteId).Select(l => l.Name).ToList());

                if (SYS_DOC_Header.ORG_TRX_Header.CompanyId > 0)
                {
                    
                    var companyName = uow.Query<XDB.ORG_Company>().Where(n => n.Id == SYS_DOC_Header.ORG_TRX_Header.CompanyId).Select(l => l.EntityId.Name).FirstOrDefault();
                    if (SYS_DOC_Header.TypeId == (byte)BL.SYS.SYS_DOC_Type.SalesOrder)
                    {
                        IBO_TRX_Header.CustomerId = uow.Query<XDB.ORG_Company>().Where(n => n.Id == SYS_DOC_Header.ORG_TRX_Header.CompanyId).Select(l => l.EntityId.Id).FirstOrDefault();
                        ((DB.IBO_TRX_Header)BindingSource.DataSource).Customer = companyName;
                        lueCustomer.Enabled = false;
                        //mruCustomer.Enabled = false;
                    }
                    else
                        if (SYS_DOC_Header.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived)
                        {
                        IBO_TRX_Header.SupplierId = uow.Query<XDB.ORG_Company>().Where(n => n.Id == SYS_DOC_Header.ORG_TRX_Header.CompanyId).Select(l => l.EntityId.Id).FirstOrDefault();
                        ((DB.IBO_TRX_Header)BindingSource.DataSource).Supplier = companyName;
                        lueSupplier.Enabled = false;    
                        //mruSupplier.Enabled = false;
                        }
                }
            }
        }

        private bool ValidateBeforeSave()
        {
            try
            { 
                bool isValid = true;
                //ValidationProvider needs to checked last
                isValid = IsSupplierValid() && ValidationProvider.Validate();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsSupplierValid()
        {
            bool isValid = true;
            if (IBO_TRX_Header.SupplierId == null && !BL.ApplicationDataContext.Instance.CompanySite.BuyoutSupplierAccount.HasValue && SYS_DOC_Header.TypeId == (byte)BL.SYS.SYS_DOC_Type.SalesOrder)
            {
                isValid = false;
                Essential.BaseAlert.ShowAlert("Default Buyout Supplier", "Default Buyout Supplier Account not set.\nSelect a supplier or setup Default Buyout Supplier Account in Site settings before continuing", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
            }
            return isValid;
        }

        protected bool SaveSuccessful()
        {
            if (!ValidateBeforeSave())
                return false;

            if (IBO_TRX_Header.SupplierId == null && BL.ApplicationDataContext.Instance.CompanySite.BuyoutSupplierAccount.HasValue && SYS_DOC_Header.TypeId == (byte)BL.SYS.SYS_DOC_Type.SalesOrder)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {           
                    var supplier = uow.Query<XDB.ORG_Company>().Where(n => n.EntityId.HasSupplier && n.EntityId.Id == BL.ApplicationDataContext.Instance.CompanySite.BuyoutSupplierAccount.Value).Select(l => new { l.EntityId.Id, CostCategory = l.CostCategoryId.Id }).FirstOrDefault();
                    ((DB.IBO_TRX_Header)BindingSource.DataSource).SupplierId = (long)lueSupplier.EditValue; //supplier.Id;
                    CostCategory = supplier.CostCategory;
                }
            }
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (IBO_TRX_Header.SupplierId != null)
                {
                    ((DB.IBO_TRX_Header)BindingSource.DataSource).Supplier = uow.Query<XDB.ORG_Company>().Where(n => n.Id == IBO_TRX_Header.SupplierId).Select(l => l.EntityId.Name).FirstOrDefault();
                }
                if (IBO_TRX_Header.CustomerId != null)
                {
                    ((DB.IBO_TRX_Header)BindingSource.DataSource).Customer= uow.Query<XDB.ORG_Company>().Where(n => n.Id == IBO_TRX_Header.CustomerId).Select(l => l.EntityId.Name).FirstOrDefault();
                }
            }

            try
            { 
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    try
                    {
                        using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                        {
                            using (TransactionScope transaction = DataContext.GetTransactionScope())
                            {
                                BL.EntityController.SaveSYS_Entity(SYS_Entity, DataContext);
                                DataContext.SaveChangesEntitySystemContext();
                                DataContext.CompleteTransaction(transaction);
                            }
                            DataContext.EntityInventoryContext.AcceptAllChanges();
                            DataContext.EntitySystemContext.AcceptAllChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityInventoryContext.RejectChanges();
                        DataContext.EntitySystemContext.RejectChanges();
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                  
                    SYS_DOC_Header_GoodsReceived = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.GoodsReceived);
                    SYS_DOC_Header_GoodsReceived.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.New;
                    SYS_DOC_Header_GoodsReceived.SiteId = (long)defaultSiteId;
                    BL.ApplicationDataContext.DeepClone<DB.ORG_TRX_Header>(SYS_DOC_Header.ORG_TRX_Header, SYS_DOC_Header_GoodsReceived.ORG_TRX_Header);

                    DB.SYS_DOC_Line line = BL.SYS.SYS_DOC_Line.New;

                    ((DB.IBO_TRX_Header)BindingSource.DataSource).EntityId = SYS_Entity.Id;
                    line.LineOrder = 1;
                    line.ItemId = ((DB.IBO_TRX_Header)BindingSource.DataSource).EntityId;
                    line.Amount = ((DB.IBO_TRX_Header)BindingSource.DataSource).UnitCost;
                    line.Quantity = ((DB.IBO_TRX_Header)BindingSource.DataSource).Quantity;
                    line.ItemId = SYS_Entity.Id;
                    //line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == ((DB.SYS_Entity)BindingSourceEntity.DataSource).Id);
                    line.IBO_TRX_Header = ((DB.IBO_TRX_Header)BindingSource.DataSource);

                    line.Total = Math.Round(line.Amount * line.Quantity, 2, MidpointRounding.AwayFromZero);

                    //TODO: Check if item is VAT Exempt
                    switch (CostCategory)
                    {
                        case (byte)BL.ORG.ORG_CostCategory.SellingPriceIncludingSalesTax:
                            line.TotalTax = line.Total * BL.ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                            break;
                        case (byte)BL.ORG.ORG_CostCategory.SellingPriceExcludingSalesTax:
                            line.TotalTax = 0;
                            break;
                        case (byte)BL.ORG.ORG_CostCategory.CostIncludingSalesTax:
                            line.TotalTax = line.Total * BL.ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                            break;
                        case (byte)BL.ORG.ORG_CostCategory.CostExcludingSalesTax:
                            line.TotalTax = 0;
                            break;
                        case (byte)BL.ORG.ORG_CostCategory.AverageCostExcludingSalesTax:
                            line.TotalTax = 0;
                            break;
                    }

                    if (((DB.IBO_TRX_Header)BindingSource.DataSource).SupplierId.HasValue)
                    {
                        SYS_DOC_Header_GoodsReceived.ORG_TRX_Header.CompanyId = ((DB.IBO_TRX_Header)BindingSource.DataSource).SupplierId.Value;
                    }

                    SYS_DOC_Header_GoodsReceived.SYS_DOC_Line.Add(line);

                    if (SYS_DOC_Header.TypeId == (byte)BL.SYS.SYS_DOC_Type.SalesOrder)
                    {
                        DialogResult result = Essential.DocumentAlert.ShowAlert("Save Document", "You are about to save this document do you wish to continue ?", Essential.DocumentAlert.Buttons.SaveAndPrint);
                        if (result == System.Windows.Forms.DialogResult.Cancel)
                            return false;

                        string message = "";
                        Int64 printerId = 0;
                        switch (result)
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                printerId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value;
                                break;
                            case System.Windows.Forms.DialogResult.No:
                                printerId = 0;
                                break;
                        }
                        DataContext.SaveChangesEntitySystemContext();
                        message = BL.ApplicationDataContext.Instance.Service.SaveDocument(SYS_DOC_Header_GoodsReceived, printerId);

                        if (message.StartsWith("Success"))
                        {
                            var returns = message.Split(',');
                            //Normal Document number
                            if (returns[1] != null)
                            {
                                ShowNotification("Document Saved", String.Format("{0} number {1} was saved successfully", "Goods Received", returns[1]), 5000, false, null);
                                SYS_DOC_Header_GoodsReceived.IgnoreChanges = true;
                                SYS_DOC_Header_GoodsReceived.DocumentNumber = Convert.ToInt64(returns[1]);
                                SYS_DOC_Header_GoodsReceived.IgnoreChanges = false;
                            }

                            //Tracking number
                            if (returns[2] != null)
                            {
                                ShowNotification("Document Saved", String.Format("{0} number {1} was saved successfully", "Tracking", returns[2]), 5000, false, null);
                                SYS_DOC_Header_GoodsReceived.IgnoreChanges = true;
                                SYS_DOC_Header_GoodsReceived.TrackId = Convert.ToInt64(returns[2]);
                                SYS_DOC_Header_GoodsReceived.IgnoreChanges = false;
                            }
                            DataContext.SaveChangesEntitySystemContext();
                            return true;
                        }
                        else if (message != string.Empty)
                        {
                            return false;
                        }
                        else
                            return false;
                    }
                    else if (SYS_DOC_Header.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived)
                    {
                        return true;
                    }

                    //Document Type not supported
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!SaveSuccessful())
                return;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void mruShortName_Leave(object sender, EventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Query<XDB.SYS_Entity>().Any(n => new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(n.TypeId.Id) && n.Name == (String)mruName.EditValue))
                {
                    SYS_Entity = DataContext.EntitySystemContext.SYS_Entity.FirstOrDefault(n => (new BL.SYS.SYS_Type[] { BL.SYS.SYS_Type.Inventory, BL.SYS.SYS_Type.BuyOut }).Cast<byte>().Contains(n.TypeId) && n.Name == (String)mruName.EditValue);
                    BindingSourceEntity.DataSource = SYS_Entity;
                    txtDescription.Enabled = false;
                    txtShortName.Enabled = false;
                }
                else
                {
                    var item = mruName.EditValue;
                    SYS_Entity = BL.SYS.SYS_Entity.NewBuyOut;
                    mruName.EditValue = item;
                    txtDescription.Enabled = true;
                    txtShortName.Enabled = true;
                }
                BindingSourceEntity.DataSource = SYS_Entity;
            }
        }

        private void mruCustomer_Leave(object sender, EventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                ValidateLayout();
                if (uow.Query<XDB.ORG_Company>().Any(n => n.EntityId.HasCustomer && n.EntityId.Id == (long)lueCustomer.EditValue))//.Name == mruCustomer.EditValue))
                {
                    //((DB.IBO_TRX_Header)BindingSource.DataSource).CustomerId = uow.Query<XDB.ORG_Company>().Where(n => n.EntityId.HasCustomer && n.EntityId.Name == mruCustomer.EditValue).Select(l => l.Id).FirstOrDefault();
                    //What we want
                    ((DB.IBO_TRX_Header)BindingSource.DataSource).CustomerId = (long)lueCustomer.EditValue; //uow.Query<XDB.ORG_Company>().Where(n => n.EntityId.HasCustomer && n.EntityId.Id == (long)lueCustomer.EditValue).Select(l => l.EntityId.Id).FirstOrDefault();
                }
            
                else 
                {
                    ((DB.IBO_TRX_Header)BindingSource.DataSource).CustomerId = null;
                }
            }
        }

        private void mruSupplier_Leave(object sender, EventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                ValidateLayout();
                if (uow.Query<XDB.ORG_Company>().Any(n => n.EntityId.HasSupplier && n.EntityId.Id == (long)lueSupplier.EditValue))//Name == mruSupplier.EditValue))
                {
                    var supplier = uow.Query<XDB.ORG_Company>().Where(n =>n.EntityId.HasSupplier && n.EntityId.Id == (long)lueSupplier.EditValue/*Name == mruSupplier.EditValue*/).Select(l => new { l.EntityId, CostCategory = l.CostCategoryId.Id }).FirstOrDefault();
                    ((DB.IBO_TRX_Header)BindingSource.DataSource).SupplierId = (long)lueSupplier.EditValue; //supplier.Id;
                   
                    CostCategory = supplier.CostCategory;
                }
                else
                {
                    ((DB.IBO_TRX_Header)BindingSource.DataSource).SupplierId = null;
                    CostCategory = null;
                }
            }
        }
    }
}
