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



namespace CDS.Client.Desktop.Core.Site
{
    public partial class SiteList : CDS.Client.Desktop.Essential.BaseList
    {
        public SiteList()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {

            try
            {
                base.BindData();
                //TODO : Add security for Site list
                //AllowNewRecord = BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SYSE04);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnOpenRecord(long Id)
        {
            
            try
            {
              
                base.OnOpenRecord(Id);
                SiteForm childForm = new SiteForm(Id);
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

                SiteForm childForm = new SiteForm();
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSIRECR);
            btnCopySite.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSIRECR) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        /*protected override void OnShown(EventArgs e)
        {
            
            base.OnShown(e);

            OnOpenRecord(DataContext.EntitySystemContext.SYS_Site.FirstOrDefault().EntityId);
            this.Close();
        }*/

        private void btnCopySite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DB.SYS_Site copySite = BL.ApplicationDataContext.DeepClone<DB.SYS_Site>(BL.SYS.SYS_Site.LoadByEntityId(SelectedRowId, DataContext), BL.SYS.SYS_Site.New);
                DB.SYS_Entity copyEntity = BL.ApplicationDataContext.DeepClone<DB.SYS_Entity>((BL.SYS.SYS_Site.LoadByEntityId(SelectedRowId, DataContext, new List<String>() { "SYS_Entity" })).SYS_Entity, BL.SYS.SYS_Entity.NewSite);
                copySite.SYS_Entity = copyEntity; 
                SiteForm childForm = new SiteForm(); 
                childForm.OpenRecord(copySite);
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

    }
}
