using Newtonsoft.Json;
using System.Xml;

namespace Jeliel.Extensions
{
    public static class XmlMethods
    {
        /// <summary>
        /// Try get innner text into a xml node
        /// </summary>
        /// <param name="data">XmlNode data</param>
        /// <returns>string</returns>
        static public string TryGetInnerText(this XmlNode data)
        {
            if (data != null)
                return data.InnerText;
            else
                return string.Empty;
        }


        /// <summary>
        ///  To convert an XML node contained in string xml into a JSON string
        /// </summary>
        /// <param name="xml">xml</param>
        /// <returns>Json</returns>
        public static string ToJSON(this string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return JsonConvert.SerializeXmlNode(doc);
        }

        /// <summary>
        /// To convert JSON text contained in string json into an XML node
        /// </summary>
        /// <param name="json">Json</param>
        /// <returns>xml</returns>
        public static string ToXML(this string json)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
            return doc.ToString();
        }
    }
}
