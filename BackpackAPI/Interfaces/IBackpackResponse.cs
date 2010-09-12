using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface IBackpackResponse
    {
        string ResponseCode { get; set; }
        string ResponseLocation { get; set; }
        XmlDocument ResponseBody { get; set; }
    }
}
