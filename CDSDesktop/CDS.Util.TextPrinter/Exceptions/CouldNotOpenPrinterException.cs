namespace CDS.Util.TextPrinter.Exceptions
{
    using CDS.Util.TextPrinter;
    using System;

    public class CouldNotOpenPrinterException : TextPrinterException
    {
        public CouldNotOpenPrinterException(string msg) : base(msg)
        {
        }
    }
}

