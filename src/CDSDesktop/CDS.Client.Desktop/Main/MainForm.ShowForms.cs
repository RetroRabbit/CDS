using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Main
{
    partial class MainForm
    {

        /// <summary>
        /// Adds the form tot the list of this.MdiChildren
        /// </summary>
        /// <param name="form"></param>
        public void ShowForm(DevExpress.XtraEditors.XtraForm form)
        {
            try
            {
                using (new Essential.UTL.WaitCursor())
                {
                    //Check if there is already a form of the same type open and select it
                    //instead of opening a new one
                    if (form is Essential.BaseList && !(form as Essential.BaseList).ForceNew)
                    {
                        if (form is Document.BaseDocumentList)
                        {
                            if (!
                             Parallel.ForEach(this.MdiChildren.Where(n => (n as Document.BaseDocumentList) != null), (child, pls) =>
                             {
                                 if ((child as Document.BaseDocumentList).DocumentType == (form as Document.BaseDocumentList).DocumentType)
                                 {
                                     //If the List is already open select it if not the form with open
                                     this.BeginInvoke(new Action(() => child.Select()));
                                     //child.Select();
                                     //return;
                                     pls.Break();

                                 }
                             }).IsCompleted)
                                return;
                            //foreach (var child in this.MdiChildren.Where(n => (n as Document.BaseDocumentList) != null))
                            //{
                            //    if ((child as Document.BaseDocumentList).DocumentType == (form as Document.BaseDocumentList).DocumentType)
                            //    {
                            //        //If the List is already open select it if not the form with open
                            //        child.Select();
                            //        return;
                            //    }
                            //}
                        }
                        else if (form is Company.CompanyList)
                        {
                            if (!
                            Parallel.ForEach(this.MdiChildren.Where(n => (n as Company.CompanyList) != null), (child, pls) =>
                            {
                                if ((child as Company.CompanyList).Type == (form as Company.CompanyList).Type)
                                {
                                    //If the List is already open select it if not the form with open
                                    this.BeginInvoke(new Action(() => child.Select()));
                                    pls.Break();
                                }
                            }).IsCompleted)
                                return;
                            //foreach (var child in this.MdiChildren.Where(n => (n as Company.CompanyList) != null))
                            //{
                            //    if ((child as Company.CompanyList).Type == (form as Company.CompanyList).Type)
                            //    {
                            //        //If the List is already open select it if not the form with open
                            //        child.Select();
                            //        return;
                            //    }
                            //}
                        }
                        else
                        {
                            if (!
                            Parallel.ForEach(this.MdiChildren, (child, pls) =>
                            {
                                if (child.Text == form.Text)
                                {
                                    //If the List is already open select it if not the form with open
                                    this.BeginInvoke(new Action(() => child.Select()));
                                    pls.Break();
                                }
                            }).IsCompleted)
                                return;
                            //foreach (var child in this.MdiChildren)
                            //{
                            //    if (child.Text == form.Text)
                            //    {
                            //        //If the List is already open select it if not the form with open
                            //        child.Select();
                            //        return;
                            //    }
                            //}
                        }

                    }

                    form.FormClosing += form_FormClosing;
                    form.FormClosed += form_FormClosed;

                    form.MdiParent = MainForm.Instance;
                    form.Show();
                    form.Focus();
                    //if (this.MdiChildren.Count() != 1)
                    //    bbiSite.Enabled = false;

                    //if (form is CDS.Client.Desktop.Document.BaseDocument)
                    //{
                    //    if ((form as CDS.Client.Desktop.Document.BaseDocument).TabColor != null)
                    //    {
                    //        MdiManager.Pages[MdiManager.Pages.Count - 1].Appearance.HeaderActive.BackColor = (form as CDS.Client.Desktop.Document.BaseDocument).TabColor;
                    //        MdiManager.Pages[MdiManager.Pages.Count - 1].Appearance.HeaderDisabled.BackColor = (form as CDS.Client.Desktop.Document.BaseDocument).TabColor;
                    //    }
                    //} 
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }


        /// <summary>
        /// Calling this method automatically opened the indicated form as a Mdi child form in the main form tabs.
        /// Exposes a way to open the Inventory Form from a Project outside of CDS.Client.Desktop.Stock
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="readOnly"></param>
        public void ShowInventoryForm(Int64 itemId, bool readOnly)
        {
            Stock.Inventory.InventoryForm childForm = new Stock.Inventory.InventoryForm(DataContext.EntityInventoryContext.ITM_Inventory.Where(n => n.EntityId == itemId).Select(n => n.Id).FirstOrDefault());
            childForm.ReadOnly = readOnly;
            ShowForm(childForm);
        }

        /// <summary>
        /// Calling this method automatically opened the indicated form as a Mdi child form in the main form tabs.
        /// Exposes a way to open the Inventory Form and select the Transaction Tab from a Project outside of CDS.Client.Desktop.Stock
        /// </summary>
        /// <param name="itemId"></param>
        public void ShowInventoryTransactionForm(Int64 itemId)
        {
            Stock.Inventory.InventoryForm childForm = new Stock.Inventory.InventoryForm(itemId);
            childForm.ReadOnly = true;
            childForm.ShowTransaction = true;
            ShowForm(childForm);
        }

        public void ShowBuyoutForm(Int64 itemId)
        {
            Stock.Buyout.BuyoutForm childForm = new Stock.Buyout.BuyoutForm(itemId);

            ShowForm(childForm);
        }

        /// <summary>
        /// Calling this method automatically opened the indicated form as a Mdi child form in the main form tabs.
        /// Exposes a way to open the Company Form from a Project outside of CDS.Client.Desktop.Company
        /// </summary>
        /// <param name="Companyid"></param>
        /// <param name="readOnly"></param>
        public void ShowCompanyForm(Int64 CompanyId, bool readOnly)
        {
            Int16 typeId = DataContext.ReadonlyContext.VW_Company.Where(n => n.Id == CompanyId).Select(l => l.TypeId).FirstOrDefault();

            Company.BaseCompanyForm childForm = null;
            switch (typeId)
            {
                case (byte)BL.ORG.ORG_Type.Customer:
                    childForm = new Company.Customer.CustomerForm(CompanyId);
                    break;
                case (byte)BL.ORG.ORG_Type.Supplier:
                    childForm = new Company.Supplier.SupplierForm(CompanyId);
                    break;
            }
            childForm.ReadOnly = readOnly;
            ShowForm(childForm);
        }

        /// <summary>
        /// Call this method to Open an existing document.
        /// </summary>
        /// <param name="id">Primary key of the document you want to open.</param>
        /// <param name="typeId">Document type that you are opening.</param>
        /// <remarks>Created: Henko Rabie 29/01/2015</remarks>
        public void ShowDocumentForm(Int64 id, Int64 typeId)
        {
            CDS.Client.Desktop.Essential.BaseForm childForm = null;
            //TODO: Fill in the rest for the other document forms
            switch (typeId)
            {
                case (byte)BL.SYS.SYS_DOC_Type.Quote:
                    childForm = new Document.Customer.QuoteForm(id);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                    childForm = new Document.Customer.SalesOrderForm(id);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                    childForm = new Document.Customer.TAXInvoiceForm(id);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                    childForm = new Document.Customer.CreditNoteForm(id);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:

                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    childForm = new Document.Supplier.PurchaseOrderForm(id);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                    childForm = new Document.Supplier.GoodsReceivedForm(id);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                    childForm = new Document.Supplier.GoodsReturnedForm(id);
                    break;
                //Werner: is this supposed to be here?
                case (byte)BL.SYS.SYS_DOC_Type.Job:
                    childForm = new Workshop.Job.JobForm(id);
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:

                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:

                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:

                    break;
                case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                    childForm = new Document.Customer.BackOrderForm(id);
                    break;
            }

            if (childForm != null)
            {
                ShowForm(childForm);
            }
        }

        /// <summary>
        /// Call this method to open a New Generated document.
        /// </summary>
        /// <param name="header">Newly generated SYS_DOC_Header of document you are opening.</param>
        /// <remarks>Created: Henko Rabie 29/01/2015</remarks>
        public void ShowDocumentForm(DB.SYS_DOC_Header header)
        {
            CDS.Client.Desktop.Document.BaseDocument childForm = null;
            //TODO: Fill in the rest for the other document forms
            switch (header.TypeId)
            {
                case (byte)BL.SYS.SYS_DOC_Type.Quote:
                    childForm = new Document.Customer.QuoteForm();
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.SalesOrder:
                    childForm = new Document.Customer.SalesOrderForm();
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TAXInvoice:
                    childForm = new Document.Customer.TAXInvoiceForm();
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.CreditNote:
                    childForm = new Document.Customer.CreditNoteForm();
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    childForm = new Document.Supplier.PurchaseOrderForm();
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReceived:
                    childForm = new Document.Supplier.GoodsReceivedForm();
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.GoodsReturned:
                    childForm = new Document.Supplier.GoodsReturnedForm();
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case (byte)BL.SYS.SYS_DOC_Type.BackOrder:
                    childForm = new Document.Customer.BackOrderForm();
                    break;
            }

            if (childForm != null)
            {
                childForm.Doc_Header = header;
                childForm.ItemState = Essential.BaseForm.EntityState.Generated;
                ShowForm(childForm);
            }
        }

        /// <summary>
        /// Calling this method automatically opened the indicated form as a Mdi child form in the main form tabs.
        /// Exposes a way to open the Document List Form from a Project outside of CDS.Client.Desktop.Document
        /// </summary>
        /// <param name="form">The form control to be displayed in the tabs.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public void ShowDocumentListForm(BL.SYS.SYS_DOC_Type? type, Int64 trackId)
        {
            CDS.Client.Desktop.Document.BaseDocumentList childForm = new Document.BaseDocumentList(type, trackId);
            ShowForm(childForm);
        }

        /// <summary>
        /// Calling this method automatically opened the indicated form as a Mdi child form in the main form tabs.
        /// Exposes a way to open the Job List Form from a Project outside of CDS.Client.Desktop.Workshop
        /// </summary>
        /// <param name="form">The form control to be displayed in the tabs.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public void ShowJobListForm(Int64 trackId)
        {
            CDS.Client.Desktop.Workshop.Job.JobList childForm = new Workshop.Job.JobList(trackId);
            ShowForm(childForm);
        }

        /// <summary>
        /// Calling this method automatically opens the indicated form as a Mdi child form in the main form tabs.
        /// Exposes a way to open the Jobs Form from a Project outside of CDS.Client.Desktop.Workshop
        /// </summary>
        /// <param name="form">The form control to be displayed in the tabs.</param>
        /// <remarks>Created: Werner Scheffer 27/10/2014</remarks>
        public void ShowJobFormFromHeader(DB.SYS_DOC_Header header, bool allowChanges)
        {
            CDS.Client.Desktop.Workshop.Job.JobForm childForm = new Workshop.Job.JobForm();
            childForm.Doc_Header = header;
            childForm.Job_header = header.JOB_Header;
            childForm.ItemState = CDS.Client.Desktop.Essential.BaseForm.EntityState.Generated;
            ShowForm(childForm);

        }

        /// <summary>
        /// Calling this method automatically opened the indicated form as a Mdi child form in the main form tabs.
        /// Exposes a way to open the Catalogue Form from a Project outside of CDS.Client.Desktop.Catalogue
        /// </summary>
        /// <param name="form">The form control to be displayed in the tabs.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public void ShowCatalogueForm(DB.VW_Company entity, CDS.Client.BusinessLayer.ORG.ORG_Type type, CDS.Client.Desktop.Essential.BaseForm form)
        {
            CDS.Client.Desktop.Catalogue.CAT.CatalogueForm childForm = new Catalogue.CAT.CatalogueForm();
            childForm.Entity = entity;
            childForm.Type = type;
            childForm.Tag = form;
            ShowForm(childForm);
        }

        public void ShowReport(Int64 reportId, DevExpress.XtraReports.Parameters.ParameterCollection parameters)
        {
            Reporting.Report.ReportForm childForm = new Reporting.Report.ReportForm();
            childForm.Parameters = parameters;
            childForm.OpenRecord(reportId);
            ShowForm(childForm);
        }

        public void ShowReport(string reportName, DevExpress.XtraReports.Parameters.ParameterCollection parameters)
        {
            var reportId = BL.RPT.RPT_Report.LoadByName(reportName, DataContext).Id;
            if (reportId == null)
                return;

            Reporting.Report.ReportForm childForm = new Reporting.Report.ReportForm();
            childForm.Parameters = parameters;
            childForm.OpenRecord(reportId);
            ShowForm(childForm);
        }

        public void HideForm(CDS.Client.Desktop.Essential.BaseForm form, bool shouldHide)
        {
            try
            {
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage p in MdiManager.Pages)
                {
                    if (p.MdiChild == form)
                    {
                        if (shouldHide)
                        {
                            (p.MdiChild as CDS.Client.Desktop.Essential.BaseForm).MdiParent = null; //.Hide();
                            (p.MdiChild as CDS.Client.Desktop.Essential.BaseForm).Hide();
                        }
                        else
                        {
                            (p.MdiChild as CDS.Client.Desktop.Essential.BaseForm).MdiParent = this; //Show();
                            (p.MdiChild as CDS.Client.Desktop.Essential.BaseForm).Show();
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void OpenEmailDialogue(Essential.BaseForm.ReportTemplateType reportTemplate, long id, string filename)
        {
            Reporting.Report.ReportEmailer.EmailtoPDF(reportTemplate, id, filename, DataContext);
        }

        /// <summary>
        /// Used to show a message using the Alert Control or Toast Notification Manager
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="showTime"></param>
        /// <param name="longText"></param>
        /// <param name="image"></param>
        public void ShowNotification(string title, string message, int showTime, bool longText, Image image)
        {
            try
            {
                Version win8version = new Version(6, 2, 9200, 0);

                if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                    Environment.OSVersion.Version >= win8version)
                {
                    var toastNotification = ToastNotificationsManager.Notifications[0];
                    toastNotification.Header = title;
                    toastNotification.Body = message;
                    toastNotification.Image = image;
                    toastNotification.Sound = DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.NoSound;
                    toastNotification.Duration = showTime > 7000 ? DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.Long : DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.Default;
                    ToastNotificationsManager.ShowNotification(ToastNotificationsManager.Notifications[0].ID);
                }
                else
                {
                    NotificationManager.AutoFormDelay = showTime;
                    NotificationManager.AutoHeight = longText;
                    if (image != null)
                        NotificationManager.Show(instance, title, message, image);
                    else
                        NotificationManager.Show(instance, title, message);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Shows a notification that the client has received a message
        /// Should only be used by the SocketHelper
        /// CDS.Client.Desktop.Essential\MSG\SocketHelper.cs
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="message"></param>
        public void ShowMessagesNotification(long personId, string message)
        {
            string sender = DataContext.EntitySystemContext.SYS_Person.Where(n => n.Id == personId).Select(n => n.Fullname).FirstOrDefault();
            this.Invoke(new Action(() => ShowNotification("Message from " + sender, message, 5000, message.Length > 30, Desktop.Properties.Resources.businessman_16)));
        }

        /// <summary>
        /// Shows a message for the given amount of milliseconds in the Status Bar
        /// </summary>
        /// <param name="message"></param>
        /// <param name="milliseconds"></param>
        public void ShowMessage(string message, long milliseconds)
        {
            bsiMessage.Caption = message;
            if (!NotificationBackgroundWorker.IsBusy)
                NotificationBackgroundWorker.RunWorkerAsync(milliseconds);
        }

    }
}
