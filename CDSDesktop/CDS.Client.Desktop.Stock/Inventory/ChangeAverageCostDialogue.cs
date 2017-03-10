using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Stock.Inventory
{
    public partial class ChangeAverageCostDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        Int64 entityId;
        public DB.SYS_DOC_Header Doc_Header;
        List<DB.SYS_DOC_Line> lines = new List<DB.SYS_DOC_Line>();
        public ChangeAverageCostDialogue()
        {
            InitializeComponent();
        }

        public ChangeAverageCostDialogue(Int64 entityId)
            : base()
        {
            InitializeComponent();
            this.entityId = entityId;
        }

        protected override void OnStart()
        {
            base.OnStart();
            Doc_Header = BL.SYS.SYS_DOC_Document.New(BL.SYS.SYS_DOC_Type.InventoryAdjustment);
            BindingSource.DataSource = Doc_Header;
            BindingSourceLines.DataSource = lines;
            //When the form opens we populate it the the current items required fields
            AddLine(entityId);
        }

        private void AddLine(Int64 entityId)
        {
            DB.SYS_DOC_Line line = BL.SYS.SYS_DOC_Line.New;
            line.ItemId = entityId;
            line.LineItem = DataContext.ReadonlyContext.VW_LineItem.FirstOrDefault(n => n.Id == entityId);
            PopulateLine(line);
            CalculateTotals(line);
            lines.Add(line);
            line.LineOrder = lines.Count();
        }

        private void PopulateLine(DB.SYS_DOC_Line line)
        {
            if (line == null || line.LineItem == null)
                return;

            line.Quantity = line.LineItem.OnHand;
            line.Description = line.LineItem.Description;
            line.UnitAverage = line.LineItem.UnitAverage;
            line.UnitCost = line.LineItem.UnitCost;
            line.Amount = line.LineItem.UnitAverage;
            line.PriceChanged = false;
        }

        private void CalculateTotals(DB.SYS_DOC_Line line)
        {
            //line.ProfitPercentage = (line.Amount > 0) ? (line.Amount - line.UnitAverage) / line.Amount : 0M;
            line.Total = line.Amount * line.Quantity;
            decimal totalExcl = 0.00M, totalTax = 0.00M, totalIncl = 0.00M;
            line.TotalTax = 0.00M;
            lines.ForEach(n => totalExcl += n.Total);
            lines.ForEach(n => totalTax += n.TotalTax);
            lines.ForEach(n => totalIncl += (n.Total + n.TotalTax));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ValidateLayout();

            DialogResult result = Essential.DocumentAlert.ShowAlert("Save Document", "You are about to save this document do you wish to continue ?", Essential.DocumentAlert.Buttons.SaveAndPrint);
            if (result == System.Windows.Forms.DialogResult.Cancel)
                return;

            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                string message;
                Int64 printerId = 0;

                lines.ForEach(n =>
                {
                    //1st remove current cost
                    var removalCost = n.UnitAverage;
                    DB.SYS_DOC_Line removalLine = BL.ApplicationDataContext.DeepClone<DB.SYS_DOC_Line>(n, BL.SYS.SYS_DOC_Line.New);
                    removalLine.Quantity = -n.Quantity;
                    removalLine.Amount = removalCost;
                    removalLine.LineItem = n.LineItem;
                    CalculateTotals(removalLine);
                    ((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line.Add(removalLine);
                    removalLine.LineOrder = Doc_Header.SYS_DOC_Line.Count();
                    //then re add with new cost
                    CalculateTotals(n);
                    ((DB.SYS_DOC_Header)BindingSource.DataSource).SYS_DOC_Line.Add(n);
                    n.LineOrder = Doc_Header.SYS_DOC_Line.Count();
                });

                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        printerId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultPrinterId.Value;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        printerId = 0;
                        break;
                }
                message = BL.ApplicationDataContext.Instance.Service.SaveDocument((DB.SYS_DOC_Header)BindingSource.DataSource, printerId);
                if (message.StartsWith("Success"))
                {
                    ShowNotification("Saved Changes", String.Format("Average Cost Document number {0} was saved successfully", message.Split(',')[1]), 5000, false, null);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {

                }
            }
            this.Close();
        }

        private void grvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DB.SYS_DOC_Line line = (grvItems.GetFocusedRow() as DB.SYS_DOC_Line);

            switch (e.Column.FieldName)
            {
                //Handeled by Repository Item
                case "ItemId":
                    //Populate all fields for this items line
                    AddLine(line.ItemId);
                    break;
            }
        }

        private void InstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            e.QueryableSource = DataContext.ReadonlyContext.VW_LineItem.Where(n => n.Archived == false && ((new int[] { (byte)BL.SYS.SYS_Type.BuyOut, (byte)BL.SYS.SYS_Type.Message }).Contains(n.TypeId)) || (n.TypeId == (byte)BL.SYS.SYS_Type.Inventory));
        }
    }
}
