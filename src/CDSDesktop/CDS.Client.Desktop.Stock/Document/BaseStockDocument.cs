using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;

namespace CDS.Client.Desktop.Stock.Document
{
    public partial class BaseStockDocument : CDS.Client.Desktop.Essential.BaseForm
    {
        public DB.SYS_DOC_Header Doc_Header;
        protected List<DB.SYS_DOC_Line> lines = new List<DB.SYS_DOC_Line>();
        private Color tabColor = Color.LightGray;
        private BL.SYS.SYS_DOC_Type documentType = BL.SYS.SYS_DOC_Type.InventoryAdjustment;
        private decimal total;
        private decimal totaltax;
        private decimal totalIncl;

        /// <summary>
        /// Boolean that returns true if Document has never been submited to the database (Is a new document)
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        protected bool IsNew
        {
            get
            {
                if (Doc_Header != null)
                    return (DataContext.EntitySystemContext.GetEntityState(Doc_Header) == System.Data.Entity.EntityState.Detached);
                else
                    return false;
            }
        }

        /// <summary>
        /// Sets or gets the tab color.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2013</remarks>
        [BrowsableAttribute(true)]
        public Color TabColor { get { return tabColor; } set { tabColor = value; } }

        /// <summary>
        /// Used to identity the Company Lookups Type
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2013</remarks>
        [BrowsableAttribute(true)]
        public BL.SYS.SYS_DOC_Type DocumentType { get { return documentType; } set { documentType = value; } }

        protected DB.SYS_DOC_Line SelectedLine
        {
            get { return grvItems.GetRow(grvItems.FocusedRowHandle) as DB.SYS_DOC_Line; }
        }

        public decimal Total
        {
            get { return lines.Sum(n => n.Total); }
            internal set { total = value; }
        }

        public decimal TotalTax
        {
            get { return lines.Sum(n => n.TotalTax); }
            internal set { totaltax = value; }
        }

        public decimal TotalIncl
        {
            get
            {
                if (lines == null)
                    throw new Exception("The Lines object should always be populated and bound to the BindingSourceLines");

                if (lines.Count == 0)
                    return 0.00M;

                return lines.Sum(n => n.TotalAmount);
            }
            internal set { totalIncl = value; }
        }

