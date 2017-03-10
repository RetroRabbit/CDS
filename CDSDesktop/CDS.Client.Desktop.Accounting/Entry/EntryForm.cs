using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;


namespace CDS.Client.Desktop.Accounting.Entry
{
    public partial class EntryForm : CDS.Client.Desktop.Essential.BaseForm
    {

        private DB.GLX_Header glxHeader;
        private List<DB.GLX_Line> glxLines = new List<DB.GLX_Line>();
        //Either create or edit
        private String accessType;

        /// <summary>
        /// Boolean that returns true if Document has never been submited to the database (Is a new document)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (glxHeader != null)
                    return (DataContext.EntityAccountingContext.GetEntityState(glxHeader) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public EntryForm()
        {
            InitializeComponent();
            accessType = "create";
        }

        public EntryForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
            accessType = "Edit";
        }

        /// <summary>
        /// Bind all the reqiured lookup values.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        /// <remarks>
        /// Changed: Werner Scheffer 21/11/2011
        /// Changed Periods to only show open periods
        /// </remarks>
        /// <remarks>
        /// Changed: Werner Scheffer 22/11/2011
        /// Changed Periods to select last open period
        /// </remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                
                //ADDS NO COST CENTER
                DB.VW_Center NoCenter = new DB.VW_Center();
                NoCenter.Id = -1;
                //NoCenter.CreatedOn = DateTime.Now;
                NoCenter.Title = "NO COST CENTER";
                NoCenter.Description = "NO COST CENTER";
                List<DB.VW_Center> centers = DataContext.ReadonlyContext.VW_Center.Where(n => n.Archived != true).ToList();
                centers.Add(NoCenter);
                ServerModeSourceCenter.QueryableSource = centers.AsQueryable();
                this.Invoke(new Action(() =>
                {
                    ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
                    ServerModeSourceAging.QueryableSource = DataContext.EntityAccountingContext.GLX_Aging;
                    ServerModeSourceStatus.QueryableSource = DataContext.EntitySystemContext.SYS_Status;
                    ServerModeSourceAbbreviation.QueryableSource = DataContext.EntitySystemContext.SYS_Abbreviation; 
                }));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = glxHeader;
            foreach (DB.GLX_Line line in glxHeader.GLX_Line)
            {
                glxLines.Add(line);
            }

            BindingSourceLines.DataSource = glxLines;
        }

