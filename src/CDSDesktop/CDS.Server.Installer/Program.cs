//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms; 

namespace CDS.Server.Installer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            try
            {
                //if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\LoadedAssembly.txt"))
                //    System.IO.File.Delete(System.Windows.Forms.Application.StartupPath + @"\LoadedAssembly.txt");

                //if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\LoadedAssembly.txt"))
                //    System.IO.File.Delete(System.Windows.Forms.Application.StartupPath + @"\LoadedAssembly.txt");

                //System.AppDomain currentDomain = System.AppDomain.CurrentDomain;
                //currentDomain.AssemblyLoad += new System.AssemblyLoadEventHandler(LoadFromFolderAssemblyLoad);
                //currentDomain.AssemblyResolve += new System.ResolveEventHandler(LoadFromFolderAssemblyResolve);

                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-us", true);
                culture.NumberFormat.CurrencyDecimalDigits = 2;
                culture.NumberFormat.CurrencyDecimalSeparator = ".";
                culture.NumberFormat.CurrencySymbol = "";

                System.Threading.Thread.CurrentThread.CurrentCulture = culture;

                DevExpress.Utils.FormatInfo.AlwaysUseThreadFormat = true;

                System.Windows.Forms.Application.Run(new InstallerForm());

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        //static void LoadFromFolderAssemblyLoad(object sender, System.AssemblyLoadEventArgs args)
        //{
        //    try
        //    {
        //        using (System.IO.StreamWriter ms = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + @"\LoadedAssembly.txt", true))
        //        {
        //            ms.WriteLine(args.LoadedAssembly.FullName);
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //}

        //static System.Reflection.Assembly LoadFromFolderAssemblyResolve(object sender, System.ResolveEventArgs args)
        //{
        //    try
        //    {
        //        using (System.IO.StreamWriter ms = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + @"\ResolvedAssembly.txt", true))
        //        {
        //            ms.WriteLine(args.Name);
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
 
        //    }

        //    string folderPath = @"C:\Program Files\Complete Distribution\Client\Enterprise\";
        //    string assemblyPath = System.IO.Path.Combine(folderPath, new System.Reflection.AssemblyName(args.Name).Name + ".dll");
        //    if (System.IO.File.Exists(assemblyPath) == false) return null;
        //    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(assemblyPath);
        //    return assembly;
        //}
    }

}
