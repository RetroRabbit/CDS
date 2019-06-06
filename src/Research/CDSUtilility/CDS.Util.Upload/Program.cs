using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Util.Upload
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <notes>
        /// args[0] = Command
        /// args[1] = File (FullName)
        /// args[2] = URL
        /// args[3] = Username
        /// args[4] = Password
        /// </notes>
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "-up": Library.UploadFile(args[1], args[2], args[3], args[4]);
                    break;
            }
        }
    }
}
