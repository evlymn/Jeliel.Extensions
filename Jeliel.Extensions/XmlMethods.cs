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
    }
}
