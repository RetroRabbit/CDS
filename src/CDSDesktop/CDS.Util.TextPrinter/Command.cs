namespace CDS.Util.TextPrinter
{
    using System;

    public class Command
    {
        private string controlstring = "";
        protected static char ESC = '\x001b';
        private string name = "";

        public Command(string sName, string sControl)
        {
            this.controlstring = parseCommand(sControl);
            this.name = sName;
        }

        public string getCommand()
        {
            return this.controlstring;
        }

        public string getName()
        {
            return this.name;
        }

        public static string parseCommand(string s)
        {
            int num;
            for (num = s.ToUpper().IndexOf("ESC"); num >= 0; num = s.ToUpper().IndexOf("ESC"))
            {
                s = s.Substring(0, num) + ESC + s.Substring(num + 3);
            }
            for (num = s.ToUpper().IndexOf("CRTL+"); num >= 0; num = s.ToUpper().IndexOf("CRTL+"))
            {
                s = s.Substring(0, num) + ((char) (((byte) s[num + 5]) - 0x40)) + s.Substring(num + 6);
            }
            return s;
        }
    }
}

