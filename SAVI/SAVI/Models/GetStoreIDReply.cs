using System;

namespace SAVI.Models
{
    [Serializable()]
    public class GetStoreIDReply
    {
        [System.Xml.Serialization.XmlElement("GetStoreIDResult")]
        public string GetStoreIDResult { get; set; }
    }
}
