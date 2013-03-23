using System;
using System.Collections.Generic;

namespace Yate.Sheets.Properties
{
    public class AttributePropertyBuilder : IPropertyBuilder<AttributeProperty>
    {
        public AttributeProperty Build(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (values.Count < 2)
            {
                throw new ArgumentException("values must have more 1 value", "values");
            }

            return new AttributeProperty(values[0], values[1]);
        }
    }
}