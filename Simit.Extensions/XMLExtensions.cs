namespace Minovex.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class XMLExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// Longs the list to element.
        /// </summary>
        /// <param name="IDList">The identifier list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">IDList
        /// or
        /// IDList must be contains any items</exception>
        public static XElement LongListToElement(this List<long> IDList)
        {
            if (IDList == null) throw new ArgumentNullException("IDList");
            if (IDList != null && IDList.Count == 0) throw new ArgumentNullException("IDList must be contains any items");

            XElement[] itemList = (from f in IDList select new XElement("i", f)).ToArray();

            XElement item = new XElement("ids", itemList);
            return item;
        }

        /// <summary>
        /// Integers the list to element.
        /// </summary>
        /// <param name="IDList">The identifier list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">IDList
        /// or
        /// IDList must be contains any items</exception>
        public static XElement IntegerListToElement(this List<int> IDList)
        {
            if (IDList == null) throw new ArgumentNullException("IDList");
            if (IDList != null && IDList.Count == 0) throw new ArgumentNullException("IDList must be contains any items");

            XElement[] itemList = (from f in IDList select new XElement("i", f)).ToArray();

            XElement item = new XElement("ids", itemList);
            return item;
        }

        /// <summary>
        /// To the SQL XML.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static SqlXml ToSqlXml(this XElement element)
        {
            StringReader xmlContent = new StringReader(element.ToString());
            XmlTextReader xmlReader = new XmlTextReader(xmlContent);
            return new SqlXml(xmlReader);
        }

        /// <summary>
        /// To the SQL XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static SqlXml ToSqlXml(this string xml)
        {
            StringReader xmlContent = new StringReader(xml);
            XmlTextReader xmlReader = new XmlTextReader(xmlContent);
            return new SqlXml(xmlReader);
        }

        /// <summary>
        /// To the XML document.
        /// </summary>
        /// <param name="xDocument">The x document.</param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        /// <summary>
        /// To the x document.
        /// </summary>
        /// <param name="xmlDocument">The XML document.</param>
        /// <returns></returns>
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

        #endregion Public Static Methods
    }
}