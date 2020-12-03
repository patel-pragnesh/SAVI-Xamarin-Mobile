using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GeteWalletParmsReply
    {
        [System.Xml.Serialization.XmlElement("GeteWalletParmsResult")]
        public IdValue GeteWalletParmsResult { get; set; }

       
    }
}
