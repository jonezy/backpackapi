using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface INotesService
    {
        XmlDocument List(string pageId);
        XmlDocument Create(string pageId, string noteTitle, string noteBody);
        XmlDocument Update(string pageId, string noteId, string noteTitle, string noteBody);
        XmlDocument Destroy(string pageId, string noteId);
    }
}
