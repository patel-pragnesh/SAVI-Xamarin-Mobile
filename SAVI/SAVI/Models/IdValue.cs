using System;

namespace SAVI.Models
{
    [Serializable()]
    public class IdValue
    {
        [System.Xml.Serialization.XmlElement("ID")]
        public string ID { get; set; }

        [System.Xml.Serialization.XmlElement("Value")]
        public string Value { get; set; }

        [System.Xml.Serialization.XmlElement("ID1")]
        public string ID1 { get; set; }

        [System.Xml.Serialization.XmlElement("ID2")]
        public string ID2 { get; set; }

        [System.Xml.Serialization.XmlElement("Amount")]
        public string Amount { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionID")]
        public string PromotionID { get; set; }

        [System.Xml.Serialization.XmlElement("TimeStamp")]
        public string TimeStamp { get; set; }

        [System.Xml.Serialization.XmlElement("Value1")]
        public string Value1 { get; set; }

        [System.Xml.Serialization.XmlElement("Type")]
        public string Type { get; set; }

        [System.Xml.Serialization.XmlElement("Used")]
        public string Used { get; set; }

        [System.Xml.Serialization.XmlElement("WindowsUser")]
        public string WindowsUser { get; set; }


    }
}
