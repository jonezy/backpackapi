using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;
using System.Collections.Generic;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("response")]
    public class ListItemsListResponse : BackpackResponse, IBackpackObject
    {
        [XmlArray("items")]
        public List<ListItem> ListItems { get; set; }
    }
}
