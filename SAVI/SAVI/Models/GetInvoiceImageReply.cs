using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetInvoiceImageReply
    {
        [System.Xml.Serialization.XmlElement("GetInvoiceImageResult")]
        public string GetInvoiceImageResult { get; set; }

       
    }
}
