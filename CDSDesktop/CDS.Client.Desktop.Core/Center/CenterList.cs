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


namespace CDS.Client.Desktop.Core.Center
{
    public partial class CenterList : CDS.Client.Desktop.Essential.BaseList
    {
        public CenterList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads all the segments on the database using LINQ to SQL.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
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
        /// Open the Segment form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                CenterForm childForm = new CenterForm();
                childForm.OpenRecord(Id);
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Segment Form with blank data so that a new record may be entered.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                CenterForm childForm = new CenterForm();
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYCERECR);
        } 
    }
}
