namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class PanasonicKX_P3123 : ESCP2Printer
    {
        public PanasonicKX_P3123()
        {
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_LINES);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_RIGHT_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY);
        }
    }
}

