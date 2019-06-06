using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.Portable
{
    public class DocumentHeader
    {
        public string id { get; set; }
        public string message{ get; set; }
        public string discount{ get; set; }
        public string documentNumber{ get; set; }
        public List<DocumentLines> documentLines { get; set; }
        public decimal total { get; set; }
        public decimal totalVat { get; set; }
        public byte documentType { get; set; }
    }
}
