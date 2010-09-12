using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("item")]
    public class ListItem : IBackpackObject
    {
        [XmlText]
        public string ItemText { get; set; }

        [XmlAttribute("id")] 
        public string Id { get; set; }
        
        [XmlAttribute("list_id")]
        public string ListId { get; set; }

        [XmlAttribute("completed")]
        public string Completed { get; set; }
    }
}
