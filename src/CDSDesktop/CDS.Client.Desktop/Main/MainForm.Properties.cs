using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Main
{
    partial class MainForm
    {
        /// <summary>
        /// Place holder for the Instance of the MainForm
        /// </summary>
        private static MainForm instance = null;
        /// <summary>
        /// Place holder for the current focused form
        /// </summary>
        private Form focusedForm = null;
        /// <summary>
        /// Place holder for the previous focused form
        /// </summary>
        private Form previousFocusedForm = null;
        /// <summary>
        /// Place holder for the list of Messenger Messages
        /// </summary>
        private List<DB.SYS_MSG_Message> messageList = new List<DB.SYS_MSG_Message>();
        /// <summary>
        /// Place holder for the DataContext
        /// </summary>
        private BL.DataContext dataContext;
        /// <summary>
        /// Place holder of the Messenger Users
        /// </summary>
        public List<Essential.MSG.MessengerUsers> messengerUsers = new List<Essential.MSG.MessengerUsers>();
        /// <summary>
        /// Task Variables
        /// </summary>
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private ConcurrentBag<Task> tasks;
        private System.Threading.Tasks.Task chatlistener;
        private System.Threading.Tasks.Task statementTask;

        private bool IsSiteAccountsSetup()
        {
            if(BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId != null) { 
            if (!BL.ApplicationDataContext.Instance.SiteAccounts.SiteAccountsSetUp())
            {
                Essential.BaseAlert.ShowAlert("Site Accounts Not Set Up", "Please set up your system accounts before creating transactions.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Warning);
                return false;
            }
            else
                return true;
            }
            return true;
        }

        Dictionary<IntPtr, string> ShortcutScreens = new Dictionary<IntPtr, string>()
        {
            
            //1
            { (IntPtr)49, "CDS.Client.Desktop.Document,CDS.Client.Desktop.Document.Customer.QuoteForm" },
            //2
            { (IntPtr)50, "CDS.Client.Desktop.Document,CDS.Client.Desktop.Document.Customer.SalesOrderForm" },
            //3
            { (IntPtr)51, "CDS.Client.Desktop.Document,CDS.Client.Desktop.Document.Customer.CreditNoteForm" },
            //4
            { (IntPtr)52, "CDS.Client.Desktop.Document,CDS.Client.Desktop.Document.Supplier.PurchaseOrderForm" },
            //5
            { (IntPtr)53, "CDS.Client.Desktop.Document,CDS.Client.Desktop.Document.Supplier.GoodsReceivedForm" },
            //6
            { (IntPtr)54, "CDS.Client.Desktop.Document,CDS.Client.Desktop.Document.Supplier.GoodsReturnedForm" },
            //7
            { (IntPtr)55, "CDS.Client.Desktop.Accounting,CDS.Client.Desktop.Accounting.AccountList" },
            //8
            { (IntPtr)56, "CDS.Client.Desktop.Stock,CDS.Client.Desktop.Stock.Inventory.InventoryList" },
            //9
            { (IntPtr)57, "CDS.Client.Desktop.Accounting,CDS.Client.Desktop.Accounting.Payment.ReceivePaymentsForm" },
            //0
            { (IntPtr)48, "CDS.Client.Desktop.Accounting,CDS.Client.Desktop.Accounting.Payment.MakePaymentsForm" },
            //E
            //{ (IntPtr)69, "CDS.Client.Desktop.Essential,CDS.Client.Desktop.Essential.UTL.SendMailForm" }
            
        };

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            //Always send keys to MDIChild
            if (MdiManager.SelectedPage != null && MdiManager.SelectedPage.MdiChild is Essential.Base)
            {
                if ((MdiManager.SelectedPage.MdiChild as Essential.Base).HandleShortcut(msg.WParam))
                    return true;
            }

            //Werner : Check variable ShortcutScreens for condition combinations
            if (keyData == (Keys.Control | Keys.D1) ||
                 keyData == (Keys.Control | Keys.D2) ||
                 keyData == (Keys.Control | Keys.D3) ||
                 keyData == (Keys.Control | Keys.D4) ||
                 keyData == (Keys.Control | Keys.D5) ||
                 keyData == (Keys.Control | Keys.D6) ||
                 keyData == (Keys.Control | Keys.D7) ||
                 keyData == (Keys.Control | Keys.D8) ||
                 keyData == (Keys.Control | Keys.D9) ||
                 keyData == (Keys.Control | Keys.D0)
              )
            {
                string screenFullName;
                if (ShortcutScreens.TryGetValue(msg.WParam, out screenFullName))
                {
                    var assembly = System.Reflection.Assembly.Load(screenFullName.Split(',')[0]);
                    var type = assembly.GetType(screenFullName.Split(',')[1], true);

                    Essential.Base form = Activator.CreateInstance(type) as Essential.Base;
                    ShowForm(form);
                }
                //return true;    // indicate that you handled this keystroke
                return base.ProcessCmdKey(ref msg, keyData);

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public Image ScreenShot { get { return CaptureWindow(); } }

        public Image CaptureWindow()
        {
            try
            {
                // get the hDC of the target window
                IntPtr hdcSrc = User32.GetWindowDC(Handle);
                // get the size
                User32.RECT windowRect = new User32.RECT();
                User32.GetWindowRect(this.Handle, ref windowRect);
                int width = windowRect.right - windowRect.left;
                int height = windowRect.bottom - windowRect.top;
                // create a device context we can copy to
                IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
                // create a bitmap we can copy it to,
                // using GetDeviceCaps to get the width/height
                IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
                // select the bitmap object
                IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
                // bitblt over
                GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
                // restore selection
                GDI32.SelectObject(hdcDest, hOld);
                // clean up 
                GDI32.DeleteDC(hdcDest);
                User32.ReleaseDC(this.Handle, hdcSrc);
                // get a .NET image object for it
                Image img = Image.FromHbitmap(hBitmap);
                // free up the Bitmap object
                GDI32.DeleteObject(hBitmap);
                return img;
            }
            catch
            {
                return new Bitmap(1, 1);
            }
        }

        public Task StatementTask { get { return statementTask; } set { statementTask = value; } }

        private List<RecentDocument> RecentDocumentsCurrent = new List<RecentDocument>();

        private List<RecentDocument> RecentDocumentsPinned = new List<RecentDocument>();

        /// <summary>
        /// Checks if the DashboardSalesForm is the only form 
        /// </summary>
        /// <returns></returns>
        private bool HasOnlyDasboarOpen()
        {
            bool IsValid = true;

            //If the Dashboard is the only open form
            if (this.MdiChildren.Count() == 1 && this.MdiChildren[0] is CDS.Client.Desktop.Core.Dashboard.DashboardSalesForm)
                return true;
            else
            {
                //Go thought all the forms
                foreach (Essential.Base form in this.MdiChildren)
                {
                    //If one of the forms isn't DashboardSalesForm mark IsValid = false and break out of loop
                    if (!(form is CDS.Client.Desktop.Core.Dashboard.DashboardSalesForm))
                    {
                        IsValid = false;
                        break;
                    }
                }
            }

            return IsValid;
        }

        /// <summary>
        /// Gets the selected User in the Messenger
        /// </summary>
        private Essential.MSG.MessengerUsers SelectedUser
        {
            get { return (Essential.MSG.MessengerUsers)grvMessengerUsers.GetFocusedRow(); }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public BL.DataContext DataContext
        {
            get
            {
                if (dataContext == null)
                    dataContext = new BL.DataContext();

                return dataContext;
            }
        }

        /// <summary>
        /// The Mdi child form that currently has focus in the application.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public Form CurrentForm
        {
            get
            {
                return (MdiManager.SelectedPage == null) ? null : MdiManager.SelectedPage.MdiChild;
            }
        }

        /// <summary>
        /// Gets and Sets the focused tab on MdiManager.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 14/02/2011</remarks>
        public Form FocusedForm
        {
            get
            {
                return (focusedForm == null) ? MdiManager.SelectedPage.MdiChild : focusedForm;
            }
            set
            {
                if (focusedForm != value)
                {
                    PreviousFocusedForm = focusedForm;
                    focusedForm = value;
                }
            }
        }

        /// <summary>
        /// Gets and Sets the previous focused tab on MdiManager
        /// </summary>
        public Form PreviousFocusedForm
        {
            get
            {
                return (previousFocusedForm == null) ? MdiManager.SelectedPage.MdiChild : previousFocusedForm;
            }
            set
            {
                if (previousFocusedForm != value)
                    previousFocusedForm = value;
            }
        }

        /// <summary>
        /// MainForm is a singleton class and only one MainForm should exist at any one time.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainForm() { Opacity = 0.00 };

                return instance;
            }
        }
    }
}
