using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using XDB = CDS.Client.DataAccessLayer.XDB;

namespace CDS.Client.Desktop.Document.Stock
{
    public partial class ScanItemDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private List<BarcodeItem> items = new List<BarcodeItem>();

        public List<BarcodeItem> Items { get { return items; } }

        public ScanItemDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            grvItems.OptionsView.ShowIndicator = false;
            grvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            grvItems.OptionsSelection.EnableAppearanceFocusedRow = false;
            grvItems.OptionsSelection.EnableAppearanceHideSelection = false;
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = items;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (items.Any(n => n.Barcode == Convert.ToString(txtBarcode.EditValue)))
                {
                    items.FirstOrDefault(n => n.Barcode == Convert.ToString(txtBarcode.EditValue)).Quantity++;
                }
                else
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        if (uow.Query<XDB.SYS_Entity>().Any(n => n.Barcode == txtBarcode.EditValue))
                        {
                            items.Add(new BarcodeItem() { Barcode = Convert.ToString(txtBarcode.EditValue), Quantity = 1 });
                        }
                    }
                }
                txtBarcode.EditValue = string.Empty;
                grdItem.RefreshDataSource();
            }
        }

        public class BarcodeItem
        {
            public string Barcode { get; set; }
            public decimal Quantity { get; set; }
        }
    }
}
