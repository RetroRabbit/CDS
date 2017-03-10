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

namespace CDS.Client.Desktop.Document.Supplier
{
    public partial class PurchaseOrderForm : CDS.Client.Desktop.Document.BaseDocument
    {
        public PurchaseOrderForm()
        {
            InitializeComponent();
        }

        public PurchaseOrderForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            BindingSource.DataSource = DataContext.EntitySystemContext.SYS_DOC_Header.Where(n => n.SiteId == defaultSiteId).ToList();
                }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (ItemState == EntityState.Open)
            {
                if (!IsNew)
                {
                    bool hasOutstanding = false;
                    //Make the Cancel button visible if there are any outstanding items
                    foreach (var lineGrouped in Doc_Header.SYS_DOC_Line.Where(n => n.Quantity >= 0).GroupBy(l => l.ItemId).Select(g => new { Item = g.Key, LineItem = g.FirstOrDefault().LineItem, Quantity = g.Sum(l => l.QtyOutstanding), AmountAvailable = g.Sum(r => r.Amount - r.AmountInvoiced) }))
                    {
                        if (lineGrouped.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory && lineGrouped.Quantity != 0)
                        {
                            hasOutstanding = true;
                            break;
                        }
                        if (lineGrouped.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account && lineGrouped.AmountAvailable != 0)
                        {
                            hasOutstanding = true;
                            break;
                        }
                    }


                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOGRRE))
                        btnViewGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    // Can create Goods Returned
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOGRRECR))
                    {
                        btnCreateGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        btnViewGoodsReceived.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }

                    if (!hasOutstanding)
                    {
                        btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnCreateGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnOnline.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnViewGoodsReceived.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }
                    else
                    {
                        // Disable Button View Goods Received when there are not Goods Received
                        if (!(BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived)))
                        {
                            btnViewGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            rpgActionDocument.ItemLinks.Add(btnCreateGoodsReceived);
                        }
                        btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
            }
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnViewGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
        }

        private void btnCreateGoodsReceived_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Supplier.GoodsReceivedForm childForm = new Supplier.GoodsReceivedForm();
            childForm.Doc_Header = BL.SYS.DocumentProcessor.CreateGoodsReceivedFromPurchaseOrder(Doc_Header, DataContext);
            childForm.ItemState = EntityState.Generated;
            Close();
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
                btnValidate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            catch (Exception ex)
            {
                HasErrors = true; CurrentException = ex;
                Doc_Header.SYS_DOC_Line.Clear();
            }
        }

        private void btnViewGoodsReceived_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.GoodsReceived, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
        }
    }
}
