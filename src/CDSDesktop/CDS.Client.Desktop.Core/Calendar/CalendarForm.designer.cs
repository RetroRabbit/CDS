namespace CDS.Client.Desktop.Core.Calendar
{
    partial class CalendarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.Calendar = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage();
            this.ServerModeSourceEmployee = new DevExpress.Data.Linq.LinqServerModeSource();
            this.itmCalendar = new DevExpress.XtraLayout.LayoutControlItem();
            this.rpgArrange = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnViewDay = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewWorkWeek = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewWeek = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewMonth = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewTimeline = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroupNone = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroupDate = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroupResource = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewWorkshopAppointment = new DevExpress.XtraBars.BarButtonItem();
            this.DateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.itmDateNavigator = new DevExpress.XtraLayout.LayoutControlItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnToday = new DevExpress.XtraBars.BarButtonItem();
            this.resourcesCheckedListBoxControl1 = new DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnNewAppointment = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewSalesAppointment = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewPurchasesAppointment = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesCheckedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.CAL_Calendar);
            this.BindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.BindingSource_AddingNew);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.resourcesCheckedListBoxControl1);
            this.LayoutControl.Controls.Add(this.DateNavigator);
            this.LayoutControl.Controls.Add(this.Calendar);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(673, 291, 250, 350);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControl.Size = new System.Drawing.Size(1206, 537);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCalendar,
            this.itmDateNavigator,
            this.layoutControlItem1});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(1206, 537);
            this.LayoutGroup.Text = "Root";
            // 
            // rpgNavigation
            // 
            this.rpgNavigation.ItemLinks.Add(this.btnToday);
            // 
            // rpHome
            // 
            this.rpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgArrange});
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnViewDay,
            this.btnViewWorkWeek,
            this.btnViewWeek,
            this.btnViewMonth,
            this.btnViewTimeline,
            this.btnNewWorkshopAppointment,
            this.btnGroupNone,
            this.btnGroupDate,
            this.btnGroupResource,
            this.barButtonItem1,
            this.btnToday,
            this.btnNewAppointment,
            this.btnNewSalesAppointment,
            this.btnNewPurchasesAppointment});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.RibbonControl.MaxItemId = 38;
            this.RibbonControl.Size = new System.Drawing.Size(1206, 155);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnNewAppointment);
            this.rpgActions.ItemLinks.Add(this.btnNewSalesAppointment);
            this.rpgActions.ItemLinks.Add(this.btnNewPurchasesAppointment);
            this.rpgActions.ItemLinks.Add(this.btnNewWorkshopAppointment);
            // 
            // DefaultToolTipController
            // 
            // 
            // 
            // 
            this.DefaultToolTipController.DefaultController.AutoPopDelay = 10000;
            this.DefaultToolTipController.DefaultController.Rounded = true;
            this.DefaultToolTipController.DefaultController.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7;
            this.DefaultToolTipController.DefaultController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // Calendar
            // 
            this.Calendar.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            this.Calendar.Location = new System.Drawing.Point(12, 12);
            this.Calendar.MenuManager = this.RibbonControl;
            this.Calendar.Name = "Calendar";
            this.Calendar.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.Calendar.Size = new System.Drawing.Size(1000, 513);
            this.Calendar.Start = new System.DateTime(2012, 3, 26, 0, 0, 0, 0);
            this.Calendar.Storage = this.schedulerStorage1;
            this.Calendar.TabIndex = 4;
            this.Calendar.Text = "schedulerControl1";
            this.Calendar.Views.DayView.TimeRulers.Add(timeRuler1);
            this.Calendar.Views.FullWeekView.Enabled = true;
            this.Calendar.Views.GanttView.Enabled = false;
            this.Calendar.Views.WeekView.Enabled = false;
            this.Calendar.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.Calendar.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.Calendar_PopupMenuShowing);
            this.Calendar.InitNewAppointment += new DevExpress.XtraScheduler.AppointmentEventHandler(this.Calendar_InitNewAppointment);
            this.Calendar.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.Calendar_EditAppointmentFormShowing);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("EntityId", "EntityId"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CreatedBy", "CreatedBy"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("CreatedOn", "CreatedOn"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ModifiedBy", "ModifiedBy"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ModifiedOn", "ModifiedOn"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Mileage", "Mileage"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Registration", "Registration"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Vehicle", "Vehicle"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Contact", "Contact"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Telephone", "Telephone"));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("DocumentId", "DocumentId"));
            this.schedulerStorage1.Appointments.DataSource = this.BindingSource;
            this.schedulerStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))), "Appointment", "&Appointment"));
            this.schedulerStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), "Sales Appointment", "&Sales Appointment"));
            this.schedulerStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192))))), "Purchases Appointment", "&Purchases Appointment"));
            this.schedulerStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))), "Workshop Appointment", "&Workshop Appointment"));
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.AppointmentId = "Id";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "LabelId";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.PercentComplete = "PercentComplete";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "StatusId";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "TypeId";
            this.schedulerStorage1.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("Fullname", "Fullname"));
            this.schedulerStorage1.Resources.DataSource = this.ServerModeSourceEmployee;
            this.schedulerStorage1.Resources.Mappings.Caption = "Fullname";
            this.schedulerStorage1.Resources.Mappings.Id = "Id";
            this.schedulerStorage1.Resources.Mappings.ParentId = "RoleId";
            this.schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsInserted);
            this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
            this.schedulerStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsDeleted);
            // 
            // ServerModeSourceEmployee
            // 
            this.ServerModeSourceEmployee.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Employee);
            this.ServerModeSourceEmployee.KeyExpression = "Id";
            // 
            // itmCalendar
            // 
            this.itmCalendar.Control = this.Calendar;
            this.itmCalendar.CustomizationFormText = "Calendar";
            this.itmCalendar.Location = new System.Drawing.Point(0, 0);
            this.itmCalendar.Name = "itmCalendar";
            this.itmCalendar.Size = new System.Drawing.Size(1004, 517);
            this.itmCalendar.Text = "Calendar";
            this.itmCalendar.TextSize = new System.Drawing.Size(0, 0);
            this.itmCalendar.TextVisible = false;
            // 
            // rpgArrange
            // 
            this.rpgArrange.ItemLinks.Add(this.btnViewDay);
            this.rpgArrange.ItemLinks.Add(this.btnViewWorkWeek);
            this.rpgArrange.ItemLinks.Add(this.btnViewWeek);
            this.rpgArrange.ItemLinks.Add(this.btnViewMonth);
            this.rpgArrange.ItemLinks.Add(this.btnViewTimeline);
            this.rpgArrange.ItemLinks.Add(this.btnGroupNone, true);
            this.rpgArrange.ItemLinks.Add(this.btnGroupDate);
            this.rpgArrange.ItemLinks.Add(this.btnGroupResource);
            this.rpgArrange.Name = "rpgArrange";
            this.rpgArrange.ShowCaptionButton = false;
            this.rpgArrange.Text = "Arrange";
            // 
            // btnViewDay
            // 
            this.btnViewDay.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnViewDay.Caption = "Day";
            this.btnViewDay.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_1_16;
            this.btnViewDay.GroupIndex = 1;
            this.btnViewDay.Id = 22;
            this.btnViewDay.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_1_32;
            this.btnViewDay.Name = "btnViewDay";
            this.btnViewDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewDay_ItemClick);
            // 
            // btnViewWorkWeek
            // 
            this.btnViewWorkWeek.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnViewWorkWeek.Caption = "Work Week";
            this.btnViewWorkWeek.Down = true;
            this.btnViewWorkWeek.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_5_16;
            this.btnViewWorkWeek.GroupIndex = 1;
            this.btnViewWorkWeek.Id = 23;
            this.btnViewWorkWeek.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_5_32;
            this.btnViewWorkWeek.Name = "btnViewWorkWeek";
            this.btnViewWorkWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewWorkWeek_ItemClick);
            // 
            // btnViewWeek
            // 
            this.btnViewWeek.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnViewWeek.Caption = "Week";
            this.btnViewWeek.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_7_16;
            this.btnViewWeek.GroupIndex = 1;
            this.btnViewWeek.Id = 24;
            this.btnViewWeek.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_7_32;
            this.btnViewWeek.Name = "btnViewWeek";
            this.btnViewWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewWeek_ItemClick);
            // 
            // btnViewMonth
            // 
            this.btnViewMonth.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnViewMonth.Caption = "Month";
            this.btnViewMonth.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_31_16;
            this.btnViewMonth.GroupIndex = 1;
            this.btnViewMonth.Id = 25;
            this.btnViewMonth.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.calendar_31_32;
            this.btnViewMonth.Name = "btnViewMonth";
            this.btnViewMonth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewMonth_ItemClick);
            // 
            // btnViewTimeline
            // 
            this.btnViewTimeline.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnViewTimeline.Caption = "Timeline";
            this.btnViewTimeline.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.clock_16;
            this.btnViewTimeline.GroupIndex = 1;
            this.btnViewTimeline.Id = 26;
            this.btnViewTimeline.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.clock_32;
            this.btnViewTimeline.Name = "btnViewTimeline";
            this.btnViewTimeline.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewTimeline_ItemClick);
            // 
            // btnGroupNone
            // 
            this.btnGroupNone.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnGroupNone.Caption = "No Grouping";
            this.btnGroupNone.Down = true;
            this.btnGroupNone.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.delete_16;
            this.btnGroupNone.GroupIndex = 2;
            this.btnGroupNone.Id = 30;
            this.btnGroupNone.Name = "btnGroupNone";
            this.btnGroupNone.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroupNone_ItemClick);
            // 
            // btnGroupDate
            // 
            this.btnGroupDate.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnGroupDate.Caption = "Group By Date";
            this.btnGroupDate.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_16;
            this.btnGroupDate.GroupIndex = 2;
            this.btnGroupDate.Id = 31;
            this.btnGroupDate.Name = "btnGroupDate";
            this.btnGroupDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroupDate_ItemClick);
            // 
            // btnGroupResource
            // 
            this.btnGroupResource.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnGroupResource.Caption = "Group By Resource";
            this.btnGroupResource.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.businessman2_16;
            this.btnGroupResource.GroupIndex = 2;
            this.btnGroupResource.Id = 32;
            this.btnGroupResource.Name = "btnGroupResource";
            this.btnGroupResource.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroupResource_ItemClick);
            // 
            // btnNewWorkshopAppointment
            // 
            this.btnNewWorkshopAppointment.Caption = "New Workshop Appointment";
            this.btnNewWorkshopAppointment.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_16;
            this.btnNewWorkshopAppointment.Id = 29;
            this.btnNewWorkshopAppointment.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_32;
            this.btnNewWorkshopAppointment.Name = "btnNewWorkshopAppointment";
            this.btnNewWorkshopAppointment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnNewWorkshopAppointment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewWorkshopAppointment_ItemClick);
            // 
            // DateNavigator
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this.DateNavigator, DevExpress.Utils.DefaultBoolean.Default);
            this.DateNavigator.HighlightTodayCell = DevExpress.Utils.DefaultBoolean.Default;
            this.DateNavigator.HotDate = null;
            this.DateNavigator.Location = new System.Drawing.Point(1016, 174);
            this.DateNavigator.Name = "DateNavigator";
            this.DateNavigator.SchedulerControl = this.Calendar;
            this.DateNavigator.Size = new System.Drawing.Size(178, 351);
            this.DateNavigator.TabIndex = 6;
            // 
            // itmDateNavigator
            // 
            this.itmDateNavigator.Control = this.DateNavigator;
            this.itmDateNavigator.CustomizationFormText = "Date Navigator";
            this.itmDateNavigator.Location = new System.Drawing.Point(1004, 162);
            this.itmDateNavigator.MaxSize = new System.Drawing.Size(182, 0);
            this.itmDateNavigator.MinSize = new System.Drawing.Size(182, 24);
            this.itmDateNavigator.Name = "itmDateNavigator";
            this.itmDateNavigator.Size = new System.Drawing.Size(182, 355);
            this.itmDateNavigator.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.itmDateNavigator.Text = "Date Navigator";
            this.itmDateNavigator.TextSize = new System.Drawing.Size(0, 0);
            this.itmDateNavigator.TextVisible = false;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 33;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnToday
            // 
            this.btnToday.Caption = "Today";
            this.btnToday.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.sun_16;
            this.btnToday.Id = 34;
            this.btnToday.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.sun_32;
            this.btnToday.Name = "btnToday";
            this.btnToday.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnToday_ItemClick);
            // 
            // resourcesCheckedListBoxControl1
            // 
            this.resourcesCheckedListBoxControl1.Location = new System.Drawing.Point(1016, 12);
            this.resourcesCheckedListBoxControl1.Name = "resourcesCheckedListBoxControl1";
            this.resourcesCheckedListBoxControl1.SchedulerControl = this.Calendar;
            this.resourcesCheckedListBoxControl1.Size = new System.Drawing.Size(178, 158);
            this.resourcesCheckedListBoxControl1.StyleController = this.LayoutControl;
            this.resourcesCheckedListBoxControl1.TabIndex = 7;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.resourcesCheckedListBoxControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(1004, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(182, 162);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnNewAppointment
            // 
            this.btnNewAppointment.Caption = "New \r\nAppointment";
            this.btnNewAppointment.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_16;
            this.btnNewAppointment.Id = 35;
            this.btnNewAppointment.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_32;
            this.btnNewAppointment.Name = "btnNewAppointment";
            this.btnNewAppointment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnNewAppointment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewAppointment_ItemClick);
            // 
            // btnNewSalesAppointment
            // 
            this.btnNewSalesAppointment.Caption = "New Sales Appointment";
            this.btnNewSalesAppointment.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_16;
            this.btnNewSalesAppointment.Id = 36;
            this.btnNewSalesAppointment.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_32;
            this.btnNewSalesAppointment.Name = "btnNewSalesAppointment";
            this.btnNewSalesAppointment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnNewSalesAppointment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewSalesAppointment_ItemClick);
            // 
            // btnNewPurchasesAppointment
            // 
            this.btnNewPurchasesAppointment.Caption = "New Purchases Appointment";
            this.btnNewPurchasesAppointment.Glyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_16;
            this.btnNewPurchasesAppointment.Id = 37;
            this.btnNewPurchasesAppointment.LargeGlyph = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_32;
            this.btnNewPurchasesAppointment.Name = "btnNewPurchasesAppointment";
            this.btnNewPurchasesAppointment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnNewPurchasesAppointment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewPurchasesAppointment_ItemClick);
            // 
            // CalendarForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AllowSave = false;
            this.AllowSaveAndClose = false;
            this.AllowSaveAndNew = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1206, 692);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "CalendarForm";
            this.SuperTipParameter = "calender,calender";
            this.TabIcon = global::CDS.Client.Desktop.Core.Properties.Resources.date_time_16;
            this.Text = "Calendar";
            this.WaitFormNewRecordDescription = "Creating new calender...";
            this.WaitFormOpenRecordDescription = "Opening calender...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesCheckedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl Calendar;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraLayout.LayoutControlItem itmCalendar;
        private DevExpress.XtraBars.BarButtonItem btnViewDay;
        private DevExpress.XtraBars.BarButtonItem btnViewWorkWeek;
        private DevExpress.XtraBars.BarButtonItem btnViewWeek;
        private DevExpress.XtraBars.BarButtonItem btnViewMonth;
        private DevExpress.XtraBars.BarButtonItem btnViewTimeline;
        private DevExpress.XtraBars.BarButtonItem btnNewWorkshopAppointment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgArrange;
        private DevExpress.XtraScheduler.DateNavigator DateNavigator;
        private DevExpress.XtraLayout.LayoutControlItem itmDateNavigator;
        private DevExpress.XtraBars.BarButtonItem btnGroupNone;
        private DevExpress.XtraBars.BarButtonItem btnGroupDate;
        private DevExpress.XtraBars.BarButtonItem btnGroupResource;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnToday;
        private DevExpress.XtraScheduler.UI.ResourcesCheckedListBoxControl resourcesCheckedListBoxControl1;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem btnNewAppointment;
        private DevExpress.XtraBars.BarButtonItem btnNewSalesAppointment;
        private DevExpress.XtraBars.BarButtonItem btnNewPurchasesAppointment;
    }
}
