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
    public partial class GoodsReceivedForm : CDS.Client.Desktop.Document.BaseDocument
    {
        public GoodsReceivedForm()
        {
            InitializeComponent();
        }

        public GoodsReceivedForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        public override void CompanyChanged()
        {
            base.CompanyChanged(); 
            btnBarcodeScanner.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INBURECR))
            {
                btnBuyout.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        protected override void OnStart()
        {
            base.OnStart(); 
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            btnCreateGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnViewGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                    foreach (var lineGrouped in Doc_Header.SYS_DOC_Line.GroupBy(l => l.ItemId).Select(g => new { Item = g.Key, LineItem = g.FirstOrDefault().LineItem, Quantity = g.Sum(l => l.QtyReceived), AmountAvailable = g.Sum(r => r.Amount - r.AmountCredited) }))
                    {
                        if (new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(lineGrouped.LineItem.TypeId) && lineGrouped.Quantity != 0)
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

                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDORURE))
                        btnViewGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    // Can create Goods Returned
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDORURECR))
                    {
                        btnCreateGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        btnViewGoodsReturned.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }

                    if (!hasOutstanding)
                    {
                        btnCreateGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnViewGoodsReturned.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }
                    else
                    {
                        // Disable Button View Goods Received when there are not Goods Received
                        if (!(BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReturned)))
                        {
                            btnViewGoodsReturned.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            rpgActionDocument.ItemLinks.Add(btnCreateGoodsReturned);
                        }
                    }
                }
            }
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
        }

        private void btnCreateGoodsReturned_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Supplier.GoodsReturnedForm childForm = new Supplier.GoodsReturnedForm();
            childForm.Doc_Header = BL.SYS.DocumentProcessor.CreateGoodsReturnedFromGoodsReceived((DB.SYS_DOC_Header)BindingSource.DataSource, DataContext);
            childForm.ItemState = EntityState.Generated;
            ForceClose = true;
            this.Close();
            ShowForm(childForm);  
        }

        private void btnViewGoodsReturned_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.GoodsReturned, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
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
