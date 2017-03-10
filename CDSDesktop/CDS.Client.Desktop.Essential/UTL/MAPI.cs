using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB = CDS.Client.DataAccessLayer.DB;
using BL = CDS.Client.BusinessLayer;

namespace CDS.Client.Desktop.Essential.UTL
{
    class MAPI
    {
        public bool AddRecipientTo(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        public bool AddRecipientCC(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        public bool AddRecipientBCC(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        public void AddAttachment(string strAttachmentFileName)
        {
            m_attachments.Add(strAttachmentFileName);
        }

        public int SendMailPopup(string strSubject, string strBody)
        {
            return SendMail(strSubject, strBody, MAPI_LOGON_UI | MAPI_DIALOG);
        }

        public int SendMailDirect(string strSubject, string strBody)
        {
            return SendMail(strSubject, strBody, MAPI_LOGON_UI);
        }


        [DllImport("MAPI32.DLL")]
        static extern int MAPISendMail(IntPtr sess, IntPtr hwnd,
                MapiMessage message, int flg, int rsv);

        int SendMail(string strSubject, string strBody, int how)
        {
            MapiMessage msg = new MapiMessage();
            msg.subject = strSubject;
            msg.noteText = strBody;

            msg.recips = GetRecipients(out msg.recipCount);
            msg.files = GetAttachments(out msg.fileCount);

            m_lastError = MAPISendMail(new IntPtr(0), new IntPtr(0), msg, how,
                    0);
            if (m_lastError > 1)
                BaseAlert.ShowAlert("Mail send failure", GetLastError(), BaseAlert.Buttons.Ok, BaseAlert.Icons.Error);

            Cleanup(ref msg);
            return m_lastError;
        }

        bool AddRecipient(string email, HowTo howTo)
        {
            MapiRecipDesc recipient = new MapiRecipDesc();

            recipient.recipClass = (int)howTo;
            recipient.name = email;
            m_recipients.Add(recipient);

            return true;
        }

        IntPtr GetRecipients(out int recipCount)
        {
            recipCount = 0;
            if (m_recipients.Count == 0)
                return IntPtr.Zero;

            int size = Marshal.SizeOf(typeof(MapiRecipDesc));
            IntPtr intPtr = Marshal.AllocHGlobal(m_recipients.Count * size);

            int ptr = (int)intPtr;
            foreach (MapiRecipDesc mapiDesc in m_recipients)
            {
                Marshal.StructureToPtr(mapiDesc, (IntPtr)ptr, false);
                ptr += size;
            }

            recipCount = m_recipients.Count;
            return intPtr;
        }

        IntPtr GetAttachments(out int fileCount)
        {
            fileCount = 0;
            if (m_attachments == null)
                return IntPtr.Zero;

            if ((m_attachments.Count <= 0) || (m_attachments.Count >
                    maxAttachments))
                return IntPtr.Zero;

            int size = Marshal.SizeOf(typeof(MapiFileDesc));
            IntPtr intPtr = Marshal.AllocHGlobal(m_attachments.Count * size);

            MapiFileDesc mapiFileDesc = new MapiFileDesc();
            mapiFileDesc.position = -1;
            int ptr = (int)intPtr;

            foreach (string strAttachment in m_attachments)
            {
                mapiFileDesc.name = Path.GetFileName(strAttachment);
                mapiFileDesc.path = strAttachment;
                Marshal.StructureToPtr(mapiFileDesc, (IntPtr)ptr, false);
                ptr += size;
            }

            fileCount = m_attachments.Count;
            return intPtr;
        }

        void Cleanup(ref MapiMessage msg)
        {
            int size = Marshal.SizeOf(typeof(MapiRecipDesc));
            int ptr = 0;

            if (msg.recips != IntPtr.Zero)
            {
                ptr = (int)msg.recips;
                for (int i = 0; i < msg.recipCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr)ptr,
                            typeof(MapiRecipDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.recips);
            }

            if (msg.files != IntPtr.Zero)
            {
                size = Marshal.SizeOf(typeof(MapiFileDesc));

                ptr = (int)msg.files;
                for (int i = 0; i < msg.fileCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr)ptr,
                            typeof(MapiFileDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.files);
            }

            m_recipients.Clear();
            m_attachments.Clear();
            m_lastError = 0;
        }

        public string GetLastError()
        {
            if (m_lastError <= 26)
                return errors[m_lastError];
            return "MAPI error [" + m_lastError.ToString() + "]";
        }

        readonly string[] errors = new string[] {
        "OK [0]", "User abort [1]", "General MAPI failure [2]", 
                "MAPI login failure [3]", "Disk full [4]", 
                "Insufficient memory [5]", "Access denied [6]", 
                "-unknown- [7]", "Too many sessions [8]", 
                "Too many files were specified [9]", 
                "Too many recipients were specified [10]", 
                "A specified attachment was not found [11]",
        "Attachment open failure [12]", 
                "Attachment write failure [13]", "Unknown recipient [14]", 
                "Bad recipient type [15]", "No messages [16]", 
                "Invalid message [17]", "Text too large [18]", 
                "Invalid session [19]", "Type not supported [20]", 
                "A recipient was specified ambiguously [21]", 
                "Message in use [22]", "Network failure [23]",
        "Invalid edit fields [24]", "Invalid recipients [25]", 
                "Not supported [26]" 
        };


        List<MapiRecipDesc> m_recipients = new
                List<MapiRecipDesc>();
        List<string> m_attachments = new List<string>();
        int m_lastError = 0;

        const int MAPI_LOGON_UI = 0x00000001;
        const int MAPI_DIALOG = 0x00000008;
        const int maxAttachments = 20;

        enum HowTo { MAPI_ORIG = 0, MAPI_TO, MAPI_CC, MAPI_BCC };


        //TODO FIX THIS
        //public static void SendDocumentToCompany(DB.SYS_DOC_Header document)
        //{
        //    bool isPurchaseDocument = false;
        //    string name = "Document";
        //    switch (document.DOC_Type.Id)
        //    {
        //        case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
        //            name = "TAX Invoice";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
        //            name = "Purchase Order";
        //            isPurchaseDocument = true;
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
        //            name = "Purchase Credit Note";
        //            isPurchaseDocument = true;
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.Quote:
        //            name = "Sales Quote";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
        //            name = "Sales Order";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
        //            name = "Back Order";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
        //            name = "Purchase Invoice";
        //            isPurchaseDocument = true;
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
        //            name = "Sales Credit Note";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
        //            name = "Internal Transfer";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
        //            name = "Transfer Shipped";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.TransferRecieved:
        //            name = "Transfer Received";
        //            break;
        //        case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
        //            name = "Inventory Adjustment";
        //            isPurchaseDocument = true;
        //            break;
        //    }

        //    string filename = "";
        //    // Export the document
        //    switch (isPurchaseDocument ? BL.ApplicationDataContext.Instance.CompanySite.PurchaseEmailFormat : BL.ApplicationDataContext.Instance.CompanySite.SalesEmailFormat)
        //    {
        //        case "PDF":
        //            filename = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), (name.ToUpper().Replace(" ", "") + "_" + document.DocumentNumber)), ".pdf");
        //            break;
        //        case "EXCEL":
        //            filename = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), (name.ToUpper().Replace(" ", "") + "_" + document.DocumentNumber)), ".xls");
        //            break;
        //        case "JPEG":
        //            filename = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), (name.ToUpper().Replace(" ", "") + "_" + document.DocumentNumber)), ".jpg");
        //            break;
        //        default:
        //            filename = Path.ChangeExtension(Path.Combine(Path.GetTempPath(), (name.ToUpper().Replace(" ", "") + "_" + document.DocumentNumber)), ".pdf");
        //            break;
        //    }

        //    //TODO: ADD NEW Reporting
        //    /*
        //    CompleteDataLayer.SystemReport rep = null;
        //    if (isPurchaseDocument)
        //    {
        //        rep = (CompleteDataLayer.SystemReport)CompleteDataLayer.SystemReportProvider.Instance.Load(new Guid("B256F83F-622F-4fa7-9BAB-E68B8889D50C"));
        //    }
        //    else
        //    {
        //        rep = (CompleteDataLayer.SystemReport)CompleteDataLayer.SystemReportProvider.Instance.Load(new Guid("8DB36CFF-DAD0-4C20-B761-BBE266C56025"));
        //    }

        //    CompleteDistribution.Controls.FastReports.FastReportForm fastviewer = new CompleteDistribution.Controls.FastReports.FastReportForm();
        //    fastviewer.AddVariable("Parameter", "DocumentGuid", Convert.ToString(document.DataLayerGuid));
        //    fastviewer.LoadReport(rep, true);

        //    //fastviewer.Show(MasterForm.Instance);
        //    //return;
        //    switch (isPurchaseDocument ? CompleteDataLayer.ApplicationContext.Instance.CompanySite.PurchaseEmailFormat : CompleteDataLayer.ApplicationContext.Instance.CompanySite.SalesEmailFormat)
        //    {
        //        case "PDF":
        //            fastviewer.ExportPDF(filename);
        //            break;
        //        case "EXCEL":
        //            fastviewer.ExportEXCEL(filename);
        //            break;
        //        case "JPEG":
        //            fastviewer.ExportJPEG(filename);
        //            break;
        //        default:
        //            fastviewer.ExportPDF(filename);
        //            break;
        //    }

        //    // Send the email
        //    string subject = String.Format("{0} #{1} from {2} on {3}", name, document.NameNumericPart.ToString().PadLeft(7, '0'), CompleteDataLayer.ApplicationContext.Instance.CompanySite.TradingName, document.FinancialDate.ToString("dd/MM/yyyy"));
        //    string body = String.Format("Please find attached the " + name + " for your attention. " + Environment.NewLine + Environment.NewLine + "Regards," + Environment.NewLine + CompleteDataLayer.ApplicationContext.Instance.LoggedInUser.FullName + Environment.NewLine + CompleteDataLayer.ApplicationContext.Instance.CompanySite.TradingName);

        //    MAPI mapi = new MAPI();
        //    mapi.AddAttachment(filename);
        //    if (!String.IsNullOrEmpty(document.Company.AccountsEmailAddress)) mapi.AddRecipientTo(document.Company.AccountsEmailAddress);
        //    mapi.SendMailPopup(subject, body);

        //    //Werner Scheffer
        //    //The fastviewer form is open but not visible so the connection stys open as the form is still "open"
        //    fastviewer.Close();
        //    */
        //}

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiMessage
    {
        public int reserved;
        public string subject;
        public string noteText;
        public string messageType;
        public string dateReceived;
        public string conversationID;
        public int flags;
        public IntPtr originator;
        public int recipCount;
        public IntPtr recips;
        public int fileCount;
        public IntPtr files;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiFileDesc
    {
        public int reserved;
        public int flags;
        public int position;
        public string path;
        public string name;
        public IntPtr type;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiRecipDesc
    {
        public int reserved;
        public int recipClass;
        public string name;
        public string address;
        public int eIDSize;
        public IntPtr entryID;
    }
}
