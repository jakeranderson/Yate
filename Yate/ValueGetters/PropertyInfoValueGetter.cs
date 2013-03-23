using System.Reflection;

namespace Yate.ValueGetters
{
    internal class PropertyInfoValueGetter : ValueGetter
    {
        internal static PropertyInfoValueGetter GetPropertyInfoValueGetter(object target, string name)
        {
            PropertyInfo property = target.GetType().GetProperty(name, DefaultBindingFlags);

            if (property != null && PropertyCanGetValue(property))
            {
                return new PropertyInfoValueGetter(target, property);
            }

            return null;
        }

        private static bool PropertyCanGetValue(PropertyInfo property)
        {
            return property.CanRead;
        }

        private readonly object _target;
        private readonly PropertyInfo _propertyInfo;

        private PropertyInfoValueGetter(object target, PropertyInfo propertyInfo)
        {
            _target = target;
            _propertyInfo = propertyInfo;
        }

        public override object GetValue()
        {
            return _propertyInfo.GetValue(_target, null);
        }
    }
}