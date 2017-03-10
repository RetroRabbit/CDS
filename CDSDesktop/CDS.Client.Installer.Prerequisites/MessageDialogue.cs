using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Installer.Prerequisites
{
    public partial class MessageDialogue : Form
    {
        public MessageDialogue()
        {
            InitializeComponent();
        }

        protected MessageDialogue(String header, String message)
        {
            InitializeComponent();
            lblHeader.Text = header;
            txtMessage.Text =  message.Replace("\n", Environment.NewLine);
        }

        public static DialogResult ShowMessage(string header, string message)
        {
            try
            {
                MessageDialogue alert = new MessageDialogue(header, message);
                return alert.ShowDialog();
            }
            catch (Exception ex)
            {
                return DialogResult.Abort;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
