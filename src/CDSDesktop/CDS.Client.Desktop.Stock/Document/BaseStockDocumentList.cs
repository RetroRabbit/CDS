using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;

namespace CDS.Client.Desktop.Stock.Document
{
    public partial class BaseStockDocumentList : CDS.Client.Desktop.Essential.BaseList
    {
        public BL.SYS.SYS_DOC_Type? DocumentType { get; set; }
        private Int64? TrackId { get; set; }
 
        public BaseStockDocumentList()
        {
            InitializeComponent();
        }

        public BaseStockDocumentList(BL.SYS.SYS_DOC_Type documentType)
        {
            InitializeComponent();
            DocumentType = documentType;
        }

        public BaseStockDocumentList(BL.SYS.SYS_DOC_Type? documentType, Int64 trackId)
        {
            InitializeComponent();
            DocumentType = documentType;
            this.TrackId = trackId;
        }

        protected override void OnStart()
        {

            base.OnStart();
            if (DocumentType != null)
            {
                byte documentType = (byte)DocumentType;
                this.Text = DataContext.EntitySystemContext.SYS_DOC_Type.Where(n => n.Id.Equals(documentType)).Select(n => n.Name).FirstOrDefault();

                if (ReferenceEquals(XPOInstantFeedbackSource.FixedFilterCriteria, null))
                    XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[HeaderId.TypeId.Id] = ? AND [HeaderId.SiteId.Id] = ?", (byte)DocumentType.Value, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);

            }
                
            this.SuperTipParameter = this.Text + "," + this.Text;

        }

        protected override void BindData()
        { 
            try
            {
                base.BindData();
                if (TrackId != null)
                    GridView.ActiveFilterString = String.Format("[HeaderId.TrackId.Id] = {0}", TrackId);

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (DocumentType == null)
            {
                AllowNewRecord = false;
            }
            else
            {
                switch ((byte)DocumentType)
                {
                    case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                        AllowNewRecord = false;
                        break;
                }
            }
        }

        protected override void OnOpenRecord(long Id)
        {
            base.OnOpenRecord(Id);
            if (DocumentType == null)
            {
                DB.VW_StockDocument entry = (DB.VW_StockDocument)((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(GridView.GetFocusedRow())).OriginalRow;
                DocumentType = ((BL.SYS.SYS_DOC_Type)entry.TypeId);
            }
            Essential.BaseForm child = null;
            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    child = new InventoryAdjustmentForm(Id);
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    //child = new Document.Customer.BackOrderForm(Id);
                    break;
            }
            ShowForm(child);
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            Essential.BaseForm child = null;
            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    //child = new Document.Customer.BackOrderForm();
                    break;
            }
            ShowForm(child);
        }
    }
}
