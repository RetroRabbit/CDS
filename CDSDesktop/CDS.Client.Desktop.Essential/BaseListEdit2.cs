using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;

namespace CDS.Client.Desktop.Essential
{
    public partial class BaseListEdit2 : CDS.Client.Desktop.Essential.Base
    {
        private bool _haserrors = false;

        /// <summary>
        /// List of Ids of the rows that have been flaged as Editable
        /// </summary>
        protected List<Int64> EditableRows = new List<Int64>();

        protected List<DevExpress.XtraGrid.Columns.GridColumn> ReadonlyColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>();

        protected Int64 SelectedRowId
        {
            get
            {
                if (GridView.FocusedRowHandle < 0)
                    return -1;

                return Convert.ToInt64(GridView.GetFocusedRow().GetType().GetProperty("Id").GetValue(GridView.GetFocusedRow()));
            }
        }

        /// <summary>
        /// This boolean is set if anything went wrong during the OnSaveRecord() method and then checked before continuing on to the 
        /// SaveAndNew or SaveAndClose finishes
        /// </summary>
        /// <remarks>Created: Werner Scheffer 10/09/2013</remarks>
        public bool HasErrors
        {
            get
            {
                return _haserrors;
            }

            set
            {
                if (value)
                {
                    _haserrors = value;
                }
                else
                {
                    _haserrors = value;
                }
            }
        }

