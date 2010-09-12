using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface ISeparatorService
    {
        XmlDocument Create(string pageId, string separatorName);
        XmlDocument Update(string pageId, string separatorName, string separatorId);
        XmlDocument Destroy(string pageId, string separatorId);
    }
}
