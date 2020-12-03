using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class ArrayOfIdValue
    {
        [System.Xml.Serialization.XmlElement("ArrayOfIdValue")]
        public List<IdValue> getIdValue { get; set; }

       
    }
}

