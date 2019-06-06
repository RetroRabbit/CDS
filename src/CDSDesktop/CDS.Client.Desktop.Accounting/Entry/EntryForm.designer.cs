namespace CDS.Client.Desktop.Accounting.Entry
{
    partial class EntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            this.txtReference = new DevExpress.XtraEditors.TextEdit();
            this.itmReference = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.itmDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.datDate = new DevExpress.XtraEditors.DateEdit();
            this.itmDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ServerModeSourceCenter = new DevExpress.Data.Linq.LinqServerModeSource();
            this.pnlHeader = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmTrackNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTrackNumber = new DevExpress.XtraEditors.TextEdit();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ddlReference = new DevExpress.XtraEditors.ComboBoxEdit();
            this.itmStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceStatus = new DevExpress.Data.Linq.LinqServerModeSource();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.itmAutoPost = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkAutoPost = new DevExpress.XtraEditors.CheckEdit();
            this.itmNewTrackNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkNewTrackNumber = new DevExpress.XtraEditors.CheckEdit();
            this.ServerModeSourcePeriod = new DevExpress.Data.Linq.LinqServerModeSource();
            this.grdLines = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceLines = new System.Windows.Forms.BindingSource();
            this.grvLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAccountId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repAccounts = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.InstantFeedbackSourceAccount = new DevExpress.Data.Linq.LinqInstantFeedbackSource();
            this.repAccountsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCenterId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlCenters = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colAgingId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlAgings = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServerModeSourceAging = new DevExpress.Data.Linq.LinqServerModeSource();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itmLines = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlLines = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itmCreatedBy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCreatedBy = new DevExpress.XtraEditors.LookUpEdit();
            this.ServerModeSourceCreatedBy = new DevExpress.Data.Linq.LinqServerModeSource();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.itmCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgHistory = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnTrackHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnRejectEntry = new DevExpress.XtraBars.BarButtonItem();
            this.btnReverseEntry = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewDocument = new DevExpress.XtraBars.BarButtonItem();
            this.ServerModeSourceAbbreviation = new DevExpress.Data.Linq.LinqServerModeSource();
            this.btnApproveEntry = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTrackNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrackNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAutoPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoPost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNewTrackNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNewTrackNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repAccountsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCenters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAbbreviation)).BeginInit();
            this.SuspendLayout();
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(CDS.Client.DataAccessLayer.DB.GLX_Header);
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.ddlReference);
            this.LayoutControl.Controls.Add(this.chkNewTrackNumber);
            this.LayoutControl.Controls.Add(this.txtTrackNumber);
            this.LayoutControl.Controls.Add(this.txtCreatedOn);
            this.LayoutControl.Controls.Add(this.txtStatus);
            this.LayoutControl.Controls.Add(this.chkAutoPost);
            this.LayoutControl.Controls.Add(this.grdLines);
            this.LayoutControl.Controls.Add(this.datDate);
            this.LayoutControl.Controls.Add(this.txtDescription);
            this.LayoutControl.Controls.Add(this.txtReference);
            this.LayoutControl.Controls.Add(this.txtCreatedBy);
            this.LayoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1146, 354, 250, 350);
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
            this.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = false;
            this.LayoutControl.Size = new System.Drawing.Size(784, 418);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.pnlHeader,
            this.pnlLines,
            this.lcgHistory});
            this.LayoutGroup.Name = "Root";
            this.LayoutGroup.Size = new System.Drawing.Size(784, 418);
            this.LayoutGroup.Text = "Root";
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTrackHistory,
            this.btnRejectEntry,
            this.btnReverseEntry,
            this.btnViewDocument,
            this.btnApproveEntry});
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RibbonControl.Size = new System.Drawing.Size(784, 144);
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnTrackHistory);
            this.rpgActions.ItemLinks.Add(this.btnApproveEntry);
            this.rpgActions.ItemLinks.Add(this.btnRejectEntry);
            this.rpgActions.ItemLinks.Add(this.btnReverseEntry);
            this.rpgActions.ItemLinks.Add(this.btnViewDocument);
            // 
            // DefaultToolTipController
            // 
            // 
            // 
            // 
            this.DefaultToolTipController.DefaultController.AutoPopDelay = 10000;
            this.DefaultToolTipController.DefaultController.Rounded = true;
            this.DefaultToolTipController.DefaultController.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7;
            this.DefaultToolTipController.DefaultController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // txtReference
            // 
            this.txtReference.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Reference", true));
            this.txtReference.EnterMoveNextControl = true;
            this.txtReference.Location = new System.Drawing.Point(104, 67);
            this.txtReference.MenuManager = this.RibbonControl;
            this.txtReference.Name = "txtReference";
            this.txtReference.Properties.Leave += new System.EventHandler(this.txtReference_Properties_Leave);
            this.txtReference.Size = new System.Drawing.Size(656, 20);
            this.txtReference.StyleController = this.LayoutControl;
            this.txtReference.TabIndex = 4;
            // 
            // itmReference
            // 
            this.itmReference.Control = this.txtReference;
            this.itmReference.CustomizationFormText = "Reference";
            this.itmReference.Location = new System.Drawing.Point(0, 24);
            this.itmReference.Name = "itmReference";
            this.itmReference.Size = new System.Drawing.Size(740, 24);
            this.itmReference.Text = "Reference";
            this.itmReference.TextSize = new System.Drawing.Size(76, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Description", true));
            this.txtDescription.EnterMoveNextControl = true;
            this.txtDescription.Location = new System.Drawing.Point(104, 91);
            this.txtDescription.MenuManager = this.RibbonControl;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Leave += new System.EventHandler(this.txtDescription_Properties_Leave);
            this.txtDescription.Size = new System.Drawing.Size(656, 20);
            this.txtDescription.StyleController = this.LayoutControl;
            this.txtDescription.TabIndex = 5;
            // 
            // itmDescription
            // 
            this.itmDescription.Control = this.txtDescription;
            this.itmDescription.CustomizationFormText = "Description";
            this.itmDescription.Location = new System.Drawing.Point(0, 48);
            this.itmDescription.Name = "itmDescription";
            this.itmDescription.Size = new System.Drawing.Size(740, 24);
            this.itmDescription.Text = "Description";
            this.itmDescription.TextSize = new System.Drawing.Size(76, 13);
            // 
            // datDate
            // 
            this.datDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Date", true));
            this.datDate.EditValue = null;
            this.datDate.EnterMoveNextControl = true;
            this.datDate.Location = new System.Drawing.Point(104, 115);
            this.datDate.MenuManager = this.RibbonControl;
            this.datDate.Name = "datDate";
            this.datDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datDate.Size = new System.Drawing.Size(102, 20);
            this.datDate.StyleController = this.LayoutControl;
            this.datDate.TabIndex = 9;
            this.datDate.EditValueChanged += new System.EventHandler(this.datDate_EditValueChanged);
            // 
            // itmDate
            // 
            this.itmDate.Control = this.datDate;
            this.itmDate.CustomizationFormText = "Date";
            this.itmDate.Location = new System.Drawing.Point(0, 72);
            this.itmDate.Name = "itmDate";
            this.itmDate.Size = new System.Drawing.Size(186, 24);
            this.itmDate.Text = "Date";
            this.itmDate.TextSize = new System.Drawing.Size(76, 13);
            // 
            // ServerModeSourceCenter
            // 
            this.ServerModeSourceCenter.ElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Center);
            this.ServerModeSourceCenter.KeyExpression = "Id";
            // 
            // pnlHeader
            // 
            this.pnlHeader.CustomizationFormText = "Identity";
            this.pnlHeader.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmReference,
            this.itmDescription,
            this.itmTrackNumber,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.itmStatus,
            this.emptySpaceItem1,
            this.itmDate,
            this.itmAutoPost,
            this.itmNewTrackNumber});
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(764, 163);
            this.pnlHeader.Text = "Header";
            // 
            // itmTrackNumber
            // 
            this.itmTrackNumber.Control = this.txtTrackNumber;
            this.itmTrackNumber.CustomizationFormText = "Track Number";
            this.itmTrackNumber.Location = new System.Drawing.Point(559, 96);
            this.itmTrackNumber.Name = "itmTrackNumber";
            this.itmTrackNumber.Size = new System.Drawing.Size(181, 24);
            this.itmTrackNumber.Text = "Track Number";
            this.itmTrackNumber.TextSize = new System.Drawing.Size(76, 13);
            // 
            // txtTrackNumber
            // 
            this.txtTrackNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TrackId", true));
            this.txtTrackNumber.EditValue = "";
            this.txtTrackNumber.Enabled = false;
            this.txtTrackNumber.EnterMoveNextControl = true;
            this.txtTrackNumber.Location = new System.Drawing.Point(663, 139);
            this.txtTrackNumber.MenuManager = this.RibbonControl;
            this.txtTrackNumber.Name = "txtTrackNumber";
            this.txtTrackNumber.Size = new System.Drawing.Size(97, 20);
            this.txtTrackNumber.StyleController = this.LayoutControl;
            this.txtTrackNumber.TabIndex = 18;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(186, 72);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(272, 24);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ddlReference;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(740, 24);
            this.layoutControlItem2.Text = "Reference Auto";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(76, 13);
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // ddlReference
            // 
            this.ddlReference.Location = new System.Drawing.Point(104, 43);
            this.ddlReference.MenuManager = this.RibbonControl;
            this.ddlReference.Name = "ddlReference";
            this.ddlReference.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlReference.Size = new System.Drawing.Size(656, 20);
            this.ddlReference.StyleController = this.LayoutControl;
            this.ddlReference.TabIndex = 22;
            // 
            // itmStatus
            // 
            this.itmStatus.Control = this.txtStatus;
            this.itmStatus.CustomizationFormText = "Status";
            this.itmStatus.Location = new System.Drawing.Point(559, 72);
            this.itmStatus.Name = "itmStatus";
            this.itmStatus.Size = new System.Drawing.Size(181, 24);
            this.itmStatus.Text = "Status";
            this.itmStatus.TextSize = new System.Drawing.Size(76, 13);
            // 
            // txtStatus
            // 
            this.txtStatus.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "StatusId", true));
            this.txtStatus.Location = new System.Drawing.Point(663, 115);
            this.txtStatus.MenuManager = this.RibbonControl;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtStatus.Properties.DataSource = this.ServerModeSourceStatus;
            this.txtStatus.Properties.DisplayMember = "Name";
            this.txtStatus.Properties.NullText = "";
            this.txtStatus.Properties.ReadOnly = true;
            this.txtStatus.Properties.ValueMember = "Id";
            this.txtStatus.Size = new System.Drawing.Size(97, 18);
            this.txtStatus.StyleController = this.LayoutControl;
            this.txtStatus.TabIndex = 21;
            this.txtStatus.TabStop = false;
            // 
            // ServerModeSourceStatus
            // 
            this.ServerModeSourceStatus.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Status);
            this.ServerModeSourceStatus.KeyExpression = "[Id]";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(458, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // itmAutoPost
            // 
            this.itmAutoPost.Control = this.chkAutoPost;
            this.itmAutoPost.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.itmAutoPost.CustomizationFormText = "layoutControlItem1";
            this.itmAutoPost.Location = new System.Drawing.Point(458, 72);
            this.itmAutoPost.Name = "itmAutoPost";
            this.itmAutoPost.Size = new System.Drawing.Size(101, 24);
            this.itmAutoPost.Text = "itmAutoPost";
            this.itmAutoPost.TextSize = new System.Drawing.Size(0, 0);
            this.itmAutoPost.TextVisible = false;
            // 
            // chkAutoPost
            // 
            this.chkAutoPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoPost.Enabled = false;
            this.chkAutoPost.EnterMoveNextControl = true;
            this.chkAutoPost.Location = new System.Drawing.Point(482, 115);
            this.chkAutoPost.MenuManager = this.RibbonControl;
            this.chkAutoPost.Name = "chkAutoPost";
            this.chkAutoPost.Properties.Caption = "Auto Post";
            this.chkAutoPost.Properties.ReadOnly = true;
            this.chkAutoPost.Size = new System.Drawing.Size(97, 19);
            this.chkAutoPost.StyleController = this.LayoutControl;
            this.chkAutoPost.TabIndex = 20;
            // 
            // itmNewTrackNumber
            // 
            this.itmNewTrackNumber.Control = this.chkNewTrackNumber;
            this.itmNewTrackNumber.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.itmNewTrackNumber.CustomizationFormText = "New Track Number";
            this.itmNewTrackNumber.Location = new System.Drawing.Point(458, 96);
            this.itmNewTrackNumber.Name = "itmNewTrackNumber";
            this.itmNewTrackNumber.Size = new System.Drawing.Size(101, 24);
            this.itmNewTrackNumber.Text = "New Track Number";
            this.itmNewTrackNumber.TextSize = new System.Drawing.Size(0, 0);
            this.itmNewTrackNumber.TextVisible = false;
            // 
            // chkNewTrackNumber
            // 
            this.chkNewTrackNumber.EditValue = true;
            this.chkNewTrackNumber.EnterMoveNextControl = true;
            this.chkNewTrackNumber.Location = new System.Drawing.Point(482, 139);
            this.chkNewTrackNumber.MenuManager = this.RibbonControl;
            this.chkNewTrackNumber.Name = "chkNewTrackNumber";
            this.chkNewTrackNumber.Properties.Caption = "Auto Assign";
            this.chkNewTrackNumber.Size = new System.Drawing.Size(97, 19);
            this.chkNewTrackNumber.StyleController = this.LayoutControl;
            this.chkNewTrackNumber.TabIndex = 19;
            this.chkNewTrackNumber.CheckedChanged += new System.EventHandler(this.chkNewTrackNumber_CheckedChanged);
            // 
            // ServerModeSourcePeriod
            // 
            this.ServerModeSourcePeriod.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Period);
            this.ServerModeSourcePeriod.KeyExpression = "Id";
            // 
            // grdLines
            // 
            this.grdLines.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdLines.DataSource = this.BindingSourceLines;
            this.grdLines.Location = new System.Drawing.Point(24, 206);
            this.grdLines.MainView = this.grvLines;
            this.grdLines.MenuManager = this.RibbonControl;
            this.grdLines.Name = "grdLines";
            this.grdLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ddlAgings,
            this.ddlCenters,
            this.repAccounts});
            this.grdLines.Size = new System.Drawing.Size(736, 121);
            this.grdLines.TabIndex = 11;
            this.grdLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLines});
            // 
            // BindingSourceLines
            // 
            this.BindingSourceLines.DataSource = typeof(CDS.Client.DataAccessLayer.DB.GLX_Line);
            // 
            // grvLines
            // 
            this.grvLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccountId,
            this.colCenterId,
            this.colAgingId,
            this.colAmount});
            this.grvLines.GridControl = this.grdLines;
            this.grvLines.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.colAmount, "", "Total of all transactions")});
            this.grvLines.Name = "grvLines";
            this.grvLines.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvLines.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvLines.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.grvLines.OptionsCustomization.AllowColumnMoving = false;
            this.grvLines.OptionsCustomization.AllowFilter = false;
            this.grvLines.OptionsCustomization.AllowGroup = false;
            this.grvLines.OptionsCustomization.AllowQuickHideColumns = false;
            this.grvLines.OptionsCustomization.AllowSort = false;
            this.grvLines.OptionsFilter.AllowFilterEditor = false;
            this.grvLines.OptionsFind.AllowFindPanel = false;
            this.grvLines.OptionsMenu.EnableColumnMenu = false;
            this.grvLines.OptionsMenu.EnableFooterMenu = false;
            this.grvLines.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvLines.OptionsMenu.ShowAutoFilterRowItem = false;
            this.grvLines.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvLines.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvLines.OptionsView.ShowDetailButtons = false;
            this.grvLines.OptionsView.ShowFooter = true;
            this.grvLines.OptionsView.ShowGroupPanel = false;
            this.grvLines.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvLines_ShowingEditor);
            this.grvLines.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvLines_InitNewRow);
            this.grvLines.HiddenEditor += new System.EventHandler(this.grvLines_HiddenEditor);
            this.grvLines.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvLines_CellValueChanged);
            this.grvLines.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvLines_InvalidRowException);
            this.grvLines.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvLines_ValidateRow);
            this.grvLines.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grvLines_KeyUp);
            // 
            // colAccountId
            // 
            this.colAccountId.Caption = "Account";
            this.colAccountId.ColumnEdit = this.repAccounts;
            this.colAccountId.FieldName = "EntityId";
            this.colAccountId.MinWidth = 100;
            this.colAccountId.Name = "colAccountId";
            this.colAccountId.Visible = true;
            this.colAccountId.VisibleIndex = 0;
            this.colAccountId.Width = 458;
            // 
            // repAccounts
            // 
            this.repAccounts.AutoHeight = false;
            this.repAccounts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repAccounts.DataSource = this.InstantFeedbackSourceAccount;
            this.repAccounts.DisplayMember = "Title";
            this.repAccounts.Name = "repAccounts";
            this.repAccounts.NullText = "Select Account ...";
            this.repAccounts.ValueMember = "Id";
            this.repAccounts.View = this.repAccountsView;
            // 
            // InstantFeedbackSourceAccount
            // 
            this.InstantFeedbackSourceAccount.DesignTimeElementType = typeof(CDS.Client.DataAccessLayer.DB.VW_Account);
            this.InstantFeedbackSourceAccount.KeyExpression = "Id";
            this.InstantFeedbackSourceAccount.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.InstantFeedbackSourceAccount_GetQueryable);
            // 
            // repAccountsView
            // 
            this.repAccountsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colDescription,
            this.colAmount1});
            this.repAccountsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repAccountsView.Name = "repAccountsView";
            this.repAccountsView.OptionsCustomization.AllowColumnMoving = false;
            this.repAccountsView.OptionsCustomization.AllowColumnResizing = false;
            this.repAccountsView.OptionsMenu.EnableColumnMenu = false;
            this.repAccountsView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repAccountsView.OptionsView.ShowGroupPanel = false;
            this.repAccountsView.OptionsView.ShowIndicator = false;
            this.repAccountsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTitle, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colAmount1
            // 
            this.colAmount1.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount1.FieldName = "Amount";
            this.colAmount1.Name = "colAmount1";
            this.colAmount1.Visible = true;
            this.colAmount1.VisibleIndex = 2;
            // 
            // colCenterId
            // 
            this.colCenterId.Caption = "Center";
            this.colCenterId.ColumnEdit = this.ddlCenters;
            this.colCenterId.FieldName = "CenterId";
            this.colCenterId.MaxWidth = 100;
            this.colCenterId.MinWidth = 100;
            this.colCenterId.Name = "colCenterId";
            this.colCenterId.Visible = true;
            this.colCenterId.VisibleIndex = 1;
            this.colCenterId.Width = 100;
            // 
            // ddlCenters
            // 
            this.ddlCenters.AutoHeight = false;
            this.ddlCenters.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCenters.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodeMain", "Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlCenters.DataSource = this.ServerModeSourceCenter;
            this.ddlCenters.DisplayMember = "Title";
            this.ddlCenters.Name = "ddlCenters";
            this.ddlCenters.NullText = "";
            this.ddlCenters.ValueMember = "Id";
            // 
            // colAgingId
            // 
            this.colAgingId.Caption = "Aging";
            this.colAgingId.ColumnEdit = this.ddlAgings;
            this.colAgingId.FieldName = "AgingId";
            this.colAgingId.MaxWidth = 100;
            this.colAgingId.MinWidth = 100;
            this.colAgingId.Name = "colAgingId";
            this.colAgingId.Visible = true;
            this.colAgingId.VisibleIndex = 2;
            this.colAgingId.Width = 100;
            // 
            // ddlAgings
            // 
            this.ddlAgings.AutoHeight = false;
            this.ddlAgings.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAgings.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlAgings.DataSource = this.ServerModeSourceAging;
            this.ddlAgings.DisplayMember = "Name";
            this.ddlAgings.Name = "ddlAgings";
            this.ddlAgings.NullText = "";
            this.ddlAgings.ValueMember = "Id";
            // 
            // ServerModeSourceAging
            // 
            this.ServerModeSourceAging.ElementType = typeof(CDS.Client.DataAccessLayer.DB.GLX_Aging);
            this.ServerModeSourceAging.KeyExpression = "Id";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Amount";
            this.colAmount.DisplayFormat.FormatString = "# ### ### ##0.00 DR; # ### ### ##0.00 CR; 0.00";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 100;
            this.colAmount.MinWidth = 100;
            this.colAmount.Name = "colAmount";
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:# ### ### ##0.00 DR; # ### ### ##0.00 CR; BALANCED}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            this.colAmount.Width = 100;
            // 
            // itmLines
            // 
            this.itmLines.Control = this.grdLines;
            this.itmLines.CustomizationFormText = "Lines";
            this.itmLines.Location = new System.Drawing.Point(0, 0);
            this.itmLines.Name = "itmLines";
            this.itmLines.Size = new System.Drawing.Size(740, 125);
            this.itmLines.Text = "Lines";
            this.itmLines.TextSize = new System.Drawing.Size(0, 0);
            this.itmLines.TextVisible = false;
            // 
            // pnlLines
            // 
            this.pnlLines.CustomizationFormText = "Lines";
            this.pnlLines.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmLines});
            this.pnlLines.Location = new System.Drawing.Point(0, 163);
            this.pnlLines.Name = "pnlLines";
            this.pnlLines.Size = new System.Drawing.Size(764, 168);
            this.pnlLines.Text = "Lines";
            // 
            // itmCreatedBy
            // 
            this.itmCreatedBy.Control = this.txtCreatedBy;
            this.itmCreatedBy.CustomizationFormText = "Created By";
            this.itmCreatedBy.Location = new System.Drawing.Point(0, 0);
            this.itmCreatedBy.Name = "itmCreatedBy";
            this.itmCreatedBy.Size = new System.Drawing.Size(375, 24);
            this.itmCreatedBy.Text = "Created By";
            this.itmCreatedBy.TextSize = new System.Drawing.Size(76, 13);
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedBy", true));
            this.txtCreatedBy.Location = new System.Drawing.Point(104, 374);
            this.txtCreatedBy.MenuManager = this.RibbonControl;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.DataSource = this.ServerModeSourceCreatedBy;
            this.txtCreatedBy.Properties.DisplayMember = "Fullname";
            this.txtCreatedBy.Properties.NullText = "";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Properties.ValueMember = "Id";
            this.txtCreatedBy.Size = new System.Drawing.Size(291, 20);
            this.txtCreatedBy.StyleController = this.LayoutControl;
            this.txtCreatedBy.TabIndex = 14;
            this.txtCreatedBy.TabStop = false;
            // 
            // ServerModeSourceCreatedBy
            // 
            this.ServerModeSourceCreatedBy.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Person);
            this.ServerModeSourceCreatedBy.KeyExpression = "Id";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreatedOn", true));
            this.txtCreatedOn.Location = new System.Drawing.Point(479, 374);
            this.txtCreatedOn.MenuManager = this.RibbonControl;
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Properties.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(281, 20);
            this.txtCreatedOn.StyleController = this.LayoutControl;
            this.txtCreatedOn.TabIndex = 16;
            this.txtCreatedOn.TabStop = false;
            // 
            // itmCreatedOn
            // 
            this.itmCreatedOn.Control = this.txtCreatedOn;
            this.itmCreatedOn.CustomizationFormText = "Created On";
            this.itmCreatedOn.Location = new System.Drawing.Point(375, 0);
            this.itmCreatedOn.Name = "itmCreatedOn";
            this.itmCreatedOn.Size = new System.Drawing.Size(365, 24);
            this.itmCreatedOn.Text = "Created On";
            this.itmCreatedOn.TextSize = new System.Drawing.Size(76, 13);
            // 
            // lcgHistory
            // 
            this.lcgHistory.CustomizationFormText = "History";
            this.lcgHistory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmCreatedOn,
            this.itmCreatedBy});
            this.lcgHistory.Location = new System.Drawing.Point(0, 331);
            this.lcgHistory.Name = "lcgHistory";
            this.lcgHistory.Size = new System.Drawing.Size(764, 67);
            this.lcgHistory.Text = "History";
            // 
            // btnTrackHistory
            // 
            this.btnTrackHistory.Caption = "Track History";
            this.btnTrackHistory.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTrackHistory.Glyph")));
            this.btnTrackHistory.Id = 16;
            this.btnTrackHistory.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTrackHistory.LargeGlyph")));
            this.btnTrackHistory.Name = "btnTrackHistory";
            toolTipTitleItem1.Text = "Track History";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click this button to show all the history for this {1} tracking number";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnTrackHistory.SuperTip = superToolTip1;
            this.btnTrackHistory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnTrackHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrackHistory_ItemClick);
            // 
            // btnRejectEntry
            // 
            this.btnRejectEntry.Caption = "Reject Entry";
            this.btnRejectEntry.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRejectEntry.Glyph")));
            this.btnRejectEntry.Id = 17;
            this.btnRejectEntry.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRejectEntry.LargeGlyph")));
            this.btnRejectEntry.Name = "btnRejectEntry";
            toolTipTitleItem2.Text = "Reject Entry";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Click this button to reject current {0}";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnRejectEntry.SuperTip = superToolTip2;
            this.btnRejectEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRejectEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRejectEntry_ItemClick);
            // 
            // btnReverseEntry
            // 
            this.btnReverseEntry.Caption = "Reverse Entry";
            this.btnReverseEntry.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReverseEntry.Glyph")));
            this.btnReverseEntry.Id = 18;
            this.btnReverseEntry.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReverseEntry.LargeGlyph")));
            this.btnReverseEntry.Name = "btnReverseEntry";
            toolTipTitleItem3.Text = "Reverse Entry";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Click button to open en new {0} screen with the reversal lines filled in. Please " +
    "note this only opens the new {0} screen, it does not automaticaly save the rever" +
    "sal {0}";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnReverseEntry.SuperTip = superToolTip3;
            this.btnReverseEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnReverseEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReverseEntry_ItemClick);
            // 
            // btnViewDocument
            // 
            this.btnViewDocument.Caption = "View \r\nDocument";
            this.btnViewDocument.Glyph = ((System.Drawing.Image)(resources.GetObject("btnViewDocument.Glyph")));
            this.btnViewDocument.Id = 19;
            this.btnViewDocument.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnViewDocument.LargeGlyph")));
            this.btnViewDocument.Name = "btnViewDocument";
            toolTipTitleItem4.Text = "Document";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Click this button to open the document liked to this {0}";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnViewDocument.SuperTip = superToolTip4;
            this.btnViewDocument.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewDocument.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewDocument_ItemClick);
            // 
            // ServerModeSourceAbbreviation
            // 
            this.ServerModeSourceAbbreviation.ElementType = typeof(CDS.Client.DataAccessLayer.DB.SYS_Abbreviation);
            this.ServerModeSourceAbbreviation.KeyExpression = "[Id]";
            // 
            // btnApproveEntry
            // 
            this.btnApproveEntry.Caption = "Approve Entry";
            this.btnApproveEntry.Glyph = ((System.Drawing.Image)(resources.GetObject("btnApproveEntry.Glyph")));
            this.btnApproveEntry.Id = 21;
            this.btnApproveEntry.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnApproveEntry.LargeGlyph")));
            this.btnApproveEntry.Name = "btnApproveEntry";
            toolTipTitleItem5.Text = "Approve Entry";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "Click this button to approve current {0}";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnApproveEntry.SuperTip = superToolTip5;
            this.btnApproveEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnApproveEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApproveEntry_ItemClick);
            // 
            // EntryForm
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Title", true));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "EntryForm";
            this.SuperTipParameter = "entry,entries";
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.TabIconBackup = ((System.Drawing.Image)(resources.GetObject("$this.TabIconBackup")));
            this.WaitFormNewRecordDescription = "Creating new entry...";
            this.WaitFormOpenRecordDescription = "Opening entry...";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmTrackNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrackNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmAutoPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoPost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmNewTrackNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNewTrackNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourcePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repAccountsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCenters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceCreatedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmCreatedOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerModeSourceAbbreviation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdLines;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLines;
        private DevExpress.XtraEditors.DateEdit datDate;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtReference;
        private DevExpress.XtraLayout.LayoutControlGroup pnlHeader;
        private DevExpress.XtraLayout.LayoutControlItem itmReference;
        private DevExpress.XtraLayout.LayoutControlItem itmDescription;
        private DevExpress.XtraLayout.LayoutControlItem itmDate;
        private DevExpress.XtraLayout.LayoutControlItem itmLines;
        private System.Windows.Forms.BindingSource BindingSourceLines;
        private DevExpress.XtraGrid.Columns.GridColumn colAccountId;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colAgingId;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourcePeriod;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCenter;
        private DevExpress.XtraLayout.LayoutControlGroup pnlLines;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlAgings;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAging;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraLayout.LayoutControlGroup lcgHistory;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedOn;
        private DevExpress.XtraLayout.LayoutControlItem itmCreatedBy;
        private DevExpress.XtraEditors.TextEdit txtTrackNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmTrackNumber;
        private DevExpress.XtraEditors.CheckEdit chkNewTrackNumber;
        private DevExpress.XtraLayout.LayoutControlItem itmNewTrackNumber;
        private DevExpress.XtraBars.BarButtonItem btnTrackHistory;
        private DevExpress.XtraEditors.CheckEdit chkAutoPost;
        private DevExpress.XtraLayout.LayoutControlItem itmAutoPost;
        private DevExpress.XtraGrid.Columns.GridColumn colCenterId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlCenters;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceStatus;
        private DevExpress.XtraEditors.LookUpEdit txtStatus;
        private DevExpress.XtraLayout.LayoutControlItem itmStatus;
        private DevExpress.XtraBars.BarButtonItem btnRejectEntry;
        private DevExpress.XtraBars.BarButtonItem btnReverseEntry;
        private DevExpress.XtraBars.BarButtonItem btnViewDocument;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceAbbreviation;
        private DevExpress.XtraEditors.ComboBoxEdit ddlReference;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem btnApproveEntry;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit txtCreatedBy;
        private DevExpress.Data.Linq.LinqServerModeSource ServerModeSourceCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repAccounts;
        private DevExpress.XtraGrid.Views.Grid.GridView repAccountsView;
        private DevExpress.Data.Linq.LinqInstantFeedbackSource InstantFeedbackSourceAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount1;
    }
}
