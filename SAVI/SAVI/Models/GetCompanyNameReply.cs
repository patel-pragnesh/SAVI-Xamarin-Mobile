using System;

namespace SAVI.Models
{
    [Serializable()]
    public class GetCompanyNameReply
    {
        [System.Xml.Serialization.XmlElement("GetCompnyNameResult")]
        public string GetCompnyNameResult { get; set; }
    }
}
