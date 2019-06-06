using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CDS.Client.Desktop.Essential.UTL;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;


//TODO:
//When paying open item invoice that happened in previous period, which aging needs to be updated?
namespace CDS.Client.Desktop.Accounting.Payment
{
    public partial class BasePaymentsForm : CDS.Client.Desktop.Essential.BaseForm
    {
        // Open Item Variables
        
        protected Dictionary<Int64, String> accountsColumns = new Dictionary<long, string>(); // Key = AccountId, Value = Column Name
        
        private string defaultPaymentAccountColumn = null;
        
        private bool appendCheckColumnFilter = true;
        
        protected List<DB.GLX_Aging> Agings { get { return BindingSourceAging.DataSource as List<DB.GLX_Aging>; } }        
        
        protected DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView PaymentGridView { get { return grvOpenItem; } }
        
        protected DataTable entriesDataSource { get { return (PaymentGridView.GridControl.DataSource as BindingSource).DataSource as DataTable; } }
        
        private bool HasLinesSelected
        {
            get
            {
                bool hasChecked = false;
                if (!this.DesignMode)
                {
                    for (int h = 0; h < grvOpenItem.RowCount; h++)
                    {
                        if (grvOpenItem.GetRowCellValue(h, grvOpenItem.Columns["colCheck"]) != null &&
                            !grvOpenItem.GetRowCellValue(h, grvOpenItem.Columns["colCheck"]).Equals(System.DBNull.Value) &&
                            Convert.ToBoolean(grvOpenItem.GetRowCellValue(h, grvOpenItem.Columns["colCheck"])))
                        {
                            hasChecked = true;
                            break;
                        }
                    }
                }

                return hasChecked;
            }
        }

        public BasePaymentsForm()
        {
            InitializeComponent();
        }

        public BasePaymentsForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void BindData()
        {
            base.BindData();

            ServerModeSourcePeriod.QueryableSource = DataContext.EntitySystemContext.SYS_Period.Where(n => n.StatusId != (byte)BL.SYS.SYS_Status.Open).OrderByDescending(n => n.StartDate);
            ServerModeSourceAging.QueryableSource = DataContext.EntityAccountingContext.GLX_Aging;
            BindingSourceAging.DataSource = DataContext.EntityAccountingContext.GLX_Aging.ToList();
        }

        /// <summary>
        /// Populates the Total column
        /// </summary>
        /// <remarks>Created: Werner Scheffer 14/08/2013</remarks>
        private void PopulateTotals()
        {
            foreach (DataRow row in entriesDataSource.Rows)
            {
                decimal total = 0;

                if (Convert.ToBoolean(row["colCheck"].ToString().Equals("True") ? 1 : 0))
                {
                    foreach (var pair in accountsColumns)
                    {
                        if (pair.Key != Convert.ToInt64(defaultPaymentAccountColumn.Replace("colReceived", "")))
                            row["colReceived" + pair.Key] = 0.00M;

                        total += Convert.ToDecimal(row["colReceived" + pair.Key]);
                    }
                    row["colTotal"] = total;
                }
                else
                {
                    row["colTotal"] = System.DBNull.Value;
                }
            }
            //entriesDataSource
        }

