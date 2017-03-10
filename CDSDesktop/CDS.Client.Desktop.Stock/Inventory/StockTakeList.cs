using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Stock.Inventory
{
    public partial class StockTakeList : CDS.Client.Desktop.Essential.BaseList
    {
        public StockTakeList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            //filter by siteId
            if (ReferenceEquals(XPOInstantFeedbackSource.FixedFilterCriteria, null))
                XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[SiteId.Id] = ?", BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);

        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            StockTakeForm childform = new StockTakeForm();
            ShowForm(childform);
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                base.OnOpenRecord(Id);
                StockTakeForm childForm = new StockTakeForm(Id);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSKRECR);
        }
    }
}
