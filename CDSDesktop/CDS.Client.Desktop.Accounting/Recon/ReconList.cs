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
    public partial class ReconList : CDS.Client.Desktop.Essential.BaseList
    {
        public ReconList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// After the form has initialised load the recons.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open a new record
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                ShowForm(new ReconForm());
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open a existing record
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        protected override void  OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                ReconForm childForm = new ReconForm(Id);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIRERECR);
        }
    }
}
