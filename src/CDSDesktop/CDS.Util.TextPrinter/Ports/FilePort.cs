namespace CDS.Util.TextPrinter.Ports
{
    using CDS.Util.TextPrinter;
    using CDS.Util.TextPrinter.Exceptions;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;

    public class FilePort : PrinterPort
    {
        private bool closed = true;
        private byte[] dataToWrite = null;
        private int dataToWriteLen = 0;
        private FileStream os = null;
        private string sFilename = "";
        private string writeError = null;

        public FilePort(string filename)
        {
            this.sFilename = filename;
        }

        public override void close()
        {
            try
            {
                this.closed = true;
                this.os.Close();
            }
            catch (Exception exception)
            {
                TextPrinterException exception2 = new TextPrinterException(exception.Message);
                throw exception2;
            }
        }

        public override void open()
        {
            try
            {
                this.os = new FileStream(this.sFilename, FileMode.OpenOrCreate);
                this.closed = false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                CouldNotOpenPrinterException exception2 = new CouldNotOpenPrinterException(exception.Message);
                throw exception2;
            }
        }

        public void run()
        {
            try
            {
                this.writeError = null;
                this.os.Write(this.dataToWrite, 0, this.dataToWriteLen);
            }
            catch (Exception exception)
            {
                this.writeError = exception.Message;
            }
        }

        public void write(string s)
        {
            this.write(Encoding.GetEncoding("UTF-16LE").GetBytes(s));
        }

        public override void write(byte[] s, int len)
        {
            TextPrinterException exception;
            try
            {
                this.dataToWrite = s;
                this.dataToWriteLen = len;
                this.writeError = null;
                Thread thread = new Thread(new ThreadStart(this.run));
                thread.Start();
                thread.Join(base.timeout);
                if (thread.IsAlive)
                {
                    thread.Interrupt();
                    exception = new TextPrinterException("Could not write to printer file. Timeout.");
                    throw exception;
                }
                if (this.writeError != null)
                {
                    exception = new TextPrinterException("Could not write to printer file. " + this.writeError);
                    throw exception;
                }
            }
            catch (Exception exception2)
            {
                exception = new TextPrinterException(exception2.Message);
                throw exception;
            }
        }
    }
}

