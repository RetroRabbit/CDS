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
    public partial class QuoteForm : CDS.Client.Desktop.Document.BaseDocument
    {
        public QuoteForm()
        {
            InitializeComponent();
        }

        public QuoteForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            UseWarehouseDiscount = false;
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id); 
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (ItemState == EntityState.Open)
            {
                if (!IsNew)
                {
                    bool hasOutstanding = false;
                    bool hasReceived = false;
                    //Make the Cancel button visible if there are any outstanding items
                    foreach (var lineGrouped in Doc_Header.SYS_DOC_Line.Where(n => n.Quantity >= 0).GroupBy(l => l.ItemId).Select(g => new { Item = g.Key, LineItem = g.FirstOrDefault().LineItem, Quantity = g.Sum(l => l.QtyOutstanding), QuantityReceived = g.Sum(l => l.QtyReceived), AmountAvailable = g.Sum(r => r.Amount - r.AmountInvoiced) }))
                    {
                        if (!hasOutstanding && lineGrouped.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory && lineGrouped.Quantity != 0)
                        {
                            hasOutstanding = true;
                            //break;
                        }
                        if (!hasOutstanding && lineGrouped.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account && lineGrouped.AmountAvailable != 0)
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
                        btnViewSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnViewSalesOrder.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }
                    //If the document has a Sales Order, has outstanding and the user has access to Create Sales Orders
                    else if (hasOutstanding && hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR))
                    {
                        btnViewSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    //If the document has no Sales Order, has outstanding and the user has access to Create Sales Orders
                    else if (hasOutstanding && !hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR))
                    {
                        btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        rpgActionDocument.ItemLinks.Add(btnCreateSalesOrder);
                    }
                }
            }
        }

        public override void CompanyChanged()
        {
            base.CompanyChanged();
            btnCatalogue.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void grdItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                //radMenu.ShowPopup(MousePosition);
            }
        }

        private void btnCreateSalesOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // TODO: NOT sure if this does anything???
            Doc_Header.SYS_DOC_Line.Clear();

            lines.ForEach(n => Doc_Header.SYS_DOC_Line.Add(n));
            SalesOrderForm childForm = new SalesOrderForm();
            childForm.Doc_Header = BL.SYS.DocumentProcessor.CreateSalesOrderFromQuote(Doc_Header, DataContext);
            childForm.ItemState = EntityState.Generated;
            this.Close();
            ShowForm(childForm);
        }

        private void btnLostSale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new LostSale.LostSaleDialogue(CompanyType)).ShowDialog();
        }

        private void btnCatalogue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowCatalogueForm(SelectedCompany, CompanyType, this);
        }

        private void btnViewSalesOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.SalesOrder, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
        }
    }
}