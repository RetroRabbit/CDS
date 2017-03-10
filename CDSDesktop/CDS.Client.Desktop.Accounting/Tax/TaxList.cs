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

namespace CDS.Client.Desktop.Accounting
{
    public partial class TaxList : CDS.Client.Desktop.Essential.BaseList
    {
        public TaxList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load all the Taxes from the database using linq to sql.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 27/02/2012</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                if (!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED))
                XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[EntityId.SiteId] = ?", BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Tax form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Werner Scheffer 27/02/2012</remarks>
        protected override void OnOpenRecord(Int64 Id)
        {
            try
            {
                
                base.OnOpenRecord(Id);
                
                TaxForm childForm = new TaxForm(Id);
                ShowForm(childForm);
                
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        /// <summary>
        /// Open the Tax form with blank data so that a new record may be entered.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 27/02/2012</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                TaxForm childForm = new TaxForm();
                ShowForm(childForm);
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
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        } 

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FITARECR);
        }

  
    }
}
