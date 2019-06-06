using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList.Nodes;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    public partial class CatalogueManagementForm : CDS.Client.Desktop.Essential.BaseForm
    {
        String imageLocation = @"C:\Catalogue\";

        public CatalogueManagementForm()
        {
            InitializeComponent();
        }

        public CatalogueManagementForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            ExpandCategories();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetActiveTab();
        }

        private void ExpandCategories()
        {
            //Werner: Parallel.ForEach on Frontend chnages freaks out some times
            //Parallel.ForEach(tlCategory.Nodes, node =>
            foreach (TreeListNode node in tlCategory.Nodes)
            {
                if (node.Level == 0)
                {
                    node.Expanded = true;
                }
            }//);
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                BindingSource.DataSource = BL.CAT.CAT_Catalogue.New;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void OpenRecord(long Id)
        {
            try
            {
             //   BindingSource.DataSource = BL.CAT.CAT_Catalogue.Load(Id, DataContext);
               // BindData();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    base.OnSaveRecord();
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveCAT_Catalogue((DB.CAT_Catalogue)BindingSource.DataSource, DataContext);
                            DataContext.SaveChangesEntityCatalogueContext();
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntityCatalogueContext.AcceptAllChanges();
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityCatalogueContext.RejectChanges();
                        DataContext.EntitySystemContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
        }

        protected override void OnNextRecord()
        {
            base.OnNextRecord();
            BindData();
        }

        protected override void OnPreviousRecord()
        {
            base.OnPreviousRecord();
            BindData();
        } 

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = BL.CAT.CAT_Catalogue.Load(Id, DataContext);
            BindingSourceCategory.DataSource = DataContext.EntityCatalogueContext.CAT_Category.Where(n => n.CatalogueId == ((DB.CAT_Catalogue)BindingSource.DataSource).Id).ToList();
        }

        private void SetActiveTab()
        {
            //using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            //{
            //    var mainform = Application.OpenForms["MainForm"];
            //    Type typExternal = mainform.GetType();
            //    System.Reflection.MethodInfo methodInf = typExternal.GetMethod("RibbonVisibility");

            //    methodInf.Invoke(mainform, new object[] { "Manage", "rpgStructure" });
            //}

            //DevExpress.XtraBars.Ribbon.RibbonControl mainRibbon = ((DevExpress.XtraBars.Ribbon.RibbonForm)this.MdiParent).Ribbon;// CDS.Client.Desktop.STD.MainForm.Instance.Ribbon;

            DevExpress.XtraBars.Ribbon.RibbonPageGroup structure = this.RibbonControl.Pages["Manage"].Groups["rpgStructure"];
            DevExpress.XtraBars.Ribbon.RibbonPageGroup content = this.RibbonControl.Pages["Manage"].Groups["rpgContent"];

            if (structure == null || content == null)
                return;

            if (tcgCatalogue.SelectedTabPage == tabStructure)
            {
                structure.Ribbon.SelectedPage = this.RibbonControl.Pages["Manage"];
                structure.Visible = true;
                content.Visible = false;
                //       AllowExport = false;
            }
            else
            {
                structure.Ribbon.SelectedPage = this.RibbonControl.Pages["Manage"];
                structure.Visible = false;
                content.Visible = true;
                //     AllowExport = true;
            }
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            System.Reflection.MethodInfo methodInf = typExternal.GetMethod("SelectRibbonPage");

            methodInf.Invoke(mainform, new object[] { structure.Ribbon.SelectedPage.Text });

        }
         
        DB.CAT_Category SelectedTopCategory { get; set; }
        object SelectedEntity { get; set; }

        public DB.CAT_Catalogue SelectedCatalogue
        {
            get { return ((DB.CAT_Catalogue)BindingSource.DataSource); }
        }

        public DB.CAT_Category SelectedCategory
        {
            get { return ((DB.CAT_Category)tlCategory.GetDataRecordByNode(tlCategory.FocusedNode)); }
        }

        public DB.CAT_Meta SelectedMeta
        {
            get { return ((DB.CAT_Meta)grvMeta.GetFocusedRow()); }
        }

        /// <summary>
        /// Gets the Id of the current selected Category (Entry Type)
        /// </summary>
        /// <remarks>Created: Werner Scheffer 23/08/2012</remarks>
        private Int64 DataCurrentCategoryId { get { return (Int64)ddlTopCategory.EditValue; } }

        /// <summary>
        /// Gets the Id of the current selected Sub Item
        /// </summary>
        /// <remarks>Created: Werner Scheffer 23/08/2012</remarks>
        //private Int64 DataCurrentChildItem { get { return (Int64)((DB.CAT_Item)DataContext.EntityCatalogueContext.CAT_Item.Where(n => n.Id == Convert.ToInt64((grdItemData.Tag as Int64?[])[0]))).Id; } }

        /// <summary>
        /// Gets the Id of the current selected Sub Category
        /// </summary>
        /// <remarks>Created: Werner Scheffer 23/08/2012</remarks>
        private Int64 DataCurrentChildCategoryId { get { return (Int64)tlCategoryData.FocusedNode.GetValue(tlCategoryData.KeyFieldName); } }

        private Int64 DataCurrentParentItemId { 
            get { 
                return SelectedEntity == null ? -1 : (Int64)(SelectedEntity as DataRowView)["Id"]; 
            } 
        }

        private DB.VW_MetaData DataCurrentMetaData { get { return grvMetaData.GetFocusedRow() as DB.VW_MetaData; } }
         
        private void btnImageLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (Essential.OpenFolderDialogue ofd = new Essential.OpenFolderDialogue())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    ((DB.CAT_Catalogue)BindingSource.DataSource).ImageDestination = ofd.FolderLocation;
            }

        }

        private void tcgCatalogue_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            SetActiveTab();
        }

        private void btnAddCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DB.CAT_Category newCategory = BL.CAT.CAT_Category.New;
                newCategory.CAT_Catalogue = ((DB.CAT_Catalogue)BindingSource.DataSource);

                BL.EntityController.SaveCAT_Category(newCategory, DataContext);
                //Werner
                //I realy dont want to do this but if the Category does not have an ID you cant place a child under it
                //Need to find a way to do it in some kind of transaction to reserve the IDs but should be able to rollback
                OnSaveRecord();
                BindingSourceCategory.Add(newCategory);

            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnAddMeta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DB.CAT_Meta newMeta = BL.CAT.CAT_Meta.New;
                newMeta.CategoryId = ((DB.CAT_Category)tlCategory.GetDataRecordByNode(tlCategory.FocusedNode)).Id;
                newMeta.SortOrder = BindingSourceMeta.Count + 1;
                BL.EntityController.SaveCAT_Meta(newMeta, DataContext);
                //Werner
                //I realy dont want to do this but if the Category does not have an ID you cant place a child under it
                //Need to find a way to do it in some kind of transaction to reserve the IDs but should be able to rollback
                OnSaveRecord();
                BindingSourceMeta.Add(newMeta);

                DataContext.EntityCatalogueContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [CDS_CAT].CAT_MetaData {0} SELECT DISTINCT [CDS_CAT].CAT_Meta.Id, [CDS_CAT].CAT_ItemData.ItemId, [CDS_CAT].CAT_Category.Id, '', GETDATE(), 1 FROM [CDS_CAT].CAT_Category INNER JOIN [CDS_CAT].CAT_Meta on [CDS_CAT].CAT_Category.Id = [CDS_CAT].CAT_Meta.CategoryId INNER JOIN [CDS_CAT].CAT_ItemData ON [CDS_CAT].CAT_ItemData.CategoryId = [CDS_CAT].CAT_Category.Id LEFT JOIN [CDS_CAT].CAT_MetaData ON [CDS_CAT].CAT_MetaData.MetaId = [CDS_CAT].CAT_Meta.Id AND [CDS_CAT].CAT_MetaData.CategoryId = [CDS_CAT].CAT_Category.Id WHERE Data IS NULL AND [CDS_CAT].CAT_Meta.Id = {1}", Environment.NewLine, newMeta.Id));
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnRemoveCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SelectedCategory == null)
                    return;

                DialogResult result;
                if (tlCategory.FocusedNode.HasChildren)
                {
                    result = Essential.BaseAlertExtended.ShowAlert("Delete", "You are about to delete the selected category do you wich to delete all child categories ?", Essential.BaseAlertExtended.Buttons.YesNoCancel, Essential.BaseAlertExtended.Icons.Question);
                }
                else
                {
                    result = Essential.BaseAlertExtended.ShowAlert("Delete", "You are about to delete the selected category.\nContinue ?", Essential.BaseAlertExtended.Buttons.YesCancel, Essential.BaseAlertExtended.Icons.Question);
                }

                switch (result)
                {
                    //Delete Children
                    case System.Windows.Forms.DialogResult.Yes:
                        DataContext.EntityCatalogueContext.CAT_Category.RemoveRange(GetCategoriesRecursive(tlCategory.FocusedNode));
                        OnSaveRecord();
                        BindData();
                        break;
                    //Delete selected category only
                    case System.Windows.Forms.DialogResult.No:

                        Parallel.ForEach(tlCategory.FocusedNode.Nodes, node =>
                        //foreach (TreeListNode node in tlCategory.FocusedNode.Nodes)
                        {
                            ((DB.CAT_Category)tlCategory.GetDataRecordByNode(node)).CategoryId = null;
                        });

                        DataContext.EntityCatalogueContext.CAT_Category.Remove((DB.CAT_Category)tlCategory.GetDataRecordByNode(tlCategory.FocusedNode));
                        OnSaveRecord();
                        BindData();
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private IEnumerable<DB.CAT_Category> GetCategoriesRecursive(TreeListNode node)
        {
            foreach (var childNode in GetCategoriesNodesRecursive(node))
            {
                yield return (DB.CAT_Category)tlCategory.GetDataRecordByNode(node);
            }
        }

        private IEnumerable<TreeListNode> GetCategoriesNodesRecursive(TreeListNode node)
        {
            yield return node;

            foreach (TreeListNode childNode in node.Nodes)
            {
                foreach (TreeListNode n in GetCategoriesNodesRecursive(childNode))
                {
                    yield return n;
                }
            }

            //if (node.HasChildren)
            //    GetCategoriesRecursive(node);         
        }

        private void btnRemoveMeta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SelectedMeta == null)
                    return;

                switch (Essential.BaseAlertExtended.ShowAlert("Delete", "You are about to delete the selected meta.\nContinue ?", Essential.BaseAlertExtended.Buttons.YesCancel, Essential.BaseAlertExtended.Icons.Question))
                {
                    //Delete Children
                    case System.Windows.Forms.DialogResult.Yes:
                        DataContext.EntityCatalogueContext.CAT_Meta.Remove(SelectedMeta);
                        DataContext.EntityCatalogueContext.CAT_MetaData.RemoveRange(DataContext.EntityCatalogueContext.CAT_MetaData.Where(n => n.MetaId == SelectedMeta.Id));
                        OnSaveRecord();
                        BindData();
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        private void btnAddEntity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AddCatalogueEntityDialogue dlg = new AddCatalogueEntityDialogue())
            {
                dlg.TopCategoryId = SelectedTopCategory == null ? null : (Int64?)SelectedTopCategory.Id;
                //I wanted to do this but the problem is with the Async load on the ddlCategory SearchLookupEdit
                //you cant get the Category form the Context befause the Async load has a DataReader open
                //and you can get it form the ddlCategory.View because it isn't populated yet
                dlg.CatalogueId = ((DB.CAT_Catalogue)BindingSource.DataSource).Id;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                        {
                            try
                            {
                                using (TransactionScope transaction = DataContext.GetTransactionScope())
                                {
                                    DB.CAT_Item item = dlg.Item;
                                    DB.CAT_ItemData itemData = BL.CAT.CAT_ItemData.New;
                                    itemData.CategoryId = dlg.TopCategoryId.Value;
                                    //item.CAT_ItemData.Add(itemData);
                                    Parallel.ForEach(dlg.ListEntryMeta, entrymeta =>
                                    //foreach (EntryMeta entryData in dlg.ListEntryMeta)
                                    {
                                        DB.CAT_MetaData metaData = BL.CAT.CAT_MetaData.New;
                                        metaData.MetaId = entrymeta.Id;
                                        metaData.Data = (string)entrymeta.Value;
                                        metaData.CategoryId = entrymeta.CategoryId;
                                        item.CAT_MetaData.Add(metaData);
                                    });

                                    BL.EntityController.SaveCAT_Item(item, DataContext);
                                    DataContext.SaveChangesEntityCatalogueContext();

                                    itemData.ItemId = item.Id;
                                    itemData.ParentItemId = item.Id;
                                    BL.EntityController.SaveCAT_ItemData(itemData, DataContext);
                                    DataContext.SaveChangesEntityCatalogueContext();
                                    DataContext.SaveChangesEntitySystemContext();
                                    DataContext.CompleteTransaction(transaction);
                                }
                                DataContext.EntityCatalogueContext.AcceptAllChanges();
                                DataContext.EntitySystemContext.AcceptAllChanges();
                                InstantFeedbackSourceEntity.Refresh();
                            }
                            catch (Exception ex)
                            {
                                DataContext.EntityCatalogueContext.RejectChanges();
                                DataContext.EntitySystemContext.RejectChanges();
                                HasErrors = true;
                                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //DataContext.EntityAccountingContext.RollBackTransaction();
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }


                }
            }

        }

        private void btnAddItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AddCatalogueItemDialogue dlg = new AddCatalogueItemDialogue())
            {
                dlg.TreeGridDataSource = tlCategory.DataSource;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                        {
                            try
                            {

                                using (TransactionScope transaction = DataContext.GetTransactionScope())
                                {
                                    //Link Meta Data to item
                                    Parallel.ForEach(dlg.MetaData, n =>
                                    {
                                        //dlg.MetaData.ForEach(n => dlg.Item.CAT_MetaData.Add(n));
                                        dlg.Item.CAT_MetaData.Add(n);
                                    });
                                    dlg.Item.CAT_ItemData.Add(dlg.ItemData);
                                    dlg.ItemData.ParentItemId = Convert.ToInt64(((System.Data.DataRowView)(ddlEntity.Properties.View.GetFocusedRow())).Row["Id"]);
                                    BL.EntityController.SaveCAT_Item(dlg.Item, DataContext);
                                    DataContext.SaveChangesEntityCatalogueContext();
                                    DataContext.SaveChangesEntitySystemContext();
                                    DataContext.CompleteTransaction(transaction);
                                }
                                DataContext.EntityCatalogueContext.AcceptAllChanges();
                                DataContext.EntitySystemContext.AcceptAllChanges();
                                InstantFeedbackSourceEntity.Refresh();
                            }
                            catch (Exception ex)
                            {
                                DataContext.EntityCatalogueContext.RejectChanges();
                                DataContext.EntitySystemContext.RejectChanges();
                                HasErrors = true;
                                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //DataContext.EntityAccountingContext.RollBackTransaction();
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }


                }
            }
        }

        private void btnRemoveEntity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRemoveItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void tlCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (SelectedCategory != null)
                BindingSourceMeta.DataSource = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == SelectedCategory.Id).ToList();
        }

        private void InstantFeedbackSourceCategory_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.EntityCatalogueContext.CAT_Category.Where(n => n.CategoryId == null);
        }

        private IQueryable EntityQuery()
        {
            if (SelectedTopCategory != null)
            {
                string mparams = String.Join(",", DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == SelectedTopCategory.Id).ToList().Select(n => " [" + n.Id + "]"));
                string asdas = "SELECT Id, Name, " + mparams +
                           "FROM (" +
                                   "select [CDS_CAT].CAT_Item.Id, Name, MetaId, Data from [CDS_CAT].CAT_MetaData " +
                                   "inner join [CDS_CAT].CAT_Item ON [CDS_CAT].CAT_MetaData.ItemId=[CDS_CAT].CAT_Item.Id " +
                                       "inner join [CDS_CAT].CAT_ItemData ON [CDS_CAT].CAT_ItemData.ItemId=[CDS_CAT].CAT_Item.Id " +
                                           "where [CDS_CAT].CAT_ItemData.CategoryId=" + SelectedTopCategory.Id +
                                 ") p PIVOT ( MIN (Data) FOR MetaId IN ( " + mparams + " ) ) AS pvt ORDER BY pvt.Name";

                System.Data.Common.DbCommand cmd = DataContext.EntityCatalogueContext.Database.Connection.CreateCommand();
                cmd.CommandText = asdas;
                DataContext.EntityCatalogueContext.Database.Connection.Open();

                return DataContext.ReadonlyContext.Database.SqlQuery<List<object>>(
                        "SELECT Id, Name, " + mparams +
                            "FROM (" +
                                    "select [CDS_CAT].CAT_Item.Id, Name, MetaId, Data from [CDS_CAT].CAT_MetaData " +
                                    "inner join [CDS_CAT].CAT_Item ON [CDS_CAT].CAT_MetaData.ItemId=[CDS_CAT].CAT_Item.Id " +
                                        "inner join [CDS_CAT].CAT_ItemData ON [CDS_CAT].CAT_ItemData.ItemId=[CDS_CAT].CAT_Item.Id " +
                                            "where [CDS_CAT].CAT_ItemData.CategoryId=" + SelectedTopCategory.Id +
                                  ") p PIVOT ( MIN (Data) FOR MetaId IN ( " + mparams + " ) ) AS pvt ORDER BY pvt.Name").AsQueryable();
            }
            return null;
        }

        private void InstantFeedbackSourceEntity_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = EntityQuery();
        }

        private void ddlTopCategory_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ddlEntity.EditValue = null;
                if (SelectedTopCategory == null)
                    return;


                ddlEntity.Properties.View.Columns.Clear();
                ddlEntity.Properties.View.Columns.Add(colTopCategoryName);
                colTopCategoryName.Visible = true;
                colTopCategoryName.VisibleIndex = 0;

                //var catitems = DataContext.CAT_ItemDatas.Where(n => n.CategoryId == (Int64)ddlTopCategories.EditValue).Select(n => n.ItemId).ToList();
                //var catitems2 = DataContext.CAT_ItemDatas.Where(n => n.CategoryId == (Int64)ddlTopCategories.EditValue).Select(n => n.ItemId).Distinct().ToList();


                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == SelectedTopCategory.Id).OrderBy(n => n.SortOrder);

                int cnt = 1;
                //Parallel.ForEach(metadata, meta =>
                foreach (var meta in metadata)
                {
                    DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsColumn.AllowEdit = false;
                    column.Name = meta.Name;
                    column.Visible = true;
                    column.FieldName = meta.Id.ToString();
                    column.Caption = meta.Name;
                    column.VisibleIndex = cnt++;

                    ddlEntity.Properties.View.Columns.Add(column);
                }//);


                Parallel.ForEach(metadata.Where(n => n.Grouped.Value).OrderBy(n => n.SortOrder), meta =>
                //foreach (var meta in metadata.Where(n => n.Grouped.Value).OrderBy(n => n.SortOrder))
                {
                    ddlEntity.Properties.View.Columns[meta.Id.ToString()].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
                    ddlEntity.Properties.View.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(ddlEntity.Properties.View.Columns[meta.Id.ToString()], DevExpress.Data.ColumnSortOrder.Ascending));
                });
                this.ddlEntity.Properties.View.GroupCount = metadata.Where(n => n.Grouped.Value).Count();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

            try
            {

                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == SelectedTopCategory.Id);

                DataTable tblResult = new DataTable();
                string mparams = String.Join(",", metadata.ToList().Select(n => "[" + n.Id + "]"));
                if (mparams.Equals(string.Empty))
                    return;

                if (metadata.Count() > 0)
                {
                    //InstantFeedbackSourceEntity = new DevExpress.Data.Linq.LinqInstantFeedbackSource(InstantFeedbackSourceEntity_GetQueryable);
                    //InstantFeedbackSourceEntity_GetQueryable(InstantFeedbackSourceEntity, new DevExpress.Data.Linq.GetQueryableEventArgs() { KeyExpression = "Id"});
                    //InstantFeedbackSourceEntity.Refresh(); 
                    System.Data.SqlClient.SqlDataAdapter adapter = BL.ApplicationDataContext.Instance.GetAdapter(
                    "SELECT Id, Name, " + mparams +
                        "FROM (" +
                                "select CAT_Item.Id, Name, MetaId, Data from [CDS_CAT].CAT_MetaData " +
                                "inner join [CDS_CAT].CAT_Item ON CAT_MetaData.ItemId=CAT_Item.Id " +
                                    "left join [CDS_CAT].CAT_ItemData ON CAT_ItemData.ItemId=CAT_Item.Id " +
                                        "where CAT_MetaData.CategoryId=" + ddlTopCategory.EditValue +
                              ") p PIVOT ( MIN (Data) FOR MetaId IN ( " + mparams + " ) ) AS pvt ORDER BY pvt.Name");
                    adapter.Fill(tblResult);
                }
                BindingSourceTopEntities.DataSource = tblResult;
                //ddlEntity.CalcBestSize();
                //ddlEntity.Properties.PopulateViewColumns();


            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private List<Int64> GetTreeIds(List<CategoryItem> items, Int64? parentid)
        {
            try
            {
                List<Int64> children = items.Where(n => n.CategoryId == parentid).Select(n => n.Id).ToList();
                List<Int64> subchildren = new List<long>();
                Parallel.ForEach(children, i =>
                //foreach (Int64 i in children)
                {
                    subchildren.AddRange(GetTreeIds(items, i));
                });
                subchildren.AddRange(children);

                return subchildren;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        private void ddlEntity_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Essential.UTL.WaitCursor())
                {
                    if (ddlEntity.EditValue == null || Convert.ToInt64(ddlEntity.EditValue) == 0)
                        return;

                    // TODO: Select only the categories that are valid for the selected top category : (Int64)ddlTopCategories.EditValue
                    List<CategoryItem> categories_with_items = DataContext.EntityCatalogueContext.CAT_Category.Where(n => (n.CategoryId != null || n.Id == SelectedTopCategory.Id) && n.CatalogueId == SelectedCatalogue.Id).Select(n => new CategoryItem { Id = n.Id, Name = n.Name, CategoryId = n.CategoryId, Items = "" }).OrderBy(n => n.Name).ToList();
                    //List<Int64> treeids = GetTreeIds(categories_with_items, DataContext.CAT_Categories.Where(n=>n.Id == (Int64)ddlTopCategories.EditValue).FirstOrDefault().CategoryId);
                    List<Int64> treeids = new List<Int64>();
                    treeids.Add(SelectedTopCategory.Id);
                    treeids.AddRange(GetTreeIds(categories_with_items, SelectedTopCategory.Id));
                    categories_with_items = categories_with_items.Where(n => treeids.Contains(n.Id)).ToList();

                    var item_datas = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.ParentItemId == DataCurrentParentItemId || n.ItemId == DataCurrentParentItemId).Join(DataContext.EntityCatalogueContext.CAT_Item, x => x.ItemId, y => y.Id, (a, b) => new { a.CategoryId, b.Name }).Distinct();

                    Parallel.ForEach(item_datas, itemdata =>
                    //foreach (var itemdata in item_datas)
                    {
                        CategoryItem category_item = categories_with_items.Where(n => n.Id == itemdata.CategoryId).FirstOrDefault();

                        if (category_item != null)
                            category_item.Items = (category_item.Items.Length > 0) ? (category_item.Items + ", " + itemdata.Name) : (itemdata.Name);
                    });

                    DataTable tblResult = new DataTable();
                    tblResult.Columns.Add("Id", typeof(Int64));
                    tblResult.Columns.Add("Name", typeof(String));
                    tblResult.Columns.Add("CategoryId", typeof(Int64));
                    tblResult.Columns.Add("Items", typeof(String));

                    //Werner: The Parallel.ForEach freaks out when you change the Entity to fast and adds a duplicate 
                    //Parallel.ForEach(categories_with_items, i =>
                    foreach (CategoryItem i in categories_with_items)
                    {

                        tblResult.Rows.Add(new object[] { i.Id, i.Name, i.CategoryId, i.Items });
                    }//);

                    if (tblResult.Rows.Count > 0)
                    {
                        tlCategoryData.DataSource = tblResult;

                        tlCategoryData.CollapseAll();
                        if (tlCategoryData.Nodes.Count > 0)
                        {
                            tlCategoryData.Nodes[0].Selected = true;
                            tlCategoryData.Nodes[0].Expanded = true;
                        }

                    }
                    tlCategoryData.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ddlTopCategoryView_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            //if (hi.InRowCell) MessageBox.Show(view.GetRowCellValue(view.FocusedRowHandle, "Id").ToString());
             
            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            SelectedTopCategory = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(view.GetFocusedRow())).OriginalRow as DB.CAT_Category;
        }

        private void ddlTopCategoryView_KeyDown(object sender, KeyEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            //if (hi.InRowCell) MessageBox.Show(view.GetRowCellValue(view.FocusedRowHandle, "Id").ToString());

            if (view.GetFocusedRow() != null)
                while (view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                {
                    Application.DoEvents();
                }

            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            SelectedTopCategory = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(view.GetFocusedRow())).OriginalRow as DB.CAT_Category;
        }


        private void ddlEntityView_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            //if (hi.InRowCell) MessageBox.Show(view.GetRowCellValue(view.FocusedRowHandle, "Id").ToString());

            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            SelectedEntity = view.GetFocusedRow();
        }

        private void ddlEntityView_KeyDown(object sender, KeyEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            //if (hi.InRowCell) MessageBox.Show(view.GetRowCellValue(view.FocusedRowHandle, "Id").ToString());

            while (view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
            {
                Application.DoEvents();
            }

            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            SelectedEntity = view.GetFocusedRow();
        } 

        private void InstantFeedbackSourceDataItemStockCode_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new byte[] { (byte)BL.SYS.SYS_Type.BuyOut, (byte)BL.SYS.SYS_Type.Message }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory ));
        }

        private void tlCategoryData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                var value = (tlCategoryData.GetDataRecordByNode(tlCategoryData.FocusedNode));
                var tempContext = DataContext.ReadonlyContext;
                var itemdata = tempContext.VW_ItemData.Where(n => n.CatalogueId == SelectedCatalogue.Id && n.ParentItemId == DataCurrentParentItemId && n.CategoryId == DataCurrentChildCategoryId);
               
                if (itemdata.Count() == 0) 
                {
                    BindingSourceMetaData.DataSource = null;
                    return;
                }

                var itemIds = itemdata.Select(l => l.ItemId).ToList();
                var metadata = tempContext.VW_MetaData.Where(n => n.CategoryId == DataCurrentChildCategoryId && itemIds.Contains(n.ItemId));

                BindingSourceMetaData.DataSource = metadata.ToList();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvMetaData_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if ((grvMetaData.GetRow(e.RowHandle) as DB.VW_MetaData).Type.Equals("Image") && grvMetaData.FocusedColumn == colMetaDataData)
                e.RepositoryItem = repImageLocation;
        }

        private void repImage_EditValueChanged(object sender, EventArgs e)
        {

            DataCurrentMetaData.Data = DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\" + DataCurrentMetaData.ItemName + ".png";

            if (!System.IO.Directory.Exists(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\"))
                System.IO.Directory.CreateDirectory(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\");

            (sender as DevExpress.XtraEditors.PictureEdit).Image.Save(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\" + DataCurrentMetaData.ItemName + ".png", ImageFormat.Jpeg);
        }

        private void grvMetaData_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

        }

        private void repImageLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    DataCurrentMetaData.Data = DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\" + DataCurrentMetaData.ItemName + ".png";

                    if (!System.IO.Directory.Exists(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\"))
                        System.IO.Directory.CreateDirectory(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\");

                    if (File.Exists(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\" + DataCurrentMetaData.ItemName + ".png"))
                        File.Delete(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\" + DataCurrentMetaData.ItemName + ".png");

                    Image.FromFile(dlg.FileName).Save(imageLocation + DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\" + DataCurrentMetaData.ItemName + ".png", ImageFormat.Png);
                    grvMetaData.SetFocusedRowCellValue(colMetaDataData, DataCurrentMetaData.Grouping + @"\" + DataCurrentMetaData.Name + @"\" + DataCurrentMetaData.ItemName + ".png");
                    ValidateLayout();
                }
            }
        }

        private void grvMetaData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            //Make changes to Context Object for Data Values
            if (grvMetaData.FocusedColumn == colMetaDataData)
                DataContext.EntityCatalogueContext.CAT_MetaData.FirstOrDefault(n => n.Id == DataCurrentMetaData.Id).Data = DataCurrentMetaData.Data;

            //Make changes to Context Object for Item Name Values
            if (grvMetaData.FocusedColumn == colItemName)
            {
                (BindingSourceMetaData.DataSource as List<DB.VW_MetaData>).ForEach(n => { if (n.ItemId == DataCurrentMetaData.ItemId) { n.ItemName = DataCurrentMetaData.ItemName; DataContext.EntityCatalogueContext.CAT_Item.FirstOrDefault(nn => nn.Id == n.ItemId).Name = n.ItemName; } });
                grdMetaData.RefreshDataSource();
            }

        }

        private void grvMetaData_DoubleClick(object sender, EventArgs e)
        {
            if (DataCurrentMetaData.Data.Equals(string.Empty))
                return;

            using (ViewImageDialogue dlg = new ViewImageDialogue())
            {
                try
                {
                    if (DataCurrentMetaData.Type.Equals("Image"))
                        dlg.Image = Image.FromFile(imageLocation + DataCurrentMetaData.Data);
                }
                catch (Exception ex)
                { }

                if (dlg.Image != null)
                    dlg.ShowDialog();
            }
        }

        private void grvMetaData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != null && e.CellValue.ToString().Contains(".png") && DataCurrentMetaData.Type.Equals("Image") && e.Column == colMetaDataData)
            {
                e.DisplayText = "Double click row to view image";
            }
        }       
 
        GridHitInfo downHitInfo = null;

        private void grvMeta_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridView view = sender as GridView;

            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

            if (Control.ModifierKeys != Keys.None) return;

            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)

                downHitInfo = hitInfo;
        }

        private void grvMeta_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {

                Size dragSize = SystemInformation.DragSize;

                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,

                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);



                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {

                    view.GridControl.DoDragDrop(view.GetFocusedRow(), DragDropEffects.Move);

                    downHitInfo = null;

                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                }

            }
        }

        private void grdMeta_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))

                e.Effect = DragDropEffects.Move;

            else

                e.Effect = DragDropEffects.None;
        }

        private void grdMeta_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GridControl grid = sender as GridControl;

            DataTable table = grid.DataSource as DataTable;

            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;

            if (row != null && table != null && row.Table != table)
            {

                table.ImportRow(row);

                row.Delete();

            }
        } 
    } 
} 