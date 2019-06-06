namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class PrintronixPSeries : CDS.Util.TextPrinter.TextPrinter
    {
        public static string SFCC = ("" + '\x0001');

        public PrintronixPSeries()
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
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_ON, SFCC + "G"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_OFF, SFCC + "H"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_ON, SFCC + "-1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_OFF, SFCC + "-0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_ON, SFCC + "S" + '\x0001'));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_OFF, SFCC + "T"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_ON, SFCC + "S" + '\0'));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_OFF, SFCC + "T"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_LINES, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_INCHES, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_WIDTH, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RIGHT_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_CHAR_SET, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PITCH, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LANDSCAPE, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_INTERSPACE, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DRAFT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HMI, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING, ""));
            base.addCharSet("437", SFCC + 'l' + "000", "USA");
            base.addCharSet("850", SFCC + 'l' + "001", "Multilingual");
            base.addPitch("10", SFCC + "X*0");
            base.addPitch("12", SFCC + "X*1");
            base.addPitch("13", SFCC + "X*2");
            base.addPitch("15", SFCC + "X*3");
            base.addPitch("17", SFCC + "X*4");
            base.addPitch("20", SFCC + "X*5");
            base.addSpacing("6", SFCC + "2");
            base.addSpacing("8", SFCC + "0");
            base.addSpacing("72", SFCC + "A#");
            base.addSpacing("216", SFCC + "3#");
            base.defaultCharSet = "437";
        }
    }
}

