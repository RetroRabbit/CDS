using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Stock.Document
{
    public partial class InventoryAdjustmentForm : CDS.Client.Desktop.Stock.Document.BaseStockDocument
    {
        public InventoryAdjustmentForm()
        {
            InitializeComponent();
        }

        public InventoryAdjustmentForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }
    }
}
