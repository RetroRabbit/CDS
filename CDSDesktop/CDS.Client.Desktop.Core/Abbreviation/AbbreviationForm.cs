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

namespace CDS.Client.Desktop.Core.Abbreviation
{
    public partial class AbbreviationForm : CDS.Client.Desktop.Essential.BaseForm
    {
        public AbbreviationForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        /// <summary>
        /// The binding source is bound to a new instance of an Abbreviation. This is for the instances where a new record is to be created.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/12/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                BindingSource.DataSource = BL.SYS.SYS_Abbreviation.New;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open an Abbreviation record from the database.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/12/2011</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                BindingSource.DataSource = BL.SYS.SYS_Abbreviation.Load(Id, DataContext);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    if (!IsValid)
                        return false;

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Abbreviation((DB.SYS_Abbreviation)BindingSource.DataSource, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Commit all changes of the Account record to the database.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/12/2011</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
        }

        /// <summary>
        /// Validates all controls before saving
        /// </summary>
        /// <returns>Boolean value indicating that the values in the controls are correct</returns>
        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                isValid = IsAbbreviationValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }

        }

        /// <summary>
        /// No duplicate abbreviation exists
        /// </summary>
        /// <returns></returns>
        private bool IsAbbreviationValid()
        {
            bool isValid = true;
            isValid = !DataContext.EntitySystemContext.SYS_Abbreviation.Any(n => n.Id != ((DB.SYS_Abbreviation)BindingSource.DataSource).Id && n.Abbreviation == ((DB.SYS_Abbreviation)BindingSource.DataSource).Abbreviation);
            if (!isValid)
                Essential.BaseAlert.ShowAlert("Invalid Abbreviation", "The abbreviation you have entered is already in use change abbreviation before saving", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

            return isValid;
        }
    }
}
