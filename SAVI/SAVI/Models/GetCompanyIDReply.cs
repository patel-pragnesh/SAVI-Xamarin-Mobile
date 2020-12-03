using System;

namespace SAVI.Models
{
    [Serializable()]
    public class GetCompanyIDReply
    {
        [System.Xml.Serialization.XmlElement("GetCompnyIDResult")]
        public string GetCompnyIDResult { get; set; }
    }
}
