using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface IListItemsService
    {
        XmlDocument List(string pageId, string listId);
        XmlDocument Create(string pageId, string listId, string listItemContent);
        XmlDocument Update(string pageId, string listId, string listItemId, string updatedListItemContent);
        XmlDocument Toggle(string pageId, string listId, string listItemId);
        XmlDocument Destroy(string pageId, string listId, string listItemId);
        XmlDocument Move(string pageId, string listId, string listItemId, string moveDirection);
    }
}
