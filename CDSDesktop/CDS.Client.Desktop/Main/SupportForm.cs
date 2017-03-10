using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace CDS.Client.Desktop.Main
{
    public partial class SupportForm : DevExpress.XtraEditors.XtraForm
    {
        //Disable click sound
        //http://stackoverflow.com/questions/393166/how-to-disable-click-sound-in-webbrowser-control
        private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        private const int SET_FEATURE_ON_THREAD = 0x00000001;
        private const int SET_FEATURE_ON_PROCESS = 0x00000002;
        private const int SET_FEATURE_IN_REGISTRY = 0x00000004;
        private const int SET_FEATURE_ON_THREAD_LOCALMACHINE = 0x00000008;
        private const int SET_FEATURE_ON_THREAD_INTRANET = 0x00000010;
        private const int SET_FEATURE_ON_THREAD_TRUSTED = 0x00000020;
        private const int SET_FEATURE_ON_THREAD_INTERNET = 0x00000040;
        private const int SET_FEATURE_ON_THREAD_RESTRICTED = 0x00000080;
         
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return:MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(
        int FeatureEntry,
        [MarshalAs(UnmanagedType.U4)] int dwFlags,
        bool fEnable);

        Essential.UTL.WaitCursor wait = new Essential.UTL.WaitCursor();
        public SupportForm()
        {
            InitializeComponent();
            int feature = FEATURE_DISABLE_NAVIGATION_SOUNDS;
            CoInternetSetFeatureEnabled(feature, SET_FEATURE_ON_PROCESS, true);
        }
        
        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            wait.ShowWaitForm();
            ((Control)Browser).Enabled = false;            
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((Control)Browser).Enabled = true;
            wait.CloseWaitForm();            
        }

    
    }
}