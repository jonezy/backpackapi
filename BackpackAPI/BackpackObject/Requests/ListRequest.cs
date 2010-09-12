using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("list")]
    public class ListRequest : IBackpackObject
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
