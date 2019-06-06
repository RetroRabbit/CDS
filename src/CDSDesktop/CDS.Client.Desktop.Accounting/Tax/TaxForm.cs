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
using System.Transactions;


namespace CDS.Client.Desktop.Accounting
{
    public partial class TaxForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.GLX_Tax glxTax;
        /// <summary>
        /// Boolean that returns true if Document has never been submited to the database (Is a new document)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (glxTax != null)
                    return (DataContext.EntityAccountingContext.GetEntityState(glxTax) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public TaxForm()
        {
            InitializeComponent();
        }

        public TaxForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = glxTax;
        }

         /// <summary>
        /// Load any necesary lookup values.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 27/02/2012</remarks>
        protected override void OnStart()
        {
            try
            {
                ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
                base.OnStart();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// The binding source is bound to a new instance of an Tax. This is for the instances where a new record is to be created.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                glxTax = BL.GLX.GLX_Tax.New;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void RefreshRecord()
        {
            base.RefreshRecord();
            if (!IsNew)
            {
                DataContext.EntityAccountingContext.ReloadEntry(BindingSource.DataSource);
                InstantFeedbackSourceAccount.Refresh();
            }
            else
            {
                InstantFeedbackSourceAccount.Refresh();
            }
        }

        /// <summary>
        /// Open an Account record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the Account to open.</param>
        /// <remarks>Created: Werner Scheffer 27/02/2012</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                glxTax = BL.GLX.GLX_Tax.Load(Id, DataContext);
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
                            BL.EntityController.SaveGLX_Tax(glxTax, DataContext);
                            DataContext.SaveChangesEntityAccountingContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Commit all changes of the Account record to the database.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 27/02/2012</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        /// <summary>
        /// Loads and opens the next Tax record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 01/08/2012</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                DB.GLX_Tax glxTax = BL.GLX.GLX_Tax.GetNextItem((DB.GLX_Tax)BindingSource.DataSource, DataContext);
                if (glxTax != null)
                {
                    BindingSource.DataSource = glxTax;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous Tax record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 01/08/2012</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();

                DB.GLX_Tax glxTax = BL.GLX.GLX_Tax.GetPreviousItem((DB.GLX_Tax)BindingSource.DataSource, DataContext);
                if (glxTax != null)
                {
                    BindingSource.DataSource = glxTax;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (IsNew)
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FITAREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FITARECR);
            AllowRefresh = true;
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                isValid = HasAccount();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool HasAccount()
        {
            try
            {
                if (ddlAccount.EditValue == DBNull.Value || ddlAccount.EditValue == null)
                {
                    ddlAccount.ErrorText = "Select Account ...";
                    return false;

                }
                else
                {
                    ddlAccount.ErrorText = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private void InstantFeedbackSourceAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            //Master Accountant filtering
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED))
            e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);
            else {
                long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.SiteId == defaultSiteId);
            }
        }
    }

}
