using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Filtering;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.Desktop.Accounting
{
    public partial class AccountList : CDS.Client.Desktop.Essential.BaseList
    {
        public AccountList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Basically just here to filter the accounts by siteId
        /// </summary>
        /// <remarks>Created: Sean Hill 12/9/2016</remarks>
protected override void OnStart()
        {
            base.OnStart();
        //if here for Super Accountants
            if (ReferenceEquals(XPOInstantFeedbackSource.FixedFilterCriteria, null) && !BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
                    XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[SiteId.Id] = ?", BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);

        }

        /// <summary>
        /// Open the Account form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                

                if (Id != -1 && checkOutOfSiteAccess(Id))
                {
                    AccountForm childForm = new AccountForm(Id);
                    ShowForm(childForm);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Account form with blank data so that a new record may be entered.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                
                    base.OnNewRecord();

                    AccountForm childForm = new AccountForm();
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIACRECR);
        }


        //Check for out of default site access
        //Only applicable to master accountants, checks if they have create and edit cred
        //accessType :  Id: EntityId
        protected bool checkOutOfSiteAccess(long Id)
        {

            if (DataContext.EntityAccountingContext.GLX_Account.SingleOrDefault(n => n.EntityId == Id).SiteId != BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId && !BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED))
            {
                Essential.BaseAlert.ShowAlert("Access Denied", "You do not have permission for the chosen operation", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                return false;
            }
            return true;
        }
    }
}

