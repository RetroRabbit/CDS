using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using CDS.Util.TextPrinter.Ports;

namespace CDS.Util.TextPrinter.Statement
{
    public class StatementPrinter  
    { 
        public StatementPrinter()
        {
        }
         
        private PrinterPort port = null;
        private TextPrinter printer = null;
        private JobProperties job = null;
        private TextProperties prop = null;
        private DataSet datacollection = null;
        
        public void PrintStatement(String Printer, String Type, String Template, long entityId,long periodId, String connectionstring)
        {
            datacollection = new DataSet();
            port = new WindowsPrinter(Printer);
            printer = PrinterFactory.getPrinter(Type);
            port.SetDocumentName("CDS DOC " + entityId);
            job = printer.getDefaultJobProperties();

            job.draftQuality = true;
            job.pitch = 10;
            //job.paperSize = PaperSize.LETTER;
             
            PrintStatementFromTemplate(Template, entityId,periodId, connectionstring);

           printer.endJob();
        }

        public void PrintStatementToFile(String Filename, String Type, String Template, long entityId, long periodId, String connectionstring)
        {
            datacollection = new DataSet();
            port = new FilePort(Filename);
            printer = PrinterFactory.getPrinter(Type);
            port.SetDocumentName("CDS DOC " + entityId);
            job = printer.getDefaultJobProperties();
            PrintStatementFromTemplate(Template, entityId, periodId, connectionstring);
            printer.endJob();
        }

        private void PrintStatementFromTemplate(String Template, long entityId,long periodId, String connectionstring)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(Template);

            XmlNode statement = xmldoc.SelectSingleNode(@"statement");
            XmlNode data = xmldoc.SelectSingleNode(@"statement/data");
            XmlNode header = xmldoc.SelectSingleNode(@"statement/header");
            XmlNode body = xmldoc.SelectSingleNode(@"statement/body");
            XmlNode footer = xmldoc.SelectSingleNode(@"statement/footer");

            job.cols = Convert.ToInt32(statement.Attributes["width"].Value);
            job.rows = Convert.ToInt32(statement.Attributes["height"].Value);


            LoadData(data, entityId, periodId, connectionstring);

            //ADDED TO ENABLE OR DIABLE AUTO FEED
            if (statement.Attributes["auto-feed-paper"].Value == "1")
                printer.autoFeedToTearOff(true);

            //printer.autoFeedToTearOff(true);

            //I dont understand what the below method is suppose to do but is causes a "V" to print as the 1st Char of the statement when printing to epson dot matrix printers
            if (statement.Attributes["auto-cut-paper"].Value == "1")
                printer.autoCutToTearOff(true);
            
            //iet rerig seker of die goed ooit werk nie
            printer.startJob(port, job);

            //printer.executeCommand("CMD_PAGE_LENGTH_INCHES", "11");
            //printer.executeCommand("CMD_PAGE_LENGTH_LINES", "57");

            Int32 maxlines = Convert.ToInt32(body.Attributes["pagemax"].Value);
            XmlNodeList items = body.SelectNodes("item");

            int numpages = (int)Math.Ceiling(datacollection.Tables[items[0].Attributes["dataset"].Value].Rows.Count / (double)maxlines);
            for (int i = 0; i < numpages; i++)
            {
                //printer.executeCommand("CMD_UTIL_NLQ_SELECTION");
                //printer.executeCommand("CMD_PICA_PITCH");

                printer.executeCommand("CMD_PAGE_LENGTH_INCHES", statement.Attributes["height-inches"].Value);
                PrintSection(header, i, numpages);
                //printer.executeCommand("CMD_ELITE_PITCH");
                PrintItemSection(body, i, numpages, maxlines);
                PrintSection(footer, i, numpages);
                //printer.executeCommand("CMD_PICA_PITCH");
                //printer.executeCommand("CMD_MOVE_LINE");

                if (i < (numpages - 1))
                    printer.newPage();
            }
            
            //datacollection.Tables[items[0].Attributes["dataset"].Value].Rows.Count
        }

