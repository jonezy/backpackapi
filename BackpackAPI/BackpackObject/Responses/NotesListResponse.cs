using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("response")]
    public class NotesListResponse : BackpackResponse, IBackpackObject
    {
        [XmlArray("notes")]
        public Notes[] CreatedNotes { get; set; }
    }
}
