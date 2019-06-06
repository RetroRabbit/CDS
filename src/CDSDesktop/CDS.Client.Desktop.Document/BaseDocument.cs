using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using CDS.Client.Desktop.Essential;
using DevExpress.Utils.Win;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.Desktop.Document
{
    public partial class BaseDocument : CDS.Client.Desktop.Essential.BaseForm
    {
        protected List<DB.SYS_DOC_Line> lines = new List<DB.SYS_DOC_Line>();
        private DB.VW_Company selectedCompany;
        private bool clearLinesOnCompanyChanged = true;
        public DB.SYS_DOC_Header Doc_Header;
        private bool AllowChanges = true;
        private Color tabColor = Color.LightGray;
        private BL.ORG.ORG_Type companyType = BL.ORG.ORG_Type.Customer;
        private BL.SYS.SYS_DOC_Type documentType = BL.SYS.SYS_DOC_Type.Quote;
        private decimal total;
        private decimal totaltax;
        private decimal totalIncl;
        string repLineEntityFilter;
        long? defaultSiteId;
        int lineCounter, readOnlyLineCount = 0;
        List<DB.SYS_DOC_Header> refDocs;

        public class DocumentLineType
        {
            public String DisplayName { get; set; }
            public int Value { get; set; }
        }

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

        /// <summary>
        /// Sets or gets the tab colour.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2013</remarks>
        [Category("Tab Color")]
        [BrowsableAttribute(true)]
        public Color TabColor { get { return tabColor; } set { tabColor = value; } }

        /// <summary>
        /// Used to identity the Company Lookups Type
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2013</remarks>
        [DefaultValue(BL.ORG.ORG_Type.Customer)]
        [BrowsableAttribute(true)]
        public BL.ORG.ORG_Type CompanyType { get { return companyType; } set { companyType = value; } }

        /// <summary>
        /// Used to identity the Company Lookups Type
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2013</remarks>
        [BrowsableAttribute(true)]
        public BL.SYS.SYS_DOC_Type DocumentType { get { return documentType; } set { documentType = value; } }

        /// <summary>
        /// Werner: What is this used for? - Henko
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2013</remarks>
        public bool UseWarehouseDiscount { get; set; }

        /// <summary>
        /// This is used when a Purchase Order is created from another document so that when you select the Suppliers it wont erase the lines
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/07/2013</remarks>
        protected bool ClearLinesOnCompanyChanged
        {
            get
            {
                return clearLinesOnCompanyChanged;
            }
            set
            {
                if (clearLinesOnCompanyChanged != value)
                {
                    clearLinesOnCompanyChanged = value;
                }
            }
        }

        protected DB.VW_Company SelectedCompany
        {
            get
            {
                return selectedCompany;
            }
            set
            {
                //If this is the first time the Company is set
                if (selectedCompany == null || selectedCompany.Id != value.Id)
                    selectedCompany = value;
            }
        }

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

        protected override bool SaveSuccessful()
        {
            if (!AllowSave)
                return false;

            try
            {
                this.OnSaveRecord();
                if (!IsValid)
                    return false;

                DialogResult result = Essential.DocumentAlert.ShowAlert("Save Document", "You are about to save this document do you wish to continue ?", Essential.DocumentAlert.Buttons.SaveAndPrint);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return false;

                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    string message = "";
                    Int64 printerId = 0;
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
                    switch (DocumentType)
                    {
                        case BL.SYS.SYS_DOC_Type.Quote:
                            break;
                        case BL.SYS.SYS_DOC_Type.SalesOrder:
                            break;
                        case BL.SYS.SYS_DOC_Type.TAXInvoice:
                            break;
                        case BL.SYS.SYS_DOC_Type.CreditNote:
                            break;
                        case BL.SYS.SYS_DOC_Type.PickingSlip:
                            break;
                        case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                            break;
                        case BL.SYS.SYS_DOC_Type.GoodsReceived:
                            break;
                        case BL.SYS.SYS_DOC_Type.GoodsReturned:
                            break;
                        case BL.SYS.SYS_DOC_Type.Job:
                            break;
                        case BL.SYS.SYS_DOC_Type.TransferRequest:
                            break;
                        case BL.SYS.SYS_DOC_Type.TransferShipment:
                            break;
                        case BL.SYS.SYS_DOC_Type.TransferReceived:
                            break;
                        case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                            break;
                        case BL.SYS.SYS_DOC_Type.BackOrder:
                            break;
                        default:
                            message = "Document Type not supported";
                            break;
                    }
                    Form originForm = Doc_Header.OriginForm;
                    Doc_Header.OriginForm = null;
                    message = BL.ApplicationDataContext.Instance.Service.SaveDocument(entry, printerId);
                    
                    if (message.StartsWith("Success"))
                    {
     
                        var returns = message.Split(',');
                        //Normal Document number
                        //Sean: Added && returns[1] != "", no document numbers??
                        if (returns[1] != null && returns[1] != "")
                        {
                            ShowNotification("Document Saved", String.Format("{0} number {1} was saved successfully", this.Text, returns[1]), 5000, false, CDS.Client.Desktop.Document.Properties.Resources.check_32);
                            entry.IgnoreChanges = true;
                            
                            entry.DocumentNumber = Convert.ToInt64(returns[1]);
                            entry.IgnoreChanges = false;
                        }

                        //Tracking number
                        if (returns[2] != null)
                        {
                            ShowNotification("Document Saved", String.Format("{0} number {1} was saved successfully", "Tracking", returns[2]), 5000, false, CDS.Client.Desktop.Document.Properties.Resources.pencil_32);
                            entry.IgnoreChanges = true;
                            entry.TrackId = Convert.ToInt64(returns[2]);
                            entry.IgnoreChanges = false;
                        }
                        

                        //Werner: Because the Entities are sent to the Service the are disjoint from the context and the Reject Changes cannot be checked
                        //I am making the assumption that when the service returns Success there will not be any further changes to the document
                        //YOU SHOULD NOT BE ABLE TO EDIT ANY DOCUMENT SO I CAN MAKE THIS ASSUMPTION
                        ForceClose = true;
                        string stringHandle = Handle.ToString();
                        foreach (System.IO.FileInfo file in (new System.IO.DirectoryInfo(Environment.CurrentDirectory + @"\Recovery")).GetFiles().Where(n => n.Name.StartsWith(stringHandle)))
                        {
                            file.Delete();
                        }
                        AllowSave = false;
                        ReadOnly = true;
                        AllowChanges = false;
                        return true;
                    }
                    else if (message != string.Empty)
                    {
                        DocumentSaveException(message);
                        return false;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                CurrentException = ex;
                MessageBox.Show(Convert.ToString(ex));
                Doc_Header.SYS_DOC_Line.Clear();
                return false;
            }
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                isValid = IsLinesValid() && IsDocumentValid();
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
            bool LinesValid = true;

            if (lines.Count() == 0)
            {
                Essential.BaseAlert.ShowAlert("Invalid Document", "Your document has no lines.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                return false;
            }

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Quantity < 0)
                {
                    grvItems.FocusedRowHandle = i;
                    grvItems.SetColumnError(colQuantity, "Invalid Value");
                    ShowMessage("Invalid Value", 3000);
                    LinesValid = false;
                    break;
                }
            }

            return LinesValid;
        }

        private bool IsDocumentValid()
        {
            bool DocumentValid = true;
            if (documentType == BL.SYS.SYS_DOC_Type.SalesOrder && Doc_Header.BackOrder != null && Doc_Header.Total == 0.00M)
                DocumentValid = false;
            return DocumentValid;
        }

        private bool HandlePaste()
        {
            int rowCount = 0;
            try
            {
                IDataObject data = Clipboard.GetDataObject();
                //data.GetData("Text").ToString().Split('\n')
                if (data.GetData("Text") == null)
                    return false;

                using (LumenWorks.Framework.IO.Csv.CsvReader csv = new LumenWorks.Framework.IO.Csv.CsvReader(new System.IO.StringReader(data.GetData("Text").ToString()), false, '\t'))
                {

                    while (csv.ReadNextRecord())
                    {
                        ++rowCount;
                        DB.SYS_DOC_Line line = BL.SYS.SYS_DOC_Line.New;

                        string itemName = csv[0];
                        DB.VW_LineItem item = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.ShortName == itemName );

                        if (item == null)
                            continue;

                        line.LineItem = item;
                        PopulateNewLine(line);
                        line.ItemId = item.Id;

                        if (csv.FieldCount >= 2)
                            line.Quantity = Convert.ToDecimal(csv[1]);

                        if (csv.FieldCount >= 3)
                            line.Amount = Convert.ToDecimal(csv[2]);

                        ValidateLineAmount(line);
                        CalculateLineTotals(line);
                        lines.Add(line);

                    }
                }
                grvItems.RefreshData();
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(string.Format("Invalid value in row {0}.\nOne or more items could not be pasted", rowCount), 5000);
            }
            finally
            {
                grvItems.RefreshData();
            }
            return false;
        }

        public BaseDocument()
        {
            InitializeComponent();
            
        }

        public BaseDocument(Int64 id)
        {
            InitializeComponent();
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected virtual void DocumentSaveException(string message)
        {
            Essential.BaseAlert.ShowAlert("Save Document failed", "Your document could not be saved at this time please try again." + Environment.NewLine + message, Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
            HasErrors = true;
            CurrentException = new Exception(message);
        }

        /// <summary>
        /// This method can be used to execute code after the Company Has Changed on the Inherited Forms
        /// </summary>
        public virtual void CompanyChanged()
        {
            if (ddlCompany.EditValue == null || Convert.ToInt64(ddlCompany.EditValue) == Convert.ToInt64(0))
                return;

            if (ItemState == EntityState.Generated)
            {
                switch (DocumentType)
                {
                    case BL.SYS.SYS_DOC_Type.Quote:
                        break;
                    case BL.SYS.SYS_DOC_Type.SalesOrder:
                        break;
                    case BL.SYS.SYS_DOC_Type.TAXInvoice:
                        break;
                    case BL.SYS.SYS_DOC_Type.CreditNote:
                        break;
                    case BL.SYS.SYS_DOC_Type.PickingSlip:
                        break;
                    case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                        foreach (DB.SYS_DOC_Line line in Doc_Header.SYS_DOC_Line)
                        {
                            PopulateNewLine(line);
                            ValidateLineAmount(line);
                            //ValidateLineDiscount(line);
                            CalculateLineTotals(line);
                            CalculateDocumentTotals();
                        }                       
                        break;
                    case BL.SYS.SYS_DOC_Type.GoodsReceived:
                        break;
                    case BL.SYS.SYS_DOC_Type.GoodsReturned:
                        break;
                    case BL.SYS.SYS_DOC_Type.Job:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferRequest:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferShipment:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferReceived:
                        break;
                    case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                        break;
                    case BL.SYS.SYS_DOC_Type.BackOrder:
                        break;
                }
            }
        }

        protected override void OnNewRecord()
        {
            int i = 1;
            base.OnNewRecord();
            
            Doc_Header = BL.SYS.SYS_DOC_Document.New(DocumentType);
            Doc_Header.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.New;
            Doc_Header.ORG_TRX_Header.CompanyId = 0;
            //SiteId
            Doc_Header.SiteId = Convert.ToInt64(BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            lines.Clear();
            Doc_Header.SYS_DOC_Line = lines;
            grdItems.RefreshDataSource();
            ddlCompany.EditValue = Convert.ToInt64(0);
            ddlCompany.Focus();
            
            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    //Custom pre-sets for this document type
                    Doc_Header.ORG_TRX_Header.IgnoreChanges = true;
                    Doc_Header.ORG_TRX_Header.DateValid = DateTime.Now.AddDays(BL.ApplicationDataContext.Instance.CompanySite.QuoteValidDays);
                    dtExpirationDate.Properties.MaxValue = DateTime.Now.AddDays(BL.ApplicationDataContext.Instance.CompanySite.QuoteValidMax);
                    
                    Doc_Header.ORG_TRX_Header.IgnoreChanges = false;
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
            }
      
        }

        protected override void BindData()
        {
            base.BindData();
            
            BindingSource.DataSource = Doc_Header;
            BindingSourceTransaction.DataSource = Doc_Header.ORG_TRX_Header;

            foreach (DB.SYS_DOC_Line line in Doc_Header.SYS_DOC_Line)
            {
                // Must populate line Parent for use in calculate totals
                // For non generated documents
                if (line.LineItem == null)
                {
                    line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId );
                    line.UnitAverage = line.LineItem.UnitAverage;
                    line.UnitCost = line.LineItem.UnitCost;

                    var movement = BL.ITM.ITM_Movement.LoadByLineId(line.Id, DataContext);
                    if (movement != null)
                    {
                        line.UnitAverage = movement.UnitAverage.Value;
                        line.UnitCost = movement.UnitCost.Value;
                    }
                }
                //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;
                lines.Add(line);
            }
            refDocs = BL.SYS.SYS_DOC_Document.LinkedDocuments(Doc_Header.TrackId, DataContext).ToList();
            readOnlyLineCount = Doc_Header.SYS_DOC_Line.Count();
            lineCounter = BL.SYS.SYS_DOC_Document.MaxLineOrder(refDocs);

            PopulateUnboundFields();
            BindingSourceLine.DataSource = lines;
 
            if (ItemState == EntityState.Recovered)
                SetUnsavedIcon();
        }

        protected override void OnStart()
        {
            base.OnStart();
            colTotalTax.Caption = String.Format("Tax ({0:0.##}%)", BL.ApplicationDataContext.Instance.CompanySite.VatPercentage);
            defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;



        }

        protected override void XPOPreBindDataFilter()
        {
            base.XPOPreBindDataFilter();
            //XPOInstantFeedbackSourceItem.FixedFilterCriteria = new DevExpress.Data.Filtering.InOperator("TypeId.Name", new string[] { "Inventory", "Account" });
            updateItemBindingSource();
            //Changed the datasource to use VW_Entity, so that siteIds could be used for filtering
            //switch (CompanyType)
            //{
            //    case BL.ORG.ORG_Type.Customer:
            //        //XPInstantFeedbackSourceItem.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[TypeId.Id] in (" + BL.ApplicationDataContext.Instance.CompanySite.LineTypeFilter + ") and IIF([TypeId.Id] = " + (byte)BL.SYS.SYS_Type.Account + " and " + (byte)BL.SYS.SYS_Type.Account + " in (" + BL.ApplicationDataContext.Instance.CompanySite.LineTypeFilter + "), [ShowOnSales] = true,true)");
            //        XPInstantFeedbackSourceItem.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[SiteId] = ? and [TypeId.Id] in (" + string.Join(", ", BL.ApplicationDataContext.Instance.CompanySite.LineTypeList) + ") and IIF([TypeId.Id] = " + (byte)BL.SYS.SYS_Type.Account + ",[ShowOnSales] = true,true)", defaultSiteId);
            //        break;
            //    case BL.ORG.ORG_Type.Supplier:
            //        XPInstantFeedbackSourceItem.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[SiteId] = ? and [TypeId.Id] in (" + string.Join(", ", BL.ApplicationDataContext.Instance.CompanySite.LineTypeList) + ") and IIF([TypeId.Id] = " + (byte)BL.SYS.SYS_Type.Account + ", [ShowOnPurchases] = true,true)", defaultSiteId);
            //        //XPInstantFeedbackSourceItem.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("IIF([TypeId.Id] = " + (byte)BL.SYS.SYS_Type.Account + " and " + (byte)BL.SYS.SYS_Type.Account + " in (" + BL.ApplicationDataContext.Instance.CompanySite.LineTypeFilter + "), [ShowOnPurchases] = true,true)");
            //        break;
            //}
            
            ////Fix this when Devexpress fixed Repository VIew Binding XPO Issue
            //repLineEntity.DataSource = XPInstantFeedbackSourceItem; 
        }

        protected override void LoadLayout()
        {
            base.LoadLayout();

            if (TabColor != null && LayoutGroup.AppearanceGroup.BackColor == new Color())
            {
                LayoutGroup.AppearanceGroup.Options.UseBackColor = true;
                LayoutGroup.AppearanceGroup.BackColor = TabColor;
                LayoutGroup.AppearanceGroup.BackColor2 = TabColor;
                grvItems.Appearance.Empty.BackColor = ControlPaint.Light(TabColor, 1.5f);
            }

            this.Invoke(new Action(() =>
            {
                ServerModeSourceShippingType.QueryableSource = DataContext.EntityOrganisationContext.ORG_TRX_ShippingType;
                ServerModeSourcePaymentType.QueryableSource = DataContext.EntityOrganisationContext.ORG_PaymentTerm;
                ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
            }));              
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            //if (this.ItemState != EntityState.New && this.ItemState != EntityState.Recovered)
            if (ItemState == EntityState.Generated)
            {
                AllowChanges = false;
            }

            AllowSaveAndNew = false;

            if (!IsNew)
            {
                ReadOnly = true;
                AllowPrint = true;
                AllowExportToPdf = true;
                btnEmailOnly.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOTI01) && DocumentType == BL.SYS.SYS_DOC_Type.TAXInvoice)
                {
                    AllowPrint = true;
                    // Documents do not have a Print Preview
                    AllowPrintPreview = false;
                }
            }
            else
            {
                AllowArchive = false;
            }

            ApplyFieldVisibility(); 
            ApplyColumnVisibility();

            if (!AllowChanges)
            {
                //Must disable company drop down user not allowed to change company
                ddlCompany.Properties.ReadOnly = true;

                //Must Disable document lines when opening from existing document (You are not allowed to change any lines of the document)
                grvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                colItemId.OptionsColumn.AllowFocus = false;
                colDescription.OptionsColumn.AllowFocus = false;
                grvItems.OptionsBehavior.Editable = false;
            }

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    colAmount.OptionsColumn.AllowFocus = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR02);
                    colDiscountPercentage.OptionsColumn.AllowFocus = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR01);
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    colAmount.OptionsColumn.AllowFocus = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR02);
                    colDiscountPercentage.OptionsColumn.AllowFocus = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR01);

                    if (ItemState == EntityState.Generated)
                    {
                        grvItems.OptionsBehavior.Editable = true;
                        colQuantity.OptionsColumn.AllowEdit = true;
                        colAmount.OptionsColumn.AllowFocus = false;
                        colDiscountPercentage.OptionsColumn.AllowFocus = false;
                    }

                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    if (ItemState == EntityState.Generated)
                    {
                        grvItems.OptionsBehavior.Editable = true;
                        colDiscountPercentage.OptionsColumn.AllowFocus = false;
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    if (IsNew)
                    {
                        //Werner: Need to enable this when creating Purchase Order from Back Order
                        ddlCompany.Properties.ReadOnly = false;
                        ClearLinesOnCompanyChanged = false;
                    }

                    if (ItemState == EntityState.Generated)
                    {
                        grvItems.OptionsBehavior.Editable = true;
                        colQuantity.OptionsColumn.AllowFocus = false;
                        colAmount.OptionsColumn.AllowFocus = true;
                        colDiscountPercentage.OptionsColumn.AllowFocus = true;
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    //Henko - TODO: Security option removed from roles
                    //colDiscountPercentage.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOGR04);
                    if (IsNew)
                    {
                        grvItems.OptionsBehavior.Editable = true;
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    if (ItemState == EntityState.Generated)
                    {
                        grvItems.OptionsBehavior.Editable = true;
                        colDiscountPercentage.OptionsColumn.AllowFocus = false;
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
            }
        }

        public override void OnExportToPDF()
        {
            //throw new Exception("We need to add the SARS PDF encryption here");
            base.OnExportToPDF();
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            Doc_Header = BL.SYS.SYS_DOC_Header.Load(Id, DataContext, new List<String>() { "SYS_DOC_Line" });
            Doc_Header.ORG_TRX_Header = BL.ORG.ORG_TRX_Header.LoadByHeaderId(Id, DataContext); 
            //ShouldRecover = false;
        }

        public override void OnPrint()
        {
            //base.OnPrint();

            DialogResult result = Essential.DocumentAlert.ShowAlert("Print Document", "You are about to print this document do you wish to continue ?", Essential.DocumentAlert.Buttons.Print);

            if (result != System.Windows.Forms.DialogResult.Cancel)
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    BL.ApplicationDataContext.Instance.Service.PrintDocument(Doc_Header.Id, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value);
                }
        }

        public override void Recover(List<BindingSource> bindingSources)
        {
            base.Recover(bindingSources);

            Doc_Header = (BindingSource.DataSource as DB.SYS_DOC_Header);
            Doc_Header.ORG_TRX_Header = (BindingSourceTransaction.DataSource as DB.ORG_TRX_Header);

            if (lines.Any())
                grvItems.OptionsBehavior.Editable = true;
            ItemState = EntityState.Recovered;

            if (Doc_Header.Generated)
                ItemState = EntityState.Generated;

            SendKeys.SendWait("{TAB}");
        }
         
        private void ApplyFieldVisibility()
        {
            if (IsNew)
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    itmExpirationDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    itmTypeDropdownSpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    itmShippingType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    itmTypeDropdownSpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    itmDueDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
            }
        }

        private void ApplyColumnVisibility()
        {
            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    if (IsNew)
                    {
                        colQtyReceived.Visible = false;
                        colQtyOutstanding.Visible = false;
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    //colQtyBackOrder.Visible = IsNew; 
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    //Werner: No Use on Credit Note Documents
                    colQtyReceived.Visible = false;
                    colQtyOutstanding.Visible = false;
                    colProfitPercentage.Visible = false;
                    colSearchProfitMargin.Visible = false;
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    colQtyReceived.Visible = false;
                    colQtyOutstanding.Visible = false;
                    //Werner: No Use on Picking Slip Documents
                    colProfitPercentage.Visible = false;
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    colQtyReceived.Visible = !IsNew;
                    colQtyOutstanding.Visible = !IsNew;
                    //Werner: No Use on Purchase Documents
                    colProfitPercentage.Visible = false;
                    colAmount.Caption = "Unit Cost";
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    colQtyReceived.Visible = !IsNew;
                    colQtyOutstanding.Visible = !IsNew;
                    //Werner: No Use on Purchase Documents
                    colProfitPercentage.Visible = false;
                    colAmount.Caption = "Unit Cost";
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    colQtyReceived.Visible = false;
                    colQtyOutstanding.Visible = false;
                    colProfitPercentage.Visible = false;
                    //Werner: No Use on Picking Slip Documents 
                    colDiscountPercentage.Visible = false;
                    colAmount.Caption = "Unit Cost";
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    //Werner: No Use on Transfer Documents
                    colProfitPercentage.Visible = false;
                    colAmount.Caption = "Unit Cost";
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    //Werner: No Use on Transfer Documents
                    colProfitPercentage.Visible = false;
                    colAmount.Caption = "Unit Cost";
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    //Werner: No Use on Transfer Documents
                    colProfitPercentage.Visible = false;
                    colAmount.Caption = "Unit Cost";
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    //Werner: No Use on Inventory Adjustment Documents
                    colProfitPercentage.Visible = false;
                    colAmount.Caption = "Unit Cost";
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    //Werner: No Use on Back Order Document
                    colProfitPercentage.Visible = false;
                    break;
            }
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

            //If new item is a stock item and Bar codes are enabled populate line with quantity one 
            if (BL.ApplicationDataContext.Instance.CompanySite.UseBarcodes && line.LineItem.InventoryId != null)
            {
                line.Quantity = 1M;
                grvItems.FocusedColumn = colAmount;
            }

            //If new item is a stock item and the document type is a Quote or Job Quote populate line with quantity one 
            if ((DocumentType == BL.SYS.SYS_DOC_Type.Quote || DocumentType == BL.SYS.SYS_DOC_Type.JobQuote) && line.LineItem.InventoryId != null)
                line.Quantity = 1;

            if ((DocumentType == BL.SYS.SYS_DOC_Type.Quote || DocumentType == BL.SYS.SYS_DOC_Type.SalesOrder) && line.LineItem.InventoryId != null)
                line.Quantity = line.LineItem.SellingPackSize.HasValue ? line.LineItem.SellingPackSize.Value : 1;

            if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut && DocumentType == BL.SYS.SYS_DOC_Type.SalesOrder)
                line.Quantity = line.LineItem.OnHand;

            line.Description = line.LineItem.ShortName;
            line.UnitAverage = line.LineItem.UnitAverage;
            line.UnitCost = line.LineItem.UnitCost;

            PopulateLineOrder();
            ValidateLineQuantity(line);
            PopulateLineAmount(line);
            PopulateLineDiscountMatrix(line);
        }

        /// <summary>
        /// Sets the lines amount value
        /// </summary>
        /// <param name="line">The current line that needs to be populated</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
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

        /// <summary>
        /// Apply the lines discount from the discount matrix
        /// </summary>
        /// <param name="line">The line that the discount matrix is applied to</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void PopulateLineDiscountMatrix(DB.SYS_DOC_Line line)
        {
            decimal sellPrice, discountPrice, discountPercentage;

            BL.ORG.ORG_TRX_PriceHelper.GetSellPrice(line, SelectedCompany, line.Quantity, UseWarehouseDiscount, out sellPrice, out discountPrice, out discountPercentage, DataContext);

            line.Amount = discountPrice;
            line.DiscountPercentage = discountPercentage;

        }

        private void ValidateLineAmount(DB.SYS_DOC_Line line)
        {
            if (BL.ApplicationDataContext.Instance.LoggedInUser.DiscountLimit.HasValue && BL.ApplicationDataContext.Instance.LoggedInUser.DiscountLimit.Value < line.DiscountPercentage)
            {
                Essential.BaseAlert.ShowAlert("Not Authorized", "You do not have the right to apply the set discount percentage.\nPlease log in with a user with sufficient rights.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                line.DiscountPercentage = 0;
                PopulateLineAmount(line);
            }

            if (DocumentType == BL.SYS.SYS_DOC_Type.SalesOrder
                || DocumentType == BL.SYS.SYS_DOC_Type.Quote)
            {

                if (!(SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR06)
                    || SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR06)) && line.Amount < line.LineItem.UnitPrice)
                {
                    PopulateLineAmount(line);
                    PopulateLineDiscountMatrix(line);
                    Essential.BaseAlert.ShowAlert("Not Authorized", "You do not have the right to sell below mark up.\nPlease log in with a user with sufficient rights.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);

                }

                if (!(SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR05)
                    || SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR05)) && line.Amount < line.LineItem.UnitAverage)
                {
                    PopulateLineAmount(line);
                    PopulateLineDiscountMatrix(line);
                    Essential.BaseAlert.ShowAlert("Not Authorized", "You do not have the right to sell below cost.\nPlease log in with a user with sufficient rights.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);

                }
            }
        }

        /// <summary>
        /// Applies a discount percentage on a specific line : TODO
        /// </summary>
        /// <param name="line">The line that the discount percentage is applied to</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void ApplyLineDiscountPercentage(DB.SYS_DOC_Line line)
        {
            if (line.DiscountPercentage < 0 || line.DiscountPercentage > 99)
            {
                PopulateLineAmount(line);
                PopulateLineDiscountMatrix(line);
                return;
            }

            line.Amount = Math.Round(line.Amount - (line.Amount * line.DiscountPercentage.Value / 100), 2, MidpointRounding.AwayFromZero);
            //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;
            //ValidateLineAmount(line);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void ValidateLineQuantity(DB.SYS_DOC_Line line)
        {
            if (line.Quantity < 0)
                line.Quantity = 0;

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    if (line.Quantity > line.LineItem.OnHand && line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory)
                    {
                        if (!SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR))
                        {
                            line.Quantity = Math.Max(0, line.LineItem.OnHand);
                            Essential.BaseAlert.ShowAlert("Excessive quantity", "You do not have the right to place items on backorder.\nPlease log in with a user with sufficient rights.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                        }
                        else if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR))
                        {
                            line.QtyOutstanding = line.Quantity - Math.Max(0, line.LineItem.OnHand);
                        }
                    }
                    else
                    {
                        line.QtyOutstanding = 0;
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    if (Doc_Header.TaxInvoice != null)
                    {
                        switch (line.LineItem.TypeId)
                        {
                            case (byte)BL.SYS.SYS_Type.Inventory:
                                if (line.Quantity > Doc_Header.TaxInvoice.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder).QtyReceived)
                                {
                                    line.Quantity = Doc_Header.TaxInvoice.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder).QtyReceived;
                                    Essential.BaseAlert.ShowAlert("Excessive quantity", "Credit cannot exceed original TAX Invoice quantity", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                                }
                                break;
                        }
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
            }

            if (SelectedLine.Surcharge.Count > 0)
            {
                foreach (var surcharge in SelectedLine.Surcharge)
                {
                    surcharge.Quantity = line.Quantity;
                    CalculateLineTotals(surcharge);
                }
            }

        }

        /// <summary>
        /// Populates all the columns that are not persistent to the database
        /// </summary>
        /// <param name="line">The current line that needs to be populated</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void PopulateUnboundFields()
        {

            if (ItemState == EntityState.New)
                return;

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:

                    Doc_Header.Processed = refDocs.Any(n => n.TrackId == Doc_Header.TrackId && n.TypeId == (byte)BL.SYS.SYS_DOC_Type.SalesOrder);

                    Parallel.ForEach(lines, line =>
                    {
                        if (line.Quantity > 0)
                            line.QtyOutstanding += line.Quantity;

                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.TAXInvoice)), refInvoices =>
                        {
                            if (line.Quantity > 0)
                            {
                                lock (line)
                                {
                                    line.QtyOutstanding -= refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.QtyReceived += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                }
                            }
                        });

                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.Quote)), refQuote =>
                        {
                            if (line.Quantity < 0)
                            {
                                lock (line)
                                {
                                    line.QtyOutstanding += refQuote.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.QtyReceived -= refQuote.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                }
                            }
                        });
                    });
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    //If Generated we need to check the Holding values again
                    if (ItemState == EntityState.Generated)
                    {
                        //TODO: Werner - Somehow run ValidateLineQuantity here for generated documents without the alerts repeating
                        bool alertAccessive = false;

                        Parallel.ForEach(lines, line =>
                        {
                            if (line.Quantity > line.LineItem.OnHand)
                            {
                                if (!SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORECR))
                                {
                                    line.Quantity = line.LineItem.OnHand;
                                    alertAccessive = true;
                                }
                                else
                                    line.QtyOutstanding = line.Quantity - line.LineItem.OnHand;
                            }
                        });

                        if (alertAccessive)
                            Essential.BaseAlert.ShowAlert("Excessive quantity", "You do not have the right to place items on backorder.\nPlease log in with a user with sufficient rights.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    }
                    else
                    {
                        Parallel.ForEach(lines, line =>
                        {
                            line.QtyOutstanding = line.Quantity;

                            Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.TAXInvoice)), refInvoices =>
                            {
                                lock (line)
                                {
                                    line.QtyOutstanding -= refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.QtyReceived += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.AmountInvoiced += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Amount;
                                    // UnitAverage Populated in BindData but need to be refreshed if the Sales order has TAX Invoice
                                    if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory)
                                        line.UnitAverage = BL.ITM.ITM_Movement.LoadByLineId(refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Id, DataContext).UnitAverage.Value;
                                }

                            });

                            Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.CreditNote)), refCredits =>
                            {
                                lock (line)
                                {
                                    line.QtyReceived -= refCredits.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.AmountInvoiced -= refCredits.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Amount;
                                }
                            });

                            Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.BackOrder)), refBackOrders =>
                            {
                                lock (line)
                                {
                                    if (refBackOrders.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity < 0))
                                        line.QtyOutstanding += refBackOrders.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity < 0).Quantity;
                                }
                            });

                            //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;
                        });
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:

                    var backorder = refDocs.FirstOrDefault(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.BackOrder);
                    Parallel.ForEach(lines, line =>
                    {
                        if (backorder != null)
                        {
                            line.QtyOutstanding += backorder.SYS_DOC_Line.Where(n => n.LineOrder == line.LineOrder).Sum(n => n.Quantity);
                        }

                        //For TAX Invoices create after Back Order
                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.TAXInvoice)), refInvoices =>
                        {
                            lock (line)
                            {
                                if (backorder != null && refInvoices.CreatedOn > backorder.CreatedOn)
                                    line.QtyOutstanding -= refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;

                                line.QtyReceived += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                            }
                        });

                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.CreditNote)), refCredits =>
                        {
                            lock (line)
                            {
                                if (refCredits.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)
                                        line.AmountCredited += refCredits.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Amount;

                                    line.QtyReceived -= refCredits.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                }
                            }
                        });
                    });
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:

                    Parallel.ForEach(lines, line =>
                    {
                        line.QtyOutstanding = line.Quantity;

                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived)), refRecieved =>
                        {
                            lock (line)
                            {
                                if (refRecieved.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)
                                        line.AmountInvoiced += refRecieved.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Amount;

                                    line.QtyReceived += refRecieved.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.QtyOutstanding -= refRecieved.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.QtyOutstanding = Math.Max(0, line.QtyOutstanding);
                                }
                            }
                        });

                        //Removed Purchase Order Canceled lines from Outstanding
                        if (line.Quantity > 0)
                        {
                            lock (line)
                            {
                                if (Doc_Header.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity < 0))
                                    line.QtyOutstanding += Doc_Header.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity < 0).Quantity;
                            }
                        }
                    });



                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:

                    var purchaseorder = refDocs.FirstOrDefault(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder);
                    Parallel.ForEach(lines, line =>
                    {
                        if (purchaseorder != null)
                        {
                            line.QtyOutstanding += purchaseorder.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                        }

                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived)), refRecieved =>
                        {
                            lock (line)
                            {
                                if (refRecieved.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    if (purchaseorder != null)
                                    {
                                        line.QtyOutstanding -= refRecieved.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    }
                                    line.QtyReceived += refRecieved.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                }
                            }
                        });

                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReturned)), refReturned =>
                        {
                            lock (line)
                            {
                                if (refReturned.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    line.AmountCredited += refReturned.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Amount;
                                    line.QtyReceived -= refReturned.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                }
                            }
                        });
                    });
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:

                    Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.PurchaseOrder)), refOrders =>
                    {
                        Parallel.ForEach(lines, line =>
                        {
                            lock (line)
                            {
                                if (refOrders.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    line.QtyOutstanding += refOrders.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                }
                            }
                        });
                    });
                    Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReceived)), refRecieved =>
                    {
                        Parallel.ForEach(lines, line =>
                        {
                            lock (line)
                            {
                                if (refRecieved.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    line.QtyReceived += refRecieved.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                    line.QtyOutstanding -= line.QtyReceived;
                                }
                            }
                        });
                    });
                    Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.GoodsReturned)), refReturns =>
                    {
                        Parallel.ForEach(lines, line =>
                        {
                            lock (line)
                            {
                                if (refReturns.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    line.QtyReceived -= refReturns.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                }
                            }
                        });
                    });
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:

                    Parallel.ForEach(lines, line =>
                    {
                        line.QtyOutstanding = line.Quantity;
                        //line.UnitAverage = line.LineItem.UnitAverage;

                        Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.TAXInvoice && n.CreatedOn > Doc_Header.CreatedOn)), refInvoices =>
                        {
                            lock (line)
                            {
                                if (refInvoices.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                                {
                                    if (refInvoices.CreatedOn > Doc_Header.CreatedOn)
                                    {
                                        line.QtyOutstanding -= refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                        line.QtyReceived += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                                        line.AmountInvoiced += refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Amount;
                                    }
                                    // TODO: Werner - Add Tree Structure to tracking numbers so that we know which invoice is linked to which back order
                                    // Calculation below cannot work when a Back Order has multiple Invoices
                                    // To be honest with will never work when a Back Order has More then on TAX Invoice 
                                    // if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory)
                                    //     line.UnitAverage = BL.ITM.ITM_Movement.LoadByLineId(refInvoices.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Id, DataContext).UnitAverage.Value;
                                }
                            }
                        });

                        //Removed Back Order Canceled lines from Outstanding
                        if (line.Quantity > 0)
                        {
                            lock (line)
                            {
                                if (Doc_Header.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity < 0))
                                    line.QtyOutstanding += Doc_Header.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity < 0).Quantity;
                            }
                        }
                        //Werner: Again we need the tree structure because there is now way to know it this credit is for the original sales orders invoice
                        //Parallel.ForEach((refDocs.Where(n => n.TypeId == (byte)BL.SYS.SYS_DOC_Type.CreditNote && n.CreatedOn > Doc_Header.CreatedOn)), refCredits =>
                        //{
                        //    lock (line)
                        //    {
                        //        if (refCredits.SYS_DOC_Line.Any(n => n.LineOrder == line.LineOrder && n.Quantity >= 0))
                        //        {
                        //            if (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)
                        //                line.AmountCredited += refCredits.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Amount;

                        //            line.QtyReceived -= refCredits.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity;
                        //        }
                        //    }
                        //});

                        //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;
                    });
                    break;
            }

            Parallel.ForEach(lines, line =>
            {
                if (line.Quantity < 0)
                {
                    lines.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Quantity += line.Quantity;
                    lines.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).Total -= line.Total;
                    lines.FirstOrDefault(n => n.LineOrder == line.LineOrder && n.Quantity >= 0).TotalTax -= line.TotalTax;
                }

            });

            lines = lines.Where(n => n.Quantity >= 0).ToList();

        }

        /// <summary>
        /// Calculate a lines Total and Tax
        /// </summary>
        /// <param name="line">The line which totals you wish to calculate</param>
        /// <remarks>Created: Henko Rabie 23/01/2015</remarks>
        private void CalculateLineTotals(DB.SYS_DOC_Line line)
        {
            // Accounts do not have a quantity also not allowed to change quantity so always use 1 if Parent Type = 5 (Account)
            line.Total = Math.Round(line.Amount * (line.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account ? 1 : line.Quantity), 2, MidpointRounding.AwayFromZero);
            if (IsNew && SelectedCompany != null)
            {
                //TODO: Check if item is VAT Exempt
                switch (SelectedCompany.CostCategoryId)
                {
                    case (byte)BL.ORG.ORG_CostCategory.SellingPriceIncludingSalesTax:
                        line.TotalTax = line.Total * BL.ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.SellingPriceExcludingSalesTax:
                        line.TotalTax = 0;
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.CostIncludingSalesTax:
                        line.TotalTax = line.Total * BL.ApplicationDataContext.Instance.CompanySite.VatPercentage / 100;
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.CostExcludingSalesTax:
                        line.TotalTax = 0;
                        break;
                    case (byte)BL.ORG.ORG_CostCategory.AverageCostExcludingSalesTax:
                        line.TotalTax = 0;
                        break;
                }
            }
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
            //TODO: Henko: Will implement 2 separate rounding settings for sales and purchase documents (then move this to BL SYS_DOC_Header)
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
            grvItems.UpdateSummary();
        }

        private void PopulateFieldsFromCompany()
        {
            if (Doc_Header.ORG_TRX_Header.CompanyId == 0)
                return;

            Doc_Header.ORG_TRX_Header.ReferenceShort2 = SelectedCompany.RepCode;
            Doc_Header.ORG_TRX_Header.ReferenceShort3 = SelectedCompany.SalesmanCode;
            Doc_Header.ORG_TRX_Header.VatNumber = SelectedCompany.VatNumber;
            Doc_Header.ORG_TRX_Header.ContactPerson = SelectedCompany.SalesContact;
            Doc_Header.ORG_TRX_Header.ContactTelephone = SelectedCompany.SalesTelephone;

            DB.VW_Address billingAddress = DataContext.ReadonlyContext.VW_Address.FirstOrDefault(n => n.CompanyId == Doc_Header.ORG_TRX_Header.CompanyId && n.TypeId == (byte)BL.SYS.SYS_Type.BillingAddress);
            DB.VW_Address shippingAddress = DataContext.ReadonlyContext.VW_Address.FirstOrDefault(n => n.CompanyId == Doc_Header.ORG_TRX_Header.CompanyId && n.TypeId == (byte)BL.SYS.SYS_Type.ShippingAddress);

            Doc_Header.ORG_TRX_Header.BillingAddressLine1 = billingAddress.Line1;
            Doc_Header.ORG_TRX_Header.BillingAddressLine2 = billingAddress.Line2;
            Doc_Header.ORG_TRX_Header.BillingAddressLine3 = billingAddress.Line3;
            Doc_Header.ORG_TRX_Header.BillingAddressLine4 = billingAddress.Line4;
            Doc_Header.ORG_TRX_Header.BillingAddressCode = billingAddress.Code;

            Doc_Header.ORG_TRX_Header.ShippingAddressLine1 = shippingAddress.Line1;
            Doc_Header.ORG_TRX_Header.ShippingAddressLine2 = shippingAddress.Line2;
            Doc_Header.ORG_TRX_Header.ShippingAddressLine3 = shippingAddress.Line3;
            Doc_Header.ORG_TRX_Header.ShippingAddressLine4 = shippingAddress.Line4;
            Doc_Header.ORG_TRX_Header.ShippingAddressCode = shippingAddress.Code;
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

        private void SelectCompany(object sender)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            //if (hi.InRowCell) MessageBox.Show(view.GetRowCellValue(view.FocusedRowHandle, "Id").ToString());

            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            SelectedCompany = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(view.GetFocusedRow())).OriginalRow as DB.VW_Company;
        }

        protected void AddBarcodeItems(List<Stock.ScanItemDialogue.BarcodeItem> items)
        {
            items.ForEach(i =>
            {
                grvItems.AddNewRow();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    var entityId = uow.Query<XDB.SYS_Entity>().Where(n => n.Barcode == i.Barcode).Select(l => l.Id).FirstOrDefault();
                    grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colItemId, entityId);
                    grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colQuantity, i.Quantity);
                }

            });
        }

        protected void AddBuyoutItem(Stock.BuyoutDialogue dlg)
        {
            //XPInstantFeedbackSourceItem.Refresh();
            updateItemBindingSource();
                 switch (DocumentType)
                 {
                     case BL.SYS.SYS_DOC_Type.Quote:
                         break;
                     case BL.SYS.SYS_DOC_Type.BackOrder:
                         break;
                     case BL.SYS.SYS_DOC_Type.SalesOrder: 
                         grvItems.AddNewRow();
                         grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colItemId, dlg.IBO_TRX_Header.EntityId);
                         grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colQuantity, dlg.IBO_TRX_Header.Quantity);
                         break;
                     case BL.SYS.SYS_DOC_Type.TAXInvoice:
                         break;
                     case BL.SYS.SYS_DOC_Type.CreditNote:
                         break;
                     case BL.SYS.SYS_DOC_Type.PickingSlip:
                         break;
                     case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                         break;
                     case BL.SYS.SYS_DOC_Type.GoodsReceived:
                         //Doc_Header.SYS_DOC_Line.Add(dlg.SYS_DOC_Header_GoodsReceived.SYS_DOC_Line.FirstOrDefault());
                         //lines = Doc_Header.SYS_DOC_Line; 
                         grvItems.AddNewRow();
                         (grvItems.GetRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle) as DB.SYS_DOC_Line).IBO_TRX_Header = dlg.IBO_TRX_Header;
                         
                         grvItems.SetRowCellValue(grvItems.FocusedRowHandle, colItemId, dlg.IBO_TRX_Header.EntityId);
                         grvItems.SetRowCellValue(grvItems.FocusedRowHandle, colQuantity, dlg.IBO_TRX_Header.Quantity);
                         grvItems.SetRowCellValue(grvItems.FocusedRowHandle, colAmount, dlg.IBO_TRX_Header.UnitCost);

                         SelectedLine.UnitCost = dlg.IBO_TRX_Header.UnitCost;
                         SelectedLine.UnitAverage = dlg.IBO_TRX_Header.UnitCost;

                         break;
                     case BL.SYS.SYS_DOC_Type.GoodsReturned:
                         break;
                     case BL.SYS.SYS_DOC_Type.Job:
                         break;
                     case BL.SYS.SYS_DOC_Type.TransferRequest:
                         break;
                     case BL.SYS.SYS_DOC_Type.TransferShipment:
                         break;
                     case BL.SYS.SYS_DOC_Type.TransferReceived:
                         break;
                     case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                         break;
                 }
        }

        public void AddCatalogueItem(Int64 entityId)
        {
            int prevFocusedRowHandle = grvItems.FocusedRowHandle;
            grvItems.AddNewRow();
            grvItems.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
            DB.SYS_DOC_Line line = (grvItems.GetFocusedRow() as DB.SYS_DOC_Line);
            line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == entityId );
            grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colItemId, entityId);
            grvItems.FocusedColumn = colDescription; 
            grvItems_FocusedRowChanged(grvItems, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(prevFocusedRowHandle, grvItems.FocusedRowHandle));
            ShowNotification("Catalogue", "Added " + line.LineItem.Name, 2000, false, null);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!DesignMode)// ||  !(System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv.exe *32"))
            {
                this.Text = String.Format("{0}",
                       DataContext.EntitySystemContext.SYS_DOC_Type.FirstOrDefault(n => n.Id == Doc_Header.TypeId).Name);

                this.Text += Doc_Header.DocumentNumber != null ? string.Format(" - {0}", ((DB.SYS_DOC_Header)BindingSource.DataSource).DocumentNumber) : "";

                this.SuperTipParameter = this.Text + "," + this.Text;

                //This is used to load the Company when a Editable document is opened
                //Should mostly be triggered by die Recovery Process
                if (((DB.ORG_TRX_Header)BindingSourceTransaction.DataSource).CompanyId != 0)
                    SelectedCompany = DataContext.ReadonlyContext.VW_Company.FirstOrDefault(n => n.Id == ((DB.ORG_TRX_Header)BindingSourceTransaction.DataSource).CompanyId);

                if(IsNew)
                    foreach (DB.SYS_DOC_Line line in lines)
                    {
                        CalculateLineTotals(line);
                    }
            }

        }

        private void BaseDocument_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    Close();
                    break;

            }
        }

        /// <summary>
        /// Checks that a accounts has been selected if not do not allow user to leave control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCompany_Leave(object sender, EventArgs e)
        {
            ValidateLayout();
            if (ddlCompany.EditValue == DBNull.Value || ddlCompany.EditValue == null || Convert.ToInt64(ddlCompany.EditValue) == Convert.ToInt64(0))
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

        /// <summary>
        /// Once a company has been selected the Document Line Grid is enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (ddlCompany.EditValue != DBNull.Value && ddlCompany.EditValue != null && ddlCompany.EditValue.ToString() != string.Empty /*&& lines.Count == 0*/ && Convert.ToInt64(ddlCompany.EditValue) != Convert.ToInt64(0))
            {
                grvItems.OptionsBehavior.Editable = true;
                SelectCompany((sender as SearchLookUpEdit).Properties.View);
                CompanyChanged();
            }
        }

        /// <summary>
        /// Populates the Field from the SelectedCompany
        /// This is done in the method because all the Binding of the DataSources has been completed at this point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public override void btnSaveAndEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                base.btnSaveAndEmail_ItemClick(sender, e);
                if (!HasErrors && IsValid)
                {
                    // TODO: Implement document email function here...
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Warns the user that he is about to change the selected Company and that the Document Lines will he cleared
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCompany_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (ClearLinesOnCompanyChanged && e.OldValue != null && e.NewValue != DBNull.Value && e.NewValue != null && lines.Count > 0 && Convert.ToInt64(e.NewValue) != 0)
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

        private void grvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DB.SYS_DOC_Line line = (grvItems.GetFocusedRow() as DB.SYS_DOC_Line);
            if (line == null)
                return;

            if (line.ItemId != 0 && line.LineItem == null)
                line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == line.ItemId );

            switch (e.Column.FieldName)
            {
                //Handled by Repository Item
                case "ItemId":
                    if ((DocumentType == BL.SYS.SYS_DOC_Type.Quote || DocumentType == BL.SYS.SYS_DOC_Type.SalesOrder) && DataContext.ReadonlyContext.VW_Alternative.Any(n => n.SearchItemName == line.LineItem.Name))
                    { 
                        using (AlternativeDialogue dlg = new AlternativeDialogue(line.LineItem.Name))
                        {
                            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            { 
                                line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == dlg.SelectedItem.EntityId );
                                line.IgnoreChanges = true;
                                line.ItemId = dlg.SelectedItem.EntityId.Value;
                                line.IgnoreChanges = false;
                            }
                        }
                    }
                    //Populate all fields for this items line
                    PopulateNewLine(line);

                    //Below is was done after PopulateNewLine as this will cause issues with FocusedRow
                    //Populate Surcharge
                    if ((DocumentType == BL.SYS.SYS_DOC_Type.Quote || DocumentType == BL.SYS.SYS_DOC_Type.SalesOrder || DocumentType == BL.SYS.SYS_DOC_Type.CreditNote) && DataContext.EntityInventoryContext.ITM_Surcharge.Any(n => n.EntityId == line.LineItem.Id))
                    {
                        foreach (var itmSurcharge in DataContext.EntityInventoryContext.ITM_Surcharge.Where(n => n.EntityId == line.LineItem.Id).Select(l => l.SurchargeId))
                        {
                            var sysSurcharge = DataContext.EntitySystemContext.SYS_Surcharge.FirstOrDefault(n => n.EntityId == itmSurcharge);
                            if(DataContext.ReadonlyContext.VW_Entity.FirstOrDefault(n=> n.Id == sysSurcharge.AccountId).SiteId == defaultSiteId) { 
                            grvItems.AddNewRow();
                            grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colItemId, sysSurcharge.EntityId);
                            grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colQuantity, 1);
                            grvItems.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, colAmount, sysSurcharge.Amount);
                            line.Surcharge.Add(SelectedLine);
                            }
                        }
                    }
                    break;
                case "Quantity":
                    ValidateLineQuantity(line);
                    break;
                case "Amount":
                    ChangeLineAmount(line);
                    break;
                //case "DiscountAmount":
                //    break;
                case "DiscountPercentage":
                    ApplyLineDiscountPercentage(line);
                    break;
            }

            ValidateLineAmount(line);
            //ValidateLineDiscount(line);
            CalculateLineTotals(line);
            CalculateDocumentTotals();
            grvItems.InvalidateRowCell(e.RowHandle, colTotal);
            ValidateLayout();
        }

        private void ChangeLineAmount(DB.SYS_DOC_Line line)
        {
            //Werner: No document that can be created from this screen should have negative values
            if (line.Amount < 0 && line.LineItem.TypeId != (byte)BL.SYS.SYS_Type.Account)
            {
                //Reset Line Amount
                PopulateLineAmount(line);
                PopulateLineDiscountMatrix(line);
            }
            else
            {
                //HENKO: What is supposed to happen here ???
                line.DiscountPercentage = 0;
                //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;
            }

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    if (Doc_Header.TaxInvoice != null)
                    {
                        switch (line.LineItem.TypeId)
                        {
                            case (byte)BL.SYS.SYS_Type.Inventory:
                                break;
                            case (byte)BL.SYS.SYS_Type.Account:
                                if (Doc_Header.TaxInvoice.SYS_DOC_Line.Any(n => line.LineOrder == n.LineOrder && line.Amount > (n.Amount - n.AmountCredited)))
                                {
                                    line.Amount = Doc_Header.TaxInvoice.SYS_DOC_Line.Where(n => n.LineOrder == line.LineOrder).Select(n => n.Amount - n.AmountCredited).FirstOrDefault();
                                    Essential.BaseAlert.ShowAlert("Excessive amount", "Credit cannot exceed original TAX Invoice amount", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                                }
                                break;
                        }
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
            }
        }

        private void grvItems_KeyDown(object sender, KeyEventArgs e)
        {
            //Delete selected Line
            if (!this.ReadOnly && e.Control && e.KeyCode == Keys.R && !colItemId.OptionsColumn.ReadOnly)
            {
                if (Essential.BaseAlert.ShowAlert("Delete Line", "You are about to delete the selected line do you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach(var surcharge in SelectedLine.Surcharge)
                    {
                        lines.Remove(surcharge);
                        readOnlyLineCount--;
                    }

                    grvItems.DeleteSelectedRows();
                    readOnlyLineCount--;
                    //for (int i = 0; i < ((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource).Count(); i++)
                    //{
                    //    //((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource)[i].LineOrder = i + 1;
                    //    CalculateLineTotals(((List<DB.SYS_DOC_Line>)BindingSourceLine.DataSource)[i]);
                    //}
                   
                    PopulateLineOrder();

                    CalculateDocumentTotals();
                    grvItems.RefreshData();
                }
            }
            //Open Inventory
            else if (e.Control && e.KeyCode == Keys.I && BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSTRE))
            {
                ValidateLayout();

                if (SelectedLine == null || SelectedLine.ItemId == 0)
                    return;

                if (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Inventory)
                {
                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        var mainform = Application.OpenForms["MainForm"];
                        Type typExternal = mainform.GetType();
                        System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowInventoryTransactionForm");

                        methodInf.Invoke(mainform, new object[] { SelectedLine.LineItem.InventoryId});
                    }
                }
                else if (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut)
                {
                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        var mainform = Application.OpenForms["MainForm"];
                        Type typExternal = mainform.GetType();
                        System.Reflection.MethodInfo methodInf = typExternal.GetMethod("ShowBuyoutForm");

                        methodInf.Invoke(mainform, new object[] { SelectedLine.ItemId });
                    }
                }
            }
            //Open Company
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
            //Delete Key on Sales Order BackOrder Column
            else if (!this.ReadOnly && e.Control && e.KeyCode == Keys.Delete && grvItems.FocusedColumn == colQtyOutstanding)
            {
                (grvItems.GetFocusedRow() as DB.SYS_DOC_Line).Quantity -= (grvItems.GetFocusedRow() as DB.SYS_DOC_Line).QtyOutstanding;
                (grvItems.GetFocusedRow() as DB.SYS_DOC_Line).QtyOutstanding = 0.00M;
                ValidateLayout();
            }
            //Handel Paste
            else if (!this.ReadOnly && (e.Control && e.KeyCode == Keys.V))
            {
                if (HandlePaste())
                {
                    e.SuppressKeyPress = true;
                    PopulateLineOrder();
                    CalculateDocumentTotals();
                    ValidateLayout();
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

        private void grvItems_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvItems.GetFocusedRow() == null)
                return;

            if (
                //Cancel Edit for Quantity and Discount if line Entity is a Account
                ((grvItems.FocusedColumn == colQuantity || grvItems.FocusedColumn == colDiscountPercentage) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Account)
                ||
                //Cancel Edit for Quantity, Discount and colAmount if line Entity is a Message
                ((grvItems.FocusedColumn == colQuantity || grvItems.FocusedColumn == colDiscountPercentage || grvItems.FocusedColumn == colAmount) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Message)
                )
                //&& new List<Int64>() { (byte)BL.SYS.SYS_Type.Account, (byte)BL.SYS.SYS_Type.Message }.Contains((((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId))
                e.Cancel = true;

            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.JOB && n.Code == "YES"))
            {
                if (Doc_Header.OriginForm != null
                    && Doc_Header.OriginForm.Name == "JobForm"
                    && (grvItems.FocusedColumn == colItemId
                    || grvItems.FocusedColumn == colDescription
                    || grvItems.FocusedColumn == colQuantity))
                    e.Cancel = true;
            }
            if (ItemState == EntityState.Generated)
            {
                switch (DocumentType)
                {
                    case BL.SYS.SYS_DOC_Type.Quote:
                        break;
                    case BL.SYS.SYS_DOC_Type.SalesOrder:
                        break;
                    case BL.SYS.SYS_DOC_Type.TAXInvoice:
                        break;
                    case BL.SYS.SYS_DOC_Type.CreditNote:
                        if ((grvItems.FocusedColumn == colQuantity) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Account)
                            e.Cancel = true;
                        else if ((grvItems.FocusedColumn == colAmount) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Inventory)
                            e.Cancel = true;
                        break;
                    case BL.SYS.SYS_DOC_Type.PickingSlip:
                        break;
                    case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                        break;
                    case BL.SYS.SYS_DOC_Type.GoodsReceived:
                        break;
                    case BL.SYS.SYS_DOC_Type.GoodsReturned:
                        if ((grvItems.FocusedColumn == colQuantity) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Account)
                            e.Cancel = true;
                        else if ((grvItems.FocusedColumn == colAmount) && (((DB.SYS_DOC_Line)grvItems.GetFocusedRow()).LineItem as DB.VW_LineItem).TypeId == (byte)BL.SYS.SYS_Type.Inventory)
                            e.Cancel = true;
                        break;
                    case BL.SYS.SYS_DOC_Type.Job:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferRequest:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferShipment:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferReceived:
                        break;
                    case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                        break;
                    case BL.SYS.SYS_DOC_Type.BackOrder:
                        break;
                }
            }
            else if (IsNew)
            {
                switch (DocumentType)
                {
                    case BL.SYS.SYS_DOC_Type.Quote:
                        break;
                    case BL.SYS.SYS_DOC_Type.BackOrder:
                        break;
                    case BL.SYS.SYS_DOC_Type.SalesOrder:
                        //Cannot change quantity of buyout if added from Dialogue
                        if (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut && grvItems.FocusedColumn == colQuantity && SelectedLine.IBO_TRX_Header != null)
                            e.Cancel = true;
                        break;
                    case BL.SYS.SYS_DOC_Type.TAXInvoice:
                        break;
                    case BL.SYS.SYS_DOC_Type.CreditNote: 
                        break;
                    case BL.SYS.SYS_DOC_Type.PickingSlip:
                        break;
                    case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                        break;
                    case BL.SYS.SYS_DOC_Type.GoodsReceived:
                        //Cannot change quantity of buyout if added from Dialogue
                        if (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.BuyOut && (grvItems.FocusedColumn == colQuantity || grvItems.FocusedColumn == colAmount || grvItems.FocusedColumn == colDiscountPercentage) && SelectedLine.IBO_TRX_Header != null)
                            e.Cancel = true;
                        break;
                    case BL.SYS.SYS_DOC_Type.GoodsReturned: 
                        break;
                    case BL.SYS.SYS_DOC_Type.Job:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferRequest:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferShipment:
                        break;
                    case BL.SYS.SYS_DOC_Type.TransferReceived:
                        break;
                    case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                        break;
                }
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

                line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == entityId );

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        } 

        private void grvItems_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            switch (DocumentType)
            {
                case BL.SYS.SYS_DOC_Type.Quote:
                    break;
                case BL.SYS.SYS_DOC_Type.SalesOrder:

                    if (Doc_Header.Quote != null)
                    {
                        DB.SYS_DOC_Line parentLine = Doc_Header.Quote.SYS_DOC_Line.FirstOrDefault(n => n.LineOrder == SelectedLine.LineOrder);

                        if (parentLine != null && Convert.ToDecimal(e.Value) > parentLine.Quantity)
                            grvItems.SetFocusedRowCellValue(grvItems.FocusedColumn, parentLine.Quantity);
                    }

                    //if (grvItems.FocusedColumn == colQuantity && SelectedLine.Quantity > SelectedLine.LineItem.OnHand && !SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSIRECR03))
                    //{
                    //    Essential.BaseAlert.ShowAlert("Excessive quantity", "You do not have the right to sell into negative.\nPlease log in with a user will sufficient right.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    //    grvItems.SetFocusedRowCellValue(grvItems.FocusedColumn, SelectedLine.LineItem.OnHand);
                    //}
                    break;
                case BL.SYS.SYS_DOC_Type.TAXInvoice:
                    break;
                case BL.SYS.SYS_DOC_Type.CreditNote:
                    break;
                case BL.SYS.SYS_DOC_Type.PickingSlip:
                    break;
                case BL.SYS.SYS_DOC_Type.PurchaseOrder:
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReceived:
                    if (grvItems.FocusedColumn == colQuantity && (DataContext.EntitySystemContext.Entry(Doc_Header).State != System.Data.Entity.EntityState.Detached) && e.Value.ToString() != string.Empty && Convert.ToDecimal(e.Value) > SelectedLine.QtyOutstanding &&
                        !(Essential.BaseAlert.ShowAlert("Excessive quantity", "You have added a quantity that is higher then the original order.\nPlease check Ordered and Shipped quantities.\nDo you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                        )
                    {
                        grvItems.SetFocusedRowCellValue(grvItems.FocusedColumn, SelectedLine.QtyOutstanding);
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.GoodsReturned:
                    if (grvItems.FocusedColumn == colQuantity && (DataContext.EntitySystemContext.Entry(Doc_Header).State != System.Data.Entity.EntityState.Detached) && e.Value.ToString() != string.Empty && Convert.ToDecimal(e.Value) > SelectedLine.QtyReceived &&
                      !(Essential.BaseAlert.ShowAlert("Excessive quantity", "You have added a quantity that is higher then the original invoice.\nPlease check Credit quantities.\nDo you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                      )
                    {
                        grvItems.SetFocusedRowCellValue(grvItems.FocusedColumn, SelectedLine.QtyOutstanding);
                    }
                    break;
                case BL.SYS.SYS_DOC_Type.Job:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferRequest:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferShipment:
                    break;
                case BL.SYS.SYS_DOC_Type.TransferReceived:
                    break;
                case BL.SYS.SYS_DOC_Type.InventoryAdjustment:
                    break;
                case BL.SYS.SYS_DOC_Type.BackOrder:
                    break;
            }
        }

        private void InstantFeedbackSourceCompany_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Company.Where(n => n.TypeId == (byte)CompanyType && !n.Archived && n.SiteId == defaultSiteId);//.Take(5);
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
                        e.TotalValue = TotalIncl - Doc_Header.ORG_TRX_Header.Rounding;
                    }
                    else
                    {
                        e.TotalValue = TotalIncl;
                    }
                }
        } 
         
        private void grvItems_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (SelectedLine == null || SelectedLine.LineItem == null)
            {
                grvItems.FocusedColumn = colItemId;
                return;
            }

            if (e.FocusedColumn == colItemId && SelectedLine.LineItem != null)
            {
                grvItems.FocusedColumn = grvItems.VisibleColumns[grvItems.Columns[grvItems.FocusedColumn.FieldName].VisibleIndex + 1];
            }

            if (e.FocusedColumn == colQuantity && (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account) || (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Message))
            {
                grvItems.FocusedColumn = grvItems.VisibleColumns[grvItems.Columns[grvItems.FocusedColumn.FieldName].VisibleIndex + 1];
            }

            if (e.FocusedColumn == colDiscountPercentage && (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account) || (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Message))
            {
                grvItems.FocusedColumn = grvItems.VisibleColumns[grvItems.Columns[grvItems.FocusedColumn.FieldName].VisibleIndex - 1];
            }
        }

        private void grvItems_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (SelectedLine == null || SelectedLine.LineItem == null)
            {
                grvItems.FocusedColumn = colItemId;
                return;
            }

            if (grvItems.FocusedColumn == colItemId && SelectedLine.LineItem != null)
            {
                grvItems.FocusedColumn = grvItems.VisibleColumns[grvItems.Columns[grvItems.FocusedColumn.FieldName].VisibleIndex + 1];
            }

            if ((grvItems.FocusedColumn == colQuantity && (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)) || (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Message))
            {
                grvItems.FocusedColumn = grvItems.VisibleColumns[grvItems.Columns[grvItems.FocusedColumn.FieldName].VisibleIndex + 1];
            }

            if ((grvItems.FocusedColumn == colDiscountPercentage && (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Account)) || (SelectedLine.LineItem.TypeId == (byte)BL.SYS.SYS_Type.Message))
            {
                grvItems.FocusedColumn = grvItems.VisibleColumns[grvItems.Columns[grvItems.FocusedColumn.FieldName].VisibleIndex - 1];
            }
        }

        private void btnEmailOnly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GenerateEmail();
        }

        private void repLineEntity_Popup(object sender, EventArgs e)
        {
            (sender as SearchLookUpEdit).Properties.View.ActiveFilterString = string.Format("[Type] in ({0})", "'" + String.Join("','", BL.ApplicationDataContext.Instance.CompanySite.LineTypeFilter.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)) + "'");
                
                //String.Format("[Type] in ({0})", "'" + String.Join("','", BL.ApplicationDataContext.Instance.CompanySite.LineTypeFilter.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)) + "'");

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

                        if (DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Name == searchValue ).Count() == 1)
                        {
                            (grvItems.ActiveEditor as DevExpress.XtraEditors.SearchLookUpEdit).EditValue =
                            DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Name == searchValue ).Select(l => l.Id).FirstOrDefault();
                            grvItems.SetFocusedRowCellValue(colItemId, DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Name == searchValue).Select(l => l.Id).FirstOrDefault());
                            SendKeys.SendWait("{ENTER}");
                            SendKeys.SendWait("{ENTER}");
                        }
                    }
                };
        }

        public override void OnShowCustomization()
        { 
            base.OnShowCustomization();
            if (IsNew)
            {
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                ReadOnly = false;
            }
            AllowSave = false;
        }

        public override void OnClosedCustomization()
        {
            base.OnClosedCustomization();
            if (IsNew)
            {
                lcgHistory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                AllowSave = true;
            }
            else
            {
                ReadOnly = true;
            }
        }

        public void updateItemBindingSource()
        {
            List<byte> typeList = BL.ApplicationDataContext.Instance.CompanySite.LineTypeList.ToList();
            switch (CompanyType)
            {
                case BL.ORG.ORG_Type.Customer:
                    repLineEntity.DataSource = DataContext.ReadonlyContext.VW_Entity.Where(n => n.SiteId == defaultSiteId && typeList.Contains(n.TypeId) && ((n.TypeId == (byte)BL.SYS.SYS_Type.Account) ? ((n.AccountTypeId == (byte)1) ? true : false) : true)).ToList();
                    break;
                case BL.ORG.ORG_Type.Supplier:
                    repLineEntity.DataSource = DataContext.ReadonlyContext.VW_Entity.Where(n => n.SiteId == defaultSiteId && typeList.Contains(n.TypeId) && ((n.TypeId == (byte)BL.SYS.SYS_Type.Account) ? ((n.AccountTypeId == (byte)3) ? true : false) : true)).ToList();
                    break;
            }
        }
    }
  
}

