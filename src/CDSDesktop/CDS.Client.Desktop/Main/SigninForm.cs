using CDS.Client.Desktop.Essential;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Main
{
    public partial class SigninForm : DevExpress.XtraEditors.XtraForm
    {
        List<CompanyConnection> companies = new List<CompanyConnection>();

        public SigninForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when the form intialises. Collects all registered companies from the config file and refreshes the connection status to each one.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        private void OnStart()
        {
            try
            {
                this.barItemText.Caption = Application.ProductVersion.ToString();

                foreach (BL.Configuration.RegisteredCompany company in config.RegisteredCompanies)
                {
                    companies.Add(new CompanyConnection() { Company = company.Name, ConnectionString = company.ConnectionString, Image = imageCollectionSmall.Images[0], Version = new Version("00.00.00.00") });
                }
                grdCompany.DataSource = companies;


                for (int i = 0; i < grvCompany.DataRowCount; i++)
                {
                    object b = grvCompany.GetRowCellValue(i, "Company");
                    if (b != null && b.Equals(CDS.Client.Desktop.Properties.Settings.Default.RegisteredCompany))
                    {
                        grvCompany.FocusedRowHandle = i;
                        break;
                    }
                }

                //ilbCompanies.EndUpdate();

                RefreshServerStatusAll();

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Creates asynchronous status updates of each registered company. The status us reflected in the colour of the icon next to the company.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        private void RefreshServerStatusAll()
        {
            try
            {
                for (int i = 0; i < companies.Count; i++)
                {
                    int j = i;
                    string result = BL.SEC.SecurityLibrary.PingConnection(config.RegisteredCompanies[j]);
                    //ilbCompanies.BeginInvoke((MethodInvoker)delegate { ilbCompanies.Items[j].ImageIndex = result.Length > 0 ? 1 : 2; });
                    companies.FirstOrDefault(n => n.Company == config.RegisteredCompanies[j].Name).Image = result.Length > 0 ? imageCollectionSmall.Images[1] : imageCollectionSmall.Images[2];
                    companies.FirstOrDefault(n => n.Company == config.RegisteredCompanies[j].Name).Version = result.Length > 0 ? new Version(result) : new Version("00.00.00.00");

                    if (result.Length > 0 && LatancyConnention() > 100)
                        companies.FirstOrDefault(n => n.Company == config.RegisteredCompanies[j].Name).Image = imageCollectionSmall.Images[3];

                    grvCompany.RefreshRow(j);
                    //var t = Task.Factory.StartNew(() =>
                    //{
                    //    try
                    //    {
                    //        string result = BL.SEC.SecurityLibrary.PingConnection(config.RegisteredCompanies[j]);
                    //        //ilbCompanies.BeginInvoke((MethodInvoker)delegate { ilbCompanies.Items[j].ImageIndex = result.Length > 0 ? 1 : 2; });
                    //        companies.FirstOrDefault(n => n.Company == config.RegisteredCompanies[j].Name).Image = result.Length > 0 ? imageCollectionSmall.Images[1] : imageCollectionSmall.Images[2];
                    //        companies.FirstOrDefault(n => n.Company == config.RegisteredCompanies[j].Name).Version = result.Length > 0 ? new Version(result) : new Version("00.00.00.00");

                    //        if (result.Length > 0 && LatancyConnention() > 100)
                    //            companies.FirstOrDefault(n => n.Company == config.RegisteredCompanies[j].Name).Image = imageCollectionSmall.Images[3];

                    //        grvCompany.RefreshRow(j);
                    //    }
                    //    catch { }
                    //});
                }

                btnDiagnose.Enabled = true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private Int64 LatancyConnention()
        {
            return 0;

            // Ping's the local machine.
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            System.Net.IPAddress address = System.Net.IPAddress.Loopback;
            System.Net.NetworkInformation.PingReply reply = pingSender.Send(address);

            return reply.RoundtripTime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        private void Signin()
        {
            try
            {
                if (!dxValidationProvider.Validate())
                    return;

                //if (!UpdateClient())
                //    return;

                //if (SecurityLibrary.SetConnection(config.RegisteredCompanies[ilbCompanies.SelectedIndex]))
                if (BL.SEC.SecurityLibrary.SetConnection(config.RegisteredCompanies[grvCompany.FocusedRowHandle]))
                {
                    if (BL.SEC.SecurityLibrary.Signin(txtUsername.Text, txtPassword.Text))
                    {
                        //Properties.Settings.Default.RegisteredCompany = config.RegisteredCompanies[ilbCompanies.SelectedIndex].Name;
                        Properties.Settings.Default.RegisteredCompany = config.RegisteredCompanies[grvCompany.FocusedRowHandle].Name;
                        Properties.Settings.Default.Save();
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // Invalid username/password provided
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.txtPassword.Text = String.Empty;
                        this.barItemText.Caption = "Incorrect username or password.";
                        this.barItemText.ImageIndex = 4;
                        txtPassword.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                this.txtPassword.Text = String.Empty;
                this.barItemText.Caption = "Could not establish connection to company.";
                this.barItemText.ImageIndex = 4;

                //if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private bool CheckUpdateLocation()
        {
            foreach (BL.Configuration.RegisteredCompany company in config.RegisteredCompanies)
            {
                //If there is and update and you are not logging into the Company set as update site then return
                if (company.UpdateSite == true && company.Name != config.RegisteredCompanies[grvCompany.FocusedRowHandle].Name)
                {
                    return BaseAlert.ShowAlert("Wrong Update Site", "You are logging into a site that has a update but is not the default update site.\n" +
                        "Do you want to continue ?", BaseAlert.Buttons.OkCancel, BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK;
                }
            }
            return true;
        }

        private void frmSignin_Load(object sender, EventArgs e)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                ConfigurationSection section = configuration.GetSection("CompleteDistributionConfig");

                section.LockItem = false;

                BL.Configuration.RegisteredCompanyCollection companies = ((BL.Configuration.CompleteDistributionConfig)(section)).RegisteredCompanies;

                config = ConfigurationManager.GetSection("CompleteDistributionConfig") as BL.Configuration.CompleteDistributionConfig;

                if (companies.Count != 0 && companies[0].UpdateSite == null)
                {
                    foreach (BL.Configuration.RegisteredCompany company in companies)
                    {
                        company.UpdateSite = false;
                    }
                    companies[0].UpdateSite = true;

                    configuration.Save(ConfigurationSaveMode.Modified);
                }
                OnStart();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ilbCompanies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Signin();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                Signin();
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
                Application.Exit();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (new Main.ConnectionDialogue().ShowDialog() == DialogResult.OK)
                {
                    // Refresh Connection list
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Opens the Connection Dialogue so that the selected connection can be edited 
        /// </summary>
        /// <param name="sender">btnEdit</param>
        /// <param name="e">EventArgs</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (new ConnectionDialogue().LoadConnection(SelectedCompanyName).ShowDialog() == DialogResult.OK)
                {
                    // Refresh Connection list
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (BaseAlert.ShowAlert("Remove Company Connection", "You are about to permanently remove the selected Company Connection.\nAre you certain you wish to continue?", BaseAlert.Buttons.OkCancel, BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    BL.Configuration.CompleteDistributionConfig section = config.GetSection("CompleteDistributionConfig") as BL.Configuration.CompleteDistributionConfig;

                    section.RegisteredCompanies.RemoveCompany(SelectedCompanyName);
                    config.Save(ConfigurationSaveMode.Modified);

                    // Refresh Connection list
                    Application.Restart();
                }
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
                new ConnectionTestAlert(SelectedCompanyName).ShowDialog();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private BL.Configuration.CompleteDistributionConfig config = null;

        private DB.SEC_User user = null;

        private String SelectedCompanyName
        {
            get
            {
                //return ((DevExpress.XtraEditors.Controls.ListBoxItem)(ilbCompanies.SelectedItem)).Value as String;
                return ((CompanyConnection)(grvCompany.GetFocusedRow())).Company as String;
            }
        }

        private String SelectedCompanyConnection
        {
            get
            {

                // return config.RegisteredCompanies[ilbCompanies.SelectedIndex].ConnectionString as String;
                return ((CompanyConnection)(grvCompany.GetFocusedRow())).ConnectionString as String;
            }
        }
    }

    public class CompanyConnection
    {
        public CompanyConnection() { }

        public String Company { get; set; }
        public String ConnectionString { get; set; }
        public Version Version { get; set; }
        public Image Image { get; set; }
    }
}

