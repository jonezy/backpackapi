using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;
using System.Collections.Generic;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("lists")]
    public class Lists : IBackpackObject
    {
        [XmlElement]
        public List<List> List { get; set; }
    }
}
