using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.DataAccessLayer.Portable
{
    public class UserProfile
    {
        string fdisplayName;
        public string displayName
        {
            get { return fdisplayName; }
            set { fdisplayName = value; }
        }

        byte[] favatar;
        public byte[] avatar
        {
            get { return favatar; }
            set { favatar = value; }
        }

        bool fonline;
        public bool online
        {
            get { return fonline; }
            set { fonline = value; }
        }
    }
}
