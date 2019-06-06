using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Services;
using System.Transactions;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Calendar
{
    public partial class CalendarForm : CDS.Client.Desktop.Essential.BaseForm
    {
        private List<DB.CAL_Calendar> calendar = null;
        private int defaultlabel = 0;
        long? defaultSiteId;

        public CalendarForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                AllowArchive = false;
                if (DataContext.EntityHumanResourcesContext.HRS_Employee.Any(n => n.PersonId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId))
                {
                    var currentRole = DataContext.EntityHumanResourcesContext.HRS_Employee.FirstOrDefault(n => n.PersonId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId).RoleId;
                    var roleAccess = DataContext.EntityHumanResourcesContext.HRS_Role.FirstOrDefault(n => n.Id == currentRole);

                    ServerModeSourceEmployee.QueryableSource = DataContext.ReadonlyContext.VW_Employee.Where(n => n.Id == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId);

                    btnNewAppointment.Visibility = roleAccess.Appointment.Value ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    btnNewPurchasesAppointment.Visibility = roleAccess.PurchaseAppointment.Value ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    btnNewSalesAppointment.Visibility = roleAccess.SaleAppointment.Value ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    btnNewWorkshopAppointment.Visibility = roleAccess.WorkshopAppointment.Value ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;


                }
                //var asd = DataContext.ReadonlyContext.VW_Employee.Where(n => rloids.Contains(n.RoleId)).ToList();
                //select by SiteId
                List<long?> companies = DataContext.EntityOrganisationContext.ORG_Company.Where(n => n.SiteId == defaultSiteId).Select(n => n.EntityId).ToList().ConvertAll(a => (long?)a);
                List<long?> companyEntities = DataContext.EntityOrganisationContext.ORG_Entity.Where(n => companies.Contains(n.Id)).Select(n => n.EntityId).ToList().ConvertAll(a => (long?)a);
                calendar = DataContext.EntityCalendarContext.CAL_Calendar.Where(n => companyEntities.Contains(n.EntityId)).ToList();
                BindingSource.DataSource = calendar;

                IDateTimeNavigationService service = Calendar.GetService(typeof(IDateTimeNavigationService)) as IDateTimeNavigationService;
                if (service != null)
                    service.GoToToday();

                Calendar.DayView.TopRowTime = new TimeSpan(DateTime.Now.TimeOfDay.Hours, 00, 00);
                Calendar.WorkWeekView.TopRowTime = new TimeSpan(DateTime.Now.TimeOfDay.Hours, 00, 00);

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void RefreshData()
        {
            try
            {
                calendar = DataContext.EntityCalendarContext.CAL_Calendar.ToList();
                Calendar.RefreshData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnViewDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnViewWorkWeek_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnViewWeek_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.FullWeek;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnViewMonth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnViewTimeline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            try
            {
                foreach (Appointment apt in e.Objects)
                {
                    DB.CAL_Calendar o = apt.GetSourceObject((SchedulerStorage)sender) as DB.CAL_Calendar;
                    if (o != null)
                    {
                        try
                        {
                            using (TransactionScope transaction = DataContext.GetTransactionScope())
                            {
                                // DB.CAL_CalendarDataProvider.Instance.Save(o);
                                DataContext.SaveChangesEntityCalendarContext();
                                RefreshData();
                                DataContext.CompleteTransaction(transaction);
                            }
                            DataContext.EntityCalendarContext.AcceptAllChanges();
                        }
                        catch (Exception ex)
                        {
                            DataContext.EntityCalendarContext.RejectChanges();
                            HasErrors = true;
                            if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void schedulerStorage1_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            try
            {
                foreach (Appointment apt in e.Objects)
                {
                    DB.CAL_Calendar o = apt.GetSourceObject((SchedulerStorage)sender) as DB.CAL_Calendar;
                    if (o != null)
                    {
                        try
                        {
                            using (TransactionScope transaction = DataContext.GetTransactionScope())
                            {
                                BL.EntityController.SaveCAL_Calendar(o, DataContext);
                                DataContext.SaveChangesEntityCalendarContext();
                                schedulerStorage1.SetAppointmentId(apt, o.Id);
                                RefreshData();
                                DataContext.CompleteTransaction(transaction);
                            }
                            DataContext.EntityCalendarContext.AcceptAllChanges();
                        }
                        catch (Exception ex)
                        {
                            DataContext.EntityCalendarContext.RejectChanges();
                            HasErrors = true;
                            if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnGroupNone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.None;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnGroupDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Date;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnGroupResource_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Calendar.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Show the print preview form for the LayoutControl.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnPrintPreview()
        {
            try
            {
                Calendar.ShowPrintPreview();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Print the current layout and values in the LayoutControl.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnPrint()
        {
            try
            {
                Calendar.Print();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();
                IDateTimeNavigationService service = Calendar.GetService(typeof(IDateTimeNavigationService)) as IDateTimeNavigationService;
                if (service != null)
                    service.NavigateForward();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();
                IDateTimeNavigationService service = Calendar.GetService(typeof(IDateTimeNavigationService)) as IDateTimeNavigationService;
                if (service != null)
                    service.NavigateBackward();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnToday_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                IDateTimeNavigationService service = Calendar.GetService(typeof(IDateTimeNavigationService)) as IDateTimeNavigationService;
                if (service != null)
                    service.GoToToday();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void BindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                e.NewObject = BL.CAL.CAL_Calendar.New;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNewAppointment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                defaultlabel = 0;
                Calendar.CreateNewAppointment();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNewSalesAppointment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                defaultlabel = 1;
                Calendar.CreateNewAppointment();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNewPurchasesAppointment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                defaultlabel = 2;
                Calendar.CreateNewAppointment();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNewWorkshopAppointment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                defaultlabel = 3;
                Calendar.CreateNewAppointment();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void Calendar_InitNewAppointment(object sender, AppointmentEventArgs e)
        {
            try
            {
                e.Appointment.LabelId = defaultlabel;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            try
            {

                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        foreach (Appointment apt in e.Objects)
                        {
                            Int64 calenderId = Convert.ToInt64(apt.Id);
                            if (calenderId > 0)
                            {
                                DataContext.EntityCalendarContext.CAL_Attachment.RemoveRange(DataContext.EntityCalendarContext.CAL_Attachment.Where(n => n.CalendarId == calenderId));
                                DataContext.EntityCalendarContext.CAL_Calendar.Remove(DataContext.EntityCalendarContext.CAL_Calendar.FirstOrDefault(n => n.Id == calenderId));
                                DataContext.SaveChangesEntityCalendarContext();
                            }
                        }

                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntityCalendarContext.AcceptAllChanges();
                }
                catch (Exception ex)
                {
                    DataContext.EntityCalendarContext.RejectChanges();
                    HasErrors = true;
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
                RefreshData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void Calendar_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.Id == DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.EditSeries);
            }

        }

        private void Calendar_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
          try
          {
              Appointment apt = e.Appointment;
              bool openRecurrenceForm = apt.IsRecurring && schedulerStorage1.Appointments.IsNewAppointment(apt);
              AppointmentDialogue f;
              // Check type of appointment - and open correct form acccordingly.
              if (apt.LabelId == 1) //	Sales Appointment
              {
                  f = new SalesAppointmentDialogue((SchedulerControl)sender, apt, openRecurrenceForm);
              }
              else if (apt.LabelId == 2) //	Purchasing Appointment
              {
                  f = new PurchasesAppointmentDialogue((SchedulerControl)sender, apt, openRecurrenceForm);
              }
              else if (apt.LabelId == 3) //	Workshop Appointment
              {
                  f = new WorkshopAppointmentDialogue((SchedulerControl)sender, apt, openRecurrenceForm);
              }
              else
              {
                  f = new AppointmentDialogue((SchedulerControl)sender, apt, openRecurrenceForm);
              }
              e.DialogResult = f.ShowDialog();
              e.Handled = true;
              defaultlabel = 0;
          
              if (apt.Type == AppointmentType.Pattern && Calendar.SelectedAppointments.Contains(apt))
                  Calendar.SelectedAppointments.Remove(apt);
          
              Calendar.Refresh();
          }
          catch (Exception ex)
          {
              if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
          
          } 

        }
         

    }
}