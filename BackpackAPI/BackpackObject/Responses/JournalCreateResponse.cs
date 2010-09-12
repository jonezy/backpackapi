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
    public class JournalCreateResponse : IBackpackObject
    {
        [XmlElement("status")]
        public string Status { get; set; }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("location")]
        public string Location { get; set; }


    }
}
    