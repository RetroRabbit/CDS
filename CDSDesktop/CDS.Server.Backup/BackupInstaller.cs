using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace CDS.Server.Backup
{
    [RunInstaller(true)]
    public partial class BackupInstaller : System.Configuration.Install.Installer
    {
        public BackupInstaller()
        {
            InitializeComponent();
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
   
        }
    }
}
