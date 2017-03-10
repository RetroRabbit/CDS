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
    public partial class ModuleWizard : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.VW_Module selectedModule;

        public ModuleWizard()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                AllowSave = false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYMOREED);
        }

        private void InstantFeedbackSourceModule_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Module.Where(n => n.Access == false && n.Module != "SYS");
        }

        private void wcModule_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == wpSelectModule)
            {
                object FocusedRow = grvModule.GetFocusedRow();
                selectedModule = (DB.VW_Module)((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)FocusedRow).OriginalRow;
            }
        }

        private void wcModule_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {

        }

        private void wcModule_FinishClick(object sender, CancelEventArgs e)
        {
            try
            {
                //DataContext.EntitySystemContext.BeginTransaction();
                //TODO : Add some code that verifies the code before saving to database
                if (true)
                {
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            DB.SYS_Module module = BL.SYS.SYS_Module.Load(selectedModule.Id, DataContext);
                            module.Code = txtAccessCode.Text;
                            BL.EntityController.SaveSYS_Module(module, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        Essential.BaseAlert.ShowAlert("Module Active", "You have succesfully activated the selected module, please log out and back in for changes to take effect.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        //HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }

                    }
                else
                {
                    Essential.BaseAlert.ShowAlert("Module Activation", "Unfortunately you code could not be verified please check the code you entered or contact our support team.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                //DataContext.EntitySystemContext.RollBackTransaction();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