        /// <summary>
        /// Open an Header record from the database.
        /// </summary>
        /// <param name="Id">The id (primary key) of the Header to open.</param>
        /// <remarks>Created: Theo Crous 01/12/2011</remarks>
        public override void OpenRecord(Int64 Id)
        {
            try
            {
                base.OpenRecord(Id);
                AllowArchive = false;

                Int64 headerId = DataContext.ReadonlyContext.VW_Line.Where(n => n.Id == (int)Id).Select(n => n.HeaderId).FirstOrDefault();
                glxHeader = BL.GLX.GLX_Header.Load(headerId, DataContext, new List<String>() { "GLX_Line" });
                ServerModeSourcePeriod.QueryableSource = DataContext.EntitySystemContext.SYS_Period.Where(n => n.StatusId != 51 || n.Id == glxHeader.PeriodId).OrderByDescending(n => n.StartDate);
                AllowSave = false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Bind a blank new record to the form.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                glxHeader = BL.GLX.GLX_Header.New;
                glxLines = new List<DB.GLX_Line>();
                glxHeader.GLX_Line = glxLines;
                ServerModeSourcePeriod.QueryableSource = DataContext.EntitySystemContext.SYS_Period.Where(n => n.StatusId != 51).OrderByDescending(n => n.StartDate);
                glxHeader.TrackId = -1;
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

                    (grdLines.MainView as DevExpress.XtraGrid.Views.Grid.GridView).PostEditor();
                    grdLines.EndUpdate();

                    //Gets Period Id from date
                    glxHeader.PeriodId = DataContext.EntitySystemContext.SYS_Period.Where(n => datDate.DateTime >= n.StartDate && datDate.DateTime <= n.EndDate).Select(n => n.Id).FirstOrDefault();
                    glxHeader.ReferencePeriodId = glxHeader.PeriodId;
                    if (!glxHeader.JournalTypeId.HasValue)
                        glxHeader.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Journal;

                    if (chkAutoPost.Checked)
                    {
                        glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
                        glxHeader.PostedDate = BL.ApplicationDataContext.Instance.ServerDateTime.Date;
                    }
                    else
                    {
                        glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Unposted;
                        glxHeader.PostedDate = null;
                    }

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        { 
                            if (!glxHeader.IsYearendHeader)
                                BL.GLX.GLX_Header.InsertProfitDistributionEntries(glxHeader, DataContext);

                            if (chkNewTrackNumber.Checked)
                            {
                                DB.SYS_Tracking tracking = BL.SYS.SYS_Tracking.New;
                                BL.EntityController.SaveSYS_Tracking(tracking, DataContext);
                                DataContext.SaveChangesEntitySystemContext();
                                glxHeader.TrackId = tracking.Id;
                            }
                            BL.EntityController.SaveGLX_Header(glxHeader, DataContext);
                            DataContext.SaveChangesEntityAccountingContext();
                            if (chkAutoPost.Checked)
                            {
                                BL.GLX.GLX_Header.UpdateLedgerAccountBalance(glxHeader, DataContext);
                            }
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                //DataContext.EntityAccountingContext.RollBackTransaction();
                HasErrors = true; CurrentException = ex;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Save the record currently displayed in the form.
        /// </summary>
        /// <remarks>Created: Theo Crous 17/11/2011</remarks>
        /// <remarks>Modified: Werner Scheffer 02/12/2011</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        /// <summary>
        /// Loads and opens the next Entry record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 05/12/2011</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                //DB.GLX_Header glx_header = BL.GLX.GLX_Header.GetNextItem((DB.GLX_Header)BindingSource.DataSource,DataContext);
                //if (glx_header != null)
                //{
                //    BindingSource.DataSource = glx_header;
                //    BindingSourceLines.DataSource = glx_header.GLX_Line;
                //    ServerModeSourcePeriod.QueryableSource = DataContext.EntitySystemContext.SYS_Period.Where(n => n.Id == glx_header.PeriodId).OrderByDescending(n => n.StartDate);
                //}
                //
                //ApplyVisibility();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous Entry record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 05/12/2011</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();

                //DB.GLX_Header glx_header = BL.GLX.GLX_Header.GetPreviousItem((DB.GLX_Header)BindingSource.DataSource,DataContext);
                //if (glx_header != null)
                //{
                //    BindingSource.DataSource = glx_header;
                //    BindingSourceLines.DataSource = glx_header.GLX_Line;
                //    ServerModeSourcePeriod.QueryableSource = DataContext.EntitySystemContext.SYS_Period.Where(n => n.Id == glx_header.PeriodId).OrderByDescending(n => n.StartDate);
                //}
                //
                //ApplyVisibility();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            if (IsNew)
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            ApplyVisibility();
            if (ItemState == EntityState.Generated && glxHeader.TrackId > 0)
            {
                chkNewTrackNumber.Checked = false;
                chkNewTrackNumber.Enabled = false;
                chkAutoPost.Properties.ReadOnly = true;
                txtTrackNumber.Enabled = false;
            }

            if (BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.FIENRE02))
            {
                chkAutoPost.Enabled = true;
                chkAutoPost.Properties.ReadOnly = false;
                chkAutoPost.Checked = true;
            }

            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRECR);
        } 

