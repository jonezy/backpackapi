using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    
    [XmlRoot("note")]
    public class Note : IBackpackObject
    {
        [XmlText]
        public string NoteBody { get; set; }

        [XmlAttribute("id")] 
        public string Id { get; set; }
        
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("created_at")]
        public string CreatedAt { get; set; }
    }
}
