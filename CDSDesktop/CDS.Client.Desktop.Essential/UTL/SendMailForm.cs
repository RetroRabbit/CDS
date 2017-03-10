using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Essential.UTL
{
    public partial class SendMailForm : CDS.Client.Desktop.Essential.BaseForm
    {
        Regex mailRegex =
            new System.Text.RegularExpressions.Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|co.za|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b");

        List<System.IO.MemoryStream> memoryStreamMapping = new List<System.IO.MemoryStream>();

        IEnumerable<string> ToList
        {
            get
            {
                {
                    foreach (var item in teTo.SelectedItems.AsEnumerable().ToList())
                    {
                        if (item.Value is CDS.Client.Desktop.Essential.UTL.SendMailForm.PopupDetails)
                            yield return (item.Value as CDS.Client.Desktop.Essential.UTL.SendMailForm.PopupDetails).Email;
                        else
                            yield return item.Value.ToString();
                    }
                }
            }
        }

        IEnumerable<string> BccList
        {
            get
            {
                {
                    foreach (var item in teBcc.SelectedItems.AsEnumerable().ToList())
                    {
                        yield return item.Value.ToString();
                    }
                }
            }
        }

        IEnumerable<object> AttachmentList
        {
            get
            {
                {
                    foreach (var item in teAttachment.SelectedItems.AsEnumerable().ToList())
                    {
                        int position;
                        //Get ms attachments first
                        if (int.TryParse(item.Value.ToString(), out position))
                        {
                            yield return memoryStreamMapping[Convert.ToInt32(item.Value)];
                        }
                        //Get file attachments
                        else if (item.Value as string != null)
                        {
                            yield return item.Value;
                        }
                    }
                }
            }
        }

        List<string> To { get { return ToList.ToList(); } }

        List<string> Bcc { get { return BccList.ToList(); } }

        List<object> Attachments { get { return AttachmentList.ToList(); } }

        private List<System.IO.MemoryStream> memoryStreamAttachments = new List<System.IO.MemoryStream>();

        public List<System.IO.MemoryStream> MemoryStreamAttachments
        {
            get { return memoryStreamAttachments; }
            set { memoryStreamAttachments = value; }
        }

        public SendMailForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void BindData()
        {
            base.BindData();
            System.Threading.Tasks.Parallel.ForEach(
            DataContext.ReadonlyContext.VW_Contact.Where(n => n.Email != null).Select(n => new { n.Fullname, n.Email, n.Telephone1, n.Telephone2 }),
               n => teTo.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(n.Fullname,
                   new PopupDetails()
                   {
                       Fullname = n.Fullname,
                       Email = n.Email,
                       Telephone1 = n.Telephone1,
                       Telephone2 = n.Telephone2
                   })));

            teBcc.Properties.Tokens.AddRange(teTo.Properties.Tokens.ToArray());
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = false;
        }

        public void AttachFile(System.IO.MemoryStream ms, string filename)
        {
            int counter = memoryStreamMapping.Count();
            memoryStreamMapping.Add(ms);

            teAttachment.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(filename, counter.ToString()));

            if (teAttachment.EditValue != null)
            {
                teAttachment.EditValue = teAttachment.EditValue.ToString() + ',' + counter.ToString();
            }
            else
            {
                teAttachment.EditValue = counter.ToString();
            }

        }

        private void ValidateToken(ref DevExpress.XtraEditors.TokenEditValidateTokenEventArgs e)
        {
            if (mailRegex.IsMatch(e.Description))
            {
                e.IsValid = true;
                e.Value = e.Description;

                teTo.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(e.Description,
                   new PopupDetails()
                   {
                       Fullname = "",
                       Email = e.Description,
                       Telephone1 = "",
                       Telephone2 = ""
                   }));
                SendKeys.Send("{TAB}");
            }
        }

        private void teTo_ValidateToken(object sender, DevExpress.XtraEditors.TokenEditValidateTokenEventArgs e)
        {
            ValidateToken(ref e);
        }

        private void teBcc_ValidateToken(object sender, DevExpress.XtraEditors.TokenEditValidateTokenEventArgs e)
        {
            ValidateToken(ref e);
        }
        private void teTo_BeforeShowPopupPanel(object sender, DevExpress.XtraEditors.TokenEditBeforeShowPopupPanelEventArgs e)
        {
            if (e.Value == null || e.Value.GetType() == typeof(string))
                return;

            lblName.Text = e.Description;
            lblEmail.Text = (e.Value as PopupDetails).Email;
            lblTelephone1.Text = (e.Value as PopupDetails).Telephone1;
            lblTelephone2.Text = (e.Value as PopupDetails).Telephone2;
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            if (ofdAttachment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                teAttachment.Properties.Tokens.Add(new DevExpress.XtraEditors.TokenEditToken(ofdAttachment.SafeFileName, ofdAttachment.FileName));

                teAttachment.EditValue = teAttachment.EditValue.ToString() + ',' + ofdAttachment.FileName;
            }
        }

        private void btnSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions options = new DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions();
            //options.ExportRootTag = DevExpress.XtraRichEdit.Export.Html.ExportRootTag.Body;
            options.CssPropertiesExportType = DevExpress.XtraRichEdit.Export.Html.CssPropertiesExportType.Inline;
            DevExpress.XtraRichEdit.Export.Html.HtmlExporter exporter = new DevExpress.XtraRichEdit.Export.Html.HtmlExporter(recBody.Model, options);
            string stringHtml = exporter.Export();

            SmtpMailer mailer = new SmtpMailer();
            mailer.AddMail(To, Bcc, BusinessLayer.ApplicationDataContext.Instance.CompanySite.AccountEmailUsername, txtSubject.Text, stringHtml, Attachments);
            mailer.SendMailingList();
        }

        private void teAttachment_Properties_TokenDoubleClick(object sender, DevExpress.XtraEditors.TokenEditTokenClickEventArgs e)
        {
            int position;
            //Get ms attachments first
            if (int.TryParse(e.Value.ToString(), out position))
            {
                var ms = memoryStreamMapping[Convert.ToInt32(e.Value)];

                ms.Position = 0;

                using (System.IO.FileStream file = System.IO.File.OpenWrite(System.IO.Path.GetTempPath() + e.Description))
                {
                    ms.WriteTo(file);
                    file.Flush();
                    file.Close();
                }
                System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() + e.Description);
            }
            //Get file attachments
            else if (e.Value as string != null)
            {
                System.Diagnostics.Process.Start(e.Value.ToString());
            }
        }

        class PopupDetails
        {
            public String Fullname { get; set; }
            public String Email { get; set; }
            public String Telephone1 { get; set; }
            public String Telephone2 { get; set; }
        }

       
    }
}
