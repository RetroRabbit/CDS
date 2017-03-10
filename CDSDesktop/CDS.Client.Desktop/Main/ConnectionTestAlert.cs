using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using BL = CDS.Client.BusinessLayer;

namespace CDS.Client.Desktop.Main
{
    public partial class ConnectionTestAlert : CDS.Client.Desktop.Essential.BaseAlert
    {
        private string ConnectionString = null;

        public ConnectionTestAlert(string Company)
        {
            InitializeComponent();
            SetButton(Buttons.Ok);

            //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                BL.Configuration.CompleteDistributionConfig section = config.GetSection("CompleteDistributionConfig") as BL.Configuration.CompleteDistributionConfig;

                BL.Configuration.RegisteredCompanyCollection companies = section.RegisteredCompanies;

                foreach (BL.Configuration.RegisteredCompany company in companies)
                {
                    if (company.Name == Company)
                    {
                        this.ConnectionString = company.ConnectionString;
                        break;
                    }
                }
            }
        }

        public ConnectionTestAlert(string Company, string ConnectionString)
        {
            InitializeComponent();
            SetButton(Buttons.Ok);

            this.ConnectionString = ConnectionString;
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                // Test the connection
                //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(ConnectionString);
                        sqlCon.Open();
                        if (sqlCon.State != ConnectionState.Closed) sqlCon.Close();

                        this.Message = String.Format("Connection to the database has been successful. No problems should be experienced connecting to this company.");
                        this.TabIcon = global::CDS.Shared.Resources.Properties.Resources.data_ok_32;
                    }
                    catch (SqlException ex)
                    {
                        switch (ex.Number)
                        {
                            case (2):
                            case (53):
                                //NetworkAddressNotFound
                                this.Message = String.Format("Network Address Not Found!\n{0}\nThe network address specified for this connection could not be found on the network. Either you are not able to connect to the network or the server is not accessible at this time.", ex.Message);
                                break;
                            case (4060):
                                //InvalidDatabase
                                this.Message = String.Format("Invalid Database!\n{0}\nThe database name specified for this connection does not exist at the server location specified. Either you have provided the incorrect database name or the name has been changed.", ex.Message);
                                break;
                            case (18452):
                            case (18456):
                                //LoginFailed
                                this.Message = String.Format("Login Failed!\n{0}\nThe user name and password or windows authentication you have provided for this connection are either invalid or have expired.", ex.Message);
                                break;
                            case (10054):
                                //ConnectionRefused
                                this.Message = String.Format("Connection Refused!\n{0}\nThe server has actively refused your connection request.", ex.Message);
                                break;
                            case (547):
                            case (2627):
                            case (2601):
                                //SqlError
                                this.Message = String.Format("Sql Error!\n{0}\nAn error has occured attempting to connect to the server.", ex.Message);
                                break;
                            default:
                                break;
                        }
                        this.TabIcon = global::CDS.Shared.Resources.Properties.Resources.data_error_32;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
