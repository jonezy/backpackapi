using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml;

namespace jonezy.org.BackpackAPI
{
    public class SeparatorService : BackpackBase, ISeparatorService
    {
        public SeparatorService(string username, string token) : base (username, token)
        {
        }

        #region ISeparatorService Members

        public System.Xml.XmlDocument Create(string pageId, string separatorName)
        {
            return bpDispatcher.ExecuteRequest(String.Format("pages/{0}/separators.xml?token={1}", pageId, this._token), "POST", CreateSeparatorEntry(separatorName));
        }

        public System.Xml.XmlDocument Update(string pageId, string separatorName, string separatorId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("pages/{0}/separators/{1}.xml?token={2}", pageId, separatorId, this._token), "PUT", CreateSeparatorEntry(separatorName));
        }

        public System.Xml.XmlDocument Destroy(string pageId, string separatorId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("pages/{0}/separators/{1}.xml?token={2}", pageId, separatorId, this._token), "DELETE", null);
        }

        #endregion

        private XmlNode CreateSeparatorEntry(string separatorName)
        {
            XmlDocument requestXml = new XmlDocument();
            XmlElement requestEl = requestXml.CreateElement("request");
            XmlElement tokenEl = requestXml.CreateElement("token");
            XmlElement separatorEl = requestXml.CreateElement("separator");
            XmlElement nameEl = requestXml.CreateElement("name");

            tokenEl.InnerText = this._token;
            nameEl.InnerText = separatorName;

            requestEl.AppendChild(tokenEl);
            separatorEl.AppendChild(nameEl);
            requestEl.AppendChild(separatorEl);
            requestXml.AppendChild(requestEl);

            return requestXml.SelectSingleNode("/*"); // root
        }
    }
}
