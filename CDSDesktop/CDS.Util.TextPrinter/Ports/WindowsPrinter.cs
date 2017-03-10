namespace CDS.Util.TextPrinter.Ports
{
    using CDS.Util.TextPrinter;
    using System;
    using System.Text;

    public class WindowsPrinter : PrinterPort
    {
        private int bytesLen = 0;
        private byte[] mbytes = new byte[0x186a0];
        protected string printerName = "";

        public WindowsPrinter(string printer)
        {
            this.printerName = printer;
        }

        public override void close()
        {
            RawPrinterHelper.SendBytesToPrinter2(this.printerName, this.mbytes, this.bytesLen, this.documentName);
        }

        public override void open()
        {
        }

        public override void write(string s)
        {
            this.write(Encoding.GetEncoding("UTF-16LE").GetBytes(s));
        }

        public override void write(byte[] b, int len)
        {
            int num;
            if ((this.bytesLen + len) >= this.mbytes.GetLength(0))
            {
                byte[] buffer = new byte[this.mbytes.GetLength(0) + 0x186a0];
                for (num = 0; num < this.bytesLen; num++)
                {
                    buffer[num] = this.mbytes[num];
                }
                this.mbytes = buffer;
            }
            for (num = 0; num < len; num++)
            {
                this.mbytes[this.bytesLen++] = b[num];
            }
        }
    }
}

