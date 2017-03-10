using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CDS.Client.Desktop.Essential.UTL;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    public partial class CatalogueForm : CDS.Client.Desktop.Essential.BaseForm
    {
        public DB.VW_Company Entity { get; set; }
        public BL.ORG.ORG_Type Type { get; set; }
        private static CatalogueForm instance = null;
        private static object SelectedEntity { get; set; }
        List<EntryMeta> entryMetaList = new List<EntryMeta>();
        String imageLocation = @"C:\Catalogue\";
        DB.VW_Catalogue selectedCatalogue;
        string previousTopCategory = "";
        bool generating = false;

        public CatalogueForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CatalogueForm is a singleton class and only one ManageMetaDataForm should exist at any one time.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 02/05/2012</remarks>
        public static CatalogueForm Instance
        {
            get
            {
                if (instance == null)
                    instance = new CatalogueForm();

                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Created: Werner Scheffer 02/05/2012</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                //ddlCatalogue.EditValue = DataContext.EntityCatalogueContext.CAT_Catalogue.OrderBy(n => n.Id).Select(n => n.Id).FirstOrDefault();
                ////ddlTopCategories.EditValue = DataContext.EntityCatalogueContext.CAT_Category.OrderBy(n => n.Name).Where(n => n.CategoryId == null).Select(n => n.Id).FirstOrDefault();

                //// TODO :  If you want to default to "VEHICLE" a setting should be created
                ////ddlTopCategories.EditValue = DataContext.EntityCatalogueContext.CAT_Category.OrderBy(n => n.Name).Where(n => n.Name == "VEHICLE").Select(n => n.Id).FirstOrDefault();

                ////This has been moved to SetTag as we need to reset Category when form reopenes
                ////ddlTopCategories.EditValue = DataContext.EntityCatalogueContext.CAT_Category.OrderBy(n => n.Name).Where(n => n.CategoryId == null &&n.CatalogueId == (Int64)ddlCatalogue.EditValue).OrderBy(n=>n.Name).Select(n => n.Id).FirstOrDefault();
                imageLocation = DataContext.EntityCatalogueContext.CAT_Catalogue.OrderBy(n => n.Id).Select(n => n.ImageDestination).FirstOrDefault() + @"\";


                int nameLength = Entity.Name.Length;

                this.Text = "Cat - " + Entity.Name.Substring(0, nameLength < 10 ? nameLength : 10);

                if (ddlCatalogue.EditValue == null || ddlCatalogue.EditValue.GetType() == typeof(String))
                {
                    ddlCatalogue.EditValue = DataContext.EntityCatalogueContext.CAT_Catalogue.OrderBy(c => c.Id).Select(c => c.Id).FirstOrDefault();
                    ddlTopCategories.EditValue = DataContext.EntityCatalogueContext.CAT_Category.OrderBy(n => n.Name).Where(n => n.CategoryId == null && n.CatalogueId == DataContext.EntityCatalogueContext.CAT_Catalogue.OrderBy(c => c.Id).Select(c => c.Id).FirstOrDefault()).OrderBy(n => n.Name).Select(n => n.Id).FirstOrDefault();
                    ddlTopItemCategories.EditValue = ddlTopCategories.EditValue;
                }
                else
                {
                    ddlTopCategories.EditValue = DataContext.EntityCatalogueContext.CAT_Category.OrderBy(n => n.Name).Where(n => n.CategoryId == null && n.CatalogueId == (Int64)ddlCatalogue.EditValue).OrderBy(n => n.Name).Select(n => n.Id).FirstOrDefault();
                    ddlTopItemCategories.EditValue = ddlTopCategories.EditValue;
                }


            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ddlTopCategories_KeyUp(null, new KeyEventArgs(Keys.Enter));
        }


        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = false;
            AllowArchive = false;
        }

        public void ChangeCompany(object parentForm)
        {
            /*ddlCatalogue.EditValue = DataContext.EntityCatalogueContext.CAT_Catalogue.OrderBy(c => c.Id).Select(c => c.Id).FirstOrDefault();
            ddlTopCategories.EditValue = DataContext.EntityCatalogueContext.CAT_Category.OrderBy(n => n.Name).Where(n => n.CategoryId == null && n.CatalogueId == DataContext.EntityCatalogueContext.CAT_Catalogue.OrderBy(c => c.Id).Select(c => c.Id).FirstOrDefault()).OrderBy(n => n.Name).Select(n => n.Id).FirstOrDefault();
            ddlTopItemCategories.EditValue = ddlTopCategories.EditValue;
            OnStart();*/
        }

        public DevExpress.XtraEditors.PanelControl ImageContainer(Image image)
        {
            DevExpress.XtraEditors.PictureEdit imagePreviewimage = new DevExpress.XtraEditors.PictureEdit();
            imagePreviewimage.Dock = System.Windows.Forms.DockStyle.Fill;
            imagePreviewimage.Location = new System.Drawing.Point(0, 0);
            imagePreviewimage.MenuManager = this.RibbonControl;
            imagePreviewimage.Name = "imagePreviewimage";
            imagePreviewimage.Size = new System.Drawing.Size(200, 100);
            imagePreviewimage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            imagePreviewimage.TabIndex = 0;
            imagePreviewimage.Image = image;
            imagePreviewimage.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            imagePreviewimage.Properties.ShowScrollBars = true;
            DevExpress.XtraEditors.PanelControl imagePreview = new DevExpress.XtraEditors.PanelControl();
            imagePreview.Controls.Add(imagePreviewimage);
            imagePreview.Location = new System.Drawing.Point(655, 404);
            imagePreview.Name = "imagePreview";
            imagePreview.Size = new System.Drawing.Size(200, 100);
            imagePreview.TabIndex = 18;

            imagePreviewimage.DoubleClick += new EventHandler(imagePreviewimage_DoubleClick);
            return imagePreview;
        }

        private Int64 DataCurrentCategory { get { return (Int64)ddlTopCategories.EditValue; } }
        private Int64 DataCurrentParentItem { get { return (Int64)((DataRowView)SelectedEntity /*grvParents.GetFocusedRow()*/)["Id"]; } }

        private Int64 DataCurrentCategorySearch { get { return (Int64)ddlTopItemCategories.EditValue; } }
        private Int64 DataCurrentParentItemSearch { get { return (Int64)((DataRowView)grvItemParents.GetFocusedRow())["Id"]; } }

        //private Int64 DataCurrentChildItem { get { try{return (Int64)((EntryItem)BindingSourceItem.DataSource).ItemId; } catch (Exception ex){return -1;}} }
        private Int64 DataCurrentChildCategory { get { return (Int64)treDataCategories.FocusedNode.GetValue(treDataCategories.KeyFieldName); } }

        private DB.VW_Catalogue GetSelectedCatalogue
        {
            get
            {
                if (Convert.ToInt64(ddlCatalogue.EditValue) == 0)
                    return null;

                return SelectedCatalogue;//(DB.CAT_Catalogue)ddlCatalogue.GetSelectedDataRow() ?? DataContext.EntityCatalogueContext.CAT_Catalogue.Where(n => n.Id == (Int64)ddlCatalogue.EditValue).FirstOrDefault();
            }
        }

        private void RefreshEntries()
        {
            try
            {
                grvParents.Columns.Clear();
                grvParents.Columns.Add(colName2);
                colName2.Visible = true;
                colName2.VisibleIndex = 0;

                //var catitems = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == (Int64)ddlTopCategories.EditValue).Select(n => n.ItemId).ToList();


                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)ddlTopCategories.EditValue).OrderBy(n => n.SortOrder);

                int cnt = 1;
                foreach (var meta in metadata)
                {
                    GridColumn column = new GridColumn();
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsColumn.AllowEdit = false;
                    column.Name = meta.Name;
                    column.Visible = true;
                    column.FieldName = meta.Id.ToString();
                    column.Caption = meta.Name;
                    column.VisibleIndex = cnt++;

                    grvParents.Columns.Add(column);
                }


                foreach (var meta in metadata.Where(n => n.Grouped.Value).OrderBy(n => n.SortOrder))
                {
                    grvParents.Columns[meta.Id.ToString()].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
                    grvParents.SortInfo.Add(new GridColumnSortInfo(grvParents.Columns[meta.Id.ToString()], DevExpress.Data.ColumnSortOrder.Ascending));
                }
                this.grvParents.GroupCount = metadata.Where(n => n.Grouped.Value).Count();

                #region ddlEntityView
                ddlEntityView.Columns.Clear();
                ddlEntityView.Columns.Add(colName2);
                colName2.Visible = true;
                colName2.VisibleIndex = 0;

                //var catitems = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == (Int64)ddlTopCategories.EditValue).Select(n => n.ItemId).ToList();

                cnt = 1;
                foreach (var meta in metadata)
                {
                    GridColumn column = new GridColumn();
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsColumn.AllowEdit = false;
                    column.Name = meta.Name;
                    column.Visible = true;
                    column.FieldName = meta.Id.ToString();
                    column.Caption = meta.Name;
                    column.VisibleIndex = cnt++;

                    ddlEntityView.Columns.Add(column);
                }


                foreach (var meta in metadata.Where(n => n.Grouped.Value).OrderBy(n => n.SortOrder))
                {
                    ddlEntityView.Columns[meta.Id.ToString()].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
                    ddlEntityView.SortInfo.Add(new GridColumnSortInfo(grvParents.Columns[meta.Id.ToString()], DevExpress.Data.ColumnSortOrder.Ascending));
                }
                ddlEntityView.GroupCount = metadata.Where(n => n.Grouped.Value).Count();
                #endregion
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void InitialiseItemGrids()
        {
            try
            {
                // Set up structure
                //var catitems = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == (Int64)ddlTopCategories.EditValue).Select(n => n.ItemId).ToList();
                var metas = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)DataCurrentChildCategory).OrderBy(n => n.SortOrder).ThenBy(n => n.Name).ToList();
                grdComparison.Rows.Clear();
                grdItemData.Rows.Clear();

                // Create grouping rows
                DevExpress.XtraVerticalGrid.Rows.CategoryRow mastergroup = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
                mastergroup.Name = "main";
                mastergroup.Properties.ReadOnly = true;
                mastergroup.Properties.Caption = "Main Information";
                grdComparison.Rows.Add(mastergroup);

                mastergroup = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
                mastergroup.Name = "main";
                mastergroup.Properties.Caption = "Main Information";
                grdItemData.Rows.Add(mastergroup);

                List<DevExpress.XtraVerticalGrid.Rows.CategoryRow> groups = metas.OrderBy(n => n.SortOrder).Select(n => n.Grouping).Distinct().Select(n => new DevExpress.XtraVerticalGrid.Rows.CategoryRow() { Name = n }).ToList();
                foreach (DevExpress.XtraVerticalGrid.Rows.CategoryRow g in groups)
                    g.Properties.Caption = g.Name;
                grdComparison.Rows.AddRange(groups.ToArray());

                groups = metas.OrderBy(n => n.SortOrder).Select(n => n.Grouping).Distinct().Select(n => new DevExpress.XtraVerticalGrid.Rows.CategoryRow() { Name = n }).ToList();
                foreach (DevExpress.XtraVerticalGrid.Rows.CategoryRow g in groups)
                    g.Properties.Caption = g.Name;
                grdItemData.Rows.AddRange(groups.ToArray());

                // Create data rows
                DevExpress.XtraVerticalGrid.Rows.EditorRow row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("Name");
                row.Properties.Caption = "Item Name";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("ShortName");
                row.Properties.Caption = "Name";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("ShortName");
                row.Properties.Caption = "Name";
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("LocationMain");
                row.Properties.Caption = "Location";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("LocationMain");
                row.Properties.Caption = "Location";
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("StockType");
                row.Properties.Caption = "Stock Type";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("StockType");
                row.Properties.Caption = "Stock Type";
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("UnitPrice");
                row.Properties.Caption = "Unit Price";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("UnitPrice");
                row.Properties.Caption = "Unit Price";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("TotalAvailable");
                row.Properties.Caption = "Available";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("TotalAvailable");
                row.Properties.Caption = "Available";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdItemData.Rows["main"].ChildRows.Add(row);

                foreach (var meta in metas)
                {
                    if (meta.Type == "Image")
                    {


                        row = new DevExpress.XtraVerticalGrid.Rows.EditorRow(meta.Id.ToString() + ".1");
                        row.Properties.Caption = meta.Name;
                        row.Properties.RowEdit = imgItemImage;
                        grdComparison.Rows[meta.Grouping].ChildRows.Add(row);

                        row = new DevExpress.XtraVerticalGrid.Rows.EditorRow(meta.Id.ToString() + ".1");
                        row.Properties.RowEdit = imgItemImage;
                        row.Properties.Caption = meta.Name;
                        grdItemData.Rows[meta.Grouping].ChildRows.Add(row);
                    }
                    else
                    {
                        row = new DevExpress.XtraVerticalGrid.Rows.EditorRow(meta.Id.ToString());
                        //row.Enabled = false;
                        row.Properties.Caption = meta.Name;
                        grdComparison.Rows[meta.Grouping].ChildRows.Add(row);

                        row = new DevExpress.XtraVerticalGrid.Rows.EditorRow(meta.Id.ToString());
                        row.Properties.Caption = meta.Name;
                        grdItemData.Rows[meta.Grouping].ChildRows.Add(row);
                    }

                    //if (meta.Type == "Image")
                    //{
                    //    RepositoryItemGraphicsEdit repItemGraphicsEdit = new RepositoryItemGraphicsEdit();
                    //    repItemGraphicsEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                    //    row.Properties.RowEdit = repItemGraphicsEdit;
                    //}
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void LoadItemGrids()
        {
            try
            {
                // Fetch data for all items and alternates
                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)DataCurrentChildCategory);
                DataTable tblResult = new DataTable();
                string mparams = String.Join(",", metadata.Select(n => n.Id).ToList().Select(n => "[" + n + "]").ToList());


                var itemslist = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == DataCurrentChildCategory && (n.ParentItemId == DataCurrentParentItem || n.ItemId == DataCurrentParentItem)).Select(n => n.ItemId).ToList();

                if (itemslist.Count > 0)
                {
                    string mids = String.Join(",", itemslist);
                    SqlDataAdapter adapter = BL.ApplicationDataContext.Instance.GetAdapter("SELECT Id, EntityId, Name, ShortName, LocationMain, StockType,[CDS_SYS].fnDiscountForItem(" + Entity.Id + "," + (byte)Type + ",EntityId," +
                    ",0,1) UnitPrice, TotalAvailable,  " + mparams +
                    "FROM (select [CDS_CAT].CAT_Item.Id, [CDS_CAT].CAT_Item.EntityId, [CDS_CAT].CAT_Item.Name, MetaId, CASE WHEN [CDS_CAT].CAT_Meta.Type = 'Image' THEN '\' + Data ELSE Data END Data,           " +
                    "ShortName, LocationMain, StockType, [CDS_SYS].VW_LineItem.InventoryId, (ISNULL(OnHand,0) - ISNULL(OnReserve,0)) TotalAvailable                          " +
                    "from                                                                                                                             " +
                    "[CDS_CAT].CAT_Item inner join                                                                                                              " +
                    "[CDS_CAT].CAT_ItemData ON [CDS_CAT].CAT_ItemData.ItemId=[CDS_CAT].CAT_Item.Id left join                                                                        " +
                    "[CDS_CAT].CAT_MetaData  ON [CDS_CAT].CAT_MetaData.ItemId=[CDS_CAT].CAT_Item.Id left join                                                                       " +
                    "[CDS_CAT].CAT_Meta ON [CDS_CAT].CAT_MetaData.MetaId=[CDS_CAT].CAT_Meta.Id left join                                                                            " +
                    "[CDS_SYS].VW_LineItem on [CDS_CAT].CAT_Item.EntityId=[CDS_SYS].VW_LineItem.Id " +
                    "where [CDS_CAT].CAT_ItemData.CategoryId=" + DataCurrentChildCategory + ") p                                                                    " +
                    "PIVOT (MIN (Data) FOR MetaId IN ( " + mparams + " ) ) AS pvt WHERE Id IN (" + mids + ") ORDER BY pvt.Name    ");
                    adapter.Fill(tblResult);

                    foreach (var m in metadata.Where(n => n.Type == "Image"))
                    {
                        tblResult.Columns.Add(new DataColumn(m.Id.ToString() + ".1", typeof(Image)));
                    }

                    for (int i = 0; i < tblResult.Rows.Count; i++)
                    {
                        var itemId = (Int64)tblResult.Rows[i]["Id"];
                        var item = DataContext.EntityCatalogueContext.CAT_Item.Where(n => n.Id == itemId).Select(n => n.Name).FirstOrDefault();

                        foreach (var m in metadata.Where(n => n.Type == "Image"))
                        {
                            //string path = tblResult.Rows[i][m.Id.ToString()].ToString();
                            string path = imageLocation + m.Grouping + @"\" + m.Name + @"\" + item + ".jpg";
                            if (System.IO.File.Exists(path))
                            {
                                using (System.IO.Stream stream = System.IO.File.OpenRead(path))
                                {
                                    tblResult.Rows[i][m.Id.ToString() + ".1"] = Image.FromStream(stream);
                                }
                            }
                        }
                    }
                    grdComparison.DataSource = tblResult;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void InitialiseItemGridsSearch()
        {
            try
            {
                // Set up structure
                var catitems = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == (Int64)ddlTopItemCategories.EditValue).Select(n => n.ItemId).ToList();
                var metas = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)DataCurrentChildCategory).OrderBy(n => n.SortOrder).ThenBy(n => n.Name).ToList();
                grdComparison.Rows.Clear();
                grdItemData.Rows.Clear();

                // Create grouping rows
                DevExpress.XtraVerticalGrid.Rows.CategoryRow mastergroup = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
                mastergroup.Name = "main";
                mastergroup.Properties.Caption = "Main Information";
                grdComparison.Rows.Add(mastergroup);

                mastergroup = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
                mastergroup.Name = "main";
                mastergroup.Properties.Caption = "Main Information";
                grdItemData.Rows.Add(mastergroup);

                List<DevExpress.XtraVerticalGrid.Rows.CategoryRow> groups = metas.OrderBy(n => n.SortOrder).Select(n => n.Grouping).Distinct().Select(n => new DevExpress.XtraVerticalGrid.Rows.CategoryRow() { Name = n }).ToList();
                foreach (DevExpress.XtraVerticalGrid.Rows.CategoryRow g in groups)
                    g.Properties.Caption = g.Name;
                grdComparison.Rows.AddRange(groups.ToArray());

                groups = metas.OrderBy(n => n.SortOrder).Select(n => n.Grouping).Distinct().Select(n => new DevExpress.XtraVerticalGrid.Rows.CategoryRow() { Name = n }).ToList();
                foreach (DevExpress.XtraVerticalGrid.Rows.CategoryRow g in groups)
                    g.Properties.Caption = g.Name;
                grdItemData.Rows.AddRange(groups.ToArray());

                // Create data rows
                DevExpress.XtraVerticalGrid.Rows.EditorRow row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("Name");
                row.Properties.Caption = "Item Name";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("ShortName");
                row.Properties.Caption = "Name";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("ShortName");
                row.Properties.Caption = "Name";
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("LocationMain");
                row.Properties.Caption = "Location";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("LocationMain");
                row.Properties.Caption = "Location";
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("StockType");
                row.Properties.Caption = "Stock Type";
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("StockType");
                row.Properties.Caption = "Stock Type";
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("UnitPrice");
                row.Properties.Caption = "Unit Price";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("UnitPrice");
                row.Properties.Caption = "Unit Price";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdItemData.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("TotalAvailable");
                row.Properties.Caption = "Available";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdComparison.Rows["main"].ChildRows.Add(row);

                row = new DevExpress.XtraVerticalGrid.Rows.EditorRow("TotalAvailable");
                row.Properties.Caption = "Available";
                row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                row.Properties.Format.FormatString = "N2";
                row.Appearance.Options.UseFont = true;
                row.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Bold);
                grdItemData.Rows["main"].ChildRows.Add(row);

                foreach (var meta in metas)
                {
                    row = new DevExpress.XtraVerticalGrid.Rows.EditorRow(meta.Id.ToString());
                    row.Properties.Caption = meta.Name;
                    grdComparison.Rows[meta.Grouping].ChildRows.Add(row);

                    if (meta.Type == "Image")
                    {
                        RepositoryItemGraphicsEdit repItemGraphicsEdit = new RepositoryItemGraphicsEdit();
                        repItemGraphicsEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                        row.Properties.RowEdit = repItemGraphicsEdit;
                    }

                    row = new DevExpress.XtraVerticalGrid.Rows.EditorRow(meta.Id.ToString());
                    row.Properties.Caption = meta.Name;
                    grdItemData.Rows[meta.Grouping].ChildRows.Add(row);


                    if (meta.Type == "Image")
                    {
                        RepositoryItemGraphicsEdit repItemGraphicsEdit = new RepositoryItemGraphicsEdit();
                        repItemGraphicsEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                        row.Properties.RowEdit = repItemGraphicsEdit;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void LoadItemGridsSearch()
        {
            try
            {
                // Fetch data for all items and alternates
                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)DataCurrentChildCategory);
                DataTable tblResult = new DataTable();
                string mparams = String.Join(",", metadata.Select(n => n.Id).ToList().Select(n => "[" + n + "]").ToList());

                if (mparams.Equals(string.Empty))
                    return;

                var itemslist = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == DataCurrentChildCategory && (n.ParentItemId == DataCurrentParentItemSearch || n.ItemId == DataCurrentParentItemSearch)).Select(n => n.ItemId).ToList();

                if (itemslist.Count > 0)
                {
                    string mids = String.Join(",", itemslist);

                    SqlDataAdapter adapter = BL.ApplicationDataContext.Instance.GetAdapter(
                      "SELECT Id, Name, ShortName, LocationMain, StockType,[CDS_SYS].fnDiscountForItem(" + Entity.Id + "," + (byte)Type + ",Id," +
                     ",0,1) UnitPrice, TotalAvailable,  " + mparams +
                     "FROM (select [CDS_CAT].CAT_Item.Id, [CDS_CAT].CAT_Item.Name, MetaId, CASE WHEN [CDS_CAT].CAT_Meta.Type = 'Image' THEN '\' + Data ELSE Data END Data,           " +
                     "ShortName, LocationMain, StockType, VW_LineItem.InventoryId, (ISNULL(OnHand,0) - ISNULL(OnReserve,0)) TotalAvailable                          " +
                     "from                                                                                                                             " +
                     "[CDS_CAT].CAT_Item inner join                                                                                                              " +
                     "[CDS_CAT].CAT_ItemData ON [CDS_CAT].CAT_ItemData.ItemId=[CDS_CAT].CAT_Item.Id left join                                                                        " +
                     "[CDS_CAT].CAT_MetaData  ON [CDS_CAT].CAT_MetaData.ItemId=[CDS_CAT].CAT_Item.Id left join                                                                       " +
                     "[CDS_CAT].CAT_Meta ON [CDS_CAT].CAT_MetaData.MetaId=[CDS_CAT].CAT_Meta.Id left join                                                                            " +
                     "[CDS_SYS].VW_LineItem on [CDS_CAT].CAT_Item.EntityId=VW_LineItem.Id                                                 " +
                     "where [CDS_CAT].CAT_ItemData.CategoryId=" + DataCurrentChildCategory + ") p                                                                    " +
                     "PIVOT (MIN (Data) FOR MetaId IN ( " + mparams + " ) ) AS pvt WHERE Id IN (" + mids + ") ORDER BY pvt.Name    ");

                    adapter.Fill(tblResult);

                    foreach (var m in metadata.Where(n => n.Type == "Image"))
                    {
                        tblResult.Columns.Add(new DataColumn(m.Id.ToString() + ".1", typeof(Image)));
                    }

                    for (int i = 0; i < tblResult.Rows.Count; i++)
                    {
                        var itemId = (Int64)tblResult.Rows[i]["Id"];
                        var item = DataContext.EntityCatalogueContext.CAT_Item.Where(n => n.Id == itemId).Select(n => n.Name).FirstOrDefault();
                        foreach (var m in metadata.Where(n => n.Type == "Image"))
                        {

                            //string path = tblResult.Rows[i][m.Id.ToString()].ToString();
                            string path = imageLocation + m.Grouping + @"\" + m.Name + @"\" + item + ".jpg";
                            if (System.IO.File.Exists(path))
                            {
                                using (System.IO.Stream stream = System.IO.File.OpenRead(path))
                                {
                                    tblResult.Rows[i][m.Id.ToString() + ".1"] = Image.FromStream(stream);
                                }
                            }
                        }
                    }

                    grdComparison.DataSource = tblResult;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RefreshEntryData()
        {
            try
            {
                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)ddlTopCategories.EditValue).Select(n => n.Id).ToList();

                DataTable tblResult = new DataTable();
                string mparams = String.Join(",", metadata.Select(n => "[" + n + "]"));
                if (mparams.Equals(string.Empty))
                    return;

                if (metadata.Count() > 0)
                {
                    SqlDataAdapter adapter = BL.ApplicationDataContext.Instance.GetAdapter(
                        "SELECT Id, Name, " + mparams +
                            "FROM (" +
                                    "select CAT_Item.Id, Name, MetaId, Data from [CDS_CAT].[CAT_MetaData] " +
                                    "inner join [CDS_CAT].[CAT_Item] ON CAT_MetaData.ItemId=CAT_Item.Id " +
                                        "inner join [CDS_CAT].[CAT_ItemData] ON CAT_ItemData.ItemId=CAT_Item.Id " +
                                            "where CAT_ItemData.CategoryId=" + ddlTopCategories.EditValue +
                                  ") p PIVOT ( MIN (Data) FOR MetaId IN ( " + mparams + " ) ) AS pvt ORDER BY pvt.Name");
                    adapter.Fill(tblResult);
                }
                bindingSourceTopItems.DataSource = tblResult;
                grvParents.BestFitColumns();

                #region ddlEntityView
                ddlEntityView.BestFitColumns();
                #endregion
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RefreshItems()
        {
            try
            {
                using (new Essential.UTL.WaitCursor())
                {
                    /*if (grvParents.FocusedRowHandle < 0)
                    return;

                object FocusedRow = grvParents.GetFocusedRow();*/
                    if (SelectedEntity == null || GetSelectedCatalogue == null)
                        return;

                    // TODO: Select only the categories that are valid for the selected top category : (Int64)ddlTopCategories.EditValue
                    List<CategoryItem> categories_with_items = DataContext.EntityCatalogueContext.CAT_Category.Where(n => (n.CategoryId != null || n.Id == DataCurrentCategory) && n.CatalogueId == GetSelectedCatalogue.Id).Select(n => new CategoryItem { Id = n.Id, Name = n.Name, CategoryId = n.CategoryId, Items = "" }).ToList();
                    List<Int64> treeids = new List<Int64>();
                    treeids.Add((Int64)ddlTopCategories.EditValue);
                    treeids.AddRange(GetTreeIds(categories_with_items, (Int64)ddlTopCategories.EditValue));
                    categories_with_items = categories_with_items.Where(n => treeids.Contains(n.Id)).ToList();

                    var item_datas = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.ParentItemId == DataCurrentParentItem || n.ItemId == DataCurrentParentItem).Join(DataContext.EntityCatalogueContext.CAT_Item, x => x.ItemId, y => y.Id, (a, b) => new { a.CategoryId, b.Name }).Distinct();


                    foreach (var itemdata in item_datas)
                    {
                        CategoryItem category_item = categories_with_items.Where(n => n.Id == itemdata.CategoryId).FirstOrDefault();
                        if (category_item != null)
                            category_item.Items = (category_item.Items.Length > 0) ? (category_item.Items + ", " + itemdata.Name) : (itemdata.Name);
                    }

                    DataTable tblResult = new DataTable();
                    tblResult.Columns.Add("Id", typeof(Int64));
                    tblResult.Columns.Add("Name", typeof(String));
                    tblResult.Columns.Add("CategoryId", typeof(Int64));
                    tblResult.Columns.Add("Items", typeof(String));

                    foreach (CategoryItem i in categories_with_items)
                        tblResult.Rows.Add(new object[] { i.Id, i.Name, i.CategoryId, i.Items });


                    treDataCategories.DataSource = tblResult;


                    treDataCategories.Columns["Name"].SortOrder = System.Windows.Forms.SortOrder.Ascending;
                    treDataCategories.Columns["Items"].SortOrder = System.Windows.Forms.SortOrder.Ascending;

                    if (treDataCategories.Nodes.Count != 0)
                    {
                        treDataCategories.CollapseAll();
                        treDataCategories.Nodes[0].Selected = true;
                        treDataCategories.Nodes[0].Expanded = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RefreshItemSearchEntries()
        {
            try
            {
                grvItemParents.Columns.Clear();
                grvItemParents.Columns.Add(colItemSearchCategory);
                grvItemParents.Columns.Add(colItemSearchName);
                grvItemParents.Columns.Add(colItemSearchParentName);

                colItemSearchCategory.Visible = true;
                //colItemSearchName.Visible = true;
                colItemSearchParentName.Visible = true;

                colItemSearchCategory.VisibleIndex = 0;
                //colItemSearchName.VisibleIndex = 1;
                colItemSearchParentName.VisibleIndex = 1;

                var catitems = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == (Int64)ddlTopItemCategories.EditValue).Select(n => n.ItemId).ToList();


                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)ddlTopItemCategories.EditValue).OrderBy(n => n.SortOrder);

                int cnt = 2;
                foreach (var meta in metadata)
                {
                    GridColumn column = new GridColumn();
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsColumn.AllowEdit = false;
                    column.Name = meta.Name;
                    column.Visible = true;
                    column.FieldName = meta.Id.ToString();
                    column.Caption = meta.Name;
                    column.VisibleIndex = cnt++;

                    grvItemParents.Columns.Add(column);
                }

                colItemSearchCategory.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
                grvItemParents.SortInfo.Add(new GridColumnSortInfo(colItemSearchCategory, DevExpress.Data.ColumnSortOrder.Ascending));

                this.grvItemParents.GroupCount = 1;

                grdItemParents.Refresh();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RefreshItemSearchData()
        {
            try
            {
                var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == (Int64)ddlTopItemCategories.EditValue).Select(n => n.Id).ToList(); ;

                DataTable tblResult = new DataTable();
                string mparams = String.Join(",", metadata.Select(n => "[" + n + "]").ToList());
                SqlDataAdapter adapter = BL.ApplicationDataContext.Instance.GetAdapter("SELECT DISTINCT Id, Category,Name,ParentName, " + mparams + " FROM (select [CDS_CAT].CAT_Category.Name as Category,Parent.Id, Child.Name as Name,Parent.Name as ParentName, MetaId, Data ,[CDS_CAT].CAT_ItemData.CategoryId from [CDS_CAT].CAT_MetaData inner join [CDS_CAT].CAT_Item Parent ON [CDS_CAT].CAT_MetaData.ItemId=Parent.Id inner join [CDS_CAT].CAT_ItemData ON [CDS_CAT].CAT_ItemData.ParentItemId=Parent.Id inner join [CDS_CAT].CAT_Item Child on [CDS_CAT].CAT_ItemData.ItemId = Child.Id INNER JOIN [CDS_CAT].CAT_Category on [CDS_CAT].CAT_ItemData.CategoryId = [CDS_CAT].CAT_Category.Id where Child.Name like '%" + btnFilterItem.Text + "%') p PIVOT (MIN (Data) FOR MetaId IN ( " + mparams + " ) ) AS pvt ORDER BY pvt.Name,pvt.ParentName");
                adapter.Fill(tblResult);

                bindingSourceTopItemsSearch.DataSource = tblResult;
                grvItemParents.BestFitColumns();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void RefreshItemsSearch()
        {
            try
            {
                if (grvItemParents.FocusedRowHandle < 0)
                    return;

                object FocusedRow = grvItemParents.GetFocusedRow();


                // TODO: Select only the categories that are valid for the selected top category : (Int64)ddlTopCategories.EditValue
                List<CategoryItem> categories_with_items = DataContext.EntityCatalogueContext.CAT_Category.Where(n => (n.CategoryId != null || n.Id == DataCurrentCategorySearch) && n.CatalogueId == GetSelectedCatalogue.Id).Select(n => new CategoryItem { Id = n.Id, Name = n.Name, CategoryId = n.CategoryId, Items = "" }).ToList();
                List<Int64> treeids = new List<Int64>();
                treeids.Add((Int64)ddlTopItemCategories.EditValue);
                treeids.AddRange(GetTreeIds(categories_with_items, (Int64)ddlTopItemCategories.EditValue));
                categories_with_items = categories_with_items.Where(n => treeids.Contains(n.Id)).ToList();

                var item_datas = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.ParentItemId == DataCurrentParentItemSearch || n.ItemId == DataCurrentParentItemSearch).Join(DataContext.EntityCatalogueContext.CAT_Item, x => x.ItemId, y => y.Id, (a, b) => new { a.CategoryId, b.Name });


                foreach (var itemdata in item_datas)
                {
                    CategoryItem category_item = categories_with_items.Where(n => n.Id == itemdata.CategoryId).FirstOrDefault();
                    if (category_item != null)
                        category_item.Items = (category_item.Items.Length > 0) ? (category_item.Items + ", " + itemdata.Name) : (itemdata.Name);
                }

                DataTable tblResult = new DataTable();
                tblResult.Columns.Add("Id", typeof(Int64));
                tblResult.Columns.Add("Name", typeof(String));
                tblResult.Columns.Add("CategoryId", typeof(Int64));
                tblResult.Columns.Add("Items", typeof(String));

                foreach (CategoryItem i in categories_with_items)
                    tblResult.Rows.Add(new object[] { i.Id, i.Name, i.CategoryId, i.Items });


                treDataCategories.DataSource = tblResult;

                if (treDataCategories.Nodes.Count != 0)
                {
                    treDataCategories.CollapseAll();
                    treDataCategories.Nodes[0].Selected = true;
                    treDataCategories.Nodes[0].Expanded = true;
                }

                DataView tblResultView = tblResult.AsDataView();
                tblResultView.RowFilter = "Items like '%" + btnFilterItem.Text + "%'";
                if (tblResultView.Count == 0)
                    return;

                string nodeCategory = tblResultView[0]["Name"].ToString();

                if (nodeCategory != null)
                {
                    TreeListNode foundNode = treDataCategories.FindNodeByFieldValue(treDataCategories.Columns[0].FieldName, nodeCategory);
                    foundNode.Selected = true;

                    while (foundNode.ParentNode != null)
                    {
                        foundNode.Expanded = true;
                        foundNode = foundNode.ParentNode;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 02/05/2012</remarks>
        private void ddlCatalogue_EditValueChanged(object sender, EventArgs e)
        {
            ServerModeSourceCategory.QueryableSource = DataContext.EntityCatalogueContext.CAT_Category.Where(n => n.CatalogueId == (Int64)GetSelectedCatalogue.Id);
            //ServerModeSourceCategory.QueryableSource = DataContext.EntityCatalogueContext.CAT_Category.
            //                                GroupJoin(DataContext.EntityCatalogueContext.CAT_ItemData, c => c.Id, i => i.CategoryId,
            //                                (cat, item) => new { cat, item }).Where(n => n.item.FirstOrDefault() != null && n.cat.CatalogueId == (Int64)GetSelectedCatalogue.Id).Select(n => n.cat)
            //                                ;

        }

        private void grvParents_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                RefreshItems();
                //Change this if there is a better way to do it
                pnlItemSearch.Height = 180;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvParents_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshItems();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void treDataCategories_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void grpItems_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            try
            {
                if (generating)
                    return;

                if (e.Page != null)
                {
                    grpItems.BeginUpdate();
                    // Copy the controls back to the template tab
                    if (e.PrevPage != null && e.PrevPage != tabComparison && e.PrevPage != tabTemplate && e.PrevPage.Items.Count > 0)
                    {
                        tabTemplate.Items.AddRange(e.PrevPage.Items.ConvertToTypedList().ToArray());
                    }

                    if (e.Page != tabComparison && e.Page != tabTemplate)
                    {
                        // Copy the template controls
                        e.Page.Items.AddRange(tabTemplate.Items.ConvertToTypedList().ToArray());


                        Int64? ItemId = ((Int64?[])grpItems.SelectedTabPage.Tag)[0];
                        Int64? EntityId = ((Int64?[])grpItems.SelectedTabPage.Tag)[1];

                        var table = grdComparison.DataSource as DataTable;
                        //var res = table.Select("[Id]=" + ((EntryItem)grpItems.SelectedTabPage.Tag).ItemId);
                        //var res = new DataView(table, "[Id]=" + ((EntryItem)grpItems.SelectedTabPage.Tag).ItemId, "", DataViewRowState.CurrentRows);
                        var res = new DataView(table, "[Id]=" + ItemId, "", DataViewRowState.CurrentRows);

                        grdItemData.DataSource = res;
                        //grdItemData.DataSource = (grdComparison.DataSource as DataTable).Select("[Id]=" + ((EntryItem)grpItems.SelectedTabPage.Tag).ItemId);


                        btnAdd.Enabled = EntityId.HasValue;

                        // Bind the selected data
                        var metastruc = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == DataCurrentChildCategory);

                        var metadata = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => n.CategoryId == DataCurrentChildCategory)
                             .GroupJoin(DataContext.EntityCatalogueContext.CAT_MetaData.Where(n => n.ItemId == ItemId), meta => meta.Id, data => data.MetaId,
                             (meta, data) => new { meta.Id, MetaDataId = data.Select(n => n.Id).FirstOrDefault() == null ? -1 : data.FirstOrDefault().Id, meta.Name, meta.Grouping, data.FirstOrDefault().Data, meta.Type })
                             ;

                        BindingSourceMetaData.DataSource = metadata.ToList();
                    }
                    grpItems.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Hides the CatalogueForm.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 11/05/2012</remarks>
        private void CatalogueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //this.Hide();
            //HideForm(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool itemAdded = true;

            if (this.Tag is Essential.BaseForm)
            {
                Int64? EntityId = ((Int64?[])grpItems.SelectedTabPage.Tag)[1];
                if (EntityId.HasValue)
                    (this.Tag as Essential.BaseForm).AddCatalogueItemToDocument(this.Tag as Essential.BaseForm, EntityId.Value);

            }

            //if (this.Tag.GetType() == typeof(CompleteDistribution.SalesOrder.SalesOrderForm) || this.Tag.GetType() == typeof(CompleteDistribution.SalesQuote.SalesQuoteForm) || this.Tag.GetType() == typeof(CompleteDistribution.PurchaseOrder.PurchaseOrderForm))
            //{
            //    Int64? ItemId = ((Int64?[])grpItems.SelectedTabPage.Tag)[0];
            //    Int64? StockId = ((Int64?[])grpItems.SelectedTabPage.Tag)[1];

            //    if (StockId.HasValue)
            //    {
            //        CompleteDataLayer.Inventory inventory = (CompleteDataLayer.Inventory)CompleteDataLayer.InventoryProvider.Instance.Load(StockId.Value);

            //        //Should not show ALT you can choose ALT from screen
            //        //if (CompleteDataLayer.PartReplacementProvider.Instance.CheckForAlternatives(inventory.NameAlphaPart))
            //        //{
            //        //    CompleteDistribution.Inventory.InventoryAlternativeForm childForm = new CompleteDistribution.Inventory.InventoryAlternativeForm();
            //        //    childForm.SearchByCode(inventory.NameAlphaPart, company);
            //        //    DialogResult dr = childForm.ShowDialog(this);
            //        //    if (dr == DialogResult.OK)
            //        //    {
            //        //        inventory = (CompleteDataLayer.Inventory)CompleteDataLayer.InventoryProvider.Instance.Load(childForm.InventoryGuid);
            //        //    }
            //        //    else if (dr == DialogResult.Cancel)
            //        //    {
            //        //        return;
            //        //    }
            //        //}


            //        if (inventory != null)
            //        {
            //            CompleteDataLayer.DocumentLine line = (CompleteDataLayer.DocumentLine)CompleteDataLayer.DocumentLineProvider.Instance.CreateNew();
            //            if (this.Tag.GetType() == typeof(CompleteDistribution.SalesOrder.SalesOrderForm))
            //                line.DocumentGuid = ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.DataLayerGuid;
            //            else if (this.Tag.GetType() == typeof(CompleteDistribution.SalesQuote.SalesQuoteForm))
            //                line.DocumentGuid = ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.DataLayerGuid;
            //            else if (this.Tag.GetType() == typeof(CompleteDistribution.PurchaseOrder.PurchaseOrderForm))
            //                line.DocumentGuid = ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.DataLayerGuid;

            //            line.Description = inventory.Name;
            //            line.InventoryGuid = inventory.InventoryGuid;
            //            line.UnitCost = inventory.UnitCost;
            //            line.TotalAvailable = inventory.TotalOnHand;
            //            line.Quantity = 1;

            //            if (inventory.TotalOnHand > 0)
            //                line.QuantityInvoice = 1;
            //            else
            //                line.QuantityBackOrder = 1;

            //            decimal sellPrice, discountPrice, discountPercentage;
            //            CompleteDataLayer.PriceHelper.Instance.GetSellPrice(line.Inventory, company, line.Quantity, false, out sellPrice, out discountPrice, out discountPercentage);
            //            line.UnitPrice = sellPrice;
            //            line.DiscountPercentage = discountPercentage;
            //            line.DiscountAmount = discountPrice;


            //            decimal quantity = line.QuantityInvoice;
            //            decimal discountedunitprice = line.UnitPrice;
            //            decimal totalvaluebeforetax = Math.Round(quantity * discountedunitprice, 2, MidpointRounding.AwayFromZero);
            //            decimal discountamount = Math.Round((line.Inventory.UnitPrice - discountedunitprice) * quantity, 2, MidpointRounding.AwayFromZero);
            //            decimal vatamount = Math.Round(totalvaluebeforetax * (CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.CompanySite.VatPercentage / 100M), 2, MidpointRounding.AwayFromZero);
            //            decimal totalvalue = totalvaluebeforetax + vatamount;

            //            line.MarkupPercentage = (line.UnitPrice > 0) ? (line.UnitPrice - inventory.UnitCost) / line.UnitPrice : 0M;
            //            line.DiscountAmount = discountamount;
            //            line.TotalAmountBeforeTax = totalvaluebeforetax;
            //            line.TotalTax = vatamount;
            //            line.TotalAmount = totalvalue;

            //            if (this.Tag.GetType() == typeof(CompleteDistribution.SalesOrder.SalesOrderForm))
            //            {
            //                bool bAdded = false;
            //                for (int i = 0; i < ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.DocumentLines.Count; i++)
            //                {
            //                    CompleteDataLayer.DocumentLine ln = ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.DocumentLines[i];
            //                    if (ln.InventoryGuid.Equals(Guid.Empty) && (ln.Quantity.Equals(0)))
            //                    {
            //                        // This is a "fake" empty row, we can use it for item
            //                        ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.DocumentLines[i] = line;
            //                        bAdded = true;
            //                        break;
            //                    }
            //                }
            //                if (!bAdded)
            //                    ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.DocumentLines.Add(line);

            //                //((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.DocumentLines.Add(line);
            //                ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.TotalAmount += line.TotalAmount;
            //                ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.TotalAmountBeforeTax += line.TotalAmountBeforeTax;
            //                ((CompleteDistribution.SalesOrder.SalesOrderForm)this.Tag).SalesOrder.TotalTax += line.TotalTax;
            //            }
            //            else if (this.Tag.GetType() == typeof(CompleteDistribution.SalesQuote.SalesQuoteForm))
            //            {
            //                bool bAdded = false;
            //                for (int i = 0; i < ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.DocumentLines.Count; i++)
            //                {
            //                    CompleteDataLayer.DocumentLine ln = ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.DocumentLines[i];
            //                    if (ln.InventoryGuid.Equals(Guid.Empty) && (ln.Quantity.Equals(0)))
            //                    {
            //                        // This is a "fake" empty row, we can use it for item
            //                        ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.DocumentLines[i] = line;
            //                        bAdded = true;
            //                        break;
            //                    }
            //                }
            //                if (!bAdded)
            //                    ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.DocumentLines.Add(line);

            //                //((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.DocumentLines.Add(line);
            //                ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.TotalAmount += line.TotalAmount;
            //                ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.TotalAmountBeforeTax += line.TotalAmountBeforeTax;
            //                ((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.TotalTax += line.TotalTax;
            //            }
            //            else if (this.Tag.GetType() == typeof(CompleteDistribution.PurchaseOrder.PurchaseOrderForm))
            //            {
            //                bool bAdded = false;
            //                for (int i = 0; i < ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.DocumentLines.Count; i++)
            //                {
            //                    CompleteDataLayer.DocumentLine ln = ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.DocumentLines[i];
            //                    if (ln.InventoryGuid.Equals(Guid.Empty) && (ln.Quantity.Equals(0)))
            //                    {
            //                        // This is a "fake" empty row, we can use it for item
            //                        ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.DocumentLines[i] = line;
            //                        bAdded = true;
            //                        break;
            //                    }
            //                }
            //                if (!bAdded)
            //                    ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.DocumentLines.Add(line);

            //                //((CompleteDistribution.SalesQuote.SalesQuoteForm)this.Tag).SalesQuote.DocumentLines.Add(line);
            //                ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.TotalAmount += line.TotalAmount;
            //                ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.TotalAmountBeforeTax += line.TotalAmountBeforeTax;
            //                ((CompleteDistribution.PurchaseOrder.PurchaseOrderForm)this.Tag).PurchaseOrder.TotalTax += line.TotalTax;
            //            }

            //            if (itemAdded)
            //                STD.MainForm.Instance.ShowNotification("Catalogue", "Added " + inventory.NameAlphaPart, 2000, false);
            //        }
            //    }
            //    else
            //    {
            //        itemAdded = false;
            //        MessageBox.Show(this, "The item you have selected does not have an asociated stock card on the system. Please create one before attempting to allocate this stock.", "Stock not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
        }

        private void grdItemData_DoubleClick(object sender, EventArgs e)
        {
            if (grdItemData.FocusedRow.Properties.Value != null && grdItemData.FocusedRow.Properties.Value.GetType().Equals(typeof(System.Drawing.Bitmap)))
            {
                //System.IO.Stream stream = System.IO.File.OpenRead(grdItemData.FocusedRow.Properties.Value.ToString());

                {

                    //DevExpress.XtraEditors.PanelControl imagePreview = ImageContainer(Image.FromStream(stream));
                    DevExpress.XtraEditors.PanelControl imagePreview = ImageContainer((Image)grdItemData.FocusedRow.Properties.Value);

                    Controls.Add(imagePreview);
                    imagePreview.Location = new Point(grdItemData.Location.X + 5, grdItemData.Location.Y + 5);
                    imagePreview.Size = grdItemData.Size;
                    imagePreview.Visible = true;
                    this.Controls.SetChildIndex(imagePreview, 0);



                }
            }
        }

        private void imagePreviewimage_DoubleClick(object sender, EventArgs e)
        {
            if ((e as System.Windows.Forms.MouseEventArgs).Button == System.Windows.Forms.MouseButtons.Left)
            {
                //((sender as DevExpress.XtraEditors.PictureEdit).Parent as DevExpress.XtraEditors.PanelControl).Visible = false;
                ((sender as DevExpress.XtraEditors.PictureEdit).Parent as DevExpress.XtraEditors.PanelControl).Dispose();
            }
        }

        private void grdItemData_Resize(object sender, EventArgs e)
        {

            DevExpress.XtraEditors.PanelControl imagePreview = (Controls["imagePreview"] as DevExpress.XtraEditors.PanelControl);
            if (imagePreview != null && imagePreview.Visible)
            {
                imagePreview.Location = new Point(grdItemData.Location.X + 5, grdItemData.Location.Y + 5);
                imagePreview.Size = grdItemData.Size;
            }

        }

        private void grvItemParents_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                RefreshItemsSearch();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void grvItemParents_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshItemsSearch();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (new Essential.UTL.WaitCursor())
            {
                grvParents.OptionsFind.FindFilterColumns = "*";
                grvParents.ApplyFindFilter(btnFilter.Text);
            }
        }

        private void btnFilter_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnFilter_ButtonClick(sender, null);
        }

        private void btnFilterItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (new Essential.UTL.WaitCursor())
                {
                    RefreshItemSearchEntries();
                    RefreshItemSearchData();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnFilterItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnFilterItem_ButtonClick(sender, null);
        }

        private List<Int64> GetTreeIds(List<CategoryItem> items, Int64? parentid)
        {
            try
            {
                List<Int64> children = items.Where(n => n.CategoryId == parentid).Select(n => n.Id).ToList();
                List<Int64> subchildren = new List<long>();
                foreach (Int64 i in children)
                {
                    subchildren.AddRange(GetTreeIds(items, i));
                }
                subchildren.AddRange(children);

                return subchildren;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        private DB.CAT_Category GetCategoryData(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            try
            {
                return (DB.CAT_Category)treDataCategories.GetDataRecordByNode(node);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        private void imgItemImage_DoubleClick(object sender, System.EventArgs e)
        {
            if (grdItemData.FocusedRow.Properties.Value != null && System.IO.File.Exists(grdItemData.FocusedRow.Properties.Value.ToString()))
            {
                System.IO.Stream stream = System.IO.File.OpenRead(grdItemData.FocusedRow.Properties.Value.ToString());

                {

                    DevExpress.XtraEditors.PanelControl imagePreview = ImageContainer(Image.FromStream(stream));
                    Controls.Add(imagePreview);
                    imagePreview.Location = new Point(grdItemData.Location.X + 5, grdItemData.Location.Y + 5);
                    imagePreview.Size = grdItemData.Size;
                    imagePreview.Visible = true;
                    this.Controls.SetChildIndex(imagePreview, 0);



                }
            }

        }

        private void ddlTopCategories_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (previousTopCategory == ddlTopCategories.Text && ddlTopCategories.Text != String.Empty)
                    {
                        SendKeys.SendWait("{TAB}");
                        return;
                    }

                    //using (new UTL.WaitCursor())
                    {
                        bindingSourceTopItems.DataSource = null;
                        treDataCategories.DataSource = null;
                        RefreshEntries();
                        RefreshEntryData();
                        RefreshItems();

                        previousTopCategory = ddlTopCategories.Text;
                    }
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }

        private void ddlEntityView_Click(object sender, EventArgs e)
        {
            SelectedEntity = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRow();
        }

        private void ddlEntityView_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == (int)Keys.Enter)
            {
                SelectedEntity = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRow();
            }
        }

        private void ddlEntity_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshItems();
                //Change this if there is a better way to do it
                // pnlItemSearch.Height = 180;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void InstantFeedbackSourceCatalogue_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_Catalogue;
        }

        private void ddlCatalogueView_Click(object sender, EventArgs e)
        {
            SelectCatalogue(sender);
        }

        private void ddlCatalogueView_KeyPress(object sender, KeyPressEventArgs e)
        {
            SelectCatalogue(sender);
        }

        private void SelectCatalogue(object sender)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo(view.GridControl.PointToClient(Cursor.Position));
            //if (hi.InRowCell) MessageBox.Show(view.GetRowCellValue(view.FocusedRowHandle, "Id").ToString());

            if (view.GetFocusedRow() == null || view.GetFocusedRow().GetType() == typeof(DevExpress.Data.NotLoadedObject))
                return;

            SelectedCatalogue = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)(view.GetFocusedRow())).OriginalRow as DB.VW_Catalogue;

        }

        protected DB.VW_Catalogue SelectedCatalogue
        {
            get
            {
                if (selectedCatalogue == null)
                    SelectedCatalogue = DataContext.ReadonlyContext.VW_Catalogue.FirstOrDefault(n => n.Id == (Int64)ddlCatalogue.EditValue);

                return selectedCatalogue;
            }
            set
            {
                //If this is the first time the Company is net
                if (selectedCatalogue == null || selectedCatalogue.Id != value.Id)
                    selectedCatalogue = value;

            }
        }

        private void grpSearch_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            bindingSourceTopItemsSearch.DataSource = null;
        }

        private void treDataCategories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateComparison(treDataCategories.FocusedNode);
            }
        }

        private void treDataCategories_DoubleClick(object sender, EventArgs e)
        {
            PopulateComparison(treDataCategories.FocusedNode);
        }

        private void PopulateComparison(TreeListNode node)
        {
            try
            {
                using (new Essential.UTL.WaitCursor())
                {
                    if (node != null)
                    {
                        if (grvItemParents.DataRowCount != 0 && grpSearch.SelectedTabPage == pnlItemSearch)
                        {
                            // Get item data
                            LoadItemGridsSearch();

                            // Set up item grids
                            InitialiseItemGridsSearch();

                            // Get all the items linked to this category
                            var itemslist = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == DataCurrentChildCategory && (n.ParentItemId == DataCurrentParentItemSearch || n.ItemId == DataCurrentParentItemSearch)).Select(n => n.ItemId).Distinct().ToList();
                            var Items = DataContext.EntityCatalogueContext.CAT_Item.Where(n => itemslist.Contains(n.Id)).Distinct();

                            grpItems.BeginUpdate();

                            generating = true;

                            foreach (var x in grpItems.TabPages.ConvertToTypedList().Where(n => n.Name.StartsWith("tab_")))
                                grpItems.RemoveTabPage((LayoutGroup)x);

                            LayoutGroup itmtemplate = null;
                            foreach (var item in Items)
                            {

                                itmtemplate = new DevExpress.XtraLayout.LayoutControlGroup();
                                itmtemplate.Text = item.Name;
                                itmtemplate.Name = "tab_" + item.Name;
                                itmtemplate.Tag = new Int64?[] { item.Id, item.EntityId };
                                grpItems.AddTabPage(itmtemplate, item.Name);
                            }
                            generating = false;
                            grpItems.EndUpdate();


                            grpItems.SelectedTabPage = tabTemplate;
                            if (Items.Count() > 0)
                                grpItems.SelectedTabPage = itmtemplate;

                            tabComparison.Visibility = (Items.Count() > 1) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                        }
                        else
                        {
                            // Get item data
                            LoadItemGrids();

                            // Set up item grids
                            InitialiseItemGrids();

                            // Get all the items linked to this category
                            var itemslist = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => n.CategoryId == DataCurrentChildCategory && (n.ParentItemId == DataCurrentParentItem || n.ItemId == DataCurrentParentItem)).Select(n => n.ItemId).ToList();
                            var Items = DataContext.EntityCatalogueContext.CAT_Item.Where(n => itemslist.Contains(n.Id));


                            grpItems.BeginUpdate();

                            generating = true;

                            foreach (var x in grpItems.TabPages.ConvertToTypedList().Where(n => n.Name.StartsWith("tab_")))
                                grpItems.RemoveTabPage((LayoutGroup)x);

                            
                            LayoutGroup itmtemplate = null;
                            foreach (var item in Items)
                            {

                                itmtemplate = new DevExpress.XtraLayout.LayoutControlGroup();
                                itmtemplate.Text = item.Name;
                                itmtemplate.Name = "tab_" + item.Name;
                                itmtemplate.Tag = new Int64?[] { item.Id, item.EntityId };
                                grpItems.AddTabPage(itmtemplate, item.Name);
                            }
                            generating = false;
                            grpItems.EndUpdate();


                            grpItems.SelectedTabPage = tabTemplate;
                            if (Items.Count() > 0)
                                grpItems.SelectedTabPage = itmtemplate;

                            tabComparison.Visibility = (Items.Count() > 1) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

    }
}
