using System;

namespace SAVI.Models
{
    [Serializable()]
    public class GetProductResponseDataBundles
    {
        [System.Xml.Serialization.XmlElement("SmsOrBundlePackage")]
        public string SmsOrBundlePackage { get; set; }

        [System.Xml.Serialization.XmlElement("ProductName")]
        public string ProductName { get; set; }

        [System.Xml.Serialization.XmlElement("TSSProductBundleShortCode")]
        public string TSSProductBundleShortCode { get; set; }

        [System.Xml.Serialization.XmlElement("TSSProductBundleName")]
        public string TSSProductBundleName { get; set; }

        [System.Xml.Serialization.XmlElement("TSSProductBundleValue")]
        public string TSSProductBundleValue { get; set; }

        [System.Xml.Serialization.XmlElement("TSSProductBundleMegs")]
        public string TSSProductBundleMegs { get; set; }

      
    }
}
