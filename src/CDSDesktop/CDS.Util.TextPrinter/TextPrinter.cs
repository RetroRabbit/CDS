namespace CDS.Util.TextPrinter
{
    using CDS.Util.TextPrinter.CharSets;
    using CDS.Util.TextPrinter.Util;
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Text;

    public abstract class TextPrinter
    {
        public char blCornerChar = '+';
        protected bool bLFfterCR = true;
        public char brCornerChar = '+';
        protected byte[] buffer;
        protected int bufferPointer = 0;
        protected int bufferSize = 100;
        public bool calculateLineSpacing = false;
        public bool calculatePitchAndHMI = false;
        protected static CharSetManager charSetManager = null;
        protected Hashtable charSetValues = new Hashtable();
        protected static string CMD_FORM_LEGTH_INCHES = "CMD_FORM_LEGTH_INCHES";
        protected static string CMD_BOLD_OFF = "CMD_BOLD_OFF";
        protected static string CMD_BOLD_ON = "CMD_BOLD_ON";
        protected static string CMD_BOTTOM_MARGIN = "CMD_BOTTOM_MARGIN";
        protected static string CMD_CONDENSED_OFF = "CMD_CONDENSED_OFF";
        protected static string CMD_CONDENSED_ON = "CMD_CONDENSED_ON";
        protected static string CMD_DOUBLESTRIKE_OFF = "CMD_DOUBLESTRIKE_OFF";
        protected static string CMD_DOUBLESTRIKE_ON = "CMD_DOUBLESTRIKE_ON";
        protected static string CMD_DOUBLEWIDE_OFF = "CMD_DOUBLEWIDE_OFF";
        protected static string CMD_DOUBLEWIDE_ON = "CMD_DOUBLEWIDE_ON";
        protected static string CMD_DRAFT = "CMD_DRAFT";
        protected static string CMD_HMI = "CMD_HMI";
        protected static string CMD_HORIZONTAL_POSITIONING = "CMD_HORIZONTAL_POSITIONING";
        protected static string CMD_INTERSPACE = "CMD_INTERSPACE";
        protected static string CMD_ITALIC_OFF = "CMD_ITALIC_OFF";
        protected static string CMD_ITALIC_ON = "CMD_ITALIC_ON";
        protected static string CMD_LANDSCAPE = "CMD_LANDSCAPE";
        protected static string CMD_LEFT_MARGIN = "CMD_LEFT_MARGIN";
        protected static string CMD_PAGE_LENGTH_INCHES = "CMD_PAGE_LENGTH_INCHES";
        protected static string CMD_PAGE_LENGTH_LINES = "CMD_PAGE_LENGTH_LINES";
        protected static string CMD_AUTO_FEED_PAPER = "CMD_AUTO_FEED_PAPER";
        protected static string CMD_AUTO_CUT_PAPER = "CMD_AUTO_CUT_PAPER";
        protected static string CMD_PAGE_WIDTH = "CMD_PAGE_WIDTH";
        protected static string CMD_PAPER_SIZE = "CMD_PAPER_SIZE";
        protected static string CMD_PITCH = "CMD_PITCH";
        protected static string CMD_PORTRAIT = "CMD_PORTRAIT";
        protected static string CMD_PROPORTIONAL_OFF = "CMD_PROPORTIONAL_OFF";
        protected static string CMD_PROPORTIONAL_ON = "CMD_PROPORTIONAL_ON";
        protected static string CMD_QUALITY = "CMD_QUALITY";
        protected static string CMD_RESET = "CMD_RESET";
        protected static string CMD_RESOLUTION = "CMD_RESOLUTION";
        protected static string CMD_RIGHT_MARGIN = "CMD_RIGHT_MARGIN";
        protected static string CMD_SELECT_CHAR_SET = "CMD_SELECT_CHAR_SET";
        protected static string CMD_SELECT_FONT = "CMD_SELECT_FONT";
        protected static string CMD_SUBSCRIPT_OFF = "CMD_SUBSCRIPT_OFF";
        protected static string CMD_SUBSCRIPT_ON = "CMD_SUBSCRIPT_ON";
        protected static string CMD_SUPERSCRIPT_OFF = "CMD_SUPERSCRIPT_OFF";
        protected static string CMD_SUPERSCRIPT_ON = "CMD_SUPERSCRIPT_ON";
        protected static string CMD_TOP_MARGIN = "CMD_TOP_MARGIN";
        protected static string CMD_UNDERLINED_OFF = "CMD_UNDERLINED_OFF";
        protected static string CMD_UNDERLINED_ON = "CMD_UNDERLINED_ON";

        protected static string CMD_UTIL_NLQ_SELECTION = "CMD_UTIL_NLQ_SELECTION";
        protected static string CMD_PICA_PITCH = "CMD_PICA_PITCH";
        protected static string CMD_ELITE_PITCH = "CMD_ELITE_PITCH";
        protected static string CMD_FEED_N_216_LINE = "CMD_FEED_N_216_LINE";
        protected static string CMD_MOVE_LINE = "CMD_MOVE_LINE";
        
        protected Hashtable cmdDependencies = new Hashtable();
        protected Hashtable commands = new Hashtable();
        protected char CR = '\r';
        public char crossLineChar = '+';
        protected int currentCol = 0;
        private TextProperties currentProp = null;
        protected int currentRow = 0;
        public bool debug = false;
        public string defaultCharSet = "";
        // THIS CHARACTER WIL NOT PRINT. IT IS USED TO REPRESENT THE BLANK CHARACTER
        private char emptyCharater = 'à';
        protected char ESC = '\x001b';
        public bool feedFormPerSoftware = false;
        public bool cutFormPerSoftware = false;
        protected char FF = '\f';
        protected Hashtable fontValues = new Hashtable();
        public char hbLineChar = '+';
        public char hLineChar = '-';
        public char htLineChar = '+';
        protected Hashtable interspacingValues = new Hashtable();
        protected JobProperties jobSetup = null;
        public bool leftMarginPerSoftware = true;
        protected char LF = '\n';
        protected string CP = (char)27 + "@" + (char)29 + "V" + (char)1;
        //protected string CP = (char)29 + (char)86 + (char)1 + " ";
        public string linesCharSet = null;
        private int page = 0;
        protected char[,] pageData = null;
        protected TextProperties[,] pageDataProperties = null;
        protected Hashtable paperSizeValues = new Hashtable();
        public bool performCharSetConversion = true;
        protected Hashtable pitchValues = new Hashtable();
        protected PrinterPort port = null;
        protected Hashtable resolutionValues = new Hashtable();
        public bool rtrimLines = false;
        public char tlCornerChar = '+';
        public bool topMarginPerSoftware = false;
        public char trCornerChar = '+';
        public char vLineChar = '|';
        public char vlLineChar = '+';
        public char vrLineChar = '+';

        protected TextPrinter()
        {
        }

        protected void addCharSet(string name, string valueOrCommand, string charSet)
        {
            this.addParamValue(this.charSetValues, new CommandCharSetValue(name, valueOrCommand, charSet));
        }

        protected void addDependency(string mainCommand, string dependent)
        {
            Vector vector = null;
            if (this.cmdDependencies.ContainsKey(mainCommand))
            {
                vector = (Vector) this.cmdDependencies[mainCommand];
            }
            if (vector == null)
            {
                vector = new Vector();
                this.cmdDependencies.Add(mainCommand, vector);
            }
            vector.addElement(dependent);
        }

        protected void addFont(string name, string valueOrCommand)
        {
            this.addParamValue(this.fontValues, new CommandParamValue(name, valueOrCommand));
        }

        protected void addPaperSize(string name, string valueOrCommand)
        {
            this.addParamValue(this.paperSizeValues, new CommandParamValue(name, valueOrCommand));
        }

        protected void addParamValue(Hashtable table, CommandParamValue val)
        {
            if (table.ContainsKey(val.name))
            {
                table.Remove(val.name);
            }
            val.value = Command.parseCommand(val.value);
            table.Add(val.name, val);
        }

        protected void addPitch(string name, string valueOrCommand)
        {
            this.addParamValue(this.pitchValues, new CommandParamValue(name, valueOrCommand));
        }

        protected void addResolution(string name, string valueOrCommand)
        {
            this.addParamValue(this.resolutionValues, new CommandParamValue(name, valueOrCommand));
        }

        protected void addSpacing(string name, string valueOrCommand)
        {
            this.addParamValue(this.interspacingValues, new CommandParamValue(name, valueOrCommand));
        }

        protected void addToBuffer(string s)
        {
            try
            {
                this.addToBuffer(Encoding.GetEncoding(this.jobSetup.encoding).GetBytes(s));
            }
            catch (Exception exception)
            {
                throw new TextPrinterException(exception.Message);
            }
        }

        protected void addToBuffer(byte[] b)
        {
            bool flag = false;
            if (b != null)
            {
                for (int i = 0; i < b.GetLength(0); i++)
                {
                    if (this.debug)
                    {
                        if (i == 0)
                        {
                            if (b[i] == this.LF)
                            {
                                Console.WriteLine("LF ");
                            }
                            else if (b[i] == this.FF)
                            {
                                Console.Write("FF ");
                            }
                            else if (b[i] == this.CR)
                            {
                                Console.Write("CR ");
                            }
                            else if (b[i] == this.ESC)
                            {
                                Console.Write("ESC ");
                                flag = true;
                            }
                            else
                            {
                                Console.Write(string.Concat(new object[] { Convert.ToString(b[i], 0x10).ToUpper(), "(", (char) b[i], ") " }));
                            }
                        }
                        else if (flag)
                        {
                            byte[] buffer = new byte[] { b[i] };
                            Console.Write(string.Concat(new object[] { Convert.ToString(b[i], 0x10).ToUpper(), "(", (char) buffer[0], ") " }));
                        }
                        else
                        {
                            Console.Write(string.Concat(new object[] { Convert.ToString(b[i], 0x10).ToUpper(), "(", (char) b[i], ") " }));
                        }
                    }
                    try
                    {
                        this.buffer[this.bufferPointer++] = b[i];
                        if (this.bufferPointer == this.bufferSize)
                        {
                            this.flushBuffer();
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.Write(exception.Message);
                        Console.Write(exception.StackTrace);
                        break;
                    }
                }
            }
        }

        protected void calculateColumnWidth(int cols)
        {
            if (this.jobSetup.paperSize != null)
            {
                double num = this.jobSetup.paperSize.getWidth() / ((double) cols);
                double num2 = 1.0 / num;
                if (this.jobSetup.pitch == -1.0)
                {
                    this.jobSetup.pitch = num2;
                }
                if (this.jobSetup.columnWidth == -1.0)
                {
                    this.jobSetup.columnWidth = num;
                }
                if (this.debug)
                {
                    Console.WriteLine(string.Concat(new object[] { "Settings for ", cols, " columns and paper width ", this.jobSetup.paperSize.getWidth(), " inches:" }));
                    Console.WriteLine("Pitch: " + this.jobSetup.pitch);
                    Console.WriteLine("HMI: " + this.jobSetup.columnWidth);
                }
            }
        }

        protected void CalculateLineSpacing(int rows)
        {
            if ((this.jobSetup.paperSize != null) && (this.jobSetup.interspacing.Length == 0))
            {
                this.jobSetup.interspacing = this.getBestLineSpacing(rows, this.jobSetup.paperSize.getHeight());
            }
        }

        protected byte[] charMapping(char c, TextProperties prop)
        {
            string s = "" + c;
            if (this.performCharSetConversion)
            {
                if (prop == null)
                {
                    prop = this.getDefaultTextProperties();
                }
                string characterSet = prop.characterSet;
                if (characterSet == null)
                {
                    characterSet = this.defaultCharSet;
                }
                if (characterSet.Length == 0)
                {
                    characterSet = this.defaultCharSet;
                }
                if (characterSet.Length == 0)
                {
                    return Encoding.GetEncoding(this.jobSetup.encoding).GetBytes(s);
                }
                Charset charset = charSetManager.getCharSet(characterSet);
                if ((charset == null) && this.charSetValues.ContainsKey(characterSet))
                {
                    string charSet = ((CommandCharSetValue) this.charSetValues[characterSet]).charSet;
                    if (charSet.Length > 0)
                    {
                        charset = charSetManager.getCharSet(charSet);
                        if ((charset == null) && charSet.ToLower().StartsWith(".net:"))
                        {
                            return Encoding.GetEncoding(charSet.Substring(5)).GetBytes(s);
                        }
                    }
                }
                if (charset != null)
                {
                    byte[] buffer = charset.fromUnicode(Encoding.GetEncoding("UTF-16LE").GetBytes(s.Substring(0, 1)));
                    if ((buffer == null) && this.jobSetup.autoChartSetSelection)
                    {
                        string name = this.getCharSetforUnicode(Encoding.GetEncoding("UTF-16LE").GetBytes(s.Substring(0, 1)));
                        if (name != null)
                        {
                            buffer = charSetManager.getCharSet(name).fromUnicode(Encoding.GetEncoding("UTF-16LE").GetBytes(s.Substring(0, 1)));
                            prop.characterSet = name;
                        }
                    }
                    return buffer;
                }
            }
            return Encoding.GetEncoding(this.jobSetup.encoding).GetBytes(s);
        }

        protected void clearCharSet()
        {
            this.charSetValues.Clear();
        }

        protected void clearCPIList()
        {
            this.pitchValues.Clear();
        }

        protected void clearFonts()
        {
            this.fontValues.Clear();
        }

        protected void clearSpacing()
        {
            this.interspacingValues.Clear();
        }

        private string[] convertToArray(Vector v)
        {
            object[] objArray = v.ToArray();
            string[] strArray = new string[objArray.GetLength(0)];
            for (int i = 0; i < objArray.GetLength(0); i++)
            {
                strArray[i] = (string) objArray[i];
            }
            return strArray;
        }

        public void endJob()
        {
            this.finishPage();
            this.flushBuffer();
            this.port.close();
        }

        public void autoFeedToTearOff(bool val)
        {
            feedFormPerSoftware = !val;
        }

        public void autoCutToTearOff(bool val)
        {
            cutFormPerSoftware = !val;
        }        

        public void executeCommand(string name)
        {
            this.executeCommandInternal(name);
        }

        public void executeCommand(string name, string param)
        {
            this.executeCommandInternal(name, param);
        }

        protected void executeCommandInternal(string name)
        {
            Command command = this.getCommand(name);
            if (command != null && !command.getCommand().Equals(string.Empty))
            {
                this.addToBuffer(command.getCommand());
                if (this.debug)
                {
                    Console.WriteLine(command.getName());
                }
                this.executeDependencies(name);
            }
        }

        protected void executeCommandInternal(string name, string param)
        {
            Command command = this.getCommand(name);
            if (command != null && !command.getCommand().Equals(string.Empty))
            {
                this.addToBuffer(this.replaceParameter(command.getCommand(), param));
                if (this.debug)
                {
                    Console.WriteLine(command.getName() + " : " + param);
                }
                this.executeDependencies(name);
            }
        }

        protected void executeDependencies(string cmdName)
        {
            Vector vector = null;
            if (this.cmdDependencies.ContainsKey(cmdName))
            {
                vector = (Vector) this.cmdDependencies[cmdName];
            }
            if (vector != null)
            {
                if (this.debug)
                {
                    Console.WriteLine("Processing dependencies");
                }
                for (int i = 0; i < vector.size(); i++)
                {
                    string str = (string) vector.elementAt(i);
                    if (str.Equals(CMD_HMI) && (this.jobSetup.columnWidth > 0.0))
                    {
                        this.executeCommand(CMD_HMI, "" + this.jobSetup.columnWidth);
                    }
                }
                if (this.debug)
                {
                    Console.WriteLine("End of dependencies");
                }
            }
        }

        protected void finishPage()
        {
            int num;
            this.page++;
            byte[] b = new byte[1];
            bool flag = false;
            if (this.topMarginPerSoftware)
            {
                num = 0;
                while (num < this.jobSetup.topMargin)
                {
                    b[0] = (byte)this.CR;
                    this.addToBuffer(b);
                    if (this.bLFfterCR)
                    {
                        b[0] = (byte)this.LF;
                        this.addToBuffer(b);
                    }
                    num++;
                }
            }

            for (int i = this.jobSetup.topMargin; i < (this.jobSetup.rows - this.jobSetup.bottomMargin); i++)
            {
                int num7;
                flag = false;
                char c = ' ';
                if (this.topMarginPerSoftware)
                {
                    for (num = 0; num < this.jobSetup.leftMargin; num++)
                    {
                        this.writeCharToBuffer(c, null);
                    }
                }
                int num5 = this.jobSetup.cols - this.jobSetup.rightMargin;
                int leftMargin = this.jobSetup.leftMargin;
                if (this.rtrimLines)
                {
                    num7 = num5 - 1;
                    while (num7 >= leftMargin)
                    {
                        if ((this.pageDataProperties[i, num7] != null) && (this.pageData[i, num7] != this.emptyCharater))
                        {
                            num5 = num7 + 1;
                            break;
                        }
                        if (num7 == leftMargin)
                        {
                            num5 = leftMargin;
                            break;
                        }
                        num7--;
                    }
                }
                for (num7 = leftMargin; num7 < num5; num7++)
                {
                    // Check if only empty space characters are left and skip this step
                    bool onlyspaces = true;
                    for (int l = num7; l < num5; l++)
                    {
                        if ((this.pageDataProperties[i, l] != null) && (this.pageData[i, l] != this.emptyCharater))
                        {
                            onlyspaces = false;
                            break;
                        }
                    }
                    if (onlyspaces) 
                        continue;

                    if ((this.pageDataProperties[i, num7] == null) || (this.pageData[i, num7] == this.emptyCharater))
                    {
                        if (!(this.jobSetup.proportional && this.supportsCommand(CMD_HORIZONTAL_POSITIONING)))
                        {
                            this.writeCharToBuffer(c, this.getDefaultTextProperties());
                        }
                        if (this.jobSetup.proportional && this.supportsCommand(CMD_HORIZONTAL_POSITIONING))
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        if (flag)
                        {
                            this.moveToHPosition(num7);
                        }
                        TextProperties newProp = this.pageDataProperties[i, num7];
                        this.writeCharToBuffer(this.pageData[i, num7], newProp);
                        flag = false;
                    }
                }
                b[0] = (byte)this.CR;
                this.addToBuffer(b);
                if (this.bLFfterCR)
                {
                    b[0] = (byte)this.LF;
                    this.addToBuffer(b);
                }
            }
            if (!this.feedFormPerSoftware)
            {
                if (this.debug)
                {
                    Console.WriteLine("\nAdding FF command to the buffer\n");
                }

                b[0] = (byte)this.CR;
                this.addToBuffer(b);
                b[0] = (byte)this.FF;
                this.addToBuffer(b);
            }
            else if (this.feedFormPerSoftware)
            {
                b[0] = (byte)this.CR;
                this.addToBuffer(b);
                if (this.bLFfterCR)
                {
                    b[0] = (byte)this.LF;
                    this.addToBuffer(b);
                }
                
                byte[] cutByte = (new System.Text.UTF8Encoding()).GetBytes(this.CP);
                this.addToBuffer(cutByte);
            }
            else if (this.debug)
            {
                Console.WriteLine("\nHardware FF disabled\n");
            }

            byte[] cutBytes = (new System.Text.UTF8Encoding()).GetBytes(this.CP);
            
            //Weet nie hoekom add ons dit hier nie? maak nie sin hoekom ons dan n if statement het onder nie???
            //this.addToBuffer(cutBytes);

            if (!this.cutFormPerSoftware)
            {
                if (this.debug)
                {
                    Console.WriteLine("\nAdding CP command to the buffer\n");
                }
                this.addToBuffer(cutBytes);
            }
            else if (this.debug)
            {
                Console.WriteLine("\nHardware CP disabled\n");
            }


            this.resetPageData();
        }

        protected void flushBuffer()
        {
            if (this.bufferPointer > 0)
            {
                this.port.write(this.buffer, this.bufferPointer);
            }
            this.bufferPointer = 0;
        }

        protected string getBestLineSpacing(int lines, double pageHeight)
        {
            int num = 0x3e8;
            string str = "";
            IDictionaryEnumerator enumerator = this.interspacingValues.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string str2;
                int num3;
                CommandParamValue value2 = (CommandParamValue) enumerator.Value;
                if (Convert.ToInt32(value2.name) >= 60)
                {
                    for (int i = 1; i < Convert.ToInt32(value2.name); i++)
                    {
                        str2 = string.Concat(new object[] { "", i, "/", value2.name });
                        num3 = this.getLinesForSpacing(str2, pageHeight);
                        if (num3 == lines)
                        {
                            return str2;
                        }
                        if ((num3 >= lines) && ((num - lines) > (num3 - lines)))
                        {
                            num = num3;
                            str = str2;
                        }
                    }
                }
                else
                {
                    str2 = "1/" + value2.name;
                    num3 = this.getLinesForSpacing(str2, pageHeight);
                    if (num3 == lines)
                    {
                        return str2;
                    }
                    if ((num3 >= lines) && ((num - lines) > (num3 - lines)))
                    {
                        num = num3;
                        str = str2;
                    }
                }
            }
            if (this.debug)
            {
                Console.WriteLine("Best line spacing:  " + str);
            }
            return str;
        }

        protected string getBestPitchCommand(string pitch)
        {
            int num = 0;
            string str = null;
            double num2 = Convert.ToDouble(pitch);
            IDictionaryEnumerator enumerator = this.pitchValues.GetEnumerator();
            while (enumerator.MoveNext())
            {
                CommandParamValue value2 = (CommandParamValue) enumerator.Value;
                if (value2.name.Equals("*"))
                {
                    return value2.value;
                }
                if (Convert.ToDouble(value2.name) == num2)
                {
                    return value2.value;
                }
                if ((Convert.ToDouble(value2.name) > num2) && (Convert.ToDouble(value2.name) < num))
                {
                    num = Convert.ToInt32(value2.name);
                    str = value2.value;
                }
            }
            return str;
        }

        public int getBufferSize()
        {
            return this.bufferSize;
        }

        protected string getCharSetforUnicode(byte[] b)
        {
            IDictionaryEnumerator enumerator = this.charSetValues.GetEnumerator();
            while (enumerator.MoveNext())
            {
                CommandParamValue value2 = (CommandParamValue) enumerator.Value;
                Charset charset = charSetManager.getCharSet(value2.name);
                if ((charset != null) && (charset.fromUnicode(b) != null))
                {
                    return value2.name;
                }
            }
            return null;
        }

        public Command getCommand(string name)
        {
            if (this.commands.ContainsKey(name))
            {
                return (Command) this.commands[name];
            }
            return null;
        }

        public JobProperties getDefaultJobProperties()
        {
            JobProperties properties = new JobProperties();
            properties.topMargin = 0;
            return properties;
        }

        public TextProperties getDefaultTextProperties()
        {
            TextProperties t = new TextProperties();
            this.setJobDefaults(t);
            if (this.jobSetup != null)
            {
                t.proportional = this.jobSetup.proportional;
                t.condensed = this.jobSetup.condensed;
            }
            return t;
        }

        public string[] getFirstElements(string[][] t)
        {
            Vector v = new Vector();
            for (int i = 0; i < t.GetLength(0); i++)
            {
                v.addElement(t[i][0]);
            }
            return this.convertToArray(v);
        }

        protected int getLinesForSpacing(string spacing, double pageHeight)
        {
            int index = spacing.IndexOf("/");
            string str = spacing.Substring(0, index);
            string str2 = spacing.Substring(index + 1);
            int num2 = Convert.ToInt32(str);
            int num3 = Convert.ToInt32(str2);
            double num4 = (pageHeight * num3) / ((double) num2);
            return (int) num4;
        }

        protected byte[] getLowHeightBytes(double i)
        {
            return new byte[] { ((byte) (i % 256.0)), ((byte) Math.Floor((double) (i / 256.0))) };
        }

        public IDictionaryEnumerator getSupportedCharPitch()
        {
            return this.pitchValues.GetEnumerator();
        }

        public string[] getSupportedCharSets()
        {
            IDictionaryEnumerator enumerator = this.charSetValues.GetEnumerator();
            Vector v = new Vector();
            while (enumerator.MoveNext())
            {
                CommandCharSetValue value2 = (CommandCharSetValue) enumerator.Value;
                v.addElement(value2.name);
            }
            return this.convertToArray(v);
        }

        public IDictionaryEnumerator getSupportedFonts()
        {
            return this.fontValues.GetEnumerator();
        }

        public IDictionaryEnumerator getSupportedInterspacing()
        {
            return this.interspacingValues.GetEnumerator();
        }

        internal void init()
        {
            this.buffer = new byte[this.bufferSize + 1];
        }

        private bool isChar(int line, int col, char[] c)
        {
            if (line < this.pageData.GetLength(0))
            {
                if (col >= this.pageData.GetLength(1))
                {
                    return false;
                }
                for (int i = 0; i < c.GetLength(0); i++)
                {
                    if (this.pageData[line, col] == c[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected string mapTableLookup(Hashtable table, string value)
        {
            if (table != null)
            {
                IDictionaryEnumerator enumerator = table.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    CommandParamValue value2 = (CommandParamValue) enumerator.Value;
                    if (value2.name.Equals(value))
                    {
                        return value2.value;
                    }
                    if (value2.name.Equals("*"))
                    {
                        return value2.value;
                    }
                }
            }
            return null;
        }

        protected void moveToHPosition(int col)
        {
            this.executeCommand(CMD_HORIZONTAL_POSITIONING, "" + col);
        }

        public void newLine()
        {
            this.currentRow++;
            this.currentCol = this.jobSetup.leftMargin;
            if (this.currentRow > (this.jobSetup.rows - this.jobSetup.bottomMargin))
            {
                this.finishPage();
            }
        }

        public void newPage()
        {
            this.finishPage();
        }

        public void printArray(string[] t)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                Console.WriteLine(t[i]);
            }
        }

        public void printHorizontalLine(int row, int col1, int col2)
        {
            TextProperties t = new TextProperties();
            if ((this.linesCharSet != null) && (this.linesCharSet.Length > 0))
            {
                t.characterSet = this.linesCharSet;
            }
            if (col2 < col1)
            {
                int num = col2;
                col2 = col1;
                col1 = num;
            }
            for (int i = col1; i <= col2; i++)
            {
                this.setHChar(row, i, i == col1, i == col2, t);
            }
        }

        public void printRectangle(int x1, int y1, int x2, int y2)
        {
            TextProperties properties = new TextProperties();
            if ((this.linesCharSet != null) && (this.linesCharSet.Length > 0))
            {
                properties.characterSet = this.linesCharSet;
            }
            this.printHorizontalLine(y1, x1, x2);
            this.printHorizontalLine(y2, x1, x2);
            this.printVerticalLine(x1, y1, y2);
            this.printVerticalLine(x2, y1, y2);
        }

        public void printString(string s)
        {
            this.printString(s, this.getDefaultTextProperties());
        }

        public void printString(string s, TextProperties t)
        {
            this.printString(s, this.currentRow, this.currentCol, t);
            this.currentCol += s.Length;
            if (this.currentCol > (this.jobSetup.cols - this.jobSetup.rightMargin))
            {
                this.currentRow++;
            }
            if (this.currentRow > (this.jobSetup.rows - this.jobSetup.bottomMargin))
            {
                this.finishPage();
            }
        }

        public void printString(string s, Font font)
        {
            this.printString(s, this.currentRow, this.currentCol, font);
            this.currentCol += s.Length;
            if (this.currentCol >= (this.jobSetup.cols - this.jobSetup.rightMargin))
            {
                this.currentRow++;
            }
            if (this.currentRow > (this.jobSetup.rows - this.jobSetup.bottomMargin))
            {
                this.finishPage();
            }
        }

        private void printString(char c, int row, int col, TextProperties t)
        {
            this.printString("" + c, row, col, t);
        }

        public void printString(string s, int row, int col, TextProperties t)
        {
            if (t == null)
            {
                t = new TextProperties();
            }
            TextProperties properties = t.getClone();
            //rows
            string[] rows = s.Split(new char [] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < rows.Length; j++)
            {
                // columns
                for (int i = 0; i < rows[j].Length; i++)
                {

                    if ((col + i) > (this.jobSetup.cols - this.jobSetup.rightMargin))
                    {
                        break;
                    }
                    if ((row < this.pageData.GetLength(0)) && ((col + i) < this.pageData.GetLength(1)))
                    {
                        try
                        {
                            this.pageData[row + j, col + i] = rows[j][i];
                            this.pageDataProperties[row + j, col + i] = properties;
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                            Console.WriteLine(exception.StackTrace);
                        }
                    }
                }
            }
        }

        public void printString(string s, int row, int col, Font font)
        {
            TextProperties t = new TextProperties();
            t.bold = font.Bold;
            t.italic = font.Italic;
            t.fontName = font.Name;
            this.printString(s, row, col, t);
        }

        public void printVerticalLine(int col, int row1, int row2)
        {
            TextProperties t = new TextProperties();
            if ((this.linesCharSet != null) && (this.linesCharSet.Length > 0))
            {
                t.characterSet = this.linesCharSet;
            }
            if (row2 < row1)
            {
                int num = row2;
                row2 = row1;
                row1 = num;
            }
            for (int i = row1; i <= row2; i++)
            {
                this.setVChar(i, col, i == row1, i == row2, t);
            }
        }

        protected void processCommandsForCharacterSet(string currentSet, string newSet)
        {
            if (!currentSet.Equals(newSet) && !newSet.Equals(""))
            {
                string param = this.mapTableLookup(this.charSetValues, newSet);
                if (param != null)
                {
                    this.executeCommand(CMD_SELECT_CHAR_SET, param);
                }
            }
        }

        protected void processCommandsForFont(string currentFont, string newFont)
        {
            if (!currentFont.Equals(newFont) && !newFont.Equals(""))
            {
                string param = this.mapTableLookup(this.fontValues, newFont);
                if (param != null)
                {
                    this.executeCommand(CMD_SELECT_FONT, param);
                }
            }
        }

        protected void processCommandsForJob()
        {
            this.executeCommand(CMD_RESET);
            this.addToBuffer(this.jobSetup.userResetCommands);            
            if (this.debug)
            {
                Console.WriteLine("User reset command: " + this.jobSetup.userResetCommands);
            }
            this.processCommandsResolution(this.jobSetup.resolution);
            if (this.jobSetup.paperSize != null)
            {
                this.processCommandsPaperSize(this.jobSetup.paperSize);
            }
            if (this.jobSetup.landscape)
            {
                this.executeCommand(CMD_LANDSCAPE);
            }
            else
            {
                this.executeCommand(CMD_PORTRAIT);
            }
            if (this.jobSetup.proportional)
            {
                this.executeCommand(CMD_PROPORTIONAL_ON);
            }
            if (!this.jobSetup.proportional)
            {
                this.executeCommand(CMD_PROPORTIONAL_OFF);
            }
            if (this.calculateLineSpacing)
            {
                this.CalculateLineSpacing(this.jobSetup.rows);
            }
            if (this.calculatePitchAndHMI)
            {
                this.calculateColumnWidth(this.jobSetup.cols);
            }
            if (this.jobSetup.pitch > 0.0)
            {
                this.processCommandsForPitch("", "" + this.jobSetup.pitch);
            }
            if (this.jobSetup.columnWidth > 0.0)
            {
                this.executeCommand(CMD_HMI, "" + this.jobSetup.columnWidth);
            }
            if (this.jobSetup.interspacing.Length > 0)
            {
                this.processCommandsForLineSpacing(this.jobSetup.interspacing);
            }
            if (this.jobSetup.condensed)
            {
                this.executeCommand(CMD_CONDENSED_ON);
            }
            if (!this.topMarginPerSoftware)
            {
                this.executeCommand(CMD_TOP_MARGIN, "" + this.jobSetup.topMargin);
                if ((this.jobSetup.bottomMargin > 0) && (this.jobSetup.rows > this.jobSetup.bottomMargin))
                {
                    this.executeCommand(CMD_BOTTOM_MARGIN, "" + (this.jobSetup.rows - this.jobSetup.bottomMargin));
                }
            }
            else
            {
                this.executeCommand(CMD_TOP_MARGIN, "0");
            }
            if (this.supportsCommand(CMD_PAGE_LENGTH_INCHES) && (this.jobSetup.paperSize != null))
            {
                this.executeCommand(CMD_PAGE_LENGTH_INCHES, "" + this.jobSetup.paperSize.getHeight());
            }
            else
            {
                //WERNER -- THIS IS WHY IT PRINTS A "5"
                this.executeCommand(CMD_PAGE_LENGTH_LINES, "" + this.jobSetup.rows);
            }
            if (!this.leftMarginPerSoftware)
            {
                this.executeCommand(CMD_LEFT_MARGIN, "" + this.jobSetup.leftMargin);
                this.executeCommand(CMD_RIGHT_MARGIN, "" + (this.jobSetup.cols - this.jobSetup.rightMargin));
            }
            else
            {
                this.executeCommand(CMD_LEFT_MARGIN, "0");
                this.executeCommand(CMD_RIGHT_MARGIN, "" + this.jobSetup.cols);
            }
            if (this.jobSetup.draftQuality)
            {
                this.executeCommand(CMD_DRAFT);
            }
            else
            {
                this.executeCommand(CMD_QUALITY);
            }
            if (this.defaultCharSet.Length > 0)
            {
                this.processCommandsForCharacterSet("", this.defaultCharSet);
            }
            this.addToBuffer(this.jobSetup.userDefinedCommands);
            if (this.debug)
            {
                Console.WriteLine("User command: " + this.jobSetup.userDefinedCommands);
            }
        }

        protected void processCommandsForLineSpacing(string spacing)
        {
            int index = spacing.IndexOf("/");
            string str = spacing.Substring(0, index);
            string str2 = spacing.Substring(index + 1);
            string command = this.mapTableLookup(this.interspacingValues, str2);
            if (command != null)
            {
                command = this.replaceParameter(command, str);
                this.executeCommand(CMD_INTERSPACE, command);
            }
            else
            {
                try
                {
                    IDictionaryEnumerator enumerator = this.interspacingValues.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        CommandParamValue value2 = (CommandParamValue) enumerator.Value;
                        if (Convert.ToInt32(value2.name) >= 60)
                        {
                            double d = Convert.ToDouble(value2.name) / Convert.ToDouble(str2);
                            if (d == Math.Floor(d))
                            {
                                command = this.replaceParameter(value2.value, "" + ((int) d));
                                this.executeCommand(CMD_INTERSPACE, command);
                                return;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(exception.StackTrace);
                }
            }
        }

        protected void processCommandsForPitch(string currentPitch, string newPitch)
        {
            if (!currentPitch.Equals(newPitch) && !newPitch.Equals(""))
            {
                string command = this.getBestPitchCommand(newPitch);
                if (command != null)
                {
                    command = this.replaceParameter(command, newPitch);
                    this.executeCommand(CMD_PITCH, command);
                }
            }
        }

        protected void processCommandsForTextProperties(TextProperties current, TextProperties next)
        {
            if (!(!current.bold || next.bold))
            {
                this.executeCommand(CMD_BOLD_OFF);
            }
            if (!(current.bold || !next.bold))
            {
                this.executeCommand(CMD_BOLD_ON);
            }
            if (!(!current.italic || next.italic))
            {
                this.executeCommand(CMD_ITALIC_OFF);
            }
            if (!(current.italic || !next.italic))
            {
                this.executeCommand(CMD_ITALIC_ON);
            }
            if (!(!current.underlined || next.underlined))
            {
                this.executeCommand(CMD_UNDERLINED_OFF);
            }
            if (!(current.underlined || !next.underlined))
            {
                this.executeCommand(CMD_UNDERLINED_ON);
            }
            if (!(!current.doubleStrike || next.doubleStrike))
            {
                this.executeCommand(CMD_DOUBLESTRIKE_OFF);
            }
            if (!(current.doubleStrike || !next.doubleStrike))
            {
                this.executeCommand(CMD_DOUBLESTRIKE_ON);
            }
            if (!(!current.doubleWide || next.doubleWide))
            {
                this.executeCommand(CMD_DOUBLEWIDE_OFF);
            }
            if (!(current.doubleWide || !next.doubleWide))
            {
                this.executeCommand(CMD_DOUBLEWIDE_ON);
            }
            if (!(!current.superscript || next.superscript))
            {
                this.executeCommand(CMD_SUPERSCRIPT_OFF);
            }
            if (!(current.superscript || !next.superscript))
            {
                this.executeCommand(CMD_SUPERSCRIPT_ON);
            }
            if (!(!current.subscript || next.subscript))
            {
                this.executeCommand(CMD_SUBSCRIPT_OFF);
            }
            if (!(current.subscript || !next.subscript))
            {
                this.executeCommand(CMD_SUBSCRIPT_ON);
            }
            if (!(current.proportional || !next.proportional))
            {
                this.executeCommand(CMD_PROPORTIONAL_ON);
            }
            if (!(!current.proportional || next.proportional))
            {
                this.executeCommand(CMD_PROPORTIONAL_OFF);
            }
            if (!(current.condensed || !next.condensed))
            {
                this.executeCommand(CMD_CONDENSED_ON);
            }
            if (!(!current.condensed || next.condensed))
            {
                this.executeCommand(CMD_CONDENSED_OFF);
            }
            this.processCommandsForPitch("" + current.pitch, "" + next.pitch);
            this.processCommandsForFont(current.fontName, next.fontName);
            if (next.characterSet.Length == 0)
            {
                next.characterSet = this.defaultCharSet;
            }
            if (current.characterSet.Length == 0)
            {
                current.characterSet = this.defaultCharSet;
            }
            this.processCommandsForCharacterSet(current.characterSet, next.characterSet);
        }

        protected void processCommandsPaperSize(PaperSize paper)
        {
            string param = this.mapTableLookup(this.paperSizeValues, paper.getName());
            if (param != null)
            {
                this.executeCommand(CMD_PAPER_SIZE, param);
            }
        }

        protected void processCommandsResolution(int resolution)
        {
            string param = this.mapTableLookup(this.resolutionValues, "" + resolution);
            if (param != null)
            {
                this.executeCommand(CMD_RESOLUTION, param);
            }
        }

        protected string replaceParameter(string command, string value)
        {
            int index = command.IndexOf("#CHAR#");
            if (index >= 0)
            {
                if (value.Length == 0)
                {
                    value = "0";
                }
                byte[] bytes = new byte[] { (byte) (0xff & ((int) Math.Floor(Convert.ToDouble(value)))) };
                try
                {
                    command = command.Substring(0, index) + Encoding.GetEncoding(this.jobSetup.encoding).GetString(bytes) + command.Substring(index + 6);
                }
                catch (Exception exception)
                {
                    throw new TextPrinterException(exception.Message);
                }
            }
            index = command.IndexOf("#");
            if (index >= 0)
            {
                command = command.Substring(0, index) + value + command.Substring(index + 1);
            }
            return command;
        }

        public void resetCommand(string cmd)
        {
            if (this.commands.ContainsKey(cmd))
            {
                this.commands.Remove(cmd);
            }
        }

        protected void resetPageData()
        {
            this.currentRow = this.jobSetup.topMargin;
            this.currentCol = this.jobSetup.leftMargin;
            this.pageData = new char[this.jobSetup.rows, this.jobSetup.cols];
            this.pageDataProperties = new TextProperties[this.jobSetup.rows, this.jobSetup.cols];
        }

        public void setBufferSize(int s)
        {
            byte[] buffer = new byte[this.bufferSize + 1];
            this.bufferSize = s;
            for (int i = 0; (i < this.buffer.GetLength(0)) && (i < buffer.GetLength(0)); i++)
            {
                buffer[i] = this.buffer[i];
            }
            this.buffer = buffer;
        }

        public void setCommand(Command cmd)
        {
            if (!this.commands.ContainsKey(cmd.getName()))
            {
                this.commands.Add(cmd.getName(), cmd);
            }
        }

        private void setHChar(int line, int col, bool firstInLine, bool lastInLine, TextProperties t)
        {
            if ((((line < this.pageData.GetLength(0)) && (col < this.pageData.GetLength(1))) && (!this.isChar(line, col, new char[] { this.hLineChar, this.hbLineChar, this.htLineChar, this.crossLineChar }) && (!lastInLine || !this.isChar(line, col, new char[] { this.trCornerChar, this.brCornerChar })))) && (((!firstInLine || !this.isChar(line, col, new char[] { this.tlCornerChar, this.blCornerChar })) && (!firstInLine || !this.isChar(line, col, new char[] { this.vrLineChar }))) && (!lastInLine || !this.isChar(line, col, new char[] { this.vlLineChar }))))
            {
                if (this.pageData[line, col] == this.vLineChar)
                {
                    if (this.isChar(line + 1, col, new char[] { this.htLineChar, this.vLineChar, this.vrLineChar, this.vlLineChar, this.blCornerChar, this.brCornerChar, this.crossLineChar }) && !this.isChar(line - 1, col, new char[] { this.hbLineChar, this.vLineChar, this.vrLineChar, this.vlLineChar, this.tlCornerChar, this.trCornerChar, this.crossLineChar }))
                    {
                        if (lastInLine)
                        {
                            this.printString(this.trCornerChar, line, col, t);
                        }
                        else if (firstInLine)
                        {
                            this.printString(this.tlCornerChar, line, col, t);
                        }
                        else
                        {
                            this.printString(this.hbLineChar, line, col, t);
                        }
                    }
                    else if (!this.isChar(line + 1, col, new char[] { this.htLineChar, this.vLineChar, this.vrLineChar, this.vlLineChar, this.blCornerChar, this.brCornerChar, this.crossLineChar }) && this.isChar(line - 1, col, new char[] { this.hbLineChar, this.vLineChar, this.vrLineChar, this.vlLineChar, this.tlCornerChar, this.trCornerChar, this.crossLineChar }))
                    {
                        if (lastInLine)
                        {
                            this.printString(this.brCornerChar, line, col, t);
                        }
                        else if (firstInLine)
                        {
                            this.printString(this.blCornerChar, line, col, t);
                        }
                        else
                        {
                            this.printString(this.htLineChar, line, col, t);
                        }
                    }
                    else if (this.isChar(line + 1, col, new char[] { this.htLineChar, this.vLineChar, this.vrLineChar, this.vlLineChar, this.blCornerChar, this.brCornerChar, this.crossLineChar }) && this.isChar(line - 1, col, new char[] { this.hbLineChar, this.vLineChar, this.vrLineChar, this.vlLineChar, this.tlCornerChar, this.trCornerChar, this.crossLineChar }))
                    {
                        if (lastInLine)
                        {
                            this.printString(this.vlLineChar, line, col, t);
                        }
                        else if (firstInLine)
                        {
                            this.printString(this.vrLineChar, line, col, t);
                        }
                        else
                        {
                            this.printString(this.crossLineChar, line, col, t);
                        }
                    }
                    else if (lastInLine)
                    {
                        this.printString(this.vlLineChar, line, col, t);
                    }
                    else if (firstInLine)
                    {
                        this.printString(this.vrLineChar, line, col, t);
                    }
                    else
                    {
                        this.printString(this.crossLineChar, line, col, t);
                    }
                }
                else if ((this.pageData[line, col] == this.vrLineChar) || (this.pageData[line, col] == this.vlLineChar))
                {
                    this.printString(this.crossLineChar, line, col, t);
                }
                else if ((this.pageData[line, col] == this.trCornerChar) || (this.pageData[line, col] == this.tlCornerChar))
                {
                    this.printString(this.hbLineChar, line, col, t);
                }
                else if ((this.pageData[line, col] == this.brCornerChar) || (this.pageData[line, col] == this.blCornerChar))
                {
                    this.printString(this.htLineChar, line, col, t);
                }
                else
                {
                    this.printString(this.hLineChar, line, col, t);
                }
            }
        }

        private void setJobDefaults(TextProperties t)
        {
            if (this.jobSetup != null)
            {
                if (t.pitch <= 0.0)
                {
                    t.pitch = this.jobSetup.pitch;
                }
                if (t.characterSet.Length == 0)
                {
                    t.characterSet = this.defaultCharSet;
                }
            }
        }

        public void setLFafterCR(bool b)
        {
            this.bLFfterCR = b;
        }

        private void setVChar(int line, int col, bool firstInLine, bool lastInLine, TextProperties t)
        {
            if ((((line < this.pageData.GetLength(0)) && (col < this.pageData.GetLength(1))) && (!this.isChar(line, col, new char[] { this.vLineChar, this.vlLineChar, this.vrLineChar, this.crossLineChar }) && (!lastInLine || !this.isChar(line, col, new char[] { this.brCornerChar, this.blCornerChar })))) && (((!firstInLine || !this.isChar(line, col, new char[] { this.tlCornerChar, this.trCornerChar })) && (!firstInLine || !this.isChar(line, col, new char[] { this.hbLineChar }))) && (!lastInLine || !this.isChar(line, col, new char[] { this.htLineChar }))))
            {
                if (this.pageData[line, col] == this.hLineChar)
                {
                    if (this.isChar(line, col + 1, new char[] { this.vlLineChar, this.hbLineChar, this.htLineChar, this.hLineChar, this.trCornerChar, this.brCornerChar, this.crossLineChar }) && !this.isChar(line, col - 1, new char[] { this.vrLineChar, this.hbLineChar, this.htLineChar, this.hLineChar, this.tlCornerChar, this.blCornerChar, this.crossLineChar }))
                    {
                        if (lastInLine)
                        {
                            this.printString(this.blCornerChar, line, col, t);
                        }
                        else if (firstInLine)
                        {
                            this.printString(this.tlCornerChar, line, col, t);
                        }
                        else
                        {
                            this.printString(this.vrLineChar, line, col, t);
                        }
                    }
                    else if (!this.isChar(line, col + 1, new char[] { this.vlLineChar, this.hbLineChar, this.htLineChar, this.hLineChar, this.trCornerChar, this.brCornerChar, this.crossLineChar }) && this.isChar(line, col - 1, new char[] { this.vrLineChar, this.hbLineChar, this.htLineChar, this.hLineChar, this.tlCornerChar, this.blCornerChar, this.crossLineChar }))
                    {
                        if (lastInLine)
                        {
                            this.printString(this.brCornerChar, line, col, t);
                        }
                        else if (firstInLine)
                        {
                            this.printString(this.trCornerChar, line, col, t);
                        }
                        else
                        {
                            this.printString(this.vlLineChar, line, col, t);
                        }
                    }
                    else if (this.isChar(line, col + 1, new char[] { this.vlLineChar, this.hbLineChar, this.htLineChar, this.hLineChar, this.trCornerChar, this.brCornerChar, this.crossLineChar }) && this.isChar(line, col - 1, new char[] { this.vrLineChar, this.hbLineChar, this.htLineChar, this.hLineChar, this.tlCornerChar, this.blCornerChar, this.crossLineChar }))
                    {
                        if (lastInLine)
                        {
                            this.printString(this.htLineChar, line, col, t);
                        }
                        else if (firstInLine)
                        {
                            this.printString(this.hbLineChar, line, col, t);
                        }
                        else
                        {
                            this.printString(this.crossLineChar, line, col, t);
                        }
                    }
                    else if (lastInLine)
                    {
                        this.printString(this.htLineChar, line, col, t);
                    }
                    else if (firstInLine)
                    {
                        this.printString(this.hbLineChar, line, col, t);
                    }
                    else
                    {
                        this.printString(this.crossLineChar, line, col, t);
                    }
                }
                else if ((this.pageData[line, col] == this.hbLineChar) || (this.pageData[line, col] == this.htLineChar))
                {
                    this.printString(this.crossLineChar, line, col, t);
                }
                else if ((this.pageData[line, col] == this.blCornerChar) || (this.pageData[line, col] == this.tlCornerChar))
                {
                    this.printString(this.vrLineChar, line, col, t);
                }
                else if ((this.pageData[line, col] == this.brCornerChar) || (this.pageData[line, col] == this.trCornerChar))
                {
                    this.printString(this.vlLineChar, line, col, t);
                }
                else
                {
                    this.printString(this.vLineChar, line, col, t);
                }
            }
        }

        public void startJob(PrinterPort p, JobProperties prop)
        {
            this.page = 1;
            if (charSetManager == null)
            {
                charSetManager = CharSetManager.getInstance();
            }
            this.jobSetup = prop;
            this.resetPageData();
            this.port = p;
            this.port.open();
            this.currentProp = this.getDefaultTextProperties();
            this.processCommandsForJob();
        }

        protected bool supportsCommand(string scmd)
        {
            Command command = this.getCommand(scmd);
            if (command == null)
            {
                return false;
            }
            if (command.getCommand().Length == 0)
            {
                return false;
            }
            return true;
        }

        protected void writeCharToBuffer(char c, TextProperties newProp)
        {
            if (newProp == null)
            {
                newProp = this.currentProp.getClone();
            }
            else
            {
                newProp = newProp.getClone();
            }
            this.setJobDefaults(newProp);
            byte[] b = null;
            try
            {
                b = this.charMapping(c, newProp);
            }
            catch (Exception exception)
            {
                throw new TextPrinterException(exception.Message);
            }
            this.processCommandsForTextProperties(this.currentProp, newProp);
            string fontName = this.currentProp.fontName;
            string characterSet = this.currentProp.characterSet;
            this.currentProp = newProp;
            if (this.currentProp.fontName.Length == 0)
            {
                this.currentProp.fontName = fontName;
            }
            if (this.currentProp.characterSet.Length == 0)
            {
                this.currentProp.characterSet = characterSet;
            }
            this.addToBuffer(b);
        }
    }
}

