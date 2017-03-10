using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CDS.Client.Installer.Prerequisites
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
                args = new string[] { "Install" };

            switch (args[0])
            {
                case "Install":
                    Application.Run(new SystemInstallDialogue());
                    break;
                //case "Prepare":
                //    Application.Run(new PrepareDialogue());
                //    break;
                //case "Prerequisites":
                //    Application.Run(new PrerequisitesDialogue());
                //    break;              
                case "Uninstall":
                    System.IO.File.Copy(Application.ExecutablePath, System.IO.Path.GetTempPath() + "\\CDS.Client.Installer.Prerequisites.exe",true);
                    Helper.Execute(System.IO.Path.GetTempPath() + "\\CDS.Client.Installer.Prerequisites.exe", "Remove", false, false);        
                    Application.Exit();
                    break;
                case "Remove":
                    if (System.IO.Directory.Exists("C:\\Program Files\\Complete Distribution\\Client\\Enterprise"))
                        System.IO.Directory.Delete("C:\\Program Files\\Complete Distribution\\Client\\Enterprise", true);

                    if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CDS Enterprise.lnk"))
                        System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CDS Enterprise.lnk");
    
                    Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{3f8d6197-b112-48fa-a60f-7cf6f3c67c08}", true);
                    Application.Exit();
                    break;
            }
        }
    }
}
