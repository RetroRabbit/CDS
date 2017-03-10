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
    public partial class TAXInvoiceForm : CDS.Client.Desktop.Document.BaseDocument
    { 
        public TAXInvoiceForm()
        {
            InitializeComponent();
        }

        public TAXInvoiceForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnNewRecord()
        {
            //base.OnNewRecord();
            throw new Exception("Not Allowed Exception", new Exception("OnNewRecord on SalesCredit should be used cannot create TAX Invoice from scratch"));
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
                if (!IsNew)
                {
                    bool hasCredited = false;
                    bool hasReceived = false;
                    //Make the Cancel button visible if there are any outstanding items
                    foreach (var lineGrouped in Doc_Header.SYS_DOC_Line.Where(n => n.Quantity >= 0).GroupBy(l => l.ItemId).Select(g => new { Item = g.Key, LineItem = g.FirstOrDefault().LineItem, QuantityCredited = g.Sum(l => l.Quantity - l.QtyReceived), QuantityReceived = g.Sum(l => l.QtyReceived), AmountCredited = g.Sum(r => r.AmountCredited) }))
                    {
                        if (!hasReceived && new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(lineGrouped.LineItem.TypeId) && lineGrouped.QuantityCredited != 0)
                        {
                            hasCredited = true;
                            //break;
                        }

                        if (!hasCredited && lineGrouped.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account && lineGrouped.AmountCredited != 0)
                        {
                            hasCredited = true;
                            //break;
                        }

                        if (!hasReceived && new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }.Contains(lineGrouped.LineItem.TypeId) && lineGrouped.QuantityReceived != 0)
                        {
                            hasReceived = true;
                            //break;
                        }
                    }

                    //If the document has a Sales Credit, nothing outstanding and the user has access to View Sales Credits
                    if (hasCredited && !hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSCRE))
                    {
                        btnViewCredits.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnViewCredits.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    }
                    //If the document has a Sales Credit, has outstanding and the user has access to Create Sales Credits
                    else if (hasCredited && hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSCRECR))
                    {
                        btnViewCredits.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnCreateCreditNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    //If the document has no Sales Credit, has outstanding and the user has access to Create Sales Credits
                    else if (!hasCredited && hasReceived && SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSCRECR))
                    {
                        btnCreateCreditNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        rpgActionDocument.ItemLinks.Add(btnCreateCreditNote);
                    }
                }
            }
        }

        private void btnCreateCreditNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer.CreditNoteForm childForm = new Customer.CreditNoteForm();
            childForm.Doc_Header = BL.SYS.DocumentProcessor.CreateCreditNoteFromTAXInvoice((DB.SYS_DOC_Header)BindingSource.DataSource, DataContext);
            childForm.ItemState = EntityState.Generated;
            ForceClose = true;
            this.Close();
            ShowForm(childForm); 
        }

        private void btnViewCredits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Document.BaseDocumentList childForm = new BaseDocumentList(BL.SYS.SYS_DOC_Type.CreditNote, Doc_Header.TrackId);
            //ForceClose = true;
            //this.Close();
            ShowForm(childForm);
        }
    }
}
