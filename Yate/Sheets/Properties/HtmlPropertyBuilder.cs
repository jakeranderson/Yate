using System;
using System.Collections.Generic;

namespace Yate.Sheets.Properties
{
    public class HtmlPropertyBuilder : IPropertyBuilder<HtmlProperty>
    {
        public HtmlProperty Build(IList<IValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (values.Count < 1)
            {
                throw new ArgumentException("values must have at least one value", "values");
            }

            return new HtmlProperty(values[0]);
        }
    }
}