using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface IUserService
    {
        XmlDocument List();
        XmlDocument Show(string userId);
    }
}
