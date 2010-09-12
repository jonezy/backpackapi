using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;
using System.Collections.Generic;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("status")]
    public class Status : IBackpackObject
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlAttribute("type", Namespace = "id")]
        public string AccountType { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("updated-at")]
        public string UpdatedAt { get; set; }
        
        [XmlAttribute("type",Namespace="updated-at")]
        public string UpdatedAtType { get; set; }

        [XmlElement("user-id")]
        public string UserId { get; set; }

        [XmlAttribute("type", Namespace="user-id")]
        public string IdType { get; set; }

        [XmlElement("user")]
        public User User { get; set; }
    }
}
