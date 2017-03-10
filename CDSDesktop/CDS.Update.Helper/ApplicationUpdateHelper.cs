using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace CDS.Update.Helper
{
    public static class ApplicationUpdateHelper
    {
        public static EventLog UpdateEvents
        {
            get
            {
                System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                if (!System.Diagnostics.EventLog.SourceExists("MySource"))
                {
                    System.Diagnostics.EventLog.CreateEventSource(
                        "MySource", "MyNewLog");
                }
                eventLog.Source = "MySource";
                eventLog.Log = "MyNewLog";
                return eventLog;
            }
        }

        /// <summary>
        /// Checks for/parses update.xml on server
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public static ApplicationUpdateXml HasUpdate(IApplicationUpdatable application)
        {

            ApplicationUpdateXml xml = null;
            try
            {
                // Check for update on server
                if (ApplicationUpdateXml.ExistsOnServer(application.UpdateXmlLocation))
                {
                    xml = ApplicationUpdateXml.Parse(application.UpdateXmlLocation);
                }

            }
            catch (Exception ex)
            {
                UpdateEvents.WriteEntry(ex.ToString());
            }
            return xml;
        }

        /// <summary>
        /// Returns the PhysicalPath for the Data Service
        /// </summary>
        /// <returns></returns>
        public static string WebServiceDir(string name)
        {
            using (Microsoft.Web.Administration.ServerManager serverManager = new Microsoft.Web.Administration.ServerManager())
            {
                Site site = serverManager.Sites.FirstOrDefault(s => s.Name == name);
                
                //Use Default Web Site if site isn't found
                if(site == null)
                    site = serverManager.Sites.FirstOrDefault(s => s.Name == "Default Web Site");

                if (site == null)
                    return null;

                var applicationRoot =
                         site.Applications.Where(a => a.Path == "/").Single();
                var virtualRoot =
                         applicationRoot.VirtualDirectories.Where(v => v.Path == "/").Single();
                return Environment.ExpandEnvironmentVariables(virtualRoot.PhysicalPath);
            }
        }

        /// <summary>
        /// Hash the file and compare to the hash in the update xml
        /// </summary>
        /// <param name="file"></param>
        /// <param name="updateMD5"></param>
        /// <returns></returns>
        public static bool DoesFilesMatch(string file, string updateMD5)
        {
            if (Hasher.HashFile(file, HashType.MD5).ToUpper() != updateMD5.ToUpper())
                return false;
            else
                return true;
        }

        /// <summary>
        /// Formats the byte count to closest byte type
        /// </summary>
        /// <param name="bytes">The amount of bytes</param>
        /// <param name="decimalPlaces">How many decimal places to show</param>
        /// <param name="showByteType">Add the byte type on the end of the string</param>
        /// <returns>The bytes formatted as specified</returns>
        public static string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            // Check if best size in KB
            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                // Check if best size in MB
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                // Best size in GB
                newBytes /= 1073741824;
                byteType = "GB";
            }

            // Show decimals
            if (decimalPlaces > 0)
                formatString += ":0.";

            // Add decimals
            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";

            // Close placeholder
            formatString += "}";

            // Add byte type
            if (showByteType)
                formatString += byteType;

            return String.Format(formatString, newBytes);
        }

        /// <summary>
        /// Copies giver source directory to destination directory
        /// </summary>
        /// <param name="sourceDirName">Directory to copy</param>
        /// <param name="destDirName">Directory to copy source directory content</param>
        /// <param name="copySubDirs">Indicated if sub folders should be copied</param>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        /// <summary>
        /// Hack to close program, delete original, move the new one to that location
        /// </summary>
        /// <param name="tempFilePath">The temporary file's path</param>
        /// <param name="currentPath">The path of the current application</param>
        /// <param name="newPath">The new path for the new file</param>
        /// <param name="launchArgs">The launch arguments</param>
        public static void Update(string currentDirectory, ApplicationUpdateXml update, string clientZipLocation)
        {
            try
            {
                UnzipUpdate(update);
                var templocation = Path.GetTempPath() + update.Version + @"\";
                List<string> restartWhenDone = new List<string>();

                string fileArgument = "/C choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & choice /C Y /N /D Y /T 2 & Copy /Y \"{1}\" \"{2}\" & exit";
                string serviceArgument = "/C SC STOP \"{3}\" & choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & choice /C Y /N /D Y /T 2 & Copy /Y \"{1}\" \"{2}\" & SC START \"{3}\" -r {4} & exit";

                ProcessStartInfo Info = new ProcessStartInfo();
                Info.WindowStyle = ProcessWindowStyle.Hidden;
                Info.CreateNoWindow = true;
                Info.FileName = "cmd.exe";

                foreach (ApplicationUpdateXml.UpdateApplication application in update.Applications)
                {
                    foreach (ApplicationUpdateXml.UpdateFile file in application.Files)
                    {
                        switch (application.Type)
                        {
                            case "Service":

                                UpdateEvents.WriteEntry(String.Format("{0}", "Entering Service"));

                                if (file.Name == Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location))
                                    continue;

                                Info.Arguments = String.Format(fileArgument, currentDirectory + @"\" + file.destination + file.Name, templocation + file.Name, currentDirectory + @"\" + file.destination + file.Name, currentDirectory + file.destination + file.Name, templocation + file.Name, Path.GetFileName(file.Name), update.LaunchArgs);
                                Process.Start(Info);
                                break;
                            case "Desktop":

                                UpdateEvents.WriteEntry(String.Format("{0}", "Entering Desktop"));

                                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();



                                foreach (System.Diagnostics.Process p in processes)
                                {
                                    try
                                    {

                                        if (Path.GetFileName(p.Modules[0].FileName) == Path.GetFileName(currentDirectory + @"\" + file.destination + file.Name))
                                        {

                                            UpdateEvents.WriteEntry("Kill Active CDS");
                                            UpdateEvents.WriteEntry("Need to restart " + p.Modules[0].FileName);
                                            restartWhenDone.Add(p.Modules[0].FileName);
                                            p.Kill();
                                        }

                                        if (p.Modules[0].FileName.Contains("Desktop"))
                                        {
                                            UpdateEvents.WriteEntry("updating cds");
                                            UpdateEvents.WriteEntry(Path.GetFileName(p.Modules[0].FileName + Environment.NewLine +
                                            Path.GetFileName(currentDirectory + @"\" + file.destination + file.Name)));
                                        }
                                    }
                                    catch
                                    { }
                                }
                                Info.Arguments = String.Format(fileArgument, currentDirectory + @"\" + file.destination + file.Name, templocation + file.Name, currentDirectory + @"\" + file.destination + file.Name, currentDirectory + file.destination + file.Name, templocation + file.Name, Path.GetFileName(file.Name), update.LaunchArgs);

                                UpdateEvents.WriteEntry("Desktop " + Info.Arguments);

                                Process.Start(Info);
                                break;
                            case "Web":

                                var siteDirectory = WebServiceDir(application.Name);

                                if (siteDirectory == null)
                                {
                                    UpdateEvents.WriteEntry("Could not find site");
                                }
                                else
                                {
                                    Info.Arguments = String.Format(fileArgument, siteDirectory + @"\" + file.destination + file.Name, templocation + @"bin\" + file.Name, siteDirectory + @"\" + file.destination + file.Name, siteDirectory + file.destination + file.Name, templocation + file.Name, Path.GetFileName(file.Name), update.LaunchArgs);
                                    UpdateEvents.WriteEntry(Info.Arguments);
                                    Process.Start(Info);
                                }
                                break;
                            case "Zip":
                                UpdateEvents.WriteEntry("Found Client Zip");
                                var extractDirectory = WebServiceDir(application.Name);
                                UpdateEvents.WriteEntry("Found iis " + extractDirectory);
                                if (!Directory.Exists(extractDirectory + @"\" + clientZipLocation))
                                {
                                    Directory.CreateDirectory(extractDirectory + @"\" + clientZipLocation);
                                }
                                else
                                {
                                    File.Delete(extractDirectory + @"\" + clientZipLocation + @"\publish.xml");
                                }

                                UpdateEvents.WriteEntry("Extracting " + Path.GetTempPath() + update.Version + @"\" + file.Name + " to " + extractDirectory + @"\" + clientZipLocation);
                                if (File.Exists(extractDirectory + @"\" + clientZipLocation + @"\publish\" + file.Name))
                                    File.Delete(extractDirectory + @"\" + clientZipLocation + @"\publish\" + file.Name);
                                ZipFile.ExtractToDirectory(Path.GetTempPath() + update.Version + @"\" + file.Name, extractDirectory + @"\" + clientZipLocation);
                                UpdateEvents.WriteEntry("Extracted Client Zip");
                                break;
                        }

                    }
                }

                if (update.Applications.Any(n => n.Type == "Service") &&
                    update.Applications.Any(n => n.Type == "Service" && n.Files.Select(l => l.Name).Contains(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)))
                    )
                {
                    var application = update.Applications.FirstOrDefault(n => n.Type == "Service" && n.Files.Select(l => l.Name).Contains(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)));
                    var exeFile = application.Files.FirstOrDefault(n => n.Name.Contains(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)));
                    Info.Arguments = String.Format(serviceArgument, currentDirectory + @"\" + exeFile.destination + exeFile.Name, templocation + exeFile.Name, currentDirectory + @"\" + exeFile.Name, application.Name, "\"" + string.Join("\" \"", restartWhenDone) + "\"");
                    Process.Start(Info);
                }

                foreach (var program in restartWhenDone)
                {
                    try
                    {
                        //System.Threading.Thread.Sleep(5000);
                        //while (!File.Exists(program)) { UpdateEvents.WriteEntry("Waiting for " + program); }
                        //
                        UpdateEvents.WriteEntry("Program to start " + program);
                        //ProcessStartInfo appInfo = new ProcessStartInfo();
                        ////appInfo.Arguments = string.Format("/C cmd /C \"{0}\"", program);
                        //appInfo.UseShellExecute = false;
                        //appInfo.FileName = program;
                        //appInfo.WorkingDirectory = Path.GetDirectoryName(program);
                        //appInfo.CreateNoWindow = false;
                        //appInfo.WindowStyle = ProcessWindowStyle.Normal;
                        //UpdateEvents.WriteEntry(appInfo.FileName + Environment.NewLine + appInfo.WorkingDirectory);
                        Process.Start(program);
                    }
                    catch (Exception ex)
                    {
                        UpdateEvents.WriteEntry(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateEvents.WriteEntry(ex.ToString());
                throw;
            }

        }

        private static void UnzipUpdate(ApplicationUpdateXml update)
        {
            if (Directory.Exists(Path.GetTempPath() + update.Version))
                Directory.Delete(Path.GetTempPath() + update.Version, true);

            ZipFile.ExtractToDirectory(Path.GetTempPath() + update.Version + @".zip", Path.GetTempPath() + update.Version);
        }
    }
}
