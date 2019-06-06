using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Customization.Controls;
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
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Essential.UTL
{
    public partial class CustomizationForm : DevExpress.XtraLayout.Customization.UserCustomizationForm
    {
        BL.DataContext DataContext = new BL.DataContext();

        private string ScreenName { get { return this.OwnerControl.Parent.GetType().FullName; } }

        private Int64 SelectedUser { get { return Convert.ToInt64(ddlUser.EditValue); } }

        public CustomizationForm()
        {
            InitializeComponent();
        }

        private void CustomizatonForm_Load(object sender, EventArgs e)
        {
            // base.OnLoad(e);

            LayoutControlItem lci = layoutControl1.GetItemByControl(bpCustomButtons);
            ButtonsPanel oldPanel = lci.Control as ButtonsPanel;
            MyButtonsPanel newPanel = new MyButtonsPanel();
            oldPanel.UnRegister();
            lci.BeginInit();
            lci.Control = newPanel;
            newPanel.Parent = oldPanel.Parent;
            oldPanel.Parent = null;
            lci.EndInit();
            newPanel.Register();
            lci.Update();
            //Copy events from one control to another
            //var eventsField = typeof(Component).GetField("events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //var eventHandlerList = eventsField.GetValue(oldPanel.UndoButton);
            //eventsField.SetValue(simpleButton1, eventHandlerList);
            this.Size = new Size(655, 365);
            this.Location = System.Windows.Forms.Cursor.Position;
            ddlUser.EditValue = BL.ApplicationDataContext.Instance.LoggedInUser.Id;
            BindingSourceUsers.DataSource = DataContext.ReadonlyContext.VW_User.Where(n => n.Archived == false).ToList();

            cbeUsers.Properties.ForceUpdateEditValue = DevExpress.Utils.DefaultBoolean.True;
            cbeUsers.EditValue = BL.ApplicationDataContext.Instance.LoggedInUser.Id.ToString();
            cbeUsers.RefreshEditValue();
        }

        internal class MyButtonsPanel : ButtonsPanel
        {
            private Int64 SelectedUser { get { return Convert.ToInt64((this.Parent.Controls.Find("ddlUser", true)[0] as DevExpress.XtraEditors.SearchLookUpEdit).EditValue); } }
            private List<Int64> SelectedUsers { get { return (this.Parent.Controls.Find("cbeUsers", true)[0] as DevExpress.XtraEditors.CheckedComboBoxEdit).EditValue.ToString().Split(',').Select(Int64.Parse).ToList(); } }
            private string ScreenName { get { return this.OwnerControl.Parent.GetType().FullName; } }

            BL.DataContext DataContext = new BL.DataContext();

            protected override void OnSaveLayoutButtonClick(object sender, EventArgs e)
            {
                try
                {
                    System.IO.Stream Layout = new System.IO.MemoryStream();
                    OwnerControl.SaveLayoutToStream(Layout);
                    System.Xml.XmlDocument XmlDoc = new System.Xml.XmlDocument();
                    Layout.Seek(0, System.IO.SeekOrigin.Begin);

                    using (System.IO.StreamReader reader = new System.IO.StreamReader(Layout))
                        XmlDoc.InnerXml = reader.ReadToEnd();

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            foreach (Int64 user in SelectedUsers)
                            {
                                DB.SYS_Layout sys_layout = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == ScreenName && n.UserId == user);

                                if (sys_layout == null)
                                {
                                    //Form Layout
                                    sys_layout = BL.SYS.SYS_Layout.New;
                                    if (sys_layout.Original == null)
                                    {
                                        sys_layout.Screen = ScreenName;
                                        sys_layout.Original = XmlDoc.InnerXml;
                                        sys_layout.SystemOriginal = XmlDoc.InnerXml;
                                        sys_layout.Custom = XmlDoc.InnerXml;
                                    }

                                    //Grids Layouts
                                    foreach (var control in OwnerControl.Control.Controls)
                                    {
                                        if (control is DevExpress.XtraGrid.GridControl)
                                        {
                                            foreach (DevExpress.XtraGrid.Views.Grid.GridView view in (control as DevExpress.XtraGrid.GridControl).Views)
                                            {

                                                System.IO.Stream gridViewLayout = new System.IO.MemoryStream();
                                                view.SaveLayoutToStream(gridViewLayout);
                                                gridViewLayout.Seek(0, System.IO.SeekOrigin.Begin);
                                                System.Xml.XmlDocument gridViewXmlDoc = new System.Xml.XmlDocument();

                                                using (System.IO.StreamReader gridViewReader = new System.IO.StreamReader(gridViewLayout))
                                                    gridViewXmlDoc.InnerXml = gridViewReader.ReadToEnd();

                                                DB.SYS_Layout sys_layout_grid = BL.SYS.SYS_Layout.New;
                                                sys_layout_grid.Screen = ScreenName + "+" + view.Name;
                                                sys_layout_grid.Original = gridViewXmlDoc.InnerXml;
                                                sys_layout_grid.SystemOriginal = gridViewXmlDoc.InnerXml;
                                                sys_layout_grid.Custom = gridViewXmlDoc.InnerXml;
                                                sys_layout_grid.UserId = user;
                                                BL.EntityController.SaveSYS_Layout(sys_layout_grid, DataContext);
                                            }
                                        }
                                    }
                                    //Ribbon Layout
                                    string ribbonQuickAccessToolbarName = ScreenName + "+" + "QuickAccessToolbar";
                                    foreach (var control in OwnerControl.Parent.Controls)
                                    {
                                        if (control is DevExpress.XtraBars.Ribbon.RibbonControl)
                                        {
                                            foreach (DevExpress.XtraBars.BarItem item in (control as DevExpress.XtraBars.Ribbon.RibbonControl).Items)
                                            {
                                                (item as DevExpress.XtraBars.BarItem).Id =
                                                (control as DevExpress.XtraBars.Ribbon.RibbonControl).Manager.GetNewItemId();
                                            }

                                            System.IO.Stream ribbonQuickAccessLayout = new System.IO.MemoryStream();
                                            (control as DevExpress.XtraBars.Ribbon.RibbonControl).Toolbar.SaveLayoutToStream(ribbonQuickAccessLayout);
                                            ribbonQuickAccessLayout.Seek(0, System.IO.SeekOrigin.Begin);
                                            System.Xml.XmlDocument ribbonQuickAccessXmlDoc = new System.Xml.XmlDocument();

                                            using (System.IO.StreamReader ribbonQuickAccessReader = new System.IO.StreamReader(ribbonQuickAccessLayout))
                                                ribbonQuickAccessXmlDoc.InnerXml = ribbonQuickAccessReader.ReadToEnd();

                                            DB.SYS_Layout sys_layout_quick_access = BL.SYS.SYS_Layout.New;
                                            sys_layout_quick_access.Screen = ribbonQuickAccessToolbarName;
                                            sys_layout_quick_access.Original = ribbonQuickAccessXmlDoc.InnerXml;
                                            sys_layout_quick_access.SystemOriginal = ribbonQuickAccessXmlDoc.InnerXml;
                                            sys_layout_quick_access.Custom = ribbonQuickAccessXmlDoc.InnerXml;
                                            sys_layout_quick_access.UserId = user;
                                            BL.EntityController.SaveSYS_Layout(sys_layout_quick_access, DataContext);
                                        }
                                    }

                                }
                                else
                                {
                                    sys_layout.Custom = XmlDoc.InnerXml;
                                    foreach (var control in OwnerControl.Control.Controls)
                                    {
                                        if (control is DevExpress.XtraGrid.GridControl)
                                        {
                                            foreach (DevExpress.XtraGrid.Views.Grid.GridView view in (control as DevExpress.XtraGrid.GridControl).Views)
                                            {
                                                System.IO.Stream gridViewLayout = new System.IO.MemoryStream();
                                                view.SaveLayoutToStream(gridViewLayout);//, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                                                gridViewLayout.Seek(0, System.IO.SeekOrigin.Begin);
                                                System.Xml.XmlDocument gridViewXmlDoc = new System.Xml.XmlDocument();

                                                using (System.IO.StreamReader gridViewReader = new System.IO.StreamReader(gridViewLayout))
                                                    gridViewXmlDoc.InnerXml = gridViewReader.ReadToEnd();

                                                string gridName = ScreenName + "+" + view.Name;
                                                DB.SYS_Layout sys_layout_grid = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == gridName && n.UserId == user);
                                                sys_layout_grid.Custom = gridViewXmlDoc.InnerXml;
                                                BL.EntityController.SaveSYS_Layout(sys_layout_grid, DataContext);
                                            }
                                        }
                                    }

                                    //Ribbon Layout
                                    string ribbonQuickAccessToolbarName = ScreenName + "+" + "QuickAccessToolbar";
                                    foreach (var control in OwnerControl.Parent.Controls)
                                    {
                                        if (control is DevExpress.XtraBars.Ribbon.RibbonControl)
                                        {
                                            System.IO.Stream ribbonQuickAccessLayout = new System.IO.MemoryStream();
                                            (control as DevExpress.XtraBars.Ribbon.RibbonControl).Toolbar.SaveLayoutToStream(ribbonQuickAccessLayout);
                                            ribbonQuickAccessLayout.Seek(0, System.IO.SeekOrigin.Begin);
                                            System.Xml.XmlDocument ribbonQuickAccessXmlDoc = new System.Xml.XmlDocument();

                                            using (System.IO.StreamReader ribbonQuickAccessReader = new System.IO.StreamReader(ribbonQuickAccessLayout))
                                                ribbonQuickAccessXmlDoc.InnerXml = ribbonQuickAccessReader.ReadToEnd();

                                            DB.SYS_Layout sys_layout_quick_access = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == ribbonQuickAccessToolbarName && n.UserId == user);
                                            sys_layout_quick_access.Custom = ribbonQuickAccessXmlDoc.InnerXml;
                                            BL.EntityController.SaveSYS_Layout(sys_layout_quick_access, DataContext);
                                        }
                                    }
                                }
                                sys_layout.UserId = user;
                                BL.EntityController.SaveSYS_Layout(sys_layout, DataContext);
                            }

                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();

                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                    OwnerControl.CustomizationForm.Close();
                }
                catch (Exception ex)
                {
                    //dataContext.EntitySystemContext.RollBackTransaction();
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }

            }

            protected override void OnLoadLayoutButtonClick(object sender, EventArgs e)
            {
                try
                {
                    //MessageBox.Show("Load Layout Button");
                    //base.OnLoadLayoutButtonClick(sender, e);

                    DB.SYS_Layout sys_layout = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == ScreenName && n.UserId == SelectedUser);
                    System.Xml.XmlDocument XmlDoc = new System.Xml.XmlDocument();
                    XmlDoc.LoadXml(sys_layout.Custom);
                    System.IO.Stream Layout = new System.IO.MemoryStream();
                    XmlDoc.Save(Layout);
                    Layout.Seek(0, System.IO.SeekOrigin.Begin);
                    OwnerControl.RestoreLayoutFromStream(Layout);
                    //OwnerControl.CustomizationForm.Close();

                    sys_layout.Custom = sys_layout.Original;
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Layout(sys_layout, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();

                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                }
                catch (Exception ex)
                {
                    //dataContext.EntitySystemContext.RollBackTransaction();
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }

            protected override void OnRedoButtonClick(object sender, EventArgs e)
            {
                base.OnRedoButtonClick(sender, e);
            }

            protected override void OnUndoButtonClick(object sender, EventArgs e)
            {
                base.OnUndoButtonClick(sender, e);
            }
        }

        private void btnRestoreFactoryDefault_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Load Layout Button");
                //base.OnLoadLayoutButtonClick(sender, e);

                DB.SYS_Layout sys_layout = DataContext.EntitySystemContext.SYS_Layout.FirstOrDefault(n => n.Screen == ScreenName && n.UserId == SelectedUser);
                System.Xml.XmlDocument XmlDoc = new System.Xml.XmlDocument();
                XmlDoc.LoadXml(sys_layout.Custom);
                System.IO.Stream Layout = new System.IO.MemoryStream();
                XmlDoc.Save(Layout);
                Layout.Seek(0, System.IO.SeekOrigin.Begin);
                OwnerControl.RestoreLayoutFromStream(Layout);
                //OwnerControl.CustomizationForm.Close();

                sys_layout.Custom = sys_layout.SystemOriginal;
                sys_layout.Original = sys_layout.SystemOriginal;
                try
                {
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        BL.EntityController.SaveSYS_Layout(sys_layout, DataContext);
                        DataContext.SaveChangesEntitySystemContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntitySystemContext.AcceptAllChanges();
                }
                catch (Exception ex)
                {
                    DataContext.EntitySystemContext.RejectChanges();

                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
            catch (Exception ex)
            {
                //DataContext.EntitySystemContext.RollBackTransaction();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void CustomizationPropertyGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {

        }

        private void InstantFeedbackSourceRole_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_User.Where(n => n.Archived == false);
        }

    }
}
