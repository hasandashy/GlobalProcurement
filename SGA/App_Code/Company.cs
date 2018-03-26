using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SGA.App_Code
{
    [Serializable, XmlRoot("company")]
    public class Company
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }

    [Serializable, XmlRoot("companies")]
    public class CompanyCollection
    {
        [System.Xml.Serialization.XmlElementAttribute("company")]
        public Company[] Companies { get; set; }
    }
}