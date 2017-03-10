using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CDS.Update.Helper;

namespace CDS.Update.Service
{
    public partial class Service : ServiceBase, IApplicationUpdatable
    {
        private System.Diagnostics.EventLog eventLog;
        private Helper.IApplicationUpdatable applicationInfo { get { return this; } }
        System.Timers.Timer timer = new System.Timers.Timer();
        private ApplicationUpdateXml update;

        /// <summary>
        /// The web client to download the update
        /// </summary>
        //private List<WebClient> webClients;
        private WebClient webClient;

        /// <summary>
        /// The thread to hash the file on
        /// </summary>
        private BackgroundWorker bgWorker;

        /// <summary>
        /// Gets the temp file path for the downloaded file
        /// </summary>
        internal ApplicationUpdateXml Update
        {
            get { return this.Update; }

        }

        public object ApplicationIcon
        {
            get { return null; }
        }

        public Service()
        {
            InitializeComponent();
            eventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog.Source = "MySource";
            eventLog.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.
            eventLog.WriteEntry("Starting service");
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            Console.WriteLine(ServiceInstallHelper.GetServiceName());
            ServiceInstallHelper.SetRecoveryOptions(ServiceInstallHelper.GetServiceName());

            TimeSpan startTime = Properties.Settings.Default.StartTime;

            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startTime.Hours, startTime.Minutes, startTime.Seconds);
          
            if (DateTime.Now > startDate)
            {
                startDate = startDate.AddDays(1);
            }
             
            // Set up a timer to trigger at a certain time.
            timer.AutoReset = false;
            timer.Interval = (startDate - DateTime.Now).TotalMilliseconds;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();

            // Update the service state to Running.
            eventLog.WriteEntry("Started service");
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            if (args.Count() > 0)
            {
                eventLog.WriteEntry(string.Join(" ", args));
            }

        }

        protected override void OnStop()
        {

            eventLog.WriteEntry("Stopping service");
            // Update the service state to Running.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnCustomCommand(int command)
        {
            eventLog.WriteEntry("Received Command" + command.ToString());
            base.OnCustomCommand(command);
            switch (command)
            {
                case 128: CheckForUpdate();
                    break;
                case 129: StopService();
                    break;
            }
        }

        private void StopService()
        {
            eventLog.WriteEntry("Sending stop command");
            this.Stop();
        }

        private void CheckForUpdate()
        {
            try
            {

                eventLog.WriteEntry("Enter checking update" + DateTime.Now.ToString());
                // Update the service state to Start Pending.
                ServiceStatus serviceStatus = new ServiceStatus();
                serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
                serviceStatus.dwWaitHint = 100000;
                SetServiceStatus(this.ServiceHandle, ref serviceStatus);

                eventLog.WriteEntry("Checking for update xml" + DateTime.Now.ToString());

                ApplicationUpdateXml updateXML = ApplicationUpdateHelper.HasUpdate(this);

                eventLog.WriteEntry("Found update xml" + DateTime.Now.ToString() + updateXML.ToString());

                if (updateXML != null)
                {
                    update = updateXML;
                    eventLog.WriteEntry(String.Format("App Version {0}",this.applicationInfo.ApplicationAssembly.GetName().Version.ToString()));
                    eventLog.WriteEntry(String.Format("update version {0}", update.Version));
                    eventLog.WriteEntry("Is newer" + DateTime.Now.ToString() + update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version).ToString());

                    // Check if the update is not null and is a newer version than the current application
                    if (update != null && update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version))
                    {
                        eventLog.WriteEntry("download update" + DateTime.Now.ToString());
                        this.DownloadUpdate(update); // Do the update
                        eventLog.WriteEntry("updated downloaded" + DateTime.Now.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry("CheckForUpdate Excption " + DateTime.Now.ToString() + ex.ToString());
                timer.Stop();
            } 
        }

        /// <summary>
        /// Downloads update and installs the update
        /// </summary>
        /// <param name="update">The update xml info</param>
        private void DownloadUpdate(ApplicationUpdateXml update)
        {
            //webClients = new List<WebClient>();
            webClient = new WebClient();

            //var filecount = update.Applications.Select(n => n.Files.Count);

            //for (int i = 0; i < filecount.Sum(n => n); i++)
            //    webClients.Add(new WebClient());

            // Set up backgroundworker to download files
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.RunWorkerAsync();


        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Download file
            try
            {

                eventLog.WriteEntry("Entering background worker" + DateTime.Now.ToString());
                //int counter = 0;
                //foreach (ApplicationUpdateXml.UpdateApplication application in update.Applications)
                //{
                //    foreach (var file in application.Files)
                //    {
                //        var webClient = webClients[counter];
                //        file.tempFile = Path.GetTempFileName();
                //        webClient.DownloadFileAsync(new Uri(update.Uri + @"/" + file.Name), file.tempFile);
                //        counter++;
                //    }
                //}

                if (File.Exists(Path.GetTempPath() + update.Version + @".zip"))
                    File.Delete(Path.GetTempPath() + update.Version + @".zip");

                //var remoteFileSize = webClient.OpenRead(new Uri(UpdateZipLocation + @"/" + update.Version + @".zip")).Length;
                //eventLog.WriteEntry(remoteFileSize.ToString());

                eventLog.WriteEntry("downloading file" + DateTime.Now.ToString());

                webClient.DownloadFile(new Uri(UpdateZipLocation + @"/" + update.Version + @".zip"), Path.GetTempPath() + update.Version + @".zip");

                eventLog.WriteEntry("File downloaded" + DateTime.Now.ToString());

                if (!ApplicationUpdateHelper.DoesFilesMatch(Path.GetTempPath() + update.Version + @".zip", update.Md5))
                {
                    eventLog.WriteEntry(string.Format("{0} does not match MD5 : {1}", Path.GetTempPath() + update.Version + @".zip", update.Md5));
                    throw new Exception(String.Format("{0} failed to download", update.Version));
                }
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(string.Format("Exception : {0}", ex.ToString()));
                throw ex;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (File.Exists((Path.GetTempPath() + update.Version + @".zip")))
            {

                eventLog.WriteEntry("Get directory to update" + DateTime.Now.ToString());

                string currentDirectory = Path.GetDirectoryName(this.applicationInfo.ApplicationAssembly.Location);

                eventLog.WriteEntry("Begin update" + DateTime.Now.ToString());

                // "Install" it
                ApplicationUpdateHelper.Update(currentDirectory, update, clientZipLocation);
            }
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            eventLog.WriteEntry("Running Update Timer"+DateTime.Now.ToString());
            CheckForUpdate();
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        #region ApplicationUpdate
        public string ApplicationName
        {
            get { return "Test Service"; }
        }

        public string ApplicationID
        {
            get { return "Test Service"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Uri UpdateLocation
        {
            get { return new Uri(Properties.Settings.Default.UpdateURL); }
        }

        public Uri UpdateZipLocation
        {
            get { return new Uri(Properties.Settings.Default.UpdateURL+ "/publish"); }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri(Properties.Settings.Default.UpdateURL + "/publish.xml"); }
        }

        public string clientZipLocation
        {
            get { return Properties.Settings.Default.ClientZipLocation.ToString(); }
        }

        public Object Context
        {
            get { return this; }
        }
        #endregion

        #region Enum/Struct
        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public long dwServiceType;
            public ServiceState dwCurrentState;
            public long dwControlsAccepted;
            public long dwWin32ExitCode;
            public long dwServiceSpecificExitCode;
            public long dwCheckPoint;
            public long dwWaitHint;
        };
        #endregion
    }
}
