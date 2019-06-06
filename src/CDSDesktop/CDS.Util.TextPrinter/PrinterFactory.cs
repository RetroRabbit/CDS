namespace CDS.Util.TextPrinter
{
    using CDS.Util.TextPrinter.Printers;
    using System;

    public class PrinterFactory
    {
        protected static string[][] printers = new string[][] { 
            new string[] { "IBM-PROPRINTER", "ProPrinterXL" }, new string[] { "IBM-PROPRINTER-III", "ProPrinterIII" }, new string[] { "IBM-PROPRINTER-XL", "ProPrinterXL" }, new string[] { "IBM-PROPRINTER-XL24", "ProPrinterXL24" }, new string[] { "IBM-PPDS", "PPDSPrinter" }, new string[] { "EPSON-ESCP2", "ESCP2Printer" }, new string[] { "EPSON-ESCP", "ESCPPrinter" }, new string[] { "EPSON-9PIN-ESCP", "ESCP9PinPrinter" }, new string[] { "EPSON-FX850", "EpsonFX850_1050Printer" }, new string[] { "EPSON-FX1050", "EpsonFX850_1050Printer" }, new string[] { "EPSON-LQ1070", "EpsonLQ1070" }, new string[] { "HP-PCL", "PCL5Printer" }, new string[] { "HP-PCL3", "PCL3Printer" }, new string[] { "HP-PCL5", "PCL5Printer" }, new string[] { "DIABLO", "DiabloPrinter" }, new string[] { "PLAIN", "PlainPrinter" }, 
            new string[] { "OKI-MICROLINE", "OKIMicroline" }, new string[] { "P-SERIES", "PrintronixPSeries" }, new string[] { "PanasonicKX_P3123", "PanasonicKX_P3123" }, new string[] { "PanasonicKX_P1150", "PanasonicKX_P1150" }
         };

        public static CDS.Util.TextPrinter.TextPrinter getPrinter(string name)
        {
            CDS.Util.TextPrinter.TextPrinter printer = null;
            for (int i = 0; i < printers.GetLength(0); i++)
            {
                if (printers[i][0].ToUpper().Equals(name.ToUpper()))
                {
                    try
                    {
                        printer = (CDS.Util.TextPrinter.TextPrinter) Activator.CreateInstance(null, "CDS.Util.TextPrinter.Printers." + printers[i][1]).Unwrap();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.WriteLine(exception.StackTrace);
                    }
                }
            }
            if (name.ToUpper().Equals("TEST"))
            {
                printer = new TestPrinter();
            }
            if (printer == null)
            {
                printer = new PlainPrinter();
            }
            printer.init();
            return printer;
        }

        public static string[] getSupportedPrinters()
        {
            string[] strArray = new string[printers.GetLength(0)];
            for (int i = 0; i < printers.GetLength(0); i++)
            {
                strArray[i] = printers[i][0];
            }
            return strArray;
        }
    }
}

