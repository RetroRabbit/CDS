using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Xml; 
using Ionic.Zip;
using System.IO;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    public partial class CatalogueImportExportDialogue : Essential.BaseDialogue
    { 
        String imageLocation = @"C:\Catalogue\";
        List<ImportExportStatus> statusList = new List<ImportExportStatus>();

        //Locations of XML files
        private string xmlCatalogueFile;
        private string xmlCategoriesFile;
        private string xmlItemDatasFile;
        private string xmlItemsFile;
        private string xmlMetaDatasFile;
        private string xmlMetasFile;

        //Id Diff
        private Int64 diffCatalogue;
        private Int64 diffCategory;
        private Int64 diffmeta;
        private Int64 diffItem;
        private Int64 diffmetadata;
        private Int64 diffitemdata;

        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target)
            {
                Source = source;
                Target = target;
            }
        }


        public DataTable getCAT_CatalogueTable
        {
            get
            {
                DataTable table = new DataTable("CAT_Catalogue");
                table.Columns.Add("Id", typeof(Int64));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Publisher", typeof(string));
                table.Columns.Add("Revision", typeof(string));
                table.Columns.Add("Description", typeof(string));
                table.Columns.Add("ImageDestination", typeof(string));
                table.Columns.Add("CreatedOn", typeof(DateTime));
                table.Columns.Add("CreatedBy", typeof(Int64));

                return table;
            }
        }

        public DataTable getCAT_CategoryTable
        {
            get
            {
                DataTable table = new DataTable("CAT_Category");
                table.Columns.Add("Id", typeof(Int64));
                table.Columns.Add(new DataColumn("CategoryId", typeof(Int64)) { AllowDBNull = true });
                table.Columns.Add("CatalogueId", typeof(Int64));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("CreatedOn", typeof(DateTime));
                table.Columns.Add("CreatedBy", typeof(Int64));

                return table;
            }
        }

        public DataTable getCAT_MetaTable
        {
            get
            {
                DataTable table = new DataTable("CAT_Meta");
                table.Columns.Add("Id", typeof(Int64));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Grouping", typeof(string));
                table.Columns.Add("CategoryId", typeof(Int64));
                table.Columns.Add("Type", typeof(string));
                table.Columns.Add("Grouped", typeof(bool));
                table.Columns.Add("SortOrder", typeof(Int32));
                table.Columns.Add("CreatedOn", typeof(DateTime));
                table.Columns.Add("CreatedBy", typeof(Int64));

                return table;
            }
        }

        public DataTable getCAT_ItemTable
        {
            get
            {
                DataTable table = new DataTable("CAT_Item");
                table.Columns.Add("Id", typeof(Int64));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("EntityId", typeof(Int64));
                table.Columns.Add("CreatedOn", typeof(DateTime));
                table.Columns.Add("CreatedBy", typeof(Int64));

                return table;
            }
        }

        public DataTable getCAT_MetaDataTable
        {
            get
            {
                DataTable table = new DataTable("CAT_MetaData");
                table.Columns.Add("Id", typeof(Int64));
                table.Columns.Add("MetaId", typeof(Int64));
                table.Columns.Add("ItemId", typeof(Int64));
                table.Columns.Add("CategoryId", typeof(Int64));
                table.Columns.Add("Data", typeof(string));
                table.Columns.Add("CreatedOn", typeof(DateTime));
                table.Columns.Add("CreatedBy", typeof(Int64));

                return table;

            }
        }

        public DataTable getCAT_ItemDataTable
        {
            get
            {
                DataTable table = new DataTable("CAT_ItemData");
                table.Columns.Add("Id", typeof(Int64));
                table.Columns.Add("ItemId", typeof(Int64));
                table.Columns.Add("ParentItemId", typeof(Int64));
                table.Columns.Add("CategoryId", typeof(Int64));
                table.Columns.Add("CreatedOn", typeof(DateTime));
                table.Columns.Add("CreatedBy", typeof(Int64));

                return table;
            }
        }

        public DB.CAT_Catalogue Catalogue
        {
            get { return (DB.CAT_Catalogue)ddlCatalogue.GetSelectedDataRow(); } 
        }

        string toDo;
         
        public CatalogueImportExportDialogue(string toDo)
        {
            InitializeComponent();
            this.toDo = toDo;
        }

        protected override void OnStart()
        {
            base.OnStart();
            statusList.Clear();

            switch (toDo)
            {
                case "Import":
                    this.Text = "Import Catalogue";
                    itmCatalogue.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    statusList.Add(new ImportExportStatus() { Id = 1, Description = "Extract Zip File", Progress = 0, TableName = "EXTRACT", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 3, Description = "Import Catalogue Information", Progress = 0, TableName = "CAT_Catalogue", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 2, Description = "Cleaning Catalogue Data", Progress = 0, TableName = "CLEAN", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 3, Description = "Import Categories", Progress = 0, TableName = "CAT_Category", Image = imageCollectionStatus.Images[0] });
                    //statusList.Add(new ImportExportStatus() { Id = 4, Description = "Import Category Structure", Progress = 0, TableName = "CATEGORYSTRUCTURE", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 5, Description = "Import Property Structure", Progress = 0, TableName = "CAT_Meta", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 6, Description = "Import Item Data ", Progress = 0, TableName = "CAT_Item", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 7, Description = "Import Property Data", Progress = 0, TableName = "CAT_MetaData", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 8, Description = "Import Item Structure", Progress = 0, TableName = "CAT_ItemData", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 9, Description = "Import Images", Progress = 0, TableName = "IMAGES", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 9, Description = "Import Finilize", Progress = 0, TableName = "CLEANUP", Image = imageCollectionStatus.Images[0] });
                    break;
                case "Export":
                    this.Text = "Export Catalogue";
                    btnStart.Enabled = true;
                    itmCatalogueLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    itmImageLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    statusList.Add(new ImportExportStatus() { Id = 10, Description = "Export Catalogue Information", Progress = 0, TableName = "CAT_Catalogue", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 11, Description = "Export Category Structure", Progress = 0, TableName = "CAT_Category", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 12, Description = "Export Property Structure", Progress = 0, TableName = "CAT_Meta", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 13, Description = "Export Item Structure", Progress = 0, TableName = "CAT_ItemData", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 14, Description = "Export Property Data", Progress = 0, TableName = "CAT_MetaData", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 15, Description = "Export Item Data ", Progress = 0, TableName = "CAT_Item", Image = imageCollectionStatus.Images[0] });
                    statusList.Add(new ImportExportStatus() { Id = 16, Description = "Export Images", Progress = 0, TableName = "IMAGES", Image = imageCollectionStatus.Images[0] });
                    break;
            }

            BindingSource.DataSource = statusList;

            //BindingSourceCatalogue.DataSource = DataContext.EntityCatalogueContext.CAT_Catalogue.Where(n => n.Id == this.Catalogue.Id).FirstOrDefault();
            
            ServerModeSourceCatalogue.QueryableSource = DataContext.EntityCatalogueContext.CAT_Catalogue;
            //imageLocation = DataContext.EntityCatalogueContext.CAT_Catalogue.Where(n => n.Id == this.Catalogue.Id).FirstOrDefault().ImageDestination;
            //if (imageLocation == null)
            //{
            //    Essential.BaseAlert.ShowAlert("Error", "Please set catalogue image location before importing catalogue.", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
            //    this.Close();
            //}
        }
         
        public void RunImport()
        {
            try
            {
                ExtractZipFile();
                ImportCatalogue();
                // TODO : I DONT LIKE THIS NEED TO FIND OTHER WAY
                BindCatalogue();
                CleanCurrentCatalogue();

                ImportCategories();
                ImportMetas();
                ImportItems();
                ImportMetaDatas();
                ImportItemDatas();
                ImportImages();
                LinkItemsToStock();

                //ExtractZipFile();
                //ImportCatalogue();
                //// TODO : I DONT LIKE THIS NEED TO FIND OTHER WAY
                //BindCatalogue();
                //CleanCurrentCatalogue();

                //System.Threading.Thread ImportCategoriesThread = new System.Threading.Thread(ImportCategories);
                //System.Threading.Thread ImportMetasThread = new System.Threading.Thread(ImportMetas);
                //System.Threading.Thread ImportItemsThread = new System.Threading.Thread(ImportItems);
                //System.Threading.Thread ImportMetaDatasThread = new System.Threading.Thread(ImportMetaDatas);
                //System.Threading.Thread ImportItemDatasThread = new System.Threading.Thread(ImportItemDatas);
                //System.Threading.Thread ImportImagesThread = new System.Threading.Thread(ImportImages);

                //ImportCategoriesThread.Start();
                //ImportMetasThread.Start();
                //ImportItemsThread.Start();
                //ImportMetaDatasThread.Start();
                //ImportItemDatasThread.Start();
                //ImportImagesThread.Start();


            }
            catch (Exception ex)
            {
                //CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.RollbackTransaction();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

            btnStart.Enabled = true;
        }

        private void CleanCurrentCatalogue()
        {
            try
            {
                //    var categories = writeDataContext.EntityCatalogueContext.CAT_Category.Where(c => c.CatalogueId == this.Catalogue.Id);
                //    var metas = writeDataContext.EntityCatalogueContext.CAT_Meta.Where(m => categories.Select(l => l.Id).Contains(m.CategoryId));
                //    var metadatas = writeDataContext.EntityCatalogueContext.CAT_MetaData.Where(md => categories.Select(l => l.Id).Contains(md.CategoryId));
                //    var itemdatas = writeDataContext.EntityCatalogueContext.CAT_ItemData.Where(id => categories.Select(l => l.Id).Contains(id.CategoryId));
                //    var items = writeDataContext.EntityCatalogueContext.CAT_Item.Where(i => itemdatas.ToList().Select(m => m.ItemId).Contains(i.Id));
                if (DataContext.EntityCatalogueContext.CAT_Catalogue.Count() == 0 || DataContext.EntityCatalogueContext.CAT_Category.Count() == 0)
                    return;

                StringBuilder sql = new StringBuilder();
                sql.Append("DELETE FROM [CDS_CAT].CAT_MetaData FROM [CDS_CAT].CAT_MetaData INNER JOIN [CDS_CAT].CAT_Category on [CDS_CAT].CAT_MetaData.CategoryId = [CDS_CAT].CAT_Category.Id WHERE [CDS_CAT].CAT_Category.CatalogueId = " + this.Catalogue.Id + "");
                sql.Append("DELETE FROM [CDS_CAT].CAT_ItemData FROM [CDS_CAT].CAT_ItemData INNER JOIN [CDS_CAT].CAT_Category on [CDS_CAT].CAT_ItemData.CategoryId = [CDS_CAT].CAT_Category.Id WHERE [CDS_CAT].CAT_Category.CatalogueId = " + this.Catalogue.Id + "");
                sql.Append("DELETE FROM [CDS_CAT].CAT_Meta FROM [CDS_CAT].CAT_Meta INNER JOIN [CDS_CAT].CAT_Category on [CDS_CAT].CAT_Meta.CategoryId = [CDS_CAT].CAT_Category.Id WHERE [CDS_CAT].CAT_Category.CatalogueId = " + this.Catalogue.Id + "");
                sql.Append("DELETE FROM [CDS_CAT].CAT_Item FROM [CDS_CAT].CAT_Item INNER JOIN [CDS_CAT].CAT_ItemData on [CDS_CAT].CAT_Item.Id = [CDS_CAT].CAT_ItemData.ItemId INNER JOIN [CDS_CAT].CAT_Category ON [CDS_CAT].CAT_ItemData.CategoryId = [CDS_CAT].CAT_Category.Id WHERE [CDS_CAT].CAT_Category.CatalogueId = " + this.Catalogue.Id + "");
                sql.Append("DELETE FROM [CDS_CAT].CAT_Item FROM [CDS_CAT].CAT_Item INNER JOIN [CDS_CAT].CAT_ItemData on [CDS_CAT].CAT_Item.Id = [CDS_CAT].CAT_ItemData.ParentItemId INNER JOIN [CDS_CAT].CAT_Category ON [CDS_CAT].CAT_ItemData.CategoryId = [CDS_CAT].CAT_Category.Id WHERE [CDS_CAT].CAT_Category.CatalogueId = " + this.Catalogue.Id + "");
                sql.Append("DELETE [CDS_CAT].CAT_Category where CatalogueId = " + this.Catalogue.Id + "" + Environment.NewLine);

                //sql.Append("DELETE CAT_MetaData where CategoryId in ( SELECT Id from CAT_Category where CatalogueId = " + this.Catalogue.Id + ")" + Environment.NewLine);
                //sql.Append("DELETE CAT_ItemData where CategoryId in ( SELECT Id from CAT_Category where CatalogueId = " + this.Catalogue.Id + ")" + Environment.NewLine);
                //sql.Append("DELETE CAT_Meta where CategoryId in ( SELECT Id from CAT_Category where CatalogueId = " + this.Catalogue.Id + ")" + Environment.NewLine);                
                //sql.Append("DELETE CAT_Item where Id in ( SELECT Id from CAT_ItemData where CategoryId in ( SELECT Id from CAT_Category where CatalogueId = " + this.Catalogue.Id + "))" + Environment.NewLine);
                //sql.Append("DELETE CAT_Category where CatalogueId = " + this.Catalogue.Id + "" + Environment.NewLine);

                //if (CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.TransactionStatus == CompleteDataLayer.TransactionStatus.Closed)
                //    CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.BeginTransaction();

                //System.Data.SqlClient.SqlCommand sqlCommand = CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.GetCommand(sql.ToString(), false);

                //sqlCommand.ExecuteNonQuery();

                ////if (sqlCommand.ExecuteNonQuery() == 0)
                ////    throw new Exception("The sql command did not affect any rows!", null);

                //CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.CommitTransaction();
                DataContext.EntityCatalogueContext.Database.CommandTimeout = 0;
                DataContext.EntityCatalogueContext.Database.ExecuteSqlCommand(sql.ToString());
                UpdateTotal("CLEAN", 1);
                UpdateProgress("CLEAN", 1, false);

            }
            catch (Exception ex)
            {
                UpdateTotal("CLEAN", 1);
                UpdateProgress("CLEAN", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ExtractZipFile()
        {
            try
            {

                if (!Directory.Exists(@"C:\CatalogueExport"))
                    Directory.CreateDirectory(@"C:\CatalogueExport");
                else
                    Directory.Delete(@"C:\CatalogueExport", true);

                ZipFile file = new ZipFile(catalogueLocation.FileName);
                file.ExtractAll(@"C:\CatalogueExport");

                xmlCatalogueFile = @"C:\CatalogueExport\xmlCatalogue.xml";
                xmlCategoriesFile = @"C:\CatalogueExport\xmlCategories.xml";
                xmlItemDatasFile = @"C:\CatalogueExport\xmlItemDatas.xml";
                xmlItemsFile = @"C:\CatalogueExport\xmlItems.xml";
                xmlMetaDatasFile = @"C:\CatalogueExport\xmlMetaDatas.xml";
                xmlMetasFile = @"C:\CatalogueExport\xmlMetas.xml";

                //Checks that all the exported files are there
                if (!(
                       File.Exists(xmlCatalogueFile)
                    && File.Exists(xmlCategoriesFile)
                    && File.Exists(xmlItemDatasFile)
                    && File.Exists(xmlItemsFile)
                    && File.Exists(xmlMetaDatasFile)
                    && File.Exists(xmlMetasFile)
                    && File.Exists(@"C:\CatalogueExport\DirectoryInfo.txt")))
                {
                    Essential.BaseAlert.ShowAlert("Invalid File", "Zip file has invalid structure", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    return;
                }
                using (StreamReader sr = new StreamReader(@"C:\CatalogueExport\DirectoryInfo.txt"))
                {
                    string directoryName = sr.ReadLine().ToString();

                    if (!Directory.Exists(@"C:\CatalogueExport\" + directoryName))
                    {
                        Essential.BaseAlert.ShowAlert("Invalid File", "Zip file has invalid structure", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                        return;
                    }
                }

                UpdateTotal("EXTRACT", 1);
                UpdateProgress("EXTRACT", 1, false);


            }
            catch (Exception ex)
            {
                Essential.BaseAlert.ShowAlert("Invalid File", "Counld not extract file this file may be invalid or corrupt", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                UpdateTotal("EXTRACT", 1);
                UpdateProgress("EXTRACT", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ImportCatalogue()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DB.CAT_Catalogue));

                DB.CAT_Catalogue xmlElements = (DB.CAT_Catalogue)reader.Deserialize(new System.IO.StreamReader(xmlCatalogueFile));

                Int64 maxid = 0;

                if (DataContext.EntityCatalogueContext.CAT_Catalogue.Select(n => n.Id).Count() == 0)
                    maxid = 0;
                else
                    maxid = DataContext.EntityCatalogueContext.CAT_Catalogue.Select(n => n.Id).Max(n => n);

                diffCatalogue = (maxid - xmlElements.Id) + 1;

                //if (diffCatalogue < 0)
                //    diffCatalogue = (xmlElements.Id) - 1;

                DataTable insertTable = getCAT_CatalogueTable;

                if (DataContext.EntityCatalogueContext.CAT_Catalogue.Where(n => n.Name == xmlElements.Name).Count() > 0)
                    if (Essential.BaseAlert.ShowAlert("Duplicate Catalogue", "A Catalogue with the same name already exists this catalogue will be overridden." + Environment.NewLine + "Do you wish to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Warning) == System.Windows.Forms.DialogResult.OK)
                    {
                        DB.CAT_Catalogue currentCatalogue = DataContext.EntityCatalogueContext.CAT_Catalogue.Where(n => n.Name == xmlElements.Name).FirstOrDefault();
                        currentCatalogue.Name = xmlElements.Name;
                        currentCatalogue.Publisher = xmlElements.Publisher;
                        currentCatalogue.Revision = xmlElements.Revision;
                        currentCatalogue.Description = xmlElements.Description;
                        currentCatalogue.ImageDestination = xmlElements.ImageDestination;

                        ddlCatalogue.EditValue = currentCatalogue.Id;
                    }
                    else
                    {

                        this.Close();
                        return;
                    }
                else
                {
                    insertTable.Rows.Add(new object[] { xmlElements.Id + diffCatalogue, xmlElements.Name, xmlElements.Publisher, xmlElements.Revision, xmlElements.Description, btnImageLocation.Text });

                    WriteToServer(insertTable);
                }



            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Catalogue", 1);
                UpdateProgress("CAT_Catalogue", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void BindCatalogue()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DB.CAT_Catalogue));

            DB.CAT_Catalogue xmlElements = (DB.CAT_Catalogue)reader.Deserialize(new System.IO.StreamReader(xmlCatalogueFile));

            //Populate binding for Catalogue
            ServerModeSourceCatalogue.QueryableSource = DataContext.EntityCatalogueContext.CAT_Catalogue.Where(n => n.Name == xmlElements.Name);
            ddlCatalogue.EditValue = DataContext.EntityCatalogueContext.CAT_Catalogue.Where(n => n.Name == xmlElements.Name).Select(n => n.Id).FirstOrDefault();
        }

        private void ImportCategories()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_Category>));

                List<DB.CAT_Category> xmlElements = (List<DB.CAT_Category>)reader.Deserialize(new System.IO.StreamReader(xmlCategoriesFile));

                Int64 maxid = 0;

                if (DataContext.EntityCatalogueContext.CAT_Category.Select(n => n.Id).Count() == 0)
                    maxid = 0;
                else
                    maxid = DataContext.EntityCatalogueContext.CAT_Category.Select(n => n.Id).Max(n => n);

                diffCategory = (maxid - xmlElements.Min(n => n.Id)) + 1;

                //if (diffCategory < 0)
                //    diffCategory = (xmlElements.Min(n => n.Id) - 1);

                DataTable insertTable = getCAT_CategoryTable;

                //Id,Name,CatalogueId,CategoryId

                xmlElements.ForEach(n => insertTable.Rows.Add(new object[] { 
                    n.Id + diffCategory, 
                    n.CategoryId == null ? null : n.CategoryId + diffCategory, 
                    Catalogue.Id, 
                    n.Name, n.CreatedOn = BL.ApplicationDataContext.Instance.ServerDateTime, 
                    n.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId
                }));

                //UpdateTotal(insertTable.TableName, insertTable.Rows.Count);

                WriteToServer(insertTable);



            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Category", 1);
                UpdateProgress("CAT_Category", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ImportMetas()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_Meta>));

                List<DB.CAT_Meta> xmlElements = (List<DB.CAT_Meta>)reader.Deserialize(new System.IO.StreamReader(xmlMetasFile));

                Int64 maxid = 0;

                if (DataContext.EntityCatalogueContext.CAT_Meta.Select(n => n.Id).Count() == 0)
                    maxid = 0;
                else
                    maxid = DataContext.EntityCatalogueContext.CAT_Meta.Select(n => n.Id).Max(n => n);

                diffmeta = (maxid - xmlElements.Min(n => n.Id)) + 1;

                //if (diffmeta < 0)
                //    diffmeta = (xmlElements.Min(n => n.Id) - 1);

                DataTable insertTable = getCAT_MetaTable;

                //Id,Name,CatalogueId,CategoryId
                xmlElements.ForEach(n => insertTable.Rows.Add(new object[] 
                { 
                    n.Id+diffmeta,
                    n.Name,
                    n.Grouping,
                    n.CategoryId + diffCategory,
                    n.Type,
                    n.Grouped,
                    n.SortOrder,
                    n.CreatedOn = BL.ApplicationDataContext.Instance.ServerDateTime, 
                    n.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId
                }));

                //UpdateTotal(insertTable.TableName, insertTable.Rows.Count);

                WriteToServer(insertTable);

            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Meta", 1);
                UpdateProgress("CAT_Meta", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ImportItems()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_Item>));

                List<DB.CAT_Item> xmlElements = (List<DB.CAT_Item>)reader.Deserialize(new System.IO.StreamReader(xmlItemsFile));

                Int64 maxid = 0;

                if (DataContext.EntityCatalogueContext.CAT_Item.Select(n => n.Id).Count() == 0)
                    maxid = 0;
                else
                    maxid = DataContext.EntityCatalogueContext.CAT_Item.Select(n => n.Id).Max(n => n);

                diffItem = (maxid - xmlElements.Min(n => n.Id)) + 1;

                //if (diffItem < 0)
                //    diffItem = (xmlElements.Min(n => n.Id) - 1);

                DataTable insertTable = getCAT_ItemTable;

                xmlElements.ForEach(n => insertTable.Rows.Add(new object[] 
                {
                    n.Id+diffItem,
                    n.Name,
                    null,
                    n.CreatedOn = BL.ApplicationDataContext.Instance.ServerDateTime, 
                    n.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId
                }));

                //UpdateTotal(insertTable.TableName, insertTable.Rows.Count);

                WriteToServer(insertTable);

                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE [CDS_CAT].[CAT_Item] set EntityId = NULL FROM [CDS_CAT].[CAT_Item] INNER JOIN [CDS_CAT].[CAT_ItemData] on [CDS_CAT].[CAT_Item].Id = [CDS_CAT].[CAT_ItemData].ItemId INNER JOIN [CDS_CAT].[CAT_Category] ON [CDS_CAT].[CAT_ItemData].CategoryId = [CDS_CAT].[CAT_Category].Id WHERE [CDS_CAT].[CAT_Category].CatalogueId = " + this.Catalogue.Id + ";");
                sql.Append("UPDATE [CDS_CAT].[CAT_Item] set EntityId = [CDS_ITM].[VW_Inventory].EntityId FROM [CDS_CAT].[CAT_Item] INNER JOIN [CDS_ITM].[VW_Inventory] on [CDS_CAT].[CAT_Item].Name = [CDS_ITM].[VW_Inventory].Name INNER JOIN [CDS_CAT].[CAT_ItemData] on [CDS_CAT].[CAT_Item].Id = [CDS_CAT].[CAT_ItemData].ItemId INNER JOIN [CDS_CAT].[CAT_Category] ON [CDS_CAT].[CAT_ItemData].CategoryId = [CDS_CAT].[CAT_Category].Id WHERE [CDS_CAT].[CAT_Category].CatalogueId = " + this.Catalogue.Id + "");

                //if (CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.TransactionStatus == CompleteDataLayer.TransactionStatus.Closed)
                //    CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.BeginTransaction();

                //System.Data.SqlClient.SqlCommand sqlCommand = CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.GetCommand(sql.ToString(), false);

                //sqlCommand.ExecuteNonQuery();

                ////if (sqlCommand.ExecuteNonQuery() == 0)
                ////    throw new Exception("The sql command did not affect any rows!", null);

                //CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.CommitTransaction();
                (DataContext.EntityCatalogueContext as System.Data.Entity.DbContext).Database.CommandTimeout = 180;
                DataContext.EntityCatalogueContext.Database.ExecuteSqlCommand(sql.ToString());
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Item", 1);
                UpdateProgress("CAT_Item", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ImportMetaDatas()
        {

            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_MetaData>));

                List<DB.CAT_MetaData> xmlElements = (List<DB.CAT_MetaData>)reader.Deserialize(new System.IO.StreamReader(xmlMetaDatasFile));

                Int64 maxid = 0;

                if (DataContext.EntityCatalogueContext.CAT_MetaData.Select(n => n.Id).Count() == 0)
                    maxid = 0;
                else
                    maxid = DataContext.EntityCatalogueContext.CAT_MetaData.Select(n => n.Id).Max(n => n);

                diffmetadata = (maxid - xmlElements.Min(n => n.Id)) + 1;

                //if (diffmetadata < 0)
                //    diffmetadata = (xmlElements.Min(n => n.Id) - 1);

                DataTable insertTable = getCAT_MetaDataTable;

                xmlElements.ForEach(n => insertTable.Rows.Add(new object[] 
                {
                    n.Id+diffmetadata,
                    n.MetaId + diffmeta,
                    n.ItemId + diffItem,
                    n.CategoryId + diffCategory,
                    n.Data,
                    n.CreatedOn = BL.ApplicationDataContext.Instance.ServerDateTime, 
                    n.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId
                }));

                //UpdateTotal(insertTable.TableName, insertTable.Rows.Count);

                WriteToServer(insertTable);
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_MetaData", 1);
                UpdateProgress("CAT_MetaData", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ImportItemDatas()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_ItemData>));

                List<DB.CAT_ItemData> xmlElements = (List<DB.CAT_ItemData>)reader.Deserialize(new System.IO.StreamReader(xmlItemDatasFile));

                Int64 maxid = 0;

                if (DataContext.EntityCatalogueContext.CAT_ItemData.Select(n => n.Id).Count() == 0)
                    maxid = 0;
                else
                    maxid = DataContext.EntityCatalogueContext.CAT_ItemData.Select(n => n.Id).Max(n => n);

                diffitemdata = (maxid - xmlElements.Min(n => n.Id)) + 1;

                //if (diffitemdata < 0)
                //    diffitemdata = (xmlElements.Min(n => n.Id) - 1);

                DataTable insertTable = getCAT_ItemDataTable;


                foreach (var n in xmlElements)
                {
                    insertTable.Rows.Add(new object[] 
                        {
                            n.Id+diffitemdata,
                            n.ItemId + diffItem,
                            n.ParentItemId == null ? n.ItemId + diffItem : n.ParentItemId+diffItem,
                            n.CategoryId +diffCategory,
                            n.CreatedOn = BL.ApplicationDataContext.Instance.ServerDateTime, 
                            n.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId
                        });
                }

                //xmlElements.ForEach(n => insertTable.Rows.Add(new object[] 
                //{
                //    n.Id-diffitemdata,
                //    n.ParentItemId-diffitemdata,
                //    n.CategoryId -diffCategory
                //}));

                //UpdateTotal(insertTable.TableName, insertTable.Rows.Count);

                WriteToServer(insertTable);
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_ItemData", 1);
                UpdateProgress("CAT_ItemData", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ImportImages()
        {
            try
            {
                imageLocation = btnImageLocation.Text;

                if (!Directory.Exists(imageLocation))
                    Directory.CreateDirectory(imageLocation);

                using (StreamReader sr = new StreamReader(@"C:\CatalogueExport\DirectoryInfo.txt"))
                {
                    string directoryName = sr.ReadLine().ToString();
                    MoveDirectory(@"C:\CatalogueExport\" + directoryName, imageLocation);
                }

                UpdateTotal("IMAGES", 1);
                UpdateProgress("IMAGES", 1, false);
            }
            catch (Exception ex)
            {
                UpdateTotal("IMAGES", 1);
                UpdateProgress("IMAGES", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void LinkItemsToStock()
        {
            try
            {
                //if (CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.TransactionStatus == CompleteDataLayer.TransactionStatus.Closed)
                //    CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.BeginTransaction();

                string query = "UPDATE [CDS_CAT].[CAT_Item] SET EntityId = [CDS_ITM].[VW_Inventory].EntityId FROM [CDS_CAT].[CAT_Item] INNER JOIN [CDS_ITM].[VW_Inventory] on CAT_Item.Name = VW_Inventory.Name WHERE CAT_Item.EntityId IS NULL";
                //System.Data.SqlClient.SqlCommand sqlCommand = CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.GetCommand(query.ToString(), false);

                //sqlCommand.ExecuteNonQuery();

                ////if (sqlCommand.ExecuteNonQuery() == 0)
                ////    throw new Exception("The sql command did not affect any rows!", null);

                //CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.CommitTransaction();
                DataContext.EntityCatalogueContext.Database.CommandTimeout = 0;
                DataContext.EntityCatalogueContext.Database.ExecuteSqlCommand(query.ToString());

                query = String.Format("INSERT INTO [CDS_CAT].[CAT_MetaData] {0} SELECT DISTINCT CAT_Meta.Id, CAT_ItemData.ItemId, CAT_Category.Id, '', GETDATE(), 1 FROM [CDS_CAT].[CAT_Category] INNER JOIN [CDS_CAT].[CAT_Meta] on CAT_Category.Id = CAT_Meta.CategoryId INNER JOIN [CDS_CAT].[CAT_ItemData] ON CAT_ItemData.CategoryId = CAT_Category.Id LEFT JOIN [CDS_CAT].[CAT_MetaData] ON CAT_MetaData.MetaId = CAT_Meta.Id AND CAT_MetaData.CategoryId = CAT_Category.Id WHERE Data IS NULL", Environment.NewLine);

                DataContext.EntityCatalogueContext.Database.ExecuteSqlCommand(query.ToString());
                
                UpdateTotal("CLEANUP", 1);
                UpdateProgress("CLEANUP", 1, false);
            }
            catch (Exception ex)
            {
                UpdateTotal("CLEANUP", 1);
                UpdateProgress("CLEANUP", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void WriteToServer(DataTable insertTable)
        {
             
            //if (CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.TransactionStatus == CompleteDataLayer.TransactionStatus.Closed)
            //    CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.BeginTransaction();
            var connection =  new System.Data.SqlClient.SqlConnection(
               DataContext.EntityCatalogueContext.Database.Connection.ConnectionString);
            connection.Open();
            var trans = connection.BeginTransaction();
            using (System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(
               //CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.GetConnection(),
              connection,
               System.Data.SqlClient.SqlBulkCopyOptions.TableLock |
               System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers |
               System.Data.SqlClient.SqlBulkCopyOptions.KeepIdentity,
               //CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.SqlTransaction
            trans
               ))
            {


                bulkCopy.DestinationTableName = String.Format("[CDS_CAT].[{0}]", insertTable.TableName);
                bulkCopy.BulkCopyTimeout = 0;

                UpdateTotal(insertTable.TableName, insertTable.Rows.Count);

                bulkCopy.NotifyAfter = ((insertTable.Rows.Count / 100) * 10) < 1 ? 1 : ((insertTable.Rows.Count / 100) * 10);
                bulkCopy.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(bulkCopy_SqlRowsCopied);

                
                bulkCopy.WriteToServer(insertTable);
                bulkCopy.Close();
                UpdateProgress(insertTable.TableName, insertTable.Rows.Count, false);
            }


            //CompleteDataLayer.ApplicationDataContext.EntityCatalogueContext.Instance.CommitTransaction();
            trans.Commit();
            connection.Close();

        }

        void bulkCopy_SqlRowsCopied(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
        {
            UpdateProgress((sender as System.Data.SqlClient.SqlBulkCopy).DestinationTableName.Split('.')[1].Replace("[", "").Replace("]", ""), (sender as System.Data.SqlClient.SqlBulkCopy).NotifyAfter, false);
            // (sender as System.Data.SqlClient.SqlBulkCopy).NotifyAfter = 1000;
        }

        public static void MoveDirectory(string source, string target)
        {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                    string targetFile = Path.Combine(folders.Target, Path.GetFileName(file));
                    if (!File.Exists(targetFile)) //File.Delete(targetFile);
                        File.Move(file, targetFile);
                }

                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                }
            }
            // Directory.Delete(source, true);
        }

        public void RunExport()
        {
            btnStart.Enabled = false;

            try
            {
                if (!Directory.Exists(@"C:\CatalogueExport"))
                    Directory.CreateDirectory(@"C:\CatalogueExport");

                var catalogue = ddlCatalogue.GetSelectedDataRow() as DB.CAT_Catalogue;
                if (catalogue != null && !Directory.Exists(catalogue.ImageDestination))
                {
                    Essential.BaseAlert.ShowAlert("Error", "Please set Image Directory before exporting catalogue", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                    return;
                }

                //System.Threading.Thread ExportCatalogueThread = new System.Threading.Thread(ExportCatalogue);
                //System.Threading.Thread ExportCategoriesThread = new System.Threading.Thread(ExportCategories);
                //System.Threading.Thread ExportMetasThread = new System.Threading.Thread(ExportMetas);
                //System.Threading.Thread ExportItemDatasThread = new System.Threading.Thread(ExportItemDatas);
                //System.Threading.Thread ExportMetaDatasThread = new System.Threading.Thread(ExportMetaDatas);
                //System.Threading.Thread ExportItemsThread = new System.Threading.Thread(ExportItems);
                //System.Threading.Thread ExportImagesThread = new System.Threading.Thread(ExportImages);

                //ExportCatalogueThread.Start();
                //ExportCategoriesThread.Start();
                //ExportMetasThread.Start();
                //ExportItemDatasThread.Start();
                //ExportMetaDatasThread.Start();
                //ExportItemsThread.Start();
                //ExportImagesThread.Start();
                ExportCatalogue();
                ExportCategories();
                ExportMetas();
                ExportItemDatas();
                ExportMetaDatas();
                ExportItems();

                ExportImages();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            finally
            {
                Directory.Delete(@"C:\CatalogueExport", true);
                btnStart.Enabled = true;
            }
        }

        private void ExportCatalogue()
        {
            try
            {
                var catalogue = ddlCatalogue.GetSelectedDataRow();
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\CatalogueExport\xmlCatalogue.xml");
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DB.CAT_Catalogue));

                writer.Serialize(file, (DB.CAT_Catalogue)catalogue);

                file.Close();

                UpdateTotal("CAT_Catalogue", 1);
                UpdateProgress("CAT_Catalogue", 1, false);
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Catalogue", 1);
                UpdateProgress("CAT_Catalogue", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        private void ExportCategories()
        {
            try
            {
                var categories = DataContext.EntityCatalogueContext.CAT_Category.Where(n => n.CatalogueId == this.Catalogue.Id);
                decimal total = categories.Count();
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\CatalogueExport\xmlCategories.xml");
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_Category>));

                writer.Serialize(file, (List<DB.CAT_Category>)categories.ToList());

                file.Close();
                UpdateTotal("CAT_Category", 1);
                UpdateProgress("CAT_Category", 1, false);

            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Category", 1);
                UpdateProgress("CAT_Category", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        private List<Int64> GetTreeIds(List<DB.CAT_Category> items, Int64? parentid)
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

        private void ExportMetas()
        {

            try
            {

                var metas = DataContext.EntityCatalogueContext.CAT_Meta.Where(n => DataContext.EntityCatalogueContext.CAT_Category.Where(cat => cat.CatalogueId == this.Catalogue.Id).Select(l => l.Id).Contains(n.CategoryId));
                decimal total = metas.Count();

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\CatalogueExport\xmlMetas.xml");
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_Meta>));

                writer.Serialize(file, (List<DB.CAT_Meta>)metas.ToList());

                file.Close();
                UpdateTotal("CAT_Meta", 1);
                UpdateProgress("CAT_Meta", 1, false);
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Meta", 1);
                UpdateProgress("CAT_Meta", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }

        }

        private void ExportMetaDatas()
        {
            try
            {
                var metadatas = DataContext.EntityCatalogueContext.CAT_MetaData.Where(n => DataContext.EntityCatalogueContext.CAT_Category.Where(cat => cat.CatalogueId == this.Catalogue.Id).Select(l => l.Id).Contains(n.CategoryId));
                //var metadatas = DataContext.EntityCatalogueContext.CAT_MetaData.Where(n => categories.Select(l => l.CategoryId).Contains(n.CategoryId));
                decimal total = metadatas.Count();

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\CatalogueExport\xmlMetaDatas.xml");
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_MetaData>));

                writer.Serialize(file, (List<DB.CAT_MetaData>)metadatas.ToList());

                file.Close();
                UpdateTotal("CAT_MetaData", 1);
                UpdateProgress("CAT_MetaData", 1, false);
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_MetaData", 1);
                UpdateProgress("CAT_MetaData", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ExportItems()
        {
            try
            {
                var categories = DataContext.EntityCatalogueContext.CAT_Category.Where(n => n.CatalogueId == this.Catalogue.Id);

                //var items = DataContext.EntityCatalogueContext.CAT_Item
                //    .GroupJoin(DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => categories.Select(l => l.CategoryId).Contains(n.CategoryId)), item => item.Id, data => data.ItemId, 
                //    (item, data) => new { item.Id, item.Name, stockcode = DataContext.EntityCatalogueContext.tblInventories.Where(i => i.iInventoryId == item.StockId).FirstOrDefault().sNameAlphaPart })
                //    ;

                // TODO : Need to link up stock codes with items later
                var items = DataContext.EntityCatalogueContext.CAT_Item
                    .GroupJoin(DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => categories.Select(l => l.CategoryId).Contains(n.CategoryId)), item => item.Id, data => data.ItemId,
                    (item, data) => item)
                    ;

                decimal total = categories.Count();

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\CatalogueExport\xmlItems.xml");
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_Item>));

                writer.Serialize(file, (List<DB.CAT_Item>)items.ToList());

                file.Close();
                UpdateTotal("CAT_Item", 1);
                UpdateProgress("CAT_Item", 1, false);
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_Item", 1);
                UpdateProgress("CAT_Item", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ExportItemDatas()
        {
            try
            {
                var categories = DataContext.EntityCatalogueContext.CAT_Category.Where(n => n.CatalogueId == this.Catalogue.Id).Select(l => l.Id);

                //var itemdatas = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => categories.Select(l => l.CategoryId).Contains(n.CategoryId))
                //    .GroupJoin(DataContext.EntityCatalogueContext.CAT_Item, data => data.ItemId, item => item.Id, (data, item) => 
                //        new { data.Id, data.ItemId, data.ParentItemId, data.CategoryId })
                //    ;

                var itemdatas = DataContext.EntityCatalogueContext.CAT_ItemData.Where(n => categories.Contains(n.CategoryId))
                    //.GroupJoin(DataContext.EntityCatalogueContext.CAT_Item, data => data.ItemId, item => item.Id, (data, item) =>
                    //    data)
                ;

                decimal total = categories.Count();

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\CatalogueExport\xmlItemDatas.xml");
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<DB.CAT_ItemData>));
                List<DB.CAT_ItemData> ass = itemdatas.ToList();
                writer.Serialize(file, (List<DB.CAT_ItemData>)itemdatas.ToList());

                file.Close();
                UpdateTotal("CAT_ItemData", 1);
                UpdateProgress("CAT_ItemData", 1, false);
            }
            catch (Exception ex)
            {
                UpdateTotal("CAT_ItemData", 1);
                UpdateProgress("CAT_ItemData", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ExportImages()
        {
            try
            {
                if (((DB.CAT_Catalogue)ddlCatalogue.GetSelectedDataRow()).ImageDestination != null)
                {
                    if (!Directory.Exists(@"C:\CatalogueExport"))
                        Directory.CreateDirectory(@"C:\CatalogueExport");

                    ZipFile file = new ZipFile();


                    decimal total = 2;
                    decimal progress = 0;
                    using (StreamWriter sr = new StreamWriter(@"C:\CatalogueExport\DirectoryInfo.txt"))
                    {
                        sr.Write(imageLocation.Split(':').Last(n => !n.Equals("\\")));
                    }
                    UpdateTotal("IMAGES", 3);

                    file.AddDirectory(imageLocation, imageLocation);
                    UpdateProgress("IMAGES", 1, false);


                    file.AddDirectory(@"C:\CatalogueExport");
                    UpdateProgress("IMAGES", 2, false);

                    SaveFileDialog zipLocation = new SaveFileDialog() { Filter = "ZIP File (*.zip)|*.zip" };
                    zipLocation.FileName = this.Catalogue.Name + ".zip";
                    zipLocation.ShowDialog();

                    file.Save(zipLocation.FileName);
                    UpdateProgress("IMAGES", 3, false);
                }
                else
                {
                    Essential.BaseAlert.ShowAlert("Information", "No Image location set not images were exported", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    UpdateTotal("IMAGES", 1);
                    UpdateProgress("IMAGES", 1, true);
                }
            }
            catch (Exception ex)
            {
                UpdateTotal("IMAGES", 1);
                UpdateProgress("IMAGES", 1, true);
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
         
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!ValidateBeforeStart())
                return;

            statusList.ForEach(n => n.Progress = 0);

            switch (toDo)
            {
                case "Import":
                    RunImport();
                    break;
                case "Export":
                    RunExport();
                    break;
            }
        }

        private bool ValidateBeforeStart()
        {
            bool isValid = true;

            switch (toDo)
            {
                case "Import":
                    isValid = ddlCatalogue.GetSelectedDataRow() == null && File.Exists(catalogueLocation.FileName) && Directory.Exists(catalogueImageLocation.SelectedPath);
                    break;
                case "Export":
                    isValid = ddlCatalogue.GetSelectedDataRow() != null;
                    break;
            }

            if (isValid)
                btnStart.Enabled = true;

            return isValid;
        }

        private void btnCatalogueLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            catalogueLocation.ShowDialog();
            if (File.Exists(catalogueLocation.FileName) && (new FileInfo(catalogueLocation.FileName)).Extension.ToUpper().Equals(".ZIP"))
            {
                btnCatalogueLocation.Text = catalogueLocation.FileName;
                ValidateBeforeStart();
            }
        }

        private void btnImageLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            catalogueImageLocation.ShowDialog();
            if (Directory.Exists(catalogueImageLocation.SelectedPath))
            {
                btnImageLocation.Text = catalogueImageLocation.SelectedPath;
                ValidateBeforeStart();
            }
        }

        private void ddlCatalogue_EditValueChanged(object sender, EventArgs e)
        {
            ValidateBeforeStart();
            imageLocation = ((DB.CAT_Catalogue)ddlCatalogue.GetSelectedDataRow()).ImageDestination;
        }
         
        private void UpdateProgress(string tablename, decimal progress, bool failed)
        {
            ImportExportStatus currentEntry = ((List<ImportExportStatus>)BindingSource.DataSource).Where(n => n.TableName == tablename).FirstOrDefault();

            currentEntry.Progress += (int)((progress / currentEntry.Total) * 100);

            grdStatus.Invoke(new UpdateGridCallback(UpdateGrid));

            if ((int)((progress / currentEntry.Total) * 100) == 100)
            {
                currentEntry.Progress = (int)((progress / currentEntry.Total) * 100);
                currentEntry.Image = imageCollectionStatus.Images[1];

                grdStatus.Invoke(new UpdateGridCallback(UpdateGrid));
            }
            else if ((int)((progress / currentEntry.Total) * 100) == 75)
            {
                currentEntry.Progress = (int)((progress / currentEntry.Total) * 100);

                grdStatus.Invoke(new UpdateGridCallback(UpdateGrid));
            }
            else
                if ((int)((progress / currentEntry.Total) * 100) == 50)
                {
                    currentEntry.Progress = (int)((progress / currentEntry.Total) * 100);

                    grdStatus.Invoke(new UpdateGridCallback(UpdateGrid));
                }
                else
                    if ((int)((progress / currentEntry.Total) * 100) == 25)
                    {
                        currentEntry.Progress = (int)((progress / currentEntry.Total) * 100);

                        grdStatus.Invoke(new UpdateGridCallback(UpdateGrid));
                    }

            if (failed)
            {
                currentEntry.Progress = (int)((progress / currentEntry.Total) * 100);
                currentEntry.Image = imageCollectionStatus.Images[2];
                grdStatus.Invoke(new UpdateGridCallback(UpdateGrid));
            }
        }

        private void UpdateTotal(string tablename, decimal total)
        {
            ImportExportStatus currentEntry = ((List<ImportExportStatus>)BindingSource.DataSource).Where(n => n.TableName == tablename).FirstOrDefault();
            currentEntry.Total = (int)total;
        }
         
        public void UpdateGrid()
        {
            grdStatus.RefreshDataSource();
            grdStatus.Refresh();
        }

        public delegate void UpdateGridCallback();

    }
     
    public class ImportExportStatus
    {
        public Int16 Id { get; set; }
        public String Description { get; set; }
        public Int32 Progress { get; set; }
        public Int32 Total { get; set; }
        public String TableName { get; set; }
        public Image Image { get; set; }
    }
     
}
