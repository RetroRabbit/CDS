using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using DevExpress.XtraGrid.Views.Grid;

namespace CDS.Client.Desktop.Essential.UTL
{
    public partial class SelectDocumentDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public SelectDocumentDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();

            BindingSourceDocumentTypes.DataSource = DataContext.EntitySystemContext.SYS_DOC_Type.ToList();
            ServerModeSourcePeriod.QueryableSource = DataContext.ReadonlyContext.VW_Period;

            ddlPeriod.EditValue = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext).Id;
        }

        private void btnGoSearch_Click(object sender, EventArgs e)
        {
            InstantFeedbackSourceDocument.Refresh();
            ////TODO: Fid a way to fix this
            //List<byte> selectedtypes = chkTypeFilter.CheckedItems.Cast<DB.SYS_DOC_Type>().Select(n => n.Id).ToList();
            ////var context = CDS.Client.DataAccessLayer.ApplicationContext.Instance.Context;

            //DB.VW_Period period = ddlPeriod.GetSelectedDataRow() as DB.VW_Period;

            //ServerModeSourceDocument.QueryableSource = DataContext.ReadonlyContext.VW_Document.Where(n=> selectedtypes.Contains(n.TypeId.Value) &&
            //    n.DatePosted > period.StartDate && n.DatePosted < period.EndDate &&
            //  (   n.DocumentNumber.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceLong1.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceLong2.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceLong3.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceLong4.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceLong5.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceShort1.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceShort2.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceShort3.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceShort4.ToString().Contains(txtSearch.Text)
            //     || n.ReferenceShort5.ToString().Contains(txtSearch.Text))
            //    );

            ////// TODO: Add Period Filter Here !!!
            ////ServerModeSourceDocument.QueryableSource = context.DOC_Header
            ////    .Join(context.ORG_Company,
            ////        document => document.fkCompanyGuid,
            ////        company => company.pkCompanyGuid,
            ////        (document, company) => new { document, company })
            ////    .Join(context.tlStatus,
            ////        g => g.document.fkStatusGuid,
            ////        status => status.pStatusGuid,
            ////        (g, status) => new { g.document, g.company, status })
            ////    .Join(context.tlDocumentTypes,
            ////        g => g.document.fkDocumentTypeGuid,
            ////        type => type.pkDocumentTypeGuid,
            ////        (g, type) => new { g.document, g.company, g.status, type })
            ////    .Where(n =>
            ////        n.document.iNameNumericPart.ToString().Contains(txtSearch.Text)
            ////        || n.document.sOrderNumber.ToString().Contains(txtSearch.Text)
            ////        || n.document.sReferenceOurs.ToString().Contains(txtSearch.Text)
            ////        || n.document.sReferenceYours.ToString().Contains(txtSearch.Text)
            ////        || n.document.sContact.ToString().Contains(txtSearch.Text)
            ////        || n.company.sCode.ToString().Contains(txtSearch.Text)
            ////        || n.company.sTradingName.ToString().Contains(txtSearch.Text)
            ////    )
            ////    .Where(n => selectedtypes.Contains(n.document.fkDocumentTypeGuid.Value))
            ////    .Select(n => new { n.document.iDocumentId, n.document.pkDocumentGuid, DocumentType = n.type.sName, n.document.iNameNumericPart, n.document.dtFinancialDate, n.document.dTotalAmount, DocumentStatus = n.status.sName, CompanyTitle = n.company.sCode + " " + n.company.sTradingName })
            ////    ;
            //if (txtSearch.Text != String.Empty)
            //{
            //    ServerModeSourceDocument.QueryableSource = DataContext.ReadonlyContext.VW_Document.Where(n => selectedtypes.Contains(n.TypeId.Value) &&
            //        n.DatePosted > period.StartDate && n.DatePosted < period.EndDate &&
            //      (System.Data.Entity.SqlServer.SqlFunctions.StringConvert((decimal?)n.DocumentNumber).Contains(txtSearch.Text)
            //         || n.ReferenceLong1.Contains(txtSearch.Text)
            //         || n.ReferenceLong2.Contains(txtSearch.Text)
            //         || n.ReferenceLong3.Contains(txtSearch.Text)
            //         || n.ReferenceLong4.Contains(txtSearch.Text)
            //         || n.ReferenceLong5.Contains(txtSearch.Text)
            //         || n.ReferenceShort1.Contains(txtSearch.Text)
            //         || n.ReferenceShort2.Contains(txtSearch.Text)
            //         || n.ReferenceShort3.Contains(txtSearch.Text)
            //         || n.ReferenceShort4.Contains(txtSearch.Text)
            //         || n.ReferenceShort5.Contains(txtSearch.Text))
            //        );
            //}   
        }

        Int64 documentid;

        private void grdResults_DoubleClick(object sender, EventArgs e)
        {
            if ((grdResults.MainView as GridView).FocusedRowHandle < 0 /*|| !(grdResults.MainView as GridView).CalcHitInfo(MousePosition).InRow*/)
                return;

            //object FocusedRow = grvResults.GetFocusedRow();
            //documentid = Convert.ToInt64(FocusedRow.GetType().GetProperty("Id").GetValue(FocusedRow, null));
            if (((grvResults.GetFocusedRow() as DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread).OriginalRow as DB.VW_Document) == null)
                return;

            documentid = ((grvResults.GetFocusedRow() as DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread).OriginalRow as DB.VW_Document).Id;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public Int64 DocumentId
        {
            get { return this.documentid; }
        }

        private DB.VW_Period GetPeriod
        {
            get
            {
                return ddlPeriod.GetSelectedDataRow() as DB.VW_Period;
            }
        }

        private List<byte> SelectedTypes
        {
            get
            {
                return chkTypeFilter.CheckedItems.Cast<DB.SYS_DOC_Type>().Select(n => n.Id).ToList();
            }
        }
         
        private void InstantFeedbackSourceDocument_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Document.Where(n => SelectedTypes.Contains(n.TypeId.Value) &&
                n.DatePosted > GetPeriod.StartDate && n.DatePosted < GetPeriod.EndDate &&
              (     System.Data.Entity.SqlServer.SqlFunctions.StringConvert((decimal)n.DocumentNumber).Contains(txtSearch.Text)
                 || n.ReferenceLong1.Contains(txtSearch.Text)
                 || n.ReferenceLong2.Contains(txtSearch.Text)
                 || n.ReferenceLong3.Contains(txtSearch.Text)
                 || n.ReferenceLong4.Contains(txtSearch.Text)
                 || n.ReferenceLong5.Contains(txtSearch.Text)
                 || n.ReferenceShort1.Contains(txtSearch.Text)
                 || n.ReferenceShort2.Contains(txtSearch.Text)
                 || n.ReferenceShort3.Contains(txtSearch.Text)
                 || n.ReferenceShort4.Contains(txtSearch.Text)
                 || n.ReferenceShort5.Contains(txtSearch.Text))
                );
        }

        private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e)
        {
            string errorText = grvResults.DataController.LastErrorText;
            string defaultString = "Error occurred during processing server request";
            if (e.ToolTip != null && e.ToolTip.StartsWith(defaultString))
            {
                e.ToolTip = errorText;
            }
        }

        private void grdResults_ParentChanged(object sender, EventArgs e)
        {

        }

        private void grdResults_Paint(object sender, PaintEventArgs e)
        {
            if (grvResults.DataController.LastErrorText != string.Empty)
            {
            }
        }
    }
}
