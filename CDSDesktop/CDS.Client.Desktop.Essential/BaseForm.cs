using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Grid;
using BL = CDS.Client.BusinessLayer; 
using DB = CDS.Client.DataAccessLayer.DB;
using System.Reflection;
using System.Transactions;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid;

namespace CDS.Client.Desktop.Essential
{
    public partial class BaseForm : CDS.Client.Desktop.Essential.Base
    {
        public List<Component> DropDownControls = new List<Component>();
        public List<DB.IBaseEntity> BoundEntities = new List<DB.IBaseEntity>();
        private bool _readonly = false;
        private bool _haserrors = false;
        private Exception _currentErrors = null;
        private bool _isvalid = true;
        private bool _isopening = false;
        private bool _forceClose = false;
        private EntityState _itemState = EntityState.New;

        /// <summary>
        /// The Id (primary key) of Item we are opening
        /// </summary>
        /// <remarks>Created: Henko Rabie 22/01/2015</remarks>
        protected Int64 Id { get; set; }

        /// <summary>
        /// Werner : What is this used for? - Henko
        /// </summary>
        /// <remarks>Created: Werner Scheffer ??/??/2014</remarks>
        public bool IgnoreChanges { get; set; }

        /// <summary>
        /// Used to specify if you are opening a form with a new,existing or "new from reference" entity
        /// </summary>
        /// <remarks>Created: Henko Rabie 29/01/2015</remarks>
        [DefaultValue(EntityState.New)]
        public EntityState ItemState { get { return _itemState; } set { _itemState = value; } }

        /// <summary>
        /// Sets whether or not the form should be recovered.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/05/2014</remarks>
        [BrowsableAttribute(true)]
        public bool ShouldRecover { get; set; }

