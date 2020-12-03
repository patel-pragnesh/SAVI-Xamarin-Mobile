using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetBrandsReply
    {
        [System.Xml.Serialization.XmlElement("GetBrandsResult")]
        public List<IdValue> GetBrandsResult { get; set; }

       
    }
}
