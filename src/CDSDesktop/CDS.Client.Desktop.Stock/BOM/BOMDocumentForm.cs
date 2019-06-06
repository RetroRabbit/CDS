using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DB = CDS.Client.DataAccessLayer.DB;
using BL = CDS.Client.BusinessLayer;


namespace CDS.Client.Desktop.Stock.BOM
{
    public partial class BOMDocumentForm : CDS.Client.Desktop.Essential.BaseForm
    {
        List<DB.SYS_DOC_Line> sys_doc_line = new List<DB.SYS_DOC_Line>();

        public BOMDocumentForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                ServerModeSourceItem.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new int[] { }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory));
                AllowSaveAndNew = false;
                AllowArchive = false;

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void OpenRecord(long Id)
        {
            try
            {
                base.OpenRecord(Id);
                BindingSource.DataSource = BL.ITM.ITM_BOM_Document.Load(Id, DataContext, new List<String>() { "ITM_BOM_Recipe" });//DataContext.EntityInventoryContext.ITM_BOM_Document.FirstOrDefault(n => n.Id == Id);
                DB.ITM_BOM_Document itm_bom_document = ((DB.ITM_BOM_Document)BindingSource.DataSource);
                BindingSourceDocument.DataSource = BL.SYS.SYS_DOC_Header.Load(itm_bom_document.HeaderId, DataContext, new List<String>() { "SYS_DOC_Line" });//DataContext.EntityInventoryContext.ITM_BOM_Document.FirstOrDefault(n => n.HeaderId == itm_bom_document.Id);  //((DB.ITM_BOM_Document)BindingSource.DataSource).SYS_DOC_Header;
                BindingSourceRecipe.DataSource = ((DB.ITM_BOM_Document)BindingSource.DataSource).ITM_BOM_Recipe;
                DB.ITM_BOM_Recipe recipe = ((DB.ITM_BOM_Document)BindingSource.DataSource).ITM_BOM_Recipe;
                //DB.SYS_DOC_Header sys_doc_header = BL.SYS.SYS_DOC_Header.Load(itm_bom_document.HeaderId, DataContext, new List<String>() { "SYS_DOC_Line" });
                BindingSourceDocumentLine.DataSource = ((DB.SYS_DOC_Header)BindingSourceDocument.DataSource).SYS_DOC_Line;//sys_doc_header.SYS_DOC_Line.Where(n => n.ItemId != recipe.ItemResultId);

                //BOM hase been Completed or Canceled
                if (((DB.ITM_BOM_Document)BindingSource.DataSource).QuantityActualResult != null)
                {
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnComplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    ReadOnly = true;
                }
                else
                {
                    AllowSave = false;
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
                DialogResult result = Essential.BaseAlert.ShowAlert("Save Document", "You are about the save this document do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information);
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();

                    Int64 printerId = 0;
                    switch (result)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            printerId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value;
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            printerId = 0;
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            printerId = -1;
                            return false;
                    }

                    DB.SYS_DOC_Header entry = ((DB.SYS_DOC_Header)BindingSourceDocument.DataSource);
                    entry.ITM_BOM_Document = ((DB.ITM_BOM_Document)BindingSource.DataSource);
                    //Add result item
                    DB.SYS_DOC_Line resultLine = BL.SYS.SYS_DOC_Line.New;
                    resultLine.ItemId = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).ItemResultId;
                    DB.ITM_History itm_history = BL.ITM.ITM_History.GetItemCurrentHistory(DataContext.EntityInventoryContext.ITM_Inventory.FirstOrDefault(n => n.EntityId == resultLine.ItemId), DataContext);
                    resultLine.Quantity = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).QuantityResult * (entry.TypeId == (byte)BL.SYS.SYS_DOC_Type.BOMAssemblyStarted ? 1 : -1);
                    resultLine.Description = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == resultLine.ItemId).Description;
                    resultLine.Amount = itm_history.UnitAverage;
                    resultLine.Total = resultLine.Quantity * resultLine.Amount;
                    resultLine.TotalTax = 0;
                    //SYS DOC Lines
                    sys_doc_line.Add(resultLine);
                    sys_doc_line.ForEach(n => n.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(k => k.Id == n.ItemId));
                    BL.ApplicationDataContext.Instance.Service.SaveDocument(entry, printerId);
                    btnComplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    return true;
                    //If you ever remove this make sure that you refresh all the datasources as the BindingSource.DataSource is save disjoint from the DataContext
                    ForceClose = true;
                    this.Close();

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
            //AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INDOBM02);
        }

        public void NewDocument(Int64 recipeId, BL.SYS.SYS_DOC_Type itm_bom_type)
        {
            try
            {
                //Werner: Need to run this to get the NewRecord behaviour of the form
                OnNewRecord();
                btnComplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                txtQuantityActualResult.Enabled = false;
                //Recipe
                BindingSourceRecipe.DataSource = BL.ITM.ITM_BOM_Recipe.Load(recipeId, DataContext, new List<string>() { "ITM_BOM_RecipeLine" }); //DataContext.EntityInventoryContext.ITM_BOM_Recipe.FirstOrDefault(n => n.Id == recipeId);
                //SYS DOC Header
                BindingSourceDocument.DataSource = BL.SYS.SYS_DOC_Document.New(itm_bom_type);
                //BOM Document
                BindingSource.DataSource = BL.ITM.ITM_BOM_Document.New;//((DB.SYS_DOC_Header)BindingSourceDocument.DataSource).ITM_BOM_Document.FirstOrDefault();
                //Link item to BOM Document
                ((DB.ITM_BOM_Document)BindingSource.DataSource).RecipeId = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).Id;
                ((DB.ITM_BOM_Document)BindingSource.DataSource).ItemResultId = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).ItemResultId;
                ((DB.ITM_BOM_Document)BindingSource.DataSource).QuantityExpectedResult = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).QuantityResult * (itm_bom_type == BL.SYS.SYS_DOC_Type.BOMAssemblyStarted ? 1 : -1);

                //Link Lines
                ((DB.SYS_DOC_Header)BindingSourceDocument.DataSource).SYS_DOC_Line = sys_doc_line;
                BindingSourceDocumentLine.DataSource = sys_doc_line;

                //Populate the SYS_DOC_Header's lines
                foreach (var recipeLine in ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).ITM_BOM_RecipeLine)
                {
                    DB.SYS_DOC_Line line = BL.SYS.SYS_DOC_Line.New;
                    line.ItemId = recipeLine.ItemId;
                    line.Description = BL.SYS.SYS_Entity.Load(recipeLine.ItemId, DataContext).Description;
                    line.Quantity = recipeLine.Quantity * (itm_bom_type == BL.SYS.SYS_DOC_Type.BOMAssemblyStarted ? 1 : -1);
                    line.Amount = recipeLine.Amount;
                    line.Total = line.Quantity * line.Amount;
                    line.TotalTax = 0;

                    //SYS DOC Lines
                    sys_doc_line.Add(line);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult result = Essential.BaseAlert.ShowAlert("Cancel Document", "You are about the cancel this document do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information);

                Int64 printerId = 0;
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        printerId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        printerId = 0;
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        printerId = -1;
                        break;
                }

                DB.SYS_DOC_Header sys_doc_header = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.BOMCanceled);
                //DB.ITM_BOM_Document itm_bom_document = ((DB.ITM_BOM_Document)BindingSource.DataSource);//DataContext.EntityInventoryContext.ITM_BOM_Document.FirstOrDefault(n => n.HeaderId == sys_doc_header.Id); //sys_doc_header.ITM_BOM_Document.FirstOrDefault();
                foreach (DB.SYS_DOC_Line line in ((DB.SYS_DOC_Header)BindingSourceDocument.DataSource).SYS_DOC_Line)
                {
                    sys_doc_header.SYS_DOC_Line.Add(BL.ApplicationDataContext.DeepClone(line, BL.SYS.SYS_DOC_Line.New));
                }
                sys_doc_header.BOMDocumentId = ((DB.ITM_BOM_Document)BindingSource.DataSource).Id;
                //Werner: This was moved to the DataService 
                //itm_bom_document.RecipeId = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).Id;
                //itm_bom_document.ItemResultId = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).ItemResultId;
                //itm_bom_document.QuantityExpectedResult = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).QuantityResult;
                //itm_bom_document.QuantityActualResult = 0;
                //itm_bom_document.CancelParent = ((DB.ITM_BOM_Document)BindingSource.DataSource).Id;

                BL.ApplicationDataContext.Instance.Service.SaveDocument(sys_doc_header, printerId);

                //If you ever remove this make sure that you refresh all the datasources as the BindingSource.DataSource is save disjoint from the DataContext
                ForceClose = true;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnComplete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ValidateLayout();

                if (((DB.ITM_BOM_Document)BindingSource.DataSource).QuantityActualResult == null)
                {
                    Essential.BaseAlert.ShowAlert("Quantity Actual Result Required", "Enter Quantity Actual Result before continuing ?", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    return;
                }

                DialogResult result = Essential.BaseAlert.ShowAlert("Cancel Document", "You are about the cancel this document do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information);

                Int64 printerId = 0;
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        printerId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        printerId = 0;
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        printerId = -1;
                        break;
                }

                DB.SYS_DOC_Header sys_doc_header = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.BOMComplete);
                DB.ITM_BOM_Document itm_bom_document = DataContext.EntityInventoryContext.ITM_BOM_Document.FirstOrDefault(n => n.HeaderId == sys_doc_header.Id);//sys_doc_header.ITM_BOM_Document.FirstOrDefault(); 
                foreach (DB.SYS_DOC_Line line in ((DB.SYS_DOC_Header)BindingSourceDocument.DataSource).SYS_DOC_Line)
                {
                    if (line.ItemId == ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).ItemResultId)
                        line.IsBOMCompleteResultItem = true;

                    var newLine = BL.ApplicationDataContext.DeepClone(line, BL.SYS.SYS_DOC_Line.New);
                    if (newLine.LineItem == null)
                        newLine.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);

                    sys_doc_header.SYS_DOC_Line.Add(newLine);
                }
                sys_doc_header.BOMDocumentId = ((DB.ITM_BOM_Document)BindingSource.DataSource).Id;
                //Werner: This was moved to the DataService 
                //itm_bom_document.RecipeId = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).Id;
                //itm_bom_document.ItemResultId = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).ItemResultId;
                //itm_bom_document.QuantityExpectedResult = ((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).QuantityResult;
                //itm_bom_document.QuantityActualResult = 0;
                //itm_bom_document.CancelParent = ((DB.ITM_BOM_Document)BindingSource.DataSource).Id;

                BL.ApplicationDataContext.Instance.Service.SaveDocument(sys_doc_header, printerId);

                //If you ever remove this make sure that you refresh all the datasources as the BindingSource.DataSource is save disjoint from the DataContext
                ForceClose = true;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnViewRecipe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BOMRecipeForm childform = new BOMRecipeForm();
            childform.OpenRecord(((DB.ITM_BOM_Recipe)BindingSourceRecipe.DataSource).Id);
            ShowForm(childform);
        }

        private void InstantFeedbackSourceItem_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new int[] { }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory));
        }

        private void InstantFeedbackSourceItemGrid_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new int[] { }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory));
        }

        /// <summary>
        /// Sets a custom filter for the grids rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvLines_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            //Filter out the Result item so that it does not show on the grid
            if ((grvLines.GetRow(e.ListSourceRow) as DB.SYS_DOC_Line).ItemId == ((DB.ITM_BOM_Document)BindingSource.DataSource).ItemResultId
                && (grvLines.GetRow(e.ListSourceRow) as DB.SYS_DOC_Line).Quantity == ((DB.ITM_BOM_Document)BindingSource.DataSource).QuantityExpectedResult)
            {
                e.Visible = false;
                e.Handled = true;
            }
        }
    }
}
