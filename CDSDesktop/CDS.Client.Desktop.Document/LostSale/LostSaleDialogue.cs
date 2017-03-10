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

namespace CDS.Client.Desktop.Document.LostSale
{
    public partial class LostSaleDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public BL.ORG.ORG_Type CompanyType { get; set; }

        public LostSaleDialogue(BL.ORG.ORG_Type companyType)
        {
            InitializeComponent();
            this.CompanyType = companyType;
        }

        protected override void OnStart()
        {
            base.OnStart();
            long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            ServerModeSourceCompany.QueryableSource = DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (int)CompanyType && n.SiteId == defaultSiteId);
            BindingSource.DataSource = BL.ORG.ORG_TRX_LostSale.New;
            PopulateValidation();
            var validationQuantity = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            validationQuantity.ErrorText = "Enter value greater than Zero";
            validationQuantity.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            validationQuantity.Value1 = 0;
            validationQuantity.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            ValidationProvider.SetValidationRule(txtQuantity, validationQuantity);
        }

        private void PopulateValidation()
        {
            try
            {
                DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule ValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();

                ValidationRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                //base.PopulateValidation();

                foreach (Control item in this.LayoutControl.Controls)
                {

                    if (item.DataBindings.Count != 0)
                    {
                        DB.VW_Validation validationItem =
                        BL.ApplicationDataContext.Instance.ValidationRestrictions.Where(n =>
                            ((System.Windows.Forms.BindingSource)(item.DataBindings[0].DataSource)).DataSource.ToString().Split('.').Last().StartsWith(n.TableName) &&
                            n.ColumnName.StartsWith(item.DataBindings[0].BindingMemberInfo.BindingField)).FirstOrDefault();

                        if (validationItem == null)
                            continue;
                        //If there is a lenght restriction add validator
                        if ((Int32)validationItem.LengthMax.Value != 0)
                        {
                            if (item is DevExpress.XtraEditors.TextEdit)
                                (item as DevExpress.XtraEditors.TextEdit).Properties.MaxLength = (Int32)validationItem.LengthMax.Value;

                        }
                        //If there is a required field restriction add validator
                        if (!validationItem.Nullable.Value)
                        {
                            if (validationItem.ColumnName.Contains("Id"))
                            {
                                //FK IDs not allowed to be Zero
                                ValidationRule.ErrorText = "Value cannot be blank";
                                ValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
                                ValidationRule.Value1 = 0;
                                ValidationProvider.SetValidationRule(item, ValidationRule);
                            }
                            else
                            {
                                //FK IDs not allowed to be NULL
                                ValidationRule.ErrorText = "Value cannot be blank";
                                ValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
                                ValidationProvider.SetValidationRule(item, ValidationRule);
                            }
                        }
                    }
                }
            }
            catch
            {
                 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                if (!ValidationProvider.Validate())
                    return;

                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        BL.EntityController.SaveORG_TRX_LostSale((DB.ORG_TRX_LostSale)BindingSource.DataSource, DataContext);
                        DataContext.SaveChangesEntityOrganisationContext();

                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityOrganisationContext.AcceptAllChanges();
                    this.Close();
                }
                catch (Exception ex)
                {
                    DataContext.EntityOrganisationContext.RejectChanges();
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }
    }
}
