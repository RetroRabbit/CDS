using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32.TaskScheduler;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;


namespace CDS.Client.Desktop.Essential.SYS
{
    public partial class ScheduledTaskList : CDS.Client.Desktop.Essential.BaseList
    {
        public ScheduledTaskList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnStart()
        {
            base.OnStart();

            //InstantFeedbackSource.DesignTimeElementType = typeof(TaskDescriptor);
            //InstantFeedbackSource.KeyExpression = "Id";
            
        }

        //protected override IQueryable GetQueryable()
        //{
        //    return GetTasks().AsQueryable<TaskDescriptor>();
        //}
         
        /// <summary>
        /// Open the Scheduled Tasks form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                string task = (GetTasks().AsQueryable<TaskDescriptor>()).Where(n => n.Id == Id).Select(n=>n.Name).FirstOrDefault();
                //http://technet.microsoft.com/en-us/library/cc766266.aspx
                //using (TaskService ts = new TaskService("\\HENKO-PC", "Henko", "HENKO-PC", "rabbit"))
                using (TaskService ts = new TaskService())
                {
                    //Microsoft.Win32.TaskScheduler.TaskEditDialog ted = new TaskEditDialog(ts.RootFolder.Tasks.FirstOrDefault(n => n.Name == task.Name));
                    //TaskSchedulerWizard wis = new TaskSchedulerWizard(ts.RootFolder.Tasks.FirstOrDefault(n => n.Name == task.Name));
                    //ted.Show();

                    Task t = ts.RootFolder.Tasks.FirstOrDefault(n => n.Name == task);

                    TaskEditDialog editorForm = new TaskEditDialog();
                    editorForm.Editable = true;
                    editorForm.Initialize(t);
                    if (editorForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ts.RootFolder.RegisterTaskDefinition(t.Name, editorForm.TaskDefinition);
                    }

                }


                //ScheduledTaskForm childForm = new ScheduledTaskForm();
                //childForm.OpenRecord(task.Name);
                //ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Scheduled Tasks Form with blank data so that a new record may be entered.
        /// </summary>
        /// <remarks>Created: Theo Crous 18/09/2012</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                //ScheduledTaskForm childForm = new ScheduledTaskForm();
                //TODO: Add Mainform refelction method call
                //ShowForm(childForm);
              //   TaskDescriptor task = new TaskDescriptor();
                //http://technet.microsoft.com/en-us/library/cc766266.aspx
                //using (TaskService ts = new TaskService("\\HENKO-PC", "Henko", "HENKO-PC", "rabbit"))
                using (TaskService ts = new TaskService())
                 {
                    TaskDefinition task= ts.NewTask();
                     TaskEditDialog editorForm = new TaskEditDialog();
                     editorForm.Editable = true;
                     editorForm.Initialize(ts, task);
                     if (editorForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                     {
                         if (editorForm.TaskName != string.Empty)
                             ts.RootFolder.RegisterTaskDefinition(editorForm.TaskName, editorForm.TaskDefinition);
                     }
                 }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>Created: Theo Crous 18/09/2012</remarks>
        private List<TaskDescriptor> GetTasks()
        {
            List<TaskDescriptor> tasks = null;

            using (TaskService ts = new TaskService("localhost",null,null,null,false))//"\\HENKO-PC", "Henko", "HENKO-PC", "rabbit"))
            {
                int id = 1;
                tasks = ts.RootFolder.Tasks.Select(n => new TaskDescriptor
                {
                    Id = id++,
                    Name = n.Name,
                    Status = n.State.ToString(),
                    Triggers = n.Definition.Triggers.ToString(),
                    NextRunTime = n.NextRunTime,
                    LastRunTime = n.LastRunTime,
                    LastRunResult = n.LastTaskResult,
                    Author = n.Definition.RegistrationInfo.Author,
                    Created = n.Definition.RegistrationInfo.Date
                }).ToList();
            }

            return tasks;
        } 

        private class TaskDescriptor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public string Triggers { get; set; }
            public DateTime NextRunTime { get; set; }
            public DateTime LastRunTime { get; set; }
            public int LastRunResult { get; set; }
            public string Author { get; set; }
            public DateTime Created { get; set; }
        }
    }
}
