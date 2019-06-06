using CDS.Client.Desktop.Essential.UTL;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using SECL = CDS.Client.BusinessLayer.SEC;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.Desktop.Main
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private MainForm()
        {
            InitializeComponent();

            nbgSales.Visible = false;
            nbgPurchases.Visible = false;
            nbgInventory.Visible = false;
            nbgFinance.Visible = false;
            nbgOrganisation.Visible = false;
            nbgHumanResources.Visible = false;
            nbgWorkshop.Visible = false;
            nbgReporting.Visible = false;
            nbgData.Visible = false;
            nbgSystem.Visible = false;
        }

        /// <summary>
        /// Exposes a method to update the TabIcons
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
            bool found = false;
            foreach (Essential.Base child in this.MdiChildren)
            {
                if (!((child as Essential.BaseForm != null) | (child as Essential.BaseListEdit2 != null)))
                    continue;

                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage page in this.MdiManager.Pages)
                {
                    if (page.MdiChild == child)
                    {
                        page.Image = (child as Essential.Base).TabIcon;
                        found = true;
                        break;
                    }
                }
                //Werner: Wish i could do something like this but the MainForm at this time doesn't know what Form to refresh
                //if (found)
                //break;
            }
        }

        /// <summary>
        /// Creates Recovery files for all MDIChildren that are set to be recovered
        /// </summary>
        /// <param name="form"></param>
        private static void CreateRecoveryAsync(MainForm form)
        {
            string directory = Environment.CurrentDirectory + @"\Recovery";

            bool shouldStart = !System.IO.Directory.EnumerateFileSystemEntries(directory).Any();

            while (shouldStart)
            {
                //Thread.Sleep(300000);
                Thread.Sleep(20000);
                if (!System.IO.Directory.Exists(directory))
                    System.IO.Directory.CreateDirectory(directory);

                foreach (var child in form.MdiChildren)
                {
                    if (child is Essential.BaseForm)
                    {
                        if ((child as Essential.BaseForm).ShouldRecover)
                        {
                            try
                            {
                                IntPtr value = new IntPtr();
                                (child as Essential.BaseForm).PerformActionOnMainForm(me => value = me.Handle);

                                //CaptureWindow(value).Save(directory + @"\" + child.GetType().ToString() + @".png", System.Drawing.Imaging.ImageFormat.Png);                            

                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(directory + @"\" + value.ToString() + "," + child.GetType().FullName.ToString()))
                                {
                                    //string json = string.Empty;
                                    string json = (child as Essential.BaseForm).GetType().Assembly.Modules.First().Name.Replace(".dll", "") + Environment.NewLine;
                                    json += (child as Essential.BaseForm).Description + Environment.NewLine;
                                    var bindingSources = (child as Essential.BaseForm).EnumerateComponents(typeof(BindingSource));
                                    foreach (BindingSource entity in bindingSources)
                                    {
                                        if (entity.DataSource != null)
                                        {
                                            json += entity.DataSource.GetType().ToString() + "|";
                                            json += Newtonsoft.Json.JsonConvert.SerializeObject(entity.DataSource);
                                            json += Environment.NewLine;
                                        }
                                    }
                                    file.WriteLine(json);
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                form.ShowMessage("Auto Recovery done", 2000);
            }
        }

        public void AddCatalogueItemToDocument(Essential.BaseForm form, long entityId)
        {
            (form as CDS.Client.Desktop.Document.BaseDocument).AddCatalogueItem(entityId);
        }

        /// <summary>
        /// Used to close the client instance remotely
        /// </summary>
        public void ForceClose()
        {
            Application.Exit();
        }

        //TODO : FIX THIS
        public void UpdateCalendar()
        {
            try
            {
                foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage p in MdiManager.Pages)
                {
                    if (p.MdiChild.GetType() == typeof(CDS.Client.Desktop.Core.Calendar.CalendarForm))
                    {
                        (p.MdiChild as CDS.Client.Desktop.Core.Calendar.CalendarForm).RefreshData();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Sets the Left Navigations Item visibility according to the users role security
        /// </summary>
        public void ApplyMenuSecurity()
        {
            try
            {
                //Ribbon Security
                bbiSite.BeginUpdate();
                bbiSite.Enabled = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSI01);
                bbiSite.EndUpdate();

                bbiPrinter.BeginUpdate();
                bbiPrinter.Enabled = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPR01);
                bbiPrinter.EndUpdate();

                // Tidy up this function unnecessary duplicate if's with the same queries

                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.SYS_DOC && n.Code == "YES"))
                {

                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SA))
                    {
                        nbgSales.Visible = true;

                        nbiCalendar.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SACA);
                        nbiNewQuote.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR);
                        nbiNewSalesOrder.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORECR);
                        nbiNewCreditNote.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSCRECR);
                        nbiQuotes.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRE);
                        nbiSalesOrders.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSORE);
                        nbiTAXInvoices.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOTIRE);
                        nbiSalesCredits.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOSCRE);
                        nbiBackOrders.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOBORE);

                        //If you have SYS_DOC and WS enable Job Quotes
                        if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.WS && n.Code == "YES"))
                        {
                            nbiJobQuotes.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRE);
                            nbiNewJobQuote.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SADOQTRECR);
                        }

#if (CHIMERA_LITE || CHIMERA_ORDERS)
                    nbiCashierScreen.Visible = false;
