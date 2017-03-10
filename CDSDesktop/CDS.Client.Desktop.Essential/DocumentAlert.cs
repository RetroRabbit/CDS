using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DB = CDS.Client.DataAccessLayer.DB;
using BL = CDS.Client.BusinessLayer;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Transactions;
using DevExpress.XtraLayout;

namespace CDS.Client.Desktop.Essential
{
    public partial class DocumentAlert : DevExpress.XtraEditors.XtraForm
    {
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
        /// Returns the icon image that must be used for the alert information. Override the TabIcon in child alerts to provide different images.
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
        /// Returns the heading text that must be used for the alert information. Override the TabHeading in child alerts to provide different text.
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

        /// <summary>
        /// Returns the message heading that must be used for the alert information. Override the MessageHeading in child alerts to provide different text.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public String MessageHeading
        {
            get
            {
                return this.pnlInformation.Text;
            }
            set
            {
                this.pnlInformation.Text = value;
            }
        }

        /// <summary>
        /// Returns the message text that must be used for the alert information. Override the Message in child alerts to provide different text.
        /// </summary>
        /// <remarks>Created: Theo Crous 13/02/2012</remarks>
        [BrowsableAttribute(true)]
        public String Message
        {
            get
            {
                return this.lblMessage.Text;
            }
            set
            {
                this.lblMessage.Text = value;
            }
        }

        protected DocumentAlert()
        {
            InitializeComponent();
        }

        protected DocumentAlert(String Heading, String Message, Buttons Button)
        {
            InitializeComponent();

            this.TabHeading = Heading;
            this.Message = Message.Replace("\n",Environment.NewLine);
            SetButton(Button);
           // SetIcon(Icon);

        }

        public static DialogResult ShowAlert(String Heading, String Message, Buttons Button)
        {
            try
            {
                DocumentAlert alert = new DocumentAlert(Heading, Message, Button);
                return alert.ShowDialog();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return DialogResult.Abort;
            }
        }

        public void SetButton(Buttons button)
        {
            try
            {
                switch (button)
                {
                    case Buttons.Print:
                        lciPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciSaveAndPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        break;
                    case Buttons.Save:
                        lciPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciSaveAndPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        break;
                    case Buttons.SaveAndPrint:
                        lciPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lciSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciSaveAndPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lciCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void SetIcon(Icons icon)
        {
            try
            {
                //switch (icon)
                //{
                //    case Icons.Error:
                //        TabIcon = global::CDS.Shared.Resources.Properties.Resources.error_32;
                //        break;
                //    case Icons.Warning:
                //        TabIcon = global::CDS.Shared.Resources.Properties.Resources.sign_warning_32;
                //        break;
                //    case Icons.Information:
                //        TabIcon = global::CDS.Shared.Resources.Properties.Resources.information2_32;
                //        break;
                //}
                TabIcon = global::CDS.Shared.Resources.Properties.Resources.information2_32;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
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

            ddlPrinter.EditValue = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId;
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

        private void DocumentAlert_Load(object sender, EventArgs e)
        {
            this.OnStart();
        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            if (ddlPrinter.EditValue == null)
                return;

            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (ddlPrinter.EditValue == null)
                return;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public enum Buttons
        {
            SaveAndPrint,
            Save,
            Print
        }

        public enum Icons
        { 
            Information 
        }

        private void InstantFeedbackSourcePrinter_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Printer.Where(n => !n.Archived);
        }

        private void ddlPrinter_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlPrinter.EditValue != null && BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId != (long)ddlPrinter.EditValue)
            {
                BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId = (long)ddlPrinter.EditValue;

                try
                {
                    using (TransactionScope transaction = BL.ApplicationDataContext.Instance.DataContext.GetTransactionScope())
                    {
                        BL.ApplicationDataContext.Instance.DataContext.SaveChangesEntitySecurityContext();
                        BL.ApplicationDataContext.Instance.DataContext.CompleteTransaction(transaction);
                    }

                    BL.ApplicationDataContext.Instance.DataContext.EntitySecurityContext.AcceptAllChanges();
                    BL.ApplicationDataContext.Instance.DataContext.EntitySystemContext.AcceptAllChanges();
                }
                catch (Exception ex)
                {
                    BL.ApplicationDataContext.Instance.DataContext.EntitySecurityContext.RejectChanges();
                    BL.ApplicationDataContext.Instance.DataContext.EntitySystemContext.RejectChanges();
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }

    }
}