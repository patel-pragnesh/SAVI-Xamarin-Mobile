using System;

namespace SAVI.Models
{
        [Serializable()]
        public class LoginReply
        {
            [System.Xml.Serialization.XmlElement("LoginResult")]
            public string LoginResult { get; set; }
           
        }
  
}
