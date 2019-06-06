using DevExpress.XtraReports.Extensions;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Developer Express Code Central Example:
// How to implement custom XML serialization of a report that is bound to a dataset
// 
// This example demonstrates the capability to serialize a report to XML along with
// its data source.
// 
// In this example, a report that is bound to a dataset can be
// saved to a file, and then restored along with its data source.
// 
// To do this,
// override the ReportStorageExtension class, and use the
// XtraReport.SaveLayoutToXml() method. And, you can use an opposite
// LoadLayoutFromXml() method, to de-serialize an XML report from a file or
// stream.
// 
// In addition, it is required to register a custom
// ReportDesignExtension, which implements the data source serialization
// functionality.
// 
// See also: http://www.devexpress.com/scid=E3169
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3157
namespace CDS.Client.Desktop.Reporting.Report.Extensions
{
    public class DesignExtension : ReportDesignExtension
    {
        protected override bool CanSerialize(object data)
        {
            return data is DataSet || data is OleDbDataAdapter || data is SqlDataAdapter;
        }

        protected override string SerializeData(object data, XtraReport report)
        {
            //List<String> datalist = new List<String>();

            //foreach (Band band in report.Bands)
            //{
            //    string type = band.GetType().ToString();
            //    if (band.GetType().ToString().Equals("DevExpress.XtraReports.UI.DetailReportBand"))
            //    {
            //        string dataMember = ((DetailReportBand)band).DataMember.ToString();
            //        if (dataMember.Contains("_"))
            //        {
            //            dataMember = dataMember.Substring(dataMember.LastIndexOf("_") + 1);
            //        }

            //        datalist.Add(dataMember);
            //    }
            //}


            if (data is DataSet)
            {
                return (data as DataSet).GetXmlSchema();
            }
            else if (data is OleDbDataAdapter)
            {
                OleDbDataAdapter adapter = data as OleDbDataAdapter;
                return adapter.SelectCommand.Connection.ConnectionString +
                    "\r\n" + adapter.SelectCommand.CommandText;
            }
            else if (data is SqlDataAdapter)
            {
                SqlDataAdapter adapter = data as SqlDataAdapter;

                string serializedString = adapter.SelectCommand.Connection.ConnectionString +
                    "\r\n" + adapter.SelectCommand.CommandText;

                foreach (SqlParameter param in adapter.SelectCommand.Parameters)
                {
                    serializedString += "\r\nParameterName:" + param.ParameterName +
                                        "\r\nParameterType:" + param.SqlDbType.ToString() +
                                        "\r\nParameterValue:" + param.Value;
                }

                return serializedString;
            }
            else
            {
                return base.SerializeData(data, report);
            }
        }

        protected override bool CanDeserialize(string value, string typeName)
        {
            return typeof(DataSet).FullName ==
                typeName || typeof(OleDbDataAdapter).FullName == typeName || typeof(SqlDataAdapter).FullName == typeName;
        }

        protected override object DeserializeData(string value, string typeName, XtraReport report)
        {
            if (typeof(DataSet).FullName == typeName)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new StringReader(value));
                return dataSet;
            }
            else if (typeof(OleDbDataAdapter).FullName == typeName)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string[] values = value.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                adapter.SelectCommand = new OleDbCommand(values[1], new OleDbConnection(values[0]));
                return adapter;
            }
            else if (typeof(SqlDataAdapter).FullName == typeName)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string[] values = value.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                adapter.SelectCommand = new SqlCommand(values[1], new SqlConnection(values[0]));

                for (int i = 2; i < values.Count(); i += 3)
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = values[i].Substring(values[i].IndexOf(':') + 1, values[i].Length - values[i].IndexOf(':') - 1);
                    param.SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), values[i + 1].Substring(values[i + 1].IndexOf(':') + 1, values[i + 1].Length - values[i + 1].IndexOf(':') - 1));
                    param.Value = values[i + 2].Substring(values[i + 2].IndexOf(':') + 1, values[i + 2].Length - values[i + 2].IndexOf(':') - 1);
                    adapter.SelectCommand.Parameters.Add(param);
                }

                return adapter;
            }
            else
            {
                return base.DeserializeData(value, typeName, report);
            }
        }
    }
}