        public override string Description
        {
            get
            {
                return string.Format("{0}, TotalExcl : {1} TotalTax : {2}", base.Description, Total.ToString(), TotalTax.ToString());
            }
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                isValid = IsLinesValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsLinesValid()
        {
            bool IsValid = true;

            return IsValid;
        }

        public BaseStockDocument()
        {
            InitializeComponent();
        }

        public BaseStockDocument(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = Doc_Header;
            foreach (DB.SYS_DOC_Line line in Doc_Header.SYS_DOC_Line)
            {
                // Must populate line Parent for use in calculate totals
                if (line.LineItem == null)
                    line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);
                lines.Add(line);
            }
            BindingSourceLine.DataSource = lines;

            if (ItemState == EntityState.Recovered)
                SetUnsavedIcon();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override bool SaveSuccessful()
        {
            if (!AllowSave)
                return false;

            try
            {
                this.OnSaveRecord();
                if (!IsValid)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                HasErrors = true;
                CurrentException = ex;
                ((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line.Clear();
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            Doc_Header = BL.SYS.SYS_DOC_Header.Load(Id, DataContext, new List<String>() { "SYS_DOC_Line" });
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = false;
            AllowSave = false;
        }

        public override void Recover(List<BindingSource> bindingSources)
        {
            base.Recover(bindingSources);
            Doc_Header = (BindingSource.DataSource as DB.SYS_DOC_Header);
            if (lines.Any())
                grvItems.OptionsBehavior.Editable = true;
            ItemState = EntityState.Recovered;
        }

        private void LoadGridLayout()
        {
            string screenName = grdItems.Parent.Parent.GetType().FullName;
            DB.SYS_Layout sys_layout = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == screenName + "Grid");
            if (sys_layout != null)
            {
                System.Xml.XmlDocument XmlDoc = new System.Xml.XmlDocument();
                XmlDoc.LoadXml(sys_layout.Custom);
                System.IO.Stream Layout = new System.IO.MemoryStream();
                XmlDoc.Save(Layout);
                Layout.Seek(0, System.IO.SeekOrigin.Begin);
                grvItems.RestoreLayoutFromStream(Layout);
            }
        }

        /// <summary>
        /// Calculate a lines Total and Tax?????
        /// </summary>
        /// <param name="line">The line wich totals you wish to calculate</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void CalculateLineTotals(DB.SYS_DOC_Line line)
        {
            // Accounts do not have a quantity also not allowed to change qty so always use 1 if Parent Type = 5 (Account)
            line.Total = Math.Round(line.Amount * (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account ? 1 : line.Quantity), 2, MidpointRounding.AwayFromZero);
            line.TotalTax = 0.00M;
            
        }

        /// <summary>
        /// Calculates document totals, including rounding.
        /// </summary>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void CalculateDocumentTotals()
        {
            decimal totalExcl = 0.00M, totalTax = 0.00M, totalIncl = 0.00M, totalRounding = 0.00M;

            lines.ForEach(n => totalExcl += n.Total);
            lines.ForEach(n => totalTax += n.TotalTax);
            lines.ForEach(n => totalIncl += (n.Total + n.TotalTax));
            // Henko: Will implement 2 seperate rounding settings for sales and purchase documents (then move this to BL SYS_DOC_Header)
            switch (documentType)
            {
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    totalRounding = BL.SYS.SYS_DOC_Document.CalculateRounding(totalIncl);
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    totalRounding = BL.SYS.SYS_DOC_Document.CalculateRounding(totalIncl);
                    break;
                case BL.SYS.SYS_DOC_Type.Quote:
                    totalRounding = BL.SYS.SYS_DOC_Document.CalculateRounding(totalIncl);
                    break;
            }

            Doc_Header.ORG_TRX_Header.Rounding = totalRounding;
        }

        /// <summary>
        /// Populates a newly added lines fields from the parent item
        /// </summary>
        /// <param name="line">The new line that needs to be populated</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void PopulateNewLine(DB.SYS_DOC_Line line)
        {
            if (line == null || line.LineItem == null)
                return;

            if (DocumentType == BL.SYS.SYS_DOC_Type.Quote || DocumentType == BL.SYS.SYS_DOC_Type.JobQuote)
                line.Quantity = 1;

            line.Description = line.LineItem.Description;
            line.UnitAverage = line.LineItem.UnitAverage;
            line.UnitCost = line.LineItem.UnitCost;
            //Only populate LineOrder if not previously set
            // WHEN will you reach this code and the lineOrder has already be set???
            line.LineOrder = line.LineOrder == 0 ? ((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource).Count() : line.LineOrder;

            SetLineAmount(line);
        }

        /// <summary>
        /// Sets the lines amount value
        /// </summary>
        /// <param name="line">The current line that needs to be populated</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void SetLineAmount(DB.SYS_DOC_Line line)
        {
            line.Amount = line.LineItem.UnitAverage;
            CalculateLineTotals(line);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void ValidateLineQuantity(DB.SYS_DOC_Line line)
        {
            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
            }
            CalculateLineTotals(line);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!DesignMode)
            {
                this.Text = String.Format("{0}",
                       DataContext.EntitySystemContext.SYS_DOC_Type.FirstOrDefault(n => n.Id == ((DB.SYS_DOC_Header)BindingSource.DataSource).TypeId).Name);

                this.Text += ((DB.SYS_DOC_Header)BindingSource.DataSource).DocumentNumber != null ? string.Format(" - {0}", ((DB.SYS_DOC_Header)BindingSource.DataSource).DocumentNumber) : "";
                this.SuperTipParameter = this.Text + "," + this.Text;
                foreach (DB.SYS_DOC_Line line in lines)
                {
                    CalculateLineTotals(line);
                }
            }
        }

        private void BaseStockDocument_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    BaseStockDocument_FormClosing(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
                    break;
            }
        }

        private void BaseStockDocument_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void grvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DB.SYS_DOC_Line line = (grvItems.GetFocusedRow() as DB.SYS_DOC_Line);
            switch (e.Column.FieldName)
            {
                //Handeled by Repository Item
                case "ItemId":
                    if (BL.ApplicationDataContext.Instance.CompanySite.UseBarcodes)
                    {
                        line.Quantity = 1M;
                        grvItems.FocusedColumn = colAmount;
                    }
                    //Populate all fields for this items line
                    PopulateNewLine(line);
                    break;
                case "Quantity":
                    ValidateLineQuantity(line);
                    break;
            }
            CalculateDocumentTotals();
            grvItems.InvalidateRowCell(e.RowHandle, colTotal);
            ValidateLayout();
        }

        private void grvItems_KeyDown(object sender, KeyEventArgs e)
        {
            //Delete selected Line
            if (!this.ReadOnly && e.Control && e.KeyCode == Keys.R && !colItemId.OptionsColumn.ReadOnly)
            {
                if (Essential.BaseAlert.ShowAlert("Delete Line", "You are about to delete the seleced line do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    grvItems.DeleteSelectedRows();
                    for (int i = 0; i < ((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource).Count(); i++)
                    {
                        //Only populate LineOrder if not previously set
                        ((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource)[i].LineOrder = ((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource)[i].LineOrder == 0 ? i + 1 : ((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource)[i].LineOrder;
                        CalculateLineTotals(((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource)[i]);
                    }
                    CalculateDocumentTotals();
                }
            }
            //Open Inventory
            else if (e.Control && e.KeyCode == Keys.I && BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSTRE))
            {
                ValidateLayout();

                if (SelectedLine == null || SelectedLine.ItemId == 0)
                    return;

                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    var mainform = Application.OpenForms["MainForm"];
                    Type typExternal = mainform.GetType();
                    System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowInventoryTransactionForm");

                    methodInf.Invoke(mainform, new object[] { SelectedLine.ItemId });
                }
            }
            else if (!this.ReadOnly && e.KeyCode == Keys.Enter)
            {
                if (SelectedLine == null && lines.Count > 0)
                {
                    if (SaveSuccessful())
                    {
                        RestoreIcon();
                    }
                }
                else if (SelectedLine == null)
                    e.SuppressKeyPress = true;
            }
        }

        private void grvItems_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvItems.GetFocusedRow() == null)
                return;

            if (
                //Cancel Edit for Quantity and Discount if line Entity is a Account
                ((grvItems.FocusedColumn == colQuantity) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Account)
                ||
                //Cancel Edit for Quantity, Discount and colAmount if line Entity is a Message
                ((grvItems.FocusedColumn == colQuantity || grvItems.FocusedColumn == colAmount) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Message)
                )
                e.Cancel = true;

            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.JOB && n.Code == "YES"))
            {
                if (((DB.SYS_DOC_Header)BindingSource.DataSource).OriginForm != null
                    && ((DB.SYS_DOC_Header)BindingSource.DataSource).OriginForm.Name == "JobForm"
                    && (grvItems.FocusedColumn == colItemId
                    || grvItems.FocusedColumn == colDescription
                    || grvItems.FocusedColumn == colQuantity))
                    e.Cancel = true;
            }
        }

        private void grvItems_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ((DB.SYS_DOC_Line)(grvItems.GetFocusedRow())).CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId;
        }

