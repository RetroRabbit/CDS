namespace CDS.Util.TextPrinter.CharSets
{
    using CDS.Util.TextPrinter.Util;
    using System;

    public class Charset
    {
        public Vector aliases = new Vector();
        public int[] charactersCodes = new int[0x200];
        public int[] charactersUnicode = new int[0x200];
        public int charCount = 0;
        public string name = "";

        public void addAlias(string alias)
        {
            this.aliases.addElement(alias);
        }

        public void addChar(int code, int unicode)
        {
            this.charactersCodes[this.charCount] = code;
            this.charactersUnicode[this.charCount] = unicode;
            this.charCount++;
        }

        public int fromByteArray(byte[] b)
        {
            int num = b[0];
            if (b.GetLength(0) == 2)
            {
                num = b[0] + (b[1] * 0x100);
            }
            return num;
        }

        public byte[] fromUnicode(byte[] b)
        {
            int num = this.fromByteArray(b);
            if (num < 0)
            {
                num = 0x100 + num;
            }
            for (int i = 0; i < this.charCount; i++)
            {
                if (this.charactersUnicode[i] == num)
                {
                    return this.toByteArray(this.charactersCodes[i]);
                }
            }
            return null;
        }

        public Vector getAlises()
        {
            return this.aliases;
        }

        public int getCharAt(int i)
        {
            return this.charactersCodes[i];
        }

        public int getCharCount()
        {
            return this.charCount;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string s)
        {
            this.name = s;
        }

        public byte[] toByteArray(int i)
        {
            if (i <= 0x100)
            {
                return new byte[] { ((byte) i) };
            }
            return new byte[] { ((byte) (i % 0x100)), ((byte) Math.Floor((double) (((double) i) / 256.0))) };
        }

        public byte[] toUnicode(byte[] b)
        {
            int num = this.fromByteArray(b);
            if (num < 0)
            {
                num = 0x100 + num;
            }
            for (int i = 0; i < this.charCount; i++)
            {
                if (this.charactersCodes[i] == num)
                {
                    return this.toByteArray(this.charactersUnicode[i]);
                }
            }
            return null;
        }
    }
}

