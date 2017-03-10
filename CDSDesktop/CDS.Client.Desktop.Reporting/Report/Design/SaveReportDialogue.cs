using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Reporting.Report.Design
{
    public partial class SaveReportDialogue : Essential.BaseDialogue
    {
        public SaveReportDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (txtCategory.EditValue != null && txtCategory.EditValue.Equals("System"))
            {
                txtCode.Enabled = false; txtName.Enabled = false; txtDescription.Enabled = false; txtCategory.Enabled = false; txtSubCategory.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public string ReportUrl
        {
            get
            {
                return String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", id, txtCode.EditValue, txtName.EditValue, txtDescription.EditValue, txtCategory.EditValue, txtSubCategory.EditValue,cbxSecurityLevel.EditValue);
            }
            set
            {
                string[] values = value.Split(new char[] { '|' });
                id = Convert.ToInt64(values[0]);
                txtCode.EditValue = values[1];
                txtName.EditValue = values[2];
                txtDescription.EditValue = values[3];
                txtCategory.EditValue = values[4];
                txtSubCategory.EditValue = values[5];
                cbxSecurityLevel.EditValue = values[6];
            }
        }

        private Int64 id = -1;
    }
}
