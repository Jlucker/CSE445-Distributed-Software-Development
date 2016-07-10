using System.Collections.Generic;
using System.Xml.Serialization;

namespace AddPerson
{
    [XmlRoot(ElementName = "Name")]
    public class Name
    {
        [XmlElement(ElementName = "First")]
        public string First { get; set; }
        [XmlElement(ElementName = "Last")]
        public string Last { get; set; }
    }

    [XmlRoot(ElementName = "Password")]
    public class Password
    {
        [XmlElement(ElementName = "PasswordValue")]
        public string PasswordValue { get; set; }
        [XmlAttribute(AttributeName = "Encryption")]
        public string Encryption { get; set; }
    }

    [XmlRoot(ElementName = "Credential")]
    public class Credential
    {
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "Password")]
        public Password Password { get; set; }
    }

    [XmlRoot(ElementName = "Cell")]
    public class Cell
    {
        [XmlElement(ElementName = "CellNumber")]
        public string CellNumber { get; set; }
        [XmlAttribute(AttributeName = "Provider")]
        public string Provider { get; set; }
    }

    [XmlRoot(ElementName = "Phone")]
    public class Phone
    {
        [XmlElement(ElementName = "Work")]
        public string Work { get; set; }
        [XmlElement(ElementName = "Cell")]
        public Cell Cell { get; set; }
    }

    [XmlRoot(ElementName = "Category")]
    public class Category
    {
        [XmlAttribute(AttributeName = "CategoryValue")]
        public string CategoryValue { get; set; }
    }

    [XmlRoot(ElementName = "Person")]
    public class Person
    {
        [XmlElement(ElementName = "Name")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
        [XmlElement(ElementName = "Phone")]
        public Phone Phone { get; set; }
        [XmlElement(ElementName = "Category")]
        public Category Category { get; set; }
    }

    [XmlRoot(ElementName = "Persons")]
    public class Persons
    {
        [XmlElement(ElementName = "Person")]
        public List<Person> Person { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }


}
