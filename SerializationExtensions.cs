namespace Simit.Extensions
{
    #region Using Directives

    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    #endregion Using Directives

    /// <summary>
    ///
    /// </summary>
    public static class SerializationExtensions
    {
        #region Public Static Methods

        /// <summary>
        /// XMLs the serialize to string.
        /// </summary>
        /// <param name="objectInstance">The object instance.</param>
        /// <returns></returns>
        public static string XmlSerializeToString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }
            return sb.ToString();
        }

        /// <summary>
        /// XMLs the deserialize from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectData">The object data.</param>
        /// <returns></returns>
        public static T XmlDeserializeFromString<T>(this string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        /// <summary>
        /// XMLs the deserialize from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectData">The object data.</param>
        /// <param name="rootElementName">Name of the root element.</param>
        /// <returns></returns>
        public static T XmlDeserializeFromString<T>(this string objectData, string rootElementName)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T), rootElementName);
        }

        /// <summary>
        /// XMLs the deserialize from string.
        /// </summary>
        /// <param name="objectData">The object data.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object XmlDeserializeFromString(this string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }
            return result;
        }

        /// <summary>
        /// XMLs the deserialize from string.
        /// </summary>
        /// <param name="objectData">The object data.</param>
        /// <param name="type">The type.</param>
        /// <param name="rootElementName">Name of the root element.</param>
        /// <returns></returns>
        public static object XmlDeserializeFromString(this string objectData, Type type, string rootElementName)
        {
            var serializer = new XmlSerializer(type, new XmlRootAttribute(rootElementName));
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                //TODO deserialization events dene
                try
                {
                    result = serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// Serializes as x element.
        /// </summary>
        /// <param name="objectInstance">The object instance.</param>
        /// <returns></returns>
        public static XElement SerializeAsXElement(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            XDocument d = new XDocument();
            using (XmlWriter w = d.CreateWriter()) serializer.Serialize(w, objectInstance);
            XElement e = d.Root;
            e.Remove();
            return e;
        }

        /// <summary>
        /// Serializes to XML file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="mode">The mode.</param>
        public static void SerializeToXmlFile<T>(this T obj, string filePath, FileMode mode) where T : class
        {
            FileStream fileStream = default(FileStream);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                fileStream = new FileStream(filePath, mode);
                serializer.Serialize(fileStream, obj);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                fileStream.Close();
            }
        }

        #endregion Public Static Methods
    }
}