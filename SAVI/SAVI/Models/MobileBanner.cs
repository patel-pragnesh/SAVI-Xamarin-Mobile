using System;

namespace SAVI.Models
{
    [Serializable()]
    public class MobileBanner
    {
        [System.Xml.Serialization.XmlElement("ID")]
        public string ID { get; set; }

        [System.Xml.Serialization.XmlElement("Image")]
        public string Image { get; set; }

        [System.Xml.Serialization.XmlElement("Order")]
        public string Order { get; set; }

        [System.Xml.Serialization.XmlElement("URL")]
        public string URL { get; set; }




    }
}
