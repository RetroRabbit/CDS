using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using System.Linq;
using System.Reflection;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Runtime.InteropServices;


namespace CDS.Client.Desktop.Essential
{
    public partial class Base : DevExpress.XtraBars.Ribbon.RibbonForm, CDS.Client.Desktop.Essential.UTL.ITabbedForm
    {
        private BL.DataContext dataContext;
        private String superTipParameter;
        private Image tabIcon = null;
        private Image tabIconBackup = null;

        /// <summary>
        /// Werner: What is this used for? - Henko
        /// </summary>
        public bool IsClosing { get; set; }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        /// <remarks>Created: Werner Scheffer ??/??/2014</remarks>
        public BL.DataContext DataContext
        {
            get
            {
                if (dataContext == null)
                    dataContext = new BL.DataContext();

                return dataContext;
            }
        }

        /// <summary>
        /// Werner: What is this for? - Henko
        /// </summary>
        /// <remarks>Created: Werner Scheffer ??/??/2014</remarks>
        public bool CtrlPressed { get; set; }

        /// <summary>
        /// Returns the icon image that must be used for the tab in the main form. Override the TabIcon in child forms to provide different images.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        [Category("Tab Icon")]
        [BrowsableAttribute(true)]
        public Image TabIcon
        {
            get
            {
                return tabIcon;
            }
            set
            {
                tabIcon = value;
                if (TabIconBackup == null)
                    TabIconBackup = tabIcon;
            }
        }

        [Category("Tab Icon")]
        [BrowsableAttribute(true)]
        public Image TabIconBackup
        {
            get
            {
                return tabIconBackup;
            }
            set
            {
                tabIconBackup = value;
            }
        }

