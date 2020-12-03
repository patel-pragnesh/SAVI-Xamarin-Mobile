using System;
using System.Collections.Generic;

namespace SAVI.Models
{
    [Serializable()]
    public class GetMobilityRedemptionByAccNoNoVoucherReply
    {
        [System.Xml.Serialization.XmlElement("GetMobilityRedemptionByAccNoNoVoucherResult")]
        public List<Redemption3> GetMobilityRedemptionByAccNoNoVoucherResult { get; set; }
    }
}
