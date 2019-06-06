namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class EpsonLQ1070 : ESCP2Printer
    {
        public EpsonLQ1070()
        {
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_LINES);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_RIGHT_MARGIN);
            base.resetCommand(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY);
            base.clearSpacing();
            base.addSpacing("6", "Esc2");
            base.addSpacing("8", "Esc0");
            base.addSpacing("180", "Esc3#CHAR#");
            base.addSpacing("360", "Esc+#CHAR#");
            base.defaultCharSet = "850";
        }

        public JobProperties getDefaultJobProperties()
        {
            JobProperties properties = new JobProperties();
            properties.topMargin = 0;
            properties.interspacing = "1/8";
            return properties;
        }
    }
}

