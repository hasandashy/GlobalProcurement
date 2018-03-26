using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SGA.App_Code
{
    [Serializable, XmlRoot("person")]
    public class Person
    {
        [XmlElement("id")]
        public string id { get; set; }

        [XmlElement("first-name")]
        public string FirstName { get; set; }

        [XmlElement("last-name")]
        public string LastName { get; set; }

        [XmlElement("headline")]
        public string headLine { get; set; }

        [XmlElement("public-profile-url")]
        public string ProfileUrl { get; set; }

        [XmlElement("email-address")]
        public string Email { get; set; }
    }

    

    [Serializable]
    public class People
    {
        [System.Xml.Serialization.XmlElement("person")]
        public Person[] Persons { get; set; }

        [XmlAttribute("total")]
        public int Total { get; set; }

        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("start")]
        public int Start { get; set; }
    }

    [Serializable, XmlRoot("people-search")]
    public class PeopleSearchresult
    {
        [XmlElement("people")]
        public People People { get; set; }

        [XmlElement("num-results")]
        public int Count { get; set; }
    }
}