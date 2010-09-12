using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("response")]
    public class NoteResponse : BackpackResponse, IBackpackObject
    {
        [XmlElement("note")]
        public Note CreatedNote { get; set; }
    }
}
