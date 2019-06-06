namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class PCL3Printer : CDS.Util.TextPrinter.TextPrinter
    {
        public PCL3Printer()
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
            base.linesCharSet = "PC-8";
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RESET, "" + base.ESC + "E"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_ON, "" + base.ESC + "(s3B"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_OFF, "" + base.ESC + "(s0B"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_ON, "" + base.ESC + "(s1S"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_OFF, "" + base.ESC + "(s0S"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_ON, "" + base.ESC + "&d0D"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_OFF, "" + base.ESC + "&d@"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_ON, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_OFF, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_ON, "Esc(s-1U"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_OFF, "Esc(s0U"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_ON, "Esc(s1U"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_OFF, "Esc(s0U"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_LINES, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HMI, "Esc&k#H"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN, "" + base.ESC + "&l#E"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN, "" + base.ESC + "&a#L"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RIGHT_MARGIN, "" + base.ESC + "&a#M"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_CHAR_SET, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PITCH, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_ON, "Esc(s1P"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF, "Esc(s0P"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LANDSCAPE, "Esc&l1O"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_INTERSPACE, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY, "Esc(s1Q"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DRAFT, "Esc(s2Q"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAPER_SIZE, "Esc&l#A"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RESOLUTION, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING, "Esc&a#C"));
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_PITCH, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_ON, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_ON, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_OFF, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_ON, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addDependency(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_OFF, CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
            base.addFont("Univers", "Esc(s4148T");
            base.addFont("LinePrinter", "Esc(s0T");
            base.addFont("CG Times", "Esc(s4101T");
            base.addFont("Courier", "Esc(s4099T");
            base.addFont("Albertus", "Esc(s4362T");
            base.addFont("Antique Olive", "Esc(s4168T");
            base.addFont("Clarendon", "Esc(s4140T");
            base.addFont("Coronet", "Esc(s4116T");
            base.addFont("Garamond Antiqua", "Esc(s4197T");
            base.addFont("Letter Gothic", "Esc(s4102T");
            base.addFont("Marigold", "Esc(s4297T");
            base.addFont("CG Omega", "Esc(s4113T");
            base.addFont("Arial", "Esc(s16602T");
            base.addFont("Times New Roman", "Esc(s16901T");
            base.addFont("Symbol", "Esc(s16686T");
            base.addFont("Wingdings", "Esc(s31402T");
            base.addPitch("10", "Esc(s10H");
            base.addPitch("12", "Esc(s12H");
            base.addSpacing("1", "Esc&l1D");
            base.addSpacing("2", "Esc&l2D");
            base.addSpacing("3", "Esc&l3D");
            base.addSpacing("4", "Esc&l4D");
            base.addSpacing("6", "Esc&l6D");
            base.addSpacing("8", "Esc&l8D");
            base.addSpacing("12", "Esc&l12D");
            base.addSpacing("16", "Esc&l16D");
            base.addSpacing("24", "Esc&l24D");
            base.addSpacing("48", "Esc&l48D");
            base.addPaperSize("EXECUTIVE", "1");
            base.addPaperSize("LETTER", "2");
            base.addPaperSize("LEGAL", "3");
            base.addPaperSize("LEDGER", "6");
            base.addPaperSize("A4", "26");
            base.addPaperSize("A3", "27");
            base.addCharSet("ISO-IR-60", "Esc(0D", "Norwegian 1");
            base.addCharSet("ISO-IR-61", "Esc(1D", "Norwegian 2");
            base.addCharSet("ISO-IR-4", "Esc(1E", "United Kingdom");
            base.addCharSet("ISO-IR-69", "Esc(1F", "French");
            base.addCharSet("ISO-IR-21", "Esc(1G", "German");
            base.addCharSet("ISO-IR-15", "Esc(0I", "Italian");
            base.addCharSet("ISO-IR-14", "Esc(0K", "JIS ASCII");
            base.addCharSet("ISO-IR-57", "Esc(2K", "Chinese");
            base.addCharSet("ISO-8859-1", "Esc(0N", "Latin 1");
            base.addCharSet("ISO-IR-11", "Esc(0S", "Swedish");
            base.addCharSet("ISO-IR-17", "Esc(2S", "Spanish 1");
            base.addCharSet("ISO-IR-10", "Esc(3S", "Swedish 2");
            base.addCharSet("ISO-IR-16", "Esc(4S", "Portuguese 1");
            base.addCharSet("IISO-IR-84", "Esc(5S", "Portuguese 2");
            base.addCharSet("ISO-IR-85", "Esc(6S", "Spanish 2");
            base.addCharSet("ISO-IR-6", "Esc(0U", "ASCII");
            base.addCharSet("ISO-IR-2", "Esc(2U", "IRV");
            base.addCharSet("ROMAN8", "Esc(8U", "Roman8");
            base.addCharSet("Microsoft Publishing", "Esc(6J", "");
            base.addCharSet("Desktop", "Esc(7J", "Desktop");
            base.addCharSet("PS Text", "Esc(10J", "PS Text");
            base.addCharSet("Ventura International", "Esc(13J", "");
            base.addCharSet("Ventura US", "Esc(14J", "");
            base.addCharSet("Ventura ITC Zapf Dingbatsdingbats", "Esc(9L", "");
            base.addCharSet("PS ITC Zapf Dingbatsdingbats", "Esc(10L", "");
            base.addCharSet("ITC Zapf Dingbatsdingbats Series 100", "Esc(11L", "");
            base.addCharSet("ITC Zapf Dingbatsdingbats Series 200", "Esc(12L", "");
            base.addCharSet("ITC Zapf Dingbatsdingbats Series 300", "Esc(13L", "");
            base.addCharSet("PS Math", "Esc(5M", "");
            base.addCharSet("Ventura", "Math Esc(6M", "");
            base.addCharSet("Math-8", "Esc(8M", "");
            base.addCharSet("Legal", "Esc(1U", "");
            base.addCharSet("1252", "Esc(9U", "Windows");
            base.addCharSet("Pi Font", "Esc(15U", "");
            base.addCharSet("PC-8", "Esc(10U", "437");
            base.addCharSet("PC-8 D/N", "Esc(11U", "");
            base.addCharSet("850", "Esc(12U", "PC-850");
            base.defaultCharSet = "ROMAN8";
        }

        protected void calculateColumnWidth(int cols)
        {
            int num = 0;
            if ((base.jobSetup.paperSize != null) && ((base.jobSetup.resolution == 300) || (base.jobSetup.resolution == 600)))
            {
                if (base.jobSetup.paperSize == PaperSize.LETTER)
                {
                    num = 0x960;
                }
                if (base.jobSetup.paperSize == PaperSize.A4)
                {
                    num = 0x922;
                }
                if (base.jobSetup.paperSize == PaperSize.A3)
                {
                    num = 0xd25;
                }
                if (base.jobSetup.paperSize == PaperSize.LEDGER)
                {
                    num = 0xc4e;
                }
                if (base.jobSetup.paperSize == PaperSize.LEGAL)
                {
                    num = 0x960;
                }
                if (base.jobSetup.paperSize == PaperSize.EXECUTIVE)
                {
                    num = 0x7e9;
                }
                if (base.jobSetup.resolution == 600)
                {
                    num *= 2;
                }
                double num2 = num / base.jobSetup.resolution;
                double num3 = 1.0 / (num2 / ((double) cols));
                double num4 = 120.0 / num3;
                if (base.jobSetup.pitch == -1.0)
                {
                    base.jobSetup.pitch = Math.Floor((double) (num3 * 100.0)) / 100.0;
                }
                if (base.jobSetup.columnWidth == -1.0)
                {
                    base.jobSetup.columnWidth = Math.Floor((double) (num4 * 100.0)) / 100.0;
                }
                if (base.debug)
                {
                    Console.WriteLine(string.Concat(new object[] { "Settings for ", cols, " columns and paper width ", base.jobSetup.paperSize.getWidth(), " inches:" }));
                    Console.WriteLine("Pitch: " + base.jobSetup.pitch);
                    Console.WriteLine("HMI: " + base.jobSetup.columnWidth);
                }
            }
        }

        protected void calculateLineSpacing(int rows)
        {
            double pageHeight = 0.0;
            if ((base.jobSetup.paperSize != null) && ((base.jobSetup.resolution == 300) || (base.jobSetup.resolution == 600)))
            {
                pageHeight = base.jobSetup.paperSize.getHeight();
                if (base.jobSetup.interspacing.Length == 0)
                {
                    base.jobSetup.interspacing = base.getBestLineSpacing(rows, pageHeight);
                }
                if (base.debug)
                {
                    Console.WriteLine(string.Concat(new object[] { "Settings for ", rows, " lines per page and paper height ", base.jobSetup.paperSize.getHeight(), " inches:" }));
                    Console.WriteLine("Line spacing: " + base.jobSetup.interspacing);
                }
            }
        }
    }
}

