using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetBanksReply
    {
        [System.Xml.Serialization.XmlElement("GetBanksResult")]
        public List<IdValue> GetBanksResult { get; set; }

       
    }
}
