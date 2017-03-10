using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Installer.Prerequisites
{
    public partial class PrepareDialogue : Form
    { 
        public PrepareDialogue()
        {
            InitializeComponent();
        }

        private void PrepareDialogue_Load(object sender, EventArgs e)
        {
            BackgroundWorker.RunWorkerAsync();
        }

        private void CopyFiles()
        {
            if (!System.IO.Directory.Exists("C:\\Program Files\\Complete Distribution\\Client\\Enterprise"))
                System.IO.Directory.CreateDirectory("C:\\Program Files\\Complete Distribution\\Client\\Enterprise");

            Helper.DirectoryCopy(Application.StartupPath, "C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup", true);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFiles();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Helper.Execute("C:\\Program Files\\Complete Distribution\\Client\\Enterprise\\Setup\\CDS.Client.Installer.Prerequisites.exe", "Prerequisites", false, false);
        
            //Application.Exit();
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void PrepareDialogue_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse((new SolidBrush(Color.White)), 10, 10, this.Height-11, this.Width-11);
            e.Graphics.DrawArc((new Pen(Color.FromArgb(51, 119, 143))), 10, 10, this.Height-11, this.Width-11, 0, 360);
        }        

    }
}
