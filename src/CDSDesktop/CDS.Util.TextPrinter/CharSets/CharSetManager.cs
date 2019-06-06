namespace CDS.Util.TextPrinter.CharSets
{
    using CDS.Util.TextPrinter.Util;
    using System;
    using System.Collections;
    using System.IO;
    using System.Resources;

    public class CharSetManager
    {
        private static CharSetManager defaultInstance = null;
        private int mnemonicCount = 0;
        private string[] mnemonics = new string[0x7d0];
        private int[] mnemonicValues = new int[0x7d0];
        private Vector sets = new Vector();
        private Hashtable setsHash = new Hashtable();

        protected CharSetManager()
        {
            this.loadCharSet2();
        }

        public Charset getCharSet(string name)
        {
            if (this.setsHash.ContainsKey(name))
            {
                return (Charset) this.setsHash[name];
            }
            return null;
        }

        public string[] getCharSetsList()
        {
            string[] strArray = new string[this.setsHash.Count];
            int num = 0;
            IDictionaryEnumerator enumerator = this.setsHash.GetEnumerator();
            while (enumerator.MoveNext())
            {
                strArray[num++] = (string) enumerator.Key;
            }
            return strArray;
        }

        protected string getFirstWord(string line)
        {
            int length = 0;
            length = line.IndexOf(" ");
            if (length > 0)
            {
                return line.Substring(0, length);
            }
            return line;
        }

        public static CharSetManager getInstance()
        {
            try
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new CharSetManager();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }
            return defaultInstance;
        }

        private void loadCharSet2()
        {
            byte[] buffer = global::CDS.Util.TextPrinter.Properties.Resources.charset;
    
            StreamReader reader = new StreamReader(new MemoryStream(buffer));
            string line = "";
            string key = "";
            Charset charset = null;
            bool flag = false;
            bool flag2 = false;
            while ((line = reader.ReadLine()) != null)
            {
                flag = false;
                line = line.Trim();
                if (line.StartsWith("name: "))
                {
                    charset = new Charset();
                    line = this.removeFirstWord(line);
                    key = this.getFirstWord(line);
                    if (this.setsHash.ContainsKey(key))
                    {
                        this.setsHash.Remove(key);
                    }
                    this.setsHash.Add(key, charset);
                    this.sets.addElement(charset);
                    charset.setName(key);
                    flag = true;
                }
                if (line.StartsWith("pseudo: "))
                {
                    line = this.removeFirstWord(line);
                    key = this.getFirstWord(line);
                    if (this.setsHash.ContainsKey(key))
                    {
                        this.setsHash.Remove(key);
                    }
                    this.setsHash.Add(key, charset);
                    charset.addAlias(key);
                    flag = true;
                }
                if (line.StartsWith("table"))
                {
                    flag2 = true;
                    flag = true;
                }
                if (line.StartsWith("etable"))
                {
                    flag2 = false;
                    flag = true;
                }
                if ((!flag && (line.Length > 0)) && flag2)
                {
                    int code = 0;
                    int unicode = 0;
                    code = Convert.ToInt32(this.getFirstWord(line), 0x10);
                    line = this.removeFirstWord(line);
                    unicode = Convert.ToInt32(this.getFirstWord(line), 0x10);
                    charset.addChar(code, unicode);
                }
            }
            reader.Close();
        }

        protected string removeFirstWord(string line)
        {
            int startIndex = 0;
            startIndex = line.IndexOf(" ");
            if (startIndex > 0)
            {
                return line.Substring(startIndex).Trim();
            }
            return "";
        }
    }
}

