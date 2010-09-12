using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml.Serialization;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("response")]
    public class BackpackResponse : IBackpackObject
    {
        [XmlElement("response")]
        public string Response { get; set; }

        [XmlAttribute("success")]
        public string Success { get; set; }

    }
}
    