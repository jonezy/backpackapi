using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("user")]
    public class User : IBackpackObject
    {
        [XmlElement("id")] 
        public string Id { get; set; }
        
        [XmlAttribute("type")]
        public string IdType { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}
