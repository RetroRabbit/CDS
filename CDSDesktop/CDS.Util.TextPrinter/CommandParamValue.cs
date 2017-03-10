namespace CDS.Util.TextPrinter
{
    using System;

    public class CommandParamValue
    {
        public string name = "";
        public string value = "";

        public CommandParamValue(string n, string v)
        {
            this.name = n;
            this.value = v;
        }
    }
}

