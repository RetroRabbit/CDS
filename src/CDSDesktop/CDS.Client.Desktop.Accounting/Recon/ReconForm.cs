using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraPrinting;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;
using System.Threading.Tasks;


namespace CDS.Client.Desktop.Accounting
{
    public partial class ReconForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.GLX_Recon glxRecon;
        List<Int64> changeset = new List<Int64>(); // Stores line ids of check changed
        DB.VW_Recon openRecordRecon;
        bool isNew = false;

        /// <summary>
        /// Get or Set the Account Id for this recon.
        /// </summary>
        /// <remarks>Created: Theo Crous 27/08/2012</remarks>
        public Int64? AccountId { get; set; }

        /// <summary>
        /// Boolean that returns true if Document has never been submitted to the database (Is a new document)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (glxRecon != null)
                    return (DataContext.EntityAccountingContext.GetEntityState(glxRecon) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        public ReconForm()
        {
            InitializeComponent();
        }

        public ReconForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        /// <summary>
        /// Bind all the required lookup values.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        public override void OpenRecord(Int64 Id)
        {
            base.OpenRecord(Id);
            try
            {
                glxRecon = BL.GLX.GLX_Recon.Load(Id, DataContext);
                openRecordRecon = DataContext.ReadonlyContext.VW_Recon.FirstOrDefault(n => n.Id == (int)Id);
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
                    (grdLines.MainView as DevExpress.XtraGrid.Views.Grid.GridView).PostEditor();
                    grdLines.EndUpdate();

                    this.OnSaveRecord();
                    try
                    {
                        foreach (var lineid in changeset)
                        {
                            BL.GLX.GLX_Line.Load(lineid, DataContext).ReconId =
                                ((List<DB.VW_Line>)BindingSourceLines.DataSource).FirstOrDefault(n => n.Id == lineid).ReconId.HasValue ?
                                    ((DataAccessLayer.DB.GLX_Recon)BindingSource.DataSource).Id : (Int64?)null;
                        } 

                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveGLX_Recon((DataAccessLayer.DB.GLX_Recon)BindingSource.DataSource, DataContext);
                            DataContext.SaveChangesEntityAccountingContext(); 
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityAccountingContext.AcceptAllChanges(); 
                        return true;
                    }
                    catch (Exception ex)
                    {
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
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Save the record currently displayed in the form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
        }

        /// <summary>
        /// Bind all the required lookup values.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                AllowArchive = false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = glxRecon;
            ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
            RecalcProvidedTotal();
        }

        /// <summary>
        /// Bind a blank new record to the form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                isNew = true;
                glxRecon = BL.GLX.GLX_Recon.New;
                BindingSourceLines.DataSource = null;
                btnCancelRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                changeset = new List<Int64>();
                RecalcLineTotal();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();

            btnCloseRecon.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIRERE03) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancelRecon.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIRERE03) == true ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            
            if (!IsNew)
            {
                ddlAccount.Enabled = false;
            }
            else
            {
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                btnCloseRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnCancelRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if (glxRecon.StatusId == 51)
            {
                this.ReadOnly = true;
                btnCloseRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnCancelRecon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIREREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIRERECR);
        }

