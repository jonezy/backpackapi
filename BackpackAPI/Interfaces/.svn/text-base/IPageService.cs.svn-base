using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface IPageService
    {
        XmlDocument List();
        XmlDocument Search(string searchTerm);
        XmlDocument Show(string pageId);
        XmlDocument Create(string pageTitle);
        XmlDocument Destroy(string pageId);
        XmlDocument UpdateTitle(string pageId, string pageTitle);
        XmlDocument Email(string pageId);
    }
}
