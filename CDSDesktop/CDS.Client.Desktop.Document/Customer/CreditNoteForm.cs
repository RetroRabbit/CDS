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

namespace CDS.Client.Desktop.Document.Customer
{
    public partial class CreditNoteForm : CDS.Client.Desktop.Document.BaseDocument
    {
        public CreditNoteForm()
        {
            InitializeComponent();
        }

        public CreditNoteForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (ItemState == EntityState.Open)
            {
                // Henko : Need to check if C/N has been approved, if it has been buttons for approve and cancel should be removed.
                bool HasMovement = false; 
                
                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                {
                    foreach (DB.SYS_DOC_Line line in (BindingSource.DataSource as DB.SYS_DOC_Header).SYS_DOC_Line.Where(n => n.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory).ToList())
                    {
                        HasMovement = BL.ITM.ITM_Movement.LoadByLineId(line.Id, DataContext) == null;
                    }
                }
                
                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                {
                    Int64 docRef = (BindingSource.DataSource as DB.SYS_DOC_Header).Id;
                    HasMovement = DataContext.ReadonlyContext.VW_Header.Any(n => n.ReferenceId == docRef);
                    //Int64 tracking = (BindingSource.DataSource as DB.SYS_DOC_Header).TrackId;
                    //HasMovement = DataContext.ReadonlyContext.VW_Header.Any(n => n.TrackId == tracking && n.JournalTypeId == (byte)BL.GLX.GLX_JournalType.CreditNote);
                }
                
                if (!HasMovement && BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SADOSCRE01))
                {
                    btnApprove.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                } 

                //If you have access to view TAX Invoices and the Credit Note has a TAX Invoice
                if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SADOTIRE)
                    && BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.TAXInvoice))
                {
                    btnViewTAXInvoice.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
        } 

        private void btnViewTAXInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.TAXInvoice, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
        }

        private void btnApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string message = string.Empty;
                if (Essential.BaseAlert.ShowAlert("Approve Document", "You are about to approve this Credit Note", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        message = BL.ApplicationDataContext.Instance.Service.ApproveDocument((BindingSource.DataSource as DB.SYS_DOC_Header).Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId);

                        if (message.StartsWith("Success"))
                        {
                            ShowNotification("Document Approved", String.Format("{0} number {1} was approved successfully", this.Text, message.Split(',')[1]), 5000, false, null);
                        }
                        else
                        {
                            DocumentSaveException(message);
                        }
                    }
                }

                btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnApprove.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception ex)
            {
                HasErrors = true; CurrentException = ex;
                Doc_Header.SYS_DOC_Line.Clear();
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string message = string.Empty;
                if (Essential.BaseAlert.ShowAlert("Cancel Document", "You are about to cancel the Credit Note", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        message = BL.ApplicationDataContext.Instance.Service.RejectDocument((BindingSource.DataSource as DB.SYS_DOC_Header).Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId);

                        if (message.StartsWith("Success"))
                        {
                            ShowNotification("Document Cancelled", String.Format("{0} number {1} was cancelled successfully", this.Text, message.Split(',')[1]), 5000, false, null);
                        }
                        else
                        {
                            DocumentSaveException(message);
                        }
                    }
                }

                btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnApprove.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception ex)
            {
                HasErrors = true; CurrentException = ex;
                Doc_Header.SYS_DOC_Line.Clear();
            }
        }
    }
}
