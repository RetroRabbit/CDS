namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class ESCPPrinter : CDS.Util.TextPrinter.TextPrinter
    {
        public ESCPPrinter()
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


            //base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_FORM_LEGTH_INCHES, "Esc" + '\x4300#CHAR#'));
            //base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_FORM_LEGTH_INCHES, "" + base.ESC + "670#CHAR#"));
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
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_LENGTH_INCHES, "EscC" + '\0' + "#CHAR#")); //27 67 0 n 
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PAGE_WIDTH, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_TOP_MARGIN, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_BOTTOM_MARGIN, "" + base.ESC + "N#CHAR#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, "" + base.ESC + "k#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_CHAR_SET, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PITCH, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_ON, "" + base.ESC + "p1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PROPORTIONAL_OFF, "" + base.ESC + "p2"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PORTRAIT, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_LANDSCAPE, ""));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_INTERSPACE, "#"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_QUALITY, "" + base.ESC + "x1"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_DRAFT, "" + base.ESC + "x0"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HMI, "Escc"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING, "Esc$"));

            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_UTIL_NLQ_SELECTION, base.ESC + "\x0078" + "#CHAR#")); //	27 120 n EscXCHAR
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_PICA_PITCH, base.ESC + "\x0050")); // 27 80 EscP
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_ELITE_PITCH, base.ESC + "\x004d")); // 27 77 EcsM
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_FEED_N_216_LINE, base.ESC + "\x004a" + "#CHAR#")); // 27 74 n 
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_MOVE_LINE, base.ESC + "\x000c")); 

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
            base.addCharSet("437", "Esct1" + '\0', "USA");
            base.addCharSet("ISO-IR-69", "EsctCRTL+@EscR" + '\x0001', "France");
            base.addCharSet("ISO-IR-21", "EsctCRTL+@EscR" + '\x0002', "Germany");
            base.addCharSet("ISO-IR-4", "EsctCRTL+@EscR" + '\x0003', "England");
            base.addCharSet("Denmark", "EsctCRTL+@EscR" + '\x0004', "Denmark");
            base.addCharSet("Sweden", "EsctCRTL+@EscR" + '\x0005', "Sweden");
            base.addCharSet("ISO-IR-15", "EsctCRTL+@EscR" + '\x0006', "Italy");
            base.addCharSet("ISO-IR-17", "EsctCRTL+@EscR" + '\a', "Spain");
            base.addCharSet("Japan", "EsctCRTL+@EscR" + '\b', "Japan");
            base.addCharSet("ISO-IR-60", "EsctCRTL+@EscR" + '\t', "Norway");
            base.addCharSet("Denmark II", "EsctCRTL+@EscR" + '\n', "Denmark II");
            base.addCharSet("ISO-IR-85", "EsctCRTL+@EscR" + '\v', "Spain II");
            base.addCharSet("Latin America", "EsctCRTL+@EscR" + '\f', "Latin America");
            base.addCharSet("Korea", "EsctCRTL+@EscR" + '\r', "Korea");
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
            if (name.Equals(CDS.Util.TextPrinter.TextPrinter.CMD_LEFT_MARGIN))
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

