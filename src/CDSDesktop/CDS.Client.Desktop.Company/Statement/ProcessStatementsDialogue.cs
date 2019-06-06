using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Company.Statement
{
    public partial class ProcessStatementsDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private long periodId;
        private List<ProcessStement> processStements = new List<ProcessStement>();
        private List<Bitmap> images = new List<Bitmap> {
        new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/print/print_16x16.png")),
        new System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetResource("office2013/mail/mail_16x16.png"))};

        public ProcessStatementsDialogue()
        {
            InitializeComponent();
        }

        public List<ProcessStement> ProcessStements { get { return processStements; } }

        public Bitmap ImagePrint { get { return images[0]; } }
        public Bitmap ImageEmail { get { return images[1]; } }

        private void ProcessStatementsDialogue_Load(object sender, EventArgs e)
        {
            BindingSource.DataSource = processStements;
            grdProgress.RefreshDataSource();

            lblEmailProgress.Text = string.Format("Now Emailing 0 of {0}", processStements.Count(n => n.ShouldEmail));
            lblPrintProgress.Text = string.Format("Now Printing 0 of {0}", processStements.Count(n => n.ShouldPrint));
             
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ProcessStatements();
        }

        private void ProcessStatements()
        {
            
        }

        public class ProcessStement
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Contact { get; set; }
            public string Email { get; set; }
            public bool ShouldPrint { get; set; }
            public bool ShouldEmail { get; set; }            
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

        
    }
}
