using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetPaymentTypesReply
    {
        [System.Xml.Serialization.XmlElement("GetPaymentTypesResult")]
        public List<IdValue> GetPaymentTypesResult { get; set; }

       
    }
}
