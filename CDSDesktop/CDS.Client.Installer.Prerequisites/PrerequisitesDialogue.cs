using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Installer.Prerequisites
{
    public partial class PrerequisitesDialogue : Form
    {
        
        string Status { set { lblStatus.Text = value; } }
        string Progress { set { lblProgress.Text = value; } }

        public PrerequisitesDialogue()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists("C:\\Program Files\\Complete Distribution\\Client\\Enterprise"))
                System.IO.Directory.CreateDirectory("C:\\Program Files\\Complete Distribution\\Client\\Enterprise");
            else
            { 
                if (System.IO.File.Exists("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\CDS.Client.Desktop.exe"))
                    if (MessageDialogue.ShowMessage("Application already installed","Complete Distribution has already been installed. Run repair tool ?") == System.Windows.Forms.DialogResult.OK)
                  //if (MessageBox.Show("Complete Distribution has already been installed. Run repair tool ?", "Application already installed", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Run repair
                        //Werner : Dont do this
                        //System.IO.Directory.Delete("C:\\Program Files\\Complete Distribution\\Client\\Enterprise", false);
                        //System.IO.Directory.CreateDirectory("C:\\Program Files\\Complete Distribution\\Client\\Enterprise");
                    }
                    else
                    { 
                        Application.Exit(); 
                    }
            }
             
            BackgroundWorker.RunWorkerAsync();            
         
        }

        void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            //Helper.Execute("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\CDS.Client.Installer.Prerequisites.exe", "Install", false, false);
        
            //Application.Exit();
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (!SystemInfo.IsOSValid)
                OSNotValid();

            if (SystemInfo.ShouldInstallWin7SP1)
                InstallWin7Sp1();

            if (SystemInfo.ShouldInstallDotNet)
                InstallDotNet45();

          
          
        }

        private void OSNotValid()
        {
            this.BeginInvoke(new Action(() => Status = "Windows 7 or greater is required ..."));
            System.Threading.Thread.Sleep(2000);
        }

        private void InstallWin7Sp1()
        {
            this.BeginInvoke(new Action(() => Status = "Installing Win 7 SP 1 ..."));
            this.BeginInvoke(new Action(() => Progress = "(1/2)"));
            if (SystemInfo.is64BitOperatingSystem)
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\Win7PS1\x64\windows6.1-KB976932-X64.exe"))
                {
                    Helper.Execute(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\Win7PS1\x64\windows6.1-KB976932-X64.exe",
                            //"/quiet /nodialog /norestart", true);
                            "/unattend /norestart", true);
                }
                else {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Windows 7 SP 1 included");
                }
            }
            else
            {
                if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\Win7PS1\x86\windows6.1-KB976932-X86.exe"))
                {
                    Helper.Execute(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\Win7PS1\x86\windows6.1-KB976932-X86.exe",
                            //"/quiet /nodialog /norestart", true);
                            "/unattend /norestart", true);
                }
                else
                {
                    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Windows 7 SP 1 included");
                }
            }
            this.BeginInvoke(new Action(() => Status = "Installed Win 7 SP 1 ..."));
        }

        private void InstallDotNet45()
        {
            this.BeginInvoke(new Action(() => Status = "Installing .NET 4.5 ..." ));
            this.BeginInvoke(new Action(() => Progress = "(2/2)"));
            if (System.IO.File.Exists(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\.NET4.5.1\NDP451-KB2858728-x86-x64-AllOS-ENU.exe"))
            {
                Helper.Execute(Helper.StartupPath + @"\Requirements\Prerequisites\Installers\.NET4.5.1\NDP451-KB2858728-x86-x64-AllOS-ENU.exe",
                        //"/q /norestart", true);
                        "/passive /norestart", true);
            }
            this.BeginInvoke(new Action(() => Status = "Installed .NET 4.5 ..."));
        }
  
        private void RestartWhenDone()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.WorkingDirectory = Application.StartupPath;
            startInfo.Arguments = "Install";
            process.StartInfo = startInfo;
            process.Start(); 
        }
 
    }
}
