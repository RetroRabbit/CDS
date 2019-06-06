using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.Linq;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Calendar
{
    public partial class PurchasesAppointmentDialogue : CDS.Client.Desktop.Core.Calendar.AppointmentDialogue
    {
        public PurchasesAppointmentDialogue()
        {
            InitializeComponent();
        }

        public PurchasesAppointmentDialogue(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm)
        {
            InitializeComponent();
		}

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                // Only Suppliers and Only reps...?
                if (!this.DesignMode)
                { 
                    
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override IQueryable GetQueryable()
        {
            return DataContext.ReadonlyContext.VW_Entity.Where(n => n.Archived == false && (new int[] { (int)BL.SYS.SYS_Type.Company }).Contains(n.TypeId) && n.HasSupplier);
        }

        public override IQueryable GetQueryableEmployee()
        {
            roleIds = DataContext.EntityHumanResourcesContext.HRS_Role.Where(n => n.PurchaseAppointment.Value).Select(n => n.Id).ToList();
            return DataContext.ReadonlyContext.VW_Employee.Where(n => roleIds.Contains(n.RoleId));
        }

        private void btnNewPurchaseOrder_Click(object sender, EventArgs e)
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
                //CompleteDataLayer.PurchaseOrder order = (CompleteDataLayer.PurchaseOrder)CompleteDataLayer.PurchaseOrderProvider.Instance.CreateNew();
                //order.BeginLoad();

                //if (company != null)
                //{
                //    order.CompanyGuid = company.CompanyGuid;
                //    order.VatNumber = company.VatNumber;
                //    order.BillingAddress = company.BillingAddress.AddressFull;
                //    order.ShippingAddress = company.ShippingAddress.AddressFull;
                //}

                //order.TotalAmount = 0M;
                //order.TotalAmountBeforeTax = 0M;
                //order.TotalTax = 0M;

                //order.ReferenceOurs = apt.Subject;
                //order.Message = apt.Description;
                //order.Contact = Convert.ToString(controller.CustomContact);
                //order.Telephone = Convert.ToString(controller.CustomTelephone);
                ////jobquote.Technition = ddlResource.Text;
                //order.EndLoad();

                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();

                //CompleteDistribution.PurchaseOrder.PurchaseOrderForm childForm = new CompleteDistribution.PurchaseOrder.PurchaseOrderForm(order, (Int64)apt.Id);
                //childForm.EnableEvents = false;
                //STD.MainForm.Instance.ShowForm(childForm);
                //childForm.EnableEvents = true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
