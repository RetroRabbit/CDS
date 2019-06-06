﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CDS.Server.Installer
{
    public class RegisteredCompany : ConfigurationElement
    {
        /// <summary>
        /// Represents the name of the registered company, which will be displayed in the signin screen.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        //[StringValidator(InvalidCharacters = "@#$%^&*'\"|", MinLength = 1, MaxLength = 100)]
        public string Name
        {
            set
            {
                this["name"] = value;
            }
            get
            {
                return this["name"] as string;
            }
        }

        /// <summary>
        /// Represents the connection string used to connect to the registered company.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        [ConfigurationProperty("connectionstring", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/’\"|", MinLength = 1, MaxLength = 500)]
        public string ConnectionString
        {
            set
            {
                this["connectionstring"] = value;
            }
            get
            {
                return this["connectionstring"] as string;
            }
        } 

        /// <summary>
        /// Represents the connection timeout of the registered company. The default is set to 10000.
        /// </summary>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        [ConfigurationProperty("connectiontimeout", DefaultValue = "10000")]
        //[StringValidator(InvalidCharacters = "[a-zA-Z]  ~!@#$%^&*()[]{}/;’\"|", MinLength = 1, MaxLength = 500)]
        public string ConnectionTimeout
        {
            set
            {
                this["connectiontimeout"] = value;
            }
            get
            {
                return this["connectiontimeout"] as string;
            }
        }

        /// <summary>
        /// Represents the boolean used to idetify the registered company where the update should be downloaded from.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 15/07/2013</remarks>
        [ConfigurationProperty("updatesite", IsRequired = false)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/’\"|", MinLength = 1, MaxLength = 500)]
        public bool? UpdateSite
        {
            set
            {
                this["updatesite"] = value;
            }
            get
            {
                return this["updatesite"] as bool?;
            }
        }
    }
}
