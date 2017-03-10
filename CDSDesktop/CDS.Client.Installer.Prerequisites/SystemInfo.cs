using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Installer.Prerequisites
{
    public static class SystemInfo
    {
        public static bool is64BitProcess = (IntPtr.Size == 8);
        public static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsOSValid
        {
            get
            {
                //Pre Windows Vista
                if (Environment.OSVersion.Version.Major < 6)
                {
                    return false;
                }
                //Pre Windows 7
                else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor != 1)
                {
                    return false;
                }
                //Windows 7 or Windows 2008 R2
                else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
                {
                    return true;
                }
                return false;
            }

        }

        public static bool ShouldInstallDotNet
        {
            get
            {
                //If no .Net 4 isnt stalled
                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4") == null)
                    return true;

                //Check that version of .NET 4.x.x is in installed
                using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
                {
                    int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    return releaseKey < 378758;
                }
                //If somehow it gest here just install .NET 4.5.1
                return true;
            }
        }

        public static bool ShouldInstallWin7SP1
        {
            get
            {
                return (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1) && Environment.OSVersion.ServicePack != "Service Pack 1";
            }
        }

        public static bool ShouldInstallSQLLocalDB
        {
            get
            {
                //If no LocalDB isnt stalled
                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server Local DB\\Installed Versions\\11.0") == null)
                    return true; 
               
                return false;
            }
        }

        public static bool ShouldInstallIIS
        {
            get
            {
                //If no LocalDB isnt stalled
                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\InetStp") == null
                    || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\InetStp\\Components") == null)
                    return true;

                using (RegistryKey ndpKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\InetStp\\Components\\"))
                {
                    int isInstalled = Convert.ToInt32(ndpKey.GetValue("DefaultDocument"));
                    return isInstalled != 1;
                }
                 
            }
        }

    }
}
