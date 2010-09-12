using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;
using System.Collections.Generic;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("journal-entry")]
    public class Journal : IBackpackObject
    {
        [XmlElement("body")]
        public string Body { get; set; }

        [XmlElement("account")]
        public string AccountId { get; set; }
        
        [XmlAttribute("type",Namespace="account")]
        public string AccountType { get; set; }

        [XmlElement("created-at")]
        public string CreatedAt { get; set; }
        
        [XmlAttribute("type",Namespace="created-at")]
        public string CreatedType { get; set; }

        [XmlElement("id",Namespace="id")]
        public string Id { get; set; }

        [XmlAttribute("type")]
        public string IdType { get; set; }

        [XmlElement("updated-at")]
        public string UpdatedAt { get; set; }

        [XmlAttribute("type", Namespace="updated-at")]
        public string UpdatedAtType { get; set; }

        [XmlElement("user")]
        public User User { get; set; }
    }
}
