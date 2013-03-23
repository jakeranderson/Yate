using System;
using System.Collections.Generic;

namespace Yate.Sheets.Properties
{
    public class FormatTextPropertyBuilder : IPropertyBuilder<FormatTextProperty>
    {
        public FormatTextProperty Build(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (values.Count == 0)
            {
                throw new ArgumentException("values did not have enought parameters", "values");
            }

            if (values.Count == 1)
            {
                return new FormatTextProperty(values[0]);
            }

            return new FormatTextProperty(values[0], values[1]);
        }
    }
}