        private void repLineEntity_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DB.SYS_DOC_Line line = SelectedLine;
                Int64 entityId = Convert.ToInt64((sender as DevExpress.XtraEditors.SearchLookUpEdit).EditValue);
                line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == entityId);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) 
                    throw ex;
            }
        }

        private void InstantFeedbackSourceItem_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
            {
                e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false &&
                    (
                        (
                            (new int[] { (byte)BL.SYS.SYS_Type.Account, (byte)BL.SYS.SYS_Type.BuyOut, (byte)BL.SYS.SYS_Type.Message }).Contains(n.TypeId)
                            &&
                            (new int[] { (byte)BL.GLX.GLX_Type.Expenses, (byte)BL.GLX.GLX_Type.CurrentAssets }).Contains(n.AccountTypeId.Value)
                            &&
                            !(new List<String>() { BL.ApplicationDataContext.Instance.SiteAccounts.DebtorsEntity.CodeMain, BL.ApplicationDataContext.Instance.SiteAccounts.CreditorsEntity.CodeMain }).Contains(n.CodeMain)
                        )
                        ||
                            (n.AccountCostofSalesId.HasValue == true && n.TypeId == (byte)BL.SYS.SYS_Type.Inventory)
                     )
                 );
            }
            else
            {
                e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && (((new int[] { (byte)BL.SYS.SYS_Type.BuyOut, (byte)BL.SYS.SYS_Type.Message }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory)));
            }
        }

        private void grvItems_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (!DesignMode)
                if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == colTotalAmount.FieldName)
                {
                    if ((DocumentType == BL.SYS.SYS_DOC_Type.SalesOrder || DocumentType == BL.SYS.SYS_DOC_Type.TAXInvoice || DocumentType == BL.SYS.SYS_DOC_Type.Quote) && Doc_Header.ORG_TRX_Header.Rounding != 0)
                    {
                        e.TotalValue = TotalIncl + Doc_Header.ORG_TRX_Header.Rounding;
                    }
                    else
                    {
                        e.TotalValue = TotalIncl;
                    }
                }
        }
    }
}
