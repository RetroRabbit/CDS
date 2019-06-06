using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraScheduler;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Calendar
{
    public partial class WorkshopAppointmentDialogue : CDS.Client.Desktop.Core.Calendar.AppointmentDialogue
    {
        public WorkshopAppointmentDialogue()
        {
            InitializeComponent();
        }

        public WorkshopAppointmentDialogue(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm)
        {
            InitializeComponent();
		}

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                // Only Customers and Only technicians...?
                if (!this.DesignMode)
                { 
                    
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void UpdateForm()
        {
            try
            {
                base.UpdateForm();

                txtVehicle.Text = controller.CustomVehicle;
                txtRegistration.Text = controller.CustomRegistration;
                txtMileage.Text = controller.CustomMileage;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void UpdateChanges()
        {
            try
            {
                base.UpdateChanges();

                controller.CustomVehicle = txtVehicle.Text;
                controller.CustomRegistration = txtRegistration.Text;
                controller.CustomMileage = txtMileage.Text;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override IQueryable GetQueryable()
        {
            return DataContext.ReadonlyContext.VW_Entity.Where(n => n.Archived == false && (new int[] { (int)BL.SYS.SYS_Type.Company }).Contains(n.TypeId) && n.HasCustomer);
        }

        public override IQueryable GetQueryableEmployee()
        {
            roleIds = DataContext.EntityHumanResourcesContext.HRS_Role.Where(n => n.WorkshopAppointment.Value).Select(n => n.Id).ToList();
            return DataContext.ReadonlyContext.VW_Employee.Where(n => roleIds.Contains(n.RoleId));
        }

        private void btnNewJobQuote_Click(object sender, EventArgs e)
        {
            try
            {
                if (apt.Id == null)
                {
                    UpdateChanges();
                    controller.ApplyChanges();
                }

                //CompleteDataLayer.Company company = (CompleteDataLayer.Company)CompleteDataLayer.CompanyProvider.Instance.Load(Convert.ToInt32(controller.CustomCompany));

                //// Create new job card
                //CompleteDataLayer.JobQuote jobquote = (CompleteDataLayer.JobQuote)CompleteDataLayer.JobQuoteProvider.Instance.CreateNew();
                //jobquote.BeginLoad();
                ////job.JobItems.Clear();

                //if (company != null)
                //{
                //    jobquote.CompanyGuid = company.CompanyGuid;
                //    //jobquote.AccountCode = company.Code;
                //    jobquote.VatNumber = company.VatNumber;
                //    jobquote.BillingAddress = company.BillingAddress.AddressFull;
                //    jobquote.ShippingAddress = company.ShippingAddress.AddressFull;
                //}

                //// order.FinancialDate = salesquote.FinancialDate;
                //jobquote.TotalAmount = 0M;
                //jobquote.TotalAmountBeforeTax = 0M;
                //jobquote.TotalTax = 0M;

                //jobquote.ReferenceOurs = apt.Subject;
                //jobquote.Message = apt.Description;
                ////jobquote. = Convert.ToString(apt.CustomFields["Vehicle"]);
                ////jobquote.RegistrationNumber = Convert.ToString(apt.CustomFields["Registration"]);
                ////jobquote.Mileage = Convert.ToString(apt.CustomFields["Mileage"]);
                //jobquote.Contact = Convert.ToString(controller.CustomContact);
                //jobquote.Telephone = Convert.ToString(controller.CustomTelephone);
                ////jobquote.Technition = ddlResource.Text;
                //jobquote.EndLoad();

                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();

                //CompleteDistribution.JobQuote.JobQuoteForm childForm = new CompleteDistribution.JobQuote.JobQuoteForm(jobquote, (Int64)apt.Id);
                //childForm.EnableEvents = false;
                //STD.MainForm.Instance.ShowForm(childForm);
                //childForm.EnableEvents = true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNewJobCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (apt.Id == null)
                {
                    UpdateChanges();
                    controller.ApplyChanges();
                }

                // CompleteDataLayer.Company company = (CompleteDataLayer.Company)CompleteDataLayer.CompanyProvider.Instance.Load(Convert.ToInt32(controller.CustomCompany));
                   
                //// Create new job card
                // CompleteDataLayer.Job job = (CompleteDataLayer.Job)CompleteDataLayer.JobProvider.Instance.CreateNew();
                // job.BeginLoad();
                // //job.JobItems.Clear();
                   
                // if (company != null)
                // {
                //     job.CompanyGuid = company.CompanyGuid;
                //     job.AccountCode = company.Code;
                //     job.VatRegistration = company.VatNumber;
                //     job.BillingAddress = company.BillingAddress.AddressFull;
                //     job.ShippingAddress = company.ShippingAddress.AddressFull;
                // }
                   
                // // order.FinancialDate = salesquote.FinancialDate;
                // job.DateIn = DateTime.Now;
                // job.TotalAmount = 0M;
                // job.TotalAmountBeforeTax = 0M;
                // job.TotalTax = 0M;
                   
                // job.JobReference = apt.Subject;
                // job.Description = apt.Description;
                // job.VehicleDescription = Convert.ToString(controller.CustomVehicle);
                // job.RegistrationNumber = Convert.ToString(controller.CustomRegistration);
                // job.Mileage = Convert.ToString(controller.CustomMileage);
                // job.JobName = Convert.ToString(controller.CustomContact);
                // job.Telephone = Convert.ToString(controller.CustomTelephone);
                   
                // job.Technition = ddlResource.Text;
                // job.EndLoad();
                   
                // this.DialogResult = System.Windows.Forms.DialogResult.OK;
                // this.Close();
                   
                // CompleteDistribution.Job.JobForm childForm = new CompleteDistribution.Job.JobForm(job, (Int64)apt.Id);
                // childForm.EnableEvents = false;
                // STD.MainForm.Instance.ShowForm(childForm);
                // childForm.EnableEvents = true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
