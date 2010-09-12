using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;
using System.Collections.Generic;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("response")]
    public class ListsListResponse : BackpackResponse, IBackpackObject
    {
        [XmlArray("lists")]
        public List<List> Lists { get; set; }
    }
}
