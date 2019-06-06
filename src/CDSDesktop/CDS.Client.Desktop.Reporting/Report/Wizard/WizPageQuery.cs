// Developer Express Code Central Example:
// How to customize a Report Wizard
// 
// This example demonstrates how to create a Custom Report Wizard with the
// capability to define the SQL query, based on which the resulting report's data
// source will be generated (see the corresponding suggestion:
// http://www.devexpress.com/scid=AS4685).
// 
// In order to run you custom wizard in
// the corresponding handler, override the ReportCommand.NewReportWizard,
// ReportCommand.AddNewDataSource, and ReportCommand.VerbReportWizard commands (as
// described in this documentation article: How to: Override Commands in the
// End-User Designer (Custom Saving)
// (ms-help://DevExpress.NETv9.1/DevExpress.XtraReports/CustomDocument2211.htm). A
// Custom Report Wizard inherits from the XRWizardRunnerBase class, custom wizard
// pages are inherited from the InteriorWizardPage class.
// 
// Note that for most
// custom wizard pages, you should override the InteriorWizardPage.OnWizardBack()
// and InteriorWizardPage.OnWizardNext() virtual methods, to provide proper wizard
// navigation logic.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E1538

using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Native;
using System.Linq;
using System.Collections.Generic;


namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public partial class WizPageQuery : DevExpress.Utils.InteriorWizardPage
    {
        private XtraReportWizardBase standardWizard;
        private IDbDataAdapter da;
        private DataSet ds;
        private List<SqlParameter> Parameters = new List<SqlParameter>();

        static IDbDataAdapter CreateDataAdapter(string connectionString, string selectQuery)
        {
            IDbDataAdapter result;

            if (ConnectionStringHelper.GetConnectionType(connectionString) == ConnectionType.Sql)
            {
                connectionString = ConnectionStringHelper.RemoveProviderFromConnectionString(connectionString);
                SqlCommand sqlSelectCommand = new SqlCommand(selectQuery, new SqlConnection(connectionString));
                result = new SqlDataAdapter(sqlSelectCommand);
            }
            else
            {
                OleDbCommand selectCommand = new OleDbCommand(selectQuery, new OleDbConnection(connectionString));
                result = new OleDbDataAdapter(selectCommand);
            }

            result.TableMappings.Add("Table", "Table");

            return result;
        }

        public WizPageQuery(XRWizardRunnerBase runner)
        {
            standardWizard = (NewStandardReportWizard)runner.Wizard;
            ds = new DataSet();
            InitializeComponent();

            if (runner is DataWizard)
            {
                if ((runner as DataWizard).DataAdapter is SqlDataAdapter)
                {
                    SqlDataAdapter ada = (runner as DataWizard).DataAdapter as SqlDataAdapter;
                    this.Query_memoEdit.Text = ada.SelectCommand.CommandText;
                }
            }
        }

        private void Test_simpleButton_Click(object sender, EventArgs e)
        {
            
            string query = this.Query_memoEdit.Text.Replace(Environment.NewLine, " ").Replace("\t", " ");
            
            if (query.Length == 0)
                return;

            if (!query.ToUpper().Contains("BEGIN") && !query.ToUpper().StartsWith("SELECT TOP "))
            {
                //REPLACES ALL SELECTS
                //query = query.ToUpper().Replace("SELECT ", "SELECT TOP 20 ");
                var regex = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Escape("SELECT"));
                query = regex.Replace(query, "SELECT TOP 20 ", 1);
            }

            if (da != null)
                da.SelectCommand.Parameters.Clear();



            da = CreateDataAdapter(((NewStandardReportWizard)this.standardWizard).ConnectionString, query);

            foreach (SqlParameter param in Parameters)
                da.SelectCommand.Parameters.Add(param);

            ds.Reset();
            try
            {
                da.Fill(ds);

                if (da != null)
                    da.SelectCommand.Parameters.Clear();

                da = CreateDataAdapter(((NewStandardReportWizard)this.standardWizard).ConnectionString, this.Query_memoEdit.Text.Replace(Environment.NewLine, " ").Replace("\t", " "));

                foreach (SqlParameter param in Parameters)
                    da.SelectCommand.Parameters.Add(param);

            }
            catch (Exception ex)
            {
                CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Invalid Query", ex.Message, CDS.Client.Desktop.Essential.BaseAlert.Buttons.Ok, CDS.Client.Desktop.Essential.BaseAlert.Icons.Error);
                return;
                //if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                //MessageBox.Show(ex.Message);
                //return;

            }

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.Refresh();
          //  this.dataGridView1.Columns[this.dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        protected override bool OnSetActive()
        {
            WizardHelper.LastDataSourceWizardType = "WizPageQuery";

            Wizard.WizardButtons = WizardButton.Back | WizardButton.Next | WizardButton.DisabledFinish;

            return true;
        }

        protected override string OnWizardBack()
        {
            return "WizPageDataOption";
        }

        protected override string OnWizardNext()
        {
            if (ds.Tables.Count > 0)
            {
                NewStandardReportWizard reportWizard = (NewStandardReportWizard)this.standardWizard;

                ds.DataSetName = reportWizard.DatasetName;
                reportWizard.Dataset = ds;
                reportWizard.DataAdapters.Clear();
                reportWizard.DataAdapters.Add(da);

                return "WizPageChooseFields";
            }
            else
            {
                CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Query not Validated", "Please click apply to validate query.", CDS.Client.Desktop.Essential.BaseAlert.Buttons.Ok, CDS.Client.Desktop.Essential.BaseAlert.Icons.Error);
                return "WizPageQuery";
            }
        }

        private void btnBuildQuery_Click(object sender, EventArgs e)
        {
            //Designer.QueryDesigner.QueryDesignerDialogue queryDesignerDialog = new QueryDesigner.QueryDesignerDialogue(Query_memoEdit.Text);
            //queryDesignerDialog.ShowDialog();
            //if (!queryDesignerDialog.Query.Equals(string.Empty))
            //    Query_memoEdit.Text = queryDesignerDialog.Query;
        }

        private void Query_memoEdit_EditValueChanged(object sender, EventArgs e)
        {
            //btnBuildQuery.Enabled = !(Query_memoEdit.Text.Length > 0);
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            //Reporting.ReportParameterDialogueOld addParameterDialogue = new ReportParameterDialogueOld();
            Report.Wizard.ReportParameterDialogue addParameterDialogue = new ReportParameterDialogue();

            string query = this.Query_memoEdit.Text.Replace(Environment.NewLine, " ").Replace("\t", " ");

            if (!query.ToUpper().Contains("BEGIN") && !query.ToUpper().StartsWith("SELECT TOP "))
            {
                //REPLACES ALL SELECTS
                //query = query.ToUpper().Replace("SELECT ", "SELECT TOP 20 ");
                var regex = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Escape("SELECT"));
                query = regex.Replace(query, "SELECT TOP 20 ", 1);
            }

            addParameterDialogue.Query = query;
            addParameterDialogue.ShowDialog();

            if (da != null)
                da.SelectCommand.Parameters.Clear();

            da = CreateDataAdapter(((NewStandardReportWizard)this.standardWizard).ConnectionString, query);

            //When you Close the Dialogue without creating a parameter
            /* if (addParameterDialogue.Parameter == null)
                 return;

             if (addParameterDialogue.Parameter != null && Parameters.Where(n => n.ParameterName.Contains(addParameterDialogue.Parameter.ParameterName)).Count() == 0)
                 Parameters.Add(addParameterDialogue.Parameter);
             else
             {
                 Parameters.Where(n => n.ParameterName == addParameterDialogue.Parameter.ParameterName).FirstOrDefault().Value = addParameterDialogue.Parameter.Value;
             }
             */
            if (addParameterDialogue.Parameters == null)
                return;

            Parameters = addParameterDialogue.Parameters;



            foreach (SqlParameter param in Parameters)
                da.SelectCommand.Parameters.Add(param);
        }
    }
}