using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Ordering.AOR
{
    public partial class AutomaticOrderingDetailForm : CDS.Client.Desktop.Essential.BaseForm
    {
        DB.AOR_OrderLine item;
        List<DB.AOR_OrderLine> items;
        DB.VW_OrderInventoryHistory vwOrderInventoryHistory;
        int rownumber;

        public AutomaticOrderingDetailForm()
        {
            InitializeComponent();
        }

        public AutomaticOrderingDetailForm(List<DB.AOR_OrderLine> items, int rownumber)
        {
            InitializeComponent();
            item = items.ElementAt(rownumber);
            vwOrderInventoryHistory = item.InventoryHistory;
            this.rownumber = rownumber;
            this.items = items;
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = item;
            BindingSourceHistory.DataSource = vwOrderInventoryHistory;
        }

    //   internal void OpenRecord(List<DB.AOR_OrderLine> items, int rownumber)
    //   {
    //       //currentItem = items[rownumber];
    //       BindingSource.DataSource = items.ElementAt(rownumber);
    //       BindingSourceHistory.DataSource = (BindingSource.DataSource as DB.AOR_OrderLine).InventoryHistory;
    //       this.rownumber = rownumber;
    //       this.items = items;
    //   }

        protected override void OnClosing(CancelEventArgs e)
        {
         //   base.OnClosing(e);
        }

        protected override void OnNextRecord()
        {
            base.OnNextRecord();

            if (items.ElementAt(rownumber + 1) != null)
            {
                item = items.ElementAt(rownumber + 1);
                this.rownumber++;
                InstantFeedbackSourceSalesHistory.Refresh();
            }           
        }

        protected override void OnPreviousRecord()
        {
            base.OnPreviousRecord();
            if (items.ElementAt(rownumber - 1) != null)
            {
                item = items.ElementAt(rownumber - 1);
                this.rownumber--;
                InstantFeedbackSourceSalesHistory.Refresh();
            } 
        } 

        private void InstantFeedbackSourceSalesHistory_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            DB.SYS_Period currentPeriod = BL.SYS.SYS_Period.GetCurrentPeriod(DataContext);
            DateTime dateAfter = DateTime.Today.AddYears(-2);
            e.QueryableSource = DataContext.ReadonlyContext.VW_ItemHistory.Where(n => n.EntityId == ((DB.AOR_OrderLine)BindingSource.DataSource).InventoryId && n.Date > dateAfter && n.Date <= currentPeriod.EndDate);
        }
    }
}
