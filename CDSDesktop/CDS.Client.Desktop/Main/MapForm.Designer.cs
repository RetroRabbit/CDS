namespace CDS.Client.Desktop.Main
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1 = new DevExpress.XtraMap.ImageTilesLayer();
            DevExpress.XtraMap.OpenStreetMapDataProvider openStreetMapDataProvider1 = new DevExpress.XtraMap.OpenStreetMapDataProvider();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.SqlGeometryDataAdapter sqlGeometryDataAdapter1 = new DevExpress.XtraMap.SqlGeometryDataAdapter();
            DevExpress.XtraMap.MiniMap miniMap1 = new DevExpress.XtraMap.MiniMap();
            DevExpress.XtraMap.DynamicMiniMapBehavior dynamicMiniMapBehavior1 = new DevExpress.XtraMap.DynamicMiniMapBehavior();
            DevExpress.XtraMap.MiniMapImageTilesLayer miniMapImageTilesLayer1 = new DevExpress.XtraMap.MiniMapImageTilesLayer();
            DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            DevExpress.XtraMap.MiniMapVectorItemsLayer miniMapVectorItemsLayer1 = new DevExpress.XtraMap.MiniMapVectorItemsLayer();
            DevExpress.XtraMap.MapItemStorage mapItemStorage1 = new DevExpress.XtraMap.MapItemStorage();
            this.mcMap = new DevExpress.XtraMap.MapControl();
            this.itmMap = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mcMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMap)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.mcMap);
            this.LayoutControl.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LayoutControl.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmMap});
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            // 
            // mcMap
            // 
            imageTilesLayer1.DataProvider = openStreetMapDataProvider1;
            sqlGeometryDataAdapter1.ConnectionString = "Data Source=.;Initial Catalog=cds_pegasus;Persist Security Info=True;User ID=sa;P" +
    "assword=rabbit";
            sqlGeometryDataAdapter1.SpatialDataMember = "geometry";
            sqlGeometryDataAdapter1.SqlText = "SELECT [Id],[section],[description],[geometry],[geography] FROM [dbo].[RPT_MapLay" +
    "out]";
            vectorItemsLayer1.Data = sqlGeometryDataAdapter1;
            this.mcMap.Layers.Add(imageTilesLayer1);
            this.mcMap.Layers.Add(vectorItemsLayer1);
            this.mcMap.Location = new System.Drawing.Point(12, 12);
            miniMap1.Behavior = dynamicMiniMapBehavior1;
            bingMapDataProvider1.BingKey = "YOUR BING MAPS KEY";
            miniMapImageTilesLayer1.DataProvider = bingMapDataProvider1;
            miniMapVectorItemsLayer1.Data = mapItemStorage1;
            miniMap1.Layers.Add(miniMapImageTilesLayer1);
            miniMap1.Layers.Add(miniMapVectorItemsLayer1);
            this.mcMap.MiniMap = miniMap1;
            this.mcMap.Name = "mcMap";
            this.mcMap.Size = new System.Drawing.Size(972, 553);
            this.mcMap.TabIndex = 4;
            // 
            // itmMap
            // 
            this.itmMap.Control = this.mcMap;
            this.itmMap.CustomizationFormText = "Map";
            this.itmMap.Location = new System.Drawing.Point(0, 0);
            this.itmMap.Name = "itmMap";
            this.itmMap.Size = new System.Drawing.Size(976, 557);
            this.itmMap.Text = "Map";
            this.itmMap.TextSize = new System.Drawing.Size(0, 0);
            this.itmMap.TextVisible = false;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "MapForm";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mcMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraMap.MapControl mcMap;
        private DevExpress.XtraLayout.LayoutControlItem itmMap;
    }
}