        /// <summary>
        /// Sets the forms supertip parameter value
        /// </summary>
        /// <remarks>Created: Werner Scheffer 20/09/2013</remarks>
        [Category("Tooltip")]  
        [BrowsableAttribute(true)]
        public String SuperTipParameter
        {
            get { return superTipParameter; }
            set
            {
                try
                {
                    //DevExpress.XtraBars.BarButtonItem
                    foreach (var button in RibbonControl.Items)
                    {
                        if (button is DevExpress.XtraBars.BarButtonItem)
                        {
                            if (((DevExpress.XtraBars.BarButtonItem)button).SuperTip != null)
                            {
                                foreach (var item in ((DevExpress.XtraBars.BarButtonItem)button).SuperTip.Items)
                                {
                                    if (item is DevExpress.Utils.ToolTipItem)
                                    {
                                        List<String> values = value.Split(',').ToList();
                                        if (values.Count == 0)
                                        {
                                            values.Add("");
                                            values.Add("");
                                        }
                                        if (values.Count == 1)
                                        {
                                            values.Add(values[0] + "s");
                                        }

                                        if (!this.DesignMode)
                                        {
                                            ((DevExpress.Utils.ToolTipItem)item).Text = string.Format(((DevExpress.Utils.ToolTipItem)item).Text, values.ToArray());
                                        }
                                        superTipParameter = value;

                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }

        /// <summary>
        /// Sets whether or not the Print buttons is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 09/10/2013</remarks>
        [BrowsableAttribute(true)]
        public bool AllowPrintPreview
        {
            get
            {
                return this.btnPrintPreview.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnPrintPreview.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        } 

        /// <summary>
        /// Sets whether or not the Export buttons are displayed for this form.
        /// </summary>
        /// <remarks>Created: Theo Crous 02/04/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowExport
        {
            get
            {
                return this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnExportToCsv.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnExportToExcel.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnExportToHtml.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnExportToPdf.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnExportToRtf.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnExportToText.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.rpgExport.Visible = (value);
            }
        }

        /// <summary>
        /// Sets whether or not the Export to Csv button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner  21/10/2014</remarks>
        [BrowsableAttribute(true)]
        public bool AllowExportToCsv
        {
            get
            {
                return this.btnExportToCsv.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnExportToCsv.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                //If all the buttons are diabled
                if (this.btnExportToCsv.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToHtml.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToPdf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToRtf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    this.rpgExport.Visible = false;
                }
                else
                {
                    this.rpgExport.Visible = true;
                }

            }
        }

        /// <summary>
        /// Sets whether or not the Export to Excel button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner  21/10/2014</remarks>
        [BrowsableAttribute(true)]
        public bool AllowExportToExcel
        {
            get
            {
                return this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnExportToExcel.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                //If all the buttons are diabled
                if (this.btnExportToCsv.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToHtml.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToPdf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToRtf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    this.rpgExport.Visible = false;
                }
                else
                {
                    this.rpgExport.Visible = true;
                }

            }
        }

        /// <summary>
        /// Sets whether or not the Export to Html button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner  21/10/2014</remarks>
        [BrowsableAttribute(true)]
        public bool AllowExportToHtml
        {
            get
            {
                return this.btnExportToHtml.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnExportToHtml.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                //If all the buttons are diabled
                if (this.btnExportToCsv.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToHtml.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToPdf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToRtf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    this.rpgExport.Visible = false;
                }
                else
                {
                    this.rpgExport.Visible = true;
                }

            }
        }

        /// <summary>
        /// Sets whether or not the Export to Pdf button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner  21/10/2014</remarks>
        [BrowsableAttribute(true)]
        public bool AllowExportToPdf
        {
            get
            {
                return this.btnExportToPdf.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnExportToPdf.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                //If all the buttons are diabled
                if (this.btnExportToCsv.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToHtml.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToPdf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToRtf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    this.rpgExport.Visible = false;
                }
                else
                {
                    this.rpgExport.Visible = true;
                }

            }
        }

        /// <summary>
        /// Sets whether or not the Export to Rtf button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner  21/10/2014</remarks>
        [BrowsableAttribute(true)]
        public bool AllowExportToRtf
        {
            get
            {
                return this.btnExportToRtf.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnExportToRtf.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                //If all the buttons are diabled
                if (this.btnExportToCsv.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToHtml.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToPdf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToRtf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    this.rpgExport.Visible = false;
                }
                else
                {
                    this.rpgExport.Visible = true;
                }

            }
        }

        /// <summary>
        /// Sets whether or not the Export to Text button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner  21/10/2014</remarks>
        [BrowsableAttribute(true)]
        public bool AllowExportToText
        {
            get
            {
                return this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnExportToText.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                //If all the buttons are diabled
                if (this.btnExportToCsv.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToExcel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToHtml.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToRtf.Visibility == DevExpress.XtraBars.BarItemVisibility.Never
                    && this.btnExportToText.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    this.rpgExport.Visible = false;
                }
                else
                {
                    this.rpgExport.Visible = true;
                }

            }
        }

        /// <summary>
        /// Provides a user selected file path based on a preselected file format. Used for getting the export file path by all inheriting forms.
        /// </summary>
        /// <param name="filter">The file filter that must be provided. See the example for the string format.</param>
        /// <example>GetExportFilePath("Excel Files|*.xlsx")</example>
        /// <returns>A full file path result is provided indicating the file path the use has selected from the dialogue window.</returns>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected string GetExportFilePath(string filter)
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = filter + "|All Files|*.*";
                diag.CheckPathExists = true;
                diag.FileName = string.Format("{0} - {1:yyyy-MM-dd}", this.Text, DateTime.Now);
                if (diag.ShowDialog() == DialogResult.OK)
                    return diag.FileName;
                else
                    return null;
            }
        }

        /// <summary>
        /// Provides a user selected pat. Used for getting the export path by all inheriting forms.
        /// </summary>
        /// <returns>A full file path result is provided indicating the file path the use has selected from the dialogue window.</returns>
        /// <remarks>Created: Werner Scheffer 18/02/2012</remarks>
        protected string GetExportFolderPath()
        {
            using (FolderBrowserDialog diag = new FolderBrowserDialog())
            {
                if (diag.ShowDialog() == DialogResult.OK)
                    return diag.SelectedPath;
                else
                    return null;
            }
        }

        /// <summary>
        /// Will handle the keypress of certain shortcuts
        /// </summary>
        /// <param name="crtlPressed"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <remarks>Created: Werner  14/11/2014</remarks>
        public virtual bool HandleShortcut(IntPtr key)
        {
            //This means that Ctrl Has been pressed and no other button has been press after to handel it
            if (CtrlPressed)
                return false;

            //Flags Ctrl as pressed
            if (key == (IntPtr)17)
            {
                CtrlPressed = true;
                //return true;    // indicate that you handled this keystroke
                return true;
            }
            return false;
        }

        public Base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is called after the form has been initialised and should be overridden in all inheriting forms to handle data binding etc.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnStart()
        {
        }

        /// <summary>
        /// This method is called after the form has been initialised and should be overridden in all inheriting forms to handle data binding etc.
        /// </summary>
        /// <remarks>Created: Henko Rabie 20/01/2015</remarks>
        protected virtual void BindData()
        {

        }

        /// <summary>
        /// This method will apply access security
        /// </summary>
        /// <remarks>Created: Werner Scheffer 07/03/2014</remarks>
        protected virtual void ApplySecurity()
        {
            //AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INST01);
            //Werner: Added this so that we can be sure that we always ApplySecurity()
            //throw new Exception("Need to Apply Security for this form. If you have remove the base.ApplySecurity()");
        }  
        //public void SetRibbonButtonVisible(DevExpress.XtraBars.BarItem button, bool visable)
        //{

        //    button.Visibility = (visable) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

        //   bool VisibleAll = false;
        //   foreach (DevExpress.XtraBars.BarItemLink itemLink in button.Links)
        //   {
        //       if (IsVisible(itemLink))
        //       {
        //           VisibleAll = true;
        //           continue;
        //       }
        //   }

        //    //TODO: Need to find a way to get to the RibbonPageGroup
        //   if (!VisibleAll)
        //       //(sender as RibbonPageGroupItemLinkCollection).PageGroup.Visible = VisibleAll;
        //}

        /// <summary>
        /// This method is called when the user clicks on the Print Preview button and should be overridden in all inheriting forms to handle showing the preview.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnPrintPreview()
        {
        }

        /// <summary>
        /// This method is called when the user clicks on the Export to Excel button and should be overridden in all inheriting forms to handle the export.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnExportToExcel()
        {
        }

        /// <summary>
        /// This method is called when the user clicks on the Export to Pdf button and should be overridden in all inheriting forms to handle the export.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnExportToPDF()
        {
        }

        /// <summary>
        /// This method is called when the user clicks on the Export to Text button and should be overridden in all inheriting forms to handle the export.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnExportToText()
        {
        }

        /// <summary>
        /// This method is called when the user clicks on the Export to Rtf button and should be overridden in all inheriting forms to handle the export.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnExportToRTF()
        {
        }

        /// <summary>
        /// This method is called when the user clicks on the Export to Html button and should be overridden in all inheriting forms to handle the export.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnExportToHTML()
        {
        }

        /// <summary>
        /// This method is called when the user clicks on the Export to Csv button and should be overridden in all inheriting forms to handle the export.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnExportToCSV()
        {
        }

        /// <summary>
        /// This method is called when the user changes the selected Ribbon Page.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 27/11/2015</remarks>
        public virtual void OnRibbonPageChanged(object sender)
        { 
        }

        /// <summary>
        /// Werner: What is this used for? - Henko
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            IsClosing = true;
        }

        /// <summary>
        /// This method is called when the user clicks on the Print button and should be overridden in all inheriting forms to handle printing the form.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OnPrint()
        {
        }

        /// <summary>
        /// This method is called to show a form in the MainForm as a MDIChildform
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Henko Rabie 15/10/2013</remarks>
        /// <param name="form">DevExpress Form to show</param>
        public void ShowForm(DevExpress.XtraEditors.XtraForm form)
        {
            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                var mainform = Application.OpenForms["MainForm"];
                Type typExternal = mainform.GetType();
                MethodInfo methodInf = typExternal.GetMethod("ShowForm");

                methodInf.Invoke(mainform, new object[] { form });
            }
        }

        /// <summary>
        /// This method is called to show a message on the MainForm Status Bar
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Werner Scheffer 25/03/2014</remarks>
        /// <param name="form">DevExpress Form to show</param>
        public void ShowMessage(string message, Int64 milliseconds)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowMessage");

            methodInf.Invoke(mainform, new object[] { message, milliseconds });
        }

        /// <summary>
        /// This method is called to show a message on the MainForm
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Werner Scheffer 25/03/2014</remarks>
        /// <param name="form">DevExpress Form to show</param>
        public void ShowNotification(String title, String message, int showTime, bool longText, Image image)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowNotification");

            methodInf.Invoke(mainform, new object[] { title, message, showTime, longText, image });
        }

        /// <summary>
        /// Call this method to Open an existing document.
        /// This method is called to show a form in the MainForm as a MDIChildform
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <param name="id">Primary key of the document you want to open.</param>
        /// <param name="typeId">Document type that you are opening.</param>
        /// <remarks>Created: Henko Rabie 15/10/2013</remarks>
        public void ShowDocumentForm(Int64 id, byte typeId)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowDocumentForm", new Type[] { typeof(Int64), typeof(byte) });

            methodInf.Invoke(mainform, new object[] { id, typeId });
        }

        /// <summary>
        /// Call this method to open a New Generated document.
        /// This method is called to show a form in the MainForm as a MDIChildform
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <param name="header">Newly generated SYS_DOC_Header of document you are opening.</param>
        /// <remarks>Created: Henko Rabie 15/10/2013</remarks>
        public void ShowDocumentForm(DB.SYS_DOC_Header header)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowDocumentForm", new Type[] { typeof(DB.SYS_DOC_Header) });

            methodInf.Invoke(mainform, new object[] { header });
        }