#endif
                    }
                    else
                    {
                        nbgSales.Visible = false;
                    }
                }
                else
                {
                    nbgSales.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgSales.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }

                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.SYS_DOC && n.Code == "YES"))
                {

                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PU))
                    {
                        nbgPurchases.Visible = true;

                        nbiCalendar.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUCA);
                        nbiPurchaseOrdersList.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOPORE);
                        nbiGoodsReceivedList.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOGRRE);
                        nbiGoodsReturnedList.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDORURE);

                        nbiNewPurchaseOrder.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOPORECR);
                        nbiNewGoodsReceived.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDOGRRECR);
                        nbiNewGoodsReturned.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.PUDORURECR);
                    }
                    else
                    {
                        nbgPurchases.Visible = false;
                    }

                }
                else
                {
                    nbgPurchases.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgPurchases.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }

                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                {

                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.IN))
                    {
                        nbgInventory.Visible = true;

                        nbiStock.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INSTRE);
                        nbiBuyout.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INBURE);
                        nbiSurcharge.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INSURE);
                        nbiStockAdjustments.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INDOADRE);
                        nbiAutomaticOrdering.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INAORE);
                        nbiStockTake.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INSKRE);
                        nbiDiscountMatrix.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INDIRE);
                        //TODO : Need security
                        nbiBomRecipes.Visible = false;//SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INDOBM);
                        nbiBomDocuments.Visible = false;//SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INDOBM01);
                        nbiManageCatalogue.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.INCA);
                    }
                    else
                    {
                        nbgInventory.Visible = false;
                    }
                }
                else
                {
                    nbgInventory.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgInventory.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }

                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ORG && n.Code == "YES"))
                {
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.OR))
                    {
                        nbgOrganisation.Visible = true;
                        nbiSuppliers.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.ORSURE);
                        nbiCustomers.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.ORCURE);
                        nbiContacts.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.ORCORE);
                        nbiEntities.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.ORENRE);
                    }
                    else
                    {
                        nbgOrganisation.Visible = false;
                    }
                }
                else
                {
                    nbgOrganisation.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgOrganisation.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }

                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES"))
                {
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FI))
                    {
                        nbgFinance.Visible = true;


                        nbiNewEntry.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIENRECR);
                        nbiBulkEntry.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIENRE06);
                        nbiBulkReceipts.Visible = false;//SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIENRE07);
                        nbiBulkPayments.Visible = false;//SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIENRE08);
                        nbiDebtorReceipts.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIENRE04);
                        nbiCreditorPayments.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIENRE05);
                        nbiEntries.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIENRE);
                        nbiAccounts.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIACRE);
                        nbiRecons.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIRERE);
                        nbiBudgets.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIBURE);
                        nbiTax.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FITARE);
                        //TODO: Implement Cashier Screen
                        //Removed for time being
                        //nbiCashierScreen.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIEN12);
                        nbiTrialBalance.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIRP);
                        nbiIncomeStatement.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIRP);
                        nbiBalanceSheet.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.FIRP);

                    }
                    else
                    {
                        nbgFinance.Visible = false;
                    }
                }
                else
                {
                    nbgFinance.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgFinance.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }
                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.HR && n.Code == "YES"))
                {

                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.HR))
                    {
                        nbgHumanResources.Visible = true;

                        nbiRoles.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.HRRLRE);
                        nbiEmployees.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.HREMRE);
                    }
                    else
                    {
                        nbgHumanResources.Visible = false;
                    }

                }
                else
                {
                    nbgHumanResources.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgHumanResources.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }

                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.WS && n.Code == "YES"))
                {
                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WS))
                    {
                        nbgWorkshop.Visible = true;

                        nbiCalendar.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WSCA);
                        nbiNewJob.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WSDOJCRECR);
                        nbiJobs.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.WSDOJCRE);
                    }
                    else
                    {
                        nbgWorkshop.Visible = false;
                    }
                }
                else
                {
                    nbgWorkshop.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgWorkshop.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }
                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.RPT && n.Code == "YES"))
                {

                    if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.RE))
                    {
                        nbgReporting.Visible = true;

                        nbiReport.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.RERPRE);

                        //CHECK THE REPORTS ACCESS DOESNT MAKE SENCE
                        //nbiReport.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.RERP01);
                        nbiAnalytics.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.REANRE);
                    }
                    else
                    {
                        nbgReporting.Visible = false;
                    }

                }
                else
                {
                    nbgOrganisation.Visible = true;

                    foreach (DevExpress.XtraNavBar.NavBarItemLink item in nbgReporting.ItemLinks)
                    {
                        item.Item.Enabled = false;
                    }
                }

                if (SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SY))
                {
                    nbgSystem.Visible = true;

                    nbiManualBackup.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYBA);
                    nbiPeriods.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYPERE);
                    nbiCenters.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYCERE);
                    nbiUserRoles.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYSERLRE);
                    nbiUsers.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYSEURRE);
                    nbiPrinters.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYPRRE);
                    nbiSites.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYSIRE);
                    nbiSystemUpdate.Visible = SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYGE03);
                    nbiScheduledTasks.Visible = false;// SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYSTRE);
                    nbiModules.Visible = false;// SECL.SecurityLibrary.AccessGranted(SECL.AccessCodes.SYMORE);
                    nbiDashboard.Visible = false;
                }
                else
                {
                    nbgSystem.Visible = false;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Populates the Validation Restrictions for the controls on the forms
        /// </summary>
        private void PopulateValidationRestrictions()
        {
            BL.ApplicationDataContext.Instance.PopulateValidationRestrictions();
        }

        /// <summary>
        /// Populates the Module Access
        /// </summary>
        private void PopulateModuleAccess()
        {
            BL.ApplicationDataContext.Instance.PopulateModuleAccess();
        }

        /// <summary>
        /// Populates the list of abbreviations
        /// </summary>
        private void PopulateAbbreviations()
        {
            BL.ApplicationDataContext.Instance.PopulateAbbreviations();
        }

        public void SetWaitFormDescription(string description)
        {
            if (SplashManager.IsSplashFormVisible && description != string.Empty && description != null)
                SplashManager.SetWaitFormDescription(description);
        }

        public void SelectRibbonPage(string page)
        {
            DevExpress.XtraBars.Ribbon.RibbonControl mainRibbon = ((DevExpress.XtraBars.Ribbon.RibbonForm)this).Ribbon;// CDS.Client.Desktop.STD.MainForm.Instance.Ribbon;

            DevExpress.XtraBars.Ribbon.RibbonPage selectedGroup = mainRibbon.MergedPages[page];

            if (selectedGroup == null)
                return;

            mainRibbon.SelectedPage = selectedGroup;
        }

        public void ShowWaitForm()
        {
            try
            {
                if (!SplashManager.IsSplashFormVisible)
                    SplashManager.ShowWaitForm();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void CloseWaitForm()
        {
            try
            {
                if (SplashManager.IsSplashFormVisible)
                    SplashManager.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void LoadRecentDocuments()
        {
            try
            {
                string filename = Application.StartupPath + "\\" + "mru_documents.inf";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.StreamReader sr = System.IO.File.OpenText(filename);
                    for (string s = sr.ReadLine(); s != null; s = sr.ReadLine())
                    {
                        string[] values = s.Split(new char[] { '|' });

                        if (values[0] == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId.ToString())
                        {
                            if (values[1] == "P")
                            {
                                RecentDocumentsPinned.Add(new RecentDocument() { Id = new Guid(values[2]), Text = values[3], Description = values[4], Type = values[5] });
                            }
                            else if (values[1] == "C")
                            {
                                RecentDocumentsCurrent.Add(new RecentDocument() { Id = new Guid(values[2]), Text = values[3], Description = values[4], Type = values[5] });
                            }
                        }
                    }
                    sr.Close();
                }

                RefreshRecentDocuments();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void SaveRecentDocuments()
        {
            try
            {
                string filename = Application.StartupPath + "\\" + "mru_documents.inf";

                List<string> otherusersdocs = new List<string>();
                if (System.IO.File.Exists(filename))
                {
                    System.IO.StreamReader sr = System.IO.File.OpenText(filename);
                    for (string s = sr.ReadLine(); s != null; s = sr.ReadLine())
                    {
                        if (!s.StartsWith(BL.ApplicationDataContext.Instance.LoggedInUser.PersonId.ToString()))
                        {
                            otherusersdocs.Add(s);
                        }
                    }
                    sr.Close();
                }
                System.IO.StreamWriter sw = System.IO.File.CreateText(filename);
                foreach (string s in otherusersdocs)
                {
                    sw.WriteLine(s);
                }
                foreach (RecentDocument doc in RecentDocumentsPinned)
                {
                    sw.WriteLine(string.Format("{0}|P|{1}|{2}|{3}|{4}", BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, doc.Id, doc.Text, doc.Description, doc.Type));


                }
                foreach (RecentDocument doc in RecentDocumentsCurrent)
                {
                    sw.WriteLine(string.Format("{0}|C|{1}|{2}|{3}|{4}", BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, doc.Id, doc.Text, doc.Description, doc.Type));


                }
                sw.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void AddRecentDocument(Guid Id, string Text, string Description, string Type)
        {
            try
            {
                if (RecentDocumentsCurrent.Count(n => n.Id == Id) == 0 && RecentDocumentsPinned.Count(n => n.Id == Id) == 0)
                    RecentDocumentsCurrent.Add(new RecentDocument()
                    {
                        Id = Id,
                        Text = Text,
                        Description = Description,
                        Checked = false,
                        Type = Type
                    });

                while (RecentDocumentsCurrent.Count > 10)
                    RecentDocumentsCurrent.RemoveAt(0);

                RefreshRecentDocuments();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RefreshRecentDocuments()
        {
            try
            {
                pnlRecentDocuments.BeginInit();
                pnlRecentDocuments.Controls.Clear();

                foreach (RecentDocument doc in RecentDocumentsCurrent)
                {
                    DevExpress.XtraBars.Ribbon.AppMenuFileLabel item = new DevExpress.XtraBars.Ribbon.AppMenuFileLabel();
                    item.AppearanceDescription.ForeColor = Color.Gray; //TODO: Change to reflect selected DevExpress LookAndFeel
                    item.Text = doc.Text;
                    item.Description = doc.Description;
                    item.Tag = doc.Id;
                    item.Checked = doc.Checked;
                    item.AutoHeight = true;
                    item.Dock = DockStyle.Top;
                    item.Image = imageCollection3.Images[1];
                    item.SelectedImage = imageCollection3.Images[0];
                    item.Glyph = global::CDS.Shared.Resources.Properties.Resources.document_invoice_32;
                    item.LabelClick += new EventHandler(item_LabelClick);
                    item.LabelImageClick += new CancelEventHandler(itemCurrent_LabelImageClick);
                    pnlRecentDocuments.Controls.Add(item);
                }

                if (RecentDocumentsPinned.Count > 0 && RecentDocumentsCurrent.Count > 0)
                {
                    DevExpress.XtraEditors.LabelControl splitter = new DevExpress.XtraEditors.LabelControl();
                    splitter.LineVisible = true;
                    splitter.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
                    splitter.Width = pnlRecentDocuments.Width;
                    splitter.Dock = DockStyle.Top;
                    splitter.Text = "";
                    splitter.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                    pnlRecentDocuments.Controls.Add(splitter);
                }

                foreach (RecentDocument doc in RecentDocumentsPinned)
                {
                    DevExpress.XtraBars.Ribbon.AppMenuFileLabel item = new DevExpress.XtraBars.Ribbon.AppMenuFileLabel();
                    item.AppearanceDescription.ForeColor = Color.Gray; //TODO: Change to reflect selected DevExpress LookAndFeel
                    item.Text = doc.Text;
                    item.Description = doc.Description;
                    item.Tag = doc.Id;
                    item.Checked = doc.Checked;
                    item.AutoHeight = true;
                    item.Dock = DockStyle.Top;
                    item.Image = imageCollection3.Images[0];
                    item.SelectedImage = imageCollection3.Images[1];
                    item.Glyph = global::CDS.Shared.Resources.Properties.Resources.document_invoice_32;
                    item.LabelClick += new EventHandler(item_LabelClick);
                    item.LabelImageClick += new CancelEventHandler(itemPinned_LabelImageClick);
                    pnlRecentDocuments.Controls.Add(item);
                }

                pnlRecentDocuments.EndInit();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public event RibbonMouseEventHandler RibbonMouseUp;

        public event RibbonMouseEventHandler RibbonMouseDown;

        public event RibbonMouseEventHandler RibbonMouseMove;

        private void item_LabelClick(object sender, EventArgs e)
        {

        }

        private void itemCurrent_LabelImageClick(object sender, CancelEventArgs e)
        {
            try
            {
                DevExpress.XtraBars.Ribbon.AppMenuFileLabel item = sender as DevExpress.XtraBars.Ribbon.AppMenuFileLabel;
                if (item.Tag != null)
                {
                    RecentDocument move = RecentDocumentsCurrent.FirstOrDefault(n => n.Id == (Guid)item.Tag);
                    item.LabelImageClick += new CancelEventHandler(itemPinned_LabelImageClick);
                    RecentDocumentsCurrent.Remove(move);
                    RecentDocumentsPinned.Add(move);
                    RefreshRecentDocuments();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void itemPinned_LabelImageClick(object sender, CancelEventArgs e)
        {
            try
            {
                DevExpress.XtraBars.Ribbon.AppMenuFileLabel item = sender as DevExpress.XtraBars.Ribbon.AppMenuFileLabel;
                if (item.Tag != null)
                {
                    RecentDocument move = RecentDocumentsPinned.FirstOrDefault(n => n.Id == (Guid)item.Tag);
                    item.LabelImageClick += new CancelEventHandler(itemCurrent_LabelImageClick);
                    RecentDocumentsPinned.Remove(move);
                    RecentDocumentsCurrent.Add(move);
                    RefreshRecentDocuments();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveRecentDocuments();
                if (tokenSource != null)
                    tokenSource.Cancel();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool noDefaultSite = false;
            if (BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId == null)
            {
                noDefaultSite = true;
                
            }

            try
            {
                



                ServerModeSourcePerson.QueryableSource = DataContext.EntitySystemContext.SYS_Person;
                MdiManager.BeginUpdate();
                //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    //Task.Factory.StartNew(() =>
                    {
                        try
                        {
#if RELEAS
                            UpdateUpdateURL();
                            UpdateStartTime();
                            UpdateClientZipLocation();
#endif

                            if (!noDefaultSite) { 
                            if (BL.ApplicationDataContext.Instance.CompanySite.PrintServerLocation == null ||
                                BL.ApplicationDataContext.Instance.CompanySite.PrintServerLocation == string.Empty)
                            {
                                Essential.BaseAlert.ShowAlert("Required Service", "The printing service location is empty", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                            }
                            //Need to find a way to run this Asynchronous from the system without causing a sql connection issue
                            else if (!BL.ApplicationDataContext.Instance.Service.DistributedTransactionServiceRunning())
                            {
                                Essential.BaseAlert.ShowAlert("Required Service", "The following service is not started on the server please contact support.\nMSDTC", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                            }
                            }
                        }
                        catch (System.ServiceModel.CommunicationException ex)
                        {
                            //this.BeginInvoke(new Action(() =>
                            //{
                            Essential.BaseAlert.ShowAlert("Connection Issues", "CDS Could not locate printing server please correct and log back in before saving any documents.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error, this);
                            // }));
                        }
                        catch (Exception ex)
                        {
                            if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex))
                            {
                                this.Close();
                                throw ex;
                            }
                            //if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex))
                            //{
                            //    this.BeginInvoke(new Action(() => { this.Close(); }));
                            //    throw ex;
                            //}
                        }

                        // Set up display info
                        bsiUser.Caption = BL.ApplicationDataContext.Instance.LoggedInUser.DisplayName;
                        bsiVersion.Caption = Application.ProductVersion.ToString();
                        if (!noDefaultSite)
                        {
                            bsiSite.Caption = BL.ApplicationDataContext.Instance.CompanySite.ShortName;
                            this.BeginInvoke(new Action(() =>
                            this.Text = BL.ApplicationDataContext.Instance.CompanySite.Name + " - Complete Distribution"
                                ));
                            bbiSite.Caption = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSite.SYS_Entity.ShortName;
                        }
                        else
                        {
                            bsiSite.Caption = "No Default Site";
                            this.BeginInvoke(new Action(() =>
                            this.Text = "No Default Site! - Complete Distribution"
                                ));
                            bbiSite.Caption = "No Default Site";
                        }
                        txtUsername.EditValue = BL.ApplicationDataContext.Instance.LoggedInUser.Username;
                        txtDisplayName.EditValue = BL.ApplicationDataContext.Instance.LoggedInUser.DisplayName;
                       
                        
                    }//);


                    //This cannot run in its own thread needs to run here
                    //because of the code below
                    PopulateModuleAccess();
                    ApplyMenuSecurity();

                    //Task.Factory.StartNew(
                    //     () =>
                    {
                        PopulateValidationRestrictions();
                    }//);
                    // Task.Factory.StartNew(
                    //     () =>
                    {
                        //Werner: Removed as per Task 375
                        //PopulateAbbreviations();
                    }//);

                    if (BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinter != null)
                        bbiPrinter.Caption = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinter.Name;

                    gddPrinter.BeginUpdate();
                    DataContext.EntitySystemContext.SYS_Printer.Where(n => n.Archived == false).Select(n => new { n.Id, n.Name, n.Location }).ForEachAsync(printer =>
                    {
                        GalleryItem item = new GalleryItem();
                        item.Caption = printer.Name;
                        item.Description = printer.Location;
                        item.Image = global::CDS.Shared.Resources.Properties.Resources.printer_16;

                        item.Tag = printer.Id;

                        gddPrinter.Gallery.Groups[0].Items.Add(item);
                    }).Wait();
                    //foreach (var printer in DataContext.EntitySystemContext.SYS_Printer.Where(n => n.Archived == false).Select(n => new { n.Id, n.Name, n.Location }))
                    //{
                    //    GalleryItem item = new GalleryItem();
                    //    item.Caption = printer.Name;
                    //    item.Description = printer.Location;
                    //    item.Image = global::CDS.Shared.Resources.Properties.Resources.printer_16;

                    //    item.Tag = printer.Id;

                    //    gddPrinter.Gallery.Groups[0].Items.Add(item);
                    //}
                    gddPrinter.EndUpdate();

                    //List<DB.VW_Site> sites = (List<DB.VW_Site>)DataContext.ReadonlyContext.VW_Site.Where(n => !n.Archived.Equals(true)).ToList();
                    //bbiWarehouse.Caption = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSite.SYS_Entity.ShortName;

                    gddSite.BeginUpdate();
                    DataContext.ReadonlyContext.VW_Site.Where(n => !n.Archived.Equals(true)).Select(l => new { l.Id, l.Name, l.ShortName }).ForEachAsync(site =>
                    {
                        GalleryItem item = new GalleryItem();
                        item.Caption = site.ShortName;
                        item.Description = site.Name;
                        item.Image = global::CDS.Shared.Resources.Properties.Resources.factory_16;
                        item.Tag = site.Id;
                        gddSite.Gallery.Groups[0].Items.Add(item);
                    }).Wait();
                    //foreach (var site in DataContext.ReadonlyContext.VW_Site.Where(n => !n.Archived.Equals(true)).Select(l => new { l.Id, l.Name, l.ShortName }))
                    //{
                    //    GalleryItem item = new GalleryItem();
                    //    item.Caption = site.ShortName;
                    //    item.Description = site.Name;
                    //    item.Image = global::CDS.Shared.Resources.Properties.Resources.factory_16;
                    //    item.Tag = site.Id;
                    //    gddWarehouse.Gallery.Groups[0].Items.Add(item);
                    //}
                    gddSite.EndUpdate();

                    // Set up Backstage View
                    lblProduct.Text = AssemblyProduct;
                    lblVersion.Text = Application.ProductVersion.ToString();
                    lblCopyright.Text = AssemblyCopyright;

                    Task.Factory.StartNew(
                        () =>
                        {
                            LoadRecentDocuments();
                        });

                    if (!(BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYGE03)))
                    {
                        Program.Notifyicon.Visible = false;
                    }
                    if (!noDefaultSite) { 
                    if (BL.ApplicationDataContext.Instance.CompanySite.MinimizeNavigation)
                    {
                        NavBar.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
                        ribbon.Minimized = true;
                    }
                    }

                    if (CustomApplicationSettings.Instance.FontSize == 8.25f) { tbFontSize.Value = 0; }
                    else if (CustomApplicationSettings.Instance.FontSize == 10f) { tbFontSize.Value = 1; }
                    else if (CustomApplicationSettings.Instance.FontSize == 12f) { tbFontSize.Value = 2; }
                    else if (CustomApplicationSettings.Instance.FontSize == 14f) { tbFontSize.Value = 3; }

                    //Start Message Listener
                    tokenSource = new CancellationTokenSource();
                    token = tokenSource.Token;
                    tasks = new ConcurrentBag<Task>();

                    string[] data = BL.ApplicationDataContext.Instance.LoggedInUser.LastLocation.Split(';');

                    var port = data[4].Split(':')[1].TrimStart().TrimEnd();
                    /*Task*/
                    chatlistener = Task.Factory.StartNew(() => Essential.MSG.Messenger.CreateListener(1, port, token), token);
                    tasks.Add(chatlistener);

                    //Load Users for Messenger
                    //foreach (DB.SEC_User user in DataContext.EntitySecurityContext.SEC_User.Where(n => n.LastLocation != null && n.PersonId != BL.ApplicationDataContext.Instance.LoggedInUser.PersonId))

                    DataContext.EntitySecurityContext.SEC_User.Where(n => n.LastLocation != null && n.PersonId != BL.ApplicationDataContext.Instance.LoggedInUser.PersonId).ForEachAsync(user =>
                    {
                        Essential.MSG.MessengerUsers messengerUser = new Essential.MSG.MessengerUsers() { Id = user.PersonId, DisplayName = user.DisplayName, IP = user.LastLocation.Split(';')[0].Split(':')[1].TrimStart().TrimEnd(), Port = Convert.ToInt32(user.LastLocation.Split(';')[4].Split(':')[1].TrimStart().TrimEnd()) };

#if (!Debug)
                        Parallel.Invoke(new Action(() =>
                        {
                            if (Essential.MSG.Messenger.TestConnection(messengerUser.IP, Convert.ToInt32(messengerUser.Port)).Equals("Received Connection"))
                            {
                                messengerUser.Image = global::CDS.Client.Desktop.Properties.Resources.check_16;
                            }
                            else
                            {
                                messengerUser.Image = global::CDS.Client.Desktop.Properties.Resources.delete_16;
                            }
                            messengerUsers.Add(messengerUser);
                        }));
#endif
                    });

                    BindingSourceMessengerUsers.DataSource = messengerUsers;

                    grvMessengerUsers.FocusedRowHandle = 0;

                    //grdMessage.DataSource = messageList;
                    this.Visible = true;

                    NavBar.ActiveGroup = nbgSales;
                }


                if (BL.SYS.SYS_Period.GetCurrentPeriod(DataContext) == null)
                {

                    Essential.BaseAlert.ShowAlert("No Periods", "Current period not found please generate periods", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    nbgSales.Visible = false;
                    nbgPurchases.Visible = false;
                    nbgInventory.Visible = false;
                    nbgFinance.Visible = false;
                    nbgHumanResources.Visible = false;
                    nbgOrganisation.Visible = false;
                    nbgWorkshop.Visible = false;
                    nbgReporting.Visible = false;
                    nbgData.Visible = false;
                }

                if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.GLX && n.Code == "YES") && !IsSiteAccountsSetup())
                {
                    nbgSales.Visible = false;
                    nbgPurchases.Visible = false;
                    nbgInventory.Visible = false;
                    nbgOrganisation.Visible = false;
                    nbgWorkshop.Visible = false;
                    nbgReporting.Visible = false;
                    nbgData.Visible = false;
                }
                if (!noDefaultSite) { 
                if (BL.ApplicationDataContext.Instance.CompanySite.PrintServerLocation == null ||
                                 BL.ApplicationDataContext.Instance.CompanySite.PrintServerLocation == string.Empty)
                {
                    nbgSales.Visible = false;
                    nbgPurchases.Visible = false;
                }
                }
                //Disables everything except for System if the user has no default site
                //Sean Hill
                if (noDefaultSite)
                {
                    Essential.BaseAlert.ShowAlert("Required Default Site", "There is no default site selected for your current user, please do this before you can continue", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);

                    nbgSales.Visible = false;
                    nbgPurchases.Visible = false;
                    nbgInventory.Visible = false;
                    nbgFinance.Visible = false;
                    nbgHumanResources.Visible = false;
                    nbgOrganisation.Visible = false;
                    nbgWorkshop.Visible = false;
                    nbgReporting.Visible = false;
                    nbgData.Visible = false;
                    nbiManualBackup.Visible = false;
                }

                //else
                //{
                Task.Factory.StartNew(
                () =>
                {
                    // using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            ShowForm(new CDS.Client.Desktop.Core.Dashboard.DashboardSalesForm());
                        }));
                    }
                });
                //}

                if (!System.IO.Directory.Exists(Environment.CurrentDirectory + @"\Recovery"))
                    System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + @"\Recovery");

                if (System.IO.Directory.EnumerateFileSystemEntries(Environment.CurrentDirectory + @"\Recovery").Any())
                    (new RecoveryDialogue()).ShowDialog();

                RecoveryBackgroundWorker.RunWorkerAsync(this);


                BackgroundWorkerSystemNotifications.RunWorkerAsync();

                //  DummyData.GenerateData();                
                MdiManager.EndUpdate();
                this.Opacity = 1.00;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Opacity = 1;
        }

        public delegate void RibbonMouseEventHandler(object sender, MouseEventArgs e, DevExpress.XtraBars.Ribbon.ViewInfo.RibbonHitInfo hit);

        /// <summary>
        /// Places focus on closing form in order to bring it to the front of the MDI Container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender is Essential.BaseForm)
                (sender as Essential.BaseForm).Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.MdiChildren.Count() == 2)
            //    bbiSite.Enabled = true;
        }

        private void NavBar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                //Werner: All forms should be opened using ShowForm don't pull or populate and date before using ShowForm
                //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    switch (e.Link.ItemName)
                    {
                        case "nbiCatalogue":
                            //ShowForm(new CDS.Client.Desktop.Catalogue.CAT.CatalogueList());
                            break;
                        case "nbiNewQuote":
                            ShowForm(new CDS.Client.Desktop.Document.Customer.QuoteForm());
                            break;
                        case "nbiNewJobQuote":
                            ShowForm(new CDS.Client.Desktop.Document.Customer.JobQuoteForm());
                            break;
                        case "nbiNewSalesOrder":
                            ShowForm(new CDS.Client.Desktop.Document.Customer.SalesOrderForm());
                            break;
                        case "nbiNewCreditNote":
                            ShowForm(new CDS.Client.Desktop.Document.Customer.CreditNoteForm());
                            break;
                        case "nbiStockAdjustments":
                            ShowForm(new CDS.Client.Desktop.Stock.Document.BaseStockDocumentList(BL.SYS.SYS_DOC_Type.InventoryAdjustment));
                            break;
                        case "nbiQuotes":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.Quote));
                            break;
                        case "nbiJobQuotes":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.JobQuote));
                            break;
                        case "nbiSalesOrders":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.SalesOrder));
                            break;
                        case "nbiBackOrders":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.BackOrder));
                            break;
                        case "nbiTAXInvoices":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.TAXInvoice));
                            break;
                        case "nbiSalesCredits":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.CreditNote));
                            break;
                        case "nbiMessages":
                            ShowForm(new CDS.Client.Desktop.Core.Message.MessageList());
                            break;
                        case "nbiCustomers":
                            ShowForm(new CDS.Client.Desktop.Company.CompanyList(BL.ORG.ORG_Type.Customer));
                            break;
                        case "nbiBulkReceipts":
                            ShowForm(new CDS.Client.Desktop.Accounting.Payment.Bulk.BulkReceiptsForm());
                            break;
                        case "nbiBulkPayments":
                            ShowForm(new CDS.Client.Desktop.Accounting.Payment.Bulk.BulkPaymentsForm());
                            break;
                        case "nbiCashierScreen":
                            //ShowForm(new CDS.Client.Desktop.Accounting.CashierForm());
                            break;
                        case "nbiVisitations":
                            //ShowForm(new CDS.Client.Desktop.Calendar.CalendarForm());
                            break;
                        case "nbiNewPurchaseOrder":
                            ShowForm(new CDS.Client.Desktop.Document.Supplier.PurchaseOrderForm());
                            break;
                        case "nbiNewGoodsReceived":
                            ShowForm(new CDS.Client.Desktop.Document.Supplier.GoodsReceivedForm());
                            break;
                        case "nbiNewGoodsReturned":
                            ShowForm(new CDS.Client.Desktop.Document.Supplier.GoodsReturnedForm());
                            break;
                        case "nbiPurchaseOrdersList":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.PurchaseOrder));
                            break;
                        case "nbiGoodsReceivedList":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.GoodsReceived));
                            break;
                        case "nbiGoodsReturnedList":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.GoodsReturned));
                            break;
                        case "nbiSuppliers":
                            ShowForm(new CDS.Client.Desktop.Company.CompanyList(BL.ORG.ORG_Type.Supplier));
                            break;
                        case "nbiDebtorReceipts":
                            ShowForm(new CDS.Client.Desktop.Accounting.Payment.ReceivePaymentsForm(-1));
                            break;
                        case "nbiCreditorPayments":
                            ShowForm(new CDS.Client.Desktop.Accounting.Payment.MakePaymentsForm(-1));
                            break;
                        case "nbiTransfers":
                            ShowForm(new CDS.Client.Desktop.Document.BaseDocumentList(BL.SYS.SYS_DOC_Type.TransferShipment));
                            break;
                        case "nbiStock":
                            ShowForm(new CDS.Client.Desktop.Stock.Inventory.InventoryList());
                            break;
                        case "nbiBuyout":
                            ShowForm(new CDS.Client.Desktop.Stock.Buyout.BuyoutList());
                            break;
                        case "nbiSurcharge":
                            ShowForm(new CDS.Client.Desktop.Core.Surcharge.SurchargeList());
                            break;
                        case "nbiLostSale":
                            ShowForm(new CDS.Client.Desktop.Document.LostSale.LostSaleList());
                            break;
                        case "nbiAutomaticOrdering":
                            ShowForm(new CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingList());
                            break;
                        case "nbiStockTake":
                            ShowForm(new CDS.Client.Desktop.Stock.Inventory.StockTakeList());
                            break;
                        case "nbiDiscountMatrix":
                            ShowForm(new CDS.Client.Desktop.Stock.Inventory.DiscountList());
                            break;
                        case "nbiBomRecipes":
                            ShowForm(new CDS.Client.Desktop.Stock.BOM.BOMRecipeList());
                            break;
                        case "nbiBomDocuments":
                            ShowForm(new CDS.Client.Desktop.Stock.BOM.BOMDocumentList());
                            break;
                        /* case "nbiChangePrimarySupplier":
                             //ShowForm(new CompleteDistribution.Inventory.UpdatePrimarySupplier());
                             break;

                         case "nbiChangeStockCode":
                             //ShowForm(new CompleteDistribution.StockCodeHistorySelectForm());
                             break;

                         case "nbiChangeWarehouseCost":
                             //ShowForm(new CompleteDistribution.Inventory.UpdateWarehousingCost());
                             break;

                         case "nbiChangeSafetyStock":
                             //ShowForm(new CompleteDistribution.Inventory.UpdateSafetyStock());
                             break;
                         case "nbiChangeAverageCost":
                             //ShowForm(new CompleteDistribution.StockAdjustment.ChangeCostForm());
                             break;                            */
                        case "nbiManageCatalogue":
                            ShowForm(new CDS.Client.Desktop.Catalogue.CAT.CatalogueList());
                            break;
                        /*
                    case "nbiStockUpdate":
                        //DIE MOET NIE EINTLIK GEBRUIK WORD NIE MOET QUICK/IMPORT EXPORT GEBRUIK
                        //ShowForm(new CompleteDistribution.Inventory.InventoryPriceUpdates());
                        break;

                    case "nbiImportStockUpdate":
                        //DIE MOET NIE EINTLIK GEBRUIK WORD NIE MOET QUICK/IMPORT EXPORT GEBRUIK
                        //ShowForm(new CompleteDistribution.Inventory.InventoryUpdateImport());
                        break;

                    case "nbiUpdateLeadTimes":
                        //ShowForm(new CompleteDistribution.Inventory.UpdateLeadTimeForm());
                        break;*/
                        case "nbiNewEntry":
                            ShowForm(new CDS.Client.Desktop.Accounting.Entry.EntryForm());
                            break;
                        case "nbiBulkEntry":
                            ShowForm(new CDS.Client.Desktop.Accounting.Entry.BulkEntryForm());
                            break;
                        case "nbiAccounts":
                            ShowForm(new CDS.Client.Desktop.Accounting.AccountList());
                            break;
                        case "nbiEntries":
                            ShowForm(new CDS.Client.Desktop.Accounting.Entry.EntryList());
                            break;
                        case "nbiPeriods":
                            ShowForm(new CDS.Client.Desktop.Core.Period.PeriodList());
                            break;
                        case "nbiCenters":
                            ShowForm(new CDS.Client.Desktop.Core.Center.CenterList());
                            break;
                        case "nbiRecons":
                            ShowForm(new CDS.Client.Desktop.Accounting.ReconList());
                            break;
                        case "nbiBudgets":
                            ShowForm(new CDS.Client.Desktop.Accounting.Budget.BudgetForm());
                            break;
                        case "nbiSoACustomers":
                            ShowForm(new CDS.Client.Desktop.Accounting.Statement.StatementsList(true));
                            break;
                        case "nbiSoASuppliers":
                            ShowForm(new CDS.Client.Desktop.Accounting.Statement.StatementsList(false));
                            break;
                        case "nbiTrialBalance":
                            ShowForm(new CDS.Client.Desktop.Accounting.BalanceForm(Accounting.BalanceForm.BalanceType.TrialBalance));
                            break;
                        case "nbiIncomeStatement":
                            ShowForm(new CDS.Client.Desktop.Accounting.BalanceForm(Accounting.BalanceForm.BalanceType.IncomeStatement));
                            break;
                        case "nbiBalanceSheet":
                            ShowForm(new CDS.Client.Desktop.Accounting.BalanceForm(Accounting.BalanceForm.BalanceType.BalanceSheet));
                            break;
                        case "nbiCalendar":
                            ShowForm(new CDS.Client.Desktop.Core.Calendar.CalendarForm());
                            break;
                        case "nbiJobQuote":
                            CDS.Client.Desktop.Document.Customer.QuoteForm childFormJobQuote =
                            new CDS.Client.Desktop.Document.Customer.QuoteForm();
                            childFormJobQuote.UseWarehouseDiscount = true;
                            ShowForm(childFormJobQuote);
                            break;
                        case "nbiNewJob":
                            ShowForm(new CDS.Client.Desktop.Workshop.Job.JobForm());
                            break;
                        case "nbiJobs":
                            ShowForm(new CDS.Client.Desktop.Workshop.Job.JobList());
                            break;
                        case "nbiSites":
                            //MessageBox.Show("At nbiSites");
                            ShowForm(new Core.Site.SiteList());
                            break;
                        case "nbiModules":
                            ShowForm(new Main.ModuleList());
                            break;
                        case "nbiScheduledTasks":
                            ShowForm(new Essential.SYS.ScheduledTaskList());
                            break;
                        case "nbiUsers":
                            ShowForm(new CDS.Client.Desktop.Core.Security.UserList());
                            break;
                        case "nbiUserRoles":
                            ShowForm(new CDS.Client.Desktop.Core.Security.RoleList());
                            break;
                        case "nbiPrinters":
                            ShowForm(new CDS.Client.Desktop.Core.Printer.PrinterList());
                            break;
                        case "nbiWarehouses":
                            //ShowForm(new CDS.Client.Desktop.Company.CompanyList(BL.ORG.ORG_Type.Warehouse));
                            break;
                        /*
                    case "nbiImportB11Pricelist":
                        //ShowForm(new CompleteDistribution.General.ImportPriceListForm());
                        break;
                        */
                        case "nbiManualBackup":
                            //ShowForm(new CDS.Client.Desktop.Main.BackupForm());
                            CDS.Client.Desktop.Core.Backup.BackupDialogue childForm = new CDS.Client.Desktop.Core.Backup.BackupDialogue();
                            childForm.Show();
                            break;
                        /*
                    case "nbiPortInventory":
                        //ShowForm(new CompleteDistribution.Export.ImportExportStock());
                        break;

                    case "nbiPortDiscountMatrix":
                        //ShowForm(new CompleteDistribution.Export.ImportExportDiscount());
                        break;

                    case "nbiPortReplacementParts":
                        //ShowForm(new CompleteDistribution.Export.ImportExportReplacements());
                        break;

                    case "nbiPortPartData":
                        //ShowForm(new CompleteDistribution.Export.ImportExportCatalogue());
                        break;

                    case "nbiPortPartCatalogue":
                        //ShowForm(new CompleteDistribution.Export.ImportExportMeta());
                        break;
                        */
                        case "nbiAbbreviations":
                            ShowForm(new CDS.Client.Desktop.Core.Abbreviation.AbbreviationList());
                            break;
                        case "nbiTax":
                            ShowForm(new CDS.Client.Desktop.Accounting.TaxList());
                            break;
                        case "nbiReport":
                            ShowForm(new CDS.Client.Desktop.Reporting.Report.ReportList());
                            break;
                        case "nbiAnalytics":
                            ShowForm(new CDS.Client.Desktop.Reporting.Analytic.AnalyticList());
                            break;
                        case "nbiRoles":
                            ShowForm(new CDS.Client.Desktop.HumanResources.Role.RoleList());
                            break;
                        case "nbiEmployees":
                            ShowForm(new CDS.Client.Desktop.HumanResources.Employee.EmployeeList());
                            break;
                        case "nbiDashboard":
                            ShowForm(new CDS.Client.Desktop.Core.Dashboard.DashboardSalesForm());
                            break;
                        case "nbiEntities":
                            ShowForm(new CDS.Client.Desktop.Company.Entity.EntityList());
                            break;
                        case "nbiContacts":
                            ShowForm(new CDS.Client.Desktop.Company.Contact.ContactList());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void MdiManager_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            try
            {
                ITabbedForm form = e.Page.MdiChild as ITabbedForm;
                if (form != null)
                {
                    e.Page.Image = form.TabIcon;
                }
                FocusedForm = e.Page.MdiChild;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void MdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            try
            {
                if (MdiManager.Pages.Count > 0)
                    MdiManager.SelectedPage = MdiManager.Pages[MdiManager.Pages.Count - 1];
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void MdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage == null)
                    return;

                //TODO: FIX HIERDIE GROSE CODE
                if (((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild != MainForm.Instance.MdiChildren[0])
                    FocusedForm = ((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild;

                //If the Current Form is the Automatic Ordering Form
                if (((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild is CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingForm)
                {
                    (((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild as CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingForm).RefreshList();

                    //If the Automatic Ordering Form has an Active Child
                    if ((((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild as CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingForm).DetailForm != null &&
                        !(((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild as CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingForm).DetailForm.IsDisposed)
                    {

                        //Find the Automatic Ordering Detail Form 
                        foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage page in ((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).Pages)
                        {
                            if ((((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild as CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingForm) != null && page.MdiChild == (((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage.MdiChild as CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingForm).DetailForm)
                            //is CDS.Client.Desktop.Ordering.AOR.AutomaticOrderingDetailForm)
                            {
                                ((DevExpress.XtraTabbedMdi.XtraTabbedMdiManager)(sender)).SelectedPage = page;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void gddPrinter_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId = (long)e.Item.Tag;
                    BL.ApplicationDataContext.Instance.CompanySite.Reload();
                    using (TransactionScope transaction = BL.ApplicationDataContext.Instance.DataContext.GetTransactionScope())
                    {
                        BL.ApplicationDataContext.Instance.DataContext.SaveChangesEntitySecurityContext();
                        BL.ApplicationDataContext.Instance.DataContext.CompleteTransaction(transaction);
                    }

                    bbiPrinter.Caption = e.Item.Caption;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void galleryControl1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            try
            {
                Process process = new Process();

                process.StartInfo.Verb = "open";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                switch (Convert.ToString(e.Item.Tag))
                {
                    case "online":
                        process.StartInfo.FileName = "http://www.cdsonline.co.za/help";
                        break;
                    case "start":
                        process.StartInfo.FileName = "http://www.cdsonline.co.za/start";
                        break;
                    case "contact":
                        process.StartInfo.FileName = "mailto:supportdesk@cdsonline.co.za";
                        break;
                    case "ticket":
                        //process.StartInfo.FileName = "http://completedistribution.freshdesk.com/";
                        ShowForm(new TicketForm());
                        ribbon.HideApplicationButtonContentControl();
                        break;
                }
                if (process.StartInfo.FileName != string.Empty)
                    process.Start();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                // WORKAROUND: Devexpress Issue, see http://www.devexpress.com/Support/Center/p/E1479.aspx
                //if (MdiManager.SelectedPage.MdiChild.GetType() == typeof(CDS.Client.Desktop.Reporting.ReportDesignForm))
                //{
                //    CDS.Client.Desktop.Reporting.ReportDesignForm form = MdiManager.SelectedPage.MdiChild as CDS.Client.Desktop.Reporting.ReportDesignForm;
                //    if (ribbon.SelectedPage.Text == "Print Preview")
                //    {
                //        form.DesignPanel.ExecCommand(DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab);
                //    }
                //    else if (ribbon.SelectedPage.Text == "Report Designer")
                //    {
                //        form.DesignPanel.ExecCommand(DevExpress.XtraReports.UserDesigner.ReportCommand.ShowDesignerTab);
                //    }
                //    else if (ribbon.SelectedPage.Text == "HTML Preview")
                //    {
                //        form.DesignPanel.ExecCommand(DevExpress.XtraReports.UserDesigner.ReportCommand.ShowHTMLViewTab);
                //    }

                //    form.RibbonControl.SelectedPage = form.RibbonControl.Pages[ribbon.SelectedPage.Text];
                //}
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Saves Location of Main Form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 19/03/2012</remarks>
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    CustomApplicationSettings.Instance.StartPosition = this.Location;
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    CustomApplicationSettings.Instance.IsMaximized = this.WindowState == FormWindowState.Maximized ? true : false;
                }
                CustomApplicationSettings.Instance.Save();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Saves Size of Main Form.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 19/03/2012</remarks>
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                CustomApplicationSettings.Instance.StartSize = this.Size;
                CustomApplicationSettings.Instance.IsMaximized = this.WindowState == FormWindowState.Maximized ? true : false;
                CustomApplicationSettings.Instance.Save();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ribbon_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (RibbonMouseMove != null)
                {
                    DevExpress.XtraBars.Ribbon.ViewInfo.RibbonHitInfo hi = Ribbon.CalcHitInfo((new Point(e.X, e.Y)));
                    RibbonMouseMove(sender, e, hi);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ribbon_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (RibbonMouseUp != null)
                {
                    DevExpress.XtraBars.Ribbon.ViewInfo.RibbonHitInfo hi = Ribbon.CalcHitInfo((new Point(e.X, e.Y)));
                    RibbonMouseUp(sender, e, hi);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ribbon_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (RibbonMouseDown != null)
                {
                    DevExpress.XtraBars.Ribbon.ViewInfo.RibbonHitInfo hi = Ribbon.CalcHitInfo((new Point(e.X, e.Y)));
                    RibbonMouseDown(sender, e, hi);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void updateNotifyIconDisplay_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Clicked");
        }

        private void dpCatalogue_Expanding(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
        }

        private void NotificationManager_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            //int x = this.Location.X + (this.Width - (e.AlertForm.Width + 7));
            //int y = this.Location.Y + (this.Height - ((e.AlertForm.Height*activeAlertForms) + ribbonStatusBar.Height + 7));
            //e.Location = new Point(x, y);
            //activeAlertForms++;
        }

        private void NotificationManager_FormClosing(object sender, DevExpress.XtraBars.Alerter.AlertFormClosingEventArgs e)
        {
            //if (activeAlertForms > 0)
            //    activeAlertForms--;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Parallel.ForEach(((List<Essential.MSG.MessengerUsers>)BindingSourceMessengerUsers.DataSource), messengerUser =>
            //foreach (var messengerUser in ((List<Essential.MSG.MessengerUsers>)BindingSourceMessengerUsers.DataSource))
            {
                if (Essential.MSG.Messenger.TestConnection(messengerUser.IP, Convert.ToInt32(messengerUser.Port)).Equals("Received Connection"))
                {
                    messengerUser.Image = global::CDS.Client.Desktop.Properties.Resources.check_16;
                }
                else
                {
                    messengerUser.Image = global::CDS.Client.Desktop.Properties.Resources.delete_16;
                }
            });

            grdMessengerUsers.RefreshDataSource();

            UpdateMessagesGrid();
        }

        private void NotificationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bsiMessage.Visibility = BarItemVisibility.Always;
            string message = bsiMessage.Caption;

            long milliseconds = Convert.ToInt64(e.Argument);

            while (milliseconds > 0)
            {
                bsiMessage.Caption = message;
                Thread.Sleep(500);
                bsiMessage.Caption = string.Empty;
                Thread.Sleep(500);
                milliseconds -= 1000;
            }

            bsiMessage.Caption = "Message";
            bsiMessage.Visibility = BarItemVisibility.Never;
        }

        private void RecoveryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateRecoveryAsync(e.Argument as MainForm);
        }

        private void BackgroundWorkerSystemNotifications_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(20000);

                using (UnitOfWork uow = new UnitOfWork())
                {
                    foreach (var notification in uow.Query<XDB.SYS_Notification>().Where(n => !n.Read && n.PersonId.Id == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId))
                    {
                        ShowNotification(notification.Title, notification.Description, 1000, notification.Description.Length > 50, CDS.Client.Desktop.Properties.Resources.information2_32);
                        notification.Read = true;
                    }
                    uow.CommitChanges();
                }
            }
        }

        private void UpdateUpdateURL()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap(@"C:\Program Files\Complete Distribution\Server\Updates\CDS.Update.Service.exe.config"); //Path to your config file
            fileMap.ExeConfigFilename = @"C:\Program Files\Complete Distribution\Server\Updates\CDS.Update.Service.exe.config";
           
            Configuration updateServiceConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ConfigurationSectionGroup group = updateServiceConfig.SectionGroups[@"applicationSettings"];
            ClientSettingsSection clientSection = group.Sections[@"CDS.Update.Service.Properties.Settings"] as ClientSettingsSection;
            SettingElement settingElement = null;
            foreach (SettingElement sec in clientSection.Settings)
            {
                if (sec.Name == "UpdateURL")
                {
                    settingElement = sec;
                    break;
                }
            }

            settingElement.Value.ValueXml.InnerText = BL.ApplicationDataContext.Instance.CompanySite.UpdateURL.ToString();


            clientSection.SectionInformation.ForceSave = true;
            updateServiceConfig.Save(ConfigurationSaveMode.Full);
        }

        private void UpdateClientZipLocation()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap(@"C:\Program Files\Complete Distribution\Server\Updates\CDS.Update.Service.exe.config"); //Path to your config file
            fileMap.ExeConfigFilename = @"C:\Program Files\Complete Distribution\Server\Updates\CDS.Update.Service.exe.config";
            Configuration updateServiceConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ConfigurationSectionGroup group = updateServiceConfig.SectionGroups[@"applicationSettings"];
            ClientSettingsSection clientSection = group.Sections[@"CDS.Update.Service.Properties.Settings"] as ClientSettingsSection;
            SettingElement settingElement = null;
            foreach (SettingElement sec in clientSection.Settings)
            {
                if (sec.Name == "ClientZipLocation")
                {
                    settingElement = sec;
                    break;
                }
            }

           


            clientSection.SectionInformation.ForceSave = true;
            updateServiceConfig.Save(ConfigurationSaveMode.Full);
        }

        private void UpdateStartTime()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap(@"C:\Program Files\Complete Distribution\Server\Updates\CDS.Update.Service.exe.config"); //Path to your config file
            fileMap.ExeConfigFilename = @"C:\Program Files\Complete Distribution\Server\Updates\CDS.Update.Service.exe.config";
            Configuration updateServiceConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ConfigurationSectionGroup group = updateServiceConfig.SectionGroups[@"applicationSettings"];
            ClientSettingsSection clientSection = group.Sections[@"CDS.Update.Service.Properties.Settings"] as ClientSettingsSection;
            SettingElement settingElement = null;
            foreach (SettingElement sec in clientSection.Settings)
            {
                if (sec.Name == "StartTime")
                {
                    settingElement = sec;
                    break;
                }
            }

            settingElement.Value.ValueXml.InnerText = BL.ApplicationDataContext.Instance.CompanySite.UpdateCheckTime.ToString();


            clientSection.SectionInformation.ForceSave = true;
            updateServiceConfig.Save(ConfigurationSaveMode.Full);
        }

        private struct RecentDocument
        {
            public Guid Id;
            public string Text;
            public string Description;
            public Boolean Checked;
            public string Type;
        }

        private struct RecentLocation
        {
            public string Name;
        }

        private class GDI32
        {

            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }
    }
}