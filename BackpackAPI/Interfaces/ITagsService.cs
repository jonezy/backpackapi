using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface ITagsService
    {
        XmlDocument MatchPage(string tagId);
        XmlDocument TagPage(string pageId, string tags);
    }
}
