using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace CDS.Client.Desktop.Reporting.Analytic
{
    public partial class AnalyticCustomFieldDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public AnalyticCustomFieldDialogue()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                PivotGridField newBonus = GetNewInvisibleBonusField();
                newBonus.Visible = true;
                //newBonus.AreaIndex = PivotGrid.Fields["BonusAmount"].AreaIndex;
                PivotGrid.Fields.Add(newBonus);
                txtFieldName.Text = string.Empty;
                btnAccept.Enabled = false;
                txtFieldExpression.Text = string.Empty;
                txtFieldExpression.Enabled = false;
                PivotGrid.BestFit();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        PivotGridControl pivotGrid;
        public PivotGridControl PivotGrid
        {
            get { return pivotGrid; }
            set { pivotGrid = value; }
        }

        private void txtFieldName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFieldName.Text))
                {
                    btnAccept.Enabled = false;
                    txtFieldExpression.Enabled = false;
                }
                else
                {
                    btnAccept.Enabled = true;
                    txtFieldExpression.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        PivotGridField GetNewInvisibleBonusField()
        {
            try
            {
                PivotGridField newBonusField = new PivotGridField(txtFieldName.Text, PivotArea.DataArea);
                newBonusField.Name = "field_" + txtFieldName.Text;
                newBonusField.Visible = false;
                newBonusField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                newBonusField.UnboundExpression = txtFieldExpression.Text;
                newBonusField.Options.ShowUnboundExpressionMenu = true;
                return newBonusField;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        private void txtFieldExpression_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                PivotGridField newBonus = GetNewInvisibleBonusField();
                PivotGrid.Fields.Add(newBonus);
                pivotGrid.ShowUnboundExpressionEditor(newBonus);
                txtFieldExpression.Text = newBonus.UnboundExpression;
                PivotGrid.Fields.Remove(newBonus);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }


    }
}
