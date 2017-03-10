using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace CDS.Server.Installer
{
    public class CompleteDistributionConfig : ConfigurationSection
    {
        /// <summary>
        /// Returns the collection of registered companies from the config file.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        [ConfigurationProperty("RegisteredCompanies")]
        public RegisteredCompanyCollection RegisteredCompanies
        {
            get { return this["RegisteredCompanies"] as RegisteredCompanyCollection; }
        }

        /// <summary>
        /// Indicates whether or not the configuration section may be modified.
        /// </summary>
        /// <returns>false</returns>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public override bool IsReadOnly()
        {
            return false;
        }
    }
}