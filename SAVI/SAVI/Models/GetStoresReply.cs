using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetStoresReply
    {
        [System.Xml.Serialization.XmlElement("GetStoresResult")]
        public List<IdValue> GetStoresResult { get; set; }

       
    }
}
