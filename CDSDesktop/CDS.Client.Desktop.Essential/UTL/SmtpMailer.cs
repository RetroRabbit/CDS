using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Essential.UTL
{
    public class SmtpMailer
    {
        public SmtpMailer() { }

        String smtpUsername = BusinessLayer.ApplicationDataContext.Instance.CompanySite.AccountEmailUsername;
        String smtpPassword = BusinessLayer.ApplicationDataContext.Instance.CompanySite.AccountEmailPassword;
        String smtpDomain = BusinessLayer.ApplicationDataContext.Instance.CompanySite.AccountEmailDomain;

        private List<CDSMailMessage> mailingList;
        public List<CDSMailMessage> MailingList
        {
            get { if (mailingList == null) mailingList = new List<CDSMailMessage>(); return mailingList; }
            set { mailingList = value; }
        }

        /// <summary>
        /// Adds a new mail to the Mailing list
        /// </summary>
        /// <param name="to">The Email Address the Mail will be sent to</param>
        /// <param name="from">The Email Address that will appear in the from field</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail</param> 
        public void AddMail(string to, string from, string subject, string body)
        {
            AddMail(new List<string>() { to }, new List<string>(), from, subject, body, new List<object>());
        }

        /// <summary>
        /// Adds a new mail to the Mailing list
        /// </summary>
        /// <param name="to">The Email Address the Mail will be sent to</param>
        /// <param name="from">The Email Address that will appear in the from field</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail</param>
        /// <param name="attachments">File location</param>
        public void AddMail(string to, string from, string subject, string body, string attachment )
        {
            AddMail(new List<string>() { to }, new List<string>(), from, subject, body, new List<object>() { attachment });
        }

        /// <summary>
        /// Adds a new mail to the Mailing list with multiple attachments
        /// </summary>
        /// <param name="to">The Email Address the Mail will be sent to</param>
        /// <param name="from">The Email Address that will appear in the from field</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail</param>
        /// <param name="attachments">List of file locations</param>
        public void AddMail(string to, string from, string subject, string body, List<object> attachements)
        {
            AddMail(new List<string>() { to }, new List<string>(), from, subject, body, attachements);
        }

        /// <summary>
        /// Adds a new mail to the Mailing list with bcc
        /// </summary>
        /// <param name="to">The Email Address the Mail will be sent to</param>
        /// <param name="from">The Email Address that will appear in the from field</param>
        /// <param name="bcc">The Email Address that the bcc will be sent to</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail</param>
        /// <param name="attachments">List of file locations</param>
        public void AddMail(string to, string bcc, string from, string subject, string body, object attachment)
        {
            AddMail(new List<string>() { to }, new List<string>() { bcc }, from, subject, body, new List<object>() { attachment });
        }

        /// <summary>
        /// Adds a new mail to the Mailing list with multiple attachments and multiple bccs
        /// </summary>
        /// <param name="to">The Email Address the Mail will be sent to</param>
        /// <param name="from">The Email Address that will appear in the from field</param>
        /// <param name="bcc">The Email Addresses that the bccs will be sent to</param>
        /// <param name="subject">The subject of the mail</param>
        /// <param name="body">The body of the mail</param>
        /// <param name="attachments">List of file locations</param>
        public void AddMail(List<string> to, List<string> bcc, string from, string subject, string body, List<object> attachments)
        {
            CDSMailMessage cdsmail = new CDSMailMessage(new MailMessage());
            cdsmail.Mail.From = new MailAddress(from);
            cdsmail.Mail.Subject = subject;
            cdsmail.Mail.IsBodyHtml = true;
            cdsmail.Mail.Body = body;

            to.Where(n => n != null).ToList().ForEach(n => cdsmail.Mail.To.Add(new MailAddress(n)));
            attachments.Where(n => n != null && n.GetType() == typeof(string)).ToList().ForEach(n => cdsmail.Mail.Attachments.Add(new Attachment(n.ToString())));
            attachments.Where(n => n != null && n.GetType() == typeof(System.IO.MemoryStream)).ToList().ForEach(n => { (n as System.IO.MemoryStream).Position = 0; cdsmail.Mail.Attachments.Add(new Attachment((n as System.IO.MemoryStream), "Document.pdf", "application/pdf")); });
            bcc.Where(n => n != null).ToList().ForEach(n => cdsmail.Mail.Bcc.Add(n));
            MailingList.Add(cdsmail);
        }

        /// <summary>
        /// Send all the Mails in the Mailing List
        /// </summary>
        public void SendMailingList()
        {

            Parallel.ForEach(MailingList, n => SendMail(n));
        }

        /// <summary>
        /// Sends a single CDS Mail Message Object 
        /// Only for use in SendMailingList method
        /// </summary>
        /// <param name="cdsmail"></param>
        void SendMail(CDSMailMessage cdsmail)
        {

            //send the message
            SmtpClient smtp = new SmtpClient(BusinessLayer.ApplicationDataContext.Instance.CompanySite.SMTPServerLocation); //specify the mail server address

            if (smtpUsername != String.Empty && smtpPassword != String.Empty && smtpDomain != String.Empty)
            {
                System.Net.NetworkCredential smtpCredentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword, smtpDomain);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = smtpCredentials;
                smtp.EnableSsl = true;
                smtp.Port = 587; 
            }
            else if (smtpUsername != String.Empty && smtpPassword != String.Empty)
            {
                System.Net.NetworkCredential smtpCredentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = smtpCredentials;
                smtp.EnableSsl = true;
                smtp.Port = 587; 
            }

            smtp.SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);
            smtp.SendAsync(cdsmail.Mail, cdsmail);
        }

        /// <summary>
        /// Event for when the SMTP Mail's status changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Get the Original MailMessage object
            CDSMailMessage cdsmail = e.UserState as CDSMailMessage;

            //write out the subject
            if (e.Cancelled)
            {
                cdsmail.Status = MailStatus.Cancelled;
            }
            else if (e.Error != null)
            {
                cdsmail.Status = MailStatus.Error;
                cdsmail.ErrorMessage = e.Error.ToString() + Environment.NewLine + e.Error.Message.ToString();
            }
            else
            {
                cdsmail.Status = MailStatus.Sent;
            }
        }

        /// <summary>
        /// CDS Mail Message Class
        /// </summary>
        public class CDSMailMessage {
            public CDSMailMessage(MailMessage mail)
            {
                Mail = mail;
                Status = MailStatus.Unsent;
            }
            public MailMessage Mail { get; set; }
            public MailStatus Status { get; set; }
            public string ErrorMessage { get; set; }
        }

        /// <summary>
        /// CDS Mail Message statuses
        /// </summary>
        public enum MailStatus { 
            Unsent,
            Pending,
            Cancelled,
            Error,
            Sent
        } 
    }
}
