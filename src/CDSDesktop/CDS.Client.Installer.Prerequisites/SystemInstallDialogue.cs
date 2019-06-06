using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
using System.Xml;
using System.Windows.Forms.VisualStyles;

namespace CDS.Client.Installer.Prerequisites
{
    public partial class SystemInstallDialogue : Form
    {
        string Status { set { lblStatus.Text = value; } }
        string Progress { set { lblProgress.Text = value; } }

        public SystemInstallDialogue()
        {
            InitializeComponent();
        }

        private void SystemInstallDialogue_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = String.Format(lblWelcome.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            btnInstallDemo.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnInstallDemo.Width, btnInstallDemo.Height, 7, 7));
            btnInstallClient.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnInstallClient.Width, btnInstallClient.Height, 7, 7));
            btnInstallServer.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnInstallServer.Width, btnInstallServer.Height, 7, 7));
            btnClose.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnClose.Width, btnClose.Height, 7, 7));

            btnClose.FlatAppearance.BorderColor = this.BackColor;

        }

        private void SystemInstallDialogue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnInstallDemo_Click(object sender, EventArgs e)
        {
            Readonly = true;
            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.DoWork += BackgroundWorker_InstallDemo;
            BackgroundWorker.RunWorkerAsync();
        }

        private void btnInstallClient_Click(object sender, EventArgs e)
        {
            Readonly = true;
            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.DoWork += BackgroundWorker_InstallClient;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            BackgroundWorker.RunWorkerAsync();
        }

        private void btnInstallServer_Click(object sender, EventArgs e)
        {
            Readonly = true;
            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.DoWork += BackgroundWorker_InstallServer;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            BackgroundWorker.RunWorkerAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Helper.Execute("mailto:support@cdsonline.co.za?subject=Installer Help", "", false);
        }

        void BackgroundWorker_InstallDemo(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke(new Action(() => Status = "Preparing Setup files"));
            bool completed = (new PrepareDialogue()).ShowDialog() == System.Windows.Forms.DialogResult.Yes;

            if (completed)
            {
                this.BeginInvoke(new Action(() => Status = "Installing Prerequisites"));
                completed = (new PrerequisitesDialogue()).ShowDialog() == System.Windows.Forms.DialogResult.Yes;
            }

            if (completed)
            {
                if (SystemInfo.ShouldInstallSQLLocalDB)
                    InstallLocalDB();
          
                UnzipFiles();
                InstallSQLNCLI();
                InstallSQLClrTypes();
                InstallSQLSMO();                
                CopyDemoDatabase();
                SetupConnection();
                InstallWebService();
                CreateShortcut();
                CreateUninstaller();
                this.BeginInvoke(new Action(() => Status = "Setup Complete..."));
            }

        }

        void BackgroundWorker_InstallClient(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke(new Action(() => Status = "Preparing Setup files"));
            bool completed = (new PrepareDialogue()).ShowDialog() == System.Windows.Forms.DialogResult.Yes;

            if (completed)
            {
                this.BeginInvoke(new Action(() => Status = "Installing Prerequisites"));
                completed = (new PrerequisitesDialogue()).ShowDialog() == System.Windows.Forms.DialogResult.Yes;
            }
            if (completed)
            {
                UnzipFiles();
                InstallSQLNCLI();
                InstallSQLClrTypes();
                InstallSQLSMO();
                CreateShortcut();
                CreateUninstaller();
                this.BeginInvoke(new Action(() => Status = "Setup Complete..."));
            } 
        }

        void BackgroundWorker_InstallServer(object sender, DoWorkEventArgs e)
        {
            

            this.BeginInvoke(new Action(() => Status = "Preparing Setup files"));
            bool completed = (new PrepareDialogue()).ShowDialog() == System.Windows.Forms.DialogResult.Yes;

            if (completed)
            {
                this.BeginInvoke(new Action(() => Status = "Installing Prerequisites"));
                completed = (new PrerequisitesDialogue()).ShowDialog() == System.Windows.Forms.DialogResult.Yes;
            }
            if (completed)
            {
                UnzipFiles();
                InstallSQLNCLI();
                InstallSQLClrTypes();
                InstallSQLSMO();
                CopyDllsToServerFolder();
                InstallWebService();
                CreateShortcut();
                CreateUninstaller();
            }

            this.BeginInvoke(new Action(() => Status = "Running CDS Server Setup ..."));
            Helper.Execute("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Server\\CDS.Server.Installer.exe", "Install", true, false);
            this.BeginInvoke(new Action(() => Status = "Setup Complete..."));
        }

        private void InstallSQLNCLI()
        { 
            this.BeginInvoke(new Action(() => Status = "Installing SQL NCLI 2012 ..."));
            this.BeginInvoke(new Action(() => Progress = ""));
            
            if (SystemInfo.is64BitOperatingSystem)
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\SQLNCLI\x64\SQLNCLI.MSI"))
                {
                    Helper.Execute("cmd.exe", " /C \"" + "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\SQLNCLI.MSI" + "\" /qn IACCEPTSQLNCLILICENSETERMS=YES",
                        true, false, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\");
                    //Helper.Execute("msiexec", "/q /i \"" + Helper.StartupPath + "\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\SQLNCLI_64.MSI\"",
                    //      true, false);
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql NCLI included");
                }
            }
            else
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\SQLNCLI\x86\SQLNCLI.MSI"))
                {
                    //Helper.Execute("msiexec", "/q /i \"" + Helper.StartupPath + "\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\SQLNCLI_64.MSI \"",
                    //        true, false);
                    Helper.Execute("cmd.exe", " /C \"" + "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\SQLNCLI.MSI" + "\" /qn IACCEPTSQLNCLILICENSETERMS=YES",
                       true, false, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\");
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql NCLI included");
                }
            } 

        }

        private void InstallSQLSMO()
        {
            this.BeginInvoke(new Action(() => Status = "Installing SQL SMO ..."));
            this.BeginInvoke(new Action(() => Progress = ""));

            if (SystemInfo.is64BitOperatingSystem)
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\SQLNCLI\x64\SharedManagementObjects.msi"))
                {
                    Helper.Execute("cmd.exe", " /C \"" + "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\SharedManagementObjects.MSI" + "\" /qn",
                        true, false, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\");

                    //Microsoft.SqlServer.Management.BatchParser
                    //Need to install x64 and x86 on x64 System
                    Helper.Execute("cmd.exe", " /C \"" + "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\SharedManagementObjects.MSI" + "\" /qn",
                       true, false, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\");
              
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql SMO included");
                }
            }
            else
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\SQLNCLI\x86\SharedManagementObjects.msi"))
                {
                    //Helper.Execute("msiexec", "/q /i \"" + Helper.StartupPath + "\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\SQLNCLI_64.MSI \"",
                    //        true, false);
                    Helper.Execute("cmd.exe", " /C \"" + "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\SharedManagementObjects.MSI" + "\" /qn",
                       true, false, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\");
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql SMO included");
                }
            } 

        }

        private void InstallSQLClrTypes()
        {
            this.BeginInvoke(new Action(() => Status = "Installing SQL Clr Types ..."));
            this.BeginInvoke(new Action(() => Progress = ""));

            if (SystemInfo.is64BitOperatingSystem)
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\SQLNCLI\x64\SQLSysClrTypes.msi"))
                {
                    Helper.Execute("cmd.exe", " /C \"" + "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\SQLSysClrTypes.msi" + "\" /qn ",
                        true, false, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\");
                    //Helper.Execute("msiexec", "/q /i \"" + Helper.StartupPath + "\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x64\\SQLNCLI_64.MSI\"",
                    //      true, false);
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql Clr Types included");
                }
            }
            else
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\SQLNCLI\x86\SQLSysClrTypes.msi"))
                {
                    //Helper.Execute("msiexec", "/q /i \"" + Helper.StartupPath + "\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\SQLNCLI_64.MSI \"",
                    //        true, false);
                    Helper.Execute("cmd.exe", " /C \"" + "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\SQLSysClrTypes.msi" + "\" /qn ",
                       true, false, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Prerequisites\\Installers\\SQL\\SQLNCLI\\x86\\");
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql Clr Types included");
                }
            } 

        }

        private void InstallWebService()
        {
            this.BeginInvoke(new Action(() => Status = "Copying files for web service ..."));
            //Helper.DirectoryCopy("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Web", "C:\\inetpub\\", true);

            if (!System.IO.Directory.Exists("C:\\inetpub\\CDS.Web.DataService"))
                System.IO.Directory.CreateDirectory("C:\\inetpub\\CDS.Web.DataService");

            Helper.Execute("cmd.exe", String.Format(" /C cd {0}\\Requirements\\Commands\\Zip & "
             + "unrar x \"{0}\\Requirements\\Prerequisites\\CDS.Web.DataService.rar\" *.* \"C:\\inetpub\\CDS.Web.DataService\" -y", Helper.StartupPath),
             true, true, "C:\\inetpub\\CDS.Web.DataService\\");

            if (SystemInfo.ShouldInstallIIS)
            {
                this.BeginInvoke(new Action(() => Status = "Installing IIS ..."));
                Helper.Execute("cmd.exe", String.Format(" /C start /w pkgmgr /iu:IIS-WebServerRole;IIS-WebServer;IIS-CommonHttpFeatures;IIS-DefaultDocument;IIS-ApplicationDevelopment;IIS-ASPNET;IIS-NetFxExtensibility;IIS-ISAPIExtensions;IIS-ISAPIFilter;IIS-Security;IIS-BasicAuthentication;IIS-WindowsAuthentication;IIS-RequestFiltering;IIS-WebServerManagementTools;IIS-ManagementConsole;IIS-Metabase;IIS-WMICompatibility;IIS-LegacyScripts;IIS-LegacySnapIn;WAS-WindowsActivationService;WAS-ProcessModel;WAS-NetFxEnvironment;WAS-ConfigurationAPI", Helper.StartupPath), true, true);
            }
            Helper.Execute("cmd.exe", String.Format(" /C \"%WinDir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_regiis -i\"", Helper.StartupPath), true, true);
            
            this.BeginInvoke(new Action(() => Status = "Configuring web service ..."));
            Helper.Execute("cmd.exe", "cmd /c %systemroot%\\system32\\inetsrv\\appcmd ADD APPPOOL /name:\".NET v4\" /managedRuntimeVersion:v4.0", true, true, @"%systemroot%\system32\inetsrv\");

            this.BeginInvoke(new Action(() => Status = "Starting web service ..."));
            Helper.Execute("cmd.exe", "cmd /c %systemroot%\\system32\\inetsrv\\APPCMD add site /name:\"CDS.Web.DataService\" /bindings:\"http/*:8090:\" /physicalPath:\"C:\\inetpub\\CDS.Web.DataService\" /applicationDefaults.applicationPool:\".NET v4\"", true, true, @"%systemroot%\system32\inetsrv\");

            this.BeginInvoke(new Action(() => Status = "Adding firewall exceptions ..."));
            Helper.Execute("cmd.exe", "cmd /c netsh advfirewall firewall delete rule name=\"CDS.Web.DataService 8090\" protocol=UDP localport=8090", true, true);
            Helper.Execute("cmd.exe", "cmd /c netsh advfirewall firewall add rule name=\"CDS.Web.DataService 8090\" dir=in action=allow protocol=UDP localport=8090 & netsh advfirewall firewall add rule name=\"CDS.Web.DataService 8090\" dir=out action=allow protocol=UDP localport=8090 & netsh advfirewall firewall add rule name=\"CDS.Web.DataService 8090\" dir=in action=allow protocol=TCP localport=8090 & netsh advfirewall firewall add rule name=\"CDS.Web.DataService 8090\" dir=out action=allow protocol=TCP localport=8090", true, true);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke(new Action(() => Status = "Installation Complete"));
            Readonly = false;
        }

        private void SetupConnection()
        {
            this.BeginInvoke(new Action(() => Status = "Installing CDS ..."));
            this.BeginInvoke(new Action(() => Progress = ""));
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\CDS.Client.Desktop.exe.config");

            XmlAttribute connectionName = (XmlAttribute)doc.SelectSingleNode("/configuration/CompleteDistributionConfig/RegisteredCompanies/RegisteredCompany/@name");
            connectionName.Value = "DEMO U:CDS P:CDS";
            XmlAttribute connectionString = (XmlAttribute)doc.SelectSingleNode("/configuration/CompleteDistributionConfig/RegisteredCompanies/RegisteredCompany/@connectionstring");
            connectionString.Value = "Data Source=(localDB)\\v11.0;AttachDbFilename=C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\DB\\cds_pegasus.mdf;Integrated Security=True";
            doc.Save("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\CDS.Client.Desktop.exe.config");
        }

        private void UnzipFiles()
        {
            this.BeginInvoke(new Action(() => Status = "Installing CDS ..."));
            this.BeginInvoke(new Action(() => Progress = ""));
            //this.BeginInvoke(new Action(() => Status = "Installing CDS ..."));
            Helper.Execute("cmd.exe", String.Format(" /C cd {0}\\Requirements\\Commands\\Zip & "
             + "unrar x \"{0}\\Requirements\\Prerequisites\\CDS.Client.Desktop.rar\" *.* \"C:\\Program Files\\Complete Distribution\\Client\\Enterprise\" -y", Helper.StartupPath),
             true, true, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise");
            //this.BeginInvoke(new Action(() => Status = "Installed CDS ..."));

        }

        private void CopyDllsToServerFolder()
        {
            this.BeginInvoke(new Action(() => Status = "Installing CDS Server files ..."));
            this.BeginInvoke(new Action(() => Progress = ""));
            Helper.Execute("cmd.exe", String.Format(" /C xcopy \"C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\*.dll\" "
             + "\"C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\Requirements\\Server\" /y", Helper.StartupPath),true,true);
        }

        private void CopyDemoDatabase()
        {
            this.BeginInvoke(new Action(() => Status = "Installing Demo Database ..."));
            this.BeginInvoke(new Action(() => Progress = ""));
            if (!System.IO.Directory.Exists("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\DB"))
                System.IO.Directory.CreateDirectory("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\DB");

            //this.BeginInvoke(new Action(() => Status = "Installing CDS ..."));
            Helper.Execute("cmd.exe", String.Format(" /C cd {0}\\Requirements\\Commands\\Zip & "
             + "unrar x \"{0}\\Requirements\\Prerequisites\\Installers\\SQL\\2014 LocalDB\\Demo\\DemoDatabase.rar\" *.* \"C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\DB\" -y", Helper.StartupPath),
             true, true, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\DB");
            //this.BeginInvoke(new Action(() => Status = "Installed CDS ..."));
        }

        private void InstallLocalDB()
        {
            this.BeginInvoke(new Action(() => Status = "Installing SQL 2014 LocalDB ..."));
            this.BeginInvoke(new Action(() => Progress = ""));
            if (SystemInfo.is64BitOperatingSystem)
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\2014 LocalDB\x64\SqlLocalDB.msi"))
                {
                    Helper.Execute(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\2014 LocalDB\x64\SqlLocalDB.msi",
                        //"/quiet /nodialog /norestart", true);
                            "IACCEPTSQLLOCALDBLICENSETERMS=YES /passive", true);
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql LocalDB included");
                }
            }
            else
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\2014 LocalDB\x86\SqlLocalDB.msi"))
                {
                    Helper.Execute(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\SQL\2014 LocalDB\x86\SqlLocalDB.msi",
                        //"/quiet /nodialog /norestart", true);
                            "IACCEPTSQLLOCALDBLICENSETERMS=YES /passive", true);
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Sql LocalDB included");
                }
            }
            this.BeginInvoke(new Action(() => Status = "Installing SQL 2014 LocalDB ..."));
        }

        private void CreateShortcut()
        {
            this.BeginInvoke(new Action(() => Status = "Creating Shortcut on Desktop ..."));
            if (System.IO.File.Exists("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\CDS Enterprise.lnk")
                && !System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CDS Enterprise.lnk"))
            {
                System.IO.File.Copy("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\CDS Enterprise.lnk", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CDS Enterprise.lnk");

                KeyboardSend.KeyDown(Keys.LWin);
                KeyboardSend.KeyDown(Keys.D);
            }
        }

        bool Readonly { set { btnInstallClient.Enabled = !value;btnInstallServer.Enabled = !value;btnInstallDemo.Enabled = !value; } }

        protected Guid UninstallGuid { get { return new Guid("3f8d6197-b112-48fa-a60f-7cf6f3c67c08"); } }
        protected virtual string UninstallRegKeyPath
        {
            get
            {
                return @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            }
        }
        private void CreateUninstaller()
        {
            this.BeginInvoke(new Action(() => Status = "Creating Uninstaller ..."));

            using (RegistryKey parent = Registry.LocalMachine.OpenSubKey(
                         @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true))
            {
                if (parent == null)
                {
                    throw new Exception("Uninstall registry key not found.");
                }
                try
                {
                    RegistryKey key = null;

                    try
                    {

                        string guidText = UninstallGuid.ToString("B");
                        key = parent.OpenSubKey(guidText, true) ??
                              parent.CreateSubKey(guidText);

                        if (key == null)
                        {
                            throw new Exception(String.Format("Unable to create uninstaller '{0}\\{1}'", UninstallRegKeyPath, guidText));
                        }

                        Assembly asm = GetType().Assembly;
                        Version v = asm.GetName().Version;
                        string exe = "\"" + asm.CodeBase.Substring(8).Replace("/", "\\\\") + "\"";

                        key.SetValue("DisplayName", "Complete Distribution System");
                        key.SetValue("ApplicationVersion", v.ToString());
                        key.SetValue("Publisher", "Complete Distribution");
                        key.SetValue("DisplayIcon", exe);
                        key.SetValue("DisplayVersion", v.ToString(2));
                        key.SetValue("URLInfoAbout", "http://www.cdsonline.co.za");
                        key.SetValue("Contact", "support@cdsonline.co.za");
                        key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                        key.SetValue("UninstallString", exe + " Uninstall");
                    }
                    finally
                    {
                        if (key != null)
                        {
                            key.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        "An error occurred writing uninstall information to the registry.  The service is fully installed but can only be uninstalled manually through the command line.",
                        ex);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );
        private VisualStyleRenderer renderer;
        private void RemoveButtonFocusBorder_Paint(object sender, PaintEventArgs e)
        {
            Button control = (Button)sender;

            base.OnPaint(e);
            if (control.Focused && Application.RenderWithVisualStyles && control.FlatStyle == FlatStyle.Flat)
            {
                if (renderer == null)
                {
                    VisualStyleElement elem = VisualStyleElement.Button.PushButton.Normal;
                    renderer = new VisualStyleRenderer(elem.ClassName, elem.Part, (int)PushButtonState.Normal);
                }
                Rectangle rc = renderer.GetBackgroundContentRectangle(e.Graphics, new Rectangle(1, 1, control.Width, control.Height));
                rc.Height -= 3;
                rc.Width -= 3;
                using (Pen p = new Pen(SystemColors.Control))
                {
                    e.Graphics.DrawRectangle(p, rc);
                }
            }
        }

        private void pnlBackground_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    }
}
