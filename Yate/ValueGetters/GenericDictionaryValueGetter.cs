using System;
using System.Collections.Generic;
using System.Reflection;

namespace Yate.ValueGetters
{
    internal class GenericDictionaryValueGetter : ValueGetter
    {
        internal static GenericDictionaryValueGetter GetGenericDictionaryValueGetter(object target, string name)
        {
            Type dictionaryType = null;

            foreach (var interfaceType in target.GetType().GetInterfaces())
            {
                if (interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == typeof(IDictionary<,>) &&
                    interfaceType.GetGenericArguments()[0] == typeof(string))
                {
                    dictionaryType = interfaceType;

                    break;
                }
            }

            if (dictionaryType != null)
            {
                var containsKeyMethod = dictionaryType.GetMethod("ContainsKey");

                if ((bool)containsKeyMethod.Invoke(target, new object[] { name }))
                {
                    return new GenericDictionaryValueGetter(target, name, dictionaryType);
                }
            }

            return null;
        }

        private readonly object _target;
        private readonly string _key;
        private readonly MethodInfo _getMethod;

        private GenericDictionaryValueGetter(object target, string key, Type dictionaryType)
        {
            _target = target;
            _key = key;
            _getMethod = dictionaryType.GetMethod("get_Item");
        }

        public override object GetValue()
        {
            return _getMethod.Invoke(_target, new object[] { _key });
        }
    }
}