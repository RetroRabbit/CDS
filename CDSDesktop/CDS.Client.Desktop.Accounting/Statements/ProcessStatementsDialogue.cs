using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using BL = CDS.Client.BusinessLayer;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.Desktop.Accounting.Statement
{
    public partial class ProcessStatementsDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private List<CDS.Client.DataAccessLayer.Types.Statement> statements = new List<CDS.Client.DataAccessLayer.Types.Statement>();
        private List<Bitmap> images = new List<Bitmap> 
        {
            new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/print/print_16x16.png")),
            new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/mail/mail_16x16.png"))
        };

        public bool ViewOnly { get; set; }

        public ProcessStatementsDialogue()
        {
            InitializeComponent();
        }

        public List<CDS.Client.DataAccessLayer.Types.Statement> Statements { get { return statements; } }

        public Bitmap ImagePrint { get { return images[0]; } }
        public Bitmap ImageEmail { get { return images[1]; } }

        protected override void OnStart()
        {
            base.OnStart();

            lblEmailProgress.Text = string.Format("Now Emailing 0 of {0}", statements.Count(n => n.ShouldEmail));
            lblPrintProgress.Text = string.Format("Now Printing 0 of {0}", statements.Count(n => n.ShouldPrint));

            using (var uow = new DevExpress.Xpo.UnitOfWork())
            {
                DateTime date = BL.ApplicationDataContext.Instance.ServerDateTime.AddMonths(-1);

                ddlPeriod.EditValue = uow.Query<XDB.SYS_Period>().Where(n => date > n.StartDate && date < n.EndDate).Select(l => l.Id).FirstOrDefault();
            }

            itmOk.Visibility = ViewOnly ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            if (ViewOnly)
            {
                UpdateTimer.Start();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            UpdateTimer.Stop();
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = statements;
            grdProgress.RefreshDataSource(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidationProvider.Validate() && IsPrinterValid())
                ProcessStatements((long)ddlPeriod.EditValue);

            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                itmOk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                System.Threading.Thread.Sleep(1000);
            }
            
            UpdateTimer.Start();
        }

        private bool IsPrinterValid()
        {
            bool isValid = true;

            isValid = statements.Count(n => n.ShouldPrint) > 0 && ddlPrinter.EditValue == null ? false : true; ;

            if (!isValid)
                ddlPrinter.ErrorText = "Select printer ...";
            else
                ddlPrinter.ErrorText = string.Empty;

            return isValid;
        }

        private void ProcessStatements(long periodId)
        {

            pbcPrint.Properties.Maximum = Statements.Count(n => n.ShouldPrint);
            pbcEmail.Properties.Maximum = Statements.Count(n => n.ShouldEmail);

            var task = BL.ApplicationDataContext.Instance.Service.ProcessStatementsAsync(BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, periodId, (long?)ddlPrinter.EditValue, Statements);
            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                var mainform = Application.OpenForms["MainForm"];
                Type typExternal = mainform.GetType();
                System.Reflection.PropertyInfo propertyInf = typExternal.GetProperty("StatementTask");

                propertyInf.SetValue(mainform, task);
            }

            //this.Close();
        }

        private void grvProgress_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == colShouldEmail)
            {
                e.DefaultDraw();
                e.Graphics.DrawImage(ImageEmail, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 16, 16));
                e.Handled = true;
            }
            else if (e.Column == colShouldPrint)
            {
                e.DefaultDraw();
                e.Graphics.DrawImage(ImagePrint, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 16, 16));
                e.Handled = true;
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                statements = BL.ApplicationDataContext.Instance.Service.ProcessStatementsUpdate();

                pbcPrint.Properties.Maximum = Statements.Count(n => n.ShouldPrint);
                pbcEmail.Properties.Maximum = Statements.Count(n => n.ShouldEmail);

                if (BindingSource.DataSource == null)
                {
                    UpdateTimer.Stop();
                    Essential.BaseAlert.ShowAlert("Processing statements", "Statements processing complete.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    this.Close();
                }
                else
                { 
                    lblPrintProgress.Text = string.Format("Printed {0} of {1}", Statements.Count(n => n.HasPrinted.HasValue), Statements.Count(n => n.ShouldPrint));
                    pbcPrint.EditValue = Statements.Count(n => n.HasPrinted.HasValue);
                    lblEmailProgress.Text = string.Format("Mailed {0} of {1}", Statements.Count(n => n.HasMailed.HasValue), Statements.Count(n => n.ShouldEmail));
                    pbcEmail.EditValue = Statements.Count(n => n.HasMailed.HasValue);
                    BindingSource.DataSource = statements;
                    grdProgress.RefreshDataSource();
                }
            }
            catch
            {
                UpdateTimer.Stop();
                this.Close();
            }
        }

    }
}
