using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.Entity.Core.EntityClient;
using BL = CDS.Client.BusinessLayer;
using System.Threading.Tasks;


namespace CDS.Client.Desktop.Main
{
    public partial class ConnectionDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private string oldname = null;
        BL.Configuration.RegisteredCompany selectedCompany;

        public ConnectionDialogue()
        {
            InitializeComponent();
        }

        public ConnectionDialogue LoadConnection(String Company)
        {
            try
            {
                oldname = Company;
                txtName.EditValue = Company;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                BL.Configuration.CompleteDistributionConfig section = config.GetSection("CompleteDistributionConfig") as BL.Configuration.CompleteDistributionConfig;

                BL.Configuration.RegisteredCompanyCollection companies = section.RegisteredCompanies;

                string connectionString = null;
                foreach (BL.Configuration.RegisteredCompany company in companies)
                {
                    if (company.Name == Company)
                    {
                        connectionString = company.ConnectionString;
                        txtTimeout.EditValue = Convert.ToInt32(company.ConnectionTimeout) / 1000;
                        selectedCompany = company;
                        chkUpdateLocation.Checked = company.UpdateSite.Value;
                        break;
                    }
                }

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                ddlServer.EditValue = builder["Data Source"];
                ddlDatabase.EditValue = builder["Initial Catalog"];
                ddlAuthentication.SelectedIndex = Convert.ToBoolean(builder["Integrated Security"]) ? 0 : 1;

                if (ddlAuthentication.SelectedIndex != 0)
                {
                    txtUsername.EditValue = builder["User ID"];
                    txtPassword.EditValue = builder["Password"];
                }

                if (!String.IsNullOrEmpty(builder["AttachDBFilename"].ToString()))
                {
                    btnDBFileLocation.Text = builder["AttachDBFilename"].ToString();
                }

                return this;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        private void RefreshServerList()
        {
            try
            {
                //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    ddlServer.Properties.Items.Clear();
                    System.Data.DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();

                    //ServerName / InstanceName
                    foreach (DataRow row in SqlDataSourceEnumerator.Instance.GetDataSources().Rows)
                    {
                        ddlServer.Properties.Items.Add(
                            String.IsNullOrEmpty(Convert.ToString(row["InstanceName"])) ?
                            Convert.ToString(row["ServerName"]) :
                            Convert.ToString(row["ServerName"]) + "\\" + Convert.ToString(row["InstanceName"]));
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RefreshDatabaseList()
        {
            try
            {
                //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    ddlDatabase.Properties.Items.Clear();

                    using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString(true)))
                    {
                        try
                        {
                            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand("SELECT [name] FROM [sys].[databases]", sqlConnection);

                            sqlCommand.CommandTimeout = Convert.ToInt32(txtTimeout.EditValue);
                            if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();

                            using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                            {
                                while (sqlReader.Read())
                                {
                                    ddlDatabase.Properties.Items.Add(Convert.ToString(sqlReader["name"]));
                                }
                                sqlReader.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        }
                        finally
                        {
                            if (sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private String GetConnectionString(bool master)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder["Data Source"] = ddlServer.Text;

                if (master)
                    builder["Initial Catalog"] = "master";
                else
                    builder["Initial Catalog"] = ddlDatabase.Text;

                if (ddlAuthentication.SelectedIndex == 0)
                {
                    builder["Integrated Security"] = true;
                }
                else
                {
                    //This breaks the connection string, there is no false, its either true or not there
                    //builder["Integrated Security"] = false;
                    builder["User ID"] = txtUsername.Text;
                    builder["Password"] = txtPassword.Text;
                }

                if (!String.IsNullOrEmpty(btnDBFileLocation.Text))
                {
                    builder["AttachDBFilename"] = btnDBFileLocation.Text;
                }

                //REMOVE "Persist Security Info" causes fast reports go get some kind of access issue
                builder["Persist Security Info"] = null;

                builder["MultipleActiveResultSets"] = true;

                return builder.ConnectionString;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = (ConfigurationSection)config.GetSection("CompleteDistributionConfig");
            section.LockItem = false;
            BL.Configuration.RegisteredCompanyCollection companies = (BL.Configuration.RegisteredCompanyCollection)((BL.Configuration.CompleteDistributionConfig)(section)).RegisteredCompanies;
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

        private void btnDiagnose_Click(object sender, EventArgs e)
        {
            try
            {
                new ConnectionTestAlert(Convert.ToString(txtName.EditValue), GetConnectionString(false)).ShowDialog();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        //PLEASE NOTE THIS DOES NOT WORK THEN DEBUGGING
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider.Validate())
                    return;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection section = (ConfigurationSection)config.GetSection("CompleteDistributionConfig");
                section.LockItem = false;
                BL.Configuration.RegisteredCompanyCollection companies = (BL.Configuration.RegisteredCompanyCollection)((BL.Configuration.CompleteDistributionConfig)(section)).RegisteredCompanies;

                //Null then New button was clicked
                if (oldname == null)
                {

                    //NEW Entity Framwork requires the a different connection string format so we save the individual 
                    //TODO: Chekc last Param
                    companies.NewCompany(txtName.Text, GetConnectionString(false), Convert.ToString(Convert.ToInt32(txtTimeout.EditValue) * 1000), chkUpdateLocation.Checked);//, GetEntityConnectionString(false), GetEntityConnectionString(false));

                    foreach (BL.Configuration.RegisteredCompany company in companies)
                    {
                        if (company.Name == txtName.Text)
                        {
                            selectedCompany = company;
                            if (companies.Count == 1)
                                chkUpdateLocation.Checked = true;

                            break;
                        }
                    }

                }
                else
                {
                    companies[oldname].Name = txtName.Text;
                    companies[txtName.Text].ConnectionString = GetConnectionString(false);
                    companies[txtName.Text].ConnectionTimeout = Convert.ToString(Convert.ToInt32(txtTimeout.EditValue) * 1000);

                    // Set connection string properties for Entity framework conenction string
                    //companies[txtName.Text].EntityTablesConnectionString = GetEntityConnectionString(false);
                    //TODO: Make oce for Views Modle
                    //companies[txtName.Text].EntityViewsConnectionString = GetEntityConnectionString(false);
                }

                if (selectedCompany.UpdateSite.Value)
                {
                    foreach (BL.Configuration.RegisteredCompany company in companies)
                    {
                        if (selectedCompany.Name != company.Name)
                        {
                            company.UpdateSite = false;
                        }
                        else
                        {
                            company.UpdateSite = true;
                        }
                    }
                }

                config.Save(ConfigurationSaveMode.Modified);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlAuthentication_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAuthentication.SelectedIndex == 0)
                {
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                }
                else
                {
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlDatabase_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDatabase.SelectedIndex != -1)
                {
                    btnDBFileLocation.Enabled = false;
                }
                else
                {
                    btnDBFileLocation.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnDBFileLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            databaseFileLocation.ShowDialog();
            if (File.Exists(databaseFileLocation.FileName) && (new FileInfo(databaseFileLocation.FileName)).Extension.ToUpper().Equals(".MDF"))
            {
                btnDBFileLocation.Text = databaseFileLocation.FileName;
            }
        }

        private void chkUpdateLocation_CheckedChanged(object sender, EventArgs e)
        {
            selectedCompany.UpdateSite = chkUpdateLocation.Checked;
        }

        private void txtUsername_EnabledChanged(object sender, EventArgs e)
        {
            if (!txtUsername.Enabled)
            {
                dxValidationProvider.SetValidationRule(txtUsername, null);
            }
            else
            {
                DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRuleNotBlank = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
                conditionValidationRuleNotBlank.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
                conditionValidationRuleNotBlank.ErrorText = "Enter username ...";
                conditionValidationRuleNotBlank.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                dxValidationProvider.SetValidationRule(txtUsername, conditionValidationRuleNotBlank);
            }
        }

        private void txtPassword_EnabledChanged(object sender, EventArgs e)
        {
            if (!txtPassword.Enabled)
            {
                dxValidationProvider.SetValidationRule(txtPassword, null);
            }
            else
            {
                DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRuleNotBlank = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
                conditionValidationRuleNotBlank.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
                conditionValidationRuleNotBlank.ErrorText = "Enter password ...";
                conditionValidationRuleNotBlank.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                dxValidationProvider.SetValidationRule(txtPassword, conditionValidationRuleNotBlank);
            }
        }

        private void ddlServer_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (ddlServer.Properties.Items.Count == 0)
            {
                try
                {
                    using (new WaitCursor(SplashManager))
                    {
                        RefreshServerList();
                    }
                    ddlServer.ShowPopup();
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            
            }
        }

        class WaitCursor : IDisposable
        {

            DevExpress.XtraSplashScreen.SplashScreenManager SplashManager;

            public WaitCursor(DevExpress.XtraSplashScreen.SplashScreenManager splashManager)
            {
                Cursor.Current = Cursors.WaitCursor;
                SplashManager = splashManager;
                ShowWaitForm();
            }

            public void Dispose()
            {
                Cursor.Current = Cursors.Default;
                CloseWaitForm();
            }

            public void ShowWaitForm()
            {
                try
                {
                    if (!SplashManager.IsSplashFormVisible)
                        SplashManager.ShowWaitForm();
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }

            public void CloseWaitForm()
            {
                try
                {
                    if (SplashManager.IsSplashFormVisible)
                        SplashManager.CloseWaitForm();
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }

        private void ddlDatabase_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (ddlDatabase.Properties.Items.Count == 0)
            {
                try
                {
                    using (new WaitCursor(SplashManager))
                    {
                        RefreshDatabaseList();
                    }
                    ddlDatabase.ShowPopup();
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }

            }
        }
    }
}
