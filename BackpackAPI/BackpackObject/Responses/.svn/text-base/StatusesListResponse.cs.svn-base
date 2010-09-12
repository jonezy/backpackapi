using System.Xml.Serialization;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    [XmlRoot("response")]
    public class StatusesListResponse : BackpackResponse, IBackpackObject
    {
        [XmlArray("statuses")]
        public Statuses ListOfStatuses { get; set; }
    }
}
