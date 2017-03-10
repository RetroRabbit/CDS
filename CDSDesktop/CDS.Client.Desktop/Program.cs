using CDS.Client.Desktop.Essential.UTL;
using CDS.Client.Desktop.Main;
using DevExpress.XtraReports.Extensions;
using System;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;


namespace CDS.Client.Desktop
{
    static class Program
    {
        static ReportStorageExtension reportStorage;
        static Reporting.Report.Extensions.DesignExtension designExtension;
        public static ReportStorageExtension ReportStorage
        {
            get
            {
                return reportStorage;
            }
        }
        public static Reporting.Report.Extensions.DesignExtension DesignExtension
        {
            get
            {
                return designExtension;
            }
        }

        /// <summary>
        /// Update Notification valuables
        /// </summary>
        public static NotifyIcon notifyicon = null;
        private static ServiceController servicecontroller = null;
        private static ContextMenuStrip contextmenu = null;
        private static Timer timer = null;
        private static bool hasUpdate = false;
        private static System.Collections.Generic.List<System.Drawing.Bitmap> updateImages;

        public static NotifyIcon Notifyicon { get { return notifyicon; } }

        static void RestoreSize()
        {
            if (CustomApplicationSettings.Instance.IsMaximized)
            {
                MainForm.Instance.WindowState = FormWindowState.Maximized;
                MainForm.Instance.StartPosition = FormStartPosition.Manual;
                MainForm.Instance.Location = CustomApplicationSettings.Instance.StartPosition;
                MainForm.Instance.Size = CustomApplicationSettings.Instance.StartSize;


            }
            else
            {
                MainForm.Instance.Location = CustomApplicationSettings.Instance.StartPosition;
                MainForm.Instance.Size = CustomApplicationSettings.Instance.StartSize;
                MainForm.Instance.StartPosition = FormStartPosition.Manual;
                MainForm.Instance.WindowState = FormWindowState.Normal;
            }

        }