        /// <summary>
        /// Sets whether or not the Open Record button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowEditRecord
        {
            get
            {
                return this.btnEditRecord.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnEditRecord.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the New Record button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowNewRecord
        {
            get
            {
                return this.btnNewRecord.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnNewRecord.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
         

        /// <summary>
        /// Sets whether or not the New Record button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public String ActiveFilter
        {
            get
            {
                return GridView.ActiveFilterString;
            }
            set
            {
                GridView.ActiveFilterString = value;
            }
        }

        public BaseListEdit2()
        {
            InitializeComponent();
        }
 
        /// <summary>
        /// Occurs when the Refresh button is clicked. Inheriting forms should override this method to handle the refresh.
        /// </summary>
        /// <remarks>Created: Theo Crous 16/11/2011</remarks>
        protected virtual void OnUndo()
        {
         
        }

        /// <summary>
        /// Show the print preview form for the GridControl.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnPrintPreview()
        {
            try
            {
                base.OnPrintPreview();
                if (GridControl.IsPrintingAvailable)
                    GridControl.ShowRibbonPrintPreview();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Print the current values in the GridControl.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnPrint()
        {
            try
            {
                base.OnPrint();
                GridControl.Print();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Opens the file 
        /// </summary>
        /// <param name="filepath"></param>
        public void OpenExportFile(string filepath)
        {
            if (filepath == null)
                return;

            if (Essential.BaseAlert.ShowAlert("View file", "File exported would you like to view this file ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Information) == System.Windows.Forms.DialogResult.OK)
                System.Diagnostics.Process.Start(filepath);
        }

        /// <summary>
        /// Export the current values in the GridControl to Excel file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToExcel()
        {
            try
            {

                base.OnExportToExcel();
                string filepath = GetExportFilePath("Excel Files|*.xlsx");
                if (filepath != null)
                { 
                    GridControl.ExportToXlsx(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current values in the GridControl to Pdf file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToPDF()
        {
            try
            {
                base.OnExportToPDF();
                string filepath = GetExportFilePath("PDF Files|*.pdf");
                if (filepath != null)
                {
                    GridControl.ExportToPdf(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current values in the GridControl to Text file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToText()
        {
            try
            {
                base.OnExportToText();
                string filepath = GetExportFilePath("Text Files|*.txt");
                if (filepath != null)
                {
                    GridControl.ExportToText(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current values in the GridControl to Rtf file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToRTF()
        {
            try
            {
                base.OnExportToRTF();
                string filepath = GetExportFilePath("RTF Files|*.rtf");
                if (filepath != null)
                {
                    GridControl.ExportToRtf(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current values in the GridControl to Html file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToHTML()
        {
            try
            {
                base.OnExportToHTML();
                string filepath = GetExportFilePath("HTML Files|*.html");
                if (filepath != null)
                {
                    GridControl.ExportToHtml(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current values in the GridControl to Csv file format.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnExportToCSV()
        {
            try
            {
                base.OnExportToCSV();
                string filepath = GetExportFilePath("CSV Files|*.csv");
                if (filepath != null)
                {
                    GridControl.ExportToHtml(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// This method is called when the user clicks on the Edit Record button or double clicks on a row entry. The method should be overridden in all inheriting forms to handle the editing of the record.
        /// </summary>
        /// <param name="Id"></param>
        /// <remarks>Created: Werner Scheffer 14/11/2011</remarks>
        protected virtual void OnEditRecord(Int64 Id)
        {
            if (!EditableRows.Contains(Id))
                EditableRows.Add(Id);
        }

        /// <summary>
        /// This method is called when the user clicks on the New Record button and should be overridden in all inheriting forms to handle the creation of new records.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnNewRecord()
        {

        }

        /// <summary>
        /// This method is called when the user clicks on the Save Record button and should be overridden in all inheriting forms to handle the saving of the values in the form.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnSaveRecord()
        {
            try
            {
                //Reset error state for try catch
                HasErrors = false;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Runs BindData for ServerModeSource
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();            
        }

        /// <summary>
        /// This method will apply access security
        /// </summary>
        /// <remarks>Created: Werner Scheffer 07/03/2014</remarks>
        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowExport = true;
        }
        
        protected virtual bool AllowEdit()
        {
            throw new Exception("Need to Override IsNew() for this form. If you have remove the base.IsNew()");
            
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SelectedRowId == -1)//Werner : Cant get this to work|| !(GridControl.MainView as GridView).CalcHitInfo(MousePosition).InRow)
                    return;

                this.OnEditRecord(SelectedRowId);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (OnValidate())
                {
                    this.OnSaveRecord();
                    this.TabIcon = this.TabIconBackup;
                    this.Parent.TopLevelControl.Refresh();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (OnValidate())
                {
                    this.OnSaveRecord();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void GridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            //Allow new rows to be edited
            if (GridView.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle)
                return;

            if (EditableRows.Contains(Convert.ToInt64(GridView.GetFocusedRowCellValue("Id"))) && AllowEdit())
                return; 

            e.Cancel = true;
        }

        private void btnEditRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SelectedRowId == -1)
                    return; 
                
                this.OnEditRecord(SelectedRowId);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnNewRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.OnNewRecord();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.OnUndo();
                GridControl.RefreshDataSource();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        } 

        private void BaseList_Shown(object sender, EventArgs e)
        {
            try
            {
                GridFilterDefaults.ApplyStandards(GridView);
                GridView.DataController.VisibleRowCountChanged += DataController_VisibleRowCountChanged;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void DataController_VisibleRowCountChanged(object sender, EventArgs e)
        {
            if (GridView.DataController.LastErrorText != string.Empty &&GridView.DataController.LastErrorText.StartsWith("LINQ to Entities does not recognize the method"))
            {
                Exception ex = new CDS.Shared.Exception.InvalidEntityQueryException(GridView.DataController.LastErrorText);
                if (CDS.Shared.Exception.DataAccessExceptionHandler.HandleException(ref ex)) throw ex;
            }
        }

        /// <summary>
        /// Handel KeyUp Actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 29/10/2013</remarks>
        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || (e.Control && e.KeyCode == Keys.O))
            {
                if (SelectedRowId == -1) 
                    return;

                this.OnEditRecord(SelectedRowId);
            }
            else if (e.KeyCode == Keys.Z)
                this.OnUndo();
            else if (e.Control && e.KeyCode == Keys.N)
                this.OnNewRecord();
        }

        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            OnNewRecord();
        }

        private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //Do nothing if no data is bound
            if (BindingSource.DataSource.GetType() == typeof(Type).GetType())
                return;

            byte[] img1 = null;
            byte[] img2 = null;

            //Backup Original Image
            using (var ms = new MemoryStream())
            {
                if (this.TabIcon != null)
                {
                    this.TabIcon.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    img1 = ms.ToArray();
                }
            }

            //Create Backup of Floppy Disk Edit Image
            using (var ms = new MemoryStream())
            {
                global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_edit_16.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                img2 = ms.ToArray();
            }

            //Change the TabIcon to Floppy Disk Edit Image and Refresh the MainForm
            if ((img1 == null || !img1.SequenceEqual(img2.AsEnumerable())) && EditableRows.Count != 0)
            {
                this.TabIcon = global::CDS.Client.Desktop.Essential.Properties.Resources.floppy_disk_edit_16;
                this.Parent.TopLevelControl.Refresh();
            }
        } 
          
    }
}
