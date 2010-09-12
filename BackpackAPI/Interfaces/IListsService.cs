using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface IListsService
    {
        XmlDocument List(string pageId);
        XmlDocument Create(string pageId, string listName);
        XmlDocument Update(string pageId, string listId, string newListName);
        XmlDocument Destroy(string pageId, string listId);
    }
}
