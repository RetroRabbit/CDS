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

namespace CDS.Client.Desktop.Essential
{
    public partial class AlternativeDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public String SearchItem { get; set; }

        public DB.VW_Alternative SelectedItem { get; set; }

        public AlternativeDialogue(string searchItem)
        {
            InitializeComponent();
            SearchItem = searchItem;
        }

        private void InstantFeedbackSourceAlternative_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Alternative.Where(n => n.SearchItemName == SearchItem);
        }

        private void SelectItem()
        {
            if (grvAlternative.GetFocusedRow() == null || grvAlternative.GetFocusedRow() is DevExpress.Data.NotLoadedObject)
                return;

            SelectedItem = (grvAlternative.GetFocusedRow() as DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread).OriginalRow as DB.VW_Alternative;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void grvAlternative_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectItem();
        }

        private void grvAlternative_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void grvAlternative_AsyncCompleted(object sender, EventArgs e)
        {
            for(int i =0;i<grvAlternative.RowCount;i++)
            {
                  while (grvAlternative.GetRow(i) is DevExpress .Data. NotLoadedObject) {
                    Application.DoEvents(); 
                }


                  if (((grvAlternative.GetRow(i) as DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread).OriginalRow as DB.VW_Alternative).AlternativeItemName == SearchItem)
                {
                    grvAlternative.FocusedRowHandle = i;
                }
            }
        }
    }
}
