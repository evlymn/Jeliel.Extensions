using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.UI.WebControls;

namespace Jeliel.Extensions
{
    /// <summary>
    /// Conversion Methods Class
    /// </summary>
    public static class ConversionMethods
    {

        /// <summary>
        /// Returns an Object with the specified Type and whose value is equivalent to the specified object.
        /// </summary>
        /// <param name="value">An Object that implements the IConvertible interface.</param>
        /// <param name="T">The Type to which value is to be converted.</param>
        /// <returns>An object whose Type is conversionType (or conversionType's underlying type if conversionType
        /// is Nullable&lt;&gt;) and whose value is equivalent to value. -or- a null reference, if value is a null
        /// reference and conversionType is not a value type.</returns>
        /// <remarks>
        /// This method exists as a workaround to System.Convert.ChangeType(Object, Type) which does not handle
        /// nullables as of version 2.0 (2.0.50727.42) of the .NET Framework. The idea is that this method will
        /// be deleted once Convert.ChangeType is updated in a future version of the .NET Framework to handle
        /// nullable types, so we want this to behave as closely to Convert.ChangeType as possible.
        /// This method was written by Peter Johnson at:
        /// http://aspalliance.com/author.aspx?uId=1026.
        /// </remarks>
        static public object ChangeType(this Object value, Type T)
        {
            if (T == null)
                throw new ArgumentNullException("conversionType");

            if (T.IsGenericType && T.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                    return null;

                NullableConverter nullableConverter = new NullableConverter(T);
                T = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, T);
        }



       

        /// <summary>
        /// Convert an object to decimal
        /// <para>Converte um objeto para decimal</para>
        /// </summary>
        /// <param name="data">Object Data</param>
        /// <example>HTTP.Request["DECIMAIS"].ToDecimal()</example>   
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <exception cref="System.InvalidCastException">System.InvalidCastException</exception>
        /// <returns>Decimal</returns>
        static public Decimal ToDecimal(this Object data)
        {

            return Convert.ToDecimal(data);
        }

        /// <summary>
        /// Try convert to decimal
        /// </summary>
        /// <param name="data">Object Data</param>
        /// <param name="defaultValue">Return a default value if the conversion is not succeeded</param>
        /// <example>HTTP.Request["parameter"].ToDecimal(0)</example>   
        /// <returns>Decimal</returns>
        static public Decimal ToDecimal(this Object data, decimal defaultValue)
        {
            decimal.TryParse(data.ToString(), out defaultValue);
            return defaultValue;

        }

        /// <summary>
        /// Convert an object to float
        /// </summary>
        /// <param name="data">Object Data</param>
        /// <example>HTTP.Request["parameter"].ToFloat()</example>   
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>float</returns>
        static public float ToFloat(this Object data)
        {
            return float.Parse(data.ToString());
        }


        /// <summary>
        /// Convert to float specifying a culture
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="culture">CultureInfo</param>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns></returns>
        static public float ToFloat(this Object data, CultureInfo culture)
        {
            return float.Parse(data.ToString(), culture);
        }


        /// <summary>
        ///<para>Return false if object is null or the boxed string is different than 1 or true</para>
        ///<para>Retorna false se objeto passado for null se a string dentro dele for diferente de 1 ou true</para>
        /// </summary>
        /// <param name="O">Objeto</param>
        /// <returns>bool</returns>
        static public bool ToBool(this object O)
        {

            bool R = false;
            if (O == null)
                R = false;
            else if (O == DBNull.Value)
                R = false;
            else if (O.ToString().Trim() == "")
                R = false;
            else if (O.ToString().ToBool())
                R = true;
            return R;
        }

        /// <summary>
        ///  Return false if string is different than 1, true or is empty
        ///  <para>Retorna false se a string for diferente "1", "true" ou for vazia</para>
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>bool</returns>
        static public bool ToBool(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            bool Ret = false;
            if (s.Trim() == "1" || s.Trim().ToLower() == "true")
                Ret = true;
            return Ret;
        }

