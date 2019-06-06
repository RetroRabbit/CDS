using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;
using System.Data.Entity;


namespace CDS.Client.Desktop.Accounting
{
    public partial class AccountForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.SYS_Entity sysEntity;
        DB.GLX_Account glxAccount;
        DB.GLX_SiteAccount glxSiteAccount;
        //Either create or edit
        private String accessType;

        /// <summary>
        /// Boolean that returns true if Account has never been submitted to the database (Is a new Account)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (glxAccount != null)
                    return (DataContext.EntityAccountingContext.GetEntityState(glxAccount) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        private bool makeSiteDefault = false;

        public AccountForm()
        {
            InitializeComponent();
            accessType = "create";
         
        }

        public AccountForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
            accessType = "edit";
        }

        /// <summary>
        /// Load any necessary lookup values.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                tcgDetails.SelectedTabPage = lcgBalances;
                
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Essential.GridFilterDefaults.ApplyStandards(new List<DevExpress.XtraGrid.Views.Grid.GridView> { grvEntries, grvRecons });
            Int64 currentid = glxAccount.EntityId;

           // DateTime twelveMonthsBack = DateTime.Today.AddMonths(-12);
           // ServerModeSourceStatements.QueryableSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountId == currentid && n.PeriodStartDate <= DateTime.Today && n.PeriodEndDate >= twelveMonthsBack); //(n.PeriodStartDate >= twelveMonthsBack || n.PeriodEndDate >= twelveMonthsBack));

        }

        protected override void BindData()
        {
            base.BindData();
           
            //Populate site binding
            bindingSourceSite.DataSource = DataContext.EntitySystemContext.SYS_Site.Join(DataContext.EntitySystemContext.SYS_Entity, n => n.EntityId, a => a.Id, (n, a) => new { n.Id, a.Title, a.Name, a.Description, n.EntityId }).ToList();
            ddlSiteSelection.EditValue = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            
            //GET LOOKUP INFO
            ServerModeSourceType.QueryableSource = (IQueryable)DataContext.EntityAccountingContext.GLX_Type;
            ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;

            //ADDS NO COST CENTER
            DB.SYS_Entity NoCenter = BL.SYS.SYS_Entity.NewCenter;
            NoCenter.Id = -1;
            NoCenter.CreatedOn = DateTime.Now;
            NoCenter.Title = "NO COST CENTER";
            NoCenter.Description = "NO COST CENTER";
            List<DB.SYS_Entity> centers = DataContext.EntitySystemContext.SYS_Entity.Where(n => n.TypeId == (byte)BL.SYS.SYS_Type.Center).ToList();
            centers.Add(NoCenter);
            ServerModeSourceCenter.QueryableSource = centers.AsQueryable();
            
            //ADDS NO NO SYSTEM ACCOUNT TYPE
            DB.GLX_SystemAccountType NoSystemAccountType = new DB.GLX_SystemAccountType();
            NoSystemAccountType.Id = -1;
            NoSystemAccountType.Name = "NOT A SYSTEM ACCOUNT";
            List<DB.GLX_SystemAccountType> systemAccountTypes = DataContext.EntityAccountingContext.GLX_SystemAccountType.ToList();
            systemAccountTypes.Add(NoSystemAccountType);
            BindingSourceSiteAccountType.DataSource = systemAccountTypes;

            BindingSource.DataSource = glxAccount;
            BindingSourceEntity.DataSource = sysEntity;
            if (glxSiteAccount != null)
            {
                
                BindingSourceSiteAccount.DataSource = glxSiteAccount;
                ceSiteAccount.Checked = true; 
            }
            else
            {
                ceSiteAccount.Enabled = true;
            }
         
        }

        public override void RefreshRecord()
        {
            base.RefreshRecord();

            if (!IsNew)
            {
                DataContext.EntityAccountingContext.ReloadEntry(BindingSource.DataSource);
                DataContext.EntitySystemContext.ReloadEntry(BindingSourceEntity.DataSource);
                DataContext.EntityAccountingContext.ReloadEntry(BindingSourceSiteAccount.DataSource);
                InstantFeedbackSourceRecons.Refresh();
                InstantFeedbackSourceEntries.Refresh();
                ServerModeSourceStatements.Reload();
                ServerModeSourceAmountvsBudget.Reload();
                ServerModeSourceCenter.Reload();
            }
            else
            {
                ServerModeSourceCenter.Reload();
            }
        }

        /// <summary>
        /// The binding source is bound to a new instance of an Account. This is for the instances where a new record is to be created.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                glxAccount = BL.GLX.GLX_Account.New;
                sysEntity = BL.SYS.SYS_Entity.NewAccount;
                chkControlAccount.Checked = false;
                chkControlAccount.Enabled = true;
                chkAgingAccount.Enabled = true;
                btnRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                AllowArchive = false;
                tcgDetails_SelectedPageChanged(tcgDetails, null);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open an Account record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the Account to open.</param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    base.OpenRecord(Id);
                    glxAccount = BL.GLX.GLX_Account.LoadByEntityId(Id, DataContext);
                    sysEntity = BL.SYS.SYS_Entity.Load(glxAccount.EntityId, DataContext);
                    //If you do this in one line the ddlSiteAccount_EditValueChanged fires and creates a new site account
                    //this should not be done
                    glxSiteAccount = BL.GLX.GLX_SiteAccount.LoadByAccount(glxAccount.EntityId, DataContext);
                    if (glxSiteAccount != null)
                    {
                        //chkSystemAccount.Enabled = true;
                        //if (glxSiteAccount.SystemDefaultAccount)
                        //{
                        //    ddlSiteAccountType.Enabled = false;
                        //}
                        fieldBudgetAmount.Visible = !glxAccount.AgingAccount;
                    }

                    chkControlAccount.Checked = sysEntity.CodeSub == "00000";
                    chkControlAccount.Enabled = false;
                    //ddlType.Enabled = sysEntity.CodeSub == "00000";

                    //GET LOOKUP INFO
                    tcgDetails_SelectedPageChanged(tcgDetails, null);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();

                    if (!IsValid)
                        return false;

                    if (glxAccount.CenterId == -1)
                        glxAccount.CenterId = null;

                    //TODO: Improve this
                    DB.VW_Validation validationItem =
                            BL.ApplicationDataContext.Instance.ValidationRestrictions.Where(n =>
                                ((System.Windows.Forms.BindingSource)(txtName.DataBindings[0].DataSource)).DataSource.ToString().Split('.').Last().StartsWith(n.TableName) &&
                                n.ColumnName.Equals(txtName.DataBindings[0].BindingMemberInfo.BindingField)).FirstOrDefault();

                    ((DB.SYS_Entity)BindingSourceEntity.DataSource).ShortName = ((DB.SYS_Entity)BindingSourceEntity.DataSource).Name.Substring(0, validationItem.LengthMax.Value > txtName.Text.Length ? txtName.Text.Length : (int)validationItem.LengthMax.Value);
                    

                    if (sysEntity.CodeSub != "00000")
                     {
                         DB.GLX_Account glxControlAccount = BL.GLX.GLX_Account.LoadControlAccountByCode(sysEntity.CodeMain, DataContext);
                         glxAccount.AgingAccount = glxControlAccount.AgingAccount;
                         glxAccount.AccountTypeId = glxControlAccount.AccountTypeId;
                         glxAccount.MasterControlId = glxControlAccount.EntityId;
                     }
                    else
                    {
                       
                        if(ceSiteAccount.Checked)
                        glxAccount.SiteId = (long?)ddlSiteSelection.EditValue;
                    }

                    glxAccount.IsNewAccount = DataContext.EntityAccountingContext.GetEntityState(glxAccount) == System.Data.Entity.EntityState.Detached;
                    glxAccount.SiteAccount = BindingSourceSiteAccount.DataSource as DB.GLX_SiteAccount;
                    if (glxAccount.SiteAccount != null)
                        glxAccount.SiteAccount.MakeSiteDefault = makeSiteDefault;

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Entity(sysEntity, DataContext);
                            //Needs another check, Should only happen for ORG entities and not other accounts ie. Bank account, COS account etc
                            if (sysEntity.ChangeList.Contains("Name") && BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ORG && n.Code == "YES") && BL.ApplicationDataContext.Instance.SystemEntityContext.SYS_Entity.Any(n => n.CodeSub == sysEntity.CodeSub && n.TypeId == 3))
                                BL.SYS.SYS_Entity.AllignCompanyAccountNames(sysEntity, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            glxAccount.EntityId = sysEntity.Id;
                            //ControlId Represents the Rollup Account
                            //on New Accounts it is its own control
                            glxAccount.ControlId = sysEntity.Id;
                            BL.EntityController.SaveGLX_Account(glxAccount, DataContext);
                            DataContext.SaveChangesEntityAccountingContext();
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityAccountingContext.RejectChanges();
                        DataContext.EntitySystemContext.RejectChanges();                        
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true; CurrentException = ex;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Commit all changes of the Account record to the database.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        /// <summary>
        /// Loads and opens the next Account record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                //DB.GLX_Account glxAccount = BL.GLX.GLX_Account.GetNextItem((DB.GLX_Account)BindingSource.DataSource, DataContext);
                //if (glxAccount != null)
                //{
                //    BindingSource.DataSource = glxAccount;

                //    chkControlAccount.Checked = glxAccount.SYS_Entity.CodeSub == "00000";
                //    chkControlAccount.Enabled = false;

                //    //GET LOOKUP INFO
                //    tgcDetails_SelectedPageChanged(tgcDetails, null);
                //}
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous Account record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();

                //DB.GLX_Account glxAccount = BL.GLX.GLX_Account.GetPreviousItem((DB.GLX_Account)BindingSource.DataSource, DataContext);
                //if (glxAccount != null)
                //{
                //    BindingSource.DataSource = glxAccount;

                //    chkControlAccount.Checked = glxAccount.SYS_Entity.CodeSub == "00000";
                //    chkControlAccount.Enabled = false;

                //    //GET LOOKUP INFO
                //    tgcDetails_SelectedPageChanged(tgcDetails, null);
                //}
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Apply Security to all ribbon buttons
        /// </summary>
        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE01));
            AllowSave = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIACREED));
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIRERECR))
                btnRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
 

            //Remove buttons that isn't applicable with new account 
            if (IsNew)
            {
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                btnArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                AllowExport = false;
                AllowRefresh = false;
            }
            else
            {
                AllowExport = true;
                AllowRefresh = true;
            }

            //Change Archive Buttons text
            if (sysEntity.Archived)
            {
                btnArchive.Caption = "Un-Archive";
            }
            else
            {
                btnArchive.Caption = "Archive";
            }

            //Disable changing code main if Account has children
            txtCodeMain.Enabled = DataContext.ReadonlyContext.VW_Account.Count(n => n.Id != glxAccount.Id && n.ControlId == glxAccount.Id) == 0;
        }

        /// <summary>
        /// Archives the current bound item
        /// </summary>
        protected override void Archive()
        {
            base.Archive();
            DB.GLX_Account glxAccount = (DB.GLX_Account)BindingSource.DataSource;
            DB.SYS_Entity sys_entity = BL.SYS.SYS_Entity.Load(((DB.GLX_Account)BindingSource.DataSource).EntityId, DataContext);
            if (!sys_entity.Archived)
            {
                try
                {
                    //000 = Archived or Un-Archived
                    //001 = Outstanding Balance
                    //002 = Control Account
                    //003 = Is Parent
                    //004 = Parent is Archived
                    int code = -1;/* Context.Database.SqlQuery<int>(
                    "DECLARE	@return_value int" + Environment.NewLine +
                    "EXEC	@return_value = [dbo].[spArchiveAccount]" + Environment.NewLine +
                    "        @AccountId = " + glxAccount.Id + "," + Environment.NewLine +
                    "        @Archive = 1" + Environment.NewLine +
                    "SELECT	@return_value");
                    */


                    if (code.Equals(0))
                    {
                        sys_entity.Archived = !sys_entity.Archived;
                        btnArchive.Caption = sys_entity.Archived ? "Un-Archive" : "Archive";
                    }
                    else if (code.Equals(1))
                    {
                        Essential.BaseAlert.ShowAlert("Archive",
                            "This account can not be archive." + Environment.NewLine +
                            "\t• Account has outstanding balances.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }
                    else if (code.Equals(2))
                    {
                        Essential.BaseAlert.ShowAlert("Archive",
                            "This account can not be archive." + Environment.NewLine +
                            "\t• Account is a control account.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }
                    else if (code.Equals(3))
                    {
                        Essential.BaseAlert.ShowAlert("Archive",
                            "This account can not be archive." + Environment.NewLine +
                            "\t• Account is a parent for another account.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
            else
            {
                try
                {
                    //TODO: Find a way to do this
                    //returns 1 if sp was able to unarchive account
                    int code = -1; /* Context.Database.SqlQuery<int>(
                    "DECLARE	@return_value int" + Environment.NewLine +
                    "EXEC	@return_value = [dbo].[spArchiveAccount]" + Environment.NewLine +
                    "        @AccountId = " + glxAccount.Id + "," + Environment.NewLine +
                    "        @Archive = 0" + Environment.NewLine +
                    "SELECT	@return_value");
                    */

                    if (code.Equals(0))
                    {
                        sys_entity.Archived = !sys_entity.Archived;
                        btnArchive.Caption = sys_entity.Archived ? "Un-Archive" : "Archive";
                    }
                    else if (code.Equals(4))
                    {
                        Essential.BaseAlert.ShowAlert("Un-Archive",
                            "This account can not be archive." + Environment.NewLine +
                            "\t• Accounts parent account is archived.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }
                    else
                    {
                        Essential.BaseAlert.ShowAlert("Archive", "Account could not be un-archived.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }


                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }
         
        /// <summary>
        /// Checks that the account had a name.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 24/05/2013</remarks>
        private bool IsAccountNameValid()
        {
            try
            {

                if (txtName.Text.Length == 0)
                {
                    txtName.ErrorText = "Enter Account Name...";
                    return false;
                }
                else
                {
                    txtName.ErrorText = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks that the account type has been chosen when an control account.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 06/03/20121</remarks>
        private bool IsAccountTypeValid()
        {
            try
            {
                if (chkControlAccount.Checked && DataContext.EntitySystemContext.SYS_Type.Where(n => n.Id == glxAccount.AccountTypeId).Count() == 0)
                {
                    ddlType.ErrorText = "Select Account Type...";
                    return false;
                }
                else
                {
                    ddlType.ErrorText = "";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks that Code Sub exists if not an control account.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 25/05/2013</remarks>
        private bool IsCodeMainAndCodeSubValid()
        {
            try
            {
                //TODO: Find way to get modified Entity
                // if (!BL.ApplicationContext.Instance.Context.HasChanges(glxAccount.))
                //return true;


                //If there is no Main Code return false
                if (sysEntity.CodeMain == null || sysEntity.CodeMain.Length == 0)
                {
                    txtCodeMain.ErrorText = "Enter Main Code...";
                    return false;
                }
                else
                {
                    txtCodeMain.ErrorText = string.Empty;
                }

                //If there is no Sub Code return false
                if (sysEntity.CodeSub == null || sysEntity.CodeSub.Length == 0)
                {
                    txtCodeSub.ErrorText = "Enter Sub Code...";
                    return false;
                }
                else
                {
                    txtCodeSub.ErrorText = string.Empty;
                }

                //If Control Account
                if (chkControlAccount.Checked)
                {


                    //Check that Code Main is not used and Code Sub equals 00000
                    if (DataContext.EntitySystemContext.SYS_Entity.Any(n => n.Id != glxAccount.EntityId && n.CodeMain == sysEntity.CodeMain && n.CodeSub == sysEntity.CodeSub && n.TypeId == (byte)BL.SYS.SYS_Type.Account))
                    //DataContext.EntityAccountingContext.GLX_Account.Where(n => n.Id != glxAccount.Id && n.SYS_Entity.CodeMain == glxAccount.SYS_Entity.CodeMain && n.SYS_Entity.CodeSub == glxAccount.SYS_Entity.CodeSub).Count() > 0)
                    {
                        //CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Duplicates are not allowed", "This Account number already exists", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        txtCodeMain.ErrorText = "This Account number already exists";
                       
                        return false;
                    }
                    else
                    {
                        txtCodeMain.ErrorText = string.Empty;
                    }

                }
                else
                {
                    //Check that Code Main is not used and Code Sub is not used
                    if (DataContext.EntitySystemContext.SYS_Entity.Any(n => n.Id != glxAccount.EntityId && n.CodeMain == sysEntity.CodeMain && n.CodeSub == sysEntity.CodeSub && n.TypeId == (byte)BL.SYS.SYS_Type.Account))
                    //DataContext.EntitySystemContext.GLX_Account.Where(n => n.Id != glxAccount.Id && n.SYS_Entity.CodeMain == glxAccount.SYS_Entity.CodeMain && n.SYS_Entity.CodeSub == glxAccount.SYS_Entity.CodeSub).Count() > 0)
                    {
                        //CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Duplicates are not allowed", "This Account number already exists", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        txtCodeSub.ErrorText = "This Account number already exists";
                        //MessageBox.Show("This Account number already exists. Duplicates are not allowed.");
                        return false;
                    }
                    else
                    {
                        txtCodeSub.ErrorText = "";
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks that below conditions are valid.
        /// * Code Main doen not exist
        /// * Code Sub does not exist
        /// * Type for control account has been selected
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 06/03/2012</remarks>
        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;

                bool isValid = true;
                isValid = IsCodeMainAndCodeSubValid() && IsAccountTypeValid() && IsAccountNameValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private void ValidateSiteAccount()
        {
            if (glxSiteAccount == null)
                return;
            //If the Site Account is new
            if (DataContext.EntityAccountingContext.GetEntityState(glxSiteAccount) == System.Data.Entity.EntityState.Detached)
            {
                ddlSiteAccountType.Enabled = true;
                txtShortDescription.Enabled = true;
                ceSystemAccount.Enabled = true;
                if ((BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR) && accessType == "create") || (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED) && accessType == "edit"))
                    ddlSiteSelection.Enabled = true;
            }
            else
            {
                txtShortDescription.Enabled = true;

                if (!glxSiteAccount.SystemDefaultAccount)
                {
                    ceSiteAccount.Enabled = true;
                    ceSystemAccount.Enabled = true;
                    if ((BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR) && accessType == "create") || (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED) && accessType == "edit"))
                        ddlSiteSelection.Enabled = true;
                }
                ////Disable site account change if Account has children
                ////Disable site account change if Account Balance plus Children account Balance is not equal to Zero
                if ((DataContext.ReadonlyContext.VW_Balance.Any(n => n.AccountId == glxAccount.Id && n.BalanceAmount != 0)
                     || DataContext.ReadonlyContext.VW_Account.Count(n => n.Id != glxAccount.Id && n.ControlId == glxAccount.Id) != 0))
                {
                    ceSiteAccount.Enabled = false;
                    ddlSiteAccountType.Enabled = false;
                    ddlSiteSelection.Enabled = false;
                    ceSystemAccount.Enabled = true;
                }


            }
        }

        private void ddlSiteAccountType_EditValueChanged(object sender, EventArgs e)
        {
            //if (!glxSiteAccount.SystemDefaultAccount)
            //    ddlSiteAccountType.Enabled = ddlSiteAccountType.EditValue != null;

            //txtShortDescription.Enabled = ddlSiteAccountType.EditValue != null;
        }

        private void ceSiteAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (ceSiteAccount.Checked)
            {
                if (glxSiteAccount == null)
                {
                    
                    glxSiteAccount = BL.GLX.GLX_SiteAccount.New;
                    glxSiteAccount.SiteId = (long)ddlSiteSelection.EditValue;
                    BindingSourceSiteAccount.DataSource = glxSiteAccount; 
                }
                ValidateSiteAccount();
            }
            else
            {
                if (DataContext.EntityAccountingContext.GetEntityState(glxSiteAccount) != System.Data.Entity.EntityState.Detached)
                {
                    DataContext.EntityAccountingContext.GLX_SiteAccount.Remove(glxSiteAccount);
                }
                glxSiteAccount = null; 
                ddlSiteAccountType.Enabled = false;
                txtShortDescription.Enabled = false;
                ceSystemAccount.Enabled = false;
                ddlSiteSelection.Enabled = false;
            }
         
        }

        /// <summary>
        /// Binds data to grids on Tab Change.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 23/11/2011</remarks>
        private void tcgDetails_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            try
            {
                Int64 currentid = glxAccount.EntityId;
                if (((DevExpress.XtraLayout.TabbedControlGroup)sender).SelectedTabPage == lcgBalances)
                {
                    DateTime twelveMonthsBack = DateTime.Today.AddMonths(-12);
                    ServerModeSourceStatements.QueryableSource = DataContext.ReadonlyContext.VW_Balance.Where(n => n.AccountId == currentid && n.PeriodStartDate <= DateTime.Today && n.PeriodEndDate >= twelveMonthsBack); //(n.PeriodStartDate >= twelveMonthsBack || n.PeriodEndDate >= twelveMonthsBack));

                    DateTime sixMonthsBack = DateTime.Today.AddMonths(-6);
                    DateTime sixMonthsFuture = DateTime.Today.AddMonths(6);
                    ServerModeSourceAmountvsBudget.QueryableSource = DataContext.ReadonlyContext.VW_Budget.Where(n => n.AccountId == currentid && (n.PeriodEndDate >= sixMonthsBack && n.PeriodEndDate <= sixMonthsFuture)).OrderBy(o => o.PeriodCode);//.Take(12);
                }
                else if (((DevExpress.XtraLayout.TabbedControlGroup)sender).SelectedTabPage == lcgEntries)
                {
                    //ServerModeSourceEntries.QueryableSource = DataContext.ReadonlyContext.VW_Line.Where(n => n.AccountId == currentid);
                }
                else if (((DevExpress.XtraLayout.TabbedControlGroup)sender).SelectedTabPage == lcgRecons)
                {
                    //TODO: Fix recons
                    //ServerModeSourceRecon.QueryableSource = Context.GLX_Recon.Where(n => n.AccountId == currentid);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Runs when Control Account Checkbox is checked
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/08/2013</remarks>
        private void chkControlAccount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkControlAccount.Checked)
                {
                    txtCodeSub.Enabled = false;
                    sysEntity.CodeSub = "00000";
                    ddlType.Enabled = glxSiteAccount == null;
                    glxAccount.MasterControlId = null;
                    //ONLY CONTROL ACCOUNTS CAN CHOSE TO HAVIN AGINGS OR NOT
                    chkAgingAccount.Enabled = false;
                    glxAccount.AgingAccount = false;
                    
                }
                else
                {
                    txtCodeSub.Enabled = true;
                    ddlType.Enabled = false;
                    if (txtCodeSub.Text == "00000")
                        sysEntity.CodeSub = String.Empty;

                    //ONLY CONTROL ACCOUNTS CAN CHOSE TO HAVIN AGINGS OR NOT
                    chkAgingAccount.Enabled = true;
                    glxAccount.AgingAccount = true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Opens Recon for the current account
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/08/2013</remarks>
        private void btnRecon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ReconForm childForm = new ReconForm();
                childForm.AccountId = glxAccount.Id;
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Opens Entry form for the entry that double clicked on
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/08/2013</remarks>
        private void grdEntries_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ((grdEntries.MainView as GridView).FocusedRowHandle < 0)//|| !(grdEntries.MainView as GridView).CalcHitInfo(MousePosition).InRow)
                    return;

                object FocusedRow = (grdEntries.MainView as GridView).GetFocusedRow();

                if (FocusedRow is DevExpress.Data.NotLoadedObject)
                    return;

                //TODO: Fix this

                Entry.EntryForm child = new Entry.EntryForm(Convert.ToInt64(((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)FocusedRow).OriginalRow.GetType().GetProperty("Id").GetValue(((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)FocusedRow).OriginalRow, null)));
                child.ReadOnly = true;
                ShowForm(child);

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Checks if you are running Lite or Orders version and if so limits you to 10 sub account
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/08/2013</remarks>
        private void txtCodeMain_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //TODO: Remove CHIMERA Tags and make Pegasus LITE
#if (CHIMERA || CHIMERA_LITE || CHIMERA_ORDERS)
#if (CHIMERA_LITE || CHIMERA_ORDERS)
                Int64 total = BL.ApplicationContext.Instance.Context.GLX_Account.Where(n => n.SYS_Entity.CodeMain == txtCodeMain.Text).Count();

                if (total > 10)
                {
                    Essential.BaseAlert.ShowAlert("Main Account limit", "Accounts are limited to ten sub accounts in Lite version", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    DB.GLX_Account glxAccount = (DB.GLX_Account)BindingSource.DataSource;
                    glxAccount.SYS_Entity.CodeMain = "00000";
                }
#endif
#endif

            string codeMain = e.NewValue.ToString();
            var sysEntityParent = BL.SYS.SYS_Entity.LoadControlEntityByCode(codeMain, DataContext);

            if (sysEntityParent == null)
            {
                chkControlAccount.Enabled = true;
                chkAgingAccount.Enabled = true;
                glxAccount.AccountTypeId = 0;
                return;
            }

            var glxAccountParent = BL.GLX.GLX_Account.LoadByEntityId(sysEntityParent.Id, DataContext);

            //var glx_parent = from account in DataContext.EntityAccountingContext.GLX_Account
            //                 join entity in DataContext.EntitySystemContext.SYS_Entity
            //                 on account.EntityId equals entity.Id
            //                 where entity.CodeMain == e.NewValue && entity.CodeSub == "00000"
            //                 select new { account, entity };

            //if (glx_parent.Count() > 1)
            //    throw new Exception("Duplicate Accounts");

            // DataContext.EntityAccountingContext.GLX_Account.FirstOrDefault(n => n.SYS_Entity.CodeMain == e.NewValue && n.SYS_Entity.CodeSub == "00000");
            if (glxAccountParent != null)
            {
                glxAccount.AccountTypeId = glxAccountParent.AccountTypeId; //DataContext.EntityAccountingContext.GLX_Account.FirstOrDefault(n => n.SYS_Entity.CodeMain == e.NewValue && n.SYS_Entity.CodeSub == "00000").AccountTypeId;
                chkControlAccount.Checked = false;
                chkControlAccount.Enabled = false;
                chkAgingAccount.Checked = glxAccountParent.AgingAccount;
                chkAgingAccount.Enabled = false;
                sysEntity.CodeMain = sysEntityParent.CodeMain;
                glxAccount.AgingAccount = glxAccountParent.AgingAccount;                
                txtCodeMain.Refresh();
                txtCodeSub.Focus();
            }


            ddlType.Refresh();
        }

        /// <summary>
        /// Checks if Code Sub is equal to 00000 if it is set all properties required for a control account.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/08/2013</remarks>
        private void txtCodeSub_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtCodeSub.Text == "00000")
            {
                chkControlAccount.Checked = true;
                //sysEntity.CodeSub = "00000";
                txtCodeSub.Refresh();
                txtName.Focus();
            }
        }

        private void ceSystemAccount_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (chkSystemAccount.Checked)
            {//((DB.SYS_Entity)BindingSourceEntity.DataSource).Id == 
                //If the current account is the only Site account for this type you are not allowed ot remove it
                if (ceSystemAccount.Checked && DataContext.EntityAccountingContext.GLX_SiteAccount.Where(n => n.EntityId == sysEntity.Id && n.SystemDefaultAccount == true).Count() > 0)
                {
                    Essential.BaseAlert.ShowAlert("Deactivate System Account", "There are not allowed to remove the system account", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    e.Cancel = true;
                }
                //If other accounts for this site exists that are already site default account for this type warn the user
                else if (!ceSystemAccount.Checked && DataContext.EntityAccountingContext.GLX_SiteAccount.Where(n => n.TypeId == glxSiteAccount.TypeId && n.SystemDefaultAccount == true).Count() > 0)
                {
                    if (Essential.BaseAlert.ShowAlert("Override System Account", "Another account has been marked as the system account for this type on the current Site.\nDo you continue and make this the site default site account ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Error) == System.Windows.Forms.DialogResult.OK)
                    {
                        makeSiteDefault = true;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void InstantFeedbackSourceEntries_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Line.Where(n => n.AccountId == glxAccount.EntityId);
        }

        private void InstantFeedbackSourceRecons_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Recon.Where(n => n.EntityId == glxAccount.EntityId);
        }

        private void crtBalancesGraphAgingBreakdown_Click(object sender, EventArgs e)
        {
            chartBarController.Control = sender as DevExpress.XtraCharts.ChartControl;
        }

        private void crtBalancesGraphRealVsBudget_Click(object sender, EventArgs e)
        {
            chartBarController.Control = sender as DevExpress.XtraCharts.ChartControl;
        }

        private void pvtBalances_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        { 
            grvEntries.ActiveFilterString = String.Format("StartsWith([PeriodCode], '{0}')",  pvtBalances.GetFieldValue(pvtBalances.Fields["PeriodCode"], e.RowIndex));
            tcgDetails.SelectedTabPage = lcgEntries;
        }

        private void ddlType_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlType.EditValue != DBNull.Value && (byte)ddlType.EditValue != 0)
            {
                ServerModeSourceSiteAccountType.QueryableSource = DataContext.ReadonlyContext.VW_SiteAccountType.Where(n => n.TypeId == (byte)ddlType.EditValue);
            }
        }
                  
    }
}