        /// <summary>
        /// Checks if Start Amount + Movement = End Amount.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 01/12/2011</remarks>
        private bool ReconBalances()
        {
            try
            {
                return Convert.ToInt64(txtDiscrepencyTotal.EditValue) == 0;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks that Lines Have been selected.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 01/12/2011</remarks>
        private bool HasValidLines()
        {
            try
            {
                bool isValid = false;
                for (int h = 0; h < grvLines.RowCount; h++)
                {
                    if (Convert.ToBoolean(grvLines.GetRowCellValue(h, grvLines.Columns["IsReconned"])))
                    {
                        isValid = true;
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
        /// * Has Valid Lines
        /// * Is Account On Lines Valid
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 01/12/2011</remarks>
        private bool ValidateBeforeClose()
        {
            try
            {
                bool isValid = true;

                if (!HasValidLines())
                {
                    CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Error", "Recon has no valid lines.\nPlease select recon entries and try again.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    isValid = false;
                }

                if (!ReconBalances())
                {
                    CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Error", "Recon does not balance, please check entries.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
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
        /// Recalculate the total of selected lines.
        /// </summary>
        /// <remarks>Created: Theo Crous 28/08/2012</remarks>
        private void RecalcLineTotal()
        {
            List<DB.VW_Line> list = (List<DB.VW_Line>)BindingSourceLines.DataSource;

            if (list != null)
                txtLineTotal.EditValue = list.Where(n => n.IsReconned.Value).Sum(n => n.Amount);
            else
                txtLineTotal.EditValue = 0;
        }

        /// <summary>
        /// Recalculate the total provided by the user.
        /// </summary>
        /// <remarks>Created: Theo Crous 28/08/2012</remarks>
        private void RecalcProvidedTotal()
        {
            txtProvidedTotal.EditValue = glxRecon.EndAmount - glxRecon.StartAmount;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Essential.GridFilterDefaults.ApplyStandards(new List<DevExpress.XtraGrid.Views.Grid.GridView> { grvLines });
            if (AccountId.HasValue)
            {
                ddlAccount.EditValue = AccountId.Value;
            }
        }

        /// <summary>
        /// Bind Lines according to the selected account.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/11/2011</remarks>
        private void ddlAccount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAccount.EditValue != DBNull.Value && Convert.ToInt64(ddlAccount.EditValue) != -1)
                {
                    if (openRecordRecon != null && Convert.ToInt64(ddlAccount.EditValue) != openRecordRecon.EntityId)
                         glxRecon.EntityId = openRecordRecon.EntityId;

                    Int64 reconId = glxRecon.Id;
                    Int64 accountId = Convert.ToInt64(ddlAccount.EditValue);

                    //If new get all the lines for that account
                    if (IsNew)
                    { 
                        BindingSourceLines.DataSource = DataContext.ReadonlyContext.VW_Line.Where(n => n.AccountId == accountId && n.IsReconned == false).ToList();
                    }
                    //If closed get only linked lines
                    else if (glxRecon.StatusId == (byte)BL.SYS.SYS_Status.Closed)
                    { 
                        BindingSourceLines.DataSource = DataContext.ReadonlyContext.VW_Line.Where(n => n.AccountId == accountId && n.ReconId == reconId).ToList();
                    }
                    //If not closed get linked and unlinked lines for account
                    else
                    { 
                        BindingSourceLines.DataSource = DataContext.ReadonlyContext.VW_Line.Where(n => n.AccountId == accountId && (n.ReconId == reconId || n.ReconId == null)).ToList();
                    }

                    changeset = new List<Int64>();
                    RecalcLineTotal();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Closes the Current Recon.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 16/02/2012</remarks>
        private void btnCloseRecon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                IsValid = ValidateBeforeClose();
                if (!IsValid)
                    return;

                if ((CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Notification", "Please note that you are about to permanently Close this Recon.\nDo you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK))
                {

                    ((DataAccessLayer.DB.GLX_Recon)BindingSource.DataSource).StatusId = (byte)BL.SYS.SYS_Status.Closed;
                    SaveSuccessful();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// DELETES the Current Recon.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 16/02/2012</remarks>
        private void btnCancelRecon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Notification", "Please note that you are about to permanently Cancel this Recon.\nDo you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            ((DataAccessLayer.DB.GLX_Recon)BindingSource.DataSource).StatusId = (byte)BL.SYS.SYS_Status.Rejected;
                            DataContext.SaveChangesEntityAccountingContext();
                            BL.GLX.GLX_Recon.RejectRecon((DB.GLX_Recon)BindingSource.DataSource, DataContext);
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }

                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Keeps track of which lines should be linked to current recon.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 16/02/2012</remarks>
        private void grvLines_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (grvLines.FocusedRowHandle < 0)
                    return;

                DB.VW_Line FocusedRow = grvLines.GetFocusedRow() as DB.VW_Line;

                DataAccessLayer.DB.GLX_Recon recon = (BindingSource.DataSource as DataAccessLayer.DB.GLX_Recon);

                if (FocusedRow.IsReconned.Value)
                    FocusedRow.ReconId = recon.Id;
                else
                    FocusedRow.ReconId = null;

                changeset.Add(FocusedRow.Id);




                RecalcLineTotal();
                /*



                if (reconLines.Count() == 0)
                {
                    PopulateReconLines();
                }

                if ((sender as DevExpress.XtraGrid.Views.Grid.GridView).FocusedColumn == colSelected)
                {
                    //IF LINE IN RECON LINE LIST
                    if (reconLines.Where(n => n.Key == ((DB.VW_Line)grvLines.GetFocusedRow()).LineId).Count() > 0)
                    {
                        //UPDATE BOOL
                        reconLines[Convert.ToInt64(((DB.VW_Line)grvLines.GetFocusedRow()).LineId)] = Convert.ToBoolean(e.Value);
                    }
                    else
                    {
                        //ADD ITEM TO LIST
                        reconLines.Add(Convert.ToInt64(((DB.VW_Line)grvLines.GetFocusedRow()).LineId), Convert.ToBoolean(e.Value));
                    }
                }
                ReconBalances();*/
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 27/08/2012</remarks>
        private void txtLineTotal_EditValueChanged(object sender, EventArgs e)
        {
            txtDiscrepencyTotal.EditValue = Convert.ToDecimal(txtProvidedTotal.EditValue) - Convert.ToDecimal(txtLineTotal.EditValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 27/08/2012</remarks>
        private void txtStartAmount_Validated(object sender, EventArgs e)
        {
            RecalcProvidedTotal();
        }

        /// <summary>
        /// Change the color of selected rows to highlight them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 28/08/2012</remarks>
        private void grvLines_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DB.VW_Line FocusedRow = grvLines.GetRow(e.RowHandle) as DB.VW_Line;

            if (FocusedRow == null)
                return;

            if ((FocusedRow.IsReconned.HasValue && FocusedRow.IsReconned.Value))
                e.Appearance.BackColor = Color.FromArgb(249, 239, 187);
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            grvLines.PostEditor();
        }

        private void InstantFeedbackSourceAccount_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            if ((BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARECR) && isNew) || (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAAREED) && !isNew)) {
                e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false);
            }
            else
            {
                long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
                e.QueryableSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.Archived == false && n.SiteId == defaultSiteId);
            }
        }
    }
}
