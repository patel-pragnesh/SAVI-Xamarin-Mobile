using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetDisputesReply
    {
        [System.Xml.Serialization.XmlElement("GetDisputesResult")]
        public List<IdValue> GetDisputesResult { get; set; }

       
    }
}
