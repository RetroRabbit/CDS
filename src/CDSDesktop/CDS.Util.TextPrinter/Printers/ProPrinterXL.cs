namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class ProPrinterXL : CDS.Util.TextPrinter.TextPrinter
    {
        public ProPrinterXL()
        {
            base.hLineChar = '─';
            base.vLineChar = '│';
            base.tlCornerChar = '┌';
            base.trCornerChar = '┐';
            base.blCornerChar = '└';
            base.brCornerChar = '┘';
            base.vrLineChar = '├';
            base.vlLineChar = '┤';
            base.htLineChar = '┴';
            base.hbLineChar = '┬';
            base.crossLineChar = '┼';
            base.linesCharSet = "437";
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RESET, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_ON, "EscE"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_OFF, "EscF"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_ON, "Esc[" + '\x0003' + "m"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_OFF, "Esc[" + '\x0017' + "m"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_ON, "EscG"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_OFF, "EscH"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_ON, "Esc-1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_OFF, "Esc-0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_ON, "EscW1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_OFF, "EscW0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_ON, "EscS1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_OFF, "EscT"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_ON, "EscS0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_OFF, "EscT"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_LINES, "EscC#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_INCHES, "Esc" + '\0' + "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_WIDTH, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RIGHT_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_CHAR_SET, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PITCH, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_ON, "EscP1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF, "EscP0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LANDSCAPE, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_INTERSPACE, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DRAFT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING, ""));
            base.addPitch("10", "Ctrl+R");
            base.addPitch("12", "Esc:");
            base.addPitch("15", "Escg");
            base.addPitch("17.1", "Ctrl+R" + '\x000f');
            base.addPitch("20", "Esc:" + '\x000f');
            base.addSpacing("8", "Esc0");
            base.addSpacing("12", "EscA6");
            base.addSpacing("18", "EscA4");
            base.addSpacing("24", "EscA3");
            base.addSpacing("72", "EscA#");
            base.addSpacing("216", "Esc3#");
            base.clearCharSet();
            base.addCharSet("437", string.Concat(new object[] { "EscT", '\x0004', '\0', '\0', (char) ((ushort) Math.Floor((double) 1.70703125)), '\x00b5' }), "USA");
            base.addCharSet("850", string.Concat(new object[] { "EscT", '\x0004', '\0', '\0', (char) ((ushort) Math.Floor((double) 3.3203125)), 'R', "" }), "Multilingual");
            base.addCharSet("860", string.Concat(new object[] { "EscT", '\x0004', '\0', '\0', (char) ((ushort) Math.Floor((double) 3.359375)), '\\', "" }), "Portugal");
            base.addCharSet("863", string.Concat(new object[] { "EscT", '\x0004', '\0', '\0', (char) ((ushort) Math.Floor((double) 3.37109375)), '_', "" }), "863");
            base.addCharSet("865", string.Concat(new object[] { "EscT", '\x0004', '\0', '\0', (char) ((ushort) Math.Floor((double) 3.37890625)), 'a', "" }), "Norway");
            base.addCharSet("858", string.Concat(new object[] { "EscT", '\x0004', '\0', '\0', (char) ((ushort) Math.Floor((double) 3.3515625)), 'Z', "" }), "858");
            base.defaultCharSet = "437";
        }
    }
}

