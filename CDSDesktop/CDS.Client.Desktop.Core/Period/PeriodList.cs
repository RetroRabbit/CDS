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

namespace CDS.Client.Desktop.Core.Period
{
    public partial class PeriodList : CDS.Client.Desktop.Essential.BaseList
    {
        public PeriodList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// After the form has initialised load the periods.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void BindData()
        {
            base.BindData();
            try
            {
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Period form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                if (Id != -1)
                {
                    PeriodForm childForm = new PeriodForm();
                    childForm.OpenRecord(Id);
                    ShowForm(childForm);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Opens the New Financial Year Dialogue
        /// </summary>
        protected override void OnNewRecord()
        {
            try
            { 
                base.OnNewRecord();
                // Refresh if new Periods have been created
                if (new NewFinancialYearDialogue().ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    OnRefresh();
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPERECR);
        }

        private void btnEndPeriod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}