        protected void PopulateColumns()
        {
            try
            {
                if (!this.DesignMode)
                {
                    base.OnStart();

                    List<BL.GLX.PaymentAccount> accounts = BL.GLX.PaymentAccountSerializer.DeSerializePaymentAccounts(BL.ApplicationDataContext.Instance.CompanySite.PaymentAccounts, typeof(List<BL.GLX.PaymentAccount>));

                    if (accounts.Count == 0)
                    {
                        Essential.BaseAlert.ShowAlert("Invalid Payment Accounts", "Please setup Payment Accounts before you can continue", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        ReadOnly = true;
                    }

                    txtDate.EditValue = DateTime.Today;

                    // Bind Table 
                    (BindingSource.DataSource as DataTable).Columns.Add("colCheck", typeof(bool));
                    (BindingSource.DataSource as DataTable).Columns.Add("colEntryDate", typeof(DateTime));
                    (BindingSource.DataSource as DataTable).Columns.Add("colEntryReference", typeof(string));
                    (BindingSource.DataSource as DataTable).Columns.Add("colEntryAging", typeof(string));
                    (BindingSource.DataSource as DataTable).Columns.Add("colEntryAdditional", typeof(bool));


                    //BindingSource.DataSource = entriesDataSource;
                    //DevExpress.XtraGrid.Columns.GridColumn added = null;
                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn added = null;

                    //added = grvOpenItem.Columns.AddVisible("colEntryReference", "Reference");
                    //added.MaxWidth = added.MinWidth = added.Width = 80;
                    added = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() { Name = "colEntryReference", FieldName = "colEntryReference", Caption = "Reference", RowIndex = 0, MaxWidth = 80, MinWidth = 80, Width = 80, Visible = true };
                    added.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                    added.OptionsColumn.AllowIncrementalSearch = false;
                    added.OptionsColumn.AllowMove = false;
                    added.OptionsColumn.AllowShowHide = false;
                    added.OptionsFilter.AllowFilter = false;
                    grvOpenItem.Columns.Add(added);
                    grvOpenItem.Bands["gbAccounts"].Columns.Add(added);

                    //added = grvOpenItem.Columns.AddVisible("colEntryDate", "Date");
                    added = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() { Name = "colEntryDate", FieldName = "colEntryDate", Caption = "Date", RowIndex = 0, MaxWidth = 80, MinWidth = 80, Width = 80, Visible = true };
                    added.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                    added.OptionsColumn.AllowIncrementalSearch = false;
                    added.OptionsColumn.AllowMove = false;
                    added.OptionsColumn.AllowShowHide = false;
                    added.OptionsFilter.AllowFilter = false;
                    grvOpenItem.Columns.Add(added);
                    grvOpenItem.Bands["gbAccounts"].Columns.Add(added);

                    //added = grvOpenItem.Columns.AddVisible("colEntryAging", "Centre");
                    //added.MaxWidth = added.MinWidth = added.Width = 80;
                    added = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() { Name = "colEntryAging", FieldName = "colEntryAging", Caption = "Aging", RowIndex = 0, MaxWidth = 80, MinWidth = 80, Width = 80, Visible = true };
                    added.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                    added.OptionsColumn.AllowIncrementalSearch = false;
                    added.OptionsColumn.AllowMove = false;
                    added.OptionsColumn.AllowShowHide = false;
                    added.OptionsFilter.AllowFilter = false;
                    added.ColumnEdit = repddlAging;
                    grvOpenItem.Columns.Add(added);
                    grvOpenItem.Bands["gbAccounts"].Columns.Add(added);

                    BindingSourceAccounts.DataSource = accounts;

                    for (int i = 0; i < accounts.Count; i++)
                    {
                        if (accounts[i].AccountDefault)
                            chkAccount.SetItemChecked(i, true);
                    }
                    grvOpenItem.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Applies the filter on the grid view
        /// </summary>
        /// <remarks>Created: Werner Scheffer 14/08/2013</remarks>
        private void Applyfilter()
        {

            appendCheckColumnFilter = false;
            if (grvOpenItem.ActiveFilterString != String.Empty)
            {
                //grvOpenItem.ActiveFilter.Remove(colCheck);
                grvOpenItem.ActiveFilterString = grvOpenItem.ActiveFilterString.Replace(" Or [colCheck] = True", "");
                grvOpenItem.ActiveFilter.Remove(colTitle);
                grvOpenItem.ActiveFilter.Remove(colDate);
            }


            if (txtAccountFilter.Text != String.Empty)
                grvOpenItem.Columns["Title"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(String.Format("Contains([Title],'{0}')", txtAccountFilter.Text));

            if (txtDateFilter.DateTime != DateTime.MinValue)
                grvOpenItem.Columns["Date"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(String.Format("[Date] = #{0}#", txtDateFilter.DateTime.ToString("yyyy/MM/dd")));

            if (grvOpenItem.ActiveFilterString != String.Empty)
                //grvOpenItem.Columns["colCheck"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[colCheck] = true");
                grvOpenItem.ActiveFilterString = String.Format("( {0} ) Or [colCheck] = True", grvOpenItem.ActiveFilterString);

            appendCheckColumnFilter = true;
        }

        private void HighlightColumn(int focusedRowHandle, int prevFocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn focusedColumn, DevExpress.XtraGrid.Columns.GridColumn prevFocusedColumn)
        {
            if (!this.DesignMode)
            {
                DataRowView FocusedRow = grvOpenItem.GetRow(focusedRowHandle) as DataRowView;
                DataRowView PrevFocusedRow = grvOpenItem.GetRow(prevFocusedRowHandle) as DataRowView;

                if ((prevFocusedRowHandle % 2) > 0)
                {
                    prevFocusedColumn.AppearanceHeader.ForeColor = Color.Black;
                    prevFocusedColumn.AppearanceCell.BackColor = Color.White;
                }
                else
                {
                    prevFocusedColumn.AppearanceHeader.ForeColor = Color.Black;
                    prevFocusedColumn.AppearanceCell.BackColor = Color.FromArgb(240, 240, 240);
                }

                focusedColumn.AppearanceHeader.ForeColor = Color.Red;
                focusedColumn.AppearanceCell.BackColor = Color.Red;
            }
        }

        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = repCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = repCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        /// <summary>
        /// Add or remove an account to the payment reciept area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void chkAccount_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {

                BL.GLX.PaymentAccount account = ((List<BL.GLX.PaymentAccount>)BindingSourceAccounts.DataSource)[e.Index];

                string colname = "colReceived" + account.AccountId;

                if (account.AccountDefault || String.IsNullOrEmpty(defaultPaymentAccountColumn))
                    defaultPaymentAccountColumn = colname;

                //If default payment account is unchecked
                if (account.AccountDefault && e.State == CheckState.Unchecked)
                {
                    DB.GLX_Account defaultPaymentAccount = DataContext.EntityAccountingContext.GLX_Account.Where(n => ((List<BL.GLX.PaymentAccount>)BindingSourceAccounts.DataSource).Select(s => s.AccountId).Contains(n.Id) && !n.Id.Equals(account.AccountId)).FirstOrDefault();
                    if (defaultPaymentAccount == null)
                    {
                        chkAccount.SetItemChecked(e.Index, true);
                    }
                    else
                    {
                        bool found = false;

                        foreach (BL.GLX.PaymentAccount item in chkAccount.CheckedItems)
                        {
                            if (item.AccountId.Equals(defaultPaymentAccount.Id))
                            {
                                (((List<BL.GLX.PaymentAccount>)BindingSourceAccounts.DataSource)[e.Index]).AccountDefault = false;
                                ((List<BL.GLX.PaymentAccount>)BindingSourceAccounts.DataSource).Where(n => n.AccountId.Equals(defaultPaymentAccount.Id)).FirstOrDefault().AccountDefault = true;

                                defaultPaymentAccountColumn = "colReceived" + defaultPaymentAccount.Id;
                                found = true;

                                //Remove the old default payment colu
                                accountsColumns.Remove(account.AccountId);
                                grvOpenItem.Columns.Remove(grvOpenItem.Columns[colname]);
                                grvOpenItem.Bands["gbAccounts"].Columns.Remove(grvOpenItem.Columns[colname]);
                                entriesDataSource.Columns.Remove(entriesDataSource.Columns[colname]);

                                break;
                            }
                            
                        }

                        if (!found)
                            chkAccount.SetItemChecked(e.Index, true);

                        
                    }
                }
                else if (e.State == CheckState.Checked)
                {
                    //Iff account already in Accounts Column then ignore
                    if (accountsColumns.Select(n => n.Key).Contains(account.AccountId))
                        return;

                    accountsColumns.Add(account.AccountId, colname);

                    if (entriesDataSource != null)
                        entriesDataSource.Columns.Add(colname, typeof(decimal));

                    DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn added = null;
                    added = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() { Name = colname, FieldName = colname, Caption = account.AccountShortName, RowIndex = 1, Tag = account, MaxWidth = 80, MinWidth = 80, Width = 80, Visible = true };
                    //added.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    //added.DisplayFormat.FormatString = "# ### ### ##0.00
                    added.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    added.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
                    added.ColumnEdit = repCalcEdit;
                    added.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                    added.OptionsColumn.AllowIncrementalSearch = false;
                    added.OptionsColumn.AllowMove = false;
                    added.OptionsColumn.AllowShowHide = false;
                    added.OptionsFilter.AllowFilter = false;

                    grvOpenItem.Columns.Add(added);
                    grvOpenItem.Bands["gbAccounts"].Columns.Add(added);
                    //added.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colname, "{0:# ### ### ##0.00}"));
                    added.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colname, "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}"));
                }
                else
                {
                    accountsColumns.Remove(account.AccountId);
                    grvOpenItem.Columns.Remove(grvOpenItem.Columns[colname]);
                    grvOpenItem.Bands["gbAccounts"].Columns.Remove(grvOpenItem.Columns[colname]);
                    entriesDataSource.Columns.Remove(entriesDataSource.Columns[colname]);
                }

                if (grvOpenItem.Columns["colTotal"] != null)
                {
                    grvOpenItem.Columns.Remove(grvOpenItem.Columns["colTotal"]);
                    grvOpenItem.Bands["gbAccounts"].Columns.Remove(grvOpenItem.Columns["colTotal"]);
                    entriesDataSource.Columns.Remove(entriesDataSource.Columns["colTotal"]);
                }

                if (entriesDataSource != null)
                    entriesDataSource.Columns.Add("colTotal", typeof(decimal));

                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn total = null;
                total = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() { Name = "colTotal", FieldName = "colTotal", Caption = "Total", RowIndex = 1, Tag = "colTotal", MaxWidth = 120, MinWidth = 120, Width = 120, Visible = true };
                total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                total.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
                total.ColumnEdit = repCalcEdit;
                total.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
                total.OptionsColumn.AllowIncrementalSearch = false;
                total.OptionsColumn.AllowMove = false;
                total.OptionsColumn.AllowShowHide = false;
                total.OptionsFilter.AllowFilter = false;
                total.OptionsColumn.AllowEdit = false;

                grvOpenItem.Columns.Add(total);
                grvOpenItem.Bands["gbAccounts"].Columns.Add(total);
                total.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "colTotal", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00}"));

                foreach (var pair in accountsColumns)
                {
                    this.grvOpenItem.Columns[pair.Value].MinWidth = 240 / accountsColumns.Count;
                }
                grvOpenItem.Bands["gbAccounts"].Width = 240;

                PopulateTotals();
            }
            catch (Exception ex)
            {
 
            }
        }

        /// <summary>
        /// View the history of a track number. Rows with no track number will not do anything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void repViewTrackNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvOpenItem.FocusedRowHandle < 0)
                    return;

                DataRowView FocusedRow = grvOpenItem.GetFocusedRow() as DataRowView;

                if (FocusedRow["TrackNumber"] != DBNull.Value)
                {
                    //Int64 tracknumber = Convert.ToInt64(FocusedRow["TrackNumber"]);
                    //TrackList childForm = new TrackList();
                    Accounting.Entry.EntryList childForm = new Accounting.Entry.EntryList();
                    childForm.TrackId = Convert.ToInt64(FocusedRow["TrackNumber"]);
                    //childForm.OpenTrackNumber(tracknumber);
                    ShowForm(childForm);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Set the track number of a transaction. Rows with no track number will not do anything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void repSetTrackNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvOpenItem.FocusedRowHandle < 0)
                    return;

                DataRowView FocusedRow = grvOpenItem.GetFocusedRow() as DataRowView;

                if (FocusedRow["TrackNumber"] != System.DBNull.Value && FocusedRow["colCheck"] != System.DBNull.Value)
                {
                    Int64 lineid = Convert.ToInt64(FocusedRow["LineId"]);
                    Tracking.ChangeTrackingNumberDialogue childForm = new Tracking.ChangeTrackingNumberDialogue();
                    childForm.SetLineId(lineid);
                    grdOpenItem.Enabled = false;
                    if (childForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Int64 newnumber = childForm.GetNewTrackNumber();
                        BL.GLX.GLX_Header.UpdateTrackNumber(DataContext.ReadonlyContext.VW_Line.FirstOrDefault(n => n.Id == lineid).TrackId, newnumber, DataContext);
                        DataRow[] results = entriesDataSource.Select("TrackNumber=" + newnumber);
                        if (results.Length == 1)
                        {
                            // linked to a currently showing transaction
                            results[0]["Balance"] = Convert.ToDecimal(results[0]["Balance"]) + Convert.ToDecimal(FocusedRow["Balance"]);
                            entriesDataSource.Rows.Remove(FocusedRow.Row);

                            if (Convert.ToDecimal(results[0]["Balance"]) == 0)
                            {
                                entriesDataSource.Rows.Remove(results[0]);
                            }
                        }
                        grdOpenItem.BeginUpdate();
                        FocusedRow["TrackNumber"] = newnumber;
                        grdOpenItem.EndUpdate();
                    }
                    grdOpenItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Select this row to receive a payment for it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void repCheck_CheckedChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (grvOpenItem.FocusedRowHandle < 0)
                    return;

                DataRowView FocusedRow = grvOpenItem.GetFocusedRow() as DataRowView;

                FocusedRow["colCheck"] = (sender as DevExpress.XtraEditors.CheckEdit).Checked;

                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked)
                {
                    FocusedRow["colEntryDate"] = ((DateTime)txtDate.EditValue);

                    foreach (var acc in accountsColumns)
                    {
                        FocusedRow[acc.Value] = 0.00M;
                    }
            
                  
                    FocusedRow[defaultPaymentAccountColumn] = Convert.ToDecimal(FocusedRow["Balance"]);

                    if (FocusedRow["Type"] == null)
                        FocusedRow["Type"] = "-1";
                }
                else
                {
                    FocusedRow["colEntryReference"] = DBNull.Value;
                    FocusedRow["colEntryDate"] = DBNull.Value;
                    //FocusedRow[defaultPaymentAccountColumn] = DBNull.Value;
                    foreach (var acc in accountsColumns)
                    {
                        FocusedRow[acc.Value] = DBNull.Value;
                    }
                }

                grvOpenItem.RefreshRowCell(grvOpenItem.FocusedRowHandle, grvOpenItem.Columns["colEntryReference"]);
                grvOpenItem.RefreshRowCell(grvOpenItem.FocusedRowHandle, grvOpenItem.Columns["colEntryDate"]);
                grvOpenItem.RefreshRowCell(grvOpenItem.FocusedRowHandle, grvOpenItem.Columns[defaultPaymentAccountColumn]);

                if (!HasLinesSelected)
                {
                    pnlReceiveInto.Enabled = true;
                }

                ValidateLayout();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Insert an additional payable item into the current working set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void btnAddAdditionalPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AdditionalPaymentDialogue childForm = new AdditionalPaymentDialogue();
                childForm.Tag = this;
                childForm.PaymentAccounts = accountsColumns.Select(l=>l.Key).ToList();
                if (childForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    DataRow newrow = entriesDataSource.NewRow();
                    newrow["AccountId"] = childForm.DebtorAccountId;
                    newrow["Title"] = childForm.DebtorAccountTitle;
                    newrow["Description"] = childForm.Description;
                    newrow["Date"] = childForm.Date;
                    newrow["Balance"] = childForm.Amount;
                    newrow["Period"] = DataContext.EntitySystemContext.SYS_Period.Where(n => childForm.Date >= n.StartDate && childForm.Date <= n.EndDate).Select(n => n.Code).FirstOrDefault();
                    newrow["TrackNumber"] = childForm.TrackNumber;
                    newrow["LineId"] = -1;
                    //newrow["Reference"] = childForm.Reference;

                    newrow["colCheck"] = true;
                    newrow["colEntryDate"] = childForm.Date;
                    newrow["colEntryReference"] = childForm.Reference;
                    newrow["colEntryAdditional"] = true;
                    newrow["colEntryAging"] = Agings.Where(n => n.Code.Equals(childForm.Aging)).Select(n => n.Id).FirstOrDefault();
                    newrow["Aging"] = childForm.Aging;                    
                    newrow["colReceived" + childForm.PaymentAccountId] = childForm.Amount;
                    newrow["colTotal"] = childForm.Amount;
                    entriesDataSource.Rows.Add(newrow);
                    chkAccount.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Do not show editors unless the row has been checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void grvOpenItem_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvOpenItem.FocusedRowHandle < 0)
                return;

            DataRowView FocusedRow = grvOpenItem.GetFocusedRow() as DataRowView;
            //if (grvOpenItem.FocusedColumn.FieldName.StartsWith("colReceive") && (FocusedRow["colCheck"] == DBNull.Value || Convert.ToBoolean(FocusedRow["colCheck"]) == false))



            //If this entry was added from aditional payment make line readonly
            bool additionalPayment = false;
            Boolean.TryParse(FocusedRow["colEntryAdditional"].ToString(), out additionalPayment);
            if ((grvOpenItem.FocusedColumn.FieldName.Equals("colEntryDate") || grvOpenItem.FocusedColumn.FieldName.Equals("colEntryAging")) && additionalPayment)
            {
                e.Cancel = true;
            }
            else
                //If line not Checked Cancel
                if (!grvOpenItem.FocusedColumn.FieldName.Equals("colViewTrackNumber") && !grvOpenItem.FocusedColumn.FieldName.Equals("colCheck") && (FocusedRow["colCheck"] == DBNull.Value || Convert.ToBoolean(FocusedRow["colCheck"]) == false))
                {
                    e.Cancel = true;
                }
        }

