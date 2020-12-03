using System;

namespace SAVI.Models
{
    [Serializable()]
    public class ValidateBarcodeReply
    {
        [System.Xml.Serialization.XmlElement("PromotionProductID")]
        public string PromotionProductID { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionID")]
        public string PromotionID { get; set; }

        [System.Xml.Serialization.XmlElement("DateAdded")]
        public string DateAdded { get; set; }

        [System.Xml.Serialization.XmlElement("ModifiedDate")]
        public string ModifiedDate { get; set; }

        [System.Xml.Serialization.XmlElement("ProductCode")]
        public string ProductCode { get; set; }

        [System.Xml.Serialization.XmlElement("Description")]
        public string Description { get; set; }

        [System.Xml.Serialization.XmlElement("RetailValue")]
        public string RetailValue { get; set; }

        [System.Xml.Serialization.XmlElement("Barcode")]
        public string Barcode { get; set; }

        [System.Xml.Serialization.XmlElement("Deleted")]
        public string Deleted { get; set; }

        [System.Xml.Serialization.XmlElement("ImeiID")]
        public string ImeiID { get; set; }

        [System.Xml.Serialization.XmlElement("VoucherID")]
        public string VoucherID { get; set; }

        [System.Xml.Serialization.XmlElement("RewardAmount")]
        public string RewardAmount { get; set; }

        [System.Xml.Serialization.XmlElement("Gift")]
        public string Gift { get; set; }

        [System.Xml.Serialization.XmlElement("GiftMaxLimit")]
        public string GiftMaxLimit { get; set; }

        [System.Xml.Serialization.XmlElement("RedemtionCount")]
        public string RedemtionCount { get; set; }

        [System.Xml.Serialization.XmlElement("NoStock")]
        public string NoStock { get; set; }

        [System.Xml.Serialization.XmlElement("GiftStoreValue")]
        public string GiftStoreValue { get; set; }

        [System.Xml.Serialization.XmlElement("GiftSupplyValue")]
        public string GiftSupplyValue { get; set; }

        [System.Xml.Serialization.XmlElement("base64String")]
        public string base64String { get; set; }

        [System.Xml.Serialization.XmlElement("RewardCode")]
        public string RewardCode { get; set; }

        [System.Xml.Serialization.XmlElement("PastelQuantity")]
        public string PastelQuantity { get; set; }

        [System.Xml.Serialization.XmlElement("RedeemPortalPrice")]
        public string RedeemPortalPrice { get; set; }

        [System.Xml.Serialization.XmlElement("ProductDetail")]
        public string ProductDetail { get; set; }

     

    }
}
