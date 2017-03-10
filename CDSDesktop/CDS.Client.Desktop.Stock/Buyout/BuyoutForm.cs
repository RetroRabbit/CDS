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
using SECL = CDS.Client.BusinessLayer.SEC; 

namespace CDS.Client.Desktop.Stock.Buyout
{
    public partial class BuyoutForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.SYS_Entity sysEntity;
        public BuyoutForm()
        {
            InitializeComponent();
        }

        public BuyoutForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INBUREED);
            
            if(SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INSTRECR))
            {
                btnCreateStockItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            sysEntity = BL.SYS.SYS_Entity.Load(Id, DataContext);
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = sysEntity;
        }

        protected override void XPOPostBindDataFilter()
        {
            base.XPOPostBindDataFilter();
            XPInstantFeedbackSourceTransactions.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[EntityId.Id] = ?", sysEntity.Id);
      
        }

        private void btnCreateStockItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Inventory.InventoryForm childForm = new Inventory.InventoryForm();
            ShowForm(childForm);
            childForm.CreateBuyoutItem(sysEntity);
            Close();
        } 
    }
}
