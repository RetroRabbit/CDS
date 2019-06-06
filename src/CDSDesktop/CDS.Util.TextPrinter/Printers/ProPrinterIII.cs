namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class ProPrinterIII : ProPrinterXL
    {
        public ProPrinterIII()
        {
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_ON, "Esc%G"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_OFF, "Esc%H"));
            base.clearSpacing();
            base.addSpacing("8", "Esc0");
            base.addSpacing("12", "EscA6");
            base.addSpacing("18", "EscA4");
            base.addSpacing("24", "EscA3");
            base.addSpacing("72", "EscA#");
            base.clearCharSet();
        }
    }
}

