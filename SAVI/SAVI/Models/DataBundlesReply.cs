using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class DataBundlesReply
    {
        [System.Xml.Serialization.XmlElement("GetAllDataBundlesResult")]
        public List<GetProductResponseDataBundles> ListOfDataBundles { get; set; }


    }
}
