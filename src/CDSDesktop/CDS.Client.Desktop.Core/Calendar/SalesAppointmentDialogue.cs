using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Calendar
{
    public partial class SalesAppointmentDialogue : CDS.Client.Desktop.Core.Calendar.AppointmentDialogue
    {
        public SalesAppointmentDialogue()
        {
            InitializeComponent();
        }

        public SalesAppointmentDialogue(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm)
        {
            InitializeComponent();
		}

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                // Only Customers and Only sales reps...?
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
            return DataContext.ReadonlyContext.VW_Entity.Where(n => n.Archived == false && (new int[] { (int)BL.SYS.SYS_Type.Company }).Contains(n.TypeId) && n.HasCustomer);
        }

        public override IQueryable GetQueryableEmployee()
        {
            roleIds = DataContext.EntityHumanResourcesContext.HRS_Role.Where(n => n.SaleAppointment.Value).Select(n => n.Id).ToList();
            return DataContext.ReadonlyContext.VW_Employee.Where(n => roleIds.Contains(n.RoleId));
        }

        private void btnNewSalesQuote_Click(object sender, EventArgs e)
        {
            try
            {
                if (apt.Id == null)
                {
                    UpdateChanges();
                    controller.ApplyChanges();
                    return;
                }

                DB.VW_Company company;

                if (ddlCompany.Properties.View.GetFocusedRow() == null)
                {
                    company = DataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.EntityId == controller.CustomEntity && n.TypeId == (int)BL.ORG.ORG_Type.Customer);
                }
                else
                {
                    company = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(ddlCompany.Properties.View.GetFocusedRow())).OriginalRow as DB.VW_Company;
                }


                DB.SYS_DOC_Header header = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.Quote);
                header.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.New;
                header.ORG_TRX_Header.CompanyId = company.Id;
                header.ORG_TRX_Header.ContactPerson = company.SalesContact;
                header.ORG_TRX_Header.ContactTelephone = company.SalesTelephone;
                header.ORG_TRX_Header.VatNumber = company.VatNumber;

                header.ORG_TRX_Header.ReferenceLong2 = apt.Subject;
                header.Comment = apt.Description;
                header.ORG_TRX_Header.ContactPerson = Convert.ToString(controller.CustomContact);
                header.ORG_TRX_Header.ContactTelephone = Convert.ToString(controller.CustomTelephone);

                DB.VW_Address billingAddress = DataContext.ReadonlyContext.VW_Address.FirstOrDefault(n => n.CompanyId == header.ORG_TRX_Header.CompanyId && n.TypeId == (byte)BL.SYS.SYS_Type.BillingAddress);
                DB.VW_Address shippingAddress = DataContext.ReadonlyContext.VW_Address.FirstOrDefault(n => n.CompanyId == header.ORG_TRX_Header.CompanyId && n.TypeId == (byte)BL.SYS.SYS_Type.ShippingAddress);

                header.ORG_TRX_Header.BillingAddressLine1 = billingAddress.Line1;
                header.ORG_TRX_Header.BillingAddressLine2 = billingAddress.Line2;
                header.ORG_TRX_Header.BillingAddressLine3 = billingAddress.Line3;
                header.ORG_TRX_Header.BillingAddressLine4 = billingAddress.Line4;
                header.ORG_TRX_Header.BillingAddressCode = billingAddress.Code;

                header.ORG_TRX_Header.ShippingAddressLine1 = shippingAddress.Line1;
                header.ORG_TRX_Header.ShippingAddressLine2 = shippingAddress.Line2;
                header.ORG_TRX_Header.ShippingAddressLine3 = shippingAddress.Line3;
                header.ORG_TRX_Header.ShippingAddressLine4 = shippingAddress.Line4;
                header.ORG_TRX_Header.ShippingAddressCode = shippingAddress.Code;

                header.CalendarId = Convert.ToInt64(apt.Id);

                ShowDocumentForm(header);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

                // company = (CompleteDataLayer.Company)CompleteDataLayer.CompanyProvider.Instance.Load(Convert.ToInt32(controller.CustomCompany));

                //// Create new job card
                //CompleteDataLayer.SalesQuote quote = (CompleteDataLayer.SalesQuote)CompleteDataLayer.SalesQuoteProvider.Instance.CreateNew();
                //quote.BeginLoad();

                //if (company != null)
                //{
                //    quote.CompanyGuid = company.CompanyGuid;
                //    quote.VatNumber = company.VatNumber;
                //    quote.BillingAddress = company.BillingAddress.AddressFull;
                //    quote.ShippingAddress = company.ShippingAddress.AddressFull;
                //}

                //quote.TotalAmount = 0M;
                //quote.TotalAmountBeforeTax = 0M;
                //quote.TotalTax = 0M;

                //quote.ReferenceOurs = apt.Subject;
                //quote.Message = apt.Description;
                //quote.Contact = Convert.ToString(controller.CustomContact);
                //quote.Telephone = Convert.ToString(controller.CustomTelephone);
                ////jobquote.Technition = ddlResource.Text;
                //quote.EndLoad();

                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();

                //CompleteDistribution.SalesQuote.SalesQuoteForm childForm = new CompleteDistribution.SalesQuote.SalesQuoteForm(quote, (Int64)apt.Id);
                //childForm.EnableEvents = false;
                //STD.MainForm.Instance.ShowForm(childForm);
                //childForm.EnableEvents = true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNewSalesOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                //CompleteDataLayer.SalesOrder order = (CompleteDataLayer.SalesOrder)CompleteDataLayer.SalesOrderProvider.Instance.CreateNew();
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

                //CompleteDistribution.SalesOrder.SalesOrderForm childForm = new CompleteDistribution.SalesOrder.SalesOrderForm(order, (Int64)apt.Id);
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
