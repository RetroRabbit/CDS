using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Workshop.Job
{
    public partial class JobRemoveDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public decimal Quantity { get; set; } 

        public JobRemoveDialogue(decimal quantity)
        {
            InitializeComponent();
            Quantity = quantity;
            txtQuantity.EditValue = quantity.ToString();
         
        }

        protected override void OnStart()
        {
            base.OnStart(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Quantity = 0;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateBeforeSave())
                return;
            
            Quantity = Convert.ToDecimal(txtQuantity.Text);
            this.Close();
        }

        private bool ValidateBeforeSave()
        {
            return IsQuantityValid();
        }

        private bool IsQuantityValid()
        {
            bool isValid = true;

            decimal RemovalQuantity;

            if (!decimal.TryParse(txtQuantity.EditValue.ToString(), out RemovalQuantity))
            {
                Essential.BaseAlert.ShowAlert("Invalid quantity", string.Format("{0} isn't a valid decimal value", txtQuantity.EditValue), Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
                isValid = false;
            }      
           //Quantity greater than Quantity not allowed
            else if ((txtQuantity.Text == string.Empty || Convert.ToDecimal(txtQuantity.EditValue) > Quantity))
           {
               Essential.BaseAlert.ShowAlert("Invalid quantity", string.Format("Quantity greater than {0:##,##.00} not allowed", Quantity), Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
               isValid = false;
           }
           //Negative value not allowed
           else if (txtQuantity.Text != string.Empty && Convert.ToDecimal(txtQuantity.Text) < 0)
           {
               Essential.BaseAlert.ShowAlert("Invalid quantity", "Negative value not allowed", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Error);
               isValid = false;
           }

            return isValid;
        }

        private void txtQuantity_EditValueChanged(object sender, EventArgs e)
        {
         
        }
    }
}
