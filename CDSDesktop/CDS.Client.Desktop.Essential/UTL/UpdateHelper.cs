using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Essential.UTL
{
    public class UpdateHelper
    {
        /// <summary>
        /// Retrieves the current database version stamp
        /// </summary>
        /// <returns>The database version</returns>
        public static Version GetServerVersion(string Connection)
        {
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = cn;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT TOP 1 [version] FROM [CDS_SYS].[SYS_Version] ORDER BY VersionPadded DESC";
                    cn.Open();
                    string version = (string)cm.ExecuteScalar();
                    return new Version(version ?? System.Windows.Forms.Application.ProductVersion);
                }
            }
        }

        public static Version GetNextVersion(string Connection,string currentVersion)
        {
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = cn;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT TOP 1 [version] FROM [CDS_SYS].[SYS_Version] WHERE VersionPadded > [CDS_SYS].[fnVersionPad] ('" + currentVersion + "') ORDER BY VersionPadded";
                    cn.Open();
                    string version = (string)cm.ExecuteScalar();
                    return new Version(version ?? System.Windows.Forms.Application.ProductVersion);
                }
            }
        }

        public static bool DownloadClientDirector(string Connection, string Version, string TemporaryPath)
        {
            bool filePresent = false;

            using (SqlConnection cn = new SqlConnection(Connection))
            {
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = cn;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT ClientDirector FROM [CDS_SYS].[SYS_Version] WHERE Version = @FileVersionName";
                    cm.Parameters.AddWithValue("@FileVersionName", Version);
                    cn.Open();
                    SqlDataReader reader = cm.ExecuteReader(CommandBehavior.SequentialAccess);
                    if (reader.Read())
                    {
                        extractFileFromReader(Path.Combine(TemporaryPath, "Director.xml"), reader);
                        filePresent = true;
                    }

                    reader.Close();
                }
            }
            return filePresent;
        }

        public static bool DownloadClientUpdate(string Connection, string Version, string TemporaryPath)
        {
            bool filePresent = false;

            using (SqlConnection cn = new SqlConnection(Connection))
            {
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = cn;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT ClientUpdate FROM [CDS_SYS].[SYS_Version] WHERE Version = @FileVersionName";
                    cm.Parameters.AddWithValue("@FileVersionName", Version);
                    cn.Open();
                    SqlDataReader reader = cm.ExecuteReader(CommandBehavior.SequentialAccess);
                    if (reader.Read())
                    {
                        extractFileFromReader(Path.Combine(TemporaryPath, String.Format("{0}.zip", Version)), reader);
                        filePresent = true;
                    }

                    reader.Close();
                }
            }
            return filePresent;
        }

        private static void extractFileFromReader(string fileLocation, SqlDataReader reader)
        {
            int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];
            long retval;
            long startIndex = 0;

            using (FileStream fs = new FileStream(fileLocation, FileMode.CreateNew, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    startIndex = 0;
                    retval = reader.GetBytes(0, startIndex, buffer, 0, bufferSize);

                    while (retval == bufferSize)
                    {
                        bw.Write(buffer);
                        startIndex += bufferSize;
                        retval = reader.GetBytes(0, startIndex, buffer, 0, bufferSize);
                    }

                    bw.Write(buffer, 0, (int)retval);
                }
            }
            return;
        }

        public static List<DB.SYS_Version> GetVersionInfo(string Connection)
        {
            List<DB.SYS_Version> versions = new List<DB.SYS_Version>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Connection))
                {
                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.Connection = cn;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "SELECT Id,Version,Description,CreatedOn,VersionPadded FROM [CDS_SYS].[SYS_Version] ORDER BY VersionPadded";
                        cn.Open();
                        SqlDataReader sqlReader = cm.ExecuteReader();
                        while (sqlReader.Read())
                        {
                            versions.Add(new DB.SYS_Version()
                            {
                                //if (!Convert.IsDBNull(sqlReader["Id"])) Id.Id = Convert.ToInt64(sqlReader["Id"])
                                Id = Convert.ToInt64(sqlReader["Id"]),
                                Version = Convert.ToString(sqlReader["Version"]),
                                Description = !Convert.IsDBNull(sqlReader["Description"]) ? Convert.ToString(sqlReader["Description"]) : null,
                                CreatedOn = DateTime.Parse(Convert.ToString(sqlReader["CreatedOn"]))
                            });
                        }

                        sqlReader.Close();
                    }
                }
            }
            catch
            {
 
            }
            return versions;
        }
    }
}
