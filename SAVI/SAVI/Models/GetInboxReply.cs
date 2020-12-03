using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetInboxReply
    {
        [System.Xml.Serialization.XmlElement("GetInboxResult")]
        public List<IdValue> GetInboxResult { get; set; }

       
    }
}
