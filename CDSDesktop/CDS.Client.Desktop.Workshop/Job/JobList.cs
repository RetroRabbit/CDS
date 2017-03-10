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

namespace CDS.Client.Desktop.Workshop.Job
{
    public partial class JobList : CDS.Client.Desktop.Essential.BaseList
    {
        //public BL.SYS.SYS_DOC_Type DocumentType { get; set; }
        private Int64? TrackId { get; set; }

        public JobList()
        {
            InitializeComponent();
        }

        //public JobList(BL.SYS.SYS_DOC_Type documentType, Int64 trackId)
        public JobList(Int64 trackId)
        {
            InitializeComponent(); 
            this.TrackId = trackId;
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (this.TrackId != null)
                XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[HeaderId.TrackId.Id] = ? AND [CompanyId.SiteId.Id] = ?", TrackId.Value, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            else
                XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[CompanyId.SiteId.Id] = ?",  BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            
        }

        protected override void BindData()
        {
            base.BindData();
            //Need to filter out document where the line count over quantity == 0
        } 

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                JobForm childForm = new JobForm();
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                 
                JobForm childForm = new JobForm(Id);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.WSDOJCRE);
        }
    }
}
