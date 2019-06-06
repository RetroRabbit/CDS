using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq; 
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Accounting.Entry
{
    public partial class EntryList : CDS.Client.Desktop.Essential.BaseList
    {
        public Int64? TrackId { get; set; }

        public EntryList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            bool MasterAccountant = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE);
            if (TrackId != null)
            {
                if(!MasterAccountant)
                XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[HeaderId.TrackId.Id] = ? AND [EntityId.SiteId] = ?", TrackId, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
                else
                    XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[HeaderId.TrackId.Id] = ?", TrackId);

            }
            else { 
            if(!MasterAccountant)
                XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[EntityId.SiteId] = ?", BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            }
            
           

        
        }

        /// <summary>
        /// Load the data.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void BindData()
        {
            try
            {
                base.BindData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open a new record
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                ShowForm(new EntryForm());
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Entry form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Theo Crous 01/12/2011</remarks>
        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                
                if (checkOutOfSiteAccess(Id))
                { 
                EntryForm childForm = new EntryForm(Id);
                childForm.ReadOnly = true;
                ShowForm(childForm);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRECR);
        }

        internal void AutoFilter(String autoFilter)
        {
            GridView.ActiveFilterString = autoFilter;
            GridView.ExpandAllGroups();
        }
        //Check for out of default site access
        //Only applicable to master accountants, checks if they have create and edit cred
        //accessType :  Id: EntityId
        protected bool checkOutOfSiteAccess(long Id)
        {
            long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;


            if (DataContext.EntityAccountingContext.GLX_Account.SingleOrDefault(n => n.EntityId == DataContext.EntityAccountingContext.GLX_Line.FirstOrDefault(a => a.Id == Id).EntityId).SiteId != defaultSiteId && !BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED))
            {
           Essential.BaseAlert.ShowAlert("Access Denied", "You do not have permission for the chosen operation", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                return false;
            }
            return true;
        }
    }
}
