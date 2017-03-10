using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Configuration.Install;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Net.BITS;
using Ionic.Utils.Zip;

namespace CDS.Server.Backup
{
    public partial class CDSBackup : ServiceBase
    {
        EventLog eventLog1 = new EventLog();
        public CDSBackup()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";

        }
        bool execute;
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Started");
            execute = true;

            Thread mythread = new Thread(run);
            mythread.Start();

          //  Thread mySPthread = new Thread(runSP);
         //   mySPthread.Start();

        }

        protected override void OnStop()
        {
            execute = false;

        }

        private void runSP()
        {

            while (execute)
            {

                if (DateTime.Now.Hour == Convert.ToInt32(CDS.Server.Backup.Properties.Settings.Default.sptime) && DateTime.Now.Minute == Convert.ToInt32(CDS.Server.Backup.Properties.Settings.Default.spmin))
                {
                    eventLog1.WriteEntry("Running SP");
                    execSP();
                }
                Thread.Sleep(60000);

            }

        }

        private void run()
        {
            try
            {
                while (execute)
                {

                    if (DateTime.Now.Hour == Convert.ToInt32(CDS.Server.Backup.Properties.Settings.Default.backuptime) && DateTime.Now.Minute == Convert.ToInt32(CDS.Server.Backup.Properties.Settings.Default.backupmin))
                    {
                        eventLog1.WriteEntry("Creating Backup");
                        CreateBackUp();
                    }
                    Thread.Sleep(60000);

                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry(ex.ToString());
                this.Stop();
            }

        }

        private void CreateBackUp()
        {


            try
            {

                string name = "RETBACK";

                SqlConnection sqlCon = new SqlConnection(CDS.Server.Backup.Properties.Settings.Default.conn);
                ServerConnection connection = new ServerConnection(sqlCon);

                Microsoft.SqlServer.Management.Smo.Server svr = new Microsoft.SqlServer.Management.Smo.Server(connection);
                Microsoft.SqlServer.Management.Smo.Backup bkp = new Microsoft.SqlServer.Management.Smo.Backup();

                string extra = CDS.Server.Backup.Properties.Settings.Default.site;


                string backupDirectory = CDS.Server.Backup.Properties.Settings.Default.backupdirectory;

                string backUpFilename = backupDirectory + "\\" + "CDS_" + extra + DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + ".bak";
                Console.WriteLine("File name set : " + backUpFilename);
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }
                bkp.Devices.AddDevice(backUpFilename, DeviceType.File);
                bkp.BackupSetDescription = name;
                bkp.BackupSetName = name;

                bkp.Database = CDS.Server.Backup.Properties.Settings.Default.databasename;
                bkp.Action = BackupActionType.Database;
                bkp.Initialize = true;
                bkp.Incremental = false;

                bkp.SqlBackup(svr);
                try
                {
                    string smsisdn = CDS.Server.Backup.Properties.Settings.Default.contacts;
                    string[] msisdn = smsisdn.Split(new char[] { ',' });
                    for (int t = 0; t < msisdn.Length; t++)
                    {
                        if (msisdn[t].Substring(0, 2) != "27") msisdn[t] = "27" + msisdn[t].Substring(1);
                        SMS(msisdn[t], "CDS: " + CDS.Server.Backup.Properties.Settings.Default.site + " backup completed." + DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                }

                //if (DateTime.Now.DayOfWeek.ToString().CompareTo(CDS.Server.Backup.Properties.Settings.Default.remotebackday) == 0)
                //{
                //    eventLog1.WriteEntry("Registering JOB");
                //    CreateJob(backUpFilename, "CDS_" + extra + DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + ".bak");

                //}
                //else if (DateTime.Now.Day.ToString().CompareTo(CDS.Server.Backup.Properties.Settings.Default.remotebackupdate) == 0)
                //{
                //    eventLog1.WriteEntry("Registering JOB");
                //    CreateJob(backUpFilename, "CDS_" + extra + DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + ".bak");

                //}

                // Delete old backups
                int daysOld = 30;
                daysOld = Convert.ToInt32(CDS.Server.Backup.Properties.Settings.Default.daysOld);
                deleteOldFiles(backupDirectory, DateTime.Now.AddDays(-daysOld));

            }
            catch (Exception ex)
            {
                //if (EventLog.SourceExists(""))
                eventLog1.WriteEntry(ex.ToString());
                string smsisdn = CDS.Server.Backup.Properties.Settings.Default.contacts;
                string[] msisdn = smsisdn.Split(new char[] { ',' });
                for (int t = 0; t < msisdn.Length; t++)
                {
                    if (msisdn[t].Substring(0, 2) != "27") msisdn[t] = "27" + msisdn[t].Substring(1);
                    SMS(msisdn[t], "CDS:There was a problem with the " + CDS.Server.Backup.Properties.Settings.Default.site + " backup!");
                }
            }
            finally
            {
                Thread.Sleep(3600000);
            }

        }

        private void deleteOldFiles(string path, DateTime olderThanDate)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime < olderThanDate)
                {
                    System.Console.WriteLine(
                          String.Format("Delete {0}.", file.FullName)
                    );
                    file.IsReadOnly = false;
                    file.Delete();
                    //fileCount++;
                }
            }

            // Now recurse down the directories
            //DirectoryInfo[] dirs = dirInfo.GetDirectories();
            //foreach (DirectoryInfo dir in dirs)
            //{
            //    deleteOldFiles(dir.FullName, olderThanDate);
            //}
        }

        private void execSP()
        {
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = new SqlConnection(CDS.Server.Backup.Properties.Settings.Default.conn);
                if (sqlCon.State != ConnectionState.Open) sqlCon.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlCon;
                cmd.CommandTimeout = 0;
                cmd.CommandText = CDS.Server.Backup.Properties.Settings.Default.spname;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //if (EventLog.SourceExists(""))
                eventLog1.WriteEntry(ex.ToString());
            }
            finally
            {
                if (sqlCon.State != ConnectionState.Closed) sqlCon.Close();
                Thread.Sleep(3600000);
            }
        }

        private void CreateJob(string localfilename, string serverfilename)
        {
            try
            {
                Manager manager = new Manager();
                Job jobTest = new Job("CDS" + DateTime.Now.ToString("yyyy-MM-dd"));

                manager.Jobs.AddRange(new System.Net.BITS.Job[] { jobTest });
                manager.OnModfication += new System.EventHandler<System.Net.BITS.JobModificationEventArgs>(this.manager_OnModfication);
                manager.OnFileTransferred += new System.EventHandler<System.Net.BITS.FileTransferredEventArgs>(this.manager_OnFileTransferred);
                manager.OnTransferred += new System.EventHandler<System.Net.BITS.JobTransferredEventArgs>(this.manager_OnTransferred);
                manager.OnError += new System.EventHandler<System.Net.BITS.JobErrorEventArgs>(this.manager_OnError);
                // 
                // jobTest
                // 
                FileInfo fi = new FileInfo(localfilename);
                string zipfile = fi.DirectoryName + "\\ZIP\\" + fi.Name + ".zip";

                if (!Directory.Exists(fi.DirectoryName + "\\ZIP"))
                {
                    Directory.CreateDirectory(fi.DirectoryName + "\\ZIP");
                }
                try
                {
                    using (ZipFile zip = new ZipFile(zipfile))
                    {
                        zip.AddFile(localfilename, "");

                        zip.Save();
                    }
                }
                catch (System.Exception ex1)
                {
                    eventLog1.WriteEntry("Exception :" + ex1.ToString());

                }


                eventLog1.WriteEntry("About to send :" + CDS.Server.Backup.Properties.Settings.Default.remoteserver + serverfilename + ".zip," + zipfile);
                jobTest.DisplayName = "DataUpload";
                jobTest.Files.AddRange(new System.Net.BITS.File[] { new System.Net.BITS.File(CDS.Server.Backup.Properties.Settings.Default.remoteserver + serverfilename + ".zip", zipfile), });
                jobTest.Type = JobType.Upload;
                jobTest.Priority = System.Net.BITS.JobPriority.Foreground;

                jobTest.Activate();
                jobTest.Resume();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("Exception :" + ex.ToString());
            }
        }

        private void manager_OnError(object sender, JobErrorEventArgs e)
        {
            if (e.Job.State == JobState.Cancelled)
                return;
        }

        private void manager_OnModfication(object sender, JobModificationEventArgs e)
        {
            if (e.Job.State == JobState.TransientError)
            {
                int t = 0;

            }
        }
        private void manager_OnTransferred(object sender, JobTransferredEventArgs e)
        {
            int t = 0;
        }

        private void manager_OnFileTransferred(object sender, FileTransferredEventArgs e)
        {
            int t = 0;
        }

        private void SMS(string msisdn, string description)
        {

            try
            {
                //WebReference.MMSGatewayService ss = new WebReference.MMSGatewayService();
                //ss.sendSMS(CDS.Server.Backup.Properties.Settings.Default.name, CDS.Server.Backup.Properties.Settings.Default.acc, msisdn, description);

            }
            catch (Exception Ex)
            {
                eventLog1.WriteEntry(Ex.ToString());
            }
        }
    }
}
