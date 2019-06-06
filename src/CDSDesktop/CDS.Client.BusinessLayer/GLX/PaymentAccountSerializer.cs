using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CDS.Client.BusinessLayer.GLX
{
    public class PaymentAccountSerializer
    {


        /// <summary>
        /// Serialize PaymentAccounts to XML
        /// </summary>
        /// <param name="AnObject"></param>
        /// <returns>XML string</returns>
        public static string SerializePaymentAccounts(object AnObject)
        {
            XmlSerializer Xml_Serializer = new XmlSerializer(AnObject.GetType());
            StringWriter Writer = new StringWriter();
            Xml_Serializer.Serialize(Writer, AnObject);
            return Writer.ToString();
        }

        /// <summary>
        /// Deserialize XML string to a PaymentAccounts object
        /// </summary>
        /// <param name="XmlOfAnObject"></param>
        /// <param name="ObjectType"></param>
        /// <returns></returns>
        public static List<PaymentAccount> DeSerializePaymentAccounts(string XmlOfAnObject, Type ObjectType)
        {
            if (!String.IsNullOrEmpty(XmlOfAnObject))
            {
                StringReader StrReader = new StringReader(XmlOfAnObject);
                XmlSerializer Xml_Serializer = new XmlSerializer(ObjectType);
                XmlTextReader XmlReader = new XmlTextReader(StrReader);

                try
                {
                    Object AnObject = Xml_Serializer.Deserialize(XmlReader);
                    return AnObject as List<PaymentAccount>;
                }

                finally
                {
                    XmlReader.Close();
                    StrReader.Close();
                }
            }
            else
                return new List<PaymentAccount>();
        }
    }
}
