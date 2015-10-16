using System;
using System.Reflection;

namespace Jeliel.Extensions
{ /// <summary>
  /// Instance Class Methods
  /// </summary>
    public static class InstanceClassMethods
    {
        /// <summary>
        /// Set field value
        /// </summary>
        /// <param name="O">this object</param>
        /// <param name="name">Field name</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <param name="value">value</param>
        static public void SetFieldValue(this object O, string name, object value)
        {
            O.GetType().GetField(name).SetValue(O, value);
        }

        /// <summary>
        ///  Get the value from a field
        /// </summary>
        /// <param name="O">this object</param>      
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <param name="name">Field name</param>
        static public object GetFieldValue(this object O, string name)
        {
            return O.GetType().GetField(name).GetValue(O);
        }

        /// <summary>
        /// Return true if the type is a System.Nullable wrapper of a value type
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <returns>True if the type is a System.Nullable wrapper</returns>
        public static bool IsNullable(this Type type)
        {
            return type.IsGenericType
                   && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Get the PropertyInfo from an object by name
        /// </summary>
        /// <param name="o">this object</param>
        /// <param name="name">property name</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <returns>PropertyInfo</returns>
        static public PropertyInfo GetPropertyInfo(this object o, string name)
        {
            return o.GetType().GetProperty(name);
        }

        /// <summary>
        /// Get the PropertyInfo from an object by name and return type
        /// </summary>
        /// <param name="o">this object</param>
        /// <param name="name">Property name</param>
        /// <param name="type">Type type</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <returns>PropertyInfo</returns>
        static public PropertyInfo GetPropertyInfo(this object o, string name, Type type)
        {
            return o.GetType().GetProperty(name, type);
        }

        /// <summary>
        /// Set the property value by name
        /// </summary>
        /// <param name="o">this object</param>
        /// <param name="name">property name</param>
        /// <param name="value">object value</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        static public void SetPropertyValue(this object o, string name, object value)
        {
            o.GetType().GetProperty(name).SetValue(o, value, null);
        }

        /// <summary>
        ///  Set the property value by index
        /// </summary>
        /// <param name="o">this object</param>
        /// <param name="index">Property index</param>
        /// <param name="value">object value</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        static public void SetPropertyValue(this object o, int index, object value)
        {
            o.GetType().GetProperties()[index].SetValue(o, value, null);
        }

        /// <summary>
        /// Get the value from a property by name
        /// </summary>
        /// <param name="O">this object</param>
        /// <param name="name">property name</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <returns>object</returns>
        static public object GetPropertyValue(this object O, string name)
        {
            object objRet = null;
            if (O.GetType().GetProperty(name) != null)
                objRet = O.GetType().GetProperty(name).GetValue(O, null);

            return objRet;
        }

        /// <summary>
        /// Get the value from a property by index
        /// </summary>
        /// <param name="O">this object</param>
        /// <param name="index">property index</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <returns>object</returns>
        static public object GetPropertyValue(this object O, int index)
        {
            object objRet = null;
            if (O.GetType().GetProperties()[index] != null)
                objRet = O.GetType().GetProperties()[index].GetValue(O, null);

            return objRet;
        }

        /// <summary>
        /// Get the type from a property
        /// </summary>
        /// <param name="O">this object</param>
        /// <param name="name">Property Name</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <returns>Type</returns>
        static public Type GetPropertyType(this object O, string name)
        {
            return O.GetType().GetProperty(name).PropertyType;
        }

        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="O">object</param>
        /// <param name="name">Method name</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <returns>object</returns>
        static public object InvokeMethod(this object O, string name)
        {
            return O.GetType().GetMethod(name, Type.EmptyTypes).Invoke(O, null);
        }

        /// <summary>
        /// Get MethodInfo by name
        /// </summary>
        /// <param name="O">object</param>
        /// <param name="Name">nome do método</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <returns>MethodInfo</returns>
        static public MethodInfo GetMethodInfo(this object O, string Name)
        {
            return O.GetType().GetMethod(Name, Type.EmptyTypes);
        }

        /// <summary>
        /// Get MethodInfo by name and types
        /// </summary>
        /// <param name="O">this object</param>
        /// <param name="name">Method name</param>
        /// <param name="types">array of types</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <returns>MethodInfo</returns>
        static public MethodInfo GetMethodInfo(this object O, string name, Type[] types)
        {
            return O.GetType().GetMethod(name, types);
        }

        /// <summary>
        /// Invoke method by name and parameters
        /// </summary>
        /// <param name="O">this object</param>
        /// <param name="Name">nome do método</param>
        /// <param name="parameters">array of parameters</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <returns>object</returns>
        static public object InvokeMethod(this object O, string Name, object[] parameters)
        {
            return O.GetType().GetMethod(Name).Invoke(O, parameters);
        }

        /// <summary>
        /// Invoke method by name and types
        /// </summary>
        /// <param name="O">object</param>
        /// <param name="name">method name</param>
        /// <param name="types">array of types</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <returns>object</returns>
        static public object InvokeMethod(this object O, string Name, Type[] Types)
        {
            return O.GetType().GetMethod(Name, Types).Invoke(O, null);
        }

        /// <summary>
        /// Invoke method by name, types and parameters
        /// </summary>
        /// <param name="O">this object</param>
        /// <param name="name">method name</param>
        /// <param name="types">array of types</param>
        /// <param name="parameters">array of parameters</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.MethodAccessException"></exception>
        /// <exception cref="System.Reflection.AmbiguousMatchException"></exception>
        /// <exception cref="System.Reflection.TargetException"></exception>
        /// <exception cref="System.Reflection.TargetParameterCountException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <returns>object</returns>
        static public object InvokeMethod(this object O, string name, Type[] types, object[] parameters)
        {
            Type t = O.GetType();
            MethodInfo m = t.GetMethod(name, types);
            object o = m.Invoke(O, parameters);
            return o;
        }
    }
}
