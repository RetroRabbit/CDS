using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDS.Client.BusinessLayer.Configuration;
using System.Security.Cryptography;
using System.Reflection;
using System.Diagnostics;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Net;

namespace CDS.Client.BusinessLayer.SEC
{
    public class SecurityLibrary
    {
        /// <summary>
        /// Set the database connection and connection timeout for the application. These values are retrieved from the config file custom section.
        /// </summary>
        /// <param name="SessionCompany">The configuration entry for the company from which the connection string and connection timeout are retrieved.</param>
        /// <returns>Returns true if connection was succesful, otherwise returns false.</returns>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public static bool SetConnection(RegisteredCompany SessionCompany)
        {
            try
            {
                ApplicationDataContext.Instance.SetConnections(SessionCompany.ConnectionString, true);
                //CDS.Client.BusinessLayer.ApplicationContext.Instance.SetConnections(SessionCompany.ConnectionString, true);
                ApplicationDataContext.Instance.SqlCommandTimeOut = Convert.ToInt32(SessionCompany.ConnectionTimeout);


                return true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.BusinessLogicExceptionHandler.HandleException(ref ex)) throw ex;
                return false;
            }
        }
        
        /// <summary>
        /// Test the connection to the database for the selected company.
        /// </summary>
        /// <param name="SessionCompany">The configuration entry for the company from which the connection string and connection timeout are retrieved.</param>
        /// <returns>Returns true if the connection could be established, otherwise returns false.</returns>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        //public static bool PingConnection(RegisteredCompany SessionCompany)
        public static string PingConnection(RegisteredCompany SessionCompany)
        {
            System.Data.SqlClient.SqlConnection con = null;
            try
            {
                con = new System.Data.SqlClient.SqlConnection(SessionCompany.ConnectionString);
                //con.ConnectionTimeout = Convert.ToInt32(SessionCompany.ConnectionTimeout);

                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();

                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("select top 1 Version from [CDS_SYS].[SYS_Version] order by VersionPadded desc", con);
                string result = command.ExecuteScalar().ToString();

                //return true;
                return result;
            }
            catch (Exception)
            {
                // Do not handle this exception
                //return false;
                return "";
            }
            finally
            {
                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                    System.Data.SqlClient.SqlConnection.ClearPool(con);
                }
            }
        }

        public static bool AccessGranted(SEC.AccessCodes access)
        {
            return (ApplicationDataContext.Instance.AccessGranted(access)); 

        }

        /// <summary>
        /// Attempt to sign into the system with the provided username and password. Note that a database connection must already have been established at this point.
        /// </summary>
        /// <param name="Username">The case insensitive username.</param>
        /// <param name="Password">The case insensitive password.</param>
        /// <returns>Returns true if the user details are correct and could be retrieved, otherwise returns false.</returns>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public static bool Signin(String Username, String Password)
        {
            try
            {
                //CompleteDataLayer.User user = CompleteDataLayer.UserDataProvider.Instance.Authenticate(Username, Password);


                DB.SEC_User user = BL.SEC.SEC_User.Authenticate(Username, EncodePassword(Password));


                if (user != null)
                {
                    // User provided correct credentials
                    ApplicationDataContext.Instance.LoggedInUser = user;
                    ApplicationDataContext.Instance.LoggedInUser.Person = ApplicationDataContext.Instance.SystemEntityContext.SYS_Person.FirstOrDefault(n => n.Id == ApplicationDataContext.Instance.LoggedInUser.PersonId);
                    ApplicationDataContext.Instance.LoggedInUser.DefaultPrinter = ApplicationDataContext.Instance.SystemEntityContext.SYS_Printer.FirstOrDefault(n => n.Id == ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId);
                    ApplicationDataContext.Instance.LoggedInUser.DefaultSite = ApplicationDataContext.Instance.SystemEntityContext.SYS_Site.Include("SYS_Entity").FirstOrDefault(n => n.EntityId == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
                    //Console.WriteLine(ApplicationDataContext.Instance.LoggedInUser.DefaultSite.SYS_Entity.Id);
                    int PortStartIndex = 1000;
                    int PortEndIndex = 2000;
                    System.Net.NetworkInformation.IPGlobalProperties properties = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
                    IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();

                    List<int> usedPorts = tcpEndPoints.Select(p => p.Port).ToList<int>();
                    int unusedPort = 0;

                    for (int port = PortStartIndex; port < PortEndIndex; port++)
                    {
                        if (!usedPorts.Contains(port))
                        {
                            unusedPort = port;
                            break;
                        }
                    }

                    // Update Last Login Details
                    user.LastDate = DateTime.Now;
                    //user.LastLocation = String.Format("Machine: {0};OS: {1}; User:{2}; IP: {3}", Environment.MachineName, Environment.OSVersion, Environment.UserName, System.Net.Dns.GetHostAddresses(Environment.MachineName).Where(n => !n.IsIPv6LinkLocal && !n.IsIPv6Multicast && !n.IsIPv6SiteLocal && !n.IsIPv6Teredo).FirstOrDefault().ToString());
                    user.LastLocation = String.Format("Machine: {0};OS: {1}; User:{2}; IP: {3};Open Port: {4}", Environment.MachineName, Environment.OSVersion, Environment.UserName, System.Net.Dns.GetHostAddresses(Environment.MachineName).Where(n => !n.IsIPv6LinkLocal && !n.IsIPv6Multicast && !n.IsIPv6SiteLocal && n.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString(), unusedPort);
                    //IF this is null you are not loggin in from CDS.Desktop
                    if (Assembly.GetEntryAssembly() == null)
                    {
                        user.LastVersion = FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location).ProductVersion;
                    }
                    else
                    {
                        user.LastVersion = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductVersion;
                    }
                    using (System.Transactions.TransactionScope transaction = BL.ApplicationDataContext.Instance.DataContext.GetTransactionScope())
                    {
                        BL.ApplicationDataContext.Instance.DataContext.SaveChangesEntitySecurityContext();
                        BL.ApplicationDataContext.Instance.DataContext.CompleteTransaction(transaction);
                    }
                    
                    //// Get the user roles and associated access rights
                    //long[] roleids = BL.ApplicationDataContext.Instance.SecurityEntityContext.SEC_UserRole.Where(n => n.UserId == user.Id).Select(n => n.RoleId).ToArray();
                    //ApplicationDataContext.Instance.AccessIds = BL.ApplicationDataContext.Instance.SecurityEntityContext.SEC_RoleAccess.Where(n => roleids.Contains(n.RoleId)).Select(n => n.AccessId).Distinct().ToArray();
                    
                    return true;
                }
                else
                {
                    // User provided incorrect credentials
                    return false;
                }
            }
            catch (Exception ex)
            {
                //if (BusinessLogicExceptionHandler.HandleException(ref ex)) throw ex;
                throw ex.InnerException;
            }
        }

    

        /// <summary>
        /// MD5 one way encrypt passwords
        /// SELECT SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', UPPER('q'))), 3, 32)
        /// </summary>
        /// <param name="Password">the clear text password to be encrypted.</param>
        /// <returns></returns>
        public static String EncodePassword(String Password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(Password.ToUpper());
            bs = md5.ComputeHash(bs);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (byte b in bs)
                sb.Append(b.ToString("x2").ToLower());
            return sb.ToString();
        }
    }
}
