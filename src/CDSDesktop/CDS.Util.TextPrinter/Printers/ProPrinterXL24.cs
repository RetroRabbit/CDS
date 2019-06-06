namespace CDS.Util.TextPrinter.Printers
{
    using CDS.Util.TextPrinter;
    using System;

    public class ProPrinterXL24 : ProPrinterXL
    {
        public ProPrinterXL24()
        {
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_SELECT_FONT, "Esc[#x"));
            base.setCommand(new Command(CDS.Util.TextPrinter.TextPrinter.CMD_HORIZONTAL_POSITIONING, "Esc[#" + '`'));
            base.clearFonts();
            base.addFont("Data", "1");
            base.addFont("Roman", "2");
            base.addFont("SansSerif", "3");
            base.addFont("Courier", "4");
            base.addFont("Prestige", "5");
            base.addFont("Script", "6");
            base.addFont("OCR-B", "7");
            base.addFont("OCR-A", "8");
            base.addFont("Orator-C", "9");
            base.addFont("Orator", "10");
            base.addFont("Data Block", "11");
            base.addFont("Data Large", "12");
            base.clearCharSet();
            base.addCharSet("437", "Esc[;" + '\x0001' + "w", "USA");
            base.addCharSet("850", "Esc[;" + '\x0002' + "w", "Multilingual");
            base.addCharSet("860", "Esc[;" + '\x0003' + "w", "Portugal");
            base.addCharSet("863", "Esc[;" + '\x0004' + "w", "863");
            base.addCharSet("865", "Esc[;" + '\x0005' + "w", "Norway");
            base.addCharSet("858", "Esc[;" + '\x0006' + "w", "858");
            base.addCharSet("ISO-IR-6", "Esc[" + '\x0001' + "w", "ASCII");
            base.addCharSet("ISO-IR-69", "Esc[" + '\x0002' + "w", "French");
            base.addCharSet("ISO-IR-21", "Esc[" + '\x0003' + "w", "German");
            base.addCharSet("ISO-IR-4", "Esc[" + '\x0003' + "w", "United Kingdom");
            base.addCharSet("ISO-IR-17", "Esc[" + '\x0006' + "w", "Spanish 1");
            base.addCharSet("ISO-IR-15", "Esc[" + '\a' + "w", "Italian");
            base.addCharSet("ISO-IR-17", "Esc[" + '\b' + "w", "Spanish 1");
            base.addCharSet("ISO-IR-60", "Esc[" + '\n' + "w", "Norwegian 1");
            base.addCharSet("ISO-IR-85", "Esc[" + '\f' + "w", "Spanish 2");
        }
    }
}

