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
    public partial class JobQuoteForm : CDS.Client.Desktop.Document.BaseDocument
    {
     

        public JobQuoteForm()
        {
            InitializeComponent();
        }

        public JobQuoteForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();

            UseWarehouseDiscount = true;
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
             
            if (ItemState == EntityState.Open)
            {
                List<DB.SYS_DOC_Header> refDocs = BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).ToList();

                if (refDocs.Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.Job))
                {
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WSDOJCRECR))
                    {
                        btnViewJob.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
                else
                {
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WSDOJCRE))
                    {
                        btnCreateJob.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }

               
            }
        }

        private void btnLostSale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new LostSale.LostSaleDialogue(CompanyType)).ShowDialog();
        }

        private void btnCreateJob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {

                if (DataContext.EntitySystemContext.GetEntityState(Doc_Header) == System.Data.Entity.EntityState.Detached)
                {   //Need to save Job Quote before converting
                    OnSaveRecord();
                }

                DB.SYS_DOC_Header job = BL.SYS.DocumentProcessor.CreateJobFromJobQuote(Doc_Header, DataContext);
               
                IgnoreChanges = true;
                this.Close();

                var mainform = Application.OpenForms["MainForm"];
                Type typExternal = mainform.GetType();
                System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowJobFormFromHeader");

                methodInf.Invoke(mainform, new object[] { job, true });
            }
        }

        private void btnViewJob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowJobListForm");

            methodInf.Invoke(mainform, new object[] { Doc_Header.TrackId });
        }
    }
}
