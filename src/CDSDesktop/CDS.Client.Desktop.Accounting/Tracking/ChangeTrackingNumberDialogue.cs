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

namespace CDS.Client.Desktop.Accounting.Tracking
{
    public partial class ChangeTrackingNumberDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        protected Int64 LineId { get; set; }
        DB.VW_Line line;

        public ChangeTrackingNumberDialogue()
        {
            InitializeComponent(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSourceLine.DataSource = line;
            if (ReferenceEquals(XPInstantFeedbackSourceTracking.FixedFilterCriteria, null))
                XPInstantFeedbackSourceTracking.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("GLX_Headers[GLX_Lines[EntityId = ?]]", line.AccountId.Value);

            ddlNewTrackingNumber.Properties.DataSource = XPInstantFeedbackSourceTracking;
            ddlNewTrackingNumber.Properties.DisplayMember = "Id";
            ddlNewTrackingNumber.Properties.ValueMember = "Id";
        }

        /// <summary>
        /// Gets the lineid for the current row that is selected
        /// </summary>
        /// <param name="headerid"></param>
        /// <remarks>Created: Jan de Bruyn 13/08/2012</remarks>
        public void SetLineId(Int64 lineid)
        {
            this.LineId = lineid;
            line = DataContext.ReadonlyContext.VW_Line.First(n => n.Id == LineId); 
        }

        /// <summary>
        /// Retrieves the Track Number that was linked.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Created: Theo Crous 13/08/2012</remarks>
        public Int64 GetNewTrackNumber()
        {
            try
            {
                Int64 newnumber = -1;

                if (Int64.TryParse(ddlNewTrackingNumber.EditValue.ToString(), out newnumber))
                {
                    return newnumber;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return -1;
            }
        }

        /// <summary>
        /// The user has clicked on the accept button and wishes to change the tracking number of the asssociated header.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 13/08/2012</remarks>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// The user has clicked on the cancel button and wishes to not proceed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 13/08/2012</remarks>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void EntityInstantFeedbackSourceTracking_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.EntitySystemContext.SYS_Tracking.Select(n => new { TrackingNumber = n.Id, n.Initiator }).Distinct();
        }
    }
}
