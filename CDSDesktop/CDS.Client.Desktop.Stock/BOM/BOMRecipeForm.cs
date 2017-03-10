using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DB = CDS.Client.DataAccessLayer.DB;
using BL = CDS.Client.BusinessLayer;

namespace CDS.Client.Desktop.Stock.BOM
{
    public partial class BOMRecipeForm : CDS.Client.Desktop.Essential.BaseForm
    {
        List<DB.ITM_BOM_RecipeLine> itm_bom_recipeLine = new List<DB.ITM_BOM_RecipeLine>();
        DB.VW_LineItem resultItem;
         
        protected DB.ITM_BOM_RecipeLine SelectedLine
        {
            get { return grvItems.GetRow(grvItems.FocusedRowHandle) as DB.ITM_BOM_RecipeLine; }
        }

        protected DB.VW_LineItem ResultItem
        {
            get { return resultItem; }
            set
            {
                if (resultItem != value)
                {
                    resultItem = value;
                    grvItems.UpdateTotalSummary();
                }
            }
        }

        decimal total;
        public decimal Total
        {
            get
            {
                if (((List<DB.ITM_BOM_RecipeLine>)BindingSourceLine.DataSource) == null || ((List<DB.ITM_BOM_RecipeLine>)BindingSourceLine.DataSource).Count == 0)
                    return 0.00M;

                return ((List<DB.ITM_BOM_RecipeLine>)BindingSourceLine.DataSource).Sum(n => n.Total.HasValue ? n.Total.Value : 0);
            }
            internal set { total = value; }
        }
         
