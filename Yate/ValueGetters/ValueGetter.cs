using System;
using System.Reflection;

namespace Yate.ValueGetters
{
    //Talen from https://github.com/jdiamond/Nustache/blob/master/Nustache.Core/ValueGetter.cs
    //add all the other getters in this namespace
    public abstract class ValueGetter
    {
        public static readonly object NoValue = new object();

        #region Static helper methods

        public static object GetValue(object target, string name)
        {
            return GetValueGetter(target, name).GetValue();
        }

        private static ValueGetter GetValueGetter(object target, string name)
        {
            return XmlNodeValueGetter.GetXmlNodeValueGetter(target, name)
                   ?? PropertyDescriptorValueGetter.GetPropertyDescriptorValueGetter(target, name)
                   ?? GenericDictionaryValueGetter.GetGenericDictionaryValueGetter(target, name)
                   ?? DictionaryValueGetter.GetDictionaryValueGetter(target, name)
                   ?? MethodInfoValueGetter.GetMethodInfoValueGetter(target, name)
                   ?? PropertyInfoValueGetter.GetPropertyInfoValueGetter(target, name)
                   ?? FieldInfoValueGetter.GetFieldInfoValueGetter(target, name)
                   ?? (ValueGetter)new NoValueGetter();
        }

        #endregion

        #region Abstract methods

        public abstract object GetValue();

        #endregion

        #region Constants for derived classes that use reflection

        protected const BindingFlags DefaultBindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;
        protected const StringComparison DefaultNameComparison = StringComparison.CurrentCultureIgnoreCase;

        #endregion
    }
}