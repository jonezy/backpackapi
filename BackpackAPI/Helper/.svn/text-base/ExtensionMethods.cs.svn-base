using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace jonezy.org.BackpackAPI
{
    public static class ExtensionMethods
    {
        // converts the given type to xml
        public static XmlDocument ToXml(this IBackpackObject o)
        {
            StringBuilder stringBuilder = new StringBuilder();
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
            StringWriter stringWriter = new StringWriter(stringBuilder);

            xmlSerializer.Serialize(stringWriter, o);
            xmlDocument.LoadXml(stringBuilder.ToString());

            foreach(XmlNode node in xmlDocument.SelectNodes("*"))
            {
                if (node.Attributes["xmlns:xsd"] != null && node.Attributes["xmlns:xsi"] != null)
                {
                    node.Attributes.Remove(node.Attributes["xmlns:xsd"]);
                    node.Attributes.Remove(node.Attributes["xmlns:xsi"]);
                }
            }

            return xmlDocument;
        }

        // converts the given xml document to an object of the given type.
        public static IBackpackObject ToBackpackObject(this XmlDocument xmlDocument, System.Type objType)
        {
            XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument.DocumentElement);
            XmlSerializer xmlSerializer = new XmlSerializer(objType);

            return (IBackpackObject)xmlSerializer.Deserialize(xmlNodeReader);
        }
    }
}
