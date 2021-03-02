using System;

namespace SAVI.Models
{
        [Serializable()]
        public class ForgetPasswordReply
    {
            [System.Xml.Serialization.XmlElement("ForgotPasswordResult")]
            public string ForgotPasswordResult { get; set; }
           
        }
  
}
