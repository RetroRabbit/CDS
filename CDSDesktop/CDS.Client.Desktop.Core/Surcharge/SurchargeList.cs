using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Surcharge
{
    public partial class SurchargeList : CDS.Client.Desktop.Essential.BaseList
    {
        public SurchargeList() 
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[EntityId.TypeId.Id] = ? AND [AccountId.SiteId] = ?", (byte)BL.SYS.SYS_Type.Surcharge, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();

            SurchargeForm childform = new SurchargeForm();
            ShowForm(childform);
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                SurchargeForm childForm = new SurchargeForm(Id);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSURECR);
        }
    }
}
