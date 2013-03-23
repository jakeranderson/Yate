using System;
using System.ComponentModel;

namespace Yate.ValueGetters
{
    internal class PropertyDescriptorValueGetter : ValueGetter
    {
        internal static PropertyDescriptorValueGetter GetPropertyDescriptorValueGetter(object target, string name)
        {
            if (target is ICustomTypeDescriptor)
            {
                var typeDescriptor = (ICustomTypeDescriptor)target;
                PropertyDescriptorCollection properties = typeDescriptor.GetProperties();

                foreach (PropertyDescriptor property in properties)
                {
                    if (String.Equals(property.Name, name, DefaultNameComparison))
                    {
                        return new PropertyDescriptorValueGetter(target, property);
                    }
                }
            }

            return null;
        }

        private readonly object _target;
        private readonly PropertyDescriptor _propertyDescriptor;

        private PropertyDescriptorValueGetter(object target, PropertyDescriptor propertyDescriptor)
        {
            _target = target;
            _propertyDescriptor = propertyDescriptor;
        }

        public override object GetValue()
        {
            return _propertyDescriptor.GetValue(_target);
        }
    }
}