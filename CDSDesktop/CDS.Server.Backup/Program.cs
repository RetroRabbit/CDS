using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Server.Backup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            
            if (args.Length > 0)
            {

                switch (args[0])
                {
                    case "-i":
                        {
                            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                            break;
                        }
                    case "-u":
                        {
                            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                            break;
                        }
                }
            }
            else
            {
                //ServiceController service = new ServiceController("CDS Backup",Environment.MachineName);
                //service.Start(); 
                //ServiceBase[] ServicesToRun = new ServiceBase[] { new CDSBackup() };
                //ServiceBase.Run(ServicesToRun);
            }
        }
       
    }
}
