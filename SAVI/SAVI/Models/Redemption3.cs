using System;

namespace SAVI.Models
{
    [Serializable()]
    public class Redemption3
    {
        [System.Xml.Serialization.XmlElement("RedemptionID")]
        public string RedemptionID { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionName")]
        public string PromotionName { get; set; }

        [System.Xml.Serialization.XmlElement("ProductCode")]
        public string ProductCode { get; set; }

        [System.Xml.Serialization.XmlElement("ProductDescription")]
        public string ProductDescription { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionProductID")]
        public string PromotionProductID { get; set; }

        [System.Xml.Serialization.XmlElement("RedemtionDate")]
        public string RedemtionDate { get; set; }

        [System.Xml.Serialization.XmlElement("InvoiceNumber")]
        public string InvoiceNumber { get; set; }

        [System.Xml.Serialization.XmlElement("BrandName")]
        public string BrandName { get; set; }

        [System.Xml.Serialization.XmlElement("StoreID")]
        public string StoreID { get; set; }

        [System.Xml.Serialization.XmlElement("BrandID")]
        public string BrandID { get; set; }

        [System.Xml.Serialization.XmlElement("InvoiceID")]
        public string InvoiceID { get; set; }

        [System.Xml.Serialization.XmlElement("StoreName")]
        public string StoreName { get; set; }

        [System.Xml.Serialization.XmlElement("StoreRep")]
        public string StoreRep { get; set; }

        [System.Xml.Serialization.XmlElement("StoreRepMSISDN")]
        public string StoreRepMSISDN { get; set; }

        [System.Xml.Serialization.XmlElement("Imei")]
        public string Imei { get; set; }

        [System.Xml.Serialization.XmlElement("SubmittedDeviceLocationLatitude")]
        public string SubmittedDeviceLocationLatitude { get; set; }

        [System.Xml.Serialization.XmlElement("SubmittedDeviceLocationLongitude")]
        public string SubmittedDeviceLocationLongitude { get; set; }

        [System.Xml.Serialization.XmlElement("RetailValue")]
        public string RetailValue { get; set; }

        [System.Xml.Serialization.XmlElement("Verified")]
        public string Verified { get; set; }

        [System.Xml.Serialization.XmlElement("CompanyID")]
        public string CompanyID { get; set; }

        [System.Xml.Serialization.XmlElement("HasImage")]
        public string HasImage { get; set; }

        [System.Xml.Serialization.XmlElement("Disputed")]
        public string Disputed { get; set; }

        [System.Xml.Serialization.XmlElement("Paid")]
        public string Paid { get; set; }

        [System.Xml.Serialization.XmlElement("DisputesID")]
        public string DisputesID { get; set; }

        [System.Xml.Serialization.XmlElement("ImeiID")]
        public string ImeiID { get; set; }

        [System.Xml.Serialization.XmlElement("WindowsUser")]
        public string WindowsUser { get; set; }

        [System.Xml.Serialization.XmlElement("VerifiedDisputedDate")]
        public string VerifiedDisputedDate { get; set; }

        [System.Xml.Serialization.XmlElement("AutoProcessed")]
        public string AutoProcessed { get; set; }

        [System.Xml.Serialization.XmlElement("DetectCount")]
        public string DetectCount { get; set; }

        [System.Xml.Serialization.XmlElement("ContactName")]
        public string ContactName { get; set; }

        [System.Xml.Serialization.XmlElement("ContactSurname")]
        public string ContactSurname { get; set; }

        [System.Xml.Serialization.XmlElement("ContactMSISDN")]
        public string ContactMSISDN { get; set; }

        [System.Xml.Serialization.XmlElement("ContactEmail")]
        public string ContactEmail { get; set; }

        [System.Xml.Serialization.XmlElement("NoStock")]
        public string NoStock { get; set; }

        [System.Xml.Serialization.XmlElement("Pin")]
        public string Pin { get; set; }

        [System.Xml.Serialization.XmlElement("InvoiceDateCreated")]
        public string InvoiceDateCreated { get; set; }

        [System.Xml.Serialization.XmlElement("InvoiceDateModified")]
        public string InvoiceDateModified { get; set; }

    }
}
