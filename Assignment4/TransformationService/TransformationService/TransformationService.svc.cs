using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace TransformationService
{
    public class TransformationService : ITransformationService
    {
        /// <summary>
        /// Converts the uploaded content into XML docs and then performs the transformation
        /// </summary>
        /// <param name="upload"></param>
        /// <returns>Formatted HTML from the specified XML+XSL doc</returns>
        public string TransformXml(Upload upload)
        {
            var xml = GetXmlResource(upload);
            var xsl = GetXslResource(upload);
            var html = TransformToHtml(xml, xsl);
            return html;
        }

        /// <summary>
        /// Transforms the XML doc to HTML using the specified XSL doc
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="xsl"></param>
        /// <returns>Formatted HTML from the specified XML+XSL doc</returns>
        private string TransformToHtml(XmlDocument xml, XmlDocument xsl)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsl);
            using (MemoryStream stream = new MemoryStream())
            {
                xslt.Transform(xml, null, stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// code1 == 1 - string containing XML - Raw XML
        /// code1 == 2 - string containg XML - From File
        /// code1 == 3 - url to XML file
        /// </summary>
        /// <param name="upload"></param>
        /// <returns>Returns a formatted XmlDocument object for the XML</returns>
        private XmlDocument GetXmlResource(Upload upload)
        {
            if (upload.code1 == 1)
            {
                return ConvertStringToXmlDoc(upload.xmlRaw);
            } 
            else if (upload.code1 == 2)
            {
                return ConvertStringToXmlDoc(upload.xmlFileContent);
            }
            else if (upload.code1 == 3)
            {
                return GetRemoteXmlFile(upload.xmlUrl);
            }
            else
            {
                XmlDocument emptyDoc = new XmlDocument();
                return emptyDoc;
            }
        }

        /// <summary>
        /// code1 == 1 - string containing XML - Raw XML
        /// code1 == 2 - string containg XML - From File
        /// code1 == 3 - url to XML file
        /// </summary>
        /// <param name="upload"></param>
        /// <returns>Returns a formatted XmlDocument object for the XSL</returns>
        private XmlDocument GetXslResource(Upload upload)
        {
            if (upload.code2 == 1)
            {
                return ConvertStringToXmlDoc(upload.xslRaw);
            }
            else if (upload.code2 == 2)
            {
                return ConvertStringToXmlDoc(upload.xslFileContent);
            }
            else if (upload.code2 == 3)
            {
                return GetRemoteXmlFile(upload.xslUrl);
            }
            else
            {
                XmlDocument emptyDoc = new XmlDocument();
                return emptyDoc;
            }
        }

        /// <summary>
        /// Converts the supplied XML string to an XML doc
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns>Returns a formatted XML doc</returns>
        private XmlDocument ConvertStringToXmlDoc(string xmlString)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);
                return xml;
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error: ConvertStringToXmlDoc \n" + e);
            }
            XmlDocument xmlEmpty = new XmlDocument();
            return xmlEmpty;
        }
        /// <summary>
        /// Gets the remote XML doc from the specified URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Formatted XML doc</returns>
        private XmlDocument GetRemoteXmlFile(string url)
        {
            XmlDocument remoteDoc = new XmlDocument();
            try
            {
                remoteDoc.Load(url);
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error occured while accessing remote file \n" + e);
            }
            return remoteDoc;
        }
    }
}
