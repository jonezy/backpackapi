using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("item")]
    public class ListItemCreateRequest : IBackpackObject
    {
        [XmlElement("item")]
        public string Item { get; set; }

        [XmlElement("content")]
        public string Content { get; set; }
    }
}