/*
 long currentperiod = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext).Id;

            e.QueryableSource =
                    from entity in new DevExpress.Xpo.XPQuery<CDS.Client.DataAccessLayer.XDB.SYS_Entity>(DevExpress.Xpo.Session.DefaultSession) 
                    join inventory in new DevExpress.Xpo.XPQuery<CDS.Client.DataAccessLayer.XDB.ITM_Inventory>(DevExpress.Xpo.Session.DefaultSession) on entity.Id equals inventory.EntityId.Id
                    join site in new DevExpress.Xpo.XPQuery<CDS.Client.DataAccessLayer.XDB.SYS_Site>(DevExpress.Xpo.Session.DefaultSession) on inventory.SiteId equals site.EntityId
                    join itmHistory in new DevExpress.Xpo.XPQuery<CDS.Client.DataAccessLayer.XDB.ITM_History>(DevExpress.Xpo.Session.DefaultSession) on new { inventory.InventoryId.Id, periodid = currentperiod } equals new { itmHistory.InventoryId.Id, periodid = itmHistory.PeriodId.Id }
                    join account in new DevExpress.Xpo.XPQuery<CDS.Client.DataAccessLayer.XDB.GLX_Account>(DevExpress.Xpo.Session.DefaultSession) on entity.Id equals account.EntityId.Id
                    join accHistory in new DevExpress.Xpo.XPQuery<CDS.Client.DataAccessLayer.XDB.GLX_History>(DevExpress.Xpo.Session.DefaultSession) on new { account.EntityId.Id, periodid = currentperiod } equals new { accHistory.EntityId.Id, periodid = accHistory.PeriodId.Id }
                    join primSupplier in new DevExpress.Xpo.XPQuery<CDS.Client.DataAccessLayer.XDB.ITM_InventorySupplier>(DevExpress.Xpo.Session.DefaultSession) on new { inventory.Id, primary = true } equals new { primSupplier.InventoryId.Id, primary = primSupplier.PrimarySupplier }
                    select new CDS.Client.DataAccessLayer.XDB.Views.VW_LineItem() {
                        Id                          = entity.Id
                        ,InventoryId                 = inventory.Id
                        ,AccountId                   = account.Id
                        ,AccountTypeId               = account.AccountTypeId.Id
                        ,TypeId                      = entity.TypeId.Id
                        ,SiteId                      = site.Id
                        ,Type                        = entity.TypeId.Name
                        ,ShortName                   = entity.ShortName
                        ,Name                        = entity.Name
                        ,Description                 = Description
                        ,CodeMain                    = entity.CodeMain
                        ,CodeSub                     = entity.CodeSub
                        ,SupplierStockCode           = primSupplier.SupplierStockCode
                        ,Archived                    = entity.Archived
                        ,CreatedOn                   = entity.CreatedOn
                        ,CreatedBy                   = entity.CreatedBy.Id
                        ,Category                    = inventory.Category
                        ,SubCategory                 = inventory.SubCategory
                        ,StockType                   = inventory.StockType
                        ,LocationMain                = inventory.LocationMain
                        ,LocationSecondary           = inventory.LocationSecondary
                        ,Barcode                     = inventory.Barcode
                        ,MinimumStockLevel           = inventory.MinimumStockLevel
                        ,MaximumStockLevel           = inventory.MaximumStockLevel
                        ,SafetyStock                 = inventory.SafetyStock
                        ,WarehousingCost             = inventory.WarehousingCost
                        ,DiscountCode                = inventory.DiscountCode
                        ,Grouping                    = inventory.Grouping
                        ,ProfitMargin                = inventory.ProfitMargin
                        ,LabelFlag                   = inventory.LabelFlag
                        ,CostofSalesId               = inventory.CostofSalesId.Id
                        ,RequireSerial               = inventory.RequireSerial
                        ,SellingPackSize             = inventory.SellingPackSize
                        ,OnHand                      = itmHistory.OnHand
                        ,OnReserve                   = itmHistory.OnReserve
                        ,OnOrder                     = itmHistory.OnOrder
                        ,UnitPrice                   = itmHistory.UnitPrice
                        ,UnitCost                    = itmHistory.UnitCost
                        ,UnitAverage                 = itmHistory.UnitAverage
                        ,BalanceAmount               = accHistory.Amount
                        ,FirstSold                   = itmHistory.FirstSold.Value
                        ,FirstPurchased              = itmHistory.FirstPurchased.Value
                        ,LastSold                    = itmHistory.LastSold.Value
                        ,LastPurchased               = itmHistory.LastPurchased.Value
                        ,LastMovement                = itmHistory.LastMovement.Value
                        ,Site                        = site.EntityId.Name
                        ,Title                       = entity.Title
                    }
 */