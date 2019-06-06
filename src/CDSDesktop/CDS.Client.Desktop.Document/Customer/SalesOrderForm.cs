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
    public partial class SalesOrderForm : CDS.Client.Desktop.Document.BaseDocument
    {
        public SalesOrderForm()
        {
            InitializeComponent();
        }

        public SalesOrderForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        public override void CompanyChanged()
        {
            base.CompanyChanged();
            btnCatalogue.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnBarcodeScanner.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INBURECR))
            {
                btnBuyout.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (ItemState == EntityState.Open)
            {
                bool hasOutstanding = false;
                bool hasReceived = false;
                //Make the Cancel button visible if there are any outstanding items
                foreach (var lineGrouped in Doc_Header.SYS_DOC_Line.Where(n => n.Quantity >= 0).GroupBy(l => l.ItemId).Select(g => new { Item = g.Key, LineItem = g.FirstOrDefault().LineItem, QuantityOutstanding = g.Sum(l => l.QtyOutstanding), QuantityReceived = g.Sum(l => l.QtyReceived), AmountAvailable = g.Sum(r => r.Amount - r.AmountInvoiced) }))
                {
                    if (!hasOutstanding && new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(lineGrouped.LineItem.TypeId) && lineGrouped.QuantityOutstanding != 0)
                    {
                        hasOutstanding = true;
                        //break;
                    }

                    if (!hasReceived && lineGrouped.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory && lineGrouped.QuantityReceived != 0)
                    {
                        hasReceived = true;
                        //break;
                    }
                }

                //If the document has a Sales Order, nothing outstanding and the user has access to View Sales Orders
                if (!hasOutstanding && hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORE))
                {
                    btnViewTAXInvoice.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnViewTAXInvoice.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                }
                //If the document has a Sales Order, has outstanding and the user has access to Create Sales Orders
                else if (hasOutstanding && !hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR))
                {
                    btnViewBackOrders.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    rpgActionDocument.ItemLinks.Add(btnViewBackOrders);
                }
                //If the document has no Sales Order, has outstanding and the user has access to Create Sales Orders
                else if (hasOutstanding && hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR))
                {
                    btnViewTAXInvoice.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnViewBackOrders.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
        }

        private void btnLostSale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new LostSale.LostSaleDialogue(CompanyType)).ShowDialog();
        }

        private void btnViewBackOrders_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.BackOrder, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
        }

        private void btnViewTAXInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.TAXInvoice, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
        }

        private void btnCatalogue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowCatalogueForm(SelectedCompany, CompanyType, this);
        }

        private void btnBarcodeScanner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Stock.ScanItemDialogue dlg = new Stock.ScanItemDialogue())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AddBarcodeItems(dlg.Items);
                }
            }
        }

        private void btnBuyout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Stock.BuyoutDialogue dlg = new Stock.BuyoutDialogue(Doc_Header))
            {
                ValidateLayout();
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AddBuyoutItem(dlg);
                }
            }
        }
    }
}
