using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Installer.Prerequisites
{
    public static class Helper
    {
        public static string StartupPath { get { return Application.StartupPath; } }

        public static void Execute(string file, string arguments, bool waitForExit, bool hidewindows, string workingDirectory)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            if (hidewindows)
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = file;

            if (workingDirectory != null)
                startInfo.WorkingDirectory = workingDirectory;

            startInfo.Arguments = arguments;

            process.StartInfo = startInfo;
            process.Start();
            if (waitForExit)
                process.WaitForExit();
        }

        public static void Execute(string file, string arguments, bool waitForExit)
        {
            Execute(file, arguments, waitForExit, false, null);
        }
        public static void Execute(string file, string arguments, bool waitForExit, bool hidewindows)
        {
            Execute(file, arguments, waitForExit, hidewindows, null);
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

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
                if (!System.IO.File.Exists(temppath) || file.LastWriteTime > System.IO.File.GetLastAccessTime(temppath))
                    file.CopyTo(temppath, true);
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

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, int dwFlags);
    }
    static class KeyboardSend
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public static void KeyDown(Keys vKey)
        {
            //keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            //System.Threading.Thread.Sleep(500);
        }

        public static void KeyUp(Keys vKey)
        {
            //keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            //System.Threading.Thread.Sleep(500);
        }
    }
}
