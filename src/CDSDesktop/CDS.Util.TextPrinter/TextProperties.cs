namespace CDS.Util.TextPrinter
{
    using System;

    public class TextProperties
    {
        public bool bold = false;
        public string characterSet = "";
        public bool condensed = false;
        public bool doubleStrike = false;
        public bool doubleWide = false;
        public string fontName = "";
        public bool italic = false;
        public double pitch = -1.0;
        public bool proportional = false;
        public bool subscript = false;
        public bool superscript = false;
        public bool underlined = false;

        public TextProperties getClone()
        {
            TextProperties properties = new TextProperties();
            properties.bold = this.bold;
            properties.characterSet = this.characterSet;
            properties.doubleStrike = this.doubleStrike;
            properties.doubleWide = this.doubleWide;
            properties.fontName = this.fontName;
            properties.italic = this.italic;
            properties.subscript = this.subscript;
            properties.superscript = this.superscript;
            properties.underlined = this.underlined;
            properties.pitch = this.pitch;
            properties.proportional = this.proportional;
            properties.condensed = this.condensed;
            return properties;
        }
    }
}

