using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Server.Installer.SQL
{
    public class SQLWorkItem
    {
        public string Description { get; set; }
        public String Command { get; set; }
        public Int64 Rows { get; set; }
        public Image Image { get; set; }
    }
}