        public BOMRecipeForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart(); 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //This is used to load the Company when a Editable document is opened
            //Should mostly be triggered by die Recovery Process
            if (((DB.ITM_BOM_Recipe)BindingSource.DataSource).ItemResultId != 0)
                ResultItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == ((DB.ITM_BOM_Recipe)BindingSource.DataSource).ItemResultId);
        }

        public override void OpenRecord(long Id)
        {
            try
            {
                base.OpenRecord(Id);
                BindingSource.DataSource = BL.ITM.ITM_BOM_Recipe.Load(Id, DataContext, new List<string>() { "ITM_BOM_RecipeLine" }); //DataContext.EntityInventoryContext.ITM_BOM_Recipe.FirstOrDefault(n => n.Id == Id);
                foreach (var line in ((DB.ITM_BOM_Recipe)BindingSource.DataSource).ITM_BOM_RecipeLine)
                {
                    line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);
                    if (line.LineItem != null)
                    {
                        line.OnHand = line.LineItem.OnHand;
                        line.Amount = line.LineItem.UnitAverage * Math.Sign(line.Quantity);
                        line.Total = line.LineItem.UnitAverage * line.Quantity;
                    }

                    itm_bom_recipeLine.Add(line);
                }
                BindingSourceLine.DataSource = itm_bom_recipeLine;

                if (((DB.ITM_BOM_Recipe)BindingSource.DataSource).Building != 0 || ((DB.ITM_BOM_Recipe)BindingSource.DataSource).UnBuilding != 0)
                    ReadOnly = true;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                BindingSource.DataSource = BL.ITM.ITM_BOM_Recipe.New;
                foreach (var line in ((DB.ITM_BOM_Recipe)BindingSource.DataSource).ITM_BOM_RecipeLine)
                {
                    itm_bom_recipeLine.Add(line);
                }
                BindingSourceLine.DataSource = itm_bom_recipeLine;

                btnAssemble.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnDisassemble.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                    //Add all the New lines to the Recipe Entity
                    foreach (var line in itm_bom_recipeLine)
                    {
                        if (DataContext.EntityInventoryContext.GetEntityState(line) == System.Data.Entity.EntityState.Detached)
                        {
                            if (line.LineItem != null)
                            {
                                //DataContext.ReadonlyContext.Entry(line.Parent).Reload();
                                line.Amount = line.LineItem.UnitAverage;
                            }
                            ((DB.ITM_BOM_Recipe)BindingSource.DataSource).ITM_BOM_RecipeLine.Add(line);
                        }
                    }
                    BL.EntityController.SaveITM_BOM_Recipe((DB.ITM_BOM_Recipe)BindingSource.DataSource, DataContext);
                    DataContext.EntityInventoryContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }
         
        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            //Henko - TODO: BOM Security roles removed... Will implement later
            //AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INDOBM03);
        }

        /// <summary>
        /// Checks if stock is availble for work to start
        /// </summary>
        /// <param name="sys_doc_type"></param>
        /// <returns></returns>
        private bool HasItems(BL.SYS.SYS_DOC_Type sys_doc_type)
        {
            bool hasItems = true;
            //Recipe Items
            foreach (DB.ITM_BOM_RecipeLine line in ((DB.ITM_BOM_Recipe)BindingSource.DataSource).ITM_BOM_RecipeLine)
            {
                if (line.Quantity * (sys_doc_type == BL.SYS.SYS_DOC_Type.BOMAssemblyStarted ? 1 : -1) < 0)
                {
                    DB.ITM_History itm_history = BL.ITM.ITM_History.GetItemCurrentHistory(DataContext.EntityInventoryContext.ITM_Inventory.FirstOrDefault(n => n.EntityId == line.ItemId), DataContext);

                    if (itm_history.OnHand < -line.Quantity)
                    {
                        hasItems = false;
                        break;
                    }
                }
            }
            //Source Item
            DB.ITM_BOM_Recipe recipe = (DB.ITM_BOM_Recipe)BindingSource.DataSource;
            DB.ITM_History itm_historyItemResult = BL.ITM.ITM_History.GetItemCurrentHistory(DataContext.EntityInventoryContext.ITM_Inventory.FirstOrDefault(n => n.EntityId == recipe.ItemResultId), DataContext);
            if (recipe.QuantityResult * (sys_doc_type == BL.SYS.SYS_DOC_Type.BOMAssemblyStarted ? 1 : -1) < 0)
            {
                if (itm_historyItemResult.OnHand < -recipe.QuantityResult * (sys_doc_type == BL.SYS.SYS_DOC_Type.BOMAssemblyStarted ? 1 : -1))
                {
                    hasItems = false;
                }
            }
            if (!hasItems)
                Essential.BaseAlert.ShowAlert("Insufficient On Hand", "Insufficient On Hand to start work", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

            return hasItems;
        }

        private void SelectResultItem(object sender)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            ResultItem = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(view.GetFocusedRow())).OriginalRow as DB.VW_LineItem;
        }

        #region Event Handlers

        private void btnAssemble_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSaveRecord();
            if (!HasItems(BL.SYS.SYS_DOC_Type.BOMAssemblyStarted))
                return;
            BOMDocumentForm childForm = new BOMDocumentForm();
            childForm.NewDocument(((DB.ITM_BOM_Recipe)BindingSource.DataSource).Id, BL.SYS.SYS_DOC_Type.BOMAssemblyStarted);
            ShowForm(childForm);
        }

        private void btnDisassemble_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSaveRecord();
            if (!HasItems(BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted))
                return;
            BOMDocumentForm childForm = new BOMDocumentForm();
            childForm.NewDocument(((DB.ITM_BOM_Recipe)BindingSource.DataSource).Id, BL.SYS.SYS_DOC_Type.BOMDisassemblyStarted);
            ShowForm(childForm);
        }

        private void grvItems_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //TODO : Need to see if there is a better way
            ((DB.ITM_BOM_RecipeLine)(grvItems.GetFocusedRow())).CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId;

        }

        private void grvItems_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

            //If the selected item is not an account you cannot change the cost
            if (e.FocusedColumn == colAmount && (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem.TypeId != (byte)BL.SYS.SYS_Type.Account)
            {
                grvItems.FocusedColumn = e.PrevFocusedColumn;
            }
        }

        private void grvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                //Handeled by Repository Item
                case "ItemId":
                    Int64 itemId = Convert.ToInt64(e.Value);
                    (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == itemId);
                    if ((grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem != null)
                    {
                        (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).OnHand = (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem.OnHand;
                        (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).Amount = (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem.UnitAverage;
                        (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).Total = (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem.UnitAverage * (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).Quantity;
                    }
                    break;
                case "Quantity":
                    if ((grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem != null)
                    {
                        (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).Total = (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).LineItem.UnitAverage * (grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine).Quantity;
                    }
                    break;
            }
        }

        private void InstantFeedbackSourceItem_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new int[] { }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory));
        }

        private void InstantFeedbackSourceItemGrid_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new int[] { }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory));
        }


        private void grvItems_KeyDown(object sender, KeyEventArgs e)
        {
            //Delete selected Line
            if (!this.ReadOnly && e.Control && e.KeyCode == Keys.R && !colItemId.OptionsColumn.ReadOnly)
            {
                if (Essential.BaseAlert.ShowAlert("Delete Line", "You are about to delete the selected line do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    BL.ITM.ITM_BOM_RecipeLine.Delete(grvItems.GetFocusedRow() as DB.ITM_BOM_RecipeLine, DataContext);
                    grvItems.DeleteSelectedRows();
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
            //Ctrl + S
            else if (!this.ReadOnly && e.Control && e.KeyCode == Keys.S)
            {
                {
                    OnSaveRecord();
                    OnNewRecord();
                }
            }
        }

        private void grvItems_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (!DesignMode)
                if (((DevExpress.XtraGrid.GridColumnSummaryItem)e.Item).FieldName == colTotal.FieldName)
                {
                    if (ResultItem != null)
                        e.TotalValue = Total + (ResultItem.UnitAverage * ((DB.ITM_BOM_Recipe)BindingSource.DataSource).QuantityResult);
                }
        }

        private void ddlItemView_Click(object sender, EventArgs e)
        {
            SelectResultItem(sender);
            SendKeys.Send("{TAB}");
        }
        #endregion

       
    }
}
