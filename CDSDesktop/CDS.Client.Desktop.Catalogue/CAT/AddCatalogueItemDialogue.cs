using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    public partial class AddCatalogueItemDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        //tlCategory Datasource
        public object TreeGridDataSource { get; set; }
        
        public DB.CAT_Item Item { get { return BindingSource.DataSource as DB.CAT_Item; } }
        
        public DB.CAT_ItemData ItemData { get { return BindingSourceItemData.DataSource as DB.CAT_ItemData; } }
        
        public List<DB.CAT_MetaData> MetaData { get; set; }

        public AddCatalogueItemDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            tlCategory.DataSource = TreeGridDataSource;
            //Item 
            BindingSource.DataSource = BL.CAT.CAT_Item.New;
            //ItemData 
            BindingSourceItemData.DataSource = BL.CAT.CAT_ItemData.New;
            BindingSourceMetaData.DataSource = new List<EntryMeta>();
            MetaData = new List<DB.CAT_MetaData>();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            foreach (TreeListNode node in tlCategory.Nodes)
            {
                if (node.Level == 0)
                {
                    node.Expanded = true;
                }
            }
        }

        private void InstantFeedbackSourceStockItem_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory ));
        }
         
        private void pceCategory_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (tlCategory.FocusedNode != null)
                e.DisplayText = (tlCategory.GetDataRecordByNode(tlCategory.FocusedNode) as DB.CAT_Category).Name;
            else
                e.DisplayText = pceCategory.Properties.NullText;
        }
         
        private void tlCategory_DoubleClick(object sender, EventArgs e)
        {
            pceCategory.ClosePopup();
        }

        private void InstantFeedbackSourceItem_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.EntityCatalogueContext.CAT_Item.Where(n => n.CAT_ItemData.Any(nn=>nn.ItemId != nn.ParentItemId));
        }

        private void tlCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (tlCategory.FocusedNode != null)
                {
                    BindingSourceMetaData.Clear();
                    Int64 categoryId = (tlCategory.GetDataRecordByNode(tlCategory.FocusedNode) as DB.CAT_Category).Id;
                    pceCategory.EditValue = categoryId;
                    var metastruc = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == categoryId);

                    foreach (DB.CAT_Meta meta in metastruc)
                    {
                        BindingSourceMetaData.Add(new EntryMeta() { Id = meta.Id, CategoryId = meta.CategoryId, Grouping = meta.Grouping, Type = meta.Type, Name = meta.Name, Value = "" });
                    }

                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            foreach (EntryMeta metaData in BindingSourceMetaData.DataSource as List<EntryMeta>)
            {
                MetaData.Add(new DB.CAT_MetaData() { CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId, Data = metaData.Value.ToString(), CategoryId = metaData.CategoryId, MetaId = metaData.Id });
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void ddlName_EditValueChanged(object sender, EventArgs e)
        {
            BindingSource.DataSource = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(ddlName.Properties.View.GetFocusedRow())).OriginalRow as DB.CAT_Item;        
        }
         
    }
}