        /// <summary>
        /// Change the color of selected rows to highlight them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void grvOpenItem_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (!this.DesignMode)
            {
                DataRowView FocusedRow = grvOpenItem.GetRow(e.RowHandle) as DataRowView;

                if (FocusedRow != null && (FocusedRow["colCheck"] != DBNull.Value && Convert.ToBoolean(FocusedRow["colCheck"])))
                    e.Appearance.BackColor = Color.FromArgb(249, 239, 187);
            }
        }

        /// <summary>
        /// Stop user from de selecting the last receiving account. Must always have at least one account selected!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Theo Crous 23/08/2012</remarks>
        private void chkAccount_ItemChecking(object sender, DevExpress.XtraEditors.Controls.ItemCheckingEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked && chkAccount.CheckedItems.Count == 1)
                e.Cancel = true;

            BL.GLX.PaymentAccount account = ((List<BL.GLX.PaymentAccount>)BindingSourceAccounts.DataSource)[e.Index];
            long? taxTypeEntityId = DataContext.EntityAccountingContext.GLX_Tax.Where(n => n.Id == account.TaxId).Select(n => n.EntityId).FirstOrDefault();
            if (e.NewValue == CheckState.Checked && (taxTypeEntityId == null || taxTypeEntityId == 0))
            {
                Essential.BaseAlert.ShowAlert("No TAX Account", "Tax type for selected account has no tax account please assign one before trying to use this account again", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                ReadOnly = true;
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// Clears the filter on the grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 14/08/2013</remarks>
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            grvOpenItem.ActiveFilterString = String.Empty;
            //txtDateFilter.DateTime = DateTime.MinValue;
            txtDateFilter.EditValue = String.Empty;
            txtAccountFilter.Text = String.Empty;
        }

        /// <summary>
        /// Runs when Enter is pressed on the text box and applies filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 14/08/2013</remarks>
        private void txtAccountFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Applyfilter();
        }

