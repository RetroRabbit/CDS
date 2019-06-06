using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;


namespace CDS.Client.Desktop.Core.Printer
{
    public partial class PrinterForm : CDS.Client.Desktop.Essential.BaseForm
    {
        private List<DictionaryEntry> printerModelList = new List<DictionaryEntry>();
        private List<DictionaryEntry> printerTypeList = new List<DictionaryEntry>();

        public PrinterForm()
        {
            InitializeComponent();
        }

        public PrinterForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            AllowArchive = true;
            PopulateLookupEdits();            
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            BindingSource.DataSource = BL.SYS.SYS_Printer.New;
            BindData();
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            BindingSource.DataSource = BL.SYS.SYS_Printer.Load(Id, DataContext);
            btnArchive.Caption = ((DB.SYS_Printer)BindingSource.DataSource).Archived ? "Un-Archive" : "Archive";
            BindData();
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

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Printer(((DB.SYS_Printer)BindingSource.DataSource), DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                CurrentException = ex;
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowArchive = (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE01));
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPRREED)
                     || BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPRRECR);
        }

        private void PopulateLookupEdits()
        {
            printerModelList.Add(new DictionaryEntry("IBM-PROPRINTER", "IBM-PROPRINTER"));
            printerModelList.Add(new DictionaryEntry("IBM-PROPRINTER-III", "IBM-PROPRINTER-III"));
            printerModelList.Add(new DictionaryEntry("IBM-PROPRINTER-XL", "IBM-PROPRINTER-XL"));
            printerModelList.Add(new DictionaryEntry("IBM-PROPRINTER-XL24", "IBM-PROPRINTER-XL24"));

            printerModelList.Add(new DictionaryEntry("IBM-PPDS", "IBM-PPDS"));

            printerModelList.Add(new DictionaryEntry("EPSON-ESCP2", "EPSON-ESCP2"));
            printerModelList.Add(new DictionaryEntry("EPSON-ESCP", "EPSON-ESCP"));
            printerModelList.Add(new DictionaryEntry("EPSON-9PIN-ESCP", "EPSON-9PIN-ESCP"));
            printerModelList.Add(new DictionaryEntry("EPSON-FX850", "EPSON-FX850"));
            printerModelList.Add(new DictionaryEntry("EPSON-FX1050", "EPSON-FX1050"));
            printerModelList.Add(new DictionaryEntry("EPSON-LQ1070", "EPSON-LQ1070"));

            printerModelList.Add(new DictionaryEntry("HP-PCL", "HP-PCL"));
            printerModelList.Add(new DictionaryEntry("HP-PCL3", "HP-PCL3"));
            printerModelList.Add(new DictionaryEntry("HP-PCL5", "HP-PCL5"));

            printerModelList.Add(new DictionaryEntry("DIABLO", "DIABLO"));

            printerModelList.Add(new DictionaryEntry("PLAIN", "PLAIN"));

            printerModelList.Add(new DictionaryEntry("OKI-MICROLINE", "OKI-MICROLINE"));

            printerModelList.Add(new DictionaryEntry("P-SERIES", "P-SERIES"));

            printerModelList.Add(new DictionaryEntry("PanasonicKX P3123", "PanasonicKX_P3123"));
            printerModelList.Add(new DictionaryEntry("PanasonicKX P1150", "PanasonicKX_P1150"));

            printerTypeList.Add(new DictionaryEntry("DOT MATRIX", "DOTMATRIX"));
            printerTypeList.Add(new DictionaryEntry("INK JET", "INKJET"));
            printerTypeList.Add(new DictionaryEntry("RECEIPT", "RECEIPT"));

            ddlModel.Properties.DataSource = printerModelList;
            ddlType.Properties.DataSource = printerTypeList;
        }

        protected override void BindData()
        {
            try
            {
                base.BindData();
                List<string> printers =  BL.SYS.SYS_Printer.GetAvailablePrinters(BL.ApplicationDataContext.Instance.Service, ((DB.SYS_Printer)BindingSource.DataSource).Location);
                ddlNetworkLocation.Properties.DataSource = printers;

                if (printers.Count == 0)
                    Essential.BaseAlert.ShowAlert("Could not find", "", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Warning);
            }
            catch (Exception ex)
            {
                HasErrors = true;
                Essential.BaseAlert.ShowAlert("Could not find printers", "System was unable to find the list of available printers.\nPlease contact support for assistance.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Warning);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            
        }

        protected override void Archive()
        {
            base.Archive();
            DB.SYS_Printer entity = (DB.SYS_Printer)BindingSource.DataSource;
            entity.Archived = !entity.Archived;
            btnArchive.Caption = entity.Archived ? "Un-Archive" : "Archive";
            try
            {
                using (TransactionScope transaction = DataContext.GetTransactionScope())
                {
                    DataContext.SaveChangesEntitySystemContext();
                    DataContext.CompleteTransaction(transaction);
                }
                DataContext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                DataContext.EntitySystemContext.RejectChanges();
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                bool isValid = true;
                isValid = IsNameValid() && IsLocationValid();
                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        private bool IsNameValid()
        {
            bool isValid = true;
            isValid = !DataContext.EntitySystemContext.SYS_Printer.Any(n => n.Id != ((DB.SYS_Printer)BindingSource.DataSource).Id && n.Name == ((DB.SYS_Printer)BindingSource.DataSource).Name);
            if (!isValid)
                Essential.BaseAlert.ShowAlert("Invalid Name", "The name you have entered is already in use change name before saving", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

            return isValid;
        }

        private bool IsLocationValid()
        {
            bool isValid = true;
            isValid = !DataContext.EntitySystemContext.SYS_Printer.Any(n => n.Id != ((DB.SYS_Printer)BindingSource.DataSource).Id && n.Location == ((DB.SYS_Printer)BindingSource.DataSource).Location);

            if (!isValid)
                Essential.BaseAlert.ShowAlert("Invalid Location", "The location you have entered is already in use change location before saving", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

            return isValid;
        }

        private void ddlModel_Enter(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.LookUpEdit)sender).ShowPopup();
        }

        private void ddlType_Enter(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.LookUpEdit)sender).ShowPopup();
        }

    }
}
