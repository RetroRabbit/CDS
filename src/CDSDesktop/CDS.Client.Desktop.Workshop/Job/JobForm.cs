using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using System.Reflection;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using CDS.Client.Desktop.Essential;

namespace CDS.Client.Desktop.Workshop.Job
{
    public partial class JobForm : CDS.Client.Desktop.Essential.BaseForm
    {
        bool IsSaved { get; set; }

        bool AllowRemoveItem { get; set; }

        int lineCounter, readOnlyLineCount = 0;

        DB.VW_Company selectedCompany;

        protected List<DB.SYS_DOC_Line> lines = new List<DB.SYS_DOC_Line>();

        public DB.SYS_DOC_Header Doc_Header;

        public DB.JOB_Header Job_header;

        /// <summary>
        /// Boolean that returns true if Document has never been submitted to the database (Is a new document)
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

        public JobForm()
        {
            InitializeComponent();
        }

        public JobForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected DB.VW_Company SelectedCompany
        {
            get
            {
                if (selectedCompany == null)
                {
                    Int64 companyId = Convert.ToInt64(ddlCompany.EditValue);
                    selectedCompany = DataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == companyId);
                }

                return selectedCompany;
            }
        }

        protected DB.SYS_DOC_Line SelectedLine
        {
            get { return grvItems.GetRow(grvItems.FocusedRowHandle) as DB.SYS_DOC_Line; }
        }

