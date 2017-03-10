namespace CDS.Util.TextPrinter
{
    using System;

    public class PaperSize
    {
        public static PaperSize A3 = new PaperSize("A3", 297.0, 420.0, false);
        public static PaperSize A4 = new PaperSize("A4", 210.0, 297.0, false);
        public static PaperSize EXECUTIVE = new PaperSize("EXECUTIVE", 7.25, 10.5, true);
        private double height = 0.0;
        private bool inches = false;
        public static PaperSize LEDGER = new PaperSize("LEDGER", 11.0, 17.0, true);
        public static PaperSize LEGAL = new PaperSize("LEGAL", 8.5, 15.0, true);
        public static PaperSize LETTER = new PaperSize("LETTER", 8.5, 11.0, true);
        private string name = "";
        private double width = 0.0;

        public PaperSize(string sName, double w, double h, bool inch)
        {
            this.inches = inch;
            this.width = w;
            this.height = h;
            this.name = sName;
        }

        public double getHeight()
        {
            if (this.inches)
            {
                return this.height;
            }
            return (this.height / 25.6);
        }

        public string getName()
        {
            return this.name;
        }

        public double getWidth()
        {
            if (this.inches)
            {
                return this.width;
            }
            return (this.width / 25.6);
        }
    }
}

