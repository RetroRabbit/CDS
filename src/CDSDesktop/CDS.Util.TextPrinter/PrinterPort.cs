namespace CDS.Util.TextPrinter
{
    using CDS.Util.TextPrinter.Util;
    using System;

    public abstract class PrinterPort
    {
        protected string documentName = "CDS DOCUMENT";
        protected int timeout = 0x7d0;

        protected PrinterPort()
        {
        }

        public void SetDocumentName(string Name)
        {
            documentName = Name;
        }

        public virtual void close()
        {
        }

        public int getTimeout()
        {
            return this.timeout;
        }

        public RBoolean isBusy()
        {
            return null;
        }

        public RBoolean isInError()
        {
            return null;
        }

        public RBoolean isOnline()
        {
            return null;
        }

        public RBoolean isPaperOut()
        {
            return null;
        }

        public virtual void open()
        {
        }

        public void setTimeout(int i)
        {
            this.timeout = i;
        }

        public virtual void write(string s)
        {
        }

        public virtual void write(byte[] s)
        {
            this.write(s, s.GetLength(0));
        }

        public virtual void write(byte[] s, int len)
        {
        }
    }
}

