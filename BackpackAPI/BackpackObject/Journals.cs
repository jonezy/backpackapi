using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;
using System.Collections.Generic;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("journal-entries")]
    public class Journals : IBackpackObject
    {
        [XmlAttribute("type")]
        public string AccountType { get; set; }

        [XmlArray("journal-entry")]
        public List<Journal> JournalEntries { get; set; }

    }
}
