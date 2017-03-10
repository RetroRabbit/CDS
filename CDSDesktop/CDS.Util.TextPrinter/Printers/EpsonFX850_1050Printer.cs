namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class EpsonFX850_1050Printer : ESCPPrinter
    {
        public EpsonFX850_1050Printer()
        {
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_RESET, "Esc@Esct" + '\x0001'));
            base.clearCharSet();
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
            base.defaultCharSet = "437";
            base.debug = true;
        }
    }
}

