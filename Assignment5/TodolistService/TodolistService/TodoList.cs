using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TodolistService
{
    [XmlRoot(ElementName = "TodoItem")]
    public class TodoItem
    {
        [XmlElement(ElementName = "GlobalID")]
        public string GlobalID { get; set; }

        [XmlElement(ElementName = "ListID")]
        public string ListID { get; set; }

        [XmlElement(ElementName = "ListLabel")]
        public string ListLabel { get; set; }

        [XmlElement(ElementName = "ListDateCreated")]
        public string ListDateCreated { get; set; }

        [XmlElement(ElementName = "ItemID")]
        public string ItemID { get; set; }

        [XmlElement(ElementName = "ItemLabel")]
        public string ItemLabel { get; set; }

        [XmlElement(ElementName = "ItemDateCreated")]
        public string ItemDateCreated { get; set; }

        [XmlElement(ElementName = "ItemDueDate")]
        public string ItemDueDate { get; set; }

        [XmlElement(ElementName = "ItemNotes")]
        public string ItemNotes { get; set; }

        [XmlElement(ElementName = "ItemComplete")]
        public string ItemComplete { get; set; }
    }

    [XmlRoot(ElementName = "TodoList")]
    public class TodoList
    {
        [XmlElement(ElementName = "TodoItem")]
        public List<TodoItem> TodoItem { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
    }
}