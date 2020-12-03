using System;

namespace SAVI.Models
{
    [Serializable()]
    public class GetBankingDetailReply
    {
        [System.Xml.Serialization.XmlElement("BankID")]
        public string BankID { get; set; }

        [System.Xml.Serialization.XmlElement("BankName")]
        public string BankName { get; set; }

        [System.Xml.Serialization.XmlElement("BankSourceID")]
        public string BankSourceID { get; set; }

        [System.Xml.Serialization.XmlElement("DateCreated")]
        public string DateCreated { get; set; }

        [System.Xml.Serialization.XmlElement("Active")]
        public string Active { get; set; }

        [System.Xml.Serialization.XmlElement("RecipientAccount")]
        public string RecipientAccount { get; set; }

        [System.Xml.Serialization.XmlElement("RecipientAccountType")]
        public string RecipientAccountType { get; set; }

        [System.Xml.Serialization.XmlElement("BranchCode")]
        public string BranchCode { get; set; }

     
    }
}
