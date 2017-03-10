using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace CDS.Client.Desktop.Essential
{
    public partial class BaseAlert : DevExpress.XtraEditors.XtraForm
    {
        protected BaseAlert()
        {
            InitializeComponent();
        }

        protected BaseAlert(String heading, String message, Buttons button, Icons icon)
        {
            InitializeComponent();

            this.TabHeading = heading;
            this.Message = message.Replace("\n",Environment.NewLine);
            SetButton(button);
            SetIcon(icon);
            
        }

        public static DialogResult ShowAlert(String heading, String message, Buttons button, Icons icon)
        {
            

            
            try
            {
                BaseAlert alert = new BaseAlert(heading, message, button, icon);
                return alert.ShowDialog();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return DialogResult.Abort;
            }
        }

        /// <summary>
        /// Used for message from Task as it need the parent to determine the center of the parent
        /// </summary>
        /// <param name="Heading"></param>
        /// <param name="Message"></param>
        /// <param name="Button"></param>
        /// <param name="Icon"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static DialogResult ShowAlert(String heading, String message, Buttons button, Icons icon, Form owner)
        {
            try
            {
                BaseAlert alert = new BaseAlert(heading, message, button, icon);
                alert.Owner = owner;
                return alert.ShowDialog();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return DialogResult.Abort;
            }
        }

        public void SetButton(Buttons button)
        {
            try
            {
                switch (button)
                {
                    case Buttons.Ok:
                        btnOk.Visible = true;
                        btnCancel.Visible = false;
                        btnOk.Location = btnCancel.Location;
                        break;
                    case Buttons.OkCancel:
                        btnOk.Visible = true;
                        btnCancel.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void SetIcon(Icons icon)
        {
            try
            {
                switch (icon)
                {
                    case Icons.Error:
                        TabIcon = global::CDS.Shared.Resources.Properties.Resources.error_32;
                        break;
                    case Icons.Warning:
                        TabIcon = global::CDS.Shared.Resources.Properties.Resources.sign_warning_32;
                        break;
                    case Icons.Information:
                        TabIcon = global::CDS.Shared.Resources.Properties.Resources.information2_32;
                        break;
                    case Icons.Question:
                        TabIcon = global::CDS.Shared.Resources.Properties.Resources.help2_32;
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// This method is called after the form has been initialised and should be overridden in all inheriting forms to handle data binding etc.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        protected virtual void OnStart()
        {
        }

        /// <summary>
        /// Returns the icon image that must be used for the alert information. Override the TabIcon in child alerts to provide different images.
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
        /// Returns the heading text that must be used for the alert information. Override the TabHeading in child alerts to provide different text.
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

        /// <summary>
        /// Returns the message heading that must be used for the alert information. Override the MessageHeading in child alerts to provide different text.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public String MessageHeading
        {
            get
            {
                return this.pnlInformation.Text;
            }
            set
            {
                this.pnlInformation.Text = value;
            }
        }

        /// <summary>
        /// Returns the message text that must be used for the alert information. Override the Message in child alerts to provide different text.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public String Message
        {
            get
            {
                return this.lblMessage.Text;
            }
            set
            {
                this.lblMessage.Text = value;
            }
        }

        private void BaseAlert_Load(object sender, EventArgs e)
        {
            this.OnStart();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public enum Buttons
        {
            Ok,
            OkCancel
        }

        public enum Icons
        {
            Warning,
            Information,
            Error,
            Question
        }
    }
}