        private void LoadData(XmlNode section, long entityId, long periodId, String connectionstring)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            XmlNodeList datasets = section.SelectNodes("dataset");
            foreach (XmlNode dataset in datasets)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(dataset.InnerText
                    .Replace("[Parameter01]", String.Format("'{0}'", entityId))
                    .Replace("[Parameter02]", String.Format("'{0}'", periodId)), connection);
                adapter.Fill(datacollection, Convert.ToString(dataset.Attributes["id"].Value));
            }
            connection.Close();
        }

        private void PrintSection(XmlNode section, int page, int totalpages)
        {
            Int32 top = Convert.ToInt32(section.Attributes["top"].Value);
            Int32 left = Convert.ToInt32(section.Attributes["left"].Value);

            PrintSection(section, 0, top, left, page, totalpages);
        }

        private void PrintItemSection(XmlNode section, int page, int totalpages, int bodylines)
        {
            Int32 top = Convert.ToInt32(section.Attributes["top"].Value);
            Int32 left = Convert.ToInt32(section.Attributes["left"].Value);

            PrintItemSection(section, 0, top, left, page, totalpages, bodylines);
        }

        private void PrintSection(XmlNode section, int index, int top, int left, int page, int totalpages)
        {
            XmlNodeList formats = section.SelectNodes("format");

            foreach (XmlNode format in formats)
            {
                TextProperties textprop = printer.getDefaultTextProperties();

                if (format.Attributes["pitch"] != null) textprop.pitch = Convert.ToInt32(format.Attributes["pitch"].Value);
                if (format.Attributes["bold"] != null) textprop.bold = Convert.ToBoolean(format.Attributes["bold"].Value);
                if (format.Attributes["italic"] != null) textprop.italic = Convert.ToBoolean(format.Attributes["italic"].Value);
                if (format.Attributes["underlined"] != null) textprop.underlined = Convert.ToBoolean(format.Attributes["underlined"].Value);

                XmlNodeList labels = format.SelectNodes("label");
                foreach (XmlNode label in labels)
                {
                    string printstring = "";
                    // Get label text value
                    if (label.Attributes["dataset"] != null)
                        printstring = String.Format(label.Attributes["format"].Value, datacollection.Tables[label.Attributes["dataset"].Value].Columns.Contains(label.InnerText) ? (datacollection.Tables[label.Attributes["dataset"].Value].Rows[index][label.InnerText]) : label.InnerText);
                    else
                        printstring = String.Format(label.Attributes["format"].Value, label.InnerText);

                    // Replace page formatters
                    printstring = printstring.Replace("[Page#]", Convert.ToString(page + 1)).Replace("[TotalPages#]", Convert.ToString(totalpages));

                    // Set label formatting
                    int width = Convert.ToInt32(label.Attributes["width"].Value);
                    //printstring = printstring.Substring(0, Math.Min(width, printstring.Length));

                    // Set max lenth of text (take into account if it has newlines)
                    string[] temp = printstring.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i=0; i<temp.Length; i++)
                        temp[i] = temp[i].Substring(0, Math.Min(width, temp[i].Length));

                    printstring = String.Join("\n", temp);


                    if (label.Attributes["halign"].Value == "left")
                    {
                        //Iemand het die uit gecomment
                        printstring = printstring.PadRight(width);
                    }
                    else if (label.Attributes["halign"].Value == "right")
                    {
                        printstring = printstring.PadLeft(width);
                    }
                    else if (label.Attributes["halign"].Value == "center")
                    {
                        printstring = printstring.PadRight(printstring.Length + ((int)Math.Round((width - printstring.Length) / 2.0, 0)));
                        printstring = printstring.PadLeft(width);
                    }


                    
                    printer.printString(
                        printstring,
                        (top + Convert.ToInt32(label.Attributes["top"].Value)),
                        (left + Convert.ToInt32(label.Attributes["left"].Value)),
                            textprop);
                }
            }
        }

        private void PrintItemSection(XmlNode section, int index, int top, int left, int page, int totalpages, int bodylines)
        {
            XmlNode item = section.SelectNodes("item")[0];
            Int32 height = Convert.ToInt32(item.Attributes["height"].Value);

            int start = page * bodylines;
            int end = Math.Min(datacollection.Tables[item.Attributes["dataset"].Value].Rows.Count, ((page + 1) * bodylines));

            for (int i = start; i < end; i++)
            {
                PrintSection(item, i, top + ((i-start) * height), left, page, totalpages);
            }
        }
    }
}
