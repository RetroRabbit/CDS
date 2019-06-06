using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.Desktop.Accounting.Statement
{
    public partial class StatementsList : CDS.Client.Desktop.Essential.BaseListEdit
    {
        private Session BaseSession = new Session();
        System.Threading.Tasks.Task statementTask;

        private System.Threading.Tasks.Task StatementTask
        {
            get
            {
                if (statementTask == null)
                {

                    using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        var mainform = Application.OpenForms["MainForm"];
                        Type typExternal = mainform.GetType();
                        System.Reflection.PropertyInfo propertyInf = typExternal.GetProperty("StatementTask");
                         
                        statementTask = propertyInf.GetValue(mainform) as System.Threading.Tasks.Task;
                    }
                }
                return statementTask;
            }
        }
        
        public bool IsCustomer { get; set; }

        public StatementsList(bool isCustomer)
        {
            InitializeComponent();
            this.IsCustomer = isCustomer;
        }

        protected override void OnStart()
        {
            base.OnStart();

            string codeMain = null;
            switch (IsCustomer)
            {
                case true: codeMain = BL.ApplicationDataContext.Instance.SiteAccounts.DebtorsEntity.CodeMain;
                    break;
                case false: codeMain = BL.ApplicationDataContext.Instance.SiteAccounts.CreditorsEntity.CodeMain;
                    break;
            }

            //Filter by siteId for non Master Accountants
            if(!BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
            XPCollection.Filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[EntityId.CodeSub] != '00000' and [EntityId.CodeMain] = ? and SiteId.Id = ?", codeMain, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            else
                XPCollection.Filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[EntityId.CodeSub] != '00000' and [EntityId.CodeMain] = ?", codeMain);
            btnViewActiveProcessing.Visibility = StatementTask != null && StatementTask.Status != System.Threading.Tasks.TaskStatus.RanToCompletion ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        protected override void BindData()
        {
            try
            {
                base.BindData();

                switch (IsCustomer)
                { 
                    case true:
                        this.Text = "Statements of Account (Customers)";
                        break;
                    case false:
                        this.Text = "Statements of Account (Suppliers)";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            //We do not allow New from companies list screens anymore - Must create companies from ORG_Entity
            AllowNewRecord = false;

            //Not allowed to edit on this grid
            AllowEdit = false;
            AllowUndo = false;
            AllowSave = false;
            DisableColumns();
            colPrintStatement.OptionsColumn.AllowEdit = true;
            colEmailStatement.OptionsColumn.AllowEdit = true;
        }

        private void GridView_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == colEmailStatement)
            {
                e.DefaultDraw();
                e.Graphics.DrawImage(CDS.Client.Desktop.Accounting.Properties.Resources.mail_sealed_16, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 16, 16));
                e.Handled = true;
            }
            else if (e.Column == colPrintStatement)
            {
                e.DefaultDraw();
                e.Graphics.DrawImage(CDS.Client.Desktop.Accounting.Properties.Resources.printer_16, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 16, 16));
                e.Handled = true;
            }
        }

        private void GridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                LayoutControlGrid.Validate();
                var statements = this.XPCollection.Cast<CDS.Client.DataAccessLayer.XDB.GLX_Account>();

                bool clearEmail = false, clearPrint = false;
                if (info.Column == colEmailStatement && statements.Count(n => n.EmailStatement) > 0)
                {
                    clearEmail = true;
                }
                else
                    if (info.Column == colPrintStatement && statements.Count(n => n.PrintStatement) > 0)
                    {
                        clearPrint = true;
                    }

                using(var uow = new DevExpress.Xpo.Session())
                {
                    XDB.ORG_Company company = null;
                    
                    foreach (CDS.Client.DataAccessLayer.XDB.GLX_Account account in XPCollection)
                    {
                        if (account.EntityId.AccountBalance == 0.00M)
                            continue;

                        switch (IsCustomer)
                        {
                            case true: company = uow.Query<XDB.ORG_Company>().SingleOrDefault(n => n.TypeId.Id == (byte)BL.ORG.ORG_Type.Customer && n.EntityId.EntityId.CodeSub == account.EntityId.CodeSub);
                                break;
                            case false: company = uow.Query<XDB.ORG_Company>().SingleOrDefault(n => n.TypeId.Id == (byte)BL.ORG.ORG_Type.Supplier && n.EntityId.EntityId.CodeSub == account.EntityId.CodeSub);
                                break;
                        }                        

                        if (clearEmail)
                        {
                            account.EmailStatement = false;
                        }
                        else if (info.Column == colEmailStatement)
                        {
                            if (company.StatementPreference == "Email" || (company.StatementPreference == "Email, Print" || company.StatementPreference == "Print, Email"))
                                account.EmailStatement = true;

                            if (account.EntityId.AccountBalance != 0)
                                account.EmailStatement = true;
                        }

                        if (clearPrint)
                        {
                            account.PrintStatement = false;
                        }
                        else if (info.Column == colPrintStatement)
                        {
                            if (company.StatementPreference == "Print" || (company.StatementPreference == "Email, Print" || company.StatementPreference == "Print, Email"))
                                account.PrintStatement = true;

                            if (account.EntityId.AccountBalance != 0)
                                account.PrintStatement = true;
                        }
                    }
                }

                clearEmail = false;
                clearPrint = false;

                if (statements.Count(n => n.EmailStatement) > 0 || statements.Count(n => n.PrintStatement) > 0)
                    btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                else
                    btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                GridView.RefreshData();
            }
        }

        private void XPCollection_ResolveSession(object sender, ResolveSessionEventArgs e)
        {
            e.Session = BaseSession;
        }

        private void btnProcessStatements_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ProcessStatementsDialogue dlg = new ProcessStatementsDialogue())
            {
                LayoutControlGrid.Validate();


                using (var uow = new DevExpress.Xpo.Session())
                {
                    XDB.ORG_Company company = null;
                    foreach (XDB.GLX_Account account in this.XPCollection)
                    {

                        switch (IsCustomer)
                        {
                            case true: company = uow.Query<XDB.ORG_Company>().SingleOrDefault(n => n.TypeId.Id == (byte)BL.ORG.ORG_Type.Customer && n.EntityId.EntityId.CodeSub == account.EntityId.CodeSub);
                                break;
                            case false: company = uow.Query<XDB.ORG_Company>().SingleOrDefault(n => n.TypeId.Id == (byte)BL.ORG.ORG_Type.Supplier && n.EntityId.EntityId.CodeSub == account.EntityId.CodeSub);
                                break;
                        }

                        if (account.PrintStatement || account.EmailStatement)
                            dlg.Statements.Add(new CDS.Client.DataAccessLayer.Types.Statement()
                            {
                                EntityId = account.EntityId.Id,
                                Code = account.EntityId.CodeSub,
                                Name = account.EntityId.Name,
                                Contact = company.AccountsContactName,
                                Email = company.AccountsContactEmail,
                                ShouldPrint = account.PrintStatement,
                                ShouldEmail = account.EmailStatement
                            });
                    }
                }
                dlg.ShowDialog();
            }

            if (StatementTask != null && StatementTask.Status != System.Threading.Tasks.TaskStatus.RanToCompletion)
            {
                Essential.BaseAlert.ShowAlert("Processing statements", "Statements will now be processed in the background.\nClick on \"View Active Processing\" to check progress.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                btnViewActiveProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                UpdateTimer.Start();
            }
        }

        private void btnViewActiveProcessing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ProcessStatementsDialogue dlg = new ProcessStatementsDialogue())
            {
                dlg.ViewOnly = true;
                dlg.ShowDialog();
            }
        }

        private void XPCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
        
        }

        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            LayoutControlGrid.Validate();
            var statements = this.XPCollection.Cast<CDS.Client.DataAccessLayer.XDB.GLX_Account>();
            if (statements.Count(n => n.EmailStatement) > 0 || statements.Count(n => n.PrintStatement) > 0)
                btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            else
                btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (StatementTask != null && StatementTask.Status != System.Threading.Tasks.TaskStatus.RanToCompletion)
            {
                btnViewActiveProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnViewActiveProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnProcessStatements.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                UpdateTimer.Stop();
            }
        }
         
    }
}