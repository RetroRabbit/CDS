using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    public partial class ReportParameterDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public String Query { get; set; }
        public List<System.Data.SqlClient.SqlParameter> Parameters { get; set; }

        public ReportParameterDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();

            Parameters = new List<System.Data.SqlClient.SqlParameter>();
            BindingSourceTypes.DataSource = new SQLType[] { 
                new SQLType() { Name = "Big Int",SQLDataType="BigInt"},
                new SQLType() { Name = "True/False",SQLDataType="Bit"},
                new SQLType() { Name = "Date",SQLDataType="DateTime"},
                new SQLType() { Name = "Decimal",SQLDataType="Decimal"},
                new SQLType() { Name = "Int",SQLDataType="Int"},
                new SQLType() { Name = "String",SQLDataType="NVarChar"},
                new SQLType() { Name = "Money",SQLDataType="Money" } 
            };

            String[] QueryStrings = Query.Split(new char[] { '=', ' ', ',' });

            BindingSourceParameters.DataSource = QueryStrings.Where(n => n.StartsWith("@")).Distinct().Select(l => new SQLParameter() { Name = l, Type = "NVarChar" }).ToList();
        }

        public class SQLParameter
        {
            public String Name { get; set; }
            public String Type { get; set; }
            public String Value { get; set; }
        }

        public class SQLType
        {
            public String Name { get; set; }
            public String SQLDataType { get; set; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (((List<SQLParameter>)BindingSourceParameters.DataSource).Where(n => n.Value == null).Count() > 0)
                return;

            foreach (SQLParameter param in ((List<SQLParameter>)BindingSourceParameters.DataSource))
            {
                System.Data.SqlClient.SqlParameter temp = new System.Data.SqlClient.SqlParameter();
                temp.SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), param.Type.ToString());
                string paramName = param.Name.ToString().Remove(0, 1).ToLower();
                temp.ParameterName = char.ToUpper(paramName[0]) + paramName.Substring(1);

                switch (temp.SqlDbType)
                {
                    case SqlDbType.Bit:
                        temp.Value = (Boolean.Parse(param.Value)) == true ? 1 : 0;
                        break;
                    case SqlDbType.DateTime:
                        temp.Value = DateTime.Parse(param.Value.ToString()).ToString("yyyy-MM-dd hh:mm:ss.sss");
                        break;
                    default:
                        temp.Value = param.Value;
                        break;
                }
                Parameters.Add(temp);
            }
            this.Close();
        }

        private void grvParameters_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colValue)
            {
                grdParameters.BeginUpdate();
                SQLParameter temp = (SQLParameter)grvParameters.GetFocusedRow();
                var type = (SqlDbType)Enum.Parse(typeof(SqlDbType), temp.Type.ToString());

                switch (type)
                {
                    case SqlDbType.Decimal:
                        e.RepositoryItem = riParameterNumber;
                        break;
                    case SqlDbType.Int:
                        e.RepositoryItem = riParameterNumber;
                        break;
                    case SqlDbType.BigInt:
                        e.RepositoryItem = riParameterNumber;
                        break;
                    case SqlDbType.Bit:
                        e.RepositoryItem = riParameterBoolean;
                        break;
                    case SqlDbType.DateTime:
                        e.RepositoryItem = riParameterDate;
                        break;
                    case SqlDbType.Money:
                        e.RepositoryItem = riParameterNumber;
                        break;
                    default:
                        e.RepositoryItem = riParameterText;
                        break;
                }
                grdParameters.EndUpdate();
            }
        }

    }
}