        /// <summary>
        /// This method is called to show a list of Documents in the MainForm with the give TrackId
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Werner Scheffer 11/11/2014</remarks>
        /// <param name="form">DevExpress Form to show</param> 
        public void ShowDocumentListForm(BL.SYS.SYS_DOC_Type? type, Int64 trackId)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowDocumentListForm");

            methodInf.Invoke(mainform, new object[] { type, trackId });
        }

        /// <summary>
        /// This method is called to show a form in the MainForm as a MDIChildform
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Werner Scheffer 06/11/2014</remarks>
        /// <param name="form">DevExpress Form to show</param> 
        public void ShowCatalogueForm(DB.VW_Company entity, CDS.Client.BusinessLayer.ORG.ORG_Type type, BaseForm form)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowCatalogueForm");

            methodInf.Invoke(mainform, new object[] { entity, type, form });
        }

        public void ShowReport(Int64 reportId, DevExpress.XtraReports.Parameters.ParameterCollection parameters)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowReport", new Type[] { typeof(Int64), typeof(DevExpress.XtraReports.Parameters.ParameterCollection) });

            methodInf.Invoke(mainform, new object[] { reportId, parameters });
        }

        public void ShowReport(String reportName, DevExpress.XtraReports.Parameters.ParameterCollection parameters)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowReport", new Type[] { typeof(string), typeof(DevExpress.XtraReports.Parameters.ParameterCollection) });

            methodInf.Invoke(mainform, new object[] { reportName, parameters });
        }  

        /// <summary>
        /// This method is called to add and item to a document form in the MainForm
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Werner Scheffer 06/11/2014</remarks>
        /// <param name="form">DevExpress Form to add item to</param> 
        /// <param name="itemId">ID of the Entity Item to add</param>
        public void AddCatalogueItemToDocument(BaseForm form, Int64 entityId)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("AddCatalogueItemToDocument");

            methodInf.Invoke(mainform, new object[] { form, entityId });
        }

        /// <summary>
        /// This method is called to change the description text for the active WaitForm
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Werner Scheffer 25/03/2014</remarks>
        /// <param name="form">DevExpress Form to show</param>
        public void SetWaitFormDescription(String description)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("SetWaitFormDescription");

            methodInf.Invoke(mainform, new object[] { description });
        }

        /// <summary>
        /// This method is called to Show/Hide the MDIChild in the MainForm
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Werner Scheffer 06/11/2014</remarks>
        /// <param name="visible">Visible State of the form</param>
        public void HideForm(bool shouldHide)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("HideForm");

            methodInf.Invoke(mainform, new object[] { this, shouldHide });
        }

        /// <summary>
        /// Will open the email dialogue with the report attached
        /// </summary>
        /// <param name="reportTemplate">The report template type</param>
        /// <param name="id">The Id for the report object data</param>
        public void OpenEmailDialogue(BaseForm.ReportTemplateType reportTemplate, long id, string filename)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("OpenEmailDialogue");

            methodInf.Invoke(mainform, new object[] { reportTemplate, id, filename });
        }

        /// <summary>
        /// This method is called when the user clicks on the Help button.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 29/10/2013</remarks>
        private void OnHelp()
        {
            this.Cursor = Cursors.Help;
        }

        private void Base_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.XPOPreBindDataFilter();
                this.OnStart();
                this.BindData();
                this.XPOPostBindDataFilter();
                this.ApplySecurity(); 
            }
        }

      
        protected virtual void XPOPreBindDataFilter() { }

        protected virtual void XPOPostBindDataFilter() { }

        /// <summary>
        /// Sets the IsClosing flag to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Base_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsClosing = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private bool IsVisible(DevExpress.XtraBars.BarItemLink itemLink)
        {
            return (itemLink.Item.Visibility == DevExpress.XtraBars.BarItemVisibility.Always || itemLink.Item.Visibility == DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime) && itemLink.Visible;
        }

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnHelp();
        }

        private void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnPrintPreview();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnPrint();
        }

        private void btnExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnExportToExcel();
        }

        private void btnExportToPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnExportToPDF();
        }

        private void btnExportToText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnExportToText();
        }

        private void btnExportToRtf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnExportToRTF();
        }

        private void btnExportToHtml_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnExportToHTML();
        }

        private void btnExportToCsv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.OnExportToCSV();
        }
                  
    }
}