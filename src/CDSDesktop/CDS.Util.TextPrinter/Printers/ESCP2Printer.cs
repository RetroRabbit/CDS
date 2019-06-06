namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class ESCP2Printer : CDS.Util.TextPrinter.TextPrinter
    {
        public ESCP2Printer()
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
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RESET, "" + base.ESC + "@"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_ON, "EscE"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOLD_OFF, "EscF"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_ON, "Esc4"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ITALIC_OFF, "Esc5"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_ON, "EscG"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLESTRIKE_OFF, "EscH"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_ON, string.Concat(new object[] { "", base.ESC, '-', '\x0001' })));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UNDERLINED_OFF, string.Concat(new object[] { "", base.ESC, '-', '\0' })));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_ON, string.Concat(new object[] { "", base.ESC, 'W', '\x0001' })));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DOUBLEWIDE_OFF, string.Concat(new object[] { "", base.ESC, 'W', '\0' })));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_ON, "Esc" + '\x000f'));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_CONDENSED_OFF, "" + '\x0012'));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_ON, "EscS" + '\x0001'));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUBSCRIPT_OFF, "EscT"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_ON, "EscS" + '\0'));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SUPERSCRIPT_OFF, "EscT"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_LINES, "EscC#CHAR#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_INCHES, "EscC" + '\0' + "#CHAR#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_AUTO_FEED_PAPER, "" + base.FF)); //fake
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_AUTO_CUT_PAPER, (char)27 + "@" + (char)29 + "V" + (char)1));//"EscD" + "\x0001")); //fake
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_WIDTH, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN, "" + base.ESC + "N#CHAR#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, "" + base.ESC + "k#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_CHAR_SET, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PITCH, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_ON, "" + base.ESC + "p1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF, "" + base.ESC + "p0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LANDSCAPE, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_INTERSPACE, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY, "" + base.ESC + "x1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DRAFT, "" + base.ESC + "x0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HMI, "Escc"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING, "Esc$"));
            base.addFont("Roman", "" + '\0');
            base.addFont("SansSerif", "" + '\x0001');
            base.addFont("Courier", "" + '\x0002');
            base.addFont("Prestige", "" + '\x0003');
            base.addFont("Script", "" + '\x0004');
            base.addFont("OCR-B", "" + '\x0005');
            base.addFont("OCR-A", "" + '\x0006');
            base.addFont("Orator", "" + '\a');
            base.addFont("Orator-S", "" + '\b');
            base.addFont("Script-C", "" + '\t');
            base.addCharSet("437", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@1", '\x0001', '\0', "Esct1" }), "USA");
            base.addCharSet("ISO-IR-69", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\x0001' }), "France");
            base.addCharSet("ISO-IR-21", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\x0002' }), "Germany");
            base.addCharSet("ISO-IR-4", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\x0003' }), "England");
            base.addCharSet("Denmark", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\x0004' }), "Denmark");
            base.addCharSet("Sweden", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\x0005' }), "Sweden");
            base.addCharSet("ISO-IR-15", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\x0006' }), "Italy");
            base.addCharSet("ISO-IR-17", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\a' }), "Spain");
            base.addCharSet("Japan", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\b' }), "Japan");
            base.addCharSet("ISO-IR-60", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\t' }), "Norway");
            base.addCharSet("Denmark II", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\n' }), "Denmark II");
            base.addCharSet("ISO-IR-85", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\v' }), "Spain II");
            base.addCharSet("Latin America", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\0', '\0', "Esct0EscR", '\f' }), "Latin America");
            base.addCharSet("Korea", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@1", '\x0001', '\0', "Esct1EscR", '\r' }), "Korea");
            base.addCharSet("932", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0002', '\0', "Esct0" }), "Japanese");
            base.addCharSet("850", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0003', '\0', "Esct0" }), "Multilingual");
            base.addCharSet("851", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0004', '\0', "Esct0" }), "Greek");
            base.addCharSet("853", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0005', '\0', "Esct0" }), "Turkish");
            base.addCharSet("855", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0006', '\0', "Esct0" }), "Cyrillic");
            base.addCharSet("860", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\a', '\0', "Esct0" }), "Portugal");
            base.addCharSet("863", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\b', '\0', "Esct0" }), "Canada-French");
            base.addCharSet("865", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\t', '\0', "Esct0" }), "Norway");
            base.addCharSet("852", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\n', '\0', "Esct0" }), "East Europe");
            base.addCharSet("857", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\v', '\0', "Esct0" }), "Turkish II");
            base.addCharSet("862", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\f', '\0', "Esct0" }), "Hebrew");
            base.addCharSet("864", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\r', '\0', "Esct0" }), "Arabic");
            base.addCharSet("866", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x000e', '\0', "Esct0" }), "Russian");
            base.addCharSet("ISO8859-7", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x001d', '\a', "Esct0" }), "Latin/Greek");
            base.addCharSet("ISO8859-1", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x001d', '\x0010', "Esct0" }), "Latin 1");
            base.addCharSet("ISO8859-2", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x007f', '\x0002', "Esct0" }), "Latin 2");
            base.addCharSet("861", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0018', '\0', "Esct0" }), "Iceland");
            base.addCharSet("KU42", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0012', '\0', "Esct0" }), "K.U. Thai");
            base.addCharSet("TIS11", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0013', '\0', "Esct0" }), "TS 988 Thai");
            base.addCharSet("TIS18", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0014', '\0', "Esct0" }), "GENERAL Thai");
            base.addCharSet("TIS17", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0015', '\0', "Esct0" }), "SIC STD. Thai");
            base.addCharSet("TIS13", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0016', '\0', "Esct0" }), "IBM STD. Thai");
            base.addCharSet("TIS16", string.Concat(new object[] { "Esc(tCRTL+CCRTL+@0", '\x0017', '\0', "Esct0" }), "SIC OLD Thai");
            base.addPitch("10", "EscP");
            base.addPitch("12", "EscM");
            base.addPitch("15", "Escg");
            base.addSpacing("6", "Esc2");
            base.addSpacing("8", "Esc0");
            base.addSpacing("60", "EscA#CHAR#");
            base.addSpacing("180", "Esc3#CHAR#");
            base.addSpacing("360", "Esc+#CHAR#");
            base.defaultCharSet = "437";
        }

        protected void executeCommand(string name, string param)
        {
            if (name.Equals(CDS.Util.TextPrinter.TextPrinter.CMD_HMI))
            {
                byte[] b = base.getLowHeightBytes((base.jobSetup.columnWidth * 360.0) / 256.0);
                base.executeCommandInternal(CDS.Util.TextPrinter.TextPrinter.CMD_HMI);
                base.addToBuffer(b);
            }
            else if (name.Equals(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN))
            {
                int num = Convert.ToInt32(param);
                if (num == 0)
                {
                    num = 1;
                }
                base.executeCommandInternal(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN, "" + num);
            }
            else
            {
                base.executeCommand(name, param);
            }
        }

        protected void moveToHPosition(int col)
        {
            double i = ((base.jobSetup.columnWidth * col) * 60.0) / 256.0;
            byte[] b = base.getLowHeightBytes(i);
            base.executeCommand(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING);
            base.addToBuffer(b);
        }
    }
}