        /// <summary>
        /// Presents a login window to the user.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        static void Signin()
        {
            try
            {
                if (BL.ApplicationDataContext.Instance.LoggedInUser != null)
                {
                    // Henko - TODO: Security removed from user roles - still need acceptable replacement
                    //if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE02))
                    RestoreSize();

                    Application.Run(MainForm.Instance);
                }
                else
                {
                    // User credentials have not yet been provided, show login form
                    SigninForm frmLogin = new SigninForm();
                    frmLogin.ShowDialog();
                    if (frmLogin.DialogResult == DialogResult.OK)
                    {
                        // Henko - TODO: Security removed from user roles - still need acceptable replacement
                        //if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE02))
                        RestoreSize();

                        Application.Run(MainForm.Instance);
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Closes the application and exits to Windows.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public static void Signout()
        {
            //if (frmMainForm != null)
            //    frmMainForm.FormClosing -= new FormClosingEventHandler(frmMaster_FormClosing);

            //DataAccessLayer.ApplicationContext.Instance.CommitTransaction(true);

            Application.Exit();
        }

        public static void ConfigureExceptionHandling()
        {
            CDS.Shared.Exception.ExceptionLibrary.Initialise();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        [STAThread]

        //static void Main(string [] args)

        static void Main()
        {
#if(DEBUG)
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
#endif
            //if (args.Length == 0)
            //{

            Application.EnableVisualStyles();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string applicationStyle = CustomApplicationSettings.Instance.ApplicationStyle;

            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.CDSSkin).Assembly);
            DevExpress.XtraSplashScreen.SplashScreenManager.RegisterUserSkins(typeof(DevExpress.UserSkins.CDSSkin).Assembly);

            if (applicationStyle.Length == 0)
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("CDS Blue");
            else
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(applicationStyle);

            //DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Courier New", 10);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Silver");

            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font(CustomApplicationSettings.Instance.FontType, CustomApplicationSettings.Instance.FontSize);



            //Apply Windows 8 Style 
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = LookAndFeelStyle.Skin;
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Metropolis";

            // Set up the culture that determines the datetime format etc.
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-us", true);
            culture.NumberFormat.CurrencyDecimalDigits = 2;
            culture.NumberFormat.CurrencyDecimalSeparator = ".";
            culture.NumberFormat.CurrencySymbol = "";

            culture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";

            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;

            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            DevExpress.Utils.FormatInfo.AlwaysUseThreadFormat = true;

            reportStorage = new Reporting.Report.Extensions.ReportExtension();
            designExtension = new Reporting.Report.Extensions.DesignExtension();

            ReportStorageExtension.RegisterExtensionGlobal(ReportStorage);
            ReportDesignExtension.RegisterExtension(DesignExtension, "Custom");

            ReportTemplateExtension.RegisterExtensionGlobal(new Reporting.Report.Templates.CustomTemplateExtension());

            ConfigureExceptionHandling();
            CreateUpdateTrayIcon();
            Signin();
            //}
            //else if (args[0] == "-show-app-list")
            //{

            //    Application.EnableVisualStyles();
            //    DevExpress.UserSkins.BonusSkins.Register();
            //    DevExpress.Skins.SkinManager.EnableFormSkins();
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Xceed.Grid.Licenser.LicenseKey = "GRD36AUKKUZ4A75Y8CA";
            //    DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
            //    DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
            //    DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = LookAndFeelStyle.Skin;
            //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Metropolis";


            //    AppLauncher launcher = new AppLauncher();
            //    launcher.Location = new System.Drawing.Point((Cursor.Position.X - (launcher.Width / 2) < 0) ? 10 : Cursor.Position.X - (launcher.Width / 2), ((Screen.PrimaryScreen.Bounds.Height) - (new Taskbar()).Bounds.Height) - launcher.Height- 10);
            //    Application.Run(launcher);

            //    //Cursor.Position = new System.Drawing.Point(Cursor.Position.X, (Screen.PrimaryScreen.Bounds.Height) - (new Taskbar()).Bounds.Height);
            //} 
        }

        private static System.Drawing.Bitmap UpdateImageRefresh
        {
            get { return updateImages[0]; }
        }

        private static System.Drawing.Bitmap UpdateImageApply
        {
            get { return updateImages[1]; }
        }

        private static System.Drawing.Bitmap UpdateImageCancel
        {
            get { return updateImages[2]; }
        }

        private static System.Drawing.Bitmap UpdateImageNew
        {
            get { return updateImages[3]; }
        }

        /// <summary>
        /// Checks if a windows service is installed.
        /// </summary>
        /// <param name="serviceName">Service Name to check</param>
        /// <returns>Returns true if service is installed, and false if it is not installed.</returns>
        private static bool ServiceInstalled(string serviceName)
        {
            ServiceController ctl = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);
            if (ctl == null)
                return false;
            else
                return true;
        }

        private static void CreateUpdateTrayIcon()
        {
            if (!ServiceInstalled("CDS Update Service"))
                return;

            notifyicon = new NotifyIcon();
            servicecontroller = new ServiceController("CDS Update Service");
            contextmenu = new ContextMenuStrip();
            timer = new Timer();
            updateImages = new System.Collections.Generic.List<System.Drawing.Bitmap>();

            updateImages.Add(new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/actions/refresh_16x16.png")));
            updateImages.Add(new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/actions/apply_16x16.png")));
            updateImages.Add(new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/actions/cancel_16x16.png")));
            updateImages.Add(new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/support/feature_16x16.png")));

            notifyicon.Visible = true;
            notifyicon.ContextMenuStrip = contextmenu;

            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            contextmenu.Items.Add(new ToolStripMenuItem("Check for Updates", UpdateImageRefresh, new EventHandler(CheckForUpdates)) { Name = "Check" });
            contextmenu.Items.Add(new ToolStripMenuItem("Update Now", null, new EventHandler(Update)) { Name = "Update", Visible = false });
            contextmenu.Items.Add("-");
            contextmenu.Items.Add(new ToolStripMenuItem("Start Server", UpdateImageApply, new EventHandler(StartService)) { Name = "Start" });
            contextmenu.Items.Add(new ToolStripMenuItem("Stop Server", UpdateImageCancel, new EventHandler(StopService)) { Name = "Stop" });

            Application.ApplicationExit += Application_ApplicationExit;

        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            notifyicon.Dispose();
        }

        static void StartService(object sender, EventArgs e)
        {
            try
            {
                if (servicecontroller.Status == ServiceControllerStatus.Stopped)
                {
                    servicecontroller.Start();
                    servicecontroller.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
                    if (servicecontroller.Status == ServiceControllerStatus.Running)
                    {
                        notifyicon.ShowBalloonTip(1000, "CDS Update Server", "CDS Update Server Started Successfully.", ToolTipIcon.Info);
                    }
                    else
                    {
                        notifyicon.ShowBalloonTip(1000, "CDS Update Server", "CDS Update Server Failed to Start.", ToolTipIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void StopService(object sender, EventArgs e)
        {
            try
            {
                if (servicecontroller.Status == ServiceControllerStatus.Running)
                {
                    servicecontroller.Stop();
                    servicecontroller.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 10));
                    if (servicecontroller.Status == ServiceControllerStatus.Stopped)
                    {
                        notifyicon.ShowBalloonTip(1000, "CDS Update Server", "CDS Update Server Stopped Successfully.", ToolTipIcon.Info);
                    }
                    else
                    {
                        notifyicon.ShowBalloonTip(1000, "CDS Update Server", "CDS Update Server Failed to Stop.", ToolTipIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sends command to update service to check for updates
        /// </summary>
        /// <remarks>
        /// If we want the service to send feedback we will need to implement SingleInstance Application
        /// http://stackoverflow.com/questions/3793997/pass-arguments-to-running-application
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CheckForUpdates(object sender, EventArgs e)
        {
            try
            {
                servicecontroller.ExecuteCommand(128);

                //notifyicon.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.update_16.GetHicon());
                notifyicon.Icon = System.Drawing.Icon.FromHandle(UpdateImageRefresh.GetHicon());
                System.Threading.Thread.Sleep(1000 * 5);
                hasUpdate = true;
                notifyicon.Icon = System.Drawing.Icon.FromHandle(UpdateImageNew.GetHicon());
                contextmenu.Items["Stop"].Enabled = false;
                contextmenu.Items["Start"].Enabled = false;
                contextmenu.Items["Check"].Visible = false;
                contextmenu.Items["Update"].Visible = true;
            }
            catch (Exception ex)
            {
                notifyicon.ShowBalloonTip(1000, "CDS Update Server", "An error occurred trying to execute this operation." + ex.ToString(), ToolTipIcon.Info);
            }
        }

        /// <summary>
        /// Will close system and update files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Update(object sender, EventArgs e)
        {
            hasUpdate = false;
            //notifyicon.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.update_16.GetHicon());
            notifyicon.Icon = System.Drawing.Icon.FromHandle(UpdateImageRefresh.GetHicon());
            contextmenu.Items["Stop"].Enabled = true;
            contextmenu.Items["Start"].Enabled = true;
            contextmenu.Items["Check"].Visible = true;
            contextmenu.Items["Update"].Visible = false;

            notifyicon.ShowBalloonTip(1000, "CDS Update Server", "System will now update and restart.", ToolTipIcon.Info);

            System.Threading.Thread.Sleep(1000 * 5);
            //Werner: Testing only Update Service will restart application
            Application.Restart();
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                servicecontroller.Refresh();

                if (!hasUpdate)
                {
                    if (servicecontroller.Status == ServiceControllerStatus.Running)
                    {
                        //notifyicon.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.check_16.GetHicon());
                        notifyicon.Icon = System.Drawing.Icon.FromHandle(UpdateImageApply.GetHicon());
                        contextmenu.Items["Stop"].Enabled = true;
                        contextmenu.Items["Start"].Enabled = false;
                    }
                    else
                        if (servicecontroller.Status == ServiceControllerStatus.Stopped)
                    {
                        //notifyicon.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.gears_stop_16.GetHicon());
                        notifyicon.Icon = System.Drawing.Icon.FromHandle(UpdateImageCancel.GetHicon());
                        contextmenu.Items["Stop"].Enabled = false;
                        contextmenu.Items["Start"].Enabled = true;
                    }
                }

                //
                //
                //
                //
                //
                //
                //else if (servicecontroller.Status == ServiceControllerStatus.Stopped)
                //{
                //    notifyicon.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.gears_stop_16.GetHicon());
                //    contextmenu.Items["Stop"].Enabled = false;
                //    contextmenu.Items["Start"].Enabled = true;
                //}
                //else
                //{
                //    notifyicon.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.gears_pause_16.GetHicon());
                //    contextmenu.Items["Stop"].Enabled = false;
                //    contextmenu.Items["Start"].Enabled = true;
                //}
            }
            catch (Exception ex)
            {
                // Do nothing with this exception...
            }
        }

        //Recommended code for design-time skin initialization. 
        //In Visual Studio 2012 and newer versions of Visual Studio, to ensure that your custom skin assembly is loaded and that the custom skin is registered at design time, please add the following code to your project. 
        public class SkinManager : System.ComponentModel.Component
        {
            public SkinManager()
            {
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.CDSSkin).Assembly);
            }
        }
    }
}