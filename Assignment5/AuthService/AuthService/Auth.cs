using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AuthService
{
    [XmlRoot(ElementName = "Auth")]
    public class Auth
    {
        [XmlElement(ElementName = "Username")]
        public string Username { get; set; }

        [XmlElement(ElementName = "Password")]
        public string Password { get; set; }

        [XmlElement(ElementName = "Uid")]
        public string Uid { get; set; }

        [XmlElement(ElementName = "UserType")]
        public string UserType { get; set; }
    }

    [XmlRoot(ElementName = "Auths")]
    public class Auths
    {
        [XmlElement(ElementName = "Auth")]
        public List<Auth> Auth { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }
}