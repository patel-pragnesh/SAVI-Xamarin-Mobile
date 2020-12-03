using System;
using System.Collections.Generic;
using System.Text;

namespace SAVI.Models
{
    [Serializable()]
    public class Registration
    {

        [System.Xml.Serialization.XmlElement("RegistrationID")]
        public string RegistrationID { get; set; }

        [System.Xml.Serialization.XmlElement("CompanyTradingName")]
        public string CompanyTradingName { get; set; }

        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("Surname")]
        public string Surname { get; set; }

        [System.Xml.Serialization.XmlElement("ContactNumber")]
        public string ContactNumber { get; set; }

        [System.Xml.Serialization.XmlElement("ContactEmail")]
        public string ContactEmail { get; set; }

        [System.Xml.Serialization.XmlElement("IdType")]
        public string IdType { get; set; }

        [System.Xml.Serialization.XmlElement("IdNumber")]
        public string IdNumber { get; set; }

        [System.Xml.Serialization.XmlElement("StoreID")]
        public string StoreID { get; set; }

        [System.Xml.Serialization.XmlElement("CompanyID")]
        public string CompanyID { get; set; }

        [System.Xml.Serialization.XmlElement("BankID")]
        public string BankID { get; set; }

        [System.Xml.Serialization.XmlElement("Username")]
        public string Username { get; set; }

        [System.Xml.Serialization.XmlElement("Password")]
        public string Password { get; set; }

        [System.Xml.Serialization.XmlElement("AccountNum")]
        public string AccountNum { get; set; }

        [System.Xml.Serialization.XmlElement("IdImage")]
        public string IdImage { get; set; }

        [System.Xml.Serialization.XmlElement("AddressImage")]
        public string AddressImage { get; set; }

        [System.Xml.Serialization.XmlElement("Title")]
        public string Title { get; set; }

        [System.Xml.Serialization.XmlElement("MiddleName")]
        public string MiddleName { get; set; }

        [System.Xml.Serialization.XmlElement("IdVerified")]
        public string IdVerified { get; set; }

        [System.Xml.Serialization.XmlElement("AddressVerified")]
        public string AddressVerified { get; set; }

        [System.Xml.Serialization.XmlElement("IdDisputed")]
        public string IdDisputed { get; set; }

        [System.Xml.Serialization.XmlElement("AddressDisputed")]
        public string AddressDisputed { get; set; }

        [System.Xml.Serialization.XmlElement("AdvertCounter")]
        public string AdvertCounter { get; set; }

        [System.Xml.Serialization.XmlElement("Nationality")]
        public string Nationality { get; set; }
    }
}
