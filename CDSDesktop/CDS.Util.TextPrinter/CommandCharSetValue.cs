namespace CDS.Util.TextPrinter
{
    using System;

    public class CommandCharSetValue : CommandParamValue
    {
        public string charSet;

        public CommandCharSetValue(string n, string v, string c) : base(n, v)
        {
            this.charSet = "";
            this.charSet = c;
        }
    }
}

