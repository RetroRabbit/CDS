using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI; 
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;

namespace CDS.Client.Desktop.Core.Calendar
{
    public partial class AppointmentDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        protected SchedulerControl control;
        protected Appointment apt;
        bool openRecurrenceForm = false;
        int suspendUpdateCount;
        protected AppointmentStorage Appointments { get { return control.Storage.Appointments; } }
        protected internal bool IsNewAppointment { get { return controller != null ? controller.IsNewAppointment : true; } }
        protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

        // Note that the MyAppointmentFormController class is inherited from
        // the AppointmentFormController one to add custom properties.
        // See its declaration at the end of this file.
        protected MyAppointmentFormController controller;
        protected List<Int64> roleIds;
        DB.VW_Entity selectedEntity;
        protected DB.VW_Entity SelectedEntity
        {
            get
            {
                return selectedEntity;
            }
            set
            {
                //If this is the first time the Company is net
                if (selectedEntity == null || selectedEntity.Id != value.Id)
                    selectedEntity = value;

            }
        }


        public AppointmentDialogue()
        {
            InitializeComponent();
        }

        public AppointmentDialogue(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = new MyAppointmentFormController(control, apt);
            this.apt = apt;
            this.control = control;
            //
            // Required for Windows Form Des0igner support
            //
            SuspendUpdate();
            InitializeComponent();
            ResumeUpdate();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                tabAttachments.Enabled = !IsNewAppointment;

                // All companies and all Users...
                if (!this.DesignMode)
                {
                    UpdateForm();
                    tcgGroup.SelectedTabPage = tabAppointment;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected void SuspendUpdate()
        {
            try
            {
                suspendUpdateCount++;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected void ResumeUpdate()
        {
            try
            {
                if (suspendUpdateCount > 0)
                    suspendUpdateCount--;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnRecurrence_Click(object sender, EventArgs e)
        {
            try
            {
                OnRecurrenceButton();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        void OnRecurrenceButton()
        {
            try
            {
                ShowRecurrenceForm();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        void ShowRecurrenceForm()
        {
            try
            {
                if (!control.SupportsRecurrence)
                    return;

                // Prepare to edit appointment's recurrence.
                Appointment editedAptCopy = controller.EditedAppointmentCopy;
                Appointment editedPattern = controller.EditedPattern;
                Appointment patternCopy = controller.PrepareToRecurrenceEdit();

                AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek, controller);

                // Required for skins support.
                dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;

                DialogResult result = dlg.ShowDialog(this);
                dlg.Dispose();

                if (result == DialogResult.Abort)
                    controller.RemoveRecurrence();
                else
                    if (result == DialogResult.OK)
                    {
                        controller.ApplyRecurrence(patternCopy);
                        if (controller.EditedAppointmentCopy != editedAptCopy)
                            UpdateForm();
                    }
                UpdateIntervalControls();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected virtual void UpdateChanges()
        {
            try
            {
                controller.Subject = txtSubject.Text;
                controller.Location = txtLocation.Text;
                controller.Description = txtDescription.Text;

                controller.ResourceId = ddlResource.EditValue;
                //controller.SetStatus(edStatus.Status);
                //controller.SetLabel(edLabel.Label);
                controller.AllDay = this.chkAllDay.Checked;
                controller.Start = this.datStartDate.DateTime.Date + this.timStartTime.Time.TimeOfDay;
                controller.End = this.datEndDate.DateTime.Date + this.timEndTime.Time.TimeOfDay;

                if (SelectedEntity != null)
                    controller.CustomEntity = SelectedEntity.Id;

                controller.CustomContact = txtContact.Text;
                controller.CustomTelephone = txtTelephone.Text;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLayout();

                if (!ValidateBeforeSave())
                    return;

                // Required to check appointment's conflicts.
                if (!controller.IsConflictResolved())
                    return;

                UpdateChanges();

                // Save all changes made to the appointment edited in a form.
                controller.ApplyChanges();

                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private bool ValidateBeforeSave()
        {
            return /*IsAccountValid() &&*/ IsDatesValid() && IsTimeValid() && IsRecourceValid() && IsSlotAvaiable();
        }

        private bool IsAccountValid()
        {
            if (ddlCompany.EditValue != null)
            {
                ddlCompany.ErrorText = String.Empty;
                return true;
            }
            else
            {
                ddlCompany.ErrorText = "Select an Company before continuing";
                return false;
            }
        }

        private bool IsTimeValid()
        {

            if (chkAllDay.Checked)
                return true;

            //A signed number indicating the relative values of this instance and the value
            //parameter.Value Description Less than zero This instance is earlier than
            //value. Zero This instance is the same as value. Greater than zero This instance
            //is later than value.
            switch (datEndDate.DateTime.CompareTo(datStartDate.DateTime))
            {
                case 1:
                    return true;
                case 0:
                    return timStartTime.Time < timEndTime.Time ? true : false;
                case -1:
                    return false;
            }

            return false;
        }

        private bool IsRecourceValid()
        {
            if (ddlResource.EditValue != null)
            {
                ddlResource.ErrorText = String.Empty;
                return true;
            }
            else
            {
                ddlResource.ErrorText = "Select an Employee before continuing";
                return false;
            }
        }

        private bool IsDatesValid()
        {
            return datStartDate.DateTime <= datEndDate.DateTime ? true : false;
        }

        private bool IsSlotAvaiable()
        {
            bool available = true;

            DateTime startDate = new DateTime(datStartDate.DateTime.Ticks + timStartTime.Time.Ticks);
            DateTime endDate = new DateTime(datEndDate.DateTime.Ticks + timEndTime.Time.Ticks);

            //if (!DB.CAL_CalendarDataProvider.Instance.IsSlotAvaiable(startDate,endDate,Convert.ToInt64(ddlResource.EditValue)))
            //    available = STD.BaseAlert.ShowAlert("Unavailable slot", "The selected time conflicts with a previous booking for " + string.Format("{0},{1}", (ddlResource.GetSelectedDataRow() as CDS.Client.Library.Data.HRS_Employee).Lastname, (ddlResource.GetSelectedDataRow() as CDS.Client.Library.Data.HRS_Employee).Firstnames) + " do you wish to continue ?", BaseAlert.Buttons.OkCancel, BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK;

            return available;
        }

        protected virtual void UpdateForm()
        {
            try
            {
                SuspendUpdate();
                try
                {
                    txtSubject.Text = controller.Subject;
                    txtLocation.Text = controller.Location;
                    txtDescription.Text = controller.Description;
                    //edStatus.Status = Appointments.Statuses[controller.StatusId];
                    //edLabel.Label = Appointments.Labels[controller.LabelId];
                    ddlResource.EditValue = controller.ResourceId;

                    datStartDate.DateTime = controller.Start.Date;
                    datEndDate.DateTime = controller.End.Date;

                    timStartTime.Time = DateTime.MinValue.AddTicks(controller.Start.TimeOfDay.Ticks);
                    timEndTime.Time = DateTime.MinValue.AddTicks(controller.End.TimeOfDay.Ticks);
                    chkAllDay.Checked = controller.AllDay;

                    //edStatus.Storage = control.Storage;
                    //edLabel.Storage = control.Storage;

                    if (controller.CustomEntity != null)
                    {
                        ddlCompany.EditValue = controller.CustomEntity;
                    }

                    txtContact.Text = controller.CustomContact;
                    txtTelephone.Text = controller.CustomTelephone;

                    UpdateAttachments();
                }
                finally
                {
                    ResumeUpdate();
                }
                UpdateIntervalControls();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void AppointmentDialogue_Activated(object sender, EventArgs e)
        {
            try
            {
                // Required to show the recurrence form.
                if (openRecurrenceForm)
                {
                    openRecurrenceForm = false;
                    OnRecurrenceButton();
                }

                txtSubject.Focus();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void datStartDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsUpdateSuspended)
                    controller.Start = datStartDate.DateTime.Date + timStartTime.Time.TimeOfDay;
                UpdateIntervalControls();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected virtual void UpdateIntervalControls()
        {
            try
            {
                if (IsUpdateSuspended)
                    return;

                SuspendUpdate();
                try
                {
                    datStartDate.EditValue = controller.Start.Date;
                    datEndDate.EditValue = controller.End.Date;
                    timStartTime.EditValue = controller.Start.TimeOfDay;
                    timEndTime.EditValue = controller.End.TimeOfDay;

                    Appointment editedAptCopy = controller.EditedAppointmentCopy;
                    bool showControls = IsNewAppointment || editedAptCopy.Type != AppointmentType.Pattern;
                    datStartDate.Enabled = showControls;
                    datEndDate.Enabled = showControls;
                    bool enableTime = showControls && !controller.AllDay;
                    timStartTime.Visible = enableTime;
                    timStartTime.Enabled = enableTime;
                    timEndTime.Visible = enableTime;
                    timEndTime.Enabled = enableTime;
                    chkAllDay.Enabled = showControls;
                }
                finally
                {
                    ResumeUpdate();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void timStartTime_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsUpdateSuspended)
                    controller.Start = datStartDate.DateTime.Date + timStartTime.Time.TimeOfDay;
                UpdateIntervalControls();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void datEndDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsUpdateSuspended) return;
                if (IsIntervalValid())
                    controller.End = datEndDate.DateTime + timEndTime.Time.TimeOfDay;
                else
                    datEndDate.EditValue = controller.End.Date;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void timEndTime_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsUpdateSuspended) return;
                if (IsIntervalValid())
                    controller.End = datEndDate.DateTime + timEndTime.Time.TimeOfDay;
                else
                    timEndTime.EditValue = controller.End.TimeOfDay;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        bool IsIntervalValid()
        {
            try
            {
                DateTime start = datStartDate.DateTime + timStartTime.Time.TimeOfDay;
                DateTime end = datEndDate.DateTime + timEndTime.Time.TimeOfDay;
                return end >= start;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private void chkAllDay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                controller.AllDay = this.chkAllDay.Checked;
                if (!IsUpdateSuspended)
                    UpdateAppointmentStatus();

                UpdateIntervalControls();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        void UpdateAppointmentStatus()
        {
            try
            {
                //AppointmentStatus currentStatus = edStatus.Status;
                //AppointmentStatus newStatus = controller.UpdateAppointmentStatus(currentStatus);
                //if (newStatus != currentStatus)
                //    edStatus.Status = newStatus;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnJobCard_Click(object sender, EventArgs e)
        {
            try
            {
                //CompleteDataLayer.Job job = null;
                //if (Convert.ToInt64(apt.CustomFields["DocumentId"]) == 0)
                //{
                //    // Get company info

                //    CompleteDataLayer.Company company = (CompleteDataLayer.Company)CompleteDataLayer.CompanyProvider.Instance.Load(Convert.ToInt32(apt.CustomFields["CompanyId"]));


                //    // Create new job card
                //    job = (CompleteDataLayer.Job)CompleteDataLayer.JobProvider.Instance.CreateNew();
                //    job.BeginLoad();
                //    //job.JobItems.Clear();

                //    if (company != null)
                //    {
                //        job.CompanyGuid = company.CompanyGuid;
                //        job.AccountCode = company.Code;
                //        job.VatRegistration = company.VatNumber;
                //        job.BillingAddress = company.BillingAddress.AddressFull;
                //        job.ShippingAddress = company.ShippingAddress.AddressFull;
                //    }


                //    // order.FinancialDate = salesquote.FinancialDate;
                //    job.DateIn = DateTime.Now;
                //    job.TotalAmount = 0M;
                //    job.TotalAmountBeforeTax = 0M;
                //    job.TotalTax = 0M;

                //    job.JobReference = apt.Subject;
                //    job.Description = apt.Description;
                //    job.VehicleDescription = Convert.ToString(apt.CustomFields["Vehicle"]);
                //    job.RegistrationNumber = Convert.ToString(apt.CustomFields["Registration"]);
                //    job.Mileage = Convert.ToString(apt.CustomFields["Mileage"]);
                //    job.JobName = Convert.ToString(apt.CustomFields["Contact"]);
                //    job.Telephone = Convert.ToString(apt.CustomFields["Telephone"]);

                //    job.Technition = ddlResource.Text;

                //    job.EndLoad();
                //}
                //else
                //{
                //    // open existing job card

                //    job = (CompleteDataLayer.Job)CompleteDataLayer.JobProvider.Instance.Load(Convert.ToInt32(apt.CustomFields["DocumentId"]));
                //}

                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();

                //CompleteDistribution.Job.JobForm childForm = new CompleteDistribution.Job.JobForm(job, (Int64)apt.Id);
                //childForm.EnableEvents = false;
                //STD.MainForm.Instance.ShowForm(childForm);
                //childForm.EnableEvents = true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected void UpdateAttachments()
        {
            try
            {
                if (apt.Id != null && (Int64)apt.Id != 0)
                {
                    //// Load attachments here?
                    ////grdAttachments.DataSource = Library.Data.DataLibrary.GetReadonlyContext().CAL_Attachments
                    ////    .Where(n => n.CalendarId == (Int64)apt.Id)
                    ////    .Select(n => new { n.DocumentId, n.JobId, n.CreatedOn, n.CreatedBy });

                    ////grdAttachments.DataSource = context.CAL_Attachments
                    ////    .Where(n => n.CalendarId == (Int64)apt.Id)
                    ////    .Join(context.tblJobs, a => a.JobId, j => j.iJobId, (a, j) => new {a.DocumentId, a.JobId, a.CreatedOn, a.CreatedBy, j.dTotalAmount})
                    ////    ;
                    //DB.EntityViews tempReadonlyContext = DataContext.ReadonlyContext;

                    ////var sys_doc_type = DataContext.EntitySystemContext.SYS_DOC_Type.ToList();

                    //var recs = tempReadonlyContext.VW_Attachment
                    //    .Where(n => n.CalendarId == (Int64)apt.Id)
                    //    .GroupJoin(tempReadonlyContext.VW_Job, a => a.DocumentId, j => j.Id, (attachment, job) => new { attachment, job })
                    //    .SelectMany(c => c.job.DefaultIfEmpty(), (c, job) => new { c.attachment, job })
                    //    .GroupJoin(tempReadonlyContext.VW_Document, a => a.attachment.DocumentId, d => d.Id, (attachment, document) => new { attachment, document })
                    //    .SelectMany(c => c.document.DefaultIfEmpty(), (c, document) => new { c.attachment.attachment, c.attachment.job, document })
                    //    .GroupJoin(tempReadonlyContext.VW_DOC_Type, a => a.document.TypeId, t => t.Id, (attachment, documenttype) => new { attachment, documenttype })
                    //    .SelectMany(c => c.documenttype.DefaultIfEmpty(), (c, documenttype) => new { c.attachment.attachment, c.attachment.job, c.attachment.document, documenttype })
                    //    .Select(n => new
                    //    {
                    //        n.attachment.Id,
                    //        n.attachment.DocumentId,
                    //        n.attachment.CreatedBy,
                    //        n.attachment.CreatedOn,
                    //        Number = n.document.DocumentNumber ?? n.job.DocumentNumber,
                    //        TypeId = n.documenttype.Id,
                    //        TypeName = n.documenttype.Name ?? "Unknown",
                    //        //StatusGuid = (n.document.fkStatusGuid != null) ? n.document.fkStatusGuid : n.job.fkStatusGuid,
                    //        Total = n.document.Total ?? n.job.Total
                    //    }).Select(a => new { a.Id, a.DocumentId, a.Number, a.CreatedBy, a.CreatedOn, a.TypeId, a.TypeName, a.Total, }).ToList();
                    //    //.Join(DataContext.tlStatus, a => a.StatusGuid, s => s.pStatusGuid, (a, s) => new { a.Id, a.DocumentId, a.JobId, a.Number, a.CreatedBy, a.CreatedOn, a.TypeGuid, a.TypeName, a.Total, a.StatusGuid, StatusName = s.sName })
                    //    ;

                    //grdAttachments.DataSource = recs.ToList();
                    ////query.Join(ctx.DataContext.CommentSource,
                    ////       comment => comment.CommentSourceId,
                    ////       commentSource => commentSource.Id,
                    ////       (comment, commentSource) 
                    ////          => new { Comment=comment, CommentSource=commentSource })
                    ServerModeSourceAttachments.QueryableSource = DataContext.ReadonlyContext.VW_Attachment.Where(n => n.CalendarId == (Int64)apt.Id);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvAttachments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvAttachments.FocusedRowHandle < 0)
                    return;

                if ((grvAttachments.GetFocusedRow() as DB.VW_Attachment) == null)
                    return;

                object FocusedRow = grvAttachments.GetFocusedRow();
                //return Convert.ToInt64(FocusedRow.GetType().GetProperty("Id").GetValue(FocusedRow, null));


                //Open Item
                Int64 documentid = Convert.ToInt64((grvAttachments.GetFocusedRow() as DB.VW_Attachment).DocumentId);
                byte? typeId = (grvAttachments.GetFocusedRow() as DB.VW_Attachment).TypeId;
                if (documentid != 0)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();

                    ShowDocumentForm(documentid, typeId.Value);
                }
                // if (jobid.HasValue && jobid != 0)
                // {
                //     this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //     this.Close();
                   
                //     CompleteDistribution.Job.JobForm childForm = new CompleteDistribution.Job.JobForm(jobid.Value);
                //     childForm.EnableEvents = false;
                //     STD.MainForm.Instance.ShowForm(childForm);
                //     childForm.EnableEvents = true;
                // }
                // else if (documentid.HasValue && documentid != 0)
                // {
                //     this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //     this.Close();
                   
                //     switch (typeguid.ToString().ToUpper())
                //     {
                //         case "6AE4CCED-0439-45B3-B0ED-2C833928D46C": //	TAX Invoice	INV
                //             CompleteDataLayer.SalesInvoice salesinvoice = (CompleteDataLayer.SalesInvoice)CompleteDataLayer.SalesInvoiceProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.SalesInvoice.SalesInvoiceForm childFormInvoice = new CompleteDistribution.SalesInvoice.SalesInvoiceForm(salesinvoice);
                //             childFormInvoice.EnableEvents = false;
                //             childFormInvoice.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormInvoice);
                //             break;
                //         case "70F65416-0F87-4999-B745-3DDA72B4A6CE": //	Purchase Order	ORDER
                //             CompleteDataLayer.PurchaseOrder purchaseorder = (CompleteDataLayer.PurchaseOrder)CompleteDataLayer.PurchaseOrderProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.PurchaseOrder.PurchaseOrderForm childFormPurchaseOrder = new CompleteDistribution.PurchaseOrder.PurchaseOrderForm(purchaseorder);
                //             childFormPurchaseOrder.ReadOnly = false;
                //             MainForm.Instance.ShowForm(childFormPurchaseOrder);
                //             break;
                //         case "15D85108-00C5-48BC-930D-4E87BC46F67F": //	Purchase Credit Note	C/N
                //             CompleteDataLayer.PurchaseCreditNote purchasecreditnote = (CompleteDataLayer.PurchaseCreditNote)CompleteDataLayer.PurchaseCreditNoteProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.PurchaseCreditNote.PurchaseCreditNoteForm childFormPurchaseCredit = new CompleteDistribution.PurchaseCreditNote.PurchaseCreditNoteForm(purchasecreditnote);
                //             childFormPurchaseCredit.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormPurchaseCredit);
                //             break;
                //         case "DFB95C26-1CF8-4A16-A899-4FE77C78F26C": //	Goods Received	NULL
                //             break;
                //         case "29770704-9D0D-4848-81F9-5CBC7551DD38": //	Inventory Adjustment	ADJ
                //             CompleteDataLayer.StockAdjustment stockadjustment = (CompleteDataLayer.StockAdjustment)CompleteDataLayer.StockAdjustmentProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.StockAdjustment.StockAdjustmentForm childFormStockAdjust = new CompleteDistribution.StockAdjustment.StockAdjustmentForm(stockadjustment);
                //             childFormStockAdjust.EnableEvents = false;
                //             childFormStockAdjust.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormStockAdjust);
                //             break;
                //         case "8EB11219-580C-4414-9667-61B26EE64F6D": //	Sales Quote	QUOTE
                //             CompleteDataLayer.SalesQuote salesquote = (CompleteDataLayer.SalesQuote)CompleteDataLayer.SalesQuoteProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.SalesQuote.SalesQuoteForm childFormQuote = new CompleteDistribution.SalesQuote.SalesQuoteForm(salesquote);
                //             childFormQuote.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormQuote);
                //             break;
                //         case "35F6974F-B224-41F9-85BB-78EB03EFB308": //	Sales Order	ORDER
                //             CompleteDataLayer.SalesOrder salesorder = (CompleteDataLayer.SalesOrder)CompleteDataLayer.SalesOrderProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.SalesOrder.SalesOrderForm childFormSalesOrder = new CompleteDistribution.SalesOrder.SalesOrderForm(salesorder);
                //             MainForm.Instance.ShowForm(childFormSalesOrder);
                //             break;
                //         case "7207B59E-9418-40FA-B1F0-84876B67D545": //	Invalid Document	N/A
                //             break;
                //         case "7CD8EDAF-2146-44ED-AC11-911365E60B30": //	Back Order	B/O
                //             CompleteDataLayer.SalesBackOrder salesbackorder = (CompleteDataLayer.SalesBackOrder)CompleteDataLayer.SalesBackOrderProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.SalesBackOrder.SalesBackOrderForm childFormSalesBackOrder = new CompleteDistribution.SalesBackOrder.SalesBackOrderForm(salesbackorder);
                //             childFormSalesBackOrder.EnableEvents = false;
                //             childFormSalesBackOrder.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormSalesBackOrder);
                //             break;
                //         case "7430CC27-0B22-4BC8-A5CB-A0A55B5D57D7": //	Purchase Payment	PAY
                //             break;
                //         case "BB8BEEFB-5FF0-451C-8684-B34B344E8AFF": //	Sales Payment	PAY
                //             break;
                //         case "44EBD6A5-6A70-4E38-926C-B68CEBF757B8": //	Purchase Back Order	B/O
                //             break;
                //         case "8DA1C782-2BCA-4E81-B28B-EAFD3204D02D": //	Purchase Invoice	INV
                //             CompleteDataLayer.PurchaseInvoice purchaseinvoice = (CompleteDataLayer.PurchaseInvoice)CompleteDataLayer.PurchaseInvoiceProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.PurchaseInvoice.PurchaseInvoiceForm childFormPurchaseInvoice = new CompleteDistribution.PurchaseInvoice.PurchaseInvoiceForm(purchaseinvoice);
                //             childFormPurchaseInvoice.EnableEvents = false;
                //             childFormPurchaseInvoice.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormPurchaseInvoice);
                //             break;
                //         case "17AA529B-884A-4EC4-928B-EED6F576F825": //	Sales Credit Note	C/N
                //             CompleteDataLayer.SalesCreditNote salescreditnote = (CompleteDataLayer.SalesCreditNote)CompleteDataLayer.SalesCreditNoteProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.SalesCreditNote.SalesCreditNoteForm childFormSalesCredit = new CompleteDistribution.SalesCreditNote.SalesCreditNoteForm(salescreditnote);
                //             childFormSalesCredit.EnableEvents = false;
                //             childFormSalesCredit.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormSalesCredit);
                //             break;
                //         case "D0302A33-B772-464B-B73E-10FCB2FB9E50": //	Bill	BILL
                //             break;
                //         case "308C494A-E2B9-440D-9C5B-F167B6A51433": //	Internal Order	INTRL
                //             break;
                //         case "5173ADE6-514E-4D14-8A3F-B99180DDB270": //	Recieve Internal Order	RINT
                //             break;
                //         case "A95E04F5-C2CA-43B2-85C2-C0BA6AEC2B0B": //	Internal Transfer	TRANS
                //             break;
                //         case "9489DBFC-C79D-43CA-9B47-E0EDDF30EA85": //	Transfer Shipped	TXSHP
                //             break;
                //         case "4CD16D87-09C6-4EBF-AF63-C43889968659": //	Transfer Received	TXRCV
                //             break;
                //         case "C38F0384-4870-4C23-AA3E-18D424B8DFFE": //	Work In Progress	WIP
                //             break;
                //         case "02703B87-79CD-48CE-A254-C33DF8BDC02B": //	Assembly Work Started	A.START
                //             break;
                //         case "8CF7F907-734E-4F48-AECD-E6A58758C481": //	Work Completed	W.END
                //             break;
                //         case "6BFED700-D51B-4BDA-BA85-F94870B20DAC": //	Work Cancelled	W.CANCEL
                //             break;
                //         case "76A9EDBB-AA2C-4D64-86A5-C19A58D61C5C": //	Disassembly Work Started	D.START
                //             break;
                //         case "61A82D4C-4DA1-4D66-BB54-254BCE402517": //	Job Started	JOB
                //             break;
                //         case "6E7FE39F-0236-42A3-873B-C8D377B74747": //	Job cancelled	C.JOB
                //             break;
                //         case "D22CB3C7-2A1F-4D69-9067-686780FBA33B": //	Work Order	W/O
                //             break;
                //         case "B287BF7C-B17E-4DC1-B9D2-A352210C2010": //	Work Done	W/D
                //             break;
                //         case "239FC9DA-DAC3-4A3F-8AB8-18D301DE037E": //	Work Cancelled	W/C
                //             break;
                //         case "3885DDC8-6E47-49B6-9196-F0325D080604": //	Job Quote	QUOTE
                //             CompleteDataLayer.JobQuote jobquote = (CompleteDataLayer.JobQuote)CompleteDataLayer.JobQuoteProvider.Instance.Load(documentid.Value);
                //             CompleteDistribution.JobQuote.JobQuoteForm childFormJobQuote = new CompleteDistribution.JobQuote.JobQuoteForm(jobquote);
                //             childFormJobQuote.EnableEvents = false;
                //             childFormJobQuote.ReadOnly = true;
                //             MainForm.Instance.ShowForm(childFormJobQuote);
                //             break;
                //         case "6B259D33-34B3-494B-9DA1-6B7F2C9BA7A2": //	Kit	KIT
                //             break;
                //         case "81FBDD76-487D-459B-AB1F-7E241C8003E2": //	KitReversal	KITREV
                //             break;
                //     }
                   
                // }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnLinkDocument_Click(object sender, EventArgs e)
        {
            try
            {
                //if (apt.Id == null)
                //{
                //    STD.BaseAlert.ShowAlert("Save Appointment", "Please save appointment first", BaseAlert.Buttons.Ok,BaseAlert.Icons.Warning);

                //    //MessageBox.Show("Please save appointment first", "Error", MessageBoxButtons.OK);
                //}
                //else
                //{
                using (Essential.UTL.SelectDocumentDialogue dialogue = new Essential.UTL.SelectDocumentDialogue())
                {
                    if (dialogue.ShowDialog(this) == DialogResult.OK)
                    {
                        DB.CAL_Attachment attachment = BL.CAL.CAL_Attachment.New;
                        attachment.CalendarId = (Int64)apt.Id;
                        attachment.DocumentId = dialogue.DocumentId;

                        try
                        {
                            using (TransactionScope transaction = DataContext.GetTransactionScope())
                            {

                                BL.EntityController.SaveCAL_Attachment(attachment, DataContext);
                                DataContext.SaveChangesEntityCalendarContext();

                                DataContext.CompleteTransaction(transaction);
                            }
                            DataContext.EntityCalendarContext.AcceptAllChanges();
                        }
                        catch (Exception ex)
                        {
                            DataContext.EntityCalendarContext.RejectChanges();
                            if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        }


                        UpdateAttachments();
                    }
                }
                //}

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlResource_EditValueChanged(object sender, EventArgs e)
        {

        }

        public virtual IQueryable GetQueryable()
        {
            return DataContext.ReadonlyContext.VW_Entity.Where(n => n.Archived == false && (new int[] { (int)BL.SYS.SYS_Type.Company }).Contains(n.TypeId));
        }

        public virtual IQueryable GetQueryableEmployee()
        {
            roleIds = DataContext.EntityHumanResourcesContext.HRS_Role.Where(n => n.Appointment.Value).Select(n => n.Id).ToList();
            return DataContext.ReadonlyContext.VW_Employee.Where(n => roleIds.Contains(n.RoleId));
        }

        private void InstantFeedbackSourceCompany_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = GetQueryable();
        }

        private void InstantFeedbackSourceEmployee_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = GetQueryableEmployee();
        }

        private void SelectCompany(object sender)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            //if (hi.InRowCell) MessageBox.Show(view.GetRowCellValue(view.FocusedRowHandle, "Id").ToString());

            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            SelectedEntity = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(view.GetFocusedRow())).OriginalRow as DB.VW_Entity;
            controller.CustomEntity = SelectedEntity.Id;
        }

        private void ddlCompanyView_Click(object sender, EventArgs e)
        {
            SelectCompany(sender);
        }

        private void ddlCompanyView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SelectCompany(sender);
                //SendKeys.Send("{TAB}");
            }
        }

        private void grvAttachments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                if (Essential.BaseAlert.ShowAlert("Remove Attachment", "You are about to remove the seleced attachment do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        { 
                            DataContext.EntityCalendarContext.CAL_Attachment.Remove(DataContext.EntityCalendarContext.CAL_Attachment.FirstOrDefault(n => n.Id == (grvAttachments.GetFocusedRow() as DB.VW_Attachment).Id));
                            DataContext.SaveChangesEntityCalendarContext();

                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityCalendarContext.AcceptAllChanges();
                        UpdateAttachments();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityCalendarContext.RejectChanges();
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                }
            }
        }
    }

    public class MyAppointmentFormController : AppointmentFormController
    {
        public Int64? CustomEntity { get { return (Int64?)EditedAppointmentCopy.CustomFields["EntityId"]; } set { EditedAppointmentCopy.CustomFields["EntityId"] = value; } }
        public string CustomVehicle { get { return (string)EditedAppointmentCopy.CustomFields["Vehicle"]; } set { EditedAppointmentCopy.CustomFields["Vehicle"] = value; } }
        public string CustomRegistration { get { return (string)EditedAppointmentCopy.CustomFields["Registration"]; } set { EditedAppointmentCopy.CustomFields["Registration"] = value; } }
        public string CustomMileage { get { return (string)EditedAppointmentCopy.CustomFields["Mileage"]; } set { EditedAppointmentCopy.CustomFields["Mileage"] = value; } }
        public string CustomContact { get { return (string)EditedAppointmentCopy.CustomFields["Contact"]; } set { EditedAppointmentCopy.CustomFields["Contact"] = value; } }
        public string CustomTelephone { get { return (string)EditedAppointmentCopy.CustomFields["Telephone"]; } set { EditedAppointmentCopy.CustomFields["Telephone"] = value; } }

        Int64? SourceCustomEntity { get { return (Int64?)SourceAppointment.CustomFields["EntityId"]; } set { SourceAppointment.CustomFields["EntityId"] = value; } }
        string SourceCustomVehicle { get { return (string)SourceAppointment.CustomFields["Vehicle"]; } set { SourceAppointment.CustomFields["Vehicle"] = value; } }
        string SourceCustomRegistration { get { return (string)SourceAppointment.CustomFields["Registration"]; } set { SourceAppointment.CustomFields["Registration"] = value; } }
        string SourceCustomMileage { get { return (string)SourceAppointment.CustomFields["Mileage"]; } set { SourceAppointment.CustomFields["Mileage"] = value; } }
        string SourceCustomContact { get { return (string)SourceAppointment.CustomFields["Contact"]; } set { SourceAppointment.CustomFields["Contact"] = value; } }
        string SourceCustomTelephone { get { return (string)SourceAppointment.CustomFields["Telephone"]; } set { SourceAppointment.CustomFields["Telephone"] = value; } }

        public MyAppointmentFormController(SchedulerControl control, Appointment apt)
            : base(control, apt)
        {
        }

        public override bool IsAppointmentChanged()
        {
            try
            {
                if (base.IsAppointmentChanged())
                    return true;
                return SourceCustomEntity != CustomEntity || SourceCustomVehicle != CustomVehicle || SourceCustomRegistration != CustomRegistration || SourceCustomMileage != CustomMileage || SourceCustomContact != CustomContact || SourceCustomTelephone != CustomTelephone;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void ApplyCustomFieldsValues()
        {
            try
            {
                SourceCustomEntity = CustomEntity;
                SourceCustomVehicle = CustomVehicle;
                SourceCustomRegistration = CustomRegistration;
                SourceCustomMileage = CustomMileage;
                SourceCustomContact = CustomContact;
                SourceCustomTelephone = CustomTelephone;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

    }
}
