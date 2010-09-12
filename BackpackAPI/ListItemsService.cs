using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml;

namespace jonezy.org.BackpackAPI
{
    public class ListItemsService : BackpackBase, IListItemsService
    {
        public ListItemsService(string username, string token)
            : base(username, token)
        {
            
        }

        public XmlDocument List(string pageId, string listId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/{1}/items/list", pageId, listId));
        }

        public XmlDocument Create(string pageId, string listId, string listItemContent)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/{1}/items/add", pageId, listId), "POST", CreateListItemRequestElement(listItemContent));
        }

        public XmlDocument Update(string pageId, string listId, string listItemId, string updatedListItemContent)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/{1}/items/update/{2}", pageId, listId, listItemId), "POST", UpdateListItemRequestElement(updatedListItemContent));
        }

        public XmlDocument Toggle(string pageId, string listId, string listItemId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/{1}/items/toggle/{2}", pageId, listId, listItemId));
        }

        public XmlDocument Destroy(string pageId, string listId, string listItemId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/{1}/items/destroy/{2}", pageId, listId, listItemId));
        }

        public XmlDocument Move(string pageId, string listId, string listItemId, string moveDirection)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/lists/{1}/items/move/{2}", pageId, listId, listItemId), "POST", MoveListItemRequestElement(moveDirection));
        }

        private XmlNode CreateListItemRequestElement(string listItemContent)
        {
            XmlDocument listItemXml = new XmlDocument();
            ListItemCreateRequest listItemCreateRequest = new ListItemCreateRequest();
            listItemCreateRequest.Content = listItemContent;

            listItemXml = listItemCreateRequest.ToXml();

            return listItemXml.SelectSingleNode("/*"); // root
        }

        private XmlNode UpdateListItemRequestElement(string listItemContent)
        {
            XmlDocument listItemXml = new XmlDocument();
            ListItemCreateRequest listItemUpdateRequest = new ListItemCreateRequest();
            listItemUpdateRequest.Content = listItemContent;

            listItemXml = listItemUpdateRequest.ToXml();

            return listItemXml.SelectSingleNode("/*"); // root
        }

        private XmlNode MoveListItemRequestElement(string moveDirection)
        {
            XmlDocument listItemXml = new XmlDocument();
            ListItemMoveRequest listItemMoveRequest = new ListItemMoveRequest();
            listItemMoveRequest.Direction = moveDirection;

            listItemXml = listItemMoveRequest.ToXml();

            return listItemXml.SelectSingleNode("/*"); // root
        }
    }
}
