using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Essential
{
    public partial class BasePivot : CDS.Client.Desktop.Essential.Base
    {
        public BasePivot()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when the Refresh button is clicked. Inheriting forms should override this method to handle the refresh.
        /// </summary>
        /// <remarks>Created: Theo Crous 16/11/2011</remarks>
        public virtual void OnRefresh()
        {
        }

        /// <summary>
        /// Show the print preview form for the PivotControl.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnPrintPreview()
        {
            try
            {
                base.OnPrintPreview();
                if (PivotControl.IsPrintingAvailable)
                    PivotControl.ShowRibbonPrintPreview();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Print the current layout and values in the PivotControl.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override void OnPrint()
        {
            try
            {
                base.OnPrint();
                PivotControl.Print();
                //DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
                //DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
                //printableComponentLink.Component = PivotControl;
                //printableComponentLink.Landscape = true;
                //printableComponentLink.PaperKind = System.Drawing.Printing.PaperKind.A4; 
                //printableComponentLink.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                //printableComponentLink.PrintingSystem.PrintDlg();
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
        /// This method is called after the form has been initialised and should be overridden in all inheriting forms to handle data binding etc.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 28/10/2015</remarks>
        protected override void OnStart()
        {
            base.OnStart();
            lcgChartControl.Expanded = false;
        }

        /// <summary>
        /// Export the current layout and values in the PivotControl to Excel file format.
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
                    PivotControl.ExportToXlsx(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the PivotControl to Pdf file format.
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
                    DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
                    DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
                    printableComponentLink.Component = PivotControl;
                    printableComponentLink.Landscape = true;
                    printableComponentLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    printableComponentLink.PrintingSystem.Document.ScaleFactor = 0.5F;
                    printableComponentLink.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                    printableComponentLink.ExportToPdf(filepath);

                    //PivotControl.ExportToPdf(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the PivotControl to Text file format.
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
                    PivotControl.ExportToText(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the PivotControl to Rtf file format.
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
                    PivotControl.ExportToRtf(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the PivotControl to Html file format.
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
                    PivotControl.ExportToHtml(filepath);
                    OpenExportFile(filepath);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Export the current layout and values in the PivotControl to Csv file format.
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
                    PivotControl.ExportToCsv(filepath);
                    OpenExportFile(filepath);
                }
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
    }
}
