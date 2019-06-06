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
using System.Transactions;

namespace CDS.Client.Desktop.Main
{
    public partial class ModuleList : CDS.Client.Desktop.Essential.BaseList
    {
        public ModuleList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                AllowNewRecord = false;
                AllowOpenRecord = false;
                XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Access] = ?", true);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }  
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            btnActivateModule.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYMOREED) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnDeActivate.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYMOREED) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        protected override void BindData()
        {
            base.BindData();
        }

        private void btnActivateModule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(new Main.ModuleWizard());
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (GridView.GetFocusedRow() is DevExpress.Data.NotLoadedObject)
                return;

            var row = (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(GridView.GetFocusedRow())).OriginalRow as CDS.Client.DataAccessLayer.DB.VW_Module);

            if (row == null)
                return;

            if (row.Access.Value)
            {
                btnDeActivate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnDeActivate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void btnDeActivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(GridView.GetFocusedRow())).OriginalRow as CDS.Client.DataAccessLayer.DB.VW_Module);

            if (row == null)
                return;

            if (row.Access.Value)
            {
                if (Essential.BaseAlert.ShowAlert("De-Activate Module", String.Format("You are about to De-Active the selected module {0} - {1}.\nDo you want to continue ?", row.Module, row.Description), Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            DB.SYS_Module module = BL.SYS.SYS_Module.Deactivate(row.Id, DataContext);
                            BL.EntityController.SaveSYS_Module(module, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        //HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                }
            }
        }

    }
}
