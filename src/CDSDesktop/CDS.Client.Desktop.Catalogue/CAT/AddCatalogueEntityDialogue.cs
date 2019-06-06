using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    public partial class AddCatalogueEntityDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public Int64? TopCategoryId { get; set; }
        public Int64 CatalogueId { get; set; }
        public DB.CAT_Item Item { get { return BindingSourceItem.DataSource as DB.CAT_Item; } }
        public List<EntryMeta> ListEntryMeta { get { return (List<EntryMeta>)BindingSourceMetaData.DataSource; } }

        public AddCatalogueEntityDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (BL.ApplicationDataContext.Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
                itmStockCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            BindingSourceItem.DataSource = BL.CAT.CAT_Item.New;
            BindingSourceMetaData.DataSource = new List<EntryMeta>();

            ddlCategory.EditValue = TopCategoryId == null ? null : (object)TopCategoryId;
        //    PopupulateMeta();
            
            ddlCategory.Properties.View.AsyncCompleted += View_AsyncCompleted;
        }

        private void PopupulateMeta()
        {
            var metastruc = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == TopCategoryId).ToList();

            BindingSourceMetaData.Clear();

            //foreach (DB.CAT_Meta meta in metastruc)
            metastruc.ForEach(meta =>
            {
                BindingSourceMetaData.Add(new EntryMeta() { Id = meta.Id, CategoryId = meta.CategoryId, Grouping = meta.Grouping, Type = meta.Type, Name = meta.Name, Value = "" });
            });

            grvMetaData.ExpandAllGroups();
        }

        void View_AsyncCompleted(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void InstantFeedbackSourceItem_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new byte[] { (byte)BL.SYS.SYS_Type.BuyOut, (byte)BL.SYS.SYS_Type.Message }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory));
        }

        private void InstantFeedbackSourceCategory_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Category.Where(n => n.CatalogueId == CatalogueId);
        }

        private void ddlCategoryView_Click(object sender, EventArgs e)
        {
            TopCategoryId = (((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(((DevExpress.XtraGrid.Views.Grid.GridView)sender).GetFocusedRow())).OriginalRow as DB.VW_Category).Id;
          
        }

        private void ddlCategory_EditValueChanged(object sender, EventArgs e)
        {
            PopupulateMeta();
        }
    }
}
