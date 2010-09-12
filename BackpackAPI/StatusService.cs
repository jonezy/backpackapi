using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    public class StatusService: BackpackBase, IStatusService
    {
        public StatusService(string username, string token) : base (username, token)
        {
        }

        #region IStatusService Members

        public System.Xml.XmlDocument List()
        {   
            return bpDispatcher.ExecuteRequest(String.Format("statuses.xml?token={0}", this._token), "GET", null);
        }

        public System.Xml.XmlDocument Show(string userId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("users/{0}/status.xml?token={1}", userId, this._token), "GET", null);
        }

        public System.Xml.XmlDocument Update(string userId, string status)
        {
            return bpDispatcher.ExecuteRequest(String.Format("users/{0}/status.xml?token={1}", userId, this._token), "PUT", CreateStatusEntry(status).SelectSingleNode("/status/message/*"));
        }

        #endregion

        private XmlNode CreateStatusEntry(string status)
        {
            XmlDocument statusXml = new XmlDocument();
            Status statusEntry = new Status();
            statusEntry.Message = status;

            statusXml = statusEntry.ToXml();

            return statusXml.SelectSingleNode("/*");
            //XmlDocument requestXml = new XmlDocument();
            //XmlElement statusEl = requestXml.CreateElement("status");
            //XmlElement messageEl = requestXml.CreateElement("message");

            //messageEl.InnerText = status;

            //statusEl.AppendChild(messageEl);
            //requestXml.AppendChild(statusEl);

            //return requestXml.SelectSingleNode("/*"); // root
        }

    }
}
