using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml.Serialization;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("response")]
    public class ListItemsCreateResponse : BackpackResponse, IBackpackObject
    {
        [XmlElement("item")]
        public ListItem CreatedListItem { get; set; }

    }
}
    