        /// <summary>
        /// Convert to unit
        /// </summary>
        /// <param name="O">this object</param>
        /// <exception cref="System.ArgumentOutOfRangeException">System.ArgumentOutOfRangeException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>Unit</returns>
        static public Unit ToUnit(this object O)
        {
            if (O.ToString().ToLower().Contains("px"))
                return new Unit(O.ToString());
            else
                return new Unit(O.ToString() + "px");
        }


        /// <summary>
        /// Convert to int16
        /// </summary>
        /// <param name="data">this object</param>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>Int16</returns>
        static public int ToInt16(this object data)
        {
            return Int16.Parse(data.ToString());
        }

        /// <summary>
        /// Convert to int16 with default int16 value
        /// </summary>
        /// <param name="o">this object</param>
        /// <param name="defaultValue">int default value</param>
        /// <returns>Int16</returns>
        static public short ToInt16(this object o, short defaultValue)
        {
            Int16.TryParse(o.ToString(), out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Convert to int32
        /// </summary>
        /// <param name="data">this object</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>Int32</returns>
        static public Int32 ToInt32(this object data)
        {
            return Int32.Parse(data.ToString());
        }

        /// <summary>
        /// Convert to int32 with NumberStyles
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="style">NumberStyles</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>Int32</returns>
        static public Int32 ToInt32(this object data, NumberStyles style)
        {
            return Int32.Parse(data.ToString(), style);
        }

        /// <summary>
        /// Convert to Int32 with IFormatProvider
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="provider">IFormatProvider</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>Int32</returns>
        static public Int32 ToInt32(this object data, IFormatProvider provider)
        {
            return Int32.Parse(data.ToString(), provider);
        }

        /// <summary>
        /// Convert to int32 with NumberStyles and IFormatProvider
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="style">NumberStyles</param>
        /// <param name="provider">IFormatProvider</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>In32</returns>
        static public Int32 ToInt32(this object data, NumberStyles style, IFormatProvider provider)
        {
            return Int32.Parse(data.ToString(), style, provider);
        }

        /// <summary>
        /// Convert to int32 with default value
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="defaultValue">int32 default value</param>
        /// <returns>Int32</returns>
        static public Int32 ToInt32(this object data, Int32 defaultValue)
        {
            Int32.TryParse(data.ToString(), out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Convert to int32 with NumberStyles, IFormatProvider and default value
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="style">NumberStyles</param>
        /// <param name="provider">IFormatProvider</param>
        /// <param name="defaultValue">int32 default value</param>
        /// <returns>Int32</returns>
        static public Int32 ToInt32(this object data, NumberStyles style, IFormatProvider provider, Int32 defaultValue)
        {
            Int32.TryParse(data.ToString(), style, provider, out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Convert to byte
        /// </summary>
        /// <param name="data">this object</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>byte</returns>
        static public byte ToByte(this object data)
        {
            return Byte.Parse(data.ToString());
        }

        /// <summary>
        /// Convert to byte with NumberStyles
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="style">NumberStyles</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>byte</returns>
        static public byte ToByte(this object data, NumberStyles style)
        {
            return Byte.Parse(data.ToString(), style);
        }

        /// <summary>
        /// Convert to byte with IFormatProvider
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="provider">IFormatProvider</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>byte</returns>
        static public byte ToByte(this object data, IFormatProvider provider)
        {
            return Byte.Parse(data.ToString(), provider);
        }


        /// <summary>
        /// Convert to byte with NumberStyles and IFormatProvider
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="style">NumberStyles</param>
        /// <param name="provider">IFormatProvider</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>byte</returns>
        static public byte ToByte(this object data, NumberStyles style, IFormatProvider provider)
        {
            return Byte.Parse(data.ToString(), style, provider);
        }

        /// <summary>
        /// Try parse object to byte[] else return default value
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="defaultValue">byte default value</param>
        /// <returns>byte</returns>
        static public byte ToByte(this object data, byte defaultValue)
        {
            Byte.TryParse(data.ToString(), out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Convert to byte with NumberStyles, IFormatProvider and default value
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="style">NumberStyles</param>
        /// <param name="provider">IFormatProvider</param>
        /// <param name="defaultValue">byte default value</param>
        /// <returns>byte</returns>
        static public byte ToByte(this object data, NumberStyles style, IFormatProvider provider, byte defaultValue)
        {
            Byte.TryParse(data.ToString(), style, provider, out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Convert to byte[]
        /// </summary>
        /// <param name="data">this object</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">System.Runtime.Serialization.SerializationException</exception>
        /// <exception cref="System.Security.SecurityException">System.Security.SecurityException</exception>
        /// <returns>byte[]</returns>
        static public byte[] ToByteArray(this object data)
        {
            if (data == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, data);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Conver to double
        /// </summary>
        /// <param name="data">this object</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>double</returns>
        static public double ToDouble(this object data)
        {
            return Double.Parse(data.ToString());
        }

        /// <summary>
        /// Convert to double with default value
        /// </summary>
        /// <param name="data">this object</param>
        /// <param name="defaultValue">double default value</param>
        /// <returns>double</returns>
        static public double ToDouble(this object data, double defaultValue)
        {
            double.TryParse(data.ToString(), out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Convert an object to Int64
        /// </summary>
        /// <param name="data"> object data</param>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>/// <returns>Int64</returns>
        static public Int64 ToInt64(this object data)
        {
            return Int64.Parse(data.ToString());
        }

        /// <summary>
        /// Convert an object to Int64 passing a default value
        /// </summary>
        /// <param name="data">object data</param>
        /// <param name="defaultValue">Int64 defaultValue</param>
        /// <returns>Int64</returns>
        static public Int64 ToInt64(this object data, Int64 defaultValue)
        {
            Int64.TryParse(data.ToString(), out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Convert an object to Single
        /// </summary>
        /// <param name="data">object data</param>
        /// <exception cref="System.InvalidCastException">System.InvalidCastException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>Single</returns>
        static public Single ToSingle(this object data)
        {
            return Convert.ToSingle(data);
        }


        /// <summary>
        /// Convert an object to Guid
        /// </summary>
        /// <param name="data">object data</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <returns>Guid</returns>
        static public Guid ToGuid(this object data)
        {
            Guid result = Guid.Parse(data.ToString());
            return result;

        }

        /// <summary>
        /// Convert an object to TimeSpan
        /// </summary>
        /// <param name="data"> object data</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <returns>TimeSpan</returns>
        static public TimeSpan ToTimeSpan(this object data)
        {
            return TimeSpan.Parse(data.ToString());
        }

        /// <summary>
        /// Get SqlDataReader field value tith default value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="reader">SqlDataReader</param>
        /// <param name="field">field name</param>
        /// <param name="defaultValue">object default value</param>
        /// <exception cref="System.InvalidCastException">System.InvalidCastException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>T</returns>
        static public T GetValue<T>(this System.Data.SqlClient.SqlDataReader reader, string field, object defaultValue)
        {
            if (reader[field] != DBNull.Value)
            {
                return (T)Convert.ChangeType(reader[field], typeof(T));
            }
            return (T)defaultValue;
        }

        /// <summary>
        /// Get SqlDataReader field value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="reader">SqlDataReader</param>
        /// <param name="field">field name</param>
        /// <exception cref="System.InvalidCastException">System.InvalidCastException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <exception cref="System.OverflowException">System.OverflowException</exception>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>T</returns>
        static public T GetValue<T>(this System.Data.SqlClient.SqlDataReader reader, string field)
        {
            return (T)Convert.ChangeType(reader[field], typeof(T));
        }

        /// <summary>
        /// Convert to datetime
        /// </summary>
        /// <param name="data">object data</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.FormatException">System.FormatException</exception>
        /// <returns>DateTime</returns>
        static public DateTime ToDateTime(this object data)
        {
            return DateTime.Parse(data.ToString());
        }

        /// <summary>
        /// Convert stream to byte[] 
        /// </summary>
        /// <param name="data">Stream data</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <exception cref="System.NotSupportedException">System.NotSupportedException</exception>
        /// <exception cref="System.ObjectDisposedException">System.ObjectDisposedException</exception>
        /// <exception cref="System.IO.IOException">System.IO.IOException</exception>
        /// <returns></returns>
        static public byte[] ToByteArray(this Stream data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                data.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
