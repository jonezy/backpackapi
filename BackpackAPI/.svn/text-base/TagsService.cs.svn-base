using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml;

namespace jonezy.org.BackpackAPI
{
    public class TagsService : BackpackBase, ITagsService
    {

        public TagsService(string username, string token) : base (username, token)
        {
            
        }

        #region ITagsService Members

        public System.Xml.XmlDocument MatchPage(string tagId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/tags/select/{0}", tagId));
        }

        public System.Xml.XmlDocument TagPage(string pageId, string tags)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/tags/tag", pageId), "POST", CreateTagEntry(tags));
        }

        #endregion

        private XmlNode CreateTagEntry(string tags)
        {
            XmlDocument requestXml = new XmlDocument();
            XmlElement tagsEl = requestXml.CreateElement("tags");

            tagsEl.InnerText = tags;

            requestXml.AppendChild(tagsEl);

            return requestXml.SelectSingleNode("/*"); // root
        }
    }
}
