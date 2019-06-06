using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Transactions;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Center
{
    public partial class CenterForm : CDS.Client.Desktop.Essential.BaseForm
    {
        public CenterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load any necessary lookup values.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnStart()
        {
            base.OnStart();
        }

        /// <summary>
        /// The binding source is bound to a new instance of an Segment. This is for the instances where a new record is to be created.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                BindingSource.DataSource = BL.SYS.SYS_Entity.NewCenter;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open a Segment record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the Account to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                base.OpenRecord(Id);
                BindingSource.DataSource = BL.SYS.SYS_Entity.Load(Id, DataContext);
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

                    ((DB.SYS_Entity)BindingSource.DataSource).CodeSub = ((DB.SYS_Entity)BindingSource.DataSource).CodeMain;
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Entity((DB.SYS_Entity)BindingSource.DataSource, DataContext);
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
                //DataContext.EntitySystemContext.RollBackTransaction();
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Commit all changes of the Segment record to the database.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        /// <summary>
        /// Loads and opens the next Segment record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                DB.SYS_Entity glxSegment = BL.SYS.SYS_Entity.GetNextItem((DB.SYS_Entity)BindingSource.DataSource, DataContext);
                if (glxSegment != null)
                {
                    BindingSource.DataSource = glxSegment;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous Segment record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();

                DB.SYS_Entity glxSegment = BL.SYS.SYS_Entity.GetPreviousItem((DB.SYS_Entity)BindingSource.DataSource, DataContext);
                if (glxSegment != null)
                {
                    BindingSource.DataSource = glxSegment;
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
            AllowArchive = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE01));
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYCEREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYCERECR);
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
                isValid = IsCodeValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsCodeValid()
        {
            bool isValid = true;
            isValid = !DataContext.EntitySystemContext.SYS_Entity.Any(n => n.Id != ((DB.SYS_Entity)BindingSource.DataSource).Id && n.TypeId == (byte)BL.SYS.SYS_Type.Center && n.CodeMain == ((DB.SYS_Entity)BindingSource.DataSource).CodeMain);
            if (!isValid)
                Essential.BaseAlert.ShowAlert("Invalid Code", "The code you have entered is already in use change code before saving", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

            return isValid;
        }
    }
}
