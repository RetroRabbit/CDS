using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CDS.Client.BusinessLayer.Configuration
{
    /// <summary>
    /// NOTE: AddItemName parameter set to allow a custom name for the leaf
    /// element name. By default this is "add", setting AddItemName allows
    /// you to change the name to "prettify" the xml
    /// </summary>
    /// <remarks>Created: Theo Crous 14/11/2011</remarks>
    [ConfigurationCollection(typeof(RegisteredCompany), AddItemName = "RegisteredCompany")]
    public class RegisteredCompanyCollection : ConfigurationElementCollection
    {
        public override bool IsReadOnly() { return false; }

        /// <summary>
        /// When overridden in a derived class, creates a new
        /// <see cref="T:System.Configuration.ConfigurationElement"></see>.
        /// </summary>
        ///
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"></see>.
        /// </returns>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override ConfigurationElement CreateNewElement()
        {
            return new RegisteredCompany();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        ///
        /// <returns>
        /// An <see cref="T:System.Object"></see> that acts as the key for the specified
        /// <see cref="T:System.Configuration.ConfigurationElement"></see>.
        /// </returns>
        ///
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement">
        /// </see> to return the key for. </param>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RegisteredCompany)element).Name;
        }

        /// <summary>
        /// This is a custom indexer to allow retrieval of a setting
        /// at a specfic index in the collection - a useful addition!
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <remarks>No index range checking is performed...</remarks>
        /// <remarks>Created: Theo Crous 14/11/2011</remarks>
        public RegisteredCompany this[int index]
        {
            get
            {
                return this.BaseGet(index) as RegisteredCompany;
            }
            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new RegisteredCompany this[string name]
        {
            get
            {
                return this.BaseGet(name) as RegisteredCompany;
            }
            set
            {
                int index = -1;
                if (this.BaseGet(name) != null)
                {
                    index = this.BaseIndexOf(this.BaseGet(name));
                    this.BaseRemove(name);
                }

                if (index == -1)
                {
                    this.BaseAdd(value);
                }
                else
                {
                    this.BaseAdd(index, value);
                }
            }
        }

        public RegisteredCompany NewCompany(String Name, String ConnectionString, String ConnectionTimeout, bool? updateSite)//, String entitytableconnectionstring, String entityviewconnectionstring)
        {
            RegisteredCompany company = (RegisteredCompany)this.CreateNewElement();
            company.Name = Name;
            company.ConnectionString = ConnectionString;
            company.ConnectionTimeout = ConnectionTimeout;
            company.UpdateSite = updateSite;
            this.BaseAdd(company);
            return company;
        }

        public void RemoveCompany(String Name)
        {
            this.BaseRemove(Name);
        }

        public void Clear()
        {
            this.BaseClear();
        }
    }

}
