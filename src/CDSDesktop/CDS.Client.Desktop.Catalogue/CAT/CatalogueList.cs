using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    public partial class CatalogueList : CDS.Client.Desktop.Essential.BaseList
    {
        public CatalogueList()
        {
            InitializeComponent();
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                CatalogueManagementForm childForm = new CatalogueManagementForm(Id);
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                CatalogueManagementForm childForm = new CatalogueManagementForm();
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INCA);
        }  

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new CatalogueImportExportDialogue("Import")).ShowDialog();
        }

    }
}