        /// <summary>
        /// Sets whether or not the Save Record button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowSave
        {
            get
            {
                return this.btnSave.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                if (ReadOnly)
                    this.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                else
                    this.btnSave.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Save And New Record button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowSaveAndNew
        {
            get
            {
                return this.btnSaveAndNew.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                if (ReadOnly)
                    this.btnSaveAndNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                else
                    this.btnSaveAndNew.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Save And E-Maoil button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 23/07/2013</remarks>
        [BrowsableAttribute(true)]
        public bool AllowSaveAndEmail
        {
            get
            {
                return this.btnSaveAndEmail.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                if (ReadOnly)
                    this.btnSaveAndEmail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                else
                    this.btnSaveAndEmail.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Save And Close Record button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowSaveAndClose
        {
            get
            {
                return this.btnSaveAndClose.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                if (ReadOnly)
                    this.btnSaveAndClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                else
                    this.btnSaveAndClose.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Next and Previous button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowNavigate
        {
            get
            {
                return this.rpgNavigation.Visible;
            }
            set
            {
                this.btnNext.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnPrevious.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.rpgNavigation.Visible = (value);
            }
        }

        /// <summary>
        /// Sets whether or not the Archive button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 8/10/2013</remarks>
        [BrowsableAttribute(true)]
        public bool AllowArchive
        {
            get
            {
                return this.btnArchive.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnArchive.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Archive button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 8/10/2013</remarks>
        [BrowsableAttribute(true)]
        public bool AllowRefresh
        {
            get
            {
                return this.btnRefreshEntry.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnRefreshEntry.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Print buttons is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 09/10/2013</remarks>
        [BrowsableAttribute(true)]
        public bool AllowPrint
        {
            get
            {
                return this.rpgPrint.Visible;
            }
            set
            {
                this.rpgPrint.Visible = (value);
            }
        }

        /// <summary>
        /// Sets whether only the Previous button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 18/07/2013</remarks>
        [BrowsableAttribute(true)]
        public bool AllowNavigateBackOnly
        {
            get
            {
                return this.rpgNavigation.Visible;
            }
            set
            {
                this.btnPrevious.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                this.rpgNavigation.Visible = (value);
            }
        }

        /// <summary>
        /// Sets whether only the Previous button is displayed for this form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 18/07/2013</remarks>
        [Category("Reporting")]
        [BrowsableAttribute(true)]
        public ReportTemplateType ReportTemplate { get; set; }
        
        /// <summary>
        /// Returns a short Description of the form
        /// Added for use on Recovery
        /// </summary>
        /// <returns></returns>
        /// <remarks>Created: Werner Scheffer 15/05/2014</remarks>
        [DefaultValue("")]
        public virtual String Description
        {
            get { return Text; }
        }

        [Category("Wait Form")]
        [DefaultValue(null)]
        private string waitFormNewRecordDescription = null;
        public string WaitFormNewRecordDescription
        {
            get
            {
                if (waitFormNewRecordDescription == null && SuperTipParameter != null)
                    waitFormNewRecordDescription = "Creating new " + SuperTipParameter.Split(',')[0] + "...";

                return waitFormNewRecordDescription;
            }
            set
            {
                if (value.ToLower() == "null")
                    waitFormNewRecordDescription = null;
                else
                    waitFormNewRecordDescription = value;
            }
        }

        [Category("Wait Form")]
        [DefaultValue(null)]
        private string waitFormOpenRecordDescription = null;
        public string WaitFormOpenRecordDescription
        {
            get
            {
                if (waitFormOpenRecordDescription == null && SuperTipParameter != null)
                    waitFormOpenRecordDescription = "Opening " + SuperTipParameter.Split(',')[0] + "...";

                return waitFormOpenRecordDescription;
            }
            set
            {
                if (value.ToLower() == "null")
                    waitFormOpenRecordDescription = null;
                else
                    waitFormOpenRecordDescription = value;
            }
        }

        /// <summary>
        /// Gets whether or not there are changes to the entity(ies)
        /// </summary>
        /// <returns>True if there are changes and False if not</returns>
        public bool HasChangedEntities()
        {
            bool hasChangedEntities = false;

            if (!IgnoreChanges)
                foreach (DB.IBaseEntity entity in BoundEntities)
                {
                    if (entity.HasChanges)
                    {
                        hasChangedEntities = true;
                        break;
                    }
                }

            return hasChangedEntities;
        }

        /// <summary>
        /// Get or sets whether or not to close the form without asking to reject changes;
        /// </summary>
        public bool ForceClose
        {
            get { return _forceClose; }
            set { if (_forceClose != value) { _forceClose = value; } }
        }

        /// <summary>
        /// Gets or sets the readonly status for the form.
        /// </summary>
        /// <remarks>Created: Theo Crous 01/12/2011</remarks>
        public bool ReadOnly
        {
            get { return _readonly; }
            set
            {
                try
                {
                    _readonly = value;

                    LayoutControl.OptionsView.IsReadOnly = (_readonly) ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                    btnSave.Visibility = (_readonly) ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;

                    SetReadonlyRecursive(LayoutControl.Items, _readonly);
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }

        /// <summary>
        /// This boolean is set if anything went wrong during the OnSaveRecord() method and then checked before continuing on to the 
        /// SaveAndNew or SaveAndClose finishes
        /// </summary>
        /// <remarks>Created: Werner Scheffer 10/09/2013</remarks>
        public bool HasErrors
        {
            get
            {
                return _haserrors;
            }

            set
            {
                if (value)
                {
                    _haserrors = value;
                }
                else
                {
                    _haserrors = value;
                    CurrentException = null;
                    CurrentErrorMessage = null;
                }
            }
        }

        /// <summary>
        /// This Exception is set if anything went wrong during the OnSaveRecord() method  
        /// </summary>
        /// <remarks>Created: Werner Scheffer 14/01/2014</remarks>
        public Exception CurrentException
        {
            get
            {
                return _currentErrors;
            }

            set
            {
                if (value != null)
                {
                    _currentErrors = value;
                    Essential.BaseAlert.ShowAlert("An unexpected error occurred", value.Message, BaseAlert.Buttons.Ok, BaseAlert.Icons.Error);
                }
                else
                {
                    _currentErrors = value;
                }
            }
        }

        public ErrorMessage CurrentErrorMessage { 
            get; set; 
        }

        /// <summary>
        /// This boolean is set if anything went wrong during the OnSaveRecord() method and then checked before continuing on to the 
        /// SaveAndNew or SaveAndClose finishes
        /// </summary>
        /// <remarks>Created: Werner Scheffer 10/09/2013</remarks>
        public bool IsValid { 
            get; set; 
        }

        /// <summary>
        /// This is used to determine if a entity is in the prosess of being opened 
        /// Is set to True in the OpenRecord and set to false in the OnShown
        /// </summary>
        public bool IsOpening
        {
            get { return _isopening; }
            set { if (_isopening != value) _isopening = value; }
        }

        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(Int64 id)
        {
            InitializeComponent();
            this.Id = id;
        }

        /// <summary>
        /// Finds the SearchLookUpEdit's TextEdit
        /// </summary>
        /// <param name="popupForm"></param>
        /// <returns>SearchLookUpEdit's TextEdit</returns>
        public static TextEdit FindTextInputField(PopupSearchLookUpEditForm popupForm)
        {
            if (popupForm == null)
                return null;
             
            Control[] foundControls = popupForm.Controls.Find("teFind", true);
            if (foundControls.Length == 0)
                return null;

            return (TextEdit)foundControls[0];
        }

        public static SimpleButton FindButtonInputField(PopupSearchLookUpEditForm popupForm)
        {
            if (popupForm == null)
                return null;

            Control[] foundControls = popupForm.Controls.Find("btFind", true);
            if (foundControls.Length == 0)
                return null;

            return (SimpleButton)foundControls[0];
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

        public IEnumerable<Component> EnumerateComponents(Type type)
        {
            return from field in this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where type.IsAssignableFrom(field.FieldType)
                   let component = (Component)field.GetValue(this)
                   where component != null
                   select component;
        }

        public object PerformAction(Action<BaseForm> action)
        {
            if (InvokeRequired)
            {
                if (this.IsClosing || this.Disposing || this.IsDisposed)
                    return true;
                else
                    return Invoke(action, this);
            }
            else
            {
                action(this);
                return true;
            }
        }

        public object PerformActionOnMainForm(Action<BaseForm> action)
        {
            var form = this as BaseForm;
            if (form != null)
                return form.PerformAction(action);

            return null;
        }

        public override bool HandleShortcut(IntPtr key)
        {
            {
                //Flag Ctrl as pressed
                if (base.HandleShortcut(key))
                {
                    return true;
                }

                if (AllowSave && CtrlPressed && key == (IntPtr)Keys.S)
                {
                    btnSave_ItemClick(btnSave, null);
                    return true;
                }
                else if (AllowRefresh && key == (IntPtr)Keys.F5)
                {
                    //RefreshRecord();
                    btnRefreshEntry_ItemClick(btnRefreshEntry, null);
                    return true;
                } 
                CtrlPressed = false;
                return false;
            }
        }

        private bool OnValidate()
        {
            if (!ValidationProvider.Validate())
            {
                foreach (var invalid in ValidationProvider.GetInvalidControls())
                {
                    foreach (var tabControl in LayoutGroup.Items)
                    {
                        if ((tabControl as DevExpress.XtraLayout.TabbedControlGroup) != null)
                        {
                            foreach (var tabPage in (tabControl as DevExpress.XtraLayout.TabbedControlGroup).TabPages)
                            {
                                foreach (var layoutControl in (tabPage as DevExpress.XtraLayout.LayoutControlGroup).Items)
                                {
                                    if (layoutControl == invalid)
                                    {
                                        (tabPage as DevExpress.XtraLayout.LayoutControlGroup).CaptionImage =
                                            //global::CDS.Shared.Resources.Properties.Resources.error_16;  
                                             ((layoutControl as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BaseEdit).ErrorIcon;
                                    }
                                    else
                                    {
                                        if (!(layoutControl is EmptySpaceItem))
                                            if (layoutControl is DevExpress.XtraLayout.LayoutControlGroup)
                                                foreach (var layoutControlItem in (layoutControl as DevExpress.XtraLayout.LayoutControlGroup).Items)
                                                {
                                                    if ((layoutControlItem as DevExpress.XtraLayout.LayoutControlItem).Control == invalid)
                                                    {

                                                        (tabPage as DevExpress.XtraLayout.LayoutControlGroup).CaptionImage =
                                                            //global::CDS.Shared.Resources.Properties.Resources.error_16;  
                                                            ((layoutControlItem as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BaseEdit).ErrorIcon;
                                                    }
                                                }
                                    }
                                }
                            }
                        }
                    }
                }
                IsValid = false;
                return false;
            }
            else
            {
                foreach (var tabControl in LayoutGroup.Items)
                {
                    if ((tabControl as DevExpress.XtraLayout.TabbedControlGroup) != null)
                    {
                        foreach (var tabPage in (tabControl as DevExpress.XtraLayout.TabbedControlGroup).TabPages)
                        {
                            (tabPage as DevExpress.XtraLayout.LayoutControlGroup).CaptionImage = null;
                        }
                    }
                }
                IsValid = true;
                return true;
            }
        }

        public string PopulateAbbreviation(string text)
        {
            try
            {
                if (text.Length > 0)
                {
                    string[] words = text.Split(' ');

                    foreach (string word in words.Where(n => n != string.Empty))
                    {
                        if (BL.ApplicationDataContext.Instance.Abbreviations.Where(n => n.Abbreviation.StartsWith(word)).Count() > 0)
                        {
                            text = text.Replace(word, (BL.ApplicationDataContext.Instance.Abbreviations.Where(n => n.Abbreviation.StartsWith(word))).Select(s => s.Description).FirstOrDefault().ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

            return text;

        }

        public void ValidateLayout()
        {
            LayoutControl.Validate();
            LayoutControl.BeginUpdate();
            LayoutControl.EndUpdate();
        }

        /// <summary>
        /// This method is called when a new record must be loaded into the form with default values and should be overridden in all inheriting forms to handle the loading of blank values in the form.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnNewRecord()
        {
            try
            {
                if (!this.DesignMode)
                {
                    AllowNavigate = false;
                    AllowArchive = false;
                    AllowRefresh = false;
                }
                SetWaitFormDescription(WaitFormNewRecordDescription);
                if (HasErrors)
                {
                    Essential.BaseAlert.ShowAlert(CurrentErrorMessage.Title, CurrentErrorMessage.Message, CurrentErrorMessage.Buttons, CurrentErrorMessage.Icons);

                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected virtual bool SaveSuccessful()
        {
            try
            {
                this.OnSaveRecord();
                return true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// This method is called when the user clicks on the Save Record button and should be overridden in all inheriting forms to handle the saving of the values in the form.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnSaveRecord()
        {
            try
            {
                if (OnValidate())
                {
                    //Reset error state for try catch
                    HasErrors = false;
                    ValidateLayout();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// This method is called when the user clicks on the Previous button and should be overriden in all inheiting forms to handle the retrieval of the previous record.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnPreviousRecord()
        {
            //TODO:Need to rebind some of the data after you load the Previous Record
            //BindData();
        }

        /// <summary>
        /// This method is called when the user clicks on the Next button and should be overriden in all inheriting forms to handle the retrieval of the next record.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnNextRecord()
        {
            //TODO:Need to rebind some of the data after you load the Next Record
            //BindData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Created: Werner Scheffer 08/10/2013</remarks>
        protected virtual void Archive()
        {
        }

        /// <summary>
        /// Populated the Validation for all the Control on the screen
        /// </summary>
        protected virtual void PopulateValidation()
        {
            try
            {
                DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule ValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();

                ValidationRule.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
                //base.PopulateValidation();

                foreach (Control control in this.LayoutControl.Controls)
                {

                    if (control.DataBindings.Count != 0 && (control.DataBindings[0].DataSource is System.Windows.Forms.BindingSource))
                    {
                        if (((control.DataBindings[0].DataSource as System.Windows.Forms.BindingSource).DataSource as DB.IBaseEntity) != null && !BoundEntities.Contains((control.DataBindings[0].DataSource as System.Windows.Forms.BindingSource).DataSource as DB.IBaseEntity))
                            BoundEntities.Add((control.DataBindings[0].DataSource as System.Windows.Forms.BindingSource).DataSource as DB.IBaseEntity);
                         
                        DB.VW_Validation validationItem =
                        BL.ApplicationDataContext.Instance.ValidationRestrictions.Where(n =>
                            BL.ApplicationDataContext.NonProxyType(((System.Windows.Forms.BindingSource)(control.DataBindings[0].DataSource)).DataSource.GetType()).Name == n.TableName &&
                            n.ColumnName.StartsWith(control.DataBindings[0].BindingMemberInfo.BindingField)).FirstOrDefault();

                        if (validationItem == null)
                            continue;

                        //If there is a length restriction add validator
                        if ((Int32)validationItem.LengthMax.Value != 0)
                        {
                            if (control is DevExpress.XtraEditors.TextEdit)
                                (control as DevExpress.XtraEditors.TextEdit).Properties.MaxLength = (Int32)validationItem.LengthMax.Value;

                        }
                        //If there is a required field restriction add validator
                        if (!validationItem.Nullable.Value)
                        {
                            if (validationItem.ColumnName.Contains("Id"))
                            {
                                //FK IDs not allowed to be Zero
                                ValidationRule.ErrorText = "Value cannot be blank";
                                ValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
                                ValidationRule.Value1 = 0;
                            }
                            else
                            {
                                    //FK IDs not allowed to be NULL
                                    ValidationRule.ErrorText = "Value cannot be blank";
                                    ValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
                                
                            }

                            if (ValidationProvider.GetValidationRule(control) != null)
                            {
                                if (ValidationProvider.GetValidationRule(control) is CustomValidationRule)
                                {
                                    (ValidationProvider.GetValidationRule(control) as CustomValidationRule).Rules.Add(ValidationRule);
                                }
                                else
                                {
                                  CustomValidationRule customRule = new CustomValidationRule();
                                  customRule.Rules.Add((DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule)ValidationProvider.GetValidationRule(control));
                                  customRule.Rules.Add(ValidationRule);
                                  ValidationProvider.SetValidationRule(control, customRule);
                                }
                            }
                            else
                            {
                                //TODO: Fix This - Just put in this check because agingaccount checkbox on accounts keep being invalid - not sure why?????
                                if (!(control is DevExpress.XtraEditors.CheckEdit))
                                {
                                    ValidationProvider.SetValidationRule(control, ValidationRule);
                                }
                            }
                        }
                    }
                }

                foreach (var bindingsource in EnumerateComponents())
                {
                    if (bindingsource is BindingSource)
                    {
                        (bindingsource as BindingSource).DataSourceChanged += (sender, e) => { this.PopulateValidation(); };
                    }
                }
            }
            catch
            {
                HasErrors = true;
            }

            IsValid = true;
            HasErrors = false;
        }

        public class CustomValidationRule : DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule
        {
            List<DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule> rules = new List<DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule>();

            public List<DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule> Rules { get { return rules; } }

            public override bool Validate(Control control, object value)
            {
             var valuea =  base.Validate(control, value);
                bool valid = true;

                foreach(var rule in rules)
                {
                    valid = rule.Validate(control, value);

                    if (!valid)
                    {
                        if (control is BaseEdit)
                            (control as BaseEdit).ErrorText = rule.ErrorText;

                        break;
                    }
                    else 
                    {
                        (control as BaseEdit).ErrorText = string.Empty;
                    }
                } 

                return valid;
            }
        }

        private IEnumerable<Component> EnumerateComponents()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Component).IsAssignableFrom(field.FieldType)
                   let component = (Component)field.GetValue(this)
                   where component != null
                   select component;
        }


        /// <summary>
        /// This method is called when a record must be loaded for the form. All inheriting forms should handle this method by overriding the method and indicating how the data is to be loaded.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public virtual void OpenRecord(Int64 Id)
        {
            //Any Entity Opened cannot be recovered
            //Recovery is only for New Entities
            ShouldRecover = false;
            IsOpening = true;
            SetWaitFormDescription(WaitFormOpenRecordDescription);
        } 

        /// <summary>
        /// Werner: What is this used for? - Henko
        /// </summary>
        /// <param name="bindingSources"></param>
        public virtual void Recover(List<BindingSource> bindingSources)
        {
            foreach (BindingSource source in EnumerateComponents(typeof(BindingSource)))
            {
                foreach (BindingSource o in bindingSources)
                {
                    if (o.DataSource.GetType().FullName.Contains(source.GetListName(null)))
                    {
                        source.DataSource = o.DataSource;
                    }
                }
            }
        }

        /// <summary>
        /// Refreshes the bound entries
        /// </summary>
        public virtual void RefreshRecord()
        {

        }

        /// <summary>
        /// Override the loading method.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                IsOpening = true;
                //AllowArchive = false;
                LayoutControl.RegisterUserCustomizatonForm(typeof(Essential.UTL.CustomizationForm));
                LayoutControl.ShowCustomization += LayoutControl_ShowCustomization;
                
                switch (this.ItemState)
                {
                    case EntityState.New:
                        this.OnNewRecord();
                        break;
                    case EntityState.Open:
                        this.OpenRecord(this.Id);
                        break;
                    case EntityState.Recovered:
                    case EntityState.Generated:
                        break;
                }

                //Werner Moved to Base.cs after the OnStart method
                //ApplySecurity();
                //Werner: Commented this out because its a pain to changed forms while developing
                LoadLayout();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        void LayoutControl_ShowCustomization(object sender, EventArgs e)
        {
            OnShowCustomization();
        }

        public virtual void OnShowCustomization()
        {
            LayoutControl.CustomizationForm.VisibleChanged += CustomizationForm_VisibleChanged;
        }

        void CustomizationForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!((DevExpress.XtraLayout.Customization.UserCustomizationForm)(sender)).Visible)
            {
                OnClosedCustomization();
            }            
        }

        public virtual void OnClosedCustomization()
        {
           
        }

        /// <summary>
        /// Bind all the datasources on the form.
        /// </summary>
        protected override void BindData()
        {
            base.BindData();
        }

        /// <summary>
        /// Show the print preview form for the LayoutControl.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnPrintPreview()
        {
            try
            {
                base.OnPrintPreview();
                if (LayoutControl.IsPrintingAvailable)
                    LayoutControl.ShowRibbonPrintPreview();
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
                base.OnPrint();
                LayoutControl.Print();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the LayoutControl to Excel file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToExcel()
        {
            try
            {
                base.OnExportToExcel();
                string filepath = GetExportFilePath("Excel Files|*.xlsx");
                if (filepath != null)
                {
                    LayoutControl.ExportToXlsx(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the LayoutControl to Pdf file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToPDF()
        {
            try
            {
                base.OnExportToPDF();
                string filepath = GetExportFilePath("PDF Files|*.pdf");
                if (filepath != null)
                {
                    LayoutControl.ExportToPdf(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the LayoutControl to Text file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToText()
        {
            try
            {
                base.OnExportToText();
                string filepath = GetExportFilePath("Text Files|*.txt");
                if (filepath != null)
                {
                    LayoutControl.ExportToText(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the LayoutControl to Rtf file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToRTF()
        {
            try
            {
                base.OnExportToRTF();
                string filepath = GetExportFilePath("RTF Files|*.rtf");
                if (filepath != null)
                {
                    LayoutControl.ExportToRtf(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the LayoutControl to Html file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToHTML()
        {
            try
            {
                base.OnExportToHTML();
                string filepath = GetExportFilePath("HTML Files|*.html");
                if (filepath != null)
                {
                    LayoutControl.ExportToHtml(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the LayoutControl to Csv file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToCSV()
        {
            try
            {
                base.OnExportToCSV();
                string filepath = GetExportFilePath("CSV Files|*.csv");
                if (filepath != null)
                {
                    LayoutControl.ExportToText(filepath, ",", false);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            PopulateChangeTracker();
            PopulateValidation();
            PopulateDropDownControls(LayoutControl);
            PopulateEvents();
            PopulateDropDownStandards();
            ApplyGridDefaults();

            //Werner: Devexpress Default Export is ugly on some formats, by default all export are disables you can enable them all at once or one by one
            //Using the Properties on the Base
            //AllowExport = false;
            AllowPrint = false;

            //Werner: This function has been disabled since we are using LinqInstantFeedbackSource as I'm not sure how we
            //are going to sent through the filtered datasource to the Child form to Next and Previous through
            AllowNavigate = false;

            //Werner: We decided to disable this until we could find a better implementation (there is to much data on the screens)
            AllowExport = false;
        }

        /// <summary>
        /// Sets all the controls in the layout to readonly and disables any grids or other types of controls.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="Readonly"></param>
        /// <remarks>Created: Theo Crous 01/12/2011</remarks>
        private void SetReadonlyRecursive(DevExpress.XtraLayout.Utils.BaseItemCollection items, bool Readonly)
        {
            try
            {
                //layoutControl.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.True;
                //grvItems.OptionsBehavior.Editable = false;
                //grvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                //grvItems.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;


                foreach (BaseLayoutItem c in items)
                {
                    if (c is LayoutControlGroup)
                    {
                        LayoutControlGroup ci = c as LayoutControlGroup;
                        SetReadonlyRecursive(ci.Items, Readonly);
                    }
                    else if (c is EmptySpaceItem)
                    {
                        // Do nothing
                    }
                    else if (c is LayoutControlItem)
                    {
                        LayoutControlItem ci = c as LayoutControlItem;
                        if (ci.Control is DevExpress.XtraEditors.PopupBaseEdit)
                        {
                            (ci.Control as DevExpress.XtraEditors.PopupBaseEdit).Properties.ReadOnly = Readonly;
                            (ci.Control as DevExpress.XtraEditors.PopupBaseEdit).Properties.AllowDropDownWhenReadOnly = (Readonly) ? DevExpress.Utils.DefaultBoolean.False : DevExpress.Utils.DefaultBoolean.True;
                        }
                        if (ci.Control is DevExpress.XtraEditors.BaseEdit)
                        {
                            (ci.Control as DevExpress.XtraEditors.BaseEdit).Properties.ReadOnly = Readonly;
                        }
                        else if (ci.Control is DevExpress.XtraGrid.GridControl)
                        {
                            DevExpress.XtraGrid.Views.Base.BaseView k = (ci.Control as DevExpress.XtraGrid.GridControl).DefaultView;

                            if (k is GridView)
                            {
                                (k as GridView).OptionsBehavior.Editable = !Readonly;
                                (k as GridView).OptionsView.NewItemRowPosition = (Readonly) ? DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None : DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                                (k as GridView).FocusRectStyle = (Readonly) ? DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None : DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
                            }
                            else
                            {
                                throw new Exception("Cannot set readonly for this type of grid view");
                            }
                        }
                        else if (ci.Control is DevExpress.XtraEditors.LabelControl)
                        {

                        }
                        else if (ci.Control is DevExpress.XtraPivotGrid.PivotGridControl)
                        {

                        }
                        else if (ci.Control is DevExpress.XtraCharts.ChartControl)
                        {

                        }
                        else if (ci.Control is DevExpress.XtraWizard.WizardControl)
                        {

                        }
                        else if (ci.Control is DevExpress.XtraEditors.CheckedListBoxControl)
                        {
                            (ci.Control as DevExpress.XtraEditors.CheckedListBoxControl).Enabled = false;
                        }
                        else if (ci.Control is DevExpress.XtraEditors.BaseButton)
                        {
                            (ci.Control as DevExpress.XtraEditors.BaseButton).Parent.Enabled = false;
                        }
                        else
                        {
                            throw new Exception("Cannot set readonly for this type of control");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Add Event to BindingSource ListChanged
        /// </summary>
        private void PopulateChangeTracker()
        {
            foreach (Control item in this.LayoutControl.Controls)
            {
                if (item.DataBindings.Count != 0 && (item.DataBindings[0].DataSource is System.Windows.Forms.BindingSource))
                {
                    if ((item.DataBindings[0].DataSource as System.Windows.Forms.BindingSource).DataSource != null)
                    {
                        (item.DataBindings[0].DataSource as System.Windows.Forms.BindingSource).ListChanged += BindingSource_ListChanged;
                    }
                }
            }
        }

        /// <summary>
        /// Loads the Current Saved Layout
        /// </summary>
        protected virtual void LoadLayout()
        {
            string screenName = this.GetType().FullName;
            DB.SYS_Layout sys_layout = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == screenName && n.UserId == BL.ApplicationDataContext.Instance.LoggedInUser.Id);
            if (sys_layout != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(sys_layout.Custom);
                    writer.Flush();
                    stream.Position = 0;
                    LayoutControl.RestoreLayoutFromStream(stream);
                }
            }

            foreach (var control in LayoutControl.Controls)
            {
                if (control is DevExpress.XtraGrid.GridControl)
                {
                    foreach (DevExpress.XtraGrid.Views.Grid.GridView view in (control as DevExpress.XtraGrid.GridControl).Views)
                    {
                        string gridName = screenName + "+" + view.Name;

                        DB.SYS_Layout sys_layout_grid = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == gridName && n.UserId == BL.ApplicationDataContext.Instance.LoggedInUser.Id);

                        if (sys_layout_grid != null)
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                StreamWriter writer = new StreamWriter(stream);
                                writer.Write(sys_layout_grid.Custom);
                                writer.Flush();
                                stream.Position = 0;
                                view.RestoreLayoutFromStream(stream);//, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                            }
                        }
                    }
                }
            }
            foreach (var control in Controls)
            {
                if (control is DevExpress.XtraBars.Ribbon.RibbonControl)
                {
                    string ribbonQuickAccessToolbarName = screenName + "+" + "QuickAccessToolbar";

                    DB.SYS_Layout sys_layout_quick_access = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == ribbonQuickAccessToolbarName && n.UserId == BL.ApplicationDataContext.Instance.LoggedInUser.Id);

                    if (sys_layout_quick_access != null)
                    {
                        foreach (DevExpress.XtraBars.BarItem item in (control as DevExpress.XtraBars.Ribbon.RibbonControl).Items)
                        {
                            (item as DevExpress.XtraBars.BarItem).Id =
                            (control as DevExpress.XtraBars.Ribbon.RibbonControl).Manager.GetNewItemId();
                        }

                        using (MemoryStream stream = new MemoryStream())
                        {
                            StreamWriter writer = new StreamWriter(stream);
                            writer.Write(sys_layout_quick_access.Custom);
                            writer.Flush();
                            stream.Position = 0;
                            RibbonControl.Toolbar.RestoreLayoutFromStream(stream);//, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                        }
                    }
                }
            }
        }

        private void PopulateDropDownStandards()
        {

            foreach (var control in DropDownControls)
            {
                    if (control is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                  
                    }
                    else
                        if (control is DevExpress.XtraEditors.SearchLookUpEdit)
                        {
                            (control as DevExpress.XtraEditors.SearchLookUpEdit).Popup += searchLookUpEdit_Popup; 
                            (control as DevExpress.XtraEditors.SearchLookUpEdit).Properties.PopupFindMode = FindMode.FindClick;
                            (control as DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
                        }
                        else
                            if (control is DevExpress.XtraEditors.LookUpEdit) //Base of the class is a TextEdit
                            {
                             
                            }
                            else
                                if (control is DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)
                                {

                                }
                                else if (control is DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)
                                {
                                    (control as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit).Popup += searchLookUpEdit_Popup;
                                    (control as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit).PopupFindMode = FindMode.FindClick;
                                    (control as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit).View.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
                                }

                //(control as Control).Click += Control_Click;
            }
        }

        /// <summary>
        /// Werner: What is this used for? - Henko
        /// </summary>
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
                        }
                        else
                            if (control is DevExpress.XtraEditors.LookUpEdit) //Base of the class is a TextEdit
                            {
                                DropDownControls.Add(control as DevExpress.XtraEditors.LookUpEdit);
                            }
                            else
                                if (control is DevExpress.XtraGrid.GridControl)
                                {
                                   // ((DevExpress.XtraGrid.GridControl)control).DefaultView.KeyPress += (object sender, KeyPressEventArgs e) =>
                                   //{
                                   //    if (CtrlPressed && e.KeyChar == 'E')
                                   //    {
                                   //        (sender as DevExpress.XtraGrid.Views.Grid.GridView).ShowFilterEditor((sender as DevExpress.XtraGrid.Views.Grid.GridView).Columns[0]);
                                   //    }
                                   //};
                                 
                                    foreach (var repitem in (control as DevExpress.XtraGrid.GridControl).RepositoryItems)
                                    {
                                        if (repitem is DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)
                                        {
                                            DropDownControls.Add(repitem as DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit);
                                        }
                                        else if (repitem is DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)
                                        {
                                            DropDownControls.Add(repitem as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit);
                                        }
                                    }
                                }

                //(control as Control).Click += Control_Click;
            }
        }

        /// <summary>
        /// Link custom events to controls
        /// </summary>
        private void PopulateEvents()
        {
            foreach (object control in LayoutControl.Controls)
            {
                if (control is DevExpress.XtraEditors.TextEdit)
                {
                    (control as DevExpress.XtraEditors.TextEdit).KeyDown += TextBox_KeyDown;
                }
            }
        }

        /// <summary>
        /// Apply defaults for all grids 
        /// </summary>
        private void ApplyGridDefaults()
        {
            foreach (object control in LayoutControl.Controls)
            {
                if (control is DevExpress.XtraGrid.GridControl)
                {
                    foreach (DevExpress.XtraGrid.Views.Grid.GridView view in (control as DevExpress.XtraGrid.GridControl).Views)
                    {
                        view.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
                        view.OptionsNavigation.EnterMoveNextColumn = true;
                        view.OptionsMenu.ShowConditionalFormattingItem = true;
                    }
                }
            }
        }

        /// <summary>
        /// Opens the file 
        /// </summary>
        /// <param name="filepath"></param>
        public void OpenExportFile(string filepath)
        {
            if (filepath == null)
                return;

            if (Essential.BaseAlert.ShowAlert("View file", "File exported would you like to view this file ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) == System.Windows.Forms.DialogResult.OK)
                System.Diagnostics.Process.Start(filepath);
        }

        public void RestoreIcon()
        {
            this.TabIcon = this.TabIconBackup;
            //Werner: Usualy happens if you close the BaseForm in the Save Method
            if (this.Parent != null)
                this.Parent.TopLevelControl.Refresh();
        }

        public void SetUnsavedIcon()
        {
            byte[] img1 = null;
            byte[] img2 = null;

            //Backup Original Image
            using (var ms = new MemoryStream())
            {
                if (this.TabIcon != null)
                {
                    this.TabIcon.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    img1 = ms.ToArray();
                }
            }

            //Create Backup of Floppy Disk Edit Image
            using (var ms = new MemoryStream())
            {
                global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_edit_16.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                img2 = ms.ToArray();
            }

            //Change the TabIcon to Floppy Disk Edit Image and Refresh the MainForm
            if (img1 == null || !img1.SequenceEqual(img2.AsEnumerable()))
            {
                this.TabIcon = global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_edit_16;
                this.Parent.TopLevelControl.Refresh();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Focus();

            if (!ForceClose && HasChangedEntities())
            {
                if (Essential.BaseAlert.ShowAlert("Reject Changes", "Do you want to reject changes made ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Question) == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
            else
            {

                foreach (object control in DropDownControls)
                {
                    if (control is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        (control as DevExpress.XtraEditors.GridLookUpEdit).EditValue = 0;
                        (control as DevExpress.XtraEditors.GridLookUpEdit).DoValidate();
                        //ValidationProvider.RemoveControlError((Control)control);
                    }
                    else if (control is DevExpress.XtraEditors.SearchLookUpEdit)
                    {
                        (control as DevExpress.XtraEditors.SearchLookUpEdit).EditValue = 0;
                        (control as DevExpress.XtraEditors.SearchLookUpEdit).DoValidate();
                        //ValidationProvider.RemoveControlError((Control)control);
                    }
                }
            }

            string stringHandle = Handle.ToString();

            if (System.IO.Directory.Exists(Environment.CurrentDirectory + @"\Recovery"))
                foreach (System.IO.FileInfo file in (new System.IO.DirectoryInfo(Environment.CurrentDirectory + @"\Recovery")).GetFiles().Where(n => n.Name.StartsWith(stringHandle)))
                {
                    file.Delete();
                }
            ShouldRecover = false;
            base.OnClosing(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            IsOpening = false;
        }

        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            SetUnsavedIcon();
        }

        private void searchLookUpEdit_Popup(object sender, EventArgs e)
        { 
            TextEdit searchTextEdit = FindTextInputField(((IPopupControl)sender).PopupWindow as PopupSearchLookUpEditForm);
            if (searchTextEdit == null)
                return;
            else
            {
                //If this is removed the will always search for String.Empty if opened the second time ignoring PopupFindMode = FindMode.FindClick
                //(sender as SearchLookUpEdit).Properties.PopupFindMode = FindMode.FindClick;
               // searchTextEdit.EditValue = null;
                
            }
             
            searchTextEdit.KeyPress += searchTextEdit_KeyPress;
        }

        /// <summary>
        /// KeyDown Event for the SearchLookUpEdit's TextEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
                        SendKeys.Send("{Enter}");
                        //parentForm.OwnerEdit.ClosePopup();
                    }
                    else if (view.DataRowCount > 1)
                    {
                        view.FocusedRowHandle = 0;
                        view.Focus();
                    }

                }
            }
            catch (Exception ex) { }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Help)
            {
                DevExpress.Utils.ToolTipController tooltip = DevExpress.Utils.ToolTipController.DefaultController;
                tooltip.AddClientControl(sender as Control);
                tooltip.ShowHint((sender as Control).Name);
                tooltip.CloseOnClick = DevExpress.Utils.DefaultBoolean.True;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.U)
            {
                (sender as DevExpress.XtraEditors.TextEdit).SelectedText = (sender as DevExpress.XtraEditors.TextEdit).SelectedText.ToUpper();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.L)
            {
                (sender as DevExpress.XtraEditors.TextEdit).SelectedText = (sender as DevExpress.XtraEditors.TextEdit).SelectedText.ToLower();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            //TODO: This almoast works just gets stuck on spaces
            //else
            //    if (e.Control && e.KeyCode == Keys.Back)
            //    {
            //        //Removes the Delete Character at the end           
            //        (sender as DevExpress.XtraEditors.TextEdit).Text = (sender as DevExpress.XtraEditors.TextEdit).Text.TrimEnd(new char[] { (char)127 });

            //        SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            //        e.Handled = true;
            //        e.SuppressKeyPress = true;
            //    }
        }

        /// <summary>
        /// Applies abbreviations to txtReference field.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 09/01/2012</remarks>
        private void txtReference_Properties_Leave(object sender, EventArgs e)
        {
            //Werner: Removed as per Task 375
            //(sender as DevExpress.XtraEditors.TextEdit).Text = PopulateAbbreviation((sender as DevExpress.XtraEditors.TextEdit).Text);
        }

        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.OnNextRecord();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnPrevious_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.OnPreviousRecord();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        // Documents is currently the only thing that can be emailed from the save action
        public virtual void btnSaveAndEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SaveSuccessful())
                {
                    RestoreIcon();
                    ShowNotification("Save Complete", "Saved successfully.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.check_32);
                    GenerateEmail();
                }
                else
                {
                    if (HasErrors)
                        ShowNotification("Error Saving", "Error saving please try again.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.error_32);
                    else
                        ShowNotification("Item not Saving", "Please check all fields before saving.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_delete_16);
                }
                
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void GenerateEmail()
        {
            var properties = BindingSource.DataSource.GetType().GetProperties();

            long id = -1;
            
            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {
                    id = Convert.ToInt64(property.GetValue(BindingSource.DataSource));
                    break;
                }
            }

            if (id == -1)
                return;

            string title = string.Empty;
            foreach (var property in properties)
            {
                if (property.Name == "Title")
                {
                    title = property.GetValue(BindingSource.DataSource).ToString();
                    break;
                }
            }

            if (title == string.Empty)
                return;

            OpenEmailDialogue(ReportTemplate, id, title + ".pdf");
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SaveSuccessful())
                {
                    RestoreIcon();
                    ShowNotification("Save Complete", "Saved successfully.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.check_32);
                    if (!HasErrors && IsValid)
                    {
                        this.Close();
                    }
                }
                else
                {
                    if (HasErrors)
                        ShowNotification("Error Saving", "Error saving please try again.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.error_32);
                    else
                        ShowNotification("Item not Saving", "Please check all fields before saving.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_delete_16);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SaveSuccessful())
                {
                    RestoreIcon();
                    ShowNotification("Save Complete", "Saved successfully.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.check_32);
                    if (!HasErrors && IsValid)
                    {
                        BindingSource.Clear();
                        this.OnNewRecord();
                        this.BindData();
                    }
                }
                else
                {
                    if (HasErrors)
                        ShowNotification("Error Saving", "Error saving please try again.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.error_32);
                    else
                        ShowNotification("Item not Saving", "Please check all fields before saving.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_delete_16);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SaveSuccessful())
                {
                    RestoreIcon();
                    ShowNotification("Save Complete", "Saved successfully.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.check_32);
                    if (!HasErrors && IsValid)
                    {
                        this.Close();
                    }
                }
                else
                {
                    if (HasErrors)
                        ShowNotification("Error Saving", "Error saving please try again.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.error_32);
                    else
                        ShowNotification("Item not Saving", "Please check all fields before saving.", 100, false, CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_delete_16);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnArchive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Archive();
        }

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            int width, height;

            width = this.Width - 40;
            height = this.Height / 2;

            foreach (object control in DropDownControls)
            {
                if (control is DevExpress.XtraEditors.GridLookUpEdit)
                {
                    ((DevExpress.XtraEditors.GridLookUpEdit)control).Properties.PopupFormSize = new Size(width, height);
                    ((DevExpress.XtraEditors.GridLookUpEdit)control).Popup += Filter_Popup;
                }
                else
                    if (control is DevExpress.XtraEditors.SearchLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.SearchLookUpEdit)control).Properties.PopupFormSize = new Size(width, height);
                        ((DevExpress.XtraEditors.SearchLookUpEdit)control).Popup += Filter_Popup;
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
                                ((DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)control).Popup += Filter_Popup;
                            }
                            else
                                if (control is DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)
                                {
                                    ((DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)control).PopupFormSize = new Size(width, height);
                                    ((DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)control).Popup += Filter_Popup;
                                }
            }
        }

        void Filter_Popup(object sender, EventArgs e)
        {

            if ((sender is DevExpress.XtraEditors.GridLookUpEditBase))
                (sender as DevExpress.XtraEditors.GridLookUpEditBase).Properties.View.ApplyColumnsFilter();             
        }

        private void btnRefreshEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Werner: Yes This is weird to do but all the other places we refresh I run this event and not the RefreshRecord() method
            if (btnRefreshEntry.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                return;

            RefreshRecord();
            RestoreIcon();
        }

        public enum EntityState
        { 
            New,
            Open,
            Generated,
            Recovered
        }

        public enum ReportTemplateType
        {
            None,
            SalesDocument,
            PurchaseDocument,
            PickerDocument,
            StockDocument,
            WorkDocument,
            TransferDocument
        }
    }

    public class ErrorMessage
    {
        public ErrorMessage(string title, string message, Essential.BaseAlert.Buttons buttons, Essential.BaseAlert.Icons icons)
        {
            this.Title = title;
            this.Message = message;
            this.Buttons = buttons;
            this.Icons = icons;
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public Essential.BaseAlert.Buttons Buttons { get; set; }
        public Essential.BaseAlert.Icons Icons { get; set; }
    }
}
