using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors; 
using System.Threading.Tasks;

namespace CDS.Shared.Exception
{
    public partial class ExceptionDialogue : DevExpress.XtraEditors.XtraForm
    {
        bool canClose = false;
        System.Exception exception;

        public ExceptionDialogue(System.Exception ex)
        {
            InitializeComponent();
            exception = (System.Exception)Newtonsoft.Json.JsonConvert.DeserializeObject(Newtonsoft.Json.JsonConvert.SerializeObject(ex), typeof(System.Exception));
        }
         
        /// <summary>
        /// This method is called after the form has been initialized and should be overridden in all inheriting forms to handle data binding etc.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        protected virtual void OnStart()
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            //MethodInfo methodInf = typExternal.GetMethod("CaptureWindow");
            //peImage.Image = (Image)methodInf.Invoke(mainform, new object[] { });
            PropertyInfo propertyInf = typExternal.GetProperty("ScreenShot");
            peImage.Image = (Image)propertyInf.GetAccessors()[0].Invoke(mainform, new object[] { });
            this.Owner = (Form)mainform;
            txtException.Text = @"(Exception:{exception.Message}\nInnerException:{exception.InnerException}\nStackTrace:{exception.StackTrace}\n)";
            txtCallStock.Text = exception.StackTrace;
        }

        /// <summary>
        /// Returns the icon image that must be used for the dialogue information. Override the TabIcon in child dialogues to provide different images.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public Image TabIcon
        {
            get
            {
                return this.imgIcon.Image;
            }
            set
            {
                this.imgIcon.Image = value;
            }
        }

        /// <summary>
        /// Returns the heading text that must be used for the dialogue information. Override the TabHeading in child dialogues to provide different text.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public String TabHeading
        {
            get
            {
                return this.lblHeading.Text;
            }
            set
            {
                this.lblHeading.Text = value;
            }
        }

        private void BaseDialogue_Load(object sender, EventArgs e)
        {
            this.OnStart();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            canClose = true;
            Close();
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            canClose = true;
            Close();
            Application.Restart();
        }

        private void ExceptionDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !canClose;
        }

      
    }
}