        /// <summary>
        /// Runs when date filter is changed and applies filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 14/08/2013</remarks>
        private void txtDateFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Applyfilter();
        }

        /// <summary>
        /// Handels and cell changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 14/08/2013</remarks>
        private void grvOpenItem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView FocusedRow = grvOpenItem.GetFocusedRow() as DataRowView;

            bool rowchecked = false;

            Boolean.TryParse(e.Value.ToString(), out rowchecked);

            if (grvOpenItem.FocusedColumn.Equals(colCheck))
            {
                if (rowchecked)
                {
                    pnlReceiveInto.Enabled = false;

                    //If you change default payment accounts value set the other accounts to Zero
                    if (defaultPaymentAccountColumn == e.Column.FieldName)
                    {
                        foreach (var acc in accountsColumns)
                        {
                            if (FocusedRow[acc.Value] != System.DBNull.Value && acc.Value != defaultPaymentAccountColumn)
                                FocusedRow[acc.Value] = 0;
                        }
                    }

                    if (FocusedRow["colTotal"] == System.DBNull.Value)
                    {
                        FocusedRow[defaultPaymentAccountColumn] = Convert.ToDecimal(FocusedRow["Balance"]);
                    }

                    if (FocusedRow["Type"].Equals("BBF"))
                    {
                        FocusedRow["colEntryAging"] = Agings.Where(n => n.Code.Equals(FocusedRow["Aging"])).Select(n => n.Id).FirstOrDefault();
                    }
                    else if (FocusedRow["Type"].Equals("OI"))
                    {
                        DateTime entryDate = Convert.ToDateTime(FocusedRow["colEntryDate"]);
                        entryDate = entryDate.AddDays(-(entryDate.Day - 1));
                        DateTime date = Convert.ToDateTime(FocusedRow["Date"]);
                        date = date.AddDays(-(date.Day - 1));

                        int monthDiff = (int)entryDate.Subtract(date).Days / (365 / 12);

                        if (monthDiff >= 5)
                        {
                            FocusedRow["colEntryAging"] = 5;
                        }
                        else
                        {
                            FocusedRow["colEntryAging"] = monthDiff + 1;
                        }
                    }

                }
                else
                {

                    if (grvOpenItem.FocusedColumn.Equals(colCheck))
                        FocusedRow["colEntryAging"] = System.DBNull.Value;
                }
            }
            else if (grvOpenItem.FocusedColumn.FieldName.Equals("colEntryDate"))
            {
                if (FocusedRow["Type"].Equals("BBF"))
                {
                    DateTime entryDate = Convert.ToDateTime(FocusedRow["colEntryDate"]);
                    entryDate = entryDate.AddDays(-(entryDate.Day - 1));
                    DateTime date = Convert.ToDateTime(FocusedRow["Date"]);
                    date = date.AddDays(-(date.Day - 1));

                    int monthDiff = (int)date.Subtract(entryDate).Days / (365 / 12);

                    //Date in the future then dont change aging
                    if (monthDiff <= 0)
                    {
                        FocusedRow["colEntryAging"] = Agings.Where(n => n.Code.Equals(FocusedRow["Aging"])).Select(n => n.Id).FirstOrDefault();
                    }
                    //If date in the aging range then calculate
                    if (monthDiff > 0 && monthDiff < 5)
                    {
                        FocusedRow["colEntryAging"] = Agings.Where(n => n.Code.Equals(FocusedRow["Aging"])).Select(n => n.Id).FirstOrDefault() - monthDiff;
                    }
                    //If date more than 4 months back then use current
                    if (monthDiff > 4)
                    {
                        FocusedRow["colEntryAging"] = 1;
                    }
                }
                else if (FocusedRow["Type"].Equals("OI"))
                {
                    DateTime entryDate = Convert.ToDateTime(FocusedRow["colEntryDate"]);
                    entryDate = entryDate.AddDays(-(entryDate.Day - 1));
                    DateTime date = Convert.ToDateTime(FocusedRow["Date"]);
                    date = date.AddDays(-(date.Day - 1));

                    int monthDiff = (int)entryDate.Subtract(date).Days / (365 / 12);

                    if (monthDiff < 0)
                    {
                        FocusedRow["colEntryAging"] = 1;
                    }
                    else
                        if (monthDiff >= 5)
                        {
                            FocusedRow["colEntryAging"] = 5;
                        }
                        else
                        {
                            FocusedRow["colEntryAging"] = monthDiff + 1;
                        }
                }

            }
            else if (grvOpenItem.FocusedColumn.FieldName.StartsWith("colReceive"))
            {
                //If changed cel value is not default payment accounts cell
                if (defaultPaymentAccountColumn != e.Column.FieldName)
                {
                    decimal defaultPaymentAccountValue = 0M;

                    foreach (var acc in accountsColumns)
                    {
                        if (acc.Value != defaultPaymentAccountColumn)
                            defaultPaymentAccountValue += Convert.ToDecimal(FocusedRow[acc.Value] == System.DBNull.Value ? 0 : FocusedRow[acc.Value]);
                    }

                    if (FocusedRow["colTotal"] == System.DBNull.Value)
                    {
                        FocusedRow[defaultPaymentAccountColumn] = Convert.ToDecimal(FocusedRow["Balance"]);
                    }
                    else
                    {
                        FocusedRow[defaultPaymentAccountColumn] = Convert.ToDecimal(FocusedRow["colTotal"] == System.DBNull.Value ? 0 : FocusedRow["colTotal"]) - defaultPaymentAccountValue;
                    }
                }
            }

            decimal sum = 0M;

            foreach (var acc in accountsColumns)
            {
                sum += Convert.ToDecimal(FocusedRow[acc.Value] == System.DBNull.Value ? 0 : FocusedRow[acc.Value]);
            }

            if (sum.Equals(0))
                FocusedRow["colTotal"] = System.DBNull.Value;
            else
                FocusedRow["colTotal"] = sum;
        }

        private void grvOpenItem_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            //HighlightColumn(grvOpenItem.FocusedRowHandle, grvOpenItem.FocusedRowHandle, e.FocusedColumn, e.PrevFocusedColumn);
        }

        private void grvOpenItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //HighlightColumn(e.FocusedRowHandle, e.PrevFocusedRowHandle, grvOpenItem.FocusedColumn, grvOpenItem.FocusedColumn);
        }

        private void grvOpenItem_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.Equals(colCheck))
            {
                if (HasLinesSelected)
                {
                    e.Info.InnerElements.Clear();
                    e.Painter.DrawObject(e.Info);
                    DrawCheckBox(e.Graphics, e.Bounds, true);
                    e.Handled = true;
                }
            }
        }
        
        private void grvOpenItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (grvOpenItem.CalcHitInfo(e.X, e.Y).HitTest == DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitTest.Column && grvOpenItem.CalcHitInfo(e.X, e.Y).Column.FieldName.Equals("colCheck") && HasLinesSelected)
            {
                if (!(Essential.BaseAlert.ShowAlert("Selected Payments", "You are about to clear all payments do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK))
                    return;

                for (int h = 0; h < grvOpenItem.RowCount; h++)
                {
                    if (!grvOpenItem.GetRowCellValue(h, grvOpenItem.Columns["colCheck"]).Equals(System.DBNull.Value) && Convert.ToBoolean(grvOpenItem.GetRowCellValue(h, grvOpenItem.Columns["colCheck"])))
                    {
                        grvOpenItem.GetDataRow(h)["colCheck"] = false;
                        grvOpenItem.FocusedRowHandle = h;
                        //grvOpenItem.SetRowCellValue(h, grvOpenItem.Columns["colCheck"], false);
                        grvOpenItem.SetRowCellValue(h, grvOpenItem.Columns["colEntryAging"], System.DBNull.Value);
                        //grvOpenItem.SetRowCellValue(h, grvOpenItem.Columns["colTotal"], System.DBNull.Value);
                        repCheck_CheckedChanged(new DevExpress.XtraEditors.CheckEdit() { Checked = false, CheckState = System.Windows.Forms.CheckState.Unchecked }, EventArgs.Empty);
                        /*
                        grvOpenItem.SetRowCellValue(h, grvOpenItem.Columns["colEntryReference"], DBNull.Value);
                        grvOpenItem.SetRowCellValue(h, grvOpenItem.Columns["colEntryDate"],DBNull.Value);
                        
                        
                        foreach (var acc in accountsColumns)
                        {
                            grvOpenItem.SetRowCellValue(h, grvOpenItem.Columns[acc.Value], DBNull.Value);
                        }
                        grvOpenItem.SetRowCellValue(h, grvOpenItem.Columns["colCheck"], false);

                        grvOpenItem.GetDataRow(h)["colEntryReference"]=DBNull.Value;
                        grvOpenItem.GetDataRow(h)["colEntryDate"]=DBNull.Value;
                        grvOpenItem.GetDataRow(h)["colEntryAging"]=System.DBNull.Value;

                        foreach (var acc in accountsColumns)
                        {
                            grvOpenItem.GetDataRow(h)[acc.Value] = DBNull.Value;
                        }
                        grvOpenItem.GetDataRow(h)["colCheck"] = false;*/
                    }
                }

                if (!HasLinesSelected)
                {
                    pnlReceiveInto.Enabled = true;
                }

                PopulateTotals();

            }
        }

        private void repddlAging_Enter(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate { ((DevExpress.XtraEditors.LookUpEdit)sender).ShowPopup(); }));
        }

        private void grvOpenItem_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (appendCheckColumnFilter)
                if (grvOpenItem.ActiveFilterString.Contains("Or [colCheck] = True") && !grvOpenItem.ActiveFilterString.EndsWith("Or [colCheck] = True"))
                {
                    grvOpenItem.ActiveFilter.Remove(colCheck);
                    grvOpenItem.ActiveFilterString = String.Format("( {0} ) Or [colCheck] = True", grvOpenItem.ActiveFilterString.Replace(" Or [colCheck] = True", ""));
                }

        }

    }

}