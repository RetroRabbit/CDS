using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.IO;

namespace CDS.Client.Desktop.Essential
{
    public partial class BaseList : CDS.Client.Desktop.Essential.Base
    { 
        /// <summary>
        /// Will force the MainForm to open a new list instance and not select the current open list instance
        /// </summary>
        public bool ForceNew { 
            get; set; 
        }

        protected Int64 SelectedRowId
        {
            get
            {
                if (GridView.FocusedRowHandle < 0 || GridView.GetFocusedRow() is DevExpress.Data.NotLoadedObject )
                    return -1;

                object FocusedRow = GridView.GetFocusedRow();
                // HOWTO: get focusedRow when using instantfeedbackModeSource - DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread
                if (FocusedRow is DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)
                {
                    
                    return Convert.ToInt64(((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)FocusedRow).OriginalRow.GetType().GetProperty("PrimaryKey").GetValue(((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)FocusedRow).OriginalRow, null));
                }
                else
                {
                    //MessageBox.Show(Convert.ToString(FocusedRow.GetType().GetProperty("PrimaryKey").GetValue(FocusedRow, null)));
                    return Convert.ToInt64(FocusedRow.GetType().GetProperty("PrimaryKey").GetValue(FocusedRow, null));
                }
            }
        }

        /// <summary>
        /// Sets whether or not the Open Record button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Theo Crous 15/02/2012</remarks>
        [BrowsableAttribute(true)]
        public bool AllowOpenRecord
        {
            get
            {
                return this.btnOpenRecord.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnOpenRecord.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
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

        public BaseList()
        {
            InitializeComponent();
        }

        public override bool HandleShortcut(IntPtr key)
        {
            //Flag Ctrl as pressed
            if (base.HandleShortcut(key))
            {
                return true;
            }

            if (key == (IntPtr)Keys.Enter || (CtrlPressed && key == (IntPtr)Keys.O))
            {
                if (SelectedRowId == -1)
                    return true;

                if (AllowOpenRecord)
                    this.OnOpenRecord(SelectedRowId);

                return true;
            }
            else if (key == (IntPtr)Keys.F5)
            {
                this.OnRefresh();
                return true;
            }
            else if (CtrlPressed && key == (IntPtr)Keys.N)
            {
                if(AllowNewRecord)
                    this.OnNewRecord();

                return true;
            }
            //else if (CtrlPressed && key == (IntPtr)Keys.E)
            //{
            //    GridView.ShowFilterEditor(GridView.Columns[0]);
            //    return true;
            //}
            CtrlPressed = false;
            return false;
        }

        /// <summary>
        /// Occurs when the Refresh button is clicked. Inheriting forms should override this method to handle the refresh.
        /// </summary>
        /// <remarks>Created: Theo Crous 16/11/2011</remarks>
        protected virtual void OnRefresh()
        {
            BindData(); 
            XPOInstantFeedbackSource.Refresh();
        }

        /// <summary>
        /// This method is called when the user clicks on the Open Record button or double clicks on a row entry. The method should be overridden in all inheriting forms to handle the opening of the record.
        /// </summary>
        /// <param name="Id"></param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnOpenRecord(Int64 Id)
        {

        }

        /// <summary>
        /// This method is called when the user clicks on the New Record button and should be overridden in all inheriting forms to handle the creation of new records.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected virtual void OnNewRecord()
        {

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

        /// <summary>
        /// Runs BindData for ServerModeSource
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            ApplySecurity();

            LayoutControlGrid.RegisterUserCustomizatonForm(typeof(Essential.UTL.CustomizationForm));
            GridView.OptionsMenu.ShowConditionalFormattingItem = true;
            GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            LoadLayout();
        }

        private void LoadLayout()
        {
            string screenName = this.GetType().FullName;
            DB.SYS_Layout sys_layout = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == screenName && n.UserId == BL.ApplicationDataContext.Instance.LoggedInUser.Id);
            if (sys_layout != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(sys_layout.Custom);
                    writer.Flush();
                    stream.Position = 0;
                    LayoutControlGrid.RestoreLayoutFromStream(stream);
                }
            }

            foreach (var control in LayoutControlGrid.Controls)
            {
                if (control is DevExpress.XtraGrid.GridControl)
                {
                    foreach (DevExpress.XtraGrid.Views.Grid.GridView view in (control as DevExpress.XtraGrid.GridControl).Views)
                    {
                        string gridName = screenName + "+" + view.Name;

                        DB.SYS_Layout sys_layout_grid = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == gridName && n.UserId == BL.ApplicationDataContext.Instance.LoggedInUser.Id);
    
                        if(sys_layout_grid!=null)
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                StreamWriter writer = new StreamWriter(stream);
                                writer.Write(sys_layout_grid.Custom);
                                writer.Flush();
                                stream.Position = 0;
                                view.RestoreLayoutFromStream(stream);//, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                            }
                        }
                    }
                }
            }
            foreach (var control in Controls)
            {
                if (control is DevExpress.XtraBars.Ribbon.RibbonControl)
                {
                    string ribbonQuickAccessToolbarName = screenName + "+" + "QuickAccessToolbar";

                    DB.SYS_Layout sys_layout_quick_access = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == ribbonQuickAccessToolbarName && n.UserId == BL.ApplicationDataContext.Instance.LoggedInUser.Id);

                    if (sys_layout_quick_access != null)
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            StreamWriter writer = new StreamWriter(stream);
                            writer.Write(sys_layout_quick_access.Custom);
                            writer.Flush();
                            stream.Position = 0;
                            RibbonControl.Toolbar.RestoreLayoutFromStream(stream);//, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                        }
                    }
                }
            }
        } 

        /// <summary>
        /// Add code for ServerModeSource binding
        /// </summary>
        protected override void BindData()
        {
            base.BindData();
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
                    GridControl.ExportToXlsx(filepath, new DevExpress.XtraPrinting.XlsxExportOptions() { RawDataMode = true });
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
                    GridControl.ExportToCsv(filepath);
                    OpenExportFile(filepath);
                }
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

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //if (SelectedRowId == -1 )//Werner : Cant get this to work|| !(GridControl.MainView as GridView).CalcHitInfo(MousePosition).InRow)
                //    return;

                //this.OnOpenRecord(SelectedRowId);

                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
                if ((info.InRow || info.InRowCell) && !(info.InGroupRow || info.InGroupColumn))
                {
                    this.OnOpenRecord(SelectedRowId);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        } 

        private void btnOpenRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SelectedRowId == -1)
                    return; 
                
                this.OnOpenRecord(SelectedRowId);
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

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.OnRefresh();
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
            //if (e.KeyCode == Keys.Enter || (e.Control && e.KeyCode == Keys.O))
            //{
            //    if (SelectedRowId == -1) 
            //        return;

            //    this.OnOpenRecord(SelectedRowId);
            //}
            //else if (e.KeyCode == Keys.F5)
            //    this.OnRefresh();
            //else if (e.Control && e.KeyCode == Keys.N)
            //    this.OnNewRecord();
        }

        private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e)
        {
            
        }
          
        private void GridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DevExpress.XtraGrid.Menu.GridViewColumnMenu menu = e.Menu as DevExpress.XtraGrid.Menu.GridViewColumnMenu;
                menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Customize", new EventHandler((menusender, menue) => { LayoutControlGrid.ShowCustomizationForm(); }), CDS.Client.Desktop.Essential.Properties.Resources.layout_16) { BeginGroup = true });
            }
        }

        
    } 
}
