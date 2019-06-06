using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Document.LostSale
{
    public partial class LostSaleList : CDS.Client.Desktop.Essential.BaseList
    {
        public LostSaleList()
        {
            InitializeComponent();
        }
         
        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = false;
            AllowOpenRecord = false;
        }
    }
}
