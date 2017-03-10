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


namespace CDS.Client.Desktop.Core.Period
{
    public partial class ClosePeriodDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private DB.SYS_Period period = null;

        public ClosePeriodDialogue()
        {
            InitializeComponent();
        }

        public ClosePeriodDialogue(Int64 PeriodId)
        {
            InitializeComponent();

            period = BL.SYS.SYS_Period.Load(PeriodId, DataContext);
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                txtPeriod.EditValue = period.Code;

                RunSystemChecks();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RunSystemChecks()
        {
            try
            {
                List<SystemCheck> systemChecks = new List<SystemCheck>();

                // TODO: Do checks and balances to see if everything is ok! This may have to be done asynchronously

                // ADMINISTRATIVE CHECKS
                // Check 1: Check that there are no unposted entries - they must all be posted or rejected
                if (DataContext.EntityAccountingContext.GLX_Header.Where(n => n.PeriodId == period.Id && n.StatusId == 50).Count() == 0)
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 0, CheckStatus = "All Entries have been signed off." });
                }
                else
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 1, CheckStatus = "All Entries have not been signed off." });
                }

                // Check 2: Check that ALL preceding periods have been closed - mandatory : 51 == CLOSED
                DB.SYS_Period previousperiod = BL.SYS.SYS_Period.GetPreviousItem(period, DataContext);

                // If there is no previous period
                if (previousperiod == null)
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 0, CheckStatus = "All Preceding Period has been closed." });
                }
                else if (previousperiod.StatusId == (byte)BL.SYS.SYS_Status.Closed)
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 0, CheckStatus = "All Preceding Period has been closed." });
                }
                else
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 1, CheckStatus = "All Preceding Period has not been closed." });
                }

                // SANITY CHECKS
                // Check 1: Check that documents and ledger entries match up

                // Check that ledger entries and balances match up (starting balance + movement = ending balance)

                DB.SYS_Period startperiod = BL.SYS.SYS_Period.GetPreviousItem(period, DataContext);

                decimal? startbalance = startperiod == null ? 0 : DataContext.EntityAccountingContext.GLX_History.Where(n => n.PeriodId == startperiod.Id).Sum(l => l.Amount);
                decimal? movement = DataContext.ReadonlyContext.VW_Line.Where(n => n.PeriodCode == period.Code).ToList<DB.VW_Line>().Sum(l => l.Amount);
                decimal? endbalance = DataContext.EntityAccountingContext.GLX_History.Where(n => n.PeriodId == period.Id).Sum(l => l.Amount);

                if (Math.Abs((startbalance ?? 0) + (movement ?? 0) - (endbalance ?? 0)) == 0)
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 0, CheckStatus = "Movements for this period is correct." });
                }
                else
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 1, CheckStatus = "Movements for this period isn't correct." });
                }

                // Check 3: Check that ledger entries per account (amounts = zero / debit = credit)

                if ((movement ?? 0) == 0)
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 0, CheckStatus = "Movements Zeroes for this period." });
                }
                else
                {
                    systemChecks.Add(new SystemCheck() { ImageId = 1, CheckStatus = "Movements doesn't Zeroes for this period." });
                }

                // Check 4: Check that ledger balances balance (amounts = zero)

                BindingSourceChecks.DataSource = systemChecks;
                grdChecks.RefreshDataSource();

                //Disables button if there are errors
                btnClosePeriod.Enabled = !(systemChecks.Where(n => n.ImageId > 0).Count() > 0);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        #region Validation

        private bool ValidateBeforeSave()
        {
            try
            {
                bool isValid = true;
                isValid = !(((List<SystemCheck>)BindingSourceChecks.DataSource).Where(n => n.ImageId > 0).Count() > 0);

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Check if pervious period is closed before you can contunue.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 12/03/2012</remarks>
        private bool IsPreviousPeriodClosed()
        {
            try
            {
                //50 = Open
                //51 = Closed
                return BL.SYS.SYS_Period.GetPreviousItem(period, DataContext).StatusId == (byte)BL.SYS.SYS_Status.Closed;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        #endregion

        #region Event Handlers

        private void btnClosePeriod_Click(object sender, EventArgs e)
        {
            try
            {
                period.StatusId = (byte)BL.SYS.SYS_Status.Closed;

                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        DataContext.SaveChangesEntityAccountingContext();
                        DataContext.SaveChangesEntitySystemContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityInventoryContext.AcceptAllChanges();
                    DataContext.EntitySystemContext.AcceptAllChanges();
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                DataContext.EntityInventoryContext.RejectChanges();
                DataContext.EntitySystemContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        #endregion
    }

    class SystemCheck
    {
        int imageId;
        String checkStatus;

        public SystemCheck()
        {

        }

        /// <summary>
        /// 0 : Pass
        /// 1 : Fail
        /// </summary>
        public int ImageId
        {
            get
            {
                return imageId;
            }

            set
            {
                if (value != imageId)
                    imageId = value;
            }
        }

        public string CheckStatus
        {
            get
            {
                return checkStatus;
            }

            set
            {
                if (value != checkStatus)
                    checkStatus = value;
            }
        }
    }
}
