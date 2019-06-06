namespace CDS.Client.Desktop.Main
{
    partial class ModuleWizard
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
            this.wcModule = new DevExpress.XtraWizard.WizardControl();
            this.wpWelcome = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wpSelectModule = new DevExpress.XtraWizard.WizardPage();
            this.grdModule = new DevExpress.XtraGrid.GridControl();
            this.InstantFeedbackSourceModule = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.grvModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.wpComplete = new DevExpress.XtraWizard.CompletionWizardPage();
            this.txtAccessCode = new DevExpress.XtraEditors.TextEdit();
            this.itmModuleWizard = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcModule)).BeginInit();
            this.wcModule.SuspendLayout();
            this.wpSelectModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            this.wpComplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccessCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmModuleWizard)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.wcModule);
            this.LayoutControl.Size = new System.Drawing.Size(996, 577);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmModuleWizard});
            this.LayoutGroup.Size = new System.Drawing.Size(996, 577);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            // 
            // wcModule
            // 
            this.wcModule.Controls.Add(this.wpWelcome);
            this.wcModule.Controls.Add(this.wpSelectModule);
            this.wcModule.Controls.Add(this.wpComplete);
            this.wcModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcModule.Location = new System.Drawing.Point(12, 12);
            this.wcModule.Name = "wcModule";
            this.wcModule.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wpWelcome,
            this.wpSelectModule,
            this.wpComplete});
            this.wcModule.Size = new System.Drawing.Size(972, 553);
            this.wcModule.FinishClick += new System.ComponentModel.CancelEventHandler(this.wcModule_FinishClick);
            this.wcModule.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wcModule_NextClick);
            this.wcModule.PrevClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wcModule_PrevClick);
            // 
            // wpWelcome
            // 
            this.wpWelcome.IntroductionText = "This wizard guiding you through a series of simple steps to activate a CDS Module" +
    "";
            this.wpWelcome.Name = "wpWelcome";
            this.wpWelcome.Size = new System.Drawing.Size(755, 421);
            this.wpWelcome.Text = "Welcome to the Module Activation wizard";
            // 
            // wpSelectModule
            // 
            this.wpSelectModule.Controls.Add(this.grdModule);
            this.wpSelectModule.DescriptionText = "Select a Module below";
            this.wpSelectModule.Name = "wpSelectModule";
            this.wpSelectModule.Size = new System.Drawing.Size(940, 410);
            this.wpSelectModule.Text = "Available Modules";
            // 
            // grdModule
            // 
            this.grdModule.DataSource = this.InstantFeedbackSourceModule;
            this.grdModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdModule.Location = new System.Drawing.Point(0, 0);
            this.grdModule.MainView = this.grvModule;
            this.grdModule.MenuManager = this.RibbonControl;
            this.grdModule.Name = "grdModule";
            this.grdModule.Size = new System.Drawing.Size(940, 410);
            this.grdModule.TabIndex = 0;
            this.grdModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvModule});
            // 
            // InstantFeedbackSourceModule
            // 
            this.InstantFeedbackSourceModule.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Module);
            this.InstantFeedbackSourceModule.KeyExpression = "Id";
            this.InstantFeedbackSourceModule.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceModule_GetQueryable);
            // 
            // grvModule
            // 
            this.grvModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModule,
            this.colDescription,
            this.colAccess});
            this.grvModule.GridControl = this.grdModule;
            this.grvModule.Name = "grvModule";
            this.grvModule.OptionsView.ShowGroupPanel = false;
            // 
            // colModule
            // 
            this.colModule.FieldName = "Module";
            this.colModule.Name = "colModule";
            this.colModule.Visible = true;
            this.colModule.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colAccess
            // 
            this.colAccess.FieldName = "Access";
            this.colAccess.Name = "colAccess";
            this.colAccess.Visible = true;
            this.colAccess.VisibleIndex = 2;
            // 
            // wpComplete
            // 
            this.wpComplete.Controls.Add(this.txtAccessCode);
            this.wpComplete.FinishText = "Enter you access code the the text box below and click on Save";
            this.wpComplete.Name = "wpComplete";
            this.wpComplete.ProceedText = "Click on Save in the bar at the top of the application";
            this.wpComplete.Size = new System.Drawing.Size(755, 421);
            // 
            // txtAccessCode
            // 
            this.txtAccessCode.Location = new System.Drawing.Point(0, 20);
            this.txtAccessCode.MenuManager = this.RibbonControl;
            this.txtAccessCode.Name = "txtAccessCode";
            this.txtAccessCode.Size = new System.Drawing.Size(755, 20);
            this.txtAccessCode.TabIndex = 0;
            // 
            // itmModuleWizard
            // 
            this.itmModuleWizard.Control = this.wcModule;
            this.itmModuleWizard.CustomizationFormText = "itmModuleWizard";
            this.itmModuleWizard.Location = new System.Drawing.Point(0, 0);
            this.itmModuleWizard.Name = "itmModuleWizard";
            this.itmModuleWizard.Size = new System.Drawing.Size(976, 557);
            this.itmModuleWizard.Text = "itmModuleWizard";
            this.itmModuleWizard.TextSize = new System.Drawing.Size(0, 0);
            this.itmModuleWizard.TextToControlDistance = 0;
            this.itmModuleWizard.TextVisible = false;
            // 
            // ModuleWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 728);
            this.Name = "ModuleWizard";
            this.Text = "Module Wizard";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcModule)).EndInit();
            this.wcModule.ResumeLayout(false);
            this.wpSelectModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            this.wpComplete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAccessCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmModuleWizard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wcModule;
        private DevExpress.XtraWizard.WelcomeWizardPage wpWelcome;
        private DevExpress.XtraWizard.WizardPage wpSelectModule;
        private DevExpress.XtraWizard.CompletionWizardPage wpComplete;
        private DevExpress.XtraLayout.LayoutControlItem itmModuleWizard;
        private DevExpress.XtraGrid.GridControl grdModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModule;
        private DevExpress.XtraGrid.Columns.GridColumn colModule;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAccess;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceModule;
        private DevExpress.XtraEditors.TextEdit txtAccessCode;
    }
}
