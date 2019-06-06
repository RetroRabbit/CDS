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
    public partial class NewFinancialYearDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        List<DB.SYS_Period> periods = null;

        public NewFinancialYearDialogue()
        {
            InitializeComponent(); 
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                DB.SYS_Period lastPeriod = DataContext.EntitySystemContext.SYS_Period.OrderByDescending(o => o.EndDate).FirstOrDefault();

                if (lastPeriod != null)
                {
                    txtFinancialYear.EditValue = lastPeriod.FinancialYear + 1;
                    ddlMonth.EditValue = lastPeriod.EndDate.ToString("MMMM");
                    txtFinancialYear.Enabled = false;
                    ddlMonth.Enabled = false;
                }
                else
                {
                    txtFinancialYear.EditValue = DateTime.Now.Year;
                    ddlMonth.EditValue = "January";
                }

                buildPeriods();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void txtFinancialYear_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                buildPeriods();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlMonth_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                buildPeriods();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void buildPeriods()
        {
            try
            {
                if (ddlMonth.SelectedIndex == -1)
                {
                    Essential.BaseAlert.ShowAlert("Invalid selection", "Month name incorrectly spelt", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    return;
                }
                periods = new List<DB.SYS_Period>();

                DateTime start = new DateTime(Convert.ToInt32(txtFinancialYear.EditValue) - 1, ddlMonth.SelectedIndex + 1, 1);
                
                for (int i = 0; i < 12; i++)
                {
                    start = start.AddMonths(1);
                    DB.SYS_Period item = BL.SYS.SYS_Period.New;
                    item.StartDate = start;
                    item.EndDate = start.AddMonths(1).AddSeconds(-1);
                    item.Code = item.EndDate.ToString("yyyy-MM (MMM)").ToUpper();
                    item.Name = item.EndDate.ToString("MMMM yyyy");
                    item.FinancialYear = Convert.ToInt16(txtFinancialYear.EditValue);
                    item.FinancialQuarter = Convert.ToInt16((i / 3) + 1);
                    item.StatusId = (byte)BL.SYS.SYS_Status.Open;
                    periods.Add(item);
                }

                BindingSourcePeriod.DataSource = periods;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnCreateYear_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    // Select all the nonduplciate entries to ensure that no duplicates are created.
                    List<DB.SYS_Period> nonduplicates = periods.Where(n => !DataContext.EntitySystemContext.SYS_Period.Select(o => o.Code).Contains(n.Code)).ToList();
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            //DataContext.EntitySystemContext.BeginTransaction();
                            BL.SYS.SYS_Period.Save(nonduplicates, DataContext);
                            DataContext.SaveChangesEntitySystemContext();  

                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                            {
                                DataContext.EntitySystemContext.Database.ExecuteSqlCommand("EXEC [CDS_SYS].[spGeneratePeriodBalances] {0}", nonduplicates[0].Id);
                                //DataContext.EntitySystemContext.Database.ExecuteSqlCommand("EXEC DBO.spGeneratePeriodAccountBalances {0}", nonduplicates[0].Id);
                            }
                            
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ORG && n.Code == "YES"))
                            {
                                DataContext.EntitySystemContext.Database.ExecuteSqlCommand("EXEC [CDS_SYS].[spGeneratePeriodCompanyHistory] {0}", nonduplicates[0].Id);
                            }
                            
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                            {
                                DataContext.EntitySystemContext.Database.ExecuteSqlCommand("EXEC [CDS_SYS].[spGeneratePeriodInventoryHistory] {0},{1}", nonduplicates[0].Id, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
                            }
                            
                            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.IBO && n.Code == "YES"))
                            {
                                
                            }
                            DataContext.SaveChangesEntitySystemContext();                            
                             
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        //DataContext.EntitySystemContext.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        //BL.ApplicationDataContext.Instance.RollBackTransaction();
                        DataContext.EntitySystemContext.RejectChanges(); 
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                }
                catch (Exception)
                {
                    //DataContext.EntitySystemContext.RollBackTransaction();
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
