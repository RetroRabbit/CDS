using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CDS.Update.Helper
{
    /// <summary>
    /// Contains update information
    /// </summary>
    public class ApplicationUpdateXml
    {
        private Version version;
        private string md5;
        private List<UpdateApplication> applications;
        private string launchArgs;

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
        /// The update version #
        /// </summary>
        public Version Version
        {
            get { return this.version; }
        }

        /// <summary>
        /// The update Md5 for the Zip file
        /// </summary>
        public String Md5
        {
            get { return this.md5; }
        }

        /// <summary>
        /// The file name of the binary
        /// for use on local computer
        /// </summary>
        public List<UpdateApplication> Applications
        {
            get { return this.applications; }
        }

        /// <summary>
        /// The arguments to pass to the updated application on startup
        /// </summary>
        public string LaunchArgs
        {
            get { return this.launchArgs; }
        }

        /// <summary>
        /// Creates a new ApplicationUpdateXml object
        /// </summary>
        public ApplicationUpdateXml(Version version,String md5, List<UpdateApplication> applications, string launchArgs)
        {
            this.version = version;
            this.md5 = md5;
            this.applications = applications;
            this.launchArgs = launchArgs;
        }

        /// <summary>
        /// Checks if update's version is newer than the old version
        /// </summary>
        /// <param name="version">Application's current version</param>
        /// <returns>If the update's version # is newer</returns>
        public bool IsNewerThan(Version version)
        {
            return this.version > version;
        }

        /// <summary>
        /// Checks the Uri to make sure file exist
        /// </summary>
        /// <param name="location">The Uri of the update.xml</param>
        /// <returns>If the file exists</returns>
        public static bool ExistsOnServer(Uri location)
        {
            try
            {
                // Request the update.xml
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                // Read for response
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();

                return resp.StatusCode == HttpStatusCode.OK;
            }
            catch(Exception ex)
            {
                UpdateEvents.WriteEntry(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Parses the update.xml into ApplicationUpdateXml object
        /// </summary>
        /// <param name="location">Uri of update.xml on server</param>
        /// <param name="appID">The application's ID</param>
        /// <returns>The ApplicationUpdateXml object with the data, or null of any errors</returns>
        public static ApplicationUpdateXml Parse(Uri location)
        {
            Version version = null;
            string launchArgs = "", md5 = "";
            List<UpdateApplication> applications = new List<UpdateApplication>();
            ServicePointManager.ServerCertificateValidationCallback = (s, ce, ch, ssl) => true;
            XmlDocument doc = new XmlDocument();
            try
            {
                // Load the document 
                doc.Load(location.AbsoluteUri);

                // Gets the appId's node with the update info
                // This allows you to store all program's update nodes in one file
                XmlNode updateNode = doc.DocumentElement.SelectSingleNode("//update");

                // If the node doesn't exist, there is no update
                if (updateNode == null)
                    return null;

                // Parse data
                version = Version.Parse(updateNode["version"].InnerText);

                md5 = updateNode["md5"].InnerText;
                 
                foreach (XmlNode application in doc.DocumentElement.SelectNodes("//update//application"))
                {
                    List<UpdateFile> files = new List<UpdateFile>();
                    string type = application["type"].InnerText;

                    foreach (XmlNode file in application.SelectSingleNode("files").SelectNodes("file"))
                    {
                        files.Add(new UpdateFile() { Name = file["name"].InnerText, destination = file["destination"].InnerText, md5 = file["md5"].InnerText });
                    }

                    applications.Add(new UpdateApplication() { Name = application.Attributes["appID"].InnerText, Type = type, Files = files });
                }
                launchArgs = updateNode["launchArgs"].InnerText;

                return new ApplicationUpdateXml(version, md5, applications, launchArgs);
            }
            catch (Exception ex)
            {
                UpdateEvents.WriteEntry(ex.ToString());
                return null;
            }
        }

        public class UpdateApplication
        {
            List<UpdateFile> files = new List<UpdateFile>();

            /// <summary>
            /// Name of the application to update
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Type of application
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// List of files to update
            /// </summary>
            public List<UpdateFile> Files { get { return files; } set { files = value; } }
        }

        public class UpdateFile
        {
            /// <summary>
            /// A file name to download to
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// The MD5 hash of the file to download
            /// </summary>
            public string md5 { get; set; }
            /// <summary>
            /// Location of the file to replace
            /// </summary>
            public string destination { get; set; }
            /// <summary>
            /// A temp file name to download to
            /// </summary>
            //public string tempFile { get; set; }

        }
    }
}
