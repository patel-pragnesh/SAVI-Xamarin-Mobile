using System;

namespace SAVI.Models
{
    [Serializable()]
    public class GetPromotionByIDReply
    {
        [System.Xml.Serialization.XmlElement("PromotionID")]
        public string PromotionID { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionName")]
        public string PromotionName { get; set; }

        [System.Xml.Serialization.XmlElement("CreatedDate")]
        public string CreatedDate { get; set; }

        [System.Xml.Serialization.XmlElement("ModifiedDate")]
        public string ModifiedDate { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionStartDate")]
        public string PromotionStartDate { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionEndDate")]
        public string PromotionEndDate { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionIndefinitly")]
        public string PromotionIndefinitly { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionValue")]
        public string PromotionValue { get; set; }

        [System.Xml.Serialization.XmlElement("Voucher")]
        public string Voucher { get; set; }

        [System.Xml.Serialization.XmlElement("IMEI")]
        public string IMEI { get; set; }

        [System.Xml.Serialization.XmlElement("Deleted")]
        public string Deleted { get; set; }

        [System.Xml.Serialization.XmlElement("Threshold")]
        public string Threshold { get; set; }

        [System.Xml.Serialization.XmlElement("AboveThreshold")]
        public string AboveThreshold { get; set; }

        [System.Xml.Serialization.XmlElement("BelowThreshold")]
        public string BelowThreshold { get; set; }

        [System.Xml.Serialization.XmlElement("Discount")]
        public string Discount { get; set; }

        [System.Xml.Serialization.XmlElement("CelcomPayAccount")]
        public string CelcomPayAccount { get; set; }

        [System.Xml.Serialization.XmlElement("VoucherCode")]
        public string VoucherCode { get; set; }

        [System.Xml.Serialization.XmlElement("GiftAccount")]
        public string GiftAccount { get; set; }

        [System.Xml.Serialization.XmlElement("PastelOrders")]
        public string PastelOrders { get; set; }

        [System.Xml.Serialization.XmlElement("OnlinePayAccount")]
        public string OnlinePayAccount { get; set; }

        [System.Xml.Serialization.XmlElement("PromotionProduct")]
        public string PromotionProduct { get; set; }


    }
}