        /// <summary>
        /// Checks that Debit and Credit totals balance out.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 29/11/2011</remarks>
        private bool IsTotalsValid()
        {

            try
            {
                bool isValid = true;

                if (Convert.ToDecimal(colAmount.Summary[0].SummaryValue) != 0M)
                {
                    CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Incorrect Transaction total", "Transaction Total should be Zero please complete all transaction.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    isValid = false;
                }

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks that all lines have accounts selected.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 29/11/2011</remarks>
        private bool IsAccountOnLinesValid()
        {
            try
            {
                bool isValid = true;

                if ((BindingSourceLines.DataSource as List<DB.GLX_Line>).Count == 0)
                    return false;

                foreach (DB.GLX_Line line in BindingSourceLines.DataSource as List<DB.GLX_Line>)
                {
                    if (line.EntityId == 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks that below conditions are valid.
        /// * Is Totals Valid
        /// * Is Account On Lines Valid
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 29/11/2011</remarks>
        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                isValid = IsTotalsValid() && IsAccountOnLinesValid(); 
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks which controls should be visible .
        /// *btnRejectEntry
        /// *btnReverseEntry
        /// </summary>
        /// <remarks>Created: Werner Scheffer 16/01/2012</remarks>
        private void ApplyVisibility()
        {
            try
            { 
                btnTrackHistory.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                //UNPOSTED
                if (glxHeader.StatusId == (byte)BL.SYS.SYS_Status.Unposted && BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.FIENRE02))
                {
                    btnRejectEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnApproveEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnReverseEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    btnRejectEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnApproveEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnReverseEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }

                if (glxHeader.JournalTypeId.HasValue && (new byte[] { (byte)BL.GLX.GLX_JournalType.Invoice, (byte)BL.GLX.GLX_JournalType.CreditNote, (byte)BL.GLX.GLX_JournalType.GoodsRecieved, (byte)BL.GLX.GLX_JournalType.GoodsReturned }).Contains(glxHeader.JournalTypeId.Value))
                {
                    btnViewDocument.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnReverseEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }  

                //54	REJECTED
                if (glxHeader.StatusId == (byte)BL.SYS.SYS_Status.Rejected)
                {
                    btnRejectEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnReverseEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnApproveEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnViewDocument.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                //NEVER MOVE THIS
                if (IsNew)
                {
                    //Werner : All button set to Never on screen may want to remove this
                    btnRejectEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnReverseEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnApproveEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnViewDocument.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnTrackHistory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                   itmAutoPost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                   itmNewTrackNumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Event for new GLX_Line
        /// * Selects Current Aging for new GLX_Line
        /// </summary>
        /// <remarks>Created: Werner Scheffer 22/11/2011</remarks>
        private void grvLines_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                var currentId = DataContext.EntityAccountingContext.GLX_Aging.FirstOrDefault(n => n.Code.Equals("000")).Id;
                
                grvLines.SetFocusedRowCellValue(grvLines.Columns["AgingId"], currentId);

                var glx_line = grvLines.GetRow(e.RowHandle) as DB.GLX_Line;
                glx_line.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Validates values on grvLines Rows
        /// * Checks if Ledger Account is selected
        /// * Checks if Transaction Reference has been entered
        /// </summary>
        /// <remarks>Created: Werner Scheffer 22/11/2011</remarks>
        private void grvLines_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                if (e.Row == null)
                    return;

                if (((DB.GLX_Line)(e.Row)).EntityId == 0)
                {
                    e.Valid = false;
                    grvLines.SetColumnError(colAccountId, "No Account Selected");
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Disables Validation exception MessageBox
        /// </summary>
        /// <remarks>Created: Werner Scheffer 22/11/2011</remarks>
        private void grvLines_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            try
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Assigns a Center and Aging to the current selected Account
        /// </summary>
        /// <remarks>Created: Werner Scheffer 22/12/2011</remarks>
        private void grvLines_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // TODO: DIE FIX ON EXC
            try
            {
                if (e.Column == colAccountId)
                {
                    // The ledger account has been selected
                    DB.GLX_Line FocusedRow = grvLines.GetRow(e.RowHandle) as DB.GLX_Line;

                    if (FocusedRow == null || (e.Value == null || Convert.ToInt64(e.Value) == 0))
                        return;

                    FocusedRow.CenterId = DataContext.ReadonlyContext.VW_Account.Where(n => n.Id == (long?)e.Value).Select(n=>n.CenterId).FirstOrDefault();
                    FocusedRow.AgingId = ((IEnumerable<DB.GLX_Aging>)ServerModeSourceAging.QueryableSource).Select(n => n.Id).FirstOrDefault();

                    //Int64 primarykey = (Int64)FocusedRow.GetType().GetProperty("Id").GetValue(FocusedRow, null);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Marks entry as Posted and effect the accounts on the current open entry
        /// </summary>
        /// <remarks>Created: Werner Scheffer 16/01/2012</remarks>
        private void btnApproveEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                (grdLines.MainView as DevExpress.XtraGrid.Views.Grid.GridView).PostEditor();
                grdLines.EndUpdate();

                IsValid = ValidateBeforeSave();
                if (!IsValid)
                    return;

                if (CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Approve Entry", "You are about to post these entries do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) == System.Windows.Forms.DialogResult.OK)
                //if (MessageBox.Show("You are about to post htis entry do you wish to continue ?", "Accept Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                { 
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            //SET POSTED DATE TO CURRENT DATE
                            glxHeader.PostedDate = BL.ApplicationDataContext.Instance.ServerDateTime.Date;
                            //MARK AS POSTED
                            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Posted;
                            //SAVE AND POST ENTRY
                            glxHeader.ReferencePeriodId = glxHeader.PeriodId;
                            DataContext.SaveChangesEntityAccountingContext();
                            BL.GLX.GLX_Header.Approve(glxHeader, DataContext);
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                    //CLOSE FORM AFTER ENTRY HAS BEEN POSTED
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                //DataContext.EntityAccountingContext.RollBackTransaction();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Rejects the current Entry Header
        /// </summary>
        /// <remarks>Created: Werner Scheffer 12/12/2011</remarks>
        private void btnRejectEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Warning", "You are about to reject this Entry are you sure you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            //REJECT ENTRY
                            glxHeader.StatusId = (byte)BL.SYS.SYS_Status.Rejected;
                            DataContext.SaveChangesEntityAccountingContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                    // Default behaviour is to open a new record
                    this.OnNewRecord();
                }
            } 
            catch (Exception ex)
            {
                //DataContext.EntityAccountingContext.RollBackTransaction();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Creates an Entry to reverce the effect of the current open entry.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 09/01/2012</remarks>
        private void btnReverseEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                EntryForm childForm = new EntryForm();
                childForm.AllowNavigate = false;
                childForm.glxHeader = BL.GLX.GLX_Header.CreateReversalEntry(glxHeader, DataContext);
                childForm.ItemState = EntityState.Generated;
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Opens the document linked to the current open entry.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 09/01/2012</remarks>
        private void btnViewDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ShowDocumentListForm(null, glxHeader.TrackId);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Openes the Track Histor screen for the current open Entry
        /// </summary>
        /// <remarks>Created: Theo Crous 12/12/2011</remarks>
        private void btnTrackHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtTrackNumber.Text) || txtTrackNumber.Text == "-1")
                {
                    CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Information", "No track number available.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                }
                else
                {
                    EntryList childForm = new EntryList();
                    childForm.ForceNew = true;
                    childForm.TrackId = Convert.ToInt64(txtTrackNumber.Text);
                    ShowForm(childForm);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void chkNewTrackNumber_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNewTrackNumber.Checked)
                {
                    glxHeader.TrackId = -1;
                    txtTrackNumber.Enabled = false;
                }
                else
                {
                    txtTrackNumber.Enabled = true;
                    if (glxHeader.TrackId == -1)
                        glxHeader.TrackId = -1;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Applies abbreviations to txtReference field.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 09/01/2012</remarks>
        private void txtReference_Properties_Leave(object sender, EventArgs e)
        {
            //Werner: Removed as per Task 375
            //txtReference.Text = PopulateAbbreviation(txtReference.Text);
        }

        /// <summary>
        /// Applies abbreviations to txtReference txtDescription.
        /// * btnRejectEntry
        /// </summary>
        /// <remarks>Created: Werner Scheffer 09/01/2012</remarks>
        private void txtDescription_Properties_Leave(object sender, EventArgs e)
        {
            //Werner: Removed as per Task 375
            //txtDescription.Text = PopulateAbbreviation(txtDescription.Text);
        }

        /// <summary>
        /// Stops user from selecting aging if the selected account is not a aging account.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 05/04/2012</remarks>
        private void grvLines_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).FocusedValue == null)
                    return;

                if ((sender as DevExpress.XtraGrid.Views.Grid.GridView).FocusedColumn == colAgingId)
                {
                    // The ledger account has been selected
                    DB.GLX_Line FocusedRow = grvLines.GetFocusedRow() as DB.GLX_Line;

                    if (!DataContext.EntityAccountingContext.GLX_Account.Where(n => n.EntityId == FocusedRow.EntityId).Select(n=>n.AgingAccount).FirstOrDefault())
                    {
                        e.Cancel = true;
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Delete selected line.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 03/05/2012</remarks>
        private void grvLines_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                    grvLines.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvLines_HiddenEditor(object sender, EventArgs e)
        {

            if (grvLines.FocusedColumn == colAccountId)
            {
                if ((grvLines.GetFocusedRow() as DB.GLX_Line) != null && (grvLines.GetFocusedRow() as DB.GLX_Line).EntityId == 0)
                {
                    glxHeader.GLX_Line.Remove(grvLines.GetFocusedRow() as DB.GLX_Line);
                }
            }
        }

        private void datDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void InstantFeedbackSourceAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;

            if ((BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRE03)))    // Harcoded Access: FIEN05 = 544, // Write to Control accounts )
            {
                //Check for Master accountant
                if((!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR) && accessType == "create") || (!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED) && accessType == "edit"))
                e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.SiteId == defaultSiteId);
                else
                    e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);

            }
            else
            {
                //Check for Master accountant
                if ((!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR) && accessType == "create") || (!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED) && accessType == "edit"))
                e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && n.CodeSub != "00000" && n.SiteId == defaultSiteId);
                else
                e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived.Equals(false) && n.CodeSub != "00000");
            }
        }
    }
}
