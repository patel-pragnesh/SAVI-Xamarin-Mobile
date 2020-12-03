using System;

namespace SAVI.Models
{
    [Serializable()]
    public class GetRegistrationReply
    {
        [System.Xml.Serialization.XmlElement("GetRegistrationResult")]
        public Registration GetRegistrationResult { get; set; }


    }
}
