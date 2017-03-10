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

namespace CDS.Client.Desktop.Document.Customer
{
    public partial class BackOrderForm : CDS.Client.Desktop.Document.BaseDocument
    {
        public BackOrderForm()
        {
            InitializeComponent();
        }

        public BackOrderForm(Int64 id)
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
                bool hasOutstanding = false;
                bool hasReceived = false;
                //Make the Cancel button visible if there are any outstanding items
                foreach (var lineGrouped in Doc_Header.SYS_DOC_Line.Where(n=>n.Quantity >= 0).GroupBy(l => l.ItemId).Select(g => new { Item = g.Key, QuantityOutstanding = g.Sum(l => l.QtyOutstanding), QuantityReceived = g.Sum(l => l.QtyReceived) }))
                {
                    if (!hasOutstanding && lineGrouped.QuantityOutstanding != 0)
                    {
                        hasOutstanding = true; 
                    }

                    if (!hasReceived && lineGrouped.QuantityReceived != 0)
                    {
                        hasReceived = true; 
                    }
                }

                // If allowed to create TAX Invoice
                if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOTIRECR))
                {
                    // If you have outstanding 
                    if (!hasOutstanding)
                    {
                        btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnViewTAXInvoices.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }
                    else
                        if (hasOutstanding && hasReceived)
                        {
                            btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            btnViewTAXInvoices.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                        else
                            if (hasOutstanding && !hasReceived)
                            {
                                btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                rpgActionDocument.ItemLinks.Add(btnCreateSalesOrder);
                            }
                }
                else if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOTIRE))
                {
                    if (hasReceived)
                    {
                        btnViewTAXInvoices.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnViewTAXInvoices.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }
                }

                // If you have access to Create Purchase Order
                if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOPORECR))
                {
                    if (BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder))
                    {
                        btnViewPurchaseOrders.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnViewPurchaseOrders.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }
                    else
                    {
                        if (hasOutstanding)
                        {
                            btnCreatePurchaseOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            rpgActionDocument.ItemLinks.Add(btnCreatePurchaseOrder);
                        }
                    }
                }

                if (hasOutstanding)
                {
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
        }

        private void btnViewTAXInvoices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.TAXInvoice, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm); 
        }

        private void btnViewPurchaseOrders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.PurchaseOrder, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
        }

        private void btnCreatePurchaseOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Supplier.PurchaseOrderForm childForm = new Supplier.PurchaseOrderForm();
            childForm.Doc_Header = BL.SYS.DocumentProcessor.CreatePurchaseOrderFromBackOrder(Doc_Header, DataContext);
            childForm.ItemState = EntityState.Generated;
            ForceClose = true;
            this.Close();
            ShowForm(childForm);
        }

        private void btnCreateSalesOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SalesOrderForm childForm = new SalesOrderForm();
            childForm.Doc_Header = BL.SYS.DocumentProcessor.CreateSalesOrderFromBackOrder(Doc_Header, DataContext);
            childForm.ItemState = EntityState.Generated;
            ForceClose = true;
            this.Close();
            ShowForm(childForm);

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string message = string.Empty;
                if (Essential.BaseAlert.ShowAlert("Cancel Document", "You are about to cancel the outstanding items on this document", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        message = BL.ApplicationDataContext.Instance.Service.CancelDocument(Doc_Header.Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId);

                        if (message.StartsWith("Success"))
                        {
                            ShowNotification("Document Cancelled", String.Format("{0} number {1} was cancelled successfully", this.Text, message.Split(',')[1]), 5000, false, null);
                            this.Close();
                        }
                        else
                        {
                            DocumentSaveException(message);
                        }
                    }
                }

                btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception ex)
            {
                HasErrors = true; CurrentException = ex;
                Doc_Header.SYS_DOC_Line.Clear();
            }
        }
    }
}
