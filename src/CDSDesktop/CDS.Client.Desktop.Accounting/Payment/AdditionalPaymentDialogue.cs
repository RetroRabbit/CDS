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

namespace CDS.Client.Desktop.Accounting.Payment
{
    public partial class AdditionalPaymentDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public List<Int64> PaymentAccounts { get; set; }

        public DateTime Date
        {
            get { return Convert.ToDateTime(txtDate.EditValue); }
        }

        public String Reference
        {
            get { return Convert.ToString(txtReference.EditValue); }
        }

        public String Description
        {
            get { return Convert.ToString(txtDescription.EditValue); }
        }

        public Int64 DebtorAccountId
        {
            get { return Convert.ToInt64(ddlAccount.EditValue); }
        }

        public String DebtorAccountTitle
        {
            get { return Convert.ToString(ddlAccount.Text); }
        }

        public Int64 PaymentAccountId
        {
            get { return Convert.ToInt64(ddlPaymentAccount.EditValue); }
        }

        public Int64 TrackNumber
        {
            get { return txtTrackNumber.EditValue == null ? -1 : Convert.ToInt64(txtTrackNumber.EditValue); }
        }

        public Decimal Amount
        {
            get { return Convert.ToDecimal(txtAmount.EditValue); }
        }

        public String Aging
        {
            get { return Convert.ToString(ddlAging.EditValue); }
        }

        public AdditionalPaymentDialogue()
        {
            InitializeComponent(); 
        }

        protected override void OnStart()
        {
            base.OnStart();
            txtDate.DateTime = DateTime.Now;
        }

        protected override void BindData()
        {
            base.BindData();
            EntityServerModeSourceTracking.QueryableSource = DataContext.EntitySystemContext.SYS_Tracking.Select(n => new { n.Id, TrackingNumber = n.Id, n.Initiator }).Distinct();


            //List<PaymentAccount> accounts = Essential.SystemSettingForm.DeSerializePaymentAccounts(DataAccessLayer.ApplicationContext.Instance.CompanySite.PaymentAccounts, typeof(List<GLX.PaymentAccount>));
            if (this.Tag is Accounting.Payment.MakePaymentsForm)
            {
                DB.SYS_Entity entityAccount = BL.SYS.SYS_Entity.Load(BL.ApplicationDataContext.Instance.SiteAccounts.Creditors.EntityId, DataContext);
                DB.GLX_Account creditorAccount = BL.GLX.GLX_Account.Load(entityAccount.Id, DataContext);
               
                ServerModeSourceCompanyAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.ControlId == creditorAccount.Id);
                TabIcon = global::CDS.Shared.Resources.Properties.Resources.money_minus_32;
            }
            else if (this.Tag is Accounting.Payment.ReceivePaymentsForm)
            {
                DB.SYS_Entity entityAccount = BL.SYS.SYS_Entity.Load(BL.ApplicationDataContext.Instance.SiteAccounts.Debtors.EntityId, DataContext);
                DB.GLX_Account debtorsAccount = BL.GLX.GLX_Account.Load(entityAccount.Id, DataContext);
                ServerModeSourceCompanyAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.ControlId == debtorsAccount.Id);
                TabIcon = global::CDS.Shared.Resources.Properties.Resources.money2_add_32;
            }
            else
                ServerModeSourceCompanyAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);

            // ServerModeSourcePaymentAccount.QueryableSource = CDS.Client.DataAccessLayer.ApplicationContext.Instance.Context.GLX_Account.Where(n=> accounts.Select(l=>l.AccountId).Contains(n.Id));
            //Filter for master Accountants
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
            ServerModeSourcePaymentAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => PaymentAccounts.Contains(n.Id));
            else {
                long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                ServerModeSourcePaymentAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => PaymentAccounts.Contains(n.Id) && n.SiteId == defaultSiteId);
            }
            ServerModeSourceAging.QueryableSource = DataContext.EntityAccountingContext.GLX_Aging;
        }
          
        private bool ValidateBeforeSave()
        {
            bool isValid = true;
            isValid = ValidationProvider.Validate();
            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!ValidateBeforeSave())
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void chkNewTrackNumber_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNewTrackNumber.Checked)
                {
                    txtTrackNumber.EditValue = null;
                    txtTrackNumber.Enabled = false;

                    ValidationProvider.RemoveControlError(txtTrackNumber);
                }
                else
                {
                    txtTrackNumber.Enabled = true;
                    if (txtTrackNumber.EditValue != null)
                        txtTrackNumber.EditValue = null;

                    DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
                    conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
                    conditionValidationRule.ErrorText = "Select Tracking Number ...";
                    conditionValidationRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                    ValidationProvider.SetValidationRule(txtTrackNumber, conditionValidationRule);

                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
         
        private void ddlAccount_Enter(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate { ((DevExpress.XtraEditors.SearchLookUpEdit)sender).ShowPopup(); }));
        }

        private void ddlPaymentAccount_Enter(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate { ((DevExpress.XtraEditors.SearchLookUpEdit)sender).ShowPopup(); }));
        }
    }
}
