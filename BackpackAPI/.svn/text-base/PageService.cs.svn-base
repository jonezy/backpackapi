using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    public class PageService : BackpackBase, IPageService
    {
        public PageService(string username, string token) 
            : base (username, token)
        {

        }

        #region IPageService Members

        public System.Xml.XmlDocument Show(string pageId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}", pageId));
        }

        public System.Xml.XmlDocument List()
        {
            return bpDispatcher.ExecuteRequest("ws/pages/all");
        }

        public System.Xml.XmlDocument Search(string searchTerms)
        {
            return bpDispatcher.ExecuteRequest("ws/pages/search", "POST", null);
        }

        public System.Xml.XmlDocument Create(string pageTitle)
        {
            return bpDispatcher.ExecuteRequest("ws/pages/new", CreatePageRequestElement(pageTitle));
        }

        public XmlDocument Destroy(string pageId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/destroy", pageId));
        }
        
        public XmlDocument UpdateTitle(string pageId, string pageTitle)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/update_title", pageId), "POST", CreatePageRequestElement(pageTitle));
        }

        public XmlDocument Email(string pageId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/email", pageId));
        }
        #endregion


        private XmlNode CreatePageRequestElement(string pageTitle)
        {
            XmlDocument requestXml = new XmlDocument();
            XmlElement pageEl = requestXml.CreateElement("page");
            XmlElement titleEl = requestXml.CreateElement("title");

            titleEl.InnerText = pageTitle;

            pageEl.AppendChild(titleEl);
            requestXml.AppendChild(pageEl);

            return requestXml.SelectSingleNode("/*"); // root
        }

        private XmlNode CreatePageSearchRequestElement(string searchTerms)
        {
            XmlDocument requestXml = new XmlDocument();
            XmlElement termEl = requestXml.CreateElement("term");

            termEl.InnerText = searchTerms;

            requestXml.AppendChild(termEl);

            return requestXml.SelectSingleNode("/*"); // root
        }
    }
}
