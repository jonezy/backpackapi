using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;
using System.Collections.Generic;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("statuses")]
    public class Statuses : IBackpackObject
    {
        [XmlAttribute("type")]
        public string StatusType { get; set; }

        [XmlArray("status")]
        public List<Status> StatusEntries { get; set; }

    }
}
