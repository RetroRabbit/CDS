using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Essential.UTL
{
    public class DragObject
    {
        private string[] taskNames = new string[] { "Category" };
        private int index;
        public DragObject(int index)
        {
            this.index = index;
        }
        public object DragData { get { return new object[] { taskNames[index], DateTime.Now, 0 }; } }
        public int ImageIndex { get { return index; } }
    }
}
