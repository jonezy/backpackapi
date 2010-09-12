using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml;

namespace jonezy.org.BackpackAPI
{
    public class ListsService : BackpackBase, IListsService
    {
        public ListsService(string username, string token)
            : base(username, token)
        {
            
        }

        public XmlDocument List(string pageId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/list", pageId));
        }

        public XmlDocument Create(string pageId, string listName)
        {
            // have to filter the create list request element a bit here as a slightly different xml struct is expected.
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/add", pageId), "POST", CreateListRequestElement(listName).SelectSingleNode("/list/*"));
        }

        public XmlDocument Update(string pageId, string listId, string newListName)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/update/{1}", pageId, listId), "POST", CreateListRequestElement(newListName));
        }


        public XmlDocument Destroy(string pageId, string listId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/destroy/{1}", pageId, listId));
        }


        private XmlNode CreateListRequestElement(string listName)
        {
            XmlDocument listXml = new XmlDocument();
            ListRequest listRequest = new ListRequest();
            listRequest.Name = listName;

            listXml = listRequest.ToXml();

            return listXml.SelectSingleNode("/*"); // root
        }
    }
}
