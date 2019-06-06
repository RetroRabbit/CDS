using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DB = CDS.Client.DataAccessLayer.DB;
using BL = CDS.Client.BusinessLayer;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace CDS.Client.Desktop.Essential
{
    public partial class BaseDialogue : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Returns the icon image that must be used for the dialogue information. Override the TabIcon in child dialogues to provide different images.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public Image TabIcon
        {
            get
            {
                return this.imgIcon.Image;
            }
            set
            {
                this.imgIcon.Image = value;
            }
        }

        /// <summary>
        /// Returns the heading text that must be used for the dialogue information. Override the TabHeading in child dialogues to provide different text.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public String TabHeading
        {
            get
            {
                return this.lblHeading.Text;
            }
            set
            {
                this.lblHeading.Text = value;
            }
        }

        BL.DataContext dataContext;
        public List<Component> DropDownControls = new List<Component>();

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
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
        /// This property is used for read access only
        /// </summary>
        public DB.EntityViews ContextReadOnly
        {
            get
            {
                return DataContext.ReadonlyContext;
            }
        }

        /// <summary>
        /// This property is used to refresh on list screens only
        /// </summary>
        public DB.EntityViews ContextReadOnlyRefresh
        {
            get
            {
                return DataContext.ReadonlyContext;
            }
        }

        public BaseDialogue()
        {
            InitializeComponent();
        }

        public void ValidateLayout()
        {
            LayoutControl.Validate();
            LayoutControl.BeginUpdate();
            LayoutControl.EndUpdate();
        }

        /// <summary>
        /// This method is called to show a form in the MainForm as a MDIChildform
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Henko Rabie 15/10/2013</remarks>
        /// <param name="form">DevExpress Form to show</param>
        public void ShowForm(DevExpress.XtraEditors.XtraForm form)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowForm");

            methodInf.Invoke(mainform, new object[] { form });
        }

        /// <summary>
        /// Call this method to Open an existing document.
        /// </summary>
        /// <param name="id">Primary key of the document you want to open.</param>
        /// <param name="typeId">Document type that you are opening.</param>
        /// <remarks>Created: Henko Rabie 29/01/2015</remarks>
        public void ShowDocumentForm(Int64 id, Int64 typeId)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowDocumentForm");

            methodInf.Invoke(mainform, new object[] { id, typeId });
        }

        /// <summary>
        /// Call this method to open a New Generated document.
        /// </summary>
        /// <param name="header">Newly generated SYS_DOC_Header of document you are opening.</param>
        /// <remarks>Created: Henko Rabie 29/01/2015</remarks>
        public void ShowDocumentForm(DB.SYS_DOC_Header header)
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowDocumentFormFromHeader");

            methodInf.Invoke(mainform, new object[] { header });
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

            //Needs to be replaced with this.....
            //methodInf.Invoke(mainform, new object[] { title, message, showTime, longText, image });
            methodInf.Invoke(mainform, new object[] { title, message, showTime, longText, CDS.Client.Desktop.Essential.Properties.Resources.check_32 });
        }

        private void PopulateDropDownControls(DevExpress.XtraLayout.LayoutControl layoutControl)
        {
            foreach (var control in layoutControl.Controls)
            {
                if (control is DevExpress.XtraLayout.LayoutControl)
                {
                    PopulateDropDownControls(control as DevExpress.XtraLayout.LayoutControl);
                } 
                else
                    if (control is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        DropDownControls.Add(control as DevExpress.XtraEditors.GridLookUpEdit);
                    }
                    else
                        if (control is DevExpress.XtraEditors.SearchLookUpEdit)
                        {
                            DropDownControls.Add(control as DevExpress.XtraEditors.SearchLookUpEdit);
                            (control as DevExpress.XtraEditors.SearchLookUpEdit).Popup += searchLookUpEdit_Popup;
                        }
                        else
                            if (control is DevExpress.XtraEditors.LookUpEdit) //Base of the class is a TextEdit
                            {
                                DropDownControls.Add(control as DevExpress.XtraEditors.LookUpEdit);
                            }
                            else if (control is DevExpress.XtraGrid.GridControl)
                            {
                                foreach (var repitem in (control as DevExpress.XtraGrid.GridControl).RepositoryItems)
                                {
                                    if (repitem is DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)
                                    {
                                        DropDownControls.Add(repitem as DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit);
                                    }
                                    else if (repitem is DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)
                                    {
                                        DropDownControls.Add(repitem as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit);
                                        (repitem as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit).Popup += searchLookUpEdit_Popup;
                                    }
                                }
                            }
            }
        }

        private void searchLookUpEdit_Popup(object sender, EventArgs e)
        {
            TextEdit searchTextEdit = FindTextInputField(((IPopupControl)sender).PopupWindow as PopupSearchLookUpEditForm);
            if (searchTextEdit == null)
                return;

            searchTextEdit.KeyPress += searchTextEdit_KeyPress;
        }

        /// <summary>
        /// KeyDown Event for the SearchLookUpEdit's TextEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void searchTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                PopupSearchLookUpEditForm parentForm = ((TextEdit)sender).FindForm() as PopupSearchLookUpEditForm;
                GridControl grid = FindGridControl(parentForm);
                if (grid == null)
                    return;

                GridView view = grid.MainView as GridView;
                if (view.DataRowCount == 1)
                {
                    view.FocusedRowHandle = 0;
                    view.Focus();
                    SendKeys.SendWait("{Enter}");
                    //parentForm.OwnerEdit.ClosePopup();
                }
                else if (view.DataRowCount > 1)
                {
                    view.FocusedRowHandle = 0;
                    view.Focus();
                }

            }
        }

        /// <summary>
        /// Finds the SearchLookUpEdit's TextEdit
        /// </summary>
        /// <param name="popupForm"></param>
        /// <returns>SearchLookUpEdit's TextEdit</returns>
        private static TextEdit FindTextInputField(PopupSearchLookUpEditForm popupForm)
        {
            if (popupForm == null)
                return null;

            Control[] foundControls = popupForm.Controls.Find("teFind", true);
            if (foundControls.Length == 0)
                return null;

            return (TextEdit)foundControls[0];
        }

        /// <summary>
        /// Finds the SearchLookUpEdit's GridControl
        /// </summary>
        /// <param name="parentForm"></param>
        /// <returns>SearchLookUpEdit's GridControl</returns>
        private static GridControl FindGridControl(Form parentForm)
        {
            Control[] foundControls = parentForm.Controls.Find("lc", true);
            if (foundControls.Length == 0)
                return null;

            LayoutControl lc = foundControls[0] as LayoutControl;
            foreach (Control control in lc.Controls)
                if (control is GridControl)
                    return (GridControl)control;

            return null;
        }

        /// <summary>
        /// This method is called after the form has been initialised and should be overridden in all inheriting forms to handle data binding etc.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        protected virtual void OnStart()
        {
            PopulateDropDownControls(LayoutControl);

            int width = 0, height = 0;

            if (Application.OpenForms["MainForm"] != null)
            {
                width = Application.OpenForms["MainForm"].Width / 2 - 40;
                height = Application.OpenForms["MainForm"].Height / 2 / 2;
            }

            foreach (object control in DropDownControls)
            {
                if (control is DevExpress.XtraEditors.GridLookUpEdit)
                {
                    ((DevExpress.XtraEditors.GridLookUpEdit)control).Properties.PopupFormSize = new Size(width, height);
                }
                else
                    if (control is DevExpress.XtraEditors.SearchLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.SearchLookUpEdit)control).Properties.PopupFormSize = new Size(width, height);
                    }
                    else
                        if (control is DevExpress.XtraEditors.LookUpEdit)
                        {
                            ((DevExpress.XtraEditors.LookUpEdit)control).Properties.PopupFormSize = new Size(width, height);
                        }
                        else
                            if (control is DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)
                            {
                                ((DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)control).PopupFormSize = new Size(width, height);
                            }
                            else
                                if (control is DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)
                                {
                                    ((DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)control).PopupFormSize = new Size(width, height);
                                }
            }
        }

        /// <summary>
        /// This method is called after the form has been initialised and should be overridden in all inheriting forms to handle data binding etc.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 19/05/2015</remarks>
        protected virtual void BindData()
        {

        }

        /// <summary>
        /// This method will apply access security
        /// </summary>
        /// <remarks>Created: Werner Scheffer 19/05/2015</remarks>
        protected virtual void ApplySecurity()
        {
            
        }
         
        private void BaseDialogue_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.OnStart();
                this.BindData();
                this.ApplySecurity();
            }
        }
    }
}