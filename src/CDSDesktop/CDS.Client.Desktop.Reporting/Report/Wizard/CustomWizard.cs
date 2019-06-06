using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.Design;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Data.Common;
using System.Data;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using DevExpress.XtraReports.Parameters;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public class CustomWizard : XRWizardRunnerBase
    {
        public CustomWizard(XtraReport report)
            : base(report)
        {
            //this.Wizard = new NewStandardReportWizard(report);
            //((NewStandardReportWizard)this.Wizard).ConnectionString = "Provider=SQLOLEDB;" + CDS.Client.DataAccessLayer.ApplicationContext.Instance.SqlConnectionString.ConnectionString;
            //((NewStandardReportWizard)this.Wizard).DatasetName = "CompleteDistributionDataSet";
            //this.Wizard = new XtraReportWizard(report);
            this.Wizard = new NewStandardReportWizard(report);

            ((XtraReportWizard)this.Wizard).ConnectionString = "Provider=SQLOLEDB;" + BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
            ((XtraReportWizard)this.Wizard).DatasetName = "CompleteDistributionDataSet";
        }

        public DialogResult Run()
        {

            if (this.Report == null)
                return DialogResult.Cancel;

            XtraReportWizardForm form = new XtraReportWizardForm(Wizard.DesignerHost);

            form.Controls.AddRange(new Control[] {
                new WizPageWelcome(this), 
                //new WizPageWelcomeCustom(this), 
                //new WizPageDataset(this), 
                //new WizPageConnectionCustom(this),          // Custom
                //new WizPageDataOption(this),                // New
                //new WizPageTablesCustom(this),              // Custom
                //new WizPageQuery(this),                     // New
                //new WizPageChooseFieldsCustom(this),        // Custom
                //new WizPageGrouping(this), 
                //new WizPageSummary(this), 
                ////new WizPageGroupedLayout(this), 
                //new WizPageLayoutCustom(this), 
                //new WizPageUngroupedLayout(this), 
                ////new WizPageStyle(this),   //custom 
                //new WizPageStylesCustom(this),
                //new WizPageReportTitle(this), 
                //new WizPageLabelType(this), 
                //new WizPageLabelOptions(this)               //, and so on...
                });



            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                Wizard.BuildReport();
                foreach (SqlParameter param in ((SqlDataAdapter)Report.DataAdapter).SelectCommand.Parameters)
                {
                    DevExpress.XtraReports.Parameters.Parameter xParam = new DevExpress.XtraReports.Parameters.Parameter();
                    xParam.Description = param.ParameterName.Replace('_', ' ');
                    xParam.Name = param.ParameterName;
                    xParam.Visible = true;
                    xParam.Value = param.Value;
                    switch (param.SqlDbType.ToString())
                    {
                        case "BigInt":
                            xParam.Type = typeof(Int64);
                            break;
                        case "Bit":
                            xParam.Type = typeof(Boolean);
                            break;
                        case "DateTime":
                            xParam.Type = typeof(DateTime);
                            break;
                        case "Money":
                        case "Decimal":
                            xParam.Type = typeof(Decimal);
                            break;
                        case "Int":
                            xParam.Type = typeof(Int32);
                            break;
                        case "NVarChar":
                            xParam.Type = typeof(String);
                            break;
                    }

                    Report.Parameters.Add(xParam);


                }
            }

            return result;
        }
    }

    public class XtraReportWizard : NewStandardReportWizard
    {
        public XtraReportWizard(XtraReport report)
            : base(report)
        {
        }
        public override void BuildReport()
        {
            base.BuildReport();
            // Add copyright and logo to the page footer

            //ReportHeaderBand headerBand = Report.Bands[BandKind.ReportHeader] as ReportHeaderBand;
            //if (headerBand != null)
            //{
            //    if (headerBand.HeightF < 60)
            //        headerBand.HeightF = 60;

            //    //XRLabel lblCompanyName = new XRLabel();

            //    //lblCompanyName.Dpi = 254F;
            //    //lblCompanyName.LocationFloat = new DevExpress.Utils.PointFloat(13.54724F, 122F);
            //    //lblCompanyName.Font = new System.Drawing.Font("Eurostile", 10F);
            //    //lblCompanyName.Name = "lblCompanyName";
            //    //lblCompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254F);
            //    //lblCompanyName.SizeF = new System.Drawing.SizeF(1833.033F, 43.60333F);
            //    //lblCompanyName.Text = CompleteDataLayer.ApplicationContext.Instance.CompanySiteName;

            //    //headerBand.Controls.Add(lblCompanyName);

            //    //XRLabel lblParamaters = new XRLabel();

            //    //lblParamaters.Dpi = 254F;
            //    //lblParamaters.LocationFloat = new DevExpress.Utils.PointFloat(13.54724F, 177.48F);
            //    //lblParamaters.Multiline = true;
            //    //lblParamaters.Name = "lblParamaters";
            //    //lblParamaters.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 254F);
            //    //lblParamaters.SizeF = new System.Drawing.SizeF(1833.033F, 90.17F);
            //    //lblParamaters.Text = "";


            //    //headerBand.Controls.Add(lblParamaters);

            //    IDesignerHost designerHost = (IDesignerHost)this.DesignerHost.GetService(typeof(IDesignerHost));

            //    designerHost.Container.Add(lblCompanyName);
            //    //designerHost.Container.Add(lblParamaters);
            //}

            PageFooterBand footerBand = Report.Bands[BandKind.PageFooter] as PageFooterBand;
            if (footerBand != null)
            {
                if (footerBand.HeightF < 60)
                    footerBand.HeightF = 60;

                XRPageInfo pageInfo1 = (XRPageInfo)((DevExpress.XtraReports.UI.Band)footerBand).Controls["pageInfo1"];

                pageInfo1.Dpi = 254F;
                pageInfo1.Font = new System.Drawing.Font("Eurostile", 10F, System.Drawing.FontStyle.Bold);
                pageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(13.54724F, 25.00002F);
                pageInfo1.Name = "pageInfo1";
                pageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
                pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
                pageInfo1.SizeF = new System.Drawing.SizeF(472.7574F, 58.42F);
                pageInfo1.StyleName = "PageInfo";
                pageInfo1.StylePriority.UseFont = false;

                XRPageInfo pageInfo2 = (XRPageInfo)((DevExpress.XtraReports.UI.Band)footerBand).Controls["pageInfo2"];

                pageInfo2.Dpi = 254F;
                pageInfo2.Font = new System.Drawing.Font("Eurostile", 10F, System.Drawing.FontStyle.Bold);
                pageInfo2.Format = "Page {0} of {1}";
                pageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(696.8076F, 25.00002F);
                pageInfo2.Name = "pageInfo2";
                pageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
                pageInfo2.SizeF = new System.Drawing.SizeF(354.33F, 58.41999F);
                pageInfo2.StyleName = "PageInfo";
                pageInfo2.StylePriority.UseFont = false;
                pageInfo2.StylePriority.UseTextAlignment = false;
                pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;

                XRPageInfo pageInfo3 = new XRPageInfo();// (XRPageInfo)((DevExpress.XtraReports.UI.Band)footerBand).Controls["pageInfo3"];


                pageInfo3.Dpi = 254F;
                pageInfo3.Font = new System.Drawing.Font("Eurostile", 10F, System.Drawing.FontStyle.Bold);
                pageInfo3.Format = "{0:\'COMPLETE DISTRIBUTION ©\' yyyy}";
                pageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(1226.08F, 25.00002F);
                pageInfo3.Name = "pageInfo3";
                pageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
                pageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
                pageInfo3.SizeF = new System.Drawing.SizeF(618.8075F, 58.41999F);
                pageInfo3.StyleName = "PageInfo";
                pageInfo3.StylePriority.UseFont = false;
                pageInfo3.StylePriority.UseTextAlignment = false;
                pageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;

                footerBand.Controls.Add(pageInfo3);

                XRLine xrLine1 = new XRLine();

                xrLine1.Dpi = 254F;
                xrLine1.LineWidth = 3;
                xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(13.54724F, 0F);
                xrLine1.Name = "xrLine1";
                xrLine1.SizeF = new System.Drawing.SizeF(1831.34F, 18.20334F);

                footerBand.Controls.Add(xrLine1);

                //XRPictureBox picture = new XRPictureBox();
                //picture.Image = global::CDS.Shared.Resources.Properties.Resources.CDSReportLogo;
                //picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.CenterImage;
                //picture.LocationFloat = new DevExpress.Utils.PointFloat(727.5F, 15.24003F);
                //picture.SizeF = new System.Drawing.SizeF(396.0F, 147.32F);
                //picture.Dpi = 254F;
                // picture.LockedInUserDesigner = false;

                //footerBand.Controls.Add(picture);

                IDesignerHost designerHost = (IDesignerHost)this.DesignerHost.GetService(typeof(IDesignerHost));

                //designerHost.Container.Add(picture);
                //designerHost.Container.Add(label);
            }
        }
    }

    public class DataWizard : XRWizardRunnerBase
    {
        public bool NextAfterFieldSelect = true;

        private DataSet dataset = null;
        private DataAdapter adapter = null;

        public DataAdapter DataAdapter
        {
            get
            {
                return adapter;
            }
        }

        public Object Tag { get; set; }

        public DataSet DataSet
        {
            get
            {
                return dataset;
            }
        }

        public DataWizard(XtraReport report)
            : base(report)
        {
            this.Wizard = new NewStandardReportWizard(report);
            this.adapter = report.DataAdapter as DataAdapter;
            this.dataset = report.DataSource as DataSet;

            ((NewStandardReportWizard)this.Wizard).ConnectionString = "Provider=SQLOLEDB;" + BL.ApplicationDataContext.Instance.SqlConnectionString.ConnectionString;
            ((NewStandardReportWizard)this.Wizard).DatasetName = "CompleteDistributionDataSet";

        }

        public DialogResult Run()
        {

            if (this.Report == null)
                return DialogResult.Cancel;

            XtraReportWizardForm form = new XtraReportWizardForm(Wizard.DesignerHost);

            form.Controls.AddRange(new Control[] {
                new WizPageDataOption(this),                // New
                new WizPageTablesCustom(this),              // Custom
                new WizPageQuery(this),                     // New
                new WizPageChooseFieldsCustom(this),        // Custom
                new WizPageGrouping(this), 
                new WizPageSummary(this), 
                new WizPageGroupedLayout(this), 
                new WizPageUngroupedLayout(this),
                 new WizPageStylesCustom(this),
                new WizPageReportTitle(this), 
                new WizPageLabelType(this), 
                new WizPageLabelOptions(this) 
                });

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Wizard.BuildReport();  


                //var kk = this.Wizard;
                NewStandardReportWizard wiz = this.Wizard as NewStandardReportWizard;
                //this.Report.DataSource = wiz.Dataset;
                //this.Report.DataMember = wiz.Dataset.Tables[0];
                //this.Report.DataAdapter = wiz.DataAdapters[0];
                this.adapter = wiz.DataAdapters[0] as DataAdapter;
                this.dataset = wiz.Dataset;

                //((NewStandardReportWizard)this.Wizard).Dataset.DataSetName = wiz.Dataset.Tables[0].ToString() + "DataSet";
                //((NewStandardReportWizard)this.Wizard).DatasetName = wiz.Dataset.Tables[0].ToString() + "DataSet";

                //this.dataset.DataSetName = wiz.Dataset.Tables[0].ToString() + "DataSet";
                //((DevExpress.XtraReports.Design.XRWizardRunnerBase)(this))

                var host = ((DevExpress.XtraReports.Design.XRWizardRunnerBase)(this)).Wizard.DesignerHost;
                //var component = ((DevExpress.XtraReports.Design.XRWizardRunnerBase)(this)).Report.DataSource as System.ComponentModel.IComponent;


                //if (component != null)
                //{
                //    host.Container.Remove(component);
                //}
                //host.Container.Add(((DevExpress.XtraReports.Design.NewStandardReportWizard)(this.Wizard)).DataAdapters[0] as DataAdapter); 
                //host.Container.Add(((NewStandardReportWizard)this.Wizard).Dataset); 
                host.Container.Add(wiz.DataAdapters[0] as DataAdapter);
                host.Container.Add(wiz.Dataset);
                //Report.DataSource = wiz.Dataset;

                //var fieldList = (DevExpress.XtraReports.UserDesigner.FieldListDockPanel)xrDesignDockManager1[DevExpress.XtraReports.UserDesigner.DesignDockPanelType.FieldList];
                //var host = (IDesignerHost)xrDesignMdiController1.ActiveDesignPanel.GetService(typeof(IDesignerHost));
                //var component = Report.DataSource as IComponent;
                //if (component != null)
                //{
                //    host.Container.Remove(component);
                //}
                //host.Container.Add(dataSet);
                //Report.DataSource = dataSet;
                //fieldList.UpdateDataSource(host);

                foreach (SqlParameter param in ((SqlDataAdapter)Report.DataAdapter).SelectCommand.Parameters)
                {
                    DevExpress.XtraReports.Parameters.Parameter xParam = new DevExpress.XtraReports.Parameters.Parameter();
                    xParam.Description = param.ParameterName.Replace('_', ' ');
                    xParam.Name = param.ParameterName;
                    xParam.Visible = true;
                    xParam.Value = param.Value;
                    switch (param.SqlDbType.ToString())
                    {
                        case "BigInt":
                            xParam.Type = typeof(Int64);
                            break;
                        case "Bit":
                            xParam.Type = typeof(Boolean);
                            break;
                        case "DateTime":
                            xParam.Type = typeof(DateTime);
                            break;
                        case "Money":
                        case "Decimal":
                            xParam.Type = typeof(Decimal);
                            break;
                        case "Int":
                            xParam.Type = typeof(Int32);
                            break;
                        case "NVarChar":
                            xParam.Type = typeof(String);
                            break;
                    }

                    Report.Parameters.Add(xParam);
                }
            }

            return result;
        }
    }
}
