namespace CDS.Util.TextPrinter.Util
{
    using System;
    using System.Collections;

    public class Vector : ArrayList
    {
        public void addElement(object o)
        {
            base.Add(o);
        }

        public void addElement(int position, object o)
        {
            base.Insert(position, o);
        }

        public object elementAt(int i)
        {
            return base[i];
        }

        public void removeAllElements()
        {
            base.Clear();
        }

        public void setElementAt(object o, int i)
        {
            base[i] = o;
        }

        public int size()
        {
            return base.Count;
        }
    }
}

