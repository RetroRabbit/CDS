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
    public partial class PostPeriodDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private DB.SYS_Period period = null;

        public PostPeriodDialogue()
        {
            InitializeComponent();
        }

        public PostPeriodDialogue(Int64 PeriodId)
        {
            InitializeComponent();

            period = BL.SYS.SYS_Period.Load(PeriodId, DataContext);
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                ServerModeSourceAccount.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);
                BindingSource.DataSource = DataContext.ReadonlyContext.VW_PostPeriodFigures.Where(n => n.PeriodId == period.Id).ToList();
                ddlAccount.EditValue = BL.ApplicationDataContext.Instance.SiteAccounts.Profit.EntityId;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnPostPeriod_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: Fix this

                if (!ValidateBeforeSave())
                    return;

                if (CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Create Entries", "You are about to Post Entries are you sure you want to continue", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) != System.Windows.Forms.DialogResult.OK)
                    return;

                DB.GLX_Header glxHeader = BL.GLX.GLX_Header.New;
                //glxHeader.Date = BL.ApplicationContext.Instance.ServerDateTime;
                //Changed so that it is the "1st" transacrtion of the following month
                glxHeader.Date = period.EndDate.AddMinutes(1);
                glxHeader.Description = string.Format("Post Period Entries for {0}.", period.Title);
                glxHeader.Reference = String.Format("Year-end {0}", period.Code);
                //TODO: Chekc that this works
                glxHeader.PeriodId = BL.SYS.SYS_Period.GetNextItem(period, DataContext).Id;
                glxHeader.ReferencePeriodId = BL.SYS.SYS_Period.GetNextItem(period, DataContext).Id;
                glxHeader.PostedDate = BL.ApplicationDataContext.Instance.ServerDateTime;
                glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Posting;
                glxHeader.TrackId = -1;
                glxHeader.IsYearendHeader = true;
                //POASTED
                glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;

                decimal profitTotal = 0;

                foreach (DB.VW_PostPeriodFigures line in BindingSource)
                {
                    DB.GLX_Line glx_line = BL.GLX.GLX_Line.New;
                    glx_line.EntityId = line.EntityId;// BL.ApplicationContext.Instance.CompanySite.glx_Debtors;
                    //CURRENT
                    glx_line.AgingId = 1;
                    glx_line.Amount = line.Amount.Value;
                    glx_line.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line.EntityId, DataContext).CenterId;

                    //Total for profit entry
                    profitTotal += line.Amount.Value;
                    glxHeader.GLX_Line.Add(glx_line);

                }

                //PROFIT ENTRY
                DB.GLX_Line glx_line_profit = BL.GLX.GLX_Line.New;
                glx_line_profit.EntityId = (Int64)ddlAccount.EditValue;
                //CURRENT
                glx_line_profit.AgingId = 1;
                glx_line_profit.Amount = -profitTotal;
                glx_line_profit.CenterId = BL.GLX.GLX_Account.LoadByEntityId(glx_line_profit.EntityId, DataContext).CenterId;
                glxHeader.GLX_Line.Add(glx_line_profit);
                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        DB.SYS_Tracking sysTracking = BL.SYS.SYS_Tracking.New;
                        BL.EntityController.SaveSYS_Tracking(sysTracking, DataContext);
                        DataContext.SaveChangesEntitySystemContext();
                        glxHeader.TrackId = sysTracking.Id;
                        BL.EntityController.SaveGLX_Header(glxHeader, DataContext);
                        DataContext.SaveChangesEntityAccountingContext();
                        BL.GLX.GLX_Header.UpdateLedgerAccountBalance(glxHeader, DataContext);
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntitySystemContext.AcceptAllChanges();
                    DataContext.EntityAccountingContext.AcceptAllChanges();
                }
                catch (Exception ex)
                {
                    DataContext.EntitySystemContext.RejectChanges();
                    DataContext.EntityAccountingContext.RejectChanges();
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                bool isValid = true;
                isValid = IsAccountValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsAccountValid()
        {
            try
            {
                return ddlAccount.EditValue != null && ((Int64)ddlAccount.EditValue) != -1 && ((Int64)ddlAccount.EditValue) != 0;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

    }
}
