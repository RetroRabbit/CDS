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

namespace CDS.Client.Desktop.Company.Contact
{
    public partial class ContactDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public DB.ORG_Contact ORGContact { get; set; }
        public DB.SYS_Person SYSPerson { get; set; }
        public BL.ORG.ORG_Department Department { get; set; }

        public ContactDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();

            ServerModeSourceDepartment.QueryableSource = DataContext.EntityOrganisationContext.ORG_Department;
            ServerModeSourceCompany.QueryableSource = DataContext.ReadonlyContext.VW_Company;

            ddlTitle.Properties.DataSource = Enum.GetNames(typeof(BL.SYS.SYS_Title));

            switch (Department)
            {
                case BL.ORG.ORG_Department.Sales:
                    BindingSource.DataSource = BL.ORG.ORG_Contact.NewSalesContact;
                    break;
                case BL.ORG.ORG_Department.Accounts:
                    BindingSource.DataSource = BL.ORG.ORG_Contact.NewAccountsContact;
                    break;
            }

            BindingSourcePerson.DataSource = BL.SYS.SYS_Person.New;

            PopulateValidation();
        }

        /// <summary>
        /// Populated the Validation for all the Control on the screen
        /// </summary>
        protected virtual void PopulateValidation()
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

        /// <summary>
        /// Checks that below conditions are valid.
        /// * Type for control account has been selected
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 19/03/2014</remarks>
        private bool ValidateBeforeSave()
        {
            try
            {
                bool isValid = true;
                isValid = ValidationProvider.Validate() && IsEntityNameValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks that the Entity had a name.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 24/05/2013</remarks>
        private bool IsEntityNameValid()
        {
            try
            {
                string title = ddlTitle.EditValue.ToString() + txtName.Text + txtSurname.Text;
                if (DataContext.ReadonlyContext.VW_Contact.Any(n => n.Title + n.Name + n.Surname == title))
                {
                    ddlTitle.ErrorText = "Duplicate contact ...";
                    txtName.ErrorText = "Duplicate contact ...";
                    txtSurname.ErrorText = "Duplicate contact ...";
                    return false;
                }
                else
                {
                    ddlTitle.ErrorText = string.Empty;
                    txtName.ErrorText = string.Empty;
                    txtSurname.ErrorText = string.Empty;
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsValid = ValidateBeforeSave();
                if (!IsValid)
                    return;

                ORGContact = (DB.ORG_Contact)BindingSource.DataSource;
                SYSPerson = (DB.SYS_Person)BindingSourcePerson.DataSource;

                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        BL.EntityController.SaveSYS_Person(SYSPerson, DataContext);
                        DataContext.SaveChangesEntitySystemContext();
                        ORGContact.PersonId = SYSPerson.Id;
                        BL.EntityController.SaveORG_Contact(ORGContact, DataContext);
                        DataContext.SaveChangesEntityOrganisationContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityOrganisationContext.AcceptAllChanges();
                    DataContext.EntitySystemContext.AcceptAllChanges();
                    Close();
                }
                catch (Exception ex)
                {
                    DataContext.EntityOrganisationContext.RejectChanges();
                    DataContext.EntitySystemContext.RejectChanges();
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }


    }
}
