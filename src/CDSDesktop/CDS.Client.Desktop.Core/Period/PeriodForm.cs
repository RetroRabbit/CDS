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


namespace CDS.Client.Desktop.Core.Period
{
    public partial class PeriodForm : CDS.Client.Desktop.Essential.BaseForm
    {
        public PeriodForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                this.ReadOnly = true;
                txtStartDate.Properties.Buttons.Clear();
                txtEndDate.Properties.Buttons.Clear();
                ddlStatus.Properties.Buttons.Clear();
                ServerModeSourceStatus.QueryableSource = DataContext.EntitySystemContext.SYS_Status;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void LoadPeriod(DB.SYS_Period glxPeriod)
        {
            try
            {
                if (glxPeriod != null)
                {
                    BindingSource.DataSource = glxPeriod;
                    btnEndPeriod.Enabled = glxPeriod.StatusId != (byte)BL.SYS.SYS_Status.Closed;
                    btnPostPeriod.Enabled = glxPeriod.StatusId != (byte)BL.SYS.SYS_Status.Closed;

                    Int64 endperiodid = glxPeriod.Id;
                    DB.SYS_Period startperiod = DataContext.EntitySystemContext.SYS_Period.Where(o => o.EndDate < glxPeriod.EndDate).OrderByDescending(o => o.EndDate).FirstOrDefault();
                    Int64 startperiodid = -1;

                    if (startperiod != null)
                        startperiodid = startperiod.Id;

                    List<DB.VW_Balance> balances = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountMasterControlId == null & (n.PeriodId == startperiodid || n.PeriodId == endperiodid)).ToList();


                    var accounts = balances.Select(n => new { n.AccountId, n.AccountCode, n.AccountName, n.TypeFlag1, n.TypeCode }).Distinct().ToList();

                    foreach (var account in accounts)
                    {
                        var end = balances.Where(n => n.AccountId == account.AccountId && n.PeriodId == endperiodid).Select(n=>n.BalanceAmount.Value).FirstOrDefault();
                        var start = balances.Where(n => n.AccountId == account.AccountId && n.PeriodId == startperiodid).Select(n=>n.BalanceAmount.Value).FirstOrDefault();

                        decimal endbalance = end != null ? end : 0;
                        decimal startbalance = start != null ? start : 0;


                        balances.Add(new DB.VW_Balance()
                        {
                            AccountId = account.AccountId,
                            AccountCode = account.AccountCode,
                            AccountName = account.AccountName,
                            TypeFlag1 = account.TypeFlag1,
                            TypeCode = account.TypeCode,
                            PeriodCode = "MOVEMENT",
                            BalanceAmount = (endbalance) - (startbalance)
                        });
                    }


                    BindingSourceBalance.DataSource = balances;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open a Period record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the Period to open.</param>
        /// <remarks>Created: Theo Crous 27/11/2011</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                LoadPeriod(BL.SYS.SYS_Period.Load(Id, DataContext));//DataContext.EntitySystemContext.SYS_Period.Where(n => n.Id == (int)Id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the next Period record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 05/12/2011</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();
                LoadPeriod(BL.SYS.SYS_Period.GetNextItem((DB.SYS_Period)BindingSource.DataSource, DataContext));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous Period record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 05/12/2011</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();
                LoadPeriod(BL.SYS.SYS_Period.GetPreviousItem((DB.SYS_Period)BindingSource.DataSource, DataContext));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = false;
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPERECR);
            btnEndPeriod.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPERE01) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnPostPeriod.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPERE01) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

            if (!BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
            {
                btnPostPeriod.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Opens the End Period for the current selected period
        /// </summary>
        /// <remarks>Created: Werner Scheffer 02/12/2011</remarks>
        private void btnEndPeriod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var prevPeriod = BL.SYS.SYS_Period.GetPreviousItem((DB.SYS_Period)BindingSource.DataSource, DataContext);
                if (prevPeriod != null && prevPeriod.StatusId == (byte)BL.SYS.SYS_Status.Open)
                {
                    Essential.BaseAlert.ShowAlert("Close period not allowed", "All previous periods need to be close before you can close the selected period", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    return;
                }

                if (new ClosePeriodDialogue(((DB.SYS_Period)BindingSource.DataSource).Id).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Refresh form if the period has been ended
                    OpenRecord(((DB.SYS_Period)BindingSource.DataSource).Id);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Opens the Post Period for the current selected period
        /// </summary>
        /// <remarks>Created: Werner Scheffer 12/03/2012</remarks>
        private void btnPostPeriod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (new PostPeriodDialogue(((DB.SYS_Period)BindingSource.DataSource).Id).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Refresh form if the period has been ended
                    OpenRecord(((DB.SYS_Period)BindingSource.DataSource).Id);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

    }
}

