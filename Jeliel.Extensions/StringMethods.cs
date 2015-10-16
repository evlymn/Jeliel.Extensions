using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Jeliel.Extensions
{
    /// <summary>
    /// String methods
    /// </summary>
    public static class StringMethods
    {
        /// <summary>
        /// Capitalize a string
        /// </summary>
        /// <param name="s">string</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>Capitalized string</returns>
        static public string Capitalize(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
        }


        /// <summary>
        /// Split and remove empty entries
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="separator">string</param>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <returns>Array of string</returns>
        static public string[] Split(this String s, string separator)
        {
            return s.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }


        /// <summary>
        /// Remove special characters from a string
        /// </summary>
        /// <param name="data">String data</param>
        /// <returns>string</returns>
        static public string RemoveSpecialCharacters(this String data)
        {
            char[] buffer = new char[data.Length];
            int idx = 0;
            //|| (c == '.') || (c == '_')
            foreach (char c in data)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z'))
                {
                    buffer[idx] = c;
                    idx++;
                }
            }

            return new string(buffer, 0, idx);
        }


        /// <summary>
        /// Return MD5 hash
        /// </summary>
        /// <param name="value">String</param>
        /// <returns>Strig</returns>
        public static string ToMD5(this string value)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(value);
            byte[] hash = md5.ComputeHash(inputBytes);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }


        /// <summary>
        /// Join a StringBuilder with a separator
        /// </summary>
        /// <param name="stringBuilder">StringBuilder</param>
        /// <param name="separator">Separator</param>
        /// <returns>string</returns>
        public static string Join(this StringBuilder stringBuilder, string separator)
        {
            if (stringBuilder == null) return String.Empty;

            var list = new List<string>();
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                list.Add(stringBuilder[i].ToString());
            }

            return String.Join(separator, list.ToArray());
        }
    }
}
