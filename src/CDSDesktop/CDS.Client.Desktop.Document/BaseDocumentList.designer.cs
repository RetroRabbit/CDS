namespace CDS.Client.Desktop.Document
{
	partial class BaseDocumentList
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
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatePosted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFirstPrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastPrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateValid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceShort1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceShort2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceShort3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceShort4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceShort5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceLong5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRounding = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingAddressLine1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingAddressLine2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingAddressLine3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingAddressLine4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippingAddressCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingAddressLine1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingAddressLine2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingAddressLine3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingAddressLine4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingAddressCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalExcl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrackingNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).BeginInit();
            this.LayoutControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridControl.Size = new System.Drawing.Size(1021, 619);
            // 
            // GridView
            // 
            this.GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransactionType,
            this.colDocumentNumber,
            this.colCompanyName,
            this.colShippingTypeName,
            this.colDatePosted,
            this.colDateFirstPrinted,
            this.colDateLastPrinted,
            this.colDateValid,
            this.colReferenceShort1,
            this.colReferenceShort2,
            this.colReferenceShort3,
            this.colReferenceShort4,
            this.colReferenceShort5,
            this.colReferenceLong1,
            this.colReferenceLong2,
            this.colReferenceLong3,
            this.colReferenceLong4,
            this.colReferenceLong5,
            this.colRounding,
            this.colContactPerson,
            this.colContactTelephone,
            this.colTelephone,
            this.colVatNumber,
            this.colShippingAddressLine1,
            this.colShippingAddressLine2,
            this.colShippingAddressLine3,
            this.colShippingAddressLine4,
            this.colShippingAddressCode,
            this.colBillingAddressLine1,
            this.colBillingAddressLine2,
            this.colBillingAddressLine3,
            this.colBillingAddressLine4,
            this.colBillingAddressCode,
            this.colTotalCash,
            this.colTotalCredit,
            this.colTotalAccount,
            this.colComment,
            this.colTotalExcl,
            this.colTotalTax,
            this.colTotal,
            this.colTrackingNumber});
            this.GridView.OptionsBehavior.Editable = false;
            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.GridView.OptionsPrint.ExpandAllGroups = false;
            this.GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView.OptionsView.EnableAppearanceOddRow = true;
            this.GridView.OptionsView.ShowAutoFilterRow = true;
            this.GridView.OptionsView.ShowGroupPanel = false;
            this.GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDatePosted, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // LayoutControlGrid
            // 
            this.LayoutControlGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LayoutControlGrid.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LayoutControlGrid.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LayoutControlGrid.Size = new System.Drawing.Size(1025, 623);
            this.LayoutControlGrid.Controls.SetChildIndex(this.GridControl, 0);
            // 
            // itmGridControl
            // 
            this.itmGridControl.Size = new System.Drawing.Size(1025, 623);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(1025, 623);
            // 
            // XPOInstantFeedbackSource
            // 
            this.XPOInstantFeedbackSource.ObjectType = typeof(CDS.Client.DataAccessLayer.XDB.ORG_TRX_Header);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RibbonControl.Size = new System.Drawing.Size(1025, 144);
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
            // colDocumentNumber
            // 
            this.colDocumentNumber.Caption = "Document Number";
            this.colDocumentNumber.FieldName = "HeaderId.DocumentNumber";
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colDocumentNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 1;
            // 
            // colShippingTypeName
            // 
            this.colShippingTypeName.Caption = "Shipping Type";
            this.colShippingTypeName.FieldName = "ShippingTypeName";
            this.colShippingTypeName.Name = "colShippingTypeName";
            this.colShippingTypeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShippingTypeName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShippingTypeName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colDatePosted
            // 
            this.colDatePosted.Caption = "Date Posted";
            this.colDatePosted.FieldName = "DatePosted";
            this.colDatePosted.Name = "colDatePosted";
            this.colDatePosted.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colDatePosted.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDatePosted.Visible = true;
            this.colDatePosted.VisibleIndex = 3;
            // 
            // colDateFirstPrinted
            // 
            this.colDateFirstPrinted.Caption = "Date First Printed";
            this.colDateFirstPrinted.FieldName = "DateFirstPrinted";
            this.colDateFirstPrinted.Name = "colDateFirstPrinted";
            this.colDateFirstPrinted.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colDateFirstPrinted.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colDateLastPrinted
            // 
            this.colDateLastPrinted.Caption = "Date Last Printed";
            this.colDateLastPrinted.FieldName = "DateLastPrinted";
            this.colDateLastPrinted.Name = "colDateLastPrinted";
            this.colDateLastPrinted.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colDateLastPrinted.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colDateValid
            // 
            this.colDateValid.Caption = "Date Valid";
            this.colDateValid.FieldName = "DateValid";
            this.colDateValid.Name = "colDateValid";
            this.colDateValid.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.colDateValid.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colReferenceShort1
            // 
            this.colReferenceShort1.Caption = "Order Number";
            this.colReferenceShort1.FieldName = "ReferenceShort1";
            this.colReferenceShort1.Name = "colReferenceShort1";
            this.colReferenceShort1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceShort1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceShort1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colReferenceShort1.Visible = true;
            this.colReferenceShort1.VisibleIndex = 6;
            // 
            // colReferenceShort2
            // 
            this.colReferenceShort2.Caption = "Rep Code";
            this.colReferenceShort2.FieldName = "ReferenceShort2";
            this.colReferenceShort2.Name = "colReferenceShort2";
            this.colReferenceShort2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceShort2.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceShort2.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colReferenceShort2.Visible = true;
            this.colReferenceShort2.VisibleIndex = 7;
            // 
            // colReferenceShort3
            // 
            this.colReferenceShort3.Caption = "Salesman Code";
            this.colReferenceShort3.FieldName = "ReferenceShort3";
            this.colReferenceShort3.Name = "colReferenceShort3";
            this.colReferenceShort3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceShort3.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceShort3.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colReferenceShort3.Visible = true;
            this.colReferenceShort3.VisibleIndex = 8;
            // 
            // colReferenceShort4
            // 
            this.colReferenceShort4.FieldName = "ReferenceShort4";
            this.colReferenceShort4.Name = "colReferenceShort4";
            this.colReferenceShort4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceShort4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceShort4.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colReferenceShort5
            // 
            this.colReferenceShort5.FieldName = "ReferenceShort5";
            this.colReferenceShort5.Name = "colReferenceShort5";
            this.colReferenceShort5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceShort5.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceShort5.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colReferenceLong1
            // 
            this.colReferenceLong1.Caption = "Your Reference";
            this.colReferenceLong1.FieldName = "ReferenceLong1";
            this.colReferenceLong1.Name = "colReferenceLong1";
            this.colReferenceLong1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceLong1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceLong1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colReferenceLong1.Visible = true;
            this.colReferenceLong1.VisibleIndex = 5;
            // 
            // colReferenceLong2
            // 
            this.colReferenceLong2.Caption = "Our Reference";
            this.colReferenceLong2.FieldName = "ReferenceLong2";
            this.colReferenceLong2.Name = "colReferenceLong2";
            this.colReferenceLong2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceLong2.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceLong2.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colReferenceLong2.Visible = true;
            this.colReferenceLong2.VisibleIndex = 4;
            // 
            // colReferenceLong3
            // 
            this.colReferenceLong3.FieldName = "ReferenceLong3";
            this.colReferenceLong3.Name = "colReferenceLong3";
            this.colReferenceLong3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceLong3.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceLong3.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colReferenceLong4
            // 
            this.colReferenceLong4.FieldName = "ReferenceLong4";
            this.colReferenceLong4.Name = "colReferenceLong4";
            this.colReferenceLong4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceLong4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceLong4.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colReferenceLong5
            // 
            this.colReferenceLong5.FieldName = "ReferenceLong5";
            this.colReferenceLong5.Name = "colReferenceLong5";
            this.colReferenceLong5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colReferenceLong5.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colReferenceLong5.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colRounding
            // 
            this.colRounding.Caption = "Rounding";
            this.colRounding.FieldName = "Rounding";
            this.colRounding.Name = "colRounding";
            this.colRounding.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colRounding.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colContactPerson
            // 
            this.colContactPerson.Caption = "Contact Person";
            this.colContactPerson.FieldName = "ContactPerson";
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colContactPerson.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colContactPerson.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colContactTelephone
            // 
            this.colContactTelephone.Caption = "Contact Telephone";
            this.colContactTelephone.FieldName = "ContactTelephone";
            this.colContactTelephone.Name = "colContactTelephone";
            this.colContactTelephone.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colContactTelephone.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colContactTelephone.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colTelephone
            // 
            this.colTelephone.Caption = "Telephone";
            this.colTelephone.FieldName = "Telephone";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTelephone.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colTelephone.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colVatNumber
            // 
            this.colVatNumber.Caption = "Vat Number";
            this.colVatNumber.FieldName = "VatNumber";
            this.colVatNumber.Name = "colVatNumber";
            this.colVatNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVatNumber.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colVatNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colShippingAddressLine1
            // 
            this.colShippingAddressLine1.Caption = "Shipping Address Line 1";
            this.colShippingAddressLine1.FieldName = "ShippingAddressLine1";
            this.colShippingAddressLine1.Name = "colShippingAddressLine1";
            this.colShippingAddressLine1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShippingAddressLine1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShippingAddressLine1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colShippingAddressLine2
            // 
            this.colShippingAddressLine2.Caption = "Shipping Address Line 2";
            this.colShippingAddressLine2.FieldName = "ShippingAddressLine2";
            this.colShippingAddressLine2.Name = "colShippingAddressLine2";
            this.colShippingAddressLine2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShippingAddressLine2.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShippingAddressLine2.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colShippingAddressLine3
            // 
            this.colShippingAddressLine3.Caption = "Shipping Address Line 3";
            this.colShippingAddressLine3.FieldName = "ShippingAddressLine3";
            this.colShippingAddressLine3.Name = "colShippingAddressLine3";
            this.colShippingAddressLine3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShippingAddressLine3.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShippingAddressLine3.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colShippingAddressLine4
            // 
            this.colShippingAddressLine4.Caption = "Shipping Address Line 4";
            this.colShippingAddressLine4.FieldName = "ShippingAddressLine4";
            this.colShippingAddressLine4.Name = "colShippingAddressLine4";
            this.colShippingAddressLine4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShippingAddressLine4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShippingAddressLine4.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colShippingAddressCode
            // 
            this.colShippingAddressCode.Caption = "Shipping Address Code";
            this.colShippingAddressCode.FieldName = "ShippingAddressCode";
            this.colShippingAddressCode.Name = "colShippingAddressCode";
            this.colShippingAddressCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShippingAddressCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colShippingAddressCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colBillingAddressLine1
            // 
            this.colBillingAddressLine1.Caption = "Billing Address Line 1";
            this.colBillingAddressLine1.FieldName = "BillingAddressLine1";
            this.colBillingAddressLine1.Name = "colBillingAddressLine1";
            this.colBillingAddressLine1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBillingAddressLine1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colBillingAddressLine1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colBillingAddressLine2
            // 
            this.colBillingAddressLine2.Caption = "Billing Address Line 2";
            this.colBillingAddressLine2.FieldName = "BillingAddressLine2";
            this.colBillingAddressLine2.Name = "colBillingAddressLine2";
            this.colBillingAddressLine2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBillingAddressLine2.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colBillingAddressLine2.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colBillingAddressLine3
            // 
            this.colBillingAddressLine3.Caption = "Billing Address Line 3";
            this.colBillingAddressLine3.FieldName = "BillingAddressLine3";
            this.colBillingAddressLine3.Name = "colBillingAddressLine3";
            this.colBillingAddressLine3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBillingAddressLine3.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colBillingAddressLine3.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colBillingAddressLine4
            // 
            this.colBillingAddressLine4.Caption = "Billing Address Line 4";
            this.colBillingAddressLine4.FieldName = "BillingAddressLine4";
            this.colBillingAddressLine4.Name = "colBillingAddressLine4";
            this.colBillingAddressLine4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBillingAddressLine4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colBillingAddressLine4.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colBillingAddressCode
            // 
            this.colBillingAddressCode.Caption = "Billing Address Code";
            this.colBillingAddressCode.FieldName = "BillingAddressCode";
            this.colBillingAddressCode.Name = "colBillingAddressCode";
            this.colBillingAddressCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBillingAddressCode.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colBillingAddressCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colTotalCash
            // 
            this.colTotalCash.Caption = "Total Cash";
            this.colTotalCash.FieldName = "TotalCash";
            this.colTotalCash.Name = "colTotalCash";
            this.colTotalCash.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTotalCash.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colTotalCredit
            // 
            this.colTotalCredit.Caption = "Total Credit";
            this.colTotalCredit.FieldName = "TotalCredit";
            this.colTotalCredit.Name = "colTotalCredit";
            this.colTotalCredit.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTotalCredit.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colTotalAccount
            // 
            this.colTotalAccount.Caption = "Total Account";
            this.colTotalAccount.FieldName = "TotalAccount";
            this.colTotalAccount.Name = "colTotalAccount";
            this.colTotalAccount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTotalAccount.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colComment
            // 
            this.colComment.Caption = "Comment";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colComment.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colComment.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Company Name";
            this.colCompanyName.FieldName = "CompanyId.EntityId.Name";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCompanyName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCompanyName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 2;
            // 
            // colTotalExcl
            // 
            this.colTotalExcl.Caption = "Total Excl";
            this.colTotalExcl.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colTotalExcl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalExcl.FieldName = "HeaderId.TotalExcl";
            this.colTotalExcl.Name = "colTotalExcl";
            this.colTotalExcl.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTotalExcl.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTotalExcl.Visible = true;
            this.colTotalExcl.VisibleIndex = 9;
            // 
            // colTotalTax
            // 
            this.colTotalTax.Caption = "Total Tax";
            this.colTotalTax.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colTotalTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalTax.FieldName = "HeaderId.TotalTax";
            this.colTotalTax.Name = "colTotalTax";
            this.colTotalTax.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTotalTax.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTotalTax.Visible = true;
            this.colTotalTax.VisibleIndex = 10;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "{0:##,#.00}";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "HeaderId.Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTotal.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 11;
            // 
            // colTransactionType
            // 
            this.colTransactionType.Caption = "Transaction Type";
            this.colTransactionType.FieldName = "HeaderId.TypeId.Name";
            this.colTransactionType.Name = "colTransactionType";
            this.colTransactionType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTransactionType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colTransactionType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTransactionType.Visible = true;
            this.colTransactionType.VisibleIndex = 0;
            // 
            // colTrackingNumber
            // 
            this.colTrackingNumber.Caption = "Tracking Number";
            this.colTrackingNumber.FieldName = "HeaderId.TrackId.Id";
            this.colTrackingNumber.Name = "colTrackingNumber";
            this.colTrackingNumber.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.colTrackingNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // BaseDocumentList
            // 
            this.DefaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1025, 767);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "BaseDocumentList";
            this.Text = "Documents";
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGrid)).EndInit();
            this.LayoutControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itmGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colShippingTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDatePosted;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFirstPrinted;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastPrinted;
        private DevExpress.XtraGrid.Columns.GridColumn colDateValid;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceShort1;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceShort2;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceShort3;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceShort4;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceShort5;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong1;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong2;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong3;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong4;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceLong5;
        private DevExpress.XtraGrid.Columns.GridColumn colRounding;
        private DevExpress.XtraGrid.Columns.GridColumn colContactPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colContactTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colVatNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colShippingAddressLine1;
        private DevExpress.XtraGrid.Columns.GridColumn colShippingAddressLine2;
        private DevExpress.XtraGrid.Columns.GridColumn colShippingAddressLine3;
        private DevExpress.XtraGrid.Columns.GridColumn colShippingAddressLine4;
        private DevExpress.XtraGrid.Columns.GridColumn colShippingAddressCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingAddressLine1;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingAddressLine2;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingAddressLine3;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingAddressLine4;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingAddressCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCash;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalExcl;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionType;
        private DevExpress.XtraGrid.Columns.GridColumn colTrackingNumber;



    }
}
