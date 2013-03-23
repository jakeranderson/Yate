using System.Collections;

namespace Yate.ValueGetters
{
    internal class DictionaryValueGetter : ValueGetter
    {
        internal static DictionaryValueGetter GetDictionaryValueGetter(object target, string name)
        {
            if (target is IDictionary)
            {
                var dictionary = (IDictionary)target;

                if (dictionary.Contains(name))
                {
                    return new DictionaryValueGetter(dictionary, name);
                }
            }

            return null;
        }

        private readonly IDictionary _target;
        private readonly string _key;

        private DictionaryValueGetter(IDictionary target, string key)
        {
            _target = target;
            _key = key;
        }

        public override object GetValue()
        {
            return _target[_key];
        }
    }
}