        protected override void OnStart()
        {
            base.OnStart();
            AllowArchive = false;
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = Doc_Header;
            BindingSourceTransaction.DataSource = Job_header;
            BindingSourceLine.DataSource = lines;

            Doc_Header.JOB_Header = Job_header;
            lines.Clear();


            switch (ItemState)
            {
                case EntityState.Generated:
                    IsSaved = false;
                    btnCreateQuote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnViewSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnCreateSalesOrder.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Default;
                    lines.Clear();
                    foreach (DB.SYS_DOC_Line docline in ((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line)
                    {
                        docline.NewJobLine = true;
                        lines.Add(docline);
                        CalculateUnboundColumns(docline);
                        CalculateLineTotals(docline);
                    }
                    BindingSourceLine.DataSource = lines;
                    ddlCompany.Properties.ReadOnly = true;

                    colItemId.OptionsColumn.AllowFocus = false;
                    colDescription.OptionsColumn.AllowFocus = false;
                    break;

                case EntityState.Open:

                    foreach (DB.VW_JobLine jobLine in DataContext.ReadonlyContext.VW_JobLine.Where(n => n.HeaderId == ((DB.SYS_DOC_Header)BindingSource.DataSource).Id).OrderBy(o => o.LineOrder))
                    {
                        DB.SYS_DOC_Line line = BL.SYS.SYS_DOC_Line.New;
                        line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == jobLine.ItemId);
                        line.ParentLineId = jobLine.Id.Value;
                        line.HeaderId = jobLine.HeaderId;
                        line.ItemId = jobLine.ItemId;
                        line.DiscountPercentage = jobLine.DiscountPercentage;
                        line.Description = jobLine.Description;
                        line.Quantity = jobLine.Quantity.Value;
                        line.Amount = jobLine.Amount;
                        line.Total = jobLine.Total.Value;
                        line.TotalTax = jobLine.TotalTax.Value;
                        line.CreatedOn = jobLine.CreatedOn;
                        line.CreatedBy = jobLine.CreatedBy;
                        if ((new byte[] { (byte)BL.SYS.SYS_Type.Inventory, (byte)BL.SYS.SYS_Type.BuyOut }).Contains(line.LineItem.TypeId))
                            line.UnitAverage = BL.ITM.ITM_Movement.LoadByLineId(jobLine.Id.Value, DataContext).UnitAverage.Value;
                        line.LineOrder = jobLine.LineOrder;
                        lines.Add(line);
                        CalculateUnboundColumns(line);
                        CalculateLineTotals(line);
                    }
                    readOnlyLineCount = Doc_Header.SYS_DOC_Line.Count();
                    break;
            }
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            IsSaved = true;

            Doc_Header = BL.SYS.SYS_DOC_Header.Load(Id, DataContext, new List<String>() { "SYS_DOC_Line" });
            Job_header = BL.JOB.JOB_Header.LoadByHeaderId(Id, DataContext);

            //Must disable company dropdown user not allowed to change company
            ddlCompany.Properties.ReadOnly = true;
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            Doc_Header = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.Job);
            Job_header = BL.JOB.JOB_Header.New;
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                DialogResult result = Essential.DocumentAlert.ShowAlert("Save Document", "You are about the save this document do you wish to continue?", Essential.DocumentAlert.Buttons.SaveAndPrint);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return false;

                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    if (!IsValid)
                        return false;

                    string message = "";
                    Int64 printerId = 0;
                    // Henko: Werner - WHAT THE HELL????!!!!!
                    //Incase something happens remove the current lines and add the ones in the grid
                    ((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line.Clear();
                    lines.ForEach(n => ((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line.Add(n));
                    switch (result)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            printerId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value;
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            printerId = 0;
                            break;
                    }
                    DB.SYS_DOC_Header entry = (DB.SYS_DOC_Header)BindingSource.DataSource;
                    if (IsNew)
                    {
                        entry.OriginForm = null;
                        message = BL.ApplicationDataContext.Instance.Service.SaveDocument(entry, printerId);
                    }
                    else
                    {
                        try
                        {
                            if (lines.Where(n => n.NewJobLine == true).ToList().Count() > 0)
                            {
                                lines.Where(n => n.NewJobLine == true).ToList().ForEach(n => n.SYS_DOC_Header = null);
                                message = BL.ApplicationDataContext.Instance.Service.SaveJobLines(entry.Id, lines.Where(n => n.NewJobLine == true).ToList(), printerId);
                            }
                        }
                        catch (Exception ex)
                        {
                            DataContext.EntitySystemContext.RejectChanges();
                            return false;
                        }
                    }
                    if (message.StartsWith("Success"))
                    {
                        ShowNotification("Document Saved", String.Format("{0} number {1} was saved successfully", this.Text, message.Split(',')[1]), 5000, false, null);

                        //Werner: Same issue as the Documents because the Entities are sent to the Service the are disjoint from the context and the Reject Changes cannot be checked
                        //I am making the assumption that when the service returns Success there will not be any further changes to the document
                        //On this Entity type you can change after you have made changes so when the grvItems_CellValueChanged is fired i will set this back to false
                        ForceClose = true;
                    }
                    else if (message.StartsWith("ChangesSaved"))
                    {
                        ShowNotification("Document Changes Saved", String.Format("{0} number {1} was saved successfully", this.Text, ((DB.SYS_DOC_Header)BindingSource.DataSource).DocumentNumber), 5000, false, null);
                        OpenRecord(((DB.SYS_DOC_Header)BindingSource.DataSource).Id);
                        if (lines.Count() == 0)
                            Close();

                        grvItems.RefreshData();
                        //Werner: Same issue as the Documents because the Entities are sent to the Service the are disjoint from the context and the Reject Changes cannot be checked
                        //I am making the assumption that when the service returns Success there will not be any further changes to the document
                        //On this Entity type you can change after you have made changes so when the grvItems_CellValueChanged is fired i will set this back to false
                        ForceClose = true;
                    }
                    else if (message != string.Empty)
                    {
                        DocumentSaveException(message);
                        return false;
                    }
                    // Henko: Rewrite this WHOLE save method - UTTER CHAOS!!!!!
                    // Henko: I GUESS????? this means it has saved????
                    return true;
                }
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

        private void CalculateUnboundColumns(DB.SYS_DOC_Line line)
        {
            //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;
        }

        protected virtual void DocumentSaveException(string message)
        {
            Essential.BaseAlert.ShowAlert("Save Document failed", "Your document could not be saved at this time please try again." + Environment.NewLine + message, Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
            HasErrors = true; CurrentException = new Exception(message);
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                // NO Checks currently
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private void PopulateNewLine(DB.SYS_DOC_Line line)
        {
            if (line == null || line.LineItem == null)
                return;

            //If new item is a stock item and Bar codes are enabled populate line with quantity one 
            if (BL.ApplicationDataContext.Instance.CompanySite.UseBarcodes && line.LineItem.InventoryId != null)
            {
                line.Quantity = 1M;
            }

            line.Description = line.LineItem.Description;
            line.UnitAverage = line.Amount = line.LineItem.UnitAverage;

            PopulateLineOrder();

            PopulateLineAmount(line);

        }

        /// <summary>
        /// Populates the lines LineOrder
        /// </summary>
        /// <param name="line">Line of which the line order needs to be populated</param>
        private void PopulateLineOrder()
        {
            if (ItemState == EntityState.New || ItemState == EntityState.Recovered)
            {
                ResetLineOrder();
            }
            else
            {
                int counter = 1;
                lines.ForEach(n =>
                {
                    if (counter > readOnlyLineCount)
                    {
                        n.LineOrder = ++lineCounter;
                    }
                    counter++;
                });
            }
        }

        /// <summary>
        /// Resets all lines line order
        /// </summary>
        private void ResetLineOrder()
        {
            lineCounter = 0;
            lines.ForEach(n => n.LineOrder = ++lineCounter);
        }

        private void PopulateLineAmount(DB.SYS_DOC_Line line)
        {
            switch (SelectedCompany.CostCategoryId)
            {
                case (byte)BL.ORG.ORG_CostCategory.SellingPriceIncludingSalesTax:
                case (byte)BL.ORG.ORG_CostCategory.SellingPriceExcludingSalesTax:
                    line.Amount = line.LineItem.UnitPrice;
                    break;
                case (byte)BL.ORG.ORG_CostCategory.CostIncludingSalesTax:
                case (byte)BL.ORG.ORG_CostCategory.CostExcludingSalesTax:
                    line.Amount = line.LineItem.UnitCost;
                    break;
                case (byte)BL.ORG.ORG_CostCategory.AverageCostExcludingSalesTax:
                    line.Amount = line.LineItem.UnitAverage;
                    break;
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.WSDOJCREED);
            AllowRemoveItem = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.WSDOJCREED01);

            if (ItemState == EntityState.Open)
            {
                List<DB.SYS_DOC_Header> refDocs = BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).ToList();

                if (refDocs.Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.JobQuote))
                {
                    //Need security for quote
                    //if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WSDOJCRECR))
                    {
                        btnViewQuotes.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
                else
                {
                    //Need security for quote
                    // if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WSDOJCRECR))
                    {
                        btnCreateQuote.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }


                if (refDocs.Any(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.SalesOrder))
                {
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORE))
                    {
                        btnViewSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        //Werner: If Sales Order exists you can no longer remove Items
                        AllowRemoveItem = false;
                        //Werner: If Sales Order exists you can no longer Save
                        AllowSave = false;
                        ReadOnly = true;
                    }
                }
                else
                {
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR))
                    {
                        btnCreateSalesOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
            }

            if (AllowRemoveItem)
                btnRemoveItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void PopulateFieldsFromCompany()
        {
            if (Job_header.CompanyId == 0)
                return;

            Job_header.ReferenceShort1 = SelectedCompany.RepCode;
            Job_header.ReferenceShort2 = SelectedCompany.SalesmanCode;
            Job_header.ContactPerson = SelectedCompany.SalesContact;
            Job_header.ContactTelephone = SelectedCompany.SalesTelephone;

            DB.VW_Address billingAddress = DataContext.ReadonlyContext.VW_Address.FirstOrDefault(n => n.CompanyId == Job_header.CompanyId && n.TypeId == (byte)BL.SYS.SYS_Type.BillingAddress);
            DB.VW_Address shippingAddress = DataContext.ReadonlyContext.VW_Address.FirstOrDefault(n => n.CompanyId == Job_header.CompanyId && n.TypeId == (byte)BL.SYS.SYS_Type.ShippingAddress);

            Job_header.BillingAddressLine1 = billingAddress.Line1;
            Job_header.BillingAddressLine2 = billingAddress.Line2;
            Job_header.BillingAddressLine3 = billingAddress.Line3;
            Job_header.BillingAddressLine4 = billingAddress.Line4;
            Job_header.BillingAddressCode = billingAddress.Code;

            Job_header.ShippingAddressLine1 = shippingAddress.Line1;
            Job_header.ShippingAddressLine2 = shippingAddress.Line2;
            Job_header.ShippingAddressLine3 = shippingAddress.Line3;
            Job_header.ShippingAddressLine4 = shippingAddress.Line4;
            Job_header.ShippingAddressCode = shippingAddress.Code;
        }

        protected override void XPOPreBindDataFilter()
        {
            base.XPOPreBindDataFilter();
            //XPInstantFeedbackSourceItem.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("([TypeId.Name] in ('Inventory') )or ([TypeId.Name] = 'Account' and [ShowOnSales] = true)");
            //Fix this when Devexpress fixed Repository VIew Binding XPO Issue
            repLineEntity.DataSource = DataContext.ReadonlyContext.VW_Entity.Where(n => n.SiteId == BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId && (n.Type == "Inventory"  || ((n.TypeId == (byte)BL.SYS.SYS_Type.Account) ? ((n.AccountTypeId == (byte)1) ? true : false) : true))).ToList();
            //repLineEntity.DataSource = XPInstantFeedbackSourceItem;
        }

        private void ddlCompany_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.OldValue != null && e.NewValue != DBNull.Value && e.NewValue != null && lines.Count > 0 && Convert.ToInt64(e.NewValue) != 0)
            {

                if (Essential.BaseAlert.ShowAlert("Changing Account", "You are about to change the selected account\n\rall lines on the current document will be cleared", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    grvItems.OptionsBehavior.Editable = true;
                    lines.Clear();
                    grvItems.RefreshData();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void ddlCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlCompany.EditValue != DBNull.Value && ddlCompany.EditValue != null && ddlCompany.EditValue.ToString() != string.Empty && Convert.ToInt64(ddlCompany.EditValue) != 0)
            {
                grvItems.OptionsBehavior.Editable = true;
            }
        }

        private void ddlCompany_Leave(object sender, EventArgs e)
        {
            if (ddlCompany.EditValue == DBNull.Value || ddlCompany.EditValue == null || Convert.ToInt64(ddlCompany.EditValue) == 0)
            {
                this.Focus();
                //Cannot do this because when you open a new form it gets stuck 
                //ddlCompany.Focus();
                ddlCompany.ErrorText = "Value cannot be blank";
            }
            else
            {
                ddlCompany.ErrorText = "";
            }
        }

        private void grvItems_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ((DB.SYS_DOC_Line)(grvItems.GetFocusedRow())).HeaderId = ((DB.SYS_DOC_Header)BindingSource.DataSource).Id;
            ((DB.SYS_DOC_Line)(grvItems.GetFocusedRow())).CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId;
            ((DB.SYS_DOC_Line)(grvItems.GetFocusedRow())).NewJobLine = true;
            IsSaved = false;
        }

        private void grvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Werner: Go read the comment in the OnSaveRecord for why I do this
            ForceClose = false;

            DB.SYS_DOC_Line line = (grvItems.GetFocusedRow() as DB.SYS_DOC_Line);
            if (line == null)
                return;

            if (line.ItemId != 0 && line.LineItem == null)
                line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId);

            switch (e.Column.FieldName)
            {
                //Handeled by Repository Item
                case "ItemId":
                    if (DataContext.ReadonlyContext.VW_Alternative.Any(n => n.SearchItemName == line.LineItem.Name))
                        using (AlternativeDialogue dlg = new AlternativeDialogue(line.LineItem.Name))
                        {
                            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == dlg.SelectedItem.EntityId);
                                line.IgnoreChanges = true;
                                line.ItemId = dlg.SelectedItem.EntityId.Value;
                                line.IgnoreChanges = false;
                            }
                        }

                    PopulateNewLine(line);
                    break;
                case "Quantity":
                    ValidateLineQuantity(line);
                    break;

            }
            CalculateLineTotals(line);
            CalculateDocumentTotals();
            ValidateLayout();
        }

        private void CalculateDocumentTotals()
        {
            decimal totalExcl = 0.00M, totalTax = 0.00M, totalIncl = 0.00M, totalRounding = 0.00M;
            lines.ForEach(n => totalExcl += n.Total);
            lines.ForEach(n => totalTax += n.TotalTax);
            lines.ForEach(n => totalIncl += (n.Total + n.TotalTax));
            grvItems.UpdateSummary();
        }

        private void CalculateLineTotals(DB.SYS_DOC_Line line)
        {
            line.Amount = Math.Round(line.Amount, 2, MidpointRounding.AwayFromZero);
            line.Total = Math.Round((line.Amount * line.Quantity), 2, MidpointRounding.AwayFromZero);
        }

        private void ValidateLineQuantity(DB.SYS_DOC_Line line)
        {
            if (line.Quantity < 0)
                line.Quantity = 0;

            line.Quantity = Math.Min(line.Quantity, line.LineItem.OnHand);
        }

        private void JobForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Werner: Removed this it is not handeled by the Reject Changes Dialogue
            //if (SelectedCompany == null)
            //{
            //    if (!IsSaved && !(Essential.BaseAlert.ShowAlert("Close document.", "You are about to close this " + this.Text + " without saving." + Environment.NewLine + "Do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) == System.Windows.Forms.DialogResult.OK))
            //        e.Cancel = true;
            //}
            //else
            //    if (!IsSaved && !(Essential.BaseAlert.ShowAlert("Close document.", "You are about to close this " + this.Text + " for " + SelectedCompany.Name + " without saving." + Environment.NewLine + "Do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) == System.Windows.Forms.DialogResult.OK))
            //        e.Cancel = true;
        }

        private void grvItems_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (SelectedLine == null || SelectedLine.LineItem == null)
                return;
            else if (grvItems.FocusedColumn == colItemId && SelectedLine.ItemId == 0)
                return;
            else if (grvItems.FocusedColumn == colItemId && SelectedLine.ItemId != 0 && !SelectedLine.NewJobLine)
                e.Cancel = true;

            switch (SelectedLine.LineItem.TypeId)
            {
                case (byte)BL.SYS.SYS_Type.Account:
                    if (grvItems.FocusedColumn == colQuantity)
                    {
                        e.Cancel = true;
                        return;
                    }
                    break;
                case (byte)BL.SYS.SYS_Type.Inventory:
                case (byte)BL.SYS.SYS_Type.BuyOut:
                    if (grvItems.FocusedColumn == colAmount)
                    {
                        e.Cancel = true;
                        return;
                    }
                    break;
            }
            //Cannot change lines with no item selected
            if (SelectedLine == null)
                e.Cancel = true;
            //Werner Scheffer
            //Cannot do this or you will not be able to edit the new line
            //Cannot change unsaved lines
            //else if (SelectedLine.Id == 0)
            //e.Cancel = true;

                //Cannot change saved lines
            else if (!SelectedLine.NewJobLine)
                e.Cancel = true;

                //Cannot change removed lines
            else if (SelectedLine.Quantity < 0)
                e.Cancel = true;

            //if (grvItems.GetFocusedRow() != null && !((DB.SYS_DOC_Line)(grvItems.GetFocusedRow())).NewJobLine)
            //    e.Cancel = true;


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
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                RemoveItem();
            }
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
            else if (e.Control && e.KeyCode == Keys.D && SelectedCompany != null &&
                ((SelectedCompany.TypeId == (byte)BL.ORG.ORG_Type.Customer && BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORCURE)) || (SelectedCompany.TypeId == (byte)BL.ORG.ORG_Type.Supplier && BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORSURE))))
            {
                ValidateLayout();
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    var mainform = Application.OpenForms["MainForm"];
                    Type typExternal = mainform.GetType();
                    System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowCompanyForm");

                    methodInf.Invoke(mainform, new object[] { SelectedCompany.Id, true });
                }
            }
            else if (!this.ReadOnly && e.KeyCode == Keys.Enter)
            {
                //Ignore MoveNextOnEnter when there are no lines and the focused column is the Item column
                if ((sender as DevExpress.XtraGrid.Views.Grid.GridView).FocusedColumn == colItemId && SelectedLine == null && lines.Count == 0)
                {
                    e.Handled = true;
                }
                else
                    //Save document when pressing enter on empty line
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

        private void RemoveItem()
        {
            if (SelectedLine == null)
                return;

            if (AllowRemoveItem && !SelectedLine.NewJobLine && !colItemId.OptionsColumn.ReadOnly)
            {

                JobRemoveDialogue dialogue = new JobRemoveDialogue(SelectedLine.Quantity);
                dialogue.ShowDialog();

                if (dialogue.Quantity > 0)
                {
                    if (SelectedLine.NewJobLine)
                    {
                        if (SelectedLine.Quantity == dialogue.Quantity)
                        {
                            grvItems.DeleteSelectedRows();
                        }
                        else
                        {
                            SelectedLine.Quantity = dialogue.Quantity;
                        }
                        IsSaved = false;
                    }
                    else
                    {
                        DB.SYS_DOC_Line deletedItem = BL.ApplicationDataContext.DeepClone<DB.SYS_DOC_Line>(SelectedLine, BL.SYS.SYS_DOC_Line.New);
                        deletedItem.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == deletedItem.ItemId);
                        deletedItem.Quantity = -dialogue.Quantity;
                        deletedItem.NewJobLine = true;
                        deletedItem.Total = deletedItem.Quantity * deletedItem.Amount;
                        //Using Line Order to Group in VW_JobLines
                        deletedItem.LineOrder = ((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line.Max(m => m.LineOrder) + 1;
                        IsSaved = false;
                        lines.Add(deletedItem);
                        CalculateLineTotals(deletedItem);
                        //((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line.Add(deletedItem);
                        grvItems.RefreshData();
                    }

                }
            }
        }

        private void btnCreateQuote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateBeforeSave())
                return;

            if (SaveSuccessful())
            {
                IgnoreChanges = true;
                this.Close();
                ShowDocumentForm(BL.SYS.DocumentProcessor.CreateQuoteFromJob((DB.SYS_DOC_Header)BindingSource.DataSource, DataContext));
            }
        }

        private void InstantFeedbackSourceCompany_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            e.QueryableSource = DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (byte)BL.ORG.ORG_Type.Customer && n.SiteId == defaultSiteId);
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
                            (n.AccountCostofSalesId.HasValue == true && n.TypeId == (byte)BL.SYS.SYS_Type.Inventory && n.InventorySiteId == BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId)
                     )
                 );
            }
            else
            {
                e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && (((new int[] { (byte)BL.SYS.SYS_Type.BuyOut, (byte)BL.SYS.SYS_Type.Message }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory && n.InventorySiteId == BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId)));
            }
        }

        private void btnSalesOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidateBeforeSave())
                return;

            if (SaveSuccessful())
            {
                IgnoreChanges = true;
                DB.SYS_DOC_Header salesorder = BL.SYS.DocumentProcessor.CreateSalesOrderFromJob(Doc_Header, DataContext);
                this.Close();
                ShowDocumentForm(salesorder);
            }
        }

        private void btnViewSalesOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                var mainform = Application.OpenForms["MainForm"];
                Type typExternal = mainform.GetType();
                System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowDocumentListForm");

                methodInf.Invoke(mainform, new object[] { BL.SYS.SYS_DOC_Type.SalesOrder, Doc_Header.TrackId });
            }
        }

        private void btnViewQuotes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                var mainform = Application.OpenForms["MainForm"];
                Type typExternal = mainform.GetType();
                System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowDocumentListForm");

                methodInf.Invoke(mainform, new object[] { BL.SYS.SYS_DOC_Type.JobQuote, Doc_Header.TrackId });
            }
        }

        private void ddlCompany_Validated(object sender, EventArgs e)
        {
            //If the same value is selected do nothing
            if (ddlCompany.OldEditValue == ddlCompany.EditValue || ddlCompany.EditValue == null)
            {
                return;
            }
            else if (IsNew && ddlCompany.EditValue != null)
            {
                PopulateFieldsFromCompany();
            }
        }

        private void repLineEntity_Popup(object sender, EventArgs e)
        {
            IPopupControlEx popupControl = sender as IPopupControlEx;
            PopupSearchLookUpEditForm popupWindow = (PopupSearchLookUpEditForm)popupControl.PopupWindow;
            DevExpress.XtraGrid.Editors.SearchEditLookUpPopup control = (DevExpress.XtraGrid.Editors.SearchEditLookUpPopup)popupWindow.Controls[2];

            control.FindTextBox.KeyDown += (insender, ine) =>
            {
                if (ine.KeyCode == Keys.Enter)
                {
                    if (grvItems.ActiveEditor == null || (grvItems.ActiveEditor as DevExpress.XtraEditors.SearchLookUpEdit) == null)
                        return;

                    var searchValue = (insender as DevExpress.XtraEditors.TextEdit).Text;

                    if (DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Name == searchValue).Count() == 1)
                    {
                        (grvItems.ActiveEditor as DevExpress.XtraEditors.SearchLookUpEdit).EditValue =
                        DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Name == searchValue).Select(l => l.Id).FirstOrDefault();
                        grvItems.SetFocusedRowCellValue(colItemId, (grvItems.ActiveEditor as DevExpress.XtraEditors.SearchLookUpEdit).EditValue);
                        SendKeys.SendWait("{ENTER}");
                        SendKeys.SendWait("{ENTER}");
                    }
                }
            };
        }

        private void btnRemoveItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RemoveItem();
        }
    }
}
