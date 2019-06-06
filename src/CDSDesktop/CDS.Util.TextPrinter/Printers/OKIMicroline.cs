namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class OKIMicroline : CDS.Util.TextPrinter.TextPrinter
    {
        public OKIMicroline()
        {
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RESET, "Esc" + '\x0018'));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_ON, "EscT"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_OFF, "EscI"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_ON, "Esc!/"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_OFF, "Esc!*"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_ON, "EscC"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_OFF, "EscD"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_ON, "EscL"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_OFF, "EscM"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_ON, "EscJ"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_OFF, "EscK"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_LINES, "EscF#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_INCHES, "EscG"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_WIDTH, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RIGHT_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_CHAR_SET, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PITCH, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_ON, "EscY"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF, "EscZ"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LANDSCAPE, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_INTERSPACE, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DRAFT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HMI, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING, ""));
            base.addCharSet("Standard", "Esc!0", "Standard");
            base.addCharSet("BlockGraphics", "Esc!1", "BlockGraphics");
            base.addCharSet("LineGraphics", "Esc!2", "LineGraphics");
            base.addCharSet("Publisher", "Esc!Z", "Publisher");
            base.addCharSet("ISO-IR-60", "Esc!" + 'G', "Norwegian 1");
            base.addCharSet("ISO-IR-4", "Esc!" + 'B', "United Kingdom");
            base.addCharSet("ISO-IR-69", "Esc!" + 'D', "French");
            base.addCharSet("ISO-IR-21", "Esc!" + 'C', "German");
            base.addCharSet("ISO-IR-15", "Esc!" + 'I', "Italian");
            base.addCharSet("ISO-8859-1", "Esc!" + 'L', "Latin 1");
            base.addCharSet("ISO-IR-11", "Esc!" + 'E', "Swedish");
            base.addCharSet("ISO-IR-17", "Esc!" + 'K', "Spanish 1");
            base.addCharSet("ISO-IR-6", "Esc!" + '@', "ASCII");
            base.addCharSet("Microsoft Publishing", "Esc!" + 'Z', "");
            base.addCharSet("Denmark", "Esc!" + 'F', "Denmark");
            base.addFont("Courier", "Esc1");
            base.addFont("Gothic", "Esc3");
            base.addPitch("10", "" + '\x001e');
            base.addPitch("12", "" + '\x001c');
            base.addPitch("15", "Escg");
            base.addPitch("17.1", "" + '\x001d');
            base.addPitch("20", "Esc#3");
            base.addSpacing("6", "Esc6");
            base.addSpacing("8", "Esc8");
            base.addSpacing("144", "Esc%9#");
            base.defaultCharSet = "ISO-IR-6";
        }

        protected void executeCommand(string name, string param)
        {
            if (name.Equals(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_INCHES))
            {
                byte[] b = base.getLowHeightBytes(base.jobSetup.paperSize.getHeight());
                base.executeCommandInternal(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_INCHES);
                base.addToBuffer(b);
            }
            else
            {
                base.executeCommand(name, param);
            }
        }
    }
}

