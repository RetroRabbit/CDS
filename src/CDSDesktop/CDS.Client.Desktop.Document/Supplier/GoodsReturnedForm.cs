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
    public partial class GoodsReturnedForm : CDS.Client.Desktop.Document.BaseDocument
    {
        public GoodsReturnedForm()
        {
            InitializeComponent();
        }

        public GoodsReturnedForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (ItemState == EntityState.Open)
            {
                //If you have access to view Goods Received and the Credit Note has a Goods Received
                if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.PUDOGRRE)
                    && BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived))
                {
                    btnViewGoodsReceived.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
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
