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

namespace CDS.Client.Desktop.Stock.Buyout
{
    public partial class BuyoutList : CDS.Client.Desktop.Essential.BaseList
    {
        public BuyoutList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[CustomerId.SiteId.Id] = ?", BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                BuyoutForm childForm = new BuyoutForm(Id);
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
            //Werner : You are not allowed to Create new Buyouts they can only be added using Sales Order and Goods Received
            AllowNewRecord = false;
        }